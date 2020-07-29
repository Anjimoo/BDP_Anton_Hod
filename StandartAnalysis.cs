using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDataReader;
using System.Diagnostics;

namespace BDP_Anton_Hod
{
    class StandartAnalysis
    {
        public string FileName { get; set; }
       
        public StandartAnalysis(string fileName)
        {
            this.FileName = fileName;
        }

        public void analyse(System.Windows.Controls.TextBlock consoleTextBlock)
        {
            // get Excel file reference
            var reader = ExcelFile.openExcelFile(this.FileName);
            // get string with Years with maximum and minimum precipitation
            string yearMinMax = getMinMaxPrecipYear(reader);
            consoleTextBlock.Text += "\n" + yearMinMax;
            // get string with Month/Year with maximuk and minimum precipitation
            string monthYearMinMax = getMinMaxPrecipMonthYear(reader);
            consoleTextBlock.Text += "\n" + monthYearMinMax;
        }

        private string getMinMaxPrecipYear(IExcelDataReader reader)
        {
            Dictionary<double, double> yearsPrecipitationDict = new Dictionary<double, double>();
            
            double precipitationForYear = 0;
            // read every line in ExcelFile
            while (reader.Read())
            {
                // for each column(month) add precipitation of the month
                // to calculate precipitation in year
                for (int i = 1; i < 13; i++)
                {
                    precipitationForYear += reader.GetDouble(i);
                }
                yearsPrecipitationDict.Add(reader.GetDouble(0), precipitationForYear);

                precipitationForYear = 0;
            }
            // find years with maximum and minimum precipitation
            var maxKey = yearsPrecipitationDict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            var minKey = yearsPrecipitationDict.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
            // concatinate max and min keys and values 
            string maxPrecipitation = "Year with maximum precipitation is : " + maxKey.ToString() + ", Number of Precipitation is : " + yearsPrecipitationDict[maxKey];
            string minPrecipitation = "Year with minimum precipitation is : " + minKey.ToString() + ", Number of Precipitation is : " + yearsPrecipitationDict[minKey];
             
            return maxPrecipitation + "\n" + minPrecipitation;
        }

        private string getMinMaxPrecipMonthYear(IExcelDataReader reader)
        {


            return "";
        }

        private string getMinMaxSeasonYear(IExcelDataReader reader)
        {
            

            return "";
        }
    
    }
}

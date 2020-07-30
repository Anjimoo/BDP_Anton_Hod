using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDataReader;
using System.Diagnostics;
using System.Windows.Automation;

namespace BDP_Anton_Hod
{
    class StandartAnalysis
    {
        private string _fileName { get; set; }
        private List<YearlyPrecipitation> _rows;

        public int MaxPrecipitationYear { get; set; }
        public int MinPrecipitationYear { get; set; }

        public StandartAnalysis(string fileName)
        {
            _fileName = fileName;
        }

        public void Analyse()
        {
            _rows = FileParser.ParseFile(_fileName);

            SetMinMaxPrecipitationYears();
        }

        public void analyse(System.Windows.Controls.TextBlock consoleTextBlock)
        {
            // get Excel file reference
            var reader = FileParser.openExcelFile(this._fileName);
            // get string with Years with maximum and minimum precipitation
            string yearMinMax = getMinMaxPrecipYear(reader);
            consoleTextBlock.Text += "\n" + yearMinMax;
            // get string with Month/Year with maximum and minimum precipitation
            //string monthYearMinMax = getMinMaxPrecipMonthYear(reader);
            //consoleTextBlock.Text += "\n" + monthYearMinMax;
            // get string with Season?year with maximum and minimum precipitation
            string seasonYearMinMax = getMinMaxSeasonYear(reader);
            consoleTextBlock.Text += "\n" + seasonYearMinMax;
        }

        private void SetMinMaxPrecipitationYears()
        {
            // TODO
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
            string season;

            Dictionary<double, SortedDictionary<string, double>> yearMaxSeasonPrecipDict = new Dictionary<double, SortedDictionary<string, double>>();
            Dictionary<string, double> seasonsPrecipDict = new Dictionary<string, double>();
            Dictionary<double, SortedDictionary<string, double>> yearMinSeasonPrecipDict = new Dictionary<double, SortedDictionary<string, double>>();
            SortedDictionary<string, double> tempDict;

            seasonsPrecipDict.Add("winter", 0);
            seasonsPrecipDict.Add("spring", 0);
            seasonsPrecipDict.Add("summer", 0);
            seasonsPrecipDict.Add("autumn", 0);

            reader.Reset();
            while (reader.Read())
            {
                seasonsPrecipDict["winter"] = 0;
                seasonsPrecipDict["spring"] = 0;
                seasonsPrecipDict["summer"] = 0;
                seasonsPrecipDict["autumn"] = 0;
                for (int i = 1; i < 13; i++)
                {
                   
                    switch (i)
                    {
                        case int n when (n == 1 || n == 2 || n == 12):
                            seasonsPrecipDict["winter"] += reader.GetDouble(i);
                            break;
                        case int n when (n >= 3 && n <= 5):
                            seasonsPrecipDict["spring"] += reader.GetDouble(i);
                            break;
                        case int n when (n >= 6 && n <= 8):
                            seasonsPrecipDict["summer"] += reader.GetDouble(i);
                            break;
                        case int n when (n >= 9 && n <= 11):
                            seasonsPrecipDict["autumn"] += reader.GetDouble(i);
                            break;
                        default:
                            break;
                    }
                }
                season = seasonsPrecipDict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                tempDict = new SortedDictionary<string, double>();
                tempDict.Add(season, seasonsPrecipDict[season]);
                yearMaxSeasonPrecipDict.Add(reader.GetDouble(0), tempDict);

                season = seasonsPrecipDict.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
                tempDict = new SortedDictionary<string, double>();
                tempDict.Add(season, seasonsPrecipDict[season]);
                yearMinSeasonPrecipDict.Add(reader.GetDouble(0), tempDict);

            }

            var maxKey = yearMaxSeasonPrecipDict.Aggregate((x, y) => x.Value.First().Value > y.Value.First().Value ? x : y).Key;
            var minKey = yearMinSeasonPrecipDict.Aggregate((x, y) => x.Value.First().Value < y.Value.First().Value ? x : y).Key;

            string maximumSeason = "Season with most precipitation is : " + yearMaxSeasonPrecipDict[maxKey].First().Key + " and year is : " + maxKey +
                "\nNumber of precipitation in this season is : " + yearMaxSeasonPrecipDict[maxKey].First().Value; 
            string minimumSeason = "Season with least precipitation is : " + yearMinSeasonPrecipDict[minKey].First().Key + " and year is : " + minKey +
                "\nNumber of precipitation in this season is : " + yearMinSeasonPrecipDict[minKey].First().Value;

            return maximumSeason + "\n" + minimumSeason;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using ExcelDataReader;


namespace BDP_Anton_Hod
{
    static class FileParser
    {
        public static List<YearlyPrecipitation> ParseFile(string filePath)
        {
            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            List<YearlyPrecipitation> list = new List<YearlyPrecipitation>();
            
            while (reader.Read())
            {
                YearlyPrecipitation row = new YearlyPrecipitation
                {
                    Year = (int)reader.GetDouble(0),
                    WinterPrecipitation = new SeasonPrecipitation
                    {
                        Season = Season.Winter,
                        MonthlyPrecipitation =
                        {
                            { Month.December, reader.GetDouble(12) },
                            { Month.January, reader.GetDouble(1) },
                            { Month.February, reader.GetDouble(2) }
                        }
                    },
                    SpringPrecipitation = new SeasonPrecipitation
                    {
                        Season = Season.Spring,
                        MonthlyPrecipitation = 
                        {
                            { Month.March, reader.GetDouble(3) },
                            { Month.April, reader.GetDouble(4) },
                            { Month.May, reader.GetDouble(5) },
                        }
                    },
                    SummerPrecipitation = new SeasonPrecipitation
                    {
                        Season = Season.Summer,
                        MonthlyPrecipitation =
                        {
                            { Month.June, reader.GetDouble(6) },
                            { Month.July, reader.GetDouble(7) },
                            { Month.August, reader.GetDouble(8) }
                        }
                    },
                    AutumnPrecipitation = new SeasonPrecipitation
                    {
                        Season = Season.Autumn,
                        MonthlyPrecipitation =
                        {
                            { Month.September, reader.GetDouble(9) },
                            { Month.October, reader.GetDouble(10) },
                            { Month.November, reader.GetDouble(11) }
                        }
                    }
                };
            }

            return list;
        }

        public static IExcelDataReader openExcelFile(string fileName)
        {
            var stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);


            return reader;

        }
    }
}

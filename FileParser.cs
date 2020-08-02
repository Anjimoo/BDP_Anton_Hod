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
            // read line in Excel File
            while (reader.Read())
            {
                YearlyPrecipitation row = new YearlyPrecipitation // for each line in Excel create YearlPrecipitation object
                {
                    YearName = (int)reader.GetDouble(0), 
                    WinterPrecipitation = new SeasonPrecipitation 
                    {
                        SeasonName = Season.Winter,
                        MonthlyPrecipitation =
                        {
                            { Month.December, reader.GetDouble(12) },
                            { Month.January, reader.GetDouble(1) },
                            { Month.February, reader.GetDouble(2) }
                        }
                    },
                    SpringPrecipitation = new SeasonPrecipitation
                    {
                        SeasonName = Season.Spring,
                        MonthlyPrecipitation = 
                        {
                            { Month.March, reader.GetDouble(3) },
                            { Month.April, reader.GetDouble(4) },
                            { Month.May, reader.GetDouble(5) },
                        }
                    },
                    SummerPrecipitation = new SeasonPrecipitation
                    {
                        SeasonName = Season.Summer,
                        MonthlyPrecipitation =
                        {
                            { Month.June, reader.GetDouble(6) },
                            { Month.July, reader.GetDouble(7) },
                            { Month.August, reader.GetDouble(8) }
                        }
                    },
                    AutumnPrecipitation = new SeasonPrecipitation
                    {
                        SeasonName = Season.Autumn,
                        MonthlyPrecipitation =
                        {
                            { Month.September, reader.GetDouble(9) },
                            { Month.October, reader.GetDouble(10) },
                            { Month.November, reader.GetDouble(11) }
                        }
                    }
                };
                list.Add(row);
            }

            return list;
        }

 
    }
}

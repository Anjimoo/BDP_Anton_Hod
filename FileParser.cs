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
                        }
                    },
                    SpringPrecipitation = new SeasonPrecipitation
                    {

                    },
                    SummerPrecipitation = new SeasonPrecipitation
                    {

                    },
                    AutumnPrecipitation = new SeasonPrecipitation
                    {

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

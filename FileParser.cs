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
                var row = new YearlyPrecipitation
                {
                    Year = (int)reader.GetDouble(0),
                    JanuaryPrecipitation = reader.GetDouble(1),
                    FebruaryPrecipitation = reader.GetDouble(2),
                    MarchPrecipitation = reader.GetDouble(3),
                    AprilPrecipitation = reader.GetDouble(4),
                    MayPrecipitation = reader.GetDouble(5),
                    JunePrecipitation = reader.GetDouble(6),
                    JulyPrecipitation = reader.GetDouble(7),
                    AugustPrecipitation = reader.GetDouble(8),
                    SeptemberPrecipitation = reader.GetDouble(9),
                    OctoberPrecipitation = reader.GetDouble(10),
                    NovemberPrecipitation = reader.GetDouble(11),
                    DecemberPrecipitation = reader.GetDouble(12),
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

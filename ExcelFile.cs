using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelDataReader;


namespace BDP_Anton_Hod
{
    static class ExcelFile
    {
        public static IExcelDataReader openExcelFile(string fileName)
        {
            var stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            return reader;

        }
        
        
    }
}

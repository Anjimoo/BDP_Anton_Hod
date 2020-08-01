using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BDP_Anton_Hod
{
    static class MessageCreator
    {
        private static StringBuilder stringBuilder = new StringBuilder();

        public static string MakeAverageMessage(double average)
        {
            string message = "\nThe Average is:" + average;
            return message;
        }

        public static string MakeMaximumMessage(int year, double numOfPrecipitation)
        {
            string message = $"\nThe year with max precipitation is: {year}, and number of precipitation is: {numOfPrecipitation}";
            return message;
        }


        public static string MakeMinimumMessage(int year, double numOfPrecipitation)
        {
            string message = $"\nThe year with min precipitation is: {year}, and number of precipitation is: {numOfPrecipitation}";
            return message;
        }

        public static string MakeMaximumMessage(int year, KeyValuePair<Month, double> keyValuePair)
        {
            stringBuilder.Clear();

            stringBuilder.AppendLine();
            stringBuilder.Append($"Year/month with maximum precipitation :{ year } / { keyValuePair.Key }");
            stringBuilder.AppendLine();
            stringBuilder.Append($"Number of precipitation is : { keyValuePair.Value} ");

            return stringBuilder.ToString();
        }

        public static string MakeMinimumMessage(int year, KeyValuePair<Month, double> keyValuePair)
        {
            stringBuilder.Clear();

            stringBuilder.AppendLine();
            stringBuilder.Append($"Year/month with minimum precipitation :{ year } / { keyValuePair.Key }");
            stringBuilder.AppendLine();
            stringBuilder.Append($"Number of precipitation is : { keyValuePair.Value} ");

            return stringBuilder.ToString();
        }

        public static string MakeMaximumMessage(int year, KeyValuePair<Season, double> keyValuePair)
        {
            stringBuilder.Clear();
       
            stringBuilder.AppendLine();
            stringBuilder.Append($"Year/season with maximum precipitation :{ year } / { keyValuePair.Key }");
            stringBuilder.AppendLine();
            stringBuilder.Append($"Number of precipitation is : { keyValuePair.Value} ");

            return stringBuilder.ToString();
        }

        public static string MakeMinimumMessage(int year, KeyValuePair<Season, double> keyValuePair)
        {
            stringBuilder.Clear();

            stringBuilder.AppendLine();
            stringBuilder.Append($"Year/season with minimum precipitation :{ year } / { keyValuePair.Key }");
            stringBuilder.AppendLine();
            stringBuilder.Append($"Number of precipitation is : { keyValuePair.Value} ");

            return stringBuilder.ToString();
        }

    }
}

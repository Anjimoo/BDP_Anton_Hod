using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BDP_Anton_Hod
{
    static class MessageCreator
    {
        public static string MakeMaximumMessage(int year, KeyValuePair<Season, double> keyValuePair)
        {
            string message = "\nYear/"+ keyValuePair.Key.GetType().Name + " with maximum precipitation :" + year + "/" + keyValuePair.Key +
                "\nNumber of precipitation is : " + keyValuePair.Value;
            return message;
        }
        public static string MakeMaximumMessage(int year, double numOfPrecipitation)
        {
            string message = "";
            return message;
        }
        
        public static string MakeMinimumMessage(int year, KeyValuePair<Season, double> keyValuePair)
        {
        string message = "\nYear/" + keyValuePair.Key.GetType().Name + " with minimum precipitation :" + year + "/" + keyValuePair.Key +
                "\nNumber of precipitation is : " + keyValuePair.Value;
        return message;
        }
        public static string MakeMinimumMessage(int year, double numOfPrecipitation)
        {
            string message = "";
            return message;
        }
        public static string MakeAverageMessage(double average)
        { 
            string message = "";
            return message; 
        }

    }
}

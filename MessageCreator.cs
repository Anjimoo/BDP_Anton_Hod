using System;
using System.Collections.Generic;
using System.Text;

namespace BDP_Anton_Hod
{
    static class MessageCreator
    {
        public static string YearSeasonMaxPrecipitationMessage(int year, KeyValuePair<Season, double> keyValuePair)
        {
            string message = "\nYear/Season with maximum precipitation :" + year + "/" + keyValuePair.Key + "\nNumber of precipitation is : " + keyValuePair.Value;
            return message;
        }
        public static string YearSeasonMinPrecipitationMessage(int year, KeyValuePair<Season, double> keyValuePair)
        {
            string message = "\nYear/Season with minimum precipitation :" + year + "/" + keyValuePair.Key + "\nNumber of precipitation is : " + keyValuePair.Value;
            return message;
        }
    }
}

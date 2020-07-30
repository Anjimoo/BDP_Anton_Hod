using System.Collections.Generic;
using System.Linq;

namespace BDP_Anton_Hod
{
    public enum Season
    {
        Winter, Spring, Summer, Autumn
    }

    public enum Month
    {
        January, February, March, May, April, June, July, August, September, October, November, December
    }

    public class SeasonPrecipitation
    {
        public Season Season { get; set; }
        public Dictionary<Month, double> MonthlyPrecipitation { get; } = new Dictionary<Month, double>(4);

        public double TotalPrecipitation
        {
            get
            {
                return MonthlyPrecipitation.Sum(keyValuePair => keyValuePair.Value);
            }
        }

        public KeyValuePair<Month, double> MaxPrecipitation
        {
            get
            {
                return MonthlyPrecipitation.Aggregate((kvp1, kvp2) => kvp1.Value > kvp2.Value ? kvp1 : kvp2);
            }
        }
    }

    public class YearlyPrecipitation
    {
        public int Year { get; set; }
        public SeasonPrecipitation WinterPrecipitation { get; set; }
        public SeasonPrecipitation SpringPrecipitation { get; set; }
        public SeasonPrecipitation SummerPrecipitation { get; set; }
        public SeasonPrecipitation AutumnPrecipitation { get; set; }
    }
}

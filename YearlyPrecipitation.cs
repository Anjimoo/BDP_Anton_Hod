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

        // total season precipitation
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

        public KeyValuePair<Month, double> MinPrecipitation
        {
            get
            {
                return MonthlyPrecipitation.Aggregate((kvp1, kvp2) => kvp1.Value < kvp2.Value ? kvp1 : kvp2);
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

        public double TotalYearPreticipation
        {
            get
            {
                double sum = WinterPrecipitation.TotalPrecipitation + SpringPrecipitation.TotalPrecipitation +
                    SummerPrecipitation.TotalPrecipitation + AutumnPrecipitation.TotalPrecipitation;
                return sum;
            }
        }
        public KeyValuePair<Month, double> MaxMonthPrecipitation
        {
            get 
            {
                Dictionary<Month, double> seasonsPrecipitation = new Dictionary<Month, double>();

                seasonsPrecipitation.Add(WinterPrecipitation.MaxPrecipitation.Key, WinterPrecipitation.MaxPrecipitation.Value);
                seasonsPrecipitation.Add(SpringPrecipitation.MaxPrecipitation.Key, SpringPrecipitation.MaxPrecipitation.Value);
                seasonsPrecipitation.Add(SummerPrecipitation.MaxPrecipitation.Key, SummerPrecipitation.MaxPrecipitation.Value);
                seasonsPrecipitation.Add(AutumnPrecipitation.MaxPrecipitation.Key, AutumnPrecipitation.MaxPrecipitation.Value);

                return seasonsPrecipitation.Aggregate((kvp1, kvp2) => kvp1.Value > kvp2.Value ? kvp1 : kvp2);
            }
        }

        public KeyValuePair<Month, double> MinMonthPrecipitation
        {
            get
            {
                Dictionary<Month, double> seasonsPrecipitation = new Dictionary<Month, double>();

                seasonsPrecipitation.Add(WinterPrecipitation.MinPrecipitation.Key, WinterPrecipitation.MinPrecipitation.Value);
                seasonsPrecipitation.Add(SpringPrecipitation.MinPrecipitation.Key, SpringPrecipitation.MinPrecipitation.Value);
                seasonsPrecipitation.Add(SummerPrecipitation.MinPrecipitation.Key, SummerPrecipitation.MinPrecipitation.Value);
                seasonsPrecipitation.Add(AutumnPrecipitation.MinPrecipitation.Key, AutumnPrecipitation.MinPrecipitation.Value);

                return seasonsPrecipitation.Aggregate((kvp1, kvp2) => kvp1.Value < kvp2.Value ? kvp1 : kvp2);
            }
        }
    }
}

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
            // get total preticipation in year
            get
            {
                return WinterPrecipitation.TotalPrecipitation + SpringPrecipitation.TotalPrecipitation +
                    SummerPrecipitation.TotalPrecipitation + AutumnPrecipitation.TotalPrecipitation;
            }
        }

        public KeyValuePair<Season, double> MaxSeasonPrecipitation
        {
            get
            {
                return GetSeasonsPrecipitationDict().Aggregate((kvp1, kvp2) => kvp1.Value > kvp2.Value ? kvp1 : kvp2);
            }
        }

        public KeyValuePair<Season, double> MinSeasonPrecipitation
        {
            get
            {
                return GetSeasonsPrecipitationDict().Aggregate((kvp1, kvp2) => kvp1.Value < kvp2.Value ? kvp1 : kvp2);
            }
        }

        public KeyValuePair<Month, double> MaxMonthPrecipitation
        {
            // get month with maximum preticipation
            get 
            {
                Dictionary<Month, double> monthsPrecipitation = new Dictionary<Month, double>();

                monthsPrecipitation.Add(WinterPrecipitation.MaxPrecipitation.Key, WinterPrecipitation.MaxPrecipitation.Value);
                monthsPrecipitation.Add(SpringPrecipitation.MaxPrecipitation.Key, SpringPrecipitation.MaxPrecipitation.Value);
                monthsPrecipitation.Add(SummerPrecipitation.MaxPrecipitation.Key, SummerPrecipitation.MaxPrecipitation.Value);
                monthsPrecipitation.Add(AutumnPrecipitation.MaxPrecipitation.Key, AutumnPrecipitation.MaxPrecipitation.Value);

                return monthsPrecipitation.Aggregate((kvp1, kvp2) => kvp1.Value > kvp2.Value ? kvp1 : kvp2);
            }
        }

        public KeyValuePair<Month, double> MinMonthPrecipitation
        {
            // get month with minimum preticipation
            get
            {
                Dictionary<Month, double> monthsPrecipitation = new Dictionary<Month, double>();

                monthsPrecipitation.Add(WinterPrecipitation.MinPrecipitation.Key, WinterPrecipitation.MinPrecipitation.Value);
                monthsPrecipitation.Add(SpringPrecipitation.MinPrecipitation.Key, SpringPrecipitation.MinPrecipitation.Value);
                monthsPrecipitation.Add(SummerPrecipitation.MinPrecipitation.Key, SummerPrecipitation.MinPrecipitation.Value);
                monthsPrecipitation.Add(AutumnPrecipitation.MinPrecipitation.Key, AutumnPrecipitation.MinPrecipitation.Value);

                return monthsPrecipitation.Aggregate((kvp1, kvp2) => kvp1.Value < kvp2.Value ? kvp1 : kvp2);
            }
        }

        private Dictionary<Season, double> GetSeasonsPrecipitationDict()
        {
            Dictionary<Season, double> seasonsPrecipitation = new Dictionary<Season, double>();

            seasonsPrecipitation.Add(WinterPrecipitation.Season, WinterPrecipitation.TotalPrecipitation);
            seasonsPrecipitation.Add(SpringPrecipitation.Season, SpringPrecipitation.TotalPrecipitation);
            seasonsPrecipitation.Add(SummerPrecipitation.Season, SummerPrecipitation.TotalPrecipitation);
            seasonsPrecipitation.Add(AutumnPrecipitation.Season, AutumnPrecipitation.TotalPrecipitation);

            return seasonsPrecipitation;
        }
    }
}

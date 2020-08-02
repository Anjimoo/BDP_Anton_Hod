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

    public class YearlyPrecipitation
    {
        public int YearName { get; set; }

        public SeasonPrecipitation WinterPrecipitation { get; set; }
        public SeasonPrecipitation SpringPrecipitation { get; set; }
        public SeasonPrecipitation SummerPrecipitation { get; set; }
        public SeasonPrecipitation AutumnPrecipitation { get; set; }
        /// <returns>
        /// Return year's overall precipitation
        /// </returns>
        public double TotalYearPrecipitation
        {
            get
            {
                return WinterPrecipitation.TotalPrecipitation + SpringPrecipitation.TotalPrecipitation +
                    SummerPrecipitation.TotalPrecipitation + AutumnPrecipitation.TotalPrecipitation;
            }
        }

        /// <returns>
        /// Return season/precipitation pair in this year with maximum precipitation
        /// </returns>
        public KeyValuePair<Season, double> MaxSeasonPrecipitation
        {
            get
            {
                return GetSeasonsPrecipitationDict().Aggregate((kvp1, kvp2) => kvp1.Value > kvp2.Value ? kvp1 : kvp2);
            }
        }
        /// <returns>
        /// Return season/precipitation pair in this year with minimum precipitation
        /// </returns>
        public KeyValuePair<Season, double> MinSeasonPrecipitation
        {
            get
            {
                return GetSeasonsPrecipitationDict().Aggregate((kvp1, kvp2) => kvp1.Value < kvp2.Value ? kvp1 : kvp2);
            }
        }
        /// <returns>
        /// Return month/precipitation pair in this year with maximum precipitation
        /// </returns>
        public KeyValuePair<Month, double> MaxMonthPrecipitation
        {
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
        /// <returns>
        /// Return month/precipitation pair in this year with maximum precipitation
        /// </returns>
        public KeyValuePair<Month, double> MinMonthPrecipitation
        {
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
        /// <summary>
        /// Build Dictionary with seasons precipitation
        /// </summary>
        private Dictionary<Season, double> GetSeasonsPrecipitationDict()
        {
            Dictionary<Season, double> seasonsPrecipitation = new Dictionary<Season, double>();

            seasonsPrecipitation.Add(WinterPrecipitation.SeasonName, WinterPrecipitation.TotalPrecipitation);
            seasonsPrecipitation.Add(SpringPrecipitation.SeasonName, SpringPrecipitation.TotalPrecipitation);
            seasonsPrecipitation.Add(SummerPrecipitation.SeasonName, SummerPrecipitation.TotalPrecipitation);
            seasonsPrecipitation.Add(AutumnPrecipitation.SeasonName, AutumnPrecipitation.TotalPrecipitation);

            return seasonsPrecipitation;
        }
    }
}

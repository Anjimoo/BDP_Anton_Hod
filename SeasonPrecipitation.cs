using System.Collections.Generic;
using System.Linq;

namespace BDP_Anton_Hod
{
    public class SeasonPrecipitation
    {
        public Season Season { get; set; }
        public Dictionary<Month, double> MonthlyPrecipitation { get; } = new Dictionary<Month, double>(3);

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
}

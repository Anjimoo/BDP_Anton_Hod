using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BDP_Anton_Hod
{
    class MapReduceAnalysis
    {
        private string _fileName { get; set; }
        private List<YearlyPrecipitation> _rows { get; set; }
        public double AveragePrecipitatinOverYears { get; set; }
        public double MaxPrecipitationYear { get; set; }
        public double MinPrecipitationYear { get; set; }
        public int YearMaxMonth { get; set; }
        public int YearMinMonth { get; set; }
        public KeyValuePair<Month, double> MaxMonthPrecipitation { get; set; }
        public KeyValuePair<Month, double> MinMonthPrecipitation { get; set; }
        public int YearMaxSeason { get; set; }
        public int YearMinSeason { get; set; }
        public KeyValuePair<Season, double> MaxSeasonPrecipitation { get; set; }
        public KeyValuePair<Season, double> MinSeasonPrecipitation { get; set; }

        public async Task AnalyseSync()
        {
            
        }
    }
}

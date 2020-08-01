using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDataReader;
using System.Diagnostics;
using System.Windows.Automation;

namespace BDP_Anton_Hod
{
    class StandartAnalysis
    {
        private string _fileName { get; set; }
        private List<YearlyPrecipitation> _rows { get; set; }
        public int MaxYear { get; set; }
        public int MinYear { get; set; }
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

        public StandartAnalysis(string fileName)
        {
            _fileName = fileName;
        }

        public void Analyse(List<YearlyPrecipitation> _rows)
        {
            this._rows = _rows;
            SetAveragePrecipitationOverYears();
            SetMinMaxPrecipitationYears();
            SetMinMaxMonthPrecipitationYear();
            SetMinMaxSeasonPrecipitationYear();
        }

        private void SetAveragePrecipitationOverYears()
        {
            double sum = 0;
            foreach (var row in _rows)
            {
                sum += row.TotalYearPrecipitation;
     
            }
            AveragePrecipitatinOverYears = sum / _rows.Count;
        }

        private void SetMinMaxPrecipitationYears()
        {

           var MaxPrecipitationYear = _rows.Aggregate((kvp1, kvp2) => kvp1.TotalYearPrecipitation > kvp2.TotalYearPrecipitation ? kvp1 : kvp2);
            MaxYear = MaxPrecipitationYear.Year;
            var MinPrecipitationYear = _rows.Aggregate((kvp1, kvp2) => kvp1.TotalYearPrecipitation < kvp2.TotalYearPrecipitation ? kvp1 : kvp2);
            MinYear = MinPrecipitationYear.Year;
        }

        private void SetMinMaxMonthPrecipitationYear()
        {
            var MaxPrecipitationYear = _rows.Aggregate((kvp1, kvp2) => kvp1.MaxMonthPrecipitation.Value > kvp2.MaxMonthPrecipitation.Value ? kvp1 : kvp2);
            MaxMonthPrecipitation = MaxPrecipitationYear.MaxMonthPrecipitation;

            var MinPrecipitationYear = _rows.Aggregate((kvp1, kvp2) => kvp1.MinMonthPrecipitation.Value < kvp2.MinMonthPrecipitation.Value ? kvp1 : kvp2);
            MinMonthPrecipitation = MinPrecipitationYear.MinMonthPrecipitation;

        }
       
        private void SetMinMaxSeasonPrecipitationYear()
        {
            // get year of season with maximum precipitation
            var maxYear = _rows.Aggregate((kvp1, kvp2) => kvp1.MaxSeasonPrecipitation.Value > kvp2.MaxSeasonPrecipitation.Value ? kvp1 : kvp2);
            // get year of season with minimum precipitation
            var minYear = _rows.Aggregate((kvp1, kvp2) => kvp1.MinSeasonPrecipitation.Value < kvp2.MinSeasonPrecipitation.Value ? kvp1 : kvp2);

            MaxSeasonPrecipitation = maxYear.MaxSeasonPrecipitation;
            MinSeasonPrecipitation = minYear.MinSeasonPrecipitation;
          
        }
    }
}

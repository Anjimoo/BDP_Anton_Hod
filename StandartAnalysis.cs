﻿using System;
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

        public double MaxPrecipitationYear { get; set; }
        public double MinPrecipitationYear { get; set; }

        public int YearMaxSeason{ get; set; }
        public int YearMinSeason { get; set; }

        public KeyValuePair<Season, double> MaxSeasonPrecipitation { get; set; }

        public KeyValuePair<Season, double> MinSeasonPrecipitation { get; set; }


        public StandartAnalysis(string fileName)
        {
            _fileName = fileName;
        }

        public void Analyse()
        {
            _rows = FileParser.ParseFile(_fileName);

            // SetMinMaxPrecipitationYears();

            SetMinMaxSeasonPrecipitationYear();
        }

        private void SetMinMaxPrecipitationYears()
        {
            // TODO
            _rows.Aggregate((kvp1, kvp2) => kvp1.TotalYearPreticipation > kvp2.TotalYearPreticipation ? kvp1 : kvp2);

        }

        private void SetMinMaxSeasonPrecipitationYear()
        {
            // get year of season with maximum precipitation
            YearMaxSeason = _rows.Aggregate((kvp1, kvp2) => kvp1.MaxSeasonPrecipitation.Value > kvp2.MaxSeasonPrecipitation.Value ? kvp1 : kvp2).Year;
            // get year of season with minimum precipitation
            YearMinSeason = _rows.Aggregate((kvp1, kvp2) => kvp1.MinSeasonPrecipitation.Value < kvp2.MinSeasonPrecipitation.Value ? kvp1 : kvp2).Year;
           // find years of seasons with maximum and minimum precipitation in year and set to propertie
            foreach (var row in _rows)
            {
                if(row.Year == YearMaxSeason)
                {
                    MaxSeasonPrecipitation = row.MaxSeasonPrecipitation;
                }
                if(row.Year == YearMinSeason)
                {
                    MinSeasonPrecipitation = row.MinSeasonPrecipitation;
                }
            }
        }
    }
}

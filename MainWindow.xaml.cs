using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Win32;



namespace BDP_Anton_Hod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _consoleText;

        private List<YearlyPrecipitation> _rows { get; set; }
        public string ConsoleText
        {
            get => _consoleText;
            set
            {
                if (_consoleText == value) return;
                _consoleText = value;
                OnPropertyChanged();
            }
        }

        public string FileName { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }



        private void importButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                this.FileName = dialog.FileName;
                ConsoleText = "Imported file is : " + dialog.FileName;
            }
            _rows = FileParser.ParseFile(FileName);
            if(_rows != null)
            {
                MRButton.IsEnabled = true;
                standartButton.IsEnabled = true;
            }
        }
        // standart Analysis
        private void standardButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            StandardAnalysis standartAnalysis = new StandardAnalysis(this.FileName);
            standartAnalysis.Analyse(_rows);

            ConsoleText += "\nStandard analysis";
            ConsoleText += MessageCreator.MakeAverageMessage(standartAnalysis.AveragePrecipitatinOverYears);
            ConsoleText += MessageCreator.MakeMaximumMessage(standartAnalysis.MaxYear, standartAnalysis.MaxPrecipitationYear);
            ConsoleText += MessageCreator.MakeMinimumMessage(standartAnalysis.MinYear, standartAnalysis.MinPrecipitationYear);
            ConsoleText += MessageCreator.MakeMaximumMessage(standartAnalysis.YearMaxMonth, standartAnalysis.MaxMonthPrecipitation);
            ConsoleText += MessageCreator.MakeMinimumMessage(standartAnalysis.YearMinMonth, standartAnalysis.MinMonthPrecipitation);
            ConsoleText += MessageCreator.MakeMaximumMessage(standartAnalysis.YearMaxSeason, standartAnalysis.MaxSeasonPrecipitation);
            ConsoleText += MessageCreator.MakeMinimumMessage(standartAnalysis.YearMinSeason, standartAnalysis.MinSeasonPrecipitation);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ConsoleText += $"\nTotal execution time: { elapsedMs}";
        }
        // Map Reduce Analysis
        private void MRButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            MapReduceAnalysis mapReduceAnalysis = new MapReduceAnalysis();
            mapReduceAnalysis.Analyse(_rows);

            ConsoleText += "\nMapReduce analysis";
            ConsoleText += MessageCreator.MakeAverageMessage(mapReduceAnalysis.AveragePrecipitatinOverYears);
            ConsoleText += MessageCreator.MakeMaximumMessage(mapReduceAnalysis.MaxYear, mapReduceAnalysis.MaxPrecipitationYear);
            ConsoleText += MessageCreator.MakeMinimumMessage(mapReduceAnalysis.MinYear, mapReduceAnalysis.MinPrecipitationYear);
            ConsoleText += MessageCreator.MakeMaximumMessage(mapReduceAnalysis.YearMaxMonth, mapReduceAnalysis.MaxMonthPrecipitation);
            ConsoleText += MessageCreator.MakeMinimumMessage(mapReduceAnalysis.YearMinMonth, mapReduceAnalysis.MinMonthPrecipitation);
            ConsoleText += MessageCreator.MakeMaximumMessage(mapReduceAnalysis.YearMaxSeason, mapReduceAnalysis.MaxSeasonPrecipitation);
            ConsoleText += MessageCreator.MakeMinimumMessage(mapReduceAnalysis.YearMinSeason, mapReduceAnalysis.MinSeasonPrecipitation);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ConsoleText += $"\nTotal execution time: { elapsedMs}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;



namespace BDP_Anton_Hod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _consoleText;
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
        }
        // standart Analysis
        private void standartButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            StandartAnalysis standartAnalysis = new StandartAnalysis(this.FileName);
            standartAnalysis.Analyse();
            ConsoleText += MessageCreator.MakeMaximumMessage(standartAnalysis.YearMaxSeason, standartAnalysis.MaxSeasonPrecipitation);
            ConsoleText += MessageCreator.MakeMinimumMessage(standartAnalysis.YearMinSeason, standartAnalysis.MinSeasonPrecipitation);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            ConsoleText += $"\nTotal execution time: { elapsedMs}";
        }
        // Map Reduce Analysis
        private void MRButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}

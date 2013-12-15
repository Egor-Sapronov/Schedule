using System.Windows;
using System.ComponentModel;

namespace Schedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                DataContext = App.Current.AppState;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetNextSolution();
        }

        private void mnuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNextSolution_Click(object sender, RoutedEventArgs e)
        {
            GetNextSolution();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            App.Current.AppState.Scheduler.Restart();

            GetNextSolution();
        }

        private void GetNextSolution()
        {
            Schedule.Logic.Schedule schedule = App.Current.AppState.Scheduler.Execute();

            if (schedule == null)
            {
                MessageBox.Show("No more schedules exist.", "Scheduler", MessageBoxButton.OK);
            }
            else
            {
                App.Current.AppState.Schedule = schedule;
            }
        }
    }
}

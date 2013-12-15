using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Schedule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AppState _appState;

        public App()
        {
            _appState = new AppState(this);
        }

        public new static App Current { get { return (App)(Application.Current); } }

        public AppState AppState { get { return _appState; } }

        public string ApplicationTitle { get { return FindResource("ApplicationTitle") as string; } }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //DispatcherUnhandledException += App_DispatcherUnhandledException;

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        //private void Application_Exit(object sender, ExitEventArgs e)
        //{
        //}

        //void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        //{
        //    CommonExceptionHandlers.HandleException(null, e.Exception);

        //    e.Handled = true;
        //}

    }
}

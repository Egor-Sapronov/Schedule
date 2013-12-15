using System.Windows;
using System.ComponentModel;
using Schedule.Logic;

namespace Schedule
{
    public class AppState : INotifyPropertyChanged
    {
        private App _application;
        private Scheduler _scheduler;
        private Schedule.Logic.Schedule _schedule;

        internal AppState(App application)
        {
            _application = application;
            _scheduler = new Scheduler();
            _schedule = null;
        }

        public App Application { get { return _application; } }
        public Scheduler Scheduler { get { return _scheduler; } }
        public Schedule.Logic.Schedule Schedule 
        { 
            get { return _schedule; }
            set
            {
                if (value != _schedule)
                {
                    _schedule = value;
                    RaisePropertyChanged(new PropertyChangedEventArgs("Schedule"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}

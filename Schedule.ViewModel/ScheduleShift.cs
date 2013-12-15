using System.ComponentModel;

namespace Schedule.ViewModel
{
    public class ScheduleShift : INotifyPropertyChanged
    {
        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (value != _name)
                {
                    _name = value;
                    RaisePropertyChanged(new PropertyChangedEventArgs("Name"));

                }
            }
        }

        public void Copy(ScheduleShift scheduleShift)
        {
            Name = scheduleShift.Name;
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
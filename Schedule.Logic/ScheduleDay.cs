using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Logic
{
    public class ScheduleDay
    {
        private ScheduleShift _first = new ScheduleShift();
        private ScheduleShift _second = new ScheduleShift();
        private ScheduleShift _third = new ScheduleShift();

        public ScheduleShift First { get { return _first; } }
        public ScheduleShift Second { get { return _second; } }
        public ScheduleShift Third { get { return _third; } }

        public void Copy(ScheduleDay scheduleDay)
        {
            First.Copy(scheduleDay.First);
            Second.Copy(scheduleDay.Second);
            Third.Copy(scheduleDay.Third);
        }
    }
}

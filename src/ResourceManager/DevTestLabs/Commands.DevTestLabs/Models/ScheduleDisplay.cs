using Microsoft.Azure.Management.DevTestLabs.Models;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs.Models
{
    internal class ScheduleDisplay : Schedule
    {
        internal static string ToLocalizedTime(string militaryTime)
        {
            if (militaryTime == null || militaryTime.Length != 4)
            {
                return militaryTime;
            }

            ushort hours;

            if (!ushort.TryParse(militaryTime.Substring(0, 2), out hours))
            {
                return militaryTime;
            }

            ushort minutes;

            if (!ushort.TryParse(militaryTime.Substring(2), out minutes))
            {
                return militaryTime;
            }

            if (hours > 23 || minutes > 59)
            {
                return militaryTime;
            }

            return new DateTime(2000, 1, 1, hours, minutes, 0, 0).ToShortTimeString();
        }

        public new WeekDetailsDisplay WeeklyRecurrence
        {
            get
            {
                return base.WeeklyRecurrence.DuckType<WeekDetailsDisplay>();
            }
            set
            {
                base.WeeklyRecurrence = value.DuckType<WeekDetails>();
            }
        }

        public new HourDetailsDisplay HourlyRecurrence
        {
            get
            {
                return base.HourlyRecurrence.DuckType<HourDetailsDisplay>();
            }
            set
            {
                base.HourlyRecurrence = value.DuckType<HourDetails>();
            }
        }

        public new DayDetailsDisplay DailyRecurrence
        {
            get
            {
                return base.DailyRecurrence.DuckType<DayDetailsDisplay>();
            }
            set
            {
                base.DailyRecurrence = value.DuckType<DayDetails>();
            }
        }

        #region nested classes

        public class WeekDetailsDisplay : WeekDetails
        {
            public override string ToString()
            {
                if (Weekdays == null || Weekdays.Count == 0)
                {
                    return String.Format("{{ Time: {0} }}", ToLocalizedTime(Time));
                }

                return String.Format("{{ Time: {0}, Weekdays: {1} }}", ToLocalizedTime(Time), string.Join(", ", Weekdays.Select(i => i.ToString())));
            }
        }

        public class DayDetailsDisplay : DayDetails
        {
            public override string ToString()
            {
                return String.Format("{{ Time: {0} }}", ToLocalizedTime(Time));
            }
        }

        public class HourDetailsDisplay : HourDetails
        {
            public override string ToString()
            {
                return String.Format("{{ Minute: {0} }}", Minute);
            }
        }

        #endregion nested classes
    }
}

// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Hourly schedule for hourly policy
    /// </summary>
    public class HourlySchedule
    {        
        public int? Interval { get; set; }
     
        public DateTime? ScheduleWindowStartTime { get; set; }
     
        public int? ScheduleWindowDuration { get; set; }
    }

    /// <summary>
    /// Recovery services simple schedule policy.
    /// </summary>
    public class SimpleSchedulePolicy : SchedulePolicyBase
    {
        /// <summary>
        /// Describes the frequency at which this schedule should be run.
        /// </summary>
        public ScheduleRunType ScheduleRunFrequency { get; set; }

        /// <summary>
        /// Describes the list of the days of the week when this schedule should run.
        /// </summary>
        public List<DayOfWeek> ScheduleRunDays { get; set; }

        /// <summary>
        /// Describes the list of times of the days when this schedule should run.
        /// </summary>
        public List<DateTime> ScheduleRunTimes { get; set; }

        /// <summary>
        /// Represents the difference (in hours) between two successive backups per day. Allowed values are 4, 6, 8, 10 hours.
        /// </summary>        
        public int? ScheduleInterval { get; set; }

        /// <summary>
        /// Represents the window start time at which the first backup triggers in a single day, in case of hourly backups. Values can range from 00:00 to 19:30 in multiples of half hours.
        /// </summary>
        public DateTime? ScheduleWindowStartTime { get; set; }

        /// <summary>
        /// Represents the time span (in hours measured from the Schedule Window Start Time) beyond which backup jobs should not be triggered. Values can range from 4 to 23.
        /// </summary>
        public int? ScheduleWindowDuration { get; set; }

        /// <summary>
        /// Specifies the timezone in which backups are scheduled (default UTC).  
        /// </summary>
        public string ScheduleRunTimeZone { get; set; }

        public override void Validate()
        {
            //Currently only one scheduled run time is allowed
            //Validate that the schedule runtime is in multiples of 30 Mins
            if(ScheduleRunFrequency != ScheduleRunType.Hourly)
            {                
                if (ScheduleRunTimes == null || ScheduleRunTimes.Count != 1 ||
                ScheduleRunTimes[0].Minute % 30 != 0 ||
                ScheduleRunTimes[0].Second != 0 ||
                ScheduleRunTimes[0].Millisecond != 0)
                {
                    throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
                }

                if (ScheduleRunTimes[0].Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException(Resources.ScheduleTimeNotInUTCTimeZoneException);
                }

                if (ScheduleRunFrequency == ScheduleRunType.Weekly)
                {
                    if (ScheduleRunDays == null || ScheduleRunDays.Count == 0 ||
                        ScheduleRunDays.Count != ScheduleRunDays.Distinct().Count())
                    {
                        throw new ArgumentException(Resources.InvalidScheduleRunDaysInScheduleException);
                    }
                }
            }
            else
            {
                if (ScheduleInterval == null || ScheduleWindowStartTime == null || ScheduleWindowDuration == null || ScheduleRunTimeZone == null)
                {                    
                    throw new ArgumentException(String.Format(Resources.HourlyScheduleNullValueException));
                }                

                List<int> AllowedScheduleIntervals = new List<int> { 4, 6, 8, 12 };                
                if (!(AllowedScheduleIntervals.Contains((int)ScheduleInterval)))
                {                    
                    throw new ArgumentException(String.Format(Resources.InvalidScheduleInterval, string.Join(",", AllowedScheduleIntervals.ToArray())));                    
                }

                if ((ScheduleWindowDuration < ScheduleInterval) || (ScheduleWindowDuration < PolicyConstants.AfsHourlyWindowDurationMin) ||
                    (ScheduleWindowDuration > PolicyConstants.AfsHourlyWindowDurationMax))
                {                    
                    throw new ArgumentException(String.Format(Resources.InvalidScheduleWindowDuration, PolicyConstants.AfsHourlyWindowDurationMin, PolicyConstants.AfsHourlyWindowDurationMax));
                }

                DateTime windowStartTime = (DateTime)ScheduleWindowStartTime;
                DateTime minimumStartTime = new DateTime(windowStartTime.Year, windowStartTime.Month, windowStartTime.Day, 00, 00, 00, 00, DateTimeKind.Utc);
                DateTime maximumStartTime = new DateTime(windowStartTime.Year, windowStartTime.Month, windowStartTime.Day, 19, 30, 00, 00, DateTimeKind.Utc);

                // final backup time can be 23:30:00
                DateTime finalBackupTime = new DateTime(windowStartTime.Year , windowStartTime.Month, windowStartTime.Day, 23, 30, 00, 00, DateTimeKind.Utc);                                
                TimeSpan diff = finalBackupTime - windowStartTime;

                //validate window start time 
                if (ScheduleWindowStartTime > maximumStartTime || ScheduleWindowStartTime < minimumStartTime)
                {
                    throw new ArgumentException(String.Format(Resources.ScheduleWindowStartTimeOutOfRange));
                }

                if (diff.TotalHours < ScheduleWindowDuration)
                {                    
                    throw new ArgumentException(String.Format(Resources.InvalidLastBackupTime));
                }                

                // if non-UTC times are allowed then this exception needs to change 
                if (windowStartTime.Minute % 30 != 0 || windowStartTime.Second != 0 || windowStartTime.Millisecond != 0)
                {
                    throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
                }
            }            
        }

        public override string ToString()
        {
            return string.Format("scheduleRunType:{0}, ScheduleRunDays:{1}, ScheduleRunTimes:{2}",
                                  ScheduleRunFrequency,
                                  TraceUtils.GetString(ScheduleRunDays),
                                  TraceUtils.GetString(ScheduleRunTimes));
        }
    }

    public class LogSchedulePolicy : SchedulePolicyBase
    {
        public int? ScheduleFrequencyInMins { get; set; }
    }

    public class SQLSchedulePolicy : SchedulePolicyBase
    {
        /// <summary>
        /// Is compression enabled
        /// </summary>
        public bool? IsCompression { get; set; }

        /// <summary>
        /// Is differential backup enabled bool object
        /// </summary>
        public bool IsDifferentialBackupEnabled { get; set; }

        /// <summary>
        /// Is log backup enabled bool object
        /// </summary>
        public bool IsLogBackupEnabled { get; set; }

        /// <summary>
        /// Full backup schedule policy object
        /// </summary>
        public SimpleSchedulePolicy FullBackupSchedulePolicy { get; set; }

        /// <summary>
        /// Differential backup schedule policy object
        /// </summary>
        public SimpleSchedulePolicy DifferentialBackupSchedulePolicy { get; set; }

        /// <summary>
        /// Log backup schedule policy object
        /// </summary>
        public LogSchedulePolicy LogBackupSchedulePolicy { get; set; }

        public SQLSchedulePolicy()
        {
        }
    }
}

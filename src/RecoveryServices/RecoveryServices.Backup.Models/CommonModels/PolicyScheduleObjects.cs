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
        /// <summary>
        /// Represents the difference (in hours) between two successive backups per day. Allowed values are 4, 6, 8, 12 hours.
        /// </summary>  
        public int? Interval { get; set; }

        /// <summary>
        /// Represents the window start time at which the first backup triggers in a single day, in case of hourly backups. Values can range from 00:00 to 19:30 in multiples of half hours.
        /// </summary>
        public DateTime? WindowStartTime { get; set; }

        /// <summary>
        /// Represents the time span (in hours measured from the Schedule Window Start Time) beyond which backup jobs should not be triggered. Values can range from 4 to 23.
        /// </summary>
        public int? WindowDuration { get; set; }
    }

    public class DailySchedule
    {
        /// <summary>
        ///  Describes the list of times of the days when this schedule should run.
        /// </summary>
        public List<DateTime> ScheduleRunTimes { get; set; }                
    }

    public class WeeklySchedule
    {
        /// <summary>
        /// Describes the list of the days of the week when this schedule should run.
        /// </summary>
        public List<DayOfWeek> ScheduleRunDays { get; set; }

        /// <summary>
        ///  Describes the list of times of the days when this schedule should run.
        /// </summary>
        public List<DateTime> ScheduleRunTimes { get; set; }
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
                if (ScheduleInterval != null || ScheduleWindowStartTime != null || ScheduleWindowDuration != null)
                {
                    throw new ArgumentException(Resources.HourlyScheduleNotNull);
                }

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
                
                if (ScheduleRunDays != null || ScheduleRunTimes != null)
                {
                    throw new ArgumentException(Resources.NonHourlyAttributesNotNull);
                }
                
                if (ScheduleWindowDuration < ScheduleInterval)
                {
                    throw new ArgumentException(String.Format(Resources.WindowDurationLessThanInterval));
                }

                if (((DateTime)ScheduleWindowStartTime).Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException(Resources.WindowStartTimeNotInUTC);
                }

                DateTime windowStartTime = (DateTime)ScheduleWindowStartTime;                

                // If ScheduleWindowDuration is greator than (23:30 - ScheduleWindowStartTime) then throw exception  
                // if non-UTC times are allowed then this exception needs to change 
                if (windowStartTime.Minute % 30 != 0 || windowStartTime.Second != 0 || windowStartTime.Millisecond != 0)
                {
                    throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
                }
            }            
        }

        public override string ToString()
        {
            if (ScheduleRunFrequency == ScheduleRunType.Hourly)
            {
                return string.Format("scheduleRunType:{0}, ScheduleInterval:{1}, ScheduleWindowStartTime:{2}, ScheduleWindowDuration:{3}, ScheduleRunTimeZone:{4}",
                                  ScheduleRunFrequency,
                                  ScheduleInterval,
                                  ScheduleWindowStartTime.ToString(),
                                  ScheduleWindowDuration,
                                  ScheduleRunTimeZone);
            }           

            return string.Format("scheduleRunType:{0}, ScheduleRunDays:{1}, ScheduleRunTimes:{2}",
                                  ScheduleRunFrequency,
                                  TraceUtils.GetString(ScheduleRunDays),
                                  TraceUtils.GetString(ScheduleRunTimes));
        }
    }

    /// <summary>
    /// Recovery services simple schedule policy.
    /// </summary>
    public class SimpleSchedulePolicyV2 : SchedulePolicyBase
    {
        /// <summary>
        /// Describes the frequency at which this schedule should be run.
        /// </summary>
        public ScheduleRunType ScheduleRunFrequency { get; set; }

        /// <summary>
        /// Hourly Schedule for Enhanced policy. 
        /// </summary> 
        public HourlySchedule HourlySchedule { get; set; } // comment this to hide hourly support

        /// <summary>
        /// Daily Schedule for Enhanced policy.
        /// </summary>
        public DailySchedule DailySchedule { get; set; }

        /// <summary>
        /// Weekly Schedule for Enhanced policy.
        /// </summary>
        public WeeklySchedule WeeklySchedule { get; set; }
                
        /// <summary>
        /// Specifies the timezone in which backups are scheduled (default UTC).  
        /// </summary>
        public string ScheduleRunTimeZone { get; set; }

        public override void Validate() 
        {
            // Currently only one scheduled run time is allowed
            // Validate that the schedule runtime is in multiples of 30 Mins
            if (ScheduleRunFrequency == ScheduleRunType.Daily || DailySchedule != null)
            {
                if (DailySchedule.ScheduleRunTimes == null || DailySchedule.ScheduleRunTimes.Count != 1 ||
                DailySchedule.ScheduleRunTimes[0].Minute % 30 != 0 ||
                DailySchedule.ScheduleRunTimes[0].Second != 0 ||
                DailySchedule.ScheduleRunTimes[0].Millisecond != 0)
                {
                    throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
                }

                if (DailySchedule.ScheduleRunTimes[0].Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException(Resources.ScheduleTimeNotInUTCTimeZoneException);
                }
            }
            
            if (ScheduleRunFrequency == ScheduleRunType.Weekly || WeeklySchedule != null)
            {
                if (WeeklySchedule.ScheduleRunTimes == null || WeeklySchedule.ScheduleRunTimes.Count != 1 ||
                WeeklySchedule.ScheduleRunTimes[0].Minute % 30 != 0 ||
                WeeklySchedule.ScheduleRunTimes[0].Second != 0 ||
                WeeklySchedule.ScheduleRunTimes[0].Millisecond != 0)
                {
                    throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
                }

                if (WeeklySchedule.ScheduleRunTimes[0].Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException(Resources.ScheduleTimeNotInUTCTimeZoneException);
                }
                                
                if (WeeklySchedule.ScheduleRunDays == null || WeeklySchedule.ScheduleRunDays.Count == 0 ||
                    WeeklySchedule.ScheduleRunDays.Count != WeeklySchedule.ScheduleRunDays.Distinct().Count())
                {
                    throw new ArgumentException(Resources.InvalidScheduleRunDaysInScheduleException);
                }                
            }

            if (ScheduleRunFrequency == ScheduleRunType.Hourly || HourlySchedule != null)
            {
                if (HourlySchedule.Interval == null || HourlySchedule.WindowStartTime == null || HourlySchedule.WindowDuration == null || ScheduleRunTimeZone == null)
                {
                    throw new ArgumentException(String.Format(Resources.HourlyScheduleNullValueException));
                }

                if (HourlySchedule.WindowDuration < HourlySchedule.Interval)
                {
                    throw new ArgumentException(String.Format(Resources.WindowDurationLessThanInterval));
                }

                if (((DateTime)HourlySchedule.WindowStartTime).Kind != DateTimeKind.Utc)
                {
                    throw new ArgumentException(Resources.WindowStartTimeNotInUTC);
                }

                DateTime windowStartTime = (DateTime)HourlySchedule.WindowStartTime;

                // if non-UTC times are allowed then this exception needs to change 
                if (windowStartTime.Minute % 30 != 0 || windowStartTime.Second != 0 || windowStartTime.Millisecond != 0)
                {
                    throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
                }
            }
        }

        public override string ToString()
        {
            if(WeeklySchedule != null)
            {
                return string.Format("scheduleRunType:{0}, ScheduleRunDays:{1}, ScheduleRunTimes:{2}",
                                  ScheduleRunFrequency,
                                  TraceUtils.GetString(WeeklySchedule.ScheduleRunDays),
                                  TraceUtils.GetString(WeeklySchedule.ScheduleRunTimes));
            }
            else if (DailySchedule != null)
            {
                return string.Format("scheduleRunType:{0}, ScheduleRunTimes:{1}",
                                  ScheduleRunFrequency,                                  
                                  TraceUtils.GetString(DailySchedule.ScheduleRunTimes));
            }
            else if (HourlySchedule != null)
            {
                return string.Format("scheduleRunType:{0}, ScheduleInterval:{1}, ScheduleWindowStartTime:{2}, ScheduleWindowDuration:{3}, ScheduleRunTimeZone:{4}",
                                  ScheduleRunFrequency,
                                  HourlySchedule.Interval,
                                  HourlySchedule.WindowStartTime.ToString(),
                                  HourlySchedule.WindowDuration,
                                  ScheduleRunTimeZone);
            }
            
            return string.Empty;
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

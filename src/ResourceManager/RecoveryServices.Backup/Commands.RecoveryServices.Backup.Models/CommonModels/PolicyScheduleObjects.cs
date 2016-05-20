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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
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

        public override void Validate()
        {
            //Currently only one scheduled run time is allowed
            //Validate that the schedule runtime is in multiples of 30 Mins
            if (ScheduleRunTimes == null || ScheduleRunTimes.Count != 1 || 
                ScheduleRunTimes[0].Minute % 30 != 0 || 
                ScheduleRunTimes[0].Second != 0 || 
                ScheduleRunTimes[0].Millisecond != 0)
            {
                throw new ArgumentException(Resources.InvalidScheduleTimeInScheduleException);
            }

            if(ScheduleRunTimes[0].Kind != DateTimeKind.Utc)
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

        public override string ToString()
        {
            return String.Format("scheduleRunType:{0}, ScheduleRunDays:{1}, ScheduleRunTimes:{2}",
                                  ScheduleRunFrequency, 
                                  TraceUtils.GetString(ScheduleRunDays), 
                                  TraceUtils.GetString(ScheduleRunTimes));
        }
    }
}

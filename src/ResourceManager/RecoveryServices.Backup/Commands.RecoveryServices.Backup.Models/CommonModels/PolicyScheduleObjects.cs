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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class AzureRmRecoveryServicesSimpleSchedulePolicy : AzureRmRecoveryServicesSchedulePolicyBase
    {        
        public string ScheduleRunFrequency { get; set; }   
   
        public List<string> ScheduleRunDays { get; set; }
       
        public List<DateTime> ScheduleRunTimes { get; set; }

        public override void Validate()
        {
            ScheduleRunType schedRun;
            if (!Enum.TryParse<ScheduleRunType>(ScheduleRunFrequency, out schedRun) || schedRun == ScheduleRunType.Invalid)
            {
                throw new ArgumentException("", "scheduleRunType");
            }

            //Currently only one scheduled run time is allowed
            if (ScheduleRunTimes == null || ScheduleRunTimes.Count != 1)
            {
                throw new ArgumentException("", "ScheduleRunTimes");
            }

            //Validate that the schedule runtime is in multiples of 30 Mins
            if (ScheduleRunTimes[0].Minute % 30 != 0 || ScheduleRunTimes[0].Second != 0 || ScheduleRunTimes[0].Millisecond != 0)
            {
                throw new ArgumentException("ScheduleTimes must be of multiples of 30 Mins with Seconds and milliseconds set to 0 ",
                    "ScheduleRunTimes");
            }

            if (schedRun == ScheduleRunType.Weekly)
            {
                if (ScheduleRunDays == null || ScheduleRunDays.Count == 0)
                {
                    throw new ArgumentException("", "scheduleRunDays");
                }

                // validate scheduleRunsdays content 
                foreach (var day in ScheduleRunDays)
                {
                    DayOfWeek weekDay;
                    if (!Enum.TryParse<DayOfWeek>(day, out weekDay))
                    {
                        throw new ArgumentException("ScheduleRunDays content is invalid");
                    }
                }
            }
        }

        public override string ToString()
        {
            return String.Format("scheduleRunType:{0}, ScheduleRunDays:{1}, ScheduleRunTimes:{2}",
                                  ScheduleRunFrequency, ScheduleRunDays, ScheduleRunTimes);
        }
    }
}

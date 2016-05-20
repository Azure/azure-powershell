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

using Microsoft.Azure.Commands.DevTestLabs.Models;
using Microsoft.Azure.Management.DevTestLabs;
using Microsoft.Azure.Management.DevTestLabs.Models;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDtlAutoStartPolicy", HelpUri = Constants.DevTestLabsHelpUri, DefaultParameterSetName = ParameterSetEnable)]
    [OutputType(typeof(Schedule))]
    public class SetAzureRmDtlAutoStartPolicy : DtlPolicyCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Time of day when virtual machines can be auto-started.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 4,
            HelpMessage = "Time of day when virtual machines can be auto-started.")]
        [ValidateNotNullOrEmpty]
        public DateTime Time { get; set; }

        /// <summary>
        /// Days of the week when virtual machines can be auto-started.
        /// </summary>
        [Parameter(Mandatory = false,
            Position = 5,
            HelpMessage = "Days of the week when virtual machines can be auto-started.")]
        public DayOfWeek[] Days { get; set; }

        #endregion Input Parameter Definitions

        public override void ExecuteCmdlet()
        {
            var schedule = DataServiceClient.Schedule.CreateOrUpdateResource(
                ResourceGroupName,
                LabName,
                WellKnownPolicyNames.LabVmsAutoStart,
                new Schedule
                {
                    TimeZoneId = TimeZoneInfo.Local.Id,
                    TaskType = TaskType.LabVmsStartupTask,
                    WeeklyRecurrence = new WeekDetails
                    {
                        Time = Time.ToString("HHmm"),
                        Weekdays = Days == null ? null : Days.Select(i => i.ToString()).ToList()
                    },
                    Status = Enable ? PolicyStatus.Enabled : PolicyStatus.Disabled,
                }
                );

            WriteObject(schedule.DuckType<ScheduleDisplay>());
        }
    }
}

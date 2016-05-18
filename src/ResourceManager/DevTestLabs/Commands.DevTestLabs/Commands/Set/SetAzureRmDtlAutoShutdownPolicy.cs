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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDtlAutoShutdownPolicy", HelpUri = Constants.DevTestLabsHelpUri, DefaultParameterSetName = ParameterSetEnable)]
    [OutputType(typeof(Schedule))]
    public class SetAzureRmDtlAutoShutdownPolicy : DtlPolicyCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Time of day for shutting down the virtual machine.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 4,
            HelpMessage = "Time of day for shutting down the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public DateTime Time { get; set; }

        #endregion Input Parameter Definitions

        public override void ExecuteCmdlet()
        {
            var schedule = DataServiceClient.Schedule.CreateOrUpdateResource(
                ResourceGroupName,
                LabName,
                WellKnownPolicyNames.LabVmsShutdown,
                new Schedule
                {
                    TimeZoneId = TimeZoneInfo.Local.Id,
                    TaskType = TaskType.LabVmsShutdownTask,
                    DailyRecurrence = new DayDetails
                    {
                        Time = Time.ToString("HHmm")
                    },
                    Status = Enable ? PolicyStatus.Enabled : PolicyStatus.Disabled,
                }
                );

            WriteObject(schedule.DuckType<ScheduleDisplay>());
        }
    }
}

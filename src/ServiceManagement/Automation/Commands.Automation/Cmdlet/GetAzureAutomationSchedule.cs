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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation schedules for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureAutomationSchedule", DefaultParameterSetName = ByAll)]
    [OutputType(typeof(Schedule))]
    public class GetAzureAutomationSchedule : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// The get schedule by schedule id parameter set.
        /// </summary>
        private const string ByScheduleId = "ByScheduleId";

        /// <summary>
        /// The get schedule by schedule name parameter set.
        /// </summary>
        private const string ByScheduleName = "ByScheduleName";

        /// <summary>
        /// The get all parameter set.
        /// </summary>
        private const string ByAll = "ByAll";

        /// <summary>
        /// Gets or sets the schedule id.
        /// </summary>
        [Parameter(ParameterSetName = ByScheduleId, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule id.")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the schedule name.
        /// </summary>
        [Parameter(ParameterSetName = ByScheduleName, Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The schedule name.")]
        public string Name { get; set; }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationExecuteCmdlet()
        {
            IEnumerable<Schedule> schedules;
            if (this.Id.HasValue)
            {
                // ByScheduleId
                schedules = new List<Schedule>
                                {
                                    this.AutomationClient.GetSchedule(
                                        this.AutomationAccountName, this.Id.Value)
                                };

            }
            else if (this.Name != null)
            {
                // ByScheduleName
                schedules = new List<Schedule>
                                {
                                    this.AutomationClient.GetSchedule(
                                        this.AutomationAccountName, this.Name)
                                };
            }
            else
            {
                // ByAll
                schedules = this.AutomationClient.ListSchedules(this.AutomationAccountName);
            }

            this.WriteSchedule(schedules);
        }

        /// <summary>
        /// Writes a OneTimeSchedule, DailySchedule or HourlySchedule to the pipeline.
        /// </summary>
        /// <param name="schedules">
        /// The schedules.
        /// </param>
        private void WriteSchedule(IEnumerable<Schedule> schedules)
        {
            foreach (var schedule in schedules)
            {
                var dailySchedule = schedule as DailySchedule;
                if (dailySchedule != null)
                {
                    this.WriteObject(dailySchedule);
                    continue;
                }

                var hourlySchedule = schedule as HourlySchedule;
                if (hourlySchedule != null)
                {
                    this.WriteObject(hourlySchedule);
                    continue;
                }

                var oneTimeSchedule = schedule as OneTimeSchedule;
                if (oneTimeSchedule != null)
                {
                    this.WriteObject(oneTimeSchedule);
                }
            }
        }
    }
}

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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System;

namespace Microsoft.Azure.Commands.Automation.Model
{
    /// <summary>
    /// The Schedule.
    /// </summary>
    public class Schedule : BaseProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="automationAccountName">
        /// The automation account name.
        /// </param> 
        /// <param name="schedule">
        /// The schedule.
        /// </param>
        public Schedule(string resourceGroupName, string automationAccountName, Azure.Management.Automation.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();
            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.Name = schedule.Name;
            this.Description = schedule.Properties.Description;
            this.StartTime = schedule.Properties.StartTime.ToLocalTime();
            this.ExpiryTime = schedule.Properties.ExpiryTime.ToLocalTime();
            this.CreationTime = schedule.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = schedule.Properties.LastModifiedTime.ToLocalTime();
            this.IsEnabled = schedule.Properties.IsEnabled;
            this.NextRun = schedule.Properties.NextRun.HasValue
                               ? schedule.Properties.NextRun.Value.ToLocalTime()
                               : this.NextRun;
            this.Interval = schedule.Properties.Interval.HasValue ? schedule.Properties.Interval.Value : this.Interval;
            this.Frequency = (ScheduleFrequency)Enum.Parse(typeof(ScheduleFrequency), schedule.Properties.Frequency, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HourlySchedule"/> class.
        /// </summary>
        public Schedule()
        {
        }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets or sets the expiry time.
        /// </summary>
        public DateTimeOffset ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is enabled.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the next run.
        /// </summary>
        public DateTimeOffset? NextRun { get; set; }

        /// <summary>
        /// Gets or sets the schedule interval.
        /// </summary>
        public byte? Interval { get; set; }

        /// <summary>
        /// Gets or sets the schedule frequency.
        /// </summary>
        public ScheduleFrequency Frequency { get; set; }
    }
}

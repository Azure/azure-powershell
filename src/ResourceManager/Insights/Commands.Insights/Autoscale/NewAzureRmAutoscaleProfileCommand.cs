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

using Microsoft.Azure.Management.Monitor.Management.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Insights.Autoscale
{
    /// <summary>
    /// Create an autoscale profile
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutoscaleProfile"), OutputType(typeof(AutoscaleProfile))]
    public class NewAzureRmAutoscaleProfileCommand : MonitorCmdletBase
    {
        private const string AddAutoscaleProfileNoScheduleParamGroup = "CreateWithoutScheduledTimes";
        private const string AddAutoscaleProfileFixDateParamGroup = "CreateWithFixedDateScheduling";
        private const string AddAutoscaleProfileRecurrenceParamGroup = "CreateUsingRecurrentScheduling";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileNoScheduleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the profile")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the default capacity
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileNoScheduleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The default capacity for the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The default capacity for the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The default capacity for the profile")]
        [ValidateNotNullOrEmpty]
        public string DefaultCapacity { get; set; }

        /// <summary>
        /// Gets or sets the maximum capacity
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileNoScheduleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum capacity for the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum capacity for the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The maximum capacity for the profile")]
        [ValidateNotNullOrEmpty]
        public string MaximumCapacity { get; set; }

        /// <summary>
        /// Gets or sets the minimum capacity
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileNoScheduleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The minimum capacity for the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The minimum capacity for the profile")]
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The minimum capacity for the profile")]
        [ValidateNotNullOrEmpty]
        public string MinimumCapacity { get; set; }

        /// <summary>
        /// Gets or sets the start of the time window
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The start time for the schedule")]
        public DateTime StartTimeWindow { get; set; }

        /// <summary>
        /// Gets or sets the end of the time window
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The end time for the schedule")]
        public DateTime EndTimeWindow { get; set; }

        /// <summary>
        /// Gets or sets the timezone of the time window
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The time zone time for the schedule")]
        [ValidateNotNullOrEmpty]
        public string TimeWindowTimeZone { get; set; }

        /// <summary>
        /// Gets or sets the recurrence frequency
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The recurrence frequency for the setting")]
        public RecurrenceFrequency RecurrenceFrequency { get; set; }

        /// <summary>
        /// Gets or sets the ScheduleDays
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule days for the recurrence")]
        [ValidateNotNull]
        [Alias("ScheduleDays")]
        public List<string> ScheduleDay { get; set; }

        /// <summary>
        /// Gets or sets the ScheduleHours
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule hours for the recurrence")]
        [ValidateNotNull]
        [Alias("ScheduleHours")]
        public List<int?> ScheduleHour { get; set; }

        /// <summary>
        /// Gets or sets the ScheduleMinutes
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule minutes for the recurrence")]
        [ValidateNotNull]
        [Alias("ScheduleMinutes")]
        public List<int?> ScheduleMinute { get; set; }

        /// <summary>
        /// Gets or sets the ScheduleTimeZone
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule timezone for the recurrence")]
        public string ScheduleTimeZone { get; set; }

        /// <summary>
        /// Gets or sets the Rules
        /// </summary>
        [Parameter(ParameterSetName = AddAutoscaleProfileNoScheduleParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rules for the setting")]
        [Parameter(ParameterSetName = AddAutoscaleProfileFixDateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rules for the setting")]
        [Parameter(ParameterSetName = AddAutoscaleProfileRecurrenceParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The rules for the setting")]
        [ValidateNotNullOrEmpty]
        [Alias("Rules")]
        public List<ScaleRule> Rule { get; set; }

        #endregion

        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected override void ProcessRecordInternal()
        { }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "New-AzureRmAutoscaleProfile",
                topic: "Parameter name change", 
                message: "The parameter plural names for the parameters will be deprecated in a future breaking change release in favor of the singular versions of the same names.");
            AutoscaleProfile profile = this.CreateSettingProfile();
            WriteObject(profile);
        }

        /// <summary>
        /// Create an autoscale profile based on the properties of the object
        /// </summary>
        /// <returns>An autoscale profile based on the properties of the object</returns>
        public AutoscaleProfile CreateSettingProfile()
        {
            return new AutoscaleProfile
            {
                Name = this.Name ?? string.Empty,
                Capacity = new ScaleCapacity()
                {
                    DefaultProperty = this.DefaultCapacity,
                    Minimum = this.MinimumCapacity,
                    Maximum = this.MaximumCapacity,
                },

                // NOTE: "always" is specify by a null value in the FixedDate value with null ScheduledDays(Minutes, Seconds)
                // Premise: Fixed date schedule and recurrence are mutually exclusive, but they can both be missing so that the rule is always enabled.
                // Assuming dates are validated by the server
                FixedDate = this.ScheduleDay == null && (this.StartTimeWindow != default(DateTime) || this.EndTimeWindow != default(DateTime))
                        ? new TimeWindow()
                        {
                            Start = this.StartTimeWindow,
                            End = this.EndTimeWindow,
                            TimeZone = this.TimeWindowTimeZone,
                        }
                        : null,
                Recurrence = this.ScheduleDay != null ? this.CreateAutoscaleRecurrence() : null,
                Rules = this.Rule,
            };
        }

        /// <summary>
        /// Create a Recurrence based on the properties of this object
        /// </summary>
        /// <returns>A Recurrence created based on the properties of this object</returns>
        public Recurrence CreateAutoscaleRecurrence()
        {
            return new Recurrence()
            {
                Frequency = this.RecurrenceFrequency,
                Schedule = this.CreateRecurrentSchedule()
            };
        }

        private RecurrentSchedule CreateRecurrentSchedule()
        {
            // Assuming validation is done by the server
            return new RecurrentSchedule()
            {
                Days = this.ScheduleDay,

                Hours = this.ScheduleHour,
                Minutes = this.ScheduleMinute,
                TimeZone = this.ScheduleTimeZone,
            };
        }
    }
}

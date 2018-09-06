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
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using DayOfWeek = Microsoft.Azure.Commands.Automation.Model.DayOfWeek;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Creates an azure automation Schedule.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmAutomationSchedule", DefaultParameterSetName = AutomationCmdletParameterSets.ByDaily)]
    [OutputType(typeof(Schedule))]
    public class NewAzureAutomationSoftwareUpdateConfiguration : AzureAutomationBaseCmdlet
    {
        private const string COMMA = ",";
        private const string Windows = "Windows";
        /// <summary>
        /// Initializes a new instance of the <see cref="NewAzureAutomationSchedule"/> class.
        /// </summary>
        public NewAzureAutomationSoftwareUpdateConfiguration()
        {
            this.ExpiryTime = Constants.DefaultScheduleExpiryTime;
        }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The software update configuration name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule start time.")]
        [ValidateNotNull]
        public DateTimeOffset StartTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The software update configuration description.")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The schedule time zone.")]
        public string TimeZone { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Maximum duration of the software update configuration run.")]
        public TimeSpan MaximumDuration { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyWindows, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyWindows, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyWindows, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthWindows, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekWindows, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyLinux, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyLinux, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyLinux, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthLinux, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekLinux, Mandatory = false, HelpMessage = "The schedule expiry time.")]
        public DateTimeOffset ExpiryTime { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "List of azure virtual machine resource Ids.")]
        public string[] AzureVMs { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "List of non-azure computer names.")]
        public string[] NonAzureComputers { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTimeWindows, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTimeLinux, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        public SwitchParameter OneTime { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyWindows, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyLinux, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte HourInterval { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyWindows, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyLinux, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte DayInterval { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyWindows, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyLinux, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte WeekInterval { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyWindows, Mandatory = false, HelpMessage = "The list of days of week for the weekly schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyLinux, Mandatory = false, HelpMessage = "The list of days of week for the weekly schedule.")]
        public System.DayOfWeek[] DaysOfWeek { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthWindows, Mandatory = true, HelpMessage = "The monthly schedule month interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekWindows, Mandatory = true, HelpMessage = "The monthly schedule month interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthLinux, Mandatory = true, HelpMessage = "The monthly schedule month interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekLinux, Mandatory = true, HelpMessage = "The monthly schedule month interval.")]
        [ValidateRange(1, byte.MaxValue)]
        public byte MonthInterval { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthWindows, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthLinux, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        public DaysOfMonth[] DaysOfMonth { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekWindows, Mandatory = false, HelpMessage = "The day of week for the monthly occurrence.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekLinux, Mandatory = false, HelpMessage = "The day of week for the monthly occurrence.")]
        public System.DayOfWeek? DayOfWeek { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekWindows, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekLinux, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        public DayOfWeekOccurrence DayOfWeekOccurrence { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTimeWindows, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyWindows, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyWindows, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyWindows, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthWindows, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekWindows, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        [ValidateSet("Unclassified", "Critical", "Security", "UpdateRollup", "FeaturePack", "ServicePack", "Definition", "Tools", "Updates")]
        public string[] IncludedUpdateClassifications { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTimeWindows, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyWindows, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyWindows, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyWindows, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthWindows, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekWindows, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        public string[] ExcludedKbNumbers { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTimeLinux, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyLinux, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyLinux, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyLinux, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthLinux, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekLinux, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        [ValidateSet("Unclassified", "Critical", "Security", "Other")]
        public string[] IncludedPackageClassifications { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByOneTimeLinux, Mandatory = true, HelpMessage = "To create a one time schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByHourlyLinux, Mandatory = true, HelpMessage = "The hourly schedule hour interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByDailyLinux, Mandatory = true, HelpMessage = "The daily schedule day interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByWeeklyLinux, Mandatory = true, HelpMessage = "The weekly schedule week interval.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDaysOfMonthLinux, Mandatory = false, HelpMessage = "The list of days of month for the monthly schedule.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByMonthlyDayOfWeekLinux, Mandatory = false, HelpMessage = "The Occurrence of the week within the month.")]
        public string[] ExcludedPackageNameMasks { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            // must pass some target machines
            if((this.AzureVMs == null || !this.AzureVMs.Any()) && (this.NonAzureComputers == null|| !this.NonAzureComputers.Any()))
            {
                throw new ArgumentException(Resources.MonthlyScheduleNeedsDayOfWeekAndOccurrence2);
            }

            var updateConfiguration = new UpdateConfiguration()
            {
                Duration = this.MaximumDuration,
                AzureVirtualMachines = this.AzureVMs,
                NonAzureComputerNames = this.NonAzureComputers,
                OperatingSystem = this.IsWindows ? OperatingSystemType.Windows : OperatingSystemType.Linux
            };

            if(this.IsWindows)
            {
                updateConfiguration.Windows = new WindowsProperties
                {
                    ExcludedKbNumbers = this.ExcludedKbNumbers,
                    IncludedUpdateClassifications = string.Join(",", this.IncludedUpdateClassifications)
                };
            }
            else
            {
                updateConfiguration.Linux = new LinuxProperties
                {
                    IncludedPackageClassifications = string.Join(COMMA, this.IncludedPackageClassifications),
                    ExcludedPackageNameMasks = this.ExcludedPackageNameMasks
                };
            }

            var suc = new SoftwareUpdateConfiguration()
            {
                UpdateConfiguration = updateConfiguration,
                ScheduleInfo = new ScheduleProperties
                {
                    StartTime = this.StartTime,
                    ExpiryTime = this.ExpiryTime,
                }
            };

            
            this.WriteObject(suc);
        }

        private bool IsWindows
        {
            get
            {
                return this.ParameterSetName.Contains(Windows);
            }
        }

        private ScheduleProperties CreateScheduleProperties()
        {
            var scheduleProperties = new ScheduleProperties
            {
                StartTime = this.StartTime,
                ExpiryTime = this.ExpiryTime,
                TimeZone = this.TimeZone,
                AdvancedSchedule = new AdvancedSchedule()
            };

            switch (this.ParameterSetName)
            {
                case AutomationCmdletParameterSets.ByOneTime:
                    scheduleProperties.Frequency = Management.Automation.Models.ScheduleFrequency.OneTime;
                    break;
                case AutomationCmdletParameterSets.ByDaily:
                    scheduleProperties.Frequency = Management.Automation.Models.ScheduleFrequency.Day;
                    scheduleProperties.Interval = this.DayInterval;
                    break;
                case AutomationCmdletParameterSets.ByHourly:
                    scheduleProperties.Frequency = Management.Automation.Models.ScheduleFrequency.Hour;
                    scheduleProperties.Interval = this.HourInterval;
                    break;
                case AutomationCmdletParameterSets.ByWeekly:
                    scheduleProperties.Frequency = Management.Automation.Models.ScheduleFrequency.Week;
                    scheduleProperties.Interval = this.WeekInterval;
                    scheduleProperties.AdvancedSchedule = this.DaysOfWeek == null ? null : new AdvancedSchedule
                    {
                        WeekDays = this.DaysOfWeek.Select(day => day.ToString()).ToList()
                    };
                    break;
                case AutomationCmdletParameterSets.ByMonthlyDayOfWeek:
                    scheduleProperties.Frequency = Management.Automation.Models.ScheduleFrequency.Month;
                    scheduleProperties.Interval = this.MonthInterval;
                    schedule = this.CreateMonthlyScheduleModel();
                    break;
                case AutomationCmdletParameterSets.ByMonthlyDaysOfMonth:
                    scheduleProperties.Frequency = Management.Automation.Models.ScheduleFrequency.Month;
                    schedule = this.CreateMonthlyScheduleModel();
                    break;
            }
        }
    }
}

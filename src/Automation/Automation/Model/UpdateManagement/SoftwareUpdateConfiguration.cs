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

namespace Microsoft.Azure.Commands.Automation.Model.UpdateManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sdk = Microsoft.Azure.Management.Automation.Models;

    public class SoftwareUpdateConfiguration : BaseProperties
    {
        public UpdateConfiguration UpdateConfiguration { get; set; }

        public Schedule ScheduleConfiguration { get; set; }

        public string ProvisioningState { get; set; }

        public ErrorInfo ErrorInfo { get; set; }

        internal SoftwareUpdateConfiguration() { }

        internal SoftwareUpdateConfiguration(string ResourceGroupName, string automationAccountName, Sdk.SoftwareUpdateConfigurationCollectionItem suc)
        {
            this.ResourceGroupName = ResourceGroupName;
            AutomationAccountName = automationAccountName;
            Name = suc.Name;
            CreationTime = suc.CreationTime;
            ScheduleConfiguration = new Schedule
            {
                Frequency = (ScheduleFrequency)Enum.Parse(typeof(ScheduleFrequency), suc.Frequency, true),
                StartTime = suc.StartTime,
                NextRun = suc.NextRun
            };
            UpdateConfiguration = new UpdateConfiguration()
            {
                Duration = suc.UpdateConfiguration.Duration,
                AzureVirtualMachines = suc.UpdateConfiguration.AzureVirtualMachines
            };
            LastModifiedTime = suc.LastModifiedTime;
            ProvisioningState = suc.ProvisioningState;
        }

        internal SoftwareUpdateConfiguration(string resourceGroupName, string automationAccountName, Sdk.SoftwareUpdateConfiguration suc)
        {
            this.ResourceGroupName = resourceGroupName;
            this.AutomationAccountName = automationAccountName;
            this.CreationTime = suc.CreationTime;
            this.Description = suc.ScheduleInfo.Description;
            this.ErrorInfo = suc.Error == null ? null : new ErrorInfo
            {
                Code = suc.Error.Code,
                Message = suc.Error.Message
            };
            this.LastModifiedTime = suc.LastModifiedTime;
            this.Name = suc.Name;
            this.ProvisioningState = suc.ProvisioningState;
            var schedule = new Sdk.Schedule
            {
                CreationTime = suc.ScheduleInfo.CreationTime,
                Description = suc.ScheduleInfo.Description,
                ExpiryTime = suc.ScheduleInfo.ExpiryTime,
                ExpiryTimeOffsetMinutes = suc.ScheduleInfo.ExpiryTimeOffsetMinutes,
                Frequency = suc.ScheduleInfo.Frequency,
                Interval = suc.ScheduleInfo.Interval,
                IsEnabled = suc.ScheduleInfo.IsEnabled,
                LastModifiedTime = suc.ScheduleInfo.LastModifiedTime,
                AdvancedSchedule = suc.ScheduleInfo.AdvancedSchedule,
                StartTime = suc.ScheduleInfo.StartTime,
                TimeZone = suc.ScheduleInfo.TimeZone,
                NextRun = suc.ScheduleInfo.NextRun,
                NextRunOffsetMinutes = suc.ScheduleInfo.NextRunOffsetMinutes
            };

            this.ScheduleConfiguration = new Schedule(resourceGroupName, automationAccountName, schedule);

            this.UpdateConfiguration = new UpdateConfiguration
            {
                OperatingSystem = (OperatingSystemType)suc.UpdateConfiguration.OperatingSystem,
                AzureVirtualMachines = suc.UpdateConfiguration.AzureVirtualMachines,
                NonAzureComputers = suc.UpdateConfiguration.NonAzureComputerNames,
                Duration = suc.UpdateConfiguration.Duration,
                Linux = suc.UpdateConfiguration.OperatingSystem == Sdk.OperatingSystemType.Windows ? null :
                    new LinuxConfiguration
                    {
                        IncludedPackageClassifications = StringToEnumList<LinuxPackageClasses>(suc.UpdateConfiguration.Linux.IncludedPackageClassifications),
                        IncludedPackageNameMasks = suc.UpdateConfiguration.Linux.IncludedPackageNameMasks,
                        ExcludedPackageNameMasks = suc.UpdateConfiguration.Linux.ExcludedPackageNameMasks
                    },
                Windows = suc.UpdateConfiguration.OperatingSystem == Sdk.OperatingSystemType.Linux ? null :
                    new WindowsConfiguration
                    {
                        IncludedUpdateClassifications = StringToEnumList<WindowsUpdateClasses>(suc.UpdateConfiguration.Windows.IncludedUpdateClassifications),
                        IncludedKbNumbers = suc.UpdateConfiguration.Windows.IncludedKbNumbers,
                        ExcludedKbNumbers = suc.UpdateConfiguration.Windows.ExcludedKbNumbers
                    }
            };
        }

        private static IList<T> StringToEnumList<T>(string classes)
        {
            return classes.Split(new[] { ',' })
                            .Select(p => p.Trim())
                            .Select(p => (T)Enum.Parse(typeof(T), p, true))
                            .ToList();
        }
    }
}

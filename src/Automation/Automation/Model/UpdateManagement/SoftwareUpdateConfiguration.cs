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

        public Tasks Tasks { get; set; }

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

            this.Tasks = suc.Tasks != null ? new Tasks
            {
                PreTask = suc.Tasks.PreTask != null ? new Task { source = suc.Tasks.PreTask.Source, parameters = suc.Tasks.PreTask.Parameters } : null,
                PostTask = suc.Tasks.PostTask != null ? new Task { source = suc.Tasks.PostTask.Source, parameters = suc.Tasks.PostTask.Parameters } : null

            } : null;

            IList<AzureQueryProperties> azureQueries = null;
            if (suc.UpdateConfiguration != null && suc.UpdateConfiguration.Targets != null && suc.UpdateConfiguration.Targets.AzureQueries != null)
            {
                azureQueries = new List<AzureQueryProperties>();

                foreach (var query in suc.UpdateConfiguration.Targets.AzureQueries)
                {
                    var tags = new Dictionary<string, List<string>>();
                    if(query!= null && query.TagSettings!= null && query.TagSettings.Tags != null)
                    {
                        foreach (var tag in query.TagSettings.Tags)
                        {
                            tags.Add(tag.Key, new List<string>(tag.Value));
                        }
                    }
                    var azureQueryProperty = new AzureQueryProperties
                    {
                        Locations = (query == null || query.Locations == null) ? null : query.Locations.ToArray(),
                        Scope = (query == null || query.Scope == null) ? null : query.Scope.ToArray(),
                        TagSettings = (query == null || query.TagSettings == null) ? null : new TagSettings
                        {
                            Tags =  query.TagSettings.Tags == null ? null : tags,
                            FilterOperator = query.TagSettings.FilterOperator == null ? TagOperators.Any : (TagOperators)query.TagSettings.FilterOperator
                        }
                    };
                    azureQueries.Add(azureQueryProperty);
                }

            }

            IList<NonAzureQueryProperties> nonAzureQueries = null;
            if (suc.UpdateConfiguration != null && suc.UpdateConfiguration.Targets != null && suc.UpdateConfiguration.Targets.NonAzureQueries != null)
            {
                nonAzureQueries = new List<NonAzureQueryProperties>();

                foreach (var query in suc.UpdateConfiguration.Targets.NonAzureQueries)
                {
                    var nonAzureQuery = new NonAzureQueryProperties
                    {
                        FunctionAlias = query.FunctionAlias,
                        WorkspaceResourceId = query.WorkspaceId
                    };
                    nonAzureQueries.Add(nonAzureQuery);
                }
            }

            var updateTarget = suc.UpdateConfiguration.Targets == null
                ? null
                : new UpdateTargets
                {
                    AzureQueries = azureQueries,
                    NonAzureQueries = nonAzureQueries
                };

            this.ScheduleConfiguration = new Schedule(resourceGroupName, automationAccountName, schedule);

            this.UpdateConfiguration = new UpdateConfiguration
            {
                OperatingSystem = (OperatingSystemType)suc.UpdateConfiguration.OperatingSystem,
                AzureVirtualMachines = suc.UpdateConfiguration.AzureVirtualMachines,
                NonAzureComputers = suc.UpdateConfiguration.NonAzureComputerNames,
                Targets = updateTarget,
                Duration = suc.UpdateConfiguration.Duration,
                Linux = suc.UpdateConfiguration.OperatingSystem == Sdk.OperatingSystemType.Windows ? null :
                    new LinuxConfiguration
                    {
                        IncludedPackageClassifications = StringToEnumList<LinuxPackageClasses>(suc.UpdateConfiguration.Linux.IncludedPackageClassifications),
                        IncludedPackageNameMasks = suc.UpdateConfiguration.Linux.IncludedPackageNameMasks,
                        ExcludedPackageNameMasks = suc.UpdateConfiguration.Linux.ExcludedPackageNameMasks,
                        rebootSetting = (RebootSetting)Enum.Parse(typeof(RebootSetting), suc.UpdateConfiguration.Linux.RebootSetting, true)
                    },
                Windows = suc.UpdateConfiguration.OperatingSystem == Sdk.OperatingSystemType.Linux ? null :
                    new WindowsConfiguration
                    {
                        IncludedUpdateClassifications = StringToEnumList<WindowsUpdateClasses>(suc.UpdateConfiguration.Windows.IncludedUpdateClassifications),
                        IncludedKbNumbers = suc.UpdateConfiguration.Windows.IncludedKbNumbers,
                        ExcludedKbNumbers = suc.UpdateConfiguration.Windows.ExcludedKbNumbers,
                        rebootSetting = (RebootSetting)Enum.Parse(typeof(RebootSetting), suc.UpdateConfiguration.Windows.RebootSetting, true)
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

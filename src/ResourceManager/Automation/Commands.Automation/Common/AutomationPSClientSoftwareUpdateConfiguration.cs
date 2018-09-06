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

namespace Microsoft.Azure.Commands.Automation.Common
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Automation.Model.UpdateManagement;
    using Microsoft.Azure.Management.Automation;
    using Sdk = Management.Automation.Models;

    public partial class AutomationPSClient : IAutomationPSClient
    {
        #region Software Update Configuration

        public SoftwareUpdateConfiguration CreateSoftwareUpdateConfiguration(string resourceGroupName, string automationAccountName, SoftwareUpdateConfiguration configuration)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var updateConfig = configuration.UpdateConfiguration;

                var sucParameters = new Sdk.SoftwareUpdateConfiguration()
                {
                    ScheduleInfo = new Sdk.ScheduleProperties()
                    {
                        StartTime = configuration.ScheduleConfiguration.StartTime.ToUniversalTime(),
                        ExpiryTime = configuration.ScheduleConfiguration.ExpiryTime.ToUniversalTime(),
                        Frequency = configuration.ScheduleConfiguration.Frequency.ToString(),
                        Interval = configuration.ScheduleConfiguration.Interval,
                        IsEnabled = configuration.ScheduleConfiguration.IsEnabled,
                        TimeZone = configuration.ScheduleConfiguration.TimeZone,
                        AdvancedSchedule = configuration.ScheduleConfiguration.GetAdvancedSchedule()
                    },
                    UpdateConfiguration = new Sdk.UpdateConfiguration()
                    {
                        OperatingSystem = updateConfig.OperatingSystem == OperatingSystemType.Windows ? 
                                                    Sdk.OperatingSystemType.Windows : Sdk.OperatingSystemType.Linux,
                        Windows = updateConfig.OperatingSystem == OperatingSystemType.Linux ? null : new Sdk.WindowsProperties()
                        {
                            IncludedUpdateClassifications = updateConfig.Windows != null && updateConfig.Windows.IncludedUpdateClassifications != null 
                                ? string.Join(",", updateConfig.Windows.IncludedUpdateClassifications.Select(c => c.ToString())) 
                                : null,
                            ExcludedKbNumbers = updateConfig.Windows != null ? updateConfig.Windows.ExcludedKbNumbers : null
                        },
                        Linux = updateConfig.OperatingSystem == OperatingSystemType.Windows ? null : new Sdk.LinuxProperties()
                        {
                            IncludedPackageClassifications = updateConfig.Linux != null && updateConfig.Linux.IncludedPackageClassifications != null 
                                ? string.Join(",", updateConfig.Linux.IncludedPackageClassifications.Select(c=>c.ToString()))
                                : null,
                            ExcludedPackageNameMasks = updateConfig.Linux != null ? updateConfig.Linux.ExcludedPackageNameMasks : null
                        },
                        Duration = updateConfig.Duration,
                        AzureVirtualMachines = updateConfig.AzureVirtualMachines,
                        NonAzureComputerNames = updateConfig.NonAzureComputers
                    }
                };

                var suc = this.automationManagementClient.SoftwareUpdateConfigurations.Create(resourceGroupName, automationAccountName, configuration.Name, sucParameters);
                return new SoftwareUpdateConfiguration(resourceGroupName, automationAccountName, suc);
            }
        }

        public SoftwareUpdateConfiguration GetSoftwareUpdateConfigurationByName(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("name", name).NotNullOrEmpty();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var suc = this.automationManagementClient.SoftwareUpdateConfigurations.GetByName(resourceGroupName, automationAccountName, name);
                return suc == null ? null : new SoftwareUpdateConfiguration(resourceGroupName, automationAccountName, suc);
            }
        }

        public IEnumerable<SoftwareUpdateConfiguration> ListSoftwareUpdateConfigurations(string resourceGroupName, string automationAccountName, string azureVirtualMachineId = null)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();

            Sdk.SoftwareUpdateConfigurationListResult result;

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                if (string.IsNullOrWhiteSpace(azureVirtualMachineId))
                {
                    result = this.automationManagementClient.SoftwareUpdateConfigurations.List(resourceGroupName, automationAccountName);
                }
                else
                {
                    result = this.automationManagementClient.SoftwareUpdateConfigurations.ListByAzureVirtualMachine(resourceGroupName, automationAccountName, azureVirtualMachineId);
                }

                return result.Value.Select(item => new SoftwareUpdateConfiguration(resourceGroupName, automationAccountName, item)).ToList();
            }
        }

        public void DeleteSoftwareUpdateConfiguration(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();
            Requires.Argument("name", name).NotNullOrEmpty();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                this.automationManagementClient.SoftwareUpdateConfigurations.Delete(resourceGroupName, automationAccountName, name);
            }
        }

        #endregion

        #region Software Update Configuration Run

        public SoftwareUpdateRun GetSoftwareUpdateRunById(string resourceGroupName, string automationAccountName, Guid id)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var sucr = this.automationManagementClient.SoftwareUpdateConfigurationRuns.GetById(resourceGroupName, automationAccountName, id);
                return new SoftwareUpdateRun(resourceGroupName, automationAccountName, sucr);
            }
        }

        public IEnumerable<SoftwareUpdateRun> ListSoftwareUpdateRuns(
            string resourceGroupName,
            string automationAccountName,
            string softwareUpdateConfigurationName = null,
            OperatingSystemType? operatingSystem = null,
            DateTimeOffset? startTime = null,
            SoftwareUpdateRunStatus? status = null)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var sucrs = this.automationManagementClient.SoftwareUpdateConfigurationRuns.ListAll(
                    resourceGroupName, 
                    automationAccountName, 
                    softwareUpdateConfigurationName,
                    operatingSystem.ToString(),
                    status.ToString(),
                    startTime.HasValue ? startTime.Value.DateTime.ToUniversalTime() : (DateTime?)null);
                return sucrs.Value.Select(sucr =>  new SoftwareUpdateRun(resourceGroupName, automationAccountName, sucr));
            }
        }
        #endregion

        #region Software Update Configuration Machine Run
        public SoftwareUpdateMachineRun GetSoftwareUpdateMachineRunById(string resourceGroupName, string automationAccountName, Guid id)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var sucmr = this.automationManagementClient.SoftwareUpdateConfigurationMachineRuns.GetById(resourceGroupName, automationAccountName, id);
                return new SoftwareUpdateMachineRun(resourceGroupName, automationAccountName, sucmr);
            }
        }

        public IEnumerable<SoftwareUpdateMachineRun> ListSoftwareUpdateMachineRuns(
            string resourceGroupName,
            string automationAccountName,
            Guid? softwareUpdateConfigurationRunId = null,
            string targetComputer = null,
            SoftwareUpdateMachineRunStatus? status = null)
        {
            Requires.Argument("resourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("automationAccountName", automationAccountName).NotNullOrEmpty();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var sucmrs = this.automationManagementClient.SoftwareUpdateConfigurationMachineRuns.ListAll(
                    resourceGroupName,
                    automationAccountName,
                    softwareUpdateConfigurationRunId,
                    status.ToString(),
                    targetComputer);
                return sucmrs.Value.Select(item => new SoftwareUpdateMachineRun(resourceGroupName, automationAccountName, item));
            }
        }
        #endregion
    }
}

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

namespace Microsoft.Azure.Commands.Automation.Cmdlet.UpdateManagement
{
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.Azure.Commands.Automation.Common;
    using Microsoft.Azure.Commands.Automation.Model;
    using Microsoft.Azure.Commands.Automation.Model.UpdateManagement;
    using System.Linq;
    using Properties;

    [Cmdlet(VerbsCommon.New, "AzureRmAutomationSoftwareUpdateConfiguration")]
    [OutputType(typeof(SoftwareUpdateConfiguration))]
    public class NewAzureAutomationSoftwareUpdateConfiguration : AzureAutomationBaseCmdlet
    {
        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Schedule object used for software update configuration.")]
        [ValidateNotNull]
        public Schedule Schedule { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates that the software update configuration targeting windows operating system machines.")]
        public SwitchParameter Windows { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates that the software update configuration targeting Linux operating system machines.")]
        public SwitchParameter Linux { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Ids for azure virtual machines.")]
        public string[] AzureVMResourceIds { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Non-Azure computer names.")]
        public string[] NonAzureComputers { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Maximum duration for the update.")]
        public TimeSpan Duration { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Included Windows Update classifications.")]
        public WindowsUpdateClasses[] IncludedUpdateClassifications { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "KB numbers of excluded updates.")]
        public string[] ExcludedKbNumbers { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "KB numbers of included updates.")]
        public string[] IncludedKbNumbers { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Included Linux package classifications.")]
        public LinuxPackageClasses[] IncludedPackageClassifications { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Position = 8, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Excluded Linux package masks.")]
        public string[] ExcludedPackageNameMasks { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Position = 9, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Included Linux package masks.")]
        public string[] IncludedPackageNameMasks { get; set; }

        private bool IsWindows { get { return this.ParameterSetName == AutomationCmdletParameterSets.Windows; } }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if((this.AzureVMResourceIds == null || !this.AzureVMResourceIds.Any()) && (this.NonAzureComputers == null || !this.NonAzureComputers.Any()))
            {
                throw new PSArgumentException(Resources.SoftwareUpdateConfigurationHasNoTargetComputers);
            }

            var suc = new SoftwareUpdateConfiguration()
            {
                Name = this.Schedule.Name,
                Description = this.Schedule.Description,
                ScheduleConfiguration = this.Schedule,
                UpdateConfiguration = new UpdateConfiguration
                {
                    OperatingSystem = this.IsWindows ? OperatingSystemType.Windows : OperatingSystemType.Linux,
                    Windows = !this.IsWindows ? null : new WindowsConfiguration
                    {
                        ExcludedKbNumbers = this.ExcludedKbNumbers,
                        IncludedKbNumbers = this.IncludedKbNumbers,
                        IncludedUpdateClassifications = this.IncludedUpdateClassifications
                    },
                    Linux = this.IsWindows ? null : new LinuxConfiguration
                    {
                        ExcludedPackageNameMasks = this.ExcludedPackageNameMasks,
                        IncludedPackageClassifications = this.IncludedPackageClassifications,
                        IncludedPackageNameMasks = this.IncludedPackageNameMasks
                    },
                    Duration = this.Duration,
                    AzureVirtualMachines = this.AzureVMResourceIds,
                    NonAzureComputers = this.NonAzureComputers
                }
            };

            suc = this.AutomationClient.CreateSoftwareUpdateConfiguration(this.ResourceGroupName, this.AutomationAccountName, suc);
            this.WriteObject(suc);
        }
    }
}

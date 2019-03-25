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

using System.Globalization;

namespace Microsoft.Azure.Commands.Automation.Cmdlet.UpdateManagement
{
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.Azure.Commands.Automation.Common;
    using Models = Microsoft.Azure.Commands.Automation.Model;
    using Microsoft.Azure.Commands.Automation.Model.UpdateManagement;
    using System.Linq;
    using Properties;
    using System.Collections;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSoftwareUpdateConfiguration",
        SupportsShouldProcess = true, DefaultParameterSetName = AutomationCmdletParameterSets.Windows)]
    [OutputType(typeof(SoftwareUpdateConfiguration))]
    public class NewAzureAutomationSoftwareUpdateConfiguration : AzureAutomationBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Schedule object used for software update configuration.")]
        [ValidateNotNull]
        public Models.Schedule Schedule { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates that the software update configuration targeting windows operating system machines.")]
        public SwitchParameter Windows { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates that the software update configuration targeting Linux operating system machines.")]
        public SwitchParameter Linux { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Indicates that the software update configuration will Only Reboot the machines.")]
        public SwitchParameter RebootOnly { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Ids for azure virtual machines.")]
        public string[] AzureVMResourceId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Pre task.")]
        public string PreTaskRunbookName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Post task.")]
        public string PostTaskRunbookName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Pre task parameter.")]
        public Hashtable PreTaskRunbookParameter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Post task parameter.")]
        public Hashtable PostTaskRunbookParameter { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Non-Azure computer names.")]
        public string[] NonAzureComputer { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Dynamic group azure query.")]
        public AzureQueryProperties[] AzureQuery { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Dynamic group non Azure query.")]
        public NonAzureQueryProperties[] NonAzureQuery { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Maximum duration for the update.")]
        public TimeSpan Duration { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Reboot Seeting.")]
        public RebootSetting RebootSetting { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Included Windows Update classifications.")]
        public WindowsUpdateClasses[] IncludedUpdateClassification { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "KB numbers of excluded updates.")]
        public string[] ExcludedKbNumber { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Windows, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "KB numbers of included updates.")]
        public string[] IncludedKbNumber { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Included Linux package classifications.")]
        public LinuxPackageClasses[] IncludedPackageClassification { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Excluded Linux package masks.")]
        public string[] ExcludedPackageNameMask { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.Linux, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Included Linux package masks.")]
        public string[] IncludedPackageNameMask { get; set; }

        private bool IsWindows { get { return this.ParameterSetName == AutomationCmdletParameterSets.Windows; } }

        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            if ((this.AzureVMResourceId == null || !this.AzureVMResourceId.Any()) && 
                (this.NonAzureComputer == null || !this.NonAzureComputer.Any()) &&
                (this.AzureQuery == null || !this.AzureQuery.Any()) &&
                (this.NonAzureQuery == null || !this.NonAzureQuery.Any()))
            {
                throw new PSArgumentException(Resources.SoftwareUpdateConfigurationHasNoTargetComputers);
            }
            var target = (this.AzureQuery == null && this.NonAzureQuery == null) ? null : new UpdateTargets
            {
                AzureQueries = this.AzureQuery == null ? null : this.AzureQuery.ToList(),
                NonAzureQueries = this.NonAzureQuery == null ? null : this.NonAzureQuery.ToList()
            };

            var resource = string.Format(CultureInfo.CurrentCulture, Resources.SoftwareUpdateConfigurationCreateOperation);
            if (ShouldProcess(this.Schedule.Name, resource))
            {
                var suc = new SoftwareUpdateConfiguration()
                {
                    Name = this.Schedule.Name,
                    Description = this.Schedule.Description,
                    ScheduleConfiguration = this.Schedule,
                    UpdateConfiguration = new UpdateConfiguration
                    {
                        OperatingSystem = this.IsWindows ? OperatingSystemType.Windows : OperatingSystemType.Linux,
                        Windows = !this.IsWindows
                            ? null
                            : new WindowsConfiguration
                            {
                                ExcludedKbNumbers = this.ExcludedKbNumber,
                                IncludedKbNumbers = this.IncludedKbNumber,
                                IncludedUpdateClassifications = this.IncludedUpdateClassification,
                                rebootSetting = this.RebootOnly.IsPresent ? RebootSetting.RebootOnly : this.RebootSetting
                            },
                        Linux = this.IsWindows
                            ? null
                            : new LinuxConfiguration
                            {
                                ExcludedPackageNameMasks = this.ExcludedPackageNameMask,
                                IncludedPackageClassifications = this.IncludedPackageClassification,
                                IncludedPackageNameMasks = this.IncludedPackageNameMask,
                                rebootSetting = this.RebootOnly.IsPresent ? RebootSetting.RebootOnly : this.RebootSetting
                            },
                        Duration = this.Duration,
                        AzureVirtualMachines = this.AzureVMResourceId,
                        NonAzureComputers = this.NonAzureComputer,
                        Targets = target
                    },
                    Tasks = new Tasks
                    {
                        PreTask = this.PreTaskRunbookName == null ? null : new Task
                        {
                            source = this.PreTaskRunbookName,
                            parameters = TagsConversionHelper.CreateTagDictionary(this.PreTaskRunbookParameter, true)
                        },
                        PostTask = this.PostTaskRunbookName == null ? null : new Task
                        {
                            source = this.PostTaskRunbookName,
                            parameters = TagsConversionHelper.CreateTagDictionary(this.PostTaskRunbookParameter, true)
                        },
                    }
                };
                suc = this.AutomationClient.CreateSoftwareUpdateConfiguration(this.ResourceGroupName,
                    this.AutomationAccountName, suc);
                this.WriteObject(suc);
            }
        }
    }
}

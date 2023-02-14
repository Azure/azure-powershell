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

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.Azure.Commands.Automation.Common;
    using Microsoft.Azure.Commands.Automation.Model.UpdateManagement;

    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSoftwareUpdateRun",
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(SoftwareUpdateRun))]
    public class GetAzureAutomationSoftwareUpdateRun : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ById, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Id of the software update configuration run.")]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the software update configuration triggered the run.")]
        [ValidateNotNullOrEmpty]
        public string SoftwareUpdateConfigurationName { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySuc, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The software update configuration triggered the run.")]
        [ValidateNotNull]
        public SoftwareUpdateConfiguration SoftwareUpdateConfiguration { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The operating system of the run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySuc, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The operating system of the run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The operating system of the run.")]
        public OperatingSystemType? OperatingSystem { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Status of the run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySuc, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Status of the run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Status of the run.")]
        public SoftwareUpdateRunStatus? Status { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Minimum start time of the run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySuc, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Minimum start time of the run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Minimum start time of the run.")]
        public DateTimeOffset StartTime { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<SoftwareUpdateRun> result = null;
            switch (this.ParameterSetName)
            {
                case AutomationCmdletParameterSets.ById:
                    result = new SoftwareUpdateRun[] {
                        this.AutomationClient.GetSoftwareUpdateRunById(this.ResourceGroupName, this.AutomationAccountName, this.Id)
                    };
                    break;
                case AutomationCmdletParameterSets.BySuc:
                    result  = this.AutomationClient.ListSoftwareUpdateRuns(
                                                        this.ResourceGroupName, 
                                                        this.AutomationAccountName, 
                                                        this.SoftwareUpdateConfiguration.Name, this.OperatingSystem, this.StartTime, this.Status);
                    break;
                case AutomationCmdletParameterSets.BySucName:
                    result = this.AutomationClient.ListSoftwareUpdateRuns(
                                                        this.ResourceGroupName,
                                                        this.AutomationAccountName,
                                                        this.SoftwareUpdateConfigurationName, this.OperatingSystem, this.StartTime, this.Status);
                    break;
                default:
                    result = this.AutomationClient.ListSoftwareUpdateRuns(
                                                        this.ResourceGroupName,
                                                        this.AutomationAccountName,
                                                        null, this.OperatingSystem, this.StartTime, this.Status);
                    break;
            }

            this.GenerateCmdletOutput(result);
        }
    }
}

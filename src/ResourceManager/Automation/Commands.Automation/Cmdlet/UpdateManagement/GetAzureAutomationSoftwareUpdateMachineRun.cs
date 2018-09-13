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

    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSoftwareUpdateMachineRun",
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(SoftwareUpdateMachineRun))]
    public class GetAzureAutomationSoftwareUpdateMachineRun : AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ById, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Id of the software update machine run.")]
        [ValidateNotNullOrEmpty]
        public Guid Id { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucrId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Id of the software update run.")]
        [ValidateNotNullOrEmpty]
        public Guid SoftwareUpdateRunId { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucr, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The software update run.")]
        [ValidateNotNull]
        public SoftwareUpdateRun SoftwareUpdateRun { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Status of the machine run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucr, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Status of the machine run.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucrId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Status of the machine run.")]
        public SoftwareUpdateMachineRunStatus? Status { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByAll, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "target computer for the machine run. Can be either a non-azure computer name or an azure VM resource id.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucr, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "target computer for the machine run. Can be either a non-azure computer name or an azure VM resource id.")]
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.BySucrId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "target computer for the machine run. Can be either a non-azure computer name or an azure VM resource id.")]
        public string TargetComputer { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<SoftwareUpdateMachineRun> result = null;
            switch (this.ParameterSetName)
            {
                case AutomationCmdletParameterSets.ById:
                    result = new SoftwareUpdateMachineRun[] {
                        this.AutomationClient.GetSoftwareUpdateMachineRunById(
                                                        this.ResourceGroupName, 
                                                        this.AutomationAccountName, 
                                                        this.Id)
                    };
                    break;
                case AutomationCmdletParameterSets.BySucr:
                    result = this.AutomationClient.ListSoftwareUpdateMachineRuns(
                                                        this.ResourceGroupName,
                                                        this.AutomationAccountName,
                                                        this.SoftwareUpdateRun.RunId, 
                                                        this.TargetComputer, 
                                                        this.Status);
                    break;
                case AutomationCmdletParameterSets.BySucrId:
                    result = this.AutomationClient.ListSoftwareUpdateMachineRuns(
                                                        this.ResourceGroupName,
                                                        this.AutomationAccountName,
                                                        this.SoftwareUpdateRunId, 
                                                        this.TargetComputer,
                                                        this.Status);
                    break;
                default:
                    result = this.AutomationClient.ListSoftwareUpdateMachineRuns(
                                                        this.ResourceGroupName,
                                                        this.AutomationAccountName,
                                                        null, this.TargetComputer,
                                                        this.Status);
                    break;
            }

            this.GenerateCmdletOutput(result);
        }
    }
}

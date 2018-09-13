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
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using Microsoft.Azure.Commands.Automation.Common;
    using Model.UpdateManagement;

    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutomationSoftwareUpdateConfiguration",
        DefaultParameterSetName = AutomationCmdletParameterSets.ByAll)]
    [OutputType(typeof(SoftwareUpdateConfiguration))]
    public class GetAzureAutomationSoftwareUpdateConfiguration :  AzureAutomationBaseCmdlet
    {
        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the software update configuration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = AutomationCmdletParameterSets.ByVMId, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure resource Id of the virtual machine.")]
        [ValidateNotNullOrEmpty]
        public string AzureVMResourceId { get; set; }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            IEnumerable<SoftwareUpdateConfiguration> result = null;
            switch(this.ParameterSetName)
            {
                case AutomationCmdletParameterSets.ByName:
                    result = new SoftwareUpdateConfiguration[] {
                        this.AutomationClient.GetSoftwareUpdateConfigurationByName(this.ResourceGroupName, this.AutomationAccountName, this.Name)
                    };
                    break;
                case AutomationCmdletParameterSets.ByVMId:
                    result = this.AutomationClient.ListSoftwareUpdateConfigurations(this.ResourceGroupName, this.AutomationAccountName, this.AzureVMResourceId);
                    break;
                default:
                    result = this.AutomationClient.ListSoftwareUpdateConfigurations(this.ResourceGroupName, this.AutomationAccountName);
                    break;
            }
            this.GenerateCmdletOutput(result);
        }
    }
}

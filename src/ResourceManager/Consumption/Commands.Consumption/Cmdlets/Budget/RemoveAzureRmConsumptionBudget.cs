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

using System.Management.Automation;
using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using HelpMessages = Microsoft.Azure.Commands.Consumption.Common.ParameterHelpMessages.BudgetParameterHelpMessages;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmConsumptionBudget", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.PassThru)]
        public SwitchParameter PassThru;

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    ConsumptionManagementClient.Budgets.DeleteByResourceGroupName(this.ResourceGroupName,
                        this.Name);
                }
                else
                {
                    ConsumptionManagementClient.Budgets.Delete(this.Name);
                }
            }
            catch (ErrorResponseException e)
            {
                WriteExceptionError(e);
                return;
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}

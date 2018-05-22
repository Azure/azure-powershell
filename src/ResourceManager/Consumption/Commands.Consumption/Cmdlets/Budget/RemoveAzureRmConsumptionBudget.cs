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

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmConsumptionBudget", SupportsShouldProcess = true)]
    public class RemoveAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Name of a budget.")]
        public string Name;

        [Parameter(Mandatory = false, HelpMessage = "Resource Group of a budget.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        public override void ExecuteCmdlet()
        {
            bool isRemoved = true;
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
                isRemoved = false;
                WriteWarning(e.Body.Error.Message);
            }

            if (isRemoved)
            {
                WriteObject("Budget with the name " + this.Name + " was successfully removed.");
            }
        }
    }
}

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

using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Commands.Consumption.Models;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using HelpMessages = Microsoft.Azure.Commands.Consumption.Common.ParameterHelpMessages.BudgetParameterHelpMessages;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    using Budget = Management.Consumption.Models.Budget;

    [Cmdlet(VerbsCommon.Get, "AzureRmConsumptionBudget")]
    [OutputType(typeof(PSBudget))]
    public class GetAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        [Parameter(Mandatory = false, HelpMessage = HelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name;

        public override void ExecuteCmdlet()
        {
            IPage<Budget> budgets = null;
            Budget budget = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    if (!string.IsNullOrWhiteSpace(this.Name))
                    {
                        budget = ConsumptionManagementClient.Budgets.GetByResourceGroupName(this.ResourceGroupName,
                            this.Name);
                    }
                    else
                    {
                        budgets = ConsumptionManagementClient.Budgets.ListByResourceGroupName(this.ResourceGroupName);
                    }                    
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(this.Name))
                    {
                        budget = ConsumptionManagementClient.Budgets.Get(this.Name);
                    }
                    else
                    {
                        budgets = ConsumptionManagementClient.Budgets.List();
                    }                   
                }
            }
            catch (ErrorResponseException e)
            {
                WriteExceptionError(e);
            }

            if (budgets != null)
            {
                WriteObject(budgets.Select(x => new PSBudget(x)), true);
            }

            if (budget != null)
            {
                WriteObject(new PSBudget(budget), true);
            }
        }
    }
}

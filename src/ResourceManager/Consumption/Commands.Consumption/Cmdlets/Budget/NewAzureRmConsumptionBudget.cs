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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    using ResourceManager.Common.ArgumentCompleters;
    using Budget = Management.Consumption.Models.Budget;

    [Cmdlet(VerbsCommon.New, "AzureRmConsumptionBudget", SupportsShouldProcess = true)]
    [OutputType(typeof(PSBudget))]
    public class NewAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = "Amount of a budget.")]
        public decimal Amount;

        [Parameter(Mandatory = true, HelpMessage = "Name of a budget.")]
        public string Name;

        [Parameter(Mandatory = true, HelpMessage = "Category of the budget can be cost or usage.")]
        [ValidateSet("Cost", "Usage")]
        public string Category;

        [Parameter(Mandatory = false, HelpMessage = "End date (YYYY-MM-DD in UTC) of time period of a budget.")]
        public DateTime? EndDate;

        [Parameter(Mandatory = false, HelpMessage = "Space-separated list of meters to filter on. Required if category is usage.")]
        public string MeterFilter;

        [Parameter(Mandatory = false, HelpMessage = "Space-separated list of resource instances to filter on.")]
        public string ResourceFilter;

        [Parameter(Mandatory = false, HelpMessage = "Space-separated list of resource groups to filter on.")]
        public string ResourceGroupFilter;

        [Parameter(Mandatory = false, HelpMessage = "Resource Group of a budget.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        [Parameter(Mandatory = true, HelpMessage = "Start date (YYYY-MM-DD in UTC) of time period of a budget.")]
        public DateTime? StartDate;

        [Parameter(Mandatory = true, HelpMessage = "Time grain of the budget can be monthly, quarterly, or annually.")]
        [ValidateSet("Monthly", "Quarterly", "Annually")]
        public string TimeGrain;

        public override void ExecuteCmdlet()
        {
            var timePeriod = new BudgetTimePeriod();
            if (this.StartDate != null)
            {
                timePeriod.StartDate = this.StartDate.Value;
            }
            if (this.EndDate != null)
            {
                timePeriod.EndDate = this.EndDate.Value;
            }

            IList<string> resourceGroups = null;                       
            if (!string.IsNullOrWhiteSpace(this.ResourceGroupFilter))
            {
                resourceGroups = this.ResourceGroupFilter.Split(' ').ToList();
            }

            IList<string> resources = null;
            if (!string.IsNullOrWhiteSpace(this.ResourceFilter))
            {
                resources = this.ResourceFilter.Split(' ').ToList();
            }

            IList<string> meters = null;
            if (!string.IsNullOrWhiteSpace(this.MeterFilter))
            {
                meters = this.MeterFilter.Split(' ').ToList();
            }
            var filters = new Filters(resourceGroups, resources, meters);

            var requestBudget = new Budget(this.Category, this.Amount, this.TimeGrain, timePeriod, filters:filters);

            Budget responseBudget = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    responseBudget =
                        ConsumptionManagementClient.Budgets.CreateOrUpdateByResourceGroupName(this.ResourceGroupName,
                            this.Name, requestBudget);
                }
                else
                {
                    responseBudget = ConsumptionManagementClient.Budgets.CreateOrUpdate(this.Name, requestBudget);
                }
            }
            catch (ErrorResponseException e)
            {
                WriteWarning(e.Body.Error.Message);
            }

            if (responseBudget != null)
            {
                WriteObject(new PSBudget(responseBudget), true);
            }
        }
    }
}

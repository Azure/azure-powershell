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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Consumption.Common;
using Microsoft.Azure.Commands.Consumption.Models;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    using ResourceManager.Common.ArgumentCompleters;
    using Budget = Management.Consumption.Models.Budget;

    [Cmdlet(VerbsCommon.Set, "AzureRmConsumptionBudget", SupportsShouldProcess = true)]
    [OutputType(typeof(PSBudget))]
    public class SetAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Amount of a budget.")]
        public decimal? Amount;

        [Parameter(Mandatory = true, HelpMessage = "Name of a budget.")]
        public string Name;

        [Parameter(Mandatory = false, HelpMessage = "Category of the budget can be cost or usage.")]
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

        [Parameter(Mandatory = false, 
            HelpMessage = "Start date (YYYY-MM-DD in UTC) of time period of a budget. Not prior to current month for monthly time grain. Not prior to three months for quarterly time grain. Not prior to twelve months for yearly time grain. Future start date not more than three months.")]
        public DateTime? StartDate;

        [Parameter(Mandatory = false, HelpMessage = "Time grain of the budget can be monthly, quarterly, or annually.")]
        [ValidateSet("Monthly", "Quarterly", "Annually")]
        public string TimeGrain;

        public override void ExecuteCmdlet()
        {
            Budget budget = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(this.ResourceGroupName))
                {
                    budget =
                        ConsumptionManagementClient.Budgets.CreateOrUpdateByResourceGroupName(this.ResourceGroupName,
                            this.Name,
                            UpdateBudget(
                                ConsumptionManagementClient.Budgets.GetByResourceGroupName(this.ResourceGroupName,
                                    this.Name)));
                }
                else
                {
                    budget = ConsumptionManagementClient.Budgets.CreateOrUpdate(this.Name,
                        UpdateBudget(ConsumptionManagementClient.Budgets.Get(this.Name)));
                }
            }
            catch (ErrorResponseException e)
            {
                WriteWarning(e.Body.Error.Message);
            }

            if (budget != null)
            {
                WriteObject(new PSBudget(budget), true);
            }
        }

        private Budget UpdateBudget(Budget budget)
        {
            if (this.Amount != null)
            {
                budget.Amount = this.Amount.Value;
            }

            if (!string.IsNullOrWhiteSpace(this.Category))
            {
                budget.Category = this.Category;
            }

            if (this.EndDate != null)
            {
                budget.TimePeriod.EndDate = this.EndDate.Value;
            }

            if (!string.IsNullOrWhiteSpace(this.MeterFilter))
            {
                budget.Filters.Meters = this.MeterFilter.Split(' ').ToList();
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceFilter))
            {
                budget.Filters.Resources = this.ResourceFilter.Split(' ').ToList();
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceGroupFilter))
            {
                budget.Filters.ResourceGroups = this.ResourceGroupFilter.Split(' ').ToList();
            }

            if (this.StartDate != null)
            {
                budget.TimePeriod.StartDate = this.StartDate.Value;
            }

            if (!string.IsNullOrWhiteSpace(this.TimeGrain))
            {
                budget.TimeGrain = this.TimeGrain;
            }

            return budget;
        }
    }
}

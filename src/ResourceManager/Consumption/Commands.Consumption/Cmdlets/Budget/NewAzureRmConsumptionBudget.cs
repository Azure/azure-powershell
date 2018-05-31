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
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        public decimal Amount;       

        [Parameter(Mandatory = true, HelpMessage = "Category of the budget can be cost or usage.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Cost", "Usage")]
        public string Category;

        [Parameter(Mandatory = false, HelpMessage = "End date (YYYY-MM-DD in UTC) of time period of a budget.")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndDate;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated list of meters to filter on. Required if category is usage.")]
        [ValidateNotNullOrEmpty]
        public string[] MeterFilter;

        [Parameter(Mandatory = true, HelpMessage = "Name of a budget.")]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated list of resource instances to filter on.")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceFilter;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated list of resource groups to filter on.")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceGroupFilter;

        [Parameter(Mandatory = false, HelpMessage = "Resource Group of a budget.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        [Parameter(Mandatory = true, HelpMessage = "Start date (YYYY-MM-DD in UTC) of time period of a budget. Not prior to current month for monthly time grain. Not prior to three months for quarterly time grain. Not prior to twelve months for yearly time grain. Future start date not more than three months.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate;

        [Parameter(Mandatory = true, HelpMessage = "Time grain of the budget can be monthly, quarterly, or annually.")]
        [ValidateNotNullOrEmpty]
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
            if (!string.IsNullOrWhiteSpace(this.ResourceGroupFilter?.FirstOrDefault()))
            {
                resourceGroups = this.ResourceGroupFilter.ToList();
            }

            IList<string> resources = null;
            if (!string.IsNullOrWhiteSpace(this.ResourceFilter?.FirstOrDefault()))
            {
                resources = this.ResourceFilter.ToList();
            }

            IList<string> meters = null;
            if (!string.IsNullOrWhiteSpace(this.MeterFilter?.FirstOrDefault()))
            {
                meters = this.MeterFilter.ToList();
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

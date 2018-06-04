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

        [Parameter(Mandatory = false, HelpMessage = "Email addresses to send the budget notification to when the threshold is exceeded.")]
        [ValidateNotNullOrEmpty]
        [ValidateCount(1, 50)]
        public string[] ContactEmail;

        [Parameter(Mandatory = false, HelpMessage = "Action groups to send the budget notification to when the threshold is exceeded.")]
        [ValidateNotNullOrEmpty]
        public string[] ContactGroup;

        [Parameter(Mandatory = false, HelpMessage = "Contact roles to send the budget notification to when the threshold is exceeded.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Owner", "Reader", "Contributor")]
        public string[] ContactRole;

        [Parameter(Mandatory = false, HelpMessage = "End date (YYYY-MM-DD in UTC) of time period of a budget.")]
        [ValidateNotNullOrEmpty]
        public DateTime? EndDate;

        [Parameter(Mandatory = false, HelpMessage = "Comma-separated list of meters to filter on. Required if category is usage.")]
        [ValidateNotNullOrEmpty]
        public string[] MeterFilter;

        [Parameter(Mandatory = true, HelpMessage = "Name of a budget.")]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(Mandatory = false, HelpMessage = "The notification is enabled or not.")]
        public SwitchParameter NotificationEnabled;

        [Parameter(Mandatory = false, HelpMessage = "Key of a notification associated with a budget, required to create a notification with notification enabled switch, notification threshold, contact emails, contact groups, or contact roles.")]
        [ValidateNotNullOrEmpty]
        public string NotificationKey;

        [Parameter(Mandatory = false, HelpMessage = "Threshold value associated with a notification. Notification is sent when the cost or usage exceeded the threshold. It is always percent and has to be between 0 and 1000.")]
        [ValidateRange(0, 1000)]
        public decimal? NotificationThreshold;

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
            var requestBudget = new Budget(
                this.Category, 
                this.Amount, 
                this.TimeGrain, 
                CreateBudgetTimePeriod(),
                filters: CreateFilters(), 
                notifications: CreateNotifications());

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

        private BudgetTimePeriod CreateBudgetTimePeriod()
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

            return timePeriod;
        }

        private Filters CreateFilters()
        {
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
            return new Filters(resourceGroups, resources, meters);
        }

        private IDictionary<string, Notification> CreateNotifications()
        {
            IDictionary<string, Notification> budgetNotification = new Dictionary<string, Notification>();

            if (!string.IsNullOrWhiteSpace(this.NotificationKey))
            {
                var notification = new Notification
                {
                    OperatorProperty = "GreaterThanOrEqualTo"
                };

                if (this.NotificationEnabled.IsPresent)
                {
                    notification.Enabled = true;
                }

                if (this.NotificationThreshold != null)
                {
                    notification.Threshold = this.NotificationThreshold.Value;
                }

                var contactCount = 0;
                if (!string.IsNullOrWhiteSpace(this.ContactEmail?.FirstOrDefault()))
                {
                    notification.ContactEmails = this.ContactEmail.ToList();
                    contactCount += notification.ContactEmails.Count;
                }

                if (!string.IsNullOrWhiteSpace(this.ContactGroup?.FirstOrDefault()))
                {
                    notification.ContactGroups = this.ContactGroup.ToList();
                    contactCount += notification.ContactGroups.Count;
                }

                if (!string.IsNullOrWhiteSpace(this.ContactRole?.FirstOrDefault()))
                {
                    notification.ContactRoles = this.ContactRole.ToList();
                    contactCount += notification.ContactRoles.Count;
                }

                if (contactCount <= 0)
                {
                    WriteWarning("Notification cannot have all of Contact Emails, Contact Roles and Contact Groups empty.");
                }

                budgetNotification.Add(this.NotificationKey, notification);
            }

            return budgetNotification;
        }
    }
}

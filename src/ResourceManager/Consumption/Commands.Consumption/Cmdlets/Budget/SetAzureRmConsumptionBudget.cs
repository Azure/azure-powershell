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
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    using ResourceManager.Common.ArgumentCompleters;
    using Budget = Management.Consumption.Models.Budget;

    [Cmdlet(VerbsCommon.Set, "AzureRmConsumptionBudget", SupportsShouldProcess = true)]
    [OutputType(typeof(PSBudget))]
    public class SetAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = "Amount of a budget.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        public decimal? Amount;        

        [Parameter(Mandatory = false, HelpMessage = "Category of the budget can be cost or usage.")]
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

        [Parameter(Mandatory = false, HelpMessage = "The notification is disabled or not.")]
        public SwitchParameter NotificationDisabled;

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

        [Parameter(Mandatory = false, 
            HelpMessage = "Start date (YYYY-MM-DD in UTC) of time period of a budget. Not prior to current month for monthly time grain. Not prior to three months for quarterly time grain. Not prior to twelve months for yearly time grain. Future start date not more than three months.")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartDate;

        [Parameter(Mandatory = false, HelpMessage = "Time grain of the budget can be monthly, quarterly, or annually.")]
        [ValidateNotNullOrEmpty]
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

            if (!string.IsNullOrWhiteSpace(this.MeterFilter?.FirstOrDefault()))
            {
                budget.Filters.Meters = this.MeterFilter.ToList();
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceFilter?.FirstOrDefault()))
            {
                budget.Filters.Resources = this.ResourceFilter.ToList();
            }

            if (!string.IsNullOrWhiteSpace(this.ResourceGroupFilter?.FirstOrDefault()))
            {
                budget.Filters.ResourceGroups = this.ResourceGroupFilter.ToList();
            }

            if (this.StartDate != null)
            {
                budget.TimePeriod.StartDate = this.StartDate.Value;
            }

            if (!string.IsNullOrWhiteSpace(this.TimeGrain))
            {
                budget.TimeGrain = this.TimeGrain;
            }

            return UpdateBudgetNotification(budget);
        }

        private Budget UpdateBudgetNotification(Budget budget)
        {
            var notifications = budget.Notifications;

            if (!string.IsNullOrWhiteSpace(this.NotificationKey))
            {
                var notification = notifications.GetValueOrDefault(this.NotificationKey,
                    new Notification
                    {
                        OperatorProperty = "GreaterThanOrEqualTo"
                    });

                if (this.NotificationEnabled.IsPresent)
                {
                    notification.Enabled = true;
                }

                if (this.NotificationDisabled.IsPresent)
                {
                    notification.Enabled = false;
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

                if (notification.ContactEmails != null)
                {
                    contactCount += notification.ContactEmails.Count;
                }

                if (notification.ContactRoles != null)
                {
                    contactCount += notification.ContactRoles.Count;
                }

                if (notification.ContactGroups != null)
                {
                    contactCount += notification.ContactGroups.Count;
                }

                if (contactCount <= 0)
                {
                    WriteWarning("Notification cannot have all of Contact Emails, Contact Roles and Contact Groups empty.");
                }

                if (!notifications.ContainsKey(this.NotificationKey))
                {
                    notifications.Add(this.NotificationKey, notification);
                }               

                if (notifications.Keys.Count >= 6)
                {
                    WriteWarning("Budget can only have up to five notifications.");
                }
            }

            return budget;
        }
    }
}

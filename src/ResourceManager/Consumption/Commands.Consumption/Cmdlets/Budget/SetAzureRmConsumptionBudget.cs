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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using HelpMessages = Microsoft.Azure.Commands.Consumption.Common.ParameterHelpMessages.BudgetParameterHelpMessages;
using ParameterSetNames = Microsoft.Azure.Commands.Consumption.Common.Constants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{   
    using Budget = Management.Consumption.Models.Budget;

    [Cmdlet(VerbsCommon.Set, "AzureRmConsumptionBudget", DefaultParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSBudget))]
    public class SetAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Name)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.Amount)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.Amount)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        public decimal? Amount;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.Category)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.Category)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Cost", "Usage")]
        public string Category;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.TimeGrain)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.TimeGrain)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Monthly", "Quarterly", "Annually")]
        public string TimeGrain;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.StartDate)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.StartDate)]
        public DateTime? StartDate;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.EndDate)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.EndDate)]
        [ValidateNotNullOrEmpty]
        public DateTime? EndDate;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupName)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.MeterFilter)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.MeterFilter)]
        [ValidateNotNullOrEmpty]
        public string[] MeterFilter;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceFilter)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceFilter)]
        [ValidateNotNullOrEmpty]
        public string[] ResourceFilter;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupFilter)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ResourceGroupFilter)]
        [ValidateNotNullOrEmpty]
        public string[] ResourceGroupFilter;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.NotificationKey)]
        [ValidateNotNullOrEmpty]
        public string NotificationKey;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.NotificationEnabled)]
        public SwitchParameter NotificationEnabled;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.NotificationDisabled)]
        public SwitchParameter NotificationDisabled;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.NotificationThreshold)]
        [ValidateRange(0, 1000)]
        public decimal? NotificationThreshold;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ContactEmail)]
        [ValidateNotNullOrEmpty]
        public string[] ContactEmail;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ContactGroup)]
        [ValidateNotNullOrEmpty]
        public string[] ContactGroup;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = false, HelpMessage = HelpMessages.ContactRole)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Owner", "Reader", "Contributor")]
        public string[] ContactRole;     

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
                WriteExceptionError(e);
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
                var notification = notifications.GetValueOrDefault(Char.ToLowerInvariant(this.NotificationKey[0]) + this.NotificationKey.Substring(1),
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
                else if (notification.ContactEmails != null)
                {
                    contactCount += notification.ContactEmails.Count;
                }

                if (!string.IsNullOrWhiteSpace(this.ContactGroup?.FirstOrDefault()))
                {
                    notification.ContactGroups = this.ContactGroup.ToList();
                    contactCount += notification.ContactGroups.Count;
                }
                else if (notification.ContactGroups != null)
                {
                    contactCount += notification.ContactGroups.Count;
                }

                if (!string.IsNullOrWhiteSpace(this.ContactRole?.FirstOrDefault()))
                {
                    notification.ContactRoles = this.ContactRole.ToList();
                    contactCount += notification.ContactRoles.Count;
                }   
                else if (notification.ContactRoles != null)
                {
                    contactCount += notification.ContactRoles.Count;
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

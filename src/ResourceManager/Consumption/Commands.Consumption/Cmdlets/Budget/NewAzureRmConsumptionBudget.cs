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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using HelpMessages = Microsoft.Azure.Commands.Consumption.Common.ParameterHelpMessages.BudgetParameterHelpMessages;
using ParameterSetNames = Microsoft.Azure.Commands.Consumption.Common.Constants.ParameterSetNames;

namespace Microsoft.Azure.Commands.Consumption.Cmdlets.Budget
{
    using Budget = Management.Consumption.Models.Budget;

    [Cmdlet(VerbsCommon.New, "AzureRmConsumptionBudget", DefaultParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSBudget))]
    public class NewAzureRmConsumptionBudget : AzureConsumptionCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Name)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Name)]
        [ValidateNotNullOrEmpty]
        public string Name;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Amount)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Amount)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        public decimal Amount;       

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Category)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.Category)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Cost", "Usage")]
        public string Category;        

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.TimeGrain)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.TimeGrain)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Monthly", "Quarterly", "Annually")]
        public string TimeGrain;

        [Parameter(ParameterSetName = ParameterSetNames.SubscriptionItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.StartDate)]
        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.StartDate)]
        [ValidateNotNullOrEmpty]
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

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.NotificationThreshold)]
        [ValidateRange(0, 1000)]
        public decimal? NotificationThreshold;

        [Parameter(ParameterSetName = ParameterSetNames.NotificationItemParameterSet, Mandatory = true, HelpMessage = HelpMessages.ContactEmail)]
        [ValidateNotNullOrEmpty]
        [ValidateCount(1, 50)]
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
            if (ShouldProcess(Name, "Create Consumption Budget"))
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
                    WriteExceptionError(e);
                }

                if (responseBudget != null)
                {
                    WriteObject(new PSBudget(responseBudget), true);
                }
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

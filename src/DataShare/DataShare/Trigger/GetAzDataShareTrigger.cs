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

namespace Microsoft.Azure.Commands.DataShare.Trigger
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines the Get-AzDataShareTrigger cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareTrigger", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareTrigger))]
    public class GetAzDataShareTrigger : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name of azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of azure data share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure data share subscription name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.ShareSubscription, "ResourceGroupName", "AccountName")]
        public string ShareSubscriptionName { get; set; }

        /// <summary>
        /// Name of azure data share trigger.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data share trigger name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Trigger, "ResourceGroupName", "AccountName", "ShareSubscriptionName")]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the azure data share trigger.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the trigger",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.Trigger)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareSubscriptionName = parsedResourceId.GetShareSubscriptionName();
                this.Name = parsedResourceId.GetTriggerName();
            }

            if (this.Name != null)
            {
                try
                {
                    var trigger = this.DataShareManagementClient.Triggers.Get(
                        resourceGroupName: this.ResourceGroupName,
                        accountName: this.AccountName,
                        shareSubscriptionName: this.ShareSubscriptionName,
                        triggerName: this.Name) as ScheduledTrigger;
                    this.WriteObject(trigger.ToPsObject());
                }
                catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
                }
            } else
            {
                var triggersPage = this.DataShareManagementClient.Triggers.ListByShareSubscription(
                    resourceGroupName: this.ResourceGroupName,
                    accountName: this.AccountName,
                    shareSubscriptionName: this.ShareSubscriptionName);
                this.WriteTriggerPageToConsole(triggersPage);
                while (triggersPage.NextPageLink != null)
                {
                    triggersPage = this.DataShareManagementClient.Triggers.ListByShareSubscriptionNext(triggersPage.NextPageLink);
                    this.WriteTriggerPageToConsole(triggersPage);
                }
            }
        }

        private void WriteTriggerPageToConsole(IPage<Trigger> triggersPage)
        {
            this.WriteObject(triggersPage.AsEnumerable().Select(trigger => (trigger as ScheduledTrigger).ToPsObject()));
        }
    }
}

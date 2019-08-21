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

namespace Microsoft.Azure.Commands.DataShare.Share
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.DataShare;
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
    /// Defines Get-AzDataShareProviderShareSubscription cmdlet.
    /// </summary>
    [Cmdlet(
         "Get",
         Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareProviderShareSubscription", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareProviderShareSubscription))]
    public class GetAzDataShareProviderShareSubscription : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group of the Azure DataShare Account.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Data Share account name of the share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure DataShare Account name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        public string AccountName { get; set; }

        /// <summary>
        /// The name of share in account
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "share name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter(ResourceTypes.Share, "ResourceGroupName", "AccountName")]
        public string ShareName { get; set; }

        /// <summary>
        /// The share subscription id of the provider share subscription.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "The share subscription id of the provider share subscription",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The share subscription id of the provider share subscription",
            ParameterSetName = ParameterSetNames.ProviderShareSubscriptionIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ShareSubscriptionId { get; set; }

        /// <summary>
        /// The resourceId of the azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the share",
            ParameterSetName = ParameterSetNames.ProviderShareSubscriptionIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.Share)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.ProviderShareSubscriptionIdParameterSet))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.AccountName = parsedResourceId.GetAccountName();
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ShareName = parsedResourceId.GetShareName();
            }

            if (this.ShareSubscriptionId != null)
            {
                try
                {
                    ProviderShareSubscription providerShareSubscription =
                        this.DataShareManagementClient.ProviderShareSubscriptions.GetByShare(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName,
                            this.ShareSubscriptionId);

                    this.WriteObject(providerShareSubscription.ToPsObject());
                }
                catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.ShareSubscriptionId));
                }
            }
            else
            {
                string nextPageLink = null;
                List<ProviderShareSubscription> providerShareSubscriptionList = new List<ProviderShareSubscription>();

                do
                {
                    IPage<ProviderShareSubscription> providerShareSubscriptionPage = string.IsNullOrEmpty(nextPageLink)
                        ? this.DataShareManagementClient.ProviderShareSubscriptions.ListByShare(
                            this.ResourceGroupName,
                            this.AccountName,
                            this.ShareName)
                        : this.DataShareManagementClient.ProviderShareSubscriptions.ListByShareNext(
                            nextPageLink);

                    providerShareSubscriptionList.AddRange(providerShareSubscriptionPage.AsEnumerable());
                    nextPageLink = providerShareSubscriptionPage.NextPageLink;
                } while (nextPageLink != null);

                IEnumerable<PSDataShareProviderShareSubscription> providerShareSubscriptions = providerShareSubscriptionList.Select(
                    providerShareSubscription => providerShareSubscription.ToPsObject());
                this.WriteObject(providerShareSubscriptions.ToArray(), true);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataShare.Share
{
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
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Rest.Azure;

    [Cmdlet(
         "Get",
         Commands.ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareProviderShareSubscription", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSProviderShareSubscription))]
    public class GetAzDataShareProviderShareSubscription : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The Data Share account name of the share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure DataShare Account name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        /// <summary>
        /// The resource group name of the account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group of the Azure DataShare Account.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of share in account
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "share name.",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        /// <summary>
        /// The resourceId of the azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the share",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// The share subscription id of the provider share subscription.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The share subscription id of the provider share subscription",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The share subscription id of the provider share subscription",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ShareSubscriptionId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(ParameterSetNames.ResourceIdParameterSet))
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
                catch (DataShareErrorException ex)
                {
                    if (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new PSArgumentException(
                            $"ProviderShareSubscription {this.ShareSubscriptionId} not found");
                    }
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

                IEnumerable<PSProviderShareSubscription> providerShareSubscriptions = providerShareSubscriptionList.Select(
                    providerShareSubscription => providerShareSubscription.ToPsObject());
                this.WriteObject(providerShareSubscriptions.ToArray(), true);
            }
        }
    }
}
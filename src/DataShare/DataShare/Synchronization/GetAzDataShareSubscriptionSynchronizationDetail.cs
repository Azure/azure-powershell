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

namespace Microsoft.Azure.Commands.DataShare.Synchronization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Hyak.Common.Properties;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;
    using Microsoft.Rest.Azure;
    using Resources = Microsoft.Azure.PowerShell.Cmdlets.DataShare.Properties.Resources;

    /// <summary>
    /// Defines Get-AzDataShareSubscriptionSynchronizationDetail cmdlet.
    /// </summary>
    [Cmdlet(
         "Get",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareSubscriptionSynchronizationDetail",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareSynchronizationDetail))]
    public class GetAzDataShareSubscriptionSynchronizationDetail : AzureDataShareCmdletBase
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
        /// Synchronization id of the share subscription synchronization.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Synchronization id of share subscription synchronization",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Synchronization id of share subscription synchronization",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SynchronizationId { get; set; }

        /// <summary>
        /// Resource id of azure data share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure data share subscription resource id",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.ShareSubscription)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(
                ParameterSetNames.ResourceIdParameterSet,
                StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.AccountName = parsedResourceId.GetAccountName();
                this.ShareSubscriptionName = parsedResourceId.GetShareSubscriptionName();
            }

            try
            {
                string nextPageLink = null;
                List<SynchronizationDetails> shareSubscriptionSynchronizationDetailsList =
                    new List<SynchronizationDetails>();
                do
                {
                    IPage<SynchronizationDetails> shareSubscriptionSynchronizationDetails =
                        string.IsNullOrEmpty(nextPageLink)
                            ? this.DataShareManagementClient.ShareSubscriptions.ListSynchronizationDetails(
                                this.ResourceGroupName,
                                this.AccountName,
                                this.ShareSubscriptionName,
                                new ShareSubscriptionSynchronization() { SynchronizationId = this.SynchronizationId })
                            : this.DataShareManagementClient.ShareSubscriptions
                                .ListSynchronizationDetailsNext(nextPageLink);

                    shareSubscriptionSynchronizationDetailsList.AddRange(
                        shareSubscriptionSynchronizationDetails.AsEnumerable());
                    nextPageLink = shareSubscriptionSynchronizationDetails.NextPageLink;

                } while (nextPageLink != null);

                IEnumerable<PSDataShareSynchronizationDetail> synchronizationDetailsInShareSubscription =
                    shareSubscriptionSynchronizationDetailsList.Select(
                        shareSubscriptionSynchronizationDetails =>
                            shareSubscriptionSynchronizationDetails.ToPsObject());

                this.WriteObject(synchronizationDetailsInShareSubscription, true);

            }
            catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.ShareSubscriptionName));
            }
        }
    }
}
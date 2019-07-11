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

namespace Microsoft.Azure.Commands.DataShare.ProviderShareSubscription
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.DataShare.Common;
    using Microsoft.Azure.Commands.DataShare.Helpers;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.PowerShell.Cmdlets.DataShare.Models;

    /// <summary>
    /// Defines Revoke-AzDataShareSubscriptionAccess cmdlets.
    /// </summary>
    [Cmdlet("Revoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareSubscriptionAccess", DefaultParameterSetName = ParameterSetNames.FieldsParameterSet, SupportsShouldProcess = true),
     OutputType(typeof(PSProviderShareSubscription))]
    public class RevokeAzDataShareSubscriptionAccess : AzureDataShareCmdletBase
    {

        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure data share account name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        /// <summary>
        /// Name of azure data share.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure data share name",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        /// <summary>
        /// The share subscription id of the provider share subscription.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The share subscription id of the provider share subscription",
            ParameterSetName = ParameterSetNames.FieldsParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The share subscription id of the provider share subscription",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ShareSubscriptionId { get; set; }

        /// <summary>
        /// The resourceId of the azure data share.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data share",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.ShareSubscriptionId, "Revoke"))
            {
                if (this.ParameterSetName.Equals(ParameterSetNames.ResourceIdParameterSet))
                {
                    var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                    this.AccountName = parsedResourceId.GetAccountName();
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                    this.ShareName = parsedResourceId.GetShareName();
                }

                ProviderShareSubscription providerShareSubscription =
                    this.DataShareManagementClient.ProviderShareSubscriptions.Revoke(
                        resourceGroupName: this.ResourceGroupName,
                        accountName: this.AccountName,
                        shareName: this.ShareName,
                        providerShareSubscriptionId: this.ShareSubscriptionId);

                this.WriteObject(providerShareSubscription.ToPsObject());
            }
        }
    }
}

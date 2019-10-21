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

namespace Microsoft.Azure.Commands.DataShare.Account
{
    using System;
    using System.Collections.Generic;
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
    /// Defines the Get-AzDataShareAccount cmdlet.
    /// </summary>
    [Cmdlet(
         "Get",
         ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataShareAccount",
         DefaultParameterSetName = ParameterSetNames.FieldsParameterSet),
     OutputType(typeof(PSDataShareAccount))]

    public class GetAzDataShareAccount : AzureDataShareCmdletBase
    {
        /// <summary>
        /// The resource group name of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the azure data share account.",
            ParameterSetName = ParameterSetNames.ResourceGroupParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Azure data share account name.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Azure data share account name.",
            ParameterSetName = ParameterSetNames.ResourceGroupParameterSet)]
        [ResourceNameCompleter(ResourceTypes.Account, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The resourceId of the azure data share account.
        /// </summary>
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the azure data share account.",
            ParameterSetName = ParameterSetNames.ResourceIdParameterSet)]
        [ResourceIdCompleter(ResourceTypes.Account)]
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
                this.Name = parsedResourceId.GetAccountName();
            }

            if (this.ResourceGroupName == null)
            {
                string nextPageLink = null;
                List<Account> accountList = new List<Account>();

                do
                {
                    IPage<Account> accounts = string.IsNullOrEmpty(nextPageLink)
                        ? this.DataShareManagementClient.Accounts.ListBySubscription()
                        : this.DataShareManagementClient.Accounts.ListBySubscriptionNext(nextPageLink);

                    accountList.AddRange(accounts.AsEnumerable());
                    nextPageLink = accounts.NextPageLink;
                } while (nextPageLink != null);

                // List by subscription.
                IEnumerable<PSDataShareAccount> accountsInSubscription = accountList.Select(account => account.ToPsObject());
                this.WriteObject(accountsInSubscription, true);
            }
            else
            {
                if (this.Name == null)
                {
                    // List by Resource Group name.
                    string nextPageLink = null;
                    List<Account> accountList = new List<Account>();

                    do
                    {
                        IPage<Account> accounts = string.IsNullOrEmpty(nextPageLink)
                            ? this.DataShareManagementClient.Accounts.ListByResourceGroup(this.ResourceGroupName)
                            : this.DataShareManagementClient.Accounts.ListByResourceGroupNext(nextPageLink);

                        accountList.AddRange(accounts.AsEnumerable());
                        nextPageLink = accounts.NextPageLink;
                    } while (nextPageLink != null);

                    IEnumerable<PSDataShareAccount> accountsInResourceGroup =
                        accountList.Select(account => account.ToPsObject());
                    this.WriteObject(accountsInResourceGroup, true);
                }
                else
                {
                    try
                    {
                        // Get by both Profile Name and Resource Group Name.
                        var account = this.DataShareManagementClient.Accounts.Get(this.ResourceGroupName, this.Name);
                        this.WriteObject(account.ToPsObject());
                    }
                    catch (DataShareErrorException ex) when (ex.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                    {
                        throw new PSArgumentException(string.Format(Resources.ResourceNotFoundMessage, this.Name));
                    }
                }
            }
        }
    }
}
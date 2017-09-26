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
using System.Collections.Generic;
using System.Management.Automation;
using System.Globalization;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Gets a list of all storage accounts and their properties in a region.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminStorageAccount, DefaultParameterSetName = ListAccountsParamSet)]
    [Alias("Get-ACSStorageAccount")]
    public sealed class GetStorageAccountsWithAdminInfo : AdminCmdletDefaultFarm
    {
        const string ListAccountsParamSet = "ListMultipleAccounts";
        const string GetSingleAccountParamSet = "GetSingleAccount";

        /// <summary>
        /// Tenant Subscription Id to filter
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ListAccountsParamSet)]
        public string TenantSubscriptionId { get; set; }

        /// <summary>
        /// substring of Storage Account Name to filter
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ListAccountsParamSet)]
        public string PartialAccountName { get; set; }

        /// <summary>
        /// Storage Account Status to filter
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = ListAccountsParamSet)]
        public StorageAccountStatus? StorageAccountStatus { get; set; }

        /// <summary>
        /// Storage Account AccountId to get
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetSingleAccountParamSet)]
        public string AccountId { get; set; }

        /// <summary>
        /// Only need return summary information if not specified
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter Detail { get; set; }

        protected override void Execute()
        {
            List<KeyValuePair<StorageAccountSearchFilterParameter, string>> filters = new List<KeyValuePair<StorageAccountSearchFilterParameter, string>>();

            switch (ParameterSetName)
            {
                case GetSingleAccountParamSet:
                    filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.VersionedAccountName, AccountId));
                    break;
                case ListAccountsParamSet:
                    if (TenantSubscriptionId != null)
                        filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.TenantSubscriptionId, TenantSubscriptionId));
                    if (PartialAccountName != null)
                        filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.PartialAccountName, PartialAccountName));
                    if (StorageAccountStatus.HasValue == true) {
                        int accountStatus = (int)StorageAccountStatus;
                        filters.Add(new KeyValuePair<StorageAccountSearchFilterParameter, string>(StorageAccountSearchFilterParameter.StorageAccountStatus, accountStatus.ToString(CultureInfo.InvariantCulture)));
                    }
                    break;
            }
            string filter = Tools.GenerateStorageAccountsSearchFilter(filters);
            var response = Client.StorageAccounts.List(ResourceGroupName, FarmName, filter, !Detail.IsPresent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<StorageAccountResponse> adminViewList = new List<StorageAccountResponse>();
                foreach (StorageAccountModel model in response.StorageAccounts)
                {
                    // Ignoring Storage Accounts which are not having Name
                    // This will happen when Storage Account is not yet created completely
                    if (!string.IsNullOrEmpty(model.Name))
                    {
                        adminViewList.Add(new StorageAccountResponse(model, FarmName));
                    }
                }
                WriteObject(adminViewList, true);
            }
            else
                WriteObject(response, true);
        }
    }
}

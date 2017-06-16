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

using System.Management.Automation;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using System.Globalization;
using System;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    /// Tries to recover a deleted storage account.
    /// </summary>
    [Cmdlet(VerbsCommon.Undo, Nouns.AdminStorageAccountDeletion, SupportsShouldProcess = true)]
    [Alias("Undo-ACSStorageAccountDeletion")]
    public sealed class UndeleteStorageAccount : AdminCmdletDefaultFarm
    {
        /// <summary>
        /// Storage Account Id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string AccountId { get; set; }

        /// <summary>
        /// New Storage Account Name to recover with
        /// </summary>
        [Parameter(Mandatory = false)]
        public string NewAccountName { get; set; }

        /// <summary>
        /// Specify storage account api version which resource was created with
        /// </summary>
        [Parameter(Mandatory = false)]
        public string StorageAccountApiVersion { get; set; }

        /// <summary>
        /// Specifies the Microsoft.Resource.Admin apiVersion
        /// </summary>
        [Parameter(Mandatory = false)]
        public string ResourceAdminApiVersion { get; set; }

        internal static string SyncDefaultStorageAccountApiVersion = "2015-06-15";
        internal static string SyncDefaultResourceAdminApiVersion = "2015-01-01";
        internal static string SyncTargetOperation = "Create";

        internal static string BuildSyncTargetId(string tenantSubscriptionId, string resourceGroupName, string accountName)
        {
            return "/subscriptions/" + tenantSubscriptionId + "/resourcegroups/" + resourceGroupName + "/providers/Microsoft.Storage/storageAccounts/" + accountName;
        }
        protected override void Execute()
        {
            StorageAccountUndeleteParameters undeleteParam = new StorageAccountUndeleteParameters
            {
                NewAccountName = NewAccountName
            };
            if (ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Resources.StorageAccountAdminView, AccountId),
                    string.Format(CultureInfo.InvariantCulture, Resources.UndeleteOperation)))
            {
                var response = Client.StorageAccounts.Undelete(ResourceGroupName, FarmName, AccountId, undeleteParam);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, Resources.FailedToUndeleteAccount));
                }

                // get recovered account to set parameters for resource sync
                WriteVerbose(Resources.RetrieveUndeletedStorageAccount);
                StorageAccountListResponse accounts = Client.StorageAccounts.List(ResourceGroupName, FarmName, "{accountid eq '" + AccountId + "'}", true);
                if (accounts.StatusCode != System.Net.HttpStatusCode.OK ||
                    accounts.StorageAccounts.Count == 0 ||
                    accounts.StorageAccounts[0].Properties == null ||
                    accounts.StorageAccounts[0].Properties.TenantSubscriptionId.Equals(Guid.Empty) == true ||
                    accounts.StorageAccounts[0].Properties.TenantViewId == null ||
                    accounts.StorageAccounts[0].Properties.TenantResourceGroupName == null ||
                    accounts.StorageAccounts[0].Location == null)
                {
                    throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, Resources.FailedToGetAccount));
                }

                // trigger resource sync
                WriteVerbose(Resources.TriggerResourceSync);
                StorageAccountSyncRequest req = new StorageAccountSyncRequest();
                if (StorageAccountApiVersion == null)
                    StorageAccountApiVersion = SyncDefaultStorageAccountApiVersion;
                if (string.IsNullOrEmpty(ResourceAdminApiVersion))
                {
                    ResourceAdminApiVersion = SyncDefaultResourceAdminApiVersion;
                }
                req.ApiVersion = StorageAccountApiVersion;
                req.TargetOperaton = SyncTargetOperation;
                req.ResourceLocation = accounts.StorageAccounts[0].Location;
                req.Id = accounts.StorageAccounts[0].Properties.TenantViewId;

                Client.StorageAccounts.Sync(accounts.StorageAccounts[0].Properties.TenantSubscriptionId.ToString(), accounts.StorageAccounts[0].Properties.TenantResourceGroupName, ResourceAdminApiVersion, req);

                WriteWarning(Resources.WaitAfterArmSync);
            }
        }
    }
}

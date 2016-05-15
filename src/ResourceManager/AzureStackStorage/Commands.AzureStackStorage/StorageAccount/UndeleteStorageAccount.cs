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

using Microsoft.AzureStack.Management.StorageAdmin;
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Undo-StorageAccountDeletion [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [[-AccountId] {long}] [[-NewAccountName] {string}] [-TenantSubscriptionId] {string} [-Sync] {bool} [-ResourceLocation] {string}
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Undo, Nouns.AdminStorageAccountDeletion, SupportsShouldProcess = true)]
    public sealed class UndeleteStorageAccount : AdminCmdlet
    {
        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName { get; set; }

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        public long AccountId { get; set; }

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = false, Position = 6)]
        public string NewAccountName { get; set; }

        /// <summary>
        /// Specify storage account api version whic resource was created with
        /// </summary>
        [Parameter(Mandatory = false, Position = 7)]
        public string StorageAccountApiVersion { get; set; }

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
                var response = Client.StorageAccounts.Undelete(ResourceGroupName, FarmName, AccountId.ToString(CultureInfo.InvariantCulture), undeleteParam);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new ApplicationException(String.Format(CultureInfo.InvariantCulture, Resources.FailedToUndeleteAccount));
                }

                // get recovered account to set parameters for resource sync
                WriteVerbose(Resources.RetrieveUndeletedStorageAccount);
                StorageAccountListResponse accounts = Client.StorageAccounts.List(ResourceGroupName, FarmName, "{versionedaccountname eq '" + AccountId + "'}", true);
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
                    StorageAccountApiVersion = SyncStorageAccount.DefaultStorageAccountApiVersion;
                req.ApiVersion = StorageAccountApiVersion;
                req.TargetOperaton = SyncStorageAccount.SyncTargetOperation;
                req.ResourceLocation = accounts.StorageAccounts[0].Location;
                req.Id = accounts.StorageAccounts[0].Properties.TenantViewId;

                Client.StorageAccounts.Sync(accounts.StorageAccounts[0].Properties.TenantSubscriptionId.ToString(), accounts.StorageAccounts[0].Properties.TenantResourceGroupName, req);

                WriteWarning(Resources.WaitAfterArmSync);
            }
        }
    }
}

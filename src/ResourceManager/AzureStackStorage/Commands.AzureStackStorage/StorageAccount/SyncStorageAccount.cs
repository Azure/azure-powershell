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

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    /// <summary>
    ///     SYNTAX
    ///          Sync-StorageAccount [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-AccountName] {string} [-ResourceLocation] {string} [-TenantSubscriptionId] {string} 
    /// 
    /// </summary>
    [Cmdlet(VerbsData.Sync, Nouns.AdminStorageAccount, SupportsShouldProcess = true)]
    public sealed class SyncStorageAccount : AdminCmdlet
    {
        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Storage Account Name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string TenantAccountName { get; set; }

        /// <summary>
        /// Tenant Subscription Id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNull]
        public string TenantSubscriptionId { get; set; }

        /// <summary>
        /// Resource Location
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 6)]
        [ValidateNotNull]
        public string Location { get; set; }

        /// <summary>
        /// Tenant Resource Group
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 7)]
        [ValidateNotNull]
        public string TenantResourceGroup { get; set; }

        /// <summary>
        /// Specify storage account api version whic resource was created with
        /// </summary>
        [Parameter(Mandatory = false, Position = 8)]
        public string StorageAccountApiVersion { get; set; }

        /// <summary>
        /// Specifies the Microsoft.Resource.Admin apiVersion
        /// </summary>
        [Parameter(Mandatory = false)]
        public string ResourceAdminApiVersion { get; set; }

        internal static string DefaultStorageAccountApiVersion = "2015-06-15";
        internal static string DefaultResourceAdminApiVersion = "2015-01-01";
        internal static string SyncTargetOperation = "Create";

        internal static string BuildSyncTargetId(string tenantSubscriptionId, string resourceGroupName, string accountName)
        {
            return "/subscriptions/" + tenantSubscriptionId + "/resourcegroups/" + resourceGroupName + "/providers/Microsoft.Storage/storageAccounts/" + accountName;
        }

        protected override void Execute()
        {
            StorageAccountSyncRequest req = new StorageAccountSyncRequest();
            if (StorageAccountApiVersion == null)
                StorageAccountApiVersion = DefaultStorageAccountApiVersion;
            if (string.IsNullOrEmpty(ResourceAdminApiVersion))
            {
                ResourceAdminApiVersion = DefaultResourceAdminApiVersion;
            }
            req.ApiVersion = StorageAccountApiVersion;
            req.TargetOperaton = SyncTargetOperation;
            req.ResourceLocation = Location;
            req.Id = BuildSyncTargetId(TenantSubscriptionId, TenantResourceGroup, TenantAccountName);
            WriteObject(req, true);
            if (ShouldProcess(
                    string.Format(CultureInfo.InvariantCulture, Resources.StorageAccount, req.Id),
                    string.Format(CultureInfo.InvariantCulture, Resources.SyncOperation)))
            {
                StorageAccountSyncResponse syncResponse = Client.StorageAccounts.Sync(TenantSubscriptionId, TenantResourceGroup, ResourceAdminApiVersion, req);
                WriteObject(syncResponse, true);

                WriteWarning(Resources.WaitAfterArmSync);
            }
        }
    }
}

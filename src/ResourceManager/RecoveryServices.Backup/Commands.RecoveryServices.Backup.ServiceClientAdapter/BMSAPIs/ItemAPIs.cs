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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Creates a new protected item or updates an already existing protected item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="request">Protected item create or update request</param>
        /// <returns>Job created in the service for this operation</returns>
        public BaseRecoveryServicesJobResponse CreateOrUpdateProtectedItem(
                string containerName,
                string protectedItemName,
                ProtectedItemCreateOrUpdateRequest request)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.CreateOrUpdateProtectedItemAsync(
                                     resourceGroupName,
                                     resourceName,
                                     AzureFabricName,
                                     containerName,
                                     protectedItemName,
                                     request,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Deletes a protected item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <returns>Job created in the service for this operation</returns>
        public BaseRecoveryServicesJobResponse DeleteProtectedItem(
                string containerName,
                string protectedItemName)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.DeleteProtectedItemAsync(
                                     resourceGroupName,
                                     resourceName,
                                     AzureFabricName,
                                     containerName,
                                     protectedItemName,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Gets a protected item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="queryFilter">Query filter</param>
        /// <returns>Protected item</returns>
        public ProtectedItemResponse GetProtectedItem(
                string containerName,
                string protectedItemName,
            GetProtectedItemQueryParam queryFilter)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.GetAsync(
                                     resourceGroupName,
                                     resourceName,
                                     AzureFabricName,
                                     containerName,
                                     protectedItemName,
                                     queryFilter,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// List protected items protected by the Recovery Services vault according to the query params 
        /// and pagination params.
        /// </summary>
        /// <param name="queryFilter">Query params</param>
        /// <param name="paginationParams">Pagination params</param>
        /// <returns>List of protected items</returns>
        public ProtectedItemListResponse ListProtectedItem(
                ProtectedItemListQueryParam queryFilter,
            PaginationRequest paginationParams = null)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.ListAsync(
                                     resourceGroupName,
                                     resourceName, 
                                     queryFilter,
                                     paginationParams,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Triggers backup on the specified item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="itemName">Name of the item</param>
        /// <returns>Job created by this operation</returns>
        public BaseRecoveryServicesJobResponse TriggerBackup(
            string containerName, 
            string itemName, 
            DateTime? expiryDateTimeUtc)
        {
            TriggerBackupRequest triggerBackupRequest = new TriggerBackupRequest();
            triggerBackupRequest.Item = new BackupRequestResource();
            IaaSVMBackupRequest iaasVmBackupRequest = new IaaSVMBackupRequest();
            iaasVmBackupRequest.RecoveryPointExpiryTimeInUTC = expiryDateTimeUtc;
            triggerBackupRequest.Item.Properties = iaasVmBackupRequest;

            return BmsAdapter.Client.Backups.TriggerBackupAsync(
                BmsAdapter.GetResourceGroupName(),
                BmsAdapter.GetResourceName(),
                BmsAdapter.GetCustomRequestHeaders(),
                ServiceClientAdapter.AzureFabricName,
                containerName,
                itemName,
                triggerBackupRequest,
                BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}

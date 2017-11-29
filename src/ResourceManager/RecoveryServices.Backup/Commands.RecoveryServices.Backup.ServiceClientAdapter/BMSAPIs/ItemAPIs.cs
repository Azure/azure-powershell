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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using RestAzureNS = Microsoft.Rest.Azure;

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
        public RestAzureNS.AzureOperationResponse CreateOrUpdateProtectedItem(
                string containerName,
                string protectedItemName,
                ProtectedItemResource request)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.CreateOrUpdateWithHttpMessagesAsync(
                resourceName,
                resourceGroupName,
                AzureFabricName,
                containerName,
                protectedItemName,
                request,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Deletes a protected item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <returns>Job created in the service for this operation</returns>
        public RestAzureNS.AzureOperationResponse DeleteProtectedItem(
                string containerName,
                string protectedItemName)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.DeleteWithHttpMessagesAsync(
                resourceName,
                resourceGroupName,
                AzureFabricName,
                containerName,
                protectedItemName,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Gets a protected item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="queryFilter">Query filter</param>
        /// <returns>Protected item</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> GetProtectedItem(
                string containerName,
                string protectedItemName,
           ODataQuery<GetProtectedItemQueryObject> queryFilter)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.GetWithHttpMessagesAsync(
                resourceName,
                resourceGroupName,
                AzureFabricName,
                containerName,
                protectedItemName,
                queryFilter,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// List protected items protected by the Recovery Services vault according to the query params 
        /// and pagination params.
        /// </summary>
        /// <param name="queryFilter">Query params</param>
        /// <param name="skipToken">Skip token used for pagination</param>
        /// <returns>List of protected items</returns>
        public List<ProtectedItemResource> ListProtectedItem(
                ODataQuery<ProtectedItemQueryObject> queryFilter,
            string skipToken = default(string))
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            Func<RestAzureNS.IPage<ProtectedItemResource>> listAsync =
                () => BmsAdapter.Client.BackupProtectedItems.ListWithHttpMessagesAsync(
                    resourceName,
                    resourceGroupName,
                    queryFilter,
                    skipToken,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<ProtectedItemResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupProtectedItems.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Triggers backup on the specified item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="itemName">Name of the item</param>
        /// <param name="expiryDateTimeUtc">Date when the recovery points created by this backup operation will expire</param>
        /// <returns>Job created by this operation</returns>
        public RestAzureNS.AzureOperationResponse TriggerBackup(
            string containerName,
            string itemName,
            DateTime? expiryDateTimeUtc)
        {
            BackupRequestResource triggerBackupRequest = new BackupRequestResource();
            IaasVMBackupRequest iaasVmBackupRequest = new IaasVMBackupRequest();
            iaasVmBackupRequest.RecoveryPointExpiryTimeInUTC = expiryDateTimeUtc;
            triggerBackupRequest.Properties = iaasVmBackupRequest;

            return BmsAdapter.Client.Backups.TriggerWithHttpMessagesAsync(
                BmsAdapter.GetResourceName(),
                BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                itemName,
                triggerBackupRequest,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}

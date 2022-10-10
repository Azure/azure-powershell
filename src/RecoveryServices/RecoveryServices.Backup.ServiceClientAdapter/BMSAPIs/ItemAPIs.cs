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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
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
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="auxiliaryAccessToken"></param>
        /// <param name="isMUAProtected"></param>
        /// <returns>Job created in the service for this operation</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> CreateOrUpdateProtectedItem(
            string containerName,
            string protectedItemName,
            ProtectedItemResource request,
            string vaultName = null,
            string resourceGroupName = null,
            string auxiliaryAccessToken = null,
            bool isMUAProtected = false)
        {
            Dictionary<string, List<string>> customHeaders = new Dictionary<string, List<string>>();
            if (isMUAProtected)
            {
                List<ResourceGuardProxyBaseResource> resourceGuardMapping = ListResourceGuardMapping(vaultName, resourceGroupName);
                string operationRequest = null;

                if (resourceGuardMapping != null && resourceGuardMapping.Count != 0)
                {
                    foreach (ResourceGuardOperationDetail operationDetail in resourceGuardMapping[0].Properties.ResourceGuardOperationDetails)
                    {
                        if (operationDetail.VaultCriticalOperation == "Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/write") operationRequest = operationDetail.DefaultResourceRequest;
                    }

                    if (operationRequest != null)
                    {
                        request.Properties.ResourceGuardOperationRequests = new List<string>();
                        request.Properties.ResourceGuardOperationRequests.Add(operationRequest);
                    }
                }

                if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
                {
                    if (operationRequest != null)
                    {
                        customHeaders.Add("x-ms-authorization-auxiliary", new List<string> { "Bearer " + auxiliaryAccessToken });
                    }
                    else
                    {
                        throw new ArgumentException(String.Format(Resources.UnexpectedParameterToken, "ModifyProtection"));
                    }
                }
            }

            return BmsAdapter.Client.ProtectedItems.CreateOrUpdateWithHttpMessagesAsync(
                 vaultName ?? BmsAdapter.GetResourceName(),
                 resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                 AzureFabricName,
                 containerName,
                 protectedItemName,
                 request,
                 customHeaders,
                 cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Deletes a protected item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="auxiliaryAccessToken"></param>
        /// <param name="protectedItemUri"></param>
        /// <returns>Job created in the service for this operation</returns>
        public RestAzureNS.AzureOperationResponse DeleteProtectedItem(
            string containerName,
            string protectedItemName,
            string vaultName = null,
            string resourceGroupName = null,
            string auxiliaryAccessToken = null,
            string protectedItemUri = null)
        {
            Dictionary<string, List<string>> customHeaders = new Dictionary<string, List<string>>();
            if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
            {
                customHeaders.Add("x-ms-authorization-auxiliary", new List<string> { "Bearer " + auxiliaryAccessToken });
            }

            string operationRequest = null;

            // unlock
            UnlockDeleteRequest unlockDeleteRequest = new UnlockDeleteRequest();

            List<ResourceGuardProxyBaseResource> resourceGuardMapping = ListResourceGuardMapping(vaultName, resourceGroupName);

            if (resourceGuardMapping != null && resourceGuardMapping.Count != 0)
            {
                foreach (ResourceGuardOperationDetail operationDetail in resourceGuardMapping[0].Properties.ResourceGuardOperationDetails)
                {
                    if (operationDetail.VaultCriticalOperation == "Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/delete") operationRequest = operationDetail.DefaultResourceRequest;
                }

                if(operationRequest != null)
                {
                    unlockDeleteRequest.ResourceGuardOperationRequests = new List<string>();
                    unlockDeleteRequest.ResourceGuardOperationRequests.Add(operationRequest);

                    if(protectedItemUri == null)
                    {
                        throw new ArgumentException(String.Format(Resources.ProtectedItemURICantBeNull));
                    }

                    unlockDeleteRequest.ResourceToBeDeleted = protectedItemUri;
                    UnlockDeleteResponse unlockDeleteResponse = BmsAdapter.Client.ResourceGuardProxy.UnlockDeleteWithHttpMessagesAsync(vaultName ?? BmsAdapter.GetResourceName(), resourceGroupName ?? BmsAdapter.GetResourceGroupName(), resourceGuardMapping[0].Name, unlockDeleteRequest, customHeaders).Result.Body;
                }
                else if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
                {
                    throw new ArgumentException(String.Format(Resources.UnexpectedParameterToken, "Delete protection with DeleteBackupData"));
                }
            }
            else if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
            {
                throw new ArgumentException(String.Format(Resources.UnexpectedParameterToken, "Delete protection with DeleteBackupData"));
            }

            return BmsAdapter.Client.ProtectedItems.DeleteWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
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
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Protected item</returns>
        public RestAzureNS.AzureOperationResponse<ProtectedItemResource> GetProtectedItem(
            string containerName,
            string protectedItemName,
            ODataQuery<GetProtectedItemQueryObject> queryFilter,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectedItems.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
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
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protected items</returns>
        public List<ProtectedItemResource> ListProtectedItem(
            ODataQuery<ProtectedItemQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<ProtectedItemResource>> listAsync =
                () => BmsAdapter.Client.BackupProtectedItems.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
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
        /// List protected items protected from secondary region by the Recovery Services vault according to the query params 
        /// and pagination params.
        /// </summary>
        /// <param name="queryFilter">Query params</param>
        /// <param name="skipToken">Skip token used for pagination</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protected items</returns>
        public List<CrrModel.ProtectedItemResource> ListProtectedItemCrr(
            ODataQuery<CrrModel.ProtectedItemQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<CrrModel.ProtectedItemResource>> listAsync =
                () => CrrAdapter.Client.BackupProtectedItemsCrr.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    skipToken,
                    cancellationToken: CrrAdapter.CmdletCancellationToken).Result.Body;
            
            Func<string, RestAzureNS.IPage<CrrModel.ProtectedItemResource>> listNextAsync =
                nextLink => CrrAdapter.Client.BackupProtectedItemsCrr.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: CrrAdapter.CmdletCancellationToken).Result.Body;
            
            var result = HelperUtils.GetPagedListCrr(listAsync, listNextAsync);
            
            return result;
        }

        /// <summary>
        /// Triggers backup on the specified item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="itemName">Name of the item</param>
        /// <param name="triggerBackupRequest"></param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Job created by this operation</returns>
        public RestAzureNS.AzureOperationResponse TriggerBackup(
            string containerName,
            string itemName,
            BackupRequestResource triggerBackupRequest,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.Backups.TriggerWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                itemName,
                triggerBackupRequest,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Checks backup status for a given resource
        /// </summary>
        /// <param name="type">Resource type</param>
        /// <param name="resourceId">Resource id</param>
        /// <param name="resourceLocation">Resource location</param>
        /// <param name="protectableObjName">Protectable object name</param>
        /// <returns>Backup status</returns>
        public RestAzureNS.AzureOperationResponse<BackupStatusResponse> CheckBackupStatus(
            string type,
            string resourceId,
            string resourceLocation,
            string protectableObjName)
        {
            ODataQuery<ProtectionPolicyQueryObject> queryParams =
             new ODataQuery<ProtectionPolicyQueryObject>();

            BackupStatusRequest request = new BackupStatusRequest();
            request.ResourceType = ConversionUtils.GetServiceClientWorkloadType(type);
            request.ResourceId = resourceId;
            if (!string.IsNullOrWhiteSpace(protectableObjName))
            {
                request.PoLogicalName = protectableObjName;
            }

            return BmsAdapter.Client.BackupStatus.GetWithHttpMessagesAsync(
                resourceLocation,
                request,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Creates a new protection intent or updates an already existing protection intent
        /// </summary>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="request">Protected item create or update request</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Job created in the service for this operation</returns>
        public RestAzureNS.AzureOperationResponse<ProtectionIntentResource> CreateOrUpdateProtectionIntent(
            string protectedItemName,
            ProtectionIntentResource request,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectionIntent.CreateOrUpdateWithHttpMessagesAsync(
                 vaultName ?? BmsAdapter.GetResourceName(),
                 resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                 AzureFabricName,
                 protectedItemName,
                 request,
                 cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Deletes a protection intent
        /// </summary>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Job created in the service for this operation</returns>
        public RestAzureNS.AzureOperationResponse DeleteProtectionIntent(
            string protectedItemName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectionIntent.DeleteWithHttpMessagesAsync(
                 vaultName ?? BmsAdapter.GetResourceName(),
                 resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                 AzureFabricName,
                 protectedItemName,
                 cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }
                
        /// <summary>
        /// List protection intents
        /// </summary>
        /// <param name="queryFilter"></param>
        /// <param name="skipToken"></param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protection intents resource</returns>
        public List<ProtectionIntentResource> ListProtectionIntent(
            ODataQuery<ProtectionIntentQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<ProtectionIntentResource>> listAsync =
                () => BmsAdapter.Client.BackupProtectionIntent.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    skipToken,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<ProtectionIntentResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupProtectionIntent.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Lists workload items according to the query filter and the pagination params
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="queryFilter">Query filter</param>
        /// <param name="skipToken">Skip token for pagination</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protectable items</returns>
        public List<WorkloadItemResource> ListWorkloadItem(
            string containerName,
            ODataQuery<BMSWorkloadItemQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<WorkloadItemResource>> listAsync =
                () => BmsAdapter.Client.BackupWorkloadItems.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    containerName,
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<WorkloadItemResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupWorkloadItems.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }
    }
}

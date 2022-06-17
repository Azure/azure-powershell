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
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;
using Microsoft.Rest.Azure.OData;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Gets detail about the recovery point identified by the input parameters
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="recoveryPointId">ID of the recovery point</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Recovery point response returned by the service</returns>
        public RecoveryPointResource GetRecoveryPointDetails(
            string containerName,
            string protectedItemName,
            string recoveryPointId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            var response = BmsAdapter.Client.RecoveryPoints.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                protectedItemName,
                recoveryPointId,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return response;
        }

        /// <summary>
        /// Lists recovery points according to the input parameters
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="queryFilter">Query filter</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of recovery points</returns>
        public List<RecoveryPointResource> GetRecoveryPoints(
            string containerName,
            string protectedItemName,
            ODataQuery<BMSRPQueryObject> queryFilter,
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<RecoveryPointResource>> listAsync =
                () => BmsAdapter.Client.RecoveryPoints.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    containerName,
                    protectedItemName,
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<RecoveryPointResource>> listNextAsync =
                nextLink => BmsAdapter.Client.RecoveryPoints.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            var response = HelperUtils.GetPagedList(listAsync, listNextAsync);
            return response;
        }

        /// <summary>
        /// Lists recovery points from Secondary region for CRR
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="queryFilter">Query filter</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of recovery points</returns>
        public List<CrrModel.RecoveryPointResource> GetRecoveryPointsFromSecondaryRegion(
            string containerName,
            string protectedItemName,
            ODataQuery<CrrModel.BMSRPQueryObject> queryFilter,
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<CrrModel.RecoveryPointResource>> listAsync =
                () => CrrAdapter.Client.RecoveryPointsCrr.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    containerName,
                    protectedItemName,
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<CrrModel.RecoveryPointResource>> listNextAsync =
                nextLink => CrrAdapter.Client.RecoveryPointsCrr.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            var response = HelperUtils.GetPagedListCrr(listAsync, listNextAsync);
            return response;
        }

        /// <summary>
        /// Lists recovery points recommended for Archive move
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="moveRequest"></param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of recovery points</returns>
        public List<RecoveryPointResource> GetMoveRecommendedRecoveryPoints(
            string containerName,
            string protectedItemName,
            ListRecoveryPointsRecommendedForMoveRequest moveRequest,
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<RecoveryPointResource>> listAsync =
                () => BmsAdapter.Client.RecoveryPointsRecommendedForMove.ListWithHttpMessagesAsync(
                vaultName,
                resourceGroupName,
                AzureFabricName,
                containerName,
                protectedItemName,
                moveRequest             
                ).Result.Body;

            Func<string, RestAzureNS.IPage<RecoveryPointResource>> listNextAsync =
                nextLink => BmsAdapter.Client.RecoveryPointsRecommendedForMove.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            var response = HelperUtils.GetPagedList(listAsync, listNextAsync);
            return response;
        }

        /// <summary>
        /// Lists recovery points recommended for Archive move
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="moveRPAcrossTiersRequest"></param>
        /// <param name="recoveryPointId"></param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of recovery points</returns>
        public RestAzureNS.AzureOperationResponse MoveRecoveryPoint(
            string containerName,
            string protectedItemName,
            MoveRPAcrossTiersRequest moveRPAcrossTiersRequest,
            string recoveryPointId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.BeginMoveRecoveryPointWithHttpMessagesAsync(
                vaultName,
                resourceGroupName,
                AzureFabricName,
                containerName,
                protectedItemName,
                recoveryPointId,
                moveRPAcrossTiersRequest
                ).Result;
        }


        /// <summary>
        /// provision item level recovery connection identified by the input parameters
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="recoveryPointId">ID of the recovery point</param>
        /// <param name="registrationRequest">registration request for ILR</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Azure operation response returned by the service</returns>
        public RestAzureNS.AzureOperationResponse ProvisioninItemLevelRecoveryAccess(
            string containerName,
            string protectedItemName,
            string recoveryPointId,
            ILRRequest registrationRequest,
            string vaultName = null,
            string resourceGroupName = null)
        {
            ILRRequestResource provisionRequest = new ILRRequestResource();
            provisionRequest.Properties = registrationRequest;

            var response = BmsAdapter.Client.ItemLevelRecoveryConnections.ProvisionWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                protectedItemName,
                recoveryPointId,
                provisionRequest,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }

        /// <summary>
        /// Revoke access for item level recovery connection identified by the input parameters
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="recoveryPointId">ID of the recovery point</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Azure operation response returned by the service</returns>
        public RestAzureNS.AzureOperationResponse RevokeItemLevelRecoveryAccess(
            string containerName,
            string protectedItemName,
            string recoveryPointId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            var response = BmsAdapter.Client.ItemLevelRecoveryConnections.RevokeWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                protectedItemName,
                recoveryPointId,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }
    }
}

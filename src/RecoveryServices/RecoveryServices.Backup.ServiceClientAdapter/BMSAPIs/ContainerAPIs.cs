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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using RestAzureNS = Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {

        /// <summary>
        /// Inquire protection containers in the vault according to the query params
        /// </summary>
        /// <param name="containerName">Name of the container to unregister</param>
        /// <param name="queryFilter">Query parameters</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Response of the job created in the service</returns>
        public RestAzureNS.AzureOperationResponse InquireContainer(
            string containerName,
            ODataQuery<BMSContainersInquiryQueryObject> queryFilter,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectionContainers.InquireWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                queryFilter,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Fetches protection containers in the vault according to the query params
        /// </summary>
        /// <param name="queryFilter">Query parameters</param>
        /// <param name="skipToken">Skip token for pagination</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protection containers</returns>
        public IEnumerable<ProtectionContainerResource> ListContainers(
            ODataQuery<BMSContainerQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<ProtectionContainerResource>> listAsync =
                () => BmsAdapter.Client.BackupProtectionContainers.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<ProtectionContainerResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupProtectionContainers.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Fetches a particular protection container in the vault
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public ProtectionContainerResource GetContainer(
            string vaultName = null,
            string resourceGroupName = null,
            string containerName = null)
        {
            ProtectionContainerResource container = BmsAdapter.Client.ProtectionContainers.GetWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    containerName,                    
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return container;
        }

        /// <summary>
        /// Fetches backup engines in the vault according to the query params
        /// </summary>
        /// <param name="queryParams">Query parameters</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of backup engines</returns>
        public IEnumerable<BackupEngineBaseResource> ListBackupEngines(
            ODataQuery<BMSBackupEnginesQueryObject> queryParams,
            string vaultName = null,
            string resourceGroupName = null)
        {
            queryParams.Top = 200;
            Func<RestAzureNS.IPage<BackupEngineBaseResource>> listAsync =
                () => BmsAdapter.Client.BackupEngines.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryParams,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<BackupEngineBaseResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupEngines.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;
            var listResponse = HelperUtils.GetPagedList(listAsync, listNextAsync);
            return listResponse;
        }

        /// <summary>
        /// Fetches unregistered containers in the vault according to the query params
        /// </summary>
        /// <param name="queryFilter">Query parameters</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protectable containers</returns>
        public IEnumerable<ProtectableContainerResource> ListUnregisteredContainers(
            ODataQuery<BMSContainerQueryObject> queryFilter,
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<ProtectableContainerResource>> listAsync =
                () => BmsAdapter.Client.ProtectableContainers.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<ProtectableContainerResource>> listNextAsync =
                nextLink => BmsAdapter.Client.ProtectableContainers.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Gets Backup Usage Summary - registered containers/items  within the vault
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BackupManagementUsage> GetBackupUsageSummary(string vaultName, string resourceGroupName,
            ODataQuery<BMSBackupSummariesQueryObject> queryFilter)
        {            
            Func<IEnumerable<BackupManagementUsage>> listAsync = () => BmsAdapter.Client.BackupUsageSummaries.ListWithHttpMessagesAsync(
                    vaultName,
                    resourceGroupName,
                    queryFilter,
                    skipToken: null,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;
            
            return listAsync();
        }

        /// <summary>
        /// Triggers refresh of container catalog in service
        /// </summary>
        /// <returns>Response of the job created in the service</returns>
        public RestAzureNS.AzureOperationResponse RefreshContainers(
            string vaultName = null,
            string resourceGroupName = null,
            ODataQuery<BMSRefreshContainersQueryObject> queryParam = null)
        {
            var response = BmsAdapter.Client.ProtectionContainers.RefreshWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                queryParam,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }

        /// <summary>
        /// Triggers register of container in service
        /// </summary>
        /// <returns>Response of the job created in the service</returns>
        public RestAzureNS.AzureOperationResponse<ProtectionContainerResource> RegisterContainer(
            string containerName,
            ProtectionContainerResource parameters,
            string vaultName = null,
            string resourceGroupName = null)
        {
            var response = BmsAdapter.Client.ProtectionContainers.RegisterWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                containerName,
                parameters,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }

        /// <summary>
        /// Triggers unregister of a container in service
        /// </summary>
        /// <param name="containerName">Name of the container to unregister</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        public RestAzureNS.AzureOperationResponse UnregisterContainers(
            string containerName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            var response = RSAdapter.Client.RegisteredIdentities.DeleteWithHttpMessagesAsync(
             resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
             vaultName ?? BmsAdapter.GetResourceName(),
             containerName,
             cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }

        /// <summary>
        /// Triggers unregister of a workload container in service
        /// </summary>
        /// <param name="containerName">Name of the container to unregister</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        public RestAzureNS.AzureOperationResponse UnregisterWorkloadContainers(
            string containerName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            var response = BmsAdapter.Client.ProtectionContainers.UnregisterWithHttpMessagesAsync(
            vaultName ?? BmsAdapter.GetResourceName(),
            resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
            AzureFabricName,
            containerName,
            cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }
    }
}

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
        /// Fetches protection containers in the vault according to the query params
        /// </summary>
        /// <param name="queryFilter">Query parameters</param>
        /// <param name="skipToken">Skip token for pagination</param>
        /// <returns>List of protection containers</returns>
        public IEnumerable<ProtectionContainerResource> ListContainers(
            ODataQuery<BMSContainerQueryObject> queryFilter,
            string skipToken = default(string))
        {
            Func<RestAzureNS.IPage<ProtectionContainerResource>> listAsync =
                () => BmsAdapter.Client.BackupProtectionContainers.ListWithHttpMessagesAsync(
                    BmsAdapter.GetResourceName(),
                    BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<ProtectionContainerResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupProtectionContainers.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Fetches backup engines in the vault according to the query params
        /// </summary>
        /// <param name="queryParams">Query parameters</param>
        /// <returns>List of backup engines</returns>
        public IEnumerable<BackupEngineBaseResource> ListBackupEngines(
            ODataQuery<BMSBackupEnginesQueryObject> queryParams)
        {
            queryParams.Top = 200;
            Func<RestAzureNS.IPage<BackupEngineBaseResource>> listAsync =
                () => BmsAdapter.Client.BackupEngines.ListWithHttpMessagesAsync(
                    BmsAdapter.GetResourceName(),
                    BmsAdapter.GetResourceGroupName(),
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
        /// Triggers refresh of container catalog in service
        /// </summary>
        /// <returns>Response of the job created in the service</returns>
        public RestAzureNS.AzureOperationResponse RefreshContainers()
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            var response = BmsAdapter.Client.ProtectionContainers.RefreshWithHttpMessagesAsync(
                resourceName,
                resourceGroupName,
                AzureFabricName,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }

        /// <summary>
        /// Triggers unregister of a container in service
        /// </summary>
        /// <param name="containerName">Name of the container to unregister</param>
        public RestAzureNS.AzureOperationResponse UnregisterContainers(string containerName)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            var response = RSAdapter.Client.RegisteredIdentities.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                resourceName,
                containerName,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }
    }
}

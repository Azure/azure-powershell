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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Fetches protection containers in the vault according to the query params
        /// </summary>
        /// <param name="parameters">Query parameters</param>
        /// <returns>List of protection containers</returns>
        public IEnumerable<ProtectionContainerResource> ListContainers(
            ProtectionContainerListQueryParams queryParams)
        {
            var listResponse = BmsAdapter.Client.Containers.ListAsync(
                                        BmsAdapter.GetResourceGroupName(), 
                                        BmsAdapter.GetResourceName(), 
                                        queryParams,
                                        BmsAdapter.GetCustomRequestHeaders(), 
                                        BmsAdapter.CmdletCancellationToken).Result;
            return listResponse.ItemList.ProtectionContainers;
        }

        /// <summary>
        /// Fetches backup engines in the vault according to the query params
        /// </summary>
        /// <param name="parameters">Query parameters</param>
        /// <returns>List of backup engines</returns>
        public IEnumerable<BackupEngineResource> ListBackupEngines(BackupEngineListQueryParams queryParams)
        {
            PaginationRequest paginationParam = new PaginationRequest();
            paginationParam.Top = "200";
            var listResponse = BmsAdapter.Client.BackupEngines.ListAsync(
                                        BmsAdapter.GetResourceGroupName(), 
                                        BmsAdapter.GetResourceName(), 
                                        queryParams, 
                                        paginationParam, 
                                        BmsAdapter.GetCustomRequestHeaders(),
                                        BmsAdapter.CmdletCancellationToken).Result;
            return listResponse.ItemList.BackupEngines;
        }

        /// <summary>
        /// Triggers refresh of container catalog in service
        /// </summary>
        /// <returns>Response of the job created in the service</returns>
        public BaseRecoveryServicesJobResponse RefreshContainers()
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            var response = BmsAdapter.Client.Containers.RefreshAsync(
                                        resourceGroupName, 
                                        resourceName, 
                                        BmsAdapter.GetCustomRequestHeaders(), 
                                        AzureFabricName, 
                                        BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }

        /// <summary>
        /// Triggers unregister of a container in service
        /// </summary>
        public AzureOperationResponse UnregisterContainers(string containerName)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            
            var response = BmsAdapter.Client.Containers.UnregisterAsync(
                                        resourceGroupName, 
                                        resourceName, 
                                        containerName,
                                        BmsAdapter.GetCustomRequestHeaders(), 
                                        BmsAdapter.CmdletCancellationToken).Result;
            return response;
        }
    }
}

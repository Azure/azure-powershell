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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class HydraClient
    {
        /// <summary>
        /// Fetches protection containers in the vault according to the query params
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<ProtectionContainerResource> RecoveryServicesListContainers(string resourceGroupName, string resourceName, ProtectionContainerListQueryParams queryParams)
        {
            var listResponse = RecoveryServicesBmsAdapter.Client.Container.ListAsync(resourceGroupName, resourceName, queryParams,
                RecoveryServicesBmsAdapter.GetCustomRequestHeaders(), RecoveryServicesBmsAdapter.CmdletCancellationToken).Result;
            return listResponse.ItemList.ProtectionContainers;
        }

        /// <summary>
        /// Triggers refresh of container catalog in service
        /// </summary>
        /// <returns></returns>
        public BaseRecoveryServicesJobResponse RecoveryServicesRefreshContainers(string resourceGroupName, string resourceName)
        {
            var response = RecoveryServicesBmsAdapter.Client.Container.RefreshAsync(
                resourceGroupName, resourceName,
                RecoveryServicesBmsAdapter.GetCustomRequestHeaders(), AzureFabricName, RecoveryServicesBmsAdapter.CmdletCancellationToken).Result;
            return response;
        }
    }
}
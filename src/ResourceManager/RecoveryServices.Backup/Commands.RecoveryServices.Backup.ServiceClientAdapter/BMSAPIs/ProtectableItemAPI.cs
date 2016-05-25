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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Lists protectable items according to the query filter and the pagination params
        /// </summary>
        /// <param name="queryFilter">Query filter</param>
        /// <param name="paginationRequest">Pagination parameters</param>
        /// <returns>List of protectable items</returns>
        public ProtectableObjectListResponse ListProtectableItem(
                ProtectableObjectListQueryParameters queryFilter,
                PaginationRequest paginationRequest = null)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectableObjects.ListAsync(
                                     resourceGroupName,
                                     resourceName,
                                     queryFilter,
                                     paginationRequest,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Triggers backup on the specified item
        /// </summary>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="itemName">Name of the item</param>
        /// <returns>Job created by this operation</returns>
        public BaseRecoveryServicesJobResponse TriggerBackup(string containerName, string itemName)
        {
            return BmsAdapter.Client.Backups.TriggerBackupAsync(
                BmsAdapter.GetResourceGroupName(),
                BmsAdapter.GetResourceName(),
                BmsAdapter.GetCustomRequestHeaders(),
                ServiceClientAdapter.AzureFabricName,
                containerName,
                itemName,
                BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}

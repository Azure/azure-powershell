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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>Recovery point response returned by the service</returns>
        public RecoveryPointResponse GetRecoveryPointDetails
            (
            string containerName, 
            string protectedItemName, 
            string recoveryPointId
            )
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();

            var response = BmsAdapter.Client.RecoveryPoints.GetAsync(
                resourceGroupName, 
                resourceName,
                BmsAdapter.GetCustomRequestHeaders(), 
                AzureFabricName, 
                containerName, 
                protectedItemName, 
                recoveryPointId, 
                BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }

        /// <summary>
        /// Lists recovery points according to the input parameters
        /// </summary>
        /// <param name="containerName">Name of the container which the item belongs to</param>
        /// <param name="protectedItemName">Name of the item</param>
        /// <param name="queryFilter">Query filter</param>
        /// <returns>List of recovery points</returns>
        public RecoveryPointListResponse GetRecoveryPoints
            (
            string containerName, 
            string protectedItemName, 
            RecoveryPointQueryParameters queryFilter
            )
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();

            var response = BmsAdapter.Client.RecoveryPoints.ListAsync(
                resourceGroupName, 
                resourceName,
                BmsAdapter.GetCustomRequestHeaders(), 
                AzureFabricName, 
                containerName, 
                protectedItemName, 
                queryFilter, 
                BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }
    }
}

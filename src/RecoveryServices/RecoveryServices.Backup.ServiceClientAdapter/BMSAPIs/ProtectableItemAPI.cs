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
        /// Lists protectable items according to the query filter and the pagination params
        /// </summary>
        /// <param name="queryFilter">Query filter</param>
        /// <param name="skipToken">Skip token for pagination</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protectable items</returns>
        public List<WorkloadProtectableItemResource> ListProtectableItem(
            ODataQuery<BMSPOQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<WorkloadProtectableItemResource>> listAsync =
                () => BmsAdapter.Client.BackupProtectableItems.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<WorkloadProtectableItemResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupProtectableItems.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }
    }
}

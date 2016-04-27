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
        public BaseRecoveryServicesJobResponse CreateOrUpdateProtectedItem(
                string containerName,
                string protectedItemName,
                ProtectedItemCreateOrUpdateRequest request)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.CreateOrUpdateProtectedItemAsync(
                                     resourceGroupName,
                                     resourceName,
                                     AzureFabricName,
                                     containerName,
                                     protectedItemName,
                                     request,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        public BaseRecoveryServicesJobResponse DeleteProtectedItem(
                string containerName,
                string protectedItemName)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.DeleteProtectedItemAsync(
                                     resourceGroupName,
                                     resourceName,
                                     AzureFabricName,
                                     containerName,
                                     protectedItemName,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        public ProtectedItemResponse GetProtectedItem(
                string containerName,
                string protectedItemName,
            GetProtectedItemQueryParam queryFilter)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.GetAsync(
                                     resourceGroupName,
                                     resourceName,
                                     AzureFabricName,
                                     containerName,
                                     protectedItemName,
                                     queryFilter,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        public ProtectedItemListResponse ListProtectedItem(
                ProtectedItemListQueryParam queryFilter,
            PaginationRequest paginationParams = null)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectedItems.ListAsync(
                                     resourceGroupName,
                                     resourceName, 
                                     queryFilter,
                                     paginationParams,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}

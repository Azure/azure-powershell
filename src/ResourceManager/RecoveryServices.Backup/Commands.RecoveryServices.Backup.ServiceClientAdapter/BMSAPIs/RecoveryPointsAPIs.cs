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

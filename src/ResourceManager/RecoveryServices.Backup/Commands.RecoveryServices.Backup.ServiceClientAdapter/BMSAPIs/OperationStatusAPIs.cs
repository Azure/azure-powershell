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

using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Gets result of a generic operation on the protected item using the operation tracking URL
        /// </summary>
        /// <param name="operationResultLink">Operation tracking URL</param>
        /// <returns>Operation status response returned by the service</returns>
        public AzureOperationResponse<ServiceClientModel.OperationStatus> GetProtectedItemOperationStatus(
                string operationId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.BackupOperationStatuses.GetWithHttpMessagesAsync(
                resourceName, resourceGroupName, operationId).Result;
        }

        public AzureOperationResponse<ServiceClientModel.OperationStatus> GetProtectionPolicyOperationStatus(
            string policyName, string operationId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectionPolicyOperationStatuses.GetWithHttpMessagesAsync(
                resourceName, resourceGroupName, policyName, operationId).Result;
        }

        public Microsoft.Rest.Azure.AzureOperationResponse GetRefreshContainerOperationResult(
                string operationId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.ProtectionContainerRefreshOperationResults.GetWithHttpMessagesAsync(
                resourceName, resourceGroupName, AzureFabricName, operationId).Result;
        }


        public Microsoft.Rest.Azure.AzureOperationResponse GetCancelJobOperationResult(
                string operationId)
        {
            string resourceName = BmsAdapter.GetResourceName();
            string resourceGroupName = BmsAdapter.GetResourceGroupName();

            return BmsAdapter.Client.JobOperationResults.GetWithHttpMessagesAsync(
                resourceName, resourceGroupName, AzureFabricName, operationId).Result;
        }
    }
}

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
using Newtonsoft.Json;
using RestAzureNS = Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModel = Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Gets result of a generic operation on the protected item using the operation ID
        /// </summary>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Operation status response returned by the service</returns>
        public RestAzureNS.AzureOperationResponse<ServiceClientModel.OperationStatus>
            GetProtectedItemOperationStatus(
                string operationId,
                string vaultName = null,
                string resourceGroupName = null)
        {
            return BmsAdapter.Client.BackupOperationStatuses.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                operationId).Result;
        }

        /// <summary>
        /// Gets status of a generic operation on the protected item using the operation ID
        /// </summary>
        /// <param name="secondaryRegion">secondary region where to trigger the restore</param>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <returns>Operation status response returned by the service</returns>
        public RestAzureNS.AzureOperationResponse<CrrModel.OperationStatus>
            GetCrrOperationStatus(
                string secondaryRegion,
                string operationId)
        {
            return CrrAdapter.Client.CrrOperationStatus.GetWithHttpMessagesAsync(
                secondaryRegion,
                operationId).Result;
        }

        /// <summary>
        /// Gets result of a generic operation on the protection policy using the operation ID
        /// </summary>
        /// <param name="policyName">Name of the policy associated with the operation</param>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public RestAzureNS.AzureOperationResponse<ServiceClientModel.OperationStatus>
            GetProtectionPolicyOperationStatus(
                string policyName,
                string operationId,
                string vaultName = null,
                string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectionPolicyOperationStatuses.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                policyName,
                operationId).Result;
        }

        /// <summary>
        /// Gets result of the refresh operation on the protection container using the operation ID
        /// </summary>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public RestAzureNS.AzureOperationResponse GetContainerRefreshOrInquiryOperationResult(
            string operationId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter
                .Client
                .ProtectionContainerRefreshOperationResults
                .GetWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    operationId).Result;
        }

        /// <summary>
        /// Gets result of the refresh operation on the protection container using the operation ID
        /// </summary>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="containerName">Name of the container which this item belongs to</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public RestAzureNS.AzureOperationResponse<ServiceClientModel.ProtectionContainerResource>
            GetRegisterContainerOperationResult(
            string operationId,
            string containerName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter
                .Client
                .ProtectionContainerOperationResults
                .GetWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    AzureFabricName,
                    containerName,
                    operationId).Result;
        }

        /// <summary>
        /// Gets status of prepare data move operation on the source vault 
        /// </summary>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public RestAzureNS.AzureOperationResponse<ServiceClientModel.OperationStatus>
            GetDataMoveOperationStatus(
            string operationId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.GetOperationStatusWithHttpMessagesAsync(
                                vaultName,
                                resourceGroupName,
                                operationId).Result;
        }

        /// <summary>
        /// Gets correlationId result of prepare data move operation on the source vault 
        /// </summary>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public PrepareDataMoveResponse
            GetPrepareDataMoveOperationResult(
            string operationId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            var prepareResponseBase = BmsAdapter.Client.BMSPrepareDataMoveOperationResult.GetWithHttpMessagesAsync(
                                vaultName,
                                resourceGroupName,
                                operationId).Result.Body;

            var prepareResponseSerialized = JsonConvert.SerializeObject(prepareResponseBase);
            PrepareDataMoveResponse prepareResponseDerived = JsonConvert.DeserializeObject<PrepareDataMoveResponse>(prepareResponseSerialized);
            
            return prepareResponseDerived;
        }

        /// <summary>
        /// Gets result of the cancel operation on the job using the operation ID
        /// </summary>
        /// <param name="operationId">ID of the operation in progress</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public RestAzureNS.AzureOperationResponse GetCancelJobOperationResult(
            string operationId,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.JobOperationResults.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                AzureFabricName,
                operationId).Result;
        }
    }
}

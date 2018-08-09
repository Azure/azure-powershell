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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using SystemNet = System.Net;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ProviderModel
{
    /// <summary>
    /// This class implements implements methods for Azure Workload Provider Helper
    /// </summary>
    public class AzureWorkloadProviderHelper
    {
        ServiceClientAdapter ServiceClientAdapter { get; set; }

        public AzureWorkloadProviderHelper(ServiceClientAdapter serviceClientAdapter)
        {
            ServiceClientAdapter = serviceClientAdapter;
        }

        public void RefreshContainer(string vaultName = null, string resourceGroupName = null)
        {
            string errorMessage = string.Empty;
            var refreshContainerJobResponse = ServiceClientAdapter.RefreshContainers(
                vaultName: vaultName,
                resourceGroupName: resourceGroupName);

            var operationStatus = TrackingHelpers.GetOperationResult(
                refreshContainerJobResponse,
                operationId =>
                    ServiceClientAdapter.GetRefreshContainerOperationResult(
                        operationId,
                        vaultName: vaultName,
                        resourceGroupName: resourceGroupName));

            //Now wait for the operation to Complete
            if (refreshContainerJobResponse.Response.StatusCode
                    != SystemNet.HttpStatusCode.NoContent)
            {
                errorMessage = string.Format(Resources.DiscoveryFailureErrorCode,
                    refreshContainerJobResponse.Response.StatusCode);
                Logger.Instance.WriteDebug(errorMessage);
            }
        }
    }
}
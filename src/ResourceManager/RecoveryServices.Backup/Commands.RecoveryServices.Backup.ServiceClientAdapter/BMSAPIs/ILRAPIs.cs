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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
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
        /// 
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="recoveryPointId"></param>
        /// <param name="iqn"></param>
        /// <param name="shouldExtend"></param>
        /// <returns></returns>
        public BaseRecoveryServicesJobResponse ProvisionOrExtendIlrSession(
            AzureVmRecoveryPoint recoveryPoint,
            string iqn,
            bool shouldExtend = false)
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();

            ProvisionILRRequest provisionRequest = new ProvisionILRRequest();
            provisionRequest.Item = new ILRRestoreRequestResource();
            IaasVMILRRegistrationRequest registrationRequest = new IaasVMILRRegistrationRequest();
            registrationRequest.InitiatorName = iqn;
            registrationRequest.RecoveryPointId = recoveryPoint.RecoveryPointId;
            registrationRequest.RenewExistingRegistration = shouldExtend.ToString();
            provisionRequest.Item.Properties = new IaasVMILRRegistrationRequest();

            FileFolderRestoreParameters parameters = new FileFolderRestoreParameters();
            parameters.ResourceGroupName = resourceGroupName;
            parameters.ResourceName = resourceName;
            parameters.CustomRequestHeaders = BmsAdapter.GetCustomRequestHeaders();
            parameters.FabricName = AzureFabricName;
            parameters.ContainerName = recoveryPoint.ContainerName;
            parameters.ProtectedItemName = recoveryPoint.ItemName;
            parameters.RecoveryPointId = recoveryPoint.RecoveryPointId;

            var response = BmsAdapter.Client.FileFolderRestores.ProvisionAsync(
                parameters,
                provisionRequest,
                BmsAdapter.CmdletCancellationToken).Result;

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="protectedItemName"></param>
        /// <param name="recoveryPointId"></param>
        public void RevokeIlrSession(AzureVmRecoveryPoint recoveryPoint)
        {
            string resourceGroupName = BmsAdapter.GetResourceGroupName();
            string resourceName = BmsAdapter.GetResourceName();

            FileFolderRestoreParameters parameters = new FileFolderRestoreParameters();
            parameters.ResourceGroupName = resourceGroupName;
            parameters.ResourceName = resourceName;
            parameters.CustomRequestHeaders = BmsAdapter.GetCustomRequestHeaders();
            parameters.FabricName = AzureFabricName;
            parameters.ContainerName = recoveryPoint.ContainerName;
            parameters.ProtectedItemName = recoveryPoint.ItemName;
            parameters.RecoveryPointId = recoveryPoint.RecoveryPointId;

            BmsAdapter.Client.FileFolderRestores.RevokeAsync(
                parameters,
                BmsAdapter.CmdletCancellationToken).Wait();
        }
    }
}

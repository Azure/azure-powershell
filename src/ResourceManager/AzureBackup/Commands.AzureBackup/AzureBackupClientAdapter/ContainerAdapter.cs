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

using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        /// <summary>
        /// Gets all MARS containers in the vault
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarsContainerResponse> ListMachineContainers(string resourceGroupName, string resourceName)
        {
            var listResponse = AzureBackupVaultClient.Container.ListMarsContainersByType(resourceGroupName, resourceName, MarsContainerType.Machine, GetCustomRequestHeaders());
            return listResponse.ListMarsContainerResponse.Value;
        }

        /// <summary>
        /// Gets all MARS containers in the vault which match the friendly name
        /// </summary>
        /// <param name="friendlyName">The friendly name of the container</param>
        /// <returns></returns>
        public IEnumerable<MarsContainerResponse> ListMachineContainers(string resourceGroupName, string resourceName, string friendlyName)
        {
            var listResponse = AzureBackupVaultClient.Container.ListMarsContainersByTypeAndFriendlyName(resourceGroupName, resourceName, MarsContainerType.Machine, friendlyName, GetCustomRequestHeaders());
            return listResponse.ListMarsContainerResponse.Value;
        }

        /// <summary>
        /// UnRegister container
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public void UnregisterMachineContainer(string resourceGroupName, string resourceName, long containerId)
        {
            AzureBackupVaultClient.Container.UnregisterMarsContainer(resourceGroupName, resourceName, containerId.ToString(), GetCustomRequestHeaders());
        }

        /// <summary>
        /// Enable container reregistration
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public void EnableMachineContainerReregistration(string resourceGroupName, string resourceName, long containerId)
        {
            EnableReregistrationRequest request = new EnableReregistrationRequest()
            {
                ContainerReregistrationState = new ContainerReregistrationState()
                {
                    EnableReregistration = true,
                },
            };

            AzureBackupVaultClient.Container.EnableMarsContainerReregistration(resourceGroupName, resourceName, containerId.ToString(), request, GetCustomRequestHeaders());
        }

        /// <summary>
        /// Gets all IaaSVM containers in the vault by friendly name
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<CSMContainerResponse> ListContainers(string resourceGroupName, string resourceName, ContainerQueryParameters parameters)
        {
            var listResponse = AzureBackupClient.Container.ListAsync(resourceGroupName, resourceName, parameters, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return listResponse.CSMContainerListResponse.Value;
        }

        /// <summary>
        /// Register container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Guid RegisterContainer(string resourceGroupName, string resourceName, string containerName)
        {
            var response = AzureBackupClient.Container.RegisterAsync(resourceGroupName, resourceName, containerName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// UnRegister container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Guid UnRegisterContainer(string resourceGroupName, string resourceName, string containerName)
        {
            var response = AzureBackupClient.Container.UnregisterAsync(resourceGroupName, resourceName, containerName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Refresh container list in service
        /// </summary>
        /// <returns></returns>
        public Guid RefreshContainers(string resourceGroupName, string resourceName)
        {
            var response = AzureBackupClient.Container.RefreshAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response.OperationId;
        }
    }
}
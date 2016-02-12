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

using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class HydraHelper
    {
        /// <summary>
        /// Gets all IaaSVM containers in the vault by friendly name
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IEnumerable<CSMContainerResponse> BackupListContainers(string resourceGroupName, string resourceName, ContainerQueryParameters parameters)
        {
            var listResponse = BackupBmsAdapter.Client.Container.ListAsync(
                resourceGroupName, resourceName, parameters,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return listResponse.CSMContainerListResponse.Value;
        }

        /// <summary>
        /// Register container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Guid BackupRegisterContainer(string resourceGroupName, string resourceName, string containerName)
        {
            var response = BackupBmsAdapter.Client.Container.RegisterAsync(
                resourceGroupName, resourceName, containerName,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// UnRegister container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Guid BackupUnRegisterContainer(string resourceGroupName, string resourceName, string containerName)
        {
            var response = BackupBmsAdapter.Client.Container.UnregisterAsync(
                resourceGroupName, resourceName, containerName,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Refresh container list in service
        /// </summary>
        /// <returns></returns>
        public Guid BackupRefreshContainers(string resourceGroupName, string resourceName)
        {
            var response = BackupBmsAdapter.Client.Container.RefreshAsync(
                resourceGroupName, resourceName,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }
    }
}
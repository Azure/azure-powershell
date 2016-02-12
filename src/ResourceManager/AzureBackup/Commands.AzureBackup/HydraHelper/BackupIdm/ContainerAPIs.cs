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
        /// Gets all MARS containers in the vault
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarsContainerResponse> ListMachineContainers(string resourceGroupName, string resourceName)
        {
            var listResponse = BackupIdmAdapter.Client.Container.ListMarsContainersByTypeAsync(
                resourceGroupName, resourceName, MarsContainerType.Machine,
                BackupIdmAdapter.GetCustomRequestHeaders(), BackupIdmAdapter.CmdletCancellationToken).Result;
            return listResponse.ListMarsContainerResponse.Value;
        }

        /// <summary>
        /// Gets all MARS containers in the vault which match the friendly name
        /// </summary>
        /// <param name="friendlyName">The friendly name of the container</param>
        /// <returns></returns>
        public IEnumerable<MarsContainerResponse> ListMachineContainers(string resourceGroupName, string resourceName, string friendlyName)
        {
            var listResponse = BackupIdmAdapter.Client.Container.ListMarsContainersByTypeAndFriendlyNameAsync(
                resourceGroupName, resourceName, MarsContainerType.Machine, friendlyName,
                BackupIdmAdapter.GetCustomRequestHeaders(), BackupIdmAdapter.CmdletCancellationToken).Result;
            return listResponse.ListMarsContainerResponse.Value;
        }

        /// <summary>
        /// UnRegister container
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public void UnregisterMachineContainer(string resourceGroupName, string resourceName, long containerId)
        {
            BackupIdmAdapter.Client.Container.UnregisterMarsContainerAsync(
                resourceGroupName, resourceName, containerId.ToString(),
                BackupIdmAdapter.GetCustomRequestHeaders(), BackupIdmAdapter.CmdletCancellationToken).Wait();
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

            BackupIdmAdapter.Client.Container.EnableMarsContainerReregistrationAsync(
                resourceGroupName, resourceName, containerId.ToString(), request,
                BackupIdmAdapter.GetCustomRequestHeaders(), BackupIdmAdapter.CmdletCancellationToken).Wait();
        }
    }
}
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
using System.Management.Automation;
using System.Collections.Generic;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Commands.AzureBackup.Properties;
using System.Net;
using System.Linq;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Commands.AzureBackup.Models;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        /// <summary>
        /// Gets all MARS containers in the vault
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MarsContainerResponse> ListMachineContainers()
        {
            var listResponse = AzureBackupVaultClient.Container.ListMarsContainersByType(MarsContainerType.Machine, GetCustomRequestHeaders());
            return listResponse.ListMarsContainerResponse.Value;
        }

        /// <summary>
        /// Gets all MARS containers in the vault which match the friendly name
        /// </summary>
        /// <param name="friendlyName">The friendly name of the container</param>
        /// <returns></returns>
        public IEnumerable<MarsContainerResponse> ListMachineContainers(string friendlyName)
        {
            var listResponse = AzureBackupVaultClient.Container.ListMarsContainersByTypeAndFriendlyName(MarsContainerType.Machine, friendlyName, GetCustomRequestHeaders());
            return listResponse.ListMarsContainerResponse.Value;
        }

        /// <summary>
        /// UnRegister container
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public void UnregisterMachineContainer(long containerId)
        {
            AzureBackupVaultClient.Container.UnregisterMarsContainer(containerId.ToString(), GetCustomRequestHeaders());
        }

        /// <summary>
        /// Enable container reregistration
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public void EnableMachineContainerReregistration(long containerId)
        {
            AzureBackupVaultClient.Container.EnableMarsContainerReregistration(containerId.ToString(), GetCustomRequestHeaders());
        }
    }
}
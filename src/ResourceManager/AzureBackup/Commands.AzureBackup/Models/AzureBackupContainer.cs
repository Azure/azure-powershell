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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    /// <summary>
    /// Represents Azure Backup Container
    /// </summary>
    public class AzureBackupContainer : AzureBackupContainerContextObject
    {
        /// <summary>
        /// Resource group name of the resource (ex: resource group name of the VM) being managed by Azure Backup service.
        /// </summary>
        public string ManagedResourceGroupName { get; set; }

        /// <summary>
        /// Resource name of the resource (ex: resource name of the VM) being managed by the Azure Backup service.
        /// </summary>
        public string ManagedResourceName { get; set; }

        /// <summary>
        /// Status of health of the Azure Backup container
        /// </summary>
        public string HealthStatus { get; set; }

        /// <summary>
        /// Status of registration of the container
        /// </summary>
        public string RegistrationStatus { get; set; }

        public AzureBackupContainer() : base() { }

        public AzureBackupContainer(AzurePSBackupVault vault, ContainerInfo containerInfo)
            : base(vault, containerInfo)
        {
            ManagedResourceGroupName = containerInfo.ParentContainerFriendlyName;
            ManagedResourceName = containerInfo.FriendlyName;
            HealthStatus = containerInfo.HealthStatus;
            RegistrationStatus = containerInfo.RegistrationStatus;
        }
    }
}

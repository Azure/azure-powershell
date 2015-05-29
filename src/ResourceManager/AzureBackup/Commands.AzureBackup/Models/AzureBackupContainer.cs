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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Represents Azure Backup Container
    /// </summary>
    public class AzureBackupContainer : AzureBackupVaultContextObject
    {
        /// <summary>
        /// Type of the Azure Backup container
        /// </summary>
        public string ContainerType { get; set; }

        /// <summary>
        /// Friendly name for the Azure Backup container
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Status of health of the Azure Backup container
        /// </summary>
        public string HealthStatus { get; set; }

        /// <summary>
        /// Id of the Azure Backup Container
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Name of the Azure Backup container
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Friendly name of the parent container
        /// </summary>
        public string ParentContainerFriendlyName { get; set; }

        /// <summary>
        /// Name of the parent container
        /// </summary>
        public string ParentContainerName { get; set; }

        /// <summary>
        /// Region where this container is present
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Status of registration of the container
        /// </summary>
        public string RegistrationStatus { get; set; }
    }
}

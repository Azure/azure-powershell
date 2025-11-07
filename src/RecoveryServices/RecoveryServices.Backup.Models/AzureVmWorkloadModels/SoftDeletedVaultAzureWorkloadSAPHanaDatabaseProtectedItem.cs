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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Soft Deleted Azure Workload SAP HANA Database Item Class
    /// </summary>
    public class SoftDeletedVaultAzureWorkloadSAPHanaDatabaseProtectedItem : AzureWorkloadSAPHanaDatabaseProtectedItem
    {
        /// <summary>
        /// Vault ID from which the item was soft deleted
        /// </summary>
        public string VaultId { get; set; }

        /// <summary>
        /// Constructor for soft deleted Azure Workload SAP HANA Database item
        /// </summary>
        /// <param name="protectedItemResource">Mock protected item resource</param>
        /// <param name="containerName">Container name</param>
        /// <param name="containerType">Container type</param>
        /// <param name="policyName">Policy name</param>
        public SoftDeletedVaultAzureWorkloadSAPHanaDatabaseProtectedItem(ProtectedItemResource protectedItemResource,
            string containerName, ContainerType containerType, string policyName)
            : base(protectedItemResource, containerName, containerType, policyName)
        {
            if (!string.IsNullOrEmpty(protectedItemResource?.Id))
            {
                VaultId = ModeHelpers.ExtractVaultIdFromSoftDeletedId(protectedItemResource.Id);
            }
        }
    }
}
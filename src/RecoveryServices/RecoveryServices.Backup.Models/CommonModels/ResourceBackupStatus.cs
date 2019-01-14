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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Backup status of a resource.
    /// </summary>
    public class ResourceBackupStatus
    {
        /// <summary>
        /// If the resource is protected by some vault in the subscription, this contains the resource ID of that vault.
        /// </summary>
        public string VaultId { get; set; }

        /// <summary>
        /// Specifies whether the resource is protected by some vault in the subscription.
        /// </summary>
        public bool BackedUp { get; set; }

        public ResourceBackupStatus(string vaultId, bool backedUp)
        {
            if (backedUp && string.IsNullOrEmpty(vaultId) ||
                !backedUp && !string.IsNullOrEmpty(vaultId))
            {
                throw new ArgumentException($"Inconsistent parameters specified. backedUp: {backedUp} and vaultId: {vaultId}.");
            }

            VaultId = vaultId;
            BackedUp = backedUp;
        }
    }
}

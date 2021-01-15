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

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesVolumeBackupProperties
    {
        /// <summary>
        /// Gets BackupPolicyId
        /// </summary>
        /// <remarks>
        /// Backup Policy Resource ID
        /// </remarks>
        public string BackupPolicyId { get; set; }

        /// Gets PolicyEnforced
        /// </summary>
        /// <remarks>
        /// Policy Enforced
        /// </remarks>
        public bool? PolicyEnforced { get; set; }

        /// Gets PolicyEnforced
        /// </summary>
        /// <remarks>
        /// Vault Resource ID
        /// </remarks>
        public string VaultId { get; set; }

        //
        // Summary:
        //     Gets or sets BackupEnabled
        /// Gets PolicyEnforced
        /// </summary>
        /// <remarks>
        /// Backup Enabled
        /// </remarks>
        public bool? BackupEnabled { get; set; }
    }
}
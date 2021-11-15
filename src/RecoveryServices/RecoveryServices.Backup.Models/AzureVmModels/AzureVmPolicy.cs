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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure VM specific backup policy class.
    /// </summary>
    public class AzureVmPolicy : AzurePolicy
    {
        /// <summary>
        /// Object defining the retention days for a snapshot
        /// </summary>
        public int? SnapshotRetentionInDays { get; set; }

        /// <summary>
        /// Object defining the number of associated items for the policy
        /// </summary>
        public int? ProtectedItemsCount { get; set; }

        /// <summary>
        /// object defining the RG Name to store Restore Points
        /// </summary>
        public string AzureBackupRGName { get; set; }

        /// <summary>
        /// object defining the RG Name suffix to store Restore Points
        /// </summary>
        public string AzureBackupRGNameSuffix { get; set; }
    }

}
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
    public class AzureBackupItem : AzureBackupItemContextObject
    {
        /// <summary>
        /// Status for the Azure Backup Item
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Protection Status for the Azure Backup Item
        /// </summary>
        public string ProtectionStatus { get; set; }

        /// <summary>
        /// Protectable Object Name for the Azure Backup Item
        /// </summary>
        public string ProtectableObjectName { get; set; }

        /// <summary>
        /// Protection Policy Name for the Azure Backup Item
        /// </summary>
        public string ProtectionPolicyName { get; set; }

        /// <summary>
        /// Protection Policy Id for the Azure Backup Item
        /// </summary>
        public string ProtectionPolicyId { get; set; }

        /// <summary>
        /// Policy Inconsistent for the Azure Backup Item
        /// </summary>
        public bool PolicyInconsistent { get; set; }

        /// <summary>
        /// Recovery Points Count for the Azure Backup Item
        /// </summary>
        public int RecoveryPointsCount { get; set; }

        /// <summary>
        /// Last Recovery Point for the Azure Backup Item
        /// </summary>
        public DateTime? LastRecoveryPoint { get; set; }

        /// <summary>
        /// Last Backup Time for the Azure Backup Item
        /// </summary>
        public DateTime? LastBackupTime { get; set; }

        /// <summary>
        /// Last Backup Status for the Azure Backup Item
        /// </summary>
        public string LastBackupStatus { get; set; }

        /// <summary>
        /// Last Backup Job Id for the Azure Backup Item
        /// </summary>
        public string LastBackupJobId { get; set; }
    }
}
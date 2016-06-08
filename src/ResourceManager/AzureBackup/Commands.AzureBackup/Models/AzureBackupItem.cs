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

using Microsoft.Azure.Commands.AzureBackup.Helpers;
using Microsoft.Azure.Management.BackupServices.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.AzureBackup.Models
{
    /// <summary>
    /// Represents Azure Backup Item
    /// </summary>
    public class AzureRMBackupItem : AzureRMBackupItemContextObject
    {
        /// <summary>
        /// Friendly Name for the Azure BackupItem
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status for the Azure Backup Item
        /// </summary>
        public string DataSourceStatus { get; set; }

        /// <summary>
        /// Protection Status for the Azure Backup Item
        /// </summary>
        public string ProtectionStatus { get; set; }

        /// <summary>
        /// Type of Azure Backup Item
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Protection Policy Name for the Azure Backup Item
        /// </summary>
        public string ProtectionPolicyName { get; set; }

        /// <summary>
        /// Protection Policy Id for the Azure Backup Item
        /// </summary>
        public string ProtectionPolicyId { get; set; }

        /// <summary>
        /// Recovery Points Count for the Azure Backup Item
        /// </summary>
        public int RecoveryPointsCount { get; set; }

        public AzureRMBackupItem()
            : base()
        {
        }

        public AzureRMBackupItem(CSMProtectedItemResponse datasource, AzureRMBackupContainer azureBackupContainer)
            : base(datasource, azureBackupContainer)
        {
            DataSourceStatus = datasource.Properties.ProtectionStatus;
            ProtectionStatus = datasource.Properties.Status;
            ItemName = datasource.Name;
            Name = datasource.Properties.FriendlyName;

            if (datasource.Properties.ProtectionPolicyId != null)
            {
                ProtectionPolicyName = datasource.Properties.ProtectionPolicyId.Split('/').Last();
            }

            ProtectionPolicyId = datasource.Properties.ProtectionPolicyId;
            RecoveryPointsCount = datasource.Properties.RecoveryPointsCount;
            Type = ItemHelpers.GetTypeForItem(datasource.Properties.ItemType);
        }

        public AzureRMBackupItem(CSMItemResponse pPOItem, AzureRMBackupContainer azureBackupContainer)
            : base(pPOItem, azureBackupContainer)
        {
            ProtectionStatus = pPOItem.Properties.Status;
            ItemName = pPOItem.Name;
            Name = pPOItem.Properties.FriendlyName;
            Type = ItemHelpers.GetTypeForItem(pPOItem.Properties.ItemType);
        }
    }
}
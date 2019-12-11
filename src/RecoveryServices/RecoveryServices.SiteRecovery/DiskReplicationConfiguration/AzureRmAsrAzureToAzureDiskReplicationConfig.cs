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

using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates Azure Site Recovery Disk replication configuration for A2A replication.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrAzureToAzureDiskReplicationConfig",DefaultParameterSetName = ASRParameterSets.AzureToAzure,SupportsShouldProcess = true)]
    [Alias("New-ASRAzureToAzureDiskReplicationConfig")]
    [OutputType(typeof(ASRAzuretoAzureDiskReplicationConfig))]
    public class AzureRmAsrAzureToAzureDiskReplicationConfig : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        ///    Switch parameter specifying that the disk replication config created for managed disk.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk,
            Mandatory = true)]
        public SwitchParameter ManagedDisk { get; set; }

        /// <summary>
        ///     Gets or sets the disk uri.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specify the VHD URI of the disk that this mapping corresponds to.")]
        [ValidateNotNullOrEmpty]
        public string VhdUri { get; set; }

        /// <summary>
        ///     Gets or sets the primary staging/ log storage account ARM Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the log or cache storage account Id to be used to store replication logs.")]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery disk storage account ARM Id. 
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            HelpMessage = "Specifies the ID of the Azure storage account to replicate to.")]
        [ValidateNotNullOrEmpty]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the disk uri.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DiskId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery RecoveryResourceGroupId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the recovery RecoveryReplicaDiskAccountType.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Premium_LRS,
            Constants.Standard_LRS,
            Constants.Standard_SSD)]
        public string RecoveryReplicaDiskAccountType { get; set; }

        /// <summary>
        ///     Gets or sets the recovery RecoveryTargetDiskAccountType.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.Premium_LRS,
            Constants.Standard_LRS,
            Constants.Standard_SSD)]
        public string RecoveryTargetDiskAccountType { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureManagedDisk, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionVaultId { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            ASRAzuretoAzureDiskReplicationConfig diskRelicationConfig = null;

            var entityId = this.VhdUri == null ? this.DiskId : this.VhdUri;
            // Creating ASRAzureToAzureDiskReplicationConfig for Disk 
            if (this.ShouldProcess(
                this.VhdUri,
                VerbsCommon.New))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.AzureToAzure:
                        diskRelicationConfig = new ASRAzuretoAzureDiskReplicationConfig()
                        {
                            VhdUri = this.VhdUri,
                            LogStorageAccountId = this.LogStorageAccountId,
                            RecoveryAzureStorageAccountId = this.RecoveryAzureStorageAccountId
                        };
                        break;
                    case ASRParameterSets.AzureToAzureManagedDisk:
                        diskRelicationConfig = new ASRAzuretoAzureDiskReplicationConfig()
                        {
                            DiskId = this.DiskId,
                            LogStorageAccountId = this.LogStorageAccountId,
                            RecoveryReplicaDiskAccountType = this.RecoveryReplicaDiskAccountType,
                            RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                            RecoveryTargetDiskAccountType = this.RecoveryTargetDiskAccountType,
                            IsManagedDisk = true,
                            DiskEncryptionSecretUrl = this.DiskEncryptionSecretUrl,
                            DiskEncryptionVaultId = this.DiskEncryptionVaultId,
                            KeyEncryptionKeyUrl = this.KeyEncryptionKeyUrl,
                            KeyEncryptionVaultId = this.KeyEncryptionVaultId
                        };
                        break;
                }
                this.WriteObject(diskRelicationConfig);
            }
        }
    }
}

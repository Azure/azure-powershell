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
    ///     Creates Azure Site Recovery replication protected item configuration for A2A replication.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig", DefaultParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails, SupportsShouldProcess = true)]
    [Alias("New-ASRAzureToAzureReplicationProtectedItemConfig")]
    [OutputType(typeof(ASRAzureToAzureReplicationProtectedItemConfig))]
    public class AzureRmAsrAzureToAzureReplicationProtectedItemConfig : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        ///    Switch parameter specifying that the Azure to Azure replication config created.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ManagedDisk { get; set; }

        /// <summary>
        ///     Gets or sets the replication protected item name.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ReplicationProtectedItemName { get; set; }

        /// <summary>
        /// Gets or sets the recovery resource group Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the list of virtual machine disks to replicated 
        ///     and the log storage account and recovery storage account to be used to replicate the disk.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureDiskReplicationConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability set.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        /// Gets or sets the boot diagnostic storage account.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the recovery availability zone.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        /// Gets or sets the recovery proximity placement group Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets the virtual machine scale set id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryVirtualMachineScaleSetId { get; set; }

        /// <summary>
        /// Gets or sets the recovery capacity reservation group Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryCapacityReservationGroupId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            HelpMessage = "Specifies the disk encryption secret key vault ID(Azure disk encryption) to be used be recovery VM after failover.")]
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            HelpMessage = "Specifies the disk encryption secret URL(Azure disk encryption) to be used be recovery VM after failover.")]
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            HelpMessage = "Specifies the disk encryption secret key URL(Azure disk encryption) to be used be recovery VM after failover.")]
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutDiskDetails,
            HelpMessage = "Specifies the disk encryption secret key vault ID(Azure disk encryption) to be used be recovery VM after failover.")]
        public string KeyEncryptionVaultId { get; set; }

        #endregion Parameters

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            ASRAzureToAzureReplicationProtectedItemConfig protectedItemConfig = null;

            // Creating ASRAzureToAzureReplicationProtectedItemConfig 
            if (this.ShouldProcess(
                this.ReplicationProtectedItemName,
                VerbsCommon.New))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.AzureToAzure:
                    case ASRParameterSets.AzureToAzureWithoutDiskDetails:
                        protectedItemConfig = new ASRAzureToAzureReplicationProtectedItemConfig()
                        {
                            ReplicationProtectedItemName = this.ReplicationProtectedItemName,
                            RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                            RecoveryAvailabilitySetId = this.RecoveryAvailabilitySetId,
                            RecoveryAvailabilityZone = this.RecoveryAvailabilityZone,
                            RecoveryProximityPlacementGroupId = this.RecoveryProximityPlacementGroupId,
                            RecoveryCapacityReservationGroupId = this.RecoveryCapacityReservationGroupId,
                            RecoveryVirtualMachineScaleSetId = this.RecoveryVirtualMachineScaleSetId,
                            RecoveryBootDiagStorageAccountId = this.RecoveryBootDiagStorageAccountId,
                            DiskEncryptionSecretUrl = this.DiskEncryptionSecretUrl,
                            DiskEncryptionVaultId = this.DiskEncryptionVaultId,
                            KeyEncryptionKeyUrl = this.KeyEncryptionKeyUrl,
                            KeyEncryptionVaultId = this.KeyEncryptionVaultId,
                            AzureToAzureDiskReplicationConfiguration = this.AzureToAzureDiskReplicationConfiguration
                        };
                        break;
                }
                this.WriteObject(protectedItemConfig);
            }
        }
    }
}

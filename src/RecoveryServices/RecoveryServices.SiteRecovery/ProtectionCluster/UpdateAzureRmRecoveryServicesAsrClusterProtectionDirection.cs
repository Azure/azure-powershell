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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Updates the replication direction for the specified replication protection cluster.
    ///     Used to re-protect/reverse replicate a failed over replicated items in protection cluster.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterProtectionDirection", DefaultParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails, SupportsShouldProcess = true)]
    [Alias("Update-ASRClusterProtectionDirection")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrClusterProtection : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch Parameter to specifying that the replication direction being updated for replicated 
        ///    Azure virtual machines between two Azure regions.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails, Mandatory = true)]

        public SwitchParameter AzureToAzure { get; set; }

        /// <summary>
        ///     Gets or sets Protection container mapping to be used for replication.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     Gets or sets the list of replication protected Items.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true,
             HelpMessage = "Specifies the list of all replication protected items available in protection cluster.")]
        [ValidateNotNullOrEmpty]
        public ASRAzureToAzureReplicationProtectedItemConfig[] AzureToAzureReplicationProtectedItemConfig { get; set; }

        /// <summary>
        ///     Gets or sets replication protection cluster.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails, 
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectionCluster ReplicationProtectionCluster { get; set; }

        /// <summary>
        /// Gets or sets recovery resourceGroup id for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets recovery availability setId for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        /// Gets or sets recovery proximity placement group Id for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        /// Gets or sets virtual machine scale set Id for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryVirtualMachineScaleSetId { get; set; }

        /// <summary>
        /// Gets or sets capacity reservation group Id for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails)]
        [ValidateNotNullOrEmpty]
        public string RecoveryCapacityReservationGroupId { get; set; }

        /// <summary>
        /// Gets or sets BootDiagnosticStorageAccountId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails)]
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the recovery cloud service to failover this virtual machine to.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails)]
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        ///     Gets or sets azure storage account ID to store the replication log of VMs.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails,
            HelpMessage = "Specifies the disk encryption secret key vault ID(Azure disk encryption) to be used be recovery VM after failover.")]
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        [Parameter
            (ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails,
            HelpMessage = "Specifies the disk encryption secret URL(Azure disk encryption) to be used be recovery VM after failover.")]
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
       [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails,
            HelpMessage = "Specifies the disk encryption secret key URL(Azure disk encryption) to be used be recovery VM after failover.")]
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithoutProtectedItemDetails,
            HelpMessage = "Specifies the disk encryption secret key vault ID(Azure disk encryption) to be used be recovery VM after failover.")]
        public string KeyEncryptionVaultId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Replication protection cluster",
                "Update direction"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.AzureToAzure:
                    case ASRParameterSets.AzureToAzureWithoutProtectedItemDetails:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.A2ARPCReprotect();
                        break;
                }
            }
        }

        /// <summary>
        ///     Switches protection from one container to another or one replication provider to another.
        /// </summary>
        private void A2ARPCReprotect()
        {
            var switchClusterProtectionInputProperties = new SwitchClusterProtectionInputProperties()
            {
                ReplicationProtectionClusterName = this.ReplicationProtectionCluster.Name,
                ProviderSpecificDetails = new SwitchClusterProtectionProviderSpecificInput()
            };
            var fabricFriendlyName =
                        this.ReplicationProtectionCluster.PrimaryFabricFriendlyName;
            SwitchClusterProtectionInput input = new SwitchClusterProtectionInput()
            {
                Properties = switchClusterProtectionInputProperties
            };

            if (0 == string.Compare(
                this.ReplicationProtectionCluster.ReplicationProvider,
                Constants.A2A,
                StringComparison.OrdinalIgnoreCase))
            {
                var a2aSwitchClusterInput = new A2ASwitchClusterProtectionInput()
                {
                    PolicyId = this.ProtectionContainerMapping.PolicyId,
                    RecoveryContainerId =
                        this.ProtectionContainerMapping.TargetProtectionContainerId,
                    ProtectedItemsDetail = new List<A2AProtectedItemDetail>()
                };

                // Fetch the latest Protection cluster object
                var replicationProtectionClusterResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectionCluster(
                        this.fabricName,
                        this.protectionContainerName,
                        this.ReplicationProtectionCluster.Name);

                if (fabricFriendlyName != this.ProtectionContainerMapping.TargetFabricFriendlyName)
                {
                    throw new ArgumentException(
                        string.Format(Resources.InvalidSwitchParamRPCAndProtectionContainerMapping,
                        fabricFriendlyName,
                        this.ProtectionContainerMapping.TargetFabricFriendlyName));
                }

                PopulateProtectedItemDetails(a2aSwitchClusterInput, replicationProtectionClusterResponse);

                input.Properties.ProviderSpecificDetails = a2aSwitchClusterInput;
            }

            var response =
                RecoveryServicesClient.StartSwitchClusterProtection(
                this.fabricName,
                this.protectionContainerName,
                input);

            var jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Populate protected item details.
        /// </summary>
        private void PopulateProtectedItemDetails(
            A2ASwitchClusterProtectionInput a2aSwitchClusterInput,
            ReplicationProtectionCluster replicationProtectionClusterResponse)
        {
            var clusterProtectedItemIds = replicationProtectionClusterResponse.Properties.ClusterProtectedItemIds;
            if (clusterProtectedItemIds == null || clusterProtectedItemIds.Count == 0)
            {
                throw new InvalidOperationException(Resources.InvalidClusterInputWithoutProtectedItems);
            }

            if (this.AzureToAzureReplicationProtectedItemConfig == null ||
                this.AzureToAzureReplicationProtectedItemConfig.Length == 0)
            {
                foreach(string protectedItem in clusterProtectedItemIds)
                {
                    var replicationProtectedItemResponse = 
                        RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                            this.fabricName,
                            this.protectionContainerName,
                            Utilities.GetValueFromArmId(
                                protectedItem,
                            ARMResourceTypeConstants.ReplicationProtectedItems));
                    List<A2AVmManagedDiskInputDetails> diskInput = PopulateManagedDiskDetails(
                        replicationProtectedItemResponse);

                    a2aSwitchClusterInput.ProtectedItemsDetail.Add(new A2AProtectedItemDetail
                    {
                        ReplicationProtectedItemName = replicationProtectedItemResponse.Name,
                        RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                        RecoveryAvailabilitySetId = this.RecoveryAvailabilitySetId,
                        RecoveryAvailabilityZone = this.RecoveryAvailabilityZone,
                        RecoveryBootDiagStorageAccountId = this.RecoveryBootDiagStorageAccountId,
                        RecoveryCapacityReservationGroupId = this.RecoveryCapacityReservationGroupId,
                        RecoveryProximityPlacementGroupId = this.RecoveryProximityPlacementGroupId,
                        RecoveryVirtualMachineScaleSetId = this.RecoveryVirtualMachineScaleSetId,
                        VMManagedDisks = diskInput,
                        DiskEncryptionInfo = this.A2AEncryptionDetails()
                    });
                }
            }
            else
            {
                // List of RPI config given in input.
                List<string> rpiInput = new List<string>(
                    Array.ConvertAll(
                    this.AzureToAzureReplicationProtectedItemConfig,
                    obj => obj.ReplicationProtectedItemName));

                // List of RPIs present in cluster.
                var rpisInCluster = new HashSet<string>(
                    clusterProtectedItemIds.Select(
                        node => Utilities.GetValueFromArmId(
                            node,
                            ARMResourceTypeConstants.ReplicationProtectedItems)),
                    StringComparer.OrdinalIgnoreCase);

                bool allNodesNotPresentInCluster = false;

                // Checking if any RPI existing in cluster is not present RPI input list.
                allNodesNotPresentInCluster = rpisInCluster
                    .Where(rpi => !rpiInput.Contains(rpi)).Any();

                if (!allNodesNotPresentInCluster)
                {
                    foreach (ASRAzureToAzureReplicationProtectedItemConfig rpi in this.AzureToAzureReplicationProtectedItemConfig)
                    {
                        List<A2AVmManagedDiskInputDetails> diskInput = new List<A2AVmManagedDiskInputDetails>();
                        if (rpi.AzureToAzureDiskReplicationConfiguration != null
                            && rpi.AzureToAzureDiskReplicationConfiguration.Length > 0)
                        {
                            foreach (ASRAzuretoAzureDiskReplicationConfig disk in rpi.AzureToAzureDiskReplicationConfiguration)
                            {
                                diskInput.Add(new A2AVmManagedDiskInputDetails
                                {
                                    DiskId = disk.DiskId,
                                    RecoveryResourceGroupId = disk.RecoveryResourceGroupId,
                                    RecoveryReplicaDiskAccountType = disk.RecoveryReplicaDiskAccountType,
                                    RecoveryTargetDiskAccountType = disk.RecoveryTargetDiskAccountType,
                                    PrimaryStagingAzureStorageAccountId = disk.LogStorageAccountId,
                                    RecoveryDiskEncryptionSetId = disk.RecoveryDiskEncryptionSetId,
                                    DiskEncryptionInfo = Utilities.A2AEncryptionDetails(
                                    disk.DiskEncryptionSecretUrl,
                                    disk.DiskEncryptionVaultId,
                                    disk.KeyEncryptionKeyUrl,
                                    disk.KeyEncryptionVaultId)
                                });
                            }
                        }
                        else
                        {
                            var replicationProtectedItemResponse =
                                RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                                    this.fabricName,
                                    this.protectionContainerName,
                                    rpi.ReplicationProtectedItemName);
                            diskInput = PopulateManagedDiskDetails(replicationProtectedItemResponse);
                        }

                        a2aSwitchClusterInput.ProtectedItemsDetail.Add(new A2AProtectedItemDetail
                        {
                            ReplicationProtectedItemName = rpi.ReplicationProtectedItemName,
                            RecoveryResourceGroupId = rpi.RecoveryResourceGroupId,
                            RecoveryAvailabilitySetId = rpi.RecoveryAvailabilitySetId,
                            RecoveryAvailabilityZone = rpi.RecoveryAvailabilityZone,
                            RecoveryBootDiagStorageAccountId = rpi.RecoveryBootDiagStorageAccountId,
                            RecoveryCapacityReservationGroupId = rpi.RecoveryCapacityReservationGroupId,
                            RecoveryProximityPlacementGroupId = rpi.RecoveryProximityPlacementGroupId,
                            RecoveryVirtualMachineScaleSetId = rpi.RecoveryVirtualMachineScaleSetId,
                            VMManagedDisks = diskInput,
                            DiskEncryptionInfo = Utilities.A2AEncryptionDetails(
                                rpi.DiskEncryptionSecretUrl,
                                rpi.DiskEncryptionVaultId,
                                rpi.KeyEncryptionKeyUrl,
                                rpi.KeyEncryptionVaultId)
                        });
                    }
                }
                else
                {
                    // If not all RPIs present in cluster are passed as input during reprotect.
                    throw new InvalidOperationException(Resources.InvalidInputForAllNodesInCluster);
                }
            }
        }

        /// <summary>
        ///     Creating DiskEncryptionInfo for A2A encrypted Vm..
        /// </summary>
        private DiskEncryptionInfo A2AEncryptionDetails()
        {
            // Checking if any encryption data is present then the only creating DiskEncryptionInfo.
            if (this.IsParameterBound(c => c.DiskEncryptionSecretUrl) ||
                this.IsParameterBound(c => c.DiskEncryptionVaultId) ||
                this.IsParameterBound(c => c.KeyEncryptionKeyUrl) ||
                this.IsParameterBound(c => c.KeyEncryptionVaultId))
            {
                DiskEncryptionInfo diskEncryptionInfo = new DiskEncryptionInfo();
                // BEK DATA is present
                if (this.IsParameterBound(c => c.DiskEncryptionSecretUrl) && this.IsParameterBound(c => c.DiskEncryptionVaultId))
                {
                    diskEncryptionInfo.DiskEncryptionKeyInfo = new DiskEncryptionKeyInfo(this.DiskEncryptionSecretUrl, this.DiskEncryptionVaultId);
                    // KEK Data is present in pair.
                    if (this.IsParameterBound(c => c.KeyEncryptionKeyUrl) && this.IsParameterBound(c => c.KeyEncryptionVaultId))
                    {
                        diskEncryptionInfo.KeyEncryptionKeyInfo = new KeyEncryptionKeyInfo(this.KeyEncryptionKeyUrl, this.KeyEncryptionVaultId);
                    }
                }
                else
                {
                    throw new Exception("Provide Disk DiskEncryptionSecretUrl and DiskEncryptionVaultId.");
                }
                return diskEncryptionInfo;
            }
            return null;
        }

        /// <summary>
        ///     Populate managed disk details.
        /// </summary>
        private List<A2AVmManagedDiskInputDetails> PopulateManagedDiskDetails(ReplicationProtectedItem rpi)
        {
            var a2aReplicationDetails = (A2AReplicationDetails)rpi.Properties.ProviderSpecificDetails;
            var vmName = a2aReplicationDetails.RecoveryAzureVMName;
            var vmRg = Utilities.GetValueFromArmId(
                a2aReplicationDetails.RecoveryAzureResourceGroupId,
                ARMResourceTypeConstants.ResourceGroups);
            var subscriptionId = Utilities.GetValueFromArmId(a2aReplicationDetails.RecoveryAzureResourceGroupId, ARMResourceTypeConstants.Subscriptions);
            var tempSubscriptionId = this.ComputeManagementClient.GetComputeManagementClient.SubscriptionId;
            this.ComputeManagementClient.GetComputeManagementClient.SubscriptionId = subscriptionId;
            var virtualMachine = this.ComputeManagementClient.GetComputeManagementClient.
                VirtualMachines.GetWithHttpMessagesAsync(vmRg, vmName).GetAwaiter().GetResult().Body;
            this.ComputeManagementClient.GetComputeManagementClient.SubscriptionId = tempSubscriptionId;

            List<A2AVmManagedDiskInputDetails> diskInput = new List<A2AVmManagedDiskInputDetails>();
            // Passing all managedDisk data if no details is passed.
            var osDisk = virtualMachine.StorageProfile.OsDisk;
            diskInput.Add(new A2AVmManagedDiskInputDetails
            {
                DiskId = osDisk.ManagedDisk.Id,
                RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                PrimaryStagingAzureStorageAccountId = this.LogStorageAccountId,
                RecoveryReplicaDiskAccountType = osDisk.ManagedDisk.StorageAccountType,
                RecoveryTargetDiskAccountType = osDisk.ManagedDisk.StorageAccountType
            });

            if (virtualMachine.StorageProfile.DataDisks != null)
            {
                foreach (var dataDisk in virtualMachine.StorageProfile.DataDisks)
                {
                    diskInput.Add(new A2AVmManagedDiskInputDetails
                    {
                        DiskId = dataDisk.ManagedDisk.Id,
                        RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                        PrimaryStagingAzureStorageAccountId = this.LogStorageAccountId,
                        RecoveryReplicaDiskAccountType = dataDisk.ManagedDisk.StorageAccountType,
                        RecoveryTargetDiskAccountType = dataDisk.ManagedDisk.StorageAccountType
                    });
                }
            }
            return diskInput;
        }

        #region local parameters

        /// <summary>
        ///     Gets or sets name of the fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Gets or sets name of the protection container.
        /// </summary>
        private string protectionContainerName;

        #endregion
    }
}

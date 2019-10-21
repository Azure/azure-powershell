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
    ///     Sets recovery properties such as target network and virtual machine size for the specified replication protected item.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectedItem", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Set-ASRReplicationProtectedItem")]
    [OutputType(typeof(ASRJob))]
    public class SetAzureRmRecoveryServicesAsrReplicationProtectedItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the input object to the cmdlet: The ASR replication protected item object corresponding to the replication protected item to update.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicationProtectedItem")]
        public ASRReplicationProtectedItem InputObject { get; set; }

        /// <summary>
        ///     Gets or sets the name of the recovery virtual machine that will be created on failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the recovery virtual machine size.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets the NIC of the virtual machine for which this cmdlet sets the recovery network property.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string UpdateNic { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the Azure virtual network to which the protected item should be failed over.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the selected source nic Id (Nic reduction).
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string PrimaryNic { get; set; }

        /// <summary>
        /// Gets or sets resource ID of the recovery cloud service to failover this virtual machine to.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryCloudServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the subnet on the recovery Azure virtual network to which
        ///     this NIC of the protected item should be connected to on failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address that should be assigned to primary NIC on recovery.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the network interface card (NIC) properties set by user or set by default.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NotSelected,
            Constants.SelectedByUser)]
        public string NicSelectionType { get; set; }

        /// <summary>
        ///     Gets or sets i=ID of the Azure resource group in the recovery region in which 
        ///     the protected item will be recovered on failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets LicenseType for
        ///     HUB https://azure.microsoft.com/en-in/pricing/hybrid-use-benefit/
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NoLicenseType,
            Constants.LicenseTypeWindowsServer)]
        public string LicenseType { get; set; }

        /// <summary>
        ///     Gets or sets the availability set for replication protected item after failover.
        /// </summary>
        [Parameter]
        public string RecoveryAvailabilitySet { get; set; }

        /// <summary>
        ///     Gets or sets the availability set for replication protected item after failover.
        /// </summary>
        [Parameter]
        public SwitchParameter EnableAcceleratedNetworkingOnRecovery { get; set; }

        /// <summary>
        ///     Gets or sets the recovery boot diagnostics storageAccountId for replication protected item after failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        ///    Gets or sets  the list of virtual machine disks to replicated 
        ///    and the cache storage account and recovery storage account to be used to replicate the disk.
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter]
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureUpdateReplicationConfiguration { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionVaultId { get; set; }

        /// <summary>
        ///     Gets or sets if the Azure virtual machine that is created on failover should use managed disks.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.True,
            Constants.False)]
        public string UseManagedDisk { get; set; }

        /// <summary>
        ///     Gets or sets the id of the public IP address resource associated with the NIC.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryPublicIPAddressId { get; set; }

        /// <summary>
        ///     Gets or sets the id of the NSG associated with the NIC.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkSecurityGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the target backend address pools for the NIC.
        /// </summary>
        [Parameter]
        public string[] RecoveryLBBackendAddressPoolId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.FriendlyName,
                VerbsCommon.Set))
            {
                var replicationProtectedItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.InputObject.Name);

                var provider = replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                // Check for Replication Provider type HyperVReplicaAzure/InMageAzureV2/A2A
                if (!(provider is HyperVReplicaAzureReplicationDetails) &&
                    !(provider is InMageAzureV2ReplicationDetails) &&
                    !(provider is A2AReplicationDetails))
                {
                    this.WriteWarning(
                        Resources.UnsupportedReplicationProvidedForUpdateVmProperties);
                    return;
                }

                // Check for at least one option
                if (string.IsNullOrEmpty(this.Name) &&
                    string.IsNullOrEmpty(this.Size) &&
                    string.IsNullOrEmpty(this.UpdateNic) &&
                    string.IsNullOrEmpty(this.RecoveryNetworkId) &&
                    string.IsNullOrEmpty(this.PrimaryNic) &&
                    this.UseManagedDisk == null &&
                    this.IsParameterBound(c => c.RecoveryAvailabilitySet) &&
                    string.IsNullOrEmpty(this.RecoveryCloudServiceId) &&
                    string.IsNullOrEmpty(this.RecoveryResourceGroupId) &&
                    string.IsNullOrEmpty(this.LicenseType) &&
                    string.IsNullOrEmpty(this.RecoveryBootDiagStorageAccountId) &&
                    this.AzureToAzureUpdateReplicationConfiguration == null)
                {
                    this.WriteWarning(Resources.ArgumentsMissingForUpdateVmProperties);
                    return;
                }

                // Both primary & recovery inputs should be present
                if (string.IsNullOrEmpty(this.UpdateNic) ^
                    string.IsNullOrEmpty(this.RecoveryNetworkId))
                {
                    this.WriteWarning(Resources.NetworkArgumentsMissingForUpdateVmProperties);
                    return;
                }

                // NSG, LB and PIP only for A2A provider.
                if ((!string.IsNullOrEmpty(RecoveryNetworkSecurityGroupId) ||
                    !string.IsNullOrEmpty(RecoveryPublicIPAddressId) ||
                    RecoveryLBBackendAddressPoolId != null &&
                    RecoveryLBBackendAddressPoolId.Length > 0) &&
                    !(provider is A2AReplicationDetails))
                {
                    this.WriteWarning(Resources.NetworkingResourcesInDRNotSupportedForClassicVms);
                    return;
                }

                var vmName = this.Name;
                var vmSize = this.Size;
                var vmRecoveryNetworkId = this.RecoveryNetworkId;
                var licenseType = this.LicenseType;
                var recoveryResourceGroupId = this.RecoveryResourceGroupId;
                var recoveryCloudServiceId = this.RecoveryCloudServiceId;
                var useManagedDisk = this.UseManagedDisk;
                var availabilitySetId = this.RecoveryAvailabilitySet;
                var primaryNic = this.PrimaryNic;
                var vMNicInputDetailsList = new List<VMNicInputDetails>();
                var providerSpecificInput = new UpdateReplicationProtectedItemProviderInput();

                if (provider is HyperVReplicaAzureReplicationDetails)
                {
                    var providerSpecificDetails =
                        (HyperVReplicaAzureReplicationDetails)replicationProtectedItemResponse
                            .Properties.ProviderSpecificDetails;

                    if (string.IsNullOrEmpty(this.Name))
                    {
                        vmName = providerSpecificDetails.RecoveryAzureVmName;
                    }

                    if (string.IsNullOrEmpty(this.Size))
                    {
                        vmSize = providerSpecificDetails.RecoveryAzureVMSize;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryNetworkId))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails
                            .SelectedRecoveryAzureNetworkId;
                    }

                    if (string.IsNullOrEmpty(this.LicenseType))
                    {
                        licenseType = providerSpecificDetails.LicenseType;
                    }

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet
                        : providerSpecificDetails.RecoveryAvailabilitySetId;

                    if (string.IsNullOrEmpty(this.UseManagedDisk))
                    {
                        useManagedDisk = providerSpecificDetails.UseManagedDisks;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryResourceGroupId))
                    {
                        recoveryResourceGroupId =
                            providerSpecificDetails.RecoveryAzureResourceGroupId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.PrimaryNic)))
                    {
                        primaryNic = providerSpecificDetails.SelectedSourceNicId;
                    }

                    var deploymentType = Utilities.GetValueFromArmId(
                        providerSpecificDetails.RecoveryAzureStorageAccount,
                        ARMResourceTypeConstants.Providers);
                    if (deploymentType.ToLower()
                        .Contains(Constants.Classic.ToLower()))
                    {
                        providerSpecificInput =
                            new HyperVReplicaAzureUpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = recoveryResourceGroupId,
                                RecoveryAzureV2ResourceGroupId = null
                            };
                    }
                    else
                    {
                        providerSpecificInput =
                            new HyperVReplicaAzureUpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = null,
                                RecoveryAzureV2ResourceGroupId = recoveryResourceGroupId,
                                UseManagedDisks = useManagedDisk
                            };
                    }

                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VmNics);
                }
                else if (provider is InMageAzureV2ReplicationDetails)
                {
                    var providerSpecificDetails =
                        (InMageAzureV2ReplicationDetails)replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                    if (string.IsNullOrEmpty(this.Name))
                    {
                        vmName = providerSpecificDetails.RecoveryAzureVMName;
                    }

                    if (string.IsNullOrEmpty(this.Size))
                    {
                        vmSize = providerSpecificDetails.RecoveryAzureVMSize;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryNetworkId))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails.SelectedRecoveryAzureNetworkId;
                    }

                    if (string.IsNullOrEmpty(this.LicenseType))
                    {
                        licenseType = providerSpecificDetails.LicenseType;
                    }

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet : providerSpecificDetails.RecoveryAvailabilitySetId;

                    if (string.IsNullOrEmpty(this.UseManagedDisk))
                    {
                        useManagedDisk = providerSpecificDetails.UseManagedDisks;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryResourceGroupId))
                    {
                        recoveryResourceGroupId = providerSpecificDetails.RecoveryAzureResourceGroupId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.PrimaryNic)))
                    {
                        primaryNic = providerSpecificDetails.SelectedSourceNicId;
                    }

                    var deploymentType = Utilities.GetValueFromArmId(
                        providerSpecificDetails.TargetVmId,
                        ARMResourceTypeConstants.Providers);
                    if (deploymentType.ToLower()
                        .Contains(Constants.ClassicCompute.ToLower()))
                    {
                        providerSpecificInput =
                            new InMageAzureV2UpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = recoveryResourceGroupId,
                                RecoveryAzureV2ResourceGroupId = null
                            };
                    }
                    else
                    {
                        providerSpecificInput =
                            new InMageAzureV2UpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = null,
                                RecoveryAzureV2ResourceGroupId = recoveryResourceGroupId,
                                UseManagedDisks = useManagedDisk
                            };
                    }
                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VmNics);
                }
                else if (provider is A2AReplicationDetails)
                {
                    A2AReplicationDetails providerSpecificDetails = (A2AReplicationDetails)replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryResourceGroupId)))
                    {
                        recoveryResourceGroupId =
                            providerSpecificDetails.RecoveryAzureResourceGroupId;
                    }

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet
                        : providerSpecificDetails.RecoveryAvailabilitySet;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                             Utilities.GetMemberName(() => this.RecoveryNetworkId)))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails.SelectedRecoveryAzureNetworkId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryCloudServiceId)))
                    {
                        recoveryCloudServiceId =
                            providerSpecificDetails.RecoveryCloudService;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryBootDiagStorageAccountId)))
                    {
                        this.RecoveryBootDiagStorageAccountId = providerSpecificDetails.RecoveryBootDiagStorageAccountId;
                    }

                    List<A2AVmManagedDiskUpdateDetails> managedDiskUpdateDetails = null;

                    // ManagedDisk case
                    if (this.AzureToAzureUpdateReplicationConfiguration == null && providerSpecificDetails.ProtectedManagedDisks != null)
                    {
                        managedDiskUpdateDetails = new List<A2AVmManagedDiskUpdateDetails>();
                        foreach (var managedDisk in providerSpecificDetails.ProtectedManagedDisks)
                        {
                            managedDiskUpdateDetails.Add(
                                new A2AVmManagedDiskUpdateDetails(
                                    managedDisk.DiskId,
                                    managedDisk.RecoveryTargetDiskAccountType,
                                    managedDisk.RecoveryReplicaDiskAccountType));
                        }
                    }
                    else if (this.AzureToAzureUpdateReplicationConfiguration != null && this.AzureToAzureUpdateReplicationConfiguration[0].IsManagedDisk)
                    {
                        managedDiskUpdateDetails = new List<A2AVmManagedDiskUpdateDetails>();
                        foreach (var managedDisk in this.AzureToAzureUpdateReplicationConfiguration)
                        {
                            managedDiskUpdateDetails.Add(
                                new A2AVmManagedDiskUpdateDetails(
                                    managedDisk.DiskId,
                                    managedDisk.RecoveryTargetDiskAccountType,
                                    managedDisk.RecoveryReplicaDiskAccountType));
                        }
                    }

                    providerSpecificInput = new A2AUpdateReplicationProtectedItemInput()
                    {
                        RecoveryCloudServiceId = this.RecoveryCloudServiceId,
                        RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                        RecoveryBootDiagStorageAccountId = this.RecoveryBootDiagStorageAccountId,
                        ManagedDiskUpdateDetails = managedDiskUpdateDetails,
                        DiskEncryptionInfo = this.A2AEncryptionDetails(provider)
                    };

                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VmNics);
                }

                var updateReplicationProtectedItemInputProperties =
                    new UpdateReplicationProtectedItemInputProperties
                    {
                        RecoveryAzureVMName = vmName,
                        RecoveryAzureVMSize = vmSize,
                        SelectedRecoveryAzureNetworkId = vmRecoveryNetworkId,
                        SelectedSourceNicId = primaryNic,
                        VmNics = vMNicInputDetailsList,
                        LicenseType =
                            licenseType ==
                            Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                .NoLicenseType.ToString()
                                ? Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                    .NoLicenseType
                                : Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                    .WindowsServer,
                        RecoveryAvailabilitySetId = availabilitySetId,
                        ProviderSpecificDetails = providerSpecificInput
                    };

                if (provider is HyperVReplicaAzureReplicationDetails || provider is InMageAzureV2ReplicationDetails)
                {
                    updateReplicationProtectedItemInputProperties.SelectedSourceNicId = primaryNic;
                }
                var input = new UpdateReplicationProtectedItemInput
                {
                    Properties = updateReplicationProtectedItemInputProperties
                };

                var response = this.RecoveryServicesClient.UpdateVmProperties(
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.InputObject.Name,
                    input);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }

        private List<VMNicInputDetails> getNicListToUpdate(IList<VMNicDetails> vmNicList)
        {
            var vMNicInputDetailsList = new List<VMNicInputDetails>();
            // Weather to track NIC found to be updated. IF primary NIC is not or empty no need to update.
            var nicFoundToBeUpdated = string.IsNullOrEmpty(this.UpdateNic);

            if (vmNicList != null)
            {
                foreach (var nDetails in vmNicList)
                {
                    var vMNicInputDetails = new VMNicInputDetails();
                    if (!string.IsNullOrEmpty(this.UpdateNic)
                        && string.Compare(nDetails.NicId, this.UpdateNic, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        vMNicInputDetails.NicId = this.UpdateNic;
                        vMNicInputDetails.RecoveryVMSubnetName = this.RecoveryNicSubnetName;
                        vMNicInputDetails.ReplicaNicStaticIPAddress =
                            this.RecoveryNicStaticIPAddress;
                        vMNicInputDetails.SelectionType =
                            string.IsNullOrEmpty(this.NicSelectionType)
                                ? Constants.SelectedByUser : this.NicSelectionType;
                        vMNicInputDetails.RecoveryLBBackendAddressPoolIds =
                            this.RecoveryLBBackendAddressPoolId?.ToList();
                        vMNicInputDetails.RecoveryPublicIpAddressId =
                            this.RecoveryPublicIPAddressId;
                        vMNicInputDetails.RecoveryNetworkSecurityGroupId =
                            this.RecoveryNetworkSecurityGroupId;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                        // NicId  matched for update
                        nicFoundToBeUpdated = true;

                        if (this.MyInvocation.BoundParameters.ContainsKey(
                           Utilities.GetMemberName(() => this.EnableAcceleratedNetworkingOnRecovery)))
                        {
                            vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery = true;
                        }
                        else
                        {
                            vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery = false;
                        }
                    }
                    else
                    {
                        vMNicInputDetails.NicId = nDetails.NicId;
                        vMNicInputDetails.RecoveryVMSubnetName = nDetails.RecoveryVMSubnetName;
                        vMNicInputDetails.ReplicaNicStaticIPAddress =
                            nDetails.ReplicaNicStaticIPAddress;
                        vMNicInputDetails.SelectionType = nDetails.SelectionType;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                        vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery = nDetails.EnableAcceleratedNetworkingOnRecovery;
                        vMNicInputDetails.RecoveryLBBackendAddressPoolIds =
                            nDetails.RecoveryLBBackendAddressPoolIds;
                        vMNicInputDetails.RecoveryPublicIpAddressId =
                            nDetails.RecoveryPublicIpAddressId;
                        vMNicInputDetails.RecoveryNetworkSecurityGroupId =
                            nDetails.RecoveryNetworkSecurityGroupId;
                    }
                }
            }

            if (!nicFoundToBeUpdated)
            {
                throw new PSInvalidOperationException(Resources.NicNotFoundInVMForUpdateVmProperties);
            }
            return vMNicInputDetailsList;
        }

        /*
         * Creating DiskEncryptionInfo for A2A provider.
         */
        private DiskEncryptionInfo A2AEncryptionDetails(ReplicationProviderSpecificSettings provider)
        {
            // Checking if any encryption data is present then the only creating DiskEncryptionInfo.
            if (this.IsParameterBound(c => c.DiskEncryptionSecretUrl) ||
                this.IsParameterBound(c => c.DiskEncryptionVaultId) ||
                this.IsParameterBound(c => c.KeyEncryptionKeyUrl) ||
                this.IsParameterBound(c => c.KeyEncryptionVaultId))
            {
                // Non A2A scenario
                if (!(provider is A2AReplicationDetails))
                {
                    throw new Exception(
                        "DiskEncryptionSecretUrl,DiskEncryptionVaultId,KeyEncryptionKeyUrl,KeyEncryptionVaultId " +
                        "is used for updating Azure to Azure replication");
                }

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
    }
}

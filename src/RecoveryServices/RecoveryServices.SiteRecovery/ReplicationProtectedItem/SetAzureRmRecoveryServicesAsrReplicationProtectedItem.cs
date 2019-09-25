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
        public string PrimaryNic { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the Azure virtual network to which the protected item should be failed over.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkId { get; set; }

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
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilitySet { get; set; }

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
        ///     Gets or sets if the Azure virtual machine that is created on failover should use managed disks.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.True,
            Constants.False)]
        public string UseManagedDisk { get; set; }

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
                    string.IsNullOrEmpty(this.PrimaryNic) &&
                    string.IsNullOrEmpty(this.RecoveryNetworkId) &&
                    this.UseManagedDisk == null &&
                    this.IsParameterBound(c=>c.RecoveryAvailabilitySet) &&
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
                if (string.IsNullOrEmpty(this.PrimaryNic) ^
                    string.IsNullOrEmpty(this.RecoveryNetworkId))
                {
                    this.WriteWarning(Resources.NetworkArgumentsMissingForUpdateVmProperties);
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
                        (InMageAzureV2ReplicationDetails)replicationProtectedItemResponse.Properties
                            .ProviderSpecificDetails;

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

                    var deploymentType = Utilities.GetValueFromArmId(
                        providerSpecificDetails.RecoveryAzureStorageAccount,
                        ARMResourceTypeConstants.Providers);
                    if (deploymentType.ToLower()
                        .Contains(Constants.Classic.ToLower()))
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
                        ManagedDiskUpdateDetails = managedDiskUpdateDetails
                    };

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryNetworkId)))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails.SelectedRecoveryAzureNetworkId;
                    }

                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VmNics);
                }

                var updateReplicationProtectedItemInputProperties =
                    new UpdateReplicationProtectedItemInputProperties
                    {
                        RecoveryAzureVMName = vmName,
                        RecoveryAzureVMSize = vmSize,
                        SelectedRecoveryAzureNetworkId = vmRecoveryNetworkId,
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
            // Weather to track Nic found to be updated. IF primary nic is not or empty no need to update.
            var nicFoundToBeUpdated = string.IsNullOrEmpty(this.PrimaryNic);

            if (vmNicList != null)
            {
                foreach (var nDetails in vmNicList)
                {
                    var vMNicInputDetails = new VMNicInputDetails();
                    if (!string.IsNullOrEmpty(this.PrimaryNic)
                        && string.Compare(nDetails.NicId, this.PrimaryNic, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        vMNicInputDetails.NicId = this.PrimaryNic;
                        vMNicInputDetails.RecoveryVMSubnetName = this.RecoveryNicSubnetName;
                        vMNicInputDetails.ReplicaNicStaticIPAddress =
                            this.RecoveryNicStaticIPAddress;
                        vMNicInputDetails.SelectionType =
                            string.IsNullOrEmpty(this.NicSelectionType)
                                ? Constants.SelectedByUser : this.NicSelectionType;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                        // NicId  matched for updation
                        nicFoundToBeUpdated = true;
                    }
                    else
                    {
                        vMNicInputDetails.NicId = nDetails.NicId;
                        vMNicInputDetails.RecoveryVMSubnetName = nDetails.RecoveryVMSubnetName;
                        vMNicInputDetails.ReplicaNicStaticIPAddress =
                            nDetails.ReplicaNicStaticIPAddress;
                        vMNicInputDetails.SelectionType = nDetails.SelectionType;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                    }
                }
            }

            if (!nicFoundToBeUpdated)
            {
                throw new PSInvalidOperationException(Resources.NicNotFoundInVMForUpdateVmProperties);
            }
            return vMNicInputDetailsList;
        }
    }
}

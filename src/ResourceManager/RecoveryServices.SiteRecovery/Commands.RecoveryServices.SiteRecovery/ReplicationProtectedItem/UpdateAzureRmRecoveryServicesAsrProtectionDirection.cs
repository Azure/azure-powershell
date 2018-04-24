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
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Updates the replication direction for the specified replication protected item or recovery plan.
    ///     Used to re-protect/reverse replicate a failed over replicated item or recovery plan.
    /// </summary>
    [Cmdlet(
        VerbsData.Update,
        "AzureRmRecoveryServicesAsrProtectionDirection",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject,
        SupportsShouldProcess = true)]
    [Alias("Update-ASRProtectionDirection")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrProtection : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch Paramter to update replication direction from Azure to Vmware.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.AzureToVMware,
            Mandatory = true)]
        public SwitchParameter AzureToVMware { get; set; }

        /// <summary>
        ///    Switch Paramter to update replication direction from VMware to Azure.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.VMwareToAzure,
           Mandatory = true)]
        public SwitchParameter VMwareToAzure { get; set; }

        /// <summary>
        ///    Switch Paramter to reprotect a Hyper-V virtual machine after failback..
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.HyperVToAzure,
            Mandatory = true)]
        public SwitchParameter HyperVToAzure { get; set; }

        /// <summary>
        ///     Switch Paramter to update replication direction 
        ///     for a failed over Hyper-V virtual machine that is protected between two VMM managed Hyper-V sites.
        /// </summary>
        [Parameter(
            Position = 0,
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        public SwitchParameter VmmToVmm { get; set; }

        /// <summary>
        ///    Switch Paramter to specifying that the replication direction being updated for replicated 
        ///    Azure virtual machines between two Azure regions.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount,
            Mandatory = true)]
        public SwitchParameter AzureToAzure { get; set; }

        /// <summary>
        ///     Gets or sets the run as account to be used to push install the Mobility service if needed.
        ///     Must be one from the list of run as accounts in the ASR fabric.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        ///     Gets or sets DataStore of MT server for the on-premise vmware machine.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRDataStore DataStore { get; set; }

        /// <summary>
        ///     Gets or sets master target server details..
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [ValidateNotNullOrEmpty]
        public ASRMasterTargetServer MasterTarget { get; set; }

        /// <summary>
        ///     Gets or sets process server to be used for replication..
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProcessServer ProcessServer { get; set; }

        /// <summary>
        ///     Gets or sets Protection container mapping to be used for replication.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     Gets or sets azure storage account ID to store the replication log of VMs.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets recovery azure storage accountId for replication.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.HyperVToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets the list of virtual machine disks to replicated 
        ///     and the log storage account and recovery storage account to be used to replicate the disk.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureDiskReplicationConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets recovery plan object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets replication protected item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToVMware,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets direction to be used for the update operation post a failover.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.EnterpriseToEnterprise,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToVMware,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.HyperVToAzure,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true)]
        [Parameter(
             ParameterSetName = ASRParameterSets.ByRPObject,
             Mandatory = true)]
        [Parameter(
             ParameterSetName = ASRParameterSets.ByPEObject,
             Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }


        /// <summary>
        /// Gets or sets recovery resourceGroup id for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount)]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets recovery cloud serviceId for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount)]
        [ValidateNotNullOrEmpty]
        public string RecoveryCloudServiceId { get; set; }

        /// <summary>
        /// Gets or sets recovery availability setId for protected Vm.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure)]
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzureWithMultipleStorageAccount)]
        [ValidateNotNullOrEmpty]
        public string RecoveryAvailabilitySetId { get; set; }

        /// <summary>
        ///     Gets or sets retention Volume on the master target server to be used.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToVMware, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRetentionVolume RetentionVolume { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Protected item or Recovery plan",
                "Update protection direction"))
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPIObject:
                    case ASRParameterSets.AzureToVMware:
                    case ASRParameterSets.VMwareToAzure:
                    case ASRParameterSets.HyperVToAzure:
                    case ASRParameterSets.EnterpriseToEnterprise:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.SetRPIReprotect();
                        break;
                    case ASRParameterSets.AzureToAzure:
                    case ASRParameterSets.AzureToAzureWithMultipleStorageAccount:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.A2ARPIReprotect();
                        break;
                    case ASRParameterSets.ByRPObject:
                        this.SetRPReprotect();
                        break;
                    case ASRParameterSets.ByPEObject:
                        this.WriteWarning(
                        Resources.UnsupportedReplicationReprotectScenerio);
                        break;
                }
            }
        }

        /// <summary>
        ///     Update replication protection direction for replication protected item.
        /// </summary>
        private void SetRPIReprotect()
        {
            var plannedFailoverInputProperties = new ReverseReplicationInputProperties
            {
                FailoverDirection = this.Direction,
                ProviderSpecificDetails = new ReverseReplicationProviderSpecificInput()
            };

            var input = new ReverseReplicationInput { Properties = plannedFailoverInputProperties };

            // fetch the latest Protectable item objects
            var replicationProtectedItemResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectedItem(
                    this.fabricName,
                    this.protectionContainerName,
                    this.ReplicationProtectedItem.Name);

            validateRPISwitchParam();

            var protectableItemResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryProtectableItem(
                    this.fabricName,
                    this.protectionContainerName,
                    Utilities.GetValueFromArmId(
                        replicationProtectedItemResponse.Properties.ProtectableItemId,
                        ARMResourceTypeConstants.ProtectableItems));

            var asrProtectableItem = new ASRProtectableItem(protectableItemResponse);

            if (0 ==
                string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var reprotectInput = new HyperVReplicaAzureReprotectInput
                    {
                        HvHostVmId = asrProtectableItem.FabricObjectId,
                        VmName = asrProtectableItem.FriendlyName,
                        OsType = string.Compare(
                                asrProtectableItem.OS,
                                "Windows") ==
                            0 ||
                            string.Compare(
                                asrProtectableItem.OS,
                                "Linux") ==
                            0
                                ? asrProtectableItem.OS
                                : "Windows",
                        VHDId = asrProtectableItem.OSDiskId
                    };

                    var providerSpecificDetails =
                        (HyperVReplicaAzureReplicationDetails)replicationProtectedItemResponse
                            .Properties.ProviderSpecificDetails;

                    reprotectInput.StorageAccountId = this.RecoveryAzureStorageAccountId == null ?
                        providerSpecificDetails.RecoveryAzureStorageAccount
                        : this.RecoveryAzureStorageAccountId;

                    reprotectInput.LogStorageAccountId = this.LogStorageAccountId == null ?
                        providerSpecificDetails.RecoveryAzureLogStorageAccountId
                        : this.LogStorageAccountId;

                    input.Properties.ProviderSpecificDetails = reprotectInput;
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Validate the direction as RecoveryToPrimary.
                if (this.Direction == Constants.RecoveryToPrimary)
                {
                    // Set the InMage Provider specific input in the Reprotect Input.
                    var reprotectInput = new InMageReprotectInput
                    {
                        ProcessServerId = this.ProcessServer.Id,
                        MasterTargetId = this.MasterTarget != null
                            ? this.MasterTarget.Id
                            : this.ProcessServer
                                .Id, // Assumption: PS and MT may or may not be same.
                        RunAsAccountId = this.Account != null ? this.Account.AccountId : null,
                        RetentionDrive = this.RetentionVolume.VolumeName,
                        DatastoreName = this.DataStore.SymbolicName,
                        ProfileId = this.ProtectionContainerMapping.PolicyId,
                        DiskExclusionInput = new InMageDiskExclusionInput
                        {
                            VolumeOptions = new List<InMageVolumeExclusionOptions>(),
                            DiskSignatureOptions = null
                        },
                        DisksToInclude = null
                    };

                    // excluding the azure temporary storage.
                    reprotectInput.DiskExclusionInput.VolumeOptions.Add(
                        new InMageVolumeExclusionOptions
                        {
                            VolumeLabel = Constants.TemporaryStorage,
                            OnlyExcludeIfSingleVolume = Constants.Yes
                        });

                    input.Properties.ProviderSpecificDetails = reprotectInput;
                }
                else
                {
                    // PrimaryToRecovery Direction is Invalid for InMageAzureV2.
                    new ArgumentException(Resources.InvalidDirectionForAzureToVMWare);
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Validate the Direction as RecoveryToPrimary.
                if (this.Direction == Constants.RecoveryToPrimary)
                {
                    // Set the InMageAzureV2 Provider specific input in the Reprotect Input.
                    var reprotectInput = new InMageAzureV2ReprotectInput
                    {
                        ProcessServerId = this.ProcessServer.Id,
                        MasterTargetId = this.MasterTarget != null
                            ? this.MasterTarget.Id
                            : this.ProcessServer
                                .Id, // Assumption: PS and MT are same. 
                        RunAsAccountId = this.Account.AccountId,
                        PolicyId = this.ProtectionContainerMapping.PolicyId,
                        StorageAccountId = this.RecoveryAzureStorageAccountId,
                        LogStorageAccountId = this.LogStorageAccountId,
                        DisksToInclude = null
                    };
                    input.Properties.ProviderSpecificDetails = reprotectInput;
                }
                else
                {
                    // PrimaryToRecovery Direction is Invalid for InMage.
                    new ArgumentException(Resources.InvalidDirectionForVMWareToAzure);
                }
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryReprotection(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///      Update replication protection direction for recovery plan.
        /// </summary>
        private void SetRPReprotect()
        {
            // Check if the Recovery Plan contains any InMageAzureV2 and InMage Replication Provider Entities.
            var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                this.RecoveryPlan
                    .Name);

            foreach (var replicationProvider in rp.Properties.ReplicationProviders)
            {
                if (Constants.InMageAzureV2.Equals(replicationProvider, StringComparison.OrdinalIgnoreCase) ||
                    Constants.InMage.Equals(replicationProvider, StringComparison.OrdinalIgnoreCase) ||
                    Constants.A2A.Equals(replicationProvider, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.UnsupportedReplicationProviderForReprotect,
                            replicationProvider));
                }
            }

            var response =
                this.RecoveryServicesClient.UpdateAzureSiteRecoveryProtection(
                    this.RecoveryPlan.Name);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Switches protection from one container to another or one replication provider to another.
        /// </summary>
        private void A2ARPIReprotect()
        {
            var switchProtectionInputProperties = new SwitchProtectionInputProperties()
            {
                ReplicationProtectedItemName = this.ReplicationProtectedItem.Name,
                ProviderSpecificDetails = new SwitchProtectionProviderSpecificInput()
            };
            var fabricFriendlyName =
                        this.ReplicationProtectedItem.PrimaryFabricFriendlyName;
            SwitchProtectionInput input = new SwitchProtectionInput()
            {
                Properties = switchProtectionInputProperties
            };

            if (0 == string.Compare(
                this.ReplicationProtectedItem.ReplicationProvider,
                Constants.A2A,
                StringComparison.OrdinalIgnoreCase))
            {
                var a2aSwitchInput = new A2ASwitchProtectionInput()
                {
                    PolicyId = this.ProtectionContainerMapping.PolicyId,
                    RecoveryContainerId =
                        this.ProtectionContainerMapping.TargetProtectionContainerId,
                    VmDisks = new List<A2AVmDiskInputDetails>(),
                    RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                    RecoveryCloudServiceId = this.RecoveryCloudServiceId,
                    RecoveryAvailabilitySetId = this.RecoveryAvailabilitySetId
                };

                // Fetch the latest Protected item objects
                var replicationProtectedItemResponse =
                    RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(
                        this.fabricName,
                        this.protectionContainerName,
                        this.ReplicationProtectedItem.Name);

                if (fabricFriendlyName != this.ProtectionContainerMapping.TargetFabricFriendlyName)
                {
                    throw new ArgumentException(
                        string.Format(Resources.InvalidSwitchParamRPIAndProtectionContainerMapping,
                        fabricFriendlyName,
                        this.ProtectionContainerMapping.TargetFabricFriendlyName));
                }

                // At a time only Disk or managedDisk details will be present.
                // Will check with retieved protectedItem weather correct disk mapping is passed and then create the relevant object 
                // and pass as input to service.
                if (this.AzureToAzureDiskReplicationConfiguration == null || this.AzureToAzureDiskReplicationConfiguration.Length == 0)
                {
                    if (fabricFriendlyName !=
                        this.ProtectionContainerMapping.TargetFabricFriendlyName &&
                        RecoveryAzureStorageAccountId == null)
                    {
                        throw new ArgumentException(Resources.InvalidRecoveryAzureStorageAccountId);
                    }

                    foreach (var disk in ((A2AReplicationDetails)replicationProtectedItemResponse
                        .Properties.ProviderSpecificDetails)
                        .ProtectedDisks)
                    {
                        a2aSwitchInput.VmDisks.Add(new A2AVmDiskInputDetails
                        {
                            DiskUri = disk.RecoveryDiskUri,
                            RecoveryAzureStorageAccountId =
                                fabricFriendlyName ==
                                    this.ProtectionContainerMapping.TargetFabricFriendlyName &&
                                this.RecoveryAzureStorageAccountId == null ?
                                    disk.PrimaryDiskAzureStorageAccountId :
                                    this.RecoveryAzureStorageAccountId,
                            PrimaryStagingAzureStorageAccountId =
                                this.LogStorageAccountId,
                        });
                    }
                }
                else
                {
                    foreach (ASRAzuretoAzureDiskReplicationConfig disk in this.AzureToAzureDiskReplicationConfiguration)
                    {
                        if (string.IsNullOrEmpty(disk.LogStorageAccountId))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Properties.Resources.InvalidPrimaryStagingAzureStorageAccountIdDiskInput,
                                    disk.VhdUri));
                        }

                        if (string.IsNullOrEmpty(disk.RecoveryAzureStorageAccountId))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Properties.Resources.InvalidRecoveryAzureStorageAccountIdDiskInput,
                                    disk.VhdUri));
                        }

                        a2aSwitchInput.VmDisks.Add(new A2AVmDiskInputDetails
                        {
                            DiskUri = disk.VhdUri,
                            RecoveryAzureStorageAccountId = disk.RecoveryAzureStorageAccountId,
                            PrimaryStagingAzureStorageAccountId =
                                disk.LogStorageAccountId
                        });
                    }
                }

                input.Properties.ProviderSpecificDetails = a2aSwitchInput;
            }

            var response =
                RecoveryServicesClient.StartSwitchProtection(
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
        ///     validate replicated protected item parameter values depending on switch parameter.
        /// </summary>
        private void validateRPISwitchParam()
        {
            if ((this.AzureToVMware.IsPresent
                && !this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.InMageAzureV2))
                || (this.VMwareToAzure.IsPresent
                && !this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.InMage))
                || (this.HyperVToAzure.IsPresent
                && !this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.HyperVReplicaAzure))
                || (this.VmmToVmm.IsPresent
                && !(this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.HyperVReplica2012)
                || this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.HyperVReplica2012R2))))
            {
                throw new PSInvalidOperationException(Resources.InvalidParameterSet);
            }
        }

        /// <summary>
        ///     validate parameter vaules for recovery plan.
        /// </summary>
        private void validateRPSwitchParam(RecoveryPlan rp, string replicationProvider)
        {
            if ((this.HyperVToAzure.IsPresent
                && !replicationProvider.Equals(Constants.HyperVReplicaAzure))
                || (this.VmmToVmm.IsPresent
                && !(this.ReplicationProtectedItem.ReplicationProvider.Equals(Constants.HyperVReplica2012)
                || replicationProvider.Equals(Constants.HyperVReplica2012R2))))
            {
                throw new PSInvalidOperationException(Resources.InvalidParameterSet);
            }
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

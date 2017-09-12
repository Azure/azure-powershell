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
    ///     Used to initiate a recovery protection operation.
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
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        ///     Gets or sets RunAsAccount.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToVMwareRPI, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        ///     Gets or sets DataStore.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRDataStore DataStore { get; set; }

        /// <summary>
        ///     Gets or sets Master Target Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI)]
        [ValidateNotNullOrEmpty]
        public ASRMasterTargetServer MasterTarget { get; set; }

        /// <summary>
        ///     Gets or sets Process Server.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToVMwareRPI, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProcessServer ProcessServer { get; set; }

        /// <summary>
        ///     Gets or sets Policy.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToVMwareRPI, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Log Storage Account Id.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToVMwareRPI)]
        [ValidateNotNullOrEmpty]
        public string LogStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Azure Storage Account Name of the Policy for V2A scenarios.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToVMwareRPI)]
        public string RecoveryAzureStorageAccountId { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToAzureRPI,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.VMwareToVMwareRPI,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets Failover direction for the recovery plan.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToVMwareRPI, Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets Retention Volume.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.VMwareToAzureRPI, Mandatory = true)]
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
                    case ASRParameterSets.VMwareToAzureRPI:
                    case ASRParameterSets.VMwareToVMwareRPI:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.SetRPIReprotect();
                        break;
                    case ASRParameterSets.ByRPObject:
                    case ASRParameterSets.VMwareToAzureAndVMwareToVMwareRP:
                        this.SetRPReprotect();
                        break;
                }
            }
        }

        /// <summary>
        ///     RPI Reprotect.
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

                    reprotectInput.StorageAccountId =
                        providerSpecificDetails.RecoveryAzureStorageAccount;

                    input.Properties.ProviderSpecificDetails = reprotectInput;
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                // Validate the Direction as RecoveryToPrimary.
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
                        MasterTargetId = this.ProcessServer.Id, // Assumption: PS and MT are same. 
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
        ///     Starts RP Reprotect.
        /// </summary>
        private void SetRPReprotect()
        {
            // Check if the Recovery Plan contains any InMageAzureV2 and InMage Replication Provider Entities.
            var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                this.RecoveryPlan
                    .Name);
            foreach (var replicationProvider in rp.Properties.ReplicationProviders)
            {
                if (string.Compare(
                        replicationProvider,
                        Constants.InMageAzureV2,
                        StringComparison.OrdinalIgnoreCase) ==
                    0 ||
                    string.Compare(
                        replicationProvider,
                        Constants.InMage,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
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
    }
}
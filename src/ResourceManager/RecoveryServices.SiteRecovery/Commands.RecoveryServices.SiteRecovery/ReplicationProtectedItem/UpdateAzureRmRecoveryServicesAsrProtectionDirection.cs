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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Used to initiate a recovery protection operation.
    /// </summary>
    [Cmdlet(VerbsData.Update,
        "AzureRmRecoveryServicesAsrProtectionDirection",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject)]
    [Alias("Update-ASRProtectionDirection")]
    [OutputType(typeof(ASRJob))]
    public class UpdateAzureRmRecoveryServicesAsrProtection : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets Failover direction for the recovery plan.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = true)]
        [ValidateSet(Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        ///     Gets or sets Name of the PE.
        /// </summary>
        public string protectionEntityName;

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByRPIObject:
                    protectionContainerName = Utilities.GetValueFromArmId(
                        ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);
                    fabricName = Utilities.GetValueFromArmId(ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationFabrics);
                    SetRPIReprotect();
                    break;
                case ASRParameterSets.ByRPObject:
                    SetRPReprotect();
                    break;
            }
        }

        /// <summary>
        ///     RPI Reprotect.
        /// </summary>
        private void SetRPIReprotect()
        {
            var plannedFailoverInputProperties = new ReverseReplicationInputProperties
            {
                FailoverDirection = Direction,
                ProviderSpecificDetails = new ReverseReplicationProviderSpecificInput()
            };

            var input = new ReverseReplicationInput {Properties = plannedFailoverInputProperties};

            // fetch the latest Protectable item objects
            var replicationProtectedItemResponse = RecoveryServicesClient
                .GetAzureSiteRecoveryReplicationProtectedItem(fabricName,
                    protectionContainerName,
                    ReplicationProtectedItem.Name);

            var protectableItemResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(fabricName,
                    protectionContainerName,
                    Utilities.GetValueFromArmId(replicationProtectedItemResponse.Properties
                            .ProtectableItemId,
                        ARMResourceTypeConstants.ProtectableItems));

            var aSRProtectableItem = new ASRProtectableItem(protectableItemResponse);

            if (0 ==
                string.Compare(ReplicationProtectedItem.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                if (Direction == Constants.PrimaryToRecovery)
                {
                    var reprotectInput = new HyperVReplicaAzureReprotectInput
                    {
                        HvHostVmId = aSRProtectableItem.FabricObjectId,
                        VmName = aSRProtectableItem.FriendlyName,
                        OsType = string.Compare(aSRProtectableItem.OS,
                                     "Windows") ==
                                 0 ||
                                 string.Compare(aSRProtectableItem.OS,
                                     "Linux") ==
                                 0 ? aSRProtectableItem.OS : "Windows",
                        VHDId = aSRProtectableItem.OSDiskId
                    };

                    var providerSpecificDetails =
                        (HyperVReplicaAzureReplicationDetails) replicationProtectedItemResponse
                            .Properties.ProviderSpecificDetails;

                    reprotectInput.StorageAccountId =
                        providerSpecificDetails.RecoveryAzureStorageAccount;

                    input.Properties.ProviderSpecificDetails = reprotectInput;
                }
            }

            var response = RecoveryServicesClient.StartAzureSiteRecoveryReprotection(fabricName,
                protectionContainerName,
                ReplicationProtectedItem.Name,
                input);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Reprotect.
        /// </summary>
        private void SetRPReprotect()
        {
            var response =
                RecoveryServicesClient.UpdateAzureSiteRecoveryProtection(RecoveryPlan.Name);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }
    }
}
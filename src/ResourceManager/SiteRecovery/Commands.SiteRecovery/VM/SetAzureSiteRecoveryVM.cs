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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Protection Entity.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSiteRecoveryVM", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(ASRJob))]
    public class SetAzureSiteRecoveryVM : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets ID of the Virtual Machine.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRVirtualMachine VirtualMachine { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure VM given name
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure VM size
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets Selected Primary Network interface card Id
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string PrimaryNic { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Network Id
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Azure Network Id
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicSubnetName { get; set; }

        /// <summary>
        /// Gets or sets Recovery Nic Static IPAddress
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicStaticIPAddress { get; set; }

        /// <summary>
        /// Gets or sets Selection Type for Nic
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NotSelected,
            Constants.SelectedByUser)]
        public string NicSelectionType { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            ProtectableItemResponse protectableItemResponse =
                                                RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(Utilities.GetValueFromArmId(this.VirtualMachine.ID, ARMResourceTypeConstants.ReplicationFabrics),
                                                this.VirtualMachine.ProtectionContainerId, this.VirtualMachine.Name);

            if (protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId == null)
            {
                this.WriteWarning(Properties.Resources.ProtectionIsNotEnabledForVM.ToString());
                return;
            }

            ReplicationProtectedItemResponse replicationProtectedItemResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(Utilities.GetValueFromArmId(this.VirtualMachine.ID, ARMResourceTypeConstants.ReplicationFabrics),
                        this.VirtualMachine.ProtectionContainerId, Utilities.GetValueFromArmId(protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems));

            // Check for Replication Provider type HyperVReplicaAzure
            if (0 != string.Compare(
                    replicationProtectedItemResponse.ReplicationProtectedItem.Properties.ProviderSpecificDetails.InstanceType,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning(Properties.Resources.UnsupportedReplicationProvidedForUpdateVmProperties.ToString());
                return;
            }

            // Check for at least one option
            if (string.IsNullOrEmpty(this.Name) &&
                string.IsNullOrEmpty(this.Size) &&
                string.IsNullOrEmpty(this.PrimaryNic) &&
                string.IsNullOrEmpty(this.RecoveryNetworkId))
            {
                this.WriteWarning(Properties.Resources.ArgumentsMissingForUpdateVmProperties.ToString());
                return;
            }

            // Both primary & recovery inputs should be present
            if (string.IsNullOrEmpty(this.PrimaryNic) ^
                string.IsNullOrEmpty(this.RecoveryNetworkId))
            {
                this.WriteWarning(Properties.Resources.NetworkArgumentsMissingForUpdateVmProperties.ToString());
                return;
            }

            List<VMNicInputDetails> vMNicInputDetailsList = new List<VMNicInputDetails>();
            VMNicDetails vMNicDetailsToBeUpdated;
            if (!string.IsNullOrEmpty(this.PrimaryNic))
            {
                HyperVReplicaAzureReplicationDetails providerSpecificDetails =
                            (HyperVReplicaAzureReplicationDetails)replicationProtectedItemResponse.ReplicationProtectedItem.Properties.ProviderSpecificDetails;

                if (providerSpecificDetails.VMNics != null)
                {
                    vMNicDetailsToBeUpdated = providerSpecificDetails.VMNics.SingleOrDefault(n => string.Compare(n.NicId, this.PrimaryNic, StringComparison.OrdinalIgnoreCase) == 0);
                    if (vMNicDetailsToBeUpdated != null)
                    {
                        VMNicInputDetails vMNicInputDetails = new VMNicInputDetails();

                        vMNicInputDetails.NicId = this.PrimaryNic;
                        vMNicInputDetails.RecoveryVMSubnetName = this.RecoveryNicSubnetName;
                        vMNicInputDetails.ReplicaNicStaticIPAddress = this.RecoveryNicStaticIPAddress;
                        vMNicInputDetails.SelectionType = string.IsNullOrEmpty(this.NicSelectionType) ? Constants.SelectedByUser : this.NicSelectionType;
                        vMNicInputDetailsList.Add(vMNicInputDetails);

                        IEnumerable<VMNicDetails> vMNicDetailsListRemaining = providerSpecificDetails.VMNics.Where(n => string.Compare(n.NicId, this.PrimaryNic, StringComparison.OrdinalIgnoreCase) != 0);
                        foreach (VMNicDetails nDetails in vMNicDetailsListRemaining)
                        {
                            vMNicInputDetails = new VMNicInputDetails();

                            vMNicInputDetails.NicId = nDetails.NicId;
                            vMNicInputDetails.RecoveryVMSubnetName = nDetails.RecoveryVMSubnetName;
                            vMNicInputDetails.ReplicaNicStaticIPAddress = nDetails.ReplicaNicStaticIPAddress;
                            vMNicInputDetails.SelectionType = nDetails.SelectionType;
                            vMNicInputDetailsList.Add(vMNicInputDetails);
                        }
                    }
                    else
                    {
                        throw new PSInvalidOperationException(Properties.Resources.NicNotFoundInVMForUpdateVmProperties);
                    }
                }
            }

            UpdateReplicationProtectedItemInputProperties updateReplicationProtectedItemInputProperties = new UpdateReplicationProtectedItemInputProperties()
            {
                RecoveryAzureVMName = this.Name,
                RecoveryAzureVMSize = this.Size,
                SelectedRecoveryAzureNetworkId = this.RecoveryNetworkId,
                VmNics = vMNicInputDetailsList
            };

            UpdateReplicationProtectedItemInput input = new UpdateReplicationProtectedItemInput()
            {
                Properties = updateReplicationProtectedItemInputProperties
            };

            LongRunningOperationResponse response = RecoveryServicesClient.UpdateVmProperties(
                Utilities.GetValueFromArmId(this.VirtualMachine.ID, ARMResourceTypeConstants.ReplicationFabrics),
                Utilities.GetValueFromArmId(this.VirtualMachine.ID, ARMResourceTypeConstants.ReplicationProtectionContainers),
                replicationProtectedItemResponse.ReplicationProtectedItem.Name,
                input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
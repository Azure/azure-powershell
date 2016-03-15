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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryTestFailoverJob", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryTestFailoverJob : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Network ID.
        /// </summary>
        private string networkId = string.Empty; // Network ARM Id

        /// <summary>
        /// Network Type (Logical network or VM network).
        /// </summary>
        private string networkType = string.Empty; // LogicalNetworkAsInput|VmNetworkAsInput|NoNetworkAttachAsInput

        /// <summary>
        /// Gets or sets Name of the PE.
        /// </summary>
        public string protectionEntityName;

        /// <summary>
        /// Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        /// Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        /// <summary>
        /// Gets or sets failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
          Constants.PrimaryToRecovery,
          Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetwork, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithAzureVMNetworkId, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetwork, Mandatory = true)]
        public ASRNetwork VMNetwork { get; set; }

        ///// <summary>
        ///// Gets or sets Network.
        ///// </summary>
        //[Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithLogicalVMNetwork, Mandatory = true)]
        //public ASRLogicalNetwork LogicalVMNetwork { get; set; }

        /// <summary>
        /// Gets or sets Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithAzureVMNetworkId, Mandatory = true)]
        public string AzureVMNetworkId { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch(this.ParameterSetName)
                {
                    case ASRParameterSets.ByPEObjectWithVMNetwork:
                        this.networkType = "VmNetworkAsInput"; 
                        this.networkId = this.VMNetwork.ID;
                        break;
                    //case ASRParameterSets.ByPEObjectWithLogicalVMNetwork:
                    //    this.networkType = "LogicalNetworkAsInput"; 
                    //    this.networkId = this.LogicalVMNetwork.ID;
                    //    break;
                    case ASRParameterSets.ByPEObjectWithAzureVMNetworkId:
                        this.networkType = "VmNetworkAsInput"; 
                        this.networkId = this.AzureVMNetworkId;
                        break;
                    case ASRParameterSets.ByPEObject:
                        this.networkType = "NoNetworkAttachAsInput"; 
                        this.networkId = null;
                        break;
                }

                this.protectionEntityName = this.ProtectionEntity.Name;
                this.protectionContainerName = this.ProtectionEntity.ProtectionContainerId;
                this.fabricName = Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics);
                this.StartPETestFailover();
           }
            
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Starts PE Test failover.
        /// </summary>
        private void StartPETestFailover()
        {
            TestFailoverInputProperties testFailoverInputProperties = new TestFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
                NetworkId = this.networkId,
                NetworkType = this.networkType,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            TestFailoverInput input = new TestFailoverInput()
            {
                Properties = testFailoverInputProperties
            };

            // fetch the latest PE object
            ProtectableItemResponse protectableItemResponse =
                                        RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(this.fabricName,
                                        this.ProtectionEntity.ProtectionContainerId, this.ProtectionEntity.Name);

            ReplicationProtectedItemResponse replicationProtectedItemResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(this.fabricName,
                        this.ProtectionEntity.ProtectionContainerId, Utilities.GetValueFromArmId(protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId,  ARMResourceTypeConstants.ReplicationProtectedItems));

            PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies));

            this.ProtectionEntity = new ASRProtectionEntity(protectableItemResponse.ProtectableItem, replicationProtectedItemResponse.ReplicationProtectedItem);

            if (0 == string.Compare(
                this.ProtectionEntity.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase))
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    HyperVReplicaAzureFailoverProviderInput failoverInput = new HyperVReplicaAzureFailoverProviderInput()
                    {
                        PrimaryKekCertificatePfx = null,
                        SecondaryKekCertificatePfx = null,
                        VaultLocation = this.GetCurrentValutLocation()
                    };
                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
                else
                {
                    new ArgumentException(Properties.Resources.UnsupportedDirectionForTFO);// Throw Unsupported Direction Exception
                }
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.fabricName,
                this.protectionContainerName,
                Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Id,  ARMResourceTypeConstants.ReplicationProtectedItems),
                input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));       
        }
    }
}
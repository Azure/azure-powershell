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
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryTestFailoverJob", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryTestFailoverJob : SiteRecoveryCmdletBase
    {
        #region local parameters

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
        /// Primary Kek Cert pfx file.
        /// </summary>
        string primaryKekCertpfx = null;

        /// <summary>
        /// Secondary Kek Cert pfx file.
        /// </summary>
        string secondaryKekCertpfx = null;

        #endregion local parameters

        #region Parameters

        /// <summary>
        /// Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithVMNetwork, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithAzureVMNetworkId, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(Constants.PrimaryToRecovery, Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork, Mandatory = true, ValueFromPipeline = true)]
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
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObjectWithAzureVMNetworkId, Mandatory = true)]
        public string AzureVMNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (!string.IsNullOrEmpty(this.DataEncryptionPrimaryCertFile))
            {
                byte[] certBytesPrimary = File.ReadAllBytes(this.DataEncryptionPrimaryCertFile);
                primaryKekCertpfx = Convert.ToBase64String(certBytesPrimary);
            }

            if (!string.IsNullOrEmpty(this.DataEncryptionSecondaryCertFile))
            {
                byte[] certBytesSecondary = File.ReadAllBytes(this.DataEncryptionSecondaryCertFile);
                secondaryKekCertpfx = Convert.ToBase64String(certBytesSecondary);
            }

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByPEObjectWithVMNetwork:
                case ASRParameterSets.ByRPObjectWithVMNetwork:
                    this.networkType = "VmNetworkAsInput";
                    this.networkId = this.VMNetwork.ID;
                    break;
                //case ASRParameterSets.ByPEObjectWithLogicalVMNetwork:
                //case ASRParameterSets.ByRPObjectWithLogicalVMNetwork:
                //    this.networkType = "LogicalNetworkAsInput"; 
                //    this.networkId = this.LogicalVMNetwork.ID;
                //    break;
                case ASRParameterSets.ByPEObjectWithAzureVMNetworkId:
                case ASRParameterSets.ByRPObjectWithAzureVMNetworkId:
                    this.networkType = "VmNetworkAsInput";
                    this.networkId = this.AzureVMNetworkId;
                    break;
                case ASRParameterSets.ByPEObject:
                case ASRParameterSets.ByRPObject:
                    this.networkType = "NoNetworkAttachAsInput";
                    this.networkId = null;
                    break;
            }

            if (this.ParameterSetName == ASRParameterSets.ByRPObject ||
                this.ParameterSetName == ASRParameterSets.ByRPObjectWithVMNetwork ||
                this.ParameterSetName == ASRParameterSets.ByRPObjectWithAzureVMNetworkId)
            {
                this.StartRpTestFailover();
            }
            else
            {
                this.protectionEntityName = this.ProtectionEntity.Name;
                this.protectionContainerName = this.ProtectionEntity.ProtectionContainerId;
                this.fabricName = Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics);
                this.StartPETestFailover();
            }
        }

        /// <summary>
        /// Starts PE Test failover.
        /// </summary>
        private void StartPETestFailover()
        {
            var testFailoverInputProperties = new TestFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
                NetworkId = this.networkId,
                NetworkType = this.networkType,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input = new TestFailoverInput()
            {
                Properties = testFailoverInputProperties
            };

            // fetch the latest PE object
            ProtectableItemResponse protectableItemResponse =
                                        RecoveryServicesClient.GetAzureSiteRecoveryProtectableItem(this.fabricName,
                                        this.ProtectionEntity.ProtectionContainerId, this.ProtectionEntity.Name);

            ReplicationProtectedItemResponse replicationProtectedItemResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryReplicationProtectedItem(this.fabricName,
                        this.ProtectionEntity.ProtectionContainerId, Utilities.GetValueFromArmId(protectableItemResponse.ProtectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems));

            PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Properties.PolicyID, ARMResourceTypeConstants.ReplicationPolicies));

            this.ProtectionEntity = new ASRProtectionEntity(protectableItemResponse.ProtectableItem, replicationProtectedItemResponse.ReplicationProtectedItem);

            if (0 == string.Compare(
                this.ProtectionEntity.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase))
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var failoverInput = new HyperVReplicaAzureFailoverProviderInput()
                    {
                        PrimaryKekCertificatePfx = primaryKekCertpfx,
                        SecondaryKekCertificatePfx = secondaryKekCertpfx,
                        VaultLocation = this.GetCurrentVaultLocation()
                    };

                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
                else
                {
                    throw new ArgumentException(Properties.Resources.UnsupportedDirectionForTFO);// Throw Unsupported Direction Exception
                }
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.fabricName,
                this.protectionContainerName,
                Utilities.GetValueFromArmId(replicationProtectedItemResponse.ReplicationProtectedItem.Id, ARMResourceTypeConstants.ReplicationProtectedItems),
                input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }

        /// <summary>
        /// Starts RP Test failover.
        /// </summary>
        private void StartRpTestFailover()
        {
            // Refresh RP Object
            var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(this.RecoveryPlan.Name);

            var recoveryPlanTestFailoverInputProperties = new RecoveryPlanTestFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
                NetworkId = this.networkId,
                NetworkType = this.networkType,
                ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
            };

            foreach (string replicationProvider in rp.RecoveryPlan.Properties.ReplicationProviders)
            {
                if (0 == string.Compare(
                    replicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (this.Direction == Constants.PrimaryToRecovery)
                    {
                        var recoveryPlanHyperVReplicaAzureFailoverInput = new RecoveryPlanHyperVReplicaAzureFailoverInput()
                        {
                            InstanceType = replicationProvider,
                            PrimaryKekCertificatePfx = primaryKekCertpfx,
                            SecondaryKekCertificatePfx = secondaryKekCertpfx,
                            VaultLocation = this.GetCurrentVaultLocation()
                        };
                        recoveryPlanTestFailoverInputProperties.ProviderSpecificDetails.Add(recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                    else
                    {
                        throw new ArgumentException(Properties.Resources.UnsupportedDirectionForTFO);// Throw Unsupported Direction Exception
                    }
                }
            }

            var recoveryPlanTestFailoverInput = new RecoveryPlanTestFailoverInput()
            {
                Properties = recoveryPlanTestFailoverInputProperties
            };

            LongRunningOperationResponse response = RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.RecoveryPlan.Name,
                recoveryPlanTestFailoverInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
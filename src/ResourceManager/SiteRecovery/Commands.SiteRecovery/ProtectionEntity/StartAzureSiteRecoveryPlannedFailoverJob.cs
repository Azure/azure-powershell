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
    /// Used to initiate a failover operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryPlannedFailoverJob", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureSiteRecoveryPlannedFailoverJob : SiteRecoveryCmdletBase
    {
        #region local parameters

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
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        /// Gets or sets Protection Entity object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionEntity ProtectionEntity { get; set; }

        /// <summary>
        /// Gets or sets Failover direction for the protected Item.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(Constants.PrimaryToRecovery, Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets the Optimize value.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false)]
        [ValidateSet(Constants.ForDownTime, Constants.ForSynchronization)]
        public string Optimize { get; set; }

        /// <summary>
        /// Gets or sets the recovery vm creation value.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false)]
        [ValidateSet(Constants.Yes, Constants.No)]
        public string CreateVmIfNotFound { get; set; }

        /// <summary>
        /// Gets or sets hyper-V server to create vm on.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false)]
        public ASRServer Server { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false)]
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
                case ASRParameterSets.ByPEObject:
                    this.protectionEntityName = this.ProtectionEntity.Name;
                    this.protectionContainerName = this.ProtectionEntity.ProtectionContainerId;
                    this.fabricName = Utilities.GetValueFromArmId(this.ProtectionEntity.ID, ARMResourceTypeConstants.ReplicationFabrics);
                    this.StartPEPlannedFailover();
                    break;
                case ASRParameterSets.ByRPObject:
                    this.StartRpPlannedFailover();
                    break;
            }
        }

        /// <summary>
        /// Starts PE Planned failover.
        /// </summary>
        private void StartPEPlannedFailover()
        {
            var plannedFailoverInputProperties = new PlannedFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input = new PlannedFailoverInput()
            {
                Properties = plannedFailoverInputProperties
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
                    var failbackInput = new HyperVReplicaAzureFailbackProviderInput()
                    {
                        DataSyncOption = this.Optimize == Constants.ForDownTime ? Constants.ForDownTime : Constants.ForSynchronization,
                        RecoveryVmCreationOption = String.Compare(this.CreateVmIfNotFound, Constants.Yes, StringComparison.OrdinalIgnoreCase) == 0 ? Constants.CreateVmIfNotFound : Constants.NoAction
                    };

                    if (String.Compare(this.CreateVmIfNotFound, Constants.Yes, StringComparison.OrdinalIgnoreCase) == 0 &&
                        string.Compare(RecoveryServicesClient.GetAzureSiteRecoveryFabric(this.fabricName).Fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) == 0)
                    {
                        if(this.Server == null || string.Compare(this.Server.FabricType, Constants.HyperVSite) != 0)
                        {
                            throw new InvalidOperationException(
                                Properties.Resources.ImproperServerObjectPassedForHyperVFailback);
                        }
                        else
                        {
                            failbackInput.ProviderIdForAlternateRecovery = this.Server.ID;
                        }                             
                    }

                    input.Properties.ProviderSpecificDetails = failbackInput;
                }
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
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
        /// Starts RP Planned failover.
        /// </summary>
        private void StartRpPlannedFailover()
        {
            // Refresh RP Object
            var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(this.RecoveryPlan.Name);

            var recoveryPlanPlannedFailoverInputProperties = new RecoveryPlanPlannedFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
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
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                    else
                    {
                        var recoveryPlanHyperVReplicaAzureFailbackInput = new RecoveryPlanHyperVReplicaAzureFailbackInput()
                        {
                            InstanceType = replicationProvider + "Failback",
                            DataSyncOption = this.Optimize == Constants.ForDownTime ? Constants.ForDownTime : Constants.ForSynchronization,
                            RecoveryVmCreationOption = String.Compare(this.CreateVmIfNotFound, Constants.Yes, StringComparison.OrdinalIgnoreCase) == 0 ? Constants.CreateVmIfNotFound : Constants.NoAction
                        };
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(recoveryPlanHyperVReplicaAzureFailbackInput);
                    }
                }
            }

            var recoveryPlanPlannedFailoverInput = new RecoveryPlanPlannedFailoverInput()
            {
                Properties = recoveryPlanPlannedFailoverInputProperties
            };

            LongRunningOperationResponse response = RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.RecoveryPlan.Name,
                recoveryPlanPlannedFailoverInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
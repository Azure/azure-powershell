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
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Used to initiate a failover operation.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrUnplannedFailoverJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject,
        SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRFO",
        "Start-ASRUnplannedFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrUnplannedFailoverJob : SiteRecoveryCmdletBase
    {
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
           ParameterSetName = ASRParameterSets.ByRPIObjectWithRecoveryTag,
           Mandatory = true,
           ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets Failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. This is required to PerformSourceSideActions.
        /// </summary>
        [Parameter]
        [Alias("PerformSourceSideActions")]
        public SwitchParameter PerformSourceSideAction { get; set; }

        /// <summary>
        ///     Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        ///     Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Point object.
        /// </summary>
        [Parameter(
           ParameterSetName = ASRParameterSets.ByRPIObject,
           Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPoint RecoveryPoint { get; set; }

        /// <summary>
        ///     Gets or sets Recovery Tag for the Recovery Point Type.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
           Mandatory = false)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObjectWithRecoveryTag,
           Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.RecoveryTagLatest,
            Constants.RecoveryTagLatestAvailable,
            Constants.RecoveryTagLatestAvailableApplicationConsistent)]
        public string RecoveryTag { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Protected item or Recovery plan",
                "Start failover"))
            {
                if (!string.IsNullOrEmpty(this.DataEncryptionPrimaryCertFile))
                {
                    var certBytesPrimary = File.ReadAllBytes(this.DataEncryptionPrimaryCertFile);
                    this.primaryKekCertpfx = Convert.ToBase64String(certBytesPrimary);
                }

                if (!string.IsNullOrEmpty(this.DataEncryptionSecondaryCertFile))
                {
                    var certBytesSecondary =
                        File.ReadAllBytes(this.DataEncryptionSecondaryCertFile);
                    this.secondaryKekCertpfx = Convert.ToBase64String(certBytesSecondary);
                }

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByRPIObject:
                    case ASRParameterSets.ByRPIObjectWithRecoveryTag:
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.StartRPIUnplannedFailover();
                        break;
                    case ASRParameterSets.ByRPObject:
                        this.StartRpUnplannedFailover();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts RPI Unplanned failover.
        /// </summary>
        private void StartRPIUnplannedFailover()
        {
            var unplannedFailoverInputProperties = new UnplannedFailoverInputProperties
            {
                FailoverDirection = this.Direction,
                SourceSiteOperations = this.PerformSourceSideAction ? "Required" : "NotRequired",
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input =
                new UnplannedFailoverInput { Properties = unplannedFailoverInputProperties };

            if (0 ==
                string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var failoverInput = new HyperVReplicaAzureFailoverProviderInput
                    {
                        PrimaryKekCertificatePfx = this.primaryKekCertpfx,
                        SecondaryKekCertificatePfx = this.secondaryKekCertpfx,
                        VaultLocation = "dummy",
                        RecoveryPointId = this.RecoveryPoint ==null ? null : this.RecoveryPoint.ID
                    };
                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                this.InMageAzureV2UnplannedFailover(input);
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                this.InMageUnplannedFailover(input);
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryUnplannedFailover(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     InMage Unplanned failover.
        /// </summary>
        private void InMageUnplannedFailover(UnplannedFailoverInput input)
        {
            // Validate if the Replication Protection Item is part of any Replication Group.
            Guid guidResult;
            var parseFlag = Guid.TryParse(
                ((ASRInMageSpecificRPIDetails)this.ReplicationProtectedItem
                    .ProviderSpecificDetails).MultiVmGroupName,
                out guidResult);
            if (parseFlag == false ||
                guidResult == Guid.Empty ||
                string.Compare(
                    ((ASRInMageSpecificRPIDetails)this.ReplicationProtectedItem
                        .ProviderSpecificDetails).MultiVmGroupName,
                    ((ASRInMageSpecificRPIDetails)this.ReplicationProtectedItem
                        .ProviderSpecificDetails).MultiVmGroupId) !=
                0)
            {
                // Replication Group was created at the time of Protection.
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProtectionActionForUnplannedFailover,
                        this.ReplicationProtectedItem.ReplicationProvider));
            }

            // Validate the Direction as PrimaryToRecovery.
            if (this.Direction == Constants.PrimaryToRecovery)
            {
                // Set the Recovery Point Types for InMage.
                var recoveryPointType =
                    this.RecoveryTag ==
                    Constants.RecoveryTagLatestAvailableApplicationConsistent
                        ? RecoveryPointType.LatestTag
                        : RecoveryPointType.LatestTime;

                // Set the InMage Provider specific input in the Unplanned Failover Input.
                var failoverInput = new InMageFailoverProviderInput
                {
                    RecoveryPointType = recoveryPointType
                };
                input.Properties.ProviderSpecificDetails = failoverInput;
            }
            else
            {
                // RecoveryToPrimary Direction is Invalid for InMage.
                new ArgumentException(Resources.InvalidDirectionForAzureToVMWare);
            }
        }

        /// <summary>
        ///     InMageAzureV2 Unplanned failover.
        /// </summary>
        private void InMageAzureV2UnplannedFailover(UnplannedFailoverInput input)
        {
            // Validate if the Replication Protection Item is part of any Replication Group.
            Guid guidResult;
            var parseFlag = Guid.TryParse(
                ((ASRInMageAzureV2SpecificRPIDetails)this.ReplicationProtectedItem
                    .ProviderSpecificDetails).MultiVmGroupName,
                out guidResult);
            if (parseFlag == false ||
                guidResult == Guid.Empty ||
                string.Compare(
                    ((ASRInMageAzureV2SpecificRPIDetails)this.ReplicationProtectedItem
                        .ProviderSpecificDetails).MultiVmGroupName,
                    ((ASRInMageAzureV2SpecificRPIDetails)this.ReplicationProtectedItem
                        .ProviderSpecificDetails).MultiVmGroupId) !=
                0)
            {
                // Replication Group was created at the time of Protection.
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProtectionActionForUnplannedFailover,
                        this.ReplicationProtectedItem.ReplicationProvider));
            }

            // Validate the Direction as PrimaryToRecovery.
            if (this.Direction == Constants.PrimaryToRecovery)
            {
                // Set the InMageAzureV2 Provider specific input in the Unplanned Failover Input.
                var failoverInput = new InMageAzureV2FailoverProviderInput
                {
                    RecoveryPointId = this.RecoveryPoint != null ? this.RecoveryPoint.ID : null
                };
                input.Properties.ProviderSpecificDetails = failoverInput;
            }
            else
            {
                // RecoveryToPrimary Direction is Invalid for InMageAzureV2.
                new ArgumentException(Resources.InvalidDirectionForVMWareToAzure);
            }
        }

        /// <summary>
        ///     Starts RP Unplanned failover.
        /// </summary>
        private void StartRpUnplannedFailover()
        {
            // Refresh RP Object
            var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                this.RecoveryPlan.Name);

            var recoveryPlanUnplannedFailoverInputProperties =
                new RecoveryPlanUnplannedFailoverInputProperties
                {
                    FailoverDirection =
                        this.Direction == PossibleOperationsDirections.PrimaryToRecovery.ToString()
                            ? PossibleOperationsDirections.PrimaryToRecovery
                            : PossibleOperationsDirections.RecoveryToPrimary,
                    SourceSiteOperations = this.PerformSourceSideAction
                        ? SourceSiteOperations.Required
                        : SourceSiteOperations.NotRequired, //Required|NotRequired
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
                };

            foreach (var replicationProvider in rp.Properties.ReplicationProviders)
            {
                if (0 ==
                    string.Compare(
                        replicationProvider,
                        Constants.HyperVReplicaAzure,
                        StringComparison.OrdinalIgnoreCase))
                {
                    if (this.Direction == Constants.PrimaryToRecovery)
                    {
                        var recoveryPlanHyperVReplicaAzureFailoverInput =
                            new RecoveryPlanHyperVReplicaAzureFailoverInput
                            {
                                PrimaryKekCertificatePfx = this.primaryKekCertpfx,
                                SecondaryKekCertificatePfx = this.secondaryKekCertpfx,
                                VaultLocation = "dummy"
                            };
                        if (this.RecoveryTag != null)
                        {
                            var recoveryPointType =
                           this.RecoveryTag ==
                           Constants.RecoveryTagLatestAvailableApplicationConsistent
                               ? HyperVReplicaAzureRpRecoveryPointType.LatestApplicationConsistent
                               : this.RecoveryTag == Constants.RecoveryTagLatestAvailable
                                   ? HyperVReplicaAzureRpRecoveryPointType.LatestProcessed
                                   : HyperVReplicaAzureRpRecoveryPointType.Latest;

                            recoveryPlanHyperVReplicaAzureFailoverInput.RecoveryPointType = recoveryPointType;
                        }
                        recoveryPlanUnplannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                }
                else if (string.Compare(
                        replicationProvider,
                        Constants.InMageAzureV2,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    // Check if the Direction is PrimaryToRecovery.
                    if (this.Direction == Constants.PrimaryToRecovery)
                    {
                        // Set the Recovery Point Types for InMage.
                        var recoveryPointType =
                            this.RecoveryTag ==
                            Constants.RecoveryTagLatestAvailableApplicationConsistent
                                ? InMageV2RpRecoveryPointType.LatestApplicationConsistent
                                : this.RecoveryTag == Constants.RecoveryTagLatestAvailable
                                    ? InMageV2RpRecoveryPointType.LatestProcessed
                                    : InMageV2RpRecoveryPointType.Latest;

                        // Create the InMageAzureV2 Provider specific input.
                        var recoveryPlanInMageAzureV2FailoverInput =
                            new RecoveryPlanInMageAzureV2FailoverInput
                            {
                                RecoveryPointType = recoveryPointType,
                                VaultLocation = "dummy"
                            };

                        // Add the InMageAzureV2 Provider specific input in the Planned Failover Input.
                        recoveryPlanUnplannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanInMageAzureV2FailoverInput);
                    }
                }
                else if (string.Compare(
                        replicationProvider,
                        Constants.InMage,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    // Check if the Direction is RecoveryToPrimary.
                    if (this.Direction == Constants.RecoveryToPrimary)
                    {
                        // Set the Recovery Point Types for InMage.
                        var recoveryPointType =
                            this.RecoveryTag ==
                            Constants.RecoveryTagLatestAvailableApplicationConsistent
                                ? RpInMageRecoveryPointType.LatestTag
                                : RpInMageRecoveryPointType.LatestTime;

                        // Create the InMage Provider specific input.
                        var recoveryPlanInMageFailoverInput = new RecoveryPlanInMageFailoverInput
                        {
                            RecoveryPointType = recoveryPointType
                        };

                        // Add the InMage Provider specific input in the Planned Failover Input.
                        recoveryPlanUnplannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanInMageFailoverInput);
                    }
                }
            }

            var recoveryPlanUnplannedFailoverInput = new RecoveryPlanUnplannedFailoverInput
            {
                Properties = recoveryPlanUnplannedFailoverInputProperties
            };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryUnplannedFailover(
                this.RecoveryPlan.Name,
                recoveryPlanUnplannedFailoverInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local parameters

        /// <summary>
        ///     Gets or sets Name of the PE.
        /// </summary>
        public string protectionEntityName;

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        /// <summary>
        ///     Primary Kek Cert pfx file.
        /// </summary>
        private string primaryKekCertpfx;

        /// <summary>
        ///     Secondary Kek Cert pfx file.
        /// </summary>
        private string secondaryKekCertpfx;

        #endregion local parameters
    }

}

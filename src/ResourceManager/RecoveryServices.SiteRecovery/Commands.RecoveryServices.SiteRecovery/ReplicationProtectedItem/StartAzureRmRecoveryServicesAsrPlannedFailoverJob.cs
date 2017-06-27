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
        "AzureRmRecoveryServicesAsrPlannedFailoverJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject,
        SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRPFO",
        "Start-ASRPlannedFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrPlannedFailoverJob : SiteRecoveryCmdletBase
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
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets Failover direction for the protected Item.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets the Optimize value.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateSet(
            Constants.ForDownTime,
            Constants.ForSynchronization)]
        public string Optimize { get; set; }

        /// <summary>
        ///     Gets or sets the recovery vm creation value.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateSet(
            Constants.Yes,
            Constants.No)]
        public string CreateVmIfNotFound { get; set; }

        /// <summary>
        ///     Gets or sets hyper-V recovery services provider to create vm on.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = false,
            ValueFromPipeline = false)]
        public ASRRecoveryServicesProvider ServicesProvider { get; set; }

        /// <summary>
        ///     Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        ///     Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Protected item or Recovery plan",
                "Start planned failover"))
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
                        this.protectionContainerName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);
                        this.fabricName = Utilities.GetValueFromArmId(
                            this.ReplicationProtectedItem.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);
                        this.StartRPIPlannedFailover();
                        break;
                    case ASRParameterSets.ByRPObject:
                        this.StartRpPlannedFailover();
                        break;
                }
            }
        }

        /// <summary>
        ///     Starts RPI Planned failover.
        /// </summary>
        private void StartRPIPlannedFailover()
        {
            var plannedFailoverInputProperties = new PlannedFailoverInputProperties
            {
                FailoverDirection = this.Direction,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input = new PlannedFailoverInput { Properties = plannedFailoverInputProperties };

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
                        VaultLocation = "dummy"
                    };
                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
                else
                {
                    var failbackInput = new HyperVReplicaAzureFailbackProviderInput
                    {
                        DataSyncOption =
                            this.Optimize == Constants.ForDownTime ? Constants.ForDownTime
                                : Constants.ForSynchronization,
                        RecoveryVmCreationOption = string.Compare(
                                                       this.CreateVmIfNotFound,
                                                       Constants.Yes,
                                                       StringComparison.OrdinalIgnoreCase) ==
                                                   0 ? Constants.CreateVmIfNotFound
                            : Constants.NoAction
                    };

                    if ((string.Compare(
                             this.CreateVmIfNotFound,
                             Constants.Yes,
                             StringComparison.OrdinalIgnoreCase) ==
                         0) &&
                        this.RecoveryServicesClient.GetAzureSiteRecoveryFabric(this.fabricName)
                            .Properties.CustomDetails is HyperVSiteDetails)
                    {
                        if ((this.ServicesProvider == null) ||
                            (string.Compare(
                                 this.ServicesProvider.FabricType,
                                 Constants.HyperVSite) !=
                             0))
                        {
                            throw new InvalidOperationException(
                                Resources.ImproperServerObjectPassedForHyperVFailback);
                        }

                        failbackInput.ProviderIdForAlternateRecovery = this.ServicesProvider.ID;
                    }

                    input.Properties.ProviderSpecificDetails = failbackInput;
                }
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Planned failover.
        /// </summary>
        private void StartRpPlannedFailover()
        {
            // Refresh RP Object
            var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                this.RecoveryPlan.Name);

            var recoveryPlanPlannedFailoverInputProperties =
                new RecoveryPlanPlannedFailoverInputProperties
                {
                    FailoverDirection =
                        this.Direction == PossibleOperationsDirections.PrimaryToRecovery.ToString()
                            ? PossibleOperationsDirections.PrimaryToRecovery
                            : PossibleOperationsDirections.RecoveryToPrimary,
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
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                    else
                    {
                        var recoveryPlanHyperVReplicaAzureFailbackInput =
                            new RecoveryPlanHyperVReplicaAzureFailbackInput
                            {
                                DataSyncOption =
                                    this.Optimize == Constants.ForDownTime
                                        ? DataSyncStatus.ForDownTime
                                        : DataSyncStatus.ForSynchronization,
                                RecoveryVmCreationOption = string.Compare(
                                                               this.CreateVmIfNotFound,
                                                               Constants.Yes,
                                                               StringComparison
                                                                   .OrdinalIgnoreCase) ==
                                                           0 ? AlternateLocationRecoveryOption
                                    .CreateVmIfNotFound : AlternateLocationRecoveryOption.NoAction
                            };
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanHyperVReplicaAzureFailbackInput);
                    }
                }
            }

            var recoveryPlanPlannedFailoverInput = new RecoveryPlanPlannedFailoverInput
            {
                Properties = recoveryPlanPlannedFailoverInputProperties
            };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.RecoveryPlan.Name,
                recoveryPlanPlannedFailoverInput);

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
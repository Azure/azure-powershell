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
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Used to initiate a failover operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrUnplannedFailoverJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject)]
    [Alias("Start-ASRFO",
        "Start-ASRUnplannedFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrUnplannedFailoverJob : SiteRecoveryCmdletBase
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
        [Parameter(Mandatory = true)]
        [ValidateSet(Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets switch parameter. This is required to PerformSourceSideActions.
        /// </summary>
        [Parameter]
        public SwitchParameter PerformSourceSideActions { get; set; }

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
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (!string.IsNullOrEmpty(DataEncryptionPrimaryCertFile))
            {
                var certBytesPrimary = File.ReadAllBytes(DataEncryptionPrimaryCertFile);
                primaryKekCertpfx = Convert.ToBase64String(certBytesPrimary);
            }

            if (!string.IsNullOrEmpty(DataEncryptionSecondaryCertFile))
            {
                var certBytesSecondary = File.ReadAllBytes(DataEncryptionSecondaryCertFile);
                secondaryKekCertpfx = Convert.ToBase64String(certBytesSecondary);
            }

            switch (ParameterSetName)
            {
                case ASRParameterSets.ByRPIObject:
                    protectionContainerName = Utilities.GetValueFromArmId(
                        ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);
                    fabricName = Utilities.GetValueFromArmId(ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationFabrics);
                    StartRPIUnplannedFailover();
                    break;
                case ASRParameterSets.ByRPObject:
                    StartRpUnplannedFailover();
                    break;
            }
        }

        /// <summary>
        ///     Starts RPI Unplanned failover.
        /// </summary>
        private void StartRPIUnplannedFailover()
        {
            var unplannedFailoverInputProperties = new UnplannedFailoverInputProperties
            {
                FailoverDirection = Direction,
                SourceSiteOperations = PerformSourceSideActions ? "Required" : "NotRequired",
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input = new UnplannedFailoverInput {Properties = unplannedFailoverInputProperties};

            if (0 ==
                string.Compare(ReplicationProtectedItem.ReplicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
            {
                if (Direction == Constants.PrimaryToRecovery)
                {
                    var failoverInput = new HyperVReplicaAzureFailoverProviderInput
                    {
                        PrimaryKekCertificatePfx = primaryKekCertpfx,
                        SecondaryKekCertificatePfx = secondaryKekCertpfx,
                        VaultLocation = "dummy"
                    };
                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
            }

            var response = RecoveryServicesClient.StartAzureSiteRecoveryUnplannedFailover(
                fabricName,
                protectionContainerName,
                ReplicationProtectedItem.Name,
                input);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Unplanned failover.
        /// </summary>
        private void StartRpUnplannedFailover()
        {
            // Refresh RP Object
            var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(RecoveryPlan.Name);

            var recoveryPlanUnplannedFailoverInputProperties =
                new RecoveryPlanUnplannedFailoverInputProperties
                {
                    FailoverDirection =
                        Direction == PossibleOperationsDirections.PrimaryToRecovery.ToString()
                            ? PossibleOperationsDirections.PrimaryToRecovery
                            : PossibleOperationsDirections.RecoveryToPrimary,
                    SourceSiteOperations = PerformSourceSideActions ? SourceSiteOperations.Required
                        : SourceSiteOperations.NotRequired, //Required|NotRequired
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
                };

            foreach (var replicationProvider in rp.Properties.ReplicationProviders)
            {
                if (0 ==
                    string.Compare(replicationProvider,
                        Constants.HyperVReplicaAzure,
                        StringComparison.OrdinalIgnoreCase))
                {
                    if (Direction == Constants.PrimaryToRecovery)
                    {
                        var recoveryPlanHyperVReplicaAzureFailoverInput =
                            new RecoveryPlanHyperVReplicaAzureFailoverInput
                            {
                                PrimaryKekCertificatePfx = primaryKekCertpfx,
                                SecondaryKekCertificatePfx = secondaryKekCertpfx,
                                VaultLocation = "dummy"
                            };
                        recoveryPlanUnplannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                }
            }

            var recoveryPlanUnplannedFailoverInput = new RecoveryPlanUnplannedFailoverInput
            {
                Properties = recoveryPlanUnplannedFailoverInputProperties
            };

            var response = RecoveryServicesClient.StartAzureSiteRecoveryUnplannedFailover(
                RecoveryPlan.Name,
                recoveryPlanUnplannedFailoverInput);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
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
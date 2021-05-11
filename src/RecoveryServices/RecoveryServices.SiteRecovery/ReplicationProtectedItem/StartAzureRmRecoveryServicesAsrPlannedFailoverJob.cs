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
using System.ComponentModel;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Starts a planned failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrPlannedFailoverJob", DefaultParameterSetName = ASRParameterSets.ByRPIObject, SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRPFO",
        "Start-ASRPlannedFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrPlannedFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the recovery plan object to be failed over.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        ///     Gets or sets replication protected item object to be failed over.
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
        ///     Gets or sets the direction of the failover.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets what to optimize for.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateSet(
            Constants.ForDownTime,
            Constants.ForSynchronization)]
        public string Optimize { get; set; }

        /// <summary>
        ///     Gets or sets create the virtual machine if not found while failing back to the primary region
        ///     (used in alternate location recovery.)
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateSet(
            Constants.Yes,
            Constants.No)]
        public string CreateVmIfNotFound { get; set; }

        /// <summary>
        ///     Gets or sets identifies the host to on which to create the virtual machine while failing 
        ///     over to an alternate location by specifying the ASR services provider object corresponding 
        ///     to the ASR services provider running on the host.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObject,
            Mandatory = false,
            ValueFromPipeline = false)]
        public ASRRecoveryServicesProvider ServicesProvider { get; set; }

        /// <summary>
        ///     Gets or sets data encryption primary certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        ///     Gets or sets Data encryption secondary certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = false)]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        /// <summary>
        ///     Gets or sets recovery point type.
        /// </summary>
        [Parameter(
           ParameterSetName = ASRParameterSets.ByRPIObjectWithRecoveryTag,
           Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.RecoveryTagApplicationConsistent,
            Constants.RecoveryTagCrashConsistent)]
        public string RecoveryTag { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether multi VM sync enabled VMs should use
        ///     multi VM sync points for planned failover.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [DefaultValue(Constants.Disable)]
        [ValidateSet(Constants.Enable, Constants.Disable)]
        public string MultiVmSyncPoint { get; set; }

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
                    case ASRParameterSets.ByRPIObjectWithRecoveryTag:
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
                ProviderSpecificDetails = new PlannedFailoverProviderSpecificFailoverInput()
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
                    var failoverInput = new HyperVReplicaAzurePlannedFailoverProviderInput
                    {
                        PrimaryKekCertificatePfx = this.primaryKekCertpfx,
                        SecondaryKekCertificatePfx = this.secondaryKekCertpfx
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
            else if (0 ==
                string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageRcmFailback,
                    StringComparison.OrdinalIgnoreCase))
            {
                var recoveryPointType =
                    this.RecoveryTag == Constants.RecoveryTagCrashConsistent
                        ? InMageRcmFailbackRecoveryPointType.CrashConsistent
                        : InMageRcmFailbackRecoveryPointType.ApplicationConsistent;
                
                // Validate the direction as RecoveryToPrimary.
                if (this.Direction == Constants.RecoveryToPrimary)
                {
                    var failoverInput = new InMageRcmFailbackPlannedFailoverProviderInput
                    {
                        RecoveryPointType = recoveryPointType
                    };
                    input.Properties.ProviderSpecificDetails = failoverInput;
                    input.Properties.FailoverDirection = null;
                }
                else
                {
                    // PrimaryToRecovery direction is invalid for InMageRcmFailback.
                    new ArgumentException(Resources.InvalidDirectionForAzureToVMWare);
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0 ||
                string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) ==
                0 ||
                string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageRcm,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderForPlannedFailover,
                        this.ReplicationProtectedItem.ReplicationProvider));
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
                                SecondaryKekCertificatePfx = this.secondaryKekCertpfx
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
                else if (0 ==
                    string.Compare(
                        replicationProvider,
                        Constants.InMageRcmFailback,
                        StringComparison.OrdinalIgnoreCase))
                {
                    this.MultiVmSyncPoint =
                        this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.MultiVmSyncPoint))
                            ? this.MultiVmSyncPoint
                            : Constants.Enable;
                    var recoveryPointType =
                        this.RecoveryTag == Constants.RecoveryTagApplicationConsistent
                            ? InMageRcmFailbackRecoveryPointType.ApplicationConsistent
                            : InMageRcmFailbackRecoveryPointType.CrashConsistent;

                    // Validate the direction as RecoveryToPrimary.
                    if (this.Direction == Constants.RecoveryToPrimary)
                    {
                        var recoveryPlanFailoverInput =
                            new RecoveryPlanInMageRcmFailbackFailoverInput
                            {
                                RecoveryPointType = recoveryPointType,
                                UseMultiVmSyncPoint =
                                    this.MultiVmSyncPoint == Constants.Enable ?
                                        Constants.True :
                                        Constants.False
                            };
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanFailoverInput);
                    }
                    else
                    {
                        // PrimaryToRecovery direction is invalid for InMageRcmFailback.
                        new ArgumentException(Resources.InvalidDirectionForAzureToVMWare);
                    }
                }
                else if (string.Compare(
                        replicationProvider,
                        Constants.InMageAzureV2,
                        StringComparison.OrdinalIgnoreCase) ==
                    0 ||
                    string.Compare(
                        replicationProvider,
                        Constants.InMage,
                        StringComparison.OrdinalIgnoreCase) ==
                    0 ||
                    string.Compare(
                        replicationProvider,
                        Constants.InMageRcm,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.UnsupportedReplicationProviderForPlannedFailover,
                            replicationProvider));
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
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

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

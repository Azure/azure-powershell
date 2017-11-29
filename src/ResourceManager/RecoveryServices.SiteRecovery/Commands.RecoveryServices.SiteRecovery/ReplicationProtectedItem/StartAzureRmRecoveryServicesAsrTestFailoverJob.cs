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
    ///     Used to initiate a Test failover operation.
    /// </summary>
    [Cmdlet(
        VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrTestFailoverJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject,
        SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRTFO",
        "Start-ASRTestFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrTestFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId,
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
            ParameterSetName = ASRParameterSets.ByRPIObjectWithVMNetwork,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObjectWithAzureVMNetworkId,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets Network.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObjectWithVMNetwork,
            Mandatory = true)]
        public ASRNetwork VMNetwork { get; set; }

        /// <summary>
        ///     Gets or sets Network.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObjectWithAzureVMNetworkId,
            Mandatory = true)]
        public string AzureVMNetworkId { get; set; }

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
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObjectWithVMNetwork,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPIObjectWithAzureVMNetworkId,
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
            ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.RecoveryTagLatest,
            Constants.RecoveryTagLatestAvailable,
            Constants.RecoveryTagLatestAvailableApplicationConsistent)]
        [DefaultValue(Constants.RecoveryTagLatestAvailable)]
        public string RecoveryTag { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Protected item or Recovery plan",
                "Start test failover"))
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
                    case ASRParameterSets.ByRPIObjectWithVMNetwork:
                    case ASRParameterSets.ByRPObjectWithVMNetwork:
                        this.networkType = "VmNetworkAsInput";
                        this.networkId = this.VMNetwork.ID;
                        break;
                    case ASRParameterSets.ByRPIObjectWithAzureVMNetworkId:
                    case ASRParameterSets.ByRPObjectWithAzureVMNetworkId:
                        this.networkType = "VmNetworkAsInput";
                        this.networkId = this.AzureVMNetworkId;
                        break;
                    case ASRParameterSets.ByRPIObject:
                    case ASRParameterSets.ByRPObject:
                        this.networkType = "NoNetworkAttachAsInput";
                        this.networkId = null;
                        break;
                }

                if ((this.ParameterSetName == ASRParameterSets.ByRPObject) ||
                    (this.ParameterSetName == ASRParameterSets.ByRPObjectWithVMNetwork) ||
                    (this.ParameterSetName == ASRParameterSets.ByRPObjectWithAzureVMNetworkId))
                {
                    this.StartRpTestFailover();
                }
                else
                {
                    this.protectionContainerName = Utilities.GetValueFromArmId(
                        this.ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);
                    this.fabricName = Utilities.GetValueFromArmId(
                        this.ReplicationProtectedItem.ID,
                        ARMResourceTypeConstants.ReplicationFabrics);
                    this.StartRPITestFailover();
                }
            }
        }

        /// <summary>
        ///     Starts RPI Test failover.
        /// </summary>
        private void StartRPITestFailover()
        {
            var testFailoverInputProperties = new TestFailoverInputProperties
            {
                FailoverDirection = this.Direction,
                NetworkId = this.networkId,
                NetworkType = this.networkType,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput(),
                SkipTestFailoverCleanup = bool.TrueString
            };

            var input = new TestFailoverInput { Properties = testFailoverInputProperties };

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
                        SecondaryKekCertificatePfx = this.secondaryKekCertpfx
                    };

                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
                else
                {
                    new ArgumentException(
                        Resources
                            .UnsupportedDirectionForTFO); // Throw Unsupported Direction Exception
                }
            }
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMageAzureV2,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
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
                            Resources.UnsupportedReplicationProtectionActionForTestFailover,
                            this.ReplicationProtectedItem.ReplicationProvider));
                }

                // Validate the Direction as PrimaryToRecovery.
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    // Set the InMageAzureV2 Provider specific input in the Test Failover Input.
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
            else if (string.Compare(
                    this.ReplicationProtectedItem.ReplicationProvider,
                    Constants.InMage,
                    StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderForTestFailover,
                        this.ReplicationProtectedItem.ReplicationProvider));
            }

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Test failover.
        /// </summary>
        private void StartRpTestFailover()
        {
            // Refresh RP Object
            var rp = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(
                this.RecoveryPlan.Name);

            var recoveryPlanTestFailoverInputProperties =
                new RecoveryPlanTestFailoverInputProperties
                {
                    FailoverDirection =
                        this.Direction == PossibleOperationsDirections.PrimaryToRecovery.ToString()
                            ? PossibleOperationsDirections.PrimaryToRecovery
                            : PossibleOperationsDirections.RecoveryToPrimary,
                    NetworkId = this.networkId,
                    NetworkType = this.networkType,
                    ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>(),
                    SkipTestFailoverCleanup = bool.TrueString
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
                        recoveryPlanTestFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                    else
                    {
                        throw new ArgumentException(
                            Resources
                                .UnsupportedDirectionForTFO); // Throw Unsupported Direction Exception
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
                                : this.RecoveryTag == Constants.RecoveryTagLatest
                                    ? InMageV2RpRecoveryPointType.Latest
                                    : InMageV2RpRecoveryPointType.LatestProcessed;

                        // Create the InMageAzureV2 Provider specific input.
                        var recoveryPlanInMageAzureV2FailoverInput =
                            new RecoveryPlanInMageAzureV2FailoverInput
                            {
                                RecoveryPointType = recoveryPointType,
                                VaultLocation = "dummy"
                            };

                        // Add the InMageAzureV2 Provider specific input in the Test Failover Input.
                        recoveryPlanTestFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanInMageAzureV2FailoverInput);
                    }
                }
                else if (string.Compare(
                        replicationProvider,
                        Constants.InMage,
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.UnsupportedReplicationProviderForTestFailover,
                            this.ReplicationProtectedItem.ReplicationProvider));
                }
            }

            var recoveryPlanTestFailoverInput =
                new RecoveryPlanTestFailoverInput
                {
                    Properties = recoveryPlanTestFailoverInputProperties
                };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                this.RecoveryPlan.Name,
                recoveryPlanTestFailoverInput);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        #region local parameters

        /// <summary>
        ///     Network ID.
        /// </summary>
        private string networkId = string.Empty; // Network ARM Id

        /// <summary>
        ///     Network Type (Logical network or VM network).
        /// </summary>
        private string networkType =
            string.Empty; // LogicalNetworkAsInput|VmNetworkAsInput|NoNetworkAttachAsInput

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

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
    ///     Used to initiate a commit operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start,
        "AzureRmRecoveryServicesAsrTestFailoverJob",
        DefaultParameterSetName = ASRParameterSets.ByRPIObject)]
    [Alias("Start-ASRTFO",
        "Start-ASRTestFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrTestFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId,
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
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObjectWithVMNetwork,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObjectWithAzureVMNetworkId,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        ///     Gets or sets failover direction for the recovery plan.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithVMNetwork,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObjectWithVMNetwork,
            Mandatory = true)]
        public ASRNetwork VMNetwork { get; set; }

        /// <summary>
        ///     Gets or sets Network.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObjectWithAzureVMNetworkId,
            Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByRPIObjectWithAzureVMNetworkId,
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
                case ASRParameterSets.ByRPIObjectWithVMNetwork:
                case ASRParameterSets.ByRPObjectWithVMNetwork:
                    networkType = "VmNetworkAsInput";
                    networkId = VMNetwork.ID;
                    break;
                case ASRParameterSets.ByRPIObjectWithAzureVMNetworkId:
                case ASRParameterSets.ByRPObjectWithAzureVMNetworkId:
                    networkType = "VmNetworkAsInput";
                    networkId = AzureVMNetworkId;
                    break;
                case ASRParameterSets.ByRPIObject:
                case ASRParameterSets.ByRPObject:
                    networkType = "NoNetworkAttachAsInput";
                    networkId = null;
                    break;
            }

            if (ParameterSetName == ASRParameterSets.ByRPObject ||
                ParameterSetName == ASRParameterSets.ByRPObjectWithVMNetwork ||
                ParameterSetName == ASRParameterSets.ByRPObjectWithAzureVMNetworkId)
            {
                StartRpTestFailover();
            }
            else
            {
                protectionContainerName = Utilities.GetValueFromArmId(ReplicationProtectedItem.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);
                fabricName = Utilities.GetValueFromArmId(ReplicationProtectedItem.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);
                StartRPITestFailover();
            }
        }

        /// <summary>
        ///     Starts RPI Test failover.
        /// </summary>
        private void StartRPITestFailover()
        {
            var testFailoverInputProperties = new TestFailoverInputProperties
            {
                FailoverDirection = Direction,
                NetworkId = networkId,
                NetworkType = networkType,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input = new TestFailoverInput {Properties = testFailoverInputProperties};

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
                        SecondaryKekCertificatePfx = secondaryKekCertpfx
                    };

                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
                else
                {
                    new ArgumentException(Resources
                        .UnsupportedDirectionForTFO); // Throw Unsupported Direction Exception
                }
            }

            var response = RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(fabricName,
                protectionContainerName,
                ReplicationProtectedItem.Name,
                input);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///     Starts RP Test failover.
        /// </summary>
        private void StartRpTestFailover()
        {
            // Refresh RP Object
            var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(RecoveryPlan.Name);

            var recoveryPlanTestFailoverInputProperties =
                new RecoveryPlanTestFailoverInputProperties
                {
                    FailoverDirection =
                        Direction == PossibleOperationsDirections.PrimaryToRecovery.ToString()
                            ? PossibleOperationsDirections.PrimaryToRecovery
                            : PossibleOperationsDirections.RecoveryToPrimary,
                    NetworkId = networkId,
                    NetworkType = networkType,
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
                        recoveryPlanTestFailoverInputProperties.ProviderSpecificDetails.Add(
                            recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                    else
                    {
                        throw new ArgumentException(Resources
                            .UnsupportedDirectionForTFO); // Throw Unsupported Direction Exception
                    }
                }
            }

            var recoveryPlanTestFailoverInput =
                new RecoveryPlanTestFailoverInput
                {
                    Properties = recoveryPlanTestFailoverInputProperties
                };

            var response = RecoveryServicesClient.StartAzureSiteRecoveryTestFailover(
                RecoveryPlan.Name,
                recoveryPlanTestFailoverInput);

            var jobResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient
                    .GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse));
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
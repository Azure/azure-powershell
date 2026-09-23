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

using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Job = Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models.Job;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Creates an Azure Site Recovery Replication Protection Cluster.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectionCluster", DefaultParameterSetName = ASRParameterSets.AzureToAzure,SupportsShouldProcess = true)]
    [Alias("New-ASRReplicationProtectionCluster")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrReplicationProtectionCluster : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch parameter specifying that the protection cluster being created will be used 
        ///    to replicated Azure virtual machines between two Azure regions.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        public SwitchParameter AzureToAzure { get; set; }

        /// <summary>
        ///     Gets or sets the name of the Replication Protection Cluster.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        /// <summary>
        ///     Gets or sets the ASR protection container mapping object corresponding to
        ///     the replication policy to be used for replication..
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.AzureToAzure,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainerMapping ProtectionContainerMapping { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.New))
            {
                var policy = this.RecoveryServicesClient.GetAzureSiteRecoveryPolicy(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.PolicyId,
                        ARMResourceTypeConstants.ReplicationPolicies));
                var policyInstanceType = policy.Properties.ProviderSpecificDetails;

                var replicationProtectionClusterInput =
                    new ReplicationClusterProviderSpecificSettings();

                var inputProperties = new ReplicationProtectionClusterProperties
                {
                    PolicyId = this.ProtectionContainerMapping.PolicyId,
                    RecoveryContainerId = this.ProtectionContainerMapping.TargetProtectionContainerId,
                    ProviderSpecificDetails = replicationProtectionClusterInput
                };

                var input = new ReplicationProtectionCluster { Properties = inputProperties };

                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.AzureToAzure:
                        if (!(policyInstanceType is A2APolicyDetails))
                        {
                            throw new PSArgumentException(
                                string.Format(
                                    Properties.Resources.ContainerMappingParameterSetMismatch,
                                    this.ProtectionContainerMapping.Name,
                                    policyInstanceType));
                        }
                        input.Properties.ProviderSpecificDetails = new A2AReplicationProtectionClusterDetails();
                        break;
                }

                this.response = this.RecoveryServicesClient.CreateProtectionCluster(
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.ProtectionContainerMapping.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.Name,
                    input);

                this.jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(this.response.Location));

                this.WriteObject(new ASRJob(this.jobResponse));
            }
        }

        private Job jobResponse;

        /// <summary>
        ///     Job response.
        /// </summary>
        private PSSiteRecoveryLongRunningOperation response;
    }
}

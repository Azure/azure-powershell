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

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Starts cluster replication resynchronization.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterResynchronizeReplicationJob",DefaultParameterSetName = ASRParameterSets.Default,SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRClusterResynchronizeReplicationJob",
        "Start-ASRClusterResyncJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrClusterResynchronizeReplicationJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets resource Id of replication protection cluster to resynchronize.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true
            )]
        public string ResourceId { get; set; }

        /// <summary>
        ///     Gets or sets replication protection cluster to resynchronize replication for.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectionCluster ReplicationProtectionCluster { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.Default:

                    this.fabricName = Utilities.GetValueFromArmId(
                        this.ReplicationProtectionCluster.ID,
                        ARMResourceTypeConstants.ReplicationFabrics);

                    this.protectionContainerName = Utilities.GetValueFromArmId(
                        this.ReplicationProtectionCluster.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);

                    this.rpcName = this.ReplicationProtectionCluster.Name;

                    break;
                case ASRParameterSets.ByResourceId:

                    this.fabricName = Utilities.GetValueFromArmId(
                        this.ResourceId,
                        ARMResourceTypeConstants.ReplicationFabrics);

                    this.protectionContainerName = Utilities.GetValueFromArmId(
                        this.ResourceId,
                        ARMResourceTypeConstants.ReplicationProtectionContainers);

                    this.rpcName = Utilities.GetValueFromArmId(
                        this.ResourceId,
                        ARMResourceTypeConstants.ReplicationProtectedItems);

                    break;
            }

            if (this.ShouldProcess(
                this.rpcName,
                "Resyncronize replicated item "))
            {
                
                // Resync Replication of the Protection Cluster.
                var response = this.RecoveryServicesClient.StartAzureSiteRecoveryClusterResynchronizeReplication(
                    this.fabricName,
                    this.protectionContainerName,
                    this.rpcName);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails
                    (PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }

        #region Private Parameters

        /// <summary>
        ///     Gets or sets Name of the Fabric.
        /// </summary>
        private string fabricName;

        /// <summary>
        ///     Gets or sets Name of the Protection Container.
        /// </summary>
        private string protectionContainerName;

        /// <summary>
        ///     Gets or sets Name of the RPC.
        /// </summary>
        private string rpcName;

        #endregion Local Parameters
    }
}

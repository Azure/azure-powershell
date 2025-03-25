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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Starts the cluster commit failover action for a site recovery object.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterCommitFailoverJob", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias(
        "Start-ASRClusterCommitFailover",
        "Start-ASRClusterCommitFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrClusterCommitFailoverJob : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets an ASR replication protection cluster.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
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

            if (this.ShouldProcess(
                "Protected cluster",
                "Commit failover"))
            {
                this.protectionContainerName = Utilities.GetValueFromArmId(
                     this.ReplicationProtectionCluster.ID,
                     ARMResourceTypeConstants.ReplicationProtectionContainers);
              
                this.fabricName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                Logger.Instance.WriteVerbose(
                    String.Format(
                        "Start Cluster Commit Failover for Cluster: {0} Protection Container Name: {1} Fabric Name: {2}",
                        this.ReplicationProtectionCluster.Name,
                        this.protectionContainerName,
                        this.fabricName));
                this.StartRPCCommit();
              
            }
        }

        /// <summary>
        ///    Starts the cluster commit failover action.
        /// </summary>
        private void StartRPCCommit()
        {
            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryClusterCommitFailover(
                this.fabricName,
                this.protectionContainerName,
                ReplicationProtectionCluster.Name);

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
        private string fabricName;

        #endregion local parameters
    }
}

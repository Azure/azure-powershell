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

using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Starts the cluster test failover cleanup operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterTestFailoverCleanupJob", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Start-ASRClusterTestFailoverCleanupJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrClusterTestFailoverCleanupJob : SiteRecoveryCmdletBase
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
        ///     Gets or sets user Comment for Test Failover.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = false)]
        public string Comment { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (this.ShouldProcess(
                "Protected cluster",
                "Cleanup Test Failover"))
            {
                protectionContainerName = Utilities.GetValueFromArmId(
                            ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);

                fabricName = Utilities.GetValueFromArmId(
                            ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);

                StartRPCTestFailoverCleanup();
            }
        }

        /// <summary>
        ///    Starts the cluster test failover cleanup operation.
        /// </summary>
        private void StartRPCTestFailoverCleanup()
        {
            var clusterTestFailoverCleanupInputProperties = new ClusterTestFailoverCleanupInputProperties
            {
                Comments = Comment == null ? "" : Comment
            };

            var input = new ClusterTestFailoverCleanupInput
            {
                Properties = clusterTestFailoverCleanupInputProperties
            };

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryClusterTestFailoverCleanup(
                fabricName,
                protectionContainerName,
                ReplicationProtectionCluster.Name,
                input);

            var jobResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(response.Location));

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

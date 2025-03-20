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

using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Changes a recovery point for a failed over protection cluster before committing the failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrApplyClusterRecoveryPoint", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Start-ASRApplyClusterRecoveryPoint")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrApplyClusterRecoveryPoint : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the cluster recovery point object corresponding to the recovery point to be applied.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false,
            HelpMessage = "Specifies the recovery point for the cluster.")]
        [ValidateNotNullOrEmpty]
        public ASRClusterRecoveryPoint ClusterRecoveryPoint { get; set; }

        /// <summary>
        ///     Gets or sets replication protected item object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectionCluster ReplicationProtectionCluster { get; set; }

        /// <summary>
        ///    Gets or sets individual node recovery points corresponding to the recovery point to be applied.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false,
            HelpMessage = "Specifies the recovery points for the nodes which are not part of cluster recovery point.")]
        [ValidateNotNullOrEmpty]
        public List<string> ListNodeRecoveryPoint { get; set; }

        /// <summary>
        ///    Switch parameter to use the latest processed recovery point for failover.
        /// </summary>
        [Parameter(
            HelpMessage = "Fetch the latest processed recovery points if not passed for cluster or any individual node.")]
        [Alias("LatestProcessedRecoveryPoints")]
        public SwitchParameter LatestProcessedRecoveryPoint { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.ReplicationProtectionCluster.Name,
                "Apply recovery point"))
            {
                this.fabricName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                this.protectionContainerName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);

                Logger.Instance.WriteVerbose(
                    String.Format(
                        "Start Apply Cluster Recovery Point for Cluster: {0} Protection Container Name: {1} Fabric Name: {2}",
                        this.ReplicationProtectionCluster.Name,
                        this.protectionContainerName,
                        this.fabricName));

                this.StartRPCApplyRecoveryPoint();
            }
        }

        /// <summary>
        ///    Starts Cluster Apply Recovery Point operation.
        /// </summary>
        private void StartRPCApplyRecoveryPoint()
        {
            if (!string.Equals(
                    this.ReplicationProtectionCluster.ReplicationProvider,
                    Constants.A2A,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderForApplyRecoveryPoint,
                        this.ReplicationProtectionCluster.ReplicationProvider));
            }

            var applyClusterRecoveryPointInputProperties = new ApplyClusterRecoveryPointInputProperties
            {
                ProviderSpecificDetails = new ApplyClusterRecoveryPointProviderSpecificInput()
            };

            var clusterAndNodeRecoveryPoint = Utilities.ValidateAndGetClusterAndNodeRecoveryPoint(
                this.RecoveryServicesClient,
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectionCluster,
                this.ReplicationProtectionCluster.Name,
                this.ClusterRecoveryPoint,
                this.ListNodeRecoveryPoint,
                this.LatestProcessedRecoveryPoint);

            applyClusterRecoveryPointInputProperties.ClusterRecoveryPointId = clusterAndNodeRecoveryPoint.ClusterRecoveryPoint.ID;
            applyClusterRecoveryPointInputProperties.IndividualNodeRecoveryPoints = clusterAndNodeRecoveryPoint.ListNodeRecoveryPoint; 

            var input = new ApplyClusterRecoveryPointInput { Properties = applyClusterRecoveryPointInputProperties };

            input.Properties.ProviderSpecificDetails = new A2AApplyClusterRecoveryPointInput();

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryApplyClusterRecoveryPoint(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectionCluster.Name,
                input);

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

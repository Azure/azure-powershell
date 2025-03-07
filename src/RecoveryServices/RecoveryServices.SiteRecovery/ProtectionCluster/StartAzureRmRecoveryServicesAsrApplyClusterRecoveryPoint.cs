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
using System.Linq;
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
            Mandatory = false)]
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
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public List<string> NodeRecoveryPoints { get; set; }

        /// <summary>
        ///    Switch parameter to use the latest processed recovery point for failover.
        /// </summary>
        [Parameter]
        [Alias("LatestProcessedRecoveryPoint")]
        public SwitchParameter LatestProcessedRecoveryPoints { get; set; }

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
                        Resources.UnsupportedReplicationProviderForTestFailover,
                        this.ReplicationProtectionCluster.ReplicationProvider));
            }

            var applyClusterRecoveryPointInputProperties = new ApplyClusterRecoveryPointInputProperties
            {
                ProviderSpecificDetails = new ApplyClusterRecoveryPointProviderSpecificInput()
            };

            if (this.LatestProcessedRecoveryPoints && this.ClusterRecoveryPoint == null)
            {
                // If LatestProcessedRecoveryPoints flag is passed with no ClusterRecoveryPoint, get latest processed ClusterRecoveryPoint.
                this.ClusterRecoveryPoint = Utilities.GetClusterRecoveryPoint(
                    this.RecoveryServicesClient,
                    this.fabricName,
                    this.protectionContainerName,
                    this.ReplicationProtectionCluster.Name);
            }

            if (this.ClusterRecoveryPoint == null)
            {
                // If neither ClusterRecoveryPoint is not passed nor LatestProcessedRecoveryPoints flag is passed.
                throw new InvalidOperationException(
                    Resources.NeitherClusterRecoveryPointNorLatestProcessRecoveryPointPassed);
            }

            if (this.NodeRecoveryPoints == null)
            {
                this.NodeRecoveryPoints = new List<string>();
            }

            // Get the list of nodes present in cluster recovery point.
            this.nodesPresentInClusterRecoveryPoint = new HashSet<string>(
                this.ClusterRecoveryPoint.Nodes.Select(node => Utilities.GetValueFromArmId(
                    node,
                    ARMResourceTypeConstants.ReplicationProtectedItems)),
                StringComparer.OrdinalIgnoreCase);

            // Validate whether the node recovery points passed are not part of ClusterRecoveryPoint.
            Utilities.ValidateNodeRecoveryPoints(
                this.RecoveryServicesClient,
                out this.nodesPresentInNodeRecoveryPoints,
                this.nodesPresentInClusterRecoveryPoint,
                this.NodeRecoveryPoints,
                this.fabricName,
                this.protectionContainerName);

            if (this.LatestProcessedRecoveryPoints)
            {
                // If LatestProcessedRecoveryPoints flag is passed, get the latest processed NodeRecoveryPoints which are also not being part of passed NodeRecoveryPoints.
                this.NodeRecoveryPoints.AddRange(Utilities.UpdateNodeRecoveryPoints(
                    this.RecoveryServicesClient,
                    this.ReplicationProtectionCluster,
                    this.nodesPresentInClusterRecoveryPoint,
                    this.nodesPresentInNodeRecoveryPoints,
                    this.fabricName,
                    this.protectionContainerName));
            }

            applyClusterRecoveryPointInputProperties.ClusterRecoveryPointId = this.ClusterRecoveryPoint.ID;
            applyClusterRecoveryPointInputProperties.IndividualNodeRecoveryPoints = this.NodeRecoveryPoints; 

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

        /// <summary>
        ///    Gets or sets the list of individual node recovery points.
        /// </summary>
        private HashSet<string> nodesPresentInClusterRecoveryPoint;

        /// <summary>
        ///     Gets or sets the list of nodes present in nodes recovery points.
        /// </summary>
        private HashSet<string> nodesPresentInNodeRecoveryPoints;

        #endregion local parameters
    }
}

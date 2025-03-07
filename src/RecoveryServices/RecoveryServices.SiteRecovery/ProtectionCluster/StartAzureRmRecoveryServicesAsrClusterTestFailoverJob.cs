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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Starts a test failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterTestFailoverJob", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Start-ASRClusterTestFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrClusterTestFailoverJob : SiteRecoveryCmdletBase
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
        ///     Gets or sets the failover direction.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(
            Constants.PrimaryToRecovery,
            Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        ///     Gets or sets a custom clster recovery point to test failover the protected cluster to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public ASRClusterRecoveryPoint ClusterRecoveryPoint { get; set; }

        /// <summary>
        ///    Gets or sets the list of individual node recovery points.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false)]
        public List<string> NodeRecoveryPoints { get; set; }

        /// <summary>
        ///    Switch parameter to use the latest processed recovery point for failover.
        /// </summary>
        [Parameter]
        [Alias("LatestProcessedRecoveryPoint")]
        public SwitchParameter LatestProcessedRecoveryPoints { get; set; }

        /// <summary>
        ///     Gets or sets the Azure virtual network ID to connect the test fail over virtual machine(s) to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true)]
        public string AzureVMNetworkId { get; set; }


        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (ShouldProcess(
                "Protected cluster",
                "Start test failover"))
            {
                protectionContainerName = Utilities.GetValueFromArmId(
                            ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers);

                fabricName = Utilities.GetValueFromArmId(
                            ReplicationProtectionCluster.ID,
                            ARMResourceTypeConstants.ReplicationFabrics);

                StartRPCTestFailover();
            }
        }

        /// <summary>
        ///     Starts replication protection clustrer test failover.
        /// </summary>
        private void StartRPCTestFailover()
        {
            if (!string.Equals(
                    ReplicationProtectionCluster.ReplicationProvider,
                    Constants.A2A,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProviderForTestFailover,
                        this.ReplicationProtectionCluster.ReplicationProvider));
            }

            var clusterTestFailoverInputProperties = new ClusterTestFailoverInputProperties
            {
                FailoverDirection = Direction,
                NetworkType = "VmNetworkAsInput",
                NetworkId = AzureVMNetworkId,
                ProviderSpecificDetails = new ClusterTestFailoverProviderSpecificInput()
            };

            var input =
                new ClusterTestFailoverInput { Properties = clusterTestFailoverInputProperties };

            if (LatestProcessedRecoveryPoints && ClusterRecoveryPoint == null)
            {
                ClusterRecoveryPoint = GetClusterRecoveryPoint();
            }

            if (ClusterRecoveryPoint == null)
            {
                throw new InvalidOperationException(
                    Resources.NeitherClusterRecoveryPointNorLatestProcessRecoveryPointPassed);
            }

            if (NodeRecoveryPoints == null)
            {
                NodeRecoveryPoints = new List<string>();
            }

            nodesPresentInClusterRecoveryPoint = new HashSet<string>(
                ClusterRecoveryPoint.Nodes,
                StringComparer.OrdinalIgnoreCase);

            ValidateNodeRecoveryPoints();

            if (LatestProcessedRecoveryPoints)
            {
                NodeRecoveryPoints = UpdateNodeRecoveryPoints();
            }
            var failoverInput = new A2AClusterTestFailoverInput
            {
                ClusterRecoveryPointId = ClusterRecoveryPoint.ID,
                IndividualNodeRecoveryPoints = NodeRecoveryPoints
            };

            input.Properties.ProviderSpecificDetails = failoverInput;

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryClusterTestFailover(
                fabricName,
                protectionContainerName,
                this.ReplicationProtectionCluster.Name,
                input);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
            PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }

        /// <summary>
        ///    Validate the node recovery points.
        /// </summary>
        private void ValidateNodeRecoveryPoints()
        {
            var invalidNodeId = NodeRecoveryPoints
                .Select(nodeRecoveryPoint => Utilities.RemoveValueFromArmIdAfterKey(
                    nodeRecoveryPoint,
                    ARMResourceTypeConstants.RecoveryPoints))
                .FirstOrDefault(nodeId =>
                    nodesPresentInClusterRecoveryPoint.Contains(nodeId));

            if (invalidNodeId != null)
            {
                var friendlyName = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        fabricName,
                        protectionContainerName,
                        Utilities.GetValueFromArmId(
                            invalidNodeId,
                            ARMResourceTypeConstants.ReplicationProtectedItems))
                    .Properties
                    .FriendlyName;
                
                throw new InvalidOperationException(
                    string.Format(
                        Resources.WrongIndividualNodeRecoveryPointPassed,
                        friendlyName));
            }
        }

        /// <summary>
        ///    Get the cluster recovery point.
        /// </summary>
        /// <returns></returns>
        private ASRClusterRecoveryPoint GetClusterRecoveryPoint()
        {
            var clusterRecoveryPoints = this.RecoveryServicesClient
                .GetAzureSiteRecoveryClusterRecoveryPoint(
                    fabricName,
                    protectionContainerName,
                    ReplicationProtectionCluster.Name);

            if (!clusterRecoveryPoints.Any())
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ClusterRecoveryPointNotAvailable,
                        ReplicationProtectionCluster.Name));
            }

            return new ASRClusterRecoveryPoint(
                clusterRecoveryPoints.OrderByDescending(rp =>
                    rp.Properties.RecoveryPointTime).First());
        }

        /// <summary>
        ///     Update Node Recovery Points.
        /// </summary>
        /// <returns> List of node recovery points.</returns>
        private List<string> UpdateNodeRecoveryPoints()
        {
            List<string> clusterProtectedItemIds = ReplicationProtectionCluster.ClusterProtectedItemIds.ToList();

            List<string> nodesNotPresentInClusterRecoveryPoints = clusterProtectedItemIds
                .Where(clusterProtectedItemId => !nodesPresentInClusterRecoveryPoint.Contains(clusterProtectedItemId))
                .ToList();

            // get node recovery points
            ConcurrentBag<string> nodeRecoveryPoints = new ConcurrentBag<string>();
            Parallel.ForEach(
                nodesNotPresentInClusterRecoveryPoints,
                new ParallelOptions { MaxDegreeOfParallelism = 10 },
                node =>
                {
                    List<RecoveryPoint> recoveryPoints = this.RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPoint(
                    fabricName,
                    protectionContainerName,
                    Utilities.GetValueFromArmId(
                        node,
                        ARMResourceTypeConstants.ReplicationProtectedItems));

                    var sortedRecoveryPoints = recoveryPoints.OrderByDescending(rp => rp.Properties.RecoveryPointTime).ToList();

                    nodeRecoveryPoints.Add(sortedRecoveryPoints[0].Id);
                });


            List<string> nodeRecoveryPointsList = nodeRecoveryPoints.ToList();
            return nodeRecoveryPointsList;
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

        #endregion local parameters
    }

}
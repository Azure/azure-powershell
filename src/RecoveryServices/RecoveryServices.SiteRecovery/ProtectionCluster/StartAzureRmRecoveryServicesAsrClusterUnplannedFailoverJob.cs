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
    ///    Starts a cluster unplanned failover operation.
    /// </summary>
    [Cmdlet("Start", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrClusterUnplannedFailoverJob", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Start-ASRClusterUnplannedFailoverJob")]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmRecoveryServicesAsrClusterUnplannedFailoverJob : SiteRecoveryCmdletBase
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
        ///     Switch parameter to perform operation in source side before starting unplanned failover.
        /// </summary>
        [Parameter]
        [Alias("PerformSourceSideActions")]
        public SwitchParameter PerformSourceSideAction { get; set; }

        /// <summary>
        ///    Switch parameter to use the latest processed recovery point for failover.
        /// </summary>
        [Parameter(
            HelpMessage = "Fetch the latest processed recovery points if not passed for cluster or any individual node.")]
        [Alias("LatestProcessedRecoveryPoints")]
        public SwitchParameter LatestProcessedRecoveryPoint { get; set; }

        /// <summary>
        ///     Gets or sets a custom cluster recovery point to test failover the protected cluster to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false,
            HelpMessage = "Specifies the recovery point for the cluster.")]
        [ValidateNotNullOrEmpty]
        public ASRClusterRecoveryPoint ClusterRecoveryPoint { get; set; }

        /// <summary>
        ///    Gets or sets the individual node recovery points.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false,
            HelpMessage = "Specifies the recovery points for the nodes which are not part of cluster recovery point.")]
        [ValidateNotNullOrEmpty]
        public List<string> ListNodeRecoveryPoint { get; set; }


        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (ShouldProcess(
                "Protected cluster",
                "Start failover"))
            {
                this.protectionContainerName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);

                this.fabricName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                Logger.Instance.WriteVerbose(
                    String.Format(
                        "Start Cluster Unplanned Failover for Cluster: {0} Protection Container Name: {1} Fabric Name: {2}",
                        this.ReplicationProtectionCluster.Name,
                        this.protectionContainerName,
                        this.fabricName));

                this.StartRPCUnplannedFailover();
            }
        }

        /// <summary>
        ///     Starts replication protected cluster unplanned failover.
        /// </summary>
        private void StartRPCUnplannedFailover()
        {
            if (!string.Equals(
                    this.ReplicationProtectionCluster.ReplicationProvider,
                    Constants.A2A,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.UnsupportedReplicationProtectionActionForUnplannedFailover,
                        this.ReplicationProtectionCluster.ReplicationProvider));
            }

            var clusterUnplannedFailoverInputProperties = new ClusterUnplannedFailoverInputProperties
            {
                FailoverDirection = this.Direction,
                SourceSiteOperations = this.PerformSourceSideAction ? "Required" : "NotRequired",
                ProviderSpecificDetails = new ClusterUnplannedFailoverProviderSpecificInput()
            };

            var input = new ClusterUnplannedFailoverInput
            {
                Properties = clusterUnplannedFailoverInputProperties
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

            var failoverInput = new A2AClusterUnplannedFailoverInput
            {
                ClusterRecoveryPointId = clusterAndNodeRecoveryPoint.ClusterRecoveryPoint.ID,
                IndividualNodeRecoveryPoints = clusterAndNodeRecoveryPoint.ListNodeRecoveryPoint
            };

            input.Properties.ProviderSpecificDetails = failoverInput;

            var response = this.RecoveryServicesClient
                .StartAzureSiteRecoveryClusterUnplannedFailover(
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

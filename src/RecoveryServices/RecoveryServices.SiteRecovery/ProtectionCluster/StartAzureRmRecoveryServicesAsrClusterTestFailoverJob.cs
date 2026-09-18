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
    ///    Starts a cluster test failover operation.
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
        ///     Gets or sets a custom cluster recovery point to test failover the protected cluster to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = false,
            HelpMessage = "Specifies the recovery point for the cluster.")]
        [ValidateNotNullOrEmpty]
        public ASRClusterRecoveryPoint ClusterRecoveryPoint { get; set; }

        /// <summary>
        ///    Gets or sets the list of individual node recovery points.
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
        ///     Gets or sets the Azure virtual network ID to connect the test fail over virtual machine(s) to.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObject,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
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
                this.protectionContainerName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationProtectionContainers);

                this.fabricName = Utilities.GetValueFromArmId(
                    this.ReplicationProtectionCluster.ID,
                    ARMResourceTypeConstants.ReplicationFabrics);

                Logger.Instance.WriteVerbose(
                    String.Format(
                        "Start Cluster Test Failover for Cluster: {0} Protection Container Name: {1} Fabric Name: {2}",
                        this.ReplicationProtectionCluster.Name,
                        this.protectionContainerName,
                        this.fabricName));
                this.StartRPCTestFailover();
            }
        }

        /// <summary>
        ///     Starts replication protection cluster test failover.
        /// </summary>
        private void StartRPCTestFailover()
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

            var clusterTestFailoverInputProperties = new ClusterTestFailoverInputProperties
            {
                FailoverDirection = this.Direction,
                NetworkType = "VmNetworkAsInput",
                NetworkId = this.AzureVMNetworkId,
                ProviderSpecificDetails = new ClusterTestFailoverProviderSpecificInput()
            };

            var input =
                new ClusterTestFailoverInput { Properties = clusterTestFailoverInputProperties };

            var clusterAndNodeRecoveryPoint = Utilities.ValidateAndGetClusterAndNodeRecoveryPoint(
                this.RecoveryServicesClient,
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectionCluster,
                this.ReplicationProtectionCluster.Name,
                this.ClusterRecoveryPoint,
                this.ListNodeRecoveryPoint,
                this.LatestProcessedRecoveryPoint);
           
            var failoverInput = new A2AClusterTestFailoverInput
            {
                ClusterRecoveryPointId = clusterAndNodeRecoveryPoint.ClusterRecoveryPoint.ID,
                IndividualNodeRecoveryPoints = clusterAndNodeRecoveryPoint.ListNodeRecoveryPoint
            };

            input.Properties.ProviderSpecificDetails = failoverInput;

            var response = this.RecoveryServicesClient.StartAzureSiteRecoveryClusterTestFailover(
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
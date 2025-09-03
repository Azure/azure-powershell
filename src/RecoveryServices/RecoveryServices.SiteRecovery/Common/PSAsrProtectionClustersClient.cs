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
using Microsoft.Rest.Azure.OData;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Creates Replicated Protection Cluster.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name</param>
        /// <param name="input">Replication Protection Cluster input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation CreateProtectionCluster(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName,
            ReplicationProtectionCluster input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginCreateWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    input.Properties,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Gets Replication Protection Cluster.
        /// </summary>
        /// <param name="fabricName">Fabric name.</param>
        /// <param name="protectionContainerName">Protection container name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <returns>Replication Protection Cluster.</returns>
        public ReplicationProtectionCluster GetAzureSiteRecoveryReplicationProtectionCluster(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.GetWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Gets Replication Protection Cluster.
        /// </summary>
        /// <param name="fabricName">Fabric name.</param>
        /// <param name="protectionContainerName">Protection container name.</param>
        /// <returns>List of Replication Protection Clusters.</returns>
        public List<ReplicationProtectionCluster> GetAzureSiteRecoveryReplicationProtectionCluster(
            string fabricName,
            string protectionContainerName)
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters
                .ListByReplicationProtectionContainersWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationProtectionClusters
                    .ListByReplicationProtectionContainersNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Replication Protection Cluster.
        /// </summary>
        /// <returns>List of Replication Protection Clusters.</returns>
        public List<ReplicationProtectionCluster> GetAzureSiteRecoveryReplicationProtectionCluster()
        {
            var protectedClustersQueryParameter =
                new ProtectedClustersQueryParameter { };
            var odataQuery =
                new ODataQuery<ProtectedClustersQueryParameter>(
                    protectedClustersQueryParameter.ToQueryString());

            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters
                .ListWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    null,
                    null,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;

            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationProtectionClusters
                    .ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));

            pages.Insert(0, firstPage);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Remove Replication Protection Cluster.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <returns>A long running operation response.</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryReplicationProtectionCluster(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName)
        {
            var op = this.GetSiteRecoveryClient().
                ReplicationProtectionClusters.BeginPurgeWithHttpMessagesAsync(
                asrVaultCreds.ResourceGroupName,
                asrVaultCreds.ResourceName,
                fabricName,
                protectionContainerName,
                replicationProtectionClusterName,
                this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Resyncs / Repairs Cluster Replication.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryClusterResynchronizeReplication(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginRepairReplicationWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Switch the Azure Site Recovery protection entity replication direction.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="input">Input for Switch</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartSwitchClusterProtection(
            string fabricName,
            string protectionContainerName,
            SwitchClusterProtectionInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionContainers.BeginSwitchClusterProtectionWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    input.Properties,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Cluster Unplanned Failover.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <param name="input">Input for Cluster Unplanned failover.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryClusterUnplannedFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName,
            ClusterUnplannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginUnplannedFailoverWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    input.Properties,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Cluster Test Failover.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <param name="input">Input for Cluster Test failover.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryClusterTestFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName,
            ClusterTestFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginTestFailoverWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    input.Properties,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Cluster Test Failover Cleanup.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <param name="input">Input for Cluster Test failover cleanup.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryClusterTestFailoverCleanup(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName,
            ClusterTestFailoverCleanupInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginTestFailoverCleanupWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    input.Properties,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Start Cluster Apply Recovery Point.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <param name="input">Input for Cluster Apply recovery point.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryApplyClusterRecoveryPoint(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName,
            ApplyClusterRecoveryPointInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginApplyRecoveryPointWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    input.Properties,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Cluster Commit Failover.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Container Name.</param>
        /// <param name="replicationProtectionClusterName">Replication Protection Cluster Name.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryClusterCommitFailover(
            string fabricName,
            string protectionContainerName,
            string replicationProtectionClusterName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationProtectionClusters.BeginFailoverCommitWithHttpMessagesAsync(
                    asrVaultCreds.ResourceGroupName,
                    asrVaultCreds.ResourceName,
                    fabricName,
                    protectionContainerName,
                    replicationProtectionClusterName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

    }
}
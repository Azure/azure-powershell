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
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns>Protection entity list response</returns>
        public ReplicationProtectedItemListResponse GetAzureSiteRecoveryReplicationProtectedItem(string fabricName,
            string protectionContainerName)
        {
            return
                this
                .GetSiteRecoveryClient()
                .ReplicationProtectedItem.List(fabricName, protectionContainerName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicatedProtectedItemName">Virtual Machine Name</param>
        /// <returns>Replicated Protected Item response</returns>
        public ReplicationProtectedItemResponse GetAzureSiteRecoveryReplicationProtectedItem(string fabricName,
            string protectionContainerName,
            string replicatedProtectedItemName)
        {
            return
                this
                .GetSiteRecoveryClient()
                .ReplicationProtectedItem
                .Get(fabricName, protectionContainerName, replicatedProtectedItemName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Creates Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Enable protection input.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse EnableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            EnableProtectionInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginEnableProtection(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Removes Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Disable protection input.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse DisableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            DisableProtectionInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginDisableProtection(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Planned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Itenm</param>
        /// <param name="input">Input for Planned Failover</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryPlannedFailover(string fabricName, 
            string protectionContainerName, 
            string replicationProtectedItemName, 
            PlannedFailoverInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginPlannedFailover(fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Unplanned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Unplanned failover</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryUnplannedFailover(string fabricName, 
            string protectionContainerName, 
            string replicationProtectedItemName, 
            UnplannedFailoverInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginUnplannedFailover(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Test Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Test failover</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryTestFailover(string fabricName, 
            string protectionContainerName, 
            string replicationProtectedItemName, 
            TestFailoverInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginTestFailover(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Commit Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryCommitFailover(string fabricName, 
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginCommitFailover(
                 fabricName,
                 protectionContainerName,
                 replicationProtectedItemName,
                 this.GetRequestHeaders());
        }

        /// <summary>
        /// Re-protects the Azure Site Recovery protection entity.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Reprotect</param>
        /// <returns>Job Response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryReprotection(string fabricName, 
            string protectionContainerName, 
            string replicationProtectedItemName, 
            ReverseReplicationInput input)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItem.BeginReprotect(
                fabricName,
                protectionContainerName,
                replicationProtectedItemName,
                input,
                this.GetRequestHeaders());
        }
    }
}
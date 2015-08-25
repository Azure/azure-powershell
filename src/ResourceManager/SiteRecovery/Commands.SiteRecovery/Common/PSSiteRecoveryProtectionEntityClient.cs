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

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Retrieves Protection Entity.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <returns>Protection entity list response</returns>
        public ProtectionEntityListResponse GetAzureSiteRecoveryProtectionEntity(
            string protectionContainerId)
        {
            return
                this
                .GetSiteRecoveryClient()
                .ProtectionEntity
                .List(protectionContainerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Retrieves Protection Entity.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="virtualMachineId">Virtual Machine ID</param>
        /// <returns>Protection entity response</returns>
        public ProtectionEntityResponse GetAzureSiteRecoveryProtectionEntity(
            string protectionContainerId,
            string virtualMachineId)
        {
            return
                this
                .GetSiteRecoveryClient()
                .ProtectionEntity
                .Get(protectionContainerId, virtualMachineId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Sets protection on Protection entity.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Enable protection input.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse EnableProtection(
            string protectionContainerId,
            string protectionEntityId,
            EnableProtectionInput input)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.EnableProtection(
                protectionContainerId,
                protectionEntityId,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Sets protection on Protection entity.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Disable protection input.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse DisableProtection(
            string protectionContainerId,
            string protectionEntityId,
            DisableProtectionInput input)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.DisableProtection(
                protectionContainerId,
                protectionEntityId,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Planned failover.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Protection entity ID</param>
        /// <param name="plannedFailoverRequest">Planned failover request</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryPlannedFailover(
            string protectionContainerId,
            string protectionEntityId,
            PlannedFailoverRequest plannedFailoverRequest)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.BeginPlannedFailover(
                protectionContainerId,
                protectionEntityId,
                plannedFailoverRequest,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Unplanned failover.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Protection entity ID</param>
        /// <param name="unplannedFailoverRequest">Unplanned failover request</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryUnplannedFailover(
            string protectionContainerId,
            string protectionEntityId,
            UnplannedFailoverRequest unplannedFailoverRequest)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.BeginUnplannedFailover(
                protectionContainerId,
                protectionEntityId,
                unplannedFailoverRequest,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Unplanned failover.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Protection entity ID</param>
        /// <param name="testFailoverRequest">Test failover request</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryTestFailover(
            string protectionContainerId,
            string protectionEntityId,
            TestFailoverRequest testFailoverRequest)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.BeginTestFailover(
                protectionContainerId,
                protectionEntityId,
                testFailoverRequest,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Commit failover.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Recovery Plan ID</param>
        /// <param name="request">Commit failover request.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryCommitFailover(
            string protectionContainerId,
            string protectionEntityId,
            CommitFailoverRequest request)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.BeginCommitFailover(
                 protectionContainerId,
                 protectionEntityId,
                 request,
                 this.GetRequestHeaders());
        }

        /// <summary>
        /// Re-protects the Azure Site Recovery protection entity.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Recovery Plan ID</param>
        /// <param name="request">Re-protect request.</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryReprotection(
            string protectionContainerId,
            string protectionEntityId,
            ReprotectRequest request)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.BeginReprotect(
                protectionContainerId,
                protectionEntityId,
                request,
                this.GetRequestHeaders());
        }
    }
}
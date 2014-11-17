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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Represents Enable protection.
        /// </summary>
        public const string EnableProtection = "Enable";

        /// <summary>
        /// Represents Disable protection.
        /// </summary>
        public const string DisableProtection = "Disable";

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
        /// <param name="virtualMachineId">Virtual Machine ID</param>
        /// <param name="protection">Protection state to set</param>
        /// <returns>Job response</returns>
        public JobResponse SetProtectionOnProtectionEntity(
            string protectionContainerId,
            string virtualMachineId,
            string protection)
        {
            var requestHeaders = this.GetRequestHeaders();
            
            JobResponse jobResponse = null;

            if (0 == string.Compare(EnableProtection, protection, StringComparison.OrdinalIgnoreCase))
            {
                jobResponse =
                    this.GetSiteRecoveryClient().ProtectionEntity.EnableProtection(
                    protectionContainerId,
                    virtualMachineId,
                    requestHeaders);
            }
            else if (0 == string.Compare(DisableProtection, protection, StringComparison.OrdinalIgnoreCase))
            {
                jobResponse =
                    this.GetSiteRecoveryClient().ProtectionEntity.DisableProtection(
                    protectionContainerId,
                    virtualMachineId,
                    requestHeaders);
            }

            return jobResponse;
        }

        /// <summary>
        /// Starts Azure Site Recovery Planned failover.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Protection entity ID</param>
        /// <param name="plannedFailoverRequest">Planned failover request</param>
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryPlannedFailover(
            string protectionContainerId,
            string protectionEntityId,
            PlannedFailoverRequest plannedFailoverRequest)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.PlannedFailover(
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
        public JobResponse StartAzureSiteRecoveryUnplannedFailover(
            string protectionContainerId,
            string protectionEntityId,
            UnplannedFailoverRequest unplannedFailoverRequest)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.UnplannedFailover(
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
        public JobResponse StartAzureSiteRecoveryTestFailover(
            string protectionContainerId,
            string protectionEntityId,
            TestFailoverRequest testFailoverRequest)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.TestFailover(
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
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryCommitFailover(
            string protectionContainerId,
            string protectionEntityId)
        {
            return this.GetSiteRecoveryClient().ProtectionEntity.CommitFailover(
                protectionContainerId,
                protectionEntityId,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Re-protects the Azure Site Recovery protection entity.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="protectionEntityId">Recovery Plan ID</param>
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryReprotection(
            string protectionContainerId,
            string protectionEntityId)
        {
            var request = new ReprotectRequest();
            return this.GetSiteRecoveryClient().ProtectionEntity.Reprotect(
                protectionContainerId,
                protectionEntityId,
                request,
                this.GetRequestHeaders());
        }
    }
}
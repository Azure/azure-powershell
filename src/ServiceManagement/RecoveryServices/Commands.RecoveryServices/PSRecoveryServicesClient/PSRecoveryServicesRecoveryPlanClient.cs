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
        /// Gets Azure Site Recovery Plan.
        /// </summary>
        /// <returns>Recovery Plan list response</returns>
        public RecoveryPlanListResponse GetAzureSiteRecoveryRecoveryPlan()
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.List(this.GetRequestHeaders());
        }

        /// <summary>
        /// Get Azure Site Recovery recovery plan XML.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery plan id.</param>
        /// <returns>Recovery plan XML.</returns>
        public RecoveryPlanXmlOuput GetAzureSiteRecoveryRecoveryPlanFile(string recoveryPlanId)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.GetRecoveryPlanXml(
                recoveryPlanId,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery Plan ID</param>
        /// <returns>Recovery Plan response</returns>
        public RecoveryPlanResponse GetAzureSiteRecoveryRecoveryPlan(string recoveryPlanId)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.Get(recoveryPlanId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Commit failover.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery Plan ID</param>
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryCommitFailover(string recoveryPlanId)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.Commit(recoveryPlanId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Updates Azure Site Recovery protection.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery Plan ID</param>
        /// <returns>Job response</returns>
        public JobResponse UpdateAzureSiteRecoveryProtection(string recoveryPlanId)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.Reprotect(recoveryPlanId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Planned failover.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery Plan ID</param>
        /// <param name="recoveryPlanPlannedFailoverRequest">Recovery Plan Planned failover request</param>
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryPlannedFailover(
            string recoveryPlanId, 
            RpPlannedFailoverRequest recoveryPlanPlannedFailoverRequest)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.RecoveryPlanPlannedFailover(
                recoveryPlanId,
                recoveryPlanPlannedFailoverRequest, 
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Unplanned failover.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery Plan ID</param>
        /// <param name="recoveryPlanUnPlannedFailoverRequest">Recovery Plan Unplanned failover request</param>
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryUnplannedFailover(
            string recoveryPlanId,
            RpUnplannedFailoverRequest recoveryPlanUnPlannedFailoverRequest)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.RecoveryPlanUnplannedFailover(
                recoveryPlanId,
                recoveryPlanUnPlannedFailoverRequest, 
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery test failover.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery Plan ID</param>
        /// <param name="recoveryPlanTestFailoverRequest">Recovery Plan test failover request</param>
        /// <returns>Job response</returns>
        public JobResponse StartAzureSiteRecoveryTestFailover(
            string recoveryPlanId,
            RpTestFailoverRequest recoveryPlanTestFailoverRequest)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.RecoveryPlanTestFailover(
                recoveryPlanId,
                recoveryPlanTestFailoverRequest, 
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Remove Azure Site Recovery recovery plan.
        /// </summary>
        /// <param name="recoveryPlanId">Recovery plan id.</param>
        /// <returns>Job response</returns>
        public JobResponse RemoveAzureSiteRecoveryRecoveryPlan(string recoveryPlanId)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.Delete(
                recoveryPlanId, 
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanXml">Recovery Plan Xml.</param>
        /// <returns>Job response</returns>
        public JobResponse CreateAzureSiteRecoveryRecoveryPlan(string recoveryPlanXml)
        {
            RecoveryPlanXmlData recoveryPlanXmlData = new RecoveryPlanXmlData
            {
                RecoveryPlanXml = recoveryPlanXml
            };

            return this.GetSiteRecoveryClient().RecoveryPlan.CreateRecoveryPlan(
                recoveryPlanXmlData,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Update Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanXml">Recovery Plan Xml.</param>
        /// <returns>Job response</returns>
        public JobResponse UpdateAzureSiteRecoveryRecoveryPlan(string recoveryPlanXml)
        {
            RecoveryPlanXmlData recoveryPlanXmlData = new RecoveryPlanXmlData
            {
                RecoveryPlanXml = recoveryPlanXml
            };

            return this.GetSiteRecoveryClient().RecoveryPlan.UpdateRecoveryPlan(
                recoveryPlanXmlData,
                this.GetRequestHeaders());
        }
    }
}
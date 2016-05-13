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
        /// Gets Azure Site Recovery Plans.
        /// </summary>
        /// <returns></returns>
        public RecoveryPlanListResponse GetAzureSiteRecoveryRecoveryPlan()
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.List(this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public RecoveryPlanResponse GetAzureSiteRecoveryRecoveryPlan(string recoveryPlanName)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.Get(recoveryPlanName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Commit failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryCommitFailover(string recoveryPlanName)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginCommitFailover(recoveryPlanName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Reprotect Recovery Plan
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse UpdateAzureSiteRecoveryProtection(string recoveryPlanName)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginReprotect(recoveryPlanName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Planned failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Planned Failover Input</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryPlannedFailover(string recoveryPlanName, RecoveryPlanPlannedFailoverInput input)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginPlannedFailover(
                recoveryPlanName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery Unplanned failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Unplanned Failover Input</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryUnplannedFailover(string recoveryPlanName, RecoveryPlanUnplannedFailoverInput input)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginUnplannedFailover(
                recoveryPlanName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Azure Site Recovery test failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Test Failover Input</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse StartAzureSiteRecoveryTestFailover(string recoveryPlanName, RecoveryPlanTestFailoverInput input)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginTestFailover(
                recoveryPlanName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Remove Azure Site Recovery recovery plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse RemoveAzureSiteRecoveryRecoveryPlan(string recoveryPlanName)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginDeleting(
                recoveryPlanName,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Starts Creating Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Create Recovery Plan Input</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse CreateAzureSiteRecoveryRecoveryPlan(string recoveryPlanName, CreateRecoveryPlanInput input)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginCreating(recoveryPlanName,
                input,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Update Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Update Recovery Plan Input</param>
        /// <returns>Job response</returns>
        public LongRunningOperationResponse UpdateAzureSiteRecoveryRecoveryPlan(string recoveryPlanName, UpdateRecoveryPlanInput input)
        {
            return this.GetSiteRecoveryClient().RecoveryPlan.BeginUpdating(recoveryPlanName,
                input,
                this.GetRequestHeaders());
        }
    }
}
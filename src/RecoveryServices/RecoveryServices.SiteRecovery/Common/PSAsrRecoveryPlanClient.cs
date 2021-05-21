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

using System.Collections.Generic;
using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Starts Creating Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Create Recovery Plan Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation CreateAzureSiteRecoveryRecoveryPlan(
            string recoveryPlanName,
            CreateRecoveryPlanInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginCreateWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Gets Azure Site Recovery Plans.
        /// </summary>
        /// <returns></returns>
        public List<RecoveryPlan> GetAzureSiteRecoveryRecoveryPlan()
        {
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.ListWithHttpMessagesAsync(this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationRecoveryPlans.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public RecoveryPlan GetAzureSiteRecoveryRecoveryPlan(
            string recoveryPlanName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.GetWithHttpMessagesAsync(
                    recoveryPlanName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Remove Azure Site Recovery recovery plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryRecoveryPlan(
            string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginDeleteWithHttpMessagesAsync(
                    recoveryPlanName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);	
            return result;
        }

        /// <summary>
        ///     Starts Azure Site Recovery Commit failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryCommitFailover(
            string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginFailoverCommitWithHttpMessagesAsync(
                    recoveryPlanName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Azure Site Recovery cancel failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery plan name.</param>
        /// <returns>Job response.</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryCancelFailover(
            string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginFailoverCancelWithHttpMessagesAsync(
                    recoveryPlanName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Azure Site Recovery Planned failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Planned Failover Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryPlannedFailover(
            string recoveryPlanName,
            RecoveryPlanPlannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginPlannedFailoverWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Azure Site Recovery test failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Test Failover Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestFailover(
            string recoveryPlanName,
            RecoveryPlanTestFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginTestFailoverWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Azure Site Recovery test failover cleanup.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name.</param>
        /// <param name="input">Recovery Plan Test Failover cleanup input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestFailoverCleanup(
            string recoveryPlanName,
            RecoveryPlanTestFailoverCleanupInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginTestFailoverCleanupWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Starts Azure Site Recovery Unplanned failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Unplanned Failover Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryUnplannedFailover(
            string recoveryPlanName,
            RecoveryPlanUnplannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginUnplannedFailoverWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Reprotect Recovery Plan
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureSiteRecoveryProtection(
            string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginReprotectWithHttpMessagesAsync(
                    recoveryPlanName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Update Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Update Recovery Plan Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureSiteRecoveryRecoveryPlan(
            string recoveryPlanName,
            UpdateRecoveryPlanInput input)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginUpdateWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();

            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}

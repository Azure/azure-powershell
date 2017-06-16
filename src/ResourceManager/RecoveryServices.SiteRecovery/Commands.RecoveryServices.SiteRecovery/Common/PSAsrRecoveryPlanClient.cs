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
        ///     Gets Azure Site Recovery Plans.
        /// </summary>
        /// <returns></returns>
        public List<RecoveryPlan> GetAzureSiteRecoveryRecoveryPlan()
        {
            var firstPage = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.ListWithHttpMessagesAsync(GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(GetSiteRecoveryClient()
                    .ReplicationRecoveryPlans.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                GetRequestHeaders(true));
            pages.Insert(0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public RecoveryPlan GetAzureSiteRecoveryRecoveryPlan(string recoveryPlanName)
        {
            return GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.GetWithHttpMessagesAsync(recoveryPlanName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Starts Azure Site Recovery Commit failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryCommitFailover(
            string recoveryPlanName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginFailoverCommitWithHttpMessagesAsync(recoveryPlanName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
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
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginReprotectWithHttpMessagesAsync(recoveryPlanName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
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
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginPlannedFailoverWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
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
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginUnplannedFailoverWithHttpMessagesAsync(
                    recoveryPlanName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
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
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginTestFailoverWithHttpMessagesAsync(recoveryPlanName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Remove Azure Site Recovery recovery plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryRecoveryPlan(
            string recoveryPlanName)
        {
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginDeleteWithHttpMessagesAsync(recoveryPlanName,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

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
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginCreateWithHttpMessagesAsync(recoveryPlanName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
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
            var op = GetSiteRecoveryClient()
                .ReplicationRecoveryPlans.BeginUpdateWithHttpMessagesAsync(recoveryPlanName,
                    input,
                    GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
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
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        ///     Cancel Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job Name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation CancelAzureSiteRecoveryJob(
            string jobName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationJobs.BeginCancelWithHttpMessagesAsync(
                    jobName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Get Azure Site Recovery Job.
        /// </summary>
        /// <returns>Job list response</returns>
        public List<Job> GetAzureSiteRecoveryJob(
            JobQueryParameter jqp)
        {
            var odataQuery = new ODataQuery<JobQueryParameter>(jqp.ToQueryString());
            var firstPage = this.GetSiteRecoveryClient()
                .ReplicationJobs.ListWithHttpMessagesAsync(
                    odataQuery,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
            var pages = Utilities.GetAllFurtherPages(
                this.GetSiteRecoveryClient()
                    .ReplicationJobs.ListNextWithHttpMessagesAsync,
                firstPage.NextPageLink,
                this.GetRequestHeaders(true));
            pages.Insert(
                0,
                firstPage);

            return Utilities.IpageToList(pages);
        }

        /// <summary>
        ///     Gets Azure Site Recovery Job details.
        /// </summary>
        /// <param name="jobName">Job ID</param>
        /// <returns>Job response</returns>
        public Job GetAzureSiteRecoveryJobDetails(
            string jobName)
        {
            return this.GetSiteRecoveryClient()
                .ReplicationJobs.GetWithHttpMessagesAsync(
                    jobName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult()
                .Body;
        }

        /// <summary>
        ///     Restart Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job Name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation RestartAzureSiteRecoveryJob(
            string jobName)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationJobs.BeginRestartWithHttpMessagesAsync(
                    jobName,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        ///     Resumes Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job ID</param>
        /// <param name="resumeJobParams">Resume Job parameters</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation ResumeAzureSiteRecoveryJob(
            string jobName,
            ResumeJobParams resumeJobParams)
        {
            var op = this.GetSiteRecoveryClient()
                .ReplicationJobs.BeginResumeWithHttpMessagesAsync(
                    jobName,
                    resumeJobParams,
                    this.GetRequestHeaders(true))
                .GetAwaiter()
                .GetResult();
            var result = SiteRecoveryAutoMapperProfile.Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
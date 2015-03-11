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
        /// Gets Azure Site Recovery Job details.
        /// </summary>
        /// <param name="jobId">Job ID</param>
        /// <returns>Job response</returns>
        public JobResponse GetAzureSiteRecoveryJobDetails(string jobId)
        {
            return this.GetSiteRecoveryClient().Jobs.Get(jobId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Get Azure Site Recovery Job.
        /// </summary>
        /// <param name="jqp">Job query parameter.</param>
        /// <returns>Job list response</returns>
        public JobListResponse GetAzureSiteRecoveryJob(JobQueryParameter jqp)
        {
            return this.GetSiteRecoveryClient().Jobs.List(jqp, this.GetRequestHeaders());
        }

        /// <summary>
        /// Stops Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobId">Job ID</param>
        public void StopAzureSiteRecoveryJob(string jobId)
        {
            this.GetSiteRecoveryClient().Jobs.Cancel(jobId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Restarts Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobId">Job ID</param>
        /// <returns>Job response</returns>
        public JobResponse RestartAzureSiteRecoveryJob(string jobId)
        {
            return this.GetSiteRecoveryClient().Jobs.Restart(jobId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Resumes Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobId">Job ID</param>
        /// <param name="resumeJobParams">Resume Job parameters</param>
        /// <returns>Job response</returns>
        public JobResponse ResumeAzureSiteRecoveryJob(
            string jobId,
            ResumeJobParams resumeJobParams)
        {
            return this.GetSiteRecoveryClient().Jobs.Resume(jobId, resumeJobParams, this.GetRequestHeaders());
        }
    }
}
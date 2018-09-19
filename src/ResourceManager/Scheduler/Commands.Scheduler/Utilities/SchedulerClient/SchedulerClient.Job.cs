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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Net;
    using Microsoft.Azure.Management.Scheduler;
    using Microsoft.Azure.Management.Scheduler.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using PSManagement = System.Management.Automation;
    using Microsoft.Azure.Commands.Scheduler.Models;
    
    /// <summary>
    /// Client for Job.
    /// </summary>
    public partial class SchedulerClient
    {
        /// <summary>
        /// List jobs.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">job collection name.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobState">State of the job.</param>
        /// <returns>List of job definition.</returns>
        public IList<PSSchedulerJobDefinition> ListJobs(string resourceGroupName, string jobCollectionName, string jobName = "", string jobState = "")
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobCollectionName");
            }

            JobState? jobStateEnum = jobState.GetValueOrDefaultEnum<JobState?>(defaultValue: null);

            IList<JobDefinition> listOfJobs;

            if (!string.IsNullOrWhiteSpace(jobName))
            {
                JobDefinition job = this.GetJob(resourceGroupName, jobCollectionName, jobName);

                listOfJobs = new List<JobDefinition>()
                {
                    job
                };
            }
            else
            {
                listOfJobs = this.ListJobs(resourceGroupName, jobCollectionName, jobStateEnum);
            }

            return Converter.ConvertJobDefinitionListToPSList(listOfJobs);
        }

        /// <summary>
        /// List jobs.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">job collection name.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <param name="jobState">State of the job.</param>
        /// <returns>List of Job definition.</returns>
        internal IList<JobDefinition> ListJobs(string resourceGroupName, string jobCollectionName, JobState? jobState)
        {
            var listOfJobs = new List<JobDefinition>();

            var oDataQuery = new ODataQuery<JobStateFilter>();

            if (jobState != null)
            {
                Expression<Func<JobStateFilter, bool>> jobFilterExpression = (jobStateFilter) => jobStateFilter.State == jobState;
                oDataQuery.SetFilter(jobFilterExpression);
            }

            IPage<JobDefinition> jobsPage = this.SchedulerManagementClient.Jobs.List(resourceGroupName, jobCollectionName, oDataQuery);

            listOfJobs.AddRange(jobsPage);

            while (!string.IsNullOrWhiteSpace(jobsPage.NextPageLink))
            {
                jobsPage = this.SchedulerManagementClient.Jobs.ListNext(jobsPage.NextPageLink);
                listOfJobs.AddRange(jobsPage);
            }

            return listOfJobs;
        }


        /// <summary>
        /// Gets job history.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource.</param>
        /// <param name="jobCollectionName">The job collection name.</param>
        /// <param name="jobName">The name of the job.</param>
        /// <param name="jobStatus">The status of the job.</param>
        /// <returns>List of job history definition.</returns>
        public IList<PSJobHistory> GetJobHistory(string resourceGroupName, string jobCollectionName, string jobName, string jobStatus)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobCollectionName");
            }

            if(string.IsNullOrWhiteSpace(jobName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobName");
            }

            var oDataQuery = new ODataQuery<JobHistoryFilter>(); 

            JobExecutionStatus? executionStatus = jobStatus.GetValueOrDefaultEnum<JobExecutionStatus?>(defaultValue: null);

            if (executionStatus != null)
            {
                Expression<Func<JobHistoryFilter, bool>> jobHistoryFilterExpression = (jobHistoryFilter) => jobHistoryFilter.Status == executionStatus;
                oDataQuery.SetFilter(jobHistoryFilterExpression);
            }

            var listOfJobHistory = new List<JobHistoryDefinition>();

            IPage<JobHistoryDefinition> jobHistoryPage = this.SchedulerManagementClient.Jobs.ListJobHistory(resourceGroupName, jobCollectionName, jobName, oDataQuery);

            listOfJobHistory.AddRange(jobHistoryPage);

            while (!string.IsNullOrWhiteSpace(jobHistoryPage.NextPageLink))
            {
                jobHistoryPage = this.SchedulerManagementClient.Jobs.ListJobHistoryNext(jobHistoryPage.NextPageLink);
                listOfJobHistory.AddRange(jobHistoryPage);
            }

            return Converter.ConvertJobHistoryListToPSList(listOfJobHistory);
        }

       /// <summary>
       /// Deletes a job.
       /// </summary>
        /// <param name="resourceGroupName">The name of the resource.</param>
        /// <param name="jobCollectionName">The job collection name.</param>
        /// <param name="jobName">The name of the job.</param>
        public void DeleteJob(string resourceGroupName, string jobCollectionName, string jobName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobCollectionName");
            }

            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobName");
            }

            this.SchedulerManagementClient.Jobs.Delete(resourceGroupName, jobCollectionName, jobName);
        }

        /// <summary>
        /// Get Job.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">job collection name.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <returns>The Job definition.</returns>
        internal JobDefinition GetJob(string resourceGroupName, string jobCollectionName, string jobName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "resourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "jobCollectionName");
            }

            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "jobName");
            }

            try
            {
                return this.SchedulerManagementClient.Jobs.Get(resourceGroupName, jobCollectionName, jobName);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw e;
            }
        }

        /// <summary>
        /// Checks whether job exists.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">job collection name.</param>
        /// <param name="jobName">Name of the job.</param>
        /// <returns>True if job exists, false otherwise.</returns>
        internal bool JobExists(string resourceGroupName, string jobCollectionName, string jobName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "resourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "jobCollectionName");
            }

            if (string.IsNullOrWhiteSpace(jobName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "jobName");
            }

            JobDefinition job = this.GetJob(resourceGroupName, jobCollectionName, jobName);

            return job != null;
        }
    }
}

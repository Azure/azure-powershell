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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class BatchClient
    {
        /// <summary>
        /// Lists the jobs matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for jobs.</param>
        /// <returns>The jobs matching the specified filter options.</returns>
        public IEnumerable<PSCloudJob> ListJobs(ListJobOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single job matching the specified id
            if (!string.IsNullOrEmpty(options.JobId))
            {
                WriteVerbose(string.Format(Resources.GetJobById, options.JobId));
                JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                ODATADetailLevel getDetailLevel = new ODATADetailLevel(selectClause: options.Select, expandClause: options.Expand);
                CloudJob job = jobOperations.GetJob(options.JobId, detailLevel: getDetailLevel, additionalBehaviors: options.AdditionalBehaviors);
                PSCloudJob psJob = new PSCloudJob(job);
                return new PSCloudJob[] { psJob };
            }
            // List jobs using the specified filter
            else
            {
                string jobScheduleId = options.JobSchedule == null ? options.JobScheduleId : options.JobSchedule.Id;
                bool filterByJobSchedule = !string.IsNullOrEmpty(jobScheduleId);
                ODATADetailLevel listDetailLevel = new ODATADetailLevel(selectClause: options.Select, expandClause: options.Expand);

                string verboseLogString = null;
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = filterByJobSchedule ? Resources.GetJobByOData : string.Format(Resources.GetJobByODataAndJobSChedule, jobScheduleId);
                    listDetailLevel.FilterClause = options.Filter;
                }
                else
                {
                    verboseLogString = filterByJobSchedule ? Resources.GetJobNoFilter : string.Format(Resources.GetJobByJobScheduleNoFilter, jobScheduleId);
                }
                WriteVerbose(verboseLogString);

                IPagedEnumerable<CloudJob> jobs = null;
                if (filterByJobSchedule)
                {
                    JobScheduleOperations jobScheduleOperations = options.Context.BatchOMClient.JobScheduleOperations;
                    jobs = jobScheduleOperations.ListJobs(jobScheduleId, listDetailLevel, options.AdditionalBehaviors);
                }
                else
                {
                    JobOperations jobOperations = options.Context.BatchOMClient.JobOperations;
                    jobs = jobOperations.ListJobs(listDetailLevel, options.AdditionalBehaviors);
                }
                Func<CloudJob, PSCloudJob> mappingFunction = j => { return new PSCloudJob(j); };
                return PSPagedEnumerable<PSCloudJob, CloudJob>.CreateWithMaxCount(
                    jobs, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Creates a new job.
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the job.</param>
        public void CreateJob(NewJobParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            JobOperations jobOperations = parameters.Context.BatchOMClient.JobOperations;
            CloudJob job = jobOperations.CreateJob();

            job.Id = parameters.JobId;
            job.DisplayName = parameters.DisplayName;
            job.Priority = parameters.Priority;

            if (parameters.CommonEnvironmentSettings != null)
            {
                List<EnvironmentSetting> envSettings = new List<EnvironmentSetting>();
                foreach (DictionaryEntry d in parameters.CommonEnvironmentSettings)
                {
                    EnvironmentSetting envSetting = new EnvironmentSetting(d.Key.ToString(), d.Value.ToString());
                    envSettings.Add(envSetting);
                }
                job.CommonEnvironmentSettings = envSettings;
            }

            if (parameters.Constraints != null)
            {
                job.Constraints = parameters.Constraints.omObject;
            }

            if (parameters.UsesTaskDependencies != null)
            {
                job.UsesTaskDependencies = parameters.UsesTaskDependencies;
            }

            if (parameters.JobManagerTask != null)
            {
                Utils.Utils.JobManagerTaskSyncCollections(parameters.JobManagerTask);
                job.JobManagerTask = parameters.JobManagerTask.omObject;
            }

            if (parameters.JobPreparationTask != null)
            {
                Utils.Utils.JobPreparationTaskSyncCollections(parameters.JobPreparationTask);
                job.JobPreparationTask = parameters.JobPreparationTask.omObject;
            }

            if (parameters.JobReleaseTask != null)
            {
                Utils.Utils.JobReleaseTaskSyncCollections(parameters.JobReleaseTask);
                job.JobReleaseTask = parameters.JobReleaseTask.omObject;
            }

            if (parameters.Metadata != null)
            {
                job.Metadata = new List<MetadataItem>();
                foreach (DictionaryEntry d in parameters.Metadata)
                {
                    MetadataItem metadata = new MetadataItem(d.Key.ToString(), d.Value.ToString());
                    job.Metadata.Add(metadata);
                }
            }

            if (parameters.PoolInformation != null)
            {
                Utils.Utils.PoolInformationSyncCollections(parameters.PoolInformation);
                job.PoolInformation = parameters.PoolInformation.omObject;
            }

            WriteVerbose(string.Format(Resources.CreatingJob, parameters.JobId));
            job.Commit(parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Commits changes to a PSCloudJob object to the Batch Service.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="job">The PSCloudJob object representing the job to update.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void UpdateJob(BatchAccountContext context, PSCloudJob job, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (job == null)
            {
                throw new ArgumentNullException("job");
            }

            WriteVerbose(string.Format(Resources.UpdatingJob, job.Id));

            Utils.Utils.BoundJobSyncCollections(job);
            job.omObject.Commit(additionBehaviors);
        }

        /// <summary>
        /// Deletes the specified job.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobId">The id of the job to delete.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void DeleteJob(BatchAccountContext context, string jobId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(jobId))
            {
                throw new ArgumentNullException("jobId");
            }

            JobOperations jobOperations = context.BatchOMClient.JobOperations;
            jobOperations.DeleteJob(jobId, additionBehaviors);
        }

        /// <summary>
        /// Enables the specified job.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobId">The id of the job to enable.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void EnableJob(BatchAccountContext context, string jobId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(jobId))
            {
                throw new ArgumentNullException("jobId");
            }

            WriteVerbose(string.Format(Resources.EnableJob, jobId));

            JobOperations jobOperations = context.BatchOMClient.JobOperations;
            jobOperations.EnableJob(jobId, additionBehaviors);
        }

        /// <summary>
        /// Disables the specified job.
        /// </summary>
        /// <param name="parameters">Specifies the job to disable as well as the job disable option.</param>
        public void DisableJob(DisableJobParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string jobId = parameters.Job == null ? parameters.JobId : parameters.Job.Id;

            WriteVerbose(string.Format(Resources.DisableJob, jobId));

            JobOperations jobOperations = parameters.Context.BatchOMClient.JobOperations;
            jobOperations.DisableJob(jobId, parameters.DisableJobOption, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Terminates the specified job.
        /// </summary>
        /// <param name="parameters">Specifies the job to terminate as well as the terminate reason.</param>
        public void TerminateJob(TerminateJobParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            string jobId = parameters.Job == null ? parameters.JobId : parameters.Job.Id;
            WriteVerbose(string.Format(Resources.TerminateJob, jobId));

            JobOperations jobOperations = parameters.Context.BatchOMClient.JobOperations;
            jobOperations.TerminateJob(jobId, parameters.TerminateReason, parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Gets lifetime summary statistics for all of the jobs in the specified account.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="additionalBehaviors">Additional client behaviors to perform.</param>
        public PSJobStatistics GetAllJobsLifetimeStatistics(BatchAccountContext context, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            WriteVerbose(Resources.GetAllJobsLifetimeStatistics);

            JobOperations jobOperations = context.BatchOMClient.JobOperations;
            JobStatistics jobStatistics = jobOperations.GetAllJobsLifetimeStatistics(additionalBehaviors);
            PSJobStatistics psJobStatistics = new PSJobStatistics(jobStatistics);

            return psJobStatistics;
        }
    }
}

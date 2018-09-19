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
        /// Lists the job schedules matching the specified filter options.
        /// </summary>
        /// <param name="options">The options to use when querying for job schedules.</param>
        /// <returns>The workitems matching the specified filter options.</returns>
        public IEnumerable<PSCloudJobSchedule> ListJobSchedules(ListJobScheduleOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            // Get the single job schedule matching the specified id
            if (!string.IsNullOrWhiteSpace(options.JobScheduleId))
            {
                WriteVerbose(string.Format(Resources.GetJobScheduleById, options.JobScheduleId));
                JobScheduleOperations jobScheduleOperations = options.Context.BatchOMClient.JobScheduleOperations;
                ODATADetailLevel getDetailLevel = new ODATADetailLevel(selectClause: options.Select, expandClause: options.Expand);
                CloudJobSchedule jobSchedule = jobScheduleOperations.GetJobSchedule(options.JobScheduleId, detailLevel: getDetailLevel, additionalBehaviors: options.AdditionalBehaviors);
                PSCloudJobSchedule psJobSchedule = new PSCloudJobSchedule(jobSchedule);
                return new PSCloudJobSchedule[] { psJobSchedule };
            }
            // List job schedules using the specified filter
            else
            {
                string verboseLogString = null;
                ODATADetailLevel listDetailLevel = new ODATADetailLevel(selectClause: options.Select, expandClause: options.Expand);
                if (!string.IsNullOrEmpty(options.Filter))
                {
                    verboseLogString = Resources.GetJobScheduleByOData;
                    listDetailLevel.FilterClause = options.Filter;
                }
                else
                {
                    verboseLogString = Resources.GetJobScheduleNoFilter;
                }
                WriteVerbose(verboseLogString);

                JobScheduleOperations jobScheduleOperations = options.Context.BatchOMClient.JobScheduleOperations;
                IPagedEnumerable<CloudJobSchedule> workItems = jobScheduleOperations.ListJobSchedules(listDetailLevel, options.AdditionalBehaviors);
                Func<CloudJobSchedule, PSCloudJobSchedule> mappingFunction = j => { return new PSCloudJobSchedule(j); };
                return PSPagedEnumerable<PSCloudJobSchedule, CloudJobSchedule>.CreateWithMaxCount(
                    workItems, mappingFunction, options.MaxCount, () => WriteVerbose(string.Format(Resources.MaxCount, options.MaxCount)));
            }
        }

        /// <summary>
        /// Creates a new job schedule.
        /// </summary>
        /// <param name="parameters">The parameters to use when creating the job schedule.</param>
        public void CreateJobSchedule(NewJobScheduleParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            JobScheduleOperations jobScheduleOperations = parameters.Context.BatchOMClient.JobScheduleOperations;
            CloudJobSchedule jobSchedule = jobScheduleOperations.CreateJobSchedule();

            jobSchedule.Id = parameters.JobScheduleId;
            jobSchedule.DisplayName = parameters.DisplayName;

            if (parameters.Schedule != null)
            {
                jobSchedule.Schedule = parameters.Schedule.omObject;
            }

            if (parameters.JobSpecification != null)
            {
                Utils.Utils.JobSpecificationSyncCollections(parameters.JobSpecification);
                jobSchedule.JobSpecification = parameters.JobSpecification.omObject;
            }

            if (parameters.Metadata != null)
            {
                jobSchedule.Metadata = new List<MetadataItem>();
                foreach (DictionaryEntry d in parameters.Metadata)
                {
                    MetadataItem metadata = new MetadataItem(d.Key.ToString(), d.Value.ToString());
                    jobSchedule.Metadata.Add(metadata);
                }
            }
            WriteVerbose(string.Format(Resources.CreatingJobSchedule, parameters.JobScheduleId));
            jobSchedule.Commit(parameters.AdditionalBehaviors);
        }

        /// <summary>
        /// Commits changes to a PSCloudJobSchedule object to the Batch Service.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobSchedule">The PSCloudJobSchedule object representing the job schedule to update.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void UpdateJobSchedule(BatchAccountContext context, PSCloudJobSchedule jobSchedule, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (jobSchedule == null)
            {
                throw new ArgumentNullException("jobSchedule");
            }

            WriteVerbose(string.Format(Resources.UpdatingJobSchedule, jobSchedule.Id));

            Utils.Utils.BoundJobScheduleSyncCollections(jobSchedule);
            jobSchedule.omObject.Commit(additionBehaviors);
        }

        /// <summary>
        /// Deletes the specified job schedule.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobScheduleId">The id of the job schedule to delete.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void DeleteJobSchedule(BatchAccountContext context, string jobScheduleId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(jobScheduleId))
            {
                throw new ArgumentNullException("jobScheduleId");
            }

            JobScheduleOperations jobScheduleOperations = context.BatchOMClient.JobScheduleOperations;
            jobScheduleOperations.DeleteJobSchedule(jobScheduleId, additionBehaviors);
        }

        /// <summary>
        /// Enables the specified job schedule.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobScheduleId">The id of the job schedule to enable.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void EnableJobSchedule(BatchAccountContext context, string jobScheduleId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(jobScheduleId))
            {
                throw new ArgumentNullException("jobScheduleId");
            }

            WriteVerbose(string.Format(Resources.EnableJobSchedule, jobScheduleId));

            JobScheduleOperations jobScheduleOperations = context.BatchOMClient.JobScheduleOperations;
            jobScheduleOperations.EnableJobSchedule(jobScheduleId, additionBehaviors);
        }

        /// <summary>
        /// Disables the specified job schedule.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobScheduleId">The id of the job schedule to disable.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void DisableJobSchedule(BatchAccountContext context, string jobScheduleId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(jobScheduleId))
            {
                throw new ArgumentNullException("jobScheduleId");
            }

            WriteVerbose(string.Format(Resources.DisableJobSchedule, jobScheduleId));

            JobScheduleOperations jobScheduleOperations = context.BatchOMClient.JobScheduleOperations;
            jobScheduleOperations.DisableJobSchedule(jobScheduleId, additionBehaviors);
        }

        /// <summary>
        /// Terminates the specified job schedule.
        /// </summary>
        /// <param name="context">The account to use.</param>
        /// <param name="jobScheduleId">The id of the job schedule to terminate.</param>
        /// <param name="additionBehaviors">Additional client behaviors to perform.</param>
        public void TerminateJobSchedule(BatchAccountContext context, string jobScheduleId, IEnumerable<BatchClientBehavior> additionBehaviors = null)
        {
            if (string.IsNullOrWhiteSpace(jobScheduleId))
            {
                throw new ArgumentNullException("jobScheduleId");
            }

            WriteVerbose(string.Format(Resources.TerminateJobSchedule, jobScheduleId));

            JobScheduleOperations jobScheduleOperations = context.BatchOMClient.JobScheduleOperations;
            jobScheduleOperations.TerminateJobSchedule(jobScheduleId, additionBehaviors);
        }
    }
}

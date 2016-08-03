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
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using Microsoft.Azure.Commands.Scheduler.Models;
    using Microsoft.Azure.Commands.Scheduler.Properties;
    using Microsoft.Azure.Management.Scheduler;
    using Microsoft.Azure.Management.Scheduler.Models;
    using Microsoft.Rest.Azure;

    public partial class SchedulerClient
    {
        /// <summary>
        /// List job collection for current subscription.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">Name of the job collection.</param>
        /// <returns>list of job collection definition.</returns>
        public IList<PSJobCollectionDefinition> ListJobCollectionPS(string resourceGroupName = null, string jobCollectionName = null)
        {
            var jobCollectionDefinitionList = this.ListJobCollection(resourceGroupName, jobCollectionName);
            return Converter.ConvertJobCollectionDefinitionListToPSList(jobCollectionDefinitionList);
        }

        /// <summary>
        /// Create job collection.
        /// </summary>
        /// <param name="createJobCollectionParams">Job collection properties entered by user via Powershell.</param>
        /// <returns>Job collection definition.</returns>
        public PSJobCollectionDefinition CreateJobCollection(PSJobCollectionsParams createJobCollectionParams)
        {
            if (string.IsNullOrWhiteSpace(createJobCollectionParams.ResourceGroupName))
            {
                throw new PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(createJobCollectionParams.JobCollectionName))
            {
                throw new PSArgumentNullException(paramName: "JobCollectionName");
            }

            if (string.IsNullOrWhiteSpace(createJobCollectionParams.Region))
            {
                throw new PSArgumentNullException(paramName: "Region");
            }

            if (!DoesResourceGroupExists(createJobCollectionParams.ResourceGroupName))
            {
                throw new PSArgumentException(Resources.SchedulerInvalidResourceGroup);
            }

            if (!this.AvailableRegions.Contains(createJobCollectionParams.Region))
            {
                throw new PSArgumentException(Resources.SchedulerInvalidLocation);
            }

            if (HasJobCollection(createJobCollectionParams.ResourceGroupName, createJobCollectionParams.JobCollectionName))
            {
                throw new PSInvalidOperationException(string.Format(Resources.SchedulerExistingJobCollection, createJobCollectionParams.JobCollectionName, createJobCollectionParams.ResourceGroupName));
            }

            var skuDefinition = createJobCollectionParams.Plan.GetValueOrDefaultEnum<SkuDefinition>(defaultValue: SkuDefinition.Standard);

            if (skuDefinition == SkuDefinition.Free &&
                HasFreeJobCollection())
            {
                throw new PSInvalidOperationException(Resources.SchedulerNoMoreFreeJobCollection);
            }

            var quota = new JobCollectionQuota();

            this.PopulateJobCollectionQuota(quota, skuDefinition, createJobCollectionParams, newQuota: true);

            var jcProperties = new JobCollectionProperties()
            {
                Sku = new Sku(skuDefinition),
                Quota = quota,
            };

            var jobCollectionDefinition = new JobCollectionDefinition()
            {
                Location = createJobCollectionParams.Region,
                Name = createJobCollectionParams.JobCollectionName,
                Properties = jcProperties,
            };

            var jobCollectionDefinitionResult = this.SchedulerManagementClient.JobCollections.CreateOrUpdate(
                createJobCollectionParams.ResourceGroupName,
                createJobCollectionParams.JobCollectionName,
                jobCollectionDefinition);

            return Converter.ConvertJobCollectionDefinitionToPS(jobCollectionDefinitionResult);
        }

        /// <summary>
        /// Updates job collection.
        /// </summary>
        /// <param name="updateJobCollectionParams">Job collection properties to update.</param>
        /// <returns>Job collection definition.</returns>
        public PSJobCollectionDefinition UpdateJobCollection(PSJobCollectionsParams updateJobCollectionParams)
        {
            if (string.IsNullOrWhiteSpace(updateJobCollectionParams.ResourceGroupName))
            {
                throw new PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(updateJobCollectionParams.JobCollectionName))
            {
                throw new PSArgumentNullException(paramName: "JobCollectionName");
            }

            if (!string.IsNullOrWhiteSpace(updateJobCollectionParams.Region) &&
               !this.AvailableRegions.Contains(updateJobCollectionParams.Region))
            {
                throw new PSArgumentException(Resources.SchedulerInvalidLocation);
            }

            IList<JobCollectionDefinition> jobCollectionsDefition = this.ListJobCollection(
                updateJobCollectionParams.ResourceGroupName,
                updateJobCollectionParams.JobCollectionName);

            if (jobCollectionsDefition == null)
            {
                throw new PSArgumentException(
                    string.Format(Resources.JobCollectionDoesnotExist, updateJobCollectionParams.ResourceGroupName, updateJobCollectionParams.JobCollectionName));
            }

            JobCollectionDefinition jobCollectionDefinition = jobCollectionsDefition[0];

            if (jobCollectionDefinition.Properties.Sku.Name != SkuDefinition.Free &&
               !string.IsNullOrWhiteSpace(updateJobCollectionParams.Plan) &&
               updateJobCollectionParams.Plan.Equals(Constants.FreePlan, StringComparison.InvariantCultureIgnoreCase) &&
               this.HasFreeJobCollection())
            {
                throw new PSInvalidOperationException(Resources.SchedulerNoMoreFreeJobCollection);
            }

            JobCollectionQuota quota = jobCollectionDefinition.Properties.Quota;

            SkuDefinition skuDefinition = jobCollectionDefinition.Properties.Sku.Name.Value;
            bool newQuota = false;

            if (!string.IsNullOrWhiteSpace(updateJobCollectionParams.Plan))
            {
                skuDefinition = updateJobCollectionParams.Plan.GetValueOrDefaultEnum<SkuDefinition>(defaultValue:SkuDefinition.Standard);
                newQuota = true;
            }

            this.PopulateJobCollectionQuota(quota, skuDefinition, updateJobCollectionParams, newQuota);

            var jcProperties = new JobCollectionProperties()
            {
                Sku = new Sku(skuDefinition),
                Quota = quota,
            };


            jobCollectionDefinition.Location = updateJobCollectionParams.Region != null ? updateJobCollectionParams.Region : jobCollectionDefinition.Location;
            jobCollectionDefinition.Properties = jcProperties;

            var jobCollectionDefinitionResult = this.SchedulerManagementClient.JobCollections.CreateOrUpdate(
                updateJobCollectionParams.ResourceGroupName,
                updateJobCollectionParams.JobCollectionName,
                jobCollectionDefinition);

            return Converter.ConvertJobCollectionDefinitionToPS(jobCollectionDefinitionResult);
        }

        /// <summary>
        /// Delete job colleciton.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resoure group.</param>
        /// <param name="jobCollectionName">Job collection to be deleted.</param>
        public void DeleteJobCollections(string resourceGroupName, string jobCollectionName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSArgumentNullException(paramName: "JobCollectionName");
            }

            this.SchedulerManagementClient.JobCollections.Delete(resourceGroupName, jobCollectionName);
        }

        /// <summary>
        /// Disable job collection.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">Job collection to be disabled.</param>
        public void DisableJobCollection(string resourceGroupName, string jobCollectionName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSArgumentNullException(paramName: "JobCollectionName");
            }

            this.SchedulerManagementClient.JobCollections.Disable(resourceGroupName, jobCollectionName);
        }

        /// <summary>
        /// Enable job collection.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">Job collection to enabled.</param>
        public void EnableJobCollection(string resourceGroupName, string jobCollectionName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(jobCollectionName))
            {
                throw new PSArgumentNullException(paramName: "JobCollectionName");
            }

            this.SchedulerManagementClient.JobCollections.Enable(resourceGroupName, jobCollectionName);
        }

        /// <summary>
        /// List job collection.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">Name of the job collection.</param>
        /// <returns>List of job collection.</returns>
        internal IList<JobCollectionDefinition> ListJobCollection(string resourceGroupName = null, string jobCollectionName = null)
        {
            IList<JobCollectionDefinition> jobCollectionsDefinition;

            if (!string.IsNullOrWhiteSpace(resourceGroupName) && !string.IsNullOrWhiteSpace(jobCollectionName))
            {
                JobCollectionDefinition jobCollectionDefinition = this.SchedulerManagementClient.JobCollections.Get(resourceGroupName, jobCollectionName);
                jobCollectionsDefinition = new List<JobCollectionDefinition>() { jobCollectionDefinition };
            }
            else if (!string.IsNullOrWhiteSpace(resourceGroupName))
            {
                jobCollectionsDefinition = this.ListJobCollectionsByResourceGroupName(resourceGroupName);
            }
            else
            {
                jobCollectionsDefinition = this.ListJobCollectionsBySubscription();

                if (!string.IsNullOrWhiteSpace(jobCollectionName))
                {
                    jobCollectionsDefinition = jobCollectionsDefinition.Where((jobCollectionDefinition) => jobCollectionDefinition.Name.Equals(jobCollectionName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                }
            }

            return jobCollectionsDefinition;
        }

        /// <summary>
        /// Returns true if subscription has a free job collection.
        /// </summary>
        /// <returns>true, if subscription has a free job collection.</returns>
        internal bool HasFreeJobCollection()
        {
            try
            {
                IList<JobCollectionDefinition> jobCollections = this.ListJobCollectionsBySubscription();

                if (VerifyFreeJobCollectionExists(jobCollections))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw e;
            }
        }

        /// <summary>
        /// Checks whether job collection exists.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <param name="jobCollectionName">Name of the job collection.</param>
        /// <returns>True if job collection exist, otherwise false.</returns>
        internal bool HasJobCollection(string resourceGroupName, string jobCollectionName)
        {
            try
            {
                IList<JobCollectionDefinition> jobCollections = this.ListJobCollection(resourceGroupName, jobCollectionName);

                if (jobCollections != null && jobCollections.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw e;
            }
        }

        /// <summary>
        /// List all job collection for the subscription.
        /// </summary>
        /// <returns>List of job collectoin definition.</returns>
        private IList<JobCollectionDefinition> ListJobCollectionsBySubscription()
        {
            var listOfJobCollections = new List<JobCollectionDefinition>();
            IPage<JobCollectionDefinition> jobCollections = this.SchedulerManagementClient.JobCollections.ListBySubscription();

            listOfJobCollections.AddRange(jobCollections);

            while (!string.IsNullOrWhiteSpace(jobCollections.NextPageLink))
            {
                jobCollections = this.SchedulerManagementClient.JobCollections.ListBySubscriptionNext(jobCollections.NextPageLink);
                listOfJobCollections.AddRange(jobCollections);
            }

            return listOfJobCollections;
        }

        /// <summary>
        /// List all job collection for the resource group.
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group.</param>
        /// <returns>List of job collection definition.</returns>
        private IList<JobCollectionDefinition> ListJobCollectionsByResourceGroupName(string resourceGroupName)
        {
            var listOfJobCollections = new List<JobCollectionDefinition>();
            IPage<JobCollectionDefinition> jobCollections = this.SchedulerManagementClient.JobCollections.ListByResourceGroup(resourceGroupName);

            listOfJobCollections.AddRange(jobCollections);

            while (!string.IsNullOrWhiteSpace(jobCollections.NextPageLink))
            {
                jobCollections = this.SchedulerManagementClient.JobCollections.ListByResourceGroupNext(jobCollections.NextPageLink);
                listOfJobCollections.AddRange(jobCollections);
            }

            return listOfJobCollections;
        }

        /// <summary>
        /// Populate quota object with valid values.
        /// </summary>
        /// <param name="quota">Quota object.</param>
        /// <param name="skuDefinition">Sku definition (Free, Standard, P10Premium, and P20Premium</param>
        /// <param name="jobCollectionParams">Job collection parameters set via powershell.</param>
        /// <param name="newQuota">boolean to indicate whether quota object is new or existing.</param>
        private void PopulateJobCollectionQuota(JobCollectionQuota quota, SkuDefinition skuDefinition, PSJobCollectionsParams jobCollectionParams, bool newQuota = true)
        {
            if (quota == null && !newQuota)
            {
                throw new ArgumentOutOfRangeException("quota", "Quota is null.");
            }

            if (quota == null)
            {
                quota = new JobCollectionQuota();
            }

            int existingMaxCountValue = Constants.MaxJobCountQuotaStandard;
            TimeSpan existingMinRecurrenceValue = Constants.MinRecurrenceQuotaStandard;

            if (!newQuota)
            {
                existingMaxCountValue = quota.MaxJobCount.Value;
                existingMinRecurrenceValue = SchedulerUtility.ToTimeSpan(quota.MaxRecurrence.Frequency.Value, quota.MaxRecurrence.Interval.Value);
            }

            switch (skuDefinition)
            {
                case SkuDefinition.Free:
                    quota.MaxJobCount = this.GetMaxJobCount(
                        jobCollectionParams.MaxJobCount,
                        newQuota ? Constants.MaxJobCountQuotaFree : existingMaxCountValue,
                        Resources.JobCollectionMaxJobQuotaTooLargeForFree);

                    quota.MaxRecurrence = this.GetMaxRecurrence(
                        jobCollectionParams.Frequency,
                        jobCollectionParams.Interval,
                        newQuota ? Constants.MinRecurrenceQuotaFree : existingMinRecurrenceValue,
                        Resources.JobCollectionMaxRecurrenceQuotaTooLargeForFree);
                    break;

                case SkuDefinition.Standard:
                case SkuDefinition.P10Premium:
                default:
                    quota.MaxJobCount = this.GetMaxJobCount(
                        jobCollectionParams.MaxJobCount,
                        newQuota ? Constants.MaxJobCountQuotaStandard : existingMaxCountValue,
                        Resources.JobCollectionMaxJobQuotaTooLargeForPaid);

                    quota.MaxRecurrence = this.GetMaxRecurrence(
                        jobCollectionParams.Frequency,
                        jobCollectionParams.Interval,
                        newQuota ? Constants.MinRecurrenceQuotaStandard : existingMinRecurrenceValue,
                        Resources.JobCollectionMaxJobQuotaTooLargeForPaid);
                    break;

                case SkuDefinition.P20Premium:
                    quota.MaxJobCount = this.GetMaxJobCount(
                    jobCollectionParams.MaxJobCount,
                    newQuota ? Constants.MaxJobCountQuotaP20Premium : existingMaxCountValue,
                    Resources.JobCollectionMaxJobQuotaTooLargeForPaid);

                    quota.MaxRecurrence = this.GetMaxRecurrence(
                        jobCollectionParams.Frequency,
                        jobCollectionParams.Interval,
                        newQuota ? Constants.MinRecurrenceQuotaP20Premium : existingMinRecurrenceValue,
                        Resources.JobCollectionMaxJobQuotaTooLargeForPaid);
                    break;
            }
        }

        /// <summary>
        /// Gets maximum job count for the job collection.
        /// </summary>
        /// <param name="maxJobCountInput">Max job count specifed by the user.</param>
        /// <param name="defaultMaxCount">Default max job cound allowed for the job collection.</param>
        /// <param name="errorMessage">Error message for invalid job count.</param>
        /// <returns>Allowed max job count.</returns>
        private int? GetMaxJobCount(int? maxJobCountInput, int defaultMaxCount, string errorMessage = null)
        {
            int? maxJobCount = defaultMaxCount;

            if (maxJobCountInput.HasValue)
            {
                if (maxJobCountInput > defaultMaxCount)
                {
                    throw new PSArgumentOutOfRangeException("MaxJobCount",
                        maxJobCountInput,
                        string.Format(errorMessage, defaultMaxCount, maxJobCountInput.Value));
                }

                maxJobCount = maxJobCountInput;
            }

            return maxJobCount;
        }

        /// <summary>
        /// Get max recurrence for the job collection.
        /// </summary>
        /// <param name="frequencyInput">Frequence specified via powershell.</param>
        /// <param name="intervalInput">Interval specified via powershell.</param>
        /// <param name="minRecurrenceQuota">Min reurrence quota.</param>
        /// <param name="errorMessage">Error message for invalid recurrence.</param>
        /// <returns>Maximum recurrence.</returns>
        private JobMaxRecurrence GetMaxRecurrence(string frequencyInput, int? intervalInput, TimeSpan minRecurrenceQuota, string errorMessage)
        {
            int interval = intervalInput.HasValue ? intervalInput.Value : minRecurrenceQuota.GetInterval();
            RecurrenceFrequency frequency = frequencyInput.GetValueOrDefaultEnum<RecurrenceFrequency>(defaultValue: minRecurrenceQuota.GetFrequency());

            TimeSpan recurrenceTimeSpan = SchedulerUtility.ToTimeSpan(frequency, interval);

            if (recurrenceTimeSpan < minRecurrenceQuota)
            {
                throw new PSArgumentException(string.Format(errorMessage, recurrenceTimeSpan, minRecurrenceQuota));
            }

            return new JobMaxRecurrence(frequency, interval);
        }

        /// <summary>
        /// Verified whether free job collection exist in current subscription.
        /// </summary>
        /// <param name="jobCollections">List of job collection.</param>
        /// <returns></returns>
        private bool VerifyFreeJobCollectionExists(IEnumerable<JobCollectionDefinition> jobCollections)
        {

            return jobCollections.Any((jobCollectionDefinition) =>
            {
                return jobCollectionDefinition.Properties.Sku.Name == SkuDefinition.Free;
            });
        }

        /// <summary>
        /// Verifies whether job collectio already exists.
        /// </summary>
        /// <param name="jobCollections">List of job collection.</param>
        /// <param name="jobCollectionName">Name of the job collectin.</param>
        /// <returns>True, if job collectio exists, otherwise false.</returns>
        private bool VerifyJobCollectionAlreadyExists(IEnumerable<JobCollectionDefinition> jobCollections, string jobCollectionName)
        {
            return jobCollections.Any((jobCollectionDefinition) =>
            {
                return jobCollectionDefinition.Name.Equals(jobCollectionName, StringComparison.InvariantCultureIgnoreCase);
            });
        }
    }
}


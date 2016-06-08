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
using System.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model;
using Microsoft.WindowsAzure.Management.Scheduler.Models;
using Microsoft.WindowsAzure.Management.Scheduler;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler
{
    public partial class SchedulerMgmntClient
    {
        /// <summary>
        /// Creates a new Scheduler Job Collection
        /// </summary>
        /// <param name="jobCollectionRequest">Request values</param>
        /// <param name="status">Status of create action</param>
        /// <returns>Created Scheduler Job Collection</returns>
        public PSJobCollection CreateJobCollection(PSCreateJobCollectionParams jobCollectionRequest, out string status)
        {
            if (!this.AvailableRegions.Contains(jobCollectionRequest.Region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            //Only one free job collection can exist in a subscription
            if (this.HasFreeJobCollections(jobCollectionRequest.Region) && !string.IsNullOrEmpty(jobCollectionRequest.JobCollectionPlan) && jobCollectionRequest.JobCollectionPlan.Equals("Free"))
                throw new Exception(Resources.SchedulerNoMoreFreeJobCollection);

            //Job collection name should be unique in a region
            if (this.HasJobCollection(jobCollectionRequest.Region, jobCollectionRequest.JobCollectionName))
                throw new Exception(string.Format(Resources.SchedulerExistingJobCollection, jobCollectionRequest.JobCollectionName, jobCollectionRequest.Region));

            //Create cloud service, if not available
            if (!IsCloudServiceCreated(jobCollectionRequest.Region))
            {
                csmClient.CloudServices.Create(
                    cloudServiceName: jobCollectionRequest.Region.ToCloudServiceName(),
                    parameters: new CloudServiceCreateParameters
                    {
                        Description = "Cloud service created by scheduler powershell",
                        GeoRegion = jobCollectionRequest.Region,
                        Label = "Cloud service created by scheduler powershell"
                    });
            }

            JobCollectionCreateParameters jobCollectionCreateParams = new JobCollectionCreateParameters
            {
                IntrinsicSettings = new JobCollectionIntrinsicSettings
                {
                    Plan = !string.IsNullOrWhiteSpace(jobCollectionRequest.JobCollectionPlan) ?
                        (JobCollectionPlan)Enum.Parse(typeof(JobCollectionPlan), jobCollectionRequest.JobCollectionPlan) : JobCollectionPlan.Standard       
                }
            };

            switch (jobCollectionCreateParams.IntrinsicSettings.Plan)
            {
                case JobCollectionPlan.Free:
                    jobCollectionCreateParams.IntrinsicSettings.Quota = new JobCollectionQuota
                    {
                        MaxJobCount = jobCollectionRequest.MaxJobCount.HasValue ? jobCollectionRequest.MaxJobCount : this.FreeMaxJobCountValue,
                        MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Interval = jobCollectionRequest.MaxJobInterval.HasValue ? jobCollectionRequest.MaxJobInterval.Value : this.FreeMinRecurrenceValue.GetInterval(),
                            Frequency = !string.IsNullOrWhiteSpace(jobCollectionRequest.MaxJobFrequency)
                                ? (JobCollectionRecurrenceFrequency)Enum.Parse(typeof(JobCollectionRecurrenceFrequency), jobCollectionRequest.MaxJobFrequency)
                                : this.FreeMinRecurrenceValue.GetFrequency()
                        }
                    };
                    break;

                case JobCollectionPlan.Standard:
                default:
                    jobCollectionCreateParams.IntrinsicSettings.Quota = new JobCollectionQuota
                    {
                        MaxJobCount = jobCollectionRequest.MaxJobCount.HasValue ? jobCollectionRequest.MaxJobCount : this.StandardMaxJobCountValue,
                        MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Interval = jobCollectionRequest.MaxJobInterval.HasValue ? jobCollectionRequest.MaxJobInterval.Value : this.StandardMinRecurrenceValue.GetInterval(),
                            Frequency = !string.IsNullOrWhiteSpace(jobCollectionRequest.MaxJobFrequency)
                                ? (JobCollectionRecurrenceFrequency)Enum.Parse(typeof(JobCollectionRecurrenceFrequency), jobCollectionRequest.MaxJobFrequency)
                                : this.StandardMinRecurrenceValue.GetFrequency()
                        }
                    };
                    break;

                case JobCollectionPlan.Premium:
                    jobCollectionCreateParams.IntrinsicSettings.Quota = new JobCollectionQuota
                    {
                        MaxJobCount = jobCollectionRequest.MaxJobCount.HasValue ? jobCollectionRequest.MaxJobCount : this.PremiumMaxJobCountValue,
                        MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Interval = jobCollectionRequest.MaxJobInterval.HasValue ? jobCollectionRequest.MaxJobInterval.Value : this.PremiumMinRecurrenceValue.GetInterval(),
                            Frequency = !string.IsNullOrWhiteSpace(jobCollectionRequest.MaxJobFrequency)
                                ? (JobCollectionRecurrenceFrequency)Enum.Parse(typeof(JobCollectionRecurrenceFrequency), jobCollectionRequest.MaxJobFrequency)
                                : this.PremiumMinRecurrenceValue.GetFrequency()
                        }
                    };
                    break;
            }            

            SchedulerOperationStatusResponse jobCollectionCreateResponse = schedulerManagementClient.JobCollections.Create(
                cloudServiceName: jobCollectionRequest.Region.ToCloudServiceName(), 
                jobCollectionName: jobCollectionRequest.JobCollectionName, 
                parameters: jobCollectionCreateParams);

            status = jobCollectionCreateResponse.StatusCode.ToString().Equals("OK") ? "Job Collection has been created" : jobCollectionCreateResponse.StatusCode.ToString();

            return GetJobCollection(jobCollectionRequest.Region, jobCollectionRequest.JobCollectionName).FirstOrDefault();
        }

        /// <summary>
        /// Returns true if subscription has a free job collection
        /// </summary>
        /// <param name="region">Region name</param>
        /// <returns>true, if subscription has a free job collection</returns>
        internal bool HasFreeJobCollections(string region)
        {
            bool isPresent = false;
            string cloudService = region.ToCloudServiceName();
            foreach (CloudServiceListResponse.CloudService cs in csmClient.CloudServices.List().CloudServices)
            {
                if (cs.Name.Equals(cloudService, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (CloudServiceGetResponse.Resource csRes in csmClient.CloudServices.Get(cs.Name).Resources)
                    {
                        if (csRes.Type.Contains(Constants.JobCollectionResource) && !csRes.State.Equals("Unknown"))
                        {
                            JobCollectionGetResponse jcGetResponse = schedulerManagementClient.JobCollections.Get(cs.Name, csRes.Name);
                            if (jcGetResponse.IntrinsicSettings != null && jcGetResponse.IntrinsicSettings.Plan.Equals(JobCollectionPlan.Free))
                            {
                                isPresent = true;
                                break;
                            }
                        }
                    }
                }
            }
            return isPresent;
        }

        /// <summary>
        /// Returns true if subscription already has a job collection with the given name in the region
        /// </summary>
        /// <param name="jobCollectionName">The job collection name</param>
        /// <returns>true, if job collection with given name already exists</returns>
        internal bool HasJobCollection(string region, string jobCollectionName)
        {
            bool isPresent = false;
            string cloudService = region.ToCloudServiceName();
            foreach (CloudServiceListResponse.CloudService cs in csmClient.CloudServices.List().CloudServices)
            {
                if (cs.Name.Equals(cloudService, StringComparison.OrdinalIgnoreCase))
                {
                    foreach (CloudServiceGetResponse.Resource csRes in csmClient.CloudServices.Get(cs.Name).Resources)
                    {
                        if (csRes.Type.Contains(Constants.JobCollectionResource) && csRes.Name.Equals(jobCollectionName, StringComparison.OrdinalIgnoreCase))
                        {
                            isPresent = true;
                            break;
                        }
                    }
                }
            }
            return isPresent;
        }

        /// <summary>
        /// Verifies if cloud service is already created
        /// </summary>
        /// <param name="region">location to look under</param>
        /// <returns>true, if already created</returns>
        internal bool IsCloudServiceCreated(string region)
        {
            bool created = false;
            foreach (CloudServiceListResponse.CloudService cs in csmClient.CloudServices.List())
            {
                if (cs.Name.Equals(region.ToCloudServiceName(), StringComparison.OrdinalIgnoreCase))
                {
                    created = true;
                    break;
                }
            }
            return created;
        }

        /// <summary>
        /// Updates a job collection
        /// </summary>
        /// <param name="jobCollectionRequest">The job collection request</param>
        /// <param name="status">Status of update operation</param>
        /// <returns>The updated job collection</returns>
        public PSJobCollection UpdateJobCollection(PSCreateJobCollectionParams jobCollectionRequest, out string status)
        {
            if (!this.AvailableRegions.Contains(jobCollectionRequest.Region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            //Get existing job collection
            JobCollectionGetResponse jcGetResponse = schedulerManagementClient.JobCollections.Get(
                cloudServiceName: jobCollectionRequest.Region.ToCloudServiceName(),
                jobCollectionName: jobCollectionRequest.JobCollectionName);

            JobCollectionUpdateParameters jcUpdateParams = new JobCollectionUpdateParameters
            {
                IntrinsicSettings = jcGetResponse.IntrinsicSettings,
                ETag = jcGetResponse.ETag,
                Label = jcGetResponse.Label                
            };

            if (!string.IsNullOrWhiteSpace(jobCollectionRequest.JobCollectionPlan))
            {
                jcUpdateParams.IntrinsicSettings.Plan = (JobCollectionPlan)Enum.Parse(typeof(JobCollectionPlan), jobCollectionRequest.JobCollectionPlan);
            }

            if (jobCollectionRequest.MaxJobCount.HasValue)
            {
                if (jcUpdateParams.IntrinsicSettings.Quota != null)
                {
                    jcUpdateParams.IntrinsicSettings.Quota.MaxJobCount = jobCollectionRequest.MaxJobCount;
                }
                else
                {
                    jcUpdateParams.IntrinsicSettings.Quota = new JobCollectionQuota { MaxJobCount = jobCollectionRequest.MaxJobCount };
                }
            }

            if (jobCollectionRequest.MaxJobInterval.HasValue)
            {
                if (jcUpdateParams.IntrinsicSettings.Quota != null)
                {
                    if (jcUpdateParams.IntrinsicSettings.Quota.MaxRecurrence != null)
                    {
                        jcUpdateParams.IntrinsicSettings.Quota.MaxRecurrence.Interval = jobCollectionRequest.MaxJobInterval.Value;
                    }
                    else
                    {
                        jcUpdateParams.IntrinsicSettings.Quota.MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Interval = jobCollectionRequest.MaxJobInterval.Value
                        };
                    }
                }
                else
                {
                    jcUpdateParams.IntrinsicSettings.Quota = new JobCollectionQuota
                    {
                        MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Interval = jobCollectionRequest.MaxJobInterval.Value
                        }
                    };
                }
            }

            if (!string.IsNullOrWhiteSpace(jobCollectionRequest.MaxJobFrequency))
            {
                if (jcUpdateParams.IntrinsicSettings.Quota != null)
                {
                    if (jcUpdateParams.IntrinsicSettings.Quota.MaxRecurrence != null)
                    {
                        jcUpdateParams.IntrinsicSettings.Quota.MaxRecurrence.Frequency = (JobCollectionRecurrenceFrequency)Enum.Parse(typeof(JobCollectionRecurrenceFrequency), jobCollectionRequest.MaxJobFrequency);
                    }
                    else
                    {
                        jcUpdateParams.IntrinsicSettings.Quota.MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Frequency = (JobCollectionRecurrenceFrequency)Enum.Parse(typeof(JobCollectionRecurrenceFrequency), jobCollectionRequest.MaxJobFrequency)
                        };
                    }
                }
                else
                {
                    jcUpdateParams.IntrinsicSettings.Quota = new JobCollectionQuota
                    {
                        MaxRecurrence = new JobCollectionMaxRecurrence
                        {
                            Frequency = (JobCollectionRecurrenceFrequency)Enum.Parse(typeof(JobCollectionRecurrenceFrequency), jobCollectionRequest.MaxJobFrequency)
                        }                    
                    };
                }
            }

            SchedulerOperationStatusResponse response = schedulerManagementClient.JobCollections.Update(
                cloudServiceName: jobCollectionRequest.Region.ToCloudServiceName(), 
                jobCollectionName: jobCollectionRequest.JobCollectionName,
                parameters: jcUpdateParams);

            status = response.StatusCode.ToString().Equals("OK") ? "Job Collection has been updated" : response.StatusCode.ToString();

            return GetJobCollection(jobCollectionRequest.Region, jobCollectionRequest.JobCollectionName).FirstOrDefault();
        }
    }
}

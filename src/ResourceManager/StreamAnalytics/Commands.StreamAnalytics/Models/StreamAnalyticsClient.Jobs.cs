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

using Hyak.Common;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public partial class StreamAnalyticsClient
    {
        public virtual PSJob GetJob(string resourceGroupName, string jobName, string propertiesToExpand)
        {
            JobGetParameters parameters = new JobGetParameters(propertiesToExpand);
            var response = StreamAnalyticsManagementClient.StreamingJobs.Get(
                resourceGroupName, jobName, parameters);

            return new PSJob(response.Job)
            {
                ResourceGroupName = resourceGroupName
            };
        }

        public virtual List<PSJob> ListJobs(string resourceGroupName, string propertiesToExpand)
        {
            List<PSJob> jobs = new List<PSJob>();
            JobListParameters parameters = new JobListParameters(propertiesToExpand);
            var response = StreamAnalyticsManagementClient.StreamingJobs.ListJobsInResourceGroup(resourceGroupName, parameters);

            if (response != null && response.Value != null)
            {
                foreach (var job in response.Value)
                {
                    jobs.Add(new PSJob(job)
                    {
                        ResourceGroupName = resourceGroupName
                    });
                }
            }

            return jobs;
        }

        public virtual List<PSJob> ListJobs(string propertiesToExpand)
        {
            List<PSJob> jobs = new List<PSJob>();
            JobListParameters parameters = new JobListParameters(propertiesToExpand);
            var response = StreamAnalyticsManagementClient.StreamingJobs.ListJobsInSubscription(parameters);

            if (response != null && response.Value != null)
            {
                foreach (var job in response.Value)
                {
                    jobs.Add(new PSJob(job)
                    {
                        ResourceGroupName = StreamAnalyticsCommonUtilities.ExtractResourceGroupFromId(job.Id)
                    });
                }
            }

            return jobs;
        }

        public virtual List<PSJob> FilterPSJobs(JobFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            List<PSJob> jobs = new List<PSJob>();

            if (!string.IsNullOrWhiteSpace(filterOptions.JobName))
            {
                if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
                {
                    throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
                }

                jobs.Add(GetJob(filterOptions.ResourceGroupName, filterOptions.JobName,
                    filterOptions.PropertiesToExpand));
            }
            else if (!string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                jobs.AddRange(ListJobs(filterOptions.ResourceGroupName, filterOptions.PropertiesToExpand));
            }
            else
            {
                jobs.AddRange(ListJobs(filterOptions.PropertiesToExpand));
            }

            return jobs;
        }

        public virtual PSJob CreateOrUpdatePSJob(string resourceGroupName, string jobName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            // If create failed, the current behavior is to throw
            var response =
                StreamAnalyticsManagementClient.StreamingJobs.CreateOrUpdateWithRawJsonContent(
                    resourceGroupName,
                    jobName,
                    new JobCreateOrUpdateWithRawJsonContentParameters() { Content = rawJsonContent });

            return new PSJob(response.Job)
            {
                ResourceGroupName = resourceGroupName,
                JobName = jobName
            };
        }

        public virtual PSJob CreatePSJob(CreatePSJobParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            PSJob job = null;
            parameter.ConfirmAction(
                    parameter.Force,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.JobExists,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.JobCreating,
                        parameter.JobName,
                        parameter.ResourceGroupName),
                    parameter.JobName,
                    () =>
                    {
                        job = CreateOrUpdatePSJob(parameter.ResourceGroupName, parameter.JobName, parameter.RawJsonContent);
                    },
                    () => CheckJobExists(parameter.ResourceGroupName, parameter.JobName));
            return job;
        }

        public virtual HttpStatusCode StartPSJob(string resourceGroupName, string jobName, JobStartParameters parameter)
        {
            AzureOperationResponse response = StreamAnalyticsManagementClient.StreamingJobs.Start(resourceGroupName, jobName, parameter);

            return response.StatusCode;
        }

        public virtual HttpStatusCode StartPSJob(StartPSJobParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            return StartPSJob(parameter.ResourceGroupName, parameter.JobName, parameter.StartParameters);
        }

        public virtual HttpStatusCode StopPSJob(string resourceGroupName, string jobName)
        {
            AzureOperationResponse response = StreamAnalyticsManagementClient.StreamingJobs.Stop(resourceGroupName, jobName);

            return response.StatusCode;
        }

        public virtual HttpStatusCode StopPSJob(JobParametersBase parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            return StopPSJob(parameter.ResourceGroupName, parameter.JobName);
        }

        public virtual HttpStatusCode RemovePSJob(string resourceGroupName, string jobName)
        {
            AzureOperationResponse response = StreamAnalyticsManagementClient.StreamingJobs.Delete(resourceGroupName, jobName);

            return response.StatusCode;
        }

        public virtual HttpStatusCode RemovePSJob(JobParametersBase parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            return RemovePSJob(parameter.ResourceGroupName, parameter.JobName);
        }

        private bool CheckJobExists(string resourceGroupName, string jobName)
        {
            try
            {
                PSJob job = GetJob(resourceGroupName, jobName, string.Empty);
                return true;
            }
            catch (CloudException e)
            {
                //Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
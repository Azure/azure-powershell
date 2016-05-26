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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model;
using Microsoft.WindowsAzure.Scheduler;
using Microsoft.WindowsAzure.Scheduler.Models;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler
{
    public partial class SchedulerMgmntClient
    {
        #region Create Jobs

        /// <summary>
        /// Populates ErrorAction values from the request
        /// </summary>
        /// <param name="jobRequest">Request values</param>
        /// <returns>Populated JobErrorAction object</returns>
        private JobErrorAction PopulateErrorAction(PSCreateJobParams jobRequest)
        {
            if (!string.IsNullOrEmpty(jobRequest.ErrorActionMethod) && jobRequest.ErrorActionUri != null)
            {
                JobErrorAction errorAction = new JobErrorAction
                {
                    Request = new JobHttpRequest
                    {
                        Uri = jobRequest.ErrorActionUri,
                        Method = jobRequest.ErrorActionMethod
                    }
                };

                if (jobRequest.ErrorActionHeaders != null)
                {
                    errorAction.Request.Headers = jobRequest.ErrorActionHeaders.ToDictionary();
                }

                if (jobRequest.ErrorActionMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase) || jobRequest.ErrorActionMethod.Equals("POST", StringComparison.OrdinalIgnoreCase))
                    errorAction.Request.Body = jobRequest.ErrorActionBody;
                return errorAction;
            }

            if (!string.IsNullOrEmpty(jobRequest.ErrorActionSasToken) && !string.IsNullOrEmpty(jobRequest.ErrorActionStorageAccount) && !string.IsNullOrEmpty(jobRequest.ErrorActionQueueName))
            {
                return new JobErrorAction
                {
                    QueueMessage = new JobQueueMessage
                    {
                        QueueName = jobRequest.ErrorActionQueueName,
                        StorageAccountName = jobRequest.ErrorActionStorageAccount,
                        SasToken = jobRequest.ErrorActionSasToken,
                        Message = jobRequest.ErrorActionQueueBody ?? ""
                    }
                };
            }
            return null;
        }

        /// <summary>
        /// Creates a new Http Scheduler job
        /// </summary>
        /// <param name="jobRequest">Request values</param>
        /// <param name="status">Status of create action</param>
        /// <returns>Created Http Scheduler job</returns>
        public PSJobDetail CreateHttpJob(PSCreateJobParams jobRequest, out string status)
        {
            if (!this.AvailableRegions.Contains(jobRequest.Region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            SchedulerClient schedulerClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(jobRequest.Region.ToCloudServiceName(), jobRequest.JobCollectionName, csmClient.Credentials, schedulerManagementClient.BaseUri);

            JobCreateOrUpdateParameters jobCreateParams = new JobCreateOrUpdateParameters
            {
                Action = new JobAction
                {
                    Request = new JobHttpRequest
                    {
                        Uri = jobRequest.Uri,
                        Method = jobRequest.Method
                    },
                }
            };

            if (jobRequest.Headers != null)
            {
                jobCreateParams.Action.Request.Headers = jobRequest.Headers.ToDictionary();
            }

            if (jobRequest.HttpAuthType.Equals("ClientCertificate", StringComparison.OrdinalIgnoreCase))
            {
                if (jobRequest.ClientCertPfx != null && jobRequest.ClientCertPassword != null)
                {
                    jobCreateParams.Action.Request.Authentication = new ClientCertAuthentication
                    {
                        Type = HttpAuthenticationType.ClientCertificate,
                        Password = jobRequest.ClientCertPassword,
                        Pfx = jobRequest.ClientCertPfx
                    };
                }
                else
                {
                    throw new InvalidOperationException(Resources.SchedulerInvalidClientCertAuthRequest);
                }
            }

            if (jobRequest.HttpAuthType.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                if (!string.IsNullOrEmpty(jobRequest.ClientCertPfx) || !string.IsNullOrEmpty(jobRequest.ClientCertPassword))
                {
                    throw new InvalidOperationException(Resources.SchedulerInvalidNoneAuthRequest);
                }
            }

            if (jobRequest.Method.Equals("PUT", StringComparison.OrdinalIgnoreCase) || jobRequest.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                jobCreateParams.Action.Request.Body = jobRequest.Body;

            //Populate job error action
            jobCreateParams.Action.ErrorAction = PopulateErrorAction(jobRequest);

            jobCreateParams.StartTime = jobRequest.StartTime ?? default(DateTime?);

            if (jobRequest.Interval != null || jobRequest.ExecutionCount != null || !string.IsNullOrEmpty(jobRequest.Frequency) || jobRequest.EndTime != null)
            {
                jobCreateParams.Recurrence = new JobRecurrence();
                jobCreateParams.Recurrence.Count = jobRequest.ExecutionCount ?? default(int?);

                if (!string.IsNullOrEmpty(jobRequest.Frequency))
                    jobCreateParams.Recurrence.Frequency = (JobRecurrenceFrequency)Enum.Parse(typeof(JobRecurrenceFrequency), jobRequest.Frequency);

                jobCreateParams.Recurrence.Interval = jobRequest.Interval ?? default(int?);

                jobCreateParams.Recurrence.EndTime = jobRequest.EndTime ?? default(DateTime?);
            }

            JobCreateOrUpdateResponse jobCreateResponse = schedulerClient.Jobs.CreateOrUpdate(jobRequest.JobName, jobCreateParams);

            if (!string.IsNullOrEmpty(jobRequest.JobState) && jobRequest.JobState.Equals("DISABLED", StringComparison.OrdinalIgnoreCase))
                schedulerClient.Jobs.UpdateState(jobRequest.JobName, new JobUpdateStateParameters { State = JobState.Disabled });

            status = jobCreateResponse.StatusCode.ToString().Equals("OK") ? "Job has been updated" : jobCreateResponse.StatusCode.ToString();

            return GetJobDetail(jobRequest.JobCollectionName, jobRequest.JobName, jobRequest.Region.ToCloudServiceName());
        }

        /// <summary>
        /// Creates a Storage Queue Scheduler job
        /// </summary>
        /// <param name="jobRequest">Request values</param>
        /// <param name="status">Status of create action</param>
        /// <returns>Created Storage Queue Scheduler job</returns>
        public PSJobDetail CreateStorageJob(PSCreateJobParams jobRequest, out string status)
        {
            if (!this.AvailableRegions.Contains(jobRequest.Region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            SchedulerClient schedulerClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(jobRequest.Region.ToCloudServiceName(), jobRequest.JobCollectionName, csmClient.Credentials, schedulerManagementClient.BaseUri);

            JobCreateOrUpdateParameters jobCreateParams = new JobCreateOrUpdateParameters
            {
                Action = new JobAction
                {
                    Type = JobActionType.StorageQueue,
                    QueueMessage = new JobQueueMessage
                    {
                        Message = jobRequest.StorageQueueMessage ?? string.Empty,
                        StorageAccountName = jobRequest.StorageAccount,
                        QueueName = jobRequest.QueueName,
                        SasToken = jobRequest.SasToken
                    },
                }
            };

            //Populate job error action
            jobCreateParams.Action.ErrorAction = PopulateErrorAction(jobRequest);

            jobCreateParams.StartTime = jobRequest.StartTime ?? default(DateTime?);

            if (jobRequest.Interval != null || jobRequest.ExecutionCount != null || !string.IsNullOrEmpty(jobRequest.Frequency) || jobRequest.EndTime != null)
            {
                jobCreateParams.Recurrence = new JobRecurrence();
                jobCreateParams.Recurrence.Count = jobRequest.ExecutionCount ?? default(int?);

                if (!string.IsNullOrEmpty(jobRequest.Frequency))
                    jobCreateParams.Recurrence.Frequency = (JobRecurrenceFrequency)Enum.Parse(typeof(JobRecurrenceFrequency), jobRequest.Frequency);

                jobCreateParams.Recurrence.Interval = jobRequest.Interval ?? default(int?);

                jobCreateParams.Recurrence.EndTime = jobRequest.EndTime ?? default(DateTime?);
            }

            JobCreateOrUpdateResponse jobCreateResponse = schedulerClient.Jobs.CreateOrUpdate(jobRequest.JobName, jobCreateParams);

            if (!string.IsNullOrEmpty(jobRequest.JobState) && jobRequest.JobState.Equals("DISABLED", StringComparison.OrdinalIgnoreCase))
                schedulerClient.Jobs.UpdateState(jobRequest.JobName, new JobUpdateStateParameters { State = JobState.Disabled });

            status = jobCreateResponse.StatusCode.ToString().Equals("OK") ? "Job has been updated" : jobCreateResponse.StatusCode.ToString();

            return GetJobDetail(jobRequest.JobCollectionName, jobRequest.JobName, jobRequest.Region.ToCloudServiceName());
        }

        #endregion

        /// <summary>
        /// Updates given Http Scheduler job
        /// </summary>
        /// <param name="jobRequest">Request values</param>
        /// <param name="status">Status of uodate operation</param>
        /// <returns>Updated Http Scheduler job</returns>
        public PSJobDetail PatchHttpJob(PSCreateJobParams jobRequest, out string status)
        {
            if (!this.AvailableRegions.Contains(jobRequest.Region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            SchedulerClient schedulerClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(jobRequest.Region.ToCloudServiceName(), jobRequest.JobCollectionName, csmClient.Credentials, schedulerManagementClient.BaseUri);

            //Get Existing job
            Job job = schedulerClient.Jobs.Get(jobRequest.JobName).Job;

            JobCreateOrUpdateParameters jobUpdateParams = PopulateExistingJobParams(job, jobRequest, job.Action.Type);

            JobCreateOrUpdateResponse jobUpdateResponse = schedulerClient.Jobs.CreateOrUpdate(jobRequest.JobName, jobUpdateParams);

            if (!string.IsNullOrEmpty(jobRequest.JobState))
                schedulerClient.Jobs.UpdateState(jobRequest.JobName, new JobUpdateStateParameters
                {
                    State = jobRequest.JobState.Equals("Enabled", StringComparison.OrdinalIgnoreCase) ? JobState.Enabled
                        : JobState.Disabled
                });

            status = jobUpdateResponse.StatusCode.ToString().Equals("OK") ? "Job has been updated" : jobUpdateResponse.StatusCode.ToString();

            return GetJobDetail(jobRequest.JobCollectionName, jobRequest.JobName, jobRequest.Region.ToCloudServiceName());
        }

        /// <summary>
        /// If a scheduler job already exists, this will merge the existing job config values with the request
        /// </summary>
        /// <param name="job">Existing Scheduler job</param>
        /// <param name="jobRequest">Request values</param>
        /// <param name="type">Http or Storage</param>
        /// <returns>JobCreateOrUpdateParameters object to use when updating Scheduler job</returns>
        private JobCreateOrUpdateParameters PopulateExistingJobParams(Job job, PSCreateJobParams jobRequest, JobActionType type)
        {
            JobCreateOrUpdateParameters jobUpdateParams = new JobCreateOrUpdateParameters();

            if (type.Equals(JobActionType.StorageQueue))
            {
                if (jobRequest.IsStorageActionSet())
                {
                    jobUpdateParams.Action = new JobAction();
                    jobUpdateParams.Action.QueueMessage = new JobQueueMessage();
                    if (job.Action != null)
                    {
                        jobUpdateParams.Action.Type = job.Action.Type;
                        if (job.Action.QueueMessage != null)
                        {
                            jobUpdateParams.Action.QueueMessage.Message = string.IsNullOrEmpty(jobRequest.StorageQueueMessage) ? job.Action.QueueMessage.Message : jobRequest.StorageQueueMessage;
                            jobUpdateParams.Action.QueueMessage.QueueName = jobRequest.QueueName ?? job.Action.QueueMessage.QueueName;
                            jobUpdateParams.Action.QueueMessage.SasToken = jobRequest.SasToken ?? job.Action.QueueMessage.SasToken;
                            jobUpdateParams.Action.QueueMessage.StorageAccountName = job.Action.QueueMessage.StorageAccountName;
                        }
                        else if (job.Action.QueueMessage == null)
                        {
                            jobUpdateParams.Action.QueueMessage.Message = string.IsNullOrEmpty(jobRequest.StorageQueueMessage) ? string.Empty : jobRequest.StorageQueueMessage;
                            jobUpdateParams.Action.QueueMessage.QueueName = jobRequest.QueueName;
                            jobUpdateParams.Action.QueueMessage.SasToken = jobRequest.SasToken;
                            jobUpdateParams.Action.QueueMessage.StorageAccountName = jobRequest.StorageAccount;
                        }
                    }
                    else
                    {
                        jobUpdateParams.Action.QueueMessage.Message = string.IsNullOrEmpty(jobRequest.StorageQueueMessage) ? string.Empty : jobRequest.StorageQueueMessage;
                        jobUpdateParams.Action.QueueMessage.QueueName = jobRequest.QueueName;
                        jobUpdateParams.Action.QueueMessage.SasToken = jobRequest.SasToken;
                        jobUpdateParams.Action.QueueMessage.StorageAccountName = jobRequest.StorageAccount;
                    }
                }
                else
                {
                    jobUpdateParams.Action = job.Action;
                }
            }

            else //If it is a HTTP job action type
            {
                if (jobRequest.IsActionSet())
                {
                    jobUpdateParams.Action = new JobAction();
                    jobUpdateParams.Action.Request = new JobHttpRequest();
                    if (job.Action != null)
                    {
                        jobUpdateParams.Action.Type = job.Action.Type;
                        if (job.Action.Request != null)
                        {
                            jobUpdateParams.Action.Request.Uri = jobRequest.Uri ?? job.Action.Request.Uri;
                            jobUpdateParams.Action.Request.Method = jobRequest.Method ?? job.Action.Request.Method;
                            jobUpdateParams.Action.Request.Headers = jobRequest.Headers == null ? job.Action.Request.Headers : jobRequest.Headers.ToDictionary();
                            jobUpdateParams.Action.Request.Body = jobRequest.Body ?? job.Action.Request.Body;

                            //Job has existing authentication
                            if (job.Action.Request.Authentication != null)
                            {
                                if (!string.IsNullOrEmpty(jobRequest.HttpAuthType))
                                {
                                    jobUpdateParams.Action.Request.Authentication = SetHttpAuthentication(jobRequest, jobUpdateParams);
                                }
                                //the new request doesn't have any changes to auth, so preserve it
                                else
                                {
                                    jobUpdateParams.Action.Request.Authentication = job.Action.Request.Authentication;
                                }
                            }
                            else if (job.Action.Request.Authentication == null)
                            {
                                jobUpdateParams.Action.Request.Authentication = SetHttpAuthentication(jobRequest, jobUpdateParams);
                            }
                        }
                        else if (job.Action.Request == null)
                        {
                            jobUpdateParams.Action.Request.Uri = jobRequest.Uri;
                            jobUpdateParams.Action.Request.Method = jobRequest.Method;
                            jobUpdateParams.Action.Request.Headers = jobRequest.Headers.ToDictionary();
                            jobUpdateParams.Action.Request.Body = jobRequest.Body;
                            jobUpdateParams.Action.Request.Authentication = SetHttpAuthentication(jobRequest, jobUpdateParams);
                        }
                    }
                    else
                    {
                        jobUpdateParams.Action.Request.Uri = jobRequest.Uri;
                        jobUpdateParams.Action.Request.Method = jobRequest.Method;
                        jobUpdateParams.Action.Request.Headers = jobRequest.Headers.ToDictionary();
                        jobUpdateParams.Action.Request.Body = jobRequest.Body;
                        jobUpdateParams.Action.Request.Authentication = SetHttpAuthentication(jobRequest, jobUpdateParams);
                    }
                }
                else
                {
                    jobUpdateParams.Action = job.Action;
                }
            }

            if (jobRequest.IsErrorActionSet())
            {
                jobUpdateParams.Action.ErrorAction = new JobErrorAction();
                jobUpdateParams.Action.ErrorAction.Request = new JobHttpRequest();
                jobUpdateParams.Action.ErrorAction.QueueMessage = new JobQueueMessage();

                if (job.Action.ErrorAction != null)
                {
                    if (job.Action.ErrorAction.Request != null)
                    {
                        jobUpdateParams.Action.ErrorAction.Request.Uri = jobRequest.ErrorActionUri ?? job.Action.ErrorAction.Request.Uri;
                        jobUpdateParams.Action.ErrorAction.Request.Method = jobRequest.ErrorActionMethod ?? job.Action.ErrorAction.Request.Method;
                        jobUpdateParams.Action.ErrorAction.Request.Headers = jobRequest.ErrorActionHeaders == null ? job.Action.ErrorAction.Request.Headers : jobRequest.Headers.ToDictionary();
                        jobUpdateParams.Action.ErrorAction.Request.Body = jobRequest.ErrorActionBody ?? job.Action.ErrorAction.Request.Body;
                    }
                    else if (job.Action.ErrorAction.Request == null)
                    {
                        jobUpdateParams.Action.ErrorAction.Request.Uri = jobRequest.ErrorActionUri;
                        jobUpdateParams.Action.ErrorAction.Request.Method = jobRequest.ErrorActionMethod;
                        jobUpdateParams.Action.ErrorAction.Request.Headers = jobRequest.ErrorActionHeaders.ToDictionary();
                        jobUpdateParams.Action.ErrorAction.Request.Body = jobRequest.ErrorActionBody;
                    }
                    if (job.Action.ErrorAction.QueueMessage != null)
                    {
                        jobUpdateParams.Action.ErrorAction.QueueMessage.Message = jobRequest.ErrorActionQueueBody ?? job.Action.ErrorAction.QueueMessage.Message;
                        jobUpdateParams.Action.ErrorAction.QueueMessage.QueueName = jobRequest.ErrorActionQueueName ?? job.Action.ErrorAction.QueueMessage.QueueName;
                        jobUpdateParams.Action.ErrorAction.QueueMessage.SasToken = jobRequest.ErrorActionSasToken ?? job.Action.ErrorAction.QueueMessage.SasToken;
                        jobUpdateParams.Action.ErrorAction.QueueMessage.StorageAccountName = jobRequest.ErrorActionStorageAccount ?? job.Action.ErrorAction.QueueMessage.StorageAccountName;
                    }
                    else if (job.Action.ErrorAction.QueueMessage == null)
                    {
                        jobUpdateParams.Action.ErrorAction.QueueMessage.Message = jobRequest.ErrorActionQueueBody;
                        jobUpdateParams.Action.ErrorAction.QueueMessage.QueueName = jobRequest.ErrorActionQueueName;
                        jobUpdateParams.Action.ErrorAction.QueueMessage.SasToken = jobRequest.ErrorActionSasToken;
                        jobUpdateParams.Action.ErrorAction.QueueMessage.StorageAccountName = jobRequest.ErrorActionStorageAccount;
                    }
                }
                else if (job.Action.ErrorAction == null)
                {
                    jobUpdateParams.Action.ErrorAction.Request.Uri = jobRequest.ErrorActionUri;
                    jobUpdateParams.Action.ErrorAction.Request.Method = jobRequest.ErrorActionMethod;
                    jobUpdateParams.Action.ErrorAction.Request.Headers = jobRequest.ErrorActionHeaders.ToDictionary();
                    jobUpdateParams.Action.ErrorAction.Request.Body = jobRequest.ErrorActionBody;
                    jobUpdateParams.Action.ErrorAction.QueueMessage.Message = jobRequest.ErrorActionQueueBody;
                    jobUpdateParams.Action.ErrorAction.QueueMessage.QueueName = jobRequest.ErrorActionQueueName;
                    jobUpdateParams.Action.ErrorAction.QueueMessage.SasToken = jobRequest.ErrorActionSasToken;
                    jobUpdateParams.Action.ErrorAction.QueueMessage.StorageAccountName = jobRequest.ErrorActionStorageAccount;
                }
            }
            else
            {
                jobUpdateParams.Action.ErrorAction = job.Action.ErrorAction;
            }

            if (jobRequest.IsRecurrenceSet())
            {
                jobUpdateParams.Recurrence = new JobRecurrence();
                if (job.Recurrence != null)
                {
                    jobUpdateParams.Recurrence.Count = jobRequest.ExecutionCount ?? job.Recurrence.Count;
                    jobUpdateParams.Recurrence.EndTime = jobRequest.EndTime ?? job.Recurrence.EndTime;
                    jobUpdateParams.Recurrence.Frequency = string.IsNullOrEmpty(jobRequest.Frequency) ? job.Recurrence.Frequency : (JobRecurrenceFrequency)Enum.Parse(typeof(JobRecurrenceFrequency), jobRequest.Frequency);
                    jobUpdateParams.Recurrence.Interval = jobRequest.Interval ?? job.Recurrence.Interval;
                    jobUpdateParams.Recurrence.Schedule = SetRecurrenceSchedule(job.Recurrence.Schedule);
                }
                else if (job.Recurrence == null)
                {
                    jobUpdateParams.Recurrence.Count = jobRequest.ExecutionCount;
                    jobUpdateParams.Recurrence.EndTime = jobRequest.EndTime;
                    jobUpdateParams.Recurrence.Frequency = string.IsNullOrEmpty(jobRequest.Frequency) ? default(JobRecurrenceFrequency) : (JobRecurrenceFrequency)Enum.Parse(typeof(JobRecurrenceFrequency), jobRequest.Frequency);
                    jobUpdateParams.Recurrence.Interval = jobRequest.Interval;
                    jobUpdateParams.Recurrence.Schedule = null;
                }
            }
            else
            {
                jobUpdateParams.Recurrence = job.Recurrence;
                if (jobUpdateParams.Recurrence != null)
                {
                    jobUpdateParams.Recurrence.Schedule = SetRecurrenceSchedule(job.Recurrence.Schedule);
                }
            }

            jobUpdateParams.Action.RetryPolicy = job.Action.RetryPolicy;

            jobUpdateParams.StartTime = jobRequest.StartTime ?? job.StartTime;

            return jobUpdateParams;
        }

        private HttpAuthentication SetHttpAuthentication(PSCreateJobParams jobRequest, JobCreateOrUpdateParameters jobUpdateParams)
        {
            HttpAuthentication httpAuthentication = null;
            if (!string.IsNullOrEmpty(jobRequest.HttpAuthType))
            {
                switch (jobRequest.HttpAuthType.ToLower())
                {
                    case "clientcertificate":
                        if (jobRequest.ClientCertPfx != null && jobRequest.ClientCertPassword != null)
                        {
                            httpAuthentication = new ClientCertAuthentication
                            {
                                Type = HttpAuthenticationType.ClientCertificate,
                                Password = jobRequest.ClientCertPassword,
                                Pfx = jobRequest.ClientCertPfx
                            };
                        }
                        else
                        {
                            throw new InvalidOperationException(Resources.SchedulerInvalidClientCertAuthRequest);
                        }
                        break;

                    case "activedirectoryoauth":
                        if (jobRequest.Tenant != null && jobRequest.Audience != null && jobRequest.ClientId != null && jobRequest.Secret != null)
                        {
                            httpAuthentication = new AADOAuthAuthentication
                            {
                                Type = HttpAuthenticationType.ActiveDirectoryOAuth,
                                Tenant = jobRequest.Tenant,
                                Audience = jobRequest.Audience,
                                ClientId = jobRequest.ClientId,
                                Secret = jobRequest.Secret
                            };
                        }
                        else
                        {
                            throw new InvalidOperationException(Resources.SchedulerInvalidAADOAuthRequest);
                        }
                        break;

                    case "basic":
                        if (jobRequest.Username != null && jobRequest.Password != null)
                        {
                            httpAuthentication = new BasicAuthentication
                            {
                                Type = HttpAuthenticationType.Basic,
                                Username = jobRequest.Username,
                                Password = jobRequest.Password
                            };
                        }
                        else
                        {
                            throw new InvalidOperationException(Resources.SchedulerInvalidBasicAuthRequest);
                        }
                        break;

                    case "none":
                        if (!string.IsNullOrEmpty(jobRequest.ClientCertPfx) || !string.IsNullOrEmpty(jobRequest.ClientCertPassword) ||
                            !string.IsNullOrEmpty(jobRequest.Tenant) || !string.IsNullOrEmpty(jobRequest.Secret) || !string.IsNullOrEmpty(jobRequest.ClientId) || !string.IsNullOrEmpty(jobRequest.Audience) ||
                            !string.IsNullOrEmpty(jobRequest.Username) || !string.IsNullOrEmpty(jobRequest.Password))
                        {
                            throw new InvalidOperationException(Resources.SchedulerInvalidNoneAuthRequest);
                        }
                        break;
                }
            }
            return httpAuthentication;
        }

        /// <summary>
        /// Existing bug in SDK where recurrence counts are set to 0 instead of null
        /// </summary>
        /// <param name="jobRecurrenceSchedule">The JobRecurrenceSchedule</param>
        /// <returns>The JobRecurrenceSchedule</returns>
        private JobRecurrenceSchedule SetRecurrenceSchedule(JobRecurrenceSchedule jobRecurrenceSchedule)
        {
            if (jobRecurrenceSchedule != null)
            {
                JobRecurrenceSchedule schedule = new JobRecurrenceSchedule();
                schedule.Days = jobRecurrenceSchedule.Days.Count == 0 ? null : jobRecurrenceSchedule.Days;
                schedule.Hours = jobRecurrenceSchedule.Hours.Count == 0 ? null : jobRecurrenceSchedule.Hours;
                schedule.Minutes = jobRecurrenceSchedule.Minutes.Count == 0 ? null : jobRecurrenceSchedule.Minutes;
                schedule.MonthDays = jobRecurrenceSchedule.MonthDays.Count == 0 ? null : jobRecurrenceSchedule.MonthDays;
                schedule.MonthlyOccurrences = jobRecurrenceSchedule.MonthlyOccurrences.Count == 0 ? null : jobRecurrenceSchedule.MonthlyOccurrences;
                schedule.Months = jobRecurrenceSchedule.Months.Count == 0 ? null : jobRecurrenceSchedule.Months;
                return schedule;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Updates given Storage Queue Scheduler job
        /// </summary>
        /// <param name="jobRequest">Request values</param>
        /// <param name="status">Status of uodate operation</param>
        /// <returns>Updated Storage Queue Scheduler job</returns>
        public PSJobDetail PatchStorageJob(PSCreateJobParams jobRequest, out string status)
        {
            if (!this.AvailableRegions.Contains(jobRequest.Region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            SchedulerClient schedulerClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(jobRequest.Region.ToCloudServiceName(), jobRequest.JobCollectionName, csmClient.Credentials, schedulerManagementClient.BaseUri);

            //Get Existing job
            Job job = schedulerClient.Jobs.Get(jobRequest.JobName).Job;

            JobCreateOrUpdateParameters jobUpdateParams = PopulateExistingJobParams(job, jobRequest, job.Action.Type);

            JobCreateOrUpdateResponse jobUpdateResponse = schedulerClient.Jobs.CreateOrUpdate(jobRequest.JobName, jobUpdateParams);

            if (!string.IsNullOrEmpty(jobRequest.JobState))
                schedulerClient.Jobs.UpdateState(jobRequest.JobName, new JobUpdateStateParameters
                {
                    State = jobRequest.JobState.Equals("Enabled", StringComparison.OrdinalIgnoreCase) ? JobState.Enabled
                        : JobState.Disabled
                });

            status = jobUpdateResponse.StatusCode.ToString().Equals("OK") ? "Job has been updated" : jobUpdateResponse.StatusCode.ToString();

            return GetJobDetail(jobRequest.JobCollectionName, jobRequest.JobName, jobRequest.Region.ToCloudServiceName());
        }
    }
}

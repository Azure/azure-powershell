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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Scheduler.Model;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.WindowsAzure.Management.Scheduler.Models;
using Microsoft.WindowsAzure.Scheduler;
using Microsoft.WindowsAzure.Scheduler.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Commands.Utilities.Scheduler
{
    public partial class SchedulerMgmntClient
    {
        private SchedulerManagementClient schedulerManagementClient;
        private CloudServiceManagementClient csmClient;
        private AzureSubscription currentSubscription;

        private const string SupportedRegionsKey = "SupportedGeoRegions";
        private const string FreeMaxJobCountKey = "PlanDetail:Free:Quota:MaxJobCount";
        private const string FreeMinRecurrenceKey = "PlanDetail:Free:Quota:MinRecurrence";
        private const string StandardMaxJobCountKey = "PlanDetail:Standard:Quota:MaxJobCount";
        private const string StandardMinRecurrenceKey = "PlanDetail:Standard:Quota:MinRecurrence";
        private const string PremiumMaxJobCountKey = "PlanDetail:Premium:Quota:MaxJobCount";
        private const string PremiumMinRecurrenceKey = "PlanDetail:Premium:Quota:MinRecurrence";

        private int FreeMaxJobCountValue { get; set; }
        private TimeSpan FreeMinRecurrenceValue { get; set; }
        private int StandardMaxJobCountValue { get; set; }
        private TimeSpan StandardMinRecurrenceValue { get; set; }
        private int PremiumMaxJobCountValue { get; set; }
        private TimeSpan PremiumMinRecurrenceValue { get; set; }
        private List<string> AvailableRegions { get; set; }

        /// <summary>
        /// Creates new Scheduler Management Convenience Client
        /// </summary>
        /// <param name="subscription">Subscription containing websites to manipulate</param>
        public SchedulerMgmntClient(AzureSMProfile profile, AzureSubscription subscription)
        {
            currentSubscription = subscription;
            csmClient = AzureSession.ClientFactory.CreateClient<CloudServiceManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
            schedulerManagementClient = AzureSession.ClientFactory.CreateClient<SchedulerManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);

            //Get RP properties
            IDictionary<string, string> dict = schedulerManagementClient.GetResourceProviderProperties().Properties;

            //Get available regions
            string val = string.Empty;
            if (dict.TryGetValue(SupportedRegionsKey, out val))
            {
                AvailableRegions = new List<string>();
                val.Split(',').ToList().ForEach(s => AvailableRegions.Add(s));
            }

            //Store global counts for max jobs and min recurrence for each plan     
            if (dict.TryGetValue(FreeMaxJobCountKey, out val))
                FreeMaxJobCountValue = Convert.ToInt32(dict[FreeMaxJobCountKey]);

            if (dict.TryGetValue(FreeMinRecurrenceKey, out val))
                FreeMinRecurrenceValue = TimeSpan.Parse(dict[FreeMinRecurrenceKey]);

            if (dict.TryGetValue(StandardMaxJobCountKey, out val))
                StandardMaxJobCountValue = Convert.ToInt32(dict[StandardMaxJobCountKey]);

            if (dict.TryGetValue(StandardMinRecurrenceKey, out val))
                StandardMinRecurrenceValue = TimeSpan.Parse(dict[StandardMinRecurrenceKey]);

            if (dict.TryGetValue(PremiumMaxJobCountKey, out val))
                PremiumMaxJobCountValue = Convert.ToInt32(dict[PremiumMaxJobCountKey]);

            if (dict.TryGetValue(PremiumMinRecurrenceKey, out val))
                PremiumMinRecurrenceValue = TimeSpan.Parse(dict[PremiumMinRecurrenceKey]);
        }

        #region Get Available Regions
        public List<string> GetAvailableRegions()
        {
            return AvailableRegions;
        }
        #endregion

        #region Job Collections
        public List<PSJobCollection> GetJobCollection(string region = "", string jobCollection = "")
        {
            List<PSJobCollection> lstSchedulerJobCollection = new List<PSJobCollection>();
            CloudServiceListResponse csList = csmClient.CloudServices.List();

            if (!string.IsNullOrEmpty(region))
            {
                if (!this.AvailableRegions.Contains(region, StringComparer.OrdinalIgnoreCase))
                    throw new Exception(Resources.SchedulerInvalidLocation);

                string cloudService = region.ToCloudServiceName();
                foreach (CloudServiceListResponse.CloudService cs in csList.CloudServices)
                {
                    if (cs.Name.Equals(cloudService, StringComparison.OrdinalIgnoreCase))
                    {
                        GetSchedulerJobCollection(cs, jobCollection).ForEach(x => lstSchedulerJobCollection.Add(x));
                        //If job collection parameter was passed and we found a matching job collection already, exit out of the loop and return the job collection
                        if (!string.IsNullOrEmpty(jobCollection) && lstSchedulerJobCollection.Count > 0)
                            return lstSchedulerJobCollection;
                    }
                }
            }
            else if (string.IsNullOrEmpty(region))
            {
                foreach (CloudServiceListResponse.CloudService cs in csList.CloudServices)
                {
                    if (cs.Name.Equals(Constants.CloudServiceNameFirst + cs.GeoRegion.Replace(" ", string.Empty) + Constants.CloudServiceNameSecond, StringComparison.OrdinalIgnoreCase))
                    {
                        GetSchedulerJobCollection(cs, jobCollection).ForEach(x => lstSchedulerJobCollection.Add(x));
                        //If job collection parameter was passed and we found a matching job collection already, exit out of the loop and return the job collection
                        if (!string.IsNullOrEmpty(jobCollection) && lstSchedulerJobCollection.Count > 0)
                            return lstSchedulerJobCollection;
                    }
                }
            }
            return lstSchedulerJobCollection;
        }

        private List<PSJobCollection> GetSchedulerJobCollection(CloudServiceListResponse.CloudService cloudService, string jobCollection)
        {
            List<PSJobCollection> lstSchedulerJobCollection = new List<PSJobCollection>();

            foreach (CloudServiceGetResponse.Resource csRes in csmClient.CloudServices.Get(cloudService.Name).Resources)
            {
                if (csRes.Type.Contains(Constants.JobCollectionResource))
                {
                    JobCollectionGetResponse jcGetResponse = schedulerManagementClient.JobCollections.Get(cloudService.Name, csRes.Name);
                    if (string.IsNullOrEmpty(jobCollection) || (!string.IsNullOrEmpty(jobCollection) && jcGetResponse.Name.Equals(jobCollection, StringComparison.OrdinalIgnoreCase)))
                    {
                        PSJobCollection jc = new PSJobCollection
                        {
                            CloudServiceName = cloudService.Name,
                            JobCollectionName = jcGetResponse.Name,
                            State = Enum.GetName(typeof(JobCollectionState), jcGetResponse.State),
                            Location = cloudService.GeoRegion,
                            Uri = csmClient.BaseUri.AbsoluteUri + csmClient.Credentials.SubscriptionId + "cloudservices/" + cloudService.Name + Constants.JobCollectionResourceURL + jcGetResponse.Name
                        };

                        if (jcGetResponse.IntrinsicSettings != null)
                        {
                            jc.Plan = Enum.GetName(typeof(JobCollectionPlan), jcGetResponse.IntrinsicSettings.Plan);
                            if (jcGetResponse.IntrinsicSettings.Quota != null)
                            {
                                jc.MaxJobCount = jcGetResponse.IntrinsicSettings.Quota.MaxJobCount == null ? string.Empty : jcGetResponse.IntrinsicSettings.Quota.MaxJobCount.ToString();
                                jc.MaxRecurrence = jcGetResponse.IntrinsicSettings.Quota.MaxRecurrence == null ? string.Empty : jcGetResponse.IntrinsicSettings.Quota.MaxRecurrence.Interval.ToString() + " per " +
                                    jcGetResponse.IntrinsicSettings.Quota.MaxRecurrence.Frequency.ToString();
                            }
                        }
                        lstSchedulerJobCollection.Add(jc);
                    }
                }
            }

            return lstSchedulerJobCollection;
        }

        #endregion

        #region Scheduler Jobs

        public List<PSSchedulerJob> GetJob(string region, string jobCollection, string job = "", string state = "")
        {
            if (!this.AvailableRegions.Contains(region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            List<PSSchedulerJob> lstJob = new List<PSSchedulerJob>();

            string cloudService = region.ToCloudServiceName();
            if (!string.IsNullOrEmpty(job))
            {
                PSJobDetail jobDetail = GetJobDetail(jobCollection, job, cloudService);
                if (string.IsNullOrEmpty(state) || (!string.IsNullOrEmpty(state) && jobDetail.Status.Equals(state, StringComparison.OrdinalIgnoreCase)))
                {
                    lstJob.Add(jobDetail);
                    return lstJob;
                }
            }
            else if (string.IsNullOrEmpty(job))
            {
                GetSchedulerJobs(cloudService, jobCollection).ForEach(x =>
                {
                    if (string.IsNullOrEmpty(state) || (!string.IsNullOrEmpty(state) && x.Status.Equals(state, StringComparison.OrdinalIgnoreCase)))
                    {
                        lstJob.Add(x);
                    }
                });
            }
            return lstJob;
        }

        private List<PSSchedulerJob> GetSchedulerJobs(string cloudService, string jobCollection)
        {
            List<PSSchedulerJob> lstJobs = new List<PSSchedulerJob>();
            CloudServiceGetResponse csDetails = csmClient.CloudServices.Get(cloudService);
            foreach (CloudServiceGetResponse.Resource csRes in csDetails.Resources)
            {
                if (csRes.ResourceProviderNamespace.Equals(Constants.SchedulerRPNameProvider, StringComparison.OrdinalIgnoreCase) && csRes.Name.Equals(jobCollection, StringComparison.OrdinalIgnoreCase))
                {
                    SchedulerClient schedClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(cloudService, jobCollection, csmClient.Credentials, schedulerManagementClient.BaseUri);

                    JobListResponse jobs = schedClient.Jobs.List(new JobListParameters
                    {
                        Skip = 0,
                    });
                    foreach (Job job in jobs)
                    {
                        lstJobs.Add(new PSSchedulerJob
                        {
                            JobName = job.Id,
                            Lastrun = job.Status == null ? null : job.Status.LastExecutionTime,
                            Nextrun = job.Status == null ? null : job.Status.NextExecutionTime,
                            Status = job.State.ToString(),
                            StartTime = job.StartTime,
                            Recurrence = job.Recurrence == null ? string.Empty : job.Recurrence.Interval.ToString() + " per " + job.Recurrence.Frequency.ToString(),
                            Failures = job.Status == null ? default(int?) : job.Status.FailureCount,
                            Faults = job.Status == null ? default(int?) : job.Status.FaultedCount,
                            Executions = job.Status == null ? default(int?) : job.Status.ExecutionCount,
                            EndSchedule = GetEndTime(job),
                            JobCollectionName = jobCollection
                        });
                    }
                }
            }
            return lstJobs;
        }

        private string GetEndTime(Job job)
        {
            if (job.Recurrence == null)
                return "Run once";
            else if (job.Recurrence != null)
            {
                if (job.Recurrence.Count == null)
                    return "None";
                if (job.Recurrence.Count != null)
                    return "Until " + job.Recurrence.Count + " executions";
                else
                    return job.Recurrence.Interval + " executions every " + job.Recurrence.Frequency.ToString();
            }
            return null;
        }

        #endregion

        #region Job History
        public List<PSJobHistory> GetJobHistory(string jobCollection, string job, string region, string jobStatus = "")
        {
            if (!this.AvailableRegions.Contains(region, StringComparer.OrdinalIgnoreCase))
                throw new Exception(Resources.SchedulerInvalidLocation);

            List<PSJobHistory> lstPSJobHistory = new List<PSJobHistory>();
            string cloudService = region.ToCloudServiceName();
            CloudServiceGetResponse csDetails = csmClient.CloudServices.Get(cloudService);
            foreach (CloudServiceGetResponse.Resource csRes in csDetails.Resources)
            {
                if (csRes.ResourceProviderNamespace.Equals(Constants.SchedulerRPNameProvider, StringComparison.InvariantCultureIgnoreCase) && csRes.Name.Equals(jobCollection, StringComparison.OrdinalIgnoreCase))
                {
                    SchedulerClient schedClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(cloudService, jobCollection.Trim(), csmClient.Credentials, schedulerManagementClient.BaseUri);

                    List<JobGetHistoryResponse.JobHistoryEntry> lstHistory = new List<JobGetHistoryResponse.JobHistoryEntry>();
                    int currentTop = 100;

                    if (string.IsNullOrEmpty(jobStatus))
                    {
                        JobGetHistoryResponse history = schedClient.Jobs.GetHistory(job.Trim(), new JobGetHistoryParameters { Top = 100 });
                        lstHistory.AddRange(history.JobHistory);
                        while (history.JobHistory.Count > 99)
                        {
                            history = schedClient.Jobs.GetHistory(job.Trim(), new JobGetHistoryParameters { Top = 100, Skip = currentTop });
                            currentTop += 100;
                            lstHistory.AddRange(history.JobHistory);
                        }
                    }
                    else if (!string.IsNullOrEmpty(jobStatus))
                    {
                        JobHistoryStatus status = jobStatus.Equals("Completed") ? JobHistoryStatus.Completed : JobHistoryStatus.Failed;
                        JobGetHistoryResponse history = schedClient.Jobs.GetHistoryWithFilter(job.Trim(), new JobGetHistoryWithFilterParameters { Top = 100, Status = status });
                        lstHistory.AddRange(history.JobHistory);
                        while (history.JobHistory.Count > 99)
                        {
                            history = schedClient.Jobs.GetHistoryWithFilter(job.Trim(), new JobGetHistoryWithFilterParameters { Top = 100, Skip = currentTop });
                            currentTop += 100;
                            lstHistory.AddRange(history.JobHistory);
                        }
                    }
                    foreach (JobGetHistoryResponse.JobHistoryEntry entry in lstHistory)
                    {
                        PSJobHistory historyObj = new PSJobHistory();
                        historyObj.Status = entry.Status.ToString();
                        historyObj.StartTime = entry.StartTime;
                        historyObj.EndTime = entry.EndTime;
                        historyObj.JobName = entry.Id;
                        historyObj.Details = GetHistoryDetails(entry.Message);
                        historyObj.Retry = entry.RetryCount;
                        historyObj.Occurence = entry.RepeatCount;
                        if (JobHistoryActionName.ErrorAction == entry.ActionName)
                        {
                            PSJobHistoryError errorObj = historyObj.ToJobHistoryError();
                            errorObj.ErrorAction = JobHistoryActionName.ErrorAction.ToString();
                            lstPSJobHistory.Add(errorObj);
                        }
                        else
                            lstPSJobHistory.Add(historyObj);
                    }
                }
            }
            return lstPSJobHistory;
        }

        private PSJobHistoryDetail GetHistoryDetails(string message)
        {
            PSJobHistoryDetail detail = new PSJobHistoryDetail();
            if (message.Contains("Http Action -"))
            {
                PSJobHistoryHttpDetail details = new PSJobHistoryHttpDetail { ActionType = "http" };
                if (message.Contains("Request to host") && message.Contains("failed:"))
                {
                    int firstIndex = message.IndexOf("'");
                    int secondIndex = message.IndexOf("'", firstIndex + 1);
                    details.HostName = message.Substring(firstIndex + 1, secondIndex - (firstIndex + 1));
                    details.Response = "Failed";
                    details.ResponseBody = message;
                }
                else
                {
                    int firstIndex = message.IndexOf("'");
                    int secondIndex = message.IndexOf("'", firstIndex + 1);
                    int thirdIndex = message.IndexOf("'", secondIndex + 1);
                    int fourthIndex = message.IndexOf("'", thirdIndex + 1);
                    details.HostName = message.Substring(firstIndex + 1, secondIndex - (firstIndex + 1));
                    details.Response = message.Substring(thirdIndex + 1, fourthIndex - (thirdIndex + 1));
                    int bodyIndex = message.IndexOf("Body: ");
                    details.ResponseBody = message.Substring(bodyIndex + 6);
                }
                return details;

            }
            else if (message.Contains("StorageQueue Action -"))
            {
                PSJobHistoryStorageDetail details = new PSJobHistoryStorageDetail { ActionType = "Storage" };
                if (message.Contains("does not exist"))
                {
                    int firstIndex = message.IndexOf("'");
                    int secondIndex = message.IndexOf("'", firstIndex + 1);
                    details.StorageAccountName = string.Empty;
                    details.StorageQueueName = message.Substring(firstIndex + 1, secondIndex - (firstIndex + 1));
                    details.ResponseBody = message;
                    details.ResponseStatus = "Failed";
                }
                else
                {
                    int firstIndex = message.IndexOf("'");
                    int secondIndex = message.IndexOf("'", firstIndex + 1);
                    int thirdIndex = message.IndexOf("'", secondIndex + 1);
                    int fourthIndex = message.IndexOf("'", thirdIndex + 1);
                    details.StorageAccountName = message.Substring(firstIndex + 1, secondIndex - (firstIndex + 1));
                    details.StorageQueueName = message.Substring(thirdIndex + 1, fourthIndex - (thirdIndex + 1));
                    details.ResponseStatus = message.Substring(fourthIndex + 2);
                    details.ResponseBody = message;
                }
                return details;
            }
            return detail;
        }
        #endregion

        #region Get Job Details
        public PSJobDetail GetJobDetail(string jobCollection, string job, string cloudService)
        {
            CloudServiceGetResponse csDetails = csmClient.CloudServices.Get(cloudService);
            foreach (CloudServiceGetResponse.Resource csRes in csDetails.Resources)
            {
                if (csRes.ResourceProviderNamespace.Equals(Constants.SchedulerRPNameProvider, StringComparison.OrdinalIgnoreCase) && csRes.Name.Equals(jobCollection, StringComparison.OrdinalIgnoreCase))
                {
                    SchedulerClient schedClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(cloudService, jobCollection, csmClient.Credentials, schedulerManagementClient.BaseUri);

                    JobListResponse jobs = schedClient.Jobs.List(new JobListParameters
                    {
                        Skip = 0,
                    });
                    foreach (Job j in jobs)
                    {
                        if (j.Id.ToLower().Equals(job.ToLower()))
                        {
                            if (Enum.GetName(typeof(JobActionType), j.Action.Type).Contains("Http"))
                            {
                                PSHttpJobDetail jobDetail = new PSHttpJobDetail();
                                jobDetail.JobName = j.Id;
                                jobDetail.JobCollectionName = jobCollection;
                                jobDetail.CloudService = cloudService;
                                jobDetail.ActionType = Enum.GetName(typeof(JobActionType), j.Action.Type);
                                jobDetail.Uri = j.Action.Request.Uri;
                                jobDetail.Method = j.Action.Request.Method;
                                jobDetail.Body = j.Action.Request.Body;
                                jobDetail.Headers = j.Action.Request.Headers;
                                jobDetail.Status = j.State.ToString();
                                jobDetail.StartTime = j.StartTime;
                                jobDetail.EndSchedule = GetEndTime(j);
                                jobDetail.Recurrence = j.Recurrence == null ? string.Empty : j.Recurrence.Interval.ToString() + " (" + j.Recurrence.Frequency.ToString() + "s)";
                                if (j.Status != null)
                                {
                                    jobDetail.Failures = j.Status.FailureCount;
                                    jobDetail.Faults = j.Status.FaultedCount;
                                    jobDetail.Executions = j.Status.ExecutionCount;
                                    jobDetail.Lastrun = j.Status.LastExecutionTime;
                                    jobDetail.Nextrun = j.Status.NextExecutionTime;
                                }
                                if (j.Action.Request.Authentication != null)
                                {
                                    switch(j.Action.Request.Authentication.Type)
                                    {
                                        case HttpAuthenticationType.ClientCertificate:                                           
                                                PSClientCertAuthenticationJobDetail ClientCertJobDetail = new PSClientCertAuthenticationJobDetail(jobDetail);
                                                ClientCertJobDetail.ClientCertExpiryDate = ((j.Action.Request.Authentication) as ClientCertAuthentication).CertificateExpiration.ToString();
                                                ClientCertJobDetail.ClientCertSubjectName = ((j.Action.Request.Authentication) as ClientCertAuthentication).CertificateSubjectName;
                                                ClientCertJobDetail.ClientCertThumbprint = ((j.Action.Request.Authentication) as ClientCertAuthentication).CertificateThumbprint;
                                                return ClientCertJobDetail;                                              
                                        case HttpAuthenticationType.ActiveDirectoryOAuth:                                            
                                                PSAADOAuthenticationJobDetail AADOAuthJobDetail = new PSAADOAuthenticationJobDetail(jobDetail);
                                                AADOAuthJobDetail.Audience = ((j.Action.Request.Authentication) as AADOAuthAuthentication).Audience;
                                                AADOAuthJobDetail.ClientId = ((j.Action.Request.Authentication) as AADOAuthAuthentication).ClientId;
                                                AADOAuthJobDetail.Tenant = ((j.Action.Request.Authentication) as AADOAuthAuthentication).Tenant;
                                                return AADOAuthJobDetail;
                                        case HttpAuthenticationType.Basic:
                                                PSBasicAuthenticationJobDetail BasicAuthJobDetail = new PSBasicAuthenticationJobDetail(jobDetail);
                                                BasicAuthJobDetail.Username = ((j.Action.Request.Authentication) as BasicAuthentication).Username;
                                                return BasicAuthJobDetail;
                                    }                                    
                                }
                                return jobDetail;
                            }
                            else
                            {
                                return new PSStorageQueueJobDetail
                                {
                                    JobName = j.Id,
                                    JobCollectionName = jobCollection,
                                    CloudService = cloudService,
                                    ActionType = Enum.GetName(typeof(JobActionType), j.Action.Type),
                                    StorageAccountName = j.Action.QueueMessage.StorageAccountName,
                                    StorageQueueName = j.Action.QueueMessage.QueueName,
                                    SasToken = j.Action.QueueMessage.SasToken,
                                    QueueMessage = j.Action.QueueMessage.Message,
                                    Status = j.State.ToString(),
                                    EndSchedule = GetEndTime(j),
                                    StartTime = j.StartTime,
                                    Recurrence = j.Recurrence == null ? string.Empty : j.Recurrence.Interval.ToString() + " (" + j.Recurrence.Frequency.ToString() + "s)",
                                    Failures = j.Status == null ? default(int?) : j.Status.FailureCount,
                                    Faults = j.Status == null ? default(int?) : j.Status.FaultedCount,
                                    Executions = j.Status == null ? default(int?) : j.Status.ExecutionCount,
                                    Lastrun = j.Status == null ? null : j.Status.LastExecutionTime,
                                    Nextrun = j.Status == null ? null : j.Status.NextExecutionTime
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region Delete Jobs

        public bool DeleteJob(string jobCollection, string jobName, string region = "")
        {
            if (!string.IsNullOrEmpty(region))
            {
                if (!this.AvailableRegions.Contains(region, StringComparer.OrdinalIgnoreCase))
                    throw new Exception(Resources.SchedulerInvalidLocation);

                SchedulerClient schedClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(region.ToCloudServiceName(), jobCollection, csmClient.Credentials, schedulerManagementClient.BaseUri);

                AzureOperationResponse response = schedClient.Jobs.Delete(jobName);
                return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
            }
            else if (string.IsNullOrEmpty(region))
            {
                CloudServiceListResponse csList = csmClient.CloudServices.List();
                foreach (CloudServiceListResponse.CloudService cs in csList.CloudServices)
                {
                    foreach (CloudServiceGetResponse.Resource csRes in csmClient.CloudServices.Get(cs.Name).Resources)
                    {
                        if (csRes.Type.Contains(Constants.JobCollectionResource))
                        {
                            JobCollectionGetResponse jcGetResponse = schedulerManagementClient.JobCollections.Get(cs.Name, csRes.Name);
                            if (jcGetResponse.Name.Equals(jobCollection, StringComparison.OrdinalIgnoreCase))
                            {
                                foreach (PSSchedulerJob job in GetSchedulerJobs(cs.Name, jobCollection))
                                {
                                    if (job.JobName.Equals(jobName, StringComparison.OrdinalIgnoreCase))
                                    {
                                        SchedulerClient schedClient = AzureSession.ClientFactory.CreateCustomClient<SchedulerClient>(cs.Name, jobCollection, csmClient.Credentials, schedulerManagementClient.BaseUri);

                                        AzureOperationResponse response = schedClient.Jobs.Delete(jobName);
                                        return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region Delete Job Collection

        public bool DeleteJobCollection(string jobCollection, string region = "")
        {
            if (!string.IsNullOrEmpty(region))
            {
                if (!this.AvailableRegions.Contains(region, StringComparer.OrdinalIgnoreCase))
                    throw new Exception(Resources.SchedulerInvalidLocation);

                SchedulerOperationStatusResponse response = schedulerManagementClient.JobCollections.Delete(region.ToCloudServiceName(), jobCollection);
                return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
            }
            else if (string.IsNullOrEmpty(region))
            {
                CloudServiceListResponse csList = csmClient.CloudServices.List();
                foreach (CloudServiceListResponse.CloudService cs in csList.CloudServices)
                {
                    foreach (CloudServiceGetResponse.Resource csRes in csmClient.CloudServices.Get(cs.Name).Resources)
                    {
                        if (csRes.Type.Contains(Constants.JobCollectionResource))
                        {
                            JobCollectionGetResponse jcGetResponse = schedulerManagementClient.JobCollections.Get(cs.Name, csRes.Name);
                            if (jcGetResponse.Name.Equals(jobCollection, StringComparison.OrdinalIgnoreCase))
                            {
                                SchedulerOperationStatusResponse response = schedulerManagementClient.JobCollections.Delete(region.ToCloudServiceName(), jobCollection);
                                return response.StatusCode == System.Net.HttpStatusCode.OK ? true : false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion
    }
}

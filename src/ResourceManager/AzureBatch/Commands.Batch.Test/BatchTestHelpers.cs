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
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.BatchRequests;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Xunit;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test
{
    /// <summary>
    /// Helper methods for the Batch cmdlet tests
    /// </summary>
    public static class BatchTestHelpers
    {
        internal static readonly string TestCertificateFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\BatchTestCert01.cer");
        internal const string TestCertificateAlgorithm = "sha1";
        internal const string TestCertificatePassword = "Passw0rd";
        internal static readonly int DefaultQuotaCount = 20;

        /// <summary>
        /// Builds an AccountResource object using the specified parameters
        /// </summary>
        public static AccountResource CreateAccountResource(string accountName, string resourceGroupName, Hashtable tags = null, string storageId = null)
        {
            string tenantUrlEnding = "batch-test.windows-int.net";
            string endpoint = string.Format("{0}.{1}", accountName, tenantUrlEnding);
            string subscription = Guid.Empty.ToString();
            string resourceGroup = resourceGroupName;

            string id = string.Format("id/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Batch/batchAccounts/abc", subscription, resourceGroup);

            AccountResource resource = new AccountResource(
                coreQuota: DefaultQuotaCount,
                poolQuota: DefaultQuotaCount,
                activeJobAndJobScheduleQuota: DefaultQuotaCount,
                id: id,
                type: "type")
            {
                Location = "location",
                AccountEndpoint = endpoint,
                ProvisioningState = AccountProvisioningState.Succeeded,
                AutoStorage = new AutoStorageProperties() { StorageAccountId = storageId }
            };

            if (tags != null)
            {
                resource.Tags = TagsConversionHelper.CreateTagDictionary(tags, true);
            }

            return resource;
        }

        /// <summary>
        /// Builds a BatchAccountContext object with the keys set for testing
        /// </summary>
        public static BatchAccountContext CreateBatchContextWithKeys()
        {
            AccountResource resource = CreateAccountResource("account", "resourceGroup");
            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(resource);
            string dummyKey = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            SetProperty(context, "PrimaryAccountKey", dummyKey);
            SetProperty(context, "SecondaryAccountKey", dummyKey);

            return context;
        }

        /// <summary>
        /// Verifies that two BatchAccountContext objects are equal
        /// </summary>
        public static void AssertBatchAccountContextsAreEqual(BatchAccountContext context1, BatchAccountContext context2)
        {
            if (context1 == null)
            {
                Assert.Null(context2);
                return;
            }
            if (context2 == null)
            {
                Assert.Null(context1);
                return;
            }

            Assert.Equal<string>(context1.AccountEndpoint, context2.AccountEndpoint);
            Assert.Equal<string>(context1.AccountName, context2.AccountName);
            Assert.Equal<string>(context1.Id, context2.Id);
            Assert.Equal<string>(context1.Location, context2.Location);
            Assert.Equal<string>(context1.PrimaryAccountKey, context2.PrimaryAccountKey);
            Assert.Equal<string>(context1.ResourceGroupName, context2.ResourceGroupName);
            Assert.Equal<string>(context1.SecondaryAccountKey, context2.SecondaryAccountKey);
            Assert.Equal<string>(context1.State, context2.State);
            Assert.Equal<string>(context1.Subscription, context2.Subscription);
            Assert.Equal<string>(context1.TagsTable, context2.TagsTable);
            Assert.Equal<string>(context1.TaskTenantUrl, context2.TaskTenantUrl);
            Assert.Equal<string>(context1.AutoStorageProperties.StorageAccountId, context2.AutoStorageProperties.StorageAccountId);
        }

        /// <summary>
        /// Creates a RequestInterceptor that does not contact the Batch Service but instead uses the supplied response body.
        /// </summary>
        /// <param name="responseToUse">The response the interceptor should return. If none is specified, then a new instance of the response type is instantiated.</param>
        /// <param name="requestAction">An action to perform on the request.</param>
        /// <typeparam name="TOptions">The type of the request options.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response.</typeparam>
        public static RequestInterceptor CreateFakeServiceResponseInterceptor<TOptions, TResponse>(TResponse responseToUse = default(TResponse),
            Action<BatchRequest<TOptions, TResponse>> requestAction = null)
            where TOptions : ProxyModels.IOptions, new()
            where TResponse : class, IAzureOperationResponse, new()
        {
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<TOptions, TResponse> request = (BatchRequest<TOptions, TResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    responseToUse = responseToUse ?? new TResponse()
                    {
                        Response = new HttpResponseMessage()
                    };

                    if (requestAction != null)
                    {
                        requestAction(request);
                    }

                    Task<TResponse> task = Task.FromResult(responseToUse);
                    return task;
                };
            });
            return interceptor;
        }

        /// <summary>
        /// Creates a RequestInterceptor that does not contact the Batch Service but instead uses the supplied response body.
        /// </summary>
        /// <param name="responseToUse">The response the interceptor should return. If none is specified, then a new instance of the response type is instantiated.</param>
        /// <param name="requestAction">An action to perform on the request.</param>
        /// <typeparam name="TBody">The type of the body parameters associated with the request.</typeparam>
        /// <typeparam name="TOptions">The type of the request options.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response.</typeparam>
        public static RequestInterceptor CreateFakeServiceResponseInterceptor<TBody, TOptions, TResponse>(TResponse responseToUse = default(TResponse),
            Action<BatchRequest<TBody, TOptions, TResponse>> requestAction = null)
            where TOptions : ProxyModels.IOptions, new()
            where TResponse : class, IAzureOperationResponse, new()
        {
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<TBody, TOptions, TResponse> request = (BatchRequest<TBody, TOptions, TResponse>)baseRequest;

                if (requestAction != null)
                {
                    requestAction(request);
                }

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    TResponse response = responseToUse ?? new TResponse()
                    {
                        Response = new HttpResponseMessage()
                    };

                    Task<TResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            return interceptor;
        }

        /// <summary>
        /// Builds a generic azure operation response object
        /// </summary>
        /// <typeparam name="TBody">The object that will be put in the response body</typeparam>
        /// <typeparam name="THeader">The type of header for the response</typeparam>
        /// <returns></returns>
        public static AzureOperationResponse<TBody, THeader> CreateGenericAzureOperationResponse<TBody, THeader>()
            where TBody : class, new()
            where THeader : class, new()
        {
            var response = new AzureOperationResponse<TBody, THeader>()
            {
                Body = new TBody(),
                Headers = new THeader()
            };

            return response;
        }

        /// <summary>
        /// Builds a generic azure operation response with a response body that contains a list of objects
        /// </summary>
        /// <typeparam name="TBody">The object that will be put in the response body as a list</typeparam>
        /// <typeparam name="THeader">The type of header for the response</typeparam>
        /// <returns></returns>
        public static AzureOperationResponse<IPage<TBody>, THeader> CreateGenericAzureOperationListResponse<TBody, THeader>()
            where TBody : class, new()
            where THeader : class, new()
        {
            var response = new AzureOperationResponse<IPage<TBody>, THeader>()
            {
                Body = new MockPagedEnumerable<TBody>(),
                Headers = new THeader()
            };

            return response;
        }

        /// <summary>
        /// Creates a RequestInterceptor that does not contact the Batch Service on a Get NodeFile or a Get NodeFile Properties call.
        /// The interceptor must handle both request types since it's possible for one OM node file method to perform both REST APIs.
        /// </summary>
        /// <param name="fileName">The name of the file to put in the response body.</param>
        public static RequestInterceptor CreateFakeGetFileAndPropertiesFromTaskResponseInterceptor(string fileName)
        {
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                FileGetFromTaskBatchRequest fileRequest = baseRequest as FileGetFromTaskBatchRequest;

                if (fileRequest != null)
                {
                    fileRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        var response = new AzureOperationResponse<Stream, ProxyModels.FileGetFromTaskHeaders>();
                        response.Headers = new ProxyModels.FileGetFromTaskHeaders();
                        response.Body = new MemoryStream();

                        Task<AzureOperationResponse<Stream, ProxyModels.FileGetFromTaskHeaders>> task = Task.FromResult(response);

                        return task;
                    };
                }
                else
                {
                    FileGetNodeFilePropertiesFromTaskBatchRequest propRequest = (FileGetNodeFilePropertiesFromTaskBatchRequest)baseRequest;

                    propRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        var response = new AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders>();
                        response.Headers = new ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders();

                        Task<AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders>> task = Task.FromResult(response);

                        return task;
                    };
                }
            });
            return interceptor;
        }

        /// <summary>
        /// Creates a RequestInterceptor that does not contact the Batch Service on a Get NodeFile or a Get NodeFile Properties call.
        /// The interceptor must handle both request types since it's possible for one OM node file method to perform both REST APIs.
        /// </summary>
        /// <param name="fileName">The name of the file to put in the response body.</param>
        public static RequestInterceptor CreateFakeGetFileAndPropertiesFromComputeNodeResponseInterceptor(string fileName)
        {
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                FileGetFromComputeNodeBatchRequest fileRequest = baseRequest as FileGetFromComputeNodeBatchRequest;

                if (fileRequest != null)
                {
                    fileRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        var response = new AzureOperationResponse<Stream, ProxyModels.FileGetFromComputeNodeHeaders>();
                        response.Headers = new ProxyModels.FileGetFromComputeNodeHeaders();
                        response.Body = new MemoryStream();

                        Task<AzureOperationResponse<Stream, ProxyModels.FileGetFromComputeNodeHeaders>> task = Task.FromResult(response);

                        return task;
                    };
                }
                else
                {
                    FileGetNodeFilePropertiesFromComputeNodeBatchRequest propRequest = (FileGetNodeFilePropertiesFromComputeNodeBatchRequest)baseRequest;

                    propRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        var response = new AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders>();
                        response.Headers = new ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders();

                        Task<AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders>> task = Task.FromResult(response);

                        return task;
                    };
                }
            });
            return interceptor;
        }

        /// <summary>
        /// Builds a CertificateGetResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.Certificate, ProxyModels.CertificateGetHeaders> CreateCertificateGetResponse(string thumbprint)
        {
            var response = new AzureOperationResponse<ProxyModels.Certificate, ProxyModels.CertificateGetHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            ProxyModels.Certificate cert = new ProxyModels.Certificate();
            cert.Thumbprint = thumbprint;

            response.Body = cert;

            return response;
        }

        /// <summary>
        /// Builds a CertificateListResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders> CreateCertificateListResponse(IEnumerable<string> certThumbprints)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.Certificate>, ProxyModels.CertificateListHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.Certificate> certs = new List<ProxyModels.Certificate>();

            foreach (string t in certThumbprints)
            {
                ProxyModels.Certificate cert = new ProxyModels.Certificate();
                cert.Thumbprint = t;
                certs.Add(cert);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.Certificate>(certs);

            return response;
        }

        /// <summary>
        /// Builds a CloudPoolGetResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders> CreateCloudPoolGetResponse(string poolId)
        {
            var response = new AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            ProxyModels.CloudPool pool = new ProxyModels.CloudPool();
            pool.Id = poolId;

            response.Body = pool;

            return response;
        }

        /// <summary>
        /// Builds a CloudPoolListResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders> CreateCloudPoolListResponse(IEnumerable<string> poolIds)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.CloudPool> pools = new List<ProxyModels.CloudPool>();

            foreach (string id in poolIds)
            {
                ProxyModels.CloudPool pool = new ProxyModels.CloudPool();
                pool.Id = id;
                pools.Add(pool);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.CloudPool>(pools);

            return response;
        }

        /// <summary>
        /// Builds a CloudPoolUsageMetricsResponse object. Note: The lengths of all three lists must be the same.
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.PoolUsageMetrics>, ProxyModels.PoolListPoolUsageMetricsHeaders> CreatePoolListUsageMetricsResponse(
            IEnumerable<string> poolIds,
            IEnumerable<DateTime> startTimes,
            IEnumerable<DateTime> endTimes)
        {
            var poolUsageList = new List<ProxyModels.PoolUsageMetrics>();

            // Validate the lengths of the lists are equal
            if (!(poolIds.Count() == startTimes.Count() && startTimes.Count() == endTimes.Count()))
            {
                throw new ArgumentException("The lists length are not equal.");
            }

            using (var startTimeEnumerator = startTimes.GetEnumerator())
            using (var endTimeEnumerator = endTimes.GetEnumerator())
            using (var poolIdEnumerator = poolIds.GetEnumerator())
            {
                while (startTimeEnumerator.MoveNext() && endTimeEnumerator.MoveNext() && poolIdEnumerator.MoveNext())
                {
                    poolUsageList.Add(new ProxyModels.PoolUsageMetrics()
                    {
                        PoolId = poolIdEnumerator.Current,
                        StartTime = startTimeEnumerator.Current,
                        EndTime = endTimeEnumerator.Current
                    });
                }
            }

            var response = new AzureOperationResponse
                <IPage<ProxyModels.PoolUsageMetrics>, ProxyModels.PoolListPoolUsageMetricsHeaders>()
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK),
                Body = new MockPagedEnumerable<ProxyModels.PoolUsageMetrics>(poolUsageList)
            };

            return response;
        }

        /// <summary>
        /// Builds a CloudPoolStatisticsResponse object. Note: Using avgCPUPercentage and startTime for validating if the pipeline return the correct values
        /// </summary>
        public static AzureOperationResponse<ProxyModels.PoolStatistics, ProxyModels.PoolGetAllPoolsLifetimeStatisticsHeaders> CreatePoolStatisticsResponse(
            double avgCPUPercentage,
            DateTime startTime)
        {
            var stats = new ProxyModels.PoolStatistics()
            {
                ResourceStats = new ProxyModels.ResourceStatistics() { AvgCPUPercentage = avgCPUPercentage },
                UsageStats = new ProxyModels.UsageStatistics() { StartTime =  startTime }
            };

            var response = new AzureOperationResponse
                <ProxyModels.PoolStatistics, ProxyModels.PoolGetAllPoolsLifetimeStatisticsHeaders>()
            {
                Body = stats,
                Response = new HttpResponseMessage(HttpStatusCode.Accepted)
            };

            return response;
        }

        /// <summary>
        /// Builds a CloudJobStatisticsResponse object.Note: Using startTime for validating if the pipeline return the correct values
        /// </summary>
        public static AzureOperationResponse<ProxyModels.JobStatistics, ProxyModels.JobGetAllJobsLifetimeStatisticsHeaders> CreateJobStatisticsResponse(DateTime startTime)
        {
            var stats = new ProxyModels.JobStatistics()
            {
                StartTime = startTime
            };

            var response = new AzureOperationResponse
                <ProxyModels.JobStatistics, ProxyModels.JobGetAllJobsLifetimeStatisticsHeaders>()
            {
                Body = stats,
                Response = new HttpResponseMessage(HttpStatusCode.Accepted)
            };

            return response;
        }

        /// <summary>
        /// Builds a GetRemoteLoginSettingsResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.ComputeNodeGetRemoteLoginSettingsResult, ProxyModels.ComputeNodeGetRemoteLoginSettingsHeaders> CreateRemoteLoginSettingsGetResponse(string ipAddress)
        {
            var settings = new ProxyModels.ComputeNodeGetRemoteLoginSettingsResult();
            settings.RemoteLoginIPAddress = ipAddress;

            var response = new AzureOperationResponse<ProxyModels.ComputeNodeGetRemoteLoginSettingsResult, ProxyModels.ComputeNodeGetRemoteLoginSettingsHeaders>()
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK),
                Body = settings
            };

            return response;
        }

        /// <summary>
        /// Builds a ComputeNodeGetResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeGetHeaders> CreateComputeNodeGetResponse(string computeNodeId)
        {
            var response = new AzureOperationResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeGetHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            ProxyModels.ComputeNode computeNode = new ProxyModels.ComputeNode();
            computeNode.Id = computeNodeId;

            response.Body = computeNode;

            return response;
        }

        /// <summary>
        /// Builds a ComputeNodeListResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders> CreateComputeNodeListResponse(IEnumerable<string> computeNodeIds)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.ComputeNode> computeNodes = new List<ProxyModels.ComputeNode>();

            foreach (string id in computeNodeIds)
            {
                ProxyModels.ComputeNode computeNode = new ProxyModels.ComputeNode();
                computeNode.Id = id;
                computeNodes.Add(computeNode);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.ComputeNode>(computeNodes);

            return response;
        }

        /// <summary>
        /// Builds a CloudJobScheduleGetResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders> CreateCloudJobScheduleGetResponse(string jobScheduleId)
        {
            var response = new AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            ProxyModels.JobSpecification jobSpec = new ProxyModels.JobSpecification();
            ProxyModels.Schedule schedule = new ProxyModels.Schedule();

            ProxyModels.CloudJobSchedule jobSchedule = new ProxyModels.CloudJobSchedule(id: jobScheduleId, schedule: schedule, jobSpecification: jobSpec);
            response.Body = jobSchedule;

            return response;
        }

        /// <summary>
        /// Builds a CloudJobScheduleListResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders> CreateCloudJobScheduleListResponse(IEnumerable<string> jobScheduleIds)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, ProxyModels.JobScheduleListHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.CloudJobSchedule> jobSchedules = new List<ProxyModels.CloudJobSchedule>();
            ProxyModels.JobSpecification jobSpec = new ProxyModels.JobSpecification();
            ProxyModels.Schedule schedule = new ProxyModels.Schedule();

            foreach (string id in jobScheduleIds)
            {
                jobSchedules.Add(new ProxyModels.CloudJobSchedule(id: id, schedule: schedule, jobSpecification: jobSpec));
            }

            response.Body = new MockPagedEnumerable<ProxyModels.CloudJobSchedule>(jobSchedules);

            return response;
        }

        /// <summary>
        /// Builds a CloudJobGetResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.CloudJob, ProxyModels.JobGetHeaders> CreateCloudJobGetResponse(string jobId)
        {
            var response = new AzureOperationResponse<ProxyModels.CloudJob, ProxyModels.JobGetHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            ProxyModels.CloudJob job = new ProxyModels.CloudJob();
            job.Id = jobId;

            response.Body = job;

            return response;
        }

        /// <summary>
        /// Builds a CloudJobListResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.CloudJob>, ProxyModels.JobListHeaders> CreateCloudJobListResponse(IEnumerable<string> jobIds)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.CloudJob>, ProxyModels.JobListHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.CloudJob> jobs = new List<ProxyModels.CloudJob>();

            foreach (string id in jobIds)
            {
                ProxyModels.CloudJob job = new ProxyModels.CloudJob();
                job.Id = id;
                jobs.Add(job);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.CloudJob>(jobs);

            return response;
        }

        /// <summary>
        /// Builds a CloudTaskGetResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.CloudTask, ProxyModels.TaskGetHeaders> CreateCloudTaskGetResponse(string taskId)
        {
            var response = new AzureOperationResponse<ProxyModels.CloudTask, ProxyModels.TaskGetHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            ProxyModels.CloudTask task = new ProxyModels.CloudTask();
            task.Id = taskId;

            response.Body = task;

            return response;
        }

        /// <summary>
        /// Builds a CloudTaskListResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.CloudTask>, ProxyModels.TaskListHeaders> CreateCloudTaskListResponse(IEnumerable<string> taskIds)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.CloudTask>, ProxyModels.TaskListHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.CloudTask> tasks = new List<ProxyModels.CloudTask>();

            foreach (string id in taskIds)
            {
                ProxyModels.CloudTask task = new ProxyModels.CloudTask();
                task.Id = id;
                tasks.Add(task);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.CloudTask>(tasks);

            return response;
        }

        /// <summary>
        /// Builds a TaskAddCollectionResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.TaskAddCollectionResult, ProxyModels.TaskAddCollectionHeaders> CreateTaskCollectionResponse(PSCloudTask[] taskCollection)
        {
            Func<PSCloudTask, ProxyModels.TaskAddResult> mappingFunc =
                t => new ProxyModels.TaskAddResult(ProxyModels.TaskAddStatus.Success, t.Id);

            var taskAddResults = taskCollection.Select(mappingFunc);

            var response = new AzureOperationResponse
                <ProxyModels.TaskAddCollectionResult, ProxyModels.TaskAddCollectionHeaders>()
            {
                Response = new HttpResponseMessage(HttpStatusCode.Created),
                Body = new ProxyModels.TaskAddCollectionResult(taskAddResults.ToList())
            };

            return response;
        }

        /// <summary>
        /// Builds a CloudTaskListSubtasksResponse object
        /// </summary>
        public static AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult, ProxyModels.TaskListSubtasksHeaders> CreateCloudTaskListSubtasksResponse(IEnumerable<int> subtaskIds = default(IEnumerable<int>))
        {
            var response = new AzureOperationResponse<ProxyModels.CloudTaskListSubtasksResult, ProxyModels.TaskListSubtasksHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.SubtaskInformation> subtasks = new List<ProxyModels.SubtaskInformation>();
            ProxyModels.CloudTaskListSubtasksResult subtasksResult = new ProxyModels.CloudTaskListSubtasksResult();

            if (subtaskIds != null)
            {
                foreach (int id in subtaskIds)
                {
                    ProxyModels.SubtaskInformation subtask = new ProxyModels.SubtaskInformation();
                    subtask.Id = id;
                    subtasks.Add(subtask);
                }
            }

            subtasksResult.Value = subtasks;
            response.Body = subtasksResult;

            return response;
        }

        /// <summary>
        /// Builds a NodeAgentSKUResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders> CreateNodeAgentSkuResponse(IEnumerable<string> skuIds)
        {
            IEnumerable<ProxyModels.NodeAgentSku> nodeAgents =
                skuIds.Select(id => new ProxyModels.NodeAgentSku() { Id = id });

            var response = new AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders>()
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK),
                Body = new MockPagedEnumerable<ProxyModels.NodeAgentSku>(nodeAgents)
            };

            return response;
        }

        /// <summary>
        /// Builds a NodeFileGetPropertiesResponse object
        /// </summary>
        public static AzureOperationResponse<Stream, ProxyModels.ComputeNodeGetRemoteDesktopHeaders> CreateGetRemoteDesktOperationResponse()
        {
            var response = new AzureOperationResponse<Stream, ProxyModels.ComputeNodeGetRemoteDesktopHeaders>();
            response.Headers = new ProxyModels.ComputeNodeGetRemoteDesktopHeaders();
            response.Body = new MemoryStream();
            return response;
        }

        /// <summary>
        /// Builds a NodeFileGetPropertiesFromTaskResponse object
        /// </summary>
        public static AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders> CreateNodeFileGetPropertiesByTaskResponse()
        {
            var response = new AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers = new ProxyModels.FileGetNodeFilePropertiesFromTaskHeaders();
            return response;
        }

        /// <summary>
        /// Builds a NodeFileGetPropertiesFromComputeNodeResponse object
        /// </summary>
        public static AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders> CreateNodeFileGetPropertiesByComputeNodeResponse()
        {
            var response = new AzureOperationHeaderResponse<ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers = new ProxyModels.FileGetNodeFilePropertiesFromComputeNodeHeaders();
            return response;
        }

        /// <summary>
        /// Builds a NodeFileGetPropertiesFromComputeNodeResponse object
        /// </summary>
        public static AzureOperationResponse<Stream, ProxyModels.FileGetFromComputeNodeHeaders> CreateNodeFileByComputeNodeResponse()
        {
            var response = new AzureOperationResponse<Stream, ProxyModels.FileGetFromComputeNodeHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers = new ProxyModels.FileGetFromComputeNodeHeaders();
            return response;
        }

        /// <summary>
        /// Builds a NodeFileListFromTaskResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders> CreateNodeFileListByTaskResponse(IEnumerable<string> fileNames)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromTaskHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.NodeFile> files = new List<ProxyModels.NodeFile>();

            foreach (string name in fileNames)
            {
                ProxyModels.NodeFile file = new ProxyModels.NodeFile();
                file.Name = name;
                files.Add(file);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.NodeFile>(files);

            return response;
        }

        /// <summary>
        /// Builds a NodeFileListFromComputeNodeResponse object
        /// </summary>
        public static AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders> CreateNodeFileListByComputeNodeResponse(IEnumerable<string> fileNames)
        {
            var response = new AzureOperationResponse<IPage<ProxyModels.NodeFile>, ProxyModels.FileListFromComputeNodeHeaders>();
            response.Response = new HttpResponseMessage(HttpStatusCode.OK);

            List<ProxyModels.NodeFile> files = new List<ProxyModels.NodeFile>();

            foreach (string name in fileNames)
            {
                ProxyModels.NodeFile file = new ProxyModels.NodeFile();
                file.Name = name;
                files.Add(file);
            }

            response.Body = new MockPagedEnumerable<ProxyModels.NodeFile>(files);

            return response;
        }

        /// <summary>
        /// Fabricates a CloudJob that's in the bound state
        /// </summary>
        public static CloudJob CreateFakeBoundJob(BatchAccountContext context)
        {
            string jobId = "testJob";

            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                JobGetBatchRequest request = (JobGetBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    var response = new AzureOperationResponse<ProxyModels.CloudJob, ProxyModels.JobGetHeaders>();
                    response.Body = new ProxyModels.CloudJob(id: jobId, poolInfo: new ProxyModels.PoolInformation());

                    Task<AzureOperationResponse<ProxyModels.CloudJob, ProxyModels.JobGetHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });

            return context.BatchOMClient.JobOperations.GetJob(jobId, additionalBehaviors: new BatchClientBehavior[] { interceptor });
        }

        /// <summary>
        /// Fabricates a CloudJobSchedule that's in the bound state
        /// </summary>
        public static CloudJobSchedule CreateFakeBoundJobSchedule(BatchAccountContext context)
        {
            string jobScheduleId = "testJobSchedule";

            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                JobScheduleGetBatchRequest request = (JobScheduleGetBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    var response = new AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders>();

                    response.Body = new ProxyModels.CloudJobSchedule(id: jobScheduleId, schedule: new ProxyModels.Schedule(), jobSpecification: new ProxyModels.JobSpecification());

                    Task<AzureOperationResponse<ProxyModels.CloudJobSchedule, ProxyModels.JobScheduleGetHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });

            return context.BatchOMClient.JobScheduleOperations.GetJobSchedule(jobScheduleId, additionalBehaviors: new BatchClientBehavior[] { interceptor });
        }

        /// <summary>
        /// Fabricates a CloudPool that's in the bound state
        /// </summary>
        public static CloudPool CreateFakeBoundPool(BatchAccountContext context)
        {
            string poolId = "testPool";

            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                PoolGetBatchRequest request = (PoolGetBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    var response = new AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>();
                    response.Body = new ProxyModels.CloudPool(poolId, "small", "4");

                    Task<AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });

            return context.BatchOMClient.PoolOperations.GetPool(poolId, additionalBehaviors: new BatchClientBehavior[] { interceptor });
        }

        /// <summary>
        /// Fabricates a CloudTask that's in the bound state
        /// </summary>
        public static CloudTask CreateFakeBoundTask(BatchAccountContext context)
        {
            string taskId = "testTask";

            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                TaskGetBatchRequest request = (TaskGetBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    var response = new AzureOperationResponse<ProxyModels.CloudTask, ProxyModels.TaskGetHeaders>();
                    response.Body = new ProxyModels.CloudTask(taskId, "cmd /c dir /s");

                    Task<AzureOperationResponse<ProxyModels.CloudTask, ProxyModels.TaskGetHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });

            return context.BatchOMClient.JobOperations.GetTask("jobId", taskId, additionalBehaviors: new BatchClientBehavior[] { interceptor });
        }

        /// <summary>
        /// Uses Reflection to set a property value on an object. Can be used to bypass restricted set accessors.
        /// </summary>
        internal static void SetProperty(object obj, string propertyName, object propertyValue)
        {
            Type t = obj.GetType();
            PropertyInfo propInfo = t.GetProperty(propertyName);
            propInfo.SetValue(obj, propertyValue);
        }

        /// <summary>
        /// Uses Reflection to set a property value on an object.
        /// </summary>
        internal static void SetField(object obj, string fieldName, object fieldValue)
        {
            Type t = obj.GetType();
            FieldInfo fieldInfo = t.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(obj, fieldValue);
        }

        internal static T MapEnum<T>(Enum otherEnum) where T : struct
        {
            if (otherEnum == null)
            {
                throw new ArgumentNullException("otherEnum");
            }

            T result = (T)Enum.Parse(typeof(T), otherEnum.ToString(), ignoreCase: true);
            return result;
        }

        internal static T? MapNullableEnum<T>(Enum otherEnum) where T : struct
        {
            if (otherEnum == null)
            {
                return null;
            }

            return MapEnum<T>(otherEnum);
        }
    }
}

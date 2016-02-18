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
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test
{
    /// <summary>
    /// Helper methods for the Batch cmdlet tests
    /// </summary>
    public static class BatchTestHelpers
    {
        internal static readonly string TestCertificateFileName1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\BatchTestCert01.cer");
        internal static readonly string TestCertificateFileName2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\BatchTestCert02.cer");
        internal const string TestCertificateAlgorithm = "sha1";
        internal const string TestCertificatePassword = "Passw0rd";

        /// <summary>
        /// Builds an AccountResource object using the specified parameters
        /// </summary>
        public static AccountResource CreateAccountResource(string accountName, string resourceGroupName, Hashtable[] tags = null)
        {
            string tenantUrlEnding = "batch-test.windows-int.net";
            string endpoint = string.Format("{0}.{1}", accountName, tenantUrlEnding);
            string subscription = Guid.Empty.ToString();
            string resourceGroup = resourceGroupName;

            AccountResource resource = new AccountResource()
            {
                Id = string.Format("id/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Batch/batchAccounts/abc", subscription, resourceGroup),
                Location = "location",
                Properties = new AccountProperties() { AccountEndpoint = endpoint, ProvisioningState = AccountProvisioningState.Succeeded },
                Type = "type"
            };
            if (tags != null)
            {
                resource.Tags = Microsoft.Azure.Commands.Batch.Helpers.CreateTagDictionary(tags, true);
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
        }

        /// <summary>
        /// Creates a RequestInterceptor that does not contact the Batch Service but instead uses the supplied response body.
        /// </summary>
        /// <param name="responseToUse">The response the interceptor should return. If none is specified, then a new instance of the response type is instantiated.</param>
        /// <param name="requestAction">An action to perform on the request.</param>
        /// <typeparam name="TParameters">The type of the request parameters.</typeparam>
        /// <typeparam name="TResponse">The type of the expected response.</typeparam>
        public static RequestInterceptor CreateFakeServiceResponseInterceptor<TParameters, TResponse>(TResponse responseToUse = null, 
            Action<BatchRequest<TParameters, TResponse>> requestAction = null)
            where TParameters : ProxyModels.BatchParameters
            where TResponse : ProxyModels.BatchOperationResponse, new()
        {
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<TParameters, TResponse> request = (BatchRequest<TParameters, TResponse>)baseRequest;

                if (requestAction != null)
                {
                    requestAction(request);
                }

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    TResponse response = responseToUse ?? new TResponse();
                    Task<TResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            return interceptor;
        }

        /// <summary>
        /// Creates a RequestInterceptor that does not contact the Batch Service on a Get NodeFile or a Get NodeFile Properties call.
        /// The interceptor must handle both request types since it's possible for one OM node file method to perform both REST APIs.
        /// </summary>
        /// <param name="fileName">The name of the file to put in the response body.</param>
        public static RequestInterceptor CreateFakGetFileAndPropertiesResponseInterceptor(string fileName)
        {
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<ProxyModels.NodeFileGetParameters, ProxyModels.NodeFileGetResponse> fileRequest = baseRequest as
                    BatchRequest<ProxyModels.NodeFileGetParameters, ProxyModels.NodeFileGetResponse>;

                if (fileRequest != null)
                {
                    fileRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        ProxyModels.NodeFileGetResponse response = new ProxyModels.NodeFileGetResponse();
                        Task<ProxyModels.NodeFileGetResponse> task = Task.FromResult(response);
                        return task;
                    };
                }
                else
                {
                    BatchRequest<ProxyModels.NodeFileGetPropertiesParameters, ProxyModels.NodeFileGetPropertiesResponse> propRequest =
                        (BatchRequest<ProxyModels.NodeFileGetPropertiesParameters, ProxyModels.NodeFileGetPropertiesResponse>)baseRequest;

                    propRequest.ServiceRequestFunc = (cancellationToken) =>
                    {
                        ProxyModels.NodeFileGetPropertiesResponse response = BatchTestHelpers.CreateNodeFileGetPropertiesResponse(fileName);
                        Task<ProxyModels.NodeFileGetPropertiesResponse> task = Task.FromResult(response);
                        return task;
                    };
                }
            });

            return interceptor;
        }

        /// <summary>
        /// Builds a CertificateGetResponse object
        /// </summary>
        public static ProxyModels.CertificateGetResponse CreateCertificateGetResponse(string thumbprint)
        {
            ProxyModels.CertificateGetResponse response = new ProxyModels.CertificateGetResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.Certificate cert = new ProxyModels.Certificate();
            cert.Thumbprint = thumbprint;

            response.Certificate = cert;

            return response;
        }

        /// <summary>
        /// Builds a CertificateListResponse object
        /// </summary>
        public static ProxyModels.CertificateListResponse CreateCertificateListResponse(IEnumerable<string> certThumbprints)
        {
            ProxyModels.CertificateListResponse response = new ProxyModels.CertificateListResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.Certificate> certs = new List<ProxyModels.Certificate>();

            foreach (string t in certThumbprints)
            {
                ProxyModels.Certificate cert = new ProxyModels.Certificate();
                cert.Thumbprint = t;
                certs.Add(cert);
            }

            response.Certificates = certs;

            return response;
        }

        /// <summary>
        /// Builds a CloudPoolGetResponse object
        /// </summary>
        public static ProxyModels.CloudPoolGetResponse CreateCloudPoolGetResponse(string poolId)
        {
            ProxyModels.CloudPoolGetResponse response = new ProxyModels.CloudPoolGetResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.CloudPool pool = new ProxyModels.CloudPool();
            pool.Id = poolId;

            response.Pool = pool;

            return response;
        }

        /// <summary>
        /// Builds a CloudPoolListResponse object
        /// </summary>
        public static ProxyModels.CloudPoolListResponse CreateCloudPoolListResponse(IEnumerable<string> poolIds)
        {
            ProxyModels.CloudPoolListResponse response = new ProxyModels.CloudPoolListResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.CloudPool> pools = new List<ProxyModels.CloudPool>();

            foreach (string id in poolIds)
            {
                ProxyModels.CloudPool pool = new ProxyModels.CloudPool();
                pool.Id = id;
                pools.Add(pool);
            }

            response.Pools = pools;

            return response;
        }

        /// <summary>
        /// Builds a ComputeNodeGetResponse object
        /// </summary>
        public static ProxyModels.ComputeNodeGetResponse CreateComputeNodeGetResponse(string computeNodeId)
        {
            ProxyModels.ComputeNodeGetResponse response = new ProxyModels.ComputeNodeGetResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.ComputeNode computeNode = new ProxyModels.ComputeNode();
            computeNode.Id = computeNodeId;
            response.ComputeNode = computeNode;

            return response;
        }

        /// <summary>
        /// Builds a ComputeNodeListResponse object
        /// </summary>
        public static ProxyModels.ComputeNodeListResponse CreateComputeNodeListResponse(IEnumerable<string> computeNodeIds)
        {
            ProxyModels.ComputeNodeListResponse response = new ProxyModels.ComputeNodeListResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.ComputeNode> computeNodes = new List<ProxyModels.ComputeNode>();

            foreach (string id in computeNodeIds)
            {
                ProxyModels.ComputeNode computeNode = new ProxyModels.ComputeNode();
                computeNode.Id = id;
                computeNodes.Add(computeNode);
            }

            response.ComputeNodes = computeNodes;

            return response;
        }

        /// <summary>
        /// Builds a CloudJobScheduleGetResponse object
        /// </summary>
        public static ProxyModels.CloudJobScheduleGetResponse CreateCloudJobScheduleGetResponse(string jobScheduleId)
        {
            ProxyModels.CloudJobScheduleGetResponse response = new ProxyModels.CloudJobScheduleGetResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.JobSpecification jobSpec = new ProxyModels.JobSpecification();
            ProxyModels.Schedule schedule = new ProxyModels.Schedule();

            ProxyModels.CloudJobSchedule jobSchedule = new ProxyModels.CloudJobSchedule(jobScheduleId, schedule, jobSpec);
            response.JobSchedule = jobSchedule;

            return response;
        }

        /// <summary>
        /// Builds a CloudJobScheduleListResponse object
        /// </summary>
        public static ProxyModels.CloudJobScheduleListResponse CreateCloudJobScheduleListResponse(IEnumerable<string> jobScheduleIds)
        {
            ProxyModels.CloudJobScheduleListResponse response = new ProxyModels.CloudJobScheduleListResponse();
            response.StatusCode = HttpStatusCode.OK;;

            List<ProxyModels.CloudJobSchedule> jobSchedules = new List<ProxyModels.CloudJobSchedule>();
            ProxyModels.JobSpecification jobSpec = new ProxyModels.JobSpecification();
            ProxyModels.Schedule schedule = new ProxyModels.Schedule();

            foreach (string id in jobScheduleIds)
            {
                jobSchedules.Add(new ProxyModels.CloudJobSchedule(id, schedule, jobSpec));
            }

            response.JobSchedules = jobSchedules;

            return response;
        }

        /// <summary>
        /// Builds a CloudJobGetResponse object
        /// </summary>
        public static ProxyModels.CloudJobGetResponse CreateCloudJobGetResponse(string jobId)
        {
            ProxyModels.CloudJobGetResponse response = new ProxyModels.CloudJobGetResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.CloudJob job = new ProxyModels.CloudJob();
            job.Id = jobId;

            response.Job = job;

            return response;
        }

        /// <summary>
        /// Builds a CloudJobListResponse object
        /// </summary>
        public static ProxyModels.CloudJobListResponse CreateCloudJobListResponse(IEnumerable<string> jobIds)
        {
            ProxyModels.CloudJobListResponse response = new ProxyModels.CloudJobListResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.CloudJob> jobs = new List<ProxyModels.CloudJob>();

            foreach (string id in jobIds)
            {
                ProxyModels.CloudJob job = new ProxyModels.CloudJob();
                job.Id = id;
                jobs.Add(job);
            }

            response.Jobs = jobs;

            return response;
        }

        /// <summary>
        /// Builds a CloudTaskGetResponse object
        /// </summary>
        public static ProxyModels.CloudTaskGetResponse CreateCloudTaskGetResponse(string taskId)
        {
            ProxyModels.CloudTaskGetResponse response = new ProxyModels.CloudTaskGetResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.CloudTask task = new ProxyModels.CloudTask();
            task.Id = taskId;

            response.Task = task;

            return response;
        }

        /// <summary>
        /// Builds a CloudTaskListResponse object
        /// </summary>
        public static ProxyModels.CloudTaskListResponse CreateCloudTaskListResponse(IEnumerable<string> taskIds)
        {
            ProxyModels.CloudTaskListResponse response = new ProxyModels.CloudTaskListResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.CloudTask> tasks = new List<ProxyModels.CloudTask>();

            foreach (string id in taskIds)
            {
                ProxyModels.CloudTask task = new ProxyModels.CloudTask();
                task.Id = id;
                tasks.Add(task);
            }

            response.Tasks = tasks;

            return response;
        }

        /// <summary>
        /// Builds a CloudTaskListSubtasksResponse object
        /// </summary>
        public static ProxyModels.CloudTaskListSubtasksResponse CreateCloudTaskListSubtasksResponse(IEnumerable<int> subtaskIds)
        {
            ProxyModels.CloudTaskListSubtasksResponse response = new ProxyModels.CloudTaskListSubtasksResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.SubtaskInformation> subtasks = new List<ProxyModels.SubtaskInformation>();

            foreach (int id in subtaskIds)
            {
                ProxyModels.SubtaskInformation subtask = new ProxyModels.SubtaskInformation();
                subtask.Id = id;
                subtasks.Add(subtask);
            }

            response.SubtasksInformation = subtasks;

            return response;
        }

        /// <summary>
        /// Builds a NodeFileGetPropertiesResponse object
        /// </summary>
        public static ProxyModels.NodeFileGetPropertiesResponse CreateNodeFileGetPropertiesResponse(string fileName)
        {
            ProxyModels.NodeFileGetPropertiesResponse response = new ProxyModels.NodeFileGetPropertiesResponse();
            response.StatusCode = HttpStatusCode.OK;

            ProxyModels.NodeFile file = new ProxyModels.NodeFile();
            file.Name = fileName;

            response.File = file;

            return response;
        }

        /// <summary>
        /// Builds a NodeFileListResponse object
        /// </summary>
        public static ProxyModels.NodeFileListResponse CreateNodeFileListResponse(IEnumerable<string> fileNames)
        {
            ProxyModels.NodeFileListResponse response = new ProxyModels.NodeFileListResponse();
            response.StatusCode = HttpStatusCode.OK;

            List<ProxyModels.NodeFile> files = new List<ProxyModels.NodeFile>();

            foreach (string name in fileNames)
            {
                ProxyModels.NodeFile file = new ProxyModels.NodeFile();
                file.Name = name;
                files.Add(file);
            }

            response.Files = files;

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
                BatchRequest<ProxyModels.CloudJobGetParameters, ProxyModels.CloudJobGetResponse> request =
                (BatchRequest<ProxyModels.CloudJobGetParameters, ProxyModels.CloudJobGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    ProxyModels.CloudJobGetResponse response = new ProxyModels.CloudJobGetResponse();
                    response.Job = new ProxyModels.CloudJob(jobId, new ProxyModels.PoolInformation());

                    Task<ProxyModels.CloudJobGetResponse> task = Task.FromResult(response);
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
                BatchRequest<ProxyModels.CloudJobScheduleGetParameters, ProxyModels.CloudJobScheduleGetResponse> request =
                (BatchRequest<ProxyModels.CloudJobScheduleGetParameters, ProxyModels.CloudJobScheduleGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    ProxyModels.CloudJobScheduleGetResponse response = new ProxyModels.CloudJobScheduleGetResponse();
                    response.JobSchedule = new ProxyModels.CloudJobSchedule(jobScheduleId, new ProxyModels.Schedule(), new ProxyModels.JobSpecification());

                    Task<ProxyModels.CloudJobScheduleGetResponse> task = Task.FromResult(response);
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
                BatchRequest<ProxyModels.CloudPoolGetParameters, ProxyModels.CloudPoolGetResponse> request =
                (BatchRequest<ProxyModels.CloudPoolGetParameters, ProxyModels.CloudPoolGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    ProxyModels.CloudPoolGetResponse response = new ProxyModels.CloudPoolGetResponse();
                    response.Pool = new ProxyModels.CloudPool(poolId, "small", "4");

                    Task<ProxyModels.CloudPoolGetResponse> task = Task.FromResult(response);
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
                BatchRequest<ProxyModels.CloudTaskGetParameters, ProxyModels.CloudTaskGetResponse> request =
                (BatchRequest<ProxyModels.CloudTaskGetParameters, ProxyModels.CloudTaskGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    ProxyModels.CloudTaskGetResponse response = new ProxyModels.CloudTaskGetResponse();
                    response.Task = new ProxyModels.CloudTask(taskId, "cmd /c dir /s");

                    Task<ProxyModels.CloudTaskGetResponse> task = Task.FromResult(response);
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
    }
}

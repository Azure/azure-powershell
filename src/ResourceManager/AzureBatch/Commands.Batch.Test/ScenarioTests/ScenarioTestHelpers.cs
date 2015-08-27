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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Auth;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Reflection;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Moq;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    /// <summary>
    /// Helper methods for the Batch cmdlet scenario tests
    /// </summary>
    public static class ScenarioTestHelpers
    {
        // NOTE: To save time on setup and compute node allocation when recording, many tests assume the following:
        //     - A Batch account named 'pstests' exists under the subscription being used for recording.
        //     - The following commands were run to create a pool, and all 3 compute nodes are allocated:
        //          $context = Get-AzureBatchAccountKeys "pstests"
        //          $startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
        //          $startTask.CommandLine = "cmd /c echo hello"
        //          New-AzureBatchPool -Id "testPool" -VirtualMachineSize "small" -OSFamily "4" -TargetOSVersion "*" -TargetDedicated 3 -StartTask $startTask -BatchContext $context
        internal const string SharedAccount = "pstests";
        internal const string SharedPool = "testPool";
        internal const string SharedPoolStartTaskStdOut = "startup\\stdout.txt";
        internal const string SharedPoolStartTaskStdOutContent = "hello";

        /// <summary>
        /// Creates an account and resource group for use with the Scenario tests
        /// </summary>
        public static BatchAccountContext CreateTestAccountAndResourceGroup(BatchController controller, string resourceGroupName, string accountName, string location)
        {
            controller.ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup() { Location = location });
            BatchAccountCreateResponse createResponse = controller.BatchManagementClient.Accounts.Create(resourceGroupName, accountName, new BatchAccountCreateParameters() { Location = location });
            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(createResponse.Resource);
            BatchAccountListKeyResponse response = controller.BatchManagementClient.Accounts.ListKeys(resourceGroupName, accountName);
            context.PrimaryAccountKey = response.PrimaryKey;
            context.SecondaryAccountKey = response.SecondaryKey;
            return context;
        }

        /// <summary>
        /// Get Batch Context with keys
        /// </summary>
        public static BatchAccountContext GetBatchAccountContextWithKeys(BatchController controller, string accountName)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);
            BatchAccountContext context = client.ListKeys(null, accountName);

            return context;
        }

        /// <summary>
        /// Cleans up an account and resource group used in a Scenario test.
        /// </summary>
        public static void CleanupTestAccount(BatchController controller, string resourceGroupName, string accountName)
        {
            controller.BatchManagementClient.Accounts.Delete(resourceGroupName, accountName);
            controller.ResourceManagementClient.ResourceGroups.Delete(resourceGroupName);
        }

        /// <summary>
        /// Creates a test pool for use in Scenario tests.
        /// </summary>
        public static void CreateTestPool(BatchController controller, BatchAccountContext context, string poolId, int targetDedicated)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            NewPoolParameters parameters = new NewPoolParameters(context, poolId, behaviors)
            {
                VirtualMachineSize = "small",
                OSFamily = "4",
                TargetOSVersion = "*",
                TargetDedicated = targetDedicated,
            };

            client.CreatePool(parameters);
        }

        public static void EnableAutoScale(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            string formula = "$TargetDedicated=2";
            AutoScaleParameters parameters = new AutoScaleParameters(context, poolId, null, formula, behaviors);
            client.EnableAutoScale(parameters);
        }

        public static void DisableAutoScale(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PoolOperationParameters parameters = new PoolOperationParameters(context, poolId, null, behaviors);
            client.DisableAutoScale(parameters);
        }

        public static string WaitForOSVersionChange(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context, behaviors)
            {
                PoolId = poolId
            };

            DateTime timeout = DateTime.Now.AddMinutes(2);
            PSCloudPool pool = client.ListPools(options).First();
            while (pool.CurrentOSVersion != pool.TargetOSVersion)
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for active state pool");
                }
                Sleep(5000);
                pool = client.ListPools(options).First();
            }

            return pool.TargetOSVersion;
        }

        public static void WaitForSteadyPoolAllocation(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context, behaviors)
            {
                PoolId = poolId
            };

            DateTime timeout = DateTime.Now.AddMinutes(2);
            PSCloudPool pool = client.ListPools(options).First();
            while (pool.AllocationState != AllocationState.Steady)
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for steady allocation state");
                }
                Sleep(5000);
                pool = client.ListPools(options).First();
            }
        }

        /// <summary>
        /// Gets the CurrentDedicated count from a pool
        /// </summary>
        public static int GetPoolCurrentDedicated(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context, behaviors)
            {
                PoolId = poolId
            };

            PSCloudPool pool = client.ListPools(options).First();
            return pool.CurrentDedicated.Value;
        }

        /// <summary>
        /// Gets the number of pools under the specified account
        /// </summary>
        public static int GetPoolCount(BatchController controller, BatchAccountContext context)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context, behaviors);

            return client.ListPools(options).Count();
        }


        /// <summary>
        /// Deletes a pool used in a Scenario test.
        /// </summary>
        public static void DeletePool(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeletePool(context, poolId, behaviors);
        }

        /// <summary>
        /// Creates a test job schedule for use in Scenario tests.
        /// </summary>
        public static void CreateTestJobSchedule(BatchController controller, BatchAccountContext context, string jobScheduleId, TimeSpan? recurrenceInterval)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PSJobSpecification jobSpecification = new PSJobSpecification();
            jobSpecification.PoolInformation = new PSPoolInformation();
            jobSpecification.PoolInformation.PoolId = SharedPool;
            PSSchedule schedule = new PSSchedule();
            if (recurrenceInterval != null)
            {
                schedule = new PSSchedule();
                schedule.RecurrenceInterval = recurrenceInterval;
            }

            NewJobScheduleParameters parameters = new NewJobScheduleParameters(context, jobScheduleId, behaviors)
            {
                JobSpecification = jobSpecification,
                Schedule = schedule
            };

            client.CreateJobSchedule(parameters);
        }

        /// <summary>
        /// Creates a test job for use in Scenario tests.
        /// </summary>
        public static void CreateTestJob(BatchController controller, BatchAccountContext context, string jobId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PSPoolInformation poolInfo = new PSPoolInformation();
            poolInfo.PoolId = SharedPool;

            NewJobParameters parameters = new NewJobParameters(context, jobId, behaviors)
            {
                PoolInformation = poolInfo
            };

            client.CreateJob(parameters);
        }

        /// <summary>
        /// Waits for a recent job on a job schedule and returns its id. If a previous job is specified, this method waits until a new job is created.
        /// </summary>
        public static string WaitForRecentJob(BatchController controller, BatchAccountContext context, string jobScheduleId, string previousJob = null)
        {
            DateTime timeout = DateTime.Now.AddMinutes(2);
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListJobScheduleOptions options = new ListJobScheduleOptions(context, behaviors)
            {
                JobScheduleId = jobScheduleId,
                Filter = null,
                MaxCount = Constants.DefaultMaxCount
            };
            PSCloudJobSchedule jobSchedule = client.ListJobSchedules(options).First();

            while (jobSchedule.ExecutionInformation.RecentJob == null || string.Equals(jobSchedule.ExecutionInformation.RecentJob.Id, previousJob, StringComparison.OrdinalIgnoreCase))
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for recent job");
                }
                Sleep(5000);
                jobSchedule = client.ListJobSchedules(options).First();
            }
            return jobSchedule.ExecutionInformation.RecentJob.Id;
        }

        /// <summary>
        /// Creates a test task for use in Scenario tests.
        /// </summary>
        public static void CreateTestTask(BatchController controller, BatchAccountContext context, string jobId, string taskId, string cmdLine = "cmd /c dir /s")
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            NewTaskParameters parameters = new NewTaskParameters(context, jobId, null, taskId, behaviors)
            {
                CommandLine = cmdLine,
                RunElevated = true
            };
            
            client.CreateTask(parameters);
        }

        /// <summary>
        /// Waits for the specified task to complete
        /// </summary>
        public static void WaitForTaskCompletion(BatchController controller, BatchAccountContext context, string jobId, string taskId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListTaskOptions options = new ListTaskOptions(context, jobId, null, behaviors)
            {
                TaskId = taskId
            };
            IEnumerable<PSCloudTask> tasks = client.ListTasks(options);

            // Save time by not waiting during playback scenarios
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TaskStateMonitor monitor = context.BatchOMClient.Utilities.CreateTaskStateMonitor();
                monitor.WaitAll(tasks.Select(t => t.omObject), TaskState.Completed, TimeSpan.FromMinutes(2), null);
            }
        }

        /// <summary>
        /// Deletes a job schedule used in a Scenario test.
        /// </summary>
        public static void DeleteJobSchedule(BatchController controller, BatchAccountContext context, string jobScheduleId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeleteJobSchedule(context, jobScheduleId, behaviors);
        }

        /// <summary>
        /// Deletes a job used in a Scenario test.
        /// </summary>
        public static void DeleteJob(BatchController controller, BatchAccountContext context, string jobId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeleteJob(context, jobId, behaviors);
        }

        /// <summary>
        /// Terminates a job
        /// TODO: Replace with terminate Job client method when it exists.
        /// </summary>
        public static void TerminateJob(BatchAccountContext context, string jobId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };

            context.BatchOMClient.JobOperations.TerminateJob(jobId, additionalBehaviors: behaviors);
        }

        /// <summary>
        /// Gets the id of a compute node in the specified pool
        /// </summary>
        public static string GetComputeNodeId(BatchController controller, BatchAccountContext context, string poolId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListComputeNodeOptions options = new ListComputeNodeOptions(context, poolId, null, behaviors);

            return client.ListComputeNodes(options).First().Id;
        }

        /// <summary>
        /// Waits for a compute node to get to the idle state
        /// </summary>
        public static void WaitForIdleComputeNode(BatchController controller, BatchAccountContext context, string poolId, string computeNodeId)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListComputeNodeOptions options = new ListComputeNodeOptions(context, poolId, null, behaviors)
            {
                ComputeNodeId = computeNodeId
            };

            DateTime timeout = DateTime.Now.AddMinutes(2);
            PSComputeNode computeNode = client.ListComputeNodes(options).First();
            if (computeNode.State != ComputeNodeState.Idle)
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for idle compute node");
                }

                Sleep(5000);
                computeNode = client.ListComputeNodes(options).First();
            }
        }

        /// <summary>
        /// Creates a test user for use in Scenario tests.
        /// </summary>
        public static void CreateComputeNodeUser(BatchController controller, BatchAccountContext context, string poolId, string computeNodeId, string computeNodeUserName)
        {
            RequestInterceptor interceptor = CreateHttpRecordingInterceptor();
            BatchClientBehavior[] behaviors = new BatchClientBehavior[] { interceptor };
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            NewComputeNodeUserParameters parameters = new NewComputeNodeUserParameters(context, poolId, computeNodeId, null, behaviors)
            {
                ComputeNodeUserName = computeNodeUserName,
                Password = "Password1234!",
            };

            client.CreateComputeNodeUser(parameters);
        }

        /// <summary>
        /// Creates an interceptor that can be used to support the HTTP recorder scenario tests.
        /// This behavior grabs the outgoing Protocol request, converts it to an HttpRequestMessage compatible with the 
        /// HTTP recorder, sends the request through the HTTP recorder, and converts the response to an HttpWebResponse
        /// for serialization by the Protocol Layer.
        /// NOTE: This is a temporary behavior that should no longer be needed when the Batch OM switches to Hyak.
        /// </summary>
        public static RequestInterceptor CreateHttpRecordingInterceptor()
        {
            RequestInterceptor interceptor = new RequestInterceptor((batchRequest) =>
            {
                // Setup HTTP recorder
                HttpMockServer mockServer = HttpMockServer.CreateInstance();
                mockServer.InnerHandler = new HttpClientHandler();
                batchRequest.RestClient.AddHandlerToPipeline(mockServer);
            });
            return interceptor;
        }

        /// <summary>
        /// Sleep method used for Scenario Tests. Only sleep when recording.
        /// </summary>
        private static void Sleep(int milliseconds)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                Thread.Sleep(milliseconds);
            }
        }
    }
}

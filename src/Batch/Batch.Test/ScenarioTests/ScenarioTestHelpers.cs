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
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
#if NETSTANDARD
using System.Threading.Tasks;
#else
using System.IO;
#endif
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;
using BatchAccount = Microsoft.Azure.Management.Batch.Models.BatchAccount;
using BatchAccountCreateParameters = Microsoft.Azure.Management.Batch.Models.BatchAccountCreateParameters;
using BatchAccountKeys = Microsoft.Azure.Management.Batch.Models.BatchAccountKeys;
using ApplicationPackage = Microsoft.Azure.Management.Batch.Models.ApplicationPackage;
using System.Security.Policy;


namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    /// <summary>
    /// Helper methods for the Batch cmdlet scenario tests
    /// </summary>
    public static class ScenarioTestHelpers
    {
        // We expect that the following pools be created, with a configuration like:
        // testPool:
        //  - 2 nodes
        //  - PAAS
        //  - A start task with: "cmd /c "echo hello""

        // testIaasPool
        //  - 1 node
        //  - IAAS (Ubuntu 18.04)

        internal const string SharedPool = "testPool";
        internal const string SharedIaasPool = "testIaasPool";
        internal const string SharedPoolStartTaskStdOut = "startup\\stdout.txt";
        internal const string SharedPoolStartTaskStdOutContent = "hello";

        // MPI requires a special pool configuration, so a dedicated pool is used.
        internal const string MpiPoolId = "mpiPool";

        internal const string BatchAccountName = "AZURE_BATCH_ACCOUNT";
        internal const string BatchAccountKey = "AZURE_BATCH_ACCESS_KEY";
        internal const string BatchAccountEndpoint = "AZURE_BATCH_ENDPOINT";
        internal const string BatchAccountResourceGroup = "AZURE_BATCH_RESOURCE_GROUP";

        /// <summary>
        /// Creates an account and resource group for use with the Scenario tests
        /// </summary>
        public static BatchAccountContext CreateTestAccountAndResourceGroup(BatchTestRunner runner, string resourceGroupName, string accountName, string location)
        {
            runner.ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup() { Location = location });
            BatchAccount createResponse = runner.BatchManagementClient.BatchAccount.Create(resourceGroupName, accountName, new BatchAccountCreateParameters() { Location = location });
            BatchAccountContext context = BatchAccountContext.ConvertAccountResourceToNewAccountContext(createResponse, null);
            BatchAccountKeys response = runner.BatchManagementClient.BatchAccount.GetKeys(resourceGroupName, accountName);
            context.PrimaryAccountKey = response.Primary;
            context.SecondaryAccountKey = response.Secondary;
            return context;
        }

        /// <summary>
        /// Cleans up an account and resource group used in a Scenario test.
        /// </summary>
        public static void CleanupTestAccount(BatchTestRunner runner, string resourceGroupName, string accountName)
        {
            runner.BatchManagementClient.BatchAccount.Delete(resourceGroupName, accountName);
            runner.ResourceManagementClient.ResourceGroups.Delete(resourceGroupName);
        }

        /// <summary>
        /// Adds a test certificate for use in Scenario tests. Returns the thumbprint of the cert.
        /// </summary>
        [Obsolete]
        public static string AddTestCertificate(BatchTestRunner runner, BatchAccountContext context, string filePath)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            X509Certificate2 cert = new X509Certificate2(filePath);
            ListCertificateOptions getParameters = new ListCertificateOptions(context)
            {
                ThumbprintAlgorithm = BatchTestHelpers.TestCertificateAlgorithm,
                Thumbprint = cert.Thumbprint,
                Select = "thumbprint,state"
            };

            try
            {
                PSCertificate existingCert = client.ListCertificates(getParameters).FirstOrDefault();
                DateTime start = DateTime.Now;
                TimeSpan timeout = GetTimeout(TimeSpan.FromMinutes(5));
                DateTime end = start.Add(timeout);

                // Cert might still be deleting from other tests, so we wait for the delete to finish.
                while (existingCert != null && existingCert.State == CertificateState.Deleting)
                {
                    if (DateTime.Now > end)
                    {
                        throw new TimeoutException("Timed out waiting for existing cert to be deleted.");
                    }
                    Sleep(5000);
                    existingCert = client.ListCertificates(getParameters).FirstOrDefault();
                }
            }
            catch (BatchException ex)
            {
                // When the cert doesn't exist, we get a 404 error. For all other errors, throw.
                if (ex == null || !ex.Message.Contains("NotFound"))
                {
                    throw;
                }
            }

            NewCertificateParameters parameters = new NewCertificateParameters(
                context, null, cert.RawData, PSCertificateKind.Cer);

            client.AddCertificate(parameters);

            return cert.Thumbprint;
        }

        /// <summary>
        /// Deletes a certificate.
        /// </summary>
        public static void DeleteTestCertificate(BatchTestRunner runner, BatchAccountContext context, string thumbprintAlgorithm, string thumbprint)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            CertificateOperationParameters parameters = new CertificateOperationParameters(context, thumbprintAlgorithm,
                thumbprint);

            client.DeleteCertificate(parameters);
        }

        /// <summary>
        /// Deletes a certificate.
        /// </summary>
        [Obsolete]
        public static void WaitForCertificateToFailDeletion(BatchTestRunner runner, BatchAccountContext context, string thumbprintAlgorithm, string thumbprint)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListCertificateOptions parameters = new ListCertificateOptions(context)
            {
                ThumbprintAlgorithm = BatchTestHelpers.TestCertificateAlgorithm,
                Thumbprint = thumbprint
            };

            PSCertificate cert = client.ListCertificates(parameters).First();

            DateTime timeout = DateTime.Now.Add(GetTimeout(TimeSpan.FromMinutes(2)));
            while (cert.State != CertificateState.DeleteFailed)
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timed out waiting for failed certificate deletion");
                }
                Sleep(10000);
                cert = client.ListCertificates(parameters).First();
            }
        }

        /// <summary>
        /// Creates a test pool for use in Scenario tests.
        /// </summary>
        public static void CreateTestPool(
            BatchTestRunner runner,
            BatchAccountContext context,
            string poolId,
            int? targetDedicated,
            int? targetLowPriority,
            CertificateReference certReference = null,
            StartTask startTask = null,
            UpgradePolicy upgradePolicy = null)
        {
            PSCertificateReference[] certReferences = null;
            if (certReference != null)
            {
                certReferences = new PSCertificateReference[] { new PSCertificateReference(certReference) };
            }
            PSStartTask psStartTask = null;
            if (startTask != null)
            {
                psStartTask = new PSStartTask(startTask);
            }

            PSUpgradePolicy psUpgradePolicy = null;
            if (upgradePolicy != null)
            {
                psUpgradePolicy = new PSUpgradePolicy(upgradePolicy);
            }

            PSCloudServiceConfiguration paasConfiguration = new PSCloudServiceConfiguration("4", "*");
           
            NewPoolParameters parameters = new NewPoolParameters(context, poolId)
            {
                VirtualMachineSize = "standard_d1_v2",
                CloudServiceConfiguration = paasConfiguration,
                TargetDedicatedComputeNodes = targetDedicated,
                TargetLowPriorityComputeNodes = targetLowPriority,
                CertificateReferences = certReferences,
                UpgradePolicy = psUpgradePolicy,
                StartTask = psStartTask,
                InterComputeNodeCommunicationEnabled = true,
                TargetCommunicationMode = NodeCommunicationMode.Classic
            };

            CreatePoolIfNotExists(runner, parameters);
        }

        /// <summary>
        /// Creates a test pool for use in Scenario tests.
        /// </summary>
        public static void CreateTestPoolVirtualMachine(
            BatchTestRunner runner,
            BatchAccountContext context,
            string poolId,
            int? targetDedicated,
            int? targetLowPriority,
            CertificateReference certReference = null,
            StartTask startTask = null,
            UpgradePolicy upgradePolicy = null)
        {
            PSCertificateReference[] certReferences = null;
            if (certReference != null)
            {
                certReferences = new PSCertificateReference[] { new PSCertificateReference(certReference) };
            }
            PSStartTask psStartTask = null;
            if (startTask != null)
            {
                psStartTask = new PSStartTask(startTask);
            }

            PSUpgradePolicy psUpgradePolicy = null;
            if (upgradePolicy != null)
            {
                psUpgradePolicy = new PSUpgradePolicy(upgradePolicy);
            }

            string vmSize = "STANDARD_D2S_V3";
            string publisher = "canonical";
            string offer = "0001-com-ubuntu-server-focal";
            string sku = "20_04-lts";
            string nodeAgent = "batch.node.ubuntu 20.04";

            PSImageReference imageReference = new PSImageReference(offer: offer, publisher: publisher, sku: sku);
            PSVirtualMachineConfiguration vmConfiguration = new PSVirtualMachineConfiguration(imageReference, nodeAgent);
            vmConfiguration.NodePlacementConfiguration = new PSNodePlacementConfiguration(NodePlacementPolicyType.Zonal);

            NewPoolParameters parameters = new NewPoolParameters(context, poolId)
            {
                VirtualMachineSize = vmSize,
                VirtualMachineConfiguration = vmConfiguration,
                TargetDedicatedComputeNodes = targetDedicated,
                TargetLowPriorityComputeNodes = targetLowPriority,
                CertificateReferences = certReferences,
                UpgradePolicy = psUpgradePolicy,
                StartTask = psStartTask,
                TaskSlotsPerNode = 1,
                InterComputeNodeCommunicationEnabled = true
            };

            CreatePoolIfNotExists(runner, parameters);
        }


        public static void CreatePoolIfNotExists(
            BatchTestRunner runner,
            NewPoolParameters poolParameters)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            try
            {
                client.CreatePool(poolParameters);
            }
            catch (BatchException e)
            {
                if (e.RequestInformation.BatchError.Code != "PoolExists")
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Creates an MPI pool.
        /// </summary>
        public static void CreateMpiPoolIfNotExists(BatchTestRunner runner, BatchAccountContext context, int targetDedicated = 3)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);
            ListPoolOptions listOptions = new ListPoolOptions(context)
            {
                PoolId = MpiPoolId
            };

            try
            {
                client.ListPools(listOptions);
                return; // The call returned without throwing an exception, so the pool exists
            }
            catch (BatchException ex)
            {
                if (ex.RequestInformation == null || ex.RequestInformation.BatchError == null ||
                    ex.RequestInformation.BatchError.Code != BatchErrorCodeStrings.PoolNotFound)
                {
                    throw;
                }
                // We got the pool not found error, so continue and create the pool
            }

            CreateTestPoolVirtualMachine(runner, context, MpiPoolId, targetDedicated, targetLowPriority: 0);
        }

        public static void WaitForSteadyPoolAllocation(BatchTestRunner runner, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context)
            {
                PoolId = poolId
            };

            DateTime timeout = DateTime.Now.Add(GetTimeout(TimeSpan.FromMinutes(5)));
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
        /// Gets the number of pools under the specified account
        /// </summary>
        public static int GetPoolCount(BatchTestRunner runner, BatchAccountContext context)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context);

            return client.ListPools(options).Count();
        }


        /// <summary>
        /// Deletes a pool used in a Scenario test.
        /// </summary>
        public static void DeletePool(BatchTestRunner runner, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            client.DeletePool(context, poolId);
        }

        /// <summary>
        /// Creates a test job schedule for use in Scenario tests.
        /// </summary>
        public static void CreateTestJobSchedule(BatchTestRunner runner, BatchAccountContext context, string jobScheduleId, TimeSpan? recurrenceInterval)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            PSJobSpecification jobSpecification = new PSJobSpecification();
            jobSpecification.PoolInformation = new PSPoolInformation();
            jobSpecification.PoolInformation.PoolId = SharedPool;
            PSSchedule schedule = new PSSchedule();
            if (recurrenceInterval != null)
            {
                schedule = new PSSchedule();
                schedule.RecurrenceInterval = recurrenceInterval;
            }

            NewJobScheduleParameters parameters = new NewJobScheduleParameters(context, jobScheduleId)
            {
                JobSpecification = jobSpecification,
                Schedule = schedule
            };

            client.CreateJobSchedule(parameters);
        }

        /// <summary>
        /// Creates a test job for use in Scenario tests.
        /// </summary>
        public static void CreateTestJob(BatchTestRunner runner, BatchAccountContext context, string jobId, string poolId = SharedPool)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            PSPoolInformation poolInfo = new PSPoolInformation();
            poolInfo.PoolId = poolId;

            NewJobParameters parameters = new NewJobParameters(context, jobId)
            {
                PoolInformation = poolInfo
            };

            client.CreateJob(parameters);
        }

        /// <summary>
        /// Waits for a recent job on a job schedule and returns its id. If a previous job is specified, this method waits until a new job is created.
        /// </summary>
        public static string WaitForRecentJob(BatchTestRunner runner, BatchAccountContext context, string jobScheduleId, string previousJob = null)
        {
            DateTime timeout = DateTime.Now.Add(GetTimeout(TimeSpan.FromMinutes(2)));
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListJobScheduleOptions options = new ListJobScheduleOptions(context)
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
        public static void CreateTestTask(BatchTestRunner runner, BatchAccountContext context, string jobId, string taskId, string cmdLine = "cmd /c dir /s", int numInstances = 0)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            PSMultiInstanceSettings multiInstanceSettings = null;
            if (numInstances > 1)
            {
                multiInstanceSettings = new PSMultiInstanceSettings("/bin/bash -c 'echo coordinating'", numInstances);
            }

            NewTaskParameters parameters = new NewTaskParameters(context, jobId, null, taskId)
            {
                CommandLine = cmdLine,
                MultiInstanceSettings = multiInstanceSettings,
                UserIdentity = new PSUserIdentity(new PSAutoUserSpecification(AutoUserScope.Task, numInstances <= 1 ? ElevationLevel.Admin : ElevationLevel.NonAdmin))
            };

            client.CreateTask(parameters);
        }

        /// <summary>
        /// Waits for the specified task to complete
        /// </summary>
        public static void WaitForTaskCompletion(BatchTestRunner runner, BatchAccountContext context, string jobId, string taskId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListTaskOptions options = new ListTaskOptions(context, jobId, null)
            {
                TaskId = taskId
            };
            IEnumerable<PSCloudTask> tasks = client.ListTasks(options);

            // Save time by not waiting during playback scenarios
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TaskStateMonitor monitor = context.BatchOMClient.Utilities.CreateTaskStateMonitor();
                monitor.WaitAll(tasks.Select(t => t.omObject), TaskState.Completed, TimeSpan.FromMinutes(10), null);
            }
        }

        /// <summary>
        /// Waits for the job to complete
        /// </summary>
        public static PSCloudJob WaitForJobCompletion(BatchTestRunner runner, BatchAccountContext context, string jobId, string taskId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            PSCloudJob job = client.ListJobs(new ListJobOptions(context)).First(cloudJob => cloudJob.Id == jobId);

            DateTime timeout = DateTime.Now.AddMinutes(10);

            while (job.State != JobState.Completed && DateTime.Now < timeout)
            {
                job = client.ListJobs(new ListJobOptions(context)).First(cloudJob => cloudJob.Id == jobId);

                TestMockSupport.Delay(20000);
            }
            
            return job;
        }

        /// <summary>
        /// Gets the id of the compute node that the specified task completed on. Returns null if the task isn't complete.
        /// </summary>
        public static string GetTaskComputeNodeId(BatchTestRunner runner, BatchAccountContext context, string jobId, string taskId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListTaskOptions options = new ListTaskOptions(context, jobId, null)
            {
                TaskId = taskId
            };
            PSCloudTask task = client.ListTasks(options).First();

            return task.ComputeNodeInformation == null ? null : task.ComputeNodeInformation.ComputeNodeId;
        }

        /// <summary>
        /// Deletes a job schedule used in a Scenario test.
        /// </summary>
        public static void DeleteJobSchedule(BatchTestRunner runner, BatchAccountContext context, string jobScheduleId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            client.DeleteJobSchedule(context, jobScheduleId);
        }

        /// <summary>
        /// Deletes a job used in a Scenario test.
        /// </summary>
        public static void DeleteJob(BatchTestRunner runner, BatchAccountContext context, string jobId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            client.DeleteJob(context, jobId);
        }

        /// <summary>
        /// Terminates a job
        /// </summary>
        public static void TerminateJob(BatchTestRunner runner, BatchAccountContext context, string jobId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            TerminateJobParameters parameters = new TerminateJobParameters(context, jobId, null);

            client.TerminateJob(parameters);
        }

        /// <summary>
        /// Gets the id of a compute node in the specified pool
        /// </summary>
        public static string GetComputeNodeId(BatchTestRunner runner, BatchAccountContext context, string poolId, int index = 0)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListComputeNodeOptions options = new ListComputeNodeOptions(context, poolId, null);
            List<PSComputeNode> computeNodes = client.ListComputeNodes(options).ToList();
            return computeNodes[index].Id;
        }

        /// <summary>
        /// Waits for a compute node to get to the idle state
        /// </summary>
        public static void WaitForIdleComputeNode(BatchTestRunner runner, BatchAccountContext context, string poolId, string computeNodeId)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ListComputeNodeOptions options = new ListComputeNodeOptions(context, poolId, null)
            {
                ComputeNodeId = computeNodeId,
                Select = "id,state"
            };

            DateTime timeout = DateTime.Now.Add(GetTimeout(TimeSpan.FromMinutes(10)));
            PSComputeNode computeNode = client.ListComputeNodes(options).First();
            while (computeNode.State != ComputeNodeState.Idle)
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
        /// Creates a compute node user for use in Scenario tests.
        /// </summary>
        public static void CreateComputeNodeUser(BatchTestRunner runner, BatchAccountContext context, string poolId, string computeNodeId, string computeNodeUserName)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            NewComputeNodeUserParameters parameters = new NewComputeNodeUserParameters(context, poolId, computeNodeId, null)
            {
                ComputeNodeUserName = computeNodeUserName,
                Password = "Password1234!",
            };

            client.CreateComputeNodeUser(parameters);
        }

        /// <summary>
        /// Deletes a compute node user for use in Scenario tests.
        /// </summary>
        public static void DeleteComputeNodeUser(BatchTestRunner runner, BatchAccountContext context, string poolId, string computeNodeId, string computeNodeUserName)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            ComputeNodeUserOperationParameters parameters = new ComputeNodeUserOperationParameters(context, poolId, computeNodeId, computeNodeUserName);

            client.DeleteComputeNodeUser(parameters);
        }

        /// <summary>
        /// Uploads an application package to Storage
        /// </summary>
        public static ApplicationPackage CreateApplicationPackage(BatchTestRunner runner, BatchAccountContext context, string applicationName, string version, string filePath)
        {
            ApplicationPackage applicationPackage = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                applicationPackage = runner.BatchManagementClient.ApplicationPackage.Create(
                    context.ResourceGroupName,
                    context.AccountName,
                    applicationName,
                    version);

                CloudBlockBlob blob = new CloudBlockBlob(new Uri(applicationPackage.StorageUrl));
#if NETSTANDARD
                Task.Run(() => blob.UploadFromFileAsync(filePath)).Wait();
#else
                blob.UploadFromFile(filePath, FileMode.Open);
#endif
            }

            return applicationPackage;
        }

        /// <summary>
        /// Deletes an application used in a Scenario test.
        /// </summary>
        public static void DeleteApplication(BatchTestRunner runner, BatchAccountContext context, string applicationName)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            client.DeleteApplication(context.ResourceGroupName, context.AccountName, applicationName);
        }

        /// <summary>
        /// Deletes an application package used in a Scenario test.
        /// </summary>
        public static void DeleteApplicationPackage(BatchTestRunner runner, BatchAccountContext context, string applicationName, string version)
        {
            BatchClient client = new BatchClient(runner.BatchManagementClient, runner.ResourceManagementClient);

            client.DeleteApplicationPackage(context.ResourceGroupName, context.AccountName, applicationName, version);
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

        private static TimeSpan GetTimeout(TimeSpan timeout)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return TimeSpan.FromHours(3);
            }

            return timeout;
        }
    }
}

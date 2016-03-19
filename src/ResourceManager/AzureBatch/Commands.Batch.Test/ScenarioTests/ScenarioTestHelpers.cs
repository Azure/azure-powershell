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

using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
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
        //     - The SharedAccount exists under the subscription being used for recording.
        //     - The following commands were run to create a pool, and all 3 compute nodes are allocated:
        //          $context = Get-AzureRmBatchAccountKeys "<SharedAccount>"
        //          $startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
        //          $startTask.CommandLine = "cmd /c echo hello"
        //          New-AzureBatchPool -Id "testPool" -VirtualMachineSize "small" -OSFamily "4" -TargetOSVersion "*" -TargetDedicated 3 -StartTask $startTask -BatchContext $context
        internal const string SharedAccount = "pstestaccount";
        internal const string SharedPool = "testPool";
        internal const string SharedPoolStartTaskStdOut = "startup\\stdout.txt";
        internal const string SharedPoolStartTaskStdOutContent = "hello";

        // TO DO: MPI and online/offline node scheduling are only enabled in a few regions, so they need a dedicated account.  Once the features are
        // enabled everywhere, the tests for these features can just use the default shared account.
        internal const string MpiOnlineAccount = "batchtest";

        // MPI requires a special pool configuration. When recording, the Storage environment variables need to be
        // set so we can upload the MPI installer for use as a start task resource file.
        internal const string MpiPoolId = "mpiPool";
        internal const string MpiSetupFileContainer = "mpi";
        internal const string MpiSetupFileName = "MSMpiSetup.exe";
        internal const string MpiSetupFileLocalPath = "Resources\\MSMpiSetup.exe";
        internal const string StorageAccountEnvVar = "AZURE_STORAGE_ACCOUNT";
        internal const string StorageKeyEnvVar = "AZURE_STORAGE_ACCESS_KEY";

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

            ScenarioTestContext testContext = new ScenarioTestContext(context);

            return testContext;
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
        /// Adds a test certificate for use in Scenario tests. Returns the thumbprint of the cert.
        /// </summary>
        public static string AddTestCertificate(BatchController controller, BatchAccountContext context, string filePath)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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
                DateTime end = start.AddMinutes(5);

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
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.InnerExceptions)
                {
                    BatchException batchEx = inner as BatchException;
                    // When the cert doesn't exist, we get a 404 error. For all other errors, throw.
                    if (batchEx == null || !batchEx.Message.Contains("CertificateNotFound"))
                    {
                        throw;
                    }
                }
            }

            NewCertificateParameters parameters = new NewCertificateParameters(context, null, cert.RawData);

            client.AddCertificate(parameters);

            return cert.Thumbprint;
        }

        /// <summary>
        /// Deletes a certificate.
        /// </summary>
        public static void DeleteTestCertificate(BatchController controller, BatchAccountContext context, string thumbprintAlgorithm, string thumbprint)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            CertificateOperationParameters parameters = new CertificateOperationParameters(context, thumbprintAlgorithm,
                thumbprint);

            client.DeleteCertificate(parameters);
        }

        /// <summary>
        /// Deletes a certificate.
        /// </summary>
        public static void WaitForCertificateToFailDeletion(BatchController controller, BatchAccountContext context, string thumbprintAlgorithm, string thumbprint)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListCertificateOptions parameters = new ListCertificateOptions(context)
            {
                ThumbprintAlgorithm = BatchTestHelpers.TestCertificateAlgorithm,
                Thumbprint = thumbprint
            };

            PSCertificate cert = client.ListCertificates(parameters).First();

            DateTime timeout = DateTime.Now.AddMinutes(2);
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
        public static void CreateTestPool(BatchController controller, BatchAccountContext context, string poolId, int targetDedicated, 
            CertificateReference certReference = null, StartTask startTask = null)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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

            NewPoolParameters parameters = new NewPoolParameters(context, poolId)
            {
                VirtualMachineSize = "small",
                OSFamily = "4",
                TargetOSVersion = "*",
                TargetDedicated = targetDedicated,
                CertificateReferences = certReferences,
                StartTask = psStartTask,
                InterComputeNodeCommunicationEnabled = true
            };

            client.CreatePool(parameters);
        }

        /// <summary>
        /// Creates an MPI pool.
        /// </summary>
        public static void CreateMpiPoolIfNotExists(BatchController controller, BatchAccountContext context, int targetDedicated = 3)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);
            ListPoolOptions listOptions = new ListPoolOptions(context)
            {
                PoolId = MpiPoolId
            };

            try
            {
                client.ListPools(listOptions);
                return; // The call returned without throwing an exception, so the pool exists
            }
            catch (AggregateException aex)
            {
                BatchException innerException = aex.InnerException as BatchException;
                if (innerException == null || innerException.RequestInformation == null || innerException.RequestInformation.AzureError == null ||
                    innerException.RequestInformation.AzureError.Code != BatchErrorCodeStrings.PoolNotFound)
                {
                    throw;
                }
                // We got the pool not found error, so continue and create the pool
            }

            string blobUrl = UploadBlobAndGetUrl(MpiSetupFileContainer, MpiSetupFileName, MpiSetupFileLocalPath);

            StartTask startTask = new StartTask();
            startTask.CommandLine = string.Format("cmd /c set & {0} -unattend -force", MpiSetupFileName);
            startTask.ResourceFiles = new List<ResourceFile>();
            startTask.ResourceFiles.Add(new ResourceFile(blobUrl, MpiSetupFileName));
            startTask.RunElevated = true;
            startTask.WaitForSuccess = true;

            CreateTestPool(controller, context, MpiPoolId, targetDedicated, startTask: startTask);
        }


        public static void EnableAutoScale(BatchController controller, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            string formula = "$TargetDedicated=2";
            EnableAutoScaleParameters parameters = new EnableAutoScaleParameters(context, poolId, null)
            {
                AutoScaleFormula = formula
            };
            client.EnableAutoScale(parameters);
        }

        public static void DisableAutoScale(BatchController controller, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PoolOperationParameters parameters = new PoolOperationParameters(context, poolId, null);
            client.DisableAutoScale(parameters);
        }

        public static string WaitForOSVersionChange(BatchController controller, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context)
            {
                PoolId = poolId
            };

            DateTime timeout = DateTime.Now.AddMinutes(5);
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

        public static void ResizePool(BatchController controller, BatchAccountContext context, string poolId, int targetDedicated)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PoolResizeParameters parameters = new PoolResizeParameters(context, poolId, null)
            {
                TargetDedicated = targetDedicated
            };

            client.ResizePool(parameters);
        }

        public static void WaitForSteadyPoolAllocation(BatchController controller, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context)
            {
                PoolId = poolId
            };

            DateTime timeout = DateTime.Now.AddMinutes(5);
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
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context)
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
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListPoolOptions options = new ListPoolOptions(context);

            return client.ListPools(options).Count();
        }


        /// <summary>
        /// Deletes a pool used in a Scenario test.
        /// </summary>
        public static void DeletePool(BatchController controller, BatchAccountContext context, string poolId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeletePool(context, poolId);
        }

        /// <summary>
        /// Creates a test job schedule for use in Scenario tests.
        /// </summary>
        public static void CreateTestJobSchedule(BatchController controller, BatchAccountContext context, string jobScheduleId, TimeSpan? recurrenceInterval)
        {
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
        public static void CreateTestJob(BatchController controller, BatchAccountContext context, string jobId, string poolId = SharedPool)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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
        public static string WaitForRecentJob(BatchController controller, BatchAccountContext context, string jobScheduleId, string previousJob = null)
        {
            DateTime timeout = DateTime.Now.AddMinutes(2);
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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
        public static void CreateTestTask(BatchController controller, BatchAccountContext context, string jobId, string taskId, string cmdLine = "cmd /c dir /s", int numInstances = 0)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            PSMultiInstanceSettings multiInstanceSettings = null;
            if (numInstances > 1)
            {
                multiInstanceSettings = new PSMultiInstanceSettings(numInstances);
                multiInstanceSettings.CoordinationCommandLine = "cmd /c echo coordinating";
            }

            NewTaskParameters parameters = new NewTaskParameters(context, jobId, null, taskId)
            {
                CommandLine = cmdLine,
                MultiInstanceSettings = multiInstanceSettings,
                RunElevated = numInstances <= 1
            };
            
            client.CreateTask(parameters);
        }

        /// <summary>
        /// Waits for the specified task to complete
        /// </summary>
        public static void WaitForTaskCompletion(BatchController controller, BatchAccountContext context, string jobId, string taskId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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
        /// Gets the id of the compute node that the specified task completed on. Returns null if the task isn't complete.
        /// </summary>
        public static string GetTaskComputeNodeId(BatchController controller, BatchAccountContext context, string jobId, string taskId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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
        public static void DeleteJobSchedule(BatchController controller, BatchAccountContext context, string jobScheduleId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeleteJobSchedule(context, jobScheduleId);
        }

        /// <summary>
        /// Deletes a job used in a Scenario test.
        /// </summary>
        public static void DeleteJob(BatchController controller, BatchAccountContext context, string jobId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            client.DeleteJob(context, jobId);
        }

        /// <summary>
        /// Terminates a job
        /// </summary>
        public static void TerminateJob(BatchController controller, BatchAccountContext context, string jobId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            TerminateJobParameters parameters = new TerminateJobParameters(context, jobId, null);

            client.TerminateJob(parameters);
        }

        /// <summary>
        /// Gets the id of a compute node in the specified pool
        /// </summary>
        public static string GetComputeNodeId(BatchController controller, BatchAccountContext context, string poolId, int index = 0)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListComputeNodeOptions options = new ListComputeNodeOptions(context, poolId, null);
            List<PSComputeNode> computeNodes = client.ListComputeNodes(options).ToList();
            return computeNodes[index].Id;
        }

        /// <summary>
        /// Waits for a compute node to get to the idle state
        /// </summary>
        public static void WaitForIdleComputeNode(BatchController controller, BatchAccountContext context, string poolId, string computeNodeId)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ListComputeNodeOptions options = new ListComputeNodeOptions(context, poolId, null)
            {
                ComputeNodeId = computeNodeId,
                Select = "id,state"
            };

            DateTime timeout = DateTime.Now.AddMinutes(5);
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
        public static void CreateComputeNodeUser(BatchController controller, BatchAccountContext context, string poolId, string computeNodeId, string computeNodeUserName)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

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
        public static void DeleteComputeNodeUser(BatchController controller, BatchAccountContext context, string poolId, string computeNodeId, string computeNodeUserName)
        {
            BatchClient client = new BatchClient(controller.BatchManagementClient, controller.ResourceManagementClient);

            ComputeNodeUserOperationParameters parameters = new ComputeNodeUserOperationParameters(context, poolId, computeNodeId, computeNodeUserName);

            client.DeleteComputeNodeUser(parameters);
        }

        /// <summary>
        /// Uploads a blob to Storage if it doesn't exist and gets the url
        /// </summary>
        private static string UploadBlobAndGetUrl(string containerName, string blobName, string localFilePath)
        {
            string blobUrl = "https://defaultUrl.blob.core.windows.net/blobName";

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                // Create container and upload blob if they don't exist
                string storageAccountName = Environment.GetEnvironmentVariable(StorageAccountEnvVar);
                string storageKey = Environment.GetEnvironmentVariable(StorageKeyEnvVar);
                StorageCredentials creds = new StorageCredentials(storageAccountName, storageKey);
                CloudStorageAccount storageAccount = new CloudStorageAccount(creds, true);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                container.CreateIfNotExists();

                CloudBlockBlob blob = container.GetBlockBlobReference(blobName);
                if (!blob.Exists())
                {
                    blob.UploadFromFile(localFilePath, System.IO.FileMode.Open);
                }

                // Get blob url with SAS string
                SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy();
                sasPolicy.Permissions = SharedAccessBlobPermissions.Read;
                sasPolicy.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(10);
                string sasString = container.GetSharedAccessSignature(sasPolicy);

                blobUrl = string.Format("{0}/{1}{2}", container.Uri, blobName, sasString);
            }

            return blobUrl;
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

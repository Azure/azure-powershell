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
using System.IO;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class FileTests
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;
        private const string poolId = ScenarioTestHelpers.SharedPool;
        private const string startTaskStdOutName = ScenarioTestHelpers.SharedPoolStartTaskStdOut;
        private const string startTaskStdOutContent = ScenarioTestHelpers.SharedPoolStartTaskStdOutContent;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNodeFileByTaskByName()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "testGetNodeFileByTaskJob";
            string taskId = "testTask";
            string nodeFileName = "stdout.txt";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetNodeFileByTaskByName '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskId, nodeFileName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFilesByTaskByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listNodeFileByTaskFilterJob";
            string taskId = "testTask";
            string nodeFilePrefix = "std";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFilesByTaskByFilter '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, jobId, taskId, nodeFilePrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFilesByTaskWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileByTaskMaxJob";
            string taskId = "testTask";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFilesByTaskWithMaxCount '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskId, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllNodeFilesByTask()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listNodeFilesByTaskJob";
            string taskId = "testTask";
            int count = 4; // ProcessEnv, stdout, stderr, wd
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllNodeFilesByTask '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskId, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFilesByTaskRecursive()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listNodeFileByTaskRecursiveJob";
            string taskId = "testTask";
            string newFile = "testFile.txt";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFilesByTaskRecursive '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskId, newFile) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, string.Format("cmd /c echo \"test file\" > {0}", newFile));
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFileByTaskPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileByTaskPipe";
            string taskId = "testTask";
            int count = 4; // ProcessEnv, stdout, stderr, wd
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFileByTaskPipeline '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskId, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNodeFileContentByTaskByName()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileContentByTaskJob";
            string taskId = "testTask";
            string fileName = "testFile.txt";
            string nodeFileName = string.Format("wd\\{0}", fileName);
            string fileContents = "test file contents";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetNodeFileContentByTaskByName '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, jobId, taskId, nodeFileName, fileContents) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, string.Format("cmd /c echo {0} > {1}", fileContents, fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNodeFileContentByTaskPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileContentByTaskPipe";
            string taskId = "testTask";
            string fileName = "testFile.txt";
            string nodeFileName = string.Format("wd\\{0}", fileName);
            string fileContents = "test file contents";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetNodeFileContentByTaskPipeline '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, jobId, taskId, nodeFileName, fileContents) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, string.Format("cmd /c echo {0} > {1}", fileContents, fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNodeFileByComputeNodeByName()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string nodeFileName = "startup\\stdout.txt";
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetNodeFileByComputeNodeByName '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, nodeFileName) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFilesByComputeNodeByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string nodeFilePrefix = "s";
            int matches = 2;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFilesByComputeNodeByFilter '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolId, computeNodeId, nodeFilePrefix, matches) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFilesByComputeNodeWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            int maxCount = 1;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFilesByComputeNodeWithMaxCount '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, maxCount) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllNodeFilesByComputeNode()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            int count = 3; // shared, startup, workitems
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListAllNodeFilesByComputeNode '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, count) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFilesByComputeNodeRecursive()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string startupFolder = "startup";
            int recursiveCount = 5; // dir itself, ProcessEnv, stdout, stderr, wd
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFilesByComputeNodeRecursive '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolId, computeNodeId, startupFolder, recursiveCount) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListNodeFileByComputeNodePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            int count = 3; // shared, startup, workitems
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFileByComputeNodePipeline '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, count) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNodeFileContentByComputeNodeByName()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetNodeFileContentByComputeNodeByName '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolId, computeNodeId, startTaskStdOutName, startTaskStdOutContent) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNodeFileContentByComputeNodeByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetNodeFileContentByComputeNodePipeline '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolId, computeNodeId, startTaskStdOutName, startTaskStdOutContent) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRemoteDesktopProtocolFileById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetRDPFileById '{0}' '{1}' '{2}'", accountName, poolId, computeNodeId) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRemoteDesktopProtocolFilePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetRDPFilePipeline '{0}' '{1}' '{2}'", accountName, poolId, computeNodeId) }; },
            () =>
            {
                context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }
    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchNodeFile_ST", DefaultParameterSetName = ComputeNodeAndIdParameterSet)]
    public class GetBatchNodeFileScenarioTestCommand : GetBatchNodeFileCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureBatchNodeFileContent_ST")]
    public class GetBatchNodeFileContentScenarioTestCommand : GetBatchNodeFileContentCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureBatchRemoteDesktopProtocolFile_ST")]
    public class GetBatchRemoteDesktopProtocolFileScenarioTestCommand : GetBatchRemoteDesktopProtocolFileCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

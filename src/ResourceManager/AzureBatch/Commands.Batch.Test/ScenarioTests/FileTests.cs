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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class FileTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;
        private const string startTaskStdOutName = ScenarioTestHelpers.SharedPoolStartTaskStdOut;
        private const string startTaskStdOutContent = ScenarioTestHelpers.SharedPoolStartTaskStdOutContent;

        public FileTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        public void TestGetNodeFileByTaskByName()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "testGetNodeFileByTaskJob";
            string taskId = "testTask";
            string nodeFileName = "stdout.txt";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetNodeFileByTaskByName '{0}' '{1}' '{2}'", jobId, taskId, nodeFileName) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
        public void TestListNodeFilesByTaskByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listNodeFileByTaskFilterJob";
            string taskId = "testTask";
            string nodeFilePrefix = "std";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFilesByTaskByFilter '{0}' '{1}' '{2}' '{3}'", jobId, taskId, nodeFilePrefix, matches) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
        public void TestListNodeFilesByTaskWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileByTaskMaxJob";
            string taskId = "testTask";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFilesByTaskWithMaxCount '{0}' '{1}' '{2}'", jobId, taskId, maxCount) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
        public void TestListAllNodeFilesByTask()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listNodeFilesByTaskJob";
            string taskId = "testTask";
            int count = 4; // ProcessEnv, stdout, stderr, wd
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllNodeFilesByTask '{0}' '{1}' '{2}'", jobId, taskId, count) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
        public void TestListNodeFilesByTaskRecursive()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listNodeFileByTaskRecursiveJob";
            string taskId = "testTask";
            string newFile = "testFile.txt";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFilesByTaskRecursive '{0}' '{1}' '{2}'", jobId, taskId, newFile) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
        public void TestListNodeFileByTaskPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileByTaskPipe";
            string taskId = "testTask";
            int count = 4; // ProcessEnv, stdout, stderr, wd
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListNodeFileByTaskPipeline '{0}' '{1}' '{2}'", jobId, taskId, count) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
                () => { return new string[] { string.Format("Test-GetNodeFileContentByTaskByName '{0}' '{1}' '{2}' '{3}'", jobId, taskId, nodeFileName, fileContents) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
                () => { return new string[] { string.Format("Test-GetNodeFileContentByTaskPipeline '{0}' '{1}' '{2}' '{3}'", jobId, taskId, nodeFileName, fileContents) }; },
                () =>
                {
                    context = new ScenarioTestContext();
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
        public void TestGetNodeFileByComputeNodeByName()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string nodeFileName = "startup\\stdout.txt";
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetNodeFileByComputeNodeByName '{0}' '{1}' '{2}'", poolId, computeNodeId, nodeFileName) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListNodeFilesByComputeNodeByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string nodeFilePrefix = "s";
            int matches = 2;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFilesByComputeNodeByFilter '{0}' '{1}' '{2}' '{3}'", poolId, computeNodeId, nodeFilePrefix, matches) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListNodeFilesByComputeNodeWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            int maxCount = 1;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFilesByComputeNodeWithMaxCount '{0}' '{1}' '{2}'", poolId, computeNodeId, maxCount) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListAllNodeFilesByComputeNode()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            int count = 4; // shared, startup, workitems, applications
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListAllNodeFilesByComputeNode '{0}' '{1}' '{2}'", poolId, computeNodeId, count) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListNodeFilesByComputeNodeRecursive()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string startupFolder = "startup";
            int recursiveCount = 5; // dir itself, ProcessEnv, stdout, stderr, wd
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFilesByComputeNodeRecursive '{0}' '{1}' '{2}' '{3}'", poolId, computeNodeId, startupFolder, recursiveCount) }; },
            () =>
            {
                context = new ScenarioTestContext();
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
            int count = 4; // shared, startup, workitems, applications
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-ListNodeFileByComputeNodePipeline '{0}' '{1}' '{2}'", poolId, computeNodeId, count) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestGetNodeFileContentByComputeNodeByName()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetNodeFileContentByComputeNodeByName '{0}' '{1}' '{2}' '{3}'", poolId, computeNodeId, startTaskStdOutName, startTaskStdOutContent) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestGetNodeFileContentByComputeNodeByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetNodeFileContentByComputeNodePipeline '{0}' '{1}' '{2}' '{3}'", poolId, computeNodeId, startTaskStdOutName, startTaskStdOutContent) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestGetRemoteDesktopProtocolFileById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetRDPFileById '{0}' '{1}'", poolId, computeNodeId) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestGetRemoteDesktopProtocolFilePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
            () => { return new string[] { string.Format("Test-GetRDPFilePipeline '{0}' '{1}'", poolId, computeNodeId) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            TestUtilities.GetCallingClass(),
            TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteNodeFileByTaskByName()
        {
            TestDeleteNodeFileByTask(false, TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDeleteNodeFileByTaskByPipeline()
        {
            TestDeleteNodeFileByTask(true, TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDeleteNodeFileByComputeNodeByName()
        {
            TestDeleteNodeFileByComputeNode(false, TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDeleteNodeFileByComputeNodeByPipeline()
        {
            TestDeleteNodeFileByComputeNode(true, TestUtilities.GetCurrentMethodName());
        }

        private void TestDeleteNodeFileByTask(bool usePipeline, string testMethodName)
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = string.Format("deleteNodeByFileTaskBy{0}", usePipeline ? "Pipeline" : "Name");
            string taskId = "task1";
            string fileName = "testFile.txt";
            string filePath = string.Format("wd\\{0}", fileName);
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteNodeFileByTask '{0}' '{1}' '{2}' '{3}'", jobId, taskId, filePath, usePipeline ? "1" : "0") }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, string.Format("cmd /c echo \"test\" > {0}", fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                testMethodName);
        }

        private void TestDeleteNodeFileByComputeNode(bool usePipeline, string testMethodName)
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = string.Format("deleteNodeByFileComputeNodeBy{0}", usePipeline ? "Pipeline" : "Name");
            string taskId = "task1";
            string computeNodeId = null;
            string fileName = "testFile.txt";
            string filePath = string.Format("workitems\\{0}\\job-1\\{1}\\wd\\{2}", jobId, taskId, fileName);
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteNodeFileByComputeNode '{0}' '{1}' '{2}' '{3}'", poolId, computeNodeId, filePath, usePipeline ? "1" : "0") }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, string.Format("cmd /c echo \"test\" > {0}", fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                    computeNodeId = ScenarioTestHelpers.GetTaskComputeNodeId(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                testMethodName);
        }
    }
}

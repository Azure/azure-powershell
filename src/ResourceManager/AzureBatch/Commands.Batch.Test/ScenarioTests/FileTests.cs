﻿// ----------------------------------------------------------------------------------
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

using System.Reflection;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class FileTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;
        private const string startTaskStdOutName = ScenarioTestHelpers.SharedPoolStartTaskStdOut;
        private const string startTaskStdOutContent = ScenarioTestHelpers.SharedPoolStartTaskStdOutContent;

        public XunitTracingInterceptor _logger;

        public FileTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.DesktopOnly)]
        public void TestGetNodeFileContentByTask()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "nodeFileContentByTask";
            string taskId = "testTask";
            string fileName = "testFile.txt";
            string nodeFilePath = string.Format("wd\\{0}", fileName);
            string fileContents = "test file contents";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-GetNodeFileContentByTask '{0}' '{1}' '{2}' '{3}'", jobId, taskId, nodeFilePath, fileContents) }; },
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
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.DesktopOnly)]
        public void TestGetNodeFileContentByComputeNode()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                _logger,
            () => { return new string[] { string.Format("Test-GetNodeFileContentByComputeNode '{0}' '{1}' '{2}' '{3}'", poolId, computeNodeId, startTaskStdOutName, startTaskStdOutContent) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRemoteDesktopProtocolFile()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                _logger,
            () => { return new string[] { string.Format("Test-GetRDPFile '{0}' '{1}'", poolId, computeNodeId) }; },
            () =>
            {
                context = new ScenarioTestContext();
                computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
            },
            null,
            MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
            MethodBase.GetCurrentMethod().Name);
        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteNodeFileByTask()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = "deletetaskFile";
            string taskId = "task1";
            string fileName = "testFile.txt";
            string filePath = string.Format("wd\\{0}", fileName);
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-DeleteNodeFileByTask '{0}' '{1}' '{2}'", jobId, taskId, filePath) }; },
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
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteNodeFileByComputeNode()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = "deleteNodeFile";
            string taskId = "task1";
            string computeNodeId = null;
            string fileName = "testFile.txt";
            string filePath = string.Format("workitems\\{0}\\job-1\\{1}\\wd\\{2}", jobId, taskId, fileName);
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-DeleteNodeFileByComputeNode '{0}' '{1}' '{2}'", poolId, computeNodeId, filePath) }; },
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
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }
    }
}

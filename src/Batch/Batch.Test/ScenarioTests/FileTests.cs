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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class FileTests : BatchTestRunner
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;
        private const string startTaskStdOutName = ScenarioTestHelpers.SharedPoolStartTaskStdOut;
        private const string startTaskStdOutContent = ScenarioTestHelpers.SharedPoolStartTaskStdOutContent;

        public FileTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.DesktopOnly)]
        public void TestGetNodeFileContentByTask()
        {
            string jobId = "nodeFileContentByTask";
            string taskId = "testTask";
            string fileName = "testFile.txt";
            string nodeFilePath = string.Format("wd\\{0}", fileName);
            string fileContents = "test file contents";
            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(this, context, jobId, taskId, string.Format("cmd /c echo {0} > {1}", fileContents, fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(this, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-GetNodeFileContentByTask '{jobId}' '{taskId}' '{nodeFilePath}' '{fileContents}'"
            );
        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.DesktopOnly)]
        public void TestGetNodeFileContentByComputeNode()
        {
            BatchAccountContext context = null;
            string computeNodeId = null;
            TestRunner.RunTestScript(
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(this, context, poolId);
                },
            $"Test-GetNodeFileContentByComputeNode '{poolId}' '{computeNodeId}' '{startTaskStdOutName}' '{startTaskStdOutContent}'"
            );
        }

       

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteNodeFileByTask()
        {
            BatchAccountContext context = null;
            string jobId = "deletetaskFile";
            string taskId = "task1";
            string fileName = "testFile.txt";
            string filePath = string.Format("wd\\{0}", fileName);
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(this, context, jobId, taskId, string.Format("cmd /c echo \"test\" > {0}", fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(this, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-DeleteNodeFileByTask '{jobId}' '{taskId}' '{filePath}'"
            );
        }

        [Fact(Skip = "Successful re-recording, but fails in playback. See issue https://github.com/Azure/azure-powershell/issues/7512")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteNodeFileByComputeNode()
        {
            BatchAccountContext context = null;
            string jobId = "deleteNodeFile";
            string taskId = "task1";
            string computeNodeId = null;
            string fileName = "testFile.txt";
            string filePath = string.Format("workitems\\{0}\\job-1\\{1}\\wd\\{2}", jobId, taskId, fileName);
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(this, context, jobId, taskId, string.Format("cmd /c echo \"test\" > {0}", fileName));
                    ScenarioTestHelpers.WaitForTaskCompletion(this, context, jobId, taskId);
                    computeNodeId = ScenarioTestHelpers.GetTaskComputeNodeId(this, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-DeleteNodeFileByComputeNode '{poolId}' '{computeNodeId}' '{filePath}'"
            );
        }
    }
}

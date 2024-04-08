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

using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class TaskTests : BatchTestRunner
    {
        public TaskTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTaskCRUD()
        {
            string jobId = "taskCrudJob";
            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-TaskCRUD '{jobId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateTaskCollection()
        {
            string jobId = "createTaskCollectionJob";
            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-CreateTaskCollection '{jobId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTerminateTask()
        {
            BatchAccountContext context = null;
            string jobId = "testTerminateTaskJob";
            string taskId1 = "testTask1";
            string taskId2 = "testTask2";
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId);
                    // Make the tasks long running so they can be terminated before they finish execution
                    ScenarioTestHelpers.CreateTestTask(this, context, jobId, taskId1, "ping -t localhost -w 60");
                    ScenarioTestHelpers.CreateTestTask(this, context, jobId, taskId2, "ping -t localhost -w 60");
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-TerminateTask '{jobId}' '{taskId1}' '{taskId2}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllSubtasks()
        {
            string jobId = "listSubtaskJob";
            string taskId = "testTask";
            int numInstances = 3;
            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    //ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, "mpiPool", targetDedicated: 2, targetLowPriority: 0);

                    ScenarioTestHelpers.CreateMpiPoolIfNotExists(this, context);
                    ScenarioTestHelpers.CreateTestJob(this, context, jobId, ScenarioTestHelpers.MpiPoolId);
                    ScenarioTestHelpers.CreateTestTask(this, context, jobId, taskId, "/bin/bash -c 'echo task'", numInstances);
                    ScenarioTestHelpers.WaitForTaskCompletion(this, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"Test-ListAllSubtasks '{jobId}' '{taskId}' '{numInstances}'"
            );
        }
    }
}

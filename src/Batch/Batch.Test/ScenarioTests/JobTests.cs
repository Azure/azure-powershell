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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class JobTests : BatchTestRunner
    {
        public JobTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobCRUD()
        {
            TestRunner.RunTestScript("Test-JobCRUD");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEnableTerminateJob()
        {
            string jobId = "testDisableEnableTerminateJob";

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
                $"Test-DisableEnableTerminateJob '{jobId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IfJobSetsAutoFailure_ItCompletesWhenAnyTaskFails()
        {
            BatchAccountContext context = null;
            string poolId = "testPool";
            string jobId = "testJobCompletesWhenTaskFails";
            string taskId = "taskId-1";
            PSCloudJob completedJob = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId);

                },
                () =>
                {
                    completedJob = ScenarioTestHelpers.WaitForJobCompletion(this, context, jobId, taskId);
                    AssertJobIsCompleteDueToTaskFailure(completedJob);
                    ScenarioTestHelpers.DeleteJob(this, context, jobId);
                },
                $"IfJobSetsAutoFailure-ItCompletesWhenAnyTaskFails '{poolId}' '{jobId}' '{taskId}'"
            );
        }

        private void AssertJobIsCompleteDueToTaskFailure(PSCloudJob job)
        {
            Assert.Equal(Azure.Batch.Common.JobState.Completed, job.State);
            Assert.Equal("TaskFailed", job.ExecutionInformation.TerminateReason);
        }
    }
}

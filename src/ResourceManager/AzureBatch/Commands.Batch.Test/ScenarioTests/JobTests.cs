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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Reflection;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class JobTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public JobTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobCRUD()
        {
            BatchController.NewInstance.RunPsTest(_logger, "Test-JobCRUD");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEnableTerminateJob()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "testDisableEnableTerminateJob";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                _logger, 
                () => { return new string[] { string.Format("Test-DisableEnableTerminateJob '{0}'", jobId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IfJobSetsAutoFailure_ItCompletesWhenAnyTaskFails()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = "testJobCompletesWhenTaskFails";
            string taskId = "taskId-1";
            PSCloudJob completedJob = null;
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("IfJobSetsAutoFailure-ItCompletesWhenAnyTaskFails '{0}' '{1}'", jobId, taskId) }; },
                null,
                () =>
                {
                    context = new ScenarioTestContext();
                    completedJob = ScenarioTestHelpers.WaitForJobCompletion(controller, context, jobId, taskId);
                    AssertJobIsCompleteDueToTaskFailure(completedJob);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        private void AssertJobIsCompleteDueToTaskFailure(PSCloudJob job)
        {
            Assert.Equal(Azure.Batch.Common.JobState.Completed, job.State);
            Assert.Equal("TaskFailed", job.ExecutionInformation.TerminateReason);
        }
    }
}

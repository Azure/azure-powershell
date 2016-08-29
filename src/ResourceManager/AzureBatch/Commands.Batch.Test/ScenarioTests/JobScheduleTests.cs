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
    public class JobScheduleTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public JobScheduleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewJobSchedule()
        {
            BatchController.NewInstance.RunPsTest("Test-NewJobSchedule");
        }

        [Fact]
        public void TestGetJobScheduleById()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testId";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetJobScheduleById '{0}'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListJobSchedulesByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId1 = "testId1";
            string jobScheduleId2 = "testId2";
            string jobScheduleId3 = "thirdtestId";
            string jobSchedulePrefix = "testId";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobSchedulesByFilter '{0}' '{1}'", jobSchedulePrefix, matches) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId1, null);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId2, null);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId3, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId1);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId2);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAndListJobSchedulesWithSelect()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobScheduleId = "selectTest";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetAndListJobSchedulesWithSelect '{0}'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListJobSchedulesWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId1 = "testId1";
            string jobScheduleId2 = "testId2";
            string jobScheduleId3 = "thirdtestId";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobSchedulesWithMaxCount '{0}'", maxCount) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId1, null);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId2, null);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId3, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId1);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId2);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListAllJobSchedules()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId1 = "testId1";
            string jobScheduleId2 = "testId2";
            string jobScheduleId3 = "thirdtestId";
            int count = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllJobSchedules '{0}'", count) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId1, null);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId2, null);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId3, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId1);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId2);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestUpdateJobSchedule()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testUpdateJobSchedule";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-UpdateJobSchedule '{0}'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDeleteJobSchedule()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testDeleteJobSchedule";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteJobSchedule '{0}' '0'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteJobSchedulePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testDeleteJobSchedulePipe";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteJobSchedule '{0}' '1'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDisableAndEnableJobSchedule()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testDisableEnableJobSchedule";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DisableAndEnableJobSchedule '{0}' '1'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestTerminateJobScheduleById()
        {
            TestTerminateJobSchedule(false);
        }

        [Fact]
        public void TestTerminateJobSchedulePipeline()
        {
            TestTerminateJobSchedule(true);
        }

        private void TestTerminateJobSchedule(bool usePipeline)
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobScheduleId = "testTerminateJobSchedule" + (usePipeline ? "Pipeline" : "Id");
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-TerminateJobSchedule '{0}' '{1}'", jobScheduleId, usePipeline ? 1 : 0) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                usePipeline ? "TestTerminateJobSchedulePipeline" : "TestTerminateJobScheduleById");
        }
    }
}

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
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class JobScheduleTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewJobSchedule()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-NewJobSchedule '{0}'", accountName));
        }

        [Fact]
        public void TestGetJobScheduleById()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testId";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetJobScheduleById '{0}' '{1}'", accountName, jobScheduleId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-ListJobSchedulesByFilter '{0}' '{1}' '{2}'", accountName, jobSchedulePrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-GetAndListJobSchedulesWithSelect '{0}' '{1}'", accountName, jobScheduleId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-ListJobSchedulesWithMaxCount '{0}' '{1}'", accountName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-ListAllJobSchedules '{0}' '{1}'", accountName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-UpdateJobSchedule '{0}' '{1}'", accountName, jobScheduleId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-DeleteJobSchedule '{0}' '{1}' '0'", accountName, jobScheduleId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-DeleteJobSchedule '{0}' '{1}' '1'", accountName, jobScheduleId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-DisableAndEnableJobSchedule '{0}' '{1}' '1'", accountName, jobScheduleId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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
                () => { return new string[] { string.Format("Test-TerminateJobSchedule '{0}' '{1}' '{2}'", accountName, jobScheduleId, usePipeline ? 1 : 0) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
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

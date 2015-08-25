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
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class JobTests
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewJob()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-NewJob '{0}'", accountName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobById()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "testJob";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetJobById '{0}' '{1}'", accountName, jobId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
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
        public void TestListJobsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId1 = "testId1";
            string jobId2 = "testId2";
            string jobId3 = "thirdtestId";
            string state = "active";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobsByFilter '{0}' '{1}' '{2}'", accountName, state.ToString(), matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId1);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId2);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId3);
                    ScenarioTestHelpers.TerminateJob(context, jobId1);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId1);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId2);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListJobsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId1 = "testId1";
            string jobId2 = "testId2";
            string jobId3 = "thirdtestId";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobsWithMaxCount '{0}' '{1}'", accountName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId1);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId2);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId1);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId2);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllJobs()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId1 = "testId1";
            string jobId2 = "testId2";
            string jobId3 = "thirdtestId";
            int count = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllJobs '{0}' '{1}'", accountName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId1);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId2);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId1);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId2);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListJobsUnderSchedule()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testJobSchedule";
            string jobId = null;
            string jobId2 = null;
            string runOnceJob = "runOnceId";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobsUnderSchedule '{0}' '{1}' '{2}' '{3}'", accountName, jobScheduleId, jobId, 2) }; },
                () =>
                {
                    TimeSpan recurrence = TimeSpan.FromMinutes(1);
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, runOnceJob);
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, recurrence);
                    jobId = ScenarioTestHelpers.WaitForRecentJob(controller, context, jobScheduleId);
                    ScenarioTestHelpers.TerminateJob(context, jobId);
                    jobId2 = ScenarioTestHelpers.WaitForRecentJob(controller, context, jobScheduleId, jobId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, runOnceJob);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId2);
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteJob()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "deleteJobTest";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteJob '{0}' '{1}' '0'", accountName, jobId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteJobPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "testDeleteJobPipe";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteJob '{0}' '{1}' '1'", accountName, jobId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableAndEnableJob()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "testDisableEnableJob";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DisableAndEnableJob '{0}' '{1}' '1'", accountName, jobId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.New, "AzureBatchJob_ST")]
    public class NewBatchJobScenarioTestCommand : NewBatchJobCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureBatchJob_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchJobScenarioTestCommand : GetBatchJobCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Remove, "AzureBatchJob_ST")]
    public class RemoveBatchJobScenarioTestCommand : RemoveBatchJobCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsLifecycle.Enable, "AzureBatchJob_ST")]
    public class EnableBatchJobScenarioTestCommand : EnableBatchJobCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsLifecycle.Disable, "AzureBatchJob_ST")]
    public class DisableBatchJobScenarioTestCommand : DisableBatchJobCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

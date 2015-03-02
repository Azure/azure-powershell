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
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobRequiredParameters()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-get-job-params";
            string accountName = "testgetjobparams";
            string location = "eastus";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetJobRequiredParameters '{0}'", accountName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                },
                () =>
                {
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetJobByName()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-get-job";
            string accountName = "testgetjob";
            string location = "eastus";
            string workItemName = "testName";
            string jobName = null;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetJobByName '{0}' '{1}' '{2}'", accountName, workItemName, jobName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListJobsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-job-filter";
            string accountName = "testlistjobfilter";
            string location = "eastus";
            string workItemName = "testWorkItem";
            string state = "active";
            int matches = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobsByFilter '{0}' '{1}' '{2}' '{3}'", accountName, workItemName, state, matches) }; },
                () =>
                {
                    TimeSpan recurrence = TimeSpan.FromMinutes(1);
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName, recurrence);
                    string jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.TerminateJob(context, workItemName, jobName);
                    ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName, jobName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListJobsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-job-maxcount";
            string accountName = "testlistjobmaxcount";
            string location = "eastus";
            string workItemName = "testWorkItem";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobsWithMaxCount '{0}' '{1}' '{2}'", accountName, workItemName, maxCount) }; },
                () =>
                {
                    TimeSpan recurrence = TimeSpan.FromMinutes(1);
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName, recurrence);
                    string jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.TerminateJob(context, workItemName, jobName);
                    ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName, jobName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllJobs()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-job";
            string accountName = "testlistjob";
            string location = "eastus";
            string workItemName = "testWorkItem";
            int count = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllJobs '{0}' '{1}' '{2}'", accountName, workItemName, count) }; },
                () =>
                {
                    TimeSpan recurrence = TimeSpan.FromMinutes(1);
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName, recurrence);
                    string jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.TerminateJob(context, workItemName, jobName);
                    ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName, jobName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListJobPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-job-pipe";
            string accountName = "testlistjobpipe";
            string location = "eastus";
            string workItemName = "testWorkItem";
            string jobName = null;

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListJobPipeline '{0}' '{1}' '{2}'", accountName, workItemName, jobName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchJob_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchJobScenarioTestCommand : GetBatchJobCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

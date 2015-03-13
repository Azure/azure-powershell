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
    public class FileTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetTaskByName()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-get-task";
            string accountName = "testgettaskbyname";
            string location = "eastus";
            string workItemName = "testName";
            string jobName = null;
            string taskName = "testTask";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetTaskByName '{0}' '{1}' '{2}' '{3}'", accountName, workItemName, jobName, taskName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName);
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
        public void TestListTasksByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-task-filter";
            string accountName = "testlisttaskfilter";
            string location = "eastus";
            string workItemName = "testWorkItem";
            string jobName = null;
            string taskName1 = "testTask1";
            string taskName2 = "testTask2";
            string taskName3 = "thirdTestTask";
            string taskPrefix = "testTask";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTasksByFilter '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, workItemName, jobName, taskPrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName1);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName2);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName3);
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
        public void TestListTasksWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-task-maxcount";
            string accountName = "testlisttaskmaxcount";
            string location = "eastus";
            string workItemName = "testWorkItem";
            string jobName = null;
            string taskName1 = "testTask1";
            string taskName2 = "testTask2";
            string taskName3 = "testTask3";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTasksWithMaxCount '{0}' '{1}' '{2}' '{3}'", accountName, workItemName, jobName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName1);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName2);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName3);
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
        public void TestListAllTasks()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-task";
            string accountName = "testlisttask";
            string location = "eastus";
            string workItemName = "testWorkItem";
            string jobName = null;
            string taskName1 = "testTask1";
            string taskName2 = "testTask2";
            string taskName3 = "testTask3";
            int count = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllTasks '{0}' '{1}' '{2}' '{3}'", accountName, workItemName, jobName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName1);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName2);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName3);
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
        public void TestListTaskPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-task-pipe";
            string accountName = "testlisttaskpipe";
            string location = "eastus";
            string workItemName = "testWorkItem";
            string jobName = null;
            string taskName = "testTask";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTaskPipeline '{0}' '{1}' '{2}' '{3}'", accountName, workItemName, jobName, taskName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(context, workItemName, jobName, taskName);
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
    [Cmdlet(VerbsCommon.Get, "AzureBatchTaskFile_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchTaskFileScenarioTestCommand : GetBatchTaskFileCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

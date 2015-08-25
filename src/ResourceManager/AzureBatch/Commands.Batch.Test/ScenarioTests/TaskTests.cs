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
    public class TaskTests
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateTask()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "createTaskJob";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-CreateTask '{0}' '{1}'", accountName, jobId) }; },
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
        public void TestGetTaskById()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "getTaskJob";
            string taskId = "testTask";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetTaskById '{0}' '{1}' '{2}'", accountName, jobId, taskId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
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
        public void TestListTasksByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "filterTaskJob";
            string taskId1 = "testTask1";
            string taskId2 = "testTask2";
            string taskId3 = "thirdTestTask";
            string taskPrefix = "testTask";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTasksByFilter '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskPrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId1);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId2);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId3);
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
        public void TestListTasksWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "maxCountTaskJob";
            string taskId1 = "testTask1";
            string taskId2 = "testTask2";
            string taskId3 = "testTask3";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTasksWithMaxCount '{0}' '{1}' '{2}'", accountName, jobId, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId1);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId2);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId3);
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
        public void TestListAllTasks()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listTaskJob";
            string taskId1 = "testTask1";
            string taskId2 = "testTask2";
            string taskId3 = "testTask3";
            int count = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllTasks '{0}' '{1}' '{2}'", accountName, jobId, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId1);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId2);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId3);
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
        public void TestListTaskPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listTaskPipeJob";
            string taskId = "testTask";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTaskPipeline '{0}' '{1}' '{2}'", accountName, jobId, taskId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
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
        public void TestDeleteTask()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "deleteTaskJob";
            string taskId = "testTask";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteTask '{0}' '{1}' '{2}' '0'", accountName, jobId, taskId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
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
        public void TestDeleteTaskPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "deleteTaskPipeJob";
            string taskId = "testTask";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteTask '{0}' '{1}' '{2}' '1'", accountName, jobId, taskId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId);
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
    [Cmdlet(VerbsCommon.Get, "AzureBatchTask_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchTaskScenarioTestCommand : GetBatchTaskCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.New, "AzureBatchTask_ST")]
    public class NewBatchTaskScenarioTestCommand : NewBatchTaskCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Remove, "AzureBatchTask_ST")]
    public class RemoveBatchTaskScenarioTestCommand : RemoveBatchTaskCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

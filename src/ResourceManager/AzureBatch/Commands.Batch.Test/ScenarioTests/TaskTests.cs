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
    public class TaskTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
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
                () => { return new string[] { string.Format("Test-CreateTask '{0}' '{1}'", ScenarioTestHelpers.MpiOnlineAccount, jobId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, ScenarioTestHelpers.MpiOnlineAccount);
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
        public void TestGetAndListTasksWithSelect()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = "selectTaskTest";
            string taskId = "testTask1";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetAndListTasksWithSelect '{0}' '{1}' '{2}'", accountName, jobId, taskId) }; },
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
        public void TestUpdateTask()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "updateTaskJob";
            string taskId = "testTask";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-UpdateTask '{0}' '{1}' '{2}'", accountName, jobId, taskId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    // Make the task long running so the constraints can be updated
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, "ping -t localhost -w 60");
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

        [Fact]
        public void TestTerminateTask()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string jobId = "testTerminateTaskJob";
            string taskId1 = "testTask1";
            string taskId2 = "testTask2";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-TerminateTask '{0}' '{1}' '{2}' '{3}'", accountName, jobId, taskId1, taskId2) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                    // Make the tasks long running so they can be terminated before they finish execution
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId1, "ping -t localhost -w 60");
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId2, "ping -t localhost -w 60");
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListSubtasksWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "maxCountSubtaskJob";
            string taskId = "testTask";
            int numInstances = 3;
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListSubtasksWithMaxCount '{0}' '{1}' '{2}' '{3}'", ScenarioTestHelpers.MpiOnlineAccount, jobId, taskId, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, ScenarioTestHelpers.MpiOnlineAccount);
                    ScenarioTestHelpers.CreateMpiPoolIfNotExists(controller, context);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId, ScenarioTestHelpers.MpiPoolId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, "cmd /c hostname", numInstances);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListAllSubtasks()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "listSubtaskJob";
            string taskId = "testTask";
            int numInstances = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllSubtasks '{0}' '{1}' '{2}' '{3}'", ScenarioTestHelpers.MpiOnlineAccount, jobId, taskId, numInstances) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, ScenarioTestHelpers.MpiOnlineAccount);
                    ScenarioTestHelpers.CreateMpiPoolIfNotExists(controller, context);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId, ScenarioTestHelpers.MpiPoolId);
                    ScenarioTestHelpers.CreateTestTask(controller, context, jobId, taskId, "cmd /c hostname", numInstances);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, jobId, taskId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}

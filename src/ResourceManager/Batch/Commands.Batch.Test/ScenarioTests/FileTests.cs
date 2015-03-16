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
using Microsoft.Azure.Batch.Protocol.Entities;
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
        // NOTE: To save time on VM allocation when recording, these tests assume the following:
        //     - A Batch account named 'filetests' exists under the subscription being used for recording.
        //     - A pool called 'testPool' exists under this account and has at least 1 VM allocated to it.

        private const string accountName = "filetests";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetTaskFileByName()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testGetTaskFileWI";
            string jobName = null;
            string taskName = "testTask";
            string taskFileName = "stdout.txt";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetTaskFileByName '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, workItemName, jobName, taskName, taskFileName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, workItemName, jobName, taskName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListTaskFilesByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testListTaskFileFilterWI";
            string jobName = null;
            string taskName = "testTask";
            string taskFilePrefix = "std";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTaskFilesByFilter '{0}' '{1}' '{2}' '{3}' '{4}' '{5}'", accountName, workItemName, jobName, taskName, taskFilePrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, workItemName, jobName, taskName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListTaskFilesWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testTaskFileMaxWI";
            string jobName = null;
            string taskName = "testTask";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTaskFilesWithMaxCount '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, workItemName, jobName, taskName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, workItemName, jobName, taskName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllTaskFiles()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testListTaskFileWI";
            string jobName = null;
            string taskName = "testTask";
            int count = 4; // ProcessEnv, stdout, stderr, wd
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllTaskFiles '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, workItemName, jobName, taskName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, workItemName, jobName, taskName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListTaskFilesRecursive()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testListTFRecursiveWI";
            string jobName = null;
            string taskName = "testTask";
            string newFile = "testFile.txt";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTaskFilesRecursive '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, workItemName, jobName, taskName, newFile) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName, string.Format("cmd /c echo \"test file\" > {0}", newFile));
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, workItemName, jobName, taskName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListTaskFilePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testListTaskPipeWI";
            string jobName = null;
            string taskName = "testTask";
            int count = 4; // ProcessEnv, stdout, stderr, wd
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListTaskFilePipeline '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, workItemName, jobName, taskName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName);
                    ScenarioTestHelpers.WaitForTaskCompletion(controller, context, workItemName, jobName, taskName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
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

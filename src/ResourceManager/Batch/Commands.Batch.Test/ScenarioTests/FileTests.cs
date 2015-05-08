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
using System.IO;
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
        //     - The following commands were run to create a pool, and all 3 VMs are allocated:
        //          $context = Get-AzureBatchAccountKeys "filetests"
        //          $startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
        //          $startTask.CommandLine = "cmd /c echo hello"
        //          New-AzureBatchPool -Name "testPool" -VMSize "small" -OSFamily "4" -TargetOSVersion "*" -TargetDedicated 3 -StartTask $startTask -BatchContext $context

        private const string accountName = "filetests";
        private const string poolName = "testPool";
        private const string vmName = "tvm-1900272697_1-20150331t200107z"; // Use the following command to get a VM name: (Get-AzureBatchVM -PoolName "testPool" -BatchContext $context)[0].Name
        private const string startTaskStdOutName = "startup\\stdout.txt";
        private const string startTaskStdOutContent = "hello";

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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetTaskFileContentByName()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testGetTaskFileContentWI";
            string jobName = null;
            string taskName = "testTask";
            string fileName = "testFile.txt";
            string taskFileName = string.Format("wd\\{0}", fileName);
            string fileContents = "test file contents";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetTaskFileContentByName '{0}' '{1}' '{2}' '{3}' '{4}' '{5}'", accountName, workItemName, jobName, taskName, taskFileName, fileContents) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName, string.Format("cmd /c echo {0} > {1}", fileContents, fileName));
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
        public void TestGetTaskFileContentPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string workItemName = "testGetTFContentPipeWI";
            string jobName = null;
            string taskName = "testTask";
            string fileName = "testFile.txt";
            string taskFileName = string.Format("wd\\{0}", fileName);
            string fileContents = "test file contents";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetTaskFileContentPipeline '{0}' '{1}' '{2}' '{3}' '{4}' '{5}'", accountName, workItemName, jobName, taskName, taskFileName, fileContents) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                    jobName = ScenarioTestHelpers.WaitForRecentJob(controller, context, workItemName);
                    ScenarioTestHelpers.CreateTestTask(controller, context, workItemName, jobName, taskName, string.Format("cmd /c echo {0} > {1}", fileContents, fileName));
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
        public void TestGetVMFileByName()
        {
            BatchController controller = BatchController.NewInstance;
            string vmFileName = "startup\\stdout.txt";
            controller.RunPsTest(string.Format("Test-GetVMFileByName '{0}' '{1}' '{2}' '{3}'", accountName, poolName, vmName, vmFileName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMFilesByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string vmFilePrefix = "s";
            int matches = 2;
            controller.RunPsTest(string.Format("Test-ListVMFilesByFilter '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolName, vmName, vmFilePrefix, matches));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMFilesWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            int maxCount = 1;
            controller.RunPsTest(string.Format("Test-ListVMFilesWithMaxCount '{0}' '{1}' '{2}' '{3}'", accountName, poolName, vmName, maxCount));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllVMFiles()
        {
            BatchController controller = BatchController.NewInstance;
            int count = 3; // shared, startup, workitems
            controller.RunPsTest(string.Format("Test-ListAllVMFiles '{0}' '{1}' '{2}' '{3}'", accountName, poolName, vmName, count));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMFilesRecursive()
        {
            BatchController controller = BatchController.NewInstance;
            string startupFolder = "startup";
            int recursiveCount = 5; // dir itself, ProcessEnv, stdout, stderr, wd
            controller.RunPsTest(string.Format("Test-ListVMFilesRecursive '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolName, vmName, startupFolder, recursiveCount));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMFilePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            int count = 3; // shared, startup, workitems
            controller.RunPsTest(string.Format("Test-ListVMFilePipeline '{0}' '{1}' '{2}' '{3}'", accountName, poolName, vmName, count));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMFileContentByName()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetVMFileContentByName '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolName, vmName, startTaskStdOutName, startTaskStdOutContent));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMFileContentPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetVMFileContentPipeline '{0}' '{1}' '{2}' '{3}' '{4}'", accountName, poolName, vmName, startTaskStdOutName, startTaskStdOutContent));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRDPFileByName()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetRDPFileByName '{0}' '{1}' '{2}'", accountName, poolName, vmName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRDPFilePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetRDPFilePipeline '{0}' '{1}' '{2}'", accountName, poolName, vmName));
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

    [Cmdlet(VerbsCommon.Get, "AzureBatchTaskFileContent_ST")]
    public class GetBatchTaskFileContentScenarioTestCommand : GetBatchTaskFileContentCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureBatchVMFile_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchVMFileScenarioTestCommand : GetBatchVMFileCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureBatchVMFileContent_ST")]
    public class GetBatchVMFileContentScenarioTestCommand : GetBatchVMFileContentCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Get, "AzureBatchRDPFile_ST")]
    public class GetBatchRDPFileScenarioTestCommand : GetBatchRDPFileCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

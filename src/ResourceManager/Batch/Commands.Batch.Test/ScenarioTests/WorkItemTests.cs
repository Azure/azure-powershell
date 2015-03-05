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
    public class WorkItemTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewWorkItem()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-new-wi";
            string accountName = "testnewwi";
            string location = "eastus";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-NewWorkItem '{0}'", accountName) }; },
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
        public void TestGetWorkItemByName()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-get-wi";
            string accountName = "testgetwi";
            string location = "eastus";
            string workItemName = "testName";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetWorkItemByName '{0}' '{1}'", accountName, workItemName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListWorkItemsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-wi-filter";
            string accountName = "testlistwifilter";
            string location = "eastus";
            string workItemName1 = "testName1";
            string workItemName2 = "testName2";
            string workItemName3 = "thirdtestName";
            string workItemPrefix = "testName";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListWorkItemsByFilter '{0}' '{1}' '{2}'", accountName, workItemPrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName1);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName2);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName1);
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName2);
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName3);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListWorkItemsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-wi-maxcount";
            string accountName = "testlistwimaxcount";
            string location = "eastus";
            string workItemName1 = "testName1";
            string workItemName2 = "testName2";
            string workItemName3 = "thirdtestName";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListWorkItemsWithMaxCount '{0}' '{1}'", accountName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName1);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName2);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName1);
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName2);
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName3);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllWorkItems()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-wi";
            string accountName = "testlistwi";
            string location = "eastus";
            string workItemName1 = "testName1";
            string workItemName2 = "testName2";
            string workItemName3 = "thirdtestName";
            int count = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllWorkItems '{0}' '{1}'", accountName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName1);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName2);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName1);
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName2);
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName3);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteWorkItem()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-delete-wi";
            string accountName = "testdeletewi";
            string location = "eastus";
            string workItemName = "testWorkItem";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteWorkItem '{0}' '{1}' '0'", accountName, workItemName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteWorkItemPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-delete-wi-pipe";
            string accountName = "testdeletewipipe";
            string location = "eastus";
            string workItemName = "testWorkItem";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteWorkItem '{0}' '{1}' '1'", accountName, workItemName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestWorkItem(controller, context, workItemName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteWorkItem(controller, context, workItemName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchWorkItem_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchWorkItemScenarioTestCommand : GetBatchWorkItemCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.New, "AzureBatchWorkItem_ST")]
    public class NewBatchWorkItemScenarioTestCommand : NewBatchWorkItemCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Remove, "AzureBatchWorkItem_ST")]
    public class RemoveBatchWorkItemScenarioTestCommand : RemoveBatchWorkItemCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

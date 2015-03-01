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
    public class PoolTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPoolByName()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-get-pool";
            string accountName = "testgetpool";
            string location = "eastus";
            string poolName = "testName";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetPoolByName '{0}' '{1}'", accountName, poolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestPool(context, poolName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(context, poolName);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPoolsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-pool-filter";
            string accountName = "testlistpoolfilter";
            string location = "eastus";
            string poolName1 = "testName1";
            string poolName2 = "testName2";
            string poolName3 = "thirdtestName";
            string poolPrefix = "testName";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListPoolsByFilter '{0}' '{1}' '{2}'", accountName, poolPrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestPool(context, poolName1);
                    ScenarioTestHelpers.CreateTestPool(context, poolName2);
                    ScenarioTestHelpers.CreateTestPool(context, poolName3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(context, poolName1);
                    ScenarioTestHelpers.DeletePool(context, poolName2);
                    ScenarioTestHelpers.DeletePool(context, poolName3);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPoolsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-pool-maxcount";
            string accountName = "testlistpoolmaxcount";
            string location = "eastus";
            string poolName1 = "testName1";
            string poolName2 = "testName2";
            string poolName3 = "thirdtestName";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListPoolsWithMaxCount '{0}' '{1}'", accountName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestPool(context, poolName1);
                    ScenarioTestHelpers.CreateTestPool(context, poolName2);
                    ScenarioTestHelpers.CreateTestPool(context, poolName3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(context, poolName1);
                    ScenarioTestHelpers.DeletePool(context, poolName2);
                    ScenarioTestHelpers.DeletePool(context, poolName3);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllPools()
        {
            BatchController controller = BatchController.NewInstance;
            string resourceGroupName = "test-list-pool";
            string accountName = "testlistpool";
            string location = "eastus";
            string poolName1 = "testName1";
            string poolName2 = "testName2";
            string poolName3 = "thirdtestName";
            int count = 3;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllPools '{0}' '{1}'", accountName, count) }; },
                () =>
                {
                    context = ScenarioTestHelpers.CreateTestAccountAndResourceGroup(controller, resourceGroupName, accountName, location);
                    ScenarioTestHelpers.CreateTestPool(context, poolName1);
                    ScenarioTestHelpers.CreateTestPool(context, poolName2);
                    ScenarioTestHelpers.CreateTestPool(context, poolName3);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(context, poolName1);
                    ScenarioTestHelpers.DeletePool(context, poolName2);
                    ScenarioTestHelpers.DeletePool(context, poolName3);
                    ScenarioTestHelpers.CleanupTestAccount(controller, resourceGroupName, accountName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchPool_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchPoolScenarioTestCommand : GetBatchPoolCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

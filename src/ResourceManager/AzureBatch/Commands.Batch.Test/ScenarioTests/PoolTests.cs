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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class PoolTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string testPoolId = ScenarioTestHelpers.SharedPool;

        // Get from WATaskOSFamilyVersions table, which lags behind https://azure.microsoft.com/en-us/documentation/articles/cloud-services-guestos-update-matrix/
        private const string specificOSVersion = "WA-GUEST-OS-4.32_201605-01";

        public PoolTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPool()
        {
            BatchController.NewInstance.RunPsTest("Test-NewPool");
        }

        [Fact]
        public void TestGetPoolById()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId = "testGetPool";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetPoolById '{0}'", poolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListPoolsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId1 = "testFilter1";
            string poolId2 = "testFilter2";
            string poolId3 = "thirdFilterTest";
            string poolPrefix = "testFilter";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListPoolsByFilter '{0}' '{1}'", poolPrefix, matches) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId1, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId2, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId3, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId1);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId2);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAndListPoolsWithSelect()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetAndListPoolsWithSelect '{0}'", testPoolId));
        }

        [Fact]
        public void TestListPoolsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId1 = "testMaxCount1";
            string poolId2 = "testMaxCount2";
            string poolId3 = "thirdMaxCount";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListPoolsWithMaxCount '{0}'", maxCount) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId1, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId2, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId3, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId1);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId2);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestListAllPools()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId1 = "testList1";
            string poolId2 = "testList2";
            string poolId3 = "thirdTestList";
            int beforeAddCount = 0;
            int afterAddCount = 0;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllPools '{0}'", afterAddCount) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    beforeAddCount = ScenarioTestHelpers.GetPoolCount(controller, context);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId1, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId2, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId3, 0);
                    afterAddCount = beforeAddCount + 3;
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId1);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId2);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestUpdatePool()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId = "testUpdate";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-UpdatePool '{0}'", poolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDeletePool()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId = "testDelete";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeletePool '{0}' '0'", poolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, 0);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeletePoolPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId = "testDeletePipe";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeletePool '{0}' '1'", poolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, 0);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestResizePoolById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ResizePoolById '{0}'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestResizePoolByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ResizePoolByPipeline '{0}'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestStopResizePoolById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-StopResizePoolById '{0}'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestStopResizePoolByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-StopResizePoolByPipeline '{0}'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestEnableAutoScaleById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-EnableAutoScale '{0}' '0'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                    ScenarioTestHelpers.DisableAutoScale(controller, context, testPoolId);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                () =>
                {
                    ScenarioTestHelpers.DisableAutoScale(controller, context, testPoolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestEnableAutoScaleByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-EnableAutoScale '{0}' '1'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                    ScenarioTestHelpers.DisableAutoScale(controller, context, testPoolId);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                () =>
                {
                    ScenarioTestHelpers.DisableAutoScale(controller, context, testPoolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDisableAutoScaleById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DisableAutoScale '{0}' '0'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                    ScenarioTestHelpers.EnableAutoScale(controller, context, testPoolId);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestDisableAutoScaleByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DisableAutoScale '{0}' '1'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                    ScenarioTestHelpers.EnableAutoScale(controller, context, testPoolId);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestEvaluateAutoScaleById()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-EvaluateAutoScale '{0}' '0'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.EnableAutoScale(controller, context, testPoolId);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                () =>
                {
                    ScenarioTestHelpers.DisableAutoScale(controller, context, testPoolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestEvaluateAutoScaleByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-EvaluateAutoScale '{0}' '1'", testPoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.EnableAutoScale(controller, context, testPoolId);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolId);
                },
                () =>
                {
                    ScenarioTestHelpers.DisableAutoScale(controller, context, testPoolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        public void TestChangeOSVersionById()
        {
            TestChangeOSVersion(false);
        }

        [Fact]
        public void TestChangeOSVersionPipeline()
        {
            TestChangeOSVersion(true);
        }

        private void TestChangeOSVersion(bool usePipeline)
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string newTargetOSVersion = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ChangeOSVersion '{0}' '{1}' '{2}'", testPoolId, newTargetOSVersion, usePipeline ? 1 : 0) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    string currentTargetOSVersion = ScenarioTestHelpers.WaitForOSVersionChange(controller, context, testPoolId);
                    newTargetOSVersion = currentTargetOSVersion == "*" ? specificOSVersion : "*";
                },
                null,
                TestUtilities.GetCallingClass(),
                usePipeline ? "TestChangeOSVersionPipeline" : "TestChangeOSVersionById");
        }
    }
}

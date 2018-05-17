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
        private const string specificOSVersion = "WA-GUEST-OS-2.51_201605-01";

        public PoolTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestPoolCRUD()
        {
            BatchController.NewInstance.RunPsTest("Test-PoolCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestResizeAndStopResizePool()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string poolId = "resizePool";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ResizeAndStopResizePool '{0}'", poolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, targetDedicated: 0, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestAutoScaleActions()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string poolId = "autoscalePool";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-AutoScaleActions '{0}'", poolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, targetDedicated: 0, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public  void TestChangeOSVersion()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string poolId = "changeospool";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ChangeOSVersion '{0}' '{1}'", poolId, specificOSVersion) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, targetDedicated: 0, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}

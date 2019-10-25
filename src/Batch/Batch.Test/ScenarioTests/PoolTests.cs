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

using System.Reflection;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagement.Common.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class PoolTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string testPoolId = ScenarioTestHelpers.SharedPool;

        // Get from WATaskOSFamilyVersions table, which lags behind https://azure.microsoft.com/en-us/documentation/articles/cloud-services-guestos-update-matrix/
        private const string specificOSVersion = "WA-GUEST-OS-4.56_201807-02";
        public XunitTracingInterceptor _logger;

        public PoolTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPoolCRUD()
        {
            BatchController.NewInstance.RunPsTest(_logger, "Test-PoolCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResizeAndStopResizePool()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string poolId = "resizePool";
            controller.RunPsTestWorkflow(
                _logger,
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
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAutoScaleActions()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string poolId = "autoscalePool";
            controller.RunPsTestWorkflow(
                _logger,
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
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }
    }
}

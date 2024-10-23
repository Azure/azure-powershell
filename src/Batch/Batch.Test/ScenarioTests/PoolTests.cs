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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class PoolTests : BatchTestRunner
    {
        private const string testPoolId = ScenarioTestHelpers.SharedPool;

        // Get from WATaskOSFamilyVersions table, which lags behind https://azure.microsoft.com/en-us/documentation/articles/cloud-services-guestos-update-matrix/
        private const string specificOSVersion = "WA-GUEST-OS-4.56_201807-02";

        public PoolTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPoolCRUD()
        {
            TestRunner.RunTestScript("Test-PoolCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResizeAndStopResizePool()
        {
            BatchAccountContext context = null;
            string poolId = "resizePool";
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 0, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId);
                    ScenarioTestHelpers.DeletePool(this, context, poolId);
                },
                $"Test-ResizeAndStopResizePool '{poolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAutoScaleActions()
        {
            BatchAccountContext context = null;
            string poolId = "autoscalePool";
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 0, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(this, context, poolId);
                },
                $"Test-AutoScaleActions '{poolId}'"
            );
        }
    }
}

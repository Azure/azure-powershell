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
    public class ComputeNodeTests : BatchTestRunner
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;
        private const string iaasPoolId = ScenarioTestHelpers.SharedIaasPool;

        public ComputeNodeTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveComputeNodes()
        {
            BatchAccountContext context = null;
            string removeNodePoolId = "removenodepool";
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(this, context, removeNodePoolId, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, removeNodePoolId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(this, context, removeNodePoolId);
                },
                $"Test-RemoveComputeNodes '{removeNodePoolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRebootAndReimageComputeNode()
        {
            TestRunner.RunTestScript(
                mockContext =>
                {
                    _ = new ScenarioTestContext();
                },
                $"Test-RebootAndReimageComputeNode '{poolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableAndEnableComputeNodeScheduling()
        {
            TestRunner.RunTestScript(
                mockContext =>
                {
                    _ = new ScenarioTestContext();
                },
                $"Test-DisableAndEnableComputeNodeScheduling '{poolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetComputeNodeRemoteLoginSettings()
        {
            TestRunner.RunTestScript(
                mockContext =>
                {
                    _ = new ScenarioTestContext();
                },
                $"Test-GetRemoteLoginSettings '{iaasPoolId}'"
            );
        }
    }
}

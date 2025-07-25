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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
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
            UpgradePolicy upgradePolicy = new UpgradePolicy(Azure.Batch.Common.UpgradeMode.Automatic);
            upgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy();
            upgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback = true;
            upgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade = true;
            upgradePolicy.AutomaticOSUpgradePolicy.UseRollingUpgradePolicy = true;
            upgradePolicy.AutomaticOSUpgradePolicy.OsRollingUpgradeDeferral = true;

            upgradePolicy.RollingUpgradePolicy = new RollingUpgradePolicy();
            upgradePolicy.RollingUpgradePolicy.EnableCrossZoneUpgrade = true;
            upgradePolicy.RollingUpgradePolicy.MaxBatchInstancePercent = 20;
            upgradePolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent = 20;
            upgradePolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent = 20;
            upgradePolicy.RollingUpgradePolicy.PauseTimeBetweenBatches = TimeSpan.FromSeconds(5);
            upgradePolicy.RollingUpgradePolicy.PrioritizeUnhealthyInstances = false;
            upgradePolicy.RollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach = false;

            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, removeNodePoolId, targetDedicated: 2, targetLowPriority: 0, upgradePolicy: upgradePolicy);
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
            BatchAccountContext context = null;
            string poolId = "rebootandreimagenodepool";

            TestRunner.RunTestScript(
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId);
                },
                $"Test-RebootAndReimageComputeNode '{poolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableAndEnableComputeNodeScheduling()
        {
            BatchAccountContext context = null;
            string poolId = "disableandenablenodepool";

            TestRunner.RunTestScript(
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId);
                },
                $"Test-DisableAndEnableComputeNodeScheduling '{poolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetComputeNodeRemoteLoginSettings()
        {
            BatchAccountContext context = null;
            string poolId = "noderemoteloginpool";

            TestRunner.RunTestScript(
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId);
                },
                $"Test-GetRemoteLoginSettings '{poolId}'"
            );
        }
    }
}

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

using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrA2ATests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _helperModule = $"ScenarioTests/A2A/A2ATestsHelper.ps1";
        private readonly string _testModule = $"ScenarioTests/A2A/AsrA2ATests.ps1";

        public AsrA2ATests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2ADiskReplicationConfig()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-NewA2ADiskReplicationConfiguration");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2AManagedDiskReplicationConfig()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-NewA2AManagedDiskReplicationConfiguration");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2AManagedDiskReplicationConfigWithCmk()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-NewA2AManagedDiskReplicationConfigurationWithCmk");
        }

//#if NETSTANDARD
//        [Fact(Skip = "Needs investigation, TestManagementClientHelper class wasn't initialized with the ResourceManagementClient client.")]
//#else
        [Fact]
//#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ANewAsrFabric()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-NewAsrFabric");
        }

//#if NETSTANDARD
//        [Fact(Skip = "Needs investigation, TestManagementClientHelper class wasn't initialized with the ResourceManagementClient client.")]
//#else
        [Fact]
//#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ATestNewContainer()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-NewContainer");
        }

        [Fact(Skip = "Needs investigation, test times out after 60 minutes and successful enable DR.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ARemoveReplicationProtectedItemDisk()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-RemoveReplicationProtectedItemDisk");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AReplicateProximityPlacementGroupVm()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-ReplicateProximityPlacementGroupVm");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AVMNicConfig()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-VMNicConfig");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AZoneToZoneRecoveryPlanReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-ZoneToZoneRecoveryPlanReplication");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AEdgeZoneToAzureRecoveryPlanReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-EdgeZoneToAzureRecoveryPlanReplication");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AEdgeZoneToEdgeZoneRecoveryPlanReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-EdgeZoneToEdgeZoneRecoveryPlanReplication");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AEdgeZoneToAvailabilityZoneRecoveryPlanReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-EdgeZoneToAvailabilityZoneRecoveryPlanReplication");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ARecoveryPlanReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-RecoveryPlanReplication");
        }

        [Fact(Skip = "to be re-recorded in next release")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AVMSSReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-VMSSReplication");
        }

        [Fact(Skip = "Needs investigation, no suitable capacity reservation SKU found in eastus2euap or centraluseuap.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ACRGReplication()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_helperModule.AsAbsoluteLocation()}",
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-CRGReplication");
        }
    }
}

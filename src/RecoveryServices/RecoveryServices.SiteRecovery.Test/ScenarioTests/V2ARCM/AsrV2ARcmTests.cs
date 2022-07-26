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
    public class AsrV2ARCMTests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _testModule = $"ScenarioTests/V2ARCM/AsrV2ARcmTests.ps1";

        public AsrV2ARCMTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMFabric()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMFabric");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMPolicy()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMContainer()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMContainer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMContainerMapping()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMContainerMapping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestV2ARCMEnableDR()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMEnableDR");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMUpdateProtection()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMUpdateProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMTestFailover()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMTestFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMFailover()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMCommit()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMCommit");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMReprotect()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMReprotect");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMFailback()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMFailback");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMCancelFailover()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMCancelFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestV2ARCM540Reprotect()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCM540Reprotect");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMRecoveryPlan()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMRecoveryPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestV2ARCMSwitchAppliance()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                "Test-V2ARCMSwitchAppliance");
        }
    }
}

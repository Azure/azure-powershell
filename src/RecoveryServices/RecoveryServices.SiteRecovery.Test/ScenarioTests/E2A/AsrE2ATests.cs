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
    public class AsrE2ATests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _credModule = $"ScenarioTests/E2A/E2A.VaultCredentials";
        private readonly string _testModule = $"ScenarioTests/E2A/AsrE2ATests.ps1";

        public AsrE2ATests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FabricTests()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-FabricTest -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePolicy()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryCreatePolicy -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableDR()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryEnableDR -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMapNetwork()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-MapNetwork -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTFO()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-TFO -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPlannedFailover()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-PlannedFailover -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestReprotect()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-Reprotect -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }
    }
}

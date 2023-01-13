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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrE2ETests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _credModule = $"ScenarioTests/E2E/E2E.VaultCredentials";
        private readonly string _testModule = $"ScenarioTests/E2E/AsrE2ETests.ps1";

        public AsrE2ETests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FabricTests()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
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
        public void TestCreatePCMap()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-CreatePCMap -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUFOandFailback()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-UFOandFailback -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEditRP()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-EditRecoveryPlan -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRP()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryRemoveRecoveryPlan -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableDR()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryDisableDR -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePCMap()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-RemovePCMap -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicy()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryRemovePolicy -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNetworkPairing()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-RemoveNetworkPairing -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveFabric()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-RemoveFabric -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }
    }
}

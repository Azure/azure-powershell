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
    public class AsrB2ATests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _credModule = $"ScenarioTests/B2A/B2A.VaultCredentials";
        private readonly string _testModule = $"ScenarioTests/B2A/AsrB2ATests.ps1";

        public AsrB2ATests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePolicy()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-CreatePolicy -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
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
        public void TestUpdateRPI()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-UpdateRPI -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
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
        public void TestUpdateRPIWithDES()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-UpdateRPIWithDiskEncryptionSetMap -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateRPIWithAdditionalProperties()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-CreateRPIWithAdditionalProperties -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateRPIWithAdditionalProperties()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-UpdateRPIWithAdditionalProperties -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateRPIWithAvZone()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-CreateRPIWithAvailabilityZone -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateRPIWithAvZone()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-UpdateRPIWithAvailabilityZone -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }
    }
}

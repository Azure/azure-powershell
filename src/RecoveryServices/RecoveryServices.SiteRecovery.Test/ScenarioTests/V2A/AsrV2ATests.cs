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
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrV2ATests : RecoveryServicesSiteRecoveryTestRunner
    {
        private readonly string _credModule = $"ScenarioTests/V2A/V2A.VaultCredentials";
        private readonly string _testModule = $"ScenarioTests/V2A/AsrV2ATests.ps1";

        public AsrV2ATests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Needs investigation for linux.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AvCenterTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-vCenter -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddvCenterTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-AddvCenter -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AFabricTests()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2APCMappingTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-PCM -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2APCTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-PC -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2APolicyTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SiteRecoveryPolicy -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddPI()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-V2AAddPI -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreatePolicyAndAssociateTest()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreatePolicyAndAssociate -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPI()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreateRPI -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATestResync()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ATestResync -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AUpdateMS()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AUpdateMobilityService -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AUpdateSP()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AUpdateServiceProvider -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATFOJob()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ATestFailoverJob -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AFailoverJob()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AFailoverJob -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATestSwitchProtection()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ATestReprotectAzureToVmware -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATestFailback()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ATestFailback -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATestReprotect()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ATestReprotectVMwareToAzure -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2APSSwitch()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ASwitchProcessServer -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AUpdatePolicy()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AUpdatePolicy -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetRPI()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"Test-SetRPI -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPIWithDES()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreateRPIWithDES -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPIWithDESEnabledDiskInput()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreateRPIWithDESEnabledDiskInput -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPIWithPPG()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreateRPIWithPPG -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AUpdateRPIWithPPG()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AUpdateRPIWithPPG -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPIWithAvZone()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreateRPIWithAvZone -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AUpdateRPIWithAvZone()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AUpdateRPIWithAvZone -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPIWithAdditionalProperties()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2ACreateRPIWithAdditionalProperties -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AUpdateRPIWithAdditionalProperties()
        {
            TestRunner.RunTestScript(
                $"Import-Module {_testModule.AsAbsoluteLocation()}",
                $"V2AUpdateRPIWithAdditionalProperties -vaultSettingsFilePath \"{_credModule.AsAbsoluteLocation()}\"");
        }
    }
}

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

using System;
using System.IO;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrV2ATests : AsrTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AsrV2ATests(
            ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            this.VaultSettingsFilePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "V2A", "V2A.VaultCredentials");
            this.PowershellFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "V2A", "AsrV2ATests.ps1");
            this.Initialize();
        }

        [Fact(Skip = "Needs investigation for linux.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AvCenterTest()
        {
            this.RunPowerShellTest(
                _logger,
              Constants.NewModel,
              "Test-vCenter -vaultSettingsFilePath \"" +
              this.VaultSettingsFilePath +
              "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddvCenterTest()
        {
            this.RunPowerShellTest(
                _logger,
              Constants.NewModel,
              "Test-AddvCenter -vaultSettingsFilePath \"" +
              this.VaultSettingsFilePath +
              "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AFabricTests()
        {
            this.RunPowerShellTest(
               _logger,
             Constants.NewModel,
             "Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APCMappingTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-PCM -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APCTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-PC -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APolicyTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-SiteRecoveryPolicy -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddPI()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "Test-V2AAddPI -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ACreatePolicyAndAssociateTest()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "V2ACreatePolicyAndAssociate -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPI()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "V2ACreateRPI -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void V2ATestResync()
        {
            this.RunPowerShellTest(
                _logger,
             Constants.NewModel,
             "V2ATestResync -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AUpdateMS()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AUpdateMobilityService -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AUpdateSP()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AUpdateServiceProvider -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATFOJob()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ATestFailoverJob -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AFailoverJob()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AFailoverJob -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ATestSwitchProtection()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ATestReprotectAzureToVmware -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ATestFailback()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ATestFailback -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ATestReprotect()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ATestReprotectVMwareToAzure -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APSSwitch()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ASwitchProcessServer -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AUpdatePolicy()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AUpdatePolicy -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void SetRPI()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-SetRPI -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithDES()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ACreateRPIWithDES -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithDESEnabledDiskInput()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ACreateRPIWithDESEnabledDiskInput -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithPPG()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ACreateRPIWithPPG -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AUpdateRPIWithPPG()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AUpdateRPIWithPPG -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithAvZone()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ACreateRPIWithAvZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AUpdateRPIWithAvZone()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AUpdateRPIWithAvZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithAdditionalProperties()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2ACreateRPIWithAdditionalProperties -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AUpdateRPIWithAdditionalProperties()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "V2AUpdateRPIWithAdditionalProperties -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }
    }
}

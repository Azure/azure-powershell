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

using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;


namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrE2ETests : AsrTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AsrE2ETests(
            ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "E2E", "E2E.VaultCredentials");
            this.PowershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "E2E", "AsrE2ETests.ps1");
            this.Initialize();
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void FabricTests()
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
        public void TestCreatePolicy()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-SiteRecoveryCreatePolicy -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePCMap()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-CreatePCMap -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestEnableDR()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-SiteRecoveryEnableDR -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestMapNetwork()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-MapNetwork -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestTFO()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-TFO -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestPlannedFailover()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-PlannedFailover -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestReprotect()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-Reprotect -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUFOandFailback()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-UFOandFailback -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void TestEditRP()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-EditRecoveryPlan -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void TestRemoveRP()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-SiteRecoveryRemoveRecoveryPlan -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestDisableDR()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-SiteRecoveryDisableDR -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemovePCMap()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-RemovePCMap -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemovePolicy()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-SiteRecoveryRemovePolicy -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void TestRemoveNetworkPairing()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-RemoveNetworkPairing -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void TestRemoveFabric()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-RemoveFabric -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }
    }
}

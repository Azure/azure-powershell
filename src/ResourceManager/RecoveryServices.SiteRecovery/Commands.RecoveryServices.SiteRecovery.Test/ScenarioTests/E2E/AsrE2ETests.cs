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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;


namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrE2ETests : AsrTestsBase
    {
        public AsrE2ETests(
            ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            this.vaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\E2E\\E2E.VaultCredentials");
            this.powershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\E2E\\AsrE2ETests.ps1");
            this.initialize();
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void FabricTests()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePolicy()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryCreatePolicy -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePCMap()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-CreatePCMap -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestEnableDR()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryEnableDR -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestMapNetwork()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-MapNetwork -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestTFO()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-TFO -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestPlannedFailover()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-PlannedFailover -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestReprotect()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-Reprotect -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUFOandFailback()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-UFOandFailback -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void TestEditRP()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-EditRecoveryPlan -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void TestRemoveRP()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryRemoveRecoveryPlan -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestDisableDR()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryDisableDR -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemovePCMap()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-RemovePCMap -vaultSettingsFilePath \"" + this.vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemovePolicy()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-SiteRecoveryRemovePolicy -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void TestRemoveNetworkPairing()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-RemoveNetworkPairing -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void TestRemoveFabric()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-RemoveFabric -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }
    }
}

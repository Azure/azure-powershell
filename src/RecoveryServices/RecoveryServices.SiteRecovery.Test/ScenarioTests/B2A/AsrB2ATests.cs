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
    public class AsrB2ATests : AsrTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AsrB2ATests(
            ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2A.VaultCredentials");
            this.PowershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "AsrB2ATests.ps1");
            this.Initialize();
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
                "Test-CreatePolicy -vaultSettingsFilePath \"" +
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
        public void TestUpdateRPI()
        {
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-UpdateRPI -vaultSettingsFilePath \"" +
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
        public void TestUpdateRPIWithDES()
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "CMKInput", "B2A.VaultCredentials");
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-UpdateRPIWithDiskEncryptionSetMap -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreateRPIWithPPG()
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2AInput", "B2A.VaultCredentials");
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-CreateRPIWithProximityPlacementGroup -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUpdateRPIWithPPG()
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2AInput", "B2A.VaultCredentials");
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-UpdateRPIWithProximityPlacementGroup -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreateRPIWithAvZone()
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2AInput", "B2A.VaultCredentials");
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-CreateRPIWithAvailabilityZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUpdateRPIWithAvZone()
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2AInput", "B2A.VaultCredentials");
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-UpdateRPIWithAvailabilityZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreateRPIWithManagedDisk()
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2AInput", "B2A.VaultCredentials");
            this.RunPowerShellTest(
                _logger,
                Constants.NewModel,
                "Test-CreateRPIWithManagedDisk -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }
    }
}

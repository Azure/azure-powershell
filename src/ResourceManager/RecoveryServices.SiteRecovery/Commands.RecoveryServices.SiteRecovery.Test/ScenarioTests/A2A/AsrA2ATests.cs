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
    public class AsrA2ATests : AsrTestsBase
    {
        public AsrA2ATests(
            ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));

            this.vaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\A2A\\AsrA2A.VaultCredentials");
            this.powershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\A2A\\AsrA2ATests.ps1");
            this.initialize();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2ADiskReplicationConfig1()
        {
            this.RunPowerShellTest(Constants.NewModel, "Test-NewA2ADiskReplicationConfiguration ");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAsrNetworkMapping()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-NewAsrNetworkMapping -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAsrNetworkMapping()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-GetAsrNetworkMapping -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAsrFabric()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-NewAsrFabric -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }


        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestA2APolicy()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-A2ARecoveryPolicy -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestA2AProtectionContainer()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-NewRemoveA2AProtectionContainer -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestA2AProtectionContainerMapping()
        {
            this.RunPowerShellTest(
                Constants.NewModel,
                "Test-A2AProtectionContainerMapping -vaultSettingsFilePath \"" +
                this.vaultSettingsFilePath +
                "\"");
        }
    }
}

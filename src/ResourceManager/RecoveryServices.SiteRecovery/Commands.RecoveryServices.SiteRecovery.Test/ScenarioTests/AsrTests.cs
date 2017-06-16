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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests
{
    public class AsrTests : AsrTestsBase
    {
        public AsrTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void EnumerationTests()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryEnumerationTests -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void FabricTests()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void NewModelE2ETest()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryNewModelE2ETest -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePCMap()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-CreatePCMap -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePolicy()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryCreatePolicy -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreateRP()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryCreateRecoveryPlan -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestDisableDR()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryDisableDR -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestEnableDR()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryEnableDR -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestEnumerateRP()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryEnumerateRecoveryPlan -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemovePCMap()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-RemovePCMap -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemovePolicy()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryRemovePolicy -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType,
            Category.CheckIn)]
        public void TestRemoveRP()
        {
            RunPowerShellTest(Constants.NewModel,
                "Test-SiteRecoveryRemoveRecoveryPlan -vaultSettingsFilePath \"" +
                vaultSettingsFilePath +
                "\"");
        }
    }
}
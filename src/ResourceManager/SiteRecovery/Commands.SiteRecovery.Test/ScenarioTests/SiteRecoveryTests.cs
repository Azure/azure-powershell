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

namespace Microsoft.Azure.Commands.SiteRecovery.Test.ScenarioTests
{
    public class SiteRecoveryTests : SiteRecoveryTestsBase
    {
        public SiteRecoveryTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnumerationTests()
        {
            this.RunPowerShellTest("Test-SiteRecoveryEnumerationTests -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateProfile()
        {
            this.RunPowerShellTest("Test-SiteRecoveryCreateProfile -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteProfile()
        {
            this.RunPowerShellTest("Test-SiteRecoveryDeleteProfile -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAssociateProfile()
        {
            this.RunPowerShellTest("Test-SiteRecoveryAssociateProfile -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDissociateProfile()
        {
            this.RunPowerShellTest("Test-SiteRecoveryDissociateProfile -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableDR()
        {
            this.RunPowerShellTest("Test-SiteRecoveryEnableDR -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableDR()
        {
            this.RunPowerShellTest("Test-SiteRecoveryDisableDR -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateRP()
        {
            this.RunPowerShellTest("Test-SiteRecoveryCreateRecoveryPlan -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnumerateRP()
        {
            this.RunPowerShellTest("Test-SiteRecoveryEnumerateRecoveryPlan -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveRP()
        {
            this.RunPowerShellTest("Test-SiteRecoveryRemoveRecoveryPlan -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VaultCRUDTests()
        {
            this.RunPowerShellTest("Test-SiteRecoveryVaultCRUDTests");
        }
    }
}

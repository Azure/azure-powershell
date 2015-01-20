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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.RecoveryServices.Test.ScenarioTests
{
    public class RecoveryServicesTests : RecoveryServicesTestsBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesEnumerationTests()
        {
            this.RunPowerShellTest("Test-RecoveryServicesEnumerationTests -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesProtectionTests()
        {
            this.RunPowerShellTest("Test-RecoveryServicesProtectionTests -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesStorageMappingTest()
        {
            this.RunPowerShellTest("Test-StorageMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesStorageUnMappingTest()
        {
            this.RunPowerShellTest("Test-StorageUnMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesNetworkMappingTest()
        {
            this.RunPowerShellTest("Test-NetworkMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesFailbackTest()
        {
            this.RunPowerShellTest("Test-Failback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesRRAfterFailbackTest()
        {
            this.RunPowerShellTest("Test-RRAfterFailback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesCommitPFOTest()
        {
            this.RunPowerShellTest("Test-CommitPFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesPFOTest()
        {
            this.RunPowerShellTest("Test-PFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesUFOTest()
        {
            this.RunPowerShellTest("Test-UFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesTFOTest()
        {
            this.RunPowerShellTest("Test-TFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesEnableProtectionTest()
        {
            this.RunPowerShellTest("Test-EnableProtection -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesDisableProtectionTest()
        {
            this.RunPowerShellTest("Test-DisableProtection -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }
    }
}

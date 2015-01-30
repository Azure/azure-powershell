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
        public void RecoveryServicesNetworkUnMappingTest()
        {
            this.RunPowerShellTest("Test-NetworkUnMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesAzureNetworkMappingTest()
        {
            this.RunPowerShellTest("Test-AzureNetworkMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesAzureNetworkUnMappingTest()
        {
            this.RunPowerShellTest("Test-AzureNetworkUnMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesFailbackTest()
        {
            this.RunPowerShellTest("Test-Failback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesRRAfterFailoverTest()
        {
            this.RunPowerShellTest("Test-RRAfterFailover -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
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
        public void RecoveryServicesCommitAfterFailbackTest()
        {
            this.RunPowerShellTest("Test-CommitAfterFailback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesE2E_DeleteAndDissociateTest()
        {
            this.RunPowerShellTest("Test-E2E_DeleteAndDissociate -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesE2E_CreateAndAssociateTest()
        {
            this.RunPowerShellTest("Test-E2E_CreateAndAssociate -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesPFORPTest()
        {
            this.RunPowerShellTest("Test-PFORP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesTFORPTest()
        {
            this.RunPowerShellTest("Test-TFORP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesUFORPTest()
        {
            this.RunPowerShellTest("Test-UFORP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesFailbackRPTest()
        {
            this.RunPowerShellTest("Test-FailbackRP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesRRRPTest()
        {
            this.RunPowerShellTest("Test-RRRP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RecoveryServicesCommitRPTest()
        {
            this.RunPowerShellTest("Test-CommitRP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }
    }
}

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
        public void EnumerationTests()
        {
            this.RunPowerShellTest("Test-RecoveryServicesEnumerationTests -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        public void E2E_DeleteAndDissociateTest()
        {
            this.RunPowerShellTest("Test-E2E_DeleteAndDissociate -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        public void E2E_CreateAndAssociateTest()
        {
            this.RunPowerShellTest("Test-E2E_CreateAndAssociate -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        public void StorageMappingTest()
        {
            this.RunPowerShellTest("Test-StorageMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        public void StorageUnMappingTest()
        {
            this.RunPowerShellTest("Test-StorageUnMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        public void NetworkMappingTest()
        {
            this.RunPowerShellTest("Test-NetworkMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        [Fact]
        public void NetworkUnMappingTest()
        {
            this.RunPowerShellTest("Test-NetworkUnMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void ProtectionTests()
        {
            this.RunPowerShellTest("Test-RecoveryServicesProtectionTests -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void AzureNetworkMappingTest()
        {
            this.RunPowerShellTest("Test-AzureNetworkMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void AzureNetworkUnMappingTest()
        {
            this.RunPowerShellTest("Test-AzureNetworkUnMapping -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void FailbackTest()
        {
            this.RunPowerShellTest("Test-Failback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void RRAfterFailoverTest()
        {
            this.RunPowerShellTest("Test-RRAfterFailover -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void RRAfterFailbackTest()
        {
            this.RunPowerShellTest("Test-RRAfterFailback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void CommitPFOTest()
        {
            this.RunPowerShellTest("Test-CommitPFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void CommitAfterFailbackTest()
        {
            this.RunPowerShellTest("Test-CommitAfterFailback -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void PFOTest()
        {
            this.RunPowerShellTest("Test-PFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void UFOTest()
        {
            this.RunPowerShellTest("Test-UFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void TFOTest()
        {
            this.RunPowerShellTest("Test-TFO -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void EnableProtectionTest()
        {
            this.RunPowerShellTest("Test-EnableProtection -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void DisableProtectionTest()
        {
            this.RunPowerShellTest("Test-DisableProtection -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void PFORPTest()
        {
            this.RunPowerShellTest("Test-PFORP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void TFORPTest()
        {
            this.RunPowerShellTest("Test-TFORP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void UFORPTest()
        {
            this.RunPowerShellTest("Test-UFORP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void FailbackRPTest()
        {
            this.RunPowerShellTest("Test-FailbackRP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void RRRPTest()
        {
            this.RunPowerShellTest("Test-RRRP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }

        public void CommitRPTest()
        {
            this.RunPowerShellTest("Test-CommitRP -vaultSettingsFilePath \"" + vaultSettingsFilePath + "\"");
        }
    }
}

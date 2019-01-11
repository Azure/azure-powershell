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
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultManagementTests : KeyVaultTestRunner
    {
        public KeyVaultManagementTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        #region New-AzureRmKeyVault        

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewVault()
        {
            TestRunner.RunTestScript("Test-CreateNewVault");
        }

        #endregion

        #region Get-AzureRmKeyVault

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVault()
        {
            TestRunner.RunTestScript("Test-GetVault");
        }

        #endregion

        #region Get-AzureRmKeyVault (list)

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVaults()
        {
            TestRunner.RunTestScript("Test-ListVaults");
        }

        #endregion

        #region Remove-AzureRmKeyVault 

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteVault()
        {
            TestRunner.RunTestScript("Test-DeleteVaultByName");
        }

        #endregion

        #region Set-AzureRmKeyVaultAccessPolicy & Remove-AzureRmKeyVaultAccessPolicy

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByObjectId()
        {
            TestRunner.RunTestScript("Test-SetRemoveAccessPolicyByObjectId");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByUPN()
        {
            TestRunner.RunTestScript("Test-SetRemoveAccessPolicyByUPN");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyByCompoundId()
        {
            TestRunner.RunTestScript("Test-SetRemoveAccessPolicyByCompoundId");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccessPolicyWithCompoundIdPolicies()
        {
            TestRunner.RunTestScript("Test-RemoveAccessPolicyWithCompoundIdPolicies");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetCompoundIdAccessPolicy()
        {
            TestRunner.RunTestScript("Test-SetCompoundIdAccessPolicy");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRemoveAccessPolicyBySPN()
        {
            TestRunner.RunTestScript("Test-SetRemoveAccessPolicyBySPN");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicy()
        {
            TestRunner.RunTestScript("Test-ModifyAccessPolicy");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForDeployment()
        {
            TestRunner.RunTestScript("Test-ModifyAccessPolicyEnabledForDeployment");
        }


        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForTemplateDeployment()
        {
            TestRunner.RunTestScript("Test-ModifyAccessPolicyEnabledForTemplateDeployment");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyEnabledForDiskEncryption()
        {
            TestRunner.RunTestScript("Test-ModifyAccessPolicyEnabledForDiskEncryption");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestModifyAccessPolicyNegativeCases()
        {
            TestRunner.RunTestScript("Test-ModifyAccessPolicyNegativeCases");
        }

        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistentAccessPolicyDoesNotThrow()
        {
            TestRunner.RunTestScript("Test-RemoveNonExistentAccessPolicyDoesNotThrow");
        }

        #endregion

        #region Piping
        [Fact(Skip = "Test infrustructure calls need to be added to the .ps1 function for the corresponding test")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteVaultWithPiping()
        {
            TestRunner.RunTestScript("Test-CreateDeleteVaultWithPiping");
        }

        #endregion

        [Fact(Skip = "Fails in playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkSet()
        {
            TestRunner.RunTestScript("Test-NetworkRuleSet");
        }
    }
}

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


using Microsoft.Azure.Commands.Management.CognitiveServices.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace CognitiveServices.Test.ScenarioTests
{
    public class CognitiveServicesAccountTests : CognitiveServicesTestRunner
    {
        public CognitiveServicesAccountTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccount()
        {
            TestRunner.RunTestScript("Test-NewAzureRmCognitiveServicesAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountWithCustomDomain()
        {
            TestRunner.RunTestScript("Test-NewAzureRmCognitiveServicesAccountWithCustomDomain");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountWithVnet()
        {
            TestRunner.RunTestScript("Test-NewAzureRmCognitiveServicesAccountWithVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccount()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmCognitiveServicesAccount");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccounts()
        {
            TestRunner.RunTestScript("Test-GetAzureCognitiveServiceAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAsyncAccountOperations()
        {
            TestRunner.RunTestScript("Test-AsyncAccountOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAccount()
        {
            TestRunner.RunTestScript("Test-SetAzureRmCognitiveServicesAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAccountWithCustomDomain()
        {
            TestRunner.RunTestScript("Test-SetAzureRmCognitiveServicesAccountWithCustomDomain");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAccountWithVnet()
        {
            TestRunner.RunTestScript("Test-SetAzureRmCognitiveServicesAccountWithVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkRuleSet()
        {
            TestRunner.RunTestScript("Test-NetworkRuleSet");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkRuleSetDefaultActions()
        {
            TestRunner.RunTestScript("Test-NetworkRuleSetDefaultActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccountKeys()
        {
            TestRunner.RunTestScript("Test-GetAzureRmCognitiveServicesAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountKey()
        {
            TestRunner.RunTestScript("Test-NewAzureRmCognitiveServicesAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountSkus()
        {
            TestRunner.RunTestScript("Test-GetAzureRmCognitiveServicesAccountSkus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccountType()
        {
            TestRunner.RunTestScript("Test-GetAzureRmCognitiveServicesAccountType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingToGetKey()
        {
            TestRunner.RunTestScript("Test-PipingGetAccountToGetKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingToSetAccount()
        {
            TestRunner.RunTestScript("Test-PipingToSetAzureAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMinMaxAccountNames()
        {
            TestRunner.RunTestScript("Test-MinMaxAccountName");
        }
        

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUsages()
        {
            TestRunner.RunTestScript("Test-GetUsages");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedIdentity()
        {
            TestRunner.RunTestScript("Test-ManagedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUserAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-UserAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEncryption()
        {
            TestRunner.RunTestScript("Test-Encryption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUserOwnedStorage()
        {
            TestRunner.RunTestScript("Test-UserOwnedStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateEndpoint()
        {
            TestRunner.RunTestScript("Test-PrivateEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicNetworkAccess()
        {
            TestRunner.RunTestScript("Test-PublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestrictOutboundNetworkAccess()
        {
            TestRunner.RunTestScript("Test-RestrictOutboundNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableLocalAuth()
        {
            TestRunner.RunTestScript("Test-DisableLocalAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCapabilities()
        {
            TestRunner.RunTestScript("Test-Capabilities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiProperties()
        {
            TestRunner.RunTestScript("Test-ApiProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSoftDelete()
        {
            TestRunner.RunTestScript("Test-SoftDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCommitmentPlan()
        {
            TestRunner.RunTestScript("Test-CommitmentPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeployment()
        {
            TestRunner.RunTestScript("Test-Deployment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListModels()
        {
            TestRunner.RunTestScript("Test-ListModels");
        }
    }
}

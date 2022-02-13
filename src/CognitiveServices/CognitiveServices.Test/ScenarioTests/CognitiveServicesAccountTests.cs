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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CognitiveServices.Test.ScenarioTests
{
    public class CognitiveServicesAccountTests : RMTestBase
    {
        XunitTracingInterceptor traceInterceptor;

        public CognitiveServicesAccountTests(ITestOutputHelper output)
        {
            this.traceInterceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.traceInterceptor);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmCognitiveServicesAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountWithCustomDomain()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmCognitiveServicesAccountWithCustomDomain");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountWithVnet()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmCognitiveServicesAccountWithVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-RemoveAzureRmCognitiveServicesAccount");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccounts()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureCognitiveServiceAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAsyncAccountOperations()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-AsyncAccountOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SetAzureRmCognitiveServicesAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAccountWithCustomDomain()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SetAzureRmCognitiveServicesAccountWithCustomDomain");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAccountWithVnet()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SetAzureRmCognitiveServicesAccountWithVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkRuleSet()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NetworkRuleSet");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkRuleSetDefaultActions()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NetworkRuleSetDefaultActions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccountKeys()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmCognitiveServicesAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAccountKey()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmCognitiveServicesAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountSkus()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmCognitiveServicesAccountSkus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccountType()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmCognitiveServicesAccountType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingToGetKey()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-PipingGetAccountToGetKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingToSetAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-PipingToSetAzureAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMinMaxAccountNames()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-MinMaxAccountName");
        }
        

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUsages()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetUsages");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedIdentity()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManagedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUserAssignedIdentity()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-UserAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEncryption()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-Encryption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUserOwnedStorage()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-UserOwnedStorage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateEndpoint()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-PrivateEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPublicNetworkAccess()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-PublicNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestrictOutboundNetworkAccess()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-RestrictOutboundNetworkAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableLocalAuth()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-DisableLocalAuth");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCapabilities()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-Capabilities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiProperties()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ApiProperties");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSoftDelete()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SoftDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCommitmentPlan()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-CommitmentPlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeployment()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-Deployment");
        }
    }
}

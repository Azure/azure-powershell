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
        public void TestCreateAllKindsOfAccounts()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmAllKindsOfCognitiveServicesAccounts");
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
        public void TestSetAccount()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SetAzureRmCognitiveServicesAccount");
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
    }
}

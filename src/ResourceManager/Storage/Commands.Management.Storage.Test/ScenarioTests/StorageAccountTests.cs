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

using Microsoft.Azure.Commands.TestFw;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests
{
    public class StorageAccountTests
    {
        private readonly ITestRunnable _testManager;

        public StorageAccountTests(ITestOutputHelper output)
        {
            _testManager = TestManager.CreateInstance()
                .WithXunitTracingInterceptor(output)
                .WithExtraRmModules(helper => new[]
                {
                    helper.RMStorageDataPlaneModule,
                    helper.RMStorageModule,
                })
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"AzureRM.Resources.ps1",
                    @"Common.ps1",
                })
                .Build();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccount() =>
            _testManager.RunTestScript("Test-StorageAccount");

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccount()
        {
            _testManager.RunTestScript("Test-NewAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageAccount()
        {
            _testManager.RunTestScript("Test-GetAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageAccount()
        {
            _testManager.RunTestScript("Test-SetAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureStorageAccount()
        {
            _testManager.RunTestScript("Test-RemoveAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageAccountKey()
        {
            _testManager.RunTestScript("Test-GetAzureStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccountKey()
        {
            _testManager.RunTestScript("Test-NewAzureStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingGetAccountToGetKey()
        {
            _testManager.RunTestScript("Test-PipingGetAccountToGetKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingSetStorageAccount()
        {
            _testManager.RunTestScript("Test-PipingToSetAzureRmCurrentStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetCurrentStorageAccount()
        {
            _testManager.RunTestScript("Test-SetAzureRmCurrentStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmStorageAccountKeySource()
        {
            _testManager.RunTestScript("Test-SetAzureRmStorageAccountKeySource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkRule()
        {
            _testManager.RunTestScript("Test-NetworkRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageAccountStorageV2()
        {
            _testManager.RunTestScript("Test-SetAzureStorageAccountStorageV2");
        }
    }
}

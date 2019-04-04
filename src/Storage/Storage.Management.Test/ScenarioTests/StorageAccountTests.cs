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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests
{
    public class StorageAccountTests : StorageTestRunner
    {
        public StorageAccountTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccount() =>
            TestRunner.RunTestScript("Test-StorageAccount");

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccount()
        {
            TestRunner.RunTestScript("Test-NewAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageAccount()
        {
            TestRunner.RunTestScript("Test-GetAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageAccount()
        {
            TestRunner.RunTestScript("Test-SetAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureStorageAccount()
        {
            TestRunner.RunTestScript("Test-RemoveAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageAccountKey()
        {
            TestRunner.RunTestScript("Test-GetAzureStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccountKey()
        {
            TestRunner.RunTestScript("Test-NewAzureStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingGetAccountToGetKey()
        {
            TestRunner.RunTestScript("Test-PipingGetAccountToGetKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingSetStorageAccount()
        {
            TestRunner.RunTestScript("Test-PipingToSetAzureRmCurrentStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetCurrentStorageAccount()
        {
            TestRunner.RunTestScript("Test-SetAzureRmCurrentStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmStorageAccountKeySource()
        {
            TestRunner.RunTestScript("Test-SetAzureRmStorageAccountKeySource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNetworkRule()
        {
            TestRunner.RunTestScript("Test-NetworkRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageAccountStorageV2()
        {
            TestRunner.RunTestScript("Test-SetAzureStorageAccountStorageV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageLocationUsage()
        {
            TestRunner.RunTestScript("Test-GetAzureStorageLocationUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingNewUpdateAccount()
        {
            TestRunner.RunTestScript("Test-PipingNewUpdateAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccountBlockBlobStorage()
        {
            TestRunner.RunTestScript("Test-NewAzureStorageAccountBlockBlobStorage");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccountManagementPolicy()
        {
            TestRunner.RunTestScript("Test-StorageAccountManagementPolicy");
        }
    }
}

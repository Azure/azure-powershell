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

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class StorageAccountTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-StorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-NewAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-GetAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-SetAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureStorageAccount()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-RemoveAzureStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureStorageAccountKey()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-GetAzureStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureStorageAccountKey()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-NewAzureStorageAccountKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingGetAccountToGetKey()
        {
            ComputeTestController.NewInstance.RunPsTest("Test-PipingGetAccountToGetKey");
        }
    }
}

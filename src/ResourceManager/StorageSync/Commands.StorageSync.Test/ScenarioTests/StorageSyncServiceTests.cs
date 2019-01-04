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


using Microsoft.Azure.Commands.StorageSync.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace StorageSync.Test.ScenarioTests
{
    public class StorageSyncServiceTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public StorageSyncServiceTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(_logger = new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-StorageSyncService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewStorageSyncService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetStorageSyncService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetStorageSyncServices()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetStorageSyncServices");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveStorageSyncService()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveStorageSyncService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveStorageSyncServiceInputObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveStorageSyncServiceInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveStorageSyncServiceResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveStorageSyncServiceResourceId");
        }

    }
}

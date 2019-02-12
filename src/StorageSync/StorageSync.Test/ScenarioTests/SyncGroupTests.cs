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
using Xunit;
using Xunit.Abstractions;

namespace StorageSync.Test.ScenarioTests
{
    public class SyncGroupTests
    {
        private readonly XunitTracingInterceptor _logger;

        public SyncGroupTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(_logger = new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroup()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-SyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSyncGroup()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroup()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroupParentObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetSyncGroupParentObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroupParentResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetSyncGroupParentResourceId");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroups()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetSyncGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSyncGroup()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveSyncGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSyncGroupResourceId()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveSyncGroupResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSyncGroupInputObject()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveSyncGroupInputObject");
        }

    }
}

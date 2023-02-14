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

namespace Microsoft.Azure.Commands.HPCCache.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.HPCCache.Test.Fixtures;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// HpcCacheTest.
    /// </summary>
    [Collection("HpcCacheCollection")]
    public class HpcCacheStorageTargetTest : HPCCacheTestRunner, IClassFixture<StorageAccountFixture>
    {
        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly HpcCacheTestFixture fixture;

        /// <summary>
        /// StorageAccountFixture.
        /// </summary>
        private readonly StorageAccountFixture storageAccountFixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheStorageTargetTest"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="HpcCacheTestFixture"/>.</param>
        /// <param name="storageAccountFixture">Storage account fixture<see cref="StorageAccountFixture"/>.</param>
        public HpcCacheStorageTargetTest(ITestOutputHelper testOutputHelper, HpcCacheTestFixture fixture, StorageAccountFixture storageAccountFixture) : base(testOutputHelper)
        {
            this.fixture = fixture;
            this.storageAccountFixture = storageAccountFixture;
        }

        /// <summary>
        /// Test GetAzHPCCacheStorageTarget by resource group and name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzHPCCacheStorageTargetByNameAndResourceGroup()
        {
            TestRunner.RunTestScript($"Test-GetAzHPCCacheStorageTargetByNameAndResourceGroup {this.fixture.ResourceGroup.Name} {this.fixture.Cache.Name} {this.storageAccountFixture.StorageTarget.Name}");
        }

        /// <summary>
        /// Test Set-AzHpcCacheST by resource group, cachenme, storagetarget.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetStorgeTarget()
        {
            TestRunner.RunTestScript($"Test-SetStorageTarget {this.fixture.ResourceGroup.Name} {this.fixture.Cache.Name} {this.storageAccountFixture.StorageTarget.Name}");
        }

        /// <summary>
        /// Test New Set Remove and Get resource group, cachenme, storagetarget.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewGetSetRemoveST()
        {
            TestRunner.RunTestScript($"Test-New-Get-Remove-StorageTarget {this.fixture.ResourceGroup.Name} {this.fixture.Cache.Name} {this.fixture.SubscriptionID}");
        }
    }
}
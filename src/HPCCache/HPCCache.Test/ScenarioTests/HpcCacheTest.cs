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
    public class HpcCacheTest
    {
        /// <summary>
        /// Defines the testOutputHelper.
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly HpcCacheTestFixture fixture;

        /// <summary>
        /// XunitTracingInterceptor.
        /// </summary>
        private readonly XunitTracingInterceptor logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HpcCacheTest"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="HpcCacheTestFixture"/>.</param>
        public HpcCacheTest(ITestOutputHelper testOutputHelper, HpcCacheTestFixture fixture)
        {
            this.fixture = fixture;
            this.testOutputHelper = testOutputHelper;
            this.logger = new XunitTracingInterceptor(this.testOutputHelper);
            XunitTracingInterceptor.AddToContext(this.logger);
        }

        /// <summary>
        /// Test Get-AzHpcCache by resource group and name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCacheByResourceGroupAndName()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0} {1} {2}",
                    "Test-GetAzHPCCacheByNameAndResourceGroup",
                    this.fixture.ResourceGroup.Name,
                    this.fixture.Cache.Name),
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }

        /// <summary>
        /// Test Flush-AzHpcCache by resource group and name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlushCache()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0} {1} {2}",
                    "Test-FlushCache",
                    this.fixture.ResourceGroup.Name,
                    this.fixture.Cache.Name),
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }

        /// <summary>
        /// Test Start/Stop-AzHpcCache by resource group and name.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopCache()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0} {1} {2}",
                    "Test-Stop-Start-Cache",
                    this.fixture.ResourceGroup.Name,
                    this.fixture.Cache.Name),
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }


        /// <summary>
        /// Test New-AzHpcCache and Remove-AzHpcCache.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewCacheRemoveCache()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0} {1} {2} {3} {4} {5}",
                    "Test-NewCache-RemoveCache",
                    this.fixture.ResourceGroup.Name,
                    this.fixture.SubscriptionID,
                    this.fixture.ResourceGroup.Location,
                    this.fixture.VirtualNetwork.Name,
                    this.fixture.SubNet.Name)
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }

        /// <summary>
        /// Test Set-AzHpcCache by resource group and name.
        /// </summary>
        [Fact(Skip = "Bug in SetCache if cache has no tags, causes null pointer exception - internal server error.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetCache()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0} {1} {2}",
                    "Test-SetCache",
                    this.fixture.ResourceGroup.Name,
                    this.fixture.Cache.Name),
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }

        /// <summary>
        /// Test Get-AzHpcCacheUsageModel.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetUsageModel()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0}",
                    "Test-GetUsageModel"),
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }

        /// <summary>
        /// Test Get-AzHpcCacheSku.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSku()
        {
            var scripts = new string[]
            {
                string.Format(
                    "{0}",
                    "Test-GetSku"),
            };
            HpcCacheController.NewInstance.RunPsTest(this.logger, scripts);
        }
    }
}
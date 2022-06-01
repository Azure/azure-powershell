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

namespace Microsoft.Azure.Commands.Marketplace.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class PrivateStoreTests : MarketplaceTestRunner
    {
        public PrivateStoreTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStores()
        {
            TestRunner.RunTestScript("Test-GetAzMarketplacePrivateStore");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStoreOffers()
        {
            TestRunner.RunTestScript("Test-GetAzMarketplacePrivateStoreOffers");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStoreOffer()
        {
            TestRunner.RunTestScript("Test-GetAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePrivateStoreOffer()
        {
            TestRunner.RunTestScript("Test-RemoveAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePrivateStoreOffer()
        {
            TestRunner.RunTestScript("Test-CreateAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePrivateStoreOffer()
        {
            TestRunner.RunTestScript("Test-UpdateAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePrivateStorePrivateOffer()
        {
            TestRunner.RunTestScript("Test-UpdateAzMarketplacePrivateStorePrivateOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStorePrivateOffer()
        {
            TestRunner.RunTestScript("Test-GetAzMarketplacePrivateStorePrivateOffers");
        }
    }
}

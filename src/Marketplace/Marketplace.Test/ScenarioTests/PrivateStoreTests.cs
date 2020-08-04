﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class PrivateStoreTests
    {
        private readonly XunitTracingInterceptor _logger;

        public PrivateStoreTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStores()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzMarketplacePrivateStore");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStoreOffers()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzMarketplacePrivateStoreOffers");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStoreOffer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePrivateStoreOffer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePrivateStoreOffer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePrivateStoreOffer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateAzMarketplacePrivateStoreOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePrivateStorePrivateOffer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateAzMarketplacePrivateStorePrivateOffer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateStorePrivateOffer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetAzMarketplacePrivateStorePrivateOffers");
        }
    }
}

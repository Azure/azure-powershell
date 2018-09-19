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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using CommonScenarioTest = Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Store;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.MarketplaceServiceReference;
using Microsoft.WindowsAzure.Commands.Utilities.Store;
using Microsoft.WindowsAzure.Management.Models;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.Store
{
    using Resource = Management.Store.Models.CloudServiceListResponse.CloudService.AddOnResource;

    
    public class GetAzureStoreAddOnTests : SMTestBase
    {
        Mock<ICommandRuntime> mockCommandRuntime;

        Mock<StoreClient> mockStoreClient;

        Mock<MarketplaceClient> mockMarketplaceClient;

        GetAzureStoreAddOnCommand cmdlet;

        public GetAzureStoreAddOnTests()
        {
            new FileSystemHelper(this).CreateAzureSdkDirectoryAndImportPublishSettings();
            mockCommandRuntime = new Mock<ICommandRuntime>();
            mockStoreClient = new Mock<StoreClient>();
            mockMarketplaceClient = new Mock<MarketplaceClient>();
            cmdlet = new GetAzureStoreAddOnCommand()
            {
                StoreClient = mockStoreClient.Object,
                CommandRuntime = mockCommandRuntime.Object,
                MarketplaceClient = mockMarketplaceClient.Object
            };
        }

        [Fact]
        [Trait(CommonScenarioTest.Category.AcceptanceType, CommonScenarioTest.Category.CheckIn)]
        public void GetAzureStoreAddOnAvailableAddOnsSuccessfull()
        {
            // Setup
            List<WindowsAzureOffer> actualWindowsAzureOffers = new List<WindowsAzureOffer>();
            mockCommandRuntime.Setup(f => f.WriteObject(It.IsAny<object>(), true))
                .Callback<object, bool>((o, b) => actualWindowsAzureOffers = (List<WindowsAzureOffer>)o);
            List<Plan> plans = new List<Plan>();
            plans.Add(new Plan() { PlanIdentifier = "Bronze" });
            plans.Add(new Plan() { PlanIdentifier = "Silver" });
            plans.Add(new Plan() { PlanIdentifier = "Gold" });
            plans.Add(new Plan() { PlanIdentifier = "Silver" });
            plans.Add(new Plan() { PlanIdentifier = "Gold" });

            List<Offer> expectedOffers = new List<Offer>()
            {
                new Offer() { ProviderIdentifier = "Microsoft", OfferIdentifier = "Bing Translate",
                    ProviderId = new Guid("f8ede0df-591f-4722-b646-e5eb86f0ae52") },
                new Offer() { ProviderIdentifier = "NotExistingCompany", OfferIdentifier = "Not Existing Name",
                    ProviderId = new Guid("723138c2-0676-4bf6-80d4-0af31479dac4")},
                new Offer() { ProviderIdentifier = "OneSDKCompany", OfferIdentifier = "Microsoft Azure PowerShell",
                    ProviderId = new Guid("1441f7f7-33a1-4dcf-aeea-8ed8bc1b2e3d") }
            };
            List<WindowsAzureOffer> expectedWindowsAzureOffers = new List<WindowsAzureOffer>();
            expectedOffers.ForEach(o => expectedWindowsAzureOffers.Add(new WindowsAzureOffer(
                o,
                plans,
                new List<string>() { "West US", "East US" })));

            mockMarketplaceClient.Setup(f => f.GetAvailableWindowsAzureOffers(It.IsAny<string>()))
                .Returns(expectedWindowsAzureOffers);
            mockMarketplaceClient.Setup(f => f.IsKnownProvider(It.IsAny<Guid>())).Returns(true);

            mockStoreClient.Setup(f => f.GetLocations())
                .Returns(new List<LocationsListResponse.Location>() 
                {
                    new LocationsListResponse.Location() { Name = "West US" },
                    new LocationsListResponse.Location() { Name = "East US" } 
                });
            cmdlet.ListAvailable = true;

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            mockMarketplaceClient.Verify(f => f.GetAvailableWindowsAzureOffers(null), Times.Once());
            Assert.Equal(expectedWindowsAzureOffers, actualWindowsAzureOffers);
        }

        [Fact]
        [Trait(CommonScenarioTest.Category.AcceptanceType, CommonScenarioTest.Category.CheckIn)]
        public void GetAzureStoreAddOnWithEmptyCloudService()
        {
            // Setup
            List<WindowsAzureAddOn> expected = new List<WindowsAzureAddOn>();
            mockStoreClient.Setup(f => f.GetAddOn(It.IsAny<AddOnSearchOptions>())).Returns(expected);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            mockStoreClient.Verify(f => f.GetAddOn(new AddOnSearchOptions(null, null, null)), Times.Once());
            mockCommandRuntime.Verify(f => f.WriteObject(expected, true), Times.Once());
        }

        [Fact]
        [Trait(CommonScenarioTest.Category.AcceptanceType, CommonScenarioTest.Category.CheckIn)]
        public void GetAzureStoreAddOnWithoutSearchOptions()
        {
            // Setup
            List<WindowsAzureAddOn> expected = new List<WindowsAzureAddOn>()
            { 
                new WindowsAzureAddOn(new Resource() { Name = "BingSearchAddOn" }, "West US", "StoreCloudService"),
                new WindowsAzureAddOn(new Resource() { Name = "BingTranslateAddOn" }, "West US", "StoreCloudService")
            };
            mockCommandRuntime.Setup(f => f.WriteObject(It.IsAny<object>(), true));
            mockStoreClient.Setup(f => f.GetAddOn(It.IsAny<AddOnSearchOptions>())).Returns(expected);

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            mockStoreClient.Verify(f => f.GetAddOn(new AddOnSearchOptions(null, null, null)), Times.Once());
            mockCommandRuntime.Verify(f => f.WriteObject(expected, true), Times.Once());
        }

        [Fact]
        [Trait(CommonScenarioTest.Category.AcceptanceType, CommonScenarioTest.Category.CheckIn)]
        public void GetAzureStoreAddOnWithNameFilter()
        {
            // Setup
            List<WindowsAzureAddOn> expected = new List<WindowsAzureAddOn>()
            {
                new WindowsAzureAddOn(new Resource() { Name = "BingTranslateAddOn" }, "West US", "StoreCloudService")
            };
            mockCommandRuntime.Setup(f => f.WriteObject(It.IsAny<object>(), true));
            mockStoreClient.Setup(f => f.GetAddOn(new AddOnSearchOptions("BingTranslateAddOn", null, null)))
                .Returns(expected);
            cmdlet.Name = "BingTranslateAddOn";

            // Test
            cmdlet.ExecuteCmdlet();

            // Assert
            mockStoreClient.Verify(
                f => f.GetAddOn(new AddOnSearchOptions("BingTranslateAddOn", null, null)),
                Times.Once());
            mockCommandRuntime.Verify(f => f.WriteObject(expected, true), Times.Once());
        }
    }
}
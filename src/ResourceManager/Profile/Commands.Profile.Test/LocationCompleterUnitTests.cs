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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class LocationCompleterUnitTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsErrorForEmptyResourceTypeList()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            var ex = Assert.Throws<Exception>(() => LocationCompleterAttribute.FindLocations(new string[] { }, resourceTypeLocationDictionary));
            Assert.Equal(ex.Message, "No valid ResourceType given to LocationCompleter.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsErrorForInvalidResourceType()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            var ex = Assert.Throws<Exception>(() => LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.InvalidResourceType/operations" }, resourceTypeLocationDictionary));
            Assert.Equal(ex.Message, "ResourceType name: 'Microsoft.InvalidResourceType/operations' is invalid.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsErrorForResourceTypeWithNoLocation()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            var ex = Assert.Throws<Exception>(() => LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock1" }, resourceTypeLocationDictionary));
            Assert.Equal(ex.Message, "No locations exist for all of the given ResourceTypes.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsLocationForResourceTypeWithOneLocation()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock2" }, resourceTypeLocationDictionary), new string[] { "\'westus\'" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsAllLocationForResourceTypeWithMultipleLocations()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock3" }, resourceTypeLocationDictionary), new string[] { "\'westus\'", "\'centralus\'" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsErrorForResourceTypesWithNoOverlap()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            var ex = Assert.Throws<Exception>(() => LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock3", "Microsoft.Mock/mock5" }, resourceTypeLocationDictionary));
            Assert.Equal(ex.Message, "No locations exist for all of the given ResourceTypes.");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsOverlapForMultipleResourceTypes()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock3", "Microsoft.Mock/mock4" }, resourceTypeLocationDictionary), new string[] { "\'westus\'" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsFullOverlapForMultipleResourceTypes()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock5", "Microsoft.Mock/mock6" }, resourceTypeLocationDictionary), new string[] { "\'eastus\'", "\'china\'" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LocationListRecognizesDifferentFormats()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock3", "Microsoft.Mock/mock7" }, resourceTypeLocationDictionary), new string[] { "\'westus\'", "\'centralus\'" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsLocationForLowercaseProvider()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "microsofT.mock/mock2" }, resourceTypeLocationDictionary), new string[] { "\'westus\'" });
        }

        public IDictionary<string, ICollection<string>> SetMockDictionary()
        {
            IDictionary<string, ICollection<string>> resourceTypeLocationDictionary = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock1", new List<string>());
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock2", new List<string>() { "westus" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock3", new List<string>() { "westus", "centralus" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock4", new List<string>() { "westus", "eastus" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock5", new List<string>() { "eastus", "china" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock6", new List<string>() { "eastus", "china" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock7", new List<string>() { "West US", "Central-US" });
            return resourceTypeLocationDictionary;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsEmptyDictionaryForNoProviders()
        {
            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(new List<Provider>());
            Assert.Empty(resourceTypeLocationDictionary);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDictionaryForProviderWithNoResourceTypes()
        {
            List<Provider> ProviderList = new List<Provider>();
            var provider = new Provider(
                namespaceProperty: "Microsoft.Mock",
                resourceTypes: new ProviderResourceType[] { });
            ProviderList.Add(provider);

            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(ProviderList);

            Assert.Empty(resourceTypeLocationDictionary);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDictionaryForProviderWithNoLocations()
        {
            List<Provider> ProviderList = new List<Provider>();
            var provider = new Provider(
                namespaceProperty: "Microsoft.Mock",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new string[] {},
                        ResourceType = "mock1",
                    }

                });
            ProviderList.Add(provider);

            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(ProviderList);

            var matchingDictionary = new ConcurrentDictionary<string, ICollection<string>>();
            matchingDictionary.TryAdd("Microsoft.Mock/mock1", new string[] { });
            Assert.Equal(resourceTypeLocationDictionary, matchingDictionary);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDictionaryForProviderWithOneLocation()
        {
            List<Provider> ProviderList = new List<Provider>();
            var provider = new Provider(
                namespaceProperty: "Microsoft.Mock",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock1",
                    }

                });
            ProviderList.Add(provider);

            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(ProviderList);

            var matchingDictionary = new ConcurrentDictionary<string, ICollection<string>>();
            matchingDictionary.TryAdd("Microsoft.Mock/mock1", new string[] { "westus" });
            Assert.Equal(resourceTypeLocationDictionary, matchingDictionary);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDictionaryForProviderWithMultipleLocations()
        {
            List<Provider> ProviderList = new List<Provider>();
            var provider = new Provider(
                namespaceProperty: "Microsoft.Mock",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus", "centralus"},
                        ResourceType = "mock1",
                    }

                });
            ProviderList.Add(provider);

            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(ProviderList);

            var matchingDictionary = new ConcurrentDictionary<string, ICollection<string>>();
            matchingDictionary.TryAdd("Microsoft.Mock/mock1", new string[] { "westus", "centralus" });
            Assert.Equal(resourceTypeLocationDictionary, matchingDictionary);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDictionaryForProviderWitMultipleResourceTypes()
        {
            List<Provider> ProviderList = new List<Provider>();
            var provider = new Provider(
                namespaceProperty: "Microsoft.Mock",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock1",
                    },
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock2",
                    }

                });
            ProviderList.Add(provider);

            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(ProviderList);

            var matchingDictionary = new ConcurrentDictionary<string, ICollection<string>>();
            matchingDictionary.TryAdd("Microsoft.Mock/mock1", new string[] { "westus" });
            matchingDictionary.TryAdd("Microsoft.Mock/mock2", new string[] { "westus" });
            Assert.Equal(resourceTypeLocationDictionary, matchingDictionary);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConstructsDictionaryForMultipleProviders()
        {
            List<Provider> ProviderList = new List<Provider>();
            var provider = new Provider(
                namespaceProperty: "Microsoft.Mock1",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock1",
                    },
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock2",
                    }

                });
            ProviderList.Add(provider);
            provider = new Provider(
                namespaceProperty: "Microsoft.Mock2",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock1",
                    },
                    new ProviderResourceType
                    {
                        Locations = new[] {"westus"},
                        ResourceType = "mock2",
                    }

                });
            ProviderList.Add(provider);

            var resourceTypeLocationDictionary = LocationCompleterAttribute.CreateLocationDictionary(ProviderList);

            var matchingDictionary = new ConcurrentDictionary<string, ICollection<string>>();
            matchingDictionary.TryAdd("Microsoft.Mock1/mock1", new string[] { "westus" });
            matchingDictionary.TryAdd("Microsoft.Mock1/mock2", new string[] { "westus" });
            matchingDictionary.TryAdd("Microsoft.Mock2/mock1", new string[] { "westus" });
            matchingDictionary.TryAdd("Microsoft.Mock2/mock2", new string[] { "westus" });
            Assert.Equal(resourceTypeLocationDictionary, matchingDictionary);
        }
    }
}
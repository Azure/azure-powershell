
using Microsoft.Azure.Commands.ResourceManager.Common.Location;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class LocationCompleterTests
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
            Assert.Equal(ex.Message, "ResourceType name: Microsoft.InvalidResourceType/operations is invalid.");
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

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock2" }, resourceTypeLocationDictionary), new string[] { "westus" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsAllLocationForResourceTypeWithMultipleLocations()
        {
            var resourceTypeLocationDictionary = SetMockDictionary();

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock3" }, resourceTypeLocationDictionary), new string[] { "westus", "centralus" });
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

            Assert.Equal(LocationCompleterAttribute.FindLocations(new string[] { "Microsoft.Mock/mock3", "Microsoft.Mock/mock4" }, resourceTypeLocationDictionary), new string[] { "westus" });
        }

        public Dictionary<string, ICollection<string>> SetMockDictionary()
        {
            Dictionary<string, ICollection<string>> resourceTypeLocationDictionary = new Dictionary<string, ICollection<string>>(StringComparer.OrdinalIgnoreCase);
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock1", new List<string>());
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock2", new List<string>() { "westus" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock3", new List<string>() { "westus", "centralus" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock4", new List<string>() { "westus", "eastus" });
            resourceTypeLocationDictionary.Add("Microsoft.Mock/mock5", new List<string>() { "eastus", "china" });
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

            var matchingDictionary = new Dictionary<string, ICollection<string>>();
            matchingDictionary.Add("Microsoft.Mock/mock1", new string[] { });
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

            var matchingDictionary = new Dictionary<string, ICollection<string>>();
            matchingDictionary.Add("Microsoft.Mock/mock1", new string[] { "westus" });
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

            var matchingDictionary = new Dictionary<string, ICollection<string>>();
            matchingDictionary.Add("Microsoft.Mock/mock1", new string[] { "westus", "centralus" });
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

            var matchingDictionary = new Dictionary<string, ICollection<string>>();
            matchingDictionary.Add("Microsoft.Mock/mock1", new string[] { "westus" });
            matchingDictionary.Add("Microsoft.Mock/mock2", new string[] { "westus" });
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

            var matchingDictionary = new Dictionary<string, ICollection<string>>();
            matchingDictionary.Add("Microsoft.Mock1/mock1", new string[] { "westus" });
            matchingDictionary.Add("Microsoft.Mock1/mock2", new string[] { "westus" });
            matchingDictionary.Add("Microsoft.Mock2/mock1", new string[] { "westus" });
            matchingDictionary.Add("Microsoft.Mock2/mock2", new string[] { "westus" });
            Assert.Equal(resourceTypeLocationDictionary, matchingDictionary);
        }
    }
}
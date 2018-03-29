using Microsoft.Azure.Commands.ApiManagement.Models;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.ApiManagement.Test.UnitTests
{
    public class PsApiManagementTests
    {
        public PsApiManagementTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCtor()
        {
            // arrange
            var resource = new ApiManagementServiceResource
            {
                Location = "location",
                Tags = new Dictionary<string, string>()
                {
                    {"tagkey1", "tagvalue1" },
                    {"tagkey2", "tagvalue2" }
                },
                Sku = new ApiManagementServiceSkuProperties
                {
                    Capacity = 3,
                    Name = SkuType.Premium
                },
                AdditionalLocations = new List<AdditionalLocation>()
                {
                    new AdditionalLocation
                    {
                        Location = "region location",
                        Sku = new ApiManagementServiceSkuProperties()
                        {
                            Name = SkuType.Premium,
                            Capacity = 2
                        },
                        VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                        {
                            SubnetResourceId = "region subnet resourceId"
                        }
                    }
                },
                NotificationSenderEmail = "addresser@email.com",
                CustomProperties = new Dictionary<string, string>()
                {
                    { "cpkey1", "cpvalue1" },
                    { "cpkey2", "cpvalue2" }
                },
                HostnameConfigurations = new List<HostnameConfiguration>()
                {
                    new HostnameConfiguration
                    {
                        Type = HostnameType.Portal,
                        HostName = "portal hostname"
                    },
                    new HostnameConfiguration
                    {
                        Type = HostnameType.Proxy,
                        HostName = "proxy hostname"
                    }
                },
                PublisherEmail = "publisher@email.com",
                PublisherName = "publisher name",
                VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                {
                    SubnetResourceId = "region subnet resourceId"
                }
            };

            // act
            var result = new PsApiManagement(resource);

            // assert
            Assert.Equal(resource.Id, result.Id);
            Assert.Equal(resource.Location, result.Location);
            Assert.Equal(resource.Name, result.Name);
            Assert.Equal(resource.Tags.Count, result.Tags.Count);
            foreach (var tagKey in resource.Tags.Keys)
            {
                Assert.Equal(resource.Tags[tagKey], result.Tags[tagKey]);
            }

            Assert.Equal(resource.AdditionalLocations.Count, result.AdditionalRegions.Count);
            var resourceRegion = resource.AdditionalLocations[0];
            var resultRegion = result.AdditionalRegions[0];
            Assert.Equal(resourceRegion.Location, resultRegion.Location);
            Assert.Equal(resourceRegion.Sku.Name, resultRegion.Sku.ToString());
            Assert.Equal(resourceRegion.Sku.Capacity, resultRegion.Capacity);
            Assert.Equal(resourceRegion.VirtualNetworkConfiguration.SubnetResourceId, resultRegion.VirtualNetwork.SubnetResourceId);

            var portalHostname = resource.HostnameConfigurations.Single(h => h.Type == HostnameType.Portal);
            Assert.Equal(portalHostname.HostName, result.PortalHostnameConfiguration.Hostname);
            Assert.Equal(portalHostname.Certificate.Expiry, result.PortalHostnameConfiguration.HostnameCertificate.Expiry);
            Assert.Equal(portalHostname.Certificate.Subject, result.PortalHostnameConfiguration.HostnameCertificate.Subject);
            Assert.Equal(portalHostname.Certificate.Thumbprint, result.PortalHostnameConfiguration.HostnameCertificate.Thumbprint);

            var proxyHostname = resource.HostnameConfigurations.Single(h => h.Type == HostnameType.Proxy);
            Assert.Equal(proxyHostname.HostName, result.ProxyHostnameConfiguration.Hostname);
            Assert.Equal(proxyHostname.Certificate.Expiry, result.ProxyHostnameConfiguration.HostnameCertificate.Expiry);
            Assert.Equal(proxyHostname.Certificate.Subject, result.ProxyHostnameConfiguration.HostnameCertificate.Subject);
            Assert.Equal(proxyHostname.Certificate.Thumbprint, result.ProxyHostnameConfiguration.HostnameCertificate.Thumbprint);
            
            Assert.Equal(resource.VirtualNetworkConfiguration.SubnetResourceId, result.VirtualNetwork.SubnetResourceId);

            Assert.Equal(resource.ProvisioningState, result.ProvisioningState);
            Assert.Equal(resource.Sku.Name, result.Sku.ToString());
            Assert.Equal(resource.Sku.Capacity, result.Capacity);
        }
    }
}

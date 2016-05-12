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
            var resource = new ApiServiceResource
            {
                ETag = "etag",
                Id = "id",
                Location = "location",
                Name = "name",
                Type = "resource type",
                Tags = new Dictionary<string, string>()
                {
                    {"tagkey1", "tagvalue1" },
                    {"tagkey2", "tagvalue2" }
                },
                Properties = new ApiServiceProperties
                {
                    AdditionalRegions = new List<AdditionalRegion>()
                    {
                        new AdditionalRegion
                        {
                            Location = "region location",
                            SkuType = SkuType.Premium,
                            SkuUnitCount = 2,
                            StaticIPs = new List<string>() { "192.168.1.1", "192.168.1.1" },
                            VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                            {
                                Location = "region vpn location",
                                SubnetName = "region vpn subnet name",
                                VnetId = Guid.NewGuid()
                            }
                        }
                    },
                    AddresserEmail = "addresser@email.com",
                    CreatedAtUtc = DateTime.UtcNow,
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
                            Certificate = new CertificateInformation
                            {
                                Expiry = DateTime.UtcNow.AddDays(5),
                                Subject = "portal cert subject",
                                Thumbprint = "portal cert thumbprint"
                            },
                            Hostname = "portal hostname"
                        },
                        new HostnameConfiguration
                        {
                            Type = HostnameType.Proxy,
                            Certificate = new CertificateInformation
                            {
                                Expiry = DateTime.UtcNow.AddDays(10),
                                Subject = "proxy cert subject",
                                Thumbprint = "proxy cert thumbprint"
                            },
                            Hostname = "proxy hostname"
                        }
                    },
                    ManagementPortalEndpoint = "http://management.portal.endpoint",
                    ProvisioningState = "Active",
                    ProxyEndpoint = "http://proxy.endpoint",
                    PublisherEmail = "publisher@email.com",
                    PublisherName = "publisher name",
                    SkuProperties = new ApiServiceSkuProperties
                    {
                        Capacity = 3,
                        SkuType = SkuType.Premium
                    },
                    StaticIPs = new[] { "192.168.0.1", "192.168.0.2" },
                    VirtualNetworkConfiguration = new VirtualNetworkConfiguration
                    {
                        Location = "vpn location",
                        SubnetName = "vpn subnet name",
                        VnetId = Guid.NewGuid()
                    }
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

            Assert.Equal(resource.Properties.AdditionalRegions.Count, result.AdditionalRegions.Count);
            var resourceRegion = resource.Properties.AdditionalRegions[0];
            var resultRegion = result.AdditionalRegions[0];
            Assert.Equal(resourceRegion.Location, resultRegion.Location);
            Assert.Equal(resourceRegion.SkuType.ToString(), resultRegion.Sku.ToString());
            Assert.Equal(resourceRegion.SkuUnitCount, resultRegion.Capacity);
            for (int i = 0; i < resourceRegion.StaticIPs.Count; i++)
            {
                Assert.Equal(resourceRegion.StaticIPs[i], resultRegion.StaticIPs[i]);
            }
            Assert.Equal(resourceRegion.VirtualNetworkConfiguration.Location, resultRegion.VirtualNetwork.Location);
            Assert.Equal(resourceRegion.VirtualNetworkConfiguration.SubnetName, resultRegion.VirtualNetwork.SubnetName);
            Assert.Equal(resourceRegion.VirtualNetworkConfiguration.VnetId, resultRegion.VirtualNetwork.VnetId);

            var portalHostname = resource.Properties.HostnameConfigurations.Single(h => h.Type == HostnameType.Portal);
            Assert.Equal(portalHostname.Hostname, result.PortalHostnameConfiguration.Hostname);
            Assert.Equal(portalHostname.Certificate.Expiry, result.PortalHostnameConfiguration.HostnameCertificate.Expiry);
            Assert.Equal(portalHostname.Certificate.Subject, result.PortalHostnameConfiguration.HostnameCertificate.Subject);
            Assert.Equal(portalHostname.Certificate.Thumbprint, result.PortalHostnameConfiguration.HostnameCertificate.Thumbprint);

            var proxyHostname = resource.Properties.HostnameConfigurations.Single(h => h.Type == HostnameType.Proxy);
            Assert.Equal(proxyHostname.Hostname, result.ProxyHostnameConfiguration.Hostname);
            Assert.Equal(proxyHostname.Certificate.Expiry, result.ProxyHostnameConfiguration.HostnameCertificate.Expiry);
            Assert.Equal(proxyHostname.Certificate.Subject, result.ProxyHostnameConfiguration.HostnameCertificate.Subject);
            Assert.Equal(proxyHostname.Certificate.Thumbprint, result.ProxyHostnameConfiguration.HostnameCertificate.Thumbprint);

            Assert.Equal(resource.Properties.VirtualNetworkConfiguration.Location, result.VirtualNetwork.Location);
            Assert.Equal(resource.Properties.VirtualNetworkConfiguration.SubnetName, result.VirtualNetwork.SubnetName);
            Assert.Equal(resource.Properties.VirtualNetworkConfiguration.VnetId, result.VirtualNetwork.VnetId);

            Assert.Equal(resource.Properties.ManagementPortalEndpoint, result.PortalUrl);
            Assert.Equal(resource.Properties.ProxyEndpoint, result.RuntimeUrl);
            Assert.Equal(resource.Properties.ProvisioningState, result.ProvisioningState);
            Assert.Equal(resource.Properties.SkuProperties.SkuType.ToString(), result.Sku.ToString());
            Assert.Equal(resource.Properties.SkuProperties.Capacity, result.Capacity);
        }
    }
}

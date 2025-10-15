// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSNetworkConfigurationTests
    {
        #region fromMgmtNetworkConfiguration Tests

        [Fact]
        public void FromMgmtNetworkConfiguration_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var inboundNatPools = new List<InboundNatPool>
            {
                new InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: InboundEndpointProtocol.TCP,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100)
            };

            var endpointConfiguration = new PoolEndpointConfiguration(inboundNatPools);

            var publicIPAddressConfiguration = new PublicIPAddressConfiguration(
                provision: IPAddressProvisioningType.BatchManaged,
                ipAddressIds: new List<string> { "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip1" });

            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                dynamicVnetAssignmentScope: DynamicVNetAssignmentScope.Job,
                endpointConfiguration: endpointConfiguration,
                publicIPAddressConfiguration: publicIPAddressConfiguration,
                enableAcceleratedNetworking: true);

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1", result.SubnetId);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, result.DynamicVNetAssignmentScope);
            Assert.True(result.EnableAcceleratedNetworking);
            Assert.NotNull(result.EndpointConfiguration);
            Assert.NotNull(result.PublicIPAddressConfiguration);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, result.PublicIPAddressConfiguration.Provision);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1");

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1", result.SubnetId);
            Assert.Null(result.DynamicVNetAssignmentScope);
            Assert.Null(result.EnableAcceleratedNetworking);
            Assert.Null(result.EndpointConfiguration);
            Assert.Null(result.PublicIPAddressConfiguration);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_WithNullInput_ReturnsNull()
        {
            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_WithDynamicVNetAssignmentScopeNone_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                dynamicVnetAssignmentScope: DynamicVNetAssignmentScope.None);

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, result.DynamicVNetAssignmentScope);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_WithAcceleratedNetworkingFalse_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                enableAcceleratedNetworking: false);

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.EnableAcceleratedNetworking);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_VerifyPSNetworkConfigurationType()
        {
            // Arrange
            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1");

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSNetworkConfiguration>(result);
        }

        [Theory]
        [InlineData(DynamicVNetAssignmentScope.None, Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None)]
        [InlineData(DynamicVNetAssignmentScope.Job, Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job)]
        public void FromMgmtNetworkConfiguration_AllDynamicVNetAssignmentScopes_ReturnsCorrectMapping(
            DynamicVNetAssignmentScope mgmtScope,
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope expectedPsScope)
        {
            // Arrange
            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                dynamicVnetAssignmentScope: mgmtScope);

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsScope, result.DynamicVNetAssignmentScope);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_WithComplexEndpointConfiguration_HandlesCorrectly()
        {
            // Arrange
            var networkSecurityGroupRules = new List<NetworkSecurityGroupRule>
            {
                new NetworkSecurityGroupRule(
                    priority: 100,
                    access: NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/24",
                    sourcePortRanges: new List<string> { "22" })
            };

            var inboundNatPools = new List<InboundNatPool>
            {
                new InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: InboundEndpointProtocol.TCP,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100,
                    networkSecurityGroupRules: networkSecurityGroupRules),
                new InboundNatPool(
                    name: "rdp-nat-pool",
                    protocol: InboundEndpointProtocol.TCP,
                    backendPort: 3389,
                    frontendPortRangeStart: 51000,
                    frontendPortRangeEnd: 51100)
            };

            var endpointConfiguration = new PoolEndpointConfiguration(inboundNatPools);

            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                endpointConfiguration: endpointConfiguration);

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.EndpointConfiguration);
            Assert.NotNull(result.EndpointConfiguration.InboundNatPools);
            Assert.Equal(2, result.EndpointConfiguration.InboundNatPools.Count);
        }

        [Fact]
        public void FromMgmtNetworkConfiguration_WithComplexPublicIPAddressConfiguration_HandlesCorrectly()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip1",
                "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip2"
            };

            var publicIPAddressConfiguration = new PublicIPAddressConfiguration(
                provision: IPAddressProvisioningType.UserManaged,
                ipAddressIds: ipAddressIds);

            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                publicIPAddressConfiguration: publicIPAddressConfiguration);

            // Act
            var result = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.PublicIPAddressConfiguration);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result.PublicIPAddressConfiguration.Provision);
            Assert.NotNull(result.PublicIPAddressConfiguration.IpAddressIds);
            Assert.Equal(2, result.PublicIPAddressConfiguration.IpAddressIds.Count);
        }

        #endregion

        #region toMgmtNetworkConfiguration Tests

        [Fact]
        public void ToMgmtNetworkConfiguration_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var inboundNatPools = new List<Microsoft.Azure.Batch.InboundNatPool>
            {
                new Microsoft.Azure.Batch.InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100)
            };

            var endpointConfiguration = new PSPoolEndpointConfiguration(inboundNatPools);

            var publicIPAddressConfiguration = new PSPublicIPAddressConfiguration(
                provision: Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged)
            {
                IpAddressIds = new List<string> { "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip1" }
            };

            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job,
                EndpointConfiguration = endpointConfiguration,
                PublicIPAddressConfiguration = publicIPAddressConfiguration,
                EnableAcceleratedNetworking = true
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1", result.SubnetId);
            Assert.Equal(DynamicVNetAssignmentScope.Job, result.DynamicVnetAssignmentScope);
            Assert.True(result.EnableAcceleratedNetworking);
            Assert.NotNull(result.EndpointConfiguration);
            Assert.NotNull(result.PublicIPAddressConfiguration);
            Assert.Equal(IPAddressProvisioningType.BatchManaged, result.PublicIPAddressConfiguration.Provision);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1"
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1", result.SubnetId);
            Assert.Null(result.DynamicVnetAssignmentScope);
            Assert.Null(result.EnableAcceleratedNetworking);
            Assert.Null(result.EndpointConfiguration);
            Assert.Null(result.PublicIPAddressConfiguration);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_WithDynamicVNetAssignmentScopeNone_ReturnsCorrectMapping()
        {
            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DynamicVNetAssignmentScope.None, result.DynamicVnetAssignmentScope);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_WithAcceleratedNetworkingFalse_ReturnsCorrectMapping()
        {
            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                EnableAcceleratedNetworking = false
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.EnableAcceleratedNetworking);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_VerifyNetworkConfigurationType()
        {
            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1"
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkConfiguration>(result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, DynamicVNetAssignmentScope.None)]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, DynamicVNetAssignmentScope.Job)]
        public void ToMgmtNetworkConfiguration_AllDynamicVNetAssignmentScopes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope psScope,
            DynamicVNetAssignmentScope expectedMgmtScope)
        {
            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = psScope
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtScope, result.DynamicVnetAssignmentScope);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_WithComplexEndpointConfiguration_HandlesCorrectly()
        {
            // Arrange
            var networkSecurityGroupRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/24",
                    sourcePortRanges: new List<string> { "22" })
            };

            var inboundNatPools = new List<Microsoft.Azure.Batch.InboundNatPool>
            {
                new Microsoft.Azure.Batch.InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100,
                    networkSecurityGroupRules: networkSecurityGroupRules),
                new Microsoft.Azure.Batch.InboundNatPool(
                    name: "rdp-nat-pool",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 3389,
                    frontendPortRangeStart: 51000,
                    frontendPortRangeEnd: 51100)
            };

            var endpointConfiguration = new PSPoolEndpointConfiguration(inboundNatPools);

            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                EndpointConfiguration = endpointConfiguration
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.EndpointConfiguration);
            Assert.NotNull(result.EndpointConfiguration.InboundNatPools);
            Assert.Equal(2, result.EndpointConfiguration.InboundNatPools.Count);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_WithComplexPublicIPAddressConfiguration_HandlesCorrectly()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip1",
                "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip2"
            };

            var publicIPAddressConfiguration = new PSPublicIPAddressConfiguration(
                provision: Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };

            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                PublicIPAddressConfiguration = publicIPAddressConfiguration
            };

            // Act
            var result = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.PublicIPAddressConfiguration);
            Assert.Equal(IPAddressProvisioningType.UserManaged, result.PublicIPAddressConfiguration.Provision);
            Assert.NotNull(result.PublicIPAddressConfiguration.IPAddressIds);
            Assert.Equal(2, result.PublicIPAddressConfiguration.IPAddressIds.Count);
        }

        [Fact]
        public void ToMgmtNetworkConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                EnableAcceleratedNetworking = true
            };

            // Act
            var result1 = psNetworkConfiguration.toMgmtNetworkConfiguration();
            var result2 = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalInboundNatPools = new List<Microsoft.Azure.Batch.InboundNatPool>
            {
                new Microsoft.Azure.Batch.InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100)
            };

            var originalEndpointConfiguration = new PSPoolEndpointConfiguration(originalInboundNatPools);

            var originalPublicIPAddressConfiguration = new PSPublicIPAddressConfiguration(
                provision: Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged)
            {
                IpAddressIds = new List<string> { "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip1" }
            };

            var originalPsNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job,
                EndpointConfiguration = originalEndpointConfiguration,
                PublicIPAddressConfiguration = originalPublicIPAddressConfiguration,
                EnableAcceleratedNetworking = true
            };

            // Act
            var mgmtNetworkConfiguration = originalPsNetworkConfiguration.toMgmtNetworkConfiguration();
            var roundTripPsNetworkConfiguration = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(roundTripPsNetworkConfiguration);
            Assert.Equal(originalPsNetworkConfiguration.SubnetId, roundTripPsNetworkConfiguration.SubnetId);
            Assert.Equal(originalPsNetworkConfiguration.DynamicVNetAssignmentScope, roundTripPsNetworkConfiguration.DynamicVNetAssignmentScope);
            Assert.Equal(originalPsNetworkConfiguration.EnableAcceleratedNetworking, roundTripPsNetworkConfiguration.EnableAcceleratedNetworking);
            Assert.NotNull(roundTripPsNetworkConfiguration.EndpointConfiguration);
            Assert.NotNull(roundTripPsNetworkConfiguration.PublicIPAddressConfiguration);
            Assert.Equal(originalPsNetworkConfiguration.PublicIPAddressConfiguration.Provision, roundTripPsNetworkConfiguration.PublicIPAddressConfiguration.Provision);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalInboundNatPools = new List<InboundNatPool>
            {
                new InboundNatPool(
                    name: "rdp-nat-pool",
                    protocol: InboundEndpointProtocol.TCP,
                    backendPort: 3389,
                    frontendPortRangeStart: 51000,
                    frontendPortRangeEnd: 51100)
            };

            var originalEndpointConfiguration = new PoolEndpointConfiguration(originalInboundNatPools);

            var originalPublicIPAddressConfiguration = new PublicIPAddressConfiguration(
                provision: IPAddressProvisioningType.UserManaged,
                ipAddressIds: new List<string> { "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/publicIPAddresses/ip1" });

            var originalMgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                dynamicVnetAssignmentScope: DynamicVNetAssignmentScope.None,
                endpointConfiguration: originalEndpointConfiguration,
                publicIPAddressConfiguration: originalPublicIPAddressConfiguration,
                enableAcceleratedNetworking: false);

            // Act
            var psNetworkConfiguration = PSNetworkConfiguration.fromMgmtNetworkConfiguration(originalMgmtNetworkConfiguration);
            var roundTripMgmtNetworkConfiguration = psNetworkConfiguration.toMgmtNetworkConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtNetworkConfiguration);
            Assert.Equal(originalMgmtNetworkConfiguration.SubnetId, roundTripMgmtNetworkConfiguration.SubnetId);
            Assert.Equal(originalMgmtNetworkConfiguration.DynamicVnetAssignmentScope, roundTripMgmtNetworkConfiguration.DynamicVnetAssignmentScope);
            Assert.Equal(originalMgmtNetworkConfiguration.EnableAcceleratedNetworking, roundTripMgmtNetworkConfiguration.EnableAcceleratedNetworking);
            Assert.NotNull(roundTripMgmtNetworkConfiguration.EndpointConfiguration);
            Assert.NotNull(roundTripMgmtNetworkConfiguration.PublicIPAddressConfiguration);
            Assert.Equal(originalMgmtNetworkConfiguration.PublicIPAddressConfiguration.Provision, roundTripMgmtNetworkConfiguration.PublicIPAddressConfiguration.Provision);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None)]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job)]
        public void RoundTripConversion_AllDynamicVNetAssignmentScopes_PreservesOriginalValues(
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope originalScope)
        {
            // Arrange
            var originalPsNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = originalScope
            };

            // Act
            var mgmtNetworkConfiguration = originalPsNetworkConfiguration.toMgmtNetworkConfiguration();
            var roundTripPsNetworkConfiguration = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(roundTripPsNetworkConfiguration);
            Assert.Equal(originalScope, roundTripPsNetworkConfiguration.DynamicVNetAssignmentScope);
        }

        [Fact]
        public void RoundTripConversion_WithNullOptionalProperties_PreservesNullValues()
        {
            // Arrange
            var originalPsNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1"
            };

            // Act
            var mgmtNetworkConfiguration = originalPsNetworkConfiguration.toMgmtNetworkConfiguration();
            var roundTripPsNetworkConfiguration = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert
            Assert.NotNull(roundTripPsNetworkConfiguration);
            Assert.Null(roundTripPsNetworkConfiguration.DynamicVNetAssignmentScope);
            Assert.Null(roundTripPsNetworkConfiguration.EnableAcceleratedNetworking);
            Assert.Null(roundTripPsNetworkConfiguration.EndpointConfiguration);
            Assert.Null(roundTripPsNetworkConfiguration.PublicIPAddressConfiguration);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void NetworkConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test full network configuration with endpoint and public IP configurations
            var inboundNatPools = new List<Microsoft.Azure.Batch.InboundNatPool>
            {
                new Microsoft.Azure.Batch.InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100)
            };

            var endpointConfiguration = new PSPoolEndpointConfiguration(inboundNatPools);

            var publicIPAddressConfiguration = new PSPublicIPAddressConfiguration(
                provision: Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            var fullPsNetworkConfig = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job,
                EndpointConfiguration = endpointConfiguration,
                PublicIPAddressConfiguration = publicIPAddressConfiguration,
                EnableAcceleratedNetworking = true
            };

            var fullMgmtNetworkConfig = fullPsNetworkConfig.toMgmtNetworkConfiguration();
            var backToPs = PSNetworkConfiguration.fromMgmtNetworkConfiguration(fullMgmtNetworkConfig);

            Assert.Equal(DynamicVNetAssignmentScope.Job, fullMgmtNetworkConfig.DynamicVnetAssignmentScope);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, backToPs.DynamicVNetAssignmentScope);
            Assert.True(fullMgmtNetworkConfig.EnableAcceleratedNetworking);
            Assert.True(backToPs.EnableAcceleratedNetworking);
            Assert.Equal(fullPsNetworkConfig.SubnetId, backToPs.SubnetId);

            // Test minimal network configuration
            var minimalPsNetworkConfig = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1"
            };

            var minimalMgmtNetworkConfig = minimalPsNetworkConfig.toMgmtNetworkConfiguration();
            var backToPsMinimal = PSNetworkConfiguration.fromMgmtNetworkConfiguration(minimalMgmtNetworkConfig);

            Assert.Equal(minimalPsNetworkConfig.SubnetId, minimalMgmtNetworkConfig.SubnetId);
            Assert.Equal(minimalPsNetworkConfig.SubnetId, backToPsMinimal.SubnetId);
            Assert.Null(backToPsMinimal.DynamicVNetAssignmentScope);
            Assert.Null(backToPsMinimal.EnableAcceleratedNetworking);
        }

        [Fact]
        public void NetworkConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSNetworkConfiguration.fromMgmtNetworkConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void NetworkConfigurationConversions_BatchPoolNetworkingContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool networking configuration
            // NetworkConfiguration is used to configure virtual network settings for Azure Batch pools

            // Arrange - Test with realistic Batch pool networking scenarios
            var poolNetworkingScenarios = new[]
            {
                // Basic VNet integration with accelerated networking
                new {
                    SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/batch-vnet/subnets/batch-subnet",
                    DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None,
                    EnableAcceleratedNetworking = true,
                    Description = "Basic VNet integration with accelerated networking for high-performance workloads"
                },
                // Job-level dynamic VNet assignment for multi-tenant scenarios
                new {
                    SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/multi-tenant-vnet/subnets/tenant-subnet",
                    DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job,
                    EnableAcceleratedNetworking = false,
                    Description = "Job-level dynamic VNet assignment for multi-tenant isolation"
                },
                // Private pool with no public IP addresses
                new {
                    SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/private-vnet/subnets/private-subnet",
                    DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None,
                    EnableAcceleratedNetworking = false,
                    Description = "Private pool configuration with no public IP addresses"
                }
            };

            foreach (var scenario in poolNetworkingScenarios)
            {
                // Act
                var psNetworkConfiguration = new PSNetworkConfiguration()
                {
                    SubnetId = scenario.SubnetId,
                    DynamicVNetAssignmentScope = scenario.DynamicVNetAssignmentScope,
                    EnableAcceleratedNetworking = scenario.EnableAcceleratedNetworking
                };

                var mgmtNetworkConfiguration = psNetworkConfiguration.toMgmtNetworkConfiguration();

                // Assert - Should convert correctly for Batch pool networking configuration
                Assert.NotNull(mgmtNetworkConfiguration);
                Assert.Equal(scenario.SubnetId, mgmtNetworkConfiguration.SubnetId);
                Assert.Equal(scenario.EnableAcceleratedNetworking, mgmtNetworkConfiguration.EnableAcceleratedNetworking);

                var expectedMgmtScope = scenario.DynamicVNetAssignmentScope == Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None
                    ? DynamicVNetAssignmentScope.None
                    : DynamicVNetAssignmentScope.Job;
                Assert.Equal(expectedMgmtScope, mgmtNetworkConfiguration.DynamicVnetAssignmentScope);

                // Verify round-trip conversion maintains pool networking semantics
                var backToPs = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.SubnetId, backToPs.SubnetId);
                Assert.Equal(scenario.DynamicVNetAssignmentScope, backToPs.DynamicVNetAssignmentScope);
                Assert.Equal(scenario.EnableAcceleratedNetworking, backToPs.EnableAcceleratedNetworking);
            }
        }

        [Fact]
        public void NetworkConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psPublicIPAddressConfiguration = new PSPublicIPAddressConfiguration(
                provision: Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged);

            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                PublicIPAddressConfiguration = psPublicIPAddressConfiguration,
                EnableAcceleratedNetworking = true
            };

            var mgmtPublicIPAddressConfiguration = new PublicIPAddressConfiguration(
                provision: IPAddressProvisioningType.BatchManaged);

            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet2",
                publicIPAddressConfiguration: mgmtPublicIPAddressConfiguration,
                enableAcceleratedNetworking: false);

            // Act
            var mgmtResult = psNetworkConfiguration.toMgmtNetworkConfiguration();
            var psResult = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<NetworkConfiguration>(mgmtResult);
            Assert.IsType<PSNetworkConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtNetworkConfiguration, mgmtResult);
            Assert.NotSame(psNetworkConfiguration, psResult);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void NetworkConfigurationConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                EnableAcceleratedNetworking = true
            };

            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet2",
                enableAcceleratedNetworking: false);

            // Act
            var mgmtResult = psNetworkConfiguration.toMgmtNetworkConfiguration();
            var psResult = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

            // Assert - Verify correct types are returned
            Assert.IsType<NetworkConfiguration>(mgmtResult);
            Assert.IsType<PSNetworkConfiguration>(psResult);
        }

        [Fact]
        public void NetworkConfigurationConversions_SubnetIdValues_HandleValidFormats()
        {
            // Test that various subnet ID formats are handled correctly

            var subnetIdFormats = new[]
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                "/subscriptions/87654321-4321-4321-4321-cba987654321/resourceGroups/batch-rg/providers/Microsoft.Network/virtualNetworks/batch-vnet/subnets/batch-subnet",
                "/subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/test-rg/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/default"
            };

            foreach (var subnetId in subnetIdFormats)
            {
                // Arrange
                var psNetworkConfiguration = new PSNetworkConfiguration()
                {
                    SubnetId = subnetId
                };

                // Act
                var mgmtNetworkConfiguration = psNetworkConfiguration.toMgmtNetworkConfiguration();
                var roundTripPsNetworkConfiguration = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

                // Assert
                Assert.Equal(subnetId, mgmtNetworkConfiguration.SubnetId);
                Assert.Equal(subnetId, roundTripPsNetworkConfiguration.SubnetId);
            }
        }

        [Fact]
        public void NetworkConfigurationConversions_AcceleratedNetworkingValues_HandleAllOptions()
        {
            // Test that accelerated networking boolean values are handled correctly

            var acceleratedNetworkingValues = new bool?[] { true, false, null };

            foreach (var acceleratedNetworking in acceleratedNetworkingValues)
            {
                // Arrange
                var psNetworkConfiguration = new PSNetworkConfiguration()
                {
                    SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                    EnableAcceleratedNetworking = acceleratedNetworking
                };

                // Act
                var mgmtNetworkConfiguration = psNetworkConfiguration.toMgmtNetworkConfiguration();
                var roundTripPsNetworkConfiguration = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

                // Assert
                Assert.Equal(acceleratedNetworking, mgmtNetworkConfiguration.EnableAcceleratedNetworking);
                Assert.Equal(acceleratedNetworking, roundTripPsNetworkConfiguration.EnableAcceleratedNetworking);
            }
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void NetworkConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var inboundNatPools = new List<Microsoft.Azure.Batch.InboundNatPool>
            {
                new Microsoft.Azure.Batch.InboundNatPool(
                    name: "ssh-nat-pool",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 22,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100)
            };

            var endpointConfiguration = new PSPoolEndpointConfiguration(inboundNatPools);

            var publicIPAddressConfiguration = new PSPublicIPAddressConfiguration(
                provision: Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            var psNetworkConfiguration = new PSNetworkConfiguration()
            {
                SubnetId = "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1",
                DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job,
                EndpointConfiguration = endpointConfiguration,
                PublicIPAddressConfiguration = publicIPAddressConfiguration,
                EnableAcceleratedNetworking = true
            };

            var mgmtInboundNatPools = new List<InboundNatPool>
            {
                new InboundNatPool(
                    name: "rdp-nat-pool",
                    protocol: InboundEndpointProtocol.TCP,
                    backendPort: 3389,
                    frontendPortRangeStart: 51000,
                    frontendPortRangeEnd: 51100)
            };

            var mgmtEndpointConfiguration = new PoolEndpointConfiguration(mgmtInboundNatPools);

            var mgmtPublicIPAddressConfiguration = new PublicIPAddressConfiguration(
                provision: IPAddressProvisioningType.UserManaged);

            var mgmtNetworkConfiguration = new NetworkConfiguration(
                subnetId: "/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet2",
                dynamicVnetAssignmentScope: DynamicVNetAssignmentScope.None,
                endpointConfiguration: mgmtEndpointConfiguration,
                publicIPAddressConfiguration: mgmtPublicIPAddressConfiguration,
                enableAcceleratedNetworking: false);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psNetworkConfiguration.toMgmtNetworkConfiguration();
                var psResult = PSNetworkConfiguration.fromMgmtNetworkConfiguration(mgmtNetworkConfiguration);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet1/subnets/subnet1", mgmtResult.SubnetId);
                Assert.Equal("/subscriptions/sub1/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet2", psResult.SubnetId);
            }
        }

        #endregion
    }
}
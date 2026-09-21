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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    /// <summary>
    /// Unit tests for the client-side kind/ipVersion logic of the Virtual Network Appliance capability cmdlets.
    /// These exercise pure logic (payload construction, discriminator mapping, validation) with no service
    /// dependency, so they do not require a recorded session.
    /// </summary>
    public class VirtualNetworkApplianceCapabilityUnitTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_PLGatewayFastpath_UsesDualStack()
        {
            var parameters = VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("PLGatewayFastpath", "DualStack");

            var fastpath = Assert.IsType<PLGatewayFastpathCapabilityCreateOrUpdate>(parameters);
            Assert.NotNull(fastpath.Properties);
            Assert.Equal("DualStack", fastpath.Properties.IPVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_PLGateway_UsesIPv6()
        {
            var parameters = VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("PLGateway", "IPv6");

            var gateway = Assert.IsType<PLGatewayCapabilityCreateOrUpdate>(parameters);
            Assert.Equal("IPv6", gateway.Properties.IPVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_PLIPForwarders_UsesIPv6()
        {
            var parameters = VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("PLIPForwarders", "IPv6");

            var ipForwarders = Assert.IsType<PlipForwardersCapabilityCreateOrUpdate>(parameters);
            Assert.Equal("IPv6", ipForwarders.Properties.IPVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_Nat64_IsPropertyLess()
        {
            var parameters = VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("NAT64", null);

            var nat64 = Assert.IsType<Nat64CapabilityCreateOrUpdate>(parameters);
            // NAT64 carries an empty properties bag with no ipVersion, matching the service contract.
            Assert.NotNull(nat64.Properties);
            Assert.Null(nat64.Properties.IPVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_IsCaseInsensitive()
        {
            var parameters = VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("plgateway", "ipv6");

            var gateway = Assert.IsType<PLGatewayCapabilityCreateOrUpdate>(parameters);
            // The ip version is canonicalized to the exact wire casing.
            Assert.Equal("IPv6", gateway.Properties.IPVersion);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_Nat64WithIpVersion_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("NAT64", "IPv6"));
            Assert.Contains("NAT64", exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void BuildCapabilityParameters_PrivateLinkWithoutIpVersion_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(
                () => VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters("PLGateway", null));
            Assert.Contains("required", exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetCapabilityKind_MapsEveryKind()
        {
            Assert.Equal("PLGatewayFastpath", VirtualNetworkApplianceCapabilityBaseCmdlet.GetCapabilityKind(new PLGatewayFastpathCapability()));
            Assert.Equal("PLGateway", VirtualNetworkApplianceCapabilityBaseCmdlet.GetCapabilityKind(new PLGatewayCapability()));
            Assert.Equal("PLIPForwarders", VirtualNetworkApplianceCapabilityBaseCmdlet.GetCapabilityKind(new PlipForwardersCapability()));
            Assert.Equal("NAT64", VirtualNetworkApplianceCapabilityBaseCmdlet.GetCapabilityKind(new Nat64Capability()));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("PLGatewayFastpath", "IPv6")]
        [InlineData("PLGateway", "DualStack")]
        [InlineData("PLIPForwarders", "DualStack")]
        public void BuildCapabilityParameters_MismatchedIpVersionForKind_Throws(string kind, string ipVersion)
        {
            var exception = Assert.Throws<ArgumentException>(
                () => VirtualNetworkApplianceCapabilityBaseCmdlet.BuildCapabilityParameters(kind, ipVersion));
            Assert.Contains(kind, exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseCapabilityResourceId_ValidId_ParsesNames()
        {
            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworkAppliances/vna1/capabilities/pl-gateway";

            VirtualNetworkApplianceCapabilityBaseCmdlet.ParseCapabilityResourceId(id, out var resourceGroupName, out var applianceName, out var capabilityName);

            Assert.Equal("rg1", resourceGroupName);
            Assert.Equal("vna1", applianceName);
            Assert.Equal("pl-gateway", capabilityName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseCapabilityResourceId_NamesEqualToStructuralKeywords_ParsedByPosition()
        {
            // An appliance literally named "capabilities" and a capability literally named "resourceGroups"
            // must still be parsed from their fixed positions, not by keyword search.
            const string id = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworkAppliances/capabilities/capabilities/resourceGroups";

            VirtualNetworkApplianceCapabilityBaseCmdlet.ParseCapabilityResourceId(id, out var resourceGroupName, out var applianceName, out var capabilityName);

            Assert.Equal("rg1", resourceGroupName);
            Assert.Equal("capabilities", applianceName);
            Assert.Equal("resourceGroups", capabilityName);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("/subscriptions/s/resourceGroups/rg/providers/Microsoft.Network/virtualNetworkAppliances/vna")] // parent id, too short
        [InlineData("/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualNetworkAppliances/vna/capabilities/c")] // wrong provider
        [InlineData("/subscriptions/s/resourceGroups/rg/providers/Microsoft.Network/virtualNetworkAppliances/vna/subnets/c")] // wrong child type
        [InlineData("/subscriptions/s/resourceGroups/rg/providers/Microsoft.Network/virtualNetworkAppliances/vna/capabilities/c/extra")] // too long
        public void ParseCapabilityResourceId_MalformedId_Throws(string resourceId)
        {
            Assert.Throws<PSArgumentException>(
                () => VirtualNetworkApplianceCapabilityBaseCmdlet.ParseCapabilityResourceId(resourceId, out _, out _, out _));
        }
    }
}

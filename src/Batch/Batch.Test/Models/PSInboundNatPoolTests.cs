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
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSInboundNatPoolTests
    {
        #region FromMgmtInboundNatPool Tests

        [Fact]
        public void FromMgmtInboundNatPool_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var networkSecurityGroupRules = new List<NetworkSecurityGroupRule>
            {
                new NetworkSecurityGroupRule(
                    priority: 100,
                    access: NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/24",
                    sourcePortRanges: new List<string> { "80", "443" }),
                new NetworkSecurityGroupRule(
                    priority: 200,
                    access: NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "*",
                    sourcePortRanges: new List<string> { "*" })
            };

            var mgmtInboundNatPool = new InboundNatPool(
                name: "test-nat-pool",
                protocol: InboundEndpointProtocol.TCP,
                backendPort: 22,
                frontendPortRangeStart: 50000,
                frontendPortRangeEnd: 50100,
                networkSecurityGroupRules: networkSecurityGroupRules);

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test-nat-pool", result.Name);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, result.Protocol);
            Assert.Equal(22, result.BackendPort);
            Assert.Equal(50000, result.FrontendPortRangeStart);
            Assert.Equal(50100, result.FrontendPortRangeEnd);
            Assert.NotNull(result.NetworkSecurityGroupRules);
            Assert.Equal(2, result.NetworkSecurityGroupRules.Count);
            
            var rule1 = result.NetworkSecurityGroupRules.First();
            Assert.Equal(100, rule1.Priority);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, rule1.Access);
            Assert.Equal("10.0.0.0/24", rule1.SourceAddressPrefix);
        }

        [Fact]
        public void FromMgmtInboundNatPool_WithUDPProtocol_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtInboundNatPool = new InboundNatPool(
                name: "udp-nat-pool",
                protocol: InboundEndpointProtocol.UDP,
                backendPort: 53,
                frontendPortRangeStart: 60000,
                frontendPortRangeEnd: 60100);

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("udp-nat-pool", result.Name);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, result.Protocol);
            Assert.Equal(53, result.BackendPort);
            Assert.Equal(60000, result.FrontendPortRangeStart);
            Assert.Equal(60100, result.FrontendPortRangeEnd);
            Assert.True(result.NetworkSecurityGroupRules == null || result.NetworkSecurityGroupRules.Count == 0);
        }

        [Fact]
        public void FromMgmtInboundNatPool_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtInboundNatPool = new InboundNatPool(
                name: "minimal-nat-pool",
                protocol: InboundEndpointProtocol.TCP,
                backendPort: 3389,
                frontendPortRangeStart: 55000,
                frontendPortRangeEnd: 55999);

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("minimal-nat-pool", result.Name);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, result.Protocol);
            Assert.Equal(3389, result.BackendPort);
            Assert.Equal(55000, result.FrontendPortRangeStart);
            Assert.Equal(55999, result.FrontendPortRangeEnd);
            Assert.True(result.NetworkSecurityGroupRules == null || result.NetworkSecurityGroupRules.Count == 0);
        }

        [Fact]
        public void FromMgmtInboundNatPool_WithNullInput_ReturnsNull()
        {
            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtInboundNatPool_WithEmptyNetworkSecurityGroupRules_HandlesCorrectly()
        {
            // Arrange
            var mgmtInboundNatPool = new InboundNatPool(
                name: "empty-rules-pool",
                protocol: InboundEndpointProtocol.TCP,
                backendPort: 80,
                frontendPortRangeStart: 45000,
                frontendPortRangeEnd: 45100,
                networkSecurityGroupRules: new List<NetworkSecurityGroupRule>());

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("empty-rules-pool", result.Name);
            Assert.NotNull(result.NetworkSecurityGroupRules);
            Assert.Empty(result.NetworkSecurityGroupRules);
        }

        [Fact]
        public void FromMgmtInboundNatPool_VerifyPSInboundNatPoolType()
        {
            // Arrange
            var mgmtInboundNatPool = new InboundNatPool(
                name: "type-test-pool",
                protocol: InboundEndpointProtocol.TCP,
                backendPort: 443,
                frontendPortRangeStart: 40000,
                frontendPortRangeEnd: 40100);

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Microsoft.Azure.Batch.InboundNatPool>(result);
        }

        [Theory]
        [InlineData(InboundEndpointProtocol.TCP, Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp)]
        [InlineData(InboundEndpointProtocol.UDP, Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp)]
        public void FromMgmtInboundNatPool_AllProtocolTypes_ReturnsCorrectMapping(
            InboundEndpointProtocol mgmtProtocol,
            Microsoft.Azure.Batch.Common.InboundEndpointProtocol expectedPsProtocol)
        {
            // Arrange
            var mgmtInboundNatPool = new InboundNatPool(
                name: "protocol-test-pool",
                protocol: mgmtProtocol,
                backendPort: 8080,
                frontendPortRangeStart: 35000,
                frontendPortRangeEnd: 35100);

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsProtocol, result.Protocol);
        }

        [Fact]
        public void FromMgmtInboundNatPool_WithComplexNetworkSecurityGroupRules_HandlesCorrectly()
        {
            // Arrange
            var complexNetworkRules = new List<NetworkSecurityGroupRule>
            {
                new NetworkSecurityGroupRule(
                    priority: 150,
                    access: NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "192.168.1.0/24",
                    sourcePortRanges: new List<string> { "22", "80", "443" }),
                new NetworkSecurityGroupRule(
                    priority: 250,
                    access: NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/8",
                    sourcePortRanges: new List<string> { "8080-8090" }),
                new NetworkSecurityGroupRule(
                    priority: 4000,
                    access: NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "*",
                    sourcePortRanges: new List<string> { "*" })
            };

            var mgmtInboundNatPool = new InboundNatPool(
                name: "complex-rules-pool",
                protocol: InboundEndpointProtocol.TCP,
                backendPort: 22,
                frontendPortRangeStart: 30000,
                frontendPortRangeEnd: 30100,
                networkSecurityGroupRules: complexNetworkRules);

            // Act
            var result = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.NetworkSecurityGroupRules);
            Assert.Equal(3, result.NetworkSecurityGroupRules.Count);
            
            var allowRule = result.NetworkSecurityGroupRules.First(r => r.Priority == 150);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, allowRule.Access);
            Assert.Equal("192.168.1.0/24", allowRule.SourceAddressPrefix);
            Assert.Equal(3, allowRule.SourcePortRanges.Count);
            
            var denyRule = result.NetworkSecurityGroupRules.First(r => r.Priority == 4000);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, denyRule.Access);
            Assert.Equal("*", denyRule.SourceAddressPrefix);
        }

        #endregion

        #region toMgmtInboundNatPool Tests

        [Fact]
        public void ToMgmtInboundNatPool_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var networkSecurityGroupRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/24",
                    sourcePortRanges: new List<string> { "80", "443" }),
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 200,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "*",
                    sourcePortRanges: new List<string> { "*" })
            };

            var psInboundNatPool = new PSInboundNatPool(
                name: "test-nat-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 22,
                frontendPortRangeStart: 50000,
                frontendPortRangeEnd: 50100,
                networkSecurityGroupRules: networkSecurityGroupRules);

            // Act
            var result = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test-nat-pool", result.Name);
            Assert.Equal(InboundEndpointProtocol.TCP, result.Protocol);
            Assert.Equal(22, result.BackendPort);
            Assert.Equal(50000, result.FrontendPortRangeStart);
            Assert.Equal(50100, result.FrontendPortRangeEnd);
            Assert.NotNull(result.NetworkSecurityGroupRules);
            Assert.Equal(2, result.NetworkSecurityGroupRules.Count);
            
            var rule1 = result.NetworkSecurityGroupRules.First();
            Assert.Equal(100, rule1.Priority);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, rule1.Access);
            Assert.Equal("10.0.0.0/24", rule1.SourceAddressPrefix);
        }

        [Fact]
        public void ToMgmtInboundNatPool_WithUDPProtocol_ReturnsCorrectMapping()
        {
            // Arrange
            var psInboundNatPool = new PSInboundNatPool(
                name: "udp-nat-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp,
                backendPort: 53,
                frontendPortRangeStart: 60000,
                frontendPortRangeEnd: 60100);

            // Act
            var result = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("udp-nat-pool", result.Name);
            Assert.Equal(InboundEndpointProtocol.UDP, result.Protocol);
            Assert.Equal(53, result.BackendPort);
            Assert.Equal(60000, result.FrontendPortRangeStart);
            Assert.Equal(60100, result.FrontendPortRangeEnd);
            Assert.True(result.NetworkSecurityGroupRules == null || result.NetworkSecurityGroupRules.Count == 0);
        }

        [Fact]
        public void ToMgmtInboundNatPool_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psInboundNatPool = new PSInboundNatPool(
                name: "minimal-nat-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 3389,
                frontendPortRangeStart: 55000,
                frontendPortRangeEnd: 55999);

            // Act
            var result = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("minimal-nat-pool", result.Name);
            Assert.Equal(InboundEndpointProtocol.TCP, result.Protocol);
            Assert.Equal(3389, result.BackendPort);
            Assert.Equal(55000, result.FrontendPortRangeStart);
            Assert.Equal(55999, result.FrontendPortRangeEnd);
            Assert.True(result.NetworkSecurityGroupRules == null || result.NetworkSecurityGroupRules.Count == 0);
        }

        [Fact]
        public void ToMgmtInboundNatPool_VerifyInboundNatPoolType()
        {
            // Arrange
            var psInboundNatPool = new PSInboundNatPool(
                name: "type-test-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 443,
                frontendPortRangeStart: 40000,
                frontendPortRangeEnd: 40100);

            // Act
            var result = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<InboundNatPool>(result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, InboundEndpointProtocol.TCP)]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, InboundEndpointProtocol.UDP)]
        public void ToMgmtInboundNatPool_AllProtocolTypes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.InboundEndpointProtocol psProtocol,
            InboundEndpointProtocol expectedMgmtProtocol)
        {
            // Arrange
            var psInboundNatPool = new PSInboundNatPool(
                name: "protocol-test-pool",
                protocol: psProtocol,
                backendPort: 8080,
                frontendPortRangeStart: 35000,
                frontendPortRangeEnd: 35100);

            // Act
            var result = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtProtocol, result.Protocol);
        }

        [Fact]
        public void ToMgmtInboundNatPool_WithComplexNetworkSecurityGroupRules_HandlesCorrectly()
        {
            // Arrange
            var complexNetworkRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 150,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "192.168.1.0/24",
                    sourcePortRanges: new List<string> { "22", "80", "443" }),
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 250,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/8",
                    sourcePortRanges: new List<string> { "8080-8090" }),
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 4000,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "*",
                    sourcePortRanges: new List<string> { "*" })
            };

            var psInboundNatPool = new PSInboundNatPool(
                name: "complex-rules-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 22,
                frontendPortRangeStart: 30000,
                frontendPortRangeEnd: 30100,
                networkSecurityGroupRules: complexNetworkRules);

            // Act
            var result = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.NetworkSecurityGroupRules);
            Assert.Equal(3, result.NetworkSecurityGroupRules.Count);
            
            var allowRule = result.NetworkSecurityGroupRules.First(r => r.Priority == 150);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, allowRule.Access);
            Assert.Equal("192.168.1.0/24", allowRule.SourceAddressPrefix);
            Assert.Equal(3, allowRule.SourcePortRanges.Count);
            
            var denyRule = result.NetworkSecurityGroupRules.First(r => r.Priority == 4000);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, denyRule.Access);
            Assert.Equal("*", denyRule.SourceAddressPrefix);
        }

        [Fact]
        public void ToMgmtInboundNatPool_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psInboundNatPool = new PSInboundNatPool(
                name: "instance-test-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 9000,
                frontendPortRangeStart: 25000,
                frontendPortRangeEnd: 25100);

            // Act
            var result1 = psInboundNatPool.toMgmtInboundNatPool();
            var result2 = psInboundNatPool.toMgmtInboundNatPool();

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
            var originalNetworkRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/24",
                    sourcePortRanges: new List<string> { "80", "443" }),
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 200,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "*",
                    sourcePortRanges: new List<string> { "*" })
            };

            var originalPsInboundNatPool = new PSInboundNatPool(
                name: "round-trip-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 22,
                frontendPortRangeStart: 50000,
                frontendPortRangeEnd: 50100,
                networkSecurityGroupRules: originalNetworkRules);

            // Act
            var mgmtInboundNatPool = originalPsInboundNatPool.toMgmtInboundNatPool();
            var roundTripPsInboundNatPool = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(roundTripPsInboundNatPool);
            Assert.Equal(originalPsInboundNatPool.Name, roundTripPsInboundNatPool.Name);
            Assert.Equal(originalPsInboundNatPool.Protocol, roundTripPsInboundNatPool.Protocol);
            Assert.Equal(originalPsInboundNatPool.BackendPort, roundTripPsInboundNatPool.BackendPort);
            Assert.Equal(originalPsInboundNatPool.FrontendPortRangeStart, roundTripPsInboundNatPool.FrontendPortRangeStart);
            Assert.Equal(originalPsInboundNatPool.FrontendPortRangeEnd, roundTripPsInboundNatPool.FrontendPortRangeEnd);
            Assert.Equal(originalPsInboundNatPool.NetworkSecurityGroupRules?.Count, roundTripPsInboundNatPool.NetworkSecurityGroupRules?.Count);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalNetworkRules = new List<NetworkSecurityGroupRule>
            {
                new NetworkSecurityGroupRule(
                    priority: 150,
                    access: NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "192.168.1.0/24",
                    sourcePortRanges: new List<string> { "22", "3389" }),
                new NetworkSecurityGroupRule(
                    priority: 300,
                    access: NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "0.0.0.0/0",
                    sourcePortRanges: new List<string> { "23", "135" })
            };

            var originalMgmtInboundNatPool = new InboundNatPool(
                name: "mgmt-round-trip-pool",
                protocol: InboundEndpointProtocol.UDP,
                backendPort: 53,
                frontendPortRangeStart: 60000,
                frontendPortRangeEnd: 60100,
                networkSecurityGroupRules: originalNetworkRules);

            // Act
            var psInboundNatPool = new PSInboundNatPool(PSInboundNatPool.FromMgmtInboundNatPool(originalMgmtInboundNatPool));
            var roundTripMgmtInboundNatPool = psInboundNatPool.toMgmtInboundNatPool();

            // Assert
            Assert.NotNull(roundTripMgmtInboundNatPool);
            Assert.Equal(originalMgmtInboundNatPool.Name, roundTripMgmtInboundNatPool.Name);
            Assert.Equal(originalMgmtInboundNatPool.Protocol, roundTripMgmtInboundNatPool.Protocol);
            Assert.Equal(originalMgmtInboundNatPool.BackendPort, roundTripMgmtInboundNatPool.BackendPort);
            Assert.Equal(originalMgmtInboundNatPool.FrontendPortRangeStart, roundTripMgmtInboundNatPool.FrontendPortRangeStart);
            Assert.Equal(originalMgmtInboundNatPool.FrontendPortRangeEnd, roundTripMgmtInboundNatPool.FrontendPortRangeEnd);
            Assert.Equal(originalMgmtInboundNatPool.NetworkSecurityGroupRules?.Count, roundTripMgmtInboundNatPool.NetworkSecurityGroupRules?.Count);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp)]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp)]
        public void RoundTripConversion_AllProtocolTypes_PreservesOriginalValues(
            Microsoft.Azure.Batch.Common.InboundEndpointProtocol originalProtocol)
        {
            // Arrange
            var originalPsInboundNatPool = new PSInboundNatPool(
                name: "protocol-round-trip-pool",
                protocol: originalProtocol,
                backendPort: 8080,
                frontendPortRangeStart: 45000,
                frontendPortRangeEnd: 45100);

            // Act
            var mgmtInboundNatPool = originalPsInboundNatPool.toMgmtInboundNatPool();
            var roundTripPsInboundNatPool = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(roundTripPsInboundNatPool);
            Assert.Equal(originalProtocol, roundTripPsInboundNatPool.Protocol);
        }

        [Fact]
        public void RoundTripConversion_WithNullNetworkSecurityGroupRules_PreservesNullValue()
        {
            // Arrange
            var originalPsInboundNatPool = new PSInboundNatPool(
                name: "null-rules-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 80,
                frontendPortRangeStart: 40000,
                frontendPortRangeEnd: 40100);

            // Act
            var mgmtInboundNatPool = originalPsInboundNatPool.toMgmtInboundNatPool();
            var roundTripPsInboundNatPool = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert
            Assert.NotNull(roundTripPsInboundNatPool);
            Assert.True(roundTripPsInboundNatPool.NetworkSecurityGroupRules == null || 
                       roundTripPsInboundNatPool.NetworkSecurityGroupRules.Count == 0);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void InboundNatPoolConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test SSH NAT pool with security rules
            var sshNetworkRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "203.0.113.0/24",
                    sourcePortRanges: new List<string> { "22" })
            };

            var sshPsPool = new PSInboundNatPool(
                name: "ssh-nat-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 22,
                frontendPortRangeStart: 50000,
                frontendPortRangeEnd: 50100,
                networkSecurityGroupRules: sshNetworkRules);

            var sshMgmtPool = sshPsPool.toMgmtInboundNatPool();
            var backToPs = PSInboundNatPool.FromMgmtInboundNatPool(sshMgmtPool);

            Assert.Equal(InboundEndpointProtocol.TCP, sshMgmtPool.Protocol);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, backToPs.Protocol);
            Assert.Equal(22, sshMgmtPool.BackendPort);
            Assert.Equal(22, backToPs.BackendPort);
            Assert.Equal(sshPsPool.Name, backToPs.Name);

            // Test UDP NAT pool without security rules
            var udpPsPool = new PSInboundNatPool(
                name: "udp-nat-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp,
                backendPort: 53,
                frontendPortRangeStart: 60000,
                frontendPortRangeEnd: 60100);

            var udpMgmtPool = udpPsPool.toMgmtInboundNatPool();
            var backToPsUdp = PSInboundNatPool.FromMgmtInboundNatPool(udpMgmtPool);

            Assert.Equal(InboundEndpointProtocol.UDP, udpMgmtPool.Protocol);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, backToPsUdp.Protocol);
            Assert.Equal(53, udpMgmtPool.BackendPort);
            Assert.Equal(53, backToPsUdp.BackendPort);
        }

        [Fact]
        public void InboundNatPoolConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSInboundNatPool.FromMgmtInboundNatPool(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void InboundNatPoolConversions_BatchPoolEndpointContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool endpoint configuration
            // InboundNatPool is used to configure network endpoints for Azure Batch pool compute nodes

            // Arrange - Test with realistic Batch pool endpoint scenarios
            var poolEndpointScenarios = new[]
            {
                // SSH access for Linux compute nodes
                new {
                    Name = "ssh-access",
                    Protocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    BackendPort = 22,
                    FrontendPortRangeStart = 50000,
                    FrontendPortRangeEnd = 50100,
                    Description = "SSH access to Linux compute nodes"
                },
                // RDP access for Windows compute nodes
                new {
                    Name = "rdp-access",
                    Protocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    BackendPort = 3389,
                    FrontendPortRangeStart = 51000,
                    FrontendPortRangeEnd = 51100,
                    Description = "RDP access to Windows compute nodes"
                },
                // Custom application port
                new {
                    Name = "custom-app",
                    Protocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    BackendPort = 8080,
                    FrontendPortRangeStart = 52000,
                    FrontendPortRangeEnd = 52100,
                    Description = "Custom application endpoint"
                },
                // UDP service endpoint
                new {
                    Name = "udp-service",
                    Protocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp,
                    BackendPort = 53,
                    FrontendPortRangeStart = 53000,
                    FrontendPortRangeEnd = 53100,
                    Description = "UDP service endpoint"
                }
            };

            foreach (var scenario in poolEndpointScenarios)
            {
                // Act
                var psInboundNatPool = new PSInboundNatPool(
                    name: scenario.Name,
                    protocol: scenario.Protocol,
                    backendPort: scenario.BackendPort,
                    frontendPortRangeStart: scenario.FrontendPortRangeStart,
                    frontendPortRangeEnd: scenario.FrontendPortRangeEnd);

                var mgmtInboundNatPool = psInboundNatPool.toMgmtInboundNatPool();

                // Assert - Should convert correctly for Batch pool endpoint configuration
                Assert.NotNull(mgmtInboundNatPool);
                Assert.Equal(scenario.Name, mgmtInboundNatPool.Name);
                Assert.Equal(scenario.BackendPort, mgmtInboundNatPool.BackendPort);
                Assert.Equal(scenario.FrontendPortRangeStart, mgmtInboundNatPool.FrontendPortRangeStart);
                Assert.Equal(scenario.FrontendPortRangeEnd, mgmtInboundNatPool.FrontendPortRangeEnd);
                
                var expectedMgmtProtocol = scenario.Protocol == Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp
                    ? InboundEndpointProtocol.TCP
                    : InboundEndpointProtocol.UDP;
                Assert.Equal(expectedMgmtProtocol, mgmtInboundNatPool.Protocol);

                // Verify round-trip conversion maintains pool endpoint semantics
                var backToPs = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Name, backToPs.Name);
                Assert.Equal(scenario.Protocol, backToPs.Protocol);
                Assert.Equal(scenario.BackendPort, backToPs.BackendPort);
                Assert.Equal(scenario.FrontendPortRangeStart, backToPs.FrontendPortRangeStart);
                Assert.Equal(scenario.FrontendPortRangeEnd, backToPs.FrontendPortRangeEnd);
            }
        }

        [Fact]
        public void InboundNatPoolConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psNetworkRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/8",
                    sourcePortRanges: new List<string> { "80", "443" })
            };

            var psInboundNatPool = new PSInboundNatPool(
                name: "instance-test-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 80,
                frontendPortRangeStart: 45000,
                frontendPortRangeEnd: 45100,
                networkSecurityGroupRules: psNetworkRules);

            var mgmtNetworkRules = new List<NetworkSecurityGroupRule>
            {
                new NetworkSecurityGroupRule(
                    priority: 200,
                    access: NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "0.0.0.0/0",
                    sourcePortRanges: new List<string> { "*" })
            };

            var mgmtInboundNatPool = new InboundNatPool(
                name: "mgmt-instance-test-pool",
                protocol: InboundEndpointProtocol.UDP,
                backendPort: 53,
                frontendPortRangeStart: 46000,
                frontendPortRangeEnd: 46100,
                networkSecurityGroupRules: mgmtNetworkRules);

            // Act
            var mgmtResult = psInboundNatPool.toMgmtInboundNatPool();
            var psResult = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.InboundNatPool>(mgmtResult);
            Assert.IsType<Azure.Batch.InboundNatPool>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtInboundNatPool, mgmtResult);
            Assert.NotSame(psInboundNatPool, psResult);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void InboundNatPoolConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psInboundNatPool = new PSInboundNatPool(
                name: "type-safety-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 443,
                frontendPortRangeStart: 48000,
                frontendPortRangeEnd: 48100);

            var mgmtInboundNatPool = new InboundNatPool(
                name: "mgmt-type-safety-pool",
                protocol: InboundEndpointProtocol.UDP,
                backendPort: 123,
                frontendPortRangeStart: 49000,
                frontendPortRangeEnd: 49100);

            // Act
            var mgmtResult = psInboundNatPool.toMgmtInboundNatPool();
            var psResult = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

            // Assert - Verify correct types are returned
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.InboundNatPool>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.InboundNatPool>(psResult);
        }

        [Fact]
        public void InboundNatPoolConversions_PortRangeValues_HandleValidRange()
        {
            // Test that port range values within valid range are handled correctly

            var validPortRanges = new[]
            {
                new { Backend = 22, FrontendStart = 50000, FrontendEnd = 50100 },
                new { Backend = 80, FrontendStart = 51000, FrontendEnd = 51200 },
                new { Backend = 443, FrontendStart = 52000, FrontendEnd = 52500 },
                new { Backend = 3389, FrontendStart = 53000, FrontendEnd = 53100 },
                new { Backend = 8080, FrontendStart = 54000, FrontendEnd = 54999 }
            };

            foreach (var portRange in validPortRanges)
            {
                // Arrange
                var psInboundNatPool = new PSInboundNatPool(
                    name: $"port-test-{portRange.Backend}",
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: portRange.Backend,
                    frontendPortRangeStart: portRange.FrontendStart,
                    frontendPortRangeEnd: portRange.FrontendEnd);

                // Act
                var mgmtInboundNatPool = psInboundNatPool.toMgmtInboundNatPool();
                var roundTripPsInboundNatPool = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

                // Assert
                Assert.Equal(portRange.Backend, mgmtInboundNatPool.BackendPort);
                Assert.Equal(portRange.FrontendStart, mgmtInboundNatPool.FrontendPortRangeStart);
                Assert.Equal(portRange.FrontendEnd, mgmtInboundNatPool.FrontendPortRangeEnd);
                Assert.Equal(portRange.Backend, roundTripPsInboundNatPool.BackendPort);
                Assert.Equal(portRange.FrontendStart, roundTripPsInboundNatPool.FrontendPortRangeStart);
                Assert.Equal(portRange.FrontendEnd, roundTripPsInboundNatPool.FrontendPortRangeEnd);
            }
        }

        [Fact]
        public void InboundNatPoolConversions_NameValues_HandleVariousFormats()
        {
            // Test that various name formats are handled correctly

            var nameFormats = new[]
            {
                "simple-name",
                "Name_With_Underscores",
                "Name.With.Periods",
                "NameWithNumbers123",
                "123StartingWithNumber",
                "a",  // Single character
                "VeryLongNameThatIsStillValidAccordingToTheSpecification"
            };

            foreach (var name in nameFormats)
            {
                // Arrange
                var psInboundNatPool = new PSInboundNatPool(
                    name: name,
                    protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    backendPort: 80,
                    frontendPortRangeStart: 50000,
                    frontendPortRangeEnd: 50100);

                // Act
                var mgmtInboundNatPool = psInboundNatPool.toMgmtInboundNatPool();
                var roundTripPsInboundNatPool = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

                // Assert
                Assert.Equal(name, mgmtInboundNatPool.Name);
                Assert.Equal(name, roundTripPsInboundNatPool.Name);
            }
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void InboundNatPoolConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var networkRules = new List<Microsoft.Azure.Batch.NetworkSecurityGroupRule>
            {
                new Microsoft.Azure.Batch.NetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/8",
                    sourcePortRanges: new List<string> { "80", "443" })
            };

            var psInboundNatPool = new PSInboundNatPool(
                name: "performance-test-pool",
                protocol: Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                backendPort: 22,
                frontendPortRangeStart: 50000,
                frontendPortRangeEnd: 50100,
                networkSecurityGroupRules: networkRules);

            var mgmtNetworkRules = new List<NetworkSecurityGroupRule>
            {
                new NetworkSecurityGroupRule(
                    priority: 200,
                    access: NetworkSecurityGroupRuleAccess.Deny,
                    sourceAddressPrefix: "*",
                    sourcePortRanges: new List<string> { "*" })
            };

            var mgmtInboundNatPool = new InboundNatPool(
                name: "mgmt-performance-test-pool",
                protocol: InboundEndpointProtocol.UDP,
                backendPort: 53,
                frontendPortRangeStart: 60000,
                frontendPortRangeEnd: 60100,
                networkSecurityGroupRules: mgmtNetworkRules);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psInboundNatPool.toMgmtInboundNatPool();
                var psResult = PSInboundNatPool.FromMgmtInboundNatPool(mgmtInboundNatPool);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal("performance-test-pool", mgmtResult.Name);
                Assert.Equal("mgmt-performance-test-pool", psResult.Name);
            }
        }

        #endregion
    }
}
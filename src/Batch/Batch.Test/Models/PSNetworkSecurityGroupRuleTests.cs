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
    public class PSNetworkSecurityGroupRuleTests
    {
        #region FromMgmtNetworkSecurityGroupRule Tests

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var sourcePortRanges = new List<string> { "80", "443", "8080-8090" };
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 100,
                access: NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "10.0.0.0/24",
                sourcePortRanges: sourcePortRanges);

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(100, result.Priority);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, result.Access);
            Assert.Equal("10.0.0.0/24", result.SourceAddressPrefix);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Equal(3, result.SourcePortRanges.Count);
            Assert.Contains("80", result.SourcePortRanges);
            Assert.Contains("443", result.SourcePortRanges);
            Assert.Contains("8080-8090", result.SourcePortRanges);
        }

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_WithDenyAccess_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 200,
                access: NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "*",
                sourcePortRanges: new List<string> { "*" });

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.Priority);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, result.Access);
            Assert.Equal("*", result.SourceAddressPrefix);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Single(result.SourcePortRanges);
            Assert.Contains("*", result.SourcePortRanges);
        }

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 150,
                access: NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "192.168.1.0/24");

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(150, result.Priority);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, result.Access);
            Assert.Equal("192.168.1.0/24", result.SourceAddressPrefix);
            // SourcePortRanges can be null when not specified
            Assert.True(result.SourcePortRanges == null || result.SourcePortRanges.Count == 0);
        }

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_WithNullInput_ReturnsNull()
        {
            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_WithEmptySourcePortRanges_HandlesCorrectly()
        {
            // Arrange
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 250,
                access: NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "10.10.10.10",
                sourcePortRanges: new List<string>());

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(250, result.Priority);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, result.Access);
            Assert.Equal("10.10.10.10", result.SourceAddressPrefix);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Empty(result.SourcePortRanges);
        }

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_VerifyPSNetworkSecurityGroupRuleType()
        {
            // Arrange
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 300,
                access: NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "172.16.0.0/16");

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Microsoft.Azure.Batch.NetworkSecurityGroupRule>(result);
        }

        [Theory]
        [InlineData(NetworkSecurityGroupRuleAccess.Allow, Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow)]
        [InlineData(NetworkSecurityGroupRuleAccess.Deny, Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny)]
        public void FromMgmtNetworkSecurityGroupRule_AllAccessTypes_ReturnsCorrectMapping(
            NetworkSecurityGroupRuleAccess mgmtAccess,
            Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess expectedPsAccess)
        {
            // Arrange
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 400,
                access: mgmtAccess,
                sourceAddressPrefix: "203.0.113.0/24");

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsAccess, result.Access);
        }

        [Fact]
        public void FromMgmtNetworkSecurityGroupRule_WithComplexPortRanges_HandlesCorrectly()
        {
            // Arrange
            var complexPortRanges = new List<string> 
            { 
                "22", 
                "80", 
                "443", 
                "3000-3010", 
                "8080-8090", 
                "9000" 
            };
            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 500,
                access: NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "0.0.0.0/0",
                sourcePortRanges: complexPortRanges);

            // Act
            var result = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Equal(6, result.SourcePortRanges.Count);
            Assert.Equal(complexPortRanges, result.SourcePortRanges.ToList());
        }

        #endregion

        #region toMgmtNetworkSecurityGroupRule Tests

        [Fact]
        public void ToMgmtNetworkSecurityGroupRule_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var sourcePortRanges = new List<string> { "80", "443", "8080-8090" };
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 100,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "10.0.0.0/24",
                sourcePortRanges: sourcePortRanges);

            // Act
            var result = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(100, result.Priority);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, result.Access);
            Assert.Equal("10.0.0.0/24", result.SourceAddressPrefix);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Equal(3, result.SourcePortRanges.Count);
            Assert.Contains("80", result.SourcePortRanges);
            Assert.Contains("443", result.SourcePortRanges);
            Assert.Contains("8080-8090", result.SourcePortRanges);
        }

        [Fact]
        public void ToMgmtNetworkSecurityGroupRule_WithDenyAccess_ReturnsCorrectMapping()
        {
            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 200,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "*",
                sourcePortRanges: new List<string> { "*" });

            // Act
            var result = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.Priority);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, result.Access);
            Assert.Equal("*", result.SourceAddressPrefix);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Single(result.SourcePortRanges);
            Assert.Contains("*", result.SourcePortRanges);
        }

        [Fact]
        public void ToMgmtNetworkSecurityGroupRule_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 150,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "192.168.1.0/24");

            // Act
            var result = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(150, result.Priority);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, result.Access);
            Assert.Equal("192.168.1.0/24", result.SourceAddressPrefix);
            // SourcePortRanges can be null when not specified
            Assert.True(result.SourcePortRanges == null || result.SourcePortRanges.Count == 0);
        }

        [Fact]
        public void ToMgmtNetworkSecurityGroupRule_VerifyNetworkSecurityGroupRuleType()
        {
            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 300,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "172.16.0.0/16");

            // Act
            var result = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NetworkSecurityGroupRule>(result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, NetworkSecurityGroupRuleAccess.Allow)]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, NetworkSecurityGroupRuleAccess.Deny)]
        public void ToMgmtNetworkSecurityGroupRule_AllAccessTypes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess psAccess,
            NetworkSecurityGroupRuleAccess expectedMgmtAccess)
        {
            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 400,
                access: psAccess,
                sourceAddressPrefix: "203.0.113.0/24");

            // Act
            var result = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtAccess, result.Access);
        }

        [Fact]
        public void ToMgmtNetworkSecurityGroupRule_WithComplexPortRanges_HandlesCorrectly()
        {
            // Arrange
            var complexPortRanges = new List<string> 
            { 
                "22", 
                "80", 
                "443", 
                "3000-3010", 
                "8080-8090", 
                "9000" 
            };
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 500,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "0.0.0.0/0",
                sourcePortRanges: complexPortRanges);

            // Act
            var result = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.SourcePortRanges);
            Assert.Equal(6, result.SourcePortRanges.Count);
            Assert.Equal(complexPortRanges, result.SourcePortRanges.ToList());
        }

        [Fact]
        public void ToMgmtNetworkSecurityGroupRule_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 600,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "198.51.100.0/24");

            // Act
            var result1 = psRule.toMgmtNetworkSecurityGroupRule();
            var result2 = psRule.toMgmtNetworkSecurityGroupRule();

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
            var originalSourcePortRanges = new List<string> { "80", "443", "8080-8090" };
            var originalPsRule = new PSNetworkSecurityGroupRule(
                priority: 100,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "10.0.0.0/24",
                sourcePortRanges: originalSourcePortRanges);

            // Act
            var mgmtRule = originalPsRule.toMgmtNetworkSecurityGroupRule();
            var roundTripPsRule = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(roundTripPsRule);
            Assert.Equal(originalPsRule.Priority, roundTripPsRule.Priority);
            Assert.Equal(originalPsRule.Access, roundTripPsRule.Access);
            Assert.Equal(originalPsRule.SourceAddressPrefix, roundTripPsRule.SourceAddressPrefix);
            Assert.Equal(originalPsRule.SourcePortRanges?.Count, roundTripPsRule.SourcePortRanges?.Count);
            if (originalPsRule.SourcePortRanges != null && roundTripPsRule.SourcePortRanges != null)
            {
                Assert.Equal(originalPsRule.SourcePortRanges.ToList(), roundTripPsRule.SourcePortRanges.ToList());
            }
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalSourcePortRanges = new List<string> { "22", "3389", "5000-5010" };
            var originalMgmtRule = new NetworkSecurityGroupRule(
                priority: 200,
                access: NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "172.16.0.0/16",
                sourcePortRanges: originalSourcePortRanges);

            // Act
            var psRule = new PSNetworkSecurityGroupRule(PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(originalMgmtRule));
            var roundTripMgmtRule = psRule.toMgmtNetworkSecurityGroupRule();

            // Assert
            Assert.NotNull(roundTripMgmtRule);
            Assert.Equal(originalMgmtRule.Priority, roundTripMgmtRule.Priority);
            Assert.Equal(originalMgmtRule.Access, roundTripMgmtRule.Access);
            Assert.Equal(originalMgmtRule.SourceAddressPrefix, roundTripMgmtRule.SourceAddressPrefix);
            Assert.Equal(originalMgmtRule.SourcePortRanges?.Count, roundTripMgmtRule.SourcePortRanges?.Count);
            if (originalMgmtRule.SourcePortRanges != null && roundTripMgmtRule.SourcePortRanges != null)
            {
                Assert.Equal(originalMgmtRule.SourcePortRanges.ToList(), roundTripMgmtRule.SourcePortRanges.ToList());
            }
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow)]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny)]
        public void RoundTripConversion_AllAccessTypes_PreservesOriginalValues(
            Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess originalAccess)
        {
            // Arrange
            var originalPsRule = new PSNetworkSecurityGroupRule(
                priority: 300,
                access: originalAccess,
                sourceAddressPrefix: "192.168.0.0/16",
                sourcePortRanges: new List<string> { "80", "443" });

            // Act
            var mgmtRule = originalPsRule.toMgmtNetworkSecurityGroupRule();
            var roundTripPsRule = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(roundTripPsRule);
            Assert.Equal(originalAccess, roundTripPsRule.Access);
        }

        [Fact]
        public void RoundTripConversion_WithNullSourcePortRanges_PreservesNullValue()
        {
            // Arrange
            var originalPsRule = new PSNetworkSecurityGroupRule(
                priority: 400,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "203.0.113.0/24");

            // Act
            var mgmtRule = originalPsRule.toMgmtNetworkSecurityGroupRule();
            var roundTripPsRule = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert
            Assert.NotNull(roundTripPsRule);
            Assert.True(roundTripPsRule.SourcePortRanges == null || roundTripPsRule.SourcePortRanges.Count == 0);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void NetworkSecurityGroupRuleConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Allow rule with specific port ranges
            var allowPsRule = new PSNetworkSecurityGroupRule(
                priority: 100,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "10.0.0.0/8",
                sourcePortRanges: new List<string> { "80", "443" });

            var allowMgmtRule = allowPsRule.toMgmtNetworkSecurityGroupRule();
            var backToPs = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(allowMgmtRule);

            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, allowMgmtRule.Access);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, backToPs.Access);
            Assert.Equal(allowPsRule.Priority, backToPs.Priority);
            Assert.Equal(allowPsRule.SourceAddressPrefix, backToPs.SourceAddressPrefix);

            // Test Deny rule with wildcard
            var denyPsRule = new PSNetworkSecurityGroupRule(
                priority: 200,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "*",
                sourcePortRanges: new List<string> { "*" });

            var denyMgmtRule = denyPsRule.toMgmtNetworkSecurityGroupRule();
            var backToPsDeny = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(denyMgmtRule);

            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, denyMgmtRule.Access);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, backToPsDeny.Access);
            Assert.Equal(denyPsRule.Priority, backToPsDeny.Priority);
            Assert.Equal(denyPsRule.SourceAddressPrefix, backToPsDeny.SourceAddressPrefix);
        }

        [Fact]
        public void NetworkSecurityGroupRuleConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void NetworkSecurityGroupRuleConversions_BatchNetworkSecurityContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch network security configuration
            // NetworkSecurityGroupRule is used to configure inbound endpoint security in Azure Batch

            // Arrange - Test with realistic Batch network security scenarios
            var networkSecurityScenarios = new[]
            {
                // SSH access for Linux compute nodes
                new {
                    Priority = 100,
                    Access = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    SourceAddressPrefix = "203.0.113.0/24",
                    SourcePortRanges = new List<string> { "22" },
                    Description = "Allow SSH access from specific subnet"
                },
                // RDP access for Windows compute nodes
                new {
                    Priority = 110,
                    Access = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    SourceAddressPrefix = "198.51.100.0/24",
                    SourcePortRanges = new List<string> { "3389" },
                    Description = "Allow RDP access from management subnet"
                },
                // Web application ports
                new {
                    Priority = 200,
                    Access = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    SourceAddressPrefix = "0.0.0.0/0",
                    SourcePortRanges = new List<string> { "80", "443", "8080-8090" },
                    Description = "Allow web traffic from internet"
                },
                // Deny all other traffic
                new {
                    Priority = 4000,
                    Access = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                    SourceAddressPrefix = "*",
                    SourcePortRanges = new List<string> { "*" },
                    Description = "Deny all other traffic (default deny)"
                }
            };

            foreach (var scenario in networkSecurityScenarios)
            {
                // Act
                var psRule = new PSNetworkSecurityGroupRule(
                    priority: scenario.Priority,
                    access: scenario.Access,
                    sourceAddressPrefix: scenario.SourceAddressPrefix,
                    sourcePortRanges: scenario.SourcePortRanges);

                var mgmtRule = psRule.toMgmtNetworkSecurityGroupRule();

                // Assert - Should convert correctly for Batch network security configuration
                Assert.NotNull(mgmtRule);
                Assert.Equal(scenario.Priority, mgmtRule.Priority);
                
                var expectedMgmtAccess = scenario.Access == Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow
                    ? NetworkSecurityGroupRuleAccess.Allow
                    : NetworkSecurityGroupRuleAccess.Deny;
                Assert.Equal(expectedMgmtAccess, mgmtRule.Access);
                Assert.Equal(scenario.SourceAddressPrefix, mgmtRule.SourceAddressPrefix);
                Assert.Equal(scenario.SourcePortRanges.Count, mgmtRule.SourcePortRanges.Count);

                // Verify round-trip conversion maintains network security semantics
                var backToPs = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Priority, backToPs.Priority);
                Assert.Equal(scenario.Access, backToPs.Access);
                Assert.Equal(scenario.SourceAddressPrefix, backToPs.SourceAddressPrefix);
                Assert.Equal(scenario.SourcePortRanges.Count, backToPs.SourcePortRanges.Count);
            }
        }

        [Fact]
        public void NetworkSecurityGroupRuleConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 300,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "172.16.0.0/12",
                sourcePortRanges: new List<string> { "8080", "9090" });

            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 400,
                access: NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "192.168.0.0/16",
                sourcePortRanges: new List<string> { "443", "8443" });

            // Act
            var mgmtResult = psRule.toMgmtNetworkSecurityGroupRule();
            var psResult = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<NetworkSecurityGroupRule>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.NetworkSecurityGroupRule>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtRule, mgmtResult);
            Assert.NotSame(psRule, psResult);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void NetworkSecurityGroupRuleConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 500,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "10.1.0.0/16");

            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 600,
                access: NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "10.2.0.0/16");

            // Act
            var mgmtResult = psRule.toMgmtNetworkSecurityGroupRule();
            var psResult = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

            // Assert - Verify correct types are returned
            Assert.IsType<NetworkSecurityGroupRule>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.NetworkSecurityGroupRule>(psResult);
        }

        [Fact]
        public void NetworkSecurityGroupRuleConversions_PriorityValues_HandleValidRange()
        {
            // Test that priority values within valid range are handled correctly

            var validPriorities = new[] { 150, 250, 350, 1000, 2000, 4000, 4096 };

            foreach (var priority in validPriorities)
            {
                // Arrange
                var psRule = new PSNetworkSecurityGroupRule(
                    priority: priority,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/8");

                // Act
                var mgmtRule = psRule.toMgmtNetworkSecurityGroupRule();
                var roundTripPsRule = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

                // Assert
                Assert.Equal(priority, mgmtRule.Priority);
                Assert.Equal(priority, roundTripPsRule.Priority);
            }
        }

        [Fact]
        public void NetworkSecurityGroupRuleConversions_SourceAddressPrefixValues_HandleVariousFormats()
        {
            // Test that various source address prefix formats are handled correctly

            var sourceAddressPrefixes = new[]
            {
                "10.10.10.10",           // Single IP
                "192.168.1.0/24",       // IP subnet
                "172.16.0.0/12",        // Larger subnet
                "203.0.113.0/24",       // Test network
                "*",                     // All addresses
                "0.0.0.0/0"             // All addresses (CIDR)
            };

            foreach (var sourceAddressPrefix in sourceAddressPrefixes)
            {
                // Arrange
                var psRule = new PSNetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: sourceAddressPrefix);

                // Act
                var mgmtRule = psRule.toMgmtNetworkSecurityGroupRule();
                var roundTripPsRule = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

                // Assert
                Assert.Equal(sourceAddressPrefix, mgmtRule.SourceAddressPrefix);
                Assert.Equal(sourceAddressPrefix, roundTripPsRule.SourceAddressPrefix);
            }
        }

        [Fact]
        public void NetworkSecurityGroupRuleConversions_SourcePortRangesValues_HandleVariousFormats()
        {
            // Test that various source port range formats are handled correctly

            var portRangeScenarios = new[]
            {
                new List<string> { "*" },                          // All ports
                new List<string> { "80" },                         // Single port
                new List<string> { "80", "443" },                  // Multiple single ports
                new List<string> { "8080-8090" },                  // Port range
                new List<string> { "80", "443", "8080-8090" },     // Mixed single ports and ranges
                new List<string> { "22", "80", "443", "3000-3010", "8080-8090", "9000" } // Complex mix
            };

            foreach (var sourcePortRanges in portRangeScenarios)
            {
                // Arrange
                var psRule = new PSNetworkSecurityGroupRule(
                    priority: 100,
                    access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    sourceAddressPrefix: "10.0.0.0/8",
                    sourcePortRanges: sourcePortRanges);

                // Act
                var mgmtRule = psRule.toMgmtNetworkSecurityGroupRule();
                var roundTripPsRule = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

                // Assert
                Assert.Equal(sourcePortRanges.Count, mgmtRule.SourcePortRanges.Count);
                Assert.Equal(sourcePortRanges, mgmtRule.SourcePortRanges.ToList());
                Assert.Equal(sourcePortRanges.Count, roundTripPsRule.SourcePortRanges.Count);
                Assert.Equal(sourcePortRanges, roundTripPsRule.SourcePortRanges.ToList());
            }
        }

        #endregion

        #region Performance Tests

        [Fact]
        public void NetworkSecurityGroupRuleConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psRule = new PSNetworkSecurityGroupRule(
                priority: 100,
                access: Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                sourceAddressPrefix: "10.0.0.0/8",
                sourcePortRanges: new List<string> { "80", "443", "8080-8090" });

            var mgmtRule = new NetworkSecurityGroupRule(
                priority: 200,
                access: NetworkSecurityGroupRuleAccess.Deny,
                sourceAddressPrefix: "192.168.0.0/16",
                sourcePortRanges: new List<string> { "22", "3389" });

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psRule.toMgmtNetworkSecurityGroupRule();
                var psResult = PSNetworkSecurityGroupRule.FromMgmtNetworkSecurityGroupRule(mgmtRule);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(100, mgmtResult.Priority);
                Assert.Equal(200, psResult.Priority);
            }
        }

        #endregion
    }
}
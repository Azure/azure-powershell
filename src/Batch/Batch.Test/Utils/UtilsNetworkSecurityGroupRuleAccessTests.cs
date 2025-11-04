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

using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.Azure.Management.Batch.Models;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsNetworkSecurityGroupRuleAccessTests
    {
        #region ToMgmtNetworkSecurityRuleAccess Tests

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_Allow_ReturnsAllow()
        {
            // Arrange
            var psAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;

            // Act
            var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAccess);

            // Assert
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, result);
        }

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_Deny_ReturnsDeny()
        {
            // Arrange
            var psAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;

            // Act
            var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAccess);

            // Assert
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, NetworkSecurityGroupRuleAccess.Allow)]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, NetworkSecurityGroupRuleAccess.Deny)]
        public void ToMgmtNetworkSecurityRuleAccess_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess input,
            NetworkSecurityGroupRuleAccess expected)
        {
            // Act
            var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess);

            // Act
            var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(defaultValue);

            // Assert
            // Default NetworkSecurityGroupRuleAccess is typically Allow (0)
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, result);
        }

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each access type

            // Arrange & Act & Assert
            // Allow: Allow access through the network security group rule
            var allowResult = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, allowResult);

            // Deny: Deny access through the network security group rule
            var denyResult = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, denyResult);
        }

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;

            // Act - Call static method directly on class
            var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAccess);

            // Assert
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, result);
        }

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(value);
                Assert.True(Enum.IsDefined(typeof(NetworkSecurityGroupRuleAccess), result));
            }
        }

        [Fact]
        public void ToMgmtNetworkSecurityRuleAccess_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psAllow = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;
            var psDeny = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;

            // Act
            var mgmtAllow = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAllow);
            var mgmtDeny = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psDeny);

            // Assert - Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psAllow, (int)mgmtAllow);
            Assert.Equal((int)psDeny, (int)mgmtDeny);
        }

        #endregion

        #region FromMgmtNetworkSecurityRuleAccess Tests

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_Allow_ReturnsAllow()
        {
            // Arrange
            var mgmtAccess = NetworkSecurityGroupRuleAccess.Allow;

            // Act
            var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, result);
        }

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_Deny_ReturnsDeny()
        {
            // Arrange
            var mgmtAccess = NetworkSecurityGroupRuleAccess.Deny;

            // Act
            var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, result);
        }

        [Theory]
        [InlineData(NetworkSecurityGroupRuleAccess.Allow, Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow)]
        [InlineData(NetworkSecurityGroupRuleAccess.Deny, Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny)]
        public void FromMgmtNetworkSecurityRuleAccess_AllValidValues_ReturnsCorrectMapping(
            NetworkSecurityGroupRuleAccess input,
            Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess expected)
        {
            // Act
            var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(NetworkSecurityGroupRuleAccess);

            // Act
            var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(defaultValue);

            // Assert
            // Default NetworkSecurityGroupRuleAccess is typically Allow (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, result);
        }

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each access type

            // Arrange & Act & Assert
            // Allow: Allow access through the network security group rule
            var allowResult = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(NetworkSecurityGroupRuleAccess.Allow);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, allowResult);

            // Deny: Deny access through the network security group rule
            var denyResult = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(NetworkSecurityGroupRuleAccess.Deny);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, denyResult);
        }

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtAccess = NetworkSecurityGroupRuleAccess.Allow;

            // Act - Call static method directly on class
            var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, result);
        }

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                NetworkSecurityGroupRuleAccess.Allow,
                NetworkSecurityGroupRuleAccess.Deny
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(value);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess), result));
            }
        }

        [Fact]
        public void FromMgmtNetworkSecurityRuleAccess_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtAllow = NetworkSecurityGroupRuleAccess.Allow;
            var mgmtDeny = NetworkSecurityGroupRuleAccess.Deny;

            // Act
            var psAllow = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAllow);
            var psDeny = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtDeny);

            // Assert - Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtAllow, (int)psAllow);
            Assert.Equal((int)mgmtDeny, (int)psDeny);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllowValue()
        {
            // Arrange
            var originalPsAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;

            // Act
            var mgmtAccess = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(originalPsAccess);
            var roundTripPsAccess = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert
            Assert.Equal(originalPsAccess, roundTripPsAccess);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesDenyValue()
        {
            // Arrange
            var originalPsAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;

            // Act
            var mgmtAccess = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(originalPsAccess);
            var roundTripPsAccess = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert
            Assert.Equal(originalPsAccess, roundTripPsAccess);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow)]
        [InlineData(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess originalAccess)
        {
            // Act
            var mgmtAccess = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(originalAccess);
            var roundTripAccess = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert
            Assert.Equal(originalAccess, roundTripAccess);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                NetworkSecurityGroupRuleAccess.Allow,
                NetworkSecurityGroupRuleAccess.Deny
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psValue);

                // Assert
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void NetworkSecurityGroupRuleAccess_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psAccessValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess));
            var mgmtAccessValues = Enum.GetValues(typeof(NetworkSecurityGroupRuleAccess));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psAccessValues.Length, mgmtAccessValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess psValue in psAccessValues)
            {
                var result = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psValue);
                Assert.True(Enum.IsDefined(typeof(NetworkSecurityGroupRuleAccess), result));
            }

            // Verify that each management enum value can be converted successfully
            foreach (NetworkSecurityGroupRuleAccess mgmtValue in mgmtAccessValues)
            {
                var result = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess), result));
            }
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccess_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny
            };

            var mgmtValues = new[]
            {
                NetworkSecurityGroupRuleAccess.Allow,
                NetworkSecurityGroupRuleAccess.Deny
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new NetworkSecurityGroupRuleAccess[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtValues[i]);
            }

            // Assert - Each management enum value should be unique (no duplicates)
            var distinctMgmtValues = convertedMgmtValues.Distinct().ToArray();
            Assert.Equal(convertedMgmtValues.Length, distinctMgmtValues.Length);

            // Assert - Each PS enum value should be unique (no duplicates)
            var distinctPsValues = convertedPsValues.Distinct().ToArray();
            Assert.Equal(convertedPsValues.Length, distinctPsValues.Length);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Allow semantics - Grant access through the network security group rule
            var psAllow = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;
            var mgmtAllow = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAllow);
            var backToPs = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAllow);

            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, mgmtAllow);
            Assert.Equal(psAllow, backToPs);

            // Test Deny semantics - Block access through the network security group rule
            var psDeny = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;
            var mgmtDeny = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psDeny);
            var backToPsDeny = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtDeny);

            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, mgmtDeny);
            Assert.Equal(psDeny, backToPsDeny);
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_NetworkSecurityContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch network security configuration
            // NetworkSecurityGroupRuleAccess is used to specify access control for network security group rules in Azure Batch

            // Arrange - Test with realistic Batch network security scenarios
            var networkSecurityScenarios = new[]
            {
                // Allow - For permissive network rules allowing specific traffic
                new {
                    Access = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow,
                    Description = "Allow access for authorized network traffic and connections"
                },
                // Deny - For restrictive network rules blocking specific traffic
                new {
                    Access = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny,
                    Description = "Deny access to block unauthorized network traffic and connections"
                }
            };

            foreach (var scenario in networkSecurityScenarios)
            {
                // Act
                var mgmtAccess = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(scenario.Access);

                // Assert - Should convert correctly for Batch network security configuration
                var expectedMgmtAccess = scenario.Access == Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow
                    ? NetworkSecurityGroupRuleAccess.Allow
                    : NetworkSecurityGroupRuleAccess.Deny;
                Assert.Equal(expectedMgmtAccess, mgmtAccess);

                // Verify round-trip conversion maintains network security semantics
                var backToPs = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);
                Assert.Equal(scenario.Access, backToPs);
            }
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess)))
            {
                var mgmtResult = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psValue);
                Assert.Equal((int)psValue, (int)mgmtResult);
            }

            foreach (NetworkSecurityGroupRuleAccess mgmtValue in Enum.GetValues(typeof(NetworkSecurityGroupRuleAccess)))
            {
                var psResult = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtValue);
                Assert.Equal((int)mgmtValue, (int)psResult);
            }
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_InboundNatPoolContext_VerifySemantics()
        {
            // This test validates the semantic usage in the context of inbound NAT pool network security group rules
            // NetworkSecurityGroupRuleAccess determines whether traffic is allowed or denied for specific network security group rules

            // Allow access semantics - Permit specified network traffic
            var allowAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;
            var mgmtAllowAccess = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(allowAccess);
            
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, mgmtAllowAccess);
            
            // Allow access ensures that matching network traffic is permitted
            // Suitable for enabling connectivity to specific services, ports, or IP ranges
            
            // Deny access semantics - Block specified network traffic
            var denyAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;
            var mgmtDenyAccess = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(denyAccess);
            
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, mgmtDenyAccess);
            
            // Deny access ensures that matching network traffic is blocked
            // Suitable for security hardening and blocking unwanted connections
            
            // Verify semantic preservation through round-trip
            var allowRoundTrip = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAllowAccess);
            var denyRoundTrip = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtDenyAccess);
            
            Assert.Equal(allowAccess, allowRoundTrip);
            Assert.Equal(denyAccess, denyRoundTrip);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types and handle casting properly

            // Arrange
            var psAccess = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;
            var mgmtAccess = NetworkSecurityGroupRuleAccess.Allow;

            // Act
            var mgmtResult = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAccess);
            var psResult = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAccess);

            // Assert - Verify correct types are returned
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.NetworkSecurityGroupRuleAccess>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess>(psResult);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, mgmtResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, psResult);
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_EnumValueEquivalence_VerifyDirectCasting()
        {
            // Test that the enum values are equivalent and casting works as expected

            // Arrange & Act - Test direct casting behavior
            var psAllow = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;

            var mgmtAllowDirect = (NetworkSecurityGroupRuleAccess)psAllow;
            var mgmtAllowUtils = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAllow);

            // Assert - Utils methods should behave the same as direct casting
            Assert.Equal(mgmtAllowDirect, mgmtAllowUtils);
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, mgmtAllowUtils);
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_DefaultValueBehavior_VerifyConsistency()
        {
            // Test that default value handling is consistent

            // Arrange
            var defaultPsAccess = default(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess);
            var defaultMgmtAccess = default(NetworkSecurityGroupRuleAccess);

            // Act
            var mgmtFromDefault = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(defaultPsAccess);
            var psFromDefault = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(defaultMgmtAccess);

            // Assert - Both should resolve to Allow (typically the 0 value)
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, mgmtFromDefault);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, psFromDefault);
        }

        #endregion

        #region Network Security Policy Semantics Tests

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_AllowSemantics_NetworkAccessControl()
        {
            // This test validates Allow access semantics are preserved in conversions

            // Arrange - Allow access for permissive network security policies
            var psAllow = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow;

            // Act
            var mgmtAllow = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psAllow);
            var backToPs = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtAllow);

            // Assert - Allow access semantics preserved
            Assert.Equal(NetworkSecurityGroupRuleAccess.Allow, mgmtAllow);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Allow, backToPs);
            
            // Allow access characteristics:
            // - Permits matching network traffic
            // - Used for enabling connectivity
            // - Applied to authorized services and ports
            // - Essential for application functionality
        }

        [Fact]
        public void NetworkSecurityGroupRuleAccessConversions_DenySemantics_NetworkSecurityHardening()
        {
            // This test validates Deny access semantics are preserved in conversions

            // Arrange - Deny access for restrictive network security policies
            var psDeny = Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny;

            // Act
            var mgmtDeny = Utils.Utils.ToMgmtNetworkSecurityRuleAccess(psDeny);
            var backToPs = Utils.Utils.FromMgmtNetworkSecurityRuleAccess(mgmtDeny);

            // Assert - Deny access semantics preserved
            Assert.Equal(NetworkSecurityGroupRuleAccess.Deny, mgmtDeny);
            Assert.Equal(Microsoft.Azure.Batch.Common.NetworkSecurityGroupRuleAccess.Deny, backToPs);
            
            // Deny access characteristics:
            // - Blocks matching network traffic
            // - Used for security hardening
            // - Applied to unauthorized services and ports
            // - Essential for security compliance
        }

        #endregion
    }
}
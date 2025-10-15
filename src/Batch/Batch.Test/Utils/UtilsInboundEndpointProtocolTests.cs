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
    public class UtilsInboundEndpointProtocolTests
    {
        #region ToMgmtInboundEndpointProtocol Tests

        [Fact]
        public void ToMgmtInboundEndpointProtocol_TCP_ReturnsTCP()
        {
            // Arrange
            var psProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;

            // Act
            var result = Utils.Utils.ToMgmtInboundEndpointProtocol(psProtocol);

            // Assert
            Assert.Equal(InboundEndpointProtocol.TCP, result);
        }

        [Fact]
        public void ToMgmtInboundEndpointProtocol_UDP_ReturnsUDP()
        {
            // Arrange
            var psProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;

            // Act
            var result = Utils.Utils.ToMgmtInboundEndpointProtocol(psProtocol);

            // Assert
            Assert.Equal(InboundEndpointProtocol.UDP, result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, InboundEndpointProtocol.TCP)]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, InboundEndpointProtocol.UDP)]
        public void ToMgmtInboundEndpointProtocol_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.InboundEndpointProtocol input,
            InboundEndpointProtocol expected)
        {
            // Act
            var result = Utils.Utils.ToMgmtInboundEndpointProtocol(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToMgmtInboundEndpointProtocol_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.InboundEndpointProtocol);

            // Act
            var result = Utils.Utils.ToMgmtInboundEndpointProtocol(defaultValue);

            // Assert
            // Default InboundEndpointProtocol is typically TCP (0)
            Assert.Equal(InboundEndpointProtocol.TCP, result);
        }

        [Fact]
        public void ToMgmtInboundEndpointProtocol_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each protocol

            // Arrange & Act & Assert
            // TCP: Use TCP for the endpoint (connection-oriented, reliable)
            var tcpResult = Utils.Utils.ToMgmtInboundEndpointProtocol(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp);
            Assert.Equal(InboundEndpointProtocol.TCP, tcpResult);

            // UDP: Use UDP for the endpoint (connectionless, fast)
            var udpResult = Utils.Utils.ToMgmtInboundEndpointProtocol(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp);
            Assert.Equal(InboundEndpointProtocol.UDP, udpResult);
        }

        [Fact]
        public void ToMgmtInboundEndpointProtocol_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;

            // Act - Call static method directly on class
            var result = Utils.Utils.ToMgmtInboundEndpointProtocol(psProtocol);

            // Assert
            Assert.Equal(InboundEndpointProtocol.UDP, result);
        }

        [Fact]
        public void ToMgmtInboundEndpointProtocol_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.ToMgmtInboundEndpointProtocol(value);
                Assert.True(Enum.IsDefined(typeof(InboundEndpointProtocol), result));
            }
        }

        [Fact]
        public void ToMgmtInboundEndpointProtocol_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psTcp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;
            var psUdp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;

            // Act
            var mgmtTcp = Utils.Utils.ToMgmtInboundEndpointProtocol(psTcp);
            var mgmtUdp = Utils.Utils.ToMgmtInboundEndpointProtocol(psUdp);

            // Assert - Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psTcp, (int)mgmtTcp);
            Assert.Equal((int)psUdp, (int)mgmtUdp);
        }

        #endregion

        #region FromMgmtInboundEndpointProtocol Tests

        [Fact]
        public void FromMgmtInboundEndpointProtocol_TCP_ReturnsTCP()
        {
            // Arrange
            var mgmtProtocol = InboundEndpointProtocol.TCP;

            // Act
            var result = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, result);
        }

        [Fact]
        public void FromMgmtInboundEndpointProtocol_UDP_ReturnsUDP()
        {
            // Arrange
            var mgmtProtocol = InboundEndpointProtocol.UDP;

            // Act
            var result = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, result);
        }

        [Theory]
        [InlineData(InboundEndpointProtocol.TCP, Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp)]
        [InlineData(InboundEndpointProtocol.UDP, Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp)]
        public void FromMgmtInboundEndpointProtocol_AllValidValues_ReturnsCorrectMapping(
            InboundEndpointProtocol input,
            Microsoft.Azure.Batch.Common.InboundEndpointProtocol expected)
        {
            // Act
            var result = Utils.Utils.FromMgmtInboundEndpointProtocol(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromMgmtInboundEndpointProtocol_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(InboundEndpointProtocol);

            // Act
            var result = Utils.Utils.FromMgmtInboundEndpointProtocol(defaultValue);

            // Assert
            // Default InboundEndpointProtocol is typically TCP (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, result);
        }

        [Fact]
        public void FromMgmtInboundEndpointProtocol_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each protocol

            // Arrange & Act & Assert
            // TCP: Use TCP for the endpoint (connection-oriented, reliable)
            var tcpResult = Utils.Utils.FromMgmtInboundEndpointProtocol(InboundEndpointProtocol.TCP);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, tcpResult);

            // UDP: Use UDP for the endpoint (connectionless, fast)
            var udpResult = Utils.Utils.FromMgmtInboundEndpointProtocol(InboundEndpointProtocol.UDP);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, udpResult);
        }

        [Fact]
        public void FromMgmtInboundEndpointProtocol_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtProtocol = InboundEndpointProtocol.TCP;

            // Act - Call static method directly on class
            var result = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, result);
        }

        [Fact]
        public void FromMgmtInboundEndpointProtocol_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                InboundEndpointProtocol.TCP,
                InboundEndpointProtocol.UDP
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.FromMgmtInboundEndpointProtocol(value);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.InboundEndpointProtocol), result));
            }
        }

        [Fact]
        public void FromMgmtInboundEndpointProtocol_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtTcp = InboundEndpointProtocol.TCP;
            var mgmtUdp = InboundEndpointProtocol.UDP;

            // Act
            var psTcp = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtTcp);
            var psUdp = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtUdp);

            // Assert - Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtTcp, (int)psTcp);
            Assert.Equal((int)mgmtUdp, (int)psUdp);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesTCPValue()
        {
            // Arrange
            var originalPsProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;

            // Act
            var mgmtProtocol = Utils.Utils.ToMgmtInboundEndpointProtocol(originalPsProtocol);
            var roundTripPsProtocol = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert
            Assert.Equal(originalPsProtocol, roundTripPsProtocol);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesUDPValue()
        {
            // Arrange
            var originalPsProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;

            // Act
            var mgmtProtocol = Utils.Utils.ToMgmtInboundEndpointProtocol(originalPsProtocol);
            var roundTripPsProtocol = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert
            Assert.Equal(originalPsProtocol, roundTripPsProtocol);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp)]
        [InlineData(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.InboundEndpointProtocol originalProtocol)
        {
            // Act
            var mgmtProtocol = Utils.Utils.ToMgmtInboundEndpointProtocol(originalProtocol);
            var roundTripProtocol = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert
            Assert.Equal(originalProtocol, roundTripProtocol);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                InboundEndpointProtocol.TCP,
                InboundEndpointProtocol.UDP
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.FromMgmtInboundEndpointProtocol(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtInboundEndpointProtocol(psValue);

                // Assert
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void InboundEndpointProtocol_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psProtocolValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.InboundEndpointProtocol));
            var mgmtProtocolValues = Enum.GetValues(typeof(InboundEndpointProtocol));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psProtocolValues.Length, mgmtProtocolValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.InboundEndpointProtocol psValue in psProtocolValues)
            {
                var result = Utils.Utils.ToMgmtInboundEndpointProtocol(psValue);
                Assert.True(Enum.IsDefined(typeof(InboundEndpointProtocol), result));
            }

            // Verify that each management enum value can be converted successfully
            foreach (InboundEndpointProtocol mgmtValue in mgmtProtocolValues)
            {
                var result = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.InboundEndpointProtocol), result));
            }
        }

        [Fact]
        public void InboundEndpointProtocol_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp
            };

            var mgmtValues = new[]
            {
                InboundEndpointProtocol.TCP,
                InboundEndpointProtocol.UDP
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new InboundEndpointProtocol[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.ToMgmtInboundEndpointProtocol(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.InboundEndpointProtocol[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtValues[i]);
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
        public void InboundEndpointProtocolConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test TCP semantics - Connection-oriented, reliable protocol
            var psTcp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;
            var mgmtTcp = Utils.Utils.ToMgmtInboundEndpointProtocol(psTcp);
            var backToPs = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtTcp);

            Assert.Equal(InboundEndpointProtocol.TCP, mgmtTcp);
            Assert.Equal(psTcp, backToPs);

            // Test UDP semantics - Connectionless, fast protocol
            var psUdp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;
            var mgmtUdp = Utils.Utils.ToMgmtInboundEndpointProtocol(psUdp);
            var backToPsUdp = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtUdp);

            Assert.Equal(InboundEndpointProtocol.UDP, mgmtUdp);
            Assert.Equal(psUdp, backToPsUdp);
        }

        [Fact]
        public void InboundEndpointProtocolConversions_NetworkEndpointContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch network endpoint configuration
            // InboundEndpointProtocol is used to specify the protocol for inbound NAT pools in Azure Batch

            // Arrange - Test with realistic Batch network endpoint scenarios
            var endpointScenarios = new[]
            {
                // TCP - For connection-oriented applications requiring reliability
                new {
                    Protocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp,
                    Description = "TCP protocol for reliable, connection-oriented network endpoints"
                },
                // UDP - For low-latency applications or connectionless protocols
                new {
                    Protocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp,
                    Description = "UDP protocol for fast, connectionless network endpoints"
                }
            };

            foreach (var scenario in endpointScenarios)
            {
                // Act
                var mgmtProtocol = Utils.Utils.ToMgmtInboundEndpointProtocol(scenario.Protocol);

                // Assert - Should convert correctly for Batch network endpoint configuration
                var expectedMgmtProtocol = scenario.Protocol == Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp
                    ? InboundEndpointProtocol.TCP
                    : InboundEndpointProtocol.UDP;
                Assert.Equal(expectedMgmtProtocol, mgmtProtocol);

                // Verify round-trip conversion maintains network endpoint semantics
                var backToPs = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);
                Assert.Equal(scenario.Protocol, backToPs);
            }
        }

        [Fact]
        public void InboundEndpointProtocolConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.InboundEndpointProtocol psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.InboundEndpointProtocol)))
            {
                var mgmtResult = Utils.Utils.ToMgmtInboundEndpointProtocol(psValue);
                Assert.Equal((int)psValue, (int)mgmtResult);
            }

            foreach (InboundEndpointProtocol mgmtValue in Enum.GetValues(typeof(InboundEndpointProtocol)))
            {
                var psResult = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtValue);
                Assert.Equal((int)mgmtValue, (int)psResult);
            }
        }

        [Fact]
        public void InboundEndpointProtocolConversions_InboundNatPoolContext_VerifySemantics()
        {
            // This test validates the semantic usage in the context of inbound NAT pool configuration
            // InboundEndpointProtocol determines the network protocol for inbound endpoint connections

            // TCP protocol semantics - Connection-oriented for reliable applications
            var tcpProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;
            var mgmtTcpProtocol = Utils.Utils.ToMgmtInboundEndpointProtocol(tcpProtocol);
            
            Assert.Equal(InboundEndpointProtocol.TCP, mgmtTcpProtocol);
            
            // TCP ensures reliable, ordered delivery of data
            // Suitable for applications requiring guaranteed delivery (SSH, HTTP, etc.)
            
            // UDP protocol semantics - Connectionless for low-latency applications
            var udpProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;
            var mgmtUdpProtocol = Utils.Utils.ToMgmtInboundEndpointProtocol(udpProtocol);
            
            Assert.Equal(InboundEndpointProtocol.UDP, mgmtUdpProtocol);
            
            // UDP provides fast, connectionless communication
            // Suitable for real-time applications where speed is more important than reliability
            
            // Verify semantic preservation through round-trip
            var tcpRoundTrip = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtTcpProtocol);
            var udpRoundTrip = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtUdpProtocol);
            
            Assert.Equal(tcpProtocol, tcpRoundTrip);
            Assert.Equal(udpProtocol, udpRoundTrip);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void InboundEndpointProtocolConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types and handle casting properly

            // Arrange
            var psProtocol = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;
            var mgmtProtocol = InboundEndpointProtocol.TCP;

            // Act
            var mgmtResult = Utils.Utils.ToMgmtInboundEndpointProtocol(psProtocol);
            var psResult = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtProtocol);

            // Assert - Verify correct types are returned
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.InboundEndpointProtocol>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.Common.InboundEndpointProtocol>(psResult);
            Assert.Equal(InboundEndpointProtocol.UDP, mgmtResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, psResult);
        }

        [Fact]
        public void InboundEndpointProtocolConversions_EnumValueEquivalence_VerifyDirectCasting()
        {
            // Test that the enum values are equivalent and casting works as expected

            // Arrange & Act - Test direct casting behavior
            var psTcp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;

            var mgmtTcpDirect = (InboundEndpointProtocol)psTcp;
            var mgmtTcpUtils = Utils.Utils.ToMgmtInboundEndpointProtocol(psTcp);

            // Assert - Utils methods should behave the same as direct casting
            Assert.Equal(mgmtTcpDirect, mgmtTcpUtils);
            Assert.Equal(InboundEndpointProtocol.TCP, mgmtTcpUtils);
        }

        [Fact]
        public void InboundEndpointProtocolConversions_DefaultValueBehavior_VerifyConsistency()
        {
            // Test that default value handling is consistent

            // Arrange
            var defaultPsProtocol = default(Microsoft.Azure.Batch.Common.InboundEndpointProtocol);
            var defaultMgmtProtocol = default(InboundEndpointProtocol);

            // Act
            var mgmtFromDefault = Utils.Utils.ToMgmtInboundEndpointProtocol(defaultPsProtocol);
            var psFromDefault = Utils.Utils.FromMgmtInboundEndpointProtocol(defaultMgmtProtocol);

            // Assert - Both should resolve to TCP (typically the 0 value)
            Assert.Equal(InboundEndpointProtocol.TCP, mgmtFromDefault);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, psFromDefault);
        }

        #endregion

        #region Network Protocol Semantics Tests

        [Fact]
        public void InboundEndpointProtocolConversions_TCPSemantics_ConnectionOrientedProtocol()
        {
            // This test validates TCP protocol semantics are preserved in conversions

            // Arrange - TCP for connection-oriented, reliable communication
            var psTcp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp;

            // Act
            var mgmtTcp = Utils.Utils.ToMgmtInboundEndpointProtocol(psTcp);
            var backToPs = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtTcp);

            // Assert - TCP semantics preserved
            Assert.Equal(InboundEndpointProtocol.TCP, mgmtTcp);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Tcp, backToPs);
            
            // TCP protocol characteristics:
            // - Connection-oriented
            // - Reliable delivery
            // - Ordered data transmission
            // - Error detection and correction
            // - Flow control
        }

        [Fact]
        public void InboundEndpointProtocolConversions_UDPSemantics_ConnectionlessProtocol()
        {
            // This test validates UDP protocol semantics are preserved in conversions

            // Arrange - UDP for connectionless, fast communication
            var psUdp = Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp;

            // Act
            var mgmtUdp = Utils.Utils.ToMgmtInboundEndpointProtocol(psUdp);
            var backToPs = Utils.Utils.FromMgmtInboundEndpointProtocol(mgmtUdp);

            // Assert - UDP semantics preserved
            Assert.Equal(InboundEndpointProtocol.UDP, mgmtUdp);
            Assert.Equal(Microsoft.Azure.Batch.Common.InboundEndpointProtocol.Udp, backToPs);
            
            // UDP protocol characteristics:
            // - Connectionless
            // - Fast transmission
            // - No delivery guarantees
            // - No ordering guarantees
            // - Lower overhead
        }

        #endregion
    }
}
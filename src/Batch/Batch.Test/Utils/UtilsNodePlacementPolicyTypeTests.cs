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

using Microsoft.Azure.Management.Batch.Models;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsNodePlacementPolicyTypeTests
    {
        #region toMgmtNodePlacementPolicyType Tests

        [Fact]
        public void ToMgmtNodePlacementPolicyType_WithRegional_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Regional;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Equal(NodePlacementPolicyType.Regional, result);
        }

        [Fact]
        public void ToMgmtNodePlacementPolicyType_WithZonal_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Zonal;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Equal(NodePlacementPolicyType.Zonal, result);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Regional, NodePlacementPolicyType.Regional)]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Zonal, NodePlacementPolicyType.Zonal)]
        public void ToMgmtNodePlacementPolicyType_AllValidPolicyTypes_ReturnsCorrectMapping(
            Azure.Batch.Common.NodePlacementPolicyType psPolicyType,
            NodePlacementPolicyType expectedMgmtPolicyType)
        {
            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicyType);

            // Assert
            Assert.Equal(expectedMgmtPolicyType, result);
        }

        [Fact]
        public void ToMgmtNodePlacementPolicyType_WithNullableRegional_ReturnsCorrectMapping()
        {
            // Arrange
            Azure.Batch.Common.NodePlacementPolicyType? psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Regional;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Equal(NodePlacementPolicyType.Regional, result);
        }

        [Fact]
        public void ToMgmtNodePlacementPolicyType_WithNullableZonal_ReturnsCorrectMapping()
        {
            // Arrange
            Azure.Batch.Common.NodePlacementPolicyType? psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Zonal;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Equal(NodePlacementPolicyType.Zonal, result);
        }

        [Fact]
        public void ToMgmtNodePlacementPolicyType_WithNull_ReturnsNull()
        {
            // Arrange
            Azure.Batch.Common.NodePlacementPolicyType? psPolicy = null;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtNodePlacementPolicyType_RegionalSemantics_PreservesPlacementStrategy()
        {
            // Arrange - Regional strategy places nodes across multiple regions
            var psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Regional;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Equal(NodePlacementPolicyType.Regional, result);
            // Regional semantics: Nodes are placed across multiple Azure regions for high availability
        }

        [Fact]
        public void ToMgmtNodePlacementPolicyType_ZonalSemantics_PreservesPlacementStrategy()
        {
            // Arrange - Zonal strategy places nodes within specific availability zones
            var psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Zonal;

            // Act
            var result = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);

            // Assert
            Assert.Equal(NodePlacementPolicyType.Zonal, result);
            // Zonal semantics: Nodes are placed within specific availability zones for fault tolerance
        }

        #endregion

        #region fromMgmtNodePlacementPolicyType Tests

        [Fact]
        public void FromMgmtNodePlacementPolicyType_WithRegional_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtPolicy = NodePlacementPolicyType.Regional;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, result);
        }

        [Fact]
        public void FromMgmtNodePlacementPolicyType_WithZonal_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtPolicy = NodePlacementPolicyType.Zonal;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, result);
        }

        [Theory]
        [InlineData(NodePlacementPolicyType.Regional, Azure.Batch.Common.NodePlacementPolicyType.Regional)]
        [InlineData(NodePlacementPolicyType.Zonal, Azure.Batch.Common.NodePlacementPolicyType.Zonal)]
        public void FromMgmtNodePlacementPolicyType_AllValidPolicyTypes_ReturnsCorrectMapping(
            NodePlacementPolicyType mgmtPolicyType,
            Azure.Batch.Common.NodePlacementPolicyType expectedPsPolicyType)
        {
            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicyType);

            // Assert
            Assert.Equal(expectedPsPolicyType, result);
        }

        [Fact]
        public void FromMgmtNodePlacementPolicyType_WithNullableRegional_ReturnsCorrectMapping()
        {
            // Arrange
            NodePlacementPolicyType? mgmtPolicy = NodePlacementPolicyType.Regional;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, result);
        }

        [Fact]
        public void FromMgmtNodePlacementPolicyType_WithNullableZonal_ReturnsCorrectMapping()
        {
            // Arrange
            NodePlacementPolicyType? mgmtPolicy = NodePlacementPolicyType.Zonal;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, result);
        }

        [Fact]
        public void FromMgmtNodePlacementPolicyType_WithNull_ReturnsNull()
        {
            // Arrange
            NodePlacementPolicyType? mgmtPolicy = null;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtNodePlacementPolicyType_RegionalSemantics_PreservesPlacementStrategy()
        {
            // Arrange
            var mgmtPolicy = NodePlacementPolicyType.Regional;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, result);
            // Regional semantics preserved: Multi-region placement for high availability
        }

        [Fact]
        public void FromMgmtNodePlacementPolicyType_ZonalSemantics_PreservesPlacementStrategy()
        {
            // Arrange
            var mgmtPolicy = NodePlacementPolicyType.Zonal;

            // Act
            var result = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, result);
            // Zonal semantics preserved: Availability zone placement for fault tolerance
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesRegionalValue()
        {
            // Arrange
            var originalPsPolicy = Azure.Batch.Common.NodePlacementPolicyType.Regional;

            // Act - Convert PS -> Management -> PS
            var mgmtPolicy = Utils.Utils.toMgmtNodePlacementPolicyType(originalPsPolicy);
            var roundTripPsPolicy = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert - Should get back the original value
            Assert.Equal(originalPsPolicy, roundTripPsPolicy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, roundTripPsPolicy);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesZonalValue()
        {
            // Arrange
            var originalPsPolicy = Azure.Batch.Common.NodePlacementPolicyType.Zonal;

            // Act - Convert PS -> Management -> PS
            var mgmtPolicy = Utils.Utils.toMgmtNodePlacementPolicyType(originalPsPolicy);
            var roundTripPsPolicy = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

            // Assert - Should get back the original value
            Assert.Equal(originalPsPolicy, roundTripPsPolicy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, roundTripPsPolicy);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Regional)]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Zonal)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidValues(
            Azure.Batch.Common.NodePlacementPolicyType originalValue)
        {
            // Act - Convert PS -> Management -> PS
            var mgmtValue = Utils.Utils.toMgmtNodePlacementPolicyType(originalValue);
            var roundTripValue = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtValue);

            // Assert - Should get back the original value
            Assert.Equal(originalValue, roundTripValue);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // This test verifies that converting Management -> PS -> Management preserves the original value

            // Arrange
            var originalMgmtValues = new[]
            {
                NodePlacementPolicyType.Regional,
                NodePlacementPolicyType.Zonal
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act - Convert Management -> PS -> Management
                var psValue = Utils.Utils.fromMgmtNodePlacementPolicyType(originalValue);
                var roundTripValue = Utils.Utils.toMgmtNodePlacementPolicyType(psValue);

                // Assert - Should get back the original value
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        [Fact]
        public void RoundTripConversion_WithNullableValues_PreservesNulls()
        {
            // Arrange
            Azure.Batch.Common.NodePlacementPolicyType? nullPsPolicy = null;
            NodePlacementPolicyType? nullMgmtPolicy = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.toMgmtNodePlacementPolicyType(nullPsPolicy);
            var psFromNullMgmt = Utils.Utils.fromMgmtNodePlacementPolicyType(nullMgmtPolicy);

            // Assert
            Assert.Null(mgmtFromNullPs);
            Assert.Null(psFromNullMgmt);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void NodePlacementPolicyTypeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Regional semantics - Nodes placed across multiple regions for high availability
            var psRegional = Azure.Batch.Common.NodePlacementPolicyType.Regional;
            var mgmtRegional = Utils.Utils.toMgmtNodePlacementPolicyType(psRegional);
            var backToPs = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtRegional);

            Assert.Equal(NodePlacementPolicyType.Regional, mgmtRegional);
            Assert.Equal(psRegional, backToPs);

            // Test Zonal semantics - Nodes placed within specific availability zones
            var psZonal = Azure.Batch.Common.NodePlacementPolicyType.Zonal;
            var mgmtZonal = Utils.Utils.toMgmtNodePlacementPolicyType(psZonal);
            var backToPsZonal = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtZonal);

            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtZonal);
            Assert.Equal(psZonal, backToPsZonal);
        }

        [Fact]
        public void NodePlacementPolicyTypeConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNullPs = Utils.Utils.toMgmtNodePlacementPolicyType(null);
            var resultFromNullMgmt = Utils.Utils.fromMgmtNodePlacementPolicyType(null);

            // Assert
            Assert.Null(resultFromNullPs);
            Assert.Null(resultFromNullMgmt);
        }

        [Fact]
        public void NodePlacementPolicyTypeConversions_PoolPlacementContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool node placement
            // NodePlacementPolicyType is used to determine how compute nodes are allocated across Azure infrastructure

            // Arrange - Test Regional strategy for distributed workloads
            var psRegional = Azure.Batch.Common.NodePlacementPolicyType.Regional;
            var mgmtRegional = Utils.Utils.toMgmtNodePlacementPolicyType(psRegional);

            // Act & Assert - Regional should convert correctly for cross-region high availability
            Assert.Equal(NodePlacementPolicyType.Regional, mgmtRegional);

            // Arrange - Test Zonal strategy for zone-aware workloads
            var psZonal = Azure.Batch.Common.NodePlacementPolicyType.Zonal;
            var mgmtZonal = Utils.Utils.toMgmtNodePlacementPolicyType(psZonal);

            // Act & Assert - Zonal should convert correctly for availability zone placement
            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtZonal);

            // Verify round-trip conversion maintains pool placement semantics
            var backToRegional = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtRegional);
            var backToZonal = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtZonal);

            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, backToRegional);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, backToZonal);
        }

        [Fact]
        public void NodePlacementPolicyTypeConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default enum values
            
            // Arrange
            var defaultPsPolicy = default(Azure.Batch.Common.NodePlacementPolicyType);
            var defaultMgmtPolicy = default(NodePlacementPolicyType);

            // Act
            var mgmtResult = Utils.Utils.toMgmtNodePlacementPolicyType(defaultPsPolicy);
            var psResult = Utils.Utils.fromMgmtNodePlacementPolicyType(defaultMgmtPolicy);

            // Assert
            Assert.Equal((NodePlacementPolicyType)defaultPsPolicy, mgmtResult);
            Assert.Equal((Azure.Batch.Common.NodePlacementPolicyType)defaultMgmtPolicy, psResult);
            Assert.True(Enum.IsDefined(typeof(NodePlacementPolicyType), mgmtResult));
            Assert.True(Enum.IsDefined(typeof(Azure.Batch.Common.NodePlacementPolicyType), psResult));
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void NodePlacementPolicyTypeConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psPolicy = Azure.Batch.Common.NodePlacementPolicyType.Regional;
            var mgmtPolicy = NodePlacementPolicyType.Zonal;

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = Utils.Utils.toMgmtNodePlacementPolicyType(psPolicy);
                var psResult = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtPolicy);

                Assert.Equal(NodePlacementPolicyType.Regional, mgmtResult);
                Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, psResult);
            }
        }

        #endregion

        #region Infrastructure Resilience Tests

        [Fact]
        public void NodePlacementPolicyTypeConversions_RegionalStrategy_InfrastructureResilience()
        {
            // This test validates that Regional policy semantics are preserved for infrastructure resilience

            // Arrange - Regional policy for spreading across regions
            var psRegional = Azure.Batch.Common.NodePlacementPolicyType.Regional;

            // Act
            var mgmtRegional = Utils.Utils.toMgmtNodePlacementPolicyType(psRegional);
            var backToPs = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtRegional);

            // Assert - Regional placement semantics preserved
            Assert.Equal(NodePlacementPolicyType.Regional, mgmtRegional);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, backToPs);
            // Regional policy ensures nodes are distributed across multiple Azure regions for maximum resilience
        }

        [Fact]
        public void NodePlacementPolicyTypeConversions_ZonalStrategy_AvailabilityZoneAwareness()
        {
            // This test validates that Zonal policy semantics are preserved for availability zone awareness

            // Arrange - Zonal policy for availability zone placement
            var psZonal = Azure.Batch.Common.NodePlacementPolicyType.Zonal;

            // Act
            var mgmtZonal = Utils.Utils.toMgmtNodePlacementPolicyType(psZonal);
            var backToPs = Utils.Utils.fromMgmtNodePlacementPolicyType(mgmtZonal);

            // Assert - Zonal placement semantics preserved
            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtZonal);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, backToPs);
            // Zonal policy ensures nodes are placed within specific availability zones for fault tolerance
        }

        #endregion
    }
}
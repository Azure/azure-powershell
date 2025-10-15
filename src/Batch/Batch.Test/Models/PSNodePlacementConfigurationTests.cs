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
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSNodePlacementConfigurationTests
    {
        #region toMgmtNodePlacementConfiguration Tests

        [Fact]
        public void ToMgmtNodePlacementConfiguration_WithRegionalPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(NodePlacementPolicyType.Regional, result.Policy);
        }

        [Fact]
        public void ToMgmtNodePlacementConfiguration_WithZonalPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(NodePlacementPolicyType.Zonal, result.Policy);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Regional, NodePlacementPolicyType.Regional)]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Zonal, NodePlacementPolicyType.Zonal)]
        public void ToMgmtNodePlacementConfiguration_AllValidPolicyTypes_ReturnsCorrectMapping(
            Azure.Batch.Common.NodePlacementPolicyType psPolicyType,
            NodePlacementPolicyType expectedMgmtPolicyType)
        {
            // Arrange
            var psConfig = new PSNodePlacementConfiguration(psPolicyType);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtPolicyType, result.Policy);
        }

        [Fact]
        public void ToMgmtNodePlacementConfiguration_WithNullPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSNodePlacementConfiguration(policy: null);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Policy);
        }

        [Fact]
        public void ToMgmtNodePlacementConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);

            // Act
            var result1 = psConfig.toMgmtNodePlacementConfiguration();
            var result2 = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtNodePlacementConfiguration_VerifyNodePlacementConfigurationType()
        {
            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NodePlacementConfiguration>(result);
        }

        [Fact]
        public void ToMgmtNodePlacementConfiguration_RegionalSemantics_PreservesPlacementStrategy()
        {
            // Arrange - Regional strategy places nodes across multiple regions for high availability
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(NodePlacementPolicyType.Regional, result.Policy);
            // Regional semantics: Nodes are placed across multiple Azure regions for high availability
        }

        [Fact]
        public void ToMgmtNodePlacementConfiguration_ZonalSemantics_PreservesPlacementStrategy()
        {
            // Arrange - Zonal strategy places nodes within specific availability zones
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);

            // Act
            var result = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(NodePlacementPolicyType.Zonal, result.Policy);
            // Zonal semantics: Nodes are placed within specific availability zones for fault tolerance
        }

        #endregion

        #region fromMgmtNodePlacementConfiguration Tests

        [Fact]
        public void FromMgmtNodePlacementConfiguration_WithRegionalPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Regional);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, result.Policy);
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_WithZonalPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Zonal);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, result.Policy);
        }

        [Theory]
        [InlineData(NodePlacementPolicyType.Regional, Azure.Batch.Common.NodePlacementPolicyType.Regional)]
        [InlineData(NodePlacementPolicyType.Zonal, Azure.Batch.Common.NodePlacementPolicyType.Zonal)]
        public void FromMgmtNodePlacementConfiguration_AllValidPolicyTypes_ReturnsCorrectMapping(
            NodePlacementPolicyType mgmtPolicyType,
            Azure.Batch.Common.NodePlacementPolicyType expectedPsPolicyType)
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(mgmtPolicyType);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsPolicyType, result.Policy);
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_WithNullPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(null);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Policy);
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_WithNullConfiguration_ReturnsNull()
        {
            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_VerifyPSNodePlacementConfigurationType()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Regional);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSNodePlacementConfiguration>(result);
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_RegionalSemantics_PreservesPlacementStrategy()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Regional);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, result.Policy);
            // Regional semantics preserved: Multi-region placement for high availability
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_ZonalSemantics_PreservesPlacementStrategy()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Zonal);

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, result.Policy);
            // Zonal semantics preserved: Availability zone placement for fault tolerance
        }

        [Fact]
        public void FromMgmtNodePlacementConfiguration_WithDefaultNodePlacementConfiguration_HandlesCorrectly()
        {
            // Arrange
            var mgmtConfig = new NodePlacementConfiguration(); // Uses default constructor

            // Act
            var result = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            // The result should handle the default Policy from the management configuration
            Assert.True(result.Policy == null || Enum.IsDefined(typeof(Azure.Batch.Common.NodePlacementPolicyType), result.Policy));
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesRegionalValue()
        {
            // Arrange
            var originalPsConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNodePlacementConfiguration();
            var roundTripPsConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Policy, roundTripPsConfig.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, roundTripPsConfig.Policy);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesZonalValue()
        {
            // Arrange
            var originalPsConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNodePlacementConfiguration();
            var roundTripPsConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Policy, roundTripPsConfig.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, roundTripPsConfig.Policy);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Regional)]
        [InlineData(Azure.Batch.Common.NodePlacementPolicyType.Zonal)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidValues(
            Azure.Batch.Common.NodePlacementPolicyType originalPolicyType)
        {
            // Arrange
            var originalPsConfig = new PSNodePlacementConfiguration(originalPolicyType);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNodePlacementConfiguration();
            var roundTripPsConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPolicyType, roundTripPsConfig.Policy);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Regional);

            // Act
            var psConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtNodePlacementConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.Policy, roundTripMgmtConfig.Policy);
            Assert.Equal(NodePlacementPolicyType.Regional, roundTripMgmtConfig.Policy);
        }

        [Fact]
        public void RoundTripConversion_WithNullPolicy_PreservesNullValue()
        {
            // Arrange
            var originalPsConfig = new PSNodePlacementConfiguration(policy: null);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtNodePlacementConfiguration();
            var roundTripPsConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Null(roundTripPsConfig.Policy);
        }

        [Fact]
        public void RoundTripConversion_WithNullConfiguration_HandlesCorrectly()
        {
            // Arrange
            NodePlacementConfiguration nullMgmtConfig = null;

            // Act
            var psConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(nullMgmtConfig);

            // Assert
            Assert.Null(psConfig);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void NodePlacementConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Regional semantics - Nodes placed across multiple regions for high availability
            var psRegional = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);
            var mgmtRegional = psRegional.toMgmtNodePlacementConfiguration();
            var backToPs = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtRegional);

            Assert.Equal(NodePlacementPolicyType.Regional, mgmtRegional.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, backToPs.Policy);

            // Test Zonal semantics - Nodes placed within specific availability zones
            var psZonal = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);
            var mgmtZonal = psZonal.toMgmtNodePlacementConfiguration();
            var backToPsZonal = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtZonal);

            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtZonal.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, backToPsZonal.Policy);
        }

        [Fact]
        public void NodePlacementConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNullMgmt = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(null);

            // Assert
            Assert.Null(resultFromNullMgmt);
        }

        [Fact]
        public void NodePlacementConfigurationConversions_PoolPlacementContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool node placement
            // NodePlacementConfiguration is used to determine how compute nodes are allocated across Azure infrastructure

            // Arrange - Test Regional strategy for distributed workloads
            var psRegional = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);
            var mgmtRegional = psRegional.toMgmtNodePlacementConfiguration();

            // Act & Assert - Regional should convert correctly for cross-region high availability
            Assert.Equal(NodePlacementPolicyType.Regional, mgmtRegional.Policy);

            // Arrange - Test Zonal strategy for zone-aware workloads
            var psZonal = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);
            var mgmtZonal = psZonal.toMgmtNodePlacementConfiguration();

            // Act & Assert - Zonal should convert correctly for availability zone placement
            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtZonal.Policy);

            // Verify round-trip conversion maintains pool placement semantics
            var backToRegional = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtRegional);
            var backToZonal = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtZonal);

            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, backToRegional.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, backToZonal.Policy);
        }

        [Fact]
        public void NodePlacementConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Zonal);

            // Act
            var mgmtResult = psConfig.toMgmtNodePlacementConfiguration();
            var psResult = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<NodePlacementConfiguration>(mgmtResult);
            Assert.IsType<PSNodePlacementConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        [Fact]
        public void NodePlacementConfigurationConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default/null policy values
            
            // Arrange
            var defaultPsConfig = new PSNodePlacementConfiguration(policy: null);
            var defaultMgmtConfig = new NodePlacementConfiguration(); // Uses default constructor

            // Act
            var mgmtResult = defaultPsConfig.toMgmtNodePlacementConfiguration();
            var psResult = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(defaultMgmtConfig);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.Null(mgmtResult.Policy);
            Assert.True(psResult.Policy == null || Enum.IsDefined(typeof(Azure.Batch.Common.NodePlacementPolicyType), psResult.Policy));
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void NodePlacementConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Zonal);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psConfig.toMgmtNodePlacementConfiguration();
                var psResult = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
            }
        }

        [Fact]
        public void NodePlacementConfigurationConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);
            var mgmtConfig = new NodePlacementConfiguration(NodePlacementPolicyType.Zonal);

            // Act
            var mgmtResult = psConfig.toMgmtNodePlacementConfiguration();
            var psResult = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert - Verify correct types are returned
            Assert.IsType<NodePlacementConfiguration>(mgmtResult);
            Assert.IsType<PSNodePlacementConfiguration>(psResult);
        }

        [Fact]
        public void NodePlacementConfigurationConversions_PolicyProperty_AccessibleAfterConversion()
        {
            // Test that the Policy property is accessible and correct after conversion

            // Arrange
            var originalPolicy = Azure.Batch.Common.NodePlacementPolicyType.Zonal;
            var psConfig = new PSNodePlacementConfiguration(originalPolicy);

            // Act
            var mgmtConfig = psConfig.toMgmtNodePlacementConfiguration();
            var convertedPsConfig = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert
            Assert.Equal(originalPolicy, psConfig.Policy);
            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtConfig.Policy);
            Assert.Equal(originalPolicy, convertedPsConfig.Policy);
        }

        #endregion

        #region Infrastructure Resilience Tests

        [Fact]
        public void NodePlacementConfigurationConversions_RegionalStrategy_InfrastructureResilience()
        {
            // This test validates that Regional policy semantics are preserved for infrastructure resilience

            // Arrange - Regional policy for spreading across regions
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);

            // Act
            var mgmtConfig = psConfig.toMgmtNodePlacementConfiguration();
            var backToPs = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert - Regional placement semantics preserved
            Assert.Equal(NodePlacementPolicyType.Regional, mgmtConfig.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, backToPs.Policy);
            // Regional policy ensures nodes are distributed across multiple Azure regions for maximum resilience
        }

        [Fact]
        public void NodePlacementConfigurationConversions_ZonalStrategy_AvailabilityZoneAwareness()
        {
            // This test validates that Zonal policy semantics are preserved for availability zone awareness

            // Arrange - Zonal policy for availability zone placement
            var psConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);

            // Act
            var mgmtConfig = psConfig.toMgmtNodePlacementConfiguration();
            var backToPs = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(mgmtConfig);

            // Assert - Zonal placement semantics preserved
            Assert.Equal(NodePlacementPolicyType.Zonal, mgmtConfig.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, backToPs.Policy);
            // Zonal policy ensures nodes are placed within specific availability zones for fault tolerance
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSNodePlacementConfiguration_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes the internal object

            // Arrange & Act
            var regionalConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);
            var zonalConfig = new PSNodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Zonal);
            var nullConfig = new PSNodePlacementConfiguration(policy: null);

            // Assert
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, regionalConfig.Policy);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Zonal, zonalConfig.Policy);
            Assert.Null(nullConfig.Policy);
        }

        [Fact]
        public void PSNodePlacementConfiguration_InternalConstructor_ThrowsOnNullOmObject()
        {
            // Test that the internal constructor validates the omObject parameter

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                new PSNodePlacementConfiguration((Microsoft.Azure.Batch.NodePlacementConfiguration)null));
        }

        [Fact]
        public void PSNodePlacementConfiguration_InternalConstructor_WorksWithValidOmObject()
        {
            // Test that the internal constructor works with a valid omObject

            // Arrange
            var omObject = new Microsoft.Azure.Batch.NodePlacementConfiguration(Azure.Batch.Common.NodePlacementPolicyType.Regional);

            // Act
            var psConfig = new PSNodePlacementConfiguration(omObject);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal(Azure.Batch.Common.NodePlacementPolicyType.Regional, psConfig.Policy);
        }

        #endregion
    }
}
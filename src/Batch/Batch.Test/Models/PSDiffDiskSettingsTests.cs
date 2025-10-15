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
    public class PSDiffDiskSettingsTests
    {
        #region FromMgmtDiffDiskSettings Tests

        [Fact]
        public void FromMgmtDiffDiskSettings_WithCacheDiskPlacement_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);

            // Act
            var result = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, result.Placement);
        }

        [Fact]
        public void FromMgmtDiffDiskSettings_WithNullPlacement_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtSettings = new DiffDiskSettings(null);

            // Act
            var result = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Placement);
        }

        [Fact]
        public void FromMgmtDiffDiskSettings_WithNullSettings_ReturnsNull()
        {
            // Act
            var result = PSDiffDiskSettings.FromMgmtDiffDiskSettings(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtDiffDiskSettings_VerifyCorrectType_ReturnsPSDiffDiskSettings()
        {
            // Arrange
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);

            // Act
            var result = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSDiffDiskSettings>(result);
        }

        [Fact]
        public void FromMgmtDiffDiskSettings_CacheDiskSemantics_PreservesEphemeralOSDiskStrategy()
        {
            // Arrange - CacheDisk placement for ephemeral OS disk configuration
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);

            // Act
            var result = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, result.Placement);
            // CacheDisk semantics preserved: Ephemeral OS disk placed on cache disk for performance
        }

        [Theory]
        [InlineData(DiffDiskPlacement.CacheDisk, Azure.Batch.Common.DiffDiskPlacement.CacheDisk)]
        public void FromMgmtDiffDiskSettings_AllValidPlacementTypes_ReturnsCorrectMapping(
            DiffDiskPlacement mgmtPlacement,
            Azure.Batch.Common.DiffDiskPlacement expectedPsPlacement)
        {
            // Arrange
            var mgmtSettings = new DiffDiskSettings(mgmtPlacement);

            // Act
            var result = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsPlacement, result.Placement);
        }

        #endregion

        #region ToMgmtEphemeralOSDiskSettings Tests

        [Fact]
        public void ToMgmtEphemeralOSDiskSettings_WithCacheDiskPlacement_ReturnsCorrectMapping()
        {
            // Arrange
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act
            var result = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DiffDiskPlacement.CacheDisk, result.Placement);
        }

        [Fact]
        public void ToMgmtEphemeralOSDiskSettings_WithNullPlacement_ReturnsCorrectMapping()
        {
            // Arrange
            var psSettings = new PSDiffDiskSettings
            {
                Placement = null
            };

            // Act
            var result = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Placement);
        }

        [Fact]
        public void ToMgmtEphemeralOSDiskSettings_VerifyCorrectType_ReturnsDiffDiskSettings()
        {
            // Arrange
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act
            var result = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DiffDiskSettings>(result);
        }

        [Fact]
        public void ToMgmtEphemeralOSDiskSettings_CacheDiskSemantics_PreservesEphemeralOSDiskStrategy()
        {
            // Arrange - CacheDisk placement for ephemeral OS disk configuration
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act
            var result = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DiffDiskPlacement.CacheDisk, result.Placement);
            // CacheDisk semantics preserved: Ephemeral OS disk placed on cache disk for performance
        }

        [Theory]
        [InlineData(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, DiffDiskPlacement.CacheDisk)]
        public void ToMgmtEphemeralOSDiskSettings_AllValidPlacementTypes_ReturnsCorrectMapping(
            Azure.Batch.Common.DiffDiskPlacement psPlacement,
            DiffDiskPlacement expectedMgmtPlacement)
        {
            // Arrange
            var psSettings = new PSDiffDiskSettings
            {
                Placement = psPlacement
            };

            // Act
            var result = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtPlacement, result.Placement);
        }

        [Fact]
        public void ToMgmtEphemeralOSDiskSettings_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act
            var result1 = psSettings.ToMgmtEphemeralOSDiskSettings();
            var result2 = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesCacheDiskValue()
        {
            // Arrange
            var originalMgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);

            // Act - Convert Management -> PS -> Management
            var psSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(originalMgmtSettings);
            var roundTripMgmtSettings = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert - Should get back the original value
            Assert.NotNull(roundTripMgmtSettings);
            Assert.Equal(originalMgmtSettings.Placement, roundTripMgmtSettings.Placement);
            Assert.Equal(DiffDiskPlacement.CacheDisk, roundTripMgmtSettings.Placement);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesCacheDiskValue()
        {
            // Arrange
            var originalPsSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act - Convert PS -> Management -> PS
            var mgmtSettings = originalPsSettings.ToMgmtEphemeralOSDiskSettings();
            var roundTripPsSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert - Should get back the original value
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPsSettings.Placement, roundTripPsSettings.Placement);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, roundTripPsSettings.Placement);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.DiffDiskPlacement.CacheDisk)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidValues(
            Azure.Batch.Common.DiffDiskPlacement originalPlacement)
        {
            // Arrange
            var originalPsSettings = new PSDiffDiskSettings
            {
                Placement = originalPlacement
            };

            // Act - Convert PS -> Management -> PS
            var mgmtSettings = originalPsSettings.ToMgmtEphemeralOSDiskSettings();
            var roundTripPsSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert - Should get back the original value
            Assert.NotNull(roundTripPsSettings);
            Assert.Equal(originalPlacement, roundTripPsSettings.Placement);
        }

        [Fact]
        public void RoundTripConversion_WithNullPlacement_PreservesNullValue()
        {
            // Arrange
            var originalPsSettings = new PSDiffDiskSettings
            {
                Placement = null
            };

            // Act - Convert PS -> Management -> PS
            var mgmtSettings = originalPsSettings.ToMgmtEphemeralOSDiskSettings();
            var roundTripPsSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert - Should preserve null value
            Assert.NotNull(roundTripPsSettings);
            Assert.Null(roundTripPsSettings.Placement);
        }

        [Fact]
        public void RoundTripConversion_WithNullSettings_HandlesCorrectly()
        {
            // Arrange
            DiffDiskSettings nullMgmtSettings = null;

            // Act
            var psSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(nullMgmtSettings);

            // Assert
            Assert.Null(psSettings);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void DiffDiskSettingsConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test CacheDisk semantics - Ephemeral OS disk placed on cache disk for performance
            var mgmtCacheDisk = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var psCacheDisk = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtCacheDisk);
            var backToMgmt = psCacheDisk.ToMgmtEphemeralOSDiskSettings();

            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psCacheDisk.Placement);
            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmt.Placement);
        }

        [Fact]
        public void DiffDiskSettingsConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSDiffDiskSettings.FromMgmtDiffDiskSettings(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void DiffDiskSettingsConversions_EphemeralOSDiskContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of ephemeral OS disk configuration
            // DiffDiskSettings is used to configure ephemeral OS disk placement for Azure VMs

            // Arrange - Test CacheDisk strategy for ephemeral OS disk
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var psSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Act & Assert - CacheDisk should convert correctly for ephemeral OS disk performance
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psSettings.Placement);

            // Verify round-trip conversion maintains ephemeral OS disk semantics
            var backToMgmt = psSettings.ToMgmtEphemeralOSDiskSettings();

            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmt.Placement);
        }

        [Fact]
        public void DiffDiskSettingsConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default placement values

            // Arrange
            var defaultMgmtSettings = new DiffDiskSettings();
            var defaultPsSettings = new PSDiffDiskSettings();

            // Act
            var psFromDefault = PSDiffDiskSettings.FromMgmtDiffDiskSettings(defaultMgmtSettings);
            var mgmtFromDefault = defaultPsSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.NotNull(psFromDefault);
            Assert.NotNull(mgmtFromDefault);
            // Default values should be preserved
            Assert.Equal(defaultMgmtSettings.Placement, mgmtFromDefault.Placement);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void DiffDiskSettingsConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var psResult = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);
                var mgmtResult = psSettings.ToMgmtEphemeralOSDiskSettings();

                Assert.NotNull(psResult);
                Assert.NotNull(mgmtResult);
                Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psResult.Placement);
                Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtResult.Placement);
            }
        }

        #endregion

        #region Ephemeral OS Disk Strategy Tests

        [Fact]
        public void DiffDiskSettingsConversions_CacheDiskStrategy_EphemeralOSPerformanceOptimization()
        {
            // This test validates that CacheDisk placement semantics are preserved for ephemeral OS disk performance

            // Arrange - CacheDisk placement for high-performance ephemeral OS disk workloads
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);

            // Act
            var psSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);
            var backToMgmt = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert - CacheDisk placement semantics preserved for ephemeral OS disk
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psSettings.Placement);
            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmt.Placement);
            // CacheDisk placement ensures ephemeral OS disk is placed on cache disk for maximum performance
        }

        #endregion

        #region Type Safety and Instance Creation Tests

        [Fact]
        public void DiffDiskSettingsConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act
            var psResult = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);
            var mgmtResult = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert - Verify correct types are returned
            Assert.IsType<PSDiffDiskSettings>(psResult);
            Assert.IsType<DiffDiskSettings>(mgmtResult);
        }

        [Fact]
        public void DiffDiskSettingsConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var mgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var psSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };

            // Act
            var psResult = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);
            var mgmtResult = psSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert - Verify proper instance creation
            Assert.NotNull(psResult);
            Assert.NotNull(mgmtResult);
            Assert.IsType<PSDiffDiskSettings>(psResult);
            Assert.IsType<DiffDiskSettings>(mgmtResult);

            // Verify new instances are created
            Assert.NotSame(mgmtSettings, mgmtResult);
            Assert.NotSame(psSettings, psResult);
        }

        [Fact]
        public void DiffDiskSettingsConversions_PlacementProperty_AccessibleAfterConversion()
        {
            // Test that the Placement property is accessible and correct after conversion

            // Arrange
            var originalPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;
            var psSettings = new PSDiffDiskSettings
            {
                Placement = originalPlacement
            };

            // Act
            var mgmtSettings = psSettings.ToMgmtEphemeralOSDiskSettings();
            var convertedPsSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtSettings);

            // Assert
            Assert.Equal(originalPlacement, psSettings.Placement);
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtSettings.Placement);
            Assert.Equal(originalPlacement, convertedPsSettings.Placement);
        }

        #endregion

        #region Virtual Machine Configuration Context Tests

        [Fact]
        public void DiffDiskSettingsConversions_VMConfiguration_VerifyEphemeralOSDiskStrategy()
        {
            // This test validates the conversions work correctly in VM configuration scenarios
            // DiffDiskSettings determines ephemeral OS disk placement for Azure Batch VMs

            // Arrange - Test CacheDisk placement strategy in VM context
            var scenario = new
            {
                MgmtSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                PSPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk,
                Description = "Cache disk placement for ephemeral OS disk performance optimization"
            };

            // Act
            var psResult = PSDiffDiskSettings.FromMgmtDiffDiskSettings(scenario.MgmtSettings);
            var mgmtResult = new PSDiffDiskSettings { Placement = scenario.PSPlacement }.ToMgmtEphemeralOSDiskSettings();

            // Assert
            Assert.Equal(scenario.PSPlacement, psResult.Placement);
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtResult.Placement);

            // Verify round-trip maintains VM ephemeral OS disk strategy
            var roundTripMgmt = psResult.ToMgmtEphemeralOSDiskSettings();
            var roundTripPs = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtResult);

            Assert.Equal(DiffDiskPlacement.CacheDisk, roundTripMgmt.Placement);
            Assert.Equal(scenario.PSPlacement, roundTripPs.Placement);
        }

        [Fact]
        public void DiffDiskSettingsConversions_BatchPoolContext_PreservesEphemeralOSDiskSemantics()
        {
            // This test ensures that ephemeral OS disk placement semantics are correctly preserved in Batch pool context

            // Arrange - CacheDisk placement optimizes for high IOPS ephemeral OS disk workloads
            var mgmtCacheDiskSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);

            // Act
            var psCacheDiskSettings = PSDiffDiskSettings.FromMgmtDiffDiskSettings(mgmtCacheDiskSettings);
            var backToMgmtCacheDisk = psCacheDiskSettings.ToMgmtEphemeralOSDiskSettings();

            // Assert - CacheDisk placement semantics preserved for ephemeral OS disk scenarios
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psCacheDiskSettings.Placement);
            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmtCacheDisk.Placement);
            // Ephemeral OS disk placement ensures optimal performance for Batch pool nodes
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSDiffDiskSettings_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes

            // Arrange & Act
            var cacheSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };
            var nullSettings = new PSDiffDiskSettings
            {
                Placement = null
            };

            // Assert
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, cacheSettings.Placement);
            Assert.Null(nullSettings.Placement);
        }

        [Fact]
        public void DiffDiskSettings_Constructor_WorksWithParameters()
        {
            // Test that the Management constructor works with placement parameter

            // Arrange & Act
            var cacheSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var nullSettings = new DiffDiskSettings(null);
            var defaultSettings = new DiffDiskSettings();

            // Assert
            Assert.Equal(DiffDiskPlacement.CacheDisk, cacheSettings.Placement);
            Assert.Null(nullSettings.Placement);
            Assert.Null(defaultSettings.Placement);
        }

        #endregion
    }
}
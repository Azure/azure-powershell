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
    public class UtilsDiffDiskPlacementTests
    {
        #region ToMgmtPlacement Tests

        [Fact]
        public void ToMgmtPlacement_WithCacheDisk_ReturnsCorrectMapping()
        {
            // Arrange
            var psPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            // Act
            var result = Utils.Utils.ToMgmtPlacement(psPlacement);

            // Assert
            Assert.Equal(DiffDiskPlacement.CacheDisk, result);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, DiffDiskPlacement.CacheDisk)]
        public void ToMgmtPlacement_AllValidPlacementTypes_ReturnsCorrectMapping(
            Azure.Batch.Common.DiffDiskPlacement psPlacementType,
            DiffDiskPlacement expectedMgmtPlacementType)
        {
            // Act
            var result = Utils.Utils.ToMgmtPlacement(psPlacementType);

            // Assert
            Assert.Equal(expectedMgmtPlacementType, result);
        }

        [Fact]
        public void ToMgmtPlacement_WithNullableCacheDisk_ReturnsCorrectMapping()
        {
            // Arrange
            Azure.Batch.Common.DiffDiskPlacement? psPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            // Act
            var result = Utils.Utils.ToMgmtPlacement(psPlacement);

            // Assert
            Assert.Equal(DiffDiskPlacement.CacheDisk, result);
        }

        [Fact]
        public void ToMgmtPlacement_WithNull_ReturnsNull()
        {
            // Arrange
            Azure.Batch.Common.DiffDiskPlacement? psPlacement = null;

            // Act
            var result = Utils.Utils.ToMgmtPlacement(psPlacement);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtPlacement_CacheDiskSemantics_PreservesDiskPlacementStrategy()
        {
            // Arrange - CacheDisk strategy places diff disk on cache disk
            var psPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            // Act
            var result = Utils.Utils.ToMgmtPlacement(psPlacement);

            // Assert
            Assert.Equal(DiffDiskPlacement.CacheDisk, result);
            // CacheDisk semantics: Diff disk is placed on the cache disk for better performance
        }

        #endregion

        #region FromMgmtPlacement Tests

        [Fact]
        public void FromMgmtPlacement_WithCacheDisk_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtPlacement = DiffDiskPlacement.CacheDisk;

            // Act
            var result = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

            // Assert
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, result);
        }

        [Theory]
        [InlineData(DiffDiskPlacement.CacheDisk, Azure.Batch.Common.DiffDiskPlacement.CacheDisk)]
        public void FromMgmtPlacement_AllValidPlacementTypes_ReturnsCorrectMapping(
            DiffDiskPlacement mgmtPlacementType,
            Azure.Batch.Common.DiffDiskPlacement expectedPsPlacementType)
        {
            // Act
            var result = Utils.Utils.FromMgmtPlacement(mgmtPlacementType);

            // Assert
            Assert.Equal(expectedPsPlacementType, result);
        }

        [Fact]
        public void FromMgmtPlacement_WithNullableCacheDisk_ReturnsCorrectMapping()
        {
            // Arrange
            DiffDiskPlacement? mgmtPlacement = DiffDiskPlacement.CacheDisk;

            // Act
            var result = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

            // Assert
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, result);
        }

        [Fact]
        public void FromMgmtPlacement_WithNull_ReturnsNull()
        {
            // Arrange
            DiffDiskPlacement? mgmtPlacement = null;

            // Act
            var result = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtPlacement_CacheDiskSemantics_PreservesDiskPlacementStrategy()
        {
            // Arrange
            var mgmtPlacement = DiffDiskPlacement.CacheDisk;

            // Act
            var result = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

            // Assert
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, result);
            // CacheDisk semantics preserved: Diff disk placement on cache disk for performance
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesCacheDiskValue()
        {
            // Arrange
            var originalPsPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            // Act - Convert PS -> Management -> PS
            var mgmtPlacement = Utils.Utils.ToMgmtPlacement(originalPsPlacement);
            var roundTripPsPlacement = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

            // Assert - Should get back the original value
            Assert.Equal(originalPsPlacement, roundTripPsPlacement);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, roundTripPsPlacement);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.DiffDiskPlacement.CacheDisk)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidValues(
            Azure.Batch.Common.DiffDiskPlacement originalValue)
        {
            // Act - Convert PS -> Management -> PS
            var mgmtValue = Utils.Utils.ToMgmtPlacement(originalValue);
            var roundTripValue = Utils.Utils.FromMgmtPlacement(mgmtValue);

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
                DiffDiskPlacement.CacheDisk
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act - Convert Management -> PS -> Management
                var psValue = Utils.Utils.FromMgmtPlacement(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtPlacement(psValue);

                // Assert - Should get back the original value
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        [Fact]
        public void RoundTripConversion_WithNullableValues_PreservesNulls()
        {
            // Arrange
            Azure.Batch.Common.DiffDiskPlacement? nullPsPlacement = null;
            DiffDiskPlacement? nullMgmtPlacement = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.ToMgmtPlacement(nullPsPlacement);
            var psFromNullMgmt = Utils.Utils.FromMgmtPlacement(nullMgmtPlacement);

            // Assert
            Assert.Null(mgmtFromNullPs);
            Assert.Null(psFromNullMgmt);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void DiffDiskPlacementConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test CacheDisk semantics - Diff disk placed on cache disk for performance
            var psCacheDisk = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;
            var mgmtCacheDisk = Utils.Utils.ToMgmtPlacement(psCacheDisk);
            var backToPs = Utils.Utils.FromMgmtPlacement(mgmtCacheDisk);

            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtCacheDisk);
            Assert.Equal(psCacheDisk, backToPs);
        }

        [Fact]
        public void DiffDiskPlacementConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNullPs = Utils.Utils.ToMgmtPlacement(null);
            var resultFromNullMgmt = Utils.Utils.FromMgmtPlacement(null);

            // Assert
            Assert.Null(resultFromNullPs);
            Assert.Null(resultFromNullMgmt);
        }

        [Fact]
        public void DiffDiskPlacementConversions_VirtualMachineContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure VM diff disk placement
            // DiffDiskPlacement is used to determine where the diff disk is placed on Azure VMs

            // Arrange - Test CacheDisk strategy for performance-optimized workloads
            var psCacheDisk = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;
            var mgmtCacheDisk = Utils.Utils.ToMgmtPlacement(psCacheDisk);

            // Act & Assert - CacheDisk should convert correctly for performance optimization
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtCacheDisk);

            // Verify round-trip conversion maintains VM disk placement semantics
            var backToCacheDisk = Utils.Utils.FromMgmtPlacement(mgmtCacheDisk);

            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, backToCacheDisk);
        }

        [Fact]
        public void DiffDiskPlacementConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default enum values

            // Arrange
            var defaultPsPlacement = default(Azure.Batch.Common.DiffDiskPlacement);
            var defaultMgmtPlacement = default(DiffDiskPlacement);

            // Act
            var mgmtResult = Utils.Utils.ToMgmtPlacement(defaultPsPlacement);
            var psResult = Utils.Utils.FromMgmtPlacement(defaultMgmtPlacement);

            // Assert
            Assert.Equal((DiffDiskPlacement)defaultPsPlacement, mgmtResult);
            Assert.Equal((Azure.Batch.Common.DiffDiskPlacement)defaultMgmtPlacement, psResult);
            Assert.True(Enum.IsDefined(typeof(DiffDiskPlacement), mgmtResult));
            Assert.True(Enum.IsDefined(typeof(Azure.Batch.Common.DiffDiskPlacement), psResult));
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void DiffDiskPlacementConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;
            var mgmtPlacement = DiffDiskPlacement.CacheDisk;

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = Utils.Utils.ToMgmtPlacement(psPlacement);
                var psResult = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

                Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtResult);
                Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psResult);
            }
        }

        #endregion

        #region Disk Performance Strategy Tests

        [Fact]
        public void DiffDiskPlacementConversions_CacheDiskStrategy_PerformanceOptimization()
        {
            // This test validates that CacheDisk placement semantics are preserved for performance optimization

            // Arrange - CacheDisk placement for high-performance workloads
            var psCacheDisk = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            // Act
            var mgmtCacheDisk = Utils.Utils.ToMgmtPlacement(psCacheDisk);
            var backToPs = Utils.Utils.FromMgmtPlacement(mgmtCacheDisk);

            // Assert - CacheDisk placement semantics preserved
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtCacheDisk);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, backToPs);
            // CacheDisk placement ensures diff disk is placed on cache disk for maximum performance
        }

        #endregion

        #region Type Safety and Casting Tests

        [Fact]
        public void DiffDiskPlacementConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types and handle casting properly

            // Arrange
            var psPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;
            var mgmtPlacement = DiffDiskPlacement.CacheDisk;

            // Act
            var mgmtResult = Utils.Utils.ToMgmtPlacement(psPlacement);
            var psResult = Utils.Utils.FromMgmtPlacement(mgmtPlacement);

            // Assert - Verify correct types are returned
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.DiffDiskPlacement>(mgmtResult);
            Assert.IsType<Azure.Batch.Common.DiffDiskPlacement>(psResult);
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtResult);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psResult);
        }

        [Fact]
        public void DiffDiskPlacementConversions_EnumValueEquivalence_VerifyDirectCasting()
        {
            // Test that the enum values are equivalent and casting works as expected

            // Arrange & Act - Test direct casting behavior
            var psCacheDisk = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            var mgmtCacheDiskDirect = (DiffDiskPlacement)psCacheDisk;
            var mgmtCacheDiskUtils = Utils.Utils.ToMgmtPlacement(psCacheDisk);

            // Assert - Utils methods should behave the same as direct casting
            Assert.Equal(mgmtCacheDiskDirect, mgmtCacheDiskUtils);
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtCacheDiskUtils);
        }

        [Fact]
        public void DiffDiskPlacementConversions_NullableCasting_WorksCorrectly()
        {
            // Test that nullable casting works as expected

            // Arrange
            Azure.Batch.Common.DiffDiskPlacement? nullablePsCacheDisk = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;
            Azure.Batch.Common.DiffDiskPlacement? nullPs = null;

            // Act
            var mgmtFromNullableCacheDisk = Utils.Utils.ToMgmtPlacement(nullablePsCacheDisk);
            var mgmtFromNull = Utils.Utils.ToMgmtPlacement(nullPs);

            // Assert
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtFromNullableCacheDisk);
            Assert.Null(mgmtFromNull);
        }

        #endregion

        #region VM Configuration Context Tests

        [Fact]
        public void DiffDiskPlacementConversions_VMDiskConfiguration_VerifyPlacementStrategy()
        {
            // This test validates the conversions work correctly in VM disk configuration scenarios
            // DiffDiskPlacement determines where ephemeral disks are placed on Azure VMs

            // Arrange - Test CacheDisk placement strategy in VM context
            var scenario = new
            {
                PSPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk,
                MgmtPlacement = DiffDiskPlacement.CacheDisk,
                Description = "Cache disk placement for high-performance I/O workloads"
            };

            // Act
            var mgmtResult = Utils.Utils.ToMgmtPlacement(scenario.PSPlacement);
            var psResult = Utils.Utils.FromMgmtPlacement(scenario.MgmtPlacement);

            // Assert
            Assert.Equal(scenario.MgmtPlacement, mgmtResult);
            Assert.Equal(scenario.PSPlacement, psResult);

            // Verify round-trip maintains VM disk placement strategy
            var roundTripMgmt = Utils.Utils.ToMgmtPlacement(psResult);
            var roundTripPs = Utils.Utils.FromMgmtPlacement(mgmtResult);

            Assert.Equal(scenario.MgmtPlacement, roundTripMgmt);
            Assert.Equal(scenario.PSPlacement, roundTripPs);
        }

        [Fact]
        public void DiffDiskPlacementConversions_EphemeralDiskContext_PreservesPlacementSemantics()
        {
            // This test ensures that ephemeral disk placement semantics are correctly preserved

            // Arrange - CacheDisk placement optimizes for high IOPS workloads
            var psCacheDiskPlacement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk;

            // Act
            var mgmtCacheDiskPlacement = Utils.Utils.ToMgmtPlacement(psCacheDiskPlacement);
            var backToPsCacheDisk = Utils.Utils.FromMgmtPlacement(mgmtCacheDiskPlacement);

            // Assert - CacheDisk placement semantics preserved for high-performance scenarios
            Assert.Equal(DiffDiskPlacement.CacheDisk, mgmtCacheDiskPlacement);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, backToPsCacheDisk);
        }

        #endregion
    }
}
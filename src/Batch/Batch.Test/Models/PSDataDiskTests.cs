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
    public class PSDataDiskTests
    {
        #region toMgmtDataDisk Tests

        [Fact]
        public void ToMgmtDataDisk_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(
                lun: 1,
                diskSizeGB: 128,
                caching: Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Lun);
            Assert.Equal(128, result.DiskSizeGb);
            Assert.Equal(CachingType.ReadWrite, result.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtDataDisk_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(
                lun: 0,
                diskSizeGB: 64);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Lun);
            Assert.Equal(64, result.DiskSizeGb);
            Assert.Null(result.Caching);
            Assert.Null(result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtDataDisk_WithStandardSSDStorage_ReturnsCorrectMapping()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(
                lun: 2,
                diskSizeGB: 256,
                caching: Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Lun);
            Assert.Equal(256, result.DiskSizeGb);
            Assert.Equal(CachingType.ReadOnly, result.Caching);
            Assert.Equal(StorageAccountType.StandardSSDLRS, result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtDataDisk_WithStandardLRSStorage_ReturnsCorrectMapping()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(
                lun: 3,
                diskSizeGB: 512,
                caching: Microsoft.Azure.Batch.Common.CachingType.None,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Lun);
            Assert.Equal(512, result.DiskSizeGb);
            Assert.Equal(CachingType.None, result.Caching);
            Assert.Equal(StorageAccountType.StandardLRS, result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtDataDisk_WithNullCaching_ReturnsNullCaching()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(
                lun: 4,
                diskSizeGB: 1024,
                caching: null,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Lun);
            Assert.Equal(1024, result.DiskSizeGb);
            Assert.Null(result.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtDataDisk_WithNullStorageAccountType_ReturnsNullStorageAccountType()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(
                lun: 5,
                diskSizeGB: 2048,
                caching: Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                storageAccountType: null);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Lun);
            Assert.Equal(2048, result.DiskSizeGb);
            Assert.Equal(CachingType.ReadWrite, result.Caching);
            Assert.Null(result.StorageAccountType);
        }

        [Theory]
        [InlineData(0, 64, Microsoft.Azure.Batch.Common.CachingType.None, Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        [InlineData(1, 128, Microsoft.Azure.Batch.Common.CachingType.ReadOnly, Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)]
        [InlineData(2, 256, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)]
        [InlineData(63, 4096, Microsoft.Azure.Batch.Common.CachingType.None, Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        public void ToMgmtDataDisk_VariousConfigurations_ReturnsCorrectMapping(
            int lun,
            int diskSizeGB,
            Microsoft.Azure.Batch.Common.CachingType caching,
            Microsoft.Azure.Batch.Common.StorageAccountType storageAccountType)
        {
            // Arrange
            var psDataDisk = new PSDataDisk(lun, diskSizeGB, caching, storageAccountType);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(lun, result.Lun);
            Assert.Equal(diskSizeGB, result.DiskSizeGb);
            Assert.Equal((CachingType)caching, result.Caching);
            Assert.Equal((StorageAccountType)storageAccountType, result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtDataDisk_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(1, 128);

            // Act
            var result1 = psDataDisk.toMgmtDataDisk();
            var result2 = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtDataDisk_VerifyDataDiskType()
        {
            // Arrange
            var psDataDisk = new PSDataDisk(1, 128);

            // Act
            var result = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DataDisk>(result);
        }

        [Fact]
        public void ToMgmtDataDisk_WithBoundaryValues_ReturnsCorrectMapping()
        {
            // Test with boundary values for LUN (0-63) and disk sizes

            // Minimum LUN and disk size
            var minDataDisk = new PSDataDisk(0, 1);
            var minResult = minDataDisk.toMgmtDataDisk();
            Assert.Equal(0, minResult.Lun);
            Assert.Equal(1, minResult.DiskSizeGb);

            // Maximum LUN
            var maxLunDataDisk = new PSDataDisk(63, 32767);
            var maxLunResult = maxLunDataDisk.toMgmtDataDisk();
            Assert.Equal(63, maxLunResult.Lun);
            Assert.Equal(32767, maxLunResult.DiskSizeGb);
        }

        #endregion

        #region fromMgmtDataDisk Tests

        [Fact]
        public void FromMgmtDataDisk_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(
                lun: 1,
                diskSizeGb: 128,
                caching: CachingType.ReadWrite,
                storageAccountType: StorageAccountType.PremiumLRS);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Lun);
            Assert.Equal(128, result.DiskSizeGB);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, result.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_WithMinimalProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(
                lun: 0,
                diskSizeGb: 64);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Lun);
            Assert.Equal(64, result.DiskSizeGB);
            Assert.Null(result.Caching);
            Assert.Null(result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_WithNullMgmtDataDisk_ReturnsNull()
        {
            // Act
            var result = PSDataDisk.fromMgmtDataDisk(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtDataDisk_WithStandardSSDStorage_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(
                lun: 2,
                diskSizeGb: 256,
                caching: CachingType.ReadOnly,
                storageAccountType: StorageAccountType.StandardSSDLRS);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Lun);
            Assert.Equal(256, result.DiskSizeGB);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadOnly, result.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_WithStandardLRSStorage_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(
                lun: 3,
                diskSizeGb: 512,
                caching: CachingType.None,
                storageAccountType: StorageAccountType.StandardLRS);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Lun);
            Assert.Equal(512, result.DiskSizeGB);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.None, result.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_WithNullCaching_ReturnsNullCaching()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(
                lun: 4,
                diskSizeGb: 1024,
                caching: null,
                storageAccountType: StorageAccountType.PremiumLRS);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Lun);
            Assert.Equal(1024, result.DiskSizeGB);
            Assert.Null(result.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_WithNullStorageAccountType_ReturnsNullStorageAccountType()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(
                lun: 5,
                diskSizeGb: 2048,
                caching: CachingType.ReadWrite,
                storageAccountType: null);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Lun);
            Assert.Equal(2048, result.DiskSizeGB);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, result.Caching);
            Assert.Null(result.StorageAccountType);
        }

        [Theory]
        [InlineData(0, 64, CachingType.None, StorageAccountType.StandardLRS)]
        [InlineData(1, 128, CachingType.ReadOnly, StorageAccountType.StandardSSDLRS)]
        [InlineData(2, 256, CachingType.ReadWrite, StorageAccountType.PremiumLRS)]
        [InlineData(63, 4096, CachingType.None, StorageAccountType.StandardLRS)]
        public void FromMgmtDataDisk_VariousConfigurations_ReturnsCorrectMapping(
            int lun,
            int diskSizeGb,
            CachingType caching,
            StorageAccountType storageAccountType)
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(lun, diskSizeGb, caching, storageAccountType);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(lun, result.Lun);
            Assert.Equal(diskSizeGb, result.DiskSizeGB);
            Assert.Equal((Microsoft.Azure.Batch.Common.CachingType)caching, result.Caching);
            Assert.Equal((Microsoft.Azure.Batch.Common.StorageAccountType)storageAccountType, result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(1, 128);

            // Act - Call static method directly on class
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Lun);
            Assert.Equal(128, result.DiskSizeGB);
        }

        [Fact]
        public void FromMgmtDataDisk_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(1, 128);

            // Act
            var result1 = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);
            var result2 = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtDataDisk_VerifyPSDataDiskType()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(1, 128);

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSDataDisk>(result);
        }

        [Fact]
        public void FromMgmtDataDisk_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtDataDisk = new DataDisk(); // Uses default constructor
            mgmtDataDisk.Lun = 10;
            mgmtDataDisk.DiskSizeGb = 512;

            // Act
            var result = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Lun);
            Assert.Equal(512, result.DiskSizeGB);
            Assert.Null(result.Caching);
            Assert.Null(result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtDataDisk_WithBoundaryValues_ReturnsCorrectMapping()
        {
            // Test with boundary values for LUN (0-63) and disk sizes

            // Minimum LUN and disk size
            var minMgmtDataDisk = new DataDisk(0, 1);
            var minResult = PSDataDisk.fromMgmtDataDisk(minMgmtDataDisk);
            Assert.Equal(0, minResult.Lun);
            Assert.Equal(1, minResult.DiskSizeGB);

            // Maximum LUN
            var maxLunMgmtDataDisk = new DataDisk(63, 32767);
            var maxLunResult = PSDataDisk.fromMgmtDataDisk(maxLunMgmtDataDisk);
            Assert.Equal(63, maxLunResult.Lun);
            Assert.Equal(32767, maxLunResult.DiskSizeGB);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsDataDisk = new PSDataDisk(
                lun: 1,
                diskSizeGB: 128,
                caching: Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            // Act
            var mgmtDataDisk = originalPsDataDisk.toMgmtDataDisk();
            var roundTripPsDataDisk = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(roundTripPsDataDisk);
            Assert.Equal(originalPsDataDisk.Lun, roundTripPsDataDisk.Lun);
            Assert.Equal(originalPsDataDisk.DiskSizeGB, roundTripPsDataDisk.DiskSizeGB);
            Assert.Equal(originalPsDataDisk.Caching, roundTripPsDataDisk.Caching);
            Assert.Equal(originalPsDataDisk.StorageAccountType, roundTripPsDataDisk.StorageAccountType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesMinimalProperties()
        {
            // Arrange
            var originalPsDataDisk = new PSDataDisk(0, 64);

            // Act
            var mgmtDataDisk = originalPsDataDisk.toMgmtDataDisk();
            var roundTripPsDataDisk = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(roundTripPsDataDisk);
            Assert.Equal(originalPsDataDisk.Lun, roundTripPsDataDisk.Lun);
            Assert.Equal(originalPsDataDisk.DiskSizeGB, roundTripPsDataDisk.DiskSizeGB);
            Assert.Null(roundTripPsDataDisk.Caching);
            Assert.Null(roundTripPsDataDisk.StorageAccountType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsDataDisk = new PSDataDisk(
                lun: 2,
                diskSizeGB: 256,
                caching: null,
                storageAccountType: null);

            // Act
            var mgmtDataDisk = originalPsDataDisk.toMgmtDataDisk();
            var roundTripPsDataDisk = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(roundTripPsDataDisk);
            Assert.Equal(originalPsDataDisk.Lun, roundTripPsDataDisk.Lun);
            Assert.Equal(originalPsDataDisk.DiskSizeGB, roundTripPsDataDisk.DiskSizeGB);
            Assert.Null(roundTripPsDataDisk.Caching);
            Assert.Null(roundTripPsDataDisk.StorageAccountType);
        }

        [Theory]
        [InlineData(0, 64, Microsoft.Azure.Batch.Common.CachingType.None, Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        [InlineData(1, 128, Microsoft.Azure.Batch.Common.CachingType.ReadOnly, Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)]
        [InlineData(2, 256, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)]
        [InlineData(63, 4096, Microsoft.Azure.Batch.Common.CachingType.None, Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            int lun,
            int diskSizeGB,
            Microsoft.Azure.Batch.Common.CachingType caching,
            Microsoft.Azure.Batch.Common.StorageAccountType storageAccountType)
        {
            // Arrange
            var originalPsDataDisk = new PSDataDisk(lun, diskSizeGB, caching, storageAccountType);

            // Act
            var mgmtDataDisk = originalPsDataDisk.toMgmtDataDisk();
            var roundTripPsDataDisk = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(roundTripPsDataDisk);
            Assert.Equal(originalPsDataDisk.Lun, roundTripPsDataDisk.Lun);
            Assert.Equal(originalPsDataDisk.DiskSizeGB, roundTripPsDataDisk.DiskSizeGB);
            Assert.Equal(originalPsDataDisk.Caching, roundTripPsDataDisk.Caching);
            Assert.Equal(originalPsDataDisk.StorageAccountType, roundTripPsDataDisk.StorageAccountType);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtDataDisk = new DataDisk(
                lun: 3,
                diskSizeGb: 512,
                caching: CachingType.ReadOnly,
                storageAccountType: StorageAccountType.StandardSSDLRS);

            // Act
            var psDataDisk = PSDataDisk.fromMgmtDataDisk(originalMgmtDataDisk);
            var roundTripMgmtDataDisk = psDataDisk.toMgmtDataDisk();

            // Assert
            Assert.NotNull(roundTripMgmtDataDisk);
            Assert.Equal(originalMgmtDataDisk.Lun, roundTripMgmtDataDisk.Lun);
            Assert.Equal(originalMgmtDataDisk.DiskSizeGb, roundTripMgmtDataDisk.DiskSizeGb);
            Assert.Equal(originalMgmtDataDisk.Caching, roundTripMgmtDataDisk.Caching);
            Assert.Equal(originalMgmtDataDisk.StorageAccountType, roundTripMgmtDataDisk.StorageAccountType);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void DataDiskConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with high-performance data disk configuration
            var psDataDisk = new PSDataDisk(
                lun: 1,
                diskSizeGB: 1024,
                caching: Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            // Act
            var mgmtDataDisk = psDataDisk.toMgmtDataDisk();
            var backToPs = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert
            Assert.NotNull(mgmtDataDisk);
            Assert.Equal(1, mgmtDataDisk.Lun);
            Assert.Equal(1024, mgmtDataDisk.DiskSizeGb);
            Assert.Equal(CachingType.ReadWrite, mgmtDataDisk.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, mgmtDataDisk.StorageAccountType);

            Assert.NotNull(backToPs);
            Assert.Equal(1, backToPs.Lun);
            Assert.Equal(1024, backToPs.DiskSizeGB);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, backToPs.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, backToPs.StorageAccountType);
        }

        [Fact]
        public void DataDiskConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSDataDisk.fromMgmtDataDisk(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void DataDiskConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool configuration
            // DataDisk is used to configure additional storage for Batch pool compute nodes

            // Arrange - Test with different data disk scenarios
            var scenarios = new[]
            {
                // High-performance database storage
                new {
                    Lun = 0,
                    DiskSizeGB = 512,
                    Caching = Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    Description = "High-performance database storage with Premium SSD and read-write caching"
                },
                // Analytics workload storage
                new {
                    Lun = 1,
                    DiskSizeGB = 1024,
                    Caching = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                    Description = "Analytics workload storage with Standard SSD and read-only caching"
                },
                // Archive storage
                new {
                    Lun = 2,
                    DiskSizeGB = 2048,
                    Caching = Microsoft.Azure.Batch.Common.CachingType.None,
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                    Description = "Archive storage with Standard HDD and no caching"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psDataDisk = new PSDataDisk(
                    lun: scenario.Lun,
                    diskSizeGB: scenario.DiskSizeGB,
                    caching: scenario.Caching,
                    storageAccountType: scenario.StorageAccountType);

                // Act
                var mgmtDataDisk = psDataDisk.toMgmtDataDisk();

                // Assert - Should convert correctly for Batch pool configuration
                Assert.NotNull(mgmtDataDisk);
                Assert.Equal(scenario.Lun, mgmtDataDisk.Lun);
                Assert.Equal(scenario.DiskSizeGB, mgmtDataDisk.DiskSizeGb);

                Assert.Equal((CachingType)scenario.Caching, mgmtDataDisk.Caching);


                Assert.Equal((StorageAccountType)scenario.StorageAccountType, mgmtDataDisk.StorageAccountType);

                // Verify round-trip conversion maintains data disk semantics
                var backToPs = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Lun, backToPs.Lun);
                Assert.Equal(scenario.DiskSizeGB, backToPs.DiskSizeGB);
                Assert.Equal(scenario.Caching, backToPs.Caching);
                Assert.Equal(scenario.StorageAccountType, backToPs.StorageAccountType);
            }
        }

        [Fact]
        public void DataDiskConversions_PropertyMapping_VerifyCorrectness()
        {
            // This test verifies the property mapping between PS and Management types
            // PSDataDisk.DiskSizeGB <-> DataDisk.DiskSizeGb (different casing)
            // Other properties map directly

            // Test 1: PS to Management mapping
            var psDataDisk = new PSDataDisk(
                lun: 5,
                diskSizeGB: 512,
                caching: Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);

            var mgmtDataDisk = psDataDisk.toMgmtDataDisk();

            // Verify DiskSizeGB maps to DiskSizeGb (different casing)
            Assert.Equal(psDataDisk.DiskSizeGB, mgmtDataDisk.DiskSizeGb);
            // Verify direct mappings
            Assert.Equal(psDataDisk.Lun, mgmtDataDisk.Lun);
            Assert.Equal((CachingType)psDataDisk.Caching.Value, mgmtDataDisk.Caching);
            Assert.Equal((StorageAccountType)psDataDisk.StorageAccountType.Value, mgmtDataDisk.StorageAccountType);

            // Test 2: Management to PS mapping
            var originalMgmtDisk = new DataDisk(
                lun: 10,
                diskSizeGb: 256,
                caching: CachingType.ReadWrite,
                storageAccountType: StorageAccountType.PremiumLRS);

            var resultPsDisk = PSDataDisk.fromMgmtDataDisk(originalMgmtDisk);

            // Verify DiskSizeGb maps to DiskSizeGB (different casing)
            Assert.Equal(originalMgmtDisk.DiskSizeGb, resultPsDisk.DiskSizeGB);
            // Verify direct mappings
            Assert.Equal(originalMgmtDisk.Lun, resultPsDisk.Lun);
            Assert.Equal((Microsoft.Azure.Batch.Common.CachingType)originalMgmtDisk.Caching.Value, resultPsDisk.Caching);
            Assert.Equal((Microsoft.Azure.Batch.Common.StorageAccountType)originalMgmtDisk.StorageAccountType.Value, resultPsDisk.StorageAccountType);
        }

        [Fact]
        public void DataDiskConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psDataDisk = new PSDataDisk(1, 128, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            var mgmtDataDisk = new DataDisk(2, 256, CachingType.ReadOnly, StorageAccountType.StandardSSDLRS);

            // Act
            var mgmtResult = psDataDisk.toMgmtDataDisk();
            var psResult = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<DataDisk>(mgmtResult);
            Assert.IsType<PSDataDisk>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtDataDisk, mgmtResult);
            Assert.NotSame(psDataDisk, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void DataDiskConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psDataDisk = new PSDataDisk(1, 128, Microsoft.Azure.Batch.Common.CachingType.ReadWrite, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            var mgmtDataDisk = new DataDisk(2, 256, CachingType.ReadOnly, StorageAccountType.StandardSSDLRS);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 1000; i++)
            {
                var mgmtResult = psDataDisk.toMgmtDataDisk();
                var psResult = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(1, mgmtResult.Lun);
                Assert.Equal(2, psResult.Lun);
            }
        }

        [Fact]
        public void DataDiskConversions_EdgeCaseDiskSizes_HandleCorrectly()
        {
            // Test conversion with various edge case disk sizes

            var testDiskSizes = new[]
            {
                // Minimum sizes
                1,
                4,
                
                // Common sizes
                32,
                64,
                128,
                256,
                512,
                1024,
                2048,
                4096,
                
                // Large sizes
                8192,
                16384,
                32767 // Near maximum for int16
            };

            foreach (var diskSize in testDiskSizes)
            {
                // Arrange
                var psDataDisk = new PSDataDisk(0, diskSize);

                // Act
                var mgmtResult = psDataDisk.toMgmtDataDisk();
                var roundTripResult = PSDataDisk.fromMgmtDataDisk(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(diskSize, mgmtResult.DiskSizeGb);
                Assert.Equal(diskSize, roundTripResult.DiskSizeGB);
            }
        }

        [Fact]
        public void DataDiskConversions_EdgeCaseLunValues_HandleCorrectly()
        {
            // Test conversion with valid LUN range (0-63)

            var testLunValues = new[]
            {
                0,   // Minimum LUN
                1,   // Common LUN
                15,  // Common LUN
                31,  // Common LUN
                62,  // Near maximum LUN
                63   // Maximum LUN
            };

            foreach (var lun in testLunValues)
            {
                // Arrange
                var psDataDisk = new PSDataDisk(lun, 128);

                // Act
                var mgmtResult = psDataDisk.toMgmtDataDisk();
                var roundTripResult = PSDataDisk.fromMgmtDataDisk(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(lun, mgmtResult.Lun);
                Assert.Equal(lun, roundTripResult.Lun);
            }
        }

        [Fact]
        public void DataDiskConversions_DefaultAndNullValues_HandleCorrectly()
        {
            // Test conversion with default and null values

            // Scenario 1: Default PS constructor values
            var defaultPsDataDisk = new PSDataDisk(0, 64); // Minimal required parameters

            var mgmtFromDefault = defaultPsDataDisk.toMgmtDataDisk();
            Assert.NotNull(mgmtFromDefault);
            Assert.Equal(0, mgmtFromDefault.Lun);
            Assert.Equal(64, mgmtFromDefault.DiskSizeGb);
            Assert.Null(mgmtFromDefault.Caching);
            Assert.Null(mgmtFromDefault.StorageAccountType);

            // Scenario 2: Default management constructor
            var defaultMgmtDataDisk = new DataDisk();
            defaultMgmtDataDisk.Lun = 1;
            defaultMgmtDataDisk.DiskSizeGb = 128;

            var psFromDefault = PSDataDisk.fromMgmtDataDisk(defaultMgmtDataDisk);
            Assert.NotNull(psFromDefault);
            Assert.Equal(1, psFromDefault.Lun);
            Assert.Equal(128, psFromDefault.DiskSizeGB);
            Assert.Null(psFromDefault.Caching);
            Assert.Null(psFromDefault.StorageAccountType);

            // Scenario 3: Explicit null values
            var nullValuesPsDataDisk = new PSDataDisk(
                lun: 2,
                diskSizeGB: 256,
                caching: null,
                storageAccountType: null);

            var mgmtNullValuesResult = nullValuesPsDataDisk.toMgmtDataDisk();
            Assert.NotNull(mgmtNullValuesResult);
            Assert.Equal(2, mgmtNullValuesResult.Lun);
            Assert.Equal(256, mgmtNullValuesResult.DiskSizeGb);
            Assert.Null(mgmtNullValuesResult.Caching);
            Assert.Null(mgmtNullValuesResult.StorageAccountType);

            var roundTripNullValues = PSDataDisk.fromMgmtDataDisk(mgmtNullValuesResult);
            Assert.NotNull(roundTripNullValues);
            Assert.Equal(2, roundTripNullValues.Lun);
            Assert.Equal(256, roundTripNullValues.DiskSizeGB);
            Assert.Null(roundTripNullValues.Caching);
            Assert.Null(roundTripNullValues.StorageAccountType);
        }

        [Fact]
        public void DataDiskConversions_StoragePerformanceProfiles_VerifySemantics()
        {
            // This test validates different storage performance profiles used in real scenarios

            var performanceProfiles = new[]
            {
                new {
                    Profile = "Ultra High Performance",
                    Lun = 0,
                    DiskSizeGB = 1024,
                    Caching = Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    UseCases = new[] { "OLTP databases", "High-performance computing", "Real-time analytics" }
                },
                new {
                    Profile = "Balanced Performance",
                    Lun = 1,
                    DiskSizeGB = 512,
                    Caching = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                    UseCases = new[] { "Web applications", "Development environments", "General workloads" }
                },
                new {
                    Profile = "Cost Optimized",
                    Lun = 2,
                    DiskSizeGB = 2048,
                    Caching = Microsoft.Azure.Batch.Common.CachingType.None,
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                    UseCases = new[] { "Backup storage", "Archive data", "Batch processing temp files" }
                }
            };

            foreach (var profile in performanceProfiles)
            {
                // Act - Convert to management type and back
                var psDataDisk = new PSDataDisk(profile.Lun, profile.DiskSizeGB, profile.Caching, profile.StorageAccountType);
                var mgmtDataDisk = psDataDisk.toMgmtDataDisk();
                var roundTripDataDisk = PSDataDisk.fromMgmtDataDisk(mgmtDataDisk);

                // Assert - Performance profile characteristics should be preserved
                Assert.NotNull(mgmtDataDisk);
                Assert.NotNull(roundTripDataDisk);
                Assert.Equal(profile.Lun, roundTripDataDisk.Lun);
                Assert.Equal(profile.DiskSizeGB, roundTripDataDisk.DiskSizeGB);
                Assert.Equal(profile.Caching, roundTripDataDisk.Caching);
                Assert.Equal(profile.StorageAccountType, roundTripDataDisk.StorageAccountType);

                // Verify the conversion maintains the semantic meaning
                var expectedMgmtCaching = profile.Caching switch
                {
                    Microsoft.Azure.Batch.Common.CachingType.None => CachingType.None,
                    Microsoft.Azure.Batch.Common.CachingType.ReadOnly => CachingType.ReadOnly,
                    Microsoft.Azure.Batch.Common.CachingType.ReadWrite => CachingType.ReadWrite,
                    _ => throw new ArgumentOutOfRangeException()
                };

                var expectedMgmtStorage = profile.StorageAccountType switch
                {
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs => StorageAccountType.StandardLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs => StorageAccountType.PremiumLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS => StorageAccountType.StandardSSDLRS,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Assert.Equal(expectedMgmtCaching, mgmtDataDisk.Caching);
                Assert.Equal(expectedMgmtStorage, mgmtDataDisk.StorageAccountType);
            }
        }

        #endregion
    }
}
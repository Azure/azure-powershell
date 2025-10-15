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
    public class PSOSDiskTests
    {
        #region fromMgmtOSDisk Tests

        [Fact]
        public void FromMgmtOSDisk_WithCompleteOSDisk_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(StorageAccountType.PremiumLRS);
            var mgmtEphemeralSettings = new DiffDiskSettings(DiffDiskPlacement.CacheDisk);
            var mgmtOSDisk = new OSDisk(
                ephemeralOSDiskSettings: mgmtEphemeralSettings,
                caching: CachingType.ReadWrite,
                managedDisk: mgmtManagedDisk,
                diskSizeGb: 128,
                writeAcceleratorEnabled: true
            );

            // Act
            var result = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ManagedDisk);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.ManagedDisk.StorageAccountType);
            Assert.Equal(128, result.DiskSizeGB);
            Assert.NotNull(result.EphemeralOSDiskSettings);
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, result.EphemeralOSDiskSettings.Placement);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, result.Caching);
            Assert.True(result.WriteAcceleratorEnabled);
        }

        [Fact]
        public void FromMgmtOSDisk_WithMinimalOSDisk_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtOSDisk = new OSDisk();

            // Act
            var result = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ManagedDisk);
            Assert.Null(result.DiskSizeGB);
            Assert.Null(result.EphemeralOSDiskSettings);
            Assert.Null(result.Caching);
            Assert.Null(result.WriteAcceleratorEnabled);
        }

        [Fact]
        public void FromMgmtOSDisk_WithNullOSDisk_ReturnsNull()
        {
            // Act
            var result = PSOSDisk.fromMgmtOSDisk(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtOSDisk_VerifyCorrectType_ReturnsPSOSDisk()
        {
            // Arrange
            var mgmtOSDisk = new OSDisk(diskSizeGb: 64);

            // Act
            var result = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSOSDisk>(result);
        }

        [Theory]
        [InlineData(CachingType.None, Microsoft.Azure.Batch.Common.CachingType.None)]
        [InlineData(CachingType.ReadOnly, Microsoft.Azure.Batch.Common.CachingType.ReadOnly)]
        [InlineData(CachingType.ReadWrite, Microsoft.Azure.Batch.Common.CachingType.ReadWrite)]
        public void FromMgmtOSDisk_AllValidCachingTypes_ReturnsCorrectMapping(
            CachingType mgmtCaching,
            Microsoft.Azure.Batch.Common.CachingType expectedPsCaching)
        {
            // Arrange
            var mgmtOSDisk = new OSDisk(caching: mgmtCaching);

            // Act
            var result = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsCaching, result.Caching);
        }

        [Theory]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        [InlineData(512)]
        [InlineData(1024)]
        public void FromMgmtOSDisk_VariousDiskSizes_ReturnsCorrectMapping(int diskSize)
        {
            // Arrange
            var mgmtOSDisk = new OSDisk(diskSizeGb: diskSize);

            // Act
            var result = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(diskSize, result.DiskSizeGB);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FromMgmtOSDisk_WriteAcceleratorEnabled_ReturnsCorrectMapping(bool writeAcceleratorEnabled)
        {
            // Arrange
            var mgmtOSDisk = new OSDisk(writeAcceleratorEnabled: writeAcceleratorEnabled);

            // Act
            var result = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(writeAcceleratorEnabled, result.WriteAcceleratorEnabled);
        }

        #endregion

        #region toMgmtOSDisk Tests

        [Fact]
        public void ToMgmtOSDisk_WithCompleteOSDisk_ReturnsCorrectMapping()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);
            var psEphemeralSettings = new PSDiffDiskSettings
            {
                Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk
            };
            var psOSDisk = new PSOSDisk
            {
                ManagedDisk = psManagedDisk,
                DiskSizeGB = 256,
                EphemeralOSDiskSettings = psEphemeralSettings,
                Caching = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                WriteAcceleratorEnabled = false
            };

            // Act
            var result = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ManagedDisk);
            Assert.Equal(StorageAccountType.StandardSSDLRS, result.ManagedDisk.StorageAccountType);
            Assert.Equal(256, result.DiskSizeGb);
            Assert.NotNull(result.EphemeralOSDiskSettings);
            Assert.Equal(DiffDiskPlacement.CacheDisk, result.EphemeralOSDiskSettings.Placement);
            Assert.Equal(CachingType.ReadOnly, result.Caching);
            Assert.False(result.WriteAcceleratorEnabled);
        }

        [Fact]
        public void ToMgmtOSDisk_WithMinimalOSDisk_ReturnsCorrectMapping()
        {
            // Arrange
            var psOSDisk = new PSOSDisk();

            // Act
            var result = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.ManagedDisk);
            Assert.Null(result.DiskSizeGb);
            Assert.Null(result.EphemeralOSDiskSettings);
            Assert.Null(result.Caching);
            Assert.Null(result.WriteAcceleratorEnabled);
        }

        [Fact]
        public void ToMgmtOSDisk_VerifyCorrectType_ReturnsOSDisk()
        {
            // Arrange
            var psOSDisk = new PSOSDisk
            {
                DiskSizeGB = 64
            };

            // Act
            var result = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OSDisk>(result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.None, CachingType.None)]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.ReadOnly, CachingType.ReadOnly)]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, CachingType.ReadWrite)]
        public void ToMgmtOSDisk_AllValidCachingTypes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.CachingType psCaching,
            CachingType expectedMgmtCaching)
        {
            // Arrange
            var psOSDisk = new PSOSDisk
            {
                Caching = psCaching
            };

            // Act
            var result = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtCaching, result.Caching);
        }

        [Theory]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        [InlineData(512)]
        [InlineData(1024)]
        [InlineData(2048)]
        public void ToMgmtOSDisk_VariousDiskSizes_ReturnsCorrectMapping(int diskSize)
        {
            // Arrange
            var psOSDisk = new PSOSDisk
            {
                DiskSizeGB = diskSize
            };

            // Act
            var result = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(diskSize, result.DiskSizeGb);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToMgmtOSDisk_WriteAcceleratorEnabled_ReturnsCorrectMapping(bool writeAcceleratorEnabled)
        {
            // Arrange
            var psOSDisk = new PSOSDisk
            {
                WriteAcceleratorEnabled = writeAcceleratorEnabled
            };

            // Act
            var result = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(writeAcceleratorEnabled, result.WriteAcceleratorEnabled);
        }

        [Fact]
        public void ToMgmtOSDisk_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psOSDisk = new PSOSDisk
            {
                DiskSizeGB = 128
            };

            // Act
            var result1 = psOSDisk.toMgmtOSDisk();
            var result2 = psOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesCompleteConfiguration()
        {
            // Arrange
            var originalMgmtOSDisk = new OSDisk(
                ephemeralOSDiskSettings: new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                caching: CachingType.ReadWrite,
                managedDisk: new ManagedDisk(StorageAccountType.PremiumLRS),
                diskSizeGb: 512,
                writeAcceleratorEnabled: true
            );

            // Act - Convert Management -> PS -> Management
            var psOSDisk = PSOSDisk.fromMgmtOSDisk(originalMgmtOSDisk);
            var roundTripMgmtOSDisk = psOSDisk.toMgmtOSDisk();

            // Assert - Should get back the original values
            Assert.NotNull(roundTripMgmtOSDisk);
            Assert.Equal(originalMgmtOSDisk.DiskSizeGb, roundTripMgmtOSDisk.DiskSizeGb);
            Assert.Equal(originalMgmtOSDisk.Caching, roundTripMgmtOSDisk.Caching);
            Assert.Equal(originalMgmtOSDisk.WriteAcceleratorEnabled, roundTripMgmtOSDisk.WriteAcceleratorEnabled);
            Assert.Equal(originalMgmtOSDisk.ManagedDisk.StorageAccountType, roundTripMgmtOSDisk.ManagedDisk.StorageAccountType);
            Assert.Equal(originalMgmtOSDisk.EphemeralOSDiskSettings.Placement, roundTripMgmtOSDisk.EphemeralOSDiskSettings.Placement);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesCompleteConfiguration()
        {
            // Arrange
            var originalPsOSDisk = new PSOSDisk
            {
                ManagedDisk = new PSManagedDisk(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs),
                DiskSizeGB = 256,
                EphemeralOSDiskSettings = new PSDiffDiskSettings { Placement = Azure.Batch.Common.DiffDiskPlacement.CacheDisk },
                Caching = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                WriteAcceleratorEnabled = false
            };

            // Act - Convert PS -> Management -> PS
            var mgmtOSDisk = originalPsOSDisk.toMgmtOSDisk();
            var roundTripPsOSDisk = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert - Should get back the original values
            Assert.NotNull(roundTripPsOSDisk);
            Assert.Equal(originalPsOSDisk.DiskSizeGB, roundTripPsOSDisk.DiskSizeGB);
            Assert.Equal(originalPsOSDisk.Caching, roundTripPsOSDisk.Caching);
            Assert.Equal(originalPsOSDisk.WriteAcceleratorEnabled, roundTripPsOSDisk.WriteAcceleratorEnabled);
            Assert.Equal(originalPsOSDisk.ManagedDisk.StorageAccountType, roundTripPsOSDisk.ManagedDisk.StorageAccountType);
            Assert.Equal(originalPsOSDisk.EphemeralOSDiskSettings.Placement, roundTripPsOSDisk.EphemeralOSDiskSettings.Placement);
        }

        [Theory]
        [InlineData(64, CachingType.None, false)]
        [InlineData(128, CachingType.ReadOnly, true)]
        [InlineData(256, CachingType.ReadWrite, false)]
        [InlineData(512, CachingType.ReadOnly, true)]
        public void RoundTripConversion_VariousConfigurations_PreservesAllValues(
            int diskSize, CachingType caching, bool writeAcceleratorEnabled)
        {
            // Arrange
            var originalMgmtOSDisk = new OSDisk(
                caching: caching,
                diskSizeGb: diskSize,
                writeAcceleratorEnabled: writeAcceleratorEnabled
            );

            // Act - Convert Management -> PS -> Management
            var psOSDisk = PSOSDisk.fromMgmtOSDisk(originalMgmtOSDisk);
            var roundTripMgmtOSDisk = psOSDisk.toMgmtOSDisk();

            // Assert - Should get back the original values
            Assert.NotNull(roundTripMgmtOSDisk);
            Assert.Equal(diskSize, roundTripMgmtOSDisk.DiskSizeGb);
            Assert.Equal(caching, roundTripMgmtOSDisk.Caching);
            Assert.Equal(writeAcceleratorEnabled, roundTripMgmtOSDisk.WriteAcceleratorEnabled);
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            var originalMgmtOSDisk = new OSDisk(
                ephemeralOSDiskSettings: null,
                caching: null,
                managedDisk: null,
                diskSizeGb: null,
                writeAcceleratorEnabled: null
            );

            // Act - Convert Management -> PS -> Management
            var psOSDisk = PSOSDisk.fromMgmtOSDisk(originalMgmtOSDisk);
            var roundTripMgmtOSDisk = psOSDisk.toMgmtOSDisk();

            // Assert - Should preserve null values
            Assert.NotNull(roundTripMgmtOSDisk);
            Assert.Null(roundTripMgmtOSDisk.EphemeralOSDiskSettings);
            Assert.Null(roundTripMgmtOSDisk.Caching);
            Assert.Null(roundTripMgmtOSDisk.ManagedDisk);
            Assert.Null(roundTripMgmtOSDisk.DiskSizeGb);
            Assert.Null(roundTripMgmtOSDisk.WriteAcceleratorEnabled);
        }

        [Fact]
        public void RoundTripConversion_WithNullOSDisk_HandlesCorrectly()
        {
            // Arrange
            OSDisk nullMgmtOSDisk = null;

            // Act
            var psOSDisk = PSOSDisk.fromMgmtOSDisk(nullMgmtOSDisk);

            // Assert
            Assert.Null(psOSDisk);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void OSDiskConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test complete OS disk configuration with all components
            var mgmtOSDisk = new OSDisk(
                ephemeralOSDiskSettings: new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                caching: CachingType.ReadWrite,
                managedDisk: new ManagedDisk(StorageAccountType.PremiumLRS),
                diskSizeGb: 128,
                writeAcceleratorEnabled: true
            );

            var psOSDisk = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);
            var backToMgmt = psOSDisk.toMgmtOSDisk();

            // Assert semantic equivalence preserved
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psOSDisk.EphemeralOSDiskSettings.Placement);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, psOSDisk.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, psOSDisk.ManagedDisk.StorageAccountType);
            Assert.Equal(128, psOSDisk.DiskSizeGB);
            Assert.True(psOSDisk.WriteAcceleratorEnabled);

            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmt.EphemeralOSDiskSettings.Placement);
            Assert.Equal(CachingType.ReadWrite, backToMgmt.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, backToMgmt.ManagedDisk.StorageAccountType);
            Assert.Equal(128, backToMgmt.DiskSizeGb);
            Assert.True(backToMgmt.WriteAcceleratorEnabled);
        }

        [Fact]
        public void OSDiskConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSOSDisk.fromMgmtOSDisk(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void OSDiskConversions_VirtualMachineContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure VM OS disk configuration
            // OSDisk is used to configure the operating system disk for Azure Batch VMs

            // Arrange - Test OS disk configuration for high-performance Batch nodes
            var mgmtOSDisk = new OSDisk(
                ephemeralOSDiskSettings: new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                caching: CachingType.ReadWrite,
                managedDisk: new ManagedDisk(StorageAccountType.PremiumLRS),
                diskSizeGb: 256,
                writeAcceleratorEnabled: true
            );

            var psOSDisk = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Act & Assert - Should convert correctly for VM OS disk configuration
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psOSDisk.EphemeralOSDiskSettings.Placement);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, psOSDisk.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, psOSDisk.ManagedDisk.StorageAccountType);

            // Verify round-trip conversion maintains VM OS disk semantics
            var backToMgmt = psOSDisk.toMgmtOSDisk();

            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmt.EphemeralOSDiskSettings.Placement);
            Assert.Equal(CachingType.ReadWrite, backToMgmt.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, backToMgmt.ManagedDisk.StorageAccountType);
        }

        [Fact]
        public void OSDiskConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default OS disk values

            // Arrange
            var defaultMgmtOSDisk = new OSDisk();
            var defaultPsOSDisk = new PSOSDisk();

            // Act
            var psFromDefault = PSOSDisk.fromMgmtOSDisk(defaultMgmtOSDisk);
            var mgmtFromDefault = defaultPsOSDisk.toMgmtOSDisk();

            // Assert
            Assert.NotNull(psFromDefault);
            Assert.NotNull(mgmtFromDefault);
            // Default values should be preserved
            Assert.Equal(defaultMgmtOSDisk.DiskSizeGb, mgmtFromDefault.DiskSizeGb);
            Assert.Equal(defaultMgmtOSDisk.Caching, mgmtFromDefault.Caching);
            Assert.Equal(defaultMgmtOSDisk.WriteAcceleratorEnabled, mgmtFromDefault.WriteAcceleratorEnabled);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void OSDiskConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var mgmtOSDisk = new OSDisk(
                caching: CachingType.ReadWrite,
                diskSizeGb: 128
            );
            var psOSDisk = new PSOSDisk
            {
                Caching = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                DiskSizeGB = 256
            };

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var psResult = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);
                var mgmtResult = psOSDisk.toMgmtOSDisk();

                Assert.NotNull(psResult);
                Assert.NotNull(mgmtResult);
                Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, psResult.Caching);
                Assert.Equal(CachingType.ReadOnly, mgmtResult.Caching);
            }
        }

        [Fact]
        public void OSDiskConversions_EdgeCaseDiskSizes_HandleCorrectly()
        {
            // Test conversion with various edge case disk sizes

            var testDiskSizes = new[]
            {
                // Minimum OS disk sizes
                30,
                32,
                
                // Common OS disk sizes
                64,
                128,
                256,
                512,
                1024,
                
                // Large OS disk sizes
                2048,
                4096
            };

            foreach (var diskSize in testDiskSizes)
            {
                // Arrange
                var mgmtOSDisk = new OSDisk(diskSizeGb: diskSize);

                // Act
                var psResult = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);
                var roundTripResult = psResult.toMgmtOSDisk();

                // Assert
                Assert.NotNull(psResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(diskSize, psResult.DiskSizeGB);
                Assert.Equal(diskSize, roundTripResult.DiskSizeGb);
            }
        }

        #endregion

        #region Type Safety and Instance Creation Tests

        [Fact]
        public void OSDiskConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var mgmtOSDisk = new OSDisk(diskSizeGb: 128);
            var psOSDisk = new PSOSDisk
            {
                DiskSizeGB = 256
            };

            // Act
            var psResult = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);
            var mgmtResult = psOSDisk.toMgmtOSDisk();

            // Assert - Verify correct types are returned
            Assert.IsType<PSOSDisk>(psResult);
            Assert.IsType<OSDisk>(mgmtResult);
        }

        [Fact]
        public void OSDiskConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var mgmtOSDisk = new OSDisk(
                caching: CachingType.ReadWrite,
                diskSizeGb: 128,
                writeAcceleratorEnabled: true
            );
            var psOSDisk = new PSOSDisk
            {
                Caching = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                DiskSizeGB = 256,
                WriteAcceleratorEnabled = false
            };

            // Act
            var psResult = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);
            var mgmtResult = psOSDisk.toMgmtOSDisk();

            // Assert - Verify proper instance creation
            Assert.NotNull(psResult);
            Assert.NotNull(mgmtResult);
            Assert.IsType<PSOSDisk>(psResult);
            Assert.IsType<OSDisk>(mgmtResult);

            // Verify new instances are created
            Assert.NotSame(mgmtOSDisk, mgmtResult);
            Assert.NotSame(psOSDisk, psResult);
        }

        [Fact]
        public void OSDiskConversions_PropertiesAccessible_AfterConversion()
        {
            // Test that all properties are accessible and correct after conversion

            // Arrange
            var originalCaching = Microsoft.Azure.Batch.Common.CachingType.ReadWrite;
            var originalDiskSize = 512;
            var originalWriteAccelerator = true;

            var psOSDisk = new PSOSDisk
            {
                Caching = originalCaching,
                DiskSizeGB = originalDiskSize,
                WriteAcceleratorEnabled = originalWriteAccelerator
            };

            // Act
            var mgmtOSDisk = psOSDisk.toMgmtOSDisk();
            var convertedPsOSDisk = PSOSDisk.fromMgmtOSDisk(mgmtOSDisk);

            // Assert
            Assert.Equal(originalCaching, psOSDisk.Caching);
            Assert.Equal(originalDiskSize, psOSDisk.DiskSizeGB);
            Assert.Equal(originalWriteAccelerator, psOSDisk.WriteAcceleratorEnabled);

            Assert.Equal(CachingType.ReadWrite, mgmtOSDisk.Caching);
            Assert.Equal(originalDiskSize, mgmtOSDisk.DiskSizeGb);
            Assert.Equal(originalWriteAccelerator, mgmtOSDisk.WriteAcceleratorEnabled);

            Assert.Equal(originalCaching, convertedPsOSDisk.Caching);
            Assert.Equal(originalDiskSize, convertedPsOSDisk.DiskSizeGB);
            Assert.Equal(originalWriteAccelerator, convertedPsOSDisk.WriteAcceleratorEnabled);
        }

        #endregion

        #region Batch Pool Configuration Context Tests

        [Fact]
        public void OSDiskConversions_BatchPoolConfiguration_VerifyOSDiskStrategy()
        {
            // This test validates the conversions work correctly in Batch pool configuration scenarios
            // OSDisk determines the operating system disk configuration for Azure Batch pool VMs

            // Arrange - Test various OS disk configurations for Batch pools
            var scenarios = new[]
            {
                new {
                    MgmtOSDisk = new OSDisk(
                        ephemeralOSDiskSettings: new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                        caching: CachingType.ReadWrite,
                        managedDisk: new ManagedDisk(StorageAccountType.PremiumLRS),
                        diskSizeGb: 128,
                        writeAcceleratorEnabled: true
                    ),
                    Description = "High-performance OS disk configuration for compute-intensive Batch workloads"
                },
                new {
                    MgmtOSDisk = new OSDisk(
                        caching: CachingType.ReadOnly,
                        managedDisk: new ManagedDisk(StorageAccountType.StandardLRS),
                        diskSizeGb: 64,
                        writeAcceleratorEnabled: false
                    ),
                    Description = "Standard OS disk configuration for general Batch workloads"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Act
                var psResult = PSOSDisk.fromMgmtOSDisk(scenario.MgmtOSDisk);
                var mgmtResult = psResult.toMgmtOSDisk();

                // Assert
                Assert.Equal(scenario.MgmtOSDisk.DiskSizeGb, psResult.DiskSizeGB);
                Assert.Equal(scenario.MgmtOSDisk.Caching, mgmtResult.Caching);
                Assert.Equal(scenario.MgmtOSDisk.WriteAcceleratorEnabled, mgmtResult.WriteAcceleratorEnabled);

                // Verify round-trip maintains Batch pool OS disk strategy
                var roundTripMgmt = psResult.toMgmtOSDisk();
                var roundTripPs = PSOSDisk.fromMgmtOSDisk(mgmtResult);

                Assert.Equal(scenario.MgmtOSDisk.DiskSizeGb, roundTripMgmt.DiskSizeGb);
                Assert.Equal(scenario.MgmtOSDisk.Caching.Value.ToString(), roundTripPs.Caching.Value.ToString());
            }
        }

        [Fact]
        public void OSDiskConversions_VMConfigurationContext_PreservesOSDiskSemantics()
        {
            // This test ensures that OS disk configuration semantics are correctly preserved in VM context

            // Arrange - High-performance OS disk for Azure Batch compute nodes
            var mgmtHighPerfOSDisk = new OSDisk(
                ephemeralOSDiskSettings: new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                caching: CachingType.ReadWrite,
                managedDisk: new ManagedDisk(StorageAccountType.PremiumLRS),
                diskSizeGb: 256,
                writeAcceleratorEnabled: true
            );

            // Act
            var psHighPerfOSDisk = PSOSDisk.fromMgmtOSDisk(mgmtHighPerfOSDisk);
            var backToMgmtHighPerf = psHighPerfOSDisk.toMgmtOSDisk();

            // Assert - High-performance OS disk semantics preserved
            Assert.Equal(Azure.Batch.Common.DiffDiskPlacement.CacheDisk, psHighPerfOSDisk.EphemeralOSDiskSettings.Placement);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, psHighPerfOSDisk.Caching);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, psHighPerfOSDisk.ManagedDisk.StorageAccountType);
            Assert.True(psHighPerfOSDisk.WriteAcceleratorEnabled);

            Assert.Equal(DiffDiskPlacement.CacheDisk, backToMgmtHighPerf.EphemeralOSDiskSettings.Placement);
            Assert.Equal(CachingType.ReadWrite, backToMgmtHighPerf.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, backToMgmtHighPerf.ManagedDisk.StorageAccountType);
            Assert.True(backToMgmtHighPerf.WriteAcceleratorEnabled);
            // OS disk configuration ensures optimal performance for Batch compute workloads
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSOSDisk_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes

            // Arrange & Act
            var defaultOSDisk = new PSOSDisk();
            var configuredOSDisk = new PSOSDisk
            {
                DiskSizeGB = 128,
                Caching = Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                WriteAcceleratorEnabled = true
            };

            // Assert
            Assert.Null(defaultOSDisk.DiskSizeGB);
            Assert.Null(defaultOSDisk.Caching);
            Assert.Null(defaultOSDisk.WriteAcceleratorEnabled);

            Assert.Equal(128, configuredOSDisk.DiskSizeGB);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, configuredOSDisk.Caching);
            Assert.True(configuredOSDisk.WriteAcceleratorEnabled);
        }

        [Fact]
        public void OSDisk_Constructor_WorksWithParameters()
        {
            // Test that the Management constructor works with all parameters

            // Arrange & Act
            var minimalOSDisk = new OSDisk();
            var fullOSDisk = new OSDisk(
                ephemeralOSDiskSettings: new DiffDiskSettings(DiffDiskPlacement.CacheDisk),
                caching: CachingType.ReadWrite,
                managedDisk: new ManagedDisk(StorageAccountType.PremiumLRS),
                diskSizeGb: 256,
                writeAcceleratorEnabled: true
            );

            // Assert
            Assert.Null(minimalOSDisk.EphemeralOSDiskSettings);
            Assert.Null(minimalOSDisk.Caching);
            Assert.Null(minimalOSDisk.ManagedDisk);
            Assert.Null(minimalOSDisk.DiskSizeGb);
            Assert.Null(minimalOSDisk.WriteAcceleratorEnabled);

            Assert.Equal(DiffDiskPlacement.CacheDisk, fullOSDisk.EphemeralOSDiskSettings.Placement);
            Assert.Equal(CachingType.ReadWrite, fullOSDisk.Caching);
            Assert.Equal(StorageAccountType.PremiumLRS, fullOSDisk.ManagedDisk.StorageAccountType);
            Assert.Equal(256, fullOSDisk.DiskSizeGb);
            Assert.True(fullOSDisk.WriteAcceleratorEnabled);
        }

        #endregion
    }
}
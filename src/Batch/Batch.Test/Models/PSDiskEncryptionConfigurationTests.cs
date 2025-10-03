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
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSDiskEncryptionConfigurationTests
    {
        #region toMgmtDiskEncryptionConfiguration Tests

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_WithOsDiskTarget_ReturnsCorrectMapping()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk
                });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(DiskEncryptionTarget.OsDisk, result.Targets.First());
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_WithTemporaryDiskTarget_ReturnsCorrectMapping()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, result.Targets.First());
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_WithBothTargets_ReturnsCorrectMapping()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Equal(2, result.Targets.Count);
            Assert.Contains(DiskEncryptionTarget.OsDisk, result.Targets);
            Assert.Contains(DiskEncryptionTarget.TemporaryDisk, result.Targets);
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_WithNullTargets_ReturnsNullTargets()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(targets: null);

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Targets);
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_WithEmptyTargets_ReturnsEmptyTargets()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>());

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Empty(result.Targets);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk)]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk)]
        public void ToMgmtDiskEncryptionConfiguration_SingleTargetValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.DiskEncryptionTarget target)
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget> { target });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal((DiskEncryptionTarget)target, result.Targets.First());
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk
                });

            // Act
            var result1 = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var result2 = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_VerifyDiskEncryptionConfigurationType()
        {
            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk
                });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DiskEncryptionConfiguration>(result);
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_WindowsPoolConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Windows pool requires both OsDisk and TemporaryDisk as per documentation
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Equal(2, result.Targets.Count);
            Assert.Contains(DiskEncryptionTarget.OsDisk, result.Targets);
            Assert.Contains(DiskEncryptionTarget.TemporaryDisk, result.Targets);
        }

        [Fact]
        public void ToMgmtDiskEncryptionConfiguration_LinuxPoolConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Linux pool supports only TemporaryDisk as per documentation
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var result = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, result.Targets.First());
        }

        #endregion

        #region fromMgmtDiskEncryptionConfiguration Tests

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithOsDiskTarget_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { DiskEncryptionTarget.OsDisk });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result.Targets.First());
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithTemporaryDiskTarget_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { DiskEncryptionTarget.TemporaryDisk });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, result.Targets.First());
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithBothTargets_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget>
                {
                    DiskEncryptionTarget.OsDisk,
                    DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Equal(2, result.Targets.Count);
            Assert.Contains(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result.Targets);
            Assert.Contains(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, result.Targets);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithNullMgmtConfiguration_ReturnsNull()
        {
            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithNullTargets_ReturnsNullTargets()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(null);

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Targets);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithEmptyTargets_ReturnsEmptyTargets()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget>());

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Empty(result.Targets);
        }

        [Theory]
        [InlineData(DiskEncryptionTarget.OsDisk)]
        [InlineData(DiskEncryptionTarget.TemporaryDisk)]
        public void FromMgmtDiskEncryptionConfiguration_SingleTargetValues_ReturnsCorrectMapping(
            DiskEncryptionTarget target)
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { target });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal((Microsoft.Azure.Batch.Common.DiskEncryptionTarget)target, result.Targets.First());
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { DiskEncryptionTarget.OsDisk });

            // Act - Call static method directly on class
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result.Targets.First());
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { DiskEncryptionTarget.OsDisk });

            // Act
            var result1 = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);
            var result2 = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_VerifyPSDiskEncryptionConfigurationType()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { DiskEncryptionTarget.OsDisk });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSDiskEncryptionConfiguration>(result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(); // Uses default constructor

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Targets);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_WindowsPoolConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Windows pool requires both OsDisk and TemporaryDisk as per documentation
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget>
                {
                    DiskEncryptionTarget.OsDisk,
                    DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Equal(2, result.Targets.Count);
            Assert.Contains(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result.Targets);
            Assert.Contains(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, result.Targets);
        }

        [Fact]
        public void FromMgmtDiskEncryptionConfiguration_LinuxPoolConfiguration_ReturnsCorrectMapping()
        {
            // Arrange - Linux pool supports only TemporaryDisk as per documentation
            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget> { DiskEncryptionTarget.TemporaryDisk });

            // Act
            var result = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Targets);
            Assert.Single(result.Targets);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, result.Targets.First());
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesOsDiskTarget()
        {
            // Arrange
            var originalPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk
                });

            // Act
            var mgmtDiskEncryptionConfig = originalPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var roundTripPsDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(roundTripPsDiskEncryptionConfig);
            Assert.NotNull(roundTripPsDiskEncryptionConfig.Targets);
            Assert.Equal(originalPsDiskEncryptionConfig.Targets.Count, roundTripPsDiskEncryptionConfig.Targets.Count);
            Assert.Equal(originalPsDiskEncryptionConfig.Targets.First(), roundTripPsDiskEncryptionConfig.Targets.First());
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesTemporaryDiskTarget()
        {
            // Arrange
            var originalPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var mgmtDiskEncryptionConfig = originalPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var roundTripPsDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(roundTripPsDiskEncryptionConfig);
            Assert.NotNull(roundTripPsDiskEncryptionConfig.Targets);
            Assert.Equal(originalPsDiskEncryptionConfig.Targets.Count, roundTripPsDiskEncryptionConfig.Targets.Count);
            Assert.Equal(originalPsDiskEncryptionConfig.Targets.First(), roundTripPsDiskEncryptionConfig.Targets.First());
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesBothTargets()
        {
            // Arrange
            var originalPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var mgmtDiskEncryptionConfig = originalPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var roundTripPsDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(roundTripPsDiskEncryptionConfig);
            Assert.NotNull(roundTripPsDiskEncryptionConfig.Targets);
            Assert.Equal(originalPsDiskEncryptionConfig.Targets.Count, roundTripPsDiskEncryptionConfig.Targets.Count);
            
            foreach (var originalTarget in originalPsDiskEncryptionConfig.Targets)
            {
                Assert.Contains(originalTarget, roundTripPsDiskEncryptionConfig.Targets);
            }
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullTargets()
        {
            // Arrange
            var originalPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(targets: null);

            // Act
            var mgmtDiskEncryptionConfig = originalPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var roundTripPsDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(roundTripPsDiskEncryptionConfig);
            Assert.Null(roundTripPsDiskEncryptionConfig.Targets);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyTargets()
        {
            // Arrange
            var originalPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>());

            // Act
            var mgmtDiskEncryptionConfig = originalPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var roundTripPsDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(roundTripPsDiskEncryptionConfig);
            Assert.NotNull(roundTripPsDiskEncryptionConfig.Targets);
            Assert.Empty(roundTripPsDiskEncryptionConfig.Targets);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk)]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk)]
        public void RoundTripConversion_AllValidTargets_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.DiskEncryptionTarget target)
        {
            // Arrange
            var originalPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget> { target });

            // Act
            var mgmtDiskEncryptionConfig = originalPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var roundTripPsDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(roundTripPsDiskEncryptionConfig);
            Assert.NotNull(roundTripPsDiskEncryptionConfig.Targets);
            Assert.Single(roundTripPsDiskEncryptionConfig.Targets);
            Assert.Equal(target, roundTripPsDiskEncryptionConfig.Targets.First());
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget>
                {
                    DiskEncryptionTarget.OsDisk,
                    DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var psDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(originalMgmtDiskEncryptionConfig);
            var roundTripMgmtDiskEncryptionConfig = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtDiskEncryptionConfig);
            Assert.NotNull(roundTripMgmtDiskEncryptionConfig.Targets);
            Assert.Equal(originalMgmtDiskEncryptionConfig.Targets.Count, roundTripMgmtDiskEncryptionConfig.Targets.Count);
            
            foreach (var originalTarget in originalMgmtDiskEncryptionConfig.Targets)
            {
                Assert.Contains(originalTarget, roundTripMgmtDiskEncryptionConfig.Targets);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void DiskEncryptionConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with Windows pool disk encryption configuration
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var mgmtDiskEncryptionConfig = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var backToPs = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert
            Assert.NotNull(mgmtDiskEncryptionConfig);
            Assert.NotNull(mgmtDiskEncryptionConfig.Targets);
            Assert.Equal(2, mgmtDiskEncryptionConfig.Targets.Count);
            Assert.Contains(DiskEncryptionTarget.OsDisk, mgmtDiskEncryptionConfig.Targets);
            Assert.Contains(DiskEncryptionTarget.TemporaryDisk, mgmtDiskEncryptionConfig.Targets);

            Assert.NotNull(backToPs);
            Assert.NotNull(backToPs.Targets);
            Assert.Equal(2, backToPs.Targets.Count);
            Assert.Contains(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, backToPs.Targets);
            Assert.Contains(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, backToPs.Targets);
        }

        [Fact]
        public void DiskEncryptionConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void DiskEncryptionConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool configuration
            // DiskEncryptionConfiguration is used to configure disk encryption for Batch pool compute nodes

            // Arrange - Test with different disk encryption scenarios
            var scenarios = new[]
            {
                // Windows pool configuration (requires both targets)
                new {
                    PoolType = "Windows",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    Description = "Windows pool disk encryption with both OS and temporary disk targets"
                },
                // Linux pool configuration (only TemporaryDisk supported)
                new {
                    PoolType = "Linux",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    Description = "Linux pool disk encryption with temporary disk target only"
                },
                // Minimal configuration
                new {
                    PoolType = "Linux",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    Description = "Minimal disk encryption configuration for compliance"
                },
                // Empty configuration (no encryption)
                new {
                    PoolType = "Any",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>(),
                    Description = "Empty disk encryption configuration (no targets)"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(scenario.Targets);

                // Act
                var mgmtDiskEncryptionConfig = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();

                // Assert - Should convert correctly for Batch pool configuration
                Assert.NotNull(mgmtDiskEncryptionConfig);
                Assert.NotNull(mgmtDiskEncryptionConfig.Targets);
                Assert.Equal(scenario.Targets.Count, mgmtDiskEncryptionConfig.Targets.Count);
                
                foreach (var target in scenario.Targets)
                {
                    Assert.Contains((DiskEncryptionTarget)target, mgmtDiskEncryptionConfig.Targets);
                }

                // Verify round-trip conversion maintains disk encryption semantics
                var backToPs = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);
                Assert.NotNull(backToPs);
                Assert.NotNull(backToPs.Targets);
                Assert.Equal(scenario.Targets.Count, backToPs.Targets.Count);
                
                foreach (var target in scenario.Targets)
                {
                    Assert.Contains(target, backToPs.Targets);
                }
            }
        }

        [Fact]
        public void DiskEncryptionConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget>
                {
                    DiskEncryptionTarget.TemporaryDisk
                });

            // Act
            var mgmtResult = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            var psResult = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<DiskEncryptionConfiguration>(mgmtResult);
            Assert.IsType<PSDiskEncryptionConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtDiskEncryptionConfig, mgmtResult);
            Assert.NotSame(psDiskEncryptionConfig, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void DiskEncryptionConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                });

            var mgmtDiskEncryptionConfig = new DiskEncryptionConfiguration(
                new List<DiskEncryptionTarget>
                {
                    DiskEncryptionTarget.OsDisk,
                    DiskEncryptionTarget.TemporaryDisk
                });

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 1000; i++)
            {
                var mgmtResult = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
                var psResult = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(2, mgmtResult.Targets.Count);
                Assert.Equal(2, psResult.Targets.Count);
            }
        }

        [Fact]
        public void DiskEncryptionConfigurationConversions_DefaultAndNullValues_HandleCorrectly()
        {
            // Test conversion with default and null values

            // Scenario 1: Default PS constructor with null targets
            var defaultPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(targets: null);

            var mgmtFromDefault = defaultPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            Assert.NotNull(mgmtFromDefault);
            Assert.Null(mgmtFromDefault.Targets);

            // Scenario 2: Default management constructor
            var defaultMgmtDiskEncryptionConfig = new DiskEncryptionConfiguration();

            var psFromDefault = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(defaultMgmtDiskEncryptionConfig);
            Assert.NotNull(psFromDefault);
            Assert.Null(psFromDefault.Targets);

            // Scenario 3: Empty targets list
            var emptyTargetsPsDiskEncryptionConfig = new PSDiskEncryptionConfiguration(
                new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>());

            var mgmtEmptyTargetsResult = emptyTargetsPsDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
            Assert.NotNull(mgmtEmptyTargetsResult);
            Assert.NotNull(mgmtEmptyTargetsResult.Targets);
            Assert.Empty(mgmtEmptyTargetsResult.Targets);

            var roundTripEmptyTargets = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtEmptyTargetsResult);
            Assert.NotNull(roundTripEmptyTargets);
            Assert.NotNull(roundTripEmptyTargets.Targets);
            Assert.Empty(roundTripEmptyTargets.Targets);
        }

        [Fact]
        public void DiskEncryptionConfigurationConversions_PlatformSpecificScenarios_VerifySemantics()
        {
            // This test validates platform-specific disk encryption scenarios

            var platformScenarios = new[]
            {
                new {
                    Platform = "Windows Server 2019",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    ComplianceRequirement = "FIPS 140-2",
                    Description = "Windows pool with full disk encryption for FIPS compliance"
                },
                new {
                    Platform = "Ubuntu 20.04 LTS",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    ComplianceRequirement = "PCI DSS",
                    Description = "Linux pool with temporary disk encryption for PCI compliance"
                },
                new {
                    Platform = "Windows Server 2022",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    ComplianceRequirement = "SOC 2",
                    Description = "Modern Windows pool with comprehensive disk encryption"
                }
            };

            foreach (var scenario in platformScenarios)
            {
                // Act - Convert configuration with platform-specific requirements
                var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(scenario.Targets);
                var mgmtDiskEncryptionConfig = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
                var roundTripDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

                // Assert - Platform-specific encryption semantics should be preserved
                Assert.NotNull(mgmtDiskEncryptionConfig);
                Assert.NotNull(roundTripDiskEncryptionConfig);
                Assert.Equal(scenario.Targets.Count, mgmtDiskEncryptionConfig.Targets.Count);
                Assert.Equal(scenario.Targets.Count, roundTripDiskEncryptionConfig.Targets.Count);

                // Verify target preservation
                foreach (var target in scenario.Targets)
                {
                    Assert.Contains((DiskEncryptionTarget)target, mgmtDiskEncryptionConfig.Targets);
                    Assert.Contains(target, roundTripDiskEncryptionConfig.Targets);
                }
            }
        }

        [Fact]
        public void DiskEncryptionConfigurationConversions_SecurityComplianceContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of security compliance requirements

            // Arrange - Test with compliance-driven disk encryption scenarios
            var complianceScenarios = new[]
            {
                // Healthcare HIPAA compliance
                new {
                    Compliance = "HIPAA",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    UseCase = "Healthcare data processing with full disk encryption"
                },
                // Financial PCI DSS compliance
                new {
                    Compliance = "PCI DSS",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    UseCase = "Payment processing with temporary disk encryption"
                },
                // Government FedRAMP compliance
                new {
                    Compliance = "FedRAMP",
                    Targets = new List<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>
                    {
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                        Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
                    },
                    UseCase = "Government workloads with comprehensive encryption"
                }
            };

            foreach (var scenario in complianceScenarios)
            {
                // Act
                var psDiskEncryptionConfig = new PSDiskEncryptionConfiguration(scenario.Targets);
                var mgmtDiskEncryptionConfig = psDiskEncryptionConfig.toMgmtDiskEncryptionConfiguration();
                var roundTripDiskEncryptionConfig = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(mgmtDiskEncryptionConfig);

                // Assert - Compliance requirements should be preserved
                Assert.NotNull(mgmtDiskEncryptionConfig);
                Assert.NotNull(roundTripDiskEncryptionConfig);
                Assert.Equal(scenario.Targets.Count, mgmtDiskEncryptionConfig.Targets.Count);
                Assert.Equal(scenario.Targets.Count, roundTripDiskEncryptionConfig.Targets.Count);

                // Verify compliance semantics are maintained
                foreach (var target in scenario.Targets)
                {
                    var expectedMgmtTarget = target == Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk
                        ? DiskEncryptionTarget.OsDisk
                        : DiskEncryptionTarget.TemporaryDisk;

                    Assert.Contains(expectedMgmtTarget, mgmtDiskEncryptionConfig.Targets);
                    Assert.Contains(target, roundTripDiskEncryptionConfig.Targets);
                }
            }
        }

        #endregion
    }
}
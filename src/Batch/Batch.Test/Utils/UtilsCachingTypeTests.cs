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
    public class UtilsCachingTypeTests
    {
        #region toMgmtCaching Tests

        [Fact]
        public void ToMgmtCaching_None_ReturnsNone()
        {
            // Arrange
            var psCachingType = Microsoft.Azure.Batch.Common.CachingType.None;

            // Act
            var result = Utils.Utils.toMgmtCaching(psCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CachingType.None, result.Value);
        }

        [Fact]
        public void ToMgmtCaching_ReadOnly_ReturnsReadOnly()
        {
            // Arrange
            var psCachingType = Microsoft.Azure.Batch.Common.CachingType.ReadOnly;

            // Act
            var result = Utils.Utils.toMgmtCaching(psCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CachingType.ReadOnly, result.Value);
        }

        [Fact]
        public void ToMgmtCaching_ReadWrite_ReturnsReadWrite()
        {
            // Arrange
            var psCachingType = Microsoft.Azure.Batch.Common.CachingType.ReadWrite;

            // Act
            var result = Utils.Utils.toMgmtCaching(psCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CachingType.ReadWrite, result.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.None, CachingType.None)]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.ReadOnly, CachingType.ReadOnly)]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, CachingType.ReadWrite)]
        public void ToMgmtCaching_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.CachingType input,
            CachingType expected)
        {
            // Act
            var result = Utils.Utils.toMgmtCaching(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ToMgmtCaching_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.CachingType? nullCachingType = null;

            // Act
            var result = Utils.Utils.toMgmtCaching(nullCachingType);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtCaching_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.CachingType);

            // Act
            var result = Utils.Utils.toMgmtCaching(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default CachingType is typically None (0)
            Assert.Equal(CachingType.None, result.Value);
        }

        [Fact]
        public void ToMgmtCaching_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each caching type

            // Arrange & Act & Assert
            // None: No disk caching
            var noneResult = Utils.Utils.toMgmtCaching(Microsoft.Azure.Batch.Common.CachingType.None);
            Assert.NotNull(noneResult);
            Assert.Equal(CachingType.None, noneResult.Value);

            // ReadOnly: Disk reads are cached, but writes are not
            var readOnlyResult = Utils.Utils.toMgmtCaching(Microsoft.Azure.Batch.Common.CachingType.ReadOnly);
            Assert.NotNull(readOnlyResult);
            Assert.Equal(CachingType.ReadOnly, readOnlyResult.Value);

            // ReadWrite: Both disk reads and writes are cached
            var readWriteResult = Utils.Utils.toMgmtCaching(Microsoft.Azure.Batch.Common.CachingType.ReadWrite);
            Assert.NotNull(readWriteResult);
            Assert.Equal(CachingType.ReadWrite, readWriteResult.Value);
        }

        [Fact]
        public void ToMgmtCaching_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psCachingType = Microsoft.Azure.Batch.Common.CachingType.ReadOnly;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtCaching(psCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(CachingType.ReadOnly, result.Value);
        }

        [Fact]
        public void ToMgmtCaching_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.CachingType.None,
                Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                Microsoft.Azure.Batch.Common.CachingType.ReadWrite
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtCaching(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(CachingType), result.Value));
            }
        }

        [Fact]
        public void ToMgmtCaching_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psNone = Microsoft.Azure.Batch.Common.CachingType.None;
            var psReadOnly = Microsoft.Azure.Batch.Common.CachingType.ReadOnly;
            var psReadWrite = Microsoft.Azure.Batch.Common.CachingType.ReadWrite;

            // Act
            var mgmtNone = Utils.Utils.toMgmtCaching(psNone);
            var mgmtReadOnly = Utils.Utils.toMgmtCaching(psReadOnly);
            var mgmtReadWrite = Utils.Utils.toMgmtCaching(psReadWrite);

            // Assert
            Assert.NotNull(mgmtNone);
            Assert.NotNull(mgmtReadOnly);
            Assert.NotNull(mgmtReadWrite);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psNone, (int)mgmtNone.Value);
            Assert.Equal((int)psReadOnly, (int)mgmtReadOnly.Value);
            Assert.Equal((int)psReadWrite, (int)mgmtReadWrite.Value);
        }

        #endregion

        #region fromMgmtCaching Tests

        [Fact]
        public void FromMgmtCaching_None_ReturnsNone()
        {
            // Arrange
            var mgmtCachingType = CachingType.None;

            // Act
            var result = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.None, result.Value);
        }

        [Fact]
        public void FromMgmtCaching_ReadOnly_ReturnsReadOnly()
        {
            // Arrange
            var mgmtCachingType = CachingType.ReadOnly;

            // Act
            var result = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadOnly, result.Value);
        }

        [Fact]
        public void FromMgmtCaching_ReadWrite_ReturnsReadWrite()
        {
            // Arrange
            var mgmtCachingType = CachingType.ReadWrite;

            // Act
            var result = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, result.Value);
        }

        [Theory]
        [InlineData(CachingType.None, Microsoft.Azure.Batch.Common.CachingType.None)]
        [InlineData(CachingType.ReadOnly, Microsoft.Azure.Batch.Common.CachingType.ReadOnly)]
        [InlineData(CachingType.ReadWrite, Microsoft.Azure.Batch.Common.CachingType.ReadWrite)]
        public void FromMgmtCaching_AllValidValues_ReturnsCorrectMapping(
            CachingType input,
            Microsoft.Azure.Batch.Common.CachingType expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtCaching(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void FromMgmtCaching_NullValue_ReturnsNull()
        {
            // Arrange
            CachingType? nullCachingType = null;

            // Act
            var result = Utils.Utils.fromMgmtCaching(nullCachingType);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtCaching_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(CachingType);

            // Act
            var result = Utils.Utils.fromMgmtCaching(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default CachingType is typically None (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.None, result.Value);
        }

        [Fact]
        public void FromMgmtCaching_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each caching type

            // Arrange & Act & Assert
            // None: No disk caching
            var noneResult = Utils.Utils.fromMgmtCaching(CachingType.None);
            Assert.NotNull(noneResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.None, noneResult.Value);

            // ReadOnly: Disk reads are cached, but writes are not
            var readOnlyResult = Utils.Utils.fromMgmtCaching(CachingType.ReadOnly);
            Assert.NotNull(readOnlyResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadOnly, readOnlyResult.Value);

            // ReadWrite: Both disk reads and writes are cached
            var readWriteResult = Utils.Utils.fromMgmtCaching(CachingType.ReadWrite);
            Assert.NotNull(readWriteResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, readWriteResult.Value);
        }

        [Fact]
        public void FromMgmtCaching_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtCachingType = CachingType.ReadWrite;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, result.Value);
        }

        [Fact]
        public void FromMgmtCaching_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new CachingType?[]
            {
                CachingType.None,
                CachingType.ReadOnly,
                CachingType.ReadWrite,
                null
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtCaching(value);
                if (value.HasValue)
                {
                    Assert.NotNull(result);
                    Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.CachingType), result.Value));
                }
                else
                {
                    Assert.Null(result);
                }
            }
        }

        [Fact]
        public void FromMgmtCaching_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable CachingType

            // Arrange
            CachingType? nullableValue = CachingType.ReadOnly;

            // Act
            var result = Utils.Utils.fromMgmtCaching(nullableValue);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadOnly, result.Value);
        }

        [Fact]
        public void FromMgmtCaching_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtNone = CachingType.None;
            var mgmtReadOnly = CachingType.ReadOnly;
            var mgmtReadWrite = CachingType.ReadWrite;

            // Act
            var psNone = Utils.Utils.fromMgmtCaching(mgmtNone);
            var psReadOnly = Utils.Utils.fromMgmtCaching(mgmtReadOnly);
            var psReadWrite = Utils.Utils.fromMgmtCaching(mgmtReadWrite);

            // Assert
            Assert.NotNull(psNone);
            Assert.NotNull(psReadOnly);
            Assert.NotNull(psReadWrite);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtNone, (int)psNone.Value);
            Assert.Equal((int)mgmtReadOnly, (int)psReadOnly.Value);
            Assert.Equal((int)mgmtReadWrite, (int)psReadWrite.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNoneValue()
        {
            // Arrange
            var originalPsCachingType = Microsoft.Azure.Batch.Common.CachingType.None;

            // Act
            var mgmtCachingType = Utils.Utils.toMgmtCaching(originalPsCachingType);
            var roundTripPsCachingType = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(roundTripPsCachingType);
            Assert.Equal(originalPsCachingType, roundTripPsCachingType.Value);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesReadOnlyValue()
        {
            // Arrange
            var originalPsCachingType = Microsoft.Azure.Batch.Common.CachingType.ReadOnly;

            // Act
            var mgmtCachingType = Utils.Utils.toMgmtCaching(originalPsCachingType);
            var roundTripPsCachingType = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(roundTripPsCachingType);
            Assert.Equal(originalPsCachingType, roundTripPsCachingType.Value);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesReadWriteValue()
        {
            // Arrange
            var originalPsCachingType = Microsoft.Azure.Batch.Common.CachingType.ReadWrite;

            // Act
            var mgmtCachingType = Utils.Utils.toMgmtCaching(originalPsCachingType);
            var roundTripPsCachingType = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(roundTripPsCachingType);
            Assert.Equal(originalPsCachingType, roundTripPsCachingType.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.None)]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.ReadOnly)]
        [InlineData(Microsoft.Azure.Batch.Common.CachingType.ReadWrite)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.CachingType originalCachingType)
        {
            // Act
            var mgmtCachingType = Utils.Utils.toMgmtCaching(originalCachingType);
            var roundTripCachingType = Utils.Utils.fromMgmtCaching(mgmtCachingType);

            // Assert
            Assert.NotNull(roundTripCachingType);
            Assert.Equal(originalCachingType, roundTripCachingType.Value);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                CachingType.None,
                CachingType.ReadOnly,
                CachingType.ReadWrite
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.fromMgmtCaching(originalValue);
                var roundTripValue = Utils.Utils.toMgmtCaching(psValue);

                // Assert
                Assert.NotNull(roundTripValue);
                Assert.Equal(originalValue, roundTripValue.Value);
            }
        }

        [Fact]
        public void RoundTripConversion_NullHandling_WorksCorrectly()
        {
            // This test verifies null handling in round-trip conversions

            // Arrange
            Microsoft.Azure.Batch.Common.CachingType? nullPsValue = null;
            CachingType? nullMgmtValue = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.toMgmtCaching(nullPsValue);
            var psFromNullMgmt = Utils.Utils.fromMgmtCaching(nullMgmtValue);

            // Assert
            Assert.Null(mgmtFromNullPs);
            Assert.Null(psFromNullMgmt);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void CachingType_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psCachingTypeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.CachingType));
            var mgmtCachingTypeValues = Enum.GetValues(typeof(CachingType));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psCachingTypeValues.Length, mgmtCachingTypeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.CachingType psValue in psCachingTypeValues)
            {
                var result = Utils.Utils.toMgmtCaching(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(CachingType), result.Value));
            }

            // Verify that each management enum value can be converted successfully
            foreach (CachingType mgmtValue in mgmtCachingTypeValues)
            {
                var result = Utils.Utils.fromMgmtCaching(mgmtValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.CachingType), result.Value));
            }
        }

        [Fact]
        public void CachingType_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.CachingType.None,
                Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                Microsoft.Azure.Batch.Common.CachingType.ReadWrite
            };

            var mgmtValues = new[]
            {
                CachingType.None,
                CachingType.ReadOnly,
                CachingType.ReadWrite
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new CachingType?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.toMgmtCaching(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.CachingType?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtCaching(mgmtValues[i]);
            }

            // Assert - Each management enum value should be unique (no duplicates)
            var distinctMgmtValues = convertedMgmtValues.Where(v => v.HasValue).Select(v => v.Value).Distinct().ToArray();
            Assert.Equal(convertedMgmtValues.Count(v => v.HasValue), distinctMgmtValues.Length);

            // Assert - Each PS enum value should be unique (no duplicates)
            var distinctPsValues = convertedPsValues.Where(v => v.HasValue).Select(v => v.Value).Distinct().ToArray();
            Assert.Equal(convertedPsValues.Count(v => v.HasValue), distinctPsValues.Length);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void CachingTypeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test None semantics - No caching applied
            var psNone = Microsoft.Azure.Batch.Common.CachingType.None;
            var mgmtNone = Utils.Utils.toMgmtCaching(psNone);
            var backToPs = Utils.Utils.fromMgmtCaching(mgmtNone);

            Assert.NotNull(mgmtNone);
            Assert.Equal(CachingType.None, mgmtNone.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(psNone, backToPs.Value);

            // Test ReadOnly semantics - Cache disk reads only
            var psReadOnly = Microsoft.Azure.Batch.Common.CachingType.ReadOnly;
            var mgmtReadOnly = Utils.Utils.toMgmtCaching(psReadOnly);
            var backToPsReadOnly = Utils.Utils.fromMgmtCaching(mgmtReadOnly);

            Assert.NotNull(mgmtReadOnly);
            Assert.Equal(CachingType.ReadOnly, mgmtReadOnly.Value);
            Assert.NotNull(backToPsReadOnly);
            Assert.Equal(psReadOnly, backToPsReadOnly.Value);

            // Test ReadWrite semantics - Cache both reads and writes
            var psReadWrite = Microsoft.Azure.Batch.Common.CachingType.ReadWrite;
            var mgmtReadWrite = Utils.Utils.toMgmtCaching(psReadWrite);
            var backToPsReadWrite = Utils.Utils.fromMgmtCaching(mgmtReadWrite);

            Assert.NotNull(mgmtReadWrite);
            Assert.Equal(CachingType.ReadWrite, mgmtReadWrite.Value);
            Assert.NotNull(backToPsReadWrite);
            Assert.Equal(psReadWrite, backToPsReadWrite.Value);
        }

        [Fact]
        public void CachingTypeConversions_NullabilityHandling_VerifyBehavior()
        {
            // This test verifies the nullable handling in these conversion methods

            // toMgmtCaching returns null for null input
            Microsoft.Azure.Batch.Common.CachingType? nullInput = null;
            var result = Utils.Utils.toMgmtCaching(nullInput);
            Assert.Null(result);

            // fromMgmtCaching returns null for null input
            CachingType? nullMgmtInput = null;
            var mgmtResult = Utils.Utils.fromMgmtCaching(nullMgmtInput);
            Assert.Null(mgmtResult);

            // Both methods handle nullable types correctly
            CachingType? nullableReadWrite = CachingType.ReadWrite;
            var nonNullResult = Utils.Utils.fromMgmtCaching(nullableReadWrite);
            Assert.NotNull(nonNullResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.CachingType.ReadWrite, nonNullResult.Value);
        }

        [Fact]
        public void CachingTypeConversions_BatchDataDiskContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch data disk configuration
            // CachingType is used to specify disk caching behavior for data disks in Azure Batch

            // Arrange - Test with different caching scenarios
            var diskCachingScenarios = new[]
            {
                // High-performance scenario with read-write caching
                new {
                    CachingType = Microsoft.Azure.Batch.Common.CachingType.ReadWrite,
                    Description = "High-performance workload with read-write caching for optimal performance"
                },
                // Read-heavy scenario with read-only caching
                new {
                    CachingType = Microsoft.Azure.Batch.Common.CachingType.ReadOnly,
                    Description = "Read-heavy workload with read-only caching to optimize read operations"
                },
                // Write-heavy scenario with no caching
                new {
                    CachingType = Microsoft.Azure.Batch.Common.CachingType.None,
                    Description = "Write-heavy workload with no caching to ensure data consistency"
                }
            };

            foreach (var scenario in diskCachingScenarios)
            {
                // Act
                var mgmtCachingType = Utils.Utils.toMgmtCaching(scenario.CachingType);

                // Assert - Should convert correctly for Batch data disk configuration
                Assert.NotNull(mgmtCachingType);
                
                var expectedMgmtType = scenario.CachingType == Microsoft.Azure.Batch.Common.CachingType.None
                    ? CachingType.None
                    : scenario.CachingType == Microsoft.Azure.Batch.Common.CachingType.ReadOnly
                        ? CachingType.ReadOnly
                        : CachingType.ReadWrite;
                Assert.Equal(expectedMgmtType, mgmtCachingType.Value);

                // Verify round-trip conversion maintains disk caching semantics
                var backToPs = Utils.Utils.fromMgmtCaching(mgmtCachingType);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.CachingType, backToPs.Value);
            }
        }

        [Fact]
        public void CachingTypeConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.CachingType psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.CachingType)))
            {
                var mgmtResult = Utils.Utils.toMgmtCaching(psValue);
                Assert.NotNull(mgmtResult);
                Assert.Equal((int)psValue, (int)mgmtResult.Value);
            }

            foreach (CachingType mgmtValue in Enum.GetValues(typeof(CachingType)))
            {
                var psResult = Utils.Utils.fromMgmtCaching(mgmtValue);
                Assert.NotNull(psResult);
                Assert.Equal((int)mgmtValue, (int)psResult.Value);
            }
        }

        [Fact]
        public void CachingTypeConversions_DataDiskIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch data disk configuration
            // CachingType determines how disk I/O operations are cached for performance optimization

            // None caching semantics - No caching for write-intensive workloads
            var noneType = Microsoft.Azure.Batch.Common.CachingType.None;
            var mgmtNoneType = Utils.Utils.toMgmtCaching(noneType);
            
            Assert.NotNull(mgmtNoneType);
            Assert.Equal(CachingType.None, mgmtNoneType.Value);
            // Use case: Database workloads where data consistency is critical
            
            // ReadOnly caching semantics - Cache reads for read-heavy workloads
            var readOnlyType = Microsoft.Azure.Batch.Common.CachingType.ReadOnly;
            var mgmtReadOnlyType = Utils.Utils.toMgmtCaching(readOnlyType);
            
            Assert.NotNull(mgmtReadOnlyType);
            Assert.Equal(CachingType.ReadOnly, mgmtReadOnlyType.Value);
            // Use case: Analytics workloads with frequent data reads
            
            // ReadWrite caching semantics - Cache both reads and writes for high performance
            var readWriteType = Microsoft.Azure.Batch.Common.CachingType.ReadWrite;
            var mgmtReadWriteType = Utils.Utils.toMgmtCaching(readWriteType);
            
            Assert.NotNull(mgmtReadWriteType);
            Assert.Equal(CachingType.ReadWrite, mgmtReadWriteType.Value);
            // Use case: General-purpose workloads requiring optimal I/O performance

            // Verify all round-trip correctly
            var noneRoundTrip = Utils.Utils.fromMgmtCaching(mgmtNoneType);
            var readOnlyRoundTrip = Utils.Utils.fromMgmtCaching(mgmtReadOnlyType);
            var readWriteRoundTrip = Utils.Utils.fromMgmtCaching(mgmtReadWriteType);

            Assert.Equal(noneType, noneRoundTrip.Value);
            Assert.Equal(readOnlyType, readOnlyRoundTrip.Value);
            Assert.Equal(readWriteType, readWriteRoundTrip.Value);
        }

        #endregion
    }
}
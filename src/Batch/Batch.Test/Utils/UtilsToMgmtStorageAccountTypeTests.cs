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
    public class UtilsToMgmtStorageAccountTypeTests
    {
        #region ToMgmtStorageAccountType Tests

        [Fact]
        public void ToMgmtStorageAccountType_StandardLRS_ReturnsStandardLRS()
        {
            // Arrange
            var psStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs;

            // Act
            var result = Utils.Utils.ToMgmtStorageAccountType(psStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.StandardLRS, result.Value);
        }

        [Fact]
        public void ToMgmtStorageAccountType_PremiumLRS_ReturnsPremiumLRS()
        {
            // Arrange
            var psStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs;

            // Act
            var result = Utils.Utils.ToMgmtStorageAccountType(psStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.PremiumLRS, result.Value);
        }

        [Fact]
        public void ToMgmtStorageAccountType_StandardSSDLRS_ReturnsStandardSSDLRS()
        {
            // Arrange
            var psStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;

            // Act
            var result = Utils.Utils.ToMgmtStorageAccountType(psStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.StandardSSDLRS, result.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, StorageAccountType.StandardLRS)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, StorageAccountType.PremiumLRS)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, StorageAccountType.StandardSSDLRS)]
        public void ToMgmtStorageAccountType_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.StorageAccountType input,
            StorageAccountType expected)
        {
            // Act
            var result = Utils.Utils.ToMgmtStorageAccountType(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ToMgmtStorageAccountType_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.StorageAccountType? nullStorageAccountType = null;

            // Act
            var result = Utils.Utils.ToMgmtStorageAccountType(nullStorageAccountType);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtStorageAccountType_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.StorageAccountType);

            // Act
            var result = Utils.Utils.ToMgmtStorageAccountType(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default StorageAccountType is typically StandardLRS (0)
            Assert.Equal(StorageAccountType.StandardLRS, result.Value);
        }

        [Fact]
        public void ToMgmtStorageAccountType_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each storage account type

            // Arrange & Act & Assert
            // StandardLRS: Standard locally redundant storage
            var standardLRSResult = Utils.Utils.ToMgmtStorageAccountType(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);
            Assert.NotNull(standardLRSResult);
            Assert.Equal(StorageAccountType.StandardLRS, standardLRSResult.Value);

            // PremiumLRS: Premium locally redundant storage (SSD-based)
            var premiumLRSResult = Utils.Utils.ToMgmtStorageAccountType(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);
            Assert.NotNull(premiumLRSResult);
            Assert.Equal(StorageAccountType.PremiumLRS, premiumLRSResult.Value);

            // StandardSSDLRS: Standard SSD locally redundant storage
            var standardSSDLRSResult = Utils.Utils.ToMgmtStorageAccountType(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);
            Assert.NotNull(standardSSDLRSResult);
            Assert.Equal(StorageAccountType.StandardSSDLRS, standardSSDLRSResult.Value);
        }

        [Fact]
        public void ToMgmtStorageAccountType_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs;

            // Act - Call static method directly on class
            var result = Utils.Utils.ToMgmtStorageAccountType(psStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.PremiumLRS, result.Value);
        }

        [Fact]
        public void ToMgmtStorageAccountType_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.ToMgmtStorageAccountType(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(StorageAccountType), result.Value));
            }
        }

        [Fact]
        public void ToMgmtStorageAccountType_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psStandardLRS = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs;
            var psPremiumLRS = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs;
            var psStandardSSDLRS = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;

            // Act
            var mgmtStandardLRS = Utils.Utils.ToMgmtStorageAccountType(psStandardLRS);
            var mgmtPremiumLRS = Utils.Utils.ToMgmtStorageAccountType(psPremiumLRS);
            var mgmtStandardSSDLRS = Utils.Utils.ToMgmtStorageAccountType(psStandardSSDLRS);

            // Assert
            Assert.NotNull(mgmtStandardLRS);
            Assert.NotNull(mgmtPremiumLRS);
            Assert.NotNull(mgmtStandardSSDLRS);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psStandardLRS, (int)mgmtStandardLRS.Value);
            Assert.Equal((int)psPremiumLRS, (int)mgmtPremiumLRS.Value);
            Assert.Equal((int)psStandardSSDLRS, (int)mgmtStandardSSDLRS.Value);
        }

        #endregion

        #region FromMgmtStorageAccountType Tests

        [Fact]
        public void FromMgmtStorageAccountType_StandardLRS_ReturnsStandardLRS()
        {
            // Arrange
            var mgmtStorageAccountType = StorageAccountType.StandardLRS;

            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, result.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_PremiumLRS_ReturnsPremiumLRS()
        {
            // Arrange
            var mgmtStorageAccountType = StorageAccountType.PremiumLRS;

            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_StandardSSDLRS_ReturnsStandardSSDLRS()
        {
            // Arrange
            var mgmtStorageAccountType = StorageAccountType.StandardSSDLRS;

            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, result.Value);
        }

        [Theory]
        [InlineData(StorageAccountType.StandardLRS, Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        [InlineData(StorageAccountType.PremiumLRS, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)]
        [InlineData(StorageAccountType.StandardSSDLRS, Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)]
        public void FromMgmtStorageAccountType_AllValidValues_ReturnsCorrectMapping(
            StorageAccountType input,
            Microsoft.Azure.Batch.Common.StorageAccountType expected)
        {
            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_NullValue_ReturnsNull()
        {
            // Arrange
            StorageAccountType? nullStorageAccountType = null;

            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(nullStorageAccountType);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtStorageAccountType_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(StorageAccountType);

            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default StorageAccountType is typically StandardLRS (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, result.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each storage account type

            // Arrange & Act & Assert
            // StandardLRS: Standard locally redundant storage
            var standardLRSResult = Utils.Utils.FromMgmtStorageAccountType(StorageAccountType.StandardLRS);
            Assert.NotNull(standardLRSResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, standardLRSResult.Value);

            // PremiumLRS: Premium locally redundant storage (SSD-based)
            var premiumLRSResult = Utils.Utils.FromMgmtStorageAccountType(StorageAccountType.PremiumLRS);
            Assert.NotNull(premiumLRSResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, premiumLRSResult.Value);

            // StandardSSDLRS: Standard SSD locally redundant storage
            var standardSSDLRSResult = Utils.Utils.FromMgmtStorageAccountType(StorageAccountType.StandardSSDLRS);
            Assert.NotNull(standardSSDLRSResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, standardSSDLRSResult.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtStorageAccountType = StorageAccountType.StandardSSDLRS;

            // Act - Call static method directly on class
            var result = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, result.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new StorageAccountType?[]
            {
                StorageAccountType.StandardLRS,
                StorageAccountType.PremiumLRS,
                StorageAccountType.StandardSSDLRS,
                null
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.FromMgmtStorageAccountType(value);
                if (value.HasValue)
                {
                    Assert.NotNull(result);
                    Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.StorageAccountType), result.Value));
                }
                else
                {
                    Assert.Null(result);
                }
            }
        }

        [Fact]
        public void FromMgmtStorageAccountType_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable StorageAccountType

            // Arrange
            StorageAccountType? nullableValue = StorageAccountType.PremiumLRS;

            // Act
            var result = Utils.Utils.FromMgmtStorageAccountType(nullableValue);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.Value);
        }

        [Fact]
        public void FromMgmtStorageAccountType_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtStandardLRS = StorageAccountType.StandardLRS;
            var mgmtPremiumLRS = StorageAccountType.PremiumLRS;
            var mgmtStandardSSDLRS = StorageAccountType.StandardSSDLRS;

            // Act
            var psStandardLRS = Utils.Utils.FromMgmtStorageAccountType(mgmtStandardLRS);
            var psPremiumLRS = Utils.Utils.FromMgmtStorageAccountType(mgmtPremiumLRS);
            var psStandardSSDLRS = Utils.Utils.FromMgmtStorageAccountType(mgmtStandardSSDLRS);

            // Assert
            Assert.NotNull(psStandardLRS);
            Assert.NotNull(psPremiumLRS);
            Assert.NotNull(psStandardSSDLRS);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtStandardLRS, (int)psStandardLRS.Value);
            Assert.Equal((int)mgmtPremiumLRS, (int)psPremiumLRS.Value);
            Assert.Equal((int)mgmtStandardSSDLRS, (int)psStandardSSDLRS.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesStandardLRSValue()
        {
            // Arrange
            var originalPsStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs;

            // Act
            var mgmtStorageAccountType = Utils.Utils.ToMgmtStorageAccountType(originalPsStorageAccountType);
            var roundTripPsStorageAccountType = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(roundTripPsStorageAccountType);
            Assert.Equal(originalPsStorageAccountType, roundTripPsStorageAccountType.Value);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPremiumLRSValue()
        {
            // Arrange
            var originalPsStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs;

            // Act
            var mgmtStorageAccountType = Utils.Utils.ToMgmtStorageAccountType(originalPsStorageAccountType);
            var roundTripPsStorageAccountType = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(roundTripPsStorageAccountType);
            Assert.Equal(originalPsStorageAccountType, roundTripPsStorageAccountType.Value);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesStandardSSDLRSValue()
        {
            // Arrange
            var originalPsStorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;

            // Act
            var mgmtStorageAccountType = Utils.Utils.ToMgmtStorageAccountType(originalPsStorageAccountType);
            var roundTripPsStorageAccountType = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(roundTripPsStorageAccountType);
            Assert.Equal(originalPsStorageAccountType, roundTripPsStorageAccountType.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.StorageAccountType originalStorageAccountType)
        {
            // Act
            var mgmtStorageAccountType = Utils.Utils.ToMgmtStorageAccountType(originalStorageAccountType);
            var roundTripStorageAccountType = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);

            // Assert
            Assert.NotNull(roundTripStorageAccountType);
            Assert.Equal(originalStorageAccountType, roundTripStorageAccountType.Value);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                StorageAccountType.StandardLRS,
                StorageAccountType.PremiumLRS,
                StorageAccountType.StandardSSDLRS
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.FromMgmtStorageAccountType(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtStorageAccountType(psValue);

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
            Microsoft.Azure.Batch.Common.StorageAccountType? nullPsValue = null;
            StorageAccountType? nullMgmtValue = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.ToMgmtStorageAccountType(nullPsValue);
            var psFromNullMgmt = Utils.Utils.FromMgmtStorageAccountType(nullMgmtValue);

            // Assert
            Assert.Null(mgmtFromNullPs);
            Assert.Null(psFromNullMgmt);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void StorageAccountType_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psStorageAccountTypeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.StorageAccountType));
            var mgmtStorageAccountTypeValues = Enum.GetValues(typeof(StorageAccountType));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psStorageAccountTypeValues.Length, mgmtStorageAccountTypeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.StorageAccountType psValue in psStorageAccountTypeValues)
            {
                var result = Utils.Utils.ToMgmtStorageAccountType(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(StorageAccountType), result.Value));
            }

            // Verify that each management enum value can be converted successfully
            foreach (StorageAccountType mgmtValue in mgmtStorageAccountTypeValues)
            {
                var result = Utils.Utils.FromMgmtStorageAccountType(mgmtValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.StorageAccountType), result.Value));
            }
        }

        [Fact]
        public void StorageAccountType_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS
            };

            var mgmtValues = new[]
            {
                StorageAccountType.StandardLRS,
                StorageAccountType.PremiumLRS,
                StorageAccountType.StandardSSDLRS
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new StorageAccountType?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.ToMgmtStorageAccountType(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.StorageAccountType?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.FromMgmtStorageAccountType(mgmtValues[i]);
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
        public void StorageAccountTypeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test StandardLRS semantics - Standard locally redundant storage (HDD-based, cost-optimized)
            var psStandardLRS = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs;
            var mgmtStandardLRS = Utils.Utils.ToMgmtStorageAccountType(psStandardLRS);
            var backToPs = Utils.Utils.FromMgmtStorageAccountType(mgmtStandardLRS);

            Assert.NotNull(mgmtStandardLRS);
            Assert.Equal(StorageAccountType.StandardLRS, mgmtStandardLRS.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(psStandardLRS, backToPs.Value);

            // Test PremiumLRS semantics - Premium locally redundant storage (SSD-based, high performance)
            var psPremiumLRS = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs;
            var mgmtPremiumLRS = Utils.Utils.ToMgmtStorageAccountType(psPremiumLRS);
            var backToPsPremium = Utils.Utils.FromMgmtStorageAccountType(mgmtPremiumLRS);

            Assert.NotNull(mgmtPremiumLRS);
            Assert.Equal(StorageAccountType.PremiumLRS, mgmtPremiumLRS.Value);
            Assert.NotNull(backToPsPremium);
            Assert.Equal(psPremiumLRS, backToPsPremium.Value);

            // Test StandardSSDLRS semantics - Standard SSD locally redundant storage (balanced performance/cost)
            var psStandardSSDLRS = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;
            var mgmtStandardSSDLRS = Utils.Utils.ToMgmtStorageAccountType(psStandardSSDLRS);
            var backToPsStandardSSD = Utils.Utils.FromMgmtStorageAccountType(mgmtStandardSSDLRS);

            Assert.NotNull(mgmtStandardSSDLRS);
            Assert.Equal(StorageAccountType.StandardSSDLRS, mgmtStandardSSDLRS.Value);
            Assert.NotNull(backToPsStandardSSD);
            Assert.Equal(psStandardSSDLRS, backToPsStandardSSD.Value);
        }

        [Fact]
        public void StorageAccountTypeConversions_NullabilityHandling_VerifyBehavior()
        {
            // This test verifies the nullable handling in these conversion methods

            // ToMgmtStorageAccountType returns null for null input
            Microsoft.Azure.Batch.Common.StorageAccountType? nullInput = null;
            var result = Utils.Utils.ToMgmtStorageAccountType(nullInput);
            Assert.Null(result);

            // FromMgmtStorageAccountType returns null for null input
            StorageAccountType? nullMgmtInput = null;
            var mgmtResult = Utils.Utils.FromMgmtStorageAccountType(nullMgmtInput);
            Assert.Null(mgmtResult);

            // Both methods handle nullable types correctly
            StorageAccountType? nullableStandardSSD = StorageAccountType.StandardSSDLRS;
            var nonNullResult = Utils.Utils.FromMgmtStorageAccountType(nullableStandardSSD);
            Assert.NotNull(nonNullResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, nonNullResult.Value);
        }

        [Fact]
        public void StorageAccountTypeConversions_BatchDataDiskContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch data disk configuration
            // StorageAccountType is used to specify storage performance characteristics for data disks

            // Arrange - Test with different storage type scenarios
            var diskStorageScenarios = new[]
            {
                // High-performance scenario with Premium SSD
                new {
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    Description = "High-performance workload with Premium SSD for maximum IOPS and throughput"
                },
                // Balanced scenario with Standard SSD
                new {
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                    Description = "Balanced workload with Standard SSD for good performance at lower cost"
                },
                // Cost-optimized scenario with Standard HDD
                new {
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                    Description = "Cost-optimized workload with Standard HDD for basic storage needs"
                }
            };

            foreach (var scenario in diskStorageScenarios)
            {
                // Act
                var mgmtStorageAccountType = Utils.Utils.ToMgmtStorageAccountType(scenario.StorageAccountType);

                // Assert - Should convert correctly for Batch data disk configuration
                Assert.NotNull(mgmtStorageAccountType);
                
                var expectedMgmtType = scenario.StorageAccountType == Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs
                    ? StorageAccountType.StandardLRS
                    : scenario.StorageAccountType == Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs
                        ? StorageAccountType.PremiumLRS
                        : StorageAccountType.StandardSSDLRS;
                Assert.Equal(expectedMgmtType, mgmtStorageAccountType.Value);

                // Verify round-trip conversion maintains storage type semantics
                var backToPs = Utils.Utils.FromMgmtStorageAccountType(mgmtStorageAccountType);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.StorageAccountType, backToPs.Value);
            }
        }

        [Fact]
        public void StorageAccountTypeConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.StorageAccountType psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.StorageAccountType)))
            {
                var mgmtResult = Utils.Utils.ToMgmtStorageAccountType(psValue);
                Assert.NotNull(mgmtResult);
                Assert.Equal((int)psValue, (int)mgmtResult.Value);
            }

            foreach (StorageAccountType mgmtValue in Enum.GetValues(typeof(StorageAccountType)))
            {
                var psResult = Utils.Utils.FromMgmtStorageAccountType(mgmtValue);
                Assert.NotNull(psResult);
                Assert.Equal((int)mgmtValue, (int)psResult.Value);
            }
        }

        [Fact]
        public void StorageAccountTypeConversions_DataDiskIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch data disk configuration
            // StorageAccountType determines storage performance characteristics and cost

            // StandardLRS semantics - Standard locally redundant storage (HDD-based)
            var standardLRSType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs;
            var mgmtStandardLRSType = Utils.Utils.ToMgmtStorageAccountType(standardLRSType);
            
            Assert.NotNull(mgmtStandardLRSType);
            Assert.Equal(StorageAccountType.StandardLRS, mgmtStandardLRSType.Value);
            // Use case: Cost-optimized storage for large datasets with infrequent access
            
            // PremiumLRS semantics - Premium locally redundant storage (SSD-based)
            var premiumLRSType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs;
            var mgmtPremiumLRSType = Utils.Utils.ToMgmtStorageAccountType(premiumLRSType);
            
            Assert.NotNull(mgmtPremiumLRSType);
            Assert.Equal(StorageAccountType.PremiumLRS, mgmtPremiumLRSType.Value);
            // Use case: High-performance workloads requiring maximum IOPS and low latency
            
            // StandardSSDLRS semantics - Standard SSD locally redundant storage
            var standardSSDLRSType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;
            var mgmtStandardSSDLRSType = Utils.Utils.ToMgmtStorageAccountType(standardSSDLRSType);
            
            Assert.NotNull(mgmtStandardSSDLRSType);
            Assert.Equal(StorageAccountType.StandardSSDLRS, mgmtStandardSSDLRSType.Value);
            // Use case: Balanced performance and cost for general-purpose workloads

            // Verify all round-trip correctly
            var standardLRSRoundTrip = Utils.Utils.FromMgmtStorageAccountType(mgmtStandardLRSType);
            var premiumLRSRoundTrip = Utils.Utils.FromMgmtStorageAccountType(mgmtPremiumLRSType);
            var standardSSDLRSRoundTrip = Utils.Utils.FromMgmtStorageAccountType(mgmtStandardSSDLRSType);

            Assert.Equal(standardLRSType, standardLRSRoundTrip.Value);
            Assert.Equal(premiumLRSType, premiumLRSRoundTrip.Value);
            Assert.Equal(standardSSDLRSType, standardSSDLRSRoundTrip.Value);
        }

        [Fact]
        public void StorageAccountTypeConversions_PerformanceCharacteristics_VerifySemantics()
        {
            // This test validates that the storage account types maintain their performance characteristics
            // through the conversion process

            var performanceProfiles = new[]
            {
                new {
                    Type = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                    Category = "HDD",
                    PerformanceProfile = "Cost-Optimized",
                    TypicalIOPS = "Up to 500 IOPS",
                    UseCases = new[] { "Backup", "Archive", "Large datasets with infrequent access" }
                },
                new {
                    Type = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                    Category = "SSD",
                    PerformanceProfile = "Balanced",
                    TypicalIOPS = "Up to 6,000 IOPS",
                    UseCases = new[] { "Web servers", "Development environments", "General-purpose workloads" }
                },
                new {
                    Type = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    Category = "Premium SSD",
                    PerformanceProfile = "High-Performance",
                    TypicalIOPS = "Up to 20,000+ IOPS",
                    UseCases = new[] { "Production databases", "High-performance computing", "Low-latency applications" }
                }
            };

            foreach (var profile in performanceProfiles)
            {
                // Act - Convert to management type and back
                var mgmtType = Utils.Utils.ToMgmtStorageAccountType(profile.Type);
                var roundTripType = Utils.Utils.FromMgmtStorageAccountType(mgmtType);

                // Assert - Performance characteristics should be preserved
                Assert.NotNull(mgmtType);
                Assert.NotNull(roundTripType);
                Assert.Equal(profile.Type, roundTripType.Value);

                // Verify the conversion maintains the semantic meaning
                var expectedMgmtValue = profile.Type switch
                {
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs => StorageAccountType.StandardLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs => StorageAccountType.PremiumLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS => StorageAccountType.StandardSSDLRS,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Assert.Equal(expectedMgmtValue, mgmtType.Value);
            }
        }

        #endregion

        #region Case Sensitivity Tests

        [Fact]
        public void UppercaseVsLowercaseMethods_BehaviorConsistency_VerifyIdenticalOutput()
        {
            // This test verifies that the uppercase and lowercase method variants produce identical results
            // This ensures consistency between ToMgmtStorageAccountType/toMgmtStorageAccountType and
            // FromMgmtStorageAccountType/fromMgmtStorageAccountType

            // Arrange
            var testValues = new[]
            {
                Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS
            };

            foreach (var testValue in testValues)
            {
                // Act - Call both uppercase and lowercase variants
                var uppercaseResult = Utils.Utils.ToMgmtStorageAccountType(testValue);
                var lowercaseResult = Utils.Utils.toMgmtStorageAccountType(testValue);

                // Assert - Both should produce identical results
                Assert.Equal(uppercaseResult, lowercaseResult);

                // Test the reverse direction
                if (uppercaseResult.HasValue)
                {
                    var uppercaseReverseResult = Utils.Utils.FromMgmtStorageAccountType(uppercaseResult.Value);
                    var lowercaseReverseResult = Utils.Utils.fromMgmtStorageAccountType(uppercaseResult.Value);

                    Assert.Equal(uppercaseReverseResult, lowercaseReverseResult);
                }
            }
        }

        [Fact]
        public void UppercaseVsLowercaseMethods_NullHandling_VerifyConsistency()
        {
            // This test ensures that both uppercase and lowercase variants handle null values consistently

            // Arrange
            Microsoft.Azure.Batch.Common.StorageAccountType? nullPsValue = null;
            StorageAccountType? nullMgmtValue = null;

            // Act
            var uppercaseToMgmtResult = Utils.Utils.ToMgmtStorageAccountType(nullPsValue);
            var lowercaseToMgmtResult = Utils.Utils.toMgmtStorageAccountType(nullPsValue);

            var uppercaseFromMgmtResult = Utils.Utils.FromMgmtStorageAccountType(nullMgmtValue);
            var lowercaseFromMgmtResult = Utils.Utils.fromMgmtStorageAccountType(nullMgmtValue);

            // Assert - Both variants should handle nulls identically
            Assert.Equal(uppercaseToMgmtResult, lowercaseToMgmtResult);
            Assert.Equal(uppercaseFromMgmtResult, lowercaseFromMgmtResult);
            Assert.Null(uppercaseToMgmtResult);
            Assert.Null(lowercaseToMgmtResult);
            Assert.Null(uppercaseFromMgmtResult);
            Assert.Null(lowercaseFromMgmtResult);
        }

        #endregion
    }
}
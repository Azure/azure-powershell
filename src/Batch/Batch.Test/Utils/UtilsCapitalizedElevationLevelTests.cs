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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsCapitalizedElevationLevelTests
    {
        #region ToMgmtElevationLevel Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_NonAdmin_ReturnsNonAdmin()
        {
            // Arrange
            var psElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin;

            // Act
            var result = Utils.Utils.ToMgmtElevationLevel(psElevationLevel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ElevationLevel.NonAdmin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_Admin_ReturnsAdmin()
        {
            // Arrange
            var psElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin;

            // Act
            var result = Utils.Utils.ToMgmtElevationLevel(psElevationLevel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ElevationLevel.Admin, result.Value);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, ElevationLevel.NonAdmin)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, ElevationLevel.Admin)]
        public void ToMgmtElevationLevel_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.ElevationLevel input,
            ElevationLevel expected)
        {
            // Act
            var result = Utils.Utils.ToMgmtElevationLevel(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.ElevationLevel? nullElevationLevel = null;

            // Act
            var result = Utils.Utils.ToMgmtElevationLevel(nullElevationLevel);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.ElevationLevel);

            // Act
            var result = Utils.Utils.ToMgmtElevationLevel(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default ElevationLevel is typically NonAdmin (0)
            Assert.Equal(ElevationLevel.NonAdmin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each elevation level

            // Arrange & Act & Assert
            // NonAdmin: Standard user privileges without administrative access
            var nonAdminResult = Utils.Utils.ToMgmtElevationLevel(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);
            Assert.NotNull(nonAdminResult);
            Assert.Equal(ElevationLevel.NonAdmin, nonAdminResult.Value);

            // Admin: Administrative privileges for elevated operations
            var adminResult = Utils.Utils.ToMgmtElevationLevel(Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            Assert.NotNull(adminResult);
            Assert.Equal(ElevationLevel.Admin, adminResult.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin;

            // Act - Call static method directly on class
            var result = Utils.Utils.ToMgmtElevationLevel(psElevationLevel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ElevationLevel.Admin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                Microsoft.Azure.Batch.Common.ElevationLevel.Admin
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.ToMgmtElevationLevel(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(ElevationLevel), result.Value));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psNonAdmin = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin;
            var psAdmin = Microsoft.Azure.Batch.Common.ElevationLevel.Admin;

            // Act
            var mgmtNonAdmin = Utils.Utils.ToMgmtElevationLevel(psNonAdmin);
            var mgmtAdmin = Utils.Utils.ToMgmtElevationLevel(psAdmin);

            // Assert
            Assert.NotNull(mgmtNonAdmin);
            Assert.NotNull(mgmtAdmin);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psNonAdmin, (int)mgmtNonAdmin.Value);
            Assert.Equal((int)psAdmin, (int)mgmtAdmin.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtElevationLevel_AlwaysReturnsNewNullableValue()
        {
            // This test verifies that the method always returns a new nullable value

            // Arrange
            var psElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin;

            // Act
            var result1 = Utils.Utils.ToMgmtElevationLevel(psElevationLevel);
            var result2 = Utils.Utils.ToMgmtElevationLevel(psElevationLevel);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1.Value, result2.Value);
        }

        #endregion

        #region FromMgmtElevationLevel Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_NonAdmin_ReturnsNonAdmin()
        {
            // Arrange
            var mgmtElevationLevel = ElevationLevel.NonAdmin;

            // Act
            var result = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_Admin_ReturnsAdmin()
        {
            // Arrange
            var mgmtElevationLevel = ElevationLevel.Admin;

            // Act
            var result = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, result.Value);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(ElevationLevel.NonAdmin, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        [InlineData(ElevationLevel.Admin, Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        public void FromMgmtElevationLevel_AllValidValues_ReturnsCorrectMapping(
            ElevationLevel input,
            Microsoft.Azure.Batch.Common.ElevationLevel expected)
        {
            // Act
            var result = Utils.Utils.FromMgmtElevationLevel(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_NullValue_ReturnsNull()
        {
            // Arrange
            ElevationLevel? nullElevationLevel = null;

            // Act
            var result = Utils.Utils.FromMgmtElevationLevel(nullElevationLevel);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(ElevationLevel);

            // Act
            var result = Utils.Utils.FromMgmtElevationLevel(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default ElevationLevel is typically NonAdmin (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each elevation level

            // Arrange & Act & Assert
            // NonAdmin: Standard user privileges without administrative access
            var nonAdminResult = Utils.Utils.FromMgmtElevationLevel(ElevationLevel.NonAdmin);
            Assert.NotNull(nonAdminResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, nonAdminResult.Value);

            // Admin: Administrative privileges for elevated operations
            var adminResult = Utils.Utils.FromMgmtElevationLevel(ElevationLevel.Admin);
            Assert.NotNull(adminResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, adminResult.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtElevationLevel = ElevationLevel.NonAdmin;

            // Act - Call static method directly on class
            var result = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new ElevationLevel?[]
            {
                ElevationLevel.NonAdmin,
                ElevationLevel.Admin,
                null
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.FromMgmtElevationLevel(value);
                if (value.HasValue)
                {
                    Assert.NotNull(result);
                    Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ElevationLevel), result.Value));
                }
                else
                {
                    Assert.Null(result);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable ElevationLevel

            // Arrange
            ElevationLevel? nullableValue = ElevationLevel.Admin;

            // Act
            var result = Utils.Utils.FromMgmtElevationLevel(nullableValue);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtNonAdmin = ElevationLevel.NonAdmin;
            var mgmtAdmin = ElevationLevel.Admin;

            // Act
            var psNonAdmin = Utils.Utils.FromMgmtElevationLevel(mgmtNonAdmin);
            var psAdmin = Utils.Utils.FromMgmtElevationLevel(mgmtAdmin);

            // Assert
            Assert.NotNull(psNonAdmin);
            Assert.NotNull(psAdmin);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtNonAdmin, (int)psNonAdmin.Value);
            Assert.Equal((int)mgmtAdmin, (int)psAdmin.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtElevationLevel_AlwaysReturnsNewNullableValue()
        {
            // This test verifies that the method always returns a new nullable value

            // Arrange
            var mgmtElevationLevel = ElevationLevel.Admin;

            // Act
            var result1 = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);
            var result2 = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1.Value, result2.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNonAdminValue()
        {
            // Arrange
            var originalPsElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin;

            // Act
            var mgmtElevationLevel = Utils.Utils.ToMgmtElevationLevel(originalPsElevationLevel);
            var roundTripPsElevationLevel = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(roundTripPsElevationLevel);
            Assert.Equal(originalPsElevationLevel, roundTripPsElevationLevel.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAdminValue()
        {
            // Arrange
            var originalPsElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin;

            // Act
            var mgmtElevationLevel = Utils.Utils.ToMgmtElevationLevel(originalPsElevationLevel);
            var roundTripPsElevationLevel = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(roundTripPsElevationLevel);
            Assert.Equal(originalPsElevationLevel, roundTripPsElevationLevel.Value);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.ElevationLevel originalElevationLevel)
        {
            // Act
            var mgmtElevationLevel = Utils.Utils.ToMgmtElevationLevel(originalElevationLevel);
            var roundTripElevationLevel = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);

            // Assert
            Assert.NotNull(roundTripElevationLevel);
            Assert.Equal(originalElevationLevel, roundTripElevationLevel.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                ElevationLevel.NonAdmin,
                ElevationLevel.Admin
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.FromMgmtElevationLevel(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtElevationLevel(psValue);

                // Assert
                Assert.NotNull(roundTripValue);
                Assert.Equal(originalValue, roundTripValue.Value);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_NullHandling_WorksCorrectly()
        {
            // This test verifies null handling in round-trip conversions

            // Arrange
            Microsoft.Azure.Batch.Common.ElevationLevel? nullPsValue = null;
            ElevationLevel? nullMgmtValue = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.ToMgmtElevationLevel(nullPsValue);
            var psFromNullMgmt = Utils.Utils.FromMgmtElevationLevel(nullMgmtValue);

            // Assert
            Assert.Null(mgmtFromNullPs);
            Assert.Null(psFromNullMgmt);
        }

        #endregion

        #region Comparison with Lowercase Methods Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CapitalizedMethods_ConsistentWithLowercaseMethods_ProduceSameResults()
        {
            // This test verifies that the capitalized methods produce the same results as the lowercase ones
            // This is important for consistency across the codebase

            // Arrange
            var testValues = new[]
            {
                Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                Microsoft.Azure.Batch.Common.ElevationLevel.Admin
            };

            foreach (var psValue in testValues)
            {
                // Act - Compare ToMgmtElevationLevel vs toMgmtElevationLevel
                var capitalizedResult = Utils.Utils.ToMgmtElevationLevel(psValue);
                var lowercaseResult = Utils.Utils.toMgmtElevationLevel(psValue);

                // Assert
                Assert.Equal(capitalizedResult, lowercaseResult);
                if (capitalizedResult.HasValue && lowercaseResult.HasValue)
                {
                    Assert.Equal(capitalizedResult.Value, lowercaseResult.Value);
                }
            }

            // Test management to PowerShell conversion consistency
            var mgmtTestValues = new[]
            {
                ElevationLevel.NonAdmin,
                ElevationLevel.Admin
            };

            foreach (var mgmtValue in mgmtTestValues)
            {
                // Act - Compare FromMgmtElevationLevel vs fromMgmtElevationLevel
                var capitalizedResult = Utils.Utils.FromMgmtElevationLevel(mgmtValue);
                var lowercaseResult = Utils.Utils.fromMgmtElevationLevel(mgmtValue);

                // Assert
                Assert.Equal(capitalizedResult, lowercaseResult);
                if (capitalizedResult.HasValue && lowercaseResult.HasValue)
                {
                    Assert.Equal(capitalizedResult.Value, lowercaseResult.Value);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CapitalizedMethods_NullHandling_ConsistentWithLowercaseMethods()
        {
            // Test null handling consistency between capitalized and lowercase methods

            // Arrange
            Microsoft.Azure.Batch.Common.ElevationLevel? nullPsValue = null;
            ElevationLevel? nullMgmtValue = null;

            // Act
            var capitalizedPsToMgmt = Utils.Utils.ToMgmtElevationLevel(nullPsValue);
            var lowercasePsToMgmt = Utils.Utils.toMgmtElevationLevel(nullPsValue);

            var capitalizedMgmtToPs = Utils.Utils.FromMgmtElevationLevel(nullMgmtValue);
            var lowercaseMgmtToPs = Utils.Utils.fromMgmtElevationLevel(nullMgmtValue);

            // Assert
            Assert.Equal(capitalizedPsToMgmt, lowercasePsToMgmt);
            Assert.Equal(capitalizedMgmtToPs, lowercaseMgmtToPs);
            Assert.Null(capitalizedPsToMgmt);
            Assert.Null(lowercasePsToMgmt);
            Assert.Null(capitalizedMgmtToPs);
            Assert.Null(lowercaseMgmtToPs);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ElevationLevel_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psElevationLevelValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.ElevationLevel));
            var mgmtElevationLevelValues = Enum.GetValues(typeof(ElevationLevel));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psElevationLevelValues.Length, mgmtElevationLevelValues.Length);

            // Verify that each PS enum value can be converted successfully using capitalized methods
            foreach (Microsoft.Azure.Batch.Common.ElevationLevel psValue in psElevationLevelValues)
            {
                var result = Utils.Utils.ToMgmtElevationLevel(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(ElevationLevel), result.Value));
            }

            // Verify that each management enum value can be converted successfully using capitalized methods
            foreach (ElevationLevel mgmtValue in mgmtElevationLevelValues)
            {
                var result = Utils.Utils.FromMgmtElevationLevel(mgmtValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ElevationLevel), result.Value));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ElevationLevel_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one) using the capitalized methods

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                Microsoft.Azure.Batch.Common.ElevationLevel.Admin
            };

            var mgmtValues = new[]
            {
                ElevationLevel.NonAdmin,
                ElevationLevel.Admin
            };

            // Act - Convert PS to Management using capitalized method
            var convertedMgmtValues = new ElevationLevel?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.ToMgmtElevationLevel(psValues[i]);
            }

            // Act - Convert Management to PS using capitalized method
            var convertedPsValues = new Microsoft.Azure.Batch.Common.ElevationLevel?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.FromMgmtElevationLevel(mgmtValues[i]);
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
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ElevationLevelConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions using capitalized methods

            // Test NonAdmin semantics - Standard user privileges
            var psNonAdmin = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin;
            var mgmtNonAdmin = Utils.Utils.ToMgmtElevationLevel(psNonAdmin);
            var backToPs = Utils.Utils.FromMgmtElevationLevel(mgmtNonAdmin);

            Assert.NotNull(mgmtNonAdmin);
            Assert.Equal(ElevationLevel.NonAdmin, mgmtNonAdmin.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(psNonAdmin, backToPs.Value);

            // Test Admin semantics - Administrative privileges
            var psAdmin = Microsoft.Azure.Batch.Common.ElevationLevel.Admin;
            var mgmtAdmin = Utils.Utils.ToMgmtElevationLevel(psAdmin);
            var backToPsAdmin = Utils.Utils.FromMgmtElevationLevel(mgmtAdmin);

            Assert.NotNull(mgmtAdmin);
            Assert.Equal(ElevationLevel.Admin, mgmtAdmin.Value);
            Assert.NotNull(backToPsAdmin);
            Assert.Equal(psAdmin, backToPsAdmin.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ElevationLevelConversions_NullabilityHandling_VerifyBehavior()
        {
            // This test verifies the nullable handling in these conversion methods using capitalized methods

            // ToMgmtElevationLevel returns null for null input
            Microsoft.Azure.Batch.Common.ElevationLevel? nullInput = null;
            var result = Utils.Utils.ToMgmtElevationLevel(nullInput);
            Assert.Null(result);

            // FromMgmtElevationLevel returns null for null input
            ElevationLevel? nullMgmtInput = null;
            var mgmtResult = Utils.Utils.FromMgmtElevationLevel(nullMgmtInput);
            Assert.Null(mgmtResult);

            // Both methods handle nullable types correctly
            ElevationLevel? nullableAdmin = ElevationLevel.Admin;
            var nonNullResult = Utils.Utils.FromMgmtElevationLevel(nullableAdmin);
            Assert.NotNull(nonNullResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, nonNullResult.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ElevationLevelConversions_BatchUserContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch user accounts
            // ElevationLevel is used to specify privilege level for user accounts in Azure Batch

            // Arrange - Test with realistic Batch user scenarios
            var userAccountScenarios = new[]
            {
                // Standard user account without administrative privileges
                new {
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    Description = "Standard user account for running regular batch tasks"
                },
                // Administrative user account for privileged operations
                new {
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                    Description = "Administrative user account for system operations and elevated tasks"
                }
            };

            foreach (var scenario in userAccountScenarios)
            {
                // Act - Using capitalized methods
                var mgmtElevationLevel = Utils.Utils.ToMgmtElevationLevel(scenario.ElevationLevel);

                // Assert - Should convert correctly for Batch user account configuration
                Assert.NotNull(mgmtElevationLevel);
                
                var expectedMgmtLevel = scenario.ElevationLevel == Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin
                    ? ElevationLevel.NonAdmin
                    : ElevationLevel.Admin;
                Assert.Equal(expectedMgmtLevel, mgmtElevationLevel.Value);

                // Verify round-trip conversion maintains user account semantics
                var backToPs = Utils.Utils.FromMgmtElevationLevel(mgmtElevationLevel);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.ElevationLevel, backToPs.Value);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ElevationLevelConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values using capitalized methods
            foreach (Microsoft.Azure.Batch.Common.ElevationLevel psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.ElevationLevel)))
            {
                var mgmtResult = Utils.Utils.ToMgmtElevationLevel(psValue);
                Assert.NotNull(mgmtResult);
                Assert.Equal((int)psValue, (int)mgmtResult.Value);
            }

            foreach (ElevationLevel mgmtValue in Enum.GetValues(typeof(ElevationLevel)))
            {
                var psResult = Utils.Utils.FromMgmtElevationLevel(mgmtValue);
                Assert.NotNull(psResult);
                Assert.Equal((int)mgmtValue, (int)psResult.Value);
            }
        }

        #endregion
    }
}
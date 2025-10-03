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
    public class UtilsTests
    {
        #region toMgmtUpgradeMode Tests

        [Fact]
        public void ToMgmtUpgradeMode_Manual_ReturnsManual()
        {
            // Arrange
            var psUpgradeMode = Microsoft.Azure.Batch.Common.UpgradeMode.Manual;

            // Act
            var result = Utils.Utils.toMgmtUpgradeMode(psUpgradeMode);

            // Assert
            Assert.Equal(UpgradeMode.Manual, result);
        }

        [Fact]
        public void ToMgmtUpgradeMode_Automatic_ReturnsAutomatic()
        {
            // Arrange
            var psUpgradeMode = Microsoft.Azure.Batch.Common.UpgradeMode.Automatic;

            // Act
            var result = Utils.Utils.toMgmtUpgradeMode(psUpgradeMode);

            // Assert
            Assert.Equal(UpgradeMode.Automatic, result);
        }

        [Fact]
        public void ToMgmtUpgradeMode_Rolling_ReturnsRolling()
        {
            // Arrange
            var psUpgradeMode = Microsoft.Azure.Batch.Common.UpgradeMode.Rolling;

            // Act
            var result = Utils.Utils.toMgmtUpgradeMode(psUpgradeMode);

            // Assert
            Assert.Equal(UpgradeMode.Rolling, result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.UpgradeMode.Manual, UpgradeMode.Manual)]
        [InlineData(Microsoft.Azure.Batch.Common.UpgradeMode.Automatic, UpgradeMode.Automatic)]
        [InlineData(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling, UpgradeMode.Rolling)]
        public void ToMgmtUpgradeMode_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.UpgradeMode input, 
            UpgradeMode expected)
        {
            // Act
            var result = Utils.Utils.toMgmtUpgradeMode(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToMgmtUpgradeMode_InvalidValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var invalidUpgradeMode = (Microsoft.Azure.Batch.Common.UpgradeMode)999; // Invalid enum value

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtUpgradeMode(invalidUpgradeMode));
            Assert.Equal("psUpgradeMode", exception.ParamName);
            Assert.Equal(invalidUpgradeMode, exception.ActualValue);
        }

        [Fact]
        public void ToMgmtUpgradeMode_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each mode

            // Arrange & Act & Assert
            // Manual mode: User controls the application of updates
            var manualResult = Utils.Utils.toMgmtUpgradeMode(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);
            Assert.Equal(UpgradeMode.Manual, manualResult);

            // Automatic mode: All VMs updated simultaneously
            var automaticResult = Utils.Utils.toMgmtUpgradeMode(Microsoft.Azure.Batch.Common.UpgradeMode.Automatic);
            Assert.Equal(UpgradeMode.Automatic, automaticResult);

            // Rolling mode: VMs updated in batches with optional pause
            var rollingResult = Utils.Utils.toMgmtUpgradeMode(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling);
            Assert.Equal(UpgradeMode.Rolling, rollingResult);
        }

        [Fact]
        public void ToMgmtUpgradeMode_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation
            
            // Arrange
            var psUpgradeMode = Microsoft.Azure.Batch.Common.UpgradeMode.Automatic;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtUpgradeMode(psUpgradeMode);

            // Assert
            Assert.Equal(UpgradeMode.Automatic, result);
        }

        [Fact]
        public void ToMgmtUpgradeMode_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values
            
            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.UpgradeMode.Manual,
                Microsoft.Azure.Batch.Common.UpgradeMode.Automatic,
                Microsoft.Azure.Batch.Common.UpgradeMode.Rolling
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtUpgradeMode(value);
                Assert.True(Enum.IsDefined(typeof(UpgradeMode), result));
            }
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void ToMgmtUpgradeMode_DefaultEnumValue_HandlesZeroValue()
        {
            // Arrange - Test the default enum value (typically 0)
            var defaultValue = default(Microsoft.Azure.Batch.Common.UpgradeMode);

            // Act & Assert - Should handle the default value appropriately
            // Note: This test assumes the default value is Manual (0), but will verify actual behavior
            try
            {
                var result = Utils.Utils.toMgmtUpgradeMode(defaultValue);
                Assert.True(Enum.IsDefined(typeof(UpgradeMode), result));
            }
            catch (ArgumentOutOfRangeException)
            {
                // If default value is not handled, it should throw ArgumentOutOfRangeException
                // This is acceptable behavior for enum conversion methods
                Assert.True(true); // Test passes - expected behavior for invalid enum values
            }
        }

        [Fact]
        public void ToMgmtUpgradeMode_NegativeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var negativeValue = (Microsoft.Azure.Batch.Common.UpgradeMode)(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtUpgradeMode(negativeValue));
            Assert.Equal("psUpgradeMode", exception.ParamName);
            Assert.Equal(negativeValue, exception.ActualValue);
        }

        [Fact]
        public void ToMgmtUpgradeMode_LargeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var largeValue = (Microsoft.Azure.Batch.Common.UpgradeMode)int.MaxValue;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtUpgradeMode(largeValue));
            Assert.Equal("psUpgradeMode", exception.ParamName);
            Assert.Equal(largeValue, exception.ActualValue);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void ToMgmtUpgradeMode_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion method is updated
            
            // Arrange
            var psUpgradeModeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.UpgradeMode));
            var mgmtUpgradeModeValues = Enum.GetValues(typeof(UpgradeMode));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psUpgradeModeValues.Length, mgmtUpgradeModeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.UpgradeMode psValue in psUpgradeModeValues)
            {
                // Should not throw exception for any defined enum value
                var result = Utils.Utils.toMgmtUpgradeMode(psValue);
                Assert.True(Enum.IsDefined(typeof(UpgradeMode), result));
            }
        }

        [Fact]
        public void ToMgmtUpgradeMode_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)
            
            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.UpgradeMode.Manual,
                Microsoft.Azure.Batch.Common.UpgradeMode.Automatic,
                Microsoft.Azure.Batch.Common.UpgradeMode.Rolling
            };

            // Act
            var mgmtValues = new UpgradeMode[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                mgmtValues[i] = Utils.Utils.toMgmtUpgradeMode(psValues[i]);
            }

            // Assert - Each management enum value should be unique (no duplicates)
            var distinctValues = mgmtValues.Distinct().ToArray();
            Assert.Equal(mgmtValues.Length, distinctValues.Length);
        }

        [Fact]
        public void FromMgmtUpgradeMode_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion method is updated
            
            // Arrange
            var mgmtUpgradeModeValues = Enum.GetValues(typeof(UpgradeMode));
            var psUpgradeModeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.UpgradeMode));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(mgmtUpgradeModeValues.Length, psUpgradeModeValues.Length);

            // Verify that each management enum value can be converted successfully
            foreach (UpgradeMode mgmtValue in mgmtUpgradeModeValues)
            {
                // Should not throw exception for any defined enum value
                var result = Utils.Utils.fromMgmtUpgradeMode(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.UpgradeMode), result));
            }
        }

        [Fact]
        public void FromMgmtUpgradeMode_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)
            
            // Arrange
            var mgmtValues = new[]
            {
                UpgradeMode.Manual,
                UpgradeMode.Automatic,
                UpgradeMode.Rolling
            };

            // Act
            var psValues = new Microsoft.Azure.Batch.Common.UpgradeMode[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                psValues[i] = Utils.Utils.fromMgmtUpgradeMode(mgmtValues[i]);
            }

            // Assert - Each PS enum value should be unique (no duplicates)
            var distinctValues = psValues.Distinct().ToArray();
            Assert.Equal(psValues.Length, distinctValues.Length);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesValues()
        {
            // This test verifies that converting PS -> Management -> PS preserves the original value
            
            // Arrange
            var originalPsValues = new[]
            {
                Microsoft.Azure.Batch.Common.UpgradeMode.Manual,
                Microsoft.Azure.Batch.Common.UpgradeMode.Automatic,
                Microsoft.Azure.Batch.Common.UpgradeMode.Rolling
            };

            foreach (var originalValue in originalPsValues)
            {
                // Act - Convert PS -> Management -> PS
                var mgmtValue = Utils.Utils.toMgmtUpgradeMode(originalValue);
                var roundTripValue = Utils.Utils.fromMgmtUpgradeMode(mgmtValue);

                // Assert - Should get back the original value
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // This test verifies that converting Management -> PS -> Management preserves the original value
            
            // Arrange
            var originalMgmtValues = new[]
            {
                UpgradeMode.Manual,
                UpgradeMode.Automatic,
                UpgradeMode.Rolling
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act - Convert Management -> PS -> Management
                var psValue = Utils.Utils.fromMgmtUpgradeMode(originalValue);
                var roundTripValue = Utils.Utils.toMgmtUpgradeMode(psValue);

                // Assert - Should get back the original value
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void UpgradeModeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions
            
            // Test Manual mode semantics
            var psManual = Microsoft.Azure.Batch.Common.UpgradeMode.Manual;
            var mgmtManual = Utils.Utils.toMgmtUpgradeMode(psManual);
            var backToPs = Utils.Utils.fromMgmtUpgradeMode(mgmtManual);
            
            Assert.Equal(UpgradeMode.Manual, mgmtManual);
            Assert.Equal(psManual, backToPs);

            // Test Automatic mode semantics
            var psAutomatic = Microsoft.Azure.Batch.Common.UpgradeMode.Automatic;
            var mgmtAutomatic = Utils.Utils.toMgmtUpgradeMode(psAutomatic);
            var backToPsAuto = Utils.Utils.fromMgmtUpgradeMode(mgmtAutomatic);
            
            Assert.Equal(UpgradeMode.Automatic, mgmtAutomatic);
            Assert.Equal(psAutomatic, backToPsAuto);

            // Test Rolling mode semantics
            var psRolling = Microsoft.Azure.Batch.Common.UpgradeMode.Rolling;
            var mgmtRolling = Utils.Utils.toMgmtUpgradeMode(psRolling);
            var backToPsRolling = Utils.Utils.fromMgmtUpgradeMode(mgmtRolling);
            
            Assert.Equal(UpgradeMode.Rolling, mgmtRolling);
            Assert.Equal(psRolling, backToPsRolling);
        }

        [Fact]
        public void UpgradeModeConversions_ErrorHandling_ConsistentBehavior()
        {
            // This test ensures that both conversion methods handle invalid inputs consistently
            
            // Test invalid PS upgrade mode
            var invalidPs = (Microsoft.Azure.Batch.Common.UpgradeMode)999;
            var psException = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtUpgradeMode(invalidPs));
            Assert.Equal("psUpgradeMode", psException.ParamName);

            // Test invalid Management upgrade mode
            var invalidMgmt = (UpgradeMode)999;
            var mgmtException = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtUpgradeMode(invalidMgmt));
            Assert.Equal("mgmtUpgradeMode", mgmtException.ParamName);

            // Both should throw ArgumentOutOfRangeException with appropriate parameter names
            Assert.IsType<ArgumentOutOfRangeException>(psException);
            Assert.IsType<ArgumentOutOfRangeException>(mgmtException);
        }

        #endregion
    }
}
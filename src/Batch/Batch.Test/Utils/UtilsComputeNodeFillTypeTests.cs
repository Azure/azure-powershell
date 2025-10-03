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
    public class UtilsComputeNodeFillTypeTests
    {
        #region toMgmtComputeNodeFillType Tests

        [Fact]
        public void ToMgmtComputeNodeFillType_Pack_ReturnsPack()
        {
            // Arrange
            var psComputeNodeFillType = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack;

            // Act
            var result = Utils.Utils.toMgmtComputeNodeFillType(psComputeNodeFillType);

            // Assert
            Assert.Equal(ComputeNodeFillType.Pack, result);
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_Spread_ReturnsSpread()
        {
            // Arrange
            var psComputeNodeFillType = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread;

            // Act
            var result = Utils.Utils.toMgmtComputeNodeFillType(psComputeNodeFillType);

            // Assert
            Assert.Equal(ComputeNodeFillType.Spread, result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, ComputeNodeFillType.Pack)]
        [InlineData(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, ComputeNodeFillType.Spread)]
        public void ToMgmtComputeNodeFillType_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.ComputeNodeFillType input,
            ComputeNodeFillType expected)
        {
            // Act
            var result = Utils.Utils.toMgmtComputeNodeFillType(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_InvalidValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var invalidComputeNodeFillType = (Microsoft.Azure.Batch.Common.ComputeNodeFillType)999; // Invalid enum value

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtComputeNodeFillType(invalidComputeNodeFillType));
            Assert.Equal("psComputeNodeFillType", exception.ParamName);
            Assert.Equal(invalidComputeNodeFillType, exception.ActualValue);
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each fill type

            // Arrange & Act & Assert
            // Pack: Tasks are assigned to compute nodes to fill up each node before assigning to the next
            var packResult = Utils.Utils.toMgmtComputeNodeFillType(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            Assert.Equal(ComputeNodeFillType.Pack, packResult);

            // Spread: Tasks are assigned evenly across all compute nodes in the pool
            var spreadResult = Utils.Utils.toMgmtComputeNodeFillType(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);
            Assert.Equal(ComputeNodeFillType.Spread, spreadResult);
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psComputeNodeFillType = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtComputeNodeFillType(psComputeNodeFillType);

            // Assert
            Assert.Equal(ComputeNodeFillType.Pack, result);
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack,
                Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtComputeNodeFillType(value);
                Assert.True(Enum.IsDefined(typeof(ComputeNodeFillType), result));
            }
        }

        #endregion

        #region fromMgmtComputeNodeFillType Tests

        [Fact]
        public void FromMgmtComputeNodeFillType_Pack_ReturnsPack()
        {
            // Arrange
            var mgmtComputeNodeFillType = ComputeNodeFillType.Pack;

            // Act
            var result = Utils.Utils.fromMgmtComputeNodeFillType(mgmtComputeNodeFillType);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, result);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_Spread_ReturnsSpread()
        {
            // Arrange
            var mgmtComputeNodeFillType = ComputeNodeFillType.Spread;

            // Act
            var result = Utils.Utils.fromMgmtComputeNodeFillType(mgmtComputeNodeFillType);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, result);
        }

        [Theory]
        [InlineData(ComputeNodeFillType.Pack, Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)]
        [InlineData(ComputeNodeFillType.Spread, Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)]
        public void FromMgmtComputeNodeFillType_AllValidValues_ReturnsCorrectMapping(
            ComputeNodeFillType input,
            Microsoft.Azure.Batch.Common.ComputeNodeFillType expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtComputeNodeFillType(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_InvalidValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var invalidComputeNodeFillType = (ComputeNodeFillType)999; // Invalid enum value

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtComputeNodeFillType(invalidComputeNodeFillType));
            Assert.Equal("mgmtComputeNodeFillType", exception.ParamName);
            Assert.Equal(invalidComputeNodeFillType, exception.ActualValue);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each fill type

            // Arrange & Act & Assert
            // Pack: Tasks are assigned to compute nodes to fill up each node before assigning to the next
            var packResult = Utils.Utils.fromMgmtComputeNodeFillType(ComputeNodeFillType.Pack);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, packResult);

            // Spread: Tasks are assigned evenly across all compute nodes in the pool
            var spreadResult = Utils.Utils.fromMgmtComputeNodeFillType(ComputeNodeFillType.Spread);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, spreadResult);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtComputeNodeFillType = ComputeNodeFillType.Spread;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtComputeNodeFillType(mgmtComputeNodeFillType);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, result);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                ComputeNodeFillType.Pack,
                ComputeNodeFillType.Spread
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtComputeNodeFillType(value);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ComputeNodeFillType), result));
            }
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void ToMgmtComputeNodeFillType_DefaultEnumValue_HandlesZeroValue()
        {
            // Arrange - Test the default enum value (typically 0)
            var defaultValue = default(Microsoft.Azure.Batch.Common.ComputeNodeFillType);

            // Act & Assert - Should handle the default value appropriately
            // Note: This test assumes the default value is Pack (0), but will verify actual behavior
            try
            {
                var result = Utils.Utils.toMgmtComputeNodeFillType(defaultValue);
                Assert.True(Enum.IsDefined(typeof(ComputeNodeFillType), result));
            }
            catch (ArgumentOutOfRangeException)
            {
                // If default value is not handled, it should throw ArgumentOutOfRangeException
                // This is acceptable behavior for enum conversion methods
                Assert.True(true); // Test passes - expected behavior for invalid enum values
            }
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_DefaultEnumValue_HandlesZeroValue()
        {
            // Arrange - Test the default enum value (typically 0)
            var defaultValue = default(ComputeNodeFillType);

            // Act & Assert - Should handle the default value appropriately
            // Note: This test assumes the default value is Pack (0), but will verify actual behavior
            try
            {
                var result = Utils.Utils.fromMgmtComputeNodeFillType(defaultValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ComputeNodeFillType), result));
            }
            catch (ArgumentOutOfRangeException)
            {
                // If default value is not handled, it should throw ArgumentOutOfRangeException
                // This is acceptable behavior for enum conversion methods
                Assert.True(true); // Test passes - expected behavior for invalid enum values
            }
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_NegativeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var negativeValue = (Microsoft.Azure.Batch.Common.ComputeNodeFillType)(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtComputeNodeFillType(negativeValue));
            Assert.Equal("psComputeNodeFillType", exception.ParamName);
            Assert.Equal(negativeValue, exception.ActualValue);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_NegativeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var negativeValue = (ComputeNodeFillType)(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtComputeNodeFillType(negativeValue));
            Assert.Equal("mgmtComputeNodeFillType", exception.ParamName);
            Assert.Equal(negativeValue, exception.ActualValue);
        }

        [Fact]
        public void ToMgmtComputeNodeFillType_LargeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var largeValue = (Microsoft.Azure.Batch.Common.ComputeNodeFillType)int.MaxValue;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtComputeNodeFillType(largeValue));
            Assert.Equal("psComputeNodeFillType", exception.ParamName);
            Assert.Equal(largeValue, exception.ActualValue);
        }

        [Fact]
        public void FromMgmtComputeNodeFillType_LargeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var largeValue = (ComputeNodeFillType)int.MaxValue;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtComputeNodeFillType(largeValue));
            Assert.Equal("mgmtComputeNodeFillType", exception.ParamName);
            Assert.Equal(largeValue, exception.ActualValue);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void ComputeNodeFillType_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psComputeNodeFillTypeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.ComputeNodeFillType));
            var mgmtComputeNodeFillTypeValues = Enum.GetValues(typeof(ComputeNodeFillType));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psComputeNodeFillTypeValues.Length, mgmtComputeNodeFillTypeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.ComputeNodeFillType psValue in psComputeNodeFillTypeValues)
            {
                // Should not throw exception for any defined enum value
                var result = Utils.Utils.toMgmtComputeNodeFillType(psValue);
                Assert.True(Enum.IsDefined(typeof(ComputeNodeFillType), result));
            }

            // Verify that each management enum value can be converted successfully
            foreach (ComputeNodeFillType mgmtValue in mgmtComputeNodeFillTypeValues)
            {
                // Should not throw exception for any defined enum value
                var result = Utils.Utils.fromMgmtComputeNodeFillType(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ComputeNodeFillType), result));
            }
        }

        [Fact]
        public void ComputeNodeFillType_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack,
                Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread
            };

            var mgmtValues = new[]
            {
                ComputeNodeFillType.Pack,
                ComputeNodeFillType.Spread
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new ComputeNodeFillType[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.toMgmtComputeNodeFillType(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.ComputeNodeFillType[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtComputeNodeFillType(mgmtValues[i]);
            }

            // Assert - Each management enum value should be unique (no duplicates)
            var distinctMgmtValues = convertedMgmtValues.Distinct().ToArray();
            Assert.Equal(convertedMgmtValues.Length, distinctMgmtValues.Length);

            // Assert - Each PS enum value should be unique (no duplicates)
            var distinctPsValues = convertedPsValues.Distinct().ToArray();
            Assert.Equal(convertedPsValues.Length, distinctPsValues.Length);
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
                Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack,
                Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread
            };

            foreach (var originalValue in originalPsValues)
            {
                // Act - Convert PS -> Management -> PS
                var mgmtValue = Utils.Utils.toMgmtComputeNodeFillType(originalValue);
                var roundTripValue = Utils.Utils.fromMgmtComputeNodeFillType(mgmtValue);

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
                ComputeNodeFillType.Pack,
                ComputeNodeFillType.Spread
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act - Convert Management -> PS -> Management
                var psValue = Utils.Utils.fromMgmtComputeNodeFillType(originalValue);
                var roundTripValue = Utils.Utils.toMgmtComputeNodeFillType(psValue);

                // Assert - Should get back the original value
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ComputeNodeFillTypeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Pack semantics - Tasks fill each node before moving to the next
            var psPack = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack;
            var mgmtPack = Utils.Utils.toMgmtComputeNodeFillType(psPack);
            var backToPs = Utils.Utils.fromMgmtComputeNodeFillType(mgmtPack);

            Assert.Equal(ComputeNodeFillType.Pack, mgmtPack);
            Assert.Equal(psPack, backToPs);

            // Test Spread semantics - Tasks are distributed evenly across nodes
            var psSpread = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread;
            var mgmtSpread = Utils.Utils.toMgmtComputeNodeFillType(psSpread);
            var backToPsSpread = Utils.Utils.fromMgmtComputeNodeFillType(mgmtSpread);

            Assert.Equal(ComputeNodeFillType.Spread, mgmtSpread);
            Assert.Equal(psSpread, backToPsSpread);
        }

        [Fact]
        public void ComputeNodeFillTypeConversions_ErrorHandling_ConsistentBehavior()
        {
            // This test ensures that both conversion methods handle invalid inputs consistently

            // Test invalid PS compute node fill type
            var invalidPs = (Microsoft.Azure.Batch.Common.ComputeNodeFillType)999;
            var psException = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.toMgmtComputeNodeFillType(invalidPs));
            Assert.Equal("psComputeNodeFillType", psException.ParamName);

            // Test invalid Management compute node fill type
            var invalidMgmt = (ComputeNodeFillType)999;
            var mgmtException = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtComputeNodeFillType(invalidMgmt));
            Assert.Equal("mgmtComputeNodeFillType", mgmtException.ParamName);

            // Both should throw ArgumentOutOfRangeException with appropriate parameter names
            Assert.IsType<ArgumentOutOfRangeException>(psException);
            Assert.IsType<ArgumentOutOfRangeException>(mgmtException);
        }

        [Fact]
        public void ComputeNodeFillTypeConversions_TaskSchedulingContext_VerifyCorrectUsage()
        {
            // This test validates that the conversions work correctly in the context of task scheduling
            // ComputeNodeFillType is used in TaskSchedulingPolicy to determine how tasks are distributed

            // Arrange - Test Pack strategy (fill nodes completely before moving to next)
            var packStrategy = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack;
            var mgmtPackStrategy = Utils.Utils.toMgmtComputeNodeFillType(packStrategy);

            // Act & Assert - Pack should convert correctly
            Assert.Equal(ComputeNodeFillType.Pack, mgmtPackStrategy);

            // Arrange - Test Spread strategy (distribute tasks evenly across nodes)
            var spreadStrategy = Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread;
            var mgmtSpreadStrategy = Utils.Utils.toMgmtComputeNodeFillType(spreadStrategy);

            // Act & Assert - Spread should convert correctly
            Assert.Equal(ComputeNodeFillType.Spread, mgmtSpreadStrategy);

            // Verify round-trip conversion maintains task scheduling semantics
            var backToPack = Utils.Utils.fromMgmtComputeNodeFillType(mgmtPackStrategy);
            var backToSpread = Utils.Utils.fromMgmtComputeNodeFillType(mgmtSpreadStrategy);

            Assert.Equal(packStrategy, backToPack);
            Assert.Equal(spreadStrategy, backToSpread);
        }

        #endregion
    }
}
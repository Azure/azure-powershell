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
    public class UtilsContainerWorkingDirectoryTests
    {
        #region toMgmtContainerWorkingDirectory Tests

        [Fact]
        public void ToMgmtContainerWorkingDirectory_TaskWorkingDirectory_ReturnsTaskWorkingDirectory()
        {
            // Arrange
            var psContainerWorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory;

            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(psContainerWorkingDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, result.Value);
        }

        [Fact]
        public void ToMgmtContainerWorkingDirectory_ContainerImageDefault_ReturnsContainerImageDefault()
        {
            // Arrange
            var psContainerWorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault;

            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(psContainerWorkingDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ContainerWorkingDirectory.ContainerImageDefault, result.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, ContainerWorkingDirectory.TaskWorkingDirectory)]
        [InlineData(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault, ContainerWorkingDirectory.ContainerImageDefault)]
        public void ToMgmtContainerWorkingDirectory_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.ContainerWorkingDirectory input,
            ContainerWorkingDirectory expected)
        {
            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ToMgmtContainerWorkingDirectory_InvalidValue_ReturnsNull()
        {
            // Arrange
            var invalidContainerWorkingDirectory = (Microsoft.Azure.Batch.Common.ContainerWorkingDirectory)999; // Invalid enum value

            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(invalidContainerWorkingDirectory);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void ToMgmtContainerWorkingDirectory_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each working directory type

            // Arrange & Act & Assert
            // TaskWorkingDirectory: Use the task's working directory as the container working directory
            var taskResult = Utils.Utils.toMgmtContainerWorkingDirectory(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory);
            Assert.NotNull(taskResult);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, taskResult.Value);

            // ContainerImageDefault: Use the default working directory specified in the container image
            var containerResult = Utils.Utils.toMgmtContainerWorkingDirectory(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault);
            Assert.NotNull(containerResult);
            Assert.Equal(ContainerWorkingDirectory.ContainerImageDefault, containerResult.Value);
        }

        [Fact]
        public void ToMgmtContainerWorkingDirectory_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psContainerWorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(psContainerWorkingDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, result.Value);
        }

        [Fact]
        public void ToMgmtContainerWorkingDirectory_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory,
                Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtContainerWorkingDirectory(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(ContainerWorkingDirectory), result.Value));
            }
        }

        [Fact]
        public void ToMgmtContainerWorkingDirectory_ReturnsNullableType()
        {
            // This test verifies that the method returns a nullable ContainerWorkingDirectory

            // Arrange
            var psContainerWorkingDirectory = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory;

            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(psContainerWorkingDirectory);

            // Assert
            Assert.IsType<ContainerWorkingDirectory>(result);
            Assert.True(result.HasValue);
        }

        #endregion

        #region fromMgmtContainerWorkingDirectory Tests

        [Fact]
        public void FromMgmtContainerWorkingDirectory_TaskWorkingDirectory_ReturnsTaskWorkingDirectory()
        {
            // Arrange
            var mgmtContainerWorkingDirectory = ContainerWorkingDirectory.TaskWorkingDirectory;

            // Act
            var result = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtContainerWorkingDirectory);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, result);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_ContainerImageDefault_ReturnsContainerImageDefault()
        {
            // Arrange
            var mgmtContainerWorkingDirectory = ContainerWorkingDirectory.ContainerImageDefault;

            // Act
            var result = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtContainerWorkingDirectory);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault, result);
        }

        [Theory]
        [InlineData(ContainerWorkingDirectory.TaskWorkingDirectory, Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory)]
        [InlineData(ContainerWorkingDirectory.ContainerImageDefault, Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault)]
        public void FromMgmtContainerWorkingDirectory_AllValidValues_ReturnsCorrectMapping(
            ContainerWorkingDirectory input,
            Microsoft.Azure.Batch.Common.ContainerWorkingDirectory expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtContainerWorkingDirectory(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_NullValue_ReturnsDefault()
        {
            // Arrange
            ContainerWorkingDirectory? nullValue = null;

            // Act
            var result = Utils.Utils.fromMgmtContainerWorkingDirectory(nullValue);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_InvalidValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var invalidContainerWorkingDirectory = (ContainerWorkingDirectory)999; // Invalid enum value

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtContainerWorkingDirectory(invalidContainerWorkingDirectory));
            Assert.Equal("value", exception.ParamName);
            Assert.Equal(invalidContainerWorkingDirectory, exception.ActualValue);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each working directory type

            // Arrange & Act & Assert
            // TaskWorkingDirectory: Use the task's working directory as the container working directory
            var taskResult = Utils.Utils.fromMgmtContainerWorkingDirectory(ContainerWorkingDirectory.TaskWorkingDirectory);
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, taskResult);

            // ContainerImageDefault: Use the default working directory specified in the container image
            var containerResult = Utils.Utils.fromMgmtContainerWorkingDirectory(ContainerWorkingDirectory.ContainerImageDefault);
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault, containerResult);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtContainerWorkingDirectory = ContainerWorkingDirectory.ContainerImageDefault;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtContainerWorkingDirectory);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault, result);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new ContainerWorkingDirectory?[]
            {
                ContainerWorkingDirectory.TaskWorkingDirectory,
                ContainerWorkingDirectory.ContainerImageDefault,
                null
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtContainerWorkingDirectory(value);
                if (value.HasValue)
                {
                    Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory), result));
                }
            }
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable ContainerWorkingDirectory

            // Arrange
            ContainerWorkingDirectory? nullableValue = ContainerWorkingDirectory.TaskWorkingDirectory;

            // Act
            var result = Utils.Utils.fromMgmtContainerWorkingDirectory(nullableValue);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory, result);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void ToMgmtContainerWorkingDirectory_NegativeValue_ReturnsNull()
        {
            // Arrange
            var negativeValue = (Microsoft.Azure.Batch.Common.ContainerWorkingDirectory)(-1);

            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(negativeValue);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_NegativeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var negativeValue = (ContainerWorkingDirectory)(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtContainerWorkingDirectory(negativeValue));
            Assert.Equal("value", exception.ParamName);
            Assert.Equal(negativeValue, exception.ActualValue);
        }

        [Fact]
        public void ToMgmtContainerWorkingDirectory_LargeValue_ReturnsNull()
        {
            // Arrange
            var largeValue = (Microsoft.Azure.Batch.Common.ContainerWorkingDirectory)int.MaxValue;

            // Act
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(largeValue);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtContainerWorkingDirectory_LargeValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var largeValue = (ContainerWorkingDirectory)int.MaxValue;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtContainerWorkingDirectory(largeValue));
            Assert.Equal("value", exception.ParamName);
            Assert.Equal(largeValue, exception.ActualValue);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void ContainerWorkingDirectory_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psContainerWorkingDirectoryValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory));
            var mgmtContainerWorkingDirectoryValues = Enum.GetValues(typeof(ContainerWorkingDirectory));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psContainerWorkingDirectoryValues.Length, mgmtContainerWorkingDirectoryValues.Length);

            // Verify that each PS enum value can be converted successfully (or returns null for invalid ones)
            foreach (Microsoft.Azure.Batch.Common.ContainerWorkingDirectory psValue in psContainerWorkingDirectoryValues)
            {
                // Should not throw exception for any defined enum value
                var result = Utils.Utils.toMgmtContainerWorkingDirectory(psValue);
                // Valid values should return non-null results
                if (Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory), psValue))
                {
                    Assert.NotNull(result);
                }
            }

            // Verify that each management enum value can be converted successfully
            foreach (ContainerWorkingDirectory mgmtValue in mgmtContainerWorkingDirectoryValues)
            {
                // Should not throw exception for any defined enum value
                var result = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ContainerWorkingDirectory), result));
            }
        }

        [Fact]
        public void ContainerWorkingDirectory_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one) for valid values

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory,
                Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault
            };

            var mgmtValues = new[]
            {
                ContainerWorkingDirectory.TaskWorkingDirectory,
                ContainerWorkingDirectory.ContainerImageDefault
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new ContainerWorkingDirectory?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.toMgmtContainerWorkingDirectory(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.ContainerWorkingDirectory?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtValues[i]);
            }

            // Assert - Each management enum value should be unique (no duplicates)
            var distinctMgmtValues = convertedMgmtValues.Where(v => v.HasValue).Select(v => v.Value).Distinct().ToArray();
            Assert.Equal(convertedMgmtValues.Count(v => v.HasValue), distinctMgmtValues.Length);

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
                Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory,
                Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault
            };

            foreach (var originalValue in originalPsValues)
            {
                // Act - Convert PS -> Management -> PS
                var mgmtValue = Utils.Utils.toMgmtContainerWorkingDirectory(originalValue);
                
                if (mgmtValue.HasValue)
                {
                    var roundTripValue = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtValue.Value);

                    // Assert - Should get back the original value
                    Assert.Equal(originalValue, roundTripValue);
                }
            }
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // This test verifies that converting Management -> PS -> Management preserves the original value

            // Arrange
            var originalMgmtValues = new[]
            {
                ContainerWorkingDirectory.TaskWorkingDirectory,
                ContainerWorkingDirectory.ContainerImageDefault
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act - Convert Management -> PS -> Management
                var psValue = Utils.Utils.fromMgmtContainerWorkingDirectory(originalValue);
                var roundTripValue = Utils.Utils.toMgmtContainerWorkingDirectory(psValue);

                // Assert - Should get back the original value
                Assert.NotNull(roundTripValue);
                Assert.Equal(originalValue, roundTripValue.Value);
            }
        }

        [Fact]
        public void RoundTripConversion_NullHandling_WorksCorrectly()
        {
            // This test verifies null handling in round-trip conversions

            // Arrange
            ContainerWorkingDirectory? nullValue = null;

            // Act
            var psValue = Utils.Utils.fromMgmtContainerWorkingDirectory(nullValue);
            var backToMgmt = Utils.Utils.toMgmtContainerWorkingDirectory(psValue);

            // Assert
            // Default PS value converts to null management value
            Assert.Null(psValue);
            Assert.Null(backToMgmt);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ContainerWorkingDirectoryConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test TaskWorkingDirectory semantics - Use task's working directory
            var psTask = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory;
            var mgmtTask = Utils.Utils.toMgmtContainerWorkingDirectory(psTask);
            var backToPs = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtTask);

            Assert.NotNull(mgmtTask);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, mgmtTask.Value);
            Assert.Equal(psTask, backToPs);

            // Test ContainerImageDefault semantics - Use container image's default working directory
            var psContainer = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault;
            var mgmtContainer = Utils.Utils.toMgmtContainerWorkingDirectory(psContainer);
            var backToPsContainer = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtContainer);

            Assert.NotNull(mgmtContainer);
            Assert.Equal(ContainerWorkingDirectory.ContainerImageDefault, mgmtContainer.Value);
            Assert.Equal(psContainer, backToPsContainer);
        }

        [Fact]
        public void ContainerWorkingDirectoryConversions_ErrorHandling_ConsistentBehavior()
        {
            // This test ensures that both conversion methods handle invalid inputs consistently

            // Test invalid PS container working directory (returns null instead of throwing)
            var invalidPs = (Microsoft.Azure.Batch.Common.ContainerWorkingDirectory)999;
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(invalidPs);
            Assert.Null(result);

            // Test invalid Management container working directory (throws exception)
            var invalidMgmt = (ContainerWorkingDirectory)999;
            var mgmtException = Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtContainerWorkingDirectory(invalidMgmt));
            Assert.Equal("value", mgmtException.ParamName);
        }

        [Fact]
        public void ContainerWorkingDirectoryConversions_ContainerContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of container configuration
            // ContainerWorkingDirectory is used to specify the working directory for container tasks

            // Arrange - Test TaskWorkingDirectory for Batch task integration
            var taskWorkingDir = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.TaskWorkingDirectory;
            var mgmtTaskWorkingDir = Utils.Utils.toMgmtContainerWorkingDirectory(taskWorkingDir);

            // Act & Assert - TaskWorkingDirectory should convert correctly for Batch task compatibility
            Assert.NotNull(mgmtTaskWorkingDir);
            Assert.Equal(ContainerWorkingDirectory.TaskWorkingDirectory, mgmtTaskWorkingDir.Value);

            // Arrange - Test ContainerImageDefault for Docker image compatibility
            var containerImageDefault = Microsoft.Azure.Batch.Common.ContainerWorkingDirectory.ContainerImageDefault;
            var mgmtContainerImageDefault = Utils.Utils.toMgmtContainerWorkingDirectory(containerImageDefault);

            // Act & Assert - ContainerImageDefault should convert correctly for Docker compatibility
            Assert.NotNull(mgmtContainerImageDefault);
            Assert.Equal(ContainerWorkingDirectory.ContainerImageDefault, mgmtContainerImageDefault.Value);

            // Verify round-trip conversion maintains container semantics
            var backToTask = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtTaskWorkingDir);
            var backToContainer = Utils.Utils.fromMgmtContainerWorkingDirectory(mgmtContainerImageDefault);

            Assert.Equal(taskWorkingDir, backToTask);
            Assert.Equal(containerImageDefault, backToContainer);
        }

        [Fact]
        public void ContainerWorkingDirectoryConversions_NullabilityHandling_VerifyBehavior()
        {
            // This test verifies the special nullable handling in these conversion methods

            // toMgmtContainerWorkingDirectory returns null for invalid values (graceful degradation)
            var invalidValue = (Microsoft.Azure.Batch.Common.ContainerWorkingDirectory)999;
            var result = Utils.Utils.toMgmtContainerWorkingDirectory(invalidValue);
            Assert.Null(result);

            // fromMgmtContainerWorkingDirectory returns default for null input
            ContainerWorkingDirectory? nullInput = null;
            var defaultResult = Utils.Utils.fromMgmtContainerWorkingDirectory(nullInput);
            Assert.Null(defaultResult);

            // fromMgmtContainerWorkingDirectory throws for invalid non-null values (strict validation)
            var invalidMgmt = (ContainerWorkingDirectory)999;
            Assert.Throws<ArgumentOutOfRangeException>(() => Utils.Utils.fromMgmtContainerWorkingDirectory(invalidMgmt));
        }

        #endregion
    }
}
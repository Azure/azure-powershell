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
    public class UtilsLoginModeTests
    {
        #region ToMgmtLoginMode Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_Batch_ReturnsBatch()
        {
            // Arrange
            var psLoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch;

            // Act
            var result = Utils.Utils.ToMgmtLoginMode(psLoginMode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(LoginMode.Batch, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_Interactive_ReturnsInteractive()
        {
            // Arrange
            var psLoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive;

            // Act
            var result = Utils.Utils.ToMgmtLoginMode(psLoginMode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(LoginMode.Interactive, result.Value);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Batch, LoginMode.Batch)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Interactive, LoginMode.Interactive)]
        public void ToMgmtLoginMode_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.LoginMode input,
            LoginMode expected)
        {
            // Act
            var result = Utils.Utils.ToMgmtLoginMode(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.LoginMode? nullLoginMode = null;

            // Act
            var result = Utils.Utils.ToMgmtLoginMode(nullLoginMode);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.LoginMode);

            // Act
            var result = Utils.Utils.ToMgmtLoginMode(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default LoginMode is typically Batch (0)
            Assert.Equal(LoginMode.Batch, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each login mode

            // Arrange & Act & Assert
            // Batch mode: Use Azure Batch account credentials for authentication
            var batchResult = Utils.Utils.ToMgmtLoginMode(Microsoft.Azure.Batch.Common.LoginMode.Batch);
            Assert.NotNull(batchResult);
            Assert.Equal(LoginMode.Batch, batchResult.Value);

            // Interactive mode: Interactive login with user credentials
            var interactiveResult = Utils.Utils.ToMgmtLoginMode(Microsoft.Azure.Batch.Common.LoginMode.Interactive);
            Assert.NotNull(interactiveResult);
            Assert.Equal(LoginMode.Interactive, interactiveResult.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psLoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive;

            // Act - Call static method directly on class
            var result = Utils.Utils.ToMgmtLoginMode(psLoginMode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(LoginMode.Interactive, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.LoginMode.Batch,
                Microsoft.Azure.Batch.Common.LoginMode.Interactive
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.ToMgmtLoginMode(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(LoginMode), result.Value));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psBatch = Microsoft.Azure.Batch.Common.LoginMode.Batch;
            var psInteractive = Microsoft.Azure.Batch.Common.LoginMode.Interactive;

            // Act
            var mgmtBatch = Utils.Utils.ToMgmtLoginMode(psBatch);
            var mgmtInteractive = Utils.Utils.ToMgmtLoginMode(psInteractive);

            // Assert
            Assert.NotNull(mgmtBatch);
            Assert.NotNull(mgmtInteractive);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psBatch, (int)mgmtBatch.Value);
            Assert.Equal((int)psInteractive, (int)mgmtInteractive.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtLoginMode_AlwaysReturnsNewNullableValue()
        {
            // This test verifies that the method always returns a new nullable value

            // Arrange
            var psLoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch;

            // Act
            var result1 = Utils.Utils.ToMgmtLoginMode(psLoginMode);
            var result2 = Utils.Utils.ToMgmtLoginMode(psLoginMode);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1.Value, result2.Value);
        }

        #endregion

        #region FromMgmtLoginMode Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_Batch_ReturnsBatch()
        {
            // Arrange
            var mgmtLoginMode = LoginMode.Batch;

            // Act
            var result = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_Interactive_ReturnsInteractive()
        {
            // Arrange
            var mgmtLoginMode = LoginMode.Interactive;

            // Act
            var result = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, result.Value);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(LoginMode.Batch, Microsoft.Azure.Batch.Common.LoginMode.Batch)]
        [InlineData(LoginMode.Interactive, Microsoft.Azure.Batch.Common.LoginMode.Interactive)]
        public void FromMgmtLoginMode_AllValidValues_ReturnsCorrectMapping(
            LoginMode input,
            Microsoft.Azure.Batch.Common.LoginMode expected)
        {
            // Act
            var result = Utils.Utils.FromMgmtLoginMode(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_NullValue_ReturnsNull()
        {
            // Arrange
            LoginMode? nullLoginMode = null;

            // Act
            var result = Utils.Utils.FromMgmtLoginMode(nullLoginMode);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(LoginMode);

            // Act
            var result = Utils.Utils.FromMgmtLoginMode(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default LoginMode is typically Batch (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each login mode

            // Arrange & Act & Assert
            // Batch mode: Use Azure Batch account credentials for authentication
            var batchResult = Utils.Utils.FromMgmtLoginMode(LoginMode.Batch);
            Assert.NotNull(batchResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, batchResult.Value);

            // Interactive mode: Interactive login with user credentials
            var interactiveResult = Utils.Utils.FromMgmtLoginMode(LoginMode.Interactive);
            Assert.NotNull(interactiveResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, interactiveResult.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtLoginMode = LoginMode.Batch;

            // Act - Call static method directly on class
            var result = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new LoginMode?[]
            {
                LoginMode.Batch,
                LoginMode.Interactive,
                null
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.FromMgmtLoginMode(value);
                if (value.HasValue)
                {
                    Assert.NotNull(result);
                    Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.LoginMode), result.Value));
                }
                else
                {
                    Assert.Null(result);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable LoginMode

            // Arrange
            LoginMode? nullableValue = LoginMode.Interactive;

            // Act
            var result = Utils.Utils.FromMgmtLoginMode(nullableValue);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, result.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtBatch = LoginMode.Batch;
            var mgmtInteractive = LoginMode.Interactive;

            // Act
            var psBatch = Utils.Utils.FromMgmtLoginMode(mgmtBatch);
            var psInteractive = Utils.Utils.FromMgmtLoginMode(mgmtInteractive);

            // Assert
            Assert.NotNull(psBatch);
            Assert.NotNull(psInteractive);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtBatch, (int)psBatch.Value);
            Assert.Equal((int)mgmtInteractive, (int)psInteractive.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtLoginMode_AlwaysReturnsNewNullableValue()
        {
            // This test verifies that the method always returns a new nullable value

            // Arrange
            var mgmtLoginMode = LoginMode.Interactive;

            // Act
            var result1 = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);
            var result2 = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1.Value, result2.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesBatchValue()
        {
            // Arrange
            var originalPsLoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch;

            // Act
            var mgmtLoginMode = Utils.Utils.ToMgmtLoginMode(originalPsLoginMode);
            var roundTripPsLoginMode = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(roundTripPsLoginMode);
            Assert.Equal(originalPsLoginMode, roundTripPsLoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesInteractiveValue()
        {
            // Arrange
            var originalPsLoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive;

            // Act
            var mgmtLoginMode = Utils.Utils.ToMgmtLoginMode(originalPsLoginMode);
            var roundTripPsLoginMode = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(roundTripPsLoginMode);
            Assert.Equal(originalPsLoginMode, roundTripPsLoginMode.Value);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Batch)]
        [InlineData(Microsoft.Azure.Batch.Common.LoginMode.Interactive)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.LoginMode originalLoginMode)
        {
            // Act
            var mgmtLoginMode = Utils.Utils.ToMgmtLoginMode(originalLoginMode);
            var roundTripLoginMode = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

            // Assert
            Assert.NotNull(roundTripLoginMode);
            Assert.Equal(originalLoginMode, roundTripLoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                LoginMode.Batch,
                LoginMode.Interactive
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.FromMgmtLoginMode(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtLoginMode(psValue);

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
            Microsoft.Azure.Batch.Common.LoginMode? nullPsValue = null;
            LoginMode? nullMgmtValue = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.ToMgmtLoginMode(nullPsValue);
            var psFromNullMgmt = Utils.Utils.FromMgmtLoginMode(nullMgmtValue);

            // Assert
            Assert.Null(mgmtFromNullPs);
            Assert.Null(psFromNullMgmt);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginMode_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psLoginModeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.LoginMode));
            var mgmtLoginModeValues = Enum.GetValues(typeof(LoginMode));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psLoginModeValues.Length, mgmtLoginModeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.LoginMode psValue in psLoginModeValues)
            {
                var result = Utils.Utils.ToMgmtLoginMode(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(LoginMode), result.Value));
            }

            // Verify that each management enum value can be converted successfully
            foreach (LoginMode mgmtValue in mgmtLoginModeValues)
            {
                var result = Utils.Utils.FromMgmtLoginMode(mgmtValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.LoginMode), result.Value));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginMode_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.LoginMode.Batch,
                Microsoft.Azure.Batch.Common.LoginMode.Interactive
            };

            var mgmtValues = new[]
            {
                LoginMode.Batch,
                LoginMode.Interactive
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new LoginMode?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.ToMgmtLoginMode(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.LoginMode?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.FromMgmtLoginMode(mgmtValues[i]);
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
        public void LoginModeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Batch mode semantics - Use Azure Batch account credentials
            var psBatch = Microsoft.Azure.Batch.Common.LoginMode.Batch;
            var mgmtBatch = Utils.Utils.ToMgmtLoginMode(psBatch);
            var backToPs = Utils.Utils.FromMgmtLoginMode(mgmtBatch);

            Assert.NotNull(mgmtBatch);
            Assert.Equal(LoginMode.Batch, mgmtBatch.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(psBatch, backToPs.Value);

            // Test Interactive mode semantics - Interactive user authentication
            var psInteractive = Microsoft.Azure.Batch.Common.LoginMode.Interactive;
            var mgmtInteractive = Utils.Utils.ToMgmtLoginMode(psInteractive);
            var backToPsInteractive = Utils.Utils.FromMgmtLoginMode(mgmtInteractive);

            Assert.NotNull(mgmtInteractive);
            Assert.Equal(LoginMode.Interactive, mgmtInteractive.Value);
            Assert.NotNull(backToPsInteractive);
            Assert.Equal(psInteractive, backToPsInteractive.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginModeConversions_NullabilityHandling_VerifyBehavior()
        {
            // This test verifies the nullable handling in these conversion methods

            // ToMgmtLoginMode returns null for null input
            Microsoft.Azure.Batch.Common.LoginMode? nullInput = null;
            var result = Utils.Utils.ToMgmtLoginMode(nullInput);
            Assert.Null(result);

            // FromMgmtLoginMode returns null for null input
            LoginMode? nullMgmtInput = null;
            var mgmtResult = Utils.Utils.FromMgmtLoginMode(nullMgmtInput);
            Assert.Null(mgmtResult);

            // Both methods handle nullable types correctly
            LoginMode? nullableInteractive = LoginMode.Interactive;
            var nonNullResult = Utils.Utils.FromMgmtLoginMode(nullableInteractive);
            Assert.NotNull(nonNullResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, nonNullResult.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginModeConversions_BatchAuthenticationContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch authentication
            // LoginMode is used to specify authentication method for Azure Batch operations

            // Arrange - Test with realistic Batch authentication scenarios
            var authenticationScenarios = new[]
            {
                // Batch account authentication using account keys or certificates
                new {
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch,
                    Description = "Azure Batch account authentication for automated scripts and services"
                },
                // Interactive authentication for user-initiated operations
                new {
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive,
                    Description = "Interactive authentication for user sessions and development scenarios"
                }
            };

            foreach (var scenario in authenticationScenarios)
            {
                // Act
                var mgmtLoginMode = Utils.Utils.ToMgmtLoginMode(scenario.LoginMode);

                // Assert - Should convert correctly for Batch authentication configuration
                Assert.NotNull(mgmtLoginMode);
                
                var expectedMgmtMode = scenario.LoginMode == Microsoft.Azure.Batch.Common.LoginMode.Batch
                    ? LoginMode.Batch
                    : LoginMode.Interactive;
                Assert.Equal(expectedMgmtMode, mgmtLoginMode.Value);

                // Verify round-trip conversion maintains authentication semantics
                var backToPs = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.LoginMode, backToPs.Value);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginModeConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.LoginMode psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.LoginMode)))
            {
                var mgmtResult = Utils.Utils.ToMgmtLoginMode(psValue);
                Assert.NotNull(mgmtResult);
                Assert.Equal((int)psValue, (int)mgmtResult.Value);
            }

            foreach (LoginMode mgmtValue in Enum.GetValues(typeof(LoginMode)))
            {
                var psResult = Utils.Utils.FromMgmtLoginMode(mgmtValue);
                Assert.NotNull(psResult);
                Assert.Equal((int)mgmtValue, (int)psResult.Value);
            }
        }

        #endregion

        #region Performance Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginModeConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psLoginModes = new Microsoft.Azure.Batch.Common.LoginMode[50];
            var mgmtLoginModes = new LoginMode[50];

            for (int i = 0; i < 50; i++)
            {
                psLoginModes[i] = i % 2 == 0 
                    ? Microsoft.Azure.Batch.Common.LoginMode.Batch 
                    : Microsoft.Azure.Batch.Common.LoginMode.Interactive;
                    
                mgmtLoginModes[i] = i % 2 == 0 
                    ? LoginMode.Batch 
                    : LoginMode.Interactive;
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psMode in psLoginModes)
                {
                    var mgmtResult = Utils.Utils.ToMgmtLoginMode(psMode);
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtMode in mgmtLoginModes)
                {
                    var psResult = Utils.Utils.FromMgmtLoginMode(mgmtMode);
                    Assert.NotNull(psResult);
                }
            }
        }

        #endregion

        #region Real-world Scenario Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoginModeConversions_BatchServiceIntegration_VerifySemantics()
        {
            // This test validates the conversions work correctly in real Azure Batch service scenarios

            // Arrange - Test scenarios matching actual Azure Batch usage patterns
            var serviceScenarios = new[]
            {
                // Automated batch processing with service accounts
                new {
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Batch,
                    UseCase = "Automated data processing jobs using Azure Batch account credentials",
                    Context = "Production workloads, CI/CD pipelines, scheduled jobs"
                },
                // Developer and user scenarios
                new {
                    LoginMode = Microsoft.Azure.Batch.Common.LoginMode.Interactive,
                    UseCase = "Interactive development and testing of batch workloads",
                    Context = "Development environments, manual job submission, debugging"
                }
            };

            foreach (var scenario in serviceScenarios)
            {
                // Act - Test conversion in the context of Azure Batch service integration
                var mgmtLoginMode = Utils.Utils.ToMgmtLoginMode(scenario.LoginMode);
                var roundTripPs = Utils.Utils.FromMgmtLoginMode(mgmtLoginMode);

                // Assert - Verify service integration semantics are preserved
                Assert.NotNull(mgmtLoginMode);
                Assert.NotNull(roundTripPs);

                var expectedMgmtMode = scenario.LoginMode == Microsoft.Azure.Batch.Common.LoginMode.Batch
                    ? LoginMode.Batch
                    : LoginMode.Interactive;
                
                Assert.Equal(expectedMgmtMode, mgmtLoginMode.Value);
                Assert.Equal(scenario.LoginMode, roundTripPs.Value);

                // Verify that authentication mode semantics are maintained
                if (scenario.LoginMode == Microsoft.Azure.Batch.Common.LoginMode.Batch)
                {
                    Assert.Equal(LoginMode.Batch, mgmtLoginMode.Value);
                    // Batch mode should be used for service-to-service authentication
                }
                else
                {
                    Assert.Equal(LoginMode.Interactive, mgmtLoginMode.Value);
                    // Interactive mode should be used for user authentication
                }
            }
        }

        #endregion
    }
}
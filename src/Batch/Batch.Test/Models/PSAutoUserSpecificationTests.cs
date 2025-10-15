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
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSAutoUserSpecificationTests
    {
        #region toMgmtAutoUserSpecification Tests

        [Fact]
        public void ToMgmtAutoUserSpecification_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AutoUserScope.Task, result.Scope);
            Assert.Equal(ElevationLevel.Admin, result.ElevationLevel);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_WithPoolScopeAndNonAdmin_ReturnsCorrectMapping()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AutoUserScope.Pool, result.Scope);
            Assert.Equal(ElevationLevel.NonAdmin, result.ElevationLevel);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_WithNullScope_ReturnsNullScope()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: null,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Scope);
            Assert.Equal(ElevationLevel.Admin, result.ElevationLevel);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_WithNullElevationLevel_ReturnsNullElevationLevel()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: null);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AutoUserScope.Pool, result.Scope);
            Assert.Null(result.ElevationLevel);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_WithBothNullValues_ReturnsBothNull()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: null,
                elevationLevel: null);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Scope);
            Assert.Null(result.ElevationLevel);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Task, Microsoft.Azure.Batch.Common.ElevationLevel.Admin, AutoUserScope.Task, ElevationLevel.Admin)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Task, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, AutoUserScope.Task, ElevationLevel.NonAdmin)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, Microsoft.Azure.Batch.Common.ElevationLevel.Admin, AutoUserScope.Pool, ElevationLevel.Admin)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, AutoUserScope.Pool, ElevationLevel.NonAdmin)]
        public void ToMgmtAutoUserSpecification_AllValidCombinations_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.AutoUserScope psScope,
            Microsoft.Azure.Batch.Common.ElevationLevel psElevationLevel,
            AutoUserScope expectedScope,
            ElevationLevel expectedElevationLevel)
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: psScope,
                elevationLevel: psElevationLevel);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedScope, result.Scope);
            Assert.Equal(expectedElevationLevel, result.ElevationLevel);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var result1 = psAutoUserSpec.toMgmtAutoUserSpecification();
            var result2 = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_VerifyAutoUserSpecificationType()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.AutoUserSpecification>(result);
        }

        [Fact]
        public void ToMgmtAutoUserSpecification_DefaultValues_HandlesCorrectly()
        {
            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(); // Using default constructor

            // Act
            var result = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(result);
            // Properties should be null since no values were specified
            Assert.Null(result.Scope);
            Assert.Null(result.ElevationLevel);
        }

        #endregion

        #region fromMgmtAutoUserSpecification Tests

        [Fact]
        public void FromMgmtAutoUserSpecification_WithAllProperties_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.Admin);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, result.ElevationLevel);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_WithPoolScopeAndNonAdmin_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, result.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, result.ElevationLevel);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_WithNullMgmtSpec_ReturnsNull()
        {
            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_WithNullScope_ReturnsNullScope()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: null,
                elevationLevel: ElevationLevel.Admin);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, result.ElevationLevel);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_WithNullElevationLevel_ReturnsNullElevationLevel()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: null);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, result.Scope);
            Assert.Null(result.ElevationLevel);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_WithBothNullValues_ReturnsBothNull()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: null,
                elevationLevel: null);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Scope);
            Assert.Null(result.ElevationLevel);
        }

        [Theory]
        [InlineData(AutoUserScope.Task, ElevationLevel.Admin, Microsoft.Azure.Batch.Common.AutoUserScope.Task, Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        [InlineData(AutoUserScope.Task, ElevationLevel.NonAdmin, Microsoft.Azure.Batch.Common.AutoUserScope.Task, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        [InlineData(AutoUserScope.Pool, ElevationLevel.Admin, Microsoft.Azure.Batch.Common.AutoUserScope.Pool, Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        [InlineData(AutoUserScope.Pool, ElevationLevel.NonAdmin, Microsoft.Azure.Batch.Common.AutoUserScope.Pool, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        public void FromMgmtAutoUserSpecification_AllValidCombinations_ReturnsCorrectMapping(
            AutoUserScope mgmtScope,
            ElevationLevel mgmtElevationLevel,
            Microsoft.Azure.Batch.Common.AutoUserScope expectedScope,
            Microsoft.Azure.Batch.Common.ElevationLevel expectedElevationLevel)
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: mgmtScope,
                elevationLevel: mgmtElevationLevel);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedScope, result.Scope);
            Assert.Equal(expectedElevationLevel, result.ElevationLevel);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.NonAdmin);

            // Act - Call static method directly on class
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, result.ElevationLevel);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.Admin);

            // Act
            var result1 = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);
            var result2 = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_VerifyPSAutoUserSpecificationType()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Task,
                elevationLevel: ElevationLevel.Admin);

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSAutoUserSpecification>(result);
        }

        [Fact]
        public void FromMgmtAutoUserSpecification_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(); // Uses default constructor

            // Act
            var result = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Scope);
            Assert.Null(result.ElevationLevel);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var mgmtAutoUserSpec = originalPsAutoUserSpec.toMgmtAutoUserSpecification();
            var roundTripPsAutoUserSpec = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(roundTripPsAutoUserSpec);
            Assert.Equal(originalPsAutoUserSpec.Scope, roundTripPsAutoUserSpec.Scope);
            Assert.Equal(originalPsAutoUserSpec.ElevationLevel, roundTripPsAutoUserSpec.ElevationLevel);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsAutoUserSpec = new PSAutoUserSpecification(
                scope: null,
                elevationLevel: null);

            // Act
            var mgmtAutoUserSpec = originalPsAutoUserSpec.toMgmtAutoUserSpecification();
            var roundTripPsAutoUserSpec = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(roundTripPsAutoUserSpec);
            Assert.Null(roundTripPsAutoUserSpec.Scope);
            Assert.Null(roundTripPsAutoUserSpec.ElevationLevel);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPartialNullValues()
        {
            // Arrange
            var originalPsAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: null);

            // Act
            var mgmtAutoUserSpec = originalPsAutoUserSpec.toMgmtAutoUserSpecification();
            var roundTripPsAutoUserSpec = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(roundTripPsAutoUserSpec);
            Assert.Equal(originalPsAutoUserSpec.Scope, roundTripPsAutoUserSpec.Scope);
            Assert.Null(roundTripPsAutoUserSpec.ElevationLevel);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Task, Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Task, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        public void RoundTripConversion_AllValidCombinations_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.AutoUserScope originalScope,
            Microsoft.Azure.Batch.Common.ElevationLevel originalElevationLevel)
        {
            // Arrange
            var originalPsAutoUserSpec = new PSAutoUserSpecification(
                scope: originalScope,
                elevationLevel: originalElevationLevel);

            // Act
            var mgmtAutoUserSpec = originalPsAutoUserSpec.toMgmtAutoUserSpecification();
            var roundTripPsAutoUserSpec = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(roundTripPsAutoUserSpec);
            Assert.Equal(originalScope, roundTripPsAutoUserSpec.Scope);
            Assert.Equal(originalElevationLevel, roundTripPsAutoUserSpec.ElevationLevel);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);

            // Act
            var psAutoUserSpec = PSAutoUserSpecification.fromMgmtAutoUserSpecification(originalMgmtAutoUserSpec);
            var roundTripMgmtAutoUserSpec = psAutoUserSpec.toMgmtAutoUserSpecification();

            // Assert
            Assert.NotNull(roundTripMgmtAutoUserSpec);
            Assert.Equal(originalMgmtAutoUserSpec.Scope, roundTripMgmtAutoUserSpec.Scope);
            Assert.Equal(originalMgmtAutoUserSpec.ElevationLevel, roundTripMgmtAutoUserSpec.ElevationLevel);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void AutoUserSpecificationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic auto user scenarios
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var mgmtAutoUserSpec = psAutoUserSpec.toMgmtAutoUserSpecification();
            var backToPs = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert
            Assert.NotNull(mgmtAutoUserSpec);
            Assert.Equal(AutoUserScope.Task, mgmtAutoUserSpec.Scope);
            Assert.Equal(ElevationLevel.Admin, mgmtAutoUserSpec.ElevationLevel);

            Assert.NotNull(backToPs);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, backToPs.Scope);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, backToPs.ElevationLevel);
        }

        [Fact]
        public void AutoUserSpecificationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSAutoUserSpecification.fromMgmtAutoUserSpecification(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void AutoUserSpecificationConversions_BatchTaskContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch task configuration
            // AutoUserSpecification is used to configure auto user settings for tasks

            // Arrange - Test with different auto user scenarios
            var scenarios = new[]
            {
                // Task-scoped admin user for isolated privileged operations
                new {
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                    Description = "Task-scoped admin user for privileged operations"
                },
                // Task-scoped non-admin user for isolated standard operations
                new {
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    Description = "Task-scoped non-admin user for standard operations"
                },
                // Pool-scoped admin user for shared privileged operations
                new {
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                    Description = "Pool-scoped admin user for shared privileged operations"
                },
                // Pool-scoped non-admin user for shared standard operations
                new {
                    Scope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    Description = "Pool-scoped non-admin user for shared standard operations"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Arrange
                var psAutoUserSpec = new PSAutoUserSpecification(
                    scope: scenario.Scope,
                    elevationLevel: scenario.ElevationLevel);

                // Act
                var mgmtAutoUserSpec = psAutoUserSpec.toMgmtAutoUserSpecification();

                // Assert - Should convert correctly for Batch task configuration
                Assert.NotNull(mgmtAutoUserSpec);
                
                var expectedMgmtScope = scenario.Scope == Microsoft.Azure.Batch.Common.AutoUserScope.Task
                    ? AutoUserScope.Task
                    : AutoUserScope.Pool;
                var expectedMgmtElevationLevel = scenario.ElevationLevel == Microsoft.Azure.Batch.Common.ElevationLevel.Admin
                    ? ElevationLevel.Admin
                    : ElevationLevel.NonAdmin;
                    
                Assert.Equal(expectedMgmtScope, mgmtAutoUserSpec.Scope);
                Assert.Equal(expectedMgmtElevationLevel, mgmtAutoUserSpec.ElevationLevel);

                // Verify round-trip conversion maintains auto user semantics
                var backToPs = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Scope, backToPs.Scope);
                Assert.Equal(scenario.ElevationLevel, backToPs.ElevationLevel);
            }
        }

        [Fact]
        public void AutoUserSpecificationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);

            // Act
            var mgmtResult = psAutoUserSpec.toMgmtAutoUserSpecification();
            var psResult = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.AutoUserSpecification>(mgmtResult);
            Assert.IsType<PSAutoUserSpecification>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtAutoUserSpec, mgmtResult);
            Assert.NotSame(psAutoUserSpec, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void AutoUserSpecificationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psAutoUserSpec = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            var mgmtAutoUserSpec = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(
                scope: AutoUserScope.Pool,
                elevationLevel: ElevationLevel.NonAdmin);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psAutoUserSpec.toMgmtAutoUserSpecification();
                var psResult = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpec);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(AutoUserScope.Task, mgmtResult.Scope);
                Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, psResult.Scope);
            }
        }

        [Fact]
        public void AutoUserSpecificationConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default/null values

            // Arrange
            var psAutoUserSpecWithDefaults = new PSAutoUserSpecification(); // Default constructor
            var mgmtAutoUserSpecWithDefaults = new Microsoft.Azure.Management.Batch.Models.AutoUserSpecification(); // Default constructor

            // Act
            var mgmtResult = psAutoUserSpecWithDefaults.toMgmtAutoUserSpecification();
            var psResult = PSAutoUserSpecification.fromMgmtAutoUserSpecification(mgmtAutoUserSpecWithDefaults);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.Null(mgmtResult.Scope);
            Assert.Null(mgmtResult.ElevationLevel);
            Assert.Null(psResult.Scope);
            Assert.Null(psResult.ElevationLevel);
        }

        [Fact]
        public void AutoUserSpecificationConversions_TaskIsolationScenarios_VerifyCorrectUsage()
        {
            // This test validates conversion behavior for task isolation scenarios

            // Scenario 1: Maximum isolation (Task scope, Admin privileges)
            var maxIsolationPs = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            var maxIsolationMgmt = maxIsolationPs.toMgmtAutoUserSpecification();
            Assert.Equal(AutoUserScope.Task, maxIsolationMgmt.Scope);
            Assert.Equal(ElevationLevel.Admin, maxIsolationMgmt.ElevationLevel);

            // Scenario 2: Standard isolation (Task scope, NonAdmin privileges)
            var standardIsolationPs = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

            var standardIsolationMgmt = standardIsolationPs.toMgmtAutoUserSpecification();
            Assert.Equal(AutoUserScope.Task, standardIsolationMgmt.Scope);
            Assert.Equal(ElevationLevel.NonAdmin, standardIsolationMgmt.ElevationLevel);

            // Scenario 3: Shared operations (Pool scope, Admin privileges)
            var sharedAdminPs = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            var sharedAdminMgmt = sharedAdminPs.toMgmtAutoUserSpecification();
            Assert.Equal(AutoUserScope.Pool, sharedAdminMgmt.Scope);
            Assert.Equal(ElevationLevel.Admin, sharedAdminMgmt.ElevationLevel);

            // Scenario 4: Default shared operations (Pool scope, NonAdmin privileges)
            var defaultSharedPs = new PSAutoUserSpecification(
                scope: Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

            var defaultSharedMgmt = defaultSharedPs.toMgmtAutoUserSpecification();
            Assert.Equal(AutoUserScope.Pool, defaultSharedMgmt.Scope);
            Assert.Equal(ElevationLevel.NonAdmin, defaultSharedMgmt.ElevationLevel);

            // Verify all round-trip correctly
            var maxIsolationRoundTrip = PSAutoUserSpecification.fromMgmtAutoUserSpecification(maxIsolationMgmt);
            var standardIsolationRoundTrip = PSAutoUserSpecification.fromMgmtAutoUserSpecification(standardIsolationMgmt);
            var sharedAdminRoundTrip = PSAutoUserSpecification.fromMgmtAutoUserSpecification(sharedAdminMgmt);
            var defaultSharedRoundTrip = PSAutoUserSpecification.fromMgmtAutoUserSpecification(defaultSharedMgmt);

            Assert.Equal(maxIsolationPs.Scope, maxIsolationRoundTrip.Scope);
            Assert.Equal(maxIsolationPs.ElevationLevel, maxIsolationRoundTrip.ElevationLevel);
            Assert.Equal(standardIsolationPs.Scope, standardIsolationRoundTrip.Scope);
            Assert.Equal(standardIsolationPs.ElevationLevel, standardIsolationRoundTrip.ElevationLevel);
            Assert.Equal(sharedAdminPs.Scope, sharedAdminRoundTrip.Scope);
            Assert.Equal(sharedAdminPs.ElevationLevel, sharedAdminRoundTrip.ElevationLevel);
            Assert.Equal(defaultSharedPs.Scope, defaultSharedRoundTrip.Scope);
            Assert.Equal(defaultSharedPs.ElevationLevel, defaultSharedRoundTrip.ElevationLevel);
        }

        #endregion
    }
}
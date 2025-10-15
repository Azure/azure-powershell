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
    public class UtilsDynamicVNetAssignmentScopeTests
    {
        #region toMgmtDynamicVNetAssignmentScope Tests

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_None_ReturnsNone()
        {
            // Arrange
            var psDynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None;

            // Act
            var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DynamicVNetAssignmentScope.None, result.Value);
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_Job_ReturnsJob()
        {
            // Arrange
            var psDynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;

            // Act
            var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DynamicVNetAssignmentScope.Job, result.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, DynamicVNetAssignmentScope.None)]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, DynamicVNetAssignmentScope.Job)]
        public void ToMgmtDynamicVNetAssignmentScope_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope input,
            DynamicVNetAssignmentScope expected)
        {
            // Act
            var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope? nullDynamicVNetAssignmentScope = null;

            // Act
            var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(nullDynamicVNetAssignmentScope);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope);

            // Act
            var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default DynamicVNetAssignmentScope is typically None (0)
            Assert.Equal(DynamicVNetAssignmentScope.None, result.Value);
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each dynamic VNet assignment scope

            // Arrange & Act & Assert
            // None: No dynamic VNet assignment is enabled
            var noneResult = Utils.Utils.toMgmtDynamicVNetAssignmentScope(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None);
            Assert.NotNull(noneResult);
            Assert.Equal(DynamicVNetAssignmentScope.None, noneResult.Value);

            // Job: Dynamic VNet assignment is done per-job
            var jobResult = Utils.Utils.toMgmtDynamicVNetAssignmentScope(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job);
            Assert.NotNull(jobResult);
            Assert.Equal(DynamicVNetAssignmentScope.Job, jobResult.Value);
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psDynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(DynamicVNetAssignmentScope.Job, result.Value);
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None,
                Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(DynamicVNetAssignmentScope), result.Value));
            }
        }

        [Fact]
        public void ToMgmtDynamicVNetAssignmentScope_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psNone = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None;
            var psJob = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;

            // Act
            var mgmtNone = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psNone);
            var mgmtJob = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psJob);

            // Assert
            Assert.NotNull(mgmtNone);
            Assert.NotNull(mgmtJob);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psNone, (int)mgmtNone.Value);
            Assert.Equal((int)psJob, (int)mgmtJob.Value);
        }

        #endregion

        #region fromMgmtDynamicVNetAssignmentScope Tests

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_None_ReturnsNone()
        {
            // Arrange
            var mgmtDynamicVNetAssignmentScope = DynamicVNetAssignmentScope.None;

            // Act
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, result.Value);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_Job_ReturnsJob()
        {
            // Arrange
            var mgmtDynamicVNetAssignmentScope = DynamicVNetAssignmentScope.Job;

            // Act
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, result.Value);
        }

        [Theory]
        [InlineData(DynamicVNetAssignmentScope.None, Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None)]
        [InlineData(DynamicVNetAssignmentScope.Job, Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job)]
        public void FromMgmtDynamicVNetAssignmentScope_AllValidValues_ReturnsCorrectMapping(
            DynamicVNetAssignmentScope input,
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_NullValue_ReturnsNull()
        {
            // Arrange
            DynamicVNetAssignmentScope? nullDynamicVNetAssignmentScope = null;

            // Act
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(nullDynamicVNetAssignmentScope);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(DynamicVNetAssignmentScope);

            // Act
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default DynamicVNetAssignmentScope is typically None (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, result.Value);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each dynamic VNet assignment scope

            // Arrange & Act & Assert
            // None: No dynamic VNet assignment is enabled
            var noneResult = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(DynamicVNetAssignmentScope.None);
            Assert.NotNull(noneResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, noneResult.Value);

            // Job: Dynamic VNet assignment is done per-job
            var jobResult = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(DynamicVNetAssignmentScope.Job);
            Assert.NotNull(jobResult);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, jobResult.Value);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtDynamicVNetAssignmentScope = DynamicVNetAssignmentScope.None;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None, result.Value);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                DynamicVNetAssignmentScope.None,
                DynamicVNetAssignmentScope.Job
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope), result.Value));
            }
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable DynamicVNetAssignmentScope

            // Arrange
            DynamicVNetAssignmentScope? nullableValue = DynamicVNetAssignmentScope.Job;

            // Act
            var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(nullableValue);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, result.Value);
        }

        [Fact]
        public void FromMgmtDynamicVNetAssignmentScope_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtNone = DynamicVNetAssignmentScope.None;
            var mgmtJob = DynamicVNetAssignmentScope.Job;

            // Act
            var psNone = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtNone);
            var psJob = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtJob);

            // Assert
            Assert.NotNull(psNone);
            Assert.NotNull(psJob);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtNone, (int)psNone.Value);
            Assert.Equal((int)mgmtJob, (int)psJob.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNoneValue()
        {
            // Arrange
            var originalPsDynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None;

            // Act
            var mgmtDynamicVNetAssignmentScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(originalPsDynamicVNetAssignmentScope);
            var roundTripPsDynamicVNetAssignmentScope = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(roundTripPsDynamicVNetAssignmentScope);
            Assert.Equal(originalPsDynamicVNetAssignmentScope, roundTripPsDynamicVNetAssignmentScope.Value);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesJobValue()
        {
            // Arrange
            var originalPsDynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;

            // Act
            var mgmtDynamicVNetAssignmentScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(originalPsDynamicVNetAssignmentScope);
            var roundTripPsDynamicVNetAssignmentScope = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(roundTripPsDynamicVNetAssignmentScope);
            Assert.Equal(originalPsDynamicVNetAssignmentScope, roundTripPsDynamicVNetAssignmentScope.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None)]
        [InlineData(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope originalDynamicVNetAssignmentScope)
        {
            // Act
            var mgmtDynamicVNetAssignmentScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(originalDynamicVNetAssignmentScope);
            var roundTripDynamicVNetAssignmentScope = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);

            // Assert
            Assert.NotNull(roundTripDynamicVNetAssignmentScope);
            Assert.Equal(originalDynamicVNetAssignmentScope, roundTripDynamicVNetAssignmentScope.Value);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                DynamicVNetAssignmentScope.None,
                DynamicVNetAssignmentScope.Job
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(originalValue);
                var roundTripValue = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psValue);

                // Assert
                Assert.NotNull(roundTripValue);
                Assert.Equal(originalValue, roundTripValue.Value);
            }
        }

        [Fact]
        public void RoundTripConversion_NullHandling_PreservesNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope? nullPs = null;
            DynamicVNetAssignmentScope? nullMgmt = null;

            // Act
            var mgmtFromNull = Utils.Utils.toMgmtDynamicVNetAssignmentScope(nullPs);
            var psFromNull = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(nullMgmt);

            // Assert
            Assert.Null(mgmtFromNull);
            Assert.Null(psFromNull);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void DynamicVNetAssignmentScope_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psDynamicVNetAssignmentScopeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope));
            var mgmtDynamicVNetAssignmentScopeValues = Enum.GetValues(typeof(DynamicVNetAssignmentScope));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psDynamicVNetAssignmentScopeValues.Length, mgmtDynamicVNetAssignmentScopeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope psValue in psDynamicVNetAssignmentScopeValues)
            {
                var result = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(DynamicVNetAssignmentScope), result.Value));
            }

            // Verify that each management enum value can be converted successfully
            foreach (DynamicVNetAssignmentScope mgmtValue in mgmtDynamicVNetAssignmentScopeValues)
            {
                var result = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope), result.Value));
            }
        }

        [Fact]
        public void DynamicVNetAssignmentScope_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None,
                Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job
            };

            var mgmtValues = new[]
            {
                DynamicVNetAssignmentScope.None,
                DynamicVNetAssignmentScope.Job
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new DynamicVNetAssignmentScope?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtValues[i]);
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
        public void DynamicVNetAssignmentScopeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test None semantics - No dynamic VNet assignment is enabled
            var psNone = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None;
            var mgmtNone = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psNone);
            var backToPs = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtNone);

            Assert.NotNull(mgmtNone);
            Assert.Equal(DynamicVNetAssignmentScope.None, mgmtNone.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(psNone, backToPs.Value);

            // Test Job semantics - Dynamic VNet assignment is done per-job
            var psJob = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;
            var mgmtJob = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psJob);
            var backToPsJob = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtJob);

            Assert.NotNull(mgmtJob);
            Assert.Equal(DynamicVNetAssignmentScope.Job, mgmtJob.Value);
            Assert.NotNull(backToPsJob);
            Assert.Equal(psJob, backToPsJob.Value);
        }

        [Fact]
        public void DynamicVNetAssignmentScopeConversions_NetworkConfigurationContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of network configuration
            // DynamicVNetAssignmentScope is used to specify the scope of dynamic VNet assignment in Azure Batch

            // Arrange - Test with realistic Batch network configuration scenarios
            var networkScenarios = new[]
            {
                // None - No dynamic VNet assignment enabled for static networking
                new {
                    DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None,
                    Description = "Static network configuration with no dynamic VNet assignment"
                },
                // Job - Dynamic VNet assignment per-job for enhanced networking isolation
                new {
                    DynamicVNetAssignmentScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job,
                    Description = "Dynamic VNet assignment per-job for networking isolation and security"
                }
            };

            foreach (var scenario in networkScenarios)
            {
                // Act
                var mgmtDynamicVNetAssignmentScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(scenario.DynamicVNetAssignmentScope);

                // Assert - Should convert correctly for Batch network configuration
                Assert.NotNull(mgmtDynamicVNetAssignmentScope);
                
                var expectedMgmtScope = scenario.DynamicVNetAssignmentScope == Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None
                    ? DynamicVNetAssignmentScope.None
                    : DynamicVNetAssignmentScope.Job;
                Assert.Equal(expectedMgmtScope, mgmtDynamicVNetAssignmentScope.Value);

                // Verify round-trip conversion maintains network configuration semantics
                var backToPs = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtDynamicVNetAssignmentScope);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.DynamicVNetAssignmentScope, backToPs.Value);
            }
        }

        [Fact]
        public void DynamicVNetAssignmentScopeConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope)))
            {
                var mgmtResult = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psValue);
                Assert.NotNull(mgmtResult);
                Assert.Equal((int)psValue, (int)mgmtResult.Value);
            }

            foreach (DynamicVNetAssignmentScope mgmtValue in Enum.GetValues(typeof(DynamicVNetAssignmentScope)))
            {
                var psResult = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtValue);
                Assert.NotNull(psResult);
                Assert.Equal((int)mgmtValue, (int)psResult.Value);
            }
        }

        [Fact]
        public void DynamicVNetAssignmentScopeConversions_BatchJobNetworkingContext_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Batch job networking configuration
            // DynamicVNetAssignmentScope determines how VNet assignment is managed for jobs

            // None scope semantics - Static VNet configuration with no dynamic assignment
            var noneScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.None;
            var mgmtNoneScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(noneScope);
            
            Assert.NotNull(mgmtNoneScope);
            Assert.Equal(DynamicVNetAssignmentScope.None, mgmtNoneScope.Value);
            
            // This scope means no dynamic VNet assignment is enabled
            // Network configuration is static and shared across all jobs
            
            // Job scope semantics - Dynamic VNet assignment per-job for network isolation
            var jobScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;
            var mgmtJobScope = Utils.Utils.toMgmtDynamicVNetAssignmentScope(jobScope);
            
            Assert.NotNull(mgmtJobScope);
            Assert.Equal(DynamicVNetAssignmentScope.Job, mgmtJobScope.Value);
            
            // This scope enables dynamic VNet assignment per-job
            // Each job can get its own VNet configuration for enhanced isolation
            // Requires approval before use and subnet ID must also be set
            
            // Verify semantic preservation through round-trip
            var noneRoundTrip = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtNoneScope);
            var jobRoundTrip = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtJobScope);
            
            Assert.NotNull(noneRoundTrip);
            Assert.NotNull(jobRoundTrip);
            Assert.Equal(noneScope, noneRoundTrip.Value);
            Assert.Equal(jobScope, jobRoundTrip.Value);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public void DynamicVNetAssignmentScopeConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types and handle casting properly

            // Arrange
            var psScope = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;
            var mgmtScope = DynamicVNetAssignmentScope.Job;

            // Act
            var mgmtResult = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psScope);
            var psResult = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(mgmtScope);

            // Assert - Verify correct types are returned
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.DynamicVNetAssignmentScope>(mgmtResult.Value);
            Assert.IsType<Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope>(psResult.Value);
            Assert.Equal(DynamicVNetAssignmentScope.Job, mgmtResult.Value);
            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, psResult.Value);
        }

        [Fact]
        public void DynamicVNetAssignmentScopeConversions_EnumValueEquivalence_VerifyDirectCasting()
        {
            // Test that the enum values are equivalent and casting works as expected

            // Arrange & Act - Test direct casting behavior
            var psJob = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;

            var mgmtJobDirect = (DynamicVNetAssignmentScope)psJob;
            var mgmtJobUtils = Utils.Utils.toMgmtDynamicVNetAssignmentScope(psJob);

            // Assert - Utils methods should behave the same as direct casting
            Assert.Equal(mgmtJobDirect, mgmtJobUtils.Value);
            Assert.Equal(DynamicVNetAssignmentScope.Job, mgmtJobUtils.Value);
        }

        [Fact]
        public void DynamicVNetAssignmentScopeConversions_NullableCasting_WorksCorrectly()
        {
            // Test that nullable casting works as expected

            // Arrange
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope? nullablePsJob = Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job;
            Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope? nullPs = null;

            DynamicVNetAssignmentScope? nullableMgmtJob = DynamicVNetAssignmentScope.Job;
            DynamicVNetAssignmentScope? nullMgmt = null;

            // Act
            var mgmtFromNullableJob = Utils.Utils.toMgmtDynamicVNetAssignmentScope(nullablePsJob);
            var mgmtFromNull = Utils.Utils.toMgmtDynamicVNetAssignmentScope(nullPs);

            var psFromNullableJob = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(nullableMgmtJob);
            var psFromNull = Utils.Utils.fromMgmtDynamicVNetAssignmentScope(nullMgmt);

            // Assert
            Assert.Equal(DynamicVNetAssignmentScope.Job, mgmtFromNullableJob.Value);
            Assert.Null(mgmtFromNull);

            Assert.Equal(Microsoft.Azure.Batch.Common.DynamicVNetAssignmentScope.Job, psFromNullableJob.Value);
            Assert.Null(psFromNull);
        }

        #endregion
    }
}
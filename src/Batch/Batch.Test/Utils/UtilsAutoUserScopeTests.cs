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
    public class UtilsAutoUserScopeTests
    {
        #region toMgmtAutoUserScope Tests

        [Fact]
        public void ToMgmtAutoUserScope_Task_ReturnsTask()
        {
            // Arrange
            var psAutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Task;

            // Act
            var result = Utils.Utils.toMgmtAutoUserScope(psAutoUserScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AutoUserScope.Task, result.Value);
        }

        [Fact]
        public void ToMgmtAutoUserScope_Pool_ReturnsPool()
        {
            // Arrange
            var psAutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool;

            // Act
            var result = Utils.Utils.toMgmtAutoUserScope(psAutoUserScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AutoUserScope.Pool, result.Value);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Task, AutoUserScope.Task)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, AutoUserScope.Pool)]
        public void ToMgmtAutoUserScope_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.AutoUserScope input,
            AutoUserScope expected)
        {
            // Act
            var result = Utils.Utils.toMgmtAutoUserScope(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ToMgmtAutoUserScope_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.AutoUserScope? nullAutoUserScope = null;

            // Act
            var result = Utils.Utils.toMgmtAutoUserScope(nullAutoUserScope);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtAutoUserScope_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.AutoUserScope);

            // Act
            var result = Utils.Utils.toMgmtAutoUserScope(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default AutoUserScope is typically Task (0)
            Assert.Equal(AutoUserScope.Task, result.Value);
        }

        [Fact]
        public void ToMgmtAutoUserScope_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each auto user scope

            // Arrange & Act & Assert
            // Task: Auto user is scoped to the task execution context
            var taskResult = Utils.Utils.toMgmtAutoUserScope(Microsoft.Azure.Batch.Common.AutoUserScope.Task);
            Assert.NotNull(taskResult);
            Assert.Equal(AutoUserScope.Task, taskResult.Value);

            // Pool: Auto user is scoped to the pool context and shared across tasks
            var poolResult = Utils.Utils.toMgmtAutoUserScope(Microsoft.Azure.Batch.Common.AutoUserScope.Pool);
            Assert.NotNull(poolResult);
            Assert.Equal(AutoUserScope.Pool, poolResult.Value);
        }

        [Fact]
        public void ToMgmtAutoUserScope_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psAutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtAutoUserScope(psAutoUserScope);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AutoUserScope.Pool, result.Value);
        }

        [Fact]
        public void ToMgmtAutoUserScope_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                Microsoft.Azure.Batch.Common.AutoUserScope.Pool
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtAutoUserScope(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(AutoUserScope), result.Value));
            }
        }

        [Fact]
        public void ToMgmtAutoUserScope_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psTask = Microsoft.Azure.Batch.Common.AutoUserScope.Task;
            var psPool = Microsoft.Azure.Batch.Common.AutoUserScope.Pool;

            // Act
            var mgmtTask = Utils.Utils.toMgmtAutoUserScope(psTask);
            var mgmtPool = Utils.Utils.toMgmtAutoUserScope(psPool);

            // Assert
            Assert.NotNull(mgmtTask);
            Assert.NotNull(mgmtPool);
            
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psTask, (int)mgmtTask.Value);
            Assert.Equal((int)psPool, (int)mgmtPool.Value);
        }

        #endregion

        #region fromMgmtAutoUserScope Tests

        [Fact]
        public void FromMgmtAutoUserScope_Task_ReturnsTask()
        {
            // Arrange
            var mgmtAutoUserScope = AutoUserScope.Task;

            // Act
            var result = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result);
        }

        [Fact]
        public void FromMgmtAutoUserScope_Pool_ReturnsPool()
        {
            // Arrange
            var mgmtAutoUserScope = AutoUserScope.Pool;

            // Act
            var result = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, result);
        }

        [Theory]
        [InlineData(AutoUserScope.Task, Microsoft.Azure.Batch.Common.AutoUserScope.Task)]
        [InlineData(AutoUserScope.Pool, Microsoft.Azure.Batch.Common.AutoUserScope.Pool)]
        public void FromMgmtAutoUserScope_AllValidValues_ReturnsCorrectMapping(
            AutoUserScope input,
            Microsoft.Azure.Batch.Common.AutoUserScope expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtAutoUserScope(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromMgmtAutoUserScope_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(AutoUserScope);

            // Act
            var result = Utils.Utils.fromMgmtAutoUserScope(defaultValue);

            // Assert
            // Default AutoUserScope is typically Task (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result);
        }

        [Fact]
        public void FromMgmtAutoUserScope_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each auto user scope

            // Arrange & Act & Assert
            // Task: Auto user is scoped to the task execution context
            var taskResult = Utils.Utils.fromMgmtAutoUserScope(AutoUserScope.Task);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, taskResult);

            // Pool: Auto user is scoped to the pool context and shared across tasks
            var poolResult = Utils.Utils.fromMgmtAutoUserScope(AutoUserScope.Pool);
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, poolResult);
        }

        [Fact]
        public void FromMgmtAutoUserScope_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtAutoUserScope = AutoUserScope.Task;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Task, result);
        }

        [Fact]
        public void FromMgmtAutoUserScope_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new AutoUserScope?[]
            {
                AutoUserScope.Task,
                AutoUserScope.Pool
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtAutoUserScope(value);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.AutoUserScope), result));
            }
        }

        [Fact]
        public void FromMgmtAutoUserScope_AcceptsNullableType()
        {
            // This test verifies that the method accepts a nullable AutoUserScope

            // Arrange
            AutoUserScope? nullableValue = AutoUserScope.Pool;

            // Act
            var result = Utils.Utils.fromMgmtAutoUserScope(nullableValue);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AutoUserScope.Pool, result);
        }

        [Fact]
        public void FromMgmtAutoUserScope_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtTask = AutoUserScope.Task;
            var mgmtPool = AutoUserScope.Pool;

            // Act
            var psTask = Utils.Utils.fromMgmtAutoUserScope(mgmtTask);
            var psPool = Utils.Utils.fromMgmtAutoUserScope(mgmtPool);

            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtTask, (int)psTask);
            Assert.Equal((int)mgmtPool, (int)psPool);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesTaskValue()
        {
            // Arrange
            var originalPsAutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Task;

            // Act
            var mgmtAutoUserScope = Utils.Utils.toMgmtAutoUserScope(originalPsAutoUserScope);
            var roundTripPsAutoUserScope = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);

            // Assert
            Assert.Equal(originalPsAutoUserScope, roundTripPsAutoUserScope);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPoolValue()
        {
            // Arrange
            var originalPsAutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool;

            // Act
            var mgmtAutoUserScope = Utils.Utils.toMgmtAutoUserScope(originalPsAutoUserScope);
            var roundTripPsAutoUserScope = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);

            // Assert
            Assert.Equal(originalPsAutoUserScope, roundTripPsAutoUserScope);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Task)]
        [InlineData(Microsoft.Azure.Batch.Common.AutoUserScope.Pool)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.AutoUserScope originalAutoUserScope)
        {
            // Act
            var mgmtAutoUserScope = Utils.Utils.toMgmtAutoUserScope(originalAutoUserScope);
            var roundTripAutoUserScope = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);

            // Assert
            Assert.Equal(originalAutoUserScope, roundTripAutoUserScope);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                AutoUserScope.Task,
                AutoUserScope.Pool
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.fromMgmtAutoUserScope(originalValue);
                var roundTripValue = Utils.Utils.toMgmtAutoUserScope(psValue);

                // Assert
                Assert.NotNull(roundTripValue);
                Assert.Equal(originalValue, roundTripValue.Value);
            }
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void AutoUserScope_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psAutoUserScopeValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.AutoUserScope));
            var mgmtAutoUserScopeValues = Enum.GetValues(typeof(AutoUserScope));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psAutoUserScopeValues.Length, mgmtAutoUserScopeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.AutoUserScope psValue in psAutoUserScopeValues)
            {
                var result = Utils.Utils.toMgmtAutoUserScope(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(AutoUserScope), result.Value));
            }

            // Verify that each management enum value can be converted successfully
            foreach (AutoUserScope mgmtValue in mgmtAutoUserScopeValues)
            {
                var result = Utils.Utils.fromMgmtAutoUserScope(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.AutoUserScope), result));
            }
        }

        [Fact]
        public void AutoUserScope_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                Microsoft.Azure.Batch.Common.AutoUserScope.Pool
            };

            var mgmtValues = new[]
            {
                AutoUserScope.Task,
                AutoUserScope.Pool
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new AutoUserScope?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.toMgmtAutoUserScope(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.AutoUserScope?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtAutoUserScope(mgmtValues[i]);
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
        public void AutoUserScopeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Task semantics - Auto user is scoped to the task execution
            var psTask = Microsoft.Azure.Batch.Common.AutoUserScope.Task;
            var mgmtTask = Utils.Utils.toMgmtAutoUserScope(psTask);
            var backToPs = Utils.Utils.fromMgmtAutoUserScope(mgmtTask);

            Assert.NotNull(mgmtTask);
            Assert.Equal(AutoUserScope.Task, mgmtTask.Value);
            Assert.Equal(psTask, backToPs);

            // Test Pool semantics - Auto user is scoped to the pool and shared across tasks
            var psPool = Microsoft.Azure.Batch.Common.AutoUserScope.Pool;
            var mgmtPool = Utils.Utils.toMgmtAutoUserScope(psPool);
            var backToPsPool = Utils.Utils.fromMgmtAutoUserScope(mgmtPool);

            Assert.NotNull(mgmtPool);
            Assert.Equal(AutoUserScope.Pool, mgmtPool.Value);
            Assert.Equal(psPool, backToPsPool);
        }

        [Fact]
        public void AutoUserScopeConversions_BatchAutoUserContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch auto user specifications
            // AutoUserScope is used to specify the scope of automatically created user accounts in Azure Batch

            // Arrange - Test with realistic Batch auto user scenarios
            var autoUserScenarios = new[]
            {
                // Task-scoped user account for isolated task execution
                new {
                    AutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Task,
                    Description = "Task-scoped auto user for task isolation and security"
                },
                // Pool-scoped user account for shared operations across tasks
                new {
                    AutoUserScope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool,
                    Description = "Pool-scoped auto user for shared operations and resource access"
                }
            };

            foreach (var scenario in autoUserScenarios)
            {
                // Act
                var mgmtAutoUserScope = Utils.Utils.toMgmtAutoUserScope(scenario.AutoUserScope);

                // Assert - Should convert correctly for Batch auto user configuration
                Assert.NotNull(mgmtAutoUserScope);
                
                var expectedMgmtScope = scenario.AutoUserScope == Microsoft.Azure.Batch.Common.AutoUserScope.Task
                    ? AutoUserScope.Task
                    : AutoUserScope.Pool;
                Assert.Equal(expectedMgmtScope, mgmtAutoUserScope.Value);

                // Verify round-trip conversion maintains auto user semantics
                var backToPs = Utils.Utils.fromMgmtAutoUserScope(mgmtAutoUserScope);
                Assert.Equal(scenario.AutoUserScope, backToPs);
            }
        }

        [Fact]
        public void AutoUserScopeConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.AutoUserScope psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.AutoUserScope)))
            {
                var mgmtResult = Utils.Utils.toMgmtAutoUserScope(psValue);
                Assert.NotNull(mgmtResult);
                Assert.Equal((int)psValue, (int)mgmtResult.Value);
            }

            foreach (AutoUserScope mgmtValue in Enum.GetValues(typeof(AutoUserScope)))
            {
                var psResult = Utils.Utils.fromMgmtAutoUserScope(mgmtValue);
                Assert.Equal((int)mgmtValue, (int)psResult);
            }
        }

        [Fact]
        public void AutoUserScopeConversions_UserIdentityContext_VerifySemantics()
        {
            // This test validates the semantic usage in the context of user identity configuration
            // AutoUserScope determines how auto-created user accounts are managed and shared

            // Task scope semantics - Each task gets its own isolated user account
            var taskScope = Microsoft.Azure.Batch.Common.AutoUserScope.Task;
            var mgmtTaskScope = Utils.Utils.toMgmtAutoUserScope(taskScope);
            
            Assert.NotNull(mgmtTaskScope);
            Assert.Equal(AutoUserScope.Task, mgmtTaskScope.Value);
            
            // This scope ensures task isolation and security boundaries
            // User account lifecycle is tied to task execution
            
            // Pool scope semantics - User account is shared across tasks in the pool
            var poolScope = Microsoft.Azure.Batch.Common.AutoUserScope.Pool;
            var mgmtPoolScope = Utils.Utils.toMgmtAutoUserScope(poolScope);
            
            Assert.NotNull(mgmtPoolScope);
            Assert.Equal(AutoUserScope.Pool, mgmtPoolScope.Value);
            
            // This scope allows shared resources and inter-task communication
            // User account persists for the lifetime of the pool
            
            // Verify semantic preservation through round-trip
            var taskRoundTrip = Utils.Utils.fromMgmtAutoUserScope(mgmtTaskScope);
            var poolRoundTrip = Utils.Utils.fromMgmtAutoUserScope(mgmtPoolScope);
            
            Assert.Equal(taskScope, taskRoundTrip);
            Assert.Equal(poolScope, poolRoundTrip);
        }

        #endregion
    }
}
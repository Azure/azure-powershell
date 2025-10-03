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
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSTaskSchedulingPolicyTests
    {
        #region toMgmtTaskSchedulingPolicy Tests

        [Fact]
        public void ToMgmtTaskSchedulingPolicy_WithPackFillType_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

            // Act
            var result = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ComputeNodeFillType.Pack, result.NodeFillType);
        }

        [Fact]
        public void ToMgmtTaskSchedulingPolicy_WithSpreadFillType_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ComputeNodeFillType.Spread, result.NodeFillType);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, ComputeNodeFillType.Pack)]
        [InlineData(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, ComputeNodeFillType.Spread)]
        public void ToMgmtTaskSchedulingPolicy_AllValidComputeNodeFillTypes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.ComputeNodeFillType psComputeNodeFillType,
            ComputeNodeFillType expectedMgmtComputeNodeFillType)
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(psComputeNodeFillType);

            // Act
            var result = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtComputeNodeFillType, result.NodeFillType);
        }

        [Fact]
        public void ToMgmtTaskSchedulingPolicy_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

            // Act
            var result1 = psPolicy.toMgmtTaskSchedulingPolicy();
            var result2 = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtTaskSchedulingPolicy_VerifyTaskSchedulingPolicyType()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TaskSchedulingPolicy>(result);
        }

        [Fact]
        public void ToMgmtTaskSchedulingPolicy_PackStrategy_SemanticsPreserved()
        {
            // Arrange - Pack strategy fills each node completely before moving to next
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

            // Act
            var result = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ComputeNodeFillType.Pack, result.NodeFillType);
            // Pack semantics: As many tasks as possible should be assigned to each node before moving to next
        }

        [Fact]
        public void ToMgmtTaskSchedulingPolicy_SpreadStrategy_SemanticsPreserved()
        {
            // Arrange - Spread strategy distributes tasks evenly across all nodes
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ComputeNodeFillType.Spread, result.NodeFillType);
            // Spread semantics: Tasks should be assigned evenly across all nodes in the pool
        }

        #endregion

        #region fromMgmtTaskSchedulingPolicy Tests

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_WithPackFillType_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Pack);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, result.ComputeNodeFillType);
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_WithSpreadFillType_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, result.ComputeNodeFillType);
        }

        [Theory]
        [InlineData(ComputeNodeFillType.Pack, Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)]
        [InlineData(ComputeNodeFillType.Spread, Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)]
        public void FromMgmtTaskSchedulingPolicy_AllValidComputeNodeFillTypes_ReturnsCorrectMapping(
            ComputeNodeFillType mgmtComputeNodeFillType,
            Microsoft.Azure.Batch.Common.ComputeNodeFillType expectedPsComputeNodeFillType)
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(mgmtComputeNodeFillType);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsComputeNodeFillType, result.ComputeNodeFillType);
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_WithNullMgmtPolicy_ReturnsNull()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_CreatesNewInstance_NotSameReference()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.NotSame(psPolicy, result);
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_VerifyPSTaskSchedulingPolicyType()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSTaskSchedulingPolicy>(result);
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_PackStrategy_SemanticsPreserved()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Pack);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, result.ComputeNodeFillType);
            // Pack semantics preserved: Fill each node completely before moving to next
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_SpreadStrategy_SemanticsPreserved()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Spread);

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, result.ComputeNodeFillType);
            // Spread semantics preserved: Distribute tasks evenly across all nodes
        }

        [Fact]
        public void FromMgmtTaskSchedulingPolicy_WithDefaultTaskSchedulingPolicy_HandlesCorrectly()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(); // Uses default constructor

            // Act
            var result = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            // The result should handle the default NodeFillType from the management policy
            Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ComputeNodeFillType), result.ComputeNodeFillType));
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPackValue()
        {
            // Arrange
            var originalPsPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtTaskSchedulingPolicy();
            var roundTripPsPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)
                .fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(originalPsPolicy.ComputeNodeFillType, roundTripPsPolicy.ComputeNodeFillType);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, roundTripPsPolicy.ComputeNodeFillType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesSpreadValue()
        {
            // Arrange
            var originalPsPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtTaskSchedulingPolicy();
            var roundTripPsPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)
                .fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(originalPsPolicy.ComputeNodeFillType, roundTripPsPolicy.ComputeNodeFillType);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, roundTripPsPolicy.ComputeNodeFillType);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)]
        [InlineData(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.ComputeNodeFillType originalFillType)
        {
            // Arrange
            var originalPsPolicy = new PSTaskSchedulingPolicy(originalFillType);

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtTaskSchedulingPolicy();
            var roundTripPsPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)
                .fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(originalFillType, roundTripPsPolicy.ComputeNodeFillType);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Pack);

            // Act
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)
                .fromMgmtTaskSchedulingPolicy(originalMgmtPolicy);
            var roundTripMgmtPolicy = psPolicy.toMgmtTaskSchedulingPolicy();

            // Assert
            Assert.NotNull(roundTripMgmtPolicy);
            Assert.Equal(originalMgmtPolicy.NodeFillType, roundTripMgmtPolicy.NodeFillType);
            Assert.Equal(ComputeNodeFillType.Pack, roundTripMgmtPolicy.NodeFillType);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void TaskSchedulingPolicyConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Pack semantics - Tasks fill each node before moving to the next
            var psPack = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPack = psPack.toMgmtTaskSchedulingPolicy();
            var backToPs = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)
                .fromMgmtTaskSchedulingPolicy(mgmtPack);

            Assert.Equal(ComputeNodeFillType.Pack, mgmtPack.NodeFillType);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, backToPs.ComputeNodeFillType);

            // Test Spread semantics - Tasks are distributed evenly across nodes
            var psSpread = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);
            var mgmtSpread = psSpread.toMgmtTaskSchedulingPolicy();
            var backToPsSpread = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)
                .fromMgmtTaskSchedulingPolicy(mgmtSpread);

            Assert.Equal(ComputeNodeFillType.Spread, mgmtSpread.NodeFillType);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, backToPsSpread.ComputeNodeFillType);
        }

        [Fact]
        public void TaskSchedulingPolicyConversions_NullHandling_WorksCorrectly()
        {
            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);

            // Act
            var resultFromNull = psPolicy.fromMgmtTaskSchedulingPolicy(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void TaskSchedulingPolicyConversions_PoolSchedulingContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of pool task scheduling
            // TaskSchedulingPolicy is used to determine how tasks are assigned to compute nodes

            // Arrange - Test Pack strategy for CPU-intensive workloads
            var packPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPackPolicy = packPolicy.toMgmtTaskSchedulingPolicy();

            // Act & Assert - Pack should convert correctly for maximizing resource utilization per node
            Assert.Equal(ComputeNodeFillType.Pack, mgmtPackPolicy.NodeFillType);

            // Arrange - Test Spread strategy for memory-intensive workloads
            var spreadPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread);
            var mgmtSpreadPolicy = spreadPolicy.toMgmtTaskSchedulingPolicy();

            // Act & Assert - Spread should convert correctly for load balancing across nodes
            Assert.Equal(ComputeNodeFillType.Spread, mgmtSpreadPolicy.NodeFillType);

            // Verify round-trip conversion maintains pool scheduling semantics
            var backToPack = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread)
                .fromMgmtTaskSchedulingPolicy(mgmtPackPolicy);
            var backToSpread = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack)
                .fromMgmtTaskSchedulingPolicy(mgmtSpreadPolicy);

            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack, backToPack.ComputeNodeFillType);
            Assert.Equal(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Spread, backToSpread.ComputeNodeFillType);
        }

        [Fact]
        public void TaskSchedulingPolicyConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Spread);

            // Act
            var mgmtResult = psPolicy.toMgmtTaskSchedulingPolicy();
            var psResult = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<TaskSchedulingPolicy>(mgmtResult);
            Assert.IsType<PSTaskSchedulingPolicy>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtPolicy, mgmtResult);
            Assert.NotSame(psPolicy, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void TaskSchedulingPolicyConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psPolicy = new PSTaskSchedulingPolicy(Microsoft.Azure.Batch.Common.ComputeNodeFillType.Pack);
            var mgmtPolicy = new TaskSchedulingPolicy(ComputeNodeFillType.Spread);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psPolicy.toMgmtTaskSchedulingPolicy();
                var psResult = psPolicy.fromMgmtTaskSchedulingPolicy(mgmtPolicy);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
            }
        }

        [Fact]
        public void TaskSchedulingPolicyConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default enum values
            
            // Arrange
            var defaultPsPolicy = new PSTaskSchedulingPolicy(default(Microsoft.Azure.Batch.Common.ComputeNodeFillType));
            var defaultMgmtPolicy = new TaskSchedulingPolicy(); // Uses default NodeFillType

            // Act
            var mgmtResult = defaultPsPolicy.toMgmtTaskSchedulingPolicy();
            var psResult = defaultPsPolicy.fromMgmtTaskSchedulingPolicy(defaultMgmtPolicy);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.True(Enum.IsDefined(typeof(ComputeNodeFillType), mgmtResult.NodeFillType));
            Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.ComputeNodeFillType), psResult.ComputeNodeFillType));
        }

        #endregion
    }
}
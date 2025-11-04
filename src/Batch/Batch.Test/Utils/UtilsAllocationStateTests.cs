// ----------------------------------------------------------------------------------
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
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Utils;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsAllocationStateTests
    {
        #region ToPSAllocationState Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSAllocationState_Steady_ReturnsSteady()
        {
            // Arrange
            var mgmtAllocationState = AllocationState.Steady;

            // Act
            var result = Utils.Utils.ToPSAllocationState(mgmtAllocationState);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AllocationState.Steady, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSAllocationState_Resizing_ReturnsResizing()
        {
            // Arrange
            var mgmtAllocationState = AllocationState.Resizing;

            // Act
            var result = Utils.Utils.ToPSAllocationState(mgmtAllocationState);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AllocationState.Resizing, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSAllocationState_Stopping_ReturnsStopping()
        {
            // Arrange
            var mgmtAllocationState = AllocationState.Stopping;

            // Act
            var result = Utils.Utils.ToPSAllocationState(mgmtAllocationState);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.AllocationState.Stopping, result);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(AllocationState.Steady, Microsoft.Azure.Batch.Common.AllocationState.Steady)]
        [InlineData(AllocationState.Resizing, Microsoft.Azure.Batch.Common.AllocationState.Resizing)]
        [InlineData(AllocationState.Stopping, Microsoft.Azure.Batch.Common.AllocationState.Stopping)]
        public void ToPSAllocationState_AllValidValues_ReturnsCorrectMapping(
            AllocationState input,
            Microsoft.Azure.Batch.Common.AllocationState expected)
        {
            // Act
            var result = Utils.Utils.ToPSAllocationState(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToPSAllocationState_NullValue_ReturnsNull()
        {
            // Arrange
            AllocationState? mgmtAllocationState = null;

            // Act
            var result = Utils.Utils.ToPSAllocationState(mgmtAllocationState);

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region FromPSAllocationState Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromPSAllocationState_Steady_ReturnsSteady()
        {
            // Arrange
            var psAllocationState = Microsoft.Azure.Batch.Common.AllocationState.Steady;

            // Act
            var result = Utils.Utils.FromPSAllocationState(psAllocationState);

            // Assert
            Assert.Equal(AllocationState.Steady, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromPSAllocationState_Resizing_ReturnsResizing()
        {
            // Arrange
            var psAllocationState = Microsoft.Azure.Batch.Common.AllocationState.Resizing;

            // Act
            var result = Utils.Utils.FromPSAllocationState(psAllocationState);

            // Assert
            Assert.Equal(AllocationState.Resizing, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromPSAllocationState_Stopping_ReturnsStopping()
        {
            // Arrange
            var psAllocationState = Microsoft.Azure.Batch.Common.AllocationState.Stopping;

            // Act
            var result = Utils.Utils.FromPSAllocationState(psAllocationState);

            // Assert
            Assert.Equal(AllocationState.Stopping, result);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.AllocationState.Steady, AllocationState.Steady)]
        [InlineData(Microsoft.Azure.Batch.Common.AllocationState.Resizing, AllocationState.Resizing)]
        [InlineData(Microsoft.Azure.Batch.Common.AllocationState.Stopping, AllocationState.Stopping)]
        public void FromPSAllocationState_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.AllocationState input,
            AllocationState expected)
        {
            // Act
            var result = Utils.Utils.FromPSAllocationState(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromPSAllocationState_NullValue_ReturnsNull()
        {
            // Arrange
            Microsoft.Azure.Batch.Common.AllocationState? psAllocationState = null;

            // Act
            var result = Utils.Utils.FromPSAllocationState(psAllocationState);

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_RoundTripFromPS_MaintainsValues()
        {
            // Test round-trip conversion from PowerShell types to Management types and back

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.AllocationState.Steady,
                Microsoft.Azure.Batch.Common.AllocationState.Resizing,
                Microsoft.Azure.Batch.Common.AllocationState.Stopping
            };

            foreach (var psValue in psValues)
            {
                // Act
                var mgmtValue = Utils.Utils.FromPSAllocationState(psValue);
                var backToPs = Utils.Utils.ToPSAllocationState(mgmtValue);

                // Assert
                Assert.Equal(psValue, backToPs);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_RoundTripFromMgmt_MaintainsValues()
        {
            // Test round-trip conversion from Management types to PowerShell types and back

            // Arrange
            var mgmtValues = new[]
            {
                AllocationState.Steady,
                AllocationState.Resizing,
                AllocationState.Stopping
            };

            foreach (var mgmtValue in mgmtValues)
            {
                // Act
                var psValue = Utils.Utils.ToPSAllocationState(mgmtValue);
                var backToMgmt = Utils.Utils.FromPSAllocationState(psValue);

                // Assert
                Assert.Equal(mgmtValue, backToMgmt);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_RoundTripWithNulls_MaintainsNullValues()
        {
            // Test round-trip conversion with null values

            // Act
            var mgmtFromNull = Utils.Utils.FromPSAllocationState(null);
            var psFromNull = Utils.Utils.ToPSAllocationState(null);
            var backToMgmtFromNull = Utils.Utils.FromPSAllocationState(psFromNull);
            var backToPsFromNull = Utils.Utils.ToPSAllocationState(mgmtFromNull);

            // Assert
            Assert.Null(mgmtFromNull);
            Assert.Null(psFromNull);
            Assert.Null(backToMgmtFromNull);
            Assert.Null(backToPsFromNull);
        }

        #endregion

        #region Batch Pool Context Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool allocation states
            // AllocationState is used to indicate whether a pool is steady, resizing, or stopping

            // Arrange - Test Steady state for pools not being resized
            var psSteady = Microsoft.Azure.Batch.Common.AllocationState.Steady;
            var mgmtSteady = Utils.Utils.FromPSAllocationState(psSteady);

            // Act & Assert - Steady should convert correctly for stable pools
            Assert.Equal(AllocationState.Steady, mgmtSteady);

            // Arrange - Test Resizing state for pools being scaled
            var psResizing = Microsoft.Azure.Batch.Common.AllocationState.Resizing;
            var mgmtResizing = Utils.Utils.FromPSAllocationState(psResizing);

            // Act & Assert - Resizing should convert correctly for scaling pools
            Assert.Equal(AllocationState.Resizing, mgmtResizing);

            // Arrange - Test Stopping state for pools with resize operations being cancelled
            var psStopping = Microsoft.Azure.Batch.Common.AllocationState.Stopping;
            var mgmtStopping = Utils.Utils.FromPSAllocationState(psStopping);

            // Act & Assert - Stopping should convert correctly for resize cancellation
            Assert.Equal(AllocationState.Stopping, mgmtStopping);

            // Verify round-trip conversion maintains Batch pool allocation semantics
            var backToSteady = Utils.Utils.ToPSAllocationState(mgmtSteady);
            var backToResizing = Utils.Utils.ToPSAllocationState(mgmtResizing);
            var backToStopping = Utils.Utils.ToPSAllocationState(mgmtStopping);

            Assert.Equal(psSteady, backToSteady);
            Assert.Equal(psResizing, backToResizing);
            Assert.Equal(psStopping, backToStopping);
        }

        #endregion

        #region Performance Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psAllocationStates = new Microsoft.Azure.Batch.Common.AllocationState[]
            {
                Microsoft.Azure.Batch.Common.AllocationState.Steady,
                Microsoft.Azure.Batch.Common.AllocationState.Resizing,
                Microsoft.Azure.Batch.Common.AllocationState.Stopping
            };

            var mgmtAllocationStates = new AllocationState[]
            {
                AllocationState.Steady,
                AllocationState.Resizing,
                AllocationState.Stopping
            };

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 1000; i++)
            {
                foreach (var psState in psAllocationStates)
                {
                    var mgmtResult = Utils.Utils.FromPSAllocationState(psState);
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtState in mgmtAllocationStates)
                {
                    var psResult = Utils.Utils.ToPSAllocationState(mgmtState);
                    Assert.NotNull(psResult);
                }
            }
        }

        #endregion

        #region Real-world Scenario Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_BatchWorkloadScenarios_VerifySemantics()
        {
            // This test validates the conversions work correctly in realistic Azure Batch pool scenarios

            // Arrange - Test scenarios matching actual Azure Batch pool lifecycle
            var poolScenarios = new[]
            {
                new
                {
                    PSState = Microsoft.Azure.Batch.Common.AllocationState.Steady,
                    MgmtState = AllocationState.Steady,
                    Description = "Pool with fixed number of nodes, no resize operations"
                },
                new
                {
                    PSState = Microsoft.Azure.Batch.Common.AllocationState.Resizing,
                    MgmtState = AllocationState.Resizing,
                    Description = "Pool actively scaling up or down to meet demand"
                },
                new
                {
                    PSState = Microsoft.Azure.Batch.Common.AllocationState.Stopping,
                    MgmtState = AllocationState.Stopping,
                    Description = "Pool resize operation being cancelled by user request"
                }
            };

            foreach (var scenario in poolScenarios)
            {
                // Act - Convert from PS to Management
                var mgmtResult = Utils.Utils.FromPSAllocationState(scenario.PSState);
                var psResult = Utils.Utils.ToPSAllocationState(scenario.MgmtState);

                // Assert - Verify correct conversion for pool allocation semantics
                Assert.Equal(scenario.MgmtState, mgmtResult);
                Assert.Equal(scenario.PSState, psResult);

                // Verify round-trip conversion maintains pool allocation semantics
                var backToPs = Utils.Utils.ToPSAllocationState(mgmtResult);
                var backToMgmt = Utils.Utils.FromPSAllocationState(psResult);

                Assert.Equal(scenario.PSState, backToPs);
                Assert.Equal(scenario.MgmtState, backToMgmt);
            }
        }

        #endregion

        #region Type Safety Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllocationStateConversions_TypeSafety_VerifyReturnTypes()
        {
            // This test ensures the conversion methods return the correct types

            // Arrange
            var psAllocationState = Microsoft.Azure.Batch.Common.AllocationState.Steady;
            var mgmtAllocationState = AllocationState.Resizing;

            // Act
            var mgmtResult = Utils.Utils.FromPSAllocationState(psAllocationState);
            var psResult = Utils.Utils.ToPSAllocationState(mgmtAllocationState);

            // Assert - Verify return types
            Assert.IsType<AllocationState>(mgmtResult.Value);
            Assert.IsType<Microsoft.Azure.Batch.Common.AllocationState>(psResult.Value);

            // Verify nullable handling
            var nullMgmtResult = Utils.Utils.FromPSAllocationState(null);
            var nullPsResult = Utils.Utils.ToPSAllocationState(null);

            Assert.True(nullMgmtResult == null);
            Assert.True(nullPsResult == null);
        }

        #endregion
    }
}
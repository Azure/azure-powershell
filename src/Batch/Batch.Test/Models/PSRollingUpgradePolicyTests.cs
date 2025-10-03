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
    public class PSRollingUpgradePolicyTests
    {
        #region toMgmtRollingUpgradePolicy Tests

        [Fact]
        public void ToMgmtRollingUpgradePolicy_WithValidObject_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = true,
                MaxBatchInstancePercent = 20,
                MaxUnhealthyInstancePercent = 25,
                MaxUnhealthyUpgradedInstancePercent = 30,
                PauseTimeBetweenBatches = TimeSpan.FromMinutes(5),
                PrioritizeUnhealthyInstances = false,
                RollbackFailedInstancesOnPolicyBreach = true
            };

            // Act
            var result = psPolicy.toMgmtRollingUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableCrossZoneUpgrade);
            Assert.Equal(20, result.MaxBatchInstancePercent);
            Assert.Equal(25, result.MaxUnhealthyInstancePercent);
            Assert.Equal(30, result.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal("PT5M", result.PauseTimeBetweenBatches);
            Assert.Equal(false, result.PrioritizeUnhealthyInstances);
            Assert.Equal(true, result.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void ToMgmtRollingUpgradePolicy_WithNullValues_ReturnsObjectWithNullValues()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = null,
                MaxBatchInstancePercent = null,
                MaxUnhealthyInstancePercent = null,
                MaxUnhealthyUpgradedInstancePercent = null,
                PauseTimeBetweenBatches = null,
                PrioritizeUnhealthyInstances = null,
                RollbackFailedInstancesOnPolicyBreach = null
            };

            // Act
            var result = psPolicy.toMgmtRollingUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableCrossZoneUpgrade);
            Assert.Null(result.MaxBatchInstancePercent);
            Assert.Null(result.MaxUnhealthyInstancePercent);
            Assert.Null(result.MaxUnhealthyUpgradedInstancePercent);
            Assert.Null(result.PauseTimeBetweenBatches);
            Assert.Null(result.PrioritizeUnhealthyInstances);
            Assert.Null(result.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void ToMgmtRollingUpgradePolicy_WithNullOmObject_ReturnsNull()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            psPolicy.GetType().GetField("omObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(psPolicy, null);

            // Act
            var result = psPolicy.toMgmtRollingUpgradePolicy();

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(true, 10, 15, 20, false, true)]
        [InlineData(false, 50, 60, 70, true, false)]
        [InlineData(true, 100, 100, 100, true, true)]
        [InlineData(false, 5, 5, 0, false, false)]
        public void ToMgmtRollingUpgradePolicy_VariousValueCombinations_ReturnsCorrectMapping(
            bool enableCrossZone, int maxBatch, int maxUnhealthy, int maxUnhealthyUpgraded, bool prioritizeUnhealthy, bool rollbackFailed)
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = enableCrossZone,
                MaxBatchInstancePercent = maxBatch,
                MaxUnhealthyInstancePercent = maxUnhealthy,
                MaxUnhealthyUpgradedInstancePercent = maxUnhealthyUpgraded,
                PauseTimeBetweenBatches = TimeSpan.FromSeconds(30),
                PrioritizeUnhealthyInstances = prioritizeUnhealthy,
                RollbackFailedInstancesOnPolicyBreach = rollbackFailed
            };

            // Act
            var result = psPolicy.toMgmtRollingUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(enableCrossZone, result.EnableCrossZoneUpgrade);
            Assert.Equal(maxBatch, result.MaxBatchInstancePercent);
            Assert.Equal(maxUnhealthy, result.MaxUnhealthyInstancePercent);
            Assert.Equal(maxUnhealthyUpgraded, result.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal("PT30S", result.PauseTimeBetweenBatches);
            Assert.Equal(prioritizeUnhealthy, result.PrioritizeUnhealthyInstances);
            Assert.Equal(rollbackFailed, result.RollbackFailedInstancesOnPolicyBreach);
        }

        [Theory]
        [InlineData("00:00:30", "PT30S")]
        [InlineData("00:05:00", "PT5M")]
        [InlineData("01:00:00", "PT1H")]
        [InlineData("1.00:00:00", "P1D")]
        [InlineData("00:00:00", "PT0S")]
        public void ToMgmtRollingUpgradePolicy_TimeSpanConversion_ConvertsToISO8601Format(string timeSpanString, string expectedISO8601)
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy
            {
                PauseTimeBetweenBatches = TimeSpan.Parse(timeSpanString)
            };

            // Act
            var result = psPolicy.toMgmtRollingUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedISO8601, result.PauseTimeBetweenBatches);
        }

        #endregion

        #region fromMgmtRollingUpgradePolicy Tests

        [Fact]
        public void FromMgmtRollingUpgradePolicy_WithValidMgmtPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            var mgmtPolicy = new RollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = true,
                MaxBatchInstancePercent = 20,
                MaxUnhealthyInstancePercent = 25,
                MaxUnhealthyUpgradedInstancePercent = 30,
                PauseTimeBetweenBatches = "PT5M",
                PrioritizeUnhealthyInstances = false,
                RollbackFailedInstancesOnPolicyBreach = true
            };

            // Act
            var result = psPolicy.fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableCrossZoneUpgrade);
            Assert.Equal(20, result.MaxBatchInstancePercent);
            Assert.Equal(25, result.MaxUnhealthyInstancePercent);
            Assert.Equal(30, result.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal(TimeSpan.FromMinutes(5), result.PauseTimeBetweenBatches);
            Assert.Equal(false, result.PrioritizeUnhealthyInstances);
            Assert.Equal(true, result.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void FromMgmtRollingUpgradePolicy_WithNullMgmtPolicyValues_ReturnsObjectWithNullValues()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            var mgmtPolicy = new RollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = null,
                MaxBatchInstancePercent = null,
                MaxUnhealthyInstancePercent = null,
                MaxUnhealthyUpgradedInstancePercent = null,
                PauseTimeBetweenBatches = null,
                PrioritizeUnhealthyInstances = null,
                RollbackFailedInstancesOnPolicyBreach = null
            };

            // Act
            var result = psPolicy.fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableCrossZoneUpgrade);
            Assert.Null(result.MaxBatchInstancePercent);
            Assert.Null(result.MaxUnhealthyInstancePercent);
            Assert.Null(result.MaxUnhealthyUpgradedInstancePercent);
            Assert.Null(result.PauseTimeBetweenBatches);
            Assert.Null(result.PrioritizeUnhealthyInstances);
            Assert.Null(result.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void FromMgmtRollingUpgradePolicy_WithNullMgmtPolicy_ReturnsNull()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();

            // Act
            var result = psPolicy.fromMgmtRollingUpgradePolicy(null);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(true, 10, 15, 20, false, true)]
        [InlineData(false, 50, 60, 70, true, false)]
        [InlineData(true, 100, 100, 100, true, true)]
        [InlineData(false, 5, 5, 0, false, false)]
        public void FromMgmtRollingUpgradePolicy_VariousValueCombinations_ReturnsCorrectMapping(
            bool enableCrossZone, int maxBatch, int maxUnhealthy, int maxUnhealthyUpgraded, bool prioritizeUnhealthy, bool rollbackFailed)
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            var mgmtPolicy = new RollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = enableCrossZone,
                MaxBatchInstancePercent = maxBatch,
                MaxUnhealthyInstancePercent = maxUnhealthy,
                MaxUnhealthyUpgradedInstancePercent = maxUnhealthyUpgraded,
                PauseTimeBetweenBatches = "PT30S",
                PrioritizeUnhealthyInstances = prioritizeUnhealthy,
                RollbackFailedInstancesOnPolicyBreach = rollbackFailed
            };

            // Act
            var result = psPolicy.fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(enableCrossZone, result.EnableCrossZoneUpgrade);
            Assert.Equal(maxBatch, result.MaxBatchInstancePercent);
            Assert.Equal(maxUnhealthy, result.MaxUnhealthyInstancePercent);
            Assert.Equal(maxUnhealthyUpgraded, result.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal(TimeSpan.FromSeconds(30), result.PauseTimeBetweenBatches);
            Assert.Equal(prioritizeUnhealthy, result.PrioritizeUnhealthyInstances);
            Assert.Equal(rollbackFailed, result.RollbackFailedInstancesOnPolicyBreach);
        }

        [Theory]
        [InlineData("PT30S", "00:00:30")]
        [InlineData("PT5M", "00:05:00")]
        [InlineData("PT1H", "01:00:00")]
        [InlineData("P1D", "1.00:00:00")]
        [InlineData("PT0S", "00:00:00")]
        public void FromMgmtRollingUpgradePolicy_ISO8601Conversion_ConvertsToTimeSpan(string iso8601String, string expectedTimeSpanString)
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            var mgmtPolicy = new RollingUpgradePolicy
            {
                PauseTimeBetweenBatches = iso8601String
            };

            // Act
            var result = psPolicy.fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TimeSpan.Parse(expectedTimeSpanString), result.PauseTimeBetweenBatches);
        }

        [Fact]
        public void FromMgmtRollingUpgradePolicy_CreatesNewInstance_NotSameReference()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            var mgmtPolicy = new RollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = true,
                MaxBatchInstancePercent = 20,
                PauseTimeBetweenBatches = "PT5M"
            };

            // Act
            var result = psPolicy.fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.NotSame(psPolicy, result);
        }

        [Fact]
        public void FromMgmtRollingUpgradePolicy_InvalidTimeSpanFormat_ThrowsFormatException()
        {
            // Arrange
            var psPolicy = new PSRollingUpgradePolicy();
            var mgmtPolicy = new RollingUpgradePolicy
            {
                PauseTimeBetweenBatches = "invalid-timespan-format"
            };

            // Act & Assert
            Assert.Throws<FormatException>(() => psPolicy.fromMgmtRollingUpgradePolicy(mgmtPolicy));
        }

       #endregion

        #region Integration Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndBack_PreservesValues()
        {
            // Arrange
            var originalPsPolicy = new PSRollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = true,
                MaxBatchInstancePercent = 25,
                MaxUnhealthyInstancePercent = 30,
                MaxUnhealthyUpgradedInstancePercent = 35,
                PauseTimeBetweenBatches = TimeSpan.FromMinutes(10),
                PrioritizeUnhealthyInstances = false,
                RollbackFailedInstancesOnPolicyBreach = true
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtRollingUpgradePolicy();
            var roundTripPsPolicy = new PSRollingUpgradePolicy().fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(originalPsPolicy.EnableCrossZoneUpgrade, roundTripPsPolicy.EnableCrossZoneUpgrade);
            Assert.Equal(originalPsPolicy.MaxBatchInstancePercent, roundTripPsPolicy.MaxBatchInstancePercent);
            Assert.Equal(originalPsPolicy.MaxUnhealthyInstancePercent, roundTripPsPolicy.MaxUnhealthyInstancePercent);
            Assert.Equal(originalPsPolicy.MaxUnhealthyUpgradedInstancePercent, roundTripPsPolicy.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal(originalPsPolicy.PauseTimeBetweenBatches, roundTripPsPolicy.PauseTimeBetweenBatches);
            Assert.Equal(originalPsPolicy.PrioritizeUnhealthyInstances, roundTripPsPolicy.PrioritizeUnhealthyInstances);
            Assert.Equal(originalPsPolicy.RollbackFailedInstancesOnPolicyBreach, roundTripPsPolicy.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            var originalPsPolicy = new PSRollingUpgradePolicy
            {
                EnableCrossZoneUpgrade = null,
                MaxBatchInstancePercent = null,
                MaxUnhealthyInstancePercent = null,
                MaxUnhealthyUpgradedInstancePercent = null,
                PauseTimeBetweenBatches = null,
                PrioritizeUnhealthyInstances = null,
                RollbackFailedInstancesOnPolicyBreach = null
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtRollingUpgradePolicy();
            var roundTripPsPolicy = new PSRollingUpgradePolicy().fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Null(roundTripPsPolicy.EnableCrossZoneUpgrade);
            Assert.Null(roundTripPsPolicy.MaxBatchInstancePercent);
            Assert.Null(roundTripPsPolicy.MaxUnhealthyInstancePercent);
            Assert.Null(roundTripPsPolicy.MaxUnhealthyUpgradedInstancePercent);
            Assert.Null(roundTripPsPolicy.PauseTimeBetweenBatches);
            Assert.Null(roundTripPsPolicy.PrioritizeUnhealthyInstances);
            Assert.Null(roundTripPsPolicy.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void RoundTripConversion_ComplexTimeSpan_PreservesAccuracy()
        {
            // Arrange
            var complexTimeSpan = new TimeSpan(2, 3, 4, 5, 123); // 2 days, 3 hours, 4 minutes, 5 seconds, 123 milliseconds
            var originalPsPolicy = new PSRollingUpgradePolicy
            {
                PauseTimeBetweenBatches = complexTimeSpan
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtRollingUpgradePolicy();
            var roundTripPsPolicy = new PSRollingUpgradePolicy().fromMgmtRollingUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            // Note: ISO 8601 conversion may lose millisecond precision, so we check seconds precision
            Assert.Equal(originalPsPolicy.PauseTimeBetweenBatches.Value.Days, roundTripPsPolicy.PauseTimeBetweenBatches.Value.Days);
            Assert.Equal(originalPsPolicy.PauseTimeBetweenBatches.Value.Hours, roundTripPsPolicy.PauseTimeBetweenBatches.Value.Hours);
            Assert.Equal(originalPsPolicy.PauseTimeBetweenBatches.Value.Minutes, roundTripPsPolicy.PauseTimeBetweenBatches.Value.Minutes);
            Assert.Equal(originalPsPolicy.PauseTimeBetweenBatches.Value.Seconds, roundTripPsPolicy.PauseTimeBetweenBatches.Value.Seconds);
        }

        #endregion
    }
}
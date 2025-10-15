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
    public class PSAutomaticOSUpgradePolicyTests
    {
        #region toMgmtAutomaticOSUpgradePolicy Tests

        [Fact]
        public void ToMgmtAutomaticOSUpgradePolicy_WithValidObject_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = true,
                DisableAutomaticRollback = false,
                OsRollingUpgradeDeferral = true,
                UseRollingUpgradePolicy = false
            };

            // Act
            var result = psPolicy.toMgmtAutomaticOSUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableAutomaticOSUpgrade);
            Assert.Equal(false, result.DisableAutomaticRollback);
            Assert.Equal(true, result.OSRollingUpgradeDeferral);
            Assert.Equal(false, result.UseRollingUpgradePolicy);
        }

        [Fact]
        public void ToMgmtAutomaticOSUpgradePolicy_WithNullValues_ReturnsObjectWithNullValues()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = null,
                DisableAutomaticRollback = null,
                OsRollingUpgradeDeferral = null,
                UseRollingUpgradePolicy = null
            };

            // Act
            var result = psPolicy.toMgmtAutomaticOSUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableAutomaticOSUpgrade);
            Assert.Null(result.DisableAutomaticRollback);
            Assert.Null(result.OSRollingUpgradeDeferral);
            Assert.Null(result.UseRollingUpgradePolicy);
        }

        [Fact]
        public void ToMgmtAutomaticOSUpgradePolicy_WithNullOmObject_ReturnsNull()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();
            psPolicy.GetType().GetField("omObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(psPolicy, null);

            // Act
            var result = psPolicy.toMgmtAutomaticOSUpgradePolicy();

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(true, false, true, false)]
        [InlineData(false, true, false, true)]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ToMgmtAutomaticOSUpgradePolicy_VariousValueCombinations_ReturnsCorrectMapping(
            bool enableAutoUpgrade, bool disableRollback, bool osRollingDeferral, bool useRollingPolicy)
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = enableAutoUpgrade,
                DisableAutomaticRollback = disableRollback,
                OsRollingUpgradeDeferral = osRollingDeferral,
                UseRollingUpgradePolicy = useRollingPolicy
            };

            // Act
            var result = psPolicy.toMgmtAutomaticOSUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(enableAutoUpgrade, result.EnableAutomaticOSUpgrade);
            Assert.Equal(disableRollback, result.DisableAutomaticRollback);
            Assert.Equal(osRollingDeferral, result.OSRollingUpgradeDeferral);
            Assert.Equal(useRollingPolicy, result.UseRollingUpgradePolicy);
        }

        #endregion

        #region FromMgmtAutomaticOSUpgradePolicy Tests

        [Fact]
        public void FromMgmtAutomaticOSUpgradePolicy_WithValidMgmtPolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();
            var mgmtPolicy = new AutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = true,
                DisableAutomaticRollback = false,
                OSRollingUpgradeDeferral = true,
                UseRollingUpgradePolicy = false
            };

            // Act
            var result = psPolicy.ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.EnableAutomaticOSUpgrade);
            Assert.Equal(false, result.DisableAutomaticRollback);
            Assert.Equal(true, result.OsRollingUpgradeDeferral);
            Assert.Equal(false, result.UseRollingUpgradePolicy);
        }

        [Fact]
        public void FromMgmtAutomaticOSUpgradePolicy_WithNullMgmtPolicyValues_ReturnsObjectWithNullValues()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();
            var mgmtPolicy = new AutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = null,
                DisableAutomaticRollback = null,
                OSRollingUpgradeDeferral = null,
                UseRollingUpgradePolicy = null
            };

            // Act
            var result = psPolicy.ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.EnableAutomaticOSUpgrade);
            Assert.Null(result.DisableAutomaticRollback);
            Assert.Null(result.OsRollingUpgradeDeferral);
            Assert.Null(result.UseRollingUpgradePolicy);
        }

        [Fact]
        public void FromMgmtAutomaticOSUpgradePolicy_WithNullOmObject_ReturnsNull()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();

            // Act
            var result = psPolicy.ToPSAutomaticOSUpgradePolicy(null);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(true, false, true, false)]
        [InlineData(false, true, false, true)]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void FromMgmtAutomaticOSUpgradePolicy_VariousValueCombinations_ReturnsCorrectMapping(
            bool enableAutoUpgrade, bool disableRollback, bool osRollingDeferral, bool useRollingPolicy)
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();
            var mgmtPolicy = new AutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = enableAutoUpgrade,
                DisableAutomaticRollback = disableRollback,
                OSRollingUpgradeDeferral = osRollingDeferral,
                UseRollingUpgradePolicy = useRollingPolicy
            };

            // Act
            var result = psPolicy.ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(enableAutoUpgrade, result.EnableAutomaticOSUpgrade);
            Assert.Equal(disableRollback, result.DisableAutomaticRollback);
            Assert.Equal(osRollingDeferral, result.OsRollingUpgradeDeferral);
            Assert.Equal(useRollingPolicy, result.UseRollingUpgradePolicy);
        }

        [Fact]
        public void FromMgmtAutomaticOSUpgradePolicy_CreatesNewInstance_NotSameReference()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();
            var mgmtPolicy = new AutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = true,
                DisableAutomaticRollback = false,
                OSRollingUpgradeDeferral = true,
                UseRollingUpgradePolicy = false
            };

            // Act
            var result = psPolicy.ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.NotSame(psPolicy, result);
        }

        [Fact]
        public void FromMgmtAutomaticOSUpgradePolicy_PropertyNameMapping_CorrectlyMapsOSRollingUpgradeDeferral()
        {
            // Arrange
            var psPolicy = new PSAutomaticOSUpgradePolicy();
            var mgmtPolicy = new AutomaticOSUpgradePolicy
            {
                OSRollingUpgradeDeferral = true  // Management model uses "OS" prefix
            };

            // Act
            var result = psPolicy.ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(true, result.OsRollingUpgradeDeferral);  // PS model uses "Os" prefix
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndBack_PreservesValues()
        {
            // Arrange
            var originalPsPolicy = new PSAutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = true,
                DisableAutomaticRollback = false,
                OsRollingUpgradeDeferral = true,
                UseRollingUpgradePolicy = false
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtAutomaticOSUpgradePolicy();
            var roundTripPsPolicy = new PSAutomaticOSUpgradePolicy().ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(originalPsPolicy.EnableAutomaticOSUpgrade, roundTripPsPolicy.EnableAutomaticOSUpgrade);
            Assert.Equal(originalPsPolicy.DisableAutomaticRollback, roundTripPsPolicy.DisableAutomaticRollback);
            Assert.Equal(originalPsPolicy.OsRollingUpgradeDeferral, roundTripPsPolicy.OsRollingUpgradeDeferral);
            Assert.Equal(originalPsPolicy.UseRollingUpgradePolicy, roundTripPsPolicy.UseRollingUpgradePolicy);
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            var originalPsPolicy = new PSAutomaticOSUpgradePolicy
            {
                EnableAutomaticOSUpgrade = null,
                DisableAutomaticRollback = null,
                OsRollingUpgradeDeferral = null,
                UseRollingUpgradePolicy = null
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtAutomaticOSUpgradePolicy();
            var roundTripPsPolicy = new PSAutomaticOSUpgradePolicy().ToPSAutomaticOSUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Null(roundTripPsPolicy.EnableAutomaticOSUpgrade);
            Assert.Null(roundTripPsPolicy.DisableAutomaticRollback);
            Assert.Null(roundTripPsPolicy.OsRollingUpgradeDeferral);
            Assert.Null(roundTripPsPolicy.UseRollingUpgradePolicy);
        }

        #endregion
    }
}
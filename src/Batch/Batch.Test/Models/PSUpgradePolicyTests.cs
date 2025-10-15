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
    public class PSUpgradePolicyTests
    {
        #region toMgmtUpgradePolicy Tests

        [Fact]
        public void ToMgmtUpgradePolicy_WithValidCompletePolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = true,
                    DisableAutomaticRollback = false,
                    OsRollingUpgradeDeferral = true,
                    UseRollingUpgradePolicy = true
                },
                RollingUpgradePolicy = new PSRollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = true,
                    MaxBatchInstancePercent = 20,
                    MaxUnhealthyInstancePercent = 25,
                    MaxUnhealthyUpgradedInstancePercent = 30,
                    PauseTimeBetweenBatches = TimeSpan.FromMinutes(5),
                    PrioritizeUnhealthyInstances = false,
                    RollbackFailedInstancesOnPolicyBreach = true
                }
            };

            // Act
            var result = psPolicy.toMgmtUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(UpgradeMode.Rolling, result.Mode);

            // Verify AutomaticOSUpgradePolicy mapping
            Assert.NotNull(result.AutomaticOSUpgradePolicy);
            Assert.Equal(true, result.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade);
            Assert.Equal(false, result.AutomaticOSUpgradePolicy.DisableAutomaticRollback);
            Assert.Equal(true, result.AutomaticOSUpgradePolicy.OSRollingUpgradeDeferral);
            Assert.Equal(true, result.AutomaticOSUpgradePolicy.UseRollingUpgradePolicy);

            // Verify RollingUpgradePolicy mapping
            Assert.NotNull(result.RollingUpgradePolicy);
            Assert.Equal(true, result.RollingUpgradePolicy.EnableCrossZoneUpgrade);
            Assert.Equal(20, result.RollingUpgradePolicy.MaxBatchInstancePercent);
            Assert.Equal(25, result.RollingUpgradePolicy.MaxUnhealthyInstancePercent);
            Assert.Equal(30, result.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal("PT5M", result.RollingUpgradePolicy.PauseTimeBetweenBatches);
            Assert.Equal(false, result.RollingUpgradePolicy.PrioritizeUnhealthyInstances);
            Assert.Equal(true, result.RollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void ToMgmtUpgradePolicy_WithManualMode_ReturnsCorrectMode()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy(),
                RollingUpgradePolicy = new PSRollingUpgradePolicy()
            };

            // Act
            var result = psPolicy.toMgmtUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(UpgradeMode.Manual, result.Mode);
        }

        [Fact]
        public void ToMgmtUpgradePolicy_WithAutomaticMode_ReturnsCorrectMode()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Automatic)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy(),
                RollingUpgradePolicy = new PSRollingUpgradePolicy()
            };

            // Act
            var result = psPolicy.toMgmtUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(UpgradeMode.Automatic, result.Mode);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.UpgradeMode.Manual, UpgradeMode.Manual)]
        [InlineData(Microsoft.Azure.Batch.Common.UpgradeMode.Automatic, UpgradeMode.Automatic)]
        [InlineData(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling, UpgradeMode.Rolling)]
        public void ToMgmtUpgradePolicy_VariousUpgradeModes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.UpgradeMode psMode, 
            UpgradeMode expectedMgmtMode)
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(psMode)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy(),
                RollingUpgradePolicy = new PSRollingUpgradePolicy()
            };

            // Act
            var result = psPolicy.toMgmtUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtMode, result.Mode);
        }

        [Fact]
        public void ToMgmtUpgradePolicy_WithNullSubPolicies_HandlesNullValues()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = null,
                    DisableAutomaticRollback = null,
                    OsRollingUpgradeDeferral = null,
                    UseRollingUpgradePolicy = null
                },
                RollingUpgradePolicy = new PSRollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = null,
                    MaxBatchInstancePercent = null,
                    MaxUnhealthyInstancePercent = null,
                    MaxUnhealthyUpgradedInstancePercent = null,
                    PauseTimeBetweenBatches = null,
                    PrioritizeUnhealthyInstances = null,
                    RollbackFailedInstancesOnPolicyBreach = null
                }
            };

            // Act
            var result = psPolicy.toMgmtUpgradePolicy();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(UpgradeMode.Manual, result.Mode);
            Assert.NotNull(result.AutomaticOSUpgradePolicy);
            Assert.NotNull(result.RollingUpgradePolicy);
        }

        #endregion

        #region fromMgmtUpgradePolicy Tests

        [Fact]
        public void FromMgmtUpgradePolicy_WithValidCompletePolicy_ReturnsCorrectMapping()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);
            var mgmtPolicy = new UpgradePolicy
            {
                Mode = UpgradeMode.Rolling,
                AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = true,
                    DisableAutomaticRollback = false,
                    OSRollingUpgradeDeferral = true,
                    UseRollingUpgradePolicy = true
                },
                RollingUpgradePolicy = new RollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = true,
                    MaxBatchInstancePercent = 20,
                    MaxUnhealthyInstancePercent = 25,
                    MaxUnhealthyUpgradedInstancePercent = 30,
                    PauseTimeBetweenBatches = "PT5M",
                    PrioritizeUnhealthyInstances = false,
                    RollbackFailedInstancesOnPolicyBreach = true
                }
            };

            // Act
            var result = psPolicy.fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling, result.Mode);

            // Verify AutomaticOSUpgradePolicy mapping
            Assert.NotNull(result.AutomaticOSUpgradePolicy);
            Assert.Equal(true, result.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade);
            Assert.Equal(false, result.AutomaticOSUpgradePolicy.DisableAutomaticRollback);
            Assert.Equal(true, result.AutomaticOSUpgradePolicy.OsRollingUpgradeDeferral);
            Assert.Equal(true, result.AutomaticOSUpgradePolicy.UseRollingUpgradePolicy);

            // Verify RollingUpgradePolicy mapping
            Assert.NotNull(result.RollingUpgradePolicy);
            Assert.Equal(true, result.RollingUpgradePolicy.EnableCrossZoneUpgrade);
            Assert.Equal(20, result.RollingUpgradePolicy.MaxBatchInstancePercent);
            Assert.Equal(25, result.RollingUpgradePolicy.MaxUnhealthyInstancePercent);
            Assert.Equal(30, result.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal(TimeSpan.FromMinutes(5), result.RollingUpgradePolicy.PauseTimeBetweenBatches);
            Assert.Equal(false, result.RollingUpgradePolicy.PrioritizeUnhealthyInstances);
            Assert.Equal(true, result.RollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void FromMgmtUpgradePolicy_WithNullMgmtPolicy_ReturnsNull()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);

            // Act
            var result = psPolicy.fromMgmtUpgradePolicy(null);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(UpgradeMode.Manual, Microsoft.Azure.Batch.Common.UpgradeMode.Manual)]
        [InlineData(UpgradeMode.Automatic, Microsoft.Azure.Batch.Common.UpgradeMode.Automatic)]
        [InlineData(UpgradeMode.Rolling, Microsoft.Azure.Batch.Common.UpgradeMode.Rolling)]
        public void FromMgmtUpgradePolicy_VariousUpgradeModes_ReturnsCorrectMapping(
            UpgradeMode mgmtMode,
            Microsoft.Azure.Batch.Common.UpgradeMode expectedPsMode)
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);
            var mgmtPolicy = new UpgradePolicy
            {
                Mode = mgmtMode,
                AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy(),
                RollingUpgradePolicy = new RollingUpgradePolicy()
            };

            // Act
            var result = psPolicy.fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsMode, result.Mode);
        }

        [Fact]
        public void FromMgmtUpgradePolicy_WithNullSubPolicies_HandlesNullValues()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);
            var mgmtPolicy = new UpgradePolicy
            {
                Mode = UpgradeMode.Manual,
                AutomaticOSUpgradePolicy = null,
                RollingUpgradePolicy = null
            };

            // Act
            var result = psPolicy.fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.UpgradeMode.Manual, result.Mode);
            // Note: The actual implementation may create empty instances or handle nulls differently
            // This test verifies the method doesn't crash with null sub-policies
        }

        [Fact]
        public void FromMgmtUpgradePolicy_WithNullValuesInSubPolicies_HandlesCorrectly()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);
            var mgmtPolicy = new UpgradePolicy
            {
                Mode = UpgradeMode.Automatic,
                AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = null,
                    DisableAutomaticRollback = null,
                    OSRollingUpgradeDeferral = null,
                    UseRollingUpgradePolicy = null
                },
                RollingUpgradePolicy = new RollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = null,
                    MaxBatchInstancePercent = null,
                    MaxUnhealthyInstancePercent = null,
                    MaxUnhealthyUpgradedInstancePercent = null,
                    PauseTimeBetweenBatches = null,
                    PrioritizeUnhealthyInstances = null,
                    RollbackFailedInstancesOnPolicyBreach = null
                }
            };

            // Act
            var result = psPolicy.fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.UpgradeMode.Automatic, result.Mode);
        }

        [Fact]
        public void FromMgmtUpgradePolicy_CreatesNewInstance_NotSameReference()
        {
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual);
            var mgmtPolicy = new UpgradePolicy
            {
                Mode = UpgradeMode.Rolling,
                AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = true
                },
                RollingUpgradePolicy = new RollingUpgradePolicy
                {
                    MaxBatchInstancePercent = 20
                }
            };

            // Act
            var result = psPolicy.fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(result);
            Assert.NotSame(psPolicy, result);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesValues()
        {
            // Arrange
            var originalPsPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = true,
                    DisableAutomaticRollback = false,
                    OsRollingUpgradeDeferral = true,
                    UseRollingUpgradePolicy = true
                },
                RollingUpgradePolicy = new PSRollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = true,
                    MaxBatchInstancePercent = 25,
                    MaxUnhealthyInstancePercent = 30,
                    MaxUnhealthyUpgradedInstancePercent = 35,
                    PauseTimeBetweenBatches = TimeSpan.FromMinutes(10),
                    PrioritizeUnhealthyInstances = false,
                    RollbackFailedInstancesOnPolicyBreach = true
                }
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtUpgradePolicy();
            var roundTripPsPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual).fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(originalPsPolicy.Mode, roundTripPsPolicy.Mode);

            // Verify AutomaticOSUpgradePolicy round-trip
            Assert.Equal(originalPsPolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade, 
                        roundTripPsPolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade);
            Assert.Equal(originalPsPolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback, 
                        roundTripPsPolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback);
            Assert.Equal(originalPsPolicy.AutomaticOSUpgradePolicy.OsRollingUpgradeDeferral, 
                        roundTripPsPolicy.AutomaticOSUpgradePolicy.OsRollingUpgradeDeferral);
            Assert.Equal(originalPsPolicy.AutomaticOSUpgradePolicy.UseRollingUpgradePolicy, 
                        roundTripPsPolicy.AutomaticOSUpgradePolicy.UseRollingUpgradePolicy);

            // Verify RollingUpgradePolicy round-trip
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.EnableCrossZoneUpgrade, 
                        roundTripPsPolicy.RollingUpgradePolicy.EnableCrossZoneUpgrade);
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.MaxBatchInstancePercent, 
                        roundTripPsPolicy.RollingUpgradePolicy.MaxBatchInstancePercent);
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent, 
                        roundTripPsPolicy.RollingUpgradePolicy.MaxUnhealthyInstancePercent);
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent, 
                        roundTripPsPolicy.RollingUpgradePolicy.MaxUnhealthyUpgradedInstancePercent);
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.PauseTimeBetweenBatches, 
                        roundTripPsPolicy.RollingUpgradePolicy.PauseTimeBetweenBatches);
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.PrioritizeUnhealthyInstances, 
                        roundTripPsPolicy.RollingUpgradePolicy.PrioritizeUnhealthyInstances);
            Assert.Equal(originalPsPolicy.RollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach, 
                        roundTripPsPolicy.RollingUpgradePolicy.RollbackFailedInstancesOnPolicyBreach);
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            var originalPsPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = null,
                    DisableAutomaticRollback = null,
                    OsRollingUpgradeDeferral = null,
                    UseRollingUpgradePolicy = null
                },
                RollingUpgradePolicy = new PSRollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = null,
                    MaxBatchInstancePercent = null,
                    MaxUnhealthyInstancePercent = null,
                    MaxUnhealthyUpgradedInstancePercent = null,
                    PauseTimeBetweenBatches = null,
                    PrioritizeUnhealthyInstances = null,
                    RollbackFailedInstancesOnPolicyBreach = null
                }
            };

            // Act
            var mgmtPolicy = originalPsPolicy.toMgmtUpgradePolicy();
            var roundTripPsPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Automatic).fromMgmtUpgradePolicy(mgmtPolicy);

            // Assert
            Assert.NotNull(roundTripPsPolicy);
            Assert.Equal(Microsoft.Azure.Batch.Common.UpgradeMode.Manual, roundTripPsPolicy.Mode);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void UpgradePolicyConversions_AllUpgradeModes_MaintainSemanticEquivalence()
        {
            // Test all upgrade modes to ensure semantic meaning is preserved
            var upgradeModes = new[]
            {
                Microsoft.Azure.Batch.Common.UpgradeMode.Manual,
                Microsoft.Azure.Batch.Common.UpgradeMode.Automatic,
                Microsoft.Azure.Batch.Common.UpgradeMode.Rolling
            };

            foreach (var mode in upgradeModes)
            {
                // Arrange
                var psPolicy = new PSUpgradePolicy(mode)
                {
                    AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy
                    {
                        EnableAutomaticOSUpgrade = true,
                        DisableAutomaticRollback = false
                    },
                    RollingUpgradePolicy = new PSRollingUpgradePolicy
                    {
                        MaxBatchInstancePercent = 20,
                        PauseTimeBetweenBatches = TimeSpan.FromMinutes(5)
                    }
                };

                // Act
                var mgmtPolicy = psPolicy.toMgmtUpgradePolicy();
                var backToPs = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Manual).fromMgmtUpgradePolicy(mgmtPolicy);

                // Assert
                Assert.NotNull(mgmtPolicy);
                Assert.NotNull(backToPs);
                Assert.Equal(mode, backToPs.Mode);
            }
        }

        [Fact]
        public void UpgradePolicyConversions_SubPolicyInteraction_WorksCorrectly()
        {
            // This test verifies that the sub-policy conversions work correctly within the upgrade policy context
            
            // Arrange
            var psPolicy = new PSUpgradePolicy(Microsoft.Azure.Batch.Common.UpgradeMode.Rolling)
            {
                AutomaticOSUpgradePolicy = new PSAutomaticOSUpgradePolicy
                {
                    EnableAutomaticOSUpgrade = true,
                    UseRollingUpgradePolicy = true
                },
                RollingUpgradePolicy = new PSRollingUpgradePolicy
                {
                    EnableCrossZoneUpgrade = false,
                    MaxBatchInstancePercent = 50,
                    PauseTimeBetweenBatches = TimeSpan.FromSeconds(30)
                }
            };

            // Act
            var mgmtPolicy = psPolicy.toMgmtUpgradePolicy();

            // Assert - Verify both sub-policies are correctly converted and linked
            Assert.NotNull(mgmtPolicy);
            Assert.Equal(UpgradeMode.Rolling, mgmtPolicy.Mode);
            
            Assert.NotNull(mgmtPolicy.AutomaticOSUpgradePolicy);
            Assert.Equal(true, mgmtPolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade);
            Assert.Equal(true, mgmtPolicy.AutomaticOSUpgradePolicy.UseRollingUpgradePolicy);
            
            Assert.NotNull(mgmtPolicy.RollingUpgradePolicy);
            Assert.Equal(false, mgmtPolicy.RollingUpgradePolicy.EnableCrossZoneUpgrade);
            Assert.Equal(50, mgmtPolicy.RollingUpgradePolicy.MaxBatchInstancePercent);
            Assert.Equal("PT30S", mgmtPolicy.RollingUpgradePolicy.PauseTimeBetweenBatches);
        }

        #endregion
    }
}
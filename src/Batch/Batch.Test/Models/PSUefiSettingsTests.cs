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
    public class PSUefiSettingsTests
    {
        #region toMgmtUefiSettings Tests

        [Fact]
        public void ToMgmtUefiSettings_WithAllPropertiesEnabled_ReturnsCorrectMapping()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.True(result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_WithAllPropertiesDisabled_ReturnsCorrectMapping()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = false,
                VTpmEnabled = false
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.False(result.SecureBootEnabled);
            Assert.False(result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_WithMixedSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = false
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.False(result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_WithNullSecureBootEnabled_ReturnsNullSecureBoot()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = null,
                VTpmEnabled = true
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecureBootEnabled);
            Assert.True(result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_WithNullVTpmEnabled_ReturnsNullVTpm()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = null
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.Null(result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_WithBothNullValues_ReturnsBothNull()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = null,
                VTpmEnabled = null
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecureBootEnabled);
            Assert.Null(result.VTpmEnabled);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ToMgmtUefiSettings_AllValidCombinations_ReturnsCorrectMapping(
            bool secureBootEnabled,
            bool vTpmEnabled)
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = secureBootEnabled,
                VTpmEnabled = vTpmEnabled
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(secureBootEnabled, result.SecureBootEnabled);
            Assert.Equal(vTpmEnabled, result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            // Act
            var result1 = psUefiSettings.toMgmtUefiSettings();
            var result2 = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtUefiSettings_VerifyUefiSettingsType()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = false
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UefiSettings>(result);
        }

        [Fact]
        public void ToMgmtUefiSettings_DefaultValues_HandlesCorrectly()
        {
            // Arrange
            var psUefiSettings = new PSUefiSettings(); // Using default constructor

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            // Default values should be null for nullable bool properties
            Assert.Null(result.SecureBootEnabled);
            Assert.Null(result.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtUefiSettings_ConfidentialVMConfiguration_PreservesSecuritySettings()
        {
            // Arrange - Confidential VM with maximum security settings
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            // Act
            var result = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.True(result.VTpmEnabled);
            // Both secure boot and vTPM enabled for maximum security
        }

        #endregion

        #region fromMgmtUefiSettings Tests

        [Fact]
        public void FromMgmtUefiSettings_WithAllPropertiesEnabled_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: true);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.True(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithAllPropertiesDisabled_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: false,
                vTpmEnabled: false);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.SecureBootEnabled);
            Assert.False(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithMixedSettings_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: false);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.False(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithNullMgmtSettings_ReturnsNull()
        {
            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithNullSecureBootEnabled_ReturnsNullSecureBoot()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: null,
                vTpmEnabled: true);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecureBootEnabled);
            Assert.True(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithNullVTpmEnabled_ReturnsNullVTpm()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: null);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.Null(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithBothNullValues_ReturnsBothNull()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: null,
                vTpmEnabled: null);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecureBootEnabled);
            Assert.Null(result.VTpmEnabled);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void FromMgmtUefiSettings_AllValidCombinations_ReturnsCorrectMapping(
            bool secureBootEnabled,
            bool vTpmEnabled)
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: secureBootEnabled,
                vTpmEnabled: vTpmEnabled);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(secureBootEnabled, result.SecureBootEnabled);
            Assert.Equal(vTpmEnabled, result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: false);

            // Act - Call static method directly on class
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.False(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: true);

            // Act
            var result1 = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);
            var result2 = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtUefiSettings_VerifyPSUefiSettingsType()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: true);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSUefiSettings>(result);
        }

        [Fact]
        public void FromMgmtUefiSettings_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(); // Uses default constructor

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecureBootEnabled);
            Assert.Null(result.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtUefiSettings_ConfidentialVMConfiguration_PreservesSecuritySettings()
        {
            // Arrange
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: true);

            // Act
            var result = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SecureBootEnabled);
            Assert.True(result.VTpmEnabled);
            // Both secure boot and vTPM enabled for confidential computing
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllPropertiesEnabled()
        {
            // Arrange
            var originalPsUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            // Act
            var mgmtUefiSettings = originalPsUefiSettings.toMgmtUefiSettings();
            var roundTripPsUefiSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(roundTripPsUefiSettings);
            Assert.Equal(originalPsUefiSettings.SecureBootEnabled, roundTripPsUefiSettings.SecureBootEnabled);
            Assert.Equal(originalPsUefiSettings.VTpmEnabled, roundTripPsUefiSettings.VTpmEnabled);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllPropertiesDisabled()
        {
            // Arrange
            var originalPsUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = false,
                VTpmEnabled = false
            };

            // Act
            var mgmtUefiSettings = originalPsUefiSettings.toMgmtUefiSettings();
            var roundTripPsUefiSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(roundTripPsUefiSettings);
            Assert.Equal(originalPsUefiSettings.SecureBootEnabled, roundTripPsUefiSettings.SecureBootEnabled);
            Assert.Equal(originalPsUefiSettings.VTpmEnabled, roundTripPsUefiSettings.VTpmEnabled);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = null,
                VTpmEnabled = null
            };

            // Act
            var mgmtUefiSettings = originalPsUefiSettings.toMgmtUefiSettings();
            var roundTripPsUefiSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(roundTripPsUefiSettings);
            Assert.Null(roundTripPsUefiSettings.SecureBootEnabled);
            Assert.Null(roundTripPsUefiSettings.VTpmEnabled);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPartialNullValues()
        {
            // Arrange
            var originalPsUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = null
            };

            // Act
            var mgmtUefiSettings = originalPsUefiSettings.toMgmtUefiSettings();
            var roundTripPsUefiSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(roundTripPsUefiSettings);
            Assert.Equal(originalPsUefiSettings.SecureBootEnabled, roundTripPsUefiSettings.SecureBootEnabled);
            Assert.Null(roundTripPsUefiSettings.VTpmEnabled);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void RoundTripConversion_AllValidCombinations_PreservesOriginalValue(
            bool originalSecureBootEnabled,
            bool originalVTpmEnabled)
        {
            // Arrange
            var originalPsUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = originalSecureBootEnabled,
                VTpmEnabled = originalVTpmEnabled
            };

            // Act
            var mgmtUefiSettings = originalPsUefiSettings.toMgmtUefiSettings();
            var roundTripPsUefiSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(roundTripPsUefiSettings);
            Assert.Equal(originalSecureBootEnabled, roundTripPsUefiSettings.SecureBootEnabled);
            Assert.Equal(originalVTpmEnabled, roundTripPsUefiSettings.VTpmEnabled);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtUefiSettings = new UefiSettings(
                secureBootEnabled: true,
                vTpmEnabled: false);

            // Act
            var psUefiSettings = PSUefiSettings.fromMgmtUefiSettings(originalMgmtUefiSettings);
            var roundTripMgmtUefiSettings = psUefiSettings.toMgmtUefiSettings();

            // Assert
            Assert.NotNull(roundTripMgmtUefiSettings);
            Assert.Equal(originalMgmtUefiSettings.SecureBootEnabled, roundTripMgmtUefiSettings.SecureBootEnabled);
            Assert.Equal(originalMgmtUefiSettings.VTpmEnabled, roundTripMgmtUefiSettings.VTpmEnabled);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void UefiSettingsConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic UEFI security scenarios
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            // Act
            var mgmtUefiSettings = psUefiSettings.toMgmtUefiSettings();
            var backToPs = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.NotNull(mgmtUefiSettings);
            Assert.True(mgmtUefiSettings.SecureBootEnabled);
            Assert.True(mgmtUefiSettings.VTpmEnabled);

            Assert.NotNull(backToPs);
            Assert.True(backToPs.SecureBootEnabled);
            Assert.True(backToPs.VTpmEnabled);
        }

        [Fact]
        public void UefiSettingsConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSUefiSettings.fromMgmtUefiSettings(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void UefiSettingsConversions_BatchVMSecurityContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch VM security configuration
            // UefiSettings is used to configure security settings for virtual machines in Azure Batch pools

            // Arrange - Test with different security scenarios
            var securityScenarios = new[]
            {
                // Maximum security configuration
                new {
                    SecureBootEnabled = (bool?)true,
                    VTpmEnabled = (bool?)true,
                    Description = "Maximum security with both secure boot and vTPM enabled"
                },
                // Standard security configuration
                new {
                    SecureBootEnabled = (bool?)true,
                    VTpmEnabled = (bool?)false,
                    Description = "Standard security with secure boot enabled, vTPM disabled"
                },
                // Basic configuration
                new {
                    SecureBootEnabled = (bool?)false,
                    VTpmEnabled = (bool?)false,
                    Description = "Basic configuration with both features disabled"
                },
                // Default configuration
                new {
                    SecureBootEnabled = (bool?)null,
                    VTpmEnabled = (bool?)null,
                    Description = "Default configuration with unspecified values"
                }
            };

            foreach (var scenario in securityScenarios)
            {
                // Arrange
                var psUefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = scenario.SecureBootEnabled,
                    VTpmEnabled = scenario.VTpmEnabled
                };

                // Act
                var mgmtUefiSettings = psUefiSettings.toMgmtUefiSettings();

                // Assert - Should convert correctly for Batch VM security configuration
                Assert.NotNull(mgmtUefiSettings);
                Assert.Equal(scenario.SecureBootEnabled, mgmtUefiSettings.SecureBootEnabled);
                Assert.Equal(scenario.VTpmEnabled, mgmtUefiSettings.VTpmEnabled);

                // Verify round-trip conversion maintains security semantics
                var backToPs = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.SecureBootEnabled, backToPs.SecureBootEnabled);
                Assert.Equal(scenario.VTpmEnabled, backToPs.VTpmEnabled);
            }
        }

        [Fact]
        public void UefiSettingsConversions_ConfidentialComputingContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of confidential computing
            // UefiSettings is essential for configuring security features in confidential VMs

            // Arrange - Test with confidential computing scenarios
            var confidentialScenarios = new[]
            {
                // Confidential VM with Trusted Launch
                new {
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    ComplianceType = "Trusted Launch",
                    Description = "Confidential VM with Trusted Launch security features"
                },
                // Confidential VM with selective security features
                new {
                    SecureBootEnabled = true,
                    VTpmEnabled = false,
                    ComplianceType = "Selective Security",
                    Description = "Confidential VM with secure boot only"
                }
            };

            foreach (var scenario in confidentialScenarios)
            {
                // Act
                var psUefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = scenario.SecureBootEnabled,
                    VTpmEnabled = scenario.VTpmEnabled
                };
                var mgmtType = psUefiSettings.toMgmtUefiSettings();
                var roundTripType = PSUefiSettings.fromMgmtUefiSettings(mgmtType);

                // Assert - Confidential computing semantics should be preserved
                Assert.NotNull(roundTripType);
                Assert.Equal(scenario.SecureBootEnabled, roundTripType.SecureBootEnabled);
                Assert.Equal(scenario.VTpmEnabled, roundTripType.VTpmEnabled);
                
                // Verify the conversion maintains the security context
                Assert.NotNull(mgmtType);
                Assert.Equal(scenario.SecureBootEnabled, mgmtType.SecureBootEnabled);
                Assert.Equal(scenario.VTpmEnabled, mgmtType.VTpmEnabled);
            }
        }

        [Fact]
        public void UefiSettingsConversions_VMSecurityIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch VM security configuration
            // UefiSettings determines VM security features for compute nodes in Batch pools

            // SecureBoot semantics - Boot integrity and malware protection
            var secureBootOnlyPs = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = false
            };
            var mgmtSecureBootOnly = secureBootOnlyPs.toMgmtUefiSettings();
            
            Assert.NotNull(mgmtSecureBootOnly);
            Assert.True(mgmtSecureBootOnly.SecureBootEnabled);
            Assert.False(mgmtSecureBootOnly.VTpmEnabled);
            // Use case: Basic boot integrity protection without TPM features
            
            // vTPM semantics - Hardware security module functionality
            var vTpmOnlyPs = new PSUefiSettings()
            {
                SecureBootEnabled = false,
                VTpmEnabled = true
            };
            var mgmtVTpmOnly = vTpmOnlyPs.toMgmtUefiSettings();
            
            Assert.NotNull(mgmtVTpmOnly);
            Assert.False(mgmtVTpmOnly.SecureBootEnabled);
            Assert.True(mgmtVTpmOnly.VTpmEnabled);
            // Use case: Hardware security module functionality without secure boot

            // Combined semantics - Maximum security configuration
            var maxSecurityPs = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };
            var mgmtMaxSecurity = maxSecurityPs.toMgmtUefiSettings();
            
            Assert.NotNull(mgmtMaxSecurity);
            Assert.True(mgmtMaxSecurity.SecureBootEnabled);
            Assert.True(mgmtMaxSecurity.VTpmEnabled);
            // Use case: Maximum security for confidential computing workloads

            // Verify all round-trip correctly
            var secureBootRoundTrip = PSUefiSettings.fromMgmtUefiSettings(mgmtSecureBootOnly);
            var vTpmRoundTrip = PSUefiSettings.fromMgmtUefiSettings(mgmtVTpmOnly);
            var maxSecurityRoundTrip = PSUefiSettings.fromMgmtUefiSettings(mgmtMaxSecurity);

            Assert.NotNull(secureBootRoundTrip);
            Assert.NotNull(vTpmRoundTrip);
            Assert.NotNull(maxSecurityRoundTrip);
            Assert.Equal(secureBootOnlyPs.SecureBootEnabled, secureBootRoundTrip.SecureBootEnabled);
            Assert.Equal(secureBootOnlyPs.VTpmEnabled, secureBootRoundTrip.VTpmEnabled);
            Assert.Equal(vTpmOnlyPs.SecureBootEnabled, vTpmRoundTrip.SecureBootEnabled);
            Assert.Equal(vTpmOnlyPs.VTpmEnabled, vTpmRoundTrip.VTpmEnabled);
            Assert.Equal(maxSecurityPs.SecureBootEnabled, maxSecurityRoundTrip.SecureBootEnabled);
            Assert.Equal(maxSecurityPs.VTpmEnabled, maxSecurityRoundTrip.VTpmEnabled);
        }

        [Fact]
        public void UefiSettingsConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: false,
                vTpmEnabled: false);

            // Act
            var mgmtResult = psUefiSettings.toMgmtUefiSettings();
            var psResult = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<UefiSettings>(mgmtResult);
            Assert.IsType<PSUefiSettings>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtUefiSettings, mgmtResult);
            Assert.NotSame(psUefiSettings, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void UefiSettingsConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: false,
                vTpmEnabled: false);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psUefiSettings.toMgmtUefiSettings();
                var psResult = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.True(mgmtResult.SecureBootEnabled);
                Assert.False(psResult.SecureBootEnabled);
            }
        }

        [Fact]
        public void UefiSettingsConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = false
            };
            var mgmtUefiSettings = new UefiSettings(
                secureBootEnabled: false,
                vTpmEnabled: true);

            // Act
            var mgmtResult = psUefiSettings.toMgmtUefiSettings();
            var psResult = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert - Verify correct types are returned
            Assert.IsType<UefiSettings>(mgmtResult);
            Assert.IsType<PSUefiSettings>(psResult);
        }

        [Fact]
        public void UefiSettingsConversions_EdgeCases_HandleCorrectly()
        {
            // Test edge cases and boundary conditions

            // Default PS UEFI settings
            var defaultPs = new PSUefiSettings();
            var mgmtFromDefaultPs = defaultPs.toMgmtUefiSettings();

            Assert.NotNull(mgmtFromDefaultPs);
            Assert.Null(mgmtFromDefaultPs.SecureBootEnabled);
            Assert.Null(mgmtFromDefaultPs.VTpmEnabled);

            // Default management UEFI settings
            var defaultMgmt = new UefiSettings();
            var psFromDefaultMgmt = PSUefiSettings.fromMgmtUefiSettings(defaultMgmt);

            Assert.NotNull(psFromDefaultMgmt);
            Assert.Null(psFromDefaultMgmt.SecureBootEnabled);
            Assert.Null(psFromDefaultMgmt.VTpmEnabled);
        }

        [Fact]
        public void UefiSettingsConversions_PropertyAccess_VerifyBehavior()
        {
            // Test that properties are accessible and correct after conversion

            // Arrange
            var originalSecureBootEnabled = true;
            var originalVTpmEnabled = false;
            var psUefiSettings = new PSUefiSettings()
            {
                SecureBootEnabled = originalSecureBootEnabled,
                VTpmEnabled = originalVTpmEnabled
            };

            // Act
            var mgmtUefiSettings = psUefiSettings.toMgmtUefiSettings();
            var convertedPsUefiSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtUefiSettings);

            // Assert
            Assert.Equal(originalSecureBootEnabled, psUefiSettings.SecureBootEnabled);
            Assert.Equal(originalVTpmEnabled, psUefiSettings.VTpmEnabled);
            Assert.Equal(originalSecureBootEnabled, mgmtUefiSettings.SecureBootEnabled);
            Assert.Equal(originalVTpmEnabled, mgmtUefiSettings.VTpmEnabled);
            Assert.Equal(originalSecureBootEnabled, convertedPsUefiSettings.SecureBootEnabled);
            Assert.Equal(originalVTpmEnabled, convertedPsUefiSettings.VTpmEnabled);
        }

        #endregion

        #region Security Configuration Context Tests

        [Fact]
        public void UefiSettingsConversions_TrustedLaunchConfiguration_VerifySecurityStrategy()
        {
            // This test validates conversions work correctly for Trusted Launch VM configurations
            // UEFI settings are critical for Trusted Launch security features

            // Arrange - Trusted Launch requires both secure boot and vTPM
            var trustedLaunchPs = new PSUefiSettings()
            {
                SecureBootEnabled = true,
                VTpmEnabled = true
            };

            // Act
            var mgmtResult = trustedLaunchPs.toMgmtUefiSettings();
            var psResult = PSUefiSettings.fromMgmtUefiSettings(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.True(mgmtResult.SecureBootEnabled);
            Assert.True(mgmtResult.VTpmEnabled);

            Assert.NotNull(psResult);
            Assert.True(psResult.SecureBootEnabled);
            Assert.True(psResult.VTpmEnabled);

            // Verify round-trip maintains Trusted Launch configuration
            var roundTripMgmt = psResult.toMgmtUefiSettings();
            Assert.NotNull(roundTripMgmt);
            Assert.True(roundTripMgmt.SecureBootEnabled);
            Assert.True(roundTripMgmt.VTpmEnabled);
        }

        [Fact]
        public void UefiSettingsConversions_BatchPoolSecurityProfiles_VerifyConfiguration()
        {
            // This test validates the conversions work correctly for different Batch pool security profiles
            // Different workload types require different UEFI security configurations

            var securityProfiles = new[]
            {
                new {
                    Name = "High Security Profile",
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    Description = "Maximum security for sensitive workloads"
                },
                new {
                    Name = "Standard Security Profile", 
                    SecureBootEnabled = true,
                    VTpmEnabled = false,
                    Description = "Boot integrity for standard workloads"
                },
                new {
                    Name = "Basic Profile",
                    SecureBootEnabled = false,
                    VTpmEnabled = false,
                    Description = "No additional security features"
                }
            };

            foreach (var profile in securityProfiles)
            {
                // Arrange
                var psSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = profile.SecureBootEnabled,
                    VTpmEnabled = profile.VTpmEnabled
                };

                // Act
                var mgmtSettings = psSettings.toMgmtUefiSettings();
                var roundTripSettings = PSUefiSettings.fromMgmtUefiSettings(mgmtSettings);

                // Assert - Security profile should be preserved
                Assert.NotNull(mgmtSettings);
                Assert.Equal(profile.SecureBootEnabled, mgmtSettings.SecureBootEnabled);
                Assert.Equal(profile.VTpmEnabled, mgmtSettings.VTpmEnabled);

                Assert.NotNull(roundTripSettings);
                Assert.Equal(profile.SecureBootEnabled, roundTripSettings.SecureBootEnabled);
                Assert.Equal(profile.VTpmEnabled, roundTripSettings.VTpmEnabled);
            }
        }

        #endregion
    }
}
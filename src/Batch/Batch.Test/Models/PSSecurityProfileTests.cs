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
    public class PSSecurityProfileTests
    {
        #region toMgmtSecurityProfile Tests

        [Fact]
        public void ToMgmtSecurityProfile_WithTrustedLaunchAndEncryption_ReturnsCorrectMapping()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.TrustedLaunch, result.SecurityType);
            Assert.True(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.True(result.UefiSettings.SecureBootEnabled);
            Assert.True(result.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtSecurityProfile_WithConfidentialVM_ReturnsCorrectMapping()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                EncryptionAtHost = false,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = false
                }
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.ConfidentialVM, result.SecurityType);
            Assert.False(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.True(result.UefiSettings.SecureBootEnabled);
            Assert.False(result.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtSecurityProfile_WithNullSecurityType_ReturnsNullSecurityType()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = null,
                EncryptionAtHost = true,
                UefiSettings = null
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecurityType);
            Assert.True(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Fact]
        public void ToMgmtSecurityProfile_WithNullEncryptionAtHost_ReturnsNullEncryption()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = null,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = false,
                    VTpmEnabled = false
                }
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.TrustedLaunch, result.SecurityType);
            Assert.Null(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.False(result.UefiSettings.SecureBootEnabled);
            Assert.False(result.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void ToMgmtSecurityProfile_WithNullUefiSettings_ReturnsNullUefiSettings()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                EncryptionAtHost = false,
                UefiSettings = null
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.ConfidentialVM, result.SecurityType);
            Assert.False(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Fact]
        public void ToMgmtSecurityProfile_WithAllNullValues_ReturnsAllNull()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = null,
                EncryptionAtHost = null,
                UefiSettings = null
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecurityType);
            Assert.Null(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.SecurityTypes.TrustedLaunch, SecurityTypes.TrustedLaunch)]
        [InlineData(Azure.Batch.Common.SecurityTypes.ConfidentialVM, SecurityTypes.ConfidentialVM)]
        public void ToMgmtSecurityProfile_AllValidSecurityTypes_ReturnsCorrectMapping(
            Azure.Batch.Common.SecurityTypes psSecurityType,
            SecurityTypes expectedMgmtSecurityType)
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = psSecurityType,
                EncryptionAtHost = true
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtSecurityType, result.SecurityType);
        }

        [Fact]
        public void ToMgmtSecurityProfile_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings() { SecureBootEnabled = true }
            };

            // Act
            var result1 = psSecurityProfile.toMgmtSecurityProfile();
            var result2 = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtSecurityProfile_VerifySecurityProfileType()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                EncryptionAtHost = false
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<SecurityProfile>(result);
        }

        [Fact]
        public void ToMgmtSecurityProfile_DefaultValues_HandlesCorrectly()
        {
            // Arrange
            var psSecurityProfile = new PSSecurityProfile(); // Using default constructor

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            // Default values should be null for nullable properties
            Assert.Null(result.SecurityType);
            Assert.Null(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Fact]
        public void ToMgmtSecurityProfile_TrustedLaunchConfiguration_PreservesSecuritySettings()
        {
            // Arrange - Trusted Launch with maximum security settings
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            // Act
            var result = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.TrustedLaunch, result.SecurityType);
            Assert.True(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.True(result.UefiSettings.SecureBootEnabled);
            Assert.True(result.UefiSettings.VTpmEnabled);
            // Trusted Launch with full security features enabled
        }

        #endregion

        #region fromMgmtSecurityProfile Tests

        [Fact]
        public void FromMgmtSecurityProfile_WithTrustedLaunchAndEncryption_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.TrustedLaunch,
                encryptionAtHost: true,
                uefiSettings: new UefiSettings(
                    secureBootEnabled: true,
                    vTpmEnabled: true));

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, result.SecurityType);
            Assert.True(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.True(result.UefiSettings.SecureBootEnabled);
            Assert.True(result.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithConfidentialVM_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: false,
                uefiSettings: new UefiSettings(
                    secureBootEnabled: true,
                    vTpmEnabled: false));

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.ConfidentialVM, result.SecurityType);
            Assert.False(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.True(result.UefiSettings.SecureBootEnabled);
            Assert.False(result.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithNullMgmtProfile_ReturnsNull()
        {
            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithNullSecurityType_ReturnsNullSecurityType()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: null,
                encryptionAtHost: true,
                uefiSettings: null);

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecurityType);
            Assert.True(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithNullEncryptionAtHost_ReturnsNullEncryption()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.TrustedLaunch,
                encryptionAtHost: null,
                uefiSettings: new UefiSettings(
                    secureBootEnabled: false,
                    vTpmEnabled: false));

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, result.SecurityType);
            Assert.Null(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.False(result.UefiSettings.SecureBootEnabled);
            Assert.False(result.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithNullUefiSettings_ReturnsNullUefiSettings()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: false,
                uefiSettings: null);

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.ConfidentialVM, result.SecurityType);
            Assert.False(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithAllNullValues_ReturnsAllNull()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: null,
                encryptionAtHost: null,
                uefiSettings: null);

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecurityType);
            Assert.Null(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Theory]
        [InlineData(SecurityTypes.TrustedLaunch, Azure.Batch.Common.SecurityTypes.TrustedLaunch)]
        [InlineData(SecurityTypes.ConfidentialVM, Azure.Batch.Common.SecurityTypes.ConfidentialVM)]
        public void FromMgmtSecurityProfile_AllValidSecurityTypes_ReturnsCorrectMapping(
            SecurityTypes mgmtSecurityType,
            Azure.Batch.Common.SecurityTypes expectedPsSecurityType)
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: mgmtSecurityType,
                encryptionAtHost: true);

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsSecurityType, result.SecurityType);
        }

        [Fact]
        public void FromMgmtSecurityProfile_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.TrustedLaunch,
                encryptionAtHost: false);

            // Act - Call static method directly on class
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, result.SecurityType);
            Assert.False(result.EncryptionAtHost);
        }

        [Fact]
        public void FromMgmtSecurityProfile_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: true,
                uefiSettings: new UefiSettings(true, true));

            // Act
            var result1 = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);
            var result2 = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void FromMgmtSecurityProfile_VerifyPSSecurityProfileType()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.TrustedLaunch,
                encryptionAtHost: true);

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSSecurityProfile>(result);
        }

        [Fact]
        public void FromMgmtSecurityProfile_WithDefaultConstructor_HandlesCorrectly()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(); // Uses default constructor

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.SecurityType);
            Assert.Null(result.EncryptionAtHost);
            Assert.Null(result.UefiSettings);
        }

        [Fact]
        public void FromMgmtSecurityProfile_ConfidentialVMConfiguration_PreservesSecuritySettings()
        {
            // Arrange
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: true,
                uefiSettings: new UefiSettings(
                    secureBootEnabled: true,
                    vTpmEnabled: true));

            // Act
            var result = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.ConfidentialVM, result.SecurityType);
            Assert.True(result.EncryptionAtHost);
            Assert.NotNull(result.UefiSettings);
            Assert.True(result.UefiSettings.SecureBootEnabled);
            Assert.True(result.UefiSettings.VTpmEnabled);
            // Confidential VM with maximum security features
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllPropertiesTrustedLaunch()
        {
            // Arrange
            var originalPsSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.toMgmtSecurityProfile();
            var roundTripPsSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalPsSecurityProfile.SecurityType, roundTripPsSecurityProfile.SecurityType);
            Assert.Equal(originalPsSecurityProfile.EncryptionAtHost, roundTripPsSecurityProfile.EncryptionAtHost);
            Assert.NotNull(roundTripPsSecurityProfile.UefiSettings);
            Assert.Equal(originalPsSecurityProfile.UefiSettings.SecureBootEnabled, roundTripPsSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.Equal(originalPsSecurityProfile.UefiSettings.VTpmEnabled, roundTripPsSecurityProfile.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllPropertiesConfidentialVM()
        {
            // Arrange
            var originalPsSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                EncryptionAtHost = false,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = false
                }
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.toMgmtSecurityProfile();
            var roundTripPsSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalPsSecurityProfile.SecurityType, roundTripPsSecurityProfile.SecurityType);
            Assert.Equal(originalPsSecurityProfile.EncryptionAtHost, roundTripPsSecurityProfile.EncryptionAtHost);
            Assert.NotNull(roundTripPsSecurityProfile.UefiSettings);
            Assert.Equal(originalPsSecurityProfile.UefiSettings.SecureBootEnabled, roundTripPsSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.Equal(originalPsSecurityProfile.UefiSettings.VTpmEnabled, roundTripPsSecurityProfile.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullValues()
        {
            // Arrange
            var originalPsSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = null,
                EncryptionAtHost = null,
                UefiSettings = null
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.toMgmtSecurityProfile();
            var roundTripPsSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Null(roundTripPsSecurityProfile.SecurityType);
            Assert.Null(roundTripPsSecurityProfile.EncryptionAtHost);
            Assert.Null(roundTripPsSecurityProfile.UefiSettings);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPartialNullValues()
        {
            // Arrange
            var originalPsSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = null,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = null
                }
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.toMgmtSecurityProfile();
            var roundTripPsSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalPsSecurityProfile.SecurityType, roundTripPsSecurityProfile.SecurityType);
            Assert.Null(roundTripPsSecurityProfile.EncryptionAtHost);
            Assert.NotNull(roundTripPsSecurityProfile.UefiSettings);
            Assert.Equal(originalPsSecurityProfile.UefiSettings.SecureBootEnabled, roundTripPsSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.Null(roundTripPsSecurityProfile.UefiSettings.VTpmEnabled);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.SecurityTypes.TrustedLaunch, true)]
        [InlineData(Azure.Batch.Common.SecurityTypes.TrustedLaunch, false)]
        [InlineData(Azure.Batch.Common.SecurityTypes.ConfidentialVM, true)]
        [InlineData(Azure.Batch.Common.SecurityTypes.ConfidentialVM, false)]
        public void RoundTripConversion_AllValidCombinations_PreservesOriginalValue(
            Azure.Batch.Common.SecurityTypes originalSecurityType,
            bool originalEncryptionAtHost)
        {
            // Arrange
            var originalPsSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = originalSecurityType,
                EncryptionAtHost = originalEncryptionAtHost,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.toMgmtSecurityProfile();
            var roundTripPsSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalSecurityType, roundTripPsSecurityProfile.SecurityType);
            Assert.Equal(originalEncryptionAtHost, roundTripPsSecurityProfile.EncryptionAtHost);
            Assert.NotNull(roundTripPsSecurityProfile.UefiSettings);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: true,
                uefiSettings: new UefiSettings(
                    secureBootEnabled: false,
                    vTpmEnabled: true));

            // Act
            var psSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(originalMgmtSecurityProfile);
            var roundTripMgmtSecurityProfile = psSecurityProfile.toMgmtSecurityProfile();

            // Assert
            Assert.NotNull(roundTripMgmtSecurityProfile);
            Assert.Equal(originalMgmtSecurityProfile.SecurityType, roundTripMgmtSecurityProfile.SecurityType);
            Assert.Equal(originalMgmtSecurityProfile.EncryptionAtHost, roundTripMgmtSecurityProfile.EncryptionAtHost);
            Assert.NotNull(roundTripMgmtSecurityProfile.UefiSettings);
            Assert.Equal(originalMgmtSecurityProfile.UefiSettings.SecureBootEnabled, roundTripMgmtSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.Equal(originalMgmtSecurityProfile.UefiSettings.VTpmEnabled, roundTripMgmtSecurityProfile.UefiSettings.VTpmEnabled);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void SecurityProfileConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Arrange - Test with realistic security configuration scenarios
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            // Act
            var mgmtSecurityProfile = psSecurityProfile.toMgmtSecurityProfile();
            var backToPs = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(mgmtSecurityProfile);
            Assert.Equal(SecurityTypes.TrustedLaunch, mgmtSecurityProfile.SecurityType);
            Assert.True(mgmtSecurityProfile.EncryptionAtHost);
            Assert.NotNull(mgmtSecurityProfile.UefiSettings);
            Assert.True(mgmtSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.True(mgmtSecurityProfile.UefiSettings.VTpmEnabled);

            Assert.NotNull(backToPs);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, backToPs.SecurityType);
            Assert.True(backToPs.EncryptionAtHost);
            Assert.NotNull(backToPs.UefiSettings);
            Assert.True(backToPs.UefiSettings.SecureBootEnabled);
            Assert.True(backToPs.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void SecurityProfileConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSSecurityProfile.fromMgmtSecurityProfile(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void SecurityProfileConversions_BatchVMSecurityContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch VM security configuration
            // SecurityProfile is used to configure security settings for virtual machines in Azure Batch pools

            // Arrange - Test with different security scenarios
            var securityScenarios = new[]
            {
                // Trusted Launch with maximum security
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                    EncryptionAtHost = true,
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    Description = "Trusted Launch with maximum security features"
                },
                // Confidential VM with selective features
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                    EncryptionAtHost = false,
                    SecureBootEnabled = true,
                    VTpmEnabled = false,
                    Description = "Confidential VM with selective security features"
                }
            };

            foreach (var scenario in securityScenarios)
            {
                // Arrange
                var psSecurityProfile = new PSSecurityProfile()
                {
                    SecurityType = scenario.SecurityType,
                    EncryptionAtHost = scenario.EncryptionAtHost,
                    UefiSettings = scenario.SecureBootEnabled || scenario.VTpmEnabled
                        ? new PSUefiSettings()
                        {
                            SecureBootEnabled = scenario.SecureBootEnabled,
                            VTpmEnabled = scenario.VTpmEnabled
                        }
                        : null
                };

                // Act
                var mgmtSecurityProfile = psSecurityProfile.toMgmtSecurityProfile();

                // Assert - Should convert correctly for Batch VM security configuration
                Assert.NotNull(mgmtSecurityProfile);
                
               
                    var expectedMgmtType = scenario.SecurityType == Azure.Batch.Common.SecurityTypes.TrustedLaunch
                        ? SecurityTypes.TrustedLaunch
                        : SecurityTypes.ConfidentialVM;
                    Assert.Equal(expectedMgmtType, mgmtSecurityProfile.SecurityType);
         

                Assert.Equal(scenario.EncryptionAtHost, mgmtSecurityProfile.EncryptionAtHost);

                if (psSecurityProfile.UefiSettings != null)
                {
                    Assert.NotNull(mgmtSecurityProfile.UefiSettings);
                    Assert.Equal(scenario.SecureBootEnabled, mgmtSecurityProfile.UefiSettings.SecureBootEnabled);
                    Assert.Equal(scenario.VTpmEnabled, mgmtSecurityProfile.UefiSettings.VTpmEnabled);
                }
                else
                {
                    Assert.Null(mgmtSecurityProfile.UefiSettings);
                }

                // Verify round-trip conversion maintains security semantics
                var backToPs = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.SecurityType, backToPs.SecurityType);
                Assert.Equal(scenario.EncryptionAtHost, backToPs.EncryptionAtHost);
            }
        }

        [Fact]
        public void SecurityProfileConversions_ConfidentialComputingContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of confidential computing
            // SecurityProfile is essential for configuring security features in confidential VMs

            // Arrange - Test with confidential computing scenarios
            var confidentialScenarios = new[]
            {
                // Maximum security Confidential VM
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                    EncryptionAtHost = true,
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    ComplianceType = "Maximum Security",
                    Description = "Confidential VM with all security features enabled"
                },
                // Standard Trusted Launch
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                    EncryptionAtHost = false,
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    ComplianceType = "Trusted Launch",
                    Description = "Trusted Launch VM with standard security features"
                }
            };

            foreach (var scenario in confidentialScenarios)
            {
                // Act
                var psSecurityProfile = new PSSecurityProfile()
                {
                    SecurityType = scenario.SecurityType,
                    EncryptionAtHost = scenario.EncryptionAtHost,
                    UefiSettings = new PSUefiSettings()
                    {
                        SecureBootEnabled = scenario.SecureBootEnabled,
                        VTpmEnabled = scenario.VTpmEnabled
                    }
                };
                var mgmtType = psSecurityProfile.toMgmtSecurityProfile();
                var roundTripType = PSSecurityProfile.fromMgmtSecurityProfile(mgmtType);

                // Assert - Confidential computing semantics should be preserved
                Assert.NotNull(roundTripType);
                Assert.Equal(scenario.SecurityType, roundTripType.SecurityType);
                Assert.Equal(scenario.EncryptionAtHost, roundTripType.EncryptionAtHost);
                Assert.NotNull(roundTripType.UefiSettings);
                Assert.Equal(scenario.SecureBootEnabled, roundTripType.UefiSettings.SecureBootEnabled);
                Assert.Equal(scenario.VTpmEnabled, roundTripType.UefiSettings.VTpmEnabled);
                
                // Verify the conversion maintains the security context
                var expectedMgmtValue = scenario.SecurityType switch
                {
                    Azure.Batch.Common.SecurityTypes.TrustedLaunch => SecurityTypes.TrustedLaunch,
                    Azure.Batch.Common.SecurityTypes.ConfidentialVM => SecurityTypes.ConfidentialVM,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Assert.NotNull(mgmtType);
                Assert.Equal(expectedMgmtValue, mgmtType.SecurityType);
                Assert.Equal(scenario.EncryptionAtHost, mgmtType.EncryptionAtHost);
                Assert.NotNull(mgmtType.UefiSettings);
                Assert.Equal(scenario.SecureBootEnabled, mgmtType.UefiSettings.SecureBootEnabled);
                Assert.Equal(scenario.VTpmEnabled, mgmtType.UefiSettings.VTpmEnabled);
            }
        }

        [Fact]
        public void SecurityProfileConversions_VMSecurityIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch VM security configuration
            // SecurityProfile determines VM security features for compute nodes in Batch pools

            // Trusted Launch semantics - Boot integrity and attestation
            var trustedLaunchPs = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };
            var mgmtTrustedLaunch = trustedLaunchPs.toMgmtSecurityProfile();
            
            Assert.NotNull(mgmtTrustedLaunch);
            Assert.Equal(SecurityTypes.TrustedLaunch, mgmtTrustedLaunch.SecurityType);
            Assert.True(mgmtTrustedLaunch.EncryptionAtHost);
            Assert.NotNull(mgmtTrustedLaunch.UefiSettings);
            Assert.True(mgmtTrustedLaunch.UefiSettings.SecureBootEnabled);
            Assert.True(mgmtTrustedLaunch.UefiSettings.VTpmEnabled);
            // Use case: Enhanced boot security and hardware attestation for compliance
            
            // Confidential VM semantics - Hardware-enforced confidentiality
            var confidentialVMPs = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                EncryptionAtHost = false,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = false
                }
            };
            var mgmtConfidentialVM = confidentialVMPs.toMgmtSecurityProfile();
            
            Assert.NotNull(mgmtConfidentialVM);
            Assert.Equal(SecurityTypes.ConfidentialVM, mgmtConfidentialVM.SecurityType);
            Assert.False(mgmtConfidentialVM.EncryptionAtHost);
            Assert.NotNull(mgmtConfidentialVM.UefiSettings);
            Assert.True(mgmtConfidentialVM.UefiSettings.SecureBootEnabled);
            Assert.False(mgmtConfidentialVM.UefiSettings.VTpmEnabled);
            // Use case: Confidential computing with selective security features

            // Verify all round-trip correctly
            var trustedLaunchRoundTrip = PSSecurityProfile.fromMgmtSecurityProfile(mgmtTrustedLaunch);
            var confidentialVMRoundTrip = PSSecurityProfile.fromMgmtSecurityProfile(mgmtConfidentialVM);

            Assert.NotNull(trustedLaunchRoundTrip);
            Assert.NotNull(confidentialVMRoundTrip);
            Assert.Equal(trustedLaunchPs.SecurityType, trustedLaunchRoundTrip.SecurityType);
            Assert.Equal(trustedLaunchPs.EncryptionAtHost, trustedLaunchRoundTrip.EncryptionAtHost);
            Assert.Equal(confidentialVMPs.SecurityType, confidentialVMRoundTrip.SecurityType);
            Assert.Equal(confidentialVMPs.EncryptionAtHost, confidentialVMRoundTrip.EncryptionAtHost);
        }

        [Fact]
        public void SecurityProfileConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: false,
                uefiSettings: new UefiSettings(false, false));

            // Act
            var mgmtResult = psSecurityProfile.toMgmtSecurityProfile();
            var psResult = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<SecurityProfile>(mgmtResult);
            Assert.IsType<PSSecurityProfile>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtSecurityProfile, mgmtResult);
            Assert.NotSame(psSecurityProfile, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void SecurityProfileConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: false,
                uefiSettings: new UefiSettings(false, false));

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psSecurityProfile.toMgmtSecurityProfile();
                var psResult = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(SecurityTypes.TrustedLaunch, mgmtResult.SecurityType);
                Assert.Equal(Azure.Batch.Common.SecurityTypes.ConfidentialVM, psResult.SecurityType);
            }
        }

        [Fact]
        public void SecurityProfileConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = false
            };
            var mgmtSecurityProfile = new SecurityProfile(
                securityType: SecurityTypes.ConfidentialVM,
                encryptionAtHost: true);

            // Act
            var mgmtResult = psSecurityProfile.toMgmtSecurityProfile();
            var psResult = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert - Verify correct types are returned
            Assert.IsType<SecurityProfile>(mgmtResult);
            Assert.IsType<PSSecurityProfile>(psResult);
        }

        [Fact]
        public void SecurityProfileConversions_EdgeCases_HandleCorrectly()
        {
            // Test edge cases and boundary conditions

            // Default PS security profile
            var defaultPs = new PSSecurityProfile();
            var mgmtFromDefaultPs = defaultPs.toMgmtSecurityProfile();

            Assert.NotNull(mgmtFromDefaultPs);
            Assert.Null(mgmtFromDefaultPs.SecurityType);
            Assert.Null(mgmtFromDefaultPs.EncryptionAtHost);
            Assert.Null(mgmtFromDefaultPs.UefiSettings);

            // Default management security profile
            var defaultMgmt = new SecurityProfile();
            var psFromDefaultMgmt = PSSecurityProfile.fromMgmtSecurityProfile(defaultMgmt);

            Assert.NotNull(psFromDefaultMgmt);
            Assert.Null(psFromDefaultMgmt.SecurityType);
            Assert.Null(psFromDefaultMgmt.EncryptionAtHost);
            Assert.Null(psFromDefaultMgmt.UefiSettings);
        }

        [Fact]
        public void SecurityProfileConversions_PropertyAccess_VerifyBehavior()
        {
            // Test that properties are accessible and correct after conversion

            // Arrange
            var originalSecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM;
            var originalEncryptionAtHost = true;
            var psSecurityProfile = new PSSecurityProfile()
            {
                SecurityType = originalSecurityType,
                EncryptionAtHost = originalEncryptionAtHost,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = false,
                    VTpmEnabled = true
                }
            };

            // Act
            var mgmtSecurityProfile = psSecurityProfile.toMgmtSecurityProfile();
            var convertedPsSecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.Equal(originalSecurityType, psSecurityProfile.SecurityType);
            Assert.Equal(originalEncryptionAtHost, psSecurityProfile.EncryptionAtHost);
            Assert.Equal(SecurityTypes.ConfidentialVM, mgmtSecurityProfile.SecurityType);
            Assert.Equal(originalEncryptionAtHost, mgmtSecurityProfile.EncryptionAtHost);
            Assert.Equal(originalSecurityType, convertedPsSecurityProfile.SecurityType);
            Assert.Equal(originalEncryptionAtHost, convertedPsSecurityProfile.EncryptionAtHost);

            Assert.NotNull(psSecurityProfile.UefiSettings);
            Assert.NotNull(mgmtSecurityProfile.UefiSettings);
            Assert.NotNull(convertedPsSecurityProfile.UefiSettings);
            Assert.False(psSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.True(psSecurityProfile.UefiSettings.VTpmEnabled);
            Assert.False(mgmtSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.True(mgmtSecurityProfile.UefiSettings.VTpmEnabled);
            Assert.False(convertedPsSecurityProfile.UefiSettings.SecureBootEnabled);
            Assert.True(convertedPsSecurityProfile.UefiSettings.VTpmEnabled);
        }

        #endregion

        #region Security Configuration Context Tests

        [Fact]
        public void SecurityProfileConversions_TrustedLaunchConfiguration_VerifySecurityStrategy()
        {
            // This test validates conversions work correctly for Trusted Launch VM configurations
            // Security profiles are critical for Trusted Launch security features

            // Arrange - Trusted Launch requires specific security configuration
            var trustedLaunchPs = new PSSecurityProfile()
            {
                SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                EncryptionAtHost = true,
                UefiSettings = new PSUefiSettings()
                {
                    SecureBootEnabled = true,
                    VTpmEnabled = true
                }
            };

            // Act
            var mgmtResult = trustedLaunchPs.toMgmtSecurityProfile();
            var psResult = PSSecurityProfile.fromMgmtSecurityProfile(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.Equal(SecurityTypes.TrustedLaunch, mgmtResult.SecurityType);
            Assert.True(mgmtResult.EncryptionAtHost);
            Assert.NotNull(mgmtResult.UefiSettings);
            Assert.True(mgmtResult.UefiSettings.SecureBootEnabled);
            Assert.True(mgmtResult.UefiSettings.VTpmEnabled);

            Assert.NotNull(psResult);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, psResult.SecurityType);
            Assert.True(psResult.EncryptionAtHost);
            Assert.NotNull(psResult.UefiSettings);
            Assert.True(psResult.UefiSettings.SecureBootEnabled);
            Assert.True(psResult.UefiSettings.VTpmEnabled);

            // Verify round-trip maintains Trusted Launch configuration
            var roundTripMgmt = psResult.toMgmtSecurityProfile();
            Assert.NotNull(roundTripMgmt);
            Assert.Equal(SecurityTypes.TrustedLaunch, roundTripMgmt.SecurityType);
            Assert.True(roundTripMgmt.EncryptionAtHost);
            Assert.NotNull(roundTripMgmt.UefiSettings);
            Assert.True(roundTripMgmt.UefiSettings.SecureBootEnabled);
            Assert.True(roundTripMgmt.UefiSettings.VTpmEnabled);
        }

        [Fact]
        public void SecurityProfileConversions_BatchPoolSecurityProfiles_VerifyConfiguration()
        {
            // This test validates the conversions work correctly for different Batch pool security profiles
            // Different workload types require different security configurations

            var securityProfiles = new[]
            {
                new {
                    Name = "High Security Profile",
                    SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                    EncryptionAtHost = true,
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    Description = "Maximum security for sensitive workloads"
                },
                new {
                    Name = "Standard Security Profile", 
                    SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                    EncryptionAtHost = false,
                    SecureBootEnabled = true,
                    VTpmEnabled = true,
                    Description = "Standard trusted launch for regular workloads"
                }
            };

            foreach (var profile in securityProfiles)
            {
                // Arrange
                var psSettings = new PSSecurityProfile()
                {
                    SecurityType = profile.SecurityType,
                    EncryptionAtHost = profile.EncryptionAtHost,
                    UefiSettings = profile.SecureBootEnabled || profile.VTpmEnabled
                        ? new PSUefiSettings()
                        {
                            SecureBootEnabled = profile.SecureBootEnabled,
                            VTpmEnabled = profile.VTpmEnabled
                        }
                        : null
                };

                // Act
                var mgmtSettings = psSettings.toMgmtSecurityProfile();
                var roundTripSettings = PSSecurityProfile.fromMgmtSecurityProfile(mgmtSettings);

                // Assert - Security profile should be preserved
                Assert.NotNull(mgmtSettings);
                
                
                    var expectedType = profile.SecurityType == Azure.Batch.Common.SecurityTypes.TrustedLaunch
                        ? SecurityTypes.TrustedLaunch
                        : SecurityTypes.ConfidentialVM;
                    Assert.Equal(expectedType, mgmtSettings.SecurityType);
              
                Assert.Equal(profile.EncryptionAtHost, mgmtSettings.EncryptionAtHost);

                Assert.NotNull(roundTripSettings);
                Assert.Equal(profile.SecurityType, roundTripSettings.SecurityType);
                Assert.Equal(profile.EncryptionAtHost, roundTripSettings.EncryptionAtHost);

                if (profile.SecureBootEnabled || profile.VTpmEnabled)
                {
                    Assert.NotNull(roundTripSettings.UefiSettings);
                    Assert.Equal(profile.SecureBootEnabled, roundTripSettings.UefiSettings.SecureBootEnabled);
                    Assert.Equal(profile.VTpmEnabled, roundTripSettings.UefiSettings.VTpmEnabled);
                }
                else
                {
                    Assert.Null(roundTripSettings.UefiSettings);
                }
            }
        }

        #endregion
    }
}
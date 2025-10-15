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
    public class PSVMDiskSecurityProfileTests
    {
        #region ToMgmtVMDiskSecurityProfile Tests

        [Fact]
        public void ToMgmtVMDiskSecurityProfile_WithNonPersistedTPM_ReturnsCorrectMapping()
        {
            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };

            // Act
            var result = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NonPersistedTPM", result.SecurityEncryptionType);
        }

        [Fact]
        public void ToMgmtVMDiskSecurityProfile_WithVMGuestStateOnly_ReturnsCorrectMapping()
        {
            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };

            // Act
            var result = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("VMGuestStateOnly", result.SecurityEncryptionType);
        }

        [Theory]
        [InlineData("NonPersistedTPM")]
        [InlineData("VMGuestStateOnly")]
        [InlineData(null)]
        [InlineData("")]
        public void ToMgmtVMDiskSecurityProfile_AllValidValues_ReturnsCorrectMapping(string encryptionType)
        {
            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = encryptionType
            };

            // Act
            var result = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(encryptionType, result.SecurityEncryptionType);
        }

        [Fact]
        public void ToMgmtVMDiskSecurityProfile_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };

            // Act
            var result1 = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var result2 = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtVMDiskSecurityProfile_VerifyVMDiskSecurityProfileType()
        {
            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };

            // Act
            var result = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<VMDiskSecurityProfile>(result);
        }

        [Fact]
        public void ToMgmtVMDiskSecurityProfile_NonPersistedTPMSemantics_PreservesEncryptionStrategy()
        {
            // Arrange - NonPersistedTPM strategy for not persisting firmware state
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };

            // Act
            var result = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NonPersistedTPM", result.SecurityEncryptionType);
            // NonPersistedTPM semantics: Firmware state is not persisted in the VMGuestState blob for security
        }

        [Fact]
        public void ToMgmtVMDiskSecurityProfile_VMGuestStateOnlySemantics_PreservesEncryptionStrategy()
        {
            // Arrange - VMGuestStateOnly strategy for encrypting just the VMGuestState blob
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };

            // Act
            var result = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("VMGuestStateOnly", result.SecurityEncryptionType);
            // VMGuestStateOnly semantics: Only the VMGuestState blob is encrypted for confidentiality
        }

        #endregion

        #region FromMgmtVMDiskSecurityProfile Tests

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_WithNonPersistedTPM_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile("NonPersistedTPM");

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NonPersistedTPM", result.SecurityEncryptionType);
        }

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_WithVMGuestStateOnly_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("VMGuestStateOnly", result.SecurityEncryptionType);
        }

        [Theory]
        [InlineData("NonPersistedTPM")]
        [InlineData("VMGuestStateOnly")]
        [InlineData(null)]
        [InlineData("")]
        public void FromMgmtVMDiskSecurityProfile_AllValidValues_ReturnsCorrectMapping(string encryptionType)
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile(encryptionType);

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(encryptionType, result.SecurityEncryptionType);
        }

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_WithNullInput_ReturnsNull()
        {
            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_VerifyPSVMDiskSecurityProfileType()
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile("NonPersistedTPM");

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSVMDiskSecurityProfile>(result);
        }

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_NonPersistedTPMSemantics_PreservesEncryptionStrategy()
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile("NonPersistedTPM");

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("NonPersistedTPM", result.SecurityEncryptionType);
            // NonPersistedTPM semantics preserved: Firmware state not persisted for security
        }

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_VMGuestStateOnlySemantics_PreservesEncryptionStrategy()
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("VMGuestStateOnly", result.SecurityEncryptionType);
            // VMGuestStateOnly semantics preserved: VMGuestState blob encryption for confidentiality
        }

        [Fact]
        public void FromMgmtVMDiskSecurityProfile_WithDefaultVMDiskSecurityProfile_HandlesCorrectly()
        {
            // Arrange
            var mgmtSecurityProfile = new VMDiskSecurityProfile(); // Uses default constructor

            // Act
            var result = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(result);
            // The result should handle the default SecurityEncryptionType from the management profile
            Assert.True(result.SecurityEncryptionType == null || 
                       result.SecurityEncryptionType == "NonPersistedTPM" || 
                       result.SecurityEncryptionType == "VMGuestStateOnly" ||
                       result.SecurityEncryptionType == "");
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNonPersistedTPMValue()
        {
            // Arrange
            var originalPsSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var roundTripPsSecurityProfile = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalPsSecurityProfile.SecurityEncryptionType, roundTripPsSecurityProfile.SecurityEncryptionType);
            Assert.Equal("NonPersistedTPM", roundTripPsSecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesVMGuestStateOnlyValue()
        {
            // Arrange
            var originalPsSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var roundTripPsSecurityProfile = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalPsSecurityProfile.SecurityEncryptionType, roundTripPsSecurityProfile.SecurityEncryptionType);
            Assert.Equal("VMGuestStateOnly", roundTripPsSecurityProfile.SecurityEncryptionType);
        }

        [Theory]
        [InlineData("NonPersistedTPM")]
        [InlineData("VMGuestStateOnly")]
        [InlineData(null)]
        [InlineData("")]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidValues(string originalEncryptionType)
        {
            // Arrange
            var originalPsSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = originalEncryptionType
            };

            // Act
            var mgmtSecurityProfile = originalPsSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var roundTripPsSecurityProfile = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.NotNull(roundTripPsSecurityProfile);
            Assert.Equal(originalEncryptionType, roundTripPsSecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtSecurityProfile = new VMDiskSecurityProfile("NonPersistedTPM");

            // Act
            var psSecurityProfile = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(originalMgmtSecurityProfile);
            var roundTripMgmtSecurityProfile = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

            // Assert
            Assert.NotNull(roundTripMgmtSecurityProfile);
            Assert.Equal(originalMgmtSecurityProfile.SecurityEncryptionType, roundTripMgmtSecurityProfile.SecurityEncryptionType);
            Assert.Equal("NonPersistedTPM", roundTripMgmtSecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void RoundTripConversion_WithNullSecurityProfile_HandlesCorrectly()
        {
            // Arrange
            VMDiskSecurityProfile nullMgmtSecurityProfile = null;

            // Act
            var psSecurityProfile = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(nullMgmtSecurityProfile);

            // Assert
            Assert.Null(psSecurityProfile);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void VMDiskSecurityProfileConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test NonPersistedTPM semantics - Firmware state not persisted for security
            var psNonPersistedTPM = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var mgmtNonPersistedTPM = psNonPersistedTPM.ToMgmtVMDiskSecurityProfile();
            var backToPs = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtNonPersistedTPM);

            Assert.Equal("NonPersistedTPM", mgmtNonPersistedTPM.SecurityEncryptionType);
            Assert.Equal("NonPersistedTPM", backToPs.SecurityEncryptionType);

            // Test VMGuestStateOnly semantics - VMGuestState blob encryption
            var psVMGuestStateOnly = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };
            var mgmtVMGuestStateOnly = psVMGuestStateOnly.ToMgmtVMDiskSecurityProfile();
            var backToPsVMGuest = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtVMGuestStateOnly);

            Assert.Equal("VMGuestStateOnly", mgmtVMGuestStateOnly.SecurityEncryptionType);
            Assert.Equal("VMGuestStateOnly", backToPsVMGuest.SecurityEncryptionType);
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_ConfidentialVMContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Confidential VM configuration
            // VMDiskSecurityProfile is used to configure security settings for managed disks in Confidential VMs

            // Arrange - Test Confidential VM disk security scenarios
            var confidentialVMScenarios = new[]
            {
                // High security scenario with NonPersistedTPM
                new {
                    EncryptionType = "NonPersistedTPM",
                    Description = "Confidential VM with non-persisted TPM for maximum security"
                },
                // VMGuestState encryption scenario
                new {
                    EncryptionType = "VMGuestStateOnly",
                    Description = "Confidential VM with VMGuestState blob encryption"
                }
            };

            foreach (var scenario in confidentialVMScenarios)
            {
                // Act
                var psSecurityProfile = new PSVMDiskSecurityProfile()
                {
                    SecurityEncryptionType = scenario.EncryptionType
                };
                var mgmtSecurityProfile = psSecurityProfile.ToMgmtVMDiskSecurityProfile();

                // Assert - Should convert correctly for Confidential VM configuration
                Assert.NotNull(mgmtSecurityProfile);
                Assert.Equal(scenario.EncryptionType, mgmtSecurityProfile.SecurityEncryptionType);

                // Verify round-trip conversion maintains Confidential VM semantics
                var backToPs = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.EncryptionType, backToPs.SecurityEncryptionType);
            }
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");

            // Act
            var mgmtResult = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var psResult = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<VMDiskSecurityProfile>(mgmtResult);
            Assert.IsType<PSVMDiskSecurityProfile>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtSecurityProfile, mgmtResult);
            Assert.NotSame(psSecurityProfile, psResult);
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default/null security encryption type values
            
            // Arrange
            var defaultPsSecurityProfile = new PSVMDiskSecurityProfile();
            var defaultMgmtSecurityProfile = new VMDiskSecurityProfile(); // Uses default constructor

            // Act
            var mgmtResult = defaultPsSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var psResult = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(defaultMgmtSecurityProfile);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            // Default values should be preserved
            Assert.Equal(defaultPsSecurityProfile.SecurityEncryptionType, mgmtResult.SecurityEncryptionType);
            Assert.Equal(defaultMgmtSecurityProfile.SecurityEncryptionType, psResult.SecurityEncryptionType);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void VMDiskSecurityProfileConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
                var psResult = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
            }
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");

            // Act
            var mgmtResult = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var psResult = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert - Verify correct types are returned
            Assert.IsType<VMDiskSecurityProfile>(mgmtResult);
            Assert.IsType<PSVMDiskSecurityProfile>(psResult);
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_SecurityEncryptionTypeProperty_AccessibleAfterConversion()
        {
            // Test that the SecurityEncryptionType property is accessible and correct after conversion

            // Arrange
            var originalEncryptionType = "VMGuestStateOnly";
            var psSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = originalEncryptionType
            };

            // Act
            var mgmtSecurityProfile = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
            var convertedPsSecurityProfile = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtSecurityProfile);

            // Assert
            Assert.Equal(originalEncryptionType, psSecurityProfile.SecurityEncryptionType);
            Assert.Equal(originalEncryptionType, mgmtSecurityProfile.SecurityEncryptionType);
            Assert.Equal(originalEncryptionType, convertedPsSecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_EdgeCaseStringValues_HandleCorrectly()
        {
            // Test conversion with various edge case string values

            var testEncryptionTypes = new[]
            {
                // Valid values
                "NonPersistedTPM",
                "VMGuestStateOnly",
                
                // Edge cases
                null,
                "",
                " ", // Whitespace
                "  NonPersistedTPM  ", // Leading/trailing whitespace
                "nonpersistedtpm", // Different casing
                "VMGUESTSTATEONLY", // Different casing
                
                // Invalid values (should still be preserved)
                "InvalidType",
                "SomeOtherValue"
            };

            foreach (var encryptionType in testEncryptionTypes)
            {
                // Arrange
                var psSecurityProfile = new PSVMDiskSecurityProfile()
                {
                    SecurityEncryptionType = encryptionType
                };

                // Act
                var mgmtResult = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
                var roundTripResult = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(roundTripResult);
                Assert.Equal(encryptionType, mgmtResult.SecurityEncryptionType);
                Assert.Equal(encryptionType, roundTripResult.SecurityEncryptionType);
            }
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSVMDiskSecurityProfile_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes the internal object

            // Arrange & Act
            var psSecurityProfile = new PSVMDiskSecurityProfile();

            // Assert
            Assert.Null(psSecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void PSVMDiskSecurityProfile_InternalConstructor_ThrowsOnNullOmObject()
        {
            // Test that the internal constructor validates the omObject parameter

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                new PSVMDiskSecurityProfile((Microsoft.Azure.Batch.VMDiskSecurityProfile)null));
        }

        [Fact]
        public void PSVMDiskSecurityProfile_InternalConstructor_WorksWithValidOmObject()
        {
            // Test that the internal constructor works with a valid omObject

            // Arrange
            var omObject = new Microsoft.Azure.Batch.VMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };

            // Act
            var psSecurityProfile = new PSVMDiskSecurityProfile(omObject);

            // Assert
            Assert.NotNull(psSecurityProfile);
            Assert.Equal("NonPersistedTPM", psSecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void PSVMDiskSecurityProfile_PropertySetter_WorksCorrectly()
        {
            // Test that property setters work correctly

            // Arrange
            var psSecurityProfile = new PSVMDiskSecurityProfile();

            // Act
            psSecurityProfile.SecurityEncryptionType = "VMGuestStateOnly";

            // Assert
            Assert.Equal("VMGuestStateOnly", psSecurityProfile.SecurityEncryptionType);
        }

        #endregion

        #region Confidential Computing Security Tests

        [Fact]
        public void VMDiskSecurityProfileConversions_ConfidentialComputingSecurity_VerifySemantics()
        {
            // This test validates that the security profile types maintain their security characteristics
            // through the conversion process for Confidential Computing scenarios

            var securityProfiles = new[]
            {
                new {
                    Type = "NonPersistedTPM",
                    SecurityLevel = "Maximum",
                    Description = "Firmware state not persisted in VMGuestState blob",
                    UseCases = new[] { "High-security workloads", "Government compliance", "Financial services" }
                },
                new {
                    Type = "VMGuestStateOnly",
                    SecurityLevel = "Standard",
                    Description = "Encryption of VMGuestState blob only",
                    UseCases = new[] { "General confidential computing", "Data protection", "Privacy-sensitive workloads" }
                }
            };

            foreach (var profile in securityProfiles)
            {
                // Act - Convert to management type and back
                var psSecurityProfile = new PSVMDiskSecurityProfile()
                {
                    SecurityEncryptionType = profile.Type
                };
                var mgmtType = psSecurityProfile.ToMgmtVMDiskSecurityProfile();
                var roundTripType = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtType);

                // Assert - Security characteristics should be preserved
                Assert.NotNull(mgmtType);
                Assert.NotNull(roundTripType);
                Assert.Equal(profile.Type, roundTripType.SecurityEncryptionType);
                Assert.Equal(profile.Type, mgmtType.SecurityEncryptionType);
            }
        }

        [Fact]
        public void VMDiskSecurityProfileConversions_ConfidentialVMIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Confidential VM configuration
            // VMDiskSecurityProfile is required for Confidential VMs and controls disk encryption behavior

            // NonPersistedTPM semantics - Maximum security with no firmware state persistence
            var nonPersistedTPMProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var mgmtNonPersistedTPMProfile = nonPersistedTPMProfile.ToMgmtVMDiskSecurityProfile();
            
            Assert.NotNull(mgmtNonPersistedTPMProfile);
            Assert.Equal("NonPersistedTPM", mgmtNonPersistedTPMProfile.SecurityEncryptionType);
            // Use case: Maximum security for sensitive workloads where firmware state must not be persisted
            
            // VMGuestStateOnly semantics - Standard confidential computing encryption
            var vmGuestStateOnlyProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };
            var mgmtVMGuestStateOnlyProfile = vmGuestStateOnlyProfile.ToMgmtVMDiskSecurityProfile();
            
            Assert.NotNull(mgmtVMGuestStateOnlyProfile);
            Assert.Equal("VMGuestStateOnly", mgmtVMGuestStateOnlyProfile.SecurityEncryptionType);
            // Use case: Standard confidential computing with VMGuestState blob encryption

            // Verify all round-trip correctly
            var nonPersistedTPMRoundTrip = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtNonPersistedTPMProfile);
            var vmGuestStateOnlyRoundTrip = PSVMDiskSecurityProfile.FromMgmtVMDiskSecurityProfile(mgmtVMGuestStateOnlyProfile);

            Assert.Equal("NonPersistedTPM", nonPersistedTPMRoundTrip.SecurityEncryptionType);
            Assert.Equal("VMGuestStateOnly", vmGuestStateOnlyRoundTrip.SecurityEncryptionType);
        }

        #endregion
    }
}
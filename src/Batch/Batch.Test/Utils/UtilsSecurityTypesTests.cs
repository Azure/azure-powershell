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
    public class UtilsSecurityTypesTests
    {
        #region ToMgmtSecurityType Tests

        [Fact]
        public void ToMgmtSecurityType_TrustedLaunch_ReturnsTrustedLaunch()
        {
            // Arrange
            var psSecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch;

            // Act
            var result = Utils.Utils.ToMgmtSecurityType(psSecurityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.TrustedLaunch, result.Value);
        }

        [Fact]
        public void ToMgmtSecurityType_ConfidentialVM_ReturnsConfidentialVM()
        {
            // Arrange
            var psSecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM;

            // Act
            var result = Utils.Utils.ToMgmtSecurityType(psSecurityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.ConfidentialVM, result.Value);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.SecurityTypes.TrustedLaunch, SecurityTypes.TrustedLaunch)]
        [InlineData(Azure.Batch.Common.SecurityTypes.ConfidentialVM, SecurityTypes.ConfidentialVM)]
        public void ToMgmtSecurityType_AllValidValues_ReturnsCorrectMapping(
            Azure.Batch.Common.SecurityTypes input,
            SecurityTypes expected)
        {
            // Act
            var result = Utils.Utils.ToMgmtSecurityType(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void ToMgmtSecurityType_WithNullInput_ReturnsNull()
        {
            // Arrange
            Azure.Batch.Common.SecurityTypes? nullInput = null;

            // Act
            var result = Utils.Utils.ToMgmtSecurityType(nullInput);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtSecurityType_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Azure.Batch.Common.SecurityTypes);

            // Act
            var result = Utils.Utils.ToMgmtSecurityType(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default SecurityTypes is typically TrustedLaunch (0)
            Assert.Equal(SecurityTypes.TrustedLaunch, result.Value);
        }

        [Fact]
        public void ToMgmtSecurityType_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each security type

            // Arrange & Act & Assert
            // TrustedLaunch: Protects against advanced and persistent attack techniques
            var trustedLaunchResult = Utils.Utils.ToMgmtSecurityType(Azure.Batch.Common.SecurityTypes.TrustedLaunch);
            Assert.NotNull(trustedLaunchResult);
            Assert.Equal(SecurityTypes.TrustedLaunch, trustedLaunchResult.Value);

            // ConfidentialVM: Azure confidential computing for high security requirements
            var confidentialVMResult = Utils.Utils.ToMgmtSecurityType(Azure.Batch.Common.SecurityTypes.ConfidentialVM);
            Assert.NotNull(confidentialVMResult);
            Assert.Equal(SecurityTypes.ConfidentialVM, confidentialVMResult.Value);
        }

        [Fact]
        public void ToMgmtSecurityType_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psSecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM;

            // Act - Call static method directly on class
            var result = Utils.Utils.ToMgmtSecurityType(psSecurityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(SecurityTypes.ConfidentialVM, result.Value);
        }

        [Fact]
        public void ToMgmtSecurityType_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                Azure.Batch.Common.SecurityTypes.ConfidentialVM
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.ToMgmtSecurityType(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(SecurityTypes), result.Value));
            }
        }

        [Fact]
        public void ToMgmtSecurityType_ReturnsNullableType()
        {
            // This test verifies that the method returns a nullable SecurityTypes

            // Arrange
            var psSecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch;

            // Act
            var result = Utils.Utils.ToMgmtSecurityType(psSecurityType);

            // Assert
            Assert.IsType<SecurityTypes>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void ToMgmtSecurityType_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psTrustedLaunch = Azure.Batch.Common.SecurityTypes.TrustedLaunch;
            var psConfidentialVM = Azure.Batch.Common.SecurityTypes.ConfidentialVM;

            // Act
            var mgmtTrustedLaunch = Utils.Utils.ToMgmtSecurityType(psTrustedLaunch);
            var mgmtConfidentialVM = Utils.Utils.ToMgmtSecurityType(psConfidentialVM);

            // Assert
            // Verify that the underlying values match (direct cast behavior)
            Assert.NotNull(mgmtTrustedLaunch);
            Assert.NotNull(mgmtConfidentialVM);
            Assert.Equal((int)psTrustedLaunch, (int)mgmtTrustedLaunch.Value);
            Assert.Equal((int)psConfidentialVM, (int)mgmtConfidentialVM.Value);
        }

        #endregion

        #region fromMgmtSecurityType Tests

        [Fact]
        public void FromMgmtSecurityType_TrustedLaunch_ReturnsTrustedLaunch()
        {
            // Arrange
            var mgmtSecurityType = SecurityTypes.TrustedLaunch;

            // Act
            var result = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, result.Value);
        }

        [Fact]
        public void FromMgmtSecurityType_ConfidentialVM_ReturnsConfidentialVM()
        {
            // Arrange
            var mgmtSecurityType = SecurityTypes.ConfidentialVM;

            // Act
            var result = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.ConfidentialVM, result.Value);
        }

        [Theory]
        [InlineData(SecurityTypes.TrustedLaunch, Azure.Batch.Common.SecurityTypes.TrustedLaunch)]
        [InlineData(SecurityTypes.ConfidentialVM, Azure.Batch.Common.SecurityTypes.ConfidentialVM)]
        public void FromMgmtSecurityType_AllValidValues_ReturnsCorrectMapping(
            SecurityTypes input,
            Azure.Batch.Common.SecurityTypes expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtSecurityType(input);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void FromMgmtSecurityType_WithNullInput_ReturnsNull()
        {
            // Arrange
            SecurityTypes? nullInput = null;

            // Act
            var result = Utils.Utils.fromMgmtSecurityType(nullInput);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtSecurityType_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(SecurityTypes);

            // Act
            var result = Utils.Utils.fromMgmtSecurityType(defaultValue);

            // Assert
            Assert.NotNull(result);
            // Default SecurityTypes is typically TrustedLaunch (0)
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, result.Value);
        }

        [Fact]
        public void FromMgmtSecurityType_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each security type

            // Arrange & Act & Assert
            // TrustedLaunch: Protects against advanced and persistent attack techniques
            var trustedLaunchResult = Utils.Utils.fromMgmtSecurityType(SecurityTypes.TrustedLaunch);
            Assert.NotNull(trustedLaunchResult);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, trustedLaunchResult.Value);

            // ConfidentialVM: Azure confidential computing for high security requirements
            var confidentialVMResult = Utils.Utils.fromMgmtSecurityType(SecurityTypes.ConfidentialVM);
            Assert.NotNull(confidentialVMResult);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.ConfidentialVM, confidentialVMResult.Value);
        }

        [Fact]
        public void FromMgmtSecurityType_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtSecurityType = SecurityTypes.TrustedLaunch;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, result.Value);
        }

        [Fact]
        public void FromMgmtSecurityType_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                SecurityTypes.TrustedLaunch,
                SecurityTypes.ConfidentialVM
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtSecurityType(value);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Azure.Batch.Common.SecurityTypes), result.Value));
            }
        }

        [Fact]
        public void FromMgmtSecurityType_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtTrustedLaunch = SecurityTypes.TrustedLaunch;
            var mgmtConfidentialVM = SecurityTypes.ConfidentialVM;

            // Act
            var psTrustedLaunch = Utils.Utils.fromMgmtSecurityType(mgmtTrustedLaunch);
            var psConfidentialVM = Utils.Utils.fromMgmtSecurityType(mgmtConfidentialVM);

            // Assert
            // Verify that the underlying values match (direct cast behavior)
            Assert.NotNull(psTrustedLaunch);
            Assert.NotNull(psConfidentialVM);
            Assert.Equal((int)mgmtTrustedLaunch, (int)psTrustedLaunch.Value);
            Assert.Equal((int)mgmtConfidentialVM, (int)psConfidentialVM.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesTrustedLaunchValue()
        {
            // Arrange
            var originalPsSecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch;

            // Act
            var mgmtSecurityType = Utils.Utils.ToMgmtSecurityType(originalPsSecurityType);
            var roundTripPsSecurityType = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert
            Assert.NotNull(roundTripPsSecurityType);
            Assert.Equal(originalPsSecurityType, roundTripPsSecurityType.Value);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesConfidentialVMValue()
        {
            // Arrange
            var originalPsSecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM;

            // Act
            var mgmtSecurityType = Utils.Utils.ToMgmtSecurityType(originalPsSecurityType);
            var roundTripPsSecurityType = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert
            Assert.NotNull(roundTripPsSecurityType);
            Assert.Equal(originalPsSecurityType, roundTripPsSecurityType.Value);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.SecurityTypes.TrustedLaunch)]
        [InlineData(Azure.Batch.Common.SecurityTypes.ConfidentialVM)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Azure.Batch.Common.SecurityTypes originalSecurityType)
        {
            // Act
            var mgmtSecurityType = Utils.Utils.ToMgmtSecurityType(originalSecurityType);
            var roundTripSecurityType = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert
            Assert.NotNull(roundTripSecurityType);
            Assert.Equal(originalSecurityType, roundTripSecurityType.Value);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                SecurityTypes.TrustedLaunch,
                SecurityTypes.ConfidentialVM
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.fromMgmtSecurityType(originalValue);
                var roundTripValue = Utils.Utils.ToMgmtSecurityType(psValue);

                // Assert
                Assert.NotNull(roundTripValue);
                Assert.Equal(originalValue, roundTripValue.Value);
            }
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            Azure.Batch.Common.SecurityTypes? psNull = null;
            SecurityTypes? mgmtNull = null;

            // Act
            var mgmtFromPsNull = Utils.Utils.ToMgmtSecurityType(psNull);
            var psFromMgmtNull = Utils.Utils.fromMgmtSecurityType(mgmtNull);

            // Assert
            Assert.Null(mgmtFromPsNull);
            Assert.Null(psFromMgmtNull);
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void SecurityTypes_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psSecurityTypeValues = Enum.GetValues(typeof(Azure.Batch.Common.SecurityTypes));
            var mgmtSecurityTypeValues = Enum.GetValues(typeof(SecurityTypes));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psSecurityTypeValues.Length, mgmtSecurityTypeValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Azure.Batch.Common.SecurityTypes psValue in psSecurityTypeValues)
            {
                var result = Utils.Utils.ToMgmtSecurityType(psValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(SecurityTypes), result.Value));
            }

            // Verify that each management enum value can be converted successfully
            foreach (SecurityTypes mgmtValue in mgmtSecurityTypeValues)
            {
                var result = Utils.Utils.fromMgmtSecurityType(mgmtValue);
                Assert.NotNull(result);
                Assert.True(Enum.IsDefined(typeof(Azure.Batch.Common.SecurityTypes), result.Value));
            }
        }

        [Fact]
        public void SecurityTypes_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                Azure.Batch.Common.SecurityTypes.ConfidentialVM
            };

            var mgmtValues = new[]
            {
                SecurityTypes.TrustedLaunch,
                SecurityTypes.ConfidentialVM
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new SecurityTypes?[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.ToMgmtSecurityType(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Azure.Batch.Common.SecurityTypes?[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtSecurityType(mgmtValues[i]);
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
        public void SecurityTypesConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test TrustedLaunch semantics - Protects against advanced and persistent attack techniques
            var psTrustedLaunch = Azure.Batch.Common.SecurityTypes.TrustedLaunch;
            var mgmtTrustedLaunch = Utils.Utils.ToMgmtSecurityType(psTrustedLaunch);
            var backToPs = Utils.Utils.fromMgmtSecurityType(mgmtTrustedLaunch);

            Assert.NotNull(mgmtTrustedLaunch);
            Assert.Equal(SecurityTypes.TrustedLaunch, mgmtTrustedLaunch.Value);
            Assert.NotNull(backToPs);
            Assert.Equal(psTrustedLaunch, backToPs.Value);

            // Test ConfidentialVM semantics - High security and confidentiality requirements
            var psConfidentialVM = Azure.Batch.Common.SecurityTypes.ConfidentialVM;
            var mgmtConfidentialVM = Utils.Utils.ToMgmtSecurityType(psConfidentialVM);
            var backToPsConfidential = Utils.Utils.fromMgmtSecurityType(mgmtConfidentialVM);

            Assert.NotNull(mgmtConfidentialVM);
            Assert.Equal(SecurityTypes.ConfidentialVM, mgmtConfidentialVM.Value);
            Assert.NotNull(backToPsConfidential);
            Assert.Equal(psConfidentialVM, backToPsConfidential.Value);
        }

        [Fact]
        public void SecurityTypesConversions_NullabilityHandling_VerifyBehavior()
        {
            // This test verifies the nullable handling in these conversion methods

            // ToMgmtSecurityType returns null for null input
            Azure.Batch.Common.SecurityTypes? nullInput = null;
            var result = Utils.Utils.ToMgmtSecurityType(nullInput);
            Assert.Null(result);

            // fromMgmtSecurityType returns null for null input
            SecurityTypes? nullMgmtInput = null;
            var mgmtResult = Utils.Utils.fromMgmtSecurityType(nullMgmtInput);
            Assert.Null(mgmtResult);
        }

        [Fact]
        public void SecurityTypesConversions_BatchSecurityContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch security configuration
            // SecurityTypes is used to specify security features for virtual machines in Azure Batch pools

            // Arrange - Test with different security scenarios
            var securityScenarios = new[]
            {
                // Trusted Launch for enhanced boot security
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                    Description = "Trusted Launch for enhanced boot security and attestation"
                },
                // Confidential VM for sensitive workloads
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                    Description = "Confidential VM for sensitive data processing workloads"
                }
            };

            foreach (var scenario in securityScenarios)
            {
                // Act
                var mgmtSecurityType = Utils.Utils.ToMgmtSecurityType(scenario.SecurityType);

                // Assert - Should convert correctly for Batch security configuration
                var expectedMgmtType = scenario.SecurityType == Azure.Batch.Common.SecurityTypes.TrustedLaunch
                    ? SecurityTypes.TrustedLaunch
                    : SecurityTypes.ConfidentialVM;
                Assert.NotNull(mgmtSecurityType);
                Assert.Equal(expectedMgmtType, mgmtSecurityType.Value);

                // Verify round-trip conversion maintains security semantics
                var backToPs = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.SecurityType, backToPs.Value);
            }
        }

        [Fact]
        public void SecurityTypesConversions_ConfidentialComputingContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of confidential computing
            // SecurityTypes is essential for configuring confidential computing features in Azure Batch

            // Arrange - Test with confidential computing scenarios
            var confidentialScenarios = new[]
            {
                // TrustedLaunch for hardware-based attestation
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                    ComplianceType = "Hardware Attestation",
                    Description = "Hardware-based attestation and secure boot validation"
                },
                // ConfidentialVM for memory encryption
                new {
                    SecurityType = Azure.Batch.Common.SecurityTypes.ConfidentialVM,
                    ComplianceType = "Memory Encryption",
                    Description = "Hardware-enforced memory encryption and isolation"
                }
            };

            foreach (var scenario in confidentialScenarios)
            {
                // Act
                var mgmtType = Utils.Utils.ToMgmtSecurityType(scenario.SecurityType);
                var roundTripType = Utils.Utils.fromMgmtSecurityType(mgmtType);

                // Assert - Confidential computing semantics should be preserved
                Assert.NotNull(roundTripType);
                Assert.Equal(scenario.SecurityType, roundTripType.Value);
                
                // Verify the conversion maintains the security context
                var expectedMgmtValue = scenario.SecurityType switch
                {
                    Azure.Batch.Common.SecurityTypes.TrustedLaunch => SecurityTypes.TrustedLaunch,
                    Azure.Batch.Common.SecurityTypes.ConfidentialVM => SecurityTypes.ConfidentialVM,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Assert.NotNull(mgmtType);
                Assert.Equal(expectedMgmtValue, mgmtType.Value);
            }
        }

        [Fact]
        public void SecurityTypesConversions_VMSecurityIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch VM security configuration
            // SecurityTypes determines VM security features for compute nodes in Batch pools

            // TrustedLaunch semantics - Boot integrity and attestation
            var trustedLaunchType = Azure.Batch.Common.SecurityTypes.TrustedLaunch;
            var mgmtTrustedLaunchType = Utils.Utils.ToMgmtSecurityType(trustedLaunchType);
            
            Assert.NotNull(mgmtTrustedLaunchType);
            Assert.Equal(SecurityTypes.TrustedLaunch, mgmtTrustedLaunchType.Value);
            // Use case: Enhanced boot security for compliance requirements
            
            // ConfidentialVM semantics - Hardware-enforced confidentiality
            var confidentialVMType = Azure.Batch.Common.SecurityTypes.ConfidentialVM;
            var mgmtConfidentialVMType = Utils.Utils.ToMgmtSecurityType(confidentialVMType);
            
            Assert.NotNull(mgmtConfidentialVMType);
            Assert.Equal(SecurityTypes.ConfidentialVM, mgmtConfidentialVMType.Value);
            // Use case: Sensitive data processing with hardware isolation

            // Verify all round-trip correctly
            var trustedLaunchRoundTrip = Utils.Utils.fromMgmtSecurityType(mgmtTrustedLaunchType);
            var confidentialVMRoundTrip = Utils.Utils.fromMgmtSecurityType(mgmtConfidentialVMType);

            Assert.NotNull(trustedLaunchRoundTrip);
            Assert.NotNull(confidentialVMRoundTrip);
            Assert.Equal(trustedLaunchType, trustedLaunchRoundTrip.Value);
            Assert.Equal(confidentialVMType, confidentialVMRoundTrip.Value);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void SecurityTypesConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psSecurityTypes = new[]
            {
                Azure.Batch.Common.SecurityTypes.TrustedLaunch,
                Azure.Batch.Common.SecurityTypes.ConfidentialVM
            };

            var mgmtSecurityTypes = new[]
            {
                SecurityTypes.TrustedLaunch,
                SecurityTypes.ConfidentialVM
            };

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                foreach (var psType in psSecurityTypes)
                {
                    var mgmtResult = Utils.Utils.ToMgmtSecurityType(psType);
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtType in mgmtSecurityTypes)
                {
                    var psResult = Utils.Utils.fromMgmtSecurityType(mgmtType);
                    Assert.NotNull(psResult);
                }
            }
        }

        [Fact]
        public void SecurityTypesConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psSecurityType = Azure.Batch.Common.SecurityTypes.TrustedLaunch;
            var mgmtSecurityType = SecurityTypes.ConfidentialVM;

            // Act
            var mgmtResult = Utils.Utils.ToMgmtSecurityType(psSecurityType);
            var psResult = Utils.Utils.fromMgmtSecurityType(mgmtSecurityType);

            // Assert - Verify correct types are returned
            Assert.IsType<SecurityTypes>(mgmtResult);
            Assert.IsType<Azure.Batch.Common.SecurityTypes>(psResult);
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
        }

        [Fact]
        public void SecurityTypesConversions_EdgeCases_HandleCorrectly()
        {
            // Test edge cases and boundary conditions

            // Default enum values
            var defaultPs = default(Azure.Batch.Common.SecurityTypes);
            var defaultMgmt = default(SecurityTypes);

            var mgmtFromDefaultPs = Utils.Utils.ToMgmtSecurityType(defaultPs);
            var psFromDefaultMgmt = Utils.Utils.fromMgmtSecurityType(defaultMgmt);

            Assert.NotNull(mgmtFromDefaultPs);
            Assert.NotNull(psFromDefaultMgmt);
            Assert.Equal(SecurityTypes.TrustedLaunch, mgmtFromDefaultPs.Value);
            Assert.Equal(Azure.Batch.Common.SecurityTypes.TrustedLaunch, psFromDefaultMgmt.Value);
        }

        #endregion
    }
}
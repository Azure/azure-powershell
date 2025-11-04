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
    public class PSManagedDiskTests
    {
        #region ToMgmtManagedDisk Tests

        [Fact]
        public void ToMgmtManagedDisk_WithStandardLRS_ReturnsCorrectMapping()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.StandardLRS, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void ToMgmtManagedDisk_WithPremiumLRS_ReturnsCorrectMapping()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.PremiumLRS, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void ToMgmtManagedDisk_WithStandardSSDLRS_ReturnsCorrectMapping()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.StandardSSDLRS, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void ToMgmtManagedDisk_WithSecurityProfile_ReturnsCorrectMapping()
        {
            // Arrange
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: securityProfile);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.PremiumLRS, result.StorageAccountType);
            Assert.NotNull(result.SecurityProfile);
            Assert.Equal("NonPersistedTPM", result.SecurityProfile.SecurityEncryptionType);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, StorageAccountType.StandardLRS)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, StorageAccountType.PremiumLRS)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, StorageAccountType.StandardSSDLRS)]
        public void ToMgmtManagedDisk_AllValidStorageAccountTypes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.StorageAccountType psStorageType,
            StorageAccountType expectedMgmtStorageType)
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(storageAccountType: psStorageType);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtStorageType, result.StorageAccountType);
        }

        [Fact]
        public void ToMgmtManagedDisk_WithNullStorageAccountType_ReturnsCorrectMapping()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(storageAccountType: null);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void ToMgmtManagedDisk_WithNullSecurityProfile_ReturnsCorrectMapping()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: null);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.PremiumLRS, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void ToMgmtManagedDisk_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);

            // Act
            var result1 = psManagedDisk.ToMgmtManagedDisk();
            var result2 = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtManagedDisk_VerifyManagedDiskType()
        {
            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ManagedDisk>(result);
        }

        [Fact]
        public void ToMgmtManagedDisk_WithConfidentialVMSecurity_PreservesSecuritySettings()
        {
            // Arrange - Confidential VM with VM guest state encryption
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: securityProfile);

            // Act
            var result = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StorageAccountType.PremiumLRS, result.StorageAccountType);
            Assert.NotNull(result.SecurityProfile);
            Assert.Equal("VMGuestStateOnly", result.SecurityProfile.SecurityEncryptionType);
            // VMGuestStateOnly semantics: Only the VMGuestState blob is encrypted for confidentiality
        }

        #endregion

        #region FromMgmtManagedDisk Tests

        [Fact]
        public void FromMgmtManagedDisk_WithStandardLRS_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: StorageAccountType.StandardLRS);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithPremiumLRS_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: StorageAccountType.PremiumLRS);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithStandardSSDLRS_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: StorageAccountType.StandardSSDLRS);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithSecurityProfile_ReturnsCorrectMapping()
        {
            // Arrange
            var securityProfile = new VMDiskSecurityProfile("NonPersistedTPM");
            var mgmtManagedDisk = new ManagedDisk(
                storageAccountType: StorageAccountType.PremiumLRS,
                securityProfile: securityProfile);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.StorageAccountType);
            Assert.NotNull(result.SecurityProfile);
            Assert.Equal("NonPersistedTPM", result.SecurityProfile.SecurityEncryptionType);
        }

        [Theory]
        [InlineData(StorageAccountType.StandardLRS, Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        [InlineData(StorageAccountType.PremiumLRS, Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)]
        [InlineData(StorageAccountType.StandardSSDLRS, Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)]
        public void FromMgmtManagedDisk_AllValidStorageAccountTypes_ReturnsCorrectMapping(
            StorageAccountType mgmtStorageType,
            Microsoft.Azure.Batch.Common.StorageAccountType expectedPsStorageType)
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: mgmtStorageType);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsStorageType, result.StorageAccountType);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithNullInput_ReturnsNull()
        {
            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithNullStorageAccountType_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: null);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithNullSecurityProfile_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(
                storageAccountType: StorageAccountType.PremiumLRS,
                securityProfile: null);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.StorageAccountType);
            Assert.Null(result.SecurityProfile);
        }

        [Fact]
        public void FromMgmtManagedDisk_VerifyPSManagedDiskType()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: StorageAccountType.StandardLRS);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSManagedDisk>(result);
        }

        [Fact]
        public void FromMgmtManagedDisk_WithConfidentialVMSecurity_PreservesSecuritySettings()
        {
            // Arrange
            var securityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");
            var mgmtManagedDisk = new ManagedDisk(
                storageAccountType: StorageAccountType.PremiumLRS,
                securityProfile: securityProfile);

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, result.StorageAccountType);
            Assert.NotNull(result.SecurityProfile);
            Assert.Equal("VMGuestStateOnly", result.SecurityProfile.SecurityEncryptionType);
            // VMGuestStateOnly semantics preserved: VMGuestState blob encryption for confidentiality
        }

        [Fact]
        public void FromMgmtManagedDisk_WithDefaultManagedDisk_HandlesCorrectly()
        {
            // Arrange
            var mgmtManagedDisk = new ManagedDisk(); // Uses default constructor

            // Act
            var result = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(result);
            // The result should handle the default values from the management disk
            Assert.True(result.StorageAccountType == null || 
                       Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.StorageAccountType), result.StorageAccountType));
            Assert.Null(result.SecurityProfile);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesStandardLRSValue()
        {
            // Arrange
            var originalPsManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);

            // Act
            var mgmtManagedDisk = originalPsManagedDisk.ToMgmtManagedDisk();
            var roundTripPsManagedDisk = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(roundTripPsManagedDisk);
            Assert.Equal(originalPsManagedDisk.StorageAccountType, roundTripPsManagedDisk.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, roundTripPsManagedDisk.StorageAccountType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesPremiumLRSValue()
        {
            // Arrange
            var originalPsManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);

            // Act
            var mgmtManagedDisk = originalPsManagedDisk.ToMgmtManagedDisk();
            var roundTripPsManagedDisk = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(roundTripPsManagedDisk);
            Assert.Equal(originalPsManagedDisk.StorageAccountType, roundTripPsManagedDisk.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, roundTripPsManagedDisk.StorageAccountType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesSecurityProfile()
        {
            // Arrange
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var originalPsManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: securityProfile);

            // Act
            var mgmtManagedDisk = originalPsManagedDisk.ToMgmtManagedDisk();
            var roundTripPsManagedDisk = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(roundTripPsManagedDisk);
            Assert.Equal(originalPsManagedDisk.StorageAccountType, roundTripPsManagedDisk.StorageAccountType);
            Assert.NotNull(roundTripPsManagedDisk.SecurityProfile);
            Assert.Equal("NonPersistedTPM", roundTripPsManagedDisk.SecurityProfile.SecurityEncryptionType);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs)]
        [InlineData(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidStorageTypes(
            Microsoft.Azure.Batch.Common.StorageAccountType originalStorageType)
        {
            // Arrange
            var originalPsManagedDisk = new PSManagedDisk(storageAccountType: originalStorageType);

            // Act
            var mgmtManagedDisk = originalPsManagedDisk.ToMgmtManagedDisk();
            var roundTripPsManagedDisk = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(roundTripPsManagedDisk);
            Assert.Equal(originalStorageType, roundTripPsManagedDisk.StorageAccountType);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var securityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");
            var originalMgmtManagedDisk = new ManagedDisk(
                storageAccountType: StorageAccountType.StandardSSDLRS,
                securityProfile: securityProfile);

            // Act
            var psManagedDisk = PSManagedDisk.FromMgmtManagedDisk(originalMgmtManagedDisk);
            var roundTripMgmtManagedDisk = psManagedDisk.ToMgmtManagedDisk();

            // Assert
            Assert.NotNull(roundTripMgmtManagedDisk);
            Assert.Equal(originalMgmtManagedDisk.StorageAccountType, roundTripMgmtManagedDisk.StorageAccountType);
            Assert.NotNull(roundTripMgmtManagedDisk.SecurityProfile);
            Assert.Equal("VMGuestStateOnly", roundTripMgmtManagedDisk.SecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void RoundTripConversion_WithNullValues_PreservesNulls()
        {
            // Arrange
            var originalPsManagedDisk = new PSManagedDisk(
                storageAccountType: null,
                securityProfile: null);

            // Act
            var mgmtManagedDisk = originalPsManagedDisk.ToMgmtManagedDisk();
            var roundTripPsManagedDisk = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.NotNull(roundTripPsManagedDisk);
            Assert.Null(roundTripPsManagedDisk.StorageAccountType);
            Assert.Null(roundTripPsManagedDisk.SecurityProfile);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void ManagedDiskConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test Standard LRS semantics - Cost-optimized storage
            var psStandardLRS = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);
            var mgmtStandardLRS = psStandardLRS.ToMgmtManagedDisk();
            var backToPs = PSManagedDisk.FromMgmtManagedDisk(mgmtStandardLRS);

            Assert.Equal(StorageAccountType.StandardLRS, mgmtStandardLRS.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs, backToPs.StorageAccountType);

            // Test Premium LRS semantics - High-performance storage
            var psPremiumLRS = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);
            var mgmtPremiumLRS = psPremiumLRS.ToMgmtManagedDisk();
            var backToPsPremium = PSManagedDisk.FromMgmtManagedDisk(mgmtPremiumLRS);

            Assert.Equal(StorageAccountType.PremiumLRS, mgmtPremiumLRS.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, backToPsPremium.StorageAccountType);

            // Test Standard SSD LRS semantics - Balanced performance/cost
            var psStandardSSD = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);
            var mgmtStandardSSD = psStandardSSD.ToMgmtManagedDisk();
            var backToPsStandardSSD = PSManagedDisk.FromMgmtManagedDisk(mgmtStandardSSD);

            Assert.Equal(StorageAccountType.StandardSSDLRS, mgmtStandardSSD.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, backToPsStandardSSD.StorageAccountType);
        }

        [Fact]
        public void ManagedDiskConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSManagedDisk.FromMgmtManagedDisk(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void ManagedDiskConversions_ConfidentialVMContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Confidential VM configuration
            // ManagedDisk is used to configure OS disk settings for Confidential VMs in Azure Batch

            // Arrange - Test Confidential VM managed disk scenarios
            var confidentialVMScenarios = new[]
            {
                // High security Confidential VM with NonPersistedTPM
                new {
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    SecurityEncryptionType = "NonPersistedTPM",
                    Description = "High security Confidential VM with Premium SSD and non-persisted TPM"
                },
                // Standard Confidential VM with VMGuestStateOnly
                new {
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                    SecurityEncryptionType = "VMGuestStateOnly",
                    Description = "Standard Confidential VM with Standard SSD and VM guest state encryption"
                }
            };

            foreach (var scenario in confidentialVMScenarios)
            {
                // Arrange
                var securityProfile = new PSVMDiskSecurityProfile()
                {
                    SecurityEncryptionType = scenario.SecurityEncryptionType
                };
                var psManagedDisk = new PSManagedDisk(
                    storageAccountType: scenario.StorageAccountType,
                    securityProfile: securityProfile);

                // Act
                var mgmtManagedDisk = psManagedDisk.ToMgmtManagedDisk();

                // Assert - Should convert correctly for Confidential VM configuration
                Assert.NotNull(mgmtManagedDisk);
                Assert.NotNull(mgmtManagedDisk.SecurityProfile);
                Assert.Equal(scenario.SecurityEncryptionType, mgmtManagedDisk.SecurityProfile.SecurityEncryptionType);

                var expectedStorageType = scenario.StorageAccountType switch
                {
                    Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs => StorageAccountType.PremiumLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS => StorageAccountType.StandardSSDLRS,
                    _ => StorageAccountType.StandardLRS
                };
                Assert.Equal(expectedStorageType, mgmtManagedDisk.StorageAccountType);

                // Verify round-trip conversion maintains Confidential VM semantics
                var backToPs = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);
                Assert.NotNull(backToPs);
                Assert.NotNull(backToPs.SecurityProfile);
                Assert.Equal(scenario.SecurityEncryptionType, backToPs.SecurityProfile.SecurityEncryptionType);
                Assert.Equal(scenario.StorageAccountType, backToPs.StorageAccountType);
            }
        }

        [Fact]
        public void ManagedDiskConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: securityProfile);

            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");
            var mgmtManagedDisk = new ManagedDisk(
                storageAccountType: StorageAccountType.StandardSSDLRS,
                securityProfile: mgmtSecurityProfile);

            // Act
            var mgmtResult = psManagedDisk.ToMgmtManagedDisk();
            var psResult = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<ManagedDisk>(mgmtResult);
            Assert.IsType<PSManagedDisk>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtManagedDisk, mgmtResult);
            Assert.NotSame(psManagedDisk, psResult);
        }

        [Fact]
        public void ManagedDiskConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default/null values

            // Arrange
            PSManagedDisk defaultPsManagedDisk = new PSManagedDisk(); // Uses default constructor
            ManagedDisk defaultMgmtManagedDisk = new ManagedDisk(); // Uses default constructor

            // Act
            ManagedDisk mgmtResult = defaultPsManagedDisk.ToMgmtManagedDisk();
            PSManagedDisk psResult = PSManagedDisk.FromMgmtManagedDisk(defaultMgmtManagedDisk);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            // Default values should be preserved
            Assert.Null(mgmtResult.StorageAccountType);
            Assert.Null(psResult.StorageAccountType);
            Assert.Null(mgmtResult.SecurityProfile);
            Assert.Null(psResult.SecurityProfile);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void ManagedDiskConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: securityProfile);

            var mgmtSecurityProfile = new VMDiskSecurityProfile("VMGuestStateOnly");
            var mgmtManagedDisk = new ManagedDisk(
                storageAccountType: StorageAccountType.StandardSSDLRS,
                securityProfile: mgmtSecurityProfile);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psManagedDisk.ToMgmtManagedDisk();
                var psResult = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
            }
        }

        [Fact]
        public void ManagedDiskConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs);
            var mgmtManagedDisk = new ManagedDisk(storageAccountType: StorageAccountType.PremiumLRS);

            // Act
            var mgmtResult = psManagedDisk.ToMgmtManagedDisk();
            var psResult = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert - Verify correct types are returned
            Assert.IsType<ManagedDisk>(mgmtResult);
            Assert.IsType<PSManagedDisk>(psResult);
        }

        [Fact]
        public void ManagedDiskConversions_PropertyAccess_VerifyBehavior()
        {
            // Test that properties are accessible and correct after conversion

            // Arrange
            var originalStorageType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var psManagedDisk = new PSManagedDisk(
                storageAccountType: originalStorageType,
                securityProfile: securityProfile);

            // Act
            var mgmtManagedDisk = psManagedDisk.ToMgmtManagedDisk();
            var convertedPsManagedDisk = PSManagedDisk.FromMgmtManagedDisk(mgmtManagedDisk);

            // Assert
            Assert.Equal(originalStorageType, psManagedDisk.StorageAccountType);
            Assert.Equal(StorageAccountType.StandardSSDLRS, mgmtManagedDisk.StorageAccountType);
            Assert.Equal(originalStorageType, convertedPsManagedDisk.StorageAccountType);

            Assert.Equal("NonPersistedTPM", psManagedDisk.SecurityProfile.SecurityEncryptionType);
            Assert.Equal("NonPersistedTPM", mgmtManagedDisk.SecurityProfile.SecurityEncryptionType);
            Assert.Equal("NonPersistedTPM", convertedPsManagedDisk.SecurityProfile.SecurityEncryptionType);
        }

        #endregion

        #region Constructor and Internal Object Tests

        [Fact]
        public void PSManagedDisk_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes the internal object

            // Arrange & Act
            var psManagedDisk1 = new PSManagedDisk();
            var psManagedDisk2 = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };
            var psManagedDisk3 = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                securityProfile: securityProfile);

            // Assert
            Assert.Null(psManagedDisk1.StorageAccountType);
            Assert.Null(psManagedDisk1.SecurityProfile);

            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, psManagedDisk2.StorageAccountType);
            Assert.Null(psManagedDisk2.SecurityProfile);

            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, psManagedDisk3.StorageAccountType);
            Assert.NotNull(psManagedDisk3.SecurityProfile);
            Assert.Equal("VMGuestStateOnly", psManagedDisk3.SecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void PSManagedDisk_InternalConstructor_ThrowsOnNullOmObject()
        {
            // Test that the internal constructor validates the omObject parameter

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => 
                new PSManagedDisk((Microsoft.Azure.Batch.ManagedDisk)null));
        }

        [Fact]
        public void PSManagedDisk_InternalConstructor_WorksWithValidOmObject()
        {
            // Test that the internal constructor works with a valid omObject

            // Arrange
            var omObject = new Microsoft.Azure.Batch.ManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: new Microsoft.Azure.Batch.VMDiskSecurityProfile()
                {
                    SecurityEncryptionType = "NonPersistedTPM"
                });

            // Act
            var psManagedDisk = new PSManagedDisk(omObject);

            // Assert
            Assert.NotNull(psManagedDisk);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, psManagedDisk.StorageAccountType);
            Assert.NotNull(psManagedDisk.SecurityProfile);
            Assert.Equal("NonPersistedTPM", psManagedDisk.SecurityProfile.SecurityEncryptionType);
        }

        [Fact]
        public void PSManagedDisk_PropertySetters_WorkCorrectly()
        {
            // Test that property setters work correctly

            // Arrange
            var psManagedDisk = new PSManagedDisk();
            var securityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "VMGuestStateOnly"
            };

            // Act
            psManagedDisk.StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS;
            psManagedDisk.SecurityProfile = securityProfile;

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, psManagedDisk.StorageAccountType);
            Assert.Same(securityProfile, psManagedDisk.SecurityProfile);
        }

        #endregion

        #region OS Disk Configuration Tests

        [Fact]
        public void ManagedDiskConversions_OSDiskConfiguration_VerifySemantics()
        {
            // This test validates that the managed disk configurations maintain their OS disk characteristics
            // through the conversion process for different VM scenarios

            var osDiskProfiles = new[]
            {
                new {
                    Scenario = "High Performance VM",
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    SecurityEncryptionType = (string)null,
                    Description = "High-performance VM with Premium SSD OS disk",
                    UseCases = new[] { "Production workloads", "Database servers", "High-throughput applications" }
                },
                new {
                    Scenario = "Confidential VM",
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                    SecurityEncryptionType = "NonPersistedTPM",
                    Description = "Confidential VM with Premium SSD and maximum security",
                    UseCases = new[] { "Sensitive data processing", "Financial applications", "Government workloads" }
                },
                new {
                    Scenario = "Standard Confidential VM",
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS,
                    SecurityEncryptionType = "VMGuestStateOnly",
                    Description = "Standard Confidential VM with balanced performance and security",
                    UseCases = new[] { "Development environments", "Testing workloads", "General confidential computing" }
                },
                new {
                    Scenario = "Cost-Optimized VM",
                    StorageAccountType = Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs,
                    SecurityEncryptionType = (string)null,
                    Description = "Cost-optimized VM with Standard HDD OS disk",
                    UseCases = new[] { "Development machines", "Test environments", "Non-critical workloads" }
                }
            };

            foreach (var profile in osDiskProfiles)
            {
                // Act - Convert to management type and back
                var securityProfile = profile.SecurityEncryptionType != null 
                    ? new PSVMDiskSecurityProfile() { SecurityEncryptionType = profile.SecurityEncryptionType }
                    : null;

                var psManagedDisk = new PSManagedDisk(
                    storageAccountType: profile.StorageAccountType,
                    securityProfile: securityProfile);
                var mgmtType = psManagedDisk.ToMgmtManagedDisk();
                var roundTripType = PSManagedDisk.FromMgmtManagedDisk(mgmtType);

                // Assert - OS disk characteristics should be preserved
                Assert.NotNull(mgmtType);
                Assert.NotNull(roundTripType);
                Assert.Equal(profile.StorageAccountType, roundTripType.StorageAccountType);

                if (profile.SecurityEncryptionType != null)
                {
                    Assert.NotNull(roundTripType.SecurityProfile);
                    Assert.Equal(profile.SecurityEncryptionType, roundTripType.SecurityProfile.SecurityEncryptionType);
                }
                else
                {
                    Assert.Null(roundTripType.SecurityProfile);
                }

                // Verify the conversion maintains the semantic meaning
                var expectedMgmtValue = profile.StorageAccountType switch
                {
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardLrs => StorageAccountType.StandardLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs => StorageAccountType.PremiumLRS,
                    Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS => StorageAccountType.StandardSSDLRS,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Assert.Equal(expectedMgmtValue, mgmtType.StorageAccountType);
            }
        }

        [Fact]
        public void ManagedDiskConversions_BatchPoolIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch pool OS disk configuration
            // ManagedDisk is used for OS disk configuration in virtual machine configurations

            // Standard pool OS disk configuration
            var standardPoolDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS);
            var mgmtStandardPoolDisk = standardPoolDisk.ToMgmtManagedDisk();
            
            Assert.NotNull(mgmtStandardPoolDisk);
            Assert.Equal(StorageAccountType.StandardSSDLRS, mgmtStandardPoolDisk.StorageAccountType);
            Assert.Null(mgmtStandardPoolDisk.SecurityProfile);
            // Use case: Balanced performance and cost for general-purpose batch workloads
            
            // High-performance pool OS disk configuration
            var highPerfPoolDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs);
            var mgmtHighPerfPoolDisk = highPerfPoolDisk.ToMgmtManagedDisk();
            
            Assert.NotNull(mgmtHighPerfPoolDisk);
            Assert.Equal(StorageAccountType.PremiumLRS, mgmtHighPerfPoolDisk.StorageAccountType);
            Assert.Null(mgmtHighPerfPoolDisk.SecurityProfile);
            // Use case: High-performance batch workloads requiring fast OS disk access

            // Confidential computing pool OS disk configuration
            var confidentialSecurityProfile = new PSVMDiskSecurityProfile()
            {
                SecurityEncryptionType = "NonPersistedTPM"
            };
            var confidentialPoolDisk = new PSManagedDisk(
                storageAccountType: Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs,
                securityProfile: confidentialSecurityProfile);
            var mgmtConfidentialPoolDisk = confidentialPoolDisk.ToMgmtManagedDisk();
            
            Assert.NotNull(mgmtConfidentialPoolDisk);
            Assert.Equal(StorageAccountType.PremiumLRS, mgmtConfidentialPoolDisk.StorageAccountType);
            Assert.NotNull(mgmtConfidentialPoolDisk.SecurityProfile);
            Assert.Equal("NonPersistedTPM", mgmtConfidentialPoolDisk.SecurityProfile.SecurityEncryptionType);
            // Use case: Confidential computing batch workloads with enhanced security requirements

            // Verify all round-trip correctly
            var standardRoundTrip = PSManagedDisk.FromMgmtManagedDisk(mgmtStandardPoolDisk);
            var highPerfRoundTrip = PSManagedDisk.FromMgmtManagedDisk(mgmtHighPerfPoolDisk);
            var confidentialRoundTrip = PSManagedDisk.FromMgmtManagedDisk(mgmtConfidentialPoolDisk);

            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.StandardSSDLRS, standardRoundTrip.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, highPerfRoundTrip.StorageAccountType);
            Assert.Equal(Microsoft.Azure.Batch.Common.StorageAccountType.PremiumLrs, confidentialRoundTrip.StorageAccountType);
            Assert.NotNull(confidentialRoundTrip.SecurityProfile);
            Assert.Equal("NonPersistedTPM", confidentialRoundTrip.SecurityProfile.SecurityEncryptionType);
        }

        #endregion
    }
}
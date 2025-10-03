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
    public class UtilsDiskEncryptionTargetTests
    {
        #region toMgmtDiskEncryptionTarget Tests

        [Fact]
        public void ToMgmtDiskEncryptionTarget_OsDisk_ReturnsOsDisk()
        {
            // Arrange
            var psDiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;

            // Act
            var result = Utils.Utils.toMgmtDiskEncryptionTarget(psDiskEncryptionTarget);

            // Assert
            Assert.Equal(DiskEncryptionTarget.OsDisk, result);
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_TemporaryDisk_ReturnsTemporaryDisk()
        {
            // Arrange
            var psDiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk;

            // Act
            var result = Utils.Utils.toMgmtDiskEncryptionTarget(psDiskEncryptionTarget);

            // Assert
            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, DiskEncryptionTarget.OsDisk)]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, DiskEncryptionTarget.TemporaryDisk)]
        public void ToMgmtDiskEncryptionTarget_AllValidValues_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.DiskEncryptionTarget input,
            DiskEncryptionTarget expected)
        {
            // Act
            var result = Utils.Utils.toMgmtDiskEncryptionTarget(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(Microsoft.Azure.Batch.Common.DiskEncryptionTarget);

            // Act
            var result = Utils.Utils.toMgmtDiskEncryptionTarget(defaultValue);

            // Assert
            // Default DiskEncryptionTarget is typically OsDisk (0)
            Assert.Equal(DiskEncryptionTarget.OsDisk, result);
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each disk encryption target

            // Arrange & Act & Assert
            // OsDisk: Encrypt the OS disk
            var osDiskResult = Utils.Utils.toMgmtDiskEncryptionTarget(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk);
            Assert.Equal(DiskEncryptionTarget.OsDisk, osDiskResult);

            // TemporaryDisk: Encrypt the temporary disk
            var temporaryDiskResult = Utils.Utils.toMgmtDiskEncryptionTarget(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk);
            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, temporaryDiskResult);
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var psDiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk;

            // Act - Call static method directly on class
            var result = Utils.Utils.toMgmtDiskEncryptionTarget(psDiskEncryptionTarget);

            // Assert
            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, result);
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.toMgmtDiskEncryptionTarget(value);
                Assert.True(Enum.IsDefined(typeof(DiskEncryptionTarget), result));
            }
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_ReturnsNonNullableType()
        {
            // This test verifies that the method returns a non-nullable DiskEncryptionTarget

            // Arrange
            var psDiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;

            // Act
            var result = Utils.Utils.toMgmtDiskEncryptionTarget(psDiskEncryptionTarget);

            // Assert
            Assert.IsType<DiskEncryptionTarget>(result);
        }

        [Fact]
        public void ToMgmtDiskEncryptionTarget_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var psOsDisk = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;
            var psTemporaryDisk = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk;

            // Act
            var mgmtOsDisk = Utils.Utils.toMgmtDiskEncryptionTarget(psOsDisk);
            var mgmtTemporaryDisk = Utils.Utils.toMgmtDiskEncryptionTarget(psTemporaryDisk);

            // Assert
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)psOsDisk, (int)mgmtOsDisk);
            Assert.Equal((int)psTemporaryDisk, (int)mgmtTemporaryDisk);
        }

        #endregion

        #region fromMgmtDiskEncryptionTarget Tests

        [Fact]
        public void FromMgmtDiskEncryptionTarget_OsDisk_ReturnsOsDisk()
        {
            // Arrange
            var mgmtDiskEncryptionTarget = DiskEncryptionTarget.OsDisk;

            // Act
            var result = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_TemporaryDisk_ReturnsTemporaryDisk()
        {
            // Arrange
            var mgmtDiskEncryptionTarget = DiskEncryptionTarget.TemporaryDisk;

            // Act
            var result = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, result);
        }

        [Theory]
        [InlineData(DiskEncryptionTarget.OsDisk, Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk)]
        [InlineData(DiskEncryptionTarget.TemporaryDisk, Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk)]
        public void FromMgmtDiskEncryptionTarget_AllValidValues_ReturnsCorrectMapping(
            DiskEncryptionTarget input,
            Microsoft.Azure.Batch.Common.DiskEncryptionTarget expected)
        {
            // Act
            var result = Utils.Utils.fromMgmtDiskEncryptionTarget(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_DefaultValue_HandlesCorrectly()
        {
            // Arrange
            var defaultValue = default(DiskEncryptionTarget);

            // Act
            var result = Utils.Utils.fromMgmtDiskEncryptionTarget(defaultValue);

            // Assert
            // Default DiskEncryptionTarget is typically OsDisk (0)
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_EnumValueConsistency_EnsuresCorrectEnumMapping()
        {
            // This test ensures that the mapping logic correctly handles all defined enum values
            // and verifies that the conversion maintains the semantic meaning of each disk encryption target

            // Arrange & Act & Assert
            // OsDisk: Encrypt the OS disk
            var osDiskResult = Utils.Utils.fromMgmtDiskEncryptionTarget(DiskEncryptionTarget.OsDisk);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, osDiskResult);

            // TemporaryDisk: Encrypt the temporary disk
            var temporaryDiskResult = Utils.Utils.fromMgmtDiskEncryptionTarget(DiskEncryptionTarget.TemporaryDisk);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, temporaryDiskResult);
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_StaticMethod_DoesNotRequireInstance()
        {
            // This test verifies that the method is properly static and can be called without instantiation

            // Arrange
            var mgmtDiskEncryptionTarget = DiskEncryptionTarget.OsDisk;

            // Act - Call static method directly on class
            var result = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk, result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the enum conversion is efficient for all values

            // Arrange
            var enumValues = new[]
            {
                DiskEncryptionTarget.OsDisk,
                DiskEncryptionTarget.TemporaryDisk
            };

            // Act & Assert - Each conversion should complete without delay
            foreach (var value in enumValues)
            {
                var result = Utils.Utils.fromMgmtDiskEncryptionTarget(value);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.DiskEncryptionTarget), result));
            }
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_ReturnsNonNullableType()
        {
            // This test verifies that the method returns a non-nullable DiskEncryptionTarget

            // Arrange
            var mgmtDiskEncryptionTarget = DiskEncryptionTarget.TemporaryDisk;

            // Act
            var result = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.IsType<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>(result);
        }

        [Fact]
        public void FromMgmtDiskEncryptionTarget_CastingBehavior_VerifyDirectCast()
        {
            // This test verifies that the conversion uses direct casting as implemented

            // Arrange
            var mgmtOsDisk = DiskEncryptionTarget.OsDisk;
            var mgmtTemporaryDisk = DiskEncryptionTarget.TemporaryDisk;

            // Act
            var psOsDisk = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtOsDisk);
            var psTemporaryDisk = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtTemporaryDisk);

            // Assert
            // Verify that the underlying values match (direct cast behavior)
            Assert.Equal((int)mgmtOsDisk, (int)psOsDisk);
            Assert.Equal((int)mgmtTemporaryDisk, (int)psTemporaryDisk);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesOsDiskValue()
        {
            // Arrange
            var originalPsDiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;

            // Act
            var mgmtDiskEncryptionTarget = Utils.Utils.toMgmtDiskEncryptionTarget(originalPsDiskEncryptionTarget);
            var roundTripPsDiskEncryptionTarget = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.Equal(originalPsDiskEncryptionTarget, roundTripPsDiskEncryptionTarget);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesTemporaryDiskValue()
        {
            // Arrange
            var originalPsDiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk;

            // Act
            var mgmtDiskEncryptionTarget = Utils.Utils.toMgmtDiskEncryptionTarget(originalPsDiskEncryptionTarget);
            var roundTripPsDiskEncryptionTarget = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.Equal(originalPsDiskEncryptionTarget, roundTripPsDiskEncryptionTarget);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk)]
        [InlineData(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk)]
        public void RoundTripConversion_AllValidValues_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.DiskEncryptionTarget originalDiskEncryptionTarget)
        {
            // Act
            var mgmtDiskEncryptionTarget = Utils.Utils.toMgmtDiskEncryptionTarget(originalDiskEncryptionTarget);
            var roundTripDiskEncryptionTarget = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);

            // Assert
            Assert.Equal(originalDiskEncryptionTarget, roundTripDiskEncryptionTarget);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var originalMgmtValues = new[]
            {
                DiskEncryptionTarget.OsDisk,
                DiskEncryptionTarget.TemporaryDisk
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act
                var psValue = Utils.Utils.fromMgmtDiskEncryptionTarget(originalValue);
                var roundTripValue = Utils.Utils.toMgmtDiskEncryptionTarget(psValue);

                // Assert
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        #endregion

        #region Enum Value Verification Tests

        [Fact]
        public void DiskEncryptionTarget_VerifyEnumMemberCount_EnsuresAllValuesHandled()
        {
            // This test helps ensure that if new enum values are added, the conversion methods are updated

            // Arrange
            var psDiskEncryptionTargetValues = Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.DiskEncryptionTarget));
            var mgmtDiskEncryptionTargetValues = Enum.GetValues(typeof(DiskEncryptionTarget));

            // Act & Assert
            // Verify that both enums have the same number of values (assuming 1:1 mapping)
            Assert.Equal(psDiskEncryptionTargetValues.Length, mgmtDiskEncryptionTargetValues.Length);

            // Verify that each PS enum value can be converted successfully
            foreach (Microsoft.Azure.Batch.Common.DiskEncryptionTarget psValue in psDiskEncryptionTargetValues)
            {
                var result = Utils.Utils.toMgmtDiskEncryptionTarget(psValue);
                Assert.True(Enum.IsDefined(typeof(DiskEncryptionTarget), result));
            }

            // Verify that each management enum value can be converted successfully
            foreach (DiskEncryptionTarget mgmtValue in mgmtDiskEncryptionTargetValues)
            {
                var result = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtValue);
                Assert.True(Enum.IsDefined(typeof(Microsoft.Azure.Batch.Common.DiskEncryptionTarget), result));
            }
        }

        [Fact]
        public void DiskEncryptionTarget_BijectiveMapping_EnsuresUniqueConversion()
        {
            // This test verifies that the mapping is bijective (one-to-one)

            // Arrange
            var psValues = new[]
            {
                Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk
            };

            var mgmtValues = new[]
            {
                DiskEncryptionTarget.OsDisk,
                DiskEncryptionTarget.TemporaryDisk
            };

            // Act - Convert PS to Management
            var convertedMgmtValues = new DiskEncryptionTarget[psValues.Length];
            for (int i = 0; i < psValues.Length; i++)
            {
                convertedMgmtValues[i] = Utils.Utils.toMgmtDiskEncryptionTarget(psValues[i]);
            }

            // Act - Convert Management to PS
            var convertedPsValues = new Microsoft.Azure.Batch.Common.DiskEncryptionTarget[mgmtValues.Length];
            for (int i = 0; i < mgmtValues.Length; i++)
            {
                convertedPsValues[i] = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtValues[i]);
            }

            // Assert - Each management enum value should be unique (no duplicates)
            var distinctMgmtValues = convertedMgmtValues.Distinct().ToArray();
            Assert.Equal(convertedMgmtValues.Length, distinctMgmtValues.Length);

            // Assert - Each PS enum value should be unique (no duplicates)
            var distinctPsValues = convertedPsValues.Distinct().ToArray();
            Assert.Equal(convertedPsValues.Length, distinctPsValues.Length);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void DiskEncryptionTargetConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test OsDisk semantics - Encrypt the operating system disk
            var psOsDisk = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;
            var mgmtOsDisk = Utils.Utils.toMgmtDiskEncryptionTarget(psOsDisk);
            var backToPs = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtOsDisk);

            Assert.Equal(DiskEncryptionTarget.OsDisk, mgmtOsDisk);
            Assert.Equal(psOsDisk, backToPs);

            // Test TemporaryDisk semantics - Encrypt the temporary disk
            var psTemporaryDisk = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk;
            var mgmtTemporaryDisk = Utils.Utils.toMgmtDiskEncryptionTarget(psTemporaryDisk);
            var backToPsTemporary = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtTemporaryDisk);

            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, mgmtTemporaryDisk);
            Assert.Equal(psTemporaryDisk, backToPsTemporary);
        }

        [Fact]
        public void DiskEncryptionTargetConversions_BatchDiskEncryptionContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch disk encryption configuration
            // DiskEncryptionTarget is used to specify which disks should be encrypted on Batch compute nodes

            // Arrange - Test with different disk encryption scenarios
            var diskEncryptionScenarios = new[]
            {
                // OS disk encryption for secure boot and system files
                new {
                    DiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    Description = "Encrypt OS disk for secure boot and system file protection"
                },
                // Temporary disk encryption for application data and temp files
                new {
                    DiskEncryptionTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk,
                    Description = "Encrypt temporary disk for application data and temp file protection"
                }
            };

            foreach (var scenario in diskEncryptionScenarios)
            {
                // Act
                var mgmtDiskEncryptionTarget = Utils.Utils.toMgmtDiskEncryptionTarget(scenario.DiskEncryptionTarget);

                // Assert - Should convert correctly for Batch disk encryption configuration
                var expectedMgmtTarget = scenario.DiskEncryptionTarget == Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk
                    ? DiskEncryptionTarget.OsDisk
                    : DiskEncryptionTarget.TemporaryDisk;
                Assert.Equal(expectedMgmtTarget, mgmtDiskEncryptionTarget);

                // Verify round-trip conversion maintains disk encryption semantics
                var backToPs = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtDiskEncryptionTarget);
                Assert.Equal(scenario.DiskEncryptionTarget, backToPs);
            }
        }

        [Fact]
        public void DiskEncryptionTargetConversions_DirectCastingBehavior_VerifyImplementation()
        {
            // This test verifies that the methods use direct casting as implemented
            // This is important because it ensures the enum values have the same underlying representation

            // Test that conversion preserves underlying integer values
            foreach (Microsoft.Azure.Batch.Common.DiskEncryptionTarget psValue in Enum.GetValues(typeof(Microsoft.Azure.Batch.Common.DiskEncryptionTarget)))
            {
                var mgmtResult = Utils.Utils.toMgmtDiskEncryptionTarget(psValue);
                Assert.Equal((int)psValue, (int)mgmtResult);
            }

            foreach (DiskEncryptionTarget mgmtValue in Enum.GetValues(typeof(DiskEncryptionTarget)))
            {
                var psResult = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtValue);
                Assert.Equal((int)mgmtValue, (int)psResult);
            }
        }

        [Fact]
        public void DiskEncryptionTargetConversions_DiskEncryptionIntegration_VerifySemantics()
        {
            // This test validates the semantic usage in the context of Azure Batch disk encryption configuration
            // DiskEncryptionTarget determines which disks are encrypted at rest for security compliance

            // OsDisk encryption semantics - Protect system files and boot process
            var osDiskTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;
            var mgmtOsDiskTarget = Utils.Utils.toMgmtDiskEncryptionTarget(osDiskTarget);
            
            Assert.Equal(DiskEncryptionTarget.OsDisk, mgmtOsDiskTarget);
            // Use case: Compliance requirements for encrypting system partitions
            
            // TemporaryDisk encryption semantics - Protect application data and temporary files
            var temporaryDiskTarget = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk;
            var mgmtTemporaryDiskTarget = Utils.Utils.toMgmtDiskEncryptionTarget(temporaryDiskTarget);
            
            Assert.Equal(DiskEncryptionTarget.TemporaryDisk, mgmtTemporaryDiskTarget);
            // Use case: Secure processing of sensitive data in temporary storage

            // Verify all round-trip correctly
            var osDiskRoundTrip = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtOsDiskTarget);
            var temporaryDiskRoundTrip = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtTemporaryDiskTarget);

            Assert.Equal(osDiskTarget, osDiskRoundTrip);
            Assert.Equal(temporaryDiskTarget, temporaryDiskRoundTrip);
        }

        [Fact]
        public void DiskEncryptionTargetConversions_SecurityComplianceContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of security compliance
            // DiskEncryptionTarget is essential for meeting data protection and compliance requirements

            // Arrange - Test with security compliance scenarios
            var complianceScenarios = new[]
            {
                // FIPS compliance requiring OS disk encryption
                new {
                    Target = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk,
                    ComplianceType = "FIPS 140-2",
                    Description = "OS disk encryption for FIPS compliance and secure boot protection"
                },
                // PCI DSS compliance requiring temporary disk encryption
                new {
                    Target = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk,
                    ComplianceType = "PCI DSS",
                    Description = "Temporary disk encryption for payment processing compliance"
                }
            };

            foreach (var scenario in complianceScenarios)
            {
                // Act
                var mgmtTarget = Utils.Utils.toMgmtDiskEncryptionTarget(scenario.Target);
                var roundTripTarget = Utils.Utils.fromMgmtDiskEncryptionTarget(mgmtTarget);

                // Assert - Compliance semantics should be preserved
                Assert.Equal(scenario.Target, roundTripTarget);
                
                // Verify the conversion maintains the security context
                var expectedMgmtValue = scenario.Target switch
                {
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk => DiskEncryptionTarget.OsDisk,
                    Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk => DiskEncryptionTarget.TemporaryDisk,
                    _ => throw new ArgumentOutOfRangeException()
                };

                Assert.Equal(expectedMgmtValue, mgmtTarget);
            }
        }

        [Fact]
        public void DiskEncryptionTargetConversions_NonNullableHandling_VerifyBehavior()
        {
            // This test verifies the non-nullable handling in these conversion methods
            // Unlike other conversion methods, these work with non-nullable enums

            // Both methods handle non-nullable types correctly
            var osDiskValue = Microsoft.Azure.Batch.Common.DiskEncryptionTarget.OsDisk;
            var mgmtResult = Utils.Utils.toMgmtDiskEncryptionTarget(osDiskValue);
            Assert.Equal(DiskEncryptionTarget.OsDisk, mgmtResult);

            var temporaryDiskValue = DiskEncryptionTarget.TemporaryDisk;
            var psResult = Utils.Utils.fromMgmtDiskEncryptionTarget(temporaryDiskValue);
            Assert.Equal(Microsoft.Azure.Batch.Common.DiskEncryptionTarget.TemporaryDisk, psResult);

            // Verify that the methods return non-nullable values
            Assert.IsType<DiskEncryptionTarget>(mgmtResult);
            Assert.IsType<Microsoft.Azure.Batch.Common.DiskEncryptionTarget>(psResult);
        }

        #endregion
    }
}
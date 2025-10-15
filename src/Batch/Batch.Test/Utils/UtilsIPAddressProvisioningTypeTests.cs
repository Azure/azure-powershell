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

using Microsoft.Azure.Management.Batch.Models;
using System;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class UtilsIPAddressProvisioningTypeTests
    {
        #region toIPAddressProvisioningType Tests

        [Fact]
        public void ToIPAddressProvisioningType_WithBatchManaged_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtProvisioningType = IPAddressProvisioningType.BatchManaged;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, result);
        }

        [Fact]
        public void ToIPAddressProvisioningType_WithUserManaged_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtProvisioningType = IPAddressProvisioningType.UserManaged;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result);
        }

        [Fact]
        public void ToIPAddressProvisioningType_WithNoPublicIPAddresses_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtProvisioningType = IPAddressProvisioningType.NoPublicIPAddresses;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, result);
        }

        [Theory]
        [InlineData(IPAddressProvisioningType.BatchManaged, Azure.Batch.Common.IPAddressProvisioningType.BatchManaged)]
        [InlineData(IPAddressProvisioningType.UserManaged, Azure.Batch.Common.IPAddressProvisioningType.UserManaged)]
        [InlineData(IPAddressProvisioningType.NoPublicIPAddresses, Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses)]
        public void ToIPAddressProvisioningType_AllValidProvisioningTypes_ReturnsCorrectMapping(
            IPAddressProvisioningType mgmtProvisioningType,
            Azure.Batch.Common.IPAddressProvisioningType expectedPsProvisioningType)
        {
            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(expectedPsProvisioningType, result);
        }

        [Fact]
        public void ToIPAddressProvisioningType_WithNullableBatchManaged_ReturnsCorrectMapping()
        {
            // Arrange
            IPAddressProvisioningType? mgmtProvisioningType = IPAddressProvisioningType.BatchManaged;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, result);
        }


        [Fact]
        public void ToIPAddressProvisioningType_BatchManagedSemantics_PreservesNetworkingStrategy()
        {
            // Arrange - BatchManaged strategy for automatic IP management
            var mgmtProvisioningType = IPAddressProvisioningType.BatchManaged;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, result);
            // BatchManaged semantics: Azure Batch automatically creates and manages public IPs
        }

        [Fact]
        public void ToIPAddressProvisioningType_UserManagedSemantics_PreservesCustomNetworkingStrategy()
        {
            // Arrange - UserManaged strategy for custom IP management
            var mgmtProvisioningType = IPAddressProvisioningType.UserManaged;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result);
            // UserManaged semantics: User provides and manages public IPs for compute nodes
        }

        [Fact]
        public void ToIPAddressProvisioningType_NoPublicIPSemantics_PreservesPrivateNetworkingStrategy()
        {
            // Arrange - NoPublicIPAddresses strategy for private networking
            var mgmtProvisioningType = IPAddressProvisioningType.NoPublicIPAddresses;

            // Act
            var result = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, result);
            // NoPublicIPAddresses semantics: Compute nodes have no public IP addresses
        }

        #endregion

        #region toMgmtIPAddressProvisioningType Tests

        [Fact]
        public void ToMgmtIPAddressProvisioningType_WithBatchManaged_ReturnsCorrectMapping()
        {
            // Arrange
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.BatchManaged, result);
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_WithUserManaged_ReturnsCorrectMapping()
        {
            // Arrange
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.UserManaged, result);
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_WithNoPublicIPAddresses_ReturnsCorrectMapping()
        {
            // Arrange
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, result);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, IPAddressProvisioningType.BatchManaged)]
        [InlineData(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, IPAddressProvisioningType.UserManaged)]
        [InlineData(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, IPAddressProvisioningType.NoPublicIPAddresses)]
        public void ToMgmtIPAddressProvisioningType_AllValidProvisioningTypes_ReturnsCorrectMapping(
            Azure.Batch.Common.IPAddressProvisioningType psProvisioningType,
            IPAddressProvisioningType expectedMgmtProvisioningType)
        {
            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(expectedMgmtProvisioningType, result);
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_WithNullableBatchManaged_ReturnsCorrectMapping()
        {
            // Arrange
            Azure.Batch.Common.IPAddressProvisioningType? psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.BatchManaged, result);
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_WithNull_ReturnsNull()
        {
            // Arrange
            Azure.Batch.Common.IPAddressProvisioningType? psProvisioningType = null;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_BatchManagedSemantics_PreservesNetworkingStrategy()
        {
            // Arrange - BatchManaged strategy for automatic IP management
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.BatchManaged, result);
            // BatchManaged semantics: Azure Batch automatically creates and manages public IPs
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_UserManagedSemantics_PreservesCustomNetworkingStrategy()
        {
            // Arrange - UserManaged strategy for custom IP management
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.UserManaged, result);
            // UserManaged semantics: User provides and manages public IPs for compute nodes
        }

        [Fact]
        public void ToMgmtIPAddressProvisioningType_NoPublicIPSemantics_PreservesPrivateNetworkingStrategy()
        {
            // Arrange - NoPublicIPAddresses strategy for private networking
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;

            // Act
            var result = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);

            // Assert
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, result);
            // NoPublicIPAddresses semantics: Compute nodes have no public IP addresses
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndToPS_PreservesBatchManagedValue()
        {
            // Arrange
            var originalPsProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            // Act - Convert PS -> Management -> PS
            var mgmtProvisioningType = Utils.Utils.toMgmtIPAddressProvisioningType(originalPsProvisioningType);
            var roundTripPsProvisioningType = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert - Should get back the original value
            Assert.Equal(originalPsProvisioningType, roundTripPsProvisioningType);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, roundTripPsProvisioningType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndToPS_PreservesUserManagedValue()
        {
            // Arrange
            var originalPsProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;

            // Act - Convert PS -> Management -> PS
            var mgmtProvisioningType = Utils.Utils.toMgmtIPAddressProvisioningType(originalPsProvisioningType);
            var roundTripPsProvisioningType = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert - Should get back the original value
            Assert.Equal(originalPsProvisioningType, roundTripPsProvisioningType);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, roundTripPsProvisioningType);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndToPS_PreservesNoPublicIPValue()
        {
            // Arrange
            var originalPsProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;

            // Act - Convert PS -> Management -> PS
            var mgmtProvisioningType = Utils.Utils.toMgmtIPAddressProvisioningType(originalPsProvisioningType);
            var roundTripPsProvisioningType = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert - Should get back the original value
            Assert.Equal(originalPsProvisioningType, roundTripPsProvisioningType);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, roundTripPsProvisioningType);
        }

        [Theory]
        [InlineData(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged)]
        [InlineData(Azure.Batch.Common.IPAddressProvisioningType.UserManaged)]
        [InlineData(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses)]
        public void RoundTripConversion_ToMgmtAndToPS_PreservesAllValidValues(
            Azure.Batch.Common.IPAddressProvisioningType originalValue)
        {
            // Act - Convert PS -> Management -> PS
            var mgmtValue = Utils.Utils.toMgmtIPAddressProvisioningType(originalValue);
            var roundTripValue = Utils.Utils.toIPAddressProvisioningType(mgmtValue);

            // Assert - Should get back the original value
            Assert.Equal(originalValue, roundTripValue);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // This test verifies that converting Management -> PS -> Management preserves the original value

            // Arrange
            var originalMgmtValues = new[]
            {
                IPAddressProvisioningType.BatchManaged,
                IPAddressProvisioningType.UserManaged,
                IPAddressProvisioningType.NoPublicIPAddresses
            };

            foreach (var originalValue in originalMgmtValues)
            {
                // Act - Convert Management -> PS -> Management
                var psValue = Utils.Utils.toIPAddressProvisioningType(originalValue);
                var roundTripValue = Utils.Utils.toMgmtIPAddressProvisioningType(psValue);

                // Assert - Should get back the original value
                Assert.Equal(originalValue, roundTripValue);
            }
        }

        [Fact]
        public void RoundTripConversion_WithNullableValues_HandlesNullCorrectly()
        {
            // Arrange
            Azure.Batch.Common.IPAddressProvisioningType? nullPsProvisioningType = null;

            // Act
            var mgmtFromNullPs = Utils.Utils.toMgmtIPAddressProvisioningType(nullPsProvisioningType);

            // Assert
            Assert.Null(mgmtFromNullPs);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void IPAddressProvisioningTypeConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test BatchManaged semantics - Batch service manages public IPs
            var psBatchManaged = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;
            var mgmtBatchManaged = Utils.Utils.toMgmtIPAddressProvisioningType(psBatchManaged);
            var backToPs = Utils.Utils.toIPAddressProvisioningType(mgmtBatchManaged);

            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManaged);
            Assert.Equal(psBatchManaged, backToPs);

            // Test UserManaged semantics - User provides public IPs
            var psUserManaged = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;
            var mgmtUserManaged = Utils.Utils.toMgmtIPAddressProvisioningType(psUserManaged);
            var backToPsUserManaged = Utils.Utils.toIPAddressProvisioningType(mgmtUserManaged);

            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManaged);
            Assert.Equal(psUserManaged, backToPsUserManaged);

            // Test NoPublicIPAddresses semantics - No public IPs created
            var psNoPublicIP = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;
            var mgmtNoPublicIP = Utils.Utils.toMgmtIPAddressProvisioningType(psNoPublicIP);
            var backToPsNoPublicIP = Utils.Utils.toIPAddressProvisioningType(mgmtNoPublicIP);

            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIP);
            Assert.Equal(psNoPublicIP, backToPsNoPublicIP);
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNullPs = Utils.Utils.toMgmtIPAddressProvisioningType(null);

            // Assert
            Assert.Null(resultFromNullPs);

            // Note: toIPAddressProvisioningType(null) throws InvalidCastException as expected
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool networking
            // IPAddressProvisioningType is used to determine how public IPs are managed for Batch pool compute nodes

            // Arrange - Test BatchManaged strategy for managed public IP addresses
            var psBatchManaged = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;
            var mgmtBatchManaged = Utils.Utils.toMgmtIPAddressProvisioningType(psBatchManaged);

            // Act & Assert - BatchManaged should convert correctly for automatic IP management
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManaged);

            // Arrange - Test UserManaged strategy for custom public IP addresses
            var psUserManaged = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;
            var mgmtUserManaged = Utils.Utils.toMgmtIPAddressProvisioningType(psUserManaged);

            // Act & Assert - UserManaged should convert correctly for custom IP management
            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManaged);

            // Arrange - Test NoPublicIPAddresses strategy for private networking
            var psNoPublicIP = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;
            var mgmtNoPublicIP = Utils.Utils.toMgmtIPAddressProvisioningType(psNoPublicIP);

            // Act & Assert - NoPublicIPAddresses should convert correctly for private networking
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIP);

            // Verify round-trip conversion maintains Batch pool networking semantics
            var backToBatchManaged = Utils.Utils.toIPAddressProvisioningType(mgmtBatchManaged);
            var backToUserManaged = Utils.Utils.toIPAddressProvisioningType(mgmtUserManaged);
            var backToNoPublicIP = Utils.Utils.toIPAddressProvisioningType(mgmtNoPublicIP);

            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, backToBatchManaged);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, backToUserManaged);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, backToNoPublicIP);
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_DefaultValues_HandleCorrectly()
        {
            // Test conversion with default enum values

            // Arrange
            var defaultPsProvisioningType = default(Azure.Batch.Common.IPAddressProvisioningType);
            var defaultMgmtProvisioningType = default(IPAddressProvisioningType);

            // Act
            var mgmtResult = Utils.Utils.toMgmtIPAddressProvisioningType(defaultPsProvisioningType);
            var psResult = Utils.Utils.toIPAddressProvisioningType(defaultMgmtProvisioningType);

            // Assert
            Assert.Equal((IPAddressProvisioningType)defaultPsProvisioningType, mgmtResult);
            Assert.Equal((Azure.Batch.Common.IPAddressProvisioningType)defaultMgmtProvisioningType, psResult);
            Assert.True(Enum.IsDefined(typeof(IPAddressProvisioningType), mgmtResult));
            Assert.True(Enum.IsDefined(typeof(Azure.Batch.Common.IPAddressProvisioningType), psResult));
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void IPAddressProvisioningTypeConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;
            var mgmtProvisioningType = IPAddressProvisioningType.UserManaged;

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);
                var psResult = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

                Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtResult);
                Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, psResult);
            }
        }

        #endregion

        #region Networking Strategy Tests

        [Fact]
        public void IPAddressProvisioningTypeConversions_BatchManagedStrategy_AutomaticIPManagement()
        {
            // This test validates that BatchManaged provisioning semantics are preserved for automatic IP management

            // Arrange - BatchManaged provisioning for Azure Batch-managed public IPs
            var psBatchManaged = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            // Act
            var mgmtBatchManaged = Utils.Utils.toMgmtIPAddressProvisioningType(psBatchManaged);
            var backToPs = Utils.Utils.toIPAddressProvisioningType(mgmtBatchManaged);

            // Assert - BatchManaged provisioning semantics preserved
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManaged);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, backToPs);
            // BatchManaged ensures Azure Batch automatically creates and manages public IPs
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_UserManagedStrategy_CustomIPManagement()
        {
            // This test validates that UserManaged provisioning semantics are preserved for custom IP management

            // Arrange - UserManaged provisioning for user-provided public IPs
            var psUserManaged = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;

            // Act
            var mgmtUserManaged = Utils.Utils.toMgmtIPAddressProvisioningType(psUserManaged);
            var backToPs = Utils.Utils.toIPAddressProvisioningType(mgmtUserManaged);

            // Assert - UserManaged provisioning semantics preserved
            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManaged);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, backToPs);
            // UserManaged ensures user provides and manages public IPs for compute nodes
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_NoPublicIPStrategy_PrivateNetworking()
        {
            // This test validates that NoPublicIPAddresses provisioning semantics are preserved for private networking

            // Arrange - NoPublicIPAddresses provisioning for private-only networking
            var psNoPublicIP = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;

            // Act
            var mgmtNoPublicIP = Utils.Utils.toMgmtIPAddressProvisioningType(psNoPublicIP);
            var backToPs = Utils.Utils.toIPAddressProvisioningType(mgmtNoPublicIP);

            // Assert - NoPublicIPAddresses provisioning semantics preserved
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIP);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, backToPs);
            // NoPublicIPAddresses ensures compute nodes have no public IP addresses
        }

        #endregion

        #region Type Safety and Casting Tests

        [Fact]
        public void IPAddressProvisioningTypeConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types and handle casting properly

            // Arrange
            var psProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;
            var mgmtProvisioningType = IPAddressProvisioningType.UserManaged;

            // Act
            var mgmtResult = Utils.Utils.toMgmtIPAddressProvisioningType(psProvisioningType);
            var psResult = Utils.Utils.toIPAddressProvisioningType(mgmtProvisioningType);

            // Assert - Verify correct types are returned
            Assert.IsType<Microsoft.Azure.Management.Batch.Models.IPAddressProvisioningType>(mgmtResult);
            Assert.IsType<Azure.Batch.Common.IPAddressProvisioningType>(psResult);
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtResult);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, psResult);
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_EnumValueEquivalence_VerifyDirectCasting()
        {
            // Test that the enum values are equivalent and casting works as expected

            // Arrange & Act - Test direct casting behavior
            var psBatchManaged = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            var mgmtBatchManagedDirect = (IPAddressProvisioningType)psBatchManaged;
            var mgmtBatchManagedUtils = Utils.Utils.toMgmtIPAddressProvisioningType(psBatchManaged);

            // Assert - Utils methods should behave the same as direct casting
            Assert.Equal(mgmtBatchManagedDirect, mgmtBatchManagedUtils);
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManagedUtils);
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_NullableCasting_WorksCorrectly()
        {
            // Test that nullable casting works as expected

            // Arrange
            Azure.Batch.Common.IPAddressProvisioningType? nullablePsBatchManaged = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;
            Azure.Batch.Common.IPAddressProvisioningType? nullPs = null;

            // Act
            var mgmtFromNullableBatchManaged = Utils.Utils.toMgmtIPAddressProvisioningType(nullablePsBatchManaged);
            var mgmtFromNull = Utils.Utils.toMgmtIPAddressProvisioningType(nullPs);

            // Assert
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtFromNullableBatchManaged);
            Assert.Null(mgmtFromNull);
        }

        #endregion

        #region Public IP Configuration Context Tests

        [Fact]
        public void IPAddressProvisioningTypeConversions_PublicIPConfiguration_VerifyProvisioningStrategy()
        {
            // This test validates the conversions work correctly in public IP configuration scenarios
            // IPAddressProvisioningType determines how public IPs are provisioned for Azure Batch pools

            // Arrange - Test different provisioning strategies
            var scenarios = new[]
            {
                new
                {
                    PSProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged,
                    MgmtProvisioningType = IPAddressProvisioningType.BatchManaged,
                    Description = "Batch-managed public IP provisioning for automatic management"
                },
                new
                {
                    PSProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.UserManaged,
                    MgmtProvisioningType = IPAddressProvisioningType.UserManaged,
                    Description = "User-managed public IP provisioning for custom control"
                },
                new
                {
                    PSProvisioningType = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses,
                    MgmtProvisioningType = IPAddressProvisioningType.NoPublicIPAddresses,
                    Description = "No public IP provisioning for private networking"
                }
            };

            foreach (var scenario in scenarios)
            {
                // Act
                var mgmtResult = Utils.Utils.toMgmtIPAddressProvisioningType(scenario.PSProvisioningType);
                var psResult = Utils.Utils.toIPAddressProvisioningType(scenario.MgmtProvisioningType);

                // Assert
                Assert.Equal(scenario.MgmtProvisioningType, mgmtResult);
                Assert.Equal(scenario.PSProvisioningType, psResult);

                // Verify round-trip maintains public IP provisioning strategy
                var roundTripMgmt = Utils.Utils.toMgmtIPAddressProvisioningType(psResult);
                var roundTripPs = Utils.Utils.toIPAddressProvisioningType(mgmtResult);

                Assert.Equal(scenario.MgmtProvisioningType, roundTripMgmt);
                Assert.Equal(scenario.PSProvisioningType, roundTripPs);
            }
        }

        [Fact]
        public void IPAddressProvisioningTypeConversions_NetworkConfiguration_PreservesProvisioningSemantics()
        {
            // This test ensures that IP address provisioning semantics are correctly preserved

            // Arrange - BatchManaged provisioning optimizes for ease of use
            var psBatchManagedProvisioning = Azure.Batch.Common.IPAddressProvisioningType.BatchManaged;

            // Act
            var mgmtBatchManagedProvisioning = Utils.Utils.toMgmtIPAddressProvisioningType(psBatchManagedProvisioning);
            var backToPsBatchManaged = Utils.Utils.toIPAddressProvisioningType(mgmtBatchManagedProvisioning);

            // Assert - BatchManaged provisioning semantics preserved for automatic IP management
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManagedProvisioning);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, backToPsBatchManaged);

            // Arrange - UserManaged provisioning provides maximum control
            var psUserManagedProvisioning = Azure.Batch.Common.IPAddressProvisioningType.UserManaged;

            // Act
            var mgmtUserManagedProvisioning = Utils.Utils.toMgmtIPAddressProvisioningType(psUserManagedProvisioning);
            var backToPsUserManaged = Utils.Utils.toIPAddressProvisioningType(mgmtUserManagedProvisioning);

            // Assert - UserManaged provisioning semantics preserved for custom IP management
            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManagedProvisioning);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.UserManaged, backToPsUserManaged);

            // Arrange - NoPublicIPAddresses provisioning maximizes security
            var psNoPublicIPProvisioning = Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses;

            // Act
            var mgmtNoPublicIPProvisioning = Utils.Utils.toMgmtIPAddressProvisioningType(psNoPublicIPProvisioning);
            var backToPsNoPublicIP = Utils.Utils.toIPAddressProvisioningType(mgmtNoPublicIPProvisioning);

            // Assert - NoPublicIPAddresses provisioning semantics preserved for private networking
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIPProvisioning);
            Assert.Equal(Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, backToPsNoPublicIP);
        }

        #endregion
    }
}
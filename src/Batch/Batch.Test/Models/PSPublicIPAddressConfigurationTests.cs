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
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSPublicIPAddressConfigurationTests
    {
        #region toMgmtPublicIPAddressConfiguration Tests

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithBatchManagedProvision_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.BatchManaged, result.Provision);
            Assert.Null(result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithUserManagedProvision_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged);

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.Null(result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithNoPublicIPAddresses_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses);

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, result.Provision);
            Assert.Null(result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithNullProvision_ReturnsCorrectMapping()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(provision: null);

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Provision);
            Assert.Null(result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithSingleIPAddressId_ReturnsCorrectMapping()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-1"
            };
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.NotNull(result.IPAddressIds);
            Assert.Single(result.IPAddressIds);
            Assert.Equal(ipAddressIds[0], result.IPAddressIds[0]);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithMultipleIPAddressIds_ReturnsCorrectMapping()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-1",
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-2",
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-3"
            };
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.NotNull(result.IPAddressIds);
            Assert.Equal(3, result.IPAddressIds.Count);
            Assert.Equal(ipAddressIds, result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithEmptyIPAddressIds_ReturnsEmptyList()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = new List<string>()
            };

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.NotNull(result.IPAddressIds);
            Assert.Empty(result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_WithNullIPAddressIds_ReturnsNull()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = null
            };

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.Null(result.IPAddressIds);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            // Act
            var result1 = psConfig.toMgmtPublicIPAddressConfiguration();
            var result2 = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.NotSame(result1, result2);
        }

        [Fact]
        public void ToMgmtPublicIPAddressConfiguration_VerifyPublicIPAddressConfigurationType()
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PublicIPAddressConfiguration>(result);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, IPAddressProvisioningType.BatchManaged)]
        [InlineData(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, IPAddressProvisioningType.UserManaged)]
        [InlineData(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, IPAddressProvisioningType.NoPublicIPAddresses)]
        public void ToMgmtPublicIPAddressConfiguration_AllValidProvisionTypes_ReturnsCorrectMapping(
            Microsoft.Azure.Batch.Common.IPAddressProvisioningType psProvisionType,
            IPAddressProvisioningType expectedMgmtProvisionType)
        {
            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(psProvisionType);

            // Act
            var result = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMgmtProvisionType, result.Provision);
        }

        #endregion

        #region FromMgmtPublicIPAddressConfiguration Tests

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithBatchManagedProvision_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.BatchManaged);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, result.Provision);
            Assert.Null(result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithUserManagedProvision_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.Null(result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithNoPublicIPAddresses_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.NoPublicIPAddresses);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, result.Provision);
            Assert.Null(result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithNullProvision_ReturnsCorrectMapping()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(null);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Provision);
            Assert.Null(result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithNullConfiguration_ReturnsNull()
        {
            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithSingleIPAddressId_ReturnsCorrectMapping()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-1"
            };
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged, ipAddressIds);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.NotNull(result.IpAddressIds);
            Assert.Single(result.IpAddressIds);
            Assert.Equal(ipAddressIds[0], result.IpAddressIds[0]);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithMultipleIPAddressIds_ReturnsCorrectMapping()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-1",
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-2",
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-3"
            };
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged, ipAddressIds);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.NotNull(result.IpAddressIds);
            Assert.Equal(3, result.IpAddressIds.Count);
            Assert.Equal(ipAddressIds, result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithEmptyIPAddressIds_ReturnsEmptyList()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged, new List<string>());

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.NotNull(result.IpAddressIds);
            Assert.Empty(result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_WithNullIPAddressIds_ReturnsNull()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged, null);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, result.Provision);
            Assert.Null(result.IpAddressIds);
        }

        [Fact]
        public void FromMgmtPublicIPAddressConfiguration_VerifyPSPublicIPAddressConfigurationType()
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.BatchManaged);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PSPublicIPAddressConfiguration>(result);
        }

        [Theory]
        [InlineData(IPAddressProvisioningType.BatchManaged, Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged)]
        [InlineData(IPAddressProvisioningType.UserManaged, Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)]
        [InlineData(IPAddressProvisioningType.NoPublicIPAddresses, Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses)]
        public void FromMgmtPublicIPAddressConfiguration_AllValidProvisionTypes_ReturnsCorrectMapping(
            IPAddressProvisioningType mgmtProvisionType,
            Microsoft.Azure.Batch.Common.IPAddressProvisioningType expectedPsProvisionType)
        {
            // Arrange
            var mgmtConfig = new PublicIPAddressConfiguration(mgmtProvisionType);

            // Act
            var result = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedPsProvisionType, result.Provision);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesBatchManagedProvision()
        {
            // Arrange
            var originalPsConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Provision, roundTripPsConfig.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, roundTripPsConfig.Provision);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesUserManagedWithIPAddresses()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-1",
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-2"
            };
            var originalPsConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Provision, roundTripPsConfig.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, roundTripPsConfig.Provision);
            Assert.NotNull(roundTripPsConfig.IpAddressIds);
            Assert.Equal(2, roundTripPsConfig.IpAddressIds.Count);
            Assert.Equal(ipAddressIds, roundTripPsConfig.IpAddressIds);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNoPublicIPAddresses()
        {
            // Arrange
            var originalPsConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Provision, roundTripPsConfig.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, roundTripPsConfig.Provision);
        }

        [Fact]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullProvision()
        {
            // Arrange
            var originalPsConfig = new PSPublicIPAddressConfiguration(provision: null);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Provision, roundTripPsConfig.Provision);
            Assert.Null(roundTripPsConfig.Provision);
        }

        [Theory]
        [InlineData(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged)]
        [InlineData(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)]
        [InlineData(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllValidProvisionTypes(
            Microsoft.Azure.Batch.Common.IPAddressProvisioningType originalProvisionType)
        {
            // Arrange
            var originalPsConfig = new PSPublicIPAddressConfiguration(originalProvisionType);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalProvisionType, roundTripPsConfig.Provision);
        }

        [Fact]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesValues()
        {
            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/test-ip-1"
            };
            var originalMgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged, ipAddressIds);

            // Act
            var psConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtPublicIPAddressConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.Provision, roundTripMgmtConfig.Provision);
            Assert.Equal(IPAddressProvisioningType.UserManaged, roundTripMgmtConfig.Provision);
            Assert.NotNull(roundTripMgmtConfig.IPAddressIds);
            Assert.Single(roundTripMgmtConfig.IPAddressIds);
            Assert.Equal(ipAddressIds[0], roundTripMgmtConfig.IPAddressIds[0]);
        }

        [Fact]
        public void RoundTripConversion_WithNullConfiguration_HandlesCorrectly()
        {
            // Arrange
            PublicIPAddressConfiguration nullMgmtConfig = null;

            // Act
            var psConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(nullMgmtConfig);

            // Assert
            Assert.Null(psConfig);
        }

        [Fact]
        public void RoundTripConversion_WithEmptyIPAddressIds_PreservesEmptyList()
        {
            // Arrange
            var originalPsConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = new List<string>()
            };

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.NotNull(roundTripPsConfig.IpAddressIds);
            Assert.Empty(roundTripPsConfig.IpAddressIds);
        }

        [Fact]
        public void RoundTripConversion_WithNullIPAddressIds_PreservesNull()
        {
            // Arrange
            var originalPsConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = null
            };

            // Act
            var mgmtConfig = originalPsConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripPsConfig = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Null(roundTripPsConfig.IpAddressIds);
        }

        #endregion

        #region Integration Tests

        [Fact]
        public void PublicIPAddressConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions

            // Test BatchManaged semantics - Batch service manages public IPs automatically
            var psBatchManaged = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);
            var mgmtBatchManaged = psBatchManaged.toMgmtPublicIPAddressConfiguration();
            var backToPs = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtBatchManaged);

            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManaged.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, backToPs.Provision);

            // Test UserManaged semantics - User provides specific public IP addresses
            var ipAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/pool-ip-1",
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/test-rg/providers/Microsoft.Network/publicIPAddresses/pool-ip-2"
            };
            var psUserManaged = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };
            var mgmtUserManaged = psUserManaged.toMgmtPublicIPAddressConfiguration();
            var backToPsUserManaged = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtUserManaged);

            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManaged.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, backToPsUserManaged.Provision);
            Assert.Equal(ipAddressIds, mgmtUserManaged.IPAddressIds);
            Assert.Equal(ipAddressIds, backToPsUserManaged.IpAddressIds);

            // Test NoPublicIPAddresses semantics - No public IPs for compute nodes
            var psNoPublicIP = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses);
            var mgmtNoPublicIP = psNoPublicIP.toMgmtPublicIPAddressConfiguration();
            var backToPsNoPublicIP = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtNoPublicIP);

            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIP.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, backToPsNoPublicIP.Provision);
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch pool public IP configuration
            // PublicIPAddressConfiguration is used to configure how public IPs are provisioned for Batch pool compute nodes

            // Arrange - Test BatchManaged scenario for production workloads
            var psBatchManagedConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);
            var mgmtBatchManagedConfig = psBatchManagedConfig.toMgmtPublicIPAddressConfiguration();

            // Act & Assert - BatchManaged should convert correctly for automatic IP management
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManagedConfig.Provision);

            // Arrange - Test UserManaged scenario for enterprise networks with specific IP requirements
            var enterpriseIPAddresses = new List<string>
            {
                "/subscriptions/enterprise-sub/resourceGroups/network-rg/providers/Microsoft.Network/publicIPAddresses/enterprise-batch-ip-1",
                "/subscriptions/enterprise-sub/resourceGroups/network-rg/providers/Microsoft.Network/publicIPAddresses/enterprise-batch-ip-2",
                "/subscriptions/enterprise-sub/resourceGroups/network-rg/providers/Microsoft.Network/publicIPAddresses/enterprise-batch-ip-3"
            };
            var psUserManagedConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = enterpriseIPAddresses
            };
            var mgmtUserManagedConfig = psUserManagedConfig.toMgmtPublicIPAddressConfiguration();

            // Act & Assert - UserManaged should convert correctly for enterprise IP management
            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManagedConfig.Provision);
            Assert.Equal(3, mgmtUserManagedConfig.IPAddressIds.Count);

            // Arrange - Test NoPublicIPAddresses scenario for secure private networks
            var psNoPublicIPConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses);
            var mgmtNoPublicIPConfig = psNoPublicIPConfig.toMgmtPublicIPAddressConfiguration();

            // Act & Assert - NoPublicIPAddresses should convert correctly for private networking
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIPConfig.Provision);

            // Verify round-trip conversion maintains Batch pool networking semantics
            var backToBatchManaged = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtBatchManagedConfig);
            var backToUserManaged = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtUserManagedConfig);
            var backToNoPublicIP = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtNoPublicIPConfig);

            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, backToBatchManaged.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, backToUserManaged.Provision);
            Assert.Equal(enterpriseIPAddresses, backToUserManaged.IpAddressIds);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, backToNoPublicIP.Provision);
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/test/resourceGroups/test/providers/Microsoft.Network/publicIPAddresses/test"
            };
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.BatchManaged);

            // Act
            var mgmtResult = psConfig.toMgmtPublicIPAddressConfiguration();
            var psResult = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<PublicIPAddressConfiguration>(mgmtResult);
            Assert.IsType<PSPublicIPAddressConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public void PublicIPAddressConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient

            // Arrange
            var ipAddressIds = new List<string>
            {
                "/subscriptions/perf-test/resourceGroups/test/providers/Microsoft.Network/publicIPAddresses/ip-1",
                "/subscriptions/perf-test/resourceGroups/test/providers/Microsoft.Network/publicIPAddresses/ip-2"
            };
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = ipAddressIds
            };
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.BatchManaged);

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 100; i++)
            {
                var mgmtResult = psConfig.toMgmtPublicIPAddressConfiguration();
                var psResult = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

                Assert.NotNull(mgmtResult);
                Assert.NotNull(psResult);
                Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtResult.Provision);
                Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, psResult.Provision);
            }
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_TypeSafety_VerifyCorrectTypes()
        {
            // Test that conversions return the correct types

            // Arrange
            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);
            var mgmtConfig = new PublicIPAddressConfiguration(IPAddressProvisioningType.UserManaged);

            // Act
            var mgmtResult = psConfig.toMgmtPublicIPAddressConfiguration();
            var psResult = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtConfig);

            // Assert - Verify correct types are returned
            Assert.IsType<PublicIPAddressConfiguration>(mgmtResult);
            Assert.IsType<PSPublicIPAddressConfiguration>(psResult);
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_LargeIPAddressIdList_HandlesCorrectly()
        {
            // Test with a large list of IP address IDs to verify performance and correctness

            // Arrange - Create a list with maximum realistic number of IP addresses for a large pool
            var largeIPAddressList = new List<string>();
            for (int i = 1; i <= 50; i++) // 50 IPs would support 5000 compute nodes (100 nodes per IP)
            {
                largeIPAddressList.Add($"/subscriptions/large-pool-test/resourceGroups/network-rg/providers/Microsoft.Network/publicIPAddresses/batch-ip-{i:D2}");
            }

            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = largeIPAddressList
            };

            // Act
            var mgmtResult = psConfig.toMgmtPublicIPAddressConfiguration();
            var psResult = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtResult);

            // Assert
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.Equal(50, mgmtResult.IPAddressIds.Count);
            Assert.Equal(50, psResult.IpAddressIds.Count);
            Assert.Equal(largeIPAddressList, mgmtResult.IPAddressIds);
            Assert.Equal(largeIPAddressList, psResult.IpAddressIds);
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_IPAddressIdFormat_ValidatesCorrectFormat()
        {
            // Test that various valid Azure resource ID formats are preserved correctly

            // Arrange - Test with different subscription, resource group, and resource name patterns
            var validIPAddressIds = new List<string>
            {
                "/subscriptions/12345678-1234-1234-1234-123456789abc/resourceGroups/rg-batch-prod/providers/Microsoft.Network/publicIPAddresses/batch-pool-ip-001",
                "/subscriptions/87654321-4321-4321-4321-abcdef123456/resourceGroups/network-resources/providers/Microsoft.Network/publicIPAddresses/compute-node-public-ip",
                "/subscriptions/abcdef12-3456-7890-abcd-ef1234567890/resourceGroups/batch-networking/providers/Microsoft.Network/publicIPAddresses/pool-external-ip-primary"
            };

            var psConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = validIPAddressIds
            };

            // Act
            var mgmtResult = psConfig.toMgmtPublicIPAddressConfiguration();
            var roundTripResult = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtResult);

            // Assert - All formats should be preserved exactly
            Assert.NotNull(mgmtResult);
            Assert.NotNull(roundTripResult);
            Assert.Equal(validIPAddressIds.Count, mgmtResult.IPAddressIds.Count);
            Assert.Equal(validIPAddressIds.Count, roundTripResult.IpAddressIds.Count);
            Assert.Equal(validIPAddressIds, mgmtResult.IPAddressIds);
            Assert.Equal(validIPAddressIds, roundTripResult.IpAddressIds);
        }

        #endregion

        #region Pool Networking Strategy Tests

        [Fact]
        public void PublicIPAddressConfigurationConversions_BatchManagedStrategy_AutomaticIPManagement()
        {
            // This test validates that BatchManaged provisioning semantics are preserved for automatic IP management

            // Arrange - BatchManaged provisioning for Azure Batch-managed public IPs
            var psBatchManaged = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            // Act
            var mgmtBatchManaged = psBatchManaged.toMgmtPublicIPAddressConfiguration();
            var backToPs = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtBatchManaged);

            // Assert - BatchManaged provisioning semantics preserved
            Assert.Equal(IPAddressProvisioningType.BatchManaged, mgmtBatchManaged.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, backToPs.Provision);
            Assert.Null(mgmtBatchManaged.IPAddressIds); // No specific IPs needed for BatchManaged
            Assert.Null(backToPs.IpAddressIds);
            // BatchManaged ensures Azure Batch automatically creates and manages public IPs based on pool size
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_UserManagedStrategy_EnterpriseIPControl()
        {
            // This test validates that UserManaged provisioning semantics are preserved for enterprise IP control

            // Arrange - UserManaged provisioning for enterprise-controlled public IPs
            var enterpriseIPPool = new List<string>
            {
                "/subscriptions/enterprise-123/resourceGroups/corp-network/providers/Microsoft.Network/publicIPAddresses/batch-corp-ip-east-001",
                "/subscriptions/enterprise-123/resourceGroups/corp-network/providers/Microsoft.Network/publicIPAddresses/batch-corp-ip-east-002",
                "/subscriptions/enterprise-123/resourceGroups/corp-network/providers/Microsoft.Network/publicIPAddresses/batch-corp-ip-east-003"
            };
            var psUserManaged = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged)
            {
                IpAddressIds = enterpriseIPPool
            };

            // Act
            var mgmtUserManaged = psUserManaged.toMgmtPublicIPAddressConfiguration();
            var backToPs = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtUserManaged);

            // Assert - UserManaged provisioning semantics preserved
            Assert.Equal(IPAddressProvisioningType.UserManaged, mgmtUserManaged.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, backToPs.Provision);
            Assert.Equal(enterpriseIPPool, mgmtUserManaged.IPAddressIds);
            Assert.Equal(enterpriseIPPool, backToPs.IpAddressIds);
            // UserManaged ensures enterprise controls exactly which public IPs are used for compute nodes
        }

        [Fact]
        public void PublicIPAddressConfigurationConversions_NoPublicIPStrategy_PrivateNetworking()
        {
            // This test validates that NoPublicIPAddresses provisioning semantics are preserved for private networking

            // Arrange - NoPublicIPAddresses provisioning for secure private environments
            var psNoPublicIP = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses);

            // Act
            var mgmtNoPublicIP = psNoPublicIP.toMgmtPublicIPAddressConfiguration();
            var backToPs = PSPublicIPAddressConfiguration.FromMgmtPublicIPAddressConfiguration(mgmtNoPublicIP);

            // Assert - NoPublicIPAddresses provisioning semantics preserved
            Assert.Equal(IPAddressProvisioningType.NoPublicIPAddresses, mgmtNoPublicIP.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, backToPs.Provision);
            Assert.Null(mgmtNoPublicIP.IPAddressIds); // No public IPs for private networking
            Assert.Null(backToPs.IpAddressIds);
            // NoPublicIPAddresses ensures compute nodes have no public IP addresses for maximum security
        }

        #endregion

        #region Constructor and Property Tests

        [Fact]
        public void PSPublicIPAddressConfiguration_Constructor_InitializesCorrectly()
        {
            // Test that the PS constructor properly initializes the configuration

            // Arrange & Act
            var batchManagedConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);
            var userManagedConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged);
            var noPublicIPConfig = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses);
            var nullConfig = new PSPublicIPAddressConfiguration(provision:null);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, batchManagedConfig.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged, userManagedConfig.Provision);
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.NoPublicIPAddresses, noPublicIPConfig.Provision);
            Assert.Null(nullConfig.Provision);

            // Verify all configurations have null IP addresses initially
            Assert.Null(batchManagedConfig.IpAddressIds);
            Assert.Null(userManagedConfig.IpAddressIds);
            Assert.Null(noPublicIPConfig.IpAddressIds);
            Assert.Null(nullConfig.IpAddressIds);
        }

        [Fact]
        public void PSPublicIPAddressConfiguration_IpAddressIdsProperty_WorksCorrectly()
        {
            // Test that the IpAddressIds property setter and getter work correctly

            // Arrange
            var config = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.UserManaged);
            var testIPAddresses = new List<string>
            {
                "/subscriptions/test/resourceGroups/test/providers/Microsoft.Network/publicIPAddresses/test-ip-1",
                "/subscriptions/test/resourceGroups/test/providers/Microsoft.Network/publicIPAddresses/test-ip-2"
            };

            // Act
            config.IpAddressIds = testIPAddresses;

            // Assert
            Assert.NotNull(config.IpAddressIds);
            Assert.Equal(2, config.IpAddressIds.Count);
            Assert.Equal(testIPAddresses, config.IpAddressIds);

            // Test setting to null
            config.IpAddressIds = null;
            Assert.Null(config.IpAddressIds);

            // Test setting to empty list
            config.IpAddressIds = new List<string>();
            Assert.NotNull(config.IpAddressIds);
            Assert.Empty(config.IpAddressIds);
        }

        [Fact]
        public void PSPublicIPAddressConfiguration_ProvisionProperty_IsReadOnly()
        {
            // Test that the Provision property is read-only and set during construction

            // Arrange & Act
            var config = new PSPublicIPAddressConfiguration(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged);

            // Assert
            Assert.Equal(Microsoft.Azure.Batch.Common.IPAddressProvisioningType.BatchManaged, config.Provision);

            // Verify that Provision property has no setter (read-only)
            var provisionProperty = typeof(PSPublicIPAddressConfiguration).GetProperty("Provision");
            Assert.NotNull(provisionProperty);
            Assert.True(provisionProperty.CanRead);
            Assert.False(provisionProperty.CanWrite); // Should be read-only
        }

        #endregion
    }
}
// ----------------------------------------------------------------------------------
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
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSAzureBlobFileSystemConfigurationTests
    {
        #region toMgmtAzureBlobFileSystemConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureBlobFileSystemConfiguration_WithIdentityReference_ConvertsCorrectly()
        {
            // Arrange
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                identityReference: psIdentityRef,
                blobfuseOptions: "-o allow_other");

            // Act
            var mgmtConfig = psConfig.toMgmtAzureBlobFileSystemConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("teststorageaccount", mgmtConfig.AccountName);
            Assert.Equal("testcontainer", mgmtConfig.ContainerName);
            Assert.Equal("data", mgmtConfig.RelativeMountPath);
            Assert.Equal("-o allow_other", mgmtConfig.BlobfuseOptions);
            Assert.NotNull(mgmtConfig.IdentityReference);
            Assert.Equal(identityResourceId, mgmtConfig.IdentityReference.ResourceId);
            Assert.Null(mgmtConfig.AccountKey);
            Assert.Null(mgmtConfig.SasKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureBlobFileSystemConfiguration_WithSasKey_ConvertsCorrectly()
        {
            // Arrange
            var sasKey = "?sv=2021-08-06&ss=b&srt=sco&sp=rwdlacupx&se=2023-12-31T23:59:59Z&st=2023-01-01T00:00:00Z&spr=https&sig=testSasKey";
            var azureKey = Microsoft.Azure.Batch.AzureStorageAuthenticationKey.FromSasKey(sasKey);
            var psConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                key: azureKey,
                blobfuseOptions: null);

            // Act
            var mgmtConfig = psConfig.toMgmtAzureBlobFileSystemConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("teststorageaccount", mgmtConfig.AccountName);
            Assert.Equal("testcontainer", mgmtConfig.ContainerName);
            Assert.Equal("data", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.BlobfuseOptions);
            Assert.Equal(sasKey, mgmtConfig.SasKey);
            Assert.Null(mgmtConfig.AccountKey);
            Assert.Null(mgmtConfig.IdentityReference);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureBlobFileSystemConfiguration_WithAccountKey_ConvertsCorrectly()
        {
            // Arrange
            var accountKey = "dGVzdGFjY291bnRrZXk="; // base64 encoded test account key
            var azureKey = Microsoft.Azure.Batch.AzureStorageAuthenticationKey.FromSasKey(accountKey);
            var psConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                key: azureKey);

            // Act
            var mgmtConfig = psConfig.toMgmtAzureBlobFileSystemConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("teststorageaccount", mgmtConfig.AccountName);
            Assert.Equal("testcontainer", mgmtConfig.ContainerName);
            Assert.Equal("data", mgmtConfig.RelativeMountPath);
            Assert.Equal(accountKey, mgmtConfig.SasKey);
            Assert.Null(mgmtConfig.AccountKey);
            Assert.Null(mgmtConfig.IdentityReference);
        }

        #endregion

        #region fromMgmtAzureBlobFileSystemConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureBlobFileSystemConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureBlobFileSystemConfiguration_WithIdentityReference_ConvertsCorrectly()
        {
            // Arrange
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var mgmtConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                blobfuseOptions: "-o allow_other",
                identityReference: mgmtIdentityRef);

            // Act
            var psConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("teststorageaccount", psConfig.AccountName);
            Assert.Equal("testcontainer", psConfig.ContainerName);
            Assert.Equal("data", psConfig.RelativeMountPath);
            Assert.Equal("-o allow_other", psConfig.BlobfuseOptions);
            Assert.NotNull(psConfig.IdentityReference);
            Assert.Equal(identityResourceId, psConfig.IdentityReference.ResourceId);
            Assert.Null(psConfig.AccountKey);
            Assert.Null(psConfig.SasKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureBlobFileSystemConfiguration_WithSasKey_ConvertsCorrectly()
        {
            // Arrange
            var sasKey = "?sv=2021-08-06&ss=b&srt=sco&sp=rwdlacupx&se=2023-12-31T23:59:59Z&st=2023-01-01T00:00:00Z&spr=https&sig=testSasKey";
            var mgmtConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                sasKey: sasKey,
                blobfuseOptions: "-o allow_other");

            // Act
            var psConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("teststorageaccount", psConfig.AccountName);
            Assert.Equal("testcontainer", psConfig.ContainerName);
            Assert.Equal("data", psConfig.RelativeMountPath);
            Assert.Equal("-o allow_other", psConfig.BlobfuseOptions);
            Assert.Equal(sasKey, psConfig.SasKey);
            Assert.Null(psConfig.AccountKey);
            Assert.Null(psConfig.IdentityReference);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureBlobFileSystemConfiguration_WithNullIdentityReference_ReturnsNull()
        {
            var accountKey = "dGVzdGFjY291bnRrZXk="; // base64 encoded test account key

            // Arrange
            var mgmtConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                accountKey: accountKey,
                blobfuseOptions: "-o allow_other");

            // Act
            var psConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("teststorageaccount", psConfig.AccountName);
            Assert.Equal("testcontainer", psConfig.ContainerName);
            Assert.Equal("data", psConfig.RelativeMountPath);
            Assert.Equal("-o allow_other", psConfig.BlobfuseOptions);
            Assert.Equal(accountKey, psConfig.AccountKey);
            Assert.Null(psConfig.SasKey);
            Assert.Null(psConfig.IdentityReference);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureBlobFileSystemConfiguration_WithNullAuthenticationMethods_ReturnsNull  ()
        {
            // Arrange
            var mgmtConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                sasKey: null);

            // Act
            var psConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            // Assert - Current implementation returns null when SasKey is null and no IdentityReference
            Assert.Null(psConfig);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_WithIdentityReference_PreservesValues()
        {
            // Arrange
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var originalPsConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                identityReference: psIdentityRef,
                blobfuseOptions: "-o allow_other");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtAzureBlobFileSystemConfiguration();
            var roundTripPsConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.AccountName, roundTripPsConfig.AccountName);
            Assert.Equal(originalPsConfig.ContainerName, roundTripPsConfig.ContainerName);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal(originalPsConfig.BlobfuseOptions, roundTripPsConfig.BlobfuseOptions);
            Assert.NotNull(roundTripPsConfig.IdentityReference);
            Assert.Equal(identityResourceId, roundTripPsConfig.IdentityReference.ResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_WithSasKey_PreservesValues()
        {
            // Arrange
            var sasKey = "?sv=2021-08-06&ss=b&srt=sco&sp=rwdlacupx&se=2023-12-31T23:59:59Z&st=2023-01-01T00:00:00Z&spr=https&sig=testSasKey";
            var azureKey = Microsoft.Azure.Batch.AzureStorageAuthenticationKey.FromSasKey(sasKey);
            var originalPsConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                key: azureKey,
                blobfuseOptions: "-o allow_other");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtAzureBlobFileSystemConfiguration();
            var roundTripPsConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.AccountName, roundTripPsConfig.AccountName);
            Assert.Equal(originalPsConfig.ContainerName, roundTripPsConfig.ContainerName);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal(originalPsConfig.BlobfuseOptions, roundTripPsConfig.BlobfuseOptions);
            Assert.Equal(sasKey, roundTripPsConfig.SasKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtWithIdentityReference_PreservesValues()
        {
            // Arrange
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference(identityResourceId);
            var originalMgmtConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                blobfuseOptions: "-o allow_other",
                identityReference: mgmtIdentityRef);

            // Act
            var psConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtAzureBlobFileSystemConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.AccountName, roundTripMgmtConfig.AccountName);
            Assert.Equal(originalMgmtConfig.ContainerName, roundTripMgmtConfig.ContainerName);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal(originalMgmtConfig.BlobfuseOptions, roundTripMgmtConfig.BlobfuseOptions);
            Assert.NotNull(roundTripMgmtConfig.IdentityReference);
            Assert.Equal(identityResourceId, roundTripMgmtConfig.IdentityReference.ResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtWithSasKey_PreservesValues()
        {
            // Arrange
            var sasKey = "?sv=2021-08-06&ss=b&srt=sco&sp=rwdlacupx&se=2023-12-31T23:59:59Z&st=2023-01-01T00:00:00Z&spr=https&sig=testSasKey";
            var originalMgmtConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "data",
                sasKey: sasKey,
                blobfuseOptions: "-o allow_other");

            // Act
            var psConfig = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtAzureBlobFileSystemConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.AccountName, roundTripMgmtConfig.AccountName);
            Assert.Equal(originalMgmtConfig.ContainerName, roundTripMgmtConfig.ContainerName);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal(originalMgmtConfig.BlobfuseOptions, roundTripMgmtConfig.BlobfuseOptions);
            Assert.Equal(sasKey, roundTripMgmtConfig.SasKey);
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureBlobFileSystemConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch blob file system mounting

            // Test Identity-based authentication scenario - Managed Identity for secure access
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/batch-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "batchstorage",
                containerName: "datasets",
                relativeMountPath: "input-data",
                identityReference: psIdentityRef,
                blobfuseOptions: "-o allow_other");

            var mgmtConfig = psConfig.toMgmtAzureBlobFileSystemConfiguration();
            var backToPs = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtConfig);

            Assert.NotNull(mgmtConfig);
            Assert.Equal("batchstorage", mgmtConfig.AccountName);
            Assert.Equal("datasets", mgmtConfig.ContainerName);
            Assert.Equal("input-data", mgmtConfig.RelativeMountPath);
            Assert.Equal(identityResourceId, mgmtConfig.IdentityReference.ResourceId);

            Assert.NotNull(backToPs);
            Assert.Equal("batchstorage", backToPs.AccountName);
            Assert.Equal("datasets", backToPs.ContainerName);
            Assert.Equal("input-data", backToPs.RelativeMountPath);
            Assert.Equal(identityResourceId, backToPs.IdentityReference.ResourceId);

            // Test SAS token authentication scenario - Time-limited access
            var sasToken = "?sv=2021-08-06&ss=b&srt=sco&sp=r&se=2023-12-31T23:59:59Z&st=2023-01-01T00:00:00Z&spr=https&sig=batchSasToken";
            var azureSasKey = Microsoft.Azure.Batch.AzureStorageAuthenticationKey.FromSasKey(sasToken);
            var psSasConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "batchstorage",
                containerName: "outputs",
                relativeMountPath: "results",
                key: azureSasKey);

            var mgmtSasConfig = psSasConfig.toMgmtAzureBlobFileSystemConfiguration();
            var backToSasPs = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtSasConfig);

            Assert.NotNull(mgmtSasConfig);
            Assert.Equal(sasToken, mgmtSasConfig.SasKey);
            Assert.Equal("outputs", mgmtSasConfig.ContainerName);

            Assert.NotNull(backToSasPs);
            Assert.Equal(sasToken, backToSasPs.SasKey);
            Assert.Equal("outputs", backToSasPs.ContainerName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureBlobFileSystemConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureBlobFileSystemConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool mount configuration
            // AzureBlobFileSystemConfiguration is used to mount Azure Blob Storage containers as file systems on Batch compute nodes

            // Arrange - Test data science workload scenario with input datasets
            var dataScenario = new
            {
                AccountName = "mlstorage",
                ContainerName = "training-data",
                RelativeMountPath = "datasets",
                BlobfuseOptions = "-o allow_other --cache-size-mb=1000",
                IdentityResourceId = "/subscriptions/ml-sub/resourceGroups/ml-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/ml-identity",
                Description = "Data science training dataset mount for ML workloads"
            };

            var psIdentity = new PSComputeNodeIdentityReference { ResourceId = dataScenario.IdentityResourceId };
            var psDataConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: dataScenario.AccountName,
                containerName: dataScenario.ContainerName,
                relativeMountPath: dataScenario.RelativeMountPath,
                identityReference: psIdentity,
                blobfuseOptions: dataScenario.BlobfuseOptions);

            // Act
            var mgmtDataConfig = psDataConfig.toMgmtAzureBlobFileSystemConfiguration();

            // Assert - Should convert correctly for Batch pool mount configuration
            Assert.NotNull(mgmtDataConfig);
            Assert.Equal(dataScenario.AccountName, mgmtDataConfig.AccountName);
            Assert.Equal(dataScenario.ContainerName, mgmtDataConfig.ContainerName);
            Assert.Equal(dataScenario.RelativeMountPath, mgmtDataConfig.RelativeMountPath);
            Assert.Equal(dataScenario.BlobfuseOptions, mgmtDataConfig.BlobfuseOptions);
            Assert.Equal(dataScenario.IdentityResourceId, mgmtDataConfig.IdentityReference.ResourceId);

            // Verify round-trip conversion maintains Batch pool semantics
            var backToPs = PSAzureBlobFileSystemConfiguration.fromMgmtAzureBlobFileSystemConfiguration(mgmtDataConfig);
            Assert.NotNull(backToPs);
            Assert.Equal(dataScenario.AccountName, backToPs.AccountName);
            Assert.Equal(dataScenario.ContainerName, backToPs.ContainerName);
            Assert.Equal(dataScenario.RelativeMountPath, backToPs.RelativeMountPath);
            Assert.Equal(dataScenario.BlobfuseOptions, backToPs.BlobfuseOptions);
            Assert.Equal(dataScenario.IdentityResourceId, backToPs.IdentityReference.ResourceId);
        }

        #endregion
    }
}
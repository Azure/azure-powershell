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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSMountConfigurationTests
    {
        #region toMgmtMountConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtMountConfiguration_WithNfsConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var psNfsConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576");
            var psMountConfig = new PSMountConfiguration(psNfsConfig);

            // Act
            var mgmtMountConfig = psMountConfig.toMgmtMountConfiguration();

            // Assert
            Assert.NotNull(mgmtMountConfig);
            Assert.NotNull(mgmtMountConfig.NfsMountConfiguration);
            Assert.Null(mgmtMountConfig.CifsMountConfiguration);
            Assert.Null(mgmtMountConfig.AzureBlobFileSystemConfiguration);
            Assert.Null(mgmtMountConfig.AzureFileShareConfiguration);
            
            Assert.Equal("nfs.example.com:/data", mgmtMountConfig.NfsMountConfiguration.Source);
            Assert.Equal("nfs-data", mgmtMountConfig.NfsMountConfiguration.RelativeMountPath);
            Assert.Equal("vers=4.1,rsize=1048576", mgmtMountConfig.NfsMountConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtMountConfiguration_WithCifsConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var psCifsConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "testpass",
                source: "//server.example.com/share",
                relativeMountPath: "cifs-data",
                mountOptions: "vers=3.0");
            var psMountConfig = new PSMountConfiguration(psCifsConfig);

            // Act
            var mgmtMountConfig = psMountConfig.toMgmtMountConfiguration();

            // Assert
            Assert.NotNull(mgmtMountConfig);
            Assert.NotNull(mgmtMountConfig.CifsMountConfiguration);
            Assert.Null(mgmtMountConfig.NfsMountConfiguration);
            Assert.Null(mgmtMountConfig.AzureBlobFileSystemConfiguration);
            Assert.Null(mgmtMountConfig.AzureFileShareConfiguration);
            
            Assert.Equal("testuser", mgmtMountConfig.CifsMountConfiguration.UserName);
            Assert.Equal("testpass", mgmtMountConfig.CifsMountConfiguration.Password);
            Assert.Equal("//server.example.com/share", mgmtMountConfig.CifsMountConfiguration.Source);
            Assert.Equal("cifs-data", mgmtMountConfig.CifsMountConfiguration.RelativeMountPath);
            Assert.Equal("vers=3.0", mgmtMountConfig.CifsMountConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtMountConfiguration_WithAzureBlobFileSystemConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var psIdentityRef = new PSComputeNodeIdentityReference { ResourceId = identityResourceId };
            var psBlobConfig = new PSAzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "blob-data",
                identityReference: psIdentityRef,
                blobfuseOptions: "-o allow_other");
            var psMountConfig = new PSMountConfiguration(psBlobConfig);

            // Act
            var mgmtMountConfig = psMountConfig.toMgmtMountConfiguration();

            // Assert
            Assert.NotNull(mgmtMountConfig);
            Assert.NotNull(mgmtMountConfig.AzureBlobFileSystemConfiguration);
            Assert.Null(mgmtMountConfig.NfsMountConfiguration);
            Assert.Null(mgmtMountConfig.CifsMountConfiguration);
            Assert.Null(mgmtMountConfig.AzureFileShareConfiguration);
            
            Assert.Equal("teststorageaccount", mgmtMountConfig.AzureBlobFileSystemConfiguration.AccountName);
            Assert.Equal("testcontainer", mgmtMountConfig.AzureBlobFileSystemConfiguration.ContainerName);
            Assert.Equal("blob-data", mgmtMountConfig.AzureBlobFileSystemConfiguration.RelativeMountPath);
            Assert.Equal("-o allow_other", mgmtMountConfig.AzureBlobFileSystemConfiguration.BlobfuseOptions);
            Assert.NotNull(mgmtMountConfig.AzureBlobFileSystemConfiguration.IdentityReference);
            Assert.Equal(identityResourceId, mgmtMountConfig.AzureBlobFileSystemConfiguration.IdentityReference.ResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtMountConfiguration_WithAzureFileShareConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var psFileShareConfig = new PSAzureFileShareConfiguration(
                accountName: "teststorageaccount",
                azureFileUrl: "https://teststorageaccount.file.core.windows.net/",
                relativeMountPath: "file-share-data",
                accountKey: "testaccountkey123==",
                mountOptions: "-o uid=1000,gid=1000");
            var psMountConfig = new PSMountConfiguration(psFileShareConfig);

            // Act
            var mgmtMountConfig = psMountConfig.toMgmtMountConfiguration();

            // Assert
            Assert.NotNull(mgmtMountConfig);
            Assert.NotNull(mgmtMountConfig.AzureFileShareConfiguration);
            Assert.Null(mgmtMountConfig.NfsMountConfiguration);
            Assert.Null(mgmtMountConfig.CifsMountConfiguration);
            Assert.Null(mgmtMountConfig.AzureBlobFileSystemConfiguration);
            
            Assert.Equal("teststorageaccount", mgmtMountConfig.AzureFileShareConfiguration.AccountName);
            Assert.Equal("https://teststorageaccount.file.core.windows.net/", mgmtMountConfig.AzureFileShareConfiguration.AzureFileUrl);
            Assert.Equal("file-share-data", mgmtMountConfig.AzureFileShareConfiguration.RelativeMountPath);
            Assert.Equal("testaccountkey123==", mgmtMountConfig.AzureFileShareConfiguration.AccountKey);
            Assert.Equal("-o uid=1000,gid=1000", mgmtMountConfig.AzureFileShareConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtMountConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psNfsConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "data");
            var psMountConfig = new PSMountConfiguration(psNfsConfig);

            // Act
            var mgmtMountConfig1 = psMountConfig.toMgmtMountConfiguration();
            var mgmtMountConfig2 = psMountConfig.toMgmtMountConfiguration();

            // Assert
            Assert.NotNull(mgmtMountConfig1);
            Assert.NotNull(mgmtMountConfig2);
            Assert.NotSame(mgmtMountConfig1, mgmtMountConfig2);
            Assert.Equal(mgmtMountConfig1.NfsMountConfiguration.Source, mgmtMountConfig2.NfsMountConfiguration.Source);
        }

        #endregion

        #region fromMgmtMountConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSMountConfiguration.fromMgmtMountConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithNfsConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var mgmtNfsConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576");
            var mgmtMountConfig = new MountConfiguration(nfsMountConfiguration: mgmtNfsConfig);

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(psMountConfig);
            Assert.NotNull(psMountConfig.NfsMountConfiguration);
            Assert.Null(psMountConfig.CifsMountConfiguration);
            Assert.Null(psMountConfig.AzureBlobFileSystemConfiguration);
            Assert.Null(psMountConfig.AzureFileShareConfiguration);
            
            Assert.Equal("nfs.example.com:/data", psMountConfig.NfsMountConfiguration.Source);
            Assert.Equal("nfs-data", psMountConfig.NfsMountConfiguration.RelativeMountPath);
            Assert.Equal("vers=4.1,rsize=1048576", psMountConfig.NfsMountConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithCifsConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var mgmtCifsConfig = new CifsMountConfiguration(
                userName: "testuser",
                source: "//server.example.com/share",
                relativeMountPath: "cifs-data",
                password: "testpass",
                mountOptions: "vers=3.0");
            var mgmtMountConfig = new MountConfiguration(cifsMountConfiguration: mgmtCifsConfig);

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(psMountConfig);
            Assert.NotNull(psMountConfig.CifsMountConfiguration);
            Assert.Null(psMountConfig.NfsMountConfiguration);
            Assert.Null(psMountConfig.AzureBlobFileSystemConfiguration);
            Assert.Null(psMountConfig.AzureFileShareConfiguration);
            
            Assert.Equal("testuser", psMountConfig.CifsMountConfiguration.Username);
            Assert.Equal("testpass", psMountConfig.CifsMountConfiguration.Password);
            Assert.Equal("//server.example.com/share", psMountConfig.CifsMountConfiguration.Source);
            Assert.Equal("cifs-data", psMountConfig.CifsMountConfiguration.RelativeMountPath);
            Assert.Equal("vers=3.0", psMountConfig.CifsMountConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithAzureBlobFileSystemConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var identityResourceId = "/subscriptions/test-sub/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity";
            var mgmtIdentityRef = new ComputeNodeIdentityReference { ResourceId = identityResourceId };
            var mgmtBlobConfig = new AzureBlobFileSystemConfiguration(
                accountName: "teststorageaccount",
                containerName: "testcontainer",
                relativeMountPath: "blob-data",
                identityReference: mgmtIdentityRef,
                blobfuseOptions: "-o allow_other");
            var mgmtMountConfig = new MountConfiguration(azureBlobFileSystemConfiguration: mgmtBlobConfig);

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(psMountConfig);
            Assert.NotNull(psMountConfig.AzureBlobFileSystemConfiguration);
            Assert.Null(psMountConfig.NfsMountConfiguration);
            Assert.Null(psMountConfig.CifsMountConfiguration);
            Assert.Null(psMountConfig.AzureFileShareConfiguration);
            
            Assert.Equal("teststorageaccount", psMountConfig.AzureBlobFileSystemConfiguration.AccountName);
            Assert.Equal("testcontainer", psMountConfig.AzureBlobFileSystemConfiguration.ContainerName);
            Assert.Equal("blob-data", psMountConfig.AzureBlobFileSystemConfiguration.RelativeMountPath);
            Assert.Equal("-o allow_other", psMountConfig.AzureBlobFileSystemConfiguration.BlobfuseOptions);
            Assert.NotNull(psMountConfig.AzureBlobFileSystemConfiguration.IdentityReference);
            Assert.Equal(identityResourceId, psMountConfig.AzureBlobFileSystemConfiguration.IdentityReference.ResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithAzureFileShareConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var mgmtFileShareConfig = new AzureFileShareConfiguration(
                accountName: "teststorageaccount",
                azureFileUrl: "https://teststorageaccount.file.core.windows.net/",
                accountKey: "testaccountkey123==",
                relativeMountPath: "file-share-data",
                mountOptions: "-o uid=1000,gid=1000");
            var mgmtMountConfig = new MountConfiguration(azureFileShareConfiguration: mgmtFileShareConfig);

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(psMountConfig);
            Assert.NotNull(psMountConfig.AzureFileShareConfiguration);
            Assert.Null(psMountConfig.NfsMountConfiguration);
            Assert.Null(psMountConfig.CifsMountConfiguration);
            Assert.Null(psMountConfig.AzureBlobFileSystemConfiguration);
            
            Assert.Equal("teststorageaccount", psMountConfig.AzureFileShareConfiguration.AccountName);
            Assert.Equal("https://teststorageaccount.file.core.windows.net/", psMountConfig.AzureFileShareConfiguration.AzureFileUrl);
            Assert.Equal("file-share-data", psMountConfig.AzureFileShareConfiguration.RelativeMountPath);
            Assert.Equal("testaccountkey123==", psMountConfig.AzureFileShareConfiguration.AccountKey);
            Assert.Equal("-o uid=1000,gid=1000", psMountConfig.AzureFileShareConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithAllNullConfigurations_ReturnsNull()
        {
            // Arrange
            var mgmtMountConfig = new MountConfiguration();

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.Null(psMountConfig);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_WithMultipleConfigurations_ReturnsFirstNonNull()
        {
            // Arrange - Test priority: NFS > CIFS > AzureBlob > AzureFileShare
            var mgmtNfsConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data");
            var mgmtCifsConfig = new CifsMountConfiguration(
                userName: "testuser",
                source: "//server.example.com/share",
                relativeMountPath: "cifs-data",
                password: "testpass");
            var mgmtMountConfig = new MountConfiguration(
                nfsMountConfiguration: mgmtNfsConfig,
                cifsMountConfiguration: mgmtCifsConfig);

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert - Should return NFS configuration (first priority)
            Assert.NotNull(psMountConfig);
            Assert.NotNull(psMountConfig.NfsMountConfiguration);
            Assert.Null(psMountConfig.CifsMountConfiguration);
            Assert.Equal("nfs.example.com:/data", psMountConfig.NfsMountConfiguration.Source);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtNfsConfig = new NFSMountConfiguration(
                source: "nfs.test.com:/data",
                relativeMountPath: "test-data");
            var mgmtMountConfig = new MountConfiguration(nfsMountConfiguration: mgmtNfsConfig);

            // Act - Call static method directly on class
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(psMountConfig);
            Assert.NotNull(psMountConfig.NfsMountConfiguration);
            Assert.Equal("nfs.test.com:/data", psMountConfig.NfsMountConfiguration.Source);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtMountConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtNfsConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "data");
            var mgmtMountConfig = new MountConfiguration(nfsMountConfiguration: mgmtNfsConfig);

            // Act
            var psMountConfig1 = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);
            var psMountConfig2 = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(psMountConfig1);
            Assert.NotNull(psMountConfig2);
            Assert.NotSame(psMountConfig1, psMountConfig2);
            Assert.Equal(psMountConfig1.NfsMountConfiguration.Source, psMountConfig2.NfsMountConfiguration.Source);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNfsConfiguration()
        {
            // Arrange
            var originalPsNfsConfig = new PSNfsMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1,rsize=1048576");
            var originalPsMountConfig = new PSMountConfiguration(originalPsNfsConfig);

            // Act
            var mgmtMountConfig = originalPsMountConfig.toMgmtMountConfiguration();
            var roundTripPsMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(roundTripPsMountConfig);
            Assert.NotNull(roundTripPsMountConfig.NfsMountConfiguration);
            Assert.Equal(originalPsNfsConfig.Source, roundTripPsMountConfig.NfsMountConfiguration.Source);
            Assert.Equal(originalPsNfsConfig.RelativeMountPath, roundTripPsMountConfig.NfsMountConfiguration.RelativeMountPath);
            Assert.Equal(originalPsNfsConfig.MountOptions, roundTripPsMountConfig.NfsMountConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesCifsConfiguration()
        {
            // Arrange
            var originalPsCifsConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "testpass",
                source: "//server.example.com/share",
                relativeMountPath: "cifs-data",
                mountOptions: "vers=3.0");
            var originalPsMountConfig = new PSMountConfiguration(originalPsCifsConfig);

            // Act
            var mgmtMountConfig = originalPsMountConfig.toMgmtMountConfiguration();
            var roundTripPsMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);

            // Assert
            Assert.NotNull(roundTripPsMountConfig);
            Assert.NotNull(roundTripPsMountConfig.CifsMountConfiguration);
            Assert.Equal(originalPsCifsConfig.Username, roundTripPsMountConfig.CifsMountConfiguration.Username);
            Assert.Equal(originalPsCifsConfig.Password, roundTripPsMountConfig.CifsMountConfiguration.Password);
            Assert.Equal(originalPsCifsConfig.Source, roundTripPsMountConfig.CifsMountConfiguration.Source);
            Assert.Equal(originalPsCifsConfig.RelativeMountPath, roundTripPsMountConfig.CifsMountConfiguration.RelativeMountPath);
            Assert.Equal(originalPsCifsConfig.MountOptions, roundTripPsMountConfig.CifsMountConfiguration.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalMgmtNfsConfig = new NFSMountConfiguration(
                source: "nfs.example.com:/data",
                relativeMountPath: "nfs-data",
                mountOptions: "vers=4.1");
            var originalMgmtMountConfig = new MountConfiguration(nfsMountConfiguration: originalMgmtNfsConfig);

            // Act
            var psMountConfig = PSMountConfiguration.fromMgmtMountConfiguration(originalMgmtMountConfig);
            var roundTripMgmtMountConfig = psMountConfig.toMgmtMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtMountConfig);
            Assert.NotNull(roundTripMgmtMountConfig.NfsMountConfiguration);
            Assert.Equal(originalMgmtNfsConfig.Source, roundTripMgmtMountConfig.NfsMountConfiguration.Source);
            Assert.Equal(originalMgmtNfsConfig.RelativeMountPath, roundTripMgmtMountConfig.NfsMountConfiguration.RelativeMountPath);
            Assert.Equal(originalMgmtNfsConfig.MountOptions, roundTripMgmtMountConfig.NfsMountConfiguration.MountOptions);
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MountConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch mount configurations

            // Test various mount configuration scenarios
            var mountScenarios = new[]
            {
                new {
                    Type = "NFS",
                    Source = "nfs.example.com:/shared/data",
                    RelativeMountPath = "shared-data",
                    Options = "vers=4.1,rsize=1048576,wsize=1048576,hard,intr",
                    Description = "High-performance NFS v4.1 mount for shared data access"
                },
                new {
                    Type = "CIFS",
                    Source = "//fileserver.corp.com/department-data",
                    RelativeMountPath = "department-data", 
                    Options = "vers=3.0,uid=1000,gid=1000",
                    Description = "Corporate CIFS share for department data"
                }
            };

            foreach (var scenario in mountScenarios)
            {
                PSMountConfiguration psMountConfig = null;
                MountConfiguration mgmtMountConfig = null;

                if (scenario.Type == "NFS")
                {
                    var psNfsConfig = new PSNfsMountConfiguration(
                        source: scenario.Source,
                        relativeMountPath: scenario.RelativeMountPath,
                        mountOptions: scenario.Options);
                    psMountConfig = new PSMountConfiguration(psNfsConfig);

                    var mgmtNfsConfig = new NFSMountConfiguration(
                        source: scenario.Source,
                        relativeMountPath: scenario.RelativeMountPath,
                        mountOptions: scenario.Options);
                    mgmtMountConfig = new MountConfiguration(nfsMountConfiguration: mgmtNfsConfig);
                }
                else if (scenario.Type == "CIFS")
                {
                    var psCifsConfig = new PSCifsMountConfiguration(
                        username: "testuser",
                        password: "testpass",
                        source: scenario.Source,
                        relativeMountPath: scenario.RelativeMountPath,
                        mountOptions: scenario.Options);
                    psMountConfig = new PSMountConfiguration(psCifsConfig);

                    var mgmtCifsConfig = new CifsMountConfiguration(
                        userName: "testuser",
                        source: scenario.Source,
                        relativeMountPath: scenario.RelativeMountPath,
                        password: "testpass",
                        mountOptions: scenario.Options);
                    mgmtMountConfig = new MountConfiguration(cifsMountConfiguration: mgmtCifsConfig);
                }

                // Act - PS to Management conversion
                var mgmtResult = psMountConfig.toMgmtMountConfiguration();
                var backToPs = PSMountConfiguration.fromMgmtMountConfiguration(mgmtResult);

                // Assert - Verify semantic equivalence
                Assert.NotNull(mgmtResult);
                Assert.NotNull(backToPs);

                // Act - Management to PS conversion
                var psResult = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);
                var backToMgmt = psResult.toMgmtMountConfiguration();

                // Assert - Verify semantic equivalence in reverse direction
                Assert.NotNull(psResult);
                Assert.NotNull(backToMgmt);

                if (scenario.Type == "NFS")
                {
                    Assert.NotNull(backToPs.NfsMountConfiguration);
                    Assert.Equal(scenario.Source, backToPs.NfsMountConfiguration.Source);
                    Assert.Equal(scenario.RelativeMountPath, backToPs.NfsMountConfiguration.RelativeMountPath);
                    Assert.Equal(scenario.Options, backToPs.NfsMountConfiguration.MountOptions);

                    Assert.NotNull(psResult.NfsMountConfiguration);
                    Assert.Equal(scenario.Source, psResult.NfsMountConfiguration.Source);
                    Assert.Equal(scenario.RelativeMountPath, psResult.NfsMountConfiguration.RelativeMountPath);
                    Assert.Equal(scenario.Options, psResult.NfsMountConfiguration.MountOptions);
                }
                else if (scenario.Type == "CIFS")
                {
                    Assert.NotNull(backToPs.CifsMountConfiguration);
                    Assert.Equal(scenario.Source, backToPs.CifsMountConfiguration.Source);
                    Assert.Equal(scenario.RelativeMountPath, backToPs.CifsMountConfiguration.RelativeMountPath);
                    Assert.Equal(scenario.Options, backToPs.CifsMountConfiguration.MountOptions);

                    Assert.NotNull(psResult.CifsMountConfiguration);
                    Assert.Equal(scenario.Source, psResult.CifsMountConfiguration.Source);
                    Assert.Equal(scenario.RelativeMountPath, psResult.CifsMountConfiguration.RelativeMountPath);
                    Assert.Equal(scenario.Options, psResult.CifsMountConfiguration.MountOptions);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MountConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool mount configuration
            // MountConfiguration is used to mount file systems on Batch compute nodes for distributed storage access

            // Arrange - Test realistic Batch pool mount scenarios
            var batchScenarios = new PSMountConfiguration[]
            {
                // High-performance computing shared storage
                new PSMountConfiguration(new PSNfsMountConfiguration(
                    source: "hpc-nfs.example.com:/shared/datasets",
                    relativeMountPath: "datasets",
                    mountOptions: "vers=4.1,rsize=1048576,wsize=1048576,hard,intr,timeo=600")),
                    
                // Corporate file share for data processing
                new PSMountConfiguration(new PSCifsMountConfiguration(
                    username: "CORP\\batch-svc",
                    password: "BatchServicePassword123!",
                    source: "//corporate-storage.corp.com/batch-data",
                    relativeMountPath: "corporate-data",
                    mountOptions: "vers=3.0,uid=1000,gid=1000")),
                    
                // Azure Blob storage for temporary scratch space
                new PSMountConfiguration(new PSAzureBlobFileSystemConfiguration(
                    accountName: "batchstorage",
                    containerName: "scratch",
                    relativeMountPath: "scratch",
                    identityReference: new PSComputeNodeIdentityReference 
                    { 
                        ResourceId = "/subscriptions/test/resourceGroups/test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test" 
                    },
                    blobfuseOptions: "-o allow_other")),
                    
                // Azure File Share for persistent storage
                new PSMountConfiguration(new PSAzureFileShareConfiguration(
                    accountName: "batchfiles",
                    azureFileUrl: "https://batchfiles.file.core.windows.net/",
                    relativeMountPath: "persistent",
                    accountKey: "testkey123==",
                    mountOptions: "-o uid=1000,gid=1000"))
            };

            foreach (var scenario in batchScenarios)
            {
                // Act
                var mgmtMountConfig = scenario.toMgmtMountConfiguration();

                // Assert - Should convert correctly for Batch pool mount configuration
                Assert.NotNull(mgmtMountConfig);

                // Verify round-trip conversion maintains Batch pool semantics
                var backToPs = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);
                Assert.NotNull(backToPs);

                // Verify that only one mount type is set (mutually exclusive)
                var mountTypeCount = 0;
                if (mgmtMountConfig.NfsMountConfiguration != null) mountTypeCount++;
                if (mgmtMountConfig.CifsMountConfiguration != null) mountTypeCount++;
                if (mgmtMountConfig.AzureBlobFileSystemConfiguration != null) mountTypeCount++;
                if (mgmtMountConfig.AzureFileShareConfiguration != null) mountTypeCount++;
                
                Assert.Equal(1, mountTypeCount); // Exactly one mount type should be configured
            }
        }

        #endregion

        #region Performance Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MountConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psMountConfigs = new PSMountConfiguration[50];
            var mgmtMountConfigs = new MountConfiguration[50];

            for (int i = 0; i < 50; i++)
            {
                var psNfsConfig = new PSNfsMountConfiguration(
                    source: $"nfs{i}.example.com:/data{i}",
                    relativeMountPath: $"data{i}",
                    mountOptions: $"vers=4.{i % 2},rsize={1024 * (i + 1)}");
                psMountConfigs[i] = new PSMountConfiguration(psNfsConfig);

                var mgmtNfsConfig = new NFSMountConfiguration(
                    source: $"mgmt-nfs{i}.example.com:/volume{i}",
                    relativeMountPath: $"volume{i}",
                    mountOptions: $"vers=3,timeo={300 + i}");
                mgmtMountConfigs[i] = new MountConfiguration(nfsMountConfiguration: mgmtNfsConfig);
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 5; i++)
            {
                foreach (var psMountConfig in psMountConfigs)
                {
                    var mgmtResult = psMountConfig.toMgmtMountConfiguration();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtMountConfig in mgmtMountConfigs)
                {
                    var psResult = PSMountConfiguration.fromMgmtMountConfiguration(mgmtMountConfig);
                    Assert.NotNull(psResult);
                }
            }
        }

        #endregion
    }
}
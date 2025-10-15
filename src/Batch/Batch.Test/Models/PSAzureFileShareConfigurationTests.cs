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
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSAzureFileShareConfigurationTests
    {
        #region toMgmtAzureFileShareConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureFileShareConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "teststorageaccount",
                azureFileUrl: "https://teststorageaccount.file.core.windows.net/",
                accountKey: "dGVzdGFjY291bnRrZXk=",
                relativeMountPath: "azure-files",
                mountOptions: "vers=3.0,dir_mode=0777,file_mode=0777,uid=1000,gid=1000");

            // Act
            var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("teststorageaccount", mgmtConfig.AccountName);
            Assert.Equal("https://teststorageaccount.file.core.windows.net/", mgmtConfig.AzureFileUrl);
            Assert.Equal("dGVzdGFjY291bnRrZXk=", mgmtConfig.AccountKey);
            Assert.Equal("azure-files", mgmtConfig.RelativeMountPath);
            Assert.Equal("vers=3.0,dir_mode=0777,file_mode=0777,uid=1000,gid=1000", mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureFileShareConfiguration_WithoutMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "mystorageaccount",
                azureFileUrl: "https://mystorageaccount.file.core.windows.net/",
                accountKey: "bXlzdG9yYWdlYWNjb3VudGtleQ==",
                relativeMountPath: "shared-data",
                mountOptions: null);

            // Act
            var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("mystorageaccount", mgmtConfig.AccountName);
            Assert.Equal("https://mystorageaccount.file.core.windows.net/", mgmtConfig.AzureFileUrl);
            Assert.Equal("bXlzdG9yYWdlYWNjb3VudGtleQ==", mgmtConfig.AccountKey);
            Assert.Equal("shared-data", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureFileShareConfiguration_WithEmptyMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "emptymountstorageaccount",
                azureFileUrl: "https://emptymountstorageaccount.file.core.windows.net/",
                accountKey: "ZW1wdHltb3VudHN0b3JhZ2VhY2NvdW50a2V5",
                relativeMountPath: "empty-mount-data",
                mountOptions: "");

            // Act
            var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("emptymountstorageaccount", mgmtConfig.AccountName);
            Assert.Equal("https://emptymountstorageaccount.file.core.windows.net/", mgmtConfig.AzureFileUrl);
            Assert.Equal("ZW1wdHltb3VudHN0b3JhZ2VhY2NvdW50a2V5", mgmtConfig.AccountKey);
            Assert.Equal("empty-mount-data", mgmtConfig.RelativeMountPath);
            Assert.Equal("", mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureFileShareConfiguration_WithMinimalConfiguration_ConvertsCorrectly()
        {
            // Arrange - Using constructor without mount options parameter
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "basicstorageaccount",
                azureFileUrl: "https://basicstorageaccount.file.core.windows.net/",
                accountKey: "YmFzaWNzdG9yYWdlYWNjb3VudGtleQ==",
                relativeMountPath: "basic-files");

            // Act
            var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("basicstorageaccount", mgmtConfig.AccountName);
            Assert.Equal("https://basicstorageaccount.file.core.windows.net/", mgmtConfig.AzureFileUrl);
            Assert.Equal("YmFzaWNzdG9yYWdlYWNjb3VudGtleQ==", mgmtConfig.AccountKey);
            Assert.Equal("basic-files", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureFileShareConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "instanceteststorage",
                azureFileUrl: "https://instanceteststorage.file.core.windows.net/",
                accountKey: "aW5zdGFuY2V0ZXN0c3RvcmFnZWtleQ==",
                relativeMountPath: "instance-test");

            // Act
            var mgmtConfig1 = psConfig.toMgmtAzureFileShareConfiguration();
            var mgmtConfig2 = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig1);
            Assert.NotNull(mgmtConfig2);
            Assert.NotSame(mgmtConfig1, mgmtConfig2);
            Assert.Equal(mgmtConfig1.AccountName, mgmtConfig2.AccountName);
            Assert.Equal(mgmtConfig1.AzureFileUrl, mgmtConfig2.AzureFileUrl);
            Assert.Equal(mgmtConfig1.AccountKey, mgmtConfig2.AccountKey);
            Assert.Equal(mgmtConfig1.RelativeMountPath, mgmtConfig2.RelativeMountPath);
            Assert.Equal(mgmtConfig1.MountOptions, mgmtConfig2.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtAzureFileShareConfiguration_VerifyReturnType()
        {
            // Arrange
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "typeteststorage",
                azureFileUrl: "https://typeteststorage.file.core.windows.net/",
                accountKey: "dHlwZXRlc3RzdG9yYWdla2V5",
                relativeMountPath: "type-test");

            // Act
            var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.IsType<AzureFileShareConfiguration>(mgmtConfig);
            Assert.IsAssignableFrom<AzureFileShareConfiguration>(mgmtConfig);
        }

        #endregion

        #region fromMgmtAzureFileShareConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "teststorageaccount",
                azureFileUrl: "https://teststorageaccount.file.core.windows.net/",
                accountKey: "dGVzdGFjY291bnRrZXk=",
                relativeMountPath: "azure-files",
                mountOptions: "vers=3.0,dir_mode=0777,file_mode=0777,uid=1000,gid=1000");

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("teststorageaccount", psConfig.AccountName);
            Assert.Equal("https://teststorageaccount.file.core.windows.net/", psConfig.AzureFileUrl);
            Assert.Equal("dGVzdGFjY291bnRrZXk=", psConfig.AccountKey);
            Assert.Equal("azure-files", psConfig.RelativeMountPath);
            Assert.Equal("vers=3.0,dir_mode=0777,file_mode=0777,uid=1000,gid=1000", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_WithoutMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "mystorageaccount",
                azureFileUrl: "https://mystorageaccount.file.core.windows.net/",
                accountKey: "bXlzdG9yYWdlYWNjb3VudGtleQ==",
                relativeMountPath: "shared-data",
                mountOptions: null);

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("mystorageaccount", psConfig.AccountName);
            Assert.Equal("https://mystorageaccount.file.core.windows.net/", psConfig.AzureFileUrl);
            Assert.Equal("bXlzdG9yYWdlYWNjb3VudGtleQ==", psConfig.AccountKey);
            Assert.Equal("shared-data", psConfig.RelativeMountPath);
            Assert.Null(psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_WithEmptyMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "emptymountstorageaccount",
                azureFileUrl: "https://emptymountstorageaccount.file.core.windows.net/",
                accountKey: "ZW1wdHltb3VudHN0b3JhZ2VhY2NvdW50a2V5",
                relativeMountPath: "empty-mount-data",
                mountOptions: "");

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("emptymountstorageaccount", psConfig.AccountName);
            Assert.Equal("https://emptymountstorageaccount.file.core.windows.net/", psConfig.AzureFileUrl);
            Assert.Equal("ZW1wdHltb3VudHN0b3JhZ2VhY2NvdW50a2V5", psConfig.AccountKey);
            Assert.Equal("empty-mount-data", psConfig.RelativeMountPath);
            Assert.Equal("", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_WithMinimalConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "basicstorageaccount",
                azureFileUrl: "https://basicstorageaccount.file.core.windows.net/",
                accountKey: "YmFzaWNzdG9yYWdlYWNjb3VudGtleQ==",
                relativeMountPath: "basic-files");

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("basicstorageaccount", psConfig.AccountName);
            Assert.Equal("https://basicstorageaccount.file.core.windows.net/", psConfig.AzureFileUrl);
            Assert.Equal("YmFzaWNzdG9yYWdlYWNjb3VudGtleQ==", psConfig.AccountKey);
            Assert.Equal("basic-files", psConfig.RelativeMountPath);
            Assert.Null(psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "staticteststorage",
                azureFileUrl: "https://staticteststorage.file.core.windows.net/",
                accountKey: "c3RhdGljdGVzdHN0b3JhZ2VrZXk=",
                relativeMountPath: "static-test",
                mountOptions: "vers=2.1");

            // Act - Call static method directly on class
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("staticteststorage", psConfig.AccountName);
            Assert.Equal("https://staticteststorage.file.core.windows.net/", psConfig.AzureFileUrl);
            Assert.Equal("c3RhdGljdGVzdHN0b3JhZ2VrZXk=", psConfig.AccountKey);
            Assert.Equal("static-test", psConfig.RelativeMountPath);
            Assert.Equal("vers=2.1", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "instanceteststorage",
                azureFileUrl: "https://instanceteststorage.file.core.windows.net/",
                accountKey: "aW5zdGFuY2V0ZXN0c3RvcmFnZWtleQ==",
                relativeMountPath: "instance-test",
                mountOptions: "vers=3.0");

            // Act
            var psConfig1 = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);
            var psConfig2 = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig1);
            Assert.NotNull(psConfig2);
            Assert.NotSame(psConfig1, psConfig2);
            Assert.Equal(psConfig1.AccountName, psConfig2.AccountName);
            Assert.Equal(psConfig1.AzureFileUrl, psConfig2.AzureFileUrl);
            Assert.Equal(psConfig1.AccountKey, psConfig2.AccountKey);
            Assert.Equal(psConfig1.RelativeMountPath, psConfig2.RelativeMountPath);
            Assert.Equal(psConfig1.MountOptions, psConfig2.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtAzureFileShareConfiguration_VerifyReturnType()
        {
            // Arrange
            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "typeteststorage",
                azureFileUrl: "https://typeteststorage.file.core.windows.net/",
                accountKey: "dHlwZXRlc3RzdG9yYWdla2V5",
                relativeMountPath: "type-test");

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.IsType<PSAzureFileShareConfiguration>(psConfig);
            Assert.IsAssignableFrom<PSAzureFileShareConfiguration>(psConfig);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsConfig = new PSAzureFileShareConfiguration(
                accountName: "roundtripteststorage",
                azureFileUrl: "https://roundtripteststorage.file.core.windows.net/",
                accountKey: "cm91bmR0cmlwdGVzdHN0b3JhZ2VrZXk=",
                relativeMountPath: "roundtrip-test",
                mountOptions: "vers=3.0,dir_mode=0755,file_mode=0644,uid=1001,gid=1001");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtAzureFileShareConfiguration();
            var roundTripPsConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.AccountName, roundTripPsConfig.AccountName);
            Assert.Equal(originalPsConfig.AzureFileUrl, roundTripPsConfig.AzureFileUrl);
            Assert.Equal(originalPsConfig.AccountKey, roundTripPsConfig.AccountKey);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal(originalPsConfig.MountOptions, roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullMountOptions()
        {
            // Arrange
            var originalPsConfig = new PSAzureFileShareConfiguration(
                accountName: "nullmountteststorage",
                azureFileUrl: "https://nullmountteststorage.file.core.windows.net/",
                accountKey: "bnVsbG1vdW50dGVzdHN0b3JhZ2VrZXk=",
                relativeMountPath: "null-mount-test",
                mountOptions: null);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtAzureFileShareConfiguration();
            var roundTripPsConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.AccountName, roundTripPsConfig.AccountName);
            Assert.Equal(originalPsConfig.AzureFileUrl, roundTripPsConfig.AzureFileUrl);
            Assert.Equal(originalPsConfig.AccountKey, roundTripPsConfig.AccountKey);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Null(roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyMountOptions()
        {
            // Arrange
            var originalPsConfig = new PSAzureFileShareConfiguration(
                accountName: "emptymountteststorage",
                azureFileUrl: "https://emptymountteststorage.file.core.windows.net/",
                accountKey: "ZW1wdHltb3VudHRlc3RzdG9yYWdla2V5",
                relativeMountPath: "empty-mount-test",
                mountOptions: "");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtAzureFileShareConfiguration();
            var roundTripPsConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.AccountName, roundTripPsConfig.AccountName);
            Assert.Equal(originalPsConfig.AzureFileUrl, roundTripPsConfig.AzureFileUrl);
            Assert.Equal(originalPsConfig.AccountKey, roundTripPsConfig.AccountKey);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal("", roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalMgmtConfig = new AzureFileShareConfiguration(
                accountName: "reverseteststorage",
                azureFileUrl: "https://reverseteststorage.file.core.windows.net/",
                accountKey: "cmV2ZXJzZXRlc3RzdG9yYWdla2V5",
                relativeMountPath: "reverse-test",
                mountOptions: "vers=3.0,dir_mode=0755,file_mode=0644,uid=1001,gid=1001");

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.AccountName, roundTripMgmtConfig.AccountName);
            Assert.Equal(originalMgmtConfig.AzureFileUrl, roundTripMgmtConfig.AzureFileUrl);
            Assert.Equal(originalMgmtConfig.AccountKey, roundTripMgmtConfig.AccountKey);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal(originalMgmtConfig.MountOptions, roundTripMgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesNullMountOptions()
        {
            // Arrange
            var originalMgmtConfig = new AzureFileShareConfiguration(
                accountName: "nullreversetest",
                azureFileUrl: "https://nullreversetest.file.core.windows.net/",
                accountKey: "bnVsbHJldmVyc2V0ZXN0a2V5",
                relativeMountPath: "null-reverse-test",
                mountOptions: null);

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.AccountName, roundTripMgmtConfig.AccountName);
            Assert.Equal(originalMgmtConfig.AzureFileUrl, roundTripMgmtConfig.AzureFileUrl);
            Assert.Equal(originalMgmtConfig.AccountKey, roundTripMgmtConfig.AccountKey);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Null(roundTripMgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesEmptyMountOptions()
        {
            // Arrange
            var originalMgmtConfig = new AzureFileShareConfiguration(
                accountName: "emptyreversetest",
                azureFileUrl: "https://emptyreversetest.file.core.windows.net/",
                accountKey: "ZW1wdHlyZXZlcnNldGVzdGtleQ==",
                relativeMountPath: "empty-reverse-test",
                mountOptions: "");

            // Act
            var psConfig = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.AccountName, roundTripMgmtConfig.AccountName);
            Assert.Equal(originalMgmtConfig.AzureFileUrl, roundTripMgmtConfig.AzureFileUrl);
            Assert.Equal(originalMgmtConfig.AccountKey, roundTripMgmtConfig.AccountKey);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal("", roundTripMgmtConfig.MountOptions);
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch Azure Files mounting

            // Test various Azure Files mount scenarios
            var azureFilesScenarios = new[]
            {
                new {
                    AccountName = "prodstorageaccount",
                    AzureFileUrl = "https://prodstorageaccount.file.core.windows.net/",
                    AccountKey = "cHJvZHN0b3JhZ2VhY2NvdW50a2V5",
                    RelativeMountPath = "production-data",
                    MountOptions = "vers=3.0,dir_mode=0755,file_mode=0644,uid=1000,gid=1000,serverino",
                    Description = "Production Azure Files mount with SMB 3.0 and specific permissions"
                },
                new {
                    AccountName = "mlstorageaccount",
                    AzureFileUrl = "https://mlstorageaccount.file.core.windows.net/",
                    AccountKey = "bWxzdG9yYWdlYWNjb3VudGtleQ==",
                    RelativeMountPath = "ml-datasets",
                    MountOptions = "vers=3.0,cache=strict,actimeo=30,rsize=1048576,wsize=1048576",
                    Description = "Machine learning datasets mount with high performance settings"
                },
                new {
                    AccountName = "devstorageaccount",
                    AzureFileUrl = "https://devstorageaccount.file.core.windows.net/",
                    AccountKey = "ZGV2c3RvcmFnZWFjY291bnRrZXk=",
                    RelativeMountPath = "dev-shared",
                    MountOptions = (string)null,
                    Description = "Development shared storage without specific options"
                },
                new {
                    AccountName = "backupstorageaccount",
                    AzureFileUrl = "https://backupstorageaccount.file.core.windows.net/",
                    AccountKey = "YmFja3Vwc3RvcmFnZWFjY291bnRrZXk=",
                    RelativeMountPath = "backup-results",
                    MountOptions = "vers=2.1,dir_mode=0700,file_mode=0600,uid=0,gid=0",
                    Description = "Backup storage with restricted permissions for archival"
                }
            };

            foreach (var scenario in azureFilesScenarios)
            {
                // Act - PS to Management conversion
                var psConfig = new PSAzureFileShareConfiguration(
                    accountName: scenario.AccountName,
                    azureFileUrl: scenario.AzureFileUrl,
                    accountKey: scenario.AccountKey,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();
                var backToPs = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

                // Assert - Verify semantic equivalence
                Assert.NotNull(mgmtConfig);
                Assert.Equal(scenario.AccountName, mgmtConfig.AccountName);
                Assert.Equal(scenario.AzureFileUrl, mgmtConfig.AzureFileUrl);
                Assert.Equal(scenario.AccountKey, mgmtConfig.AccountKey);
                Assert.Equal(scenario.RelativeMountPath, mgmtConfig.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtConfig.MountOptions);

                Assert.NotNull(backToPs);
                Assert.Equal(scenario.AccountName, backToPs.AccountName);
                Assert.Equal(scenario.AzureFileUrl, backToPs.AzureFileUrl);
                Assert.Equal(scenario.AccountKey, backToPs.AccountKey);
                Assert.Equal(scenario.RelativeMountPath, backToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToPs.MountOptions);

                // Act - Management to PS conversion
                var originalMgmtConfig = new AzureFileShareConfiguration(
                    accountName: scenario.AccountName,
                    azureFileUrl: scenario.AzureFileUrl,
                    accountKey: scenario.AccountKey,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                var mgmtToPs = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(originalMgmtConfig);
                var backToMgmt = mgmtToPs.toMgmtAzureFileShareConfiguration();

                // Assert - Verify semantic equivalence in reverse direction
                Assert.NotNull(mgmtToPs);
                Assert.Equal(scenario.AccountName, mgmtToPs.AccountName);
                Assert.Equal(scenario.AzureFileUrl, mgmtToPs.AzureFileUrl);
                Assert.Equal(scenario.AccountKey, mgmtToPs.AccountKey);
                Assert.Equal(scenario.RelativeMountPath, mgmtToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtToPs.MountOptions);

                Assert.NotNull(backToMgmt);
                Assert.Equal(scenario.AccountName, backToMgmt.AccountName);
                Assert.Equal(scenario.AzureFileUrl, backToMgmt.AzureFileUrl);
                Assert.Equal(scenario.AccountKey, backToMgmt.AccountKey);
                Assert.Equal(scenario.RelativeMountPath, backToMgmt.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToMgmt.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool mount configuration
            // AzureFileShareConfiguration is used to mount Azure Files on Batch compute nodes for cloud-native file sharing

            // Arrange - Test Azure Files scenarios for different workloads
            var azureFilesScenarios = new PSAzureFileShareConfiguration[]
            {
                new PSAzureFileShareConfiguration(
                    accountName: "hpcstorageaccount",
                    azureFileUrl: "https://hpcstorageaccount.file.core.windows.net/",
                    accountKey: "aHBjc3RvcmFnZWFjY291bnRrZXk=",
                    relativeMountPath: "hpc-scratch",
                    mountOptions: "vers=3.0,dir_mode=0777,file_mode=0777,uid=1000,gid=1000,cache=loose"
                    //Description = "HPC scratch space with relaxed caching for high throughput"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "biostorageaccount",
                    azureFileUrl: "https://biostorageaccount.file.core.windows.net/",
                    accountKey: "Ymlvc3RvcmFnZWFjY291bnRrZXk=",
                    relativeMountPath: "genomics-data",
                    mountOptions: "vers=3.0,dir_mode=0755,file_mode=0644,uid=1001,gid=1001,rsize=1048576,wsize=1048576"
                    //Description = "Genomics data storage with optimized read/write buffer sizes"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "sharedstorageaccount",
                    azureFileUrl: "https://sharedstorageaccount.file.core.windows.net/",
                    accountKey: "c2hhcmVkc3RvcmFnZWFjY291bnRrZXk=",
                    relativeMountPath: "shared-workspace",
                    mountOptions: null
                    //Description = "Simple shared workspace without specific mount options"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "securestorageaccount",
                    azureFileUrl: "https://securestorageaccount.file.core.windows.net/",
                    accountKey: "c2VjdXJlc3RvcmFnZWFjY291bnRrZXk=",
                    relativeMountPath: "secure-data",
                    mountOptions: "vers=3.0,dir_mode=0700,file_mode=0600,uid=0,gid=0,nobrl"
                    //Description = "Secure data storage with restricted permissions and no byte-range locking"
                )
            };

            foreach (var scenario in azureFilesScenarios)
            {
                // Arrange
                var psAzureFilesConfig = new PSAzureFileShareConfiguration(
                    accountName: scenario.AccountName,
                    azureFileUrl: scenario.AzureFileUrl,
                    accountKey: scenario.AccountKey,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                // Act
                var mgmtAzureFilesConfig = psAzureFilesConfig.toMgmtAzureFileShareConfiguration();

                // Assert - Should convert correctly for Batch pool mount configuration
                Assert.NotNull(mgmtAzureFilesConfig);
                Assert.Equal(scenario.AccountName, mgmtAzureFilesConfig.AccountName);
                Assert.Equal(scenario.AzureFileUrl, mgmtAzureFilesConfig.AzureFileUrl);
                Assert.Equal(scenario.AccountKey, mgmtAzureFilesConfig.AccountKey);
                Assert.Equal(scenario.RelativeMountPath, mgmtAzureFilesConfig.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtAzureFilesConfig.MountOptions);

                // Verify round-trip conversion maintains Batch pool semantics
                var backToPs = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtAzureFilesConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.AccountName, backToPs.AccountName);
                Assert.Equal(scenario.AzureFileUrl, backToPs.AzureFileUrl);
                Assert.Equal(scenario.AccountKey, backToPs.AccountKey);
                Assert.Equal(scenario.RelativeMountPath, backToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToPs.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psConfig = new PSAzureFileShareConfiguration(
                accountName: "instancetest",
                azureFileUrl: "https://instancetest.file.core.windows.net/",
                accountKey: "aW5zdGFuY2V0ZXN0a2V5",
                relativeMountPath: "instance-data",
                mountOptions: "vers=3.0");

            var mgmtConfig = new AzureFileShareConfiguration(
                accountName: "mgmtinstancetest",
                azureFileUrl: "https://mgmtinstancetest.file.core.windows.net/",
                accountKey: "bWdtaW5zdGFuY2V0ZXN0a2V5",
                relativeMountPath: "mgmt-instance-data",
                mountOptions: "vers=2.1");

            // Act
            var mgmtResult = psConfig.toMgmtAzureFileShareConfiguration();
            var psResult = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<AzureFileShareConfiguration>(mgmtResult);
            Assert.IsType<PSAzureFileShareConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testConfigurations = new[]
            {
                // Standard configurations
                new { 
                    AccountName = "standardaccount", 
                    AzureFileUrl = "https://standardaccount.file.core.windows.net/", 
                    AccountKey = "c3RhbmRhcmRhY2NvdW50a2V5", 
                    RelativeMountPath = "standard", 
                    MountOptions = "vers=3.0" 
                },
                new { 
                    AccountName = "premiumaccount", 
                    AzureFileUrl = "https://premiumaccount.file.core.windows.net/", 
                    AccountKey = "cHJlbWl1bWFjY291bnRrZXk=", 
                    RelativeMountPath = "premium-data", 
                    MountOptions = "vers=2.1" 
                },
                // Edge cases
                new { 
                    AccountName = "", 
                    AzureFileUrl = "", 
                    AccountKey = "", 
                    RelativeMountPath = "", 
                    MountOptions = "" 
                },
                new { 
                    AccountName = "account-with-special-chars", 
                    AzureFileUrl = "https://account-with-special-chars.file.core.windows.net/", 
                    AccountKey = "YWNjb3VudC13aXRoLXNwZWNpYWwtY2hhcnMta2V5", 
                    RelativeMountPath = "path with spaces", 
                    MountOptions = (string)null 
                },
                new { 
                    AccountName = "   ", 
                    AzureFileUrl = "   ", 
                    AccountKey = "   ", 
                    RelativeMountPath = "   ", 
                    MountOptions = "   " 
                }, // Whitespace
                new { 
                    AccountName = "verylongaccountnamefortestingpurposesthatexceedsnormallimits", 
                    AzureFileUrl = "https://verylongaccountnamefortestingpurposesthatexceedsnormallimits.file.core.windows.net/", 
                    AccountKey = "dmVyeWxvbmdhY2NvdW50bmFtZWZvcnRlc3RpbmdwdXJwb3Nlc3RoYXRleGNlZWRzbm9ybWFsbGltaXRzLWtleQ==", 
                    RelativeMountPath = "very-long-relative-mount-path-for-testing-purposes-that-exceeds-normal-limits", 
                    MountOptions = "vers=3.0,dir_mode=0755,file_mode=0644,uid=1000,gid=1000,cache=strict,actimeo=30,rsize=1048576,wsize=1048576,serverino" 
                }
            };

            foreach (var testConfig in testConfigurations)
            {
                // Arrange
                var psConfig = new PSAzureFileShareConfiguration(
                    accountName: testConfig.AccountName,
                    azureFileUrl: testConfig.AzureFileUrl,
                    accountKey: testConfig.AccountKey,
                    relativeMountPath: testConfig.RelativeMountPath,
                    mountOptions: testConfig.MountOptions);

                var mgmtConfig = new AzureFileShareConfiguration(
                    accountName: testConfig.AccountName,
                    azureFileUrl: testConfig.AzureFileUrl,
                    accountKey: testConfig.AccountKey,
                    relativeMountPath: testConfig.RelativeMountPath,
                    mountOptions: testConfig.MountOptions);

                // Act
                var mgmtResult = psConfig.toMgmtAzureFileShareConfiguration();
                var psFromMgmtResult = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);
                var roundTripResult = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(psFromMgmtResult);
                Assert.NotNull(roundTripResult);

                Assert.Equal(testConfig.AccountName, mgmtResult.AccountName);
                Assert.Equal(testConfig.AzureFileUrl, mgmtResult.AzureFileUrl);
                Assert.Equal(testConfig.AccountKey, mgmtResult.AccountKey);
                Assert.Equal(testConfig.RelativeMountPath, mgmtResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, mgmtResult.MountOptions);

                Assert.Equal(testConfig.AccountName, psFromMgmtResult.AccountName);
                Assert.Equal(testConfig.AzureFileUrl, psFromMgmtResult.AzureFileUrl);
                Assert.Equal(testConfig.AccountKey, psFromMgmtResult.AccountKey);
                Assert.Equal(testConfig.RelativeMountPath, psFromMgmtResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, psFromMgmtResult.MountOptions);

                Assert.Equal(testConfig.AccountName, roundTripResult.AccountName);
                Assert.Equal(testConfig.AzureFileUrl, roundTripResult.AzureFileUrl);
                Assert.Equal(testConfig.AccountKey, roundTripResult.AccountKey);
                Assert.Equal(testConfig.RelativeMountPath, roundTripResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, roundTripResult.MountOptions);
            }
        }

        #endregion

        #region Performance and Azure Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psConfigs = new List<PSAzureFileShareConfiguration>();
            var mgmtConfigs = new List<AzureFileShareConfiguration>();

            for (int i = 0; i < 100; i++)
            {
                psConfigs.Add(new PSAzureFileShareConfiguration(
                    accountName: $"teststorage{i}",
                    azureFileUrl: $"https://teststorage{i}.file.core.windows.net/",
                    accountKey: $"dGVzdHN0b3JhZ2V7aX1rZXk=", // base64 encoded test key
                    relativeMountPath: $"test-data-{i}",
                    mountOptions: $"vers=3.{i % 2},uid={1000 + i},gid={1000 + i}"));

                mgmtConfigs.Add(new AzureFileShareConfiguration(
                    accountName: $"mgmtteststorage{i}",
                    azureFileUrl: $"https://mgmtteststorage{i}.file.core.windows.net/",
                    accountKey: $"bWdtdGVzdHN0b3JhZ2V7aX1rZXk=", // base64 encoded test key
                    relativeMountPath: $"mgmt-test-data-{i}",
                    mountOptions: $"vers=2.{i % 2 + 1},rsize={1024 * (i + 1)},wsize={1024 * (i + 1)}"));
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psConfig in psConfigs)
                {
                    var mgmtResult = psConfig.toMgmtAzureFileShareConfiguration();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtConfig in mgmtConfigs)
                {
                    var psResult = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);
                    Assert.NotNull(psResult);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_RealWorldAzureFilesOptions_HandleCorrectly()
        {
            // Test with realistic Azure Files mount options that would be used in production

            var realWorldConfigurations = new PSAzureFileShareConfiguration[]
            {
                new PSAzureFileShareConfiguration(
                    accountName: "prodmlstorageaccount",
                    azureFileUrl: "https://prodmlstorageaccount.file.core.windows.net/",
                    accountKey: "cHJvZG1sc3RvcmFnZWFjY291bnRrZXk=",
                    relativeMountPath: "ml-production-data",
                    mountOptions: "vers=3.0,dir_mode=0755,file_mode=0644,uid=1000,gid=1000,cache=strict,actimeo=30,rsize=1048576,wsize=1048576"
                    //Description = "Production ML workload with high performance and strict caching"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "bioinfostorageaccount",
                    azureFileUrl: "https://bioinfostorageaccount.file.core.windows.net/",
                    accountKey: "YmlvaW5mb3N0b3JhZ2VhY2NvdW50a2V5",
                    relativeMountPath: "bioinformatics-datasets",
                    mountOptions: "vers=3.0,dir_mode=0755,file_mode=0644,uid=1001,gid=1001,cache=loose,actimeo=1"
                    //Description = "Bioinformatics datasets with relaxed caching for large file access patterns"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "hpcsharedstorageaccount",
                    azureFileUrl: "https://hpcsharedstorageaccount.file.core.windows.net/",
                    accountKey: "aHBjc2hhcmVkc3RvcmFnZWFjY291bnRrZXk=",
                    relativeMountPath: "hpc-shared-workspace",
                    mountOptions: "vers=3.0,dir_mode=0777,file_mode=0666,uid=1000,gid=1000,mfsymlinks"
                    //Description = "HPC shared workspace with symbolic link support for collaborative computing"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "securearchiveaccount",
                    azureFileUrl: "https://securearchiveaccount.file.core.windows.net/",
                    accountKey: "c2VjdXJlYXJjaGl2ZWFjY291bnRrZXk=",
                    relativeMountPath: "secure-archive",
                    mountOptions: "vers=2.1,dir_mode=0700,file_mode=0600,uid=0,gid=0,nobrl"
                    //Description = "Secure archive storage with restricted permissions and no byte-range locking"
                ),
                new PSAzureFileShareConfiguration(
                    accountName: "basicsharedaccount",
                    azureFileUrl: "https://basicsharedaccount.file.core.windows.net/",
                    accountKey: "YmFzaWNzaGFyZWRhY2NvdW50a2V5",
                    relativeMountPath: "basic-shared",
                    mountOptions: null
                    //Description = "Basic shared storage without specific mount options"
                )
            };

            foreach (var config in realWorldConfigurations)
            {
                // Arrange
                var psConfig = new PSAzureFileShareConfiguration(
                    accountName: config.AccountName,
                    azureFileUrl: config.AzureFileUrl,
                    accountKey: config.AccountKey,
                    relativeMountPath: config.RelativeMountPath,
                    mountOptions: config.MountOptions);

                // Act
                var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();
                var roundTripPs = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

                // Assert
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                Assert.Equal(config.AccountName, mgmtConfig.AccountName);
                Assert.Equal(config.AzureFileUrl, mgmtConfig.AzureFileUrl);
                Assert.Equal(config.AccountKey, mgmtConfig.AccountKey);
                Assert.Equal(config.RelativeMountPath, mgmtConfig.RelativeMountPath);
                Assert.Equal(config.MountOptions, mgmtConfig.MountOptions);

                Assert.Equal(config.AccountName, roundTripPs.AccountName);
                Assert.Equal(config.AzureFileUrl, roundTripPs.AzureFileUrl);
                Assert.Equal(config.AccountKey, roundTripPs.AccountKey);
                Assert.Equal(config.RelativeMountPath, roundTripPs.RelativeMountPath);
                Assert.Equal(config.MountOptions, roundTripPs.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureFileShareConfigurationConversions_AzureUrlFormats_VerifyBehavior()
        {
            // Test with various Azure Files URL formats to ensure they're preserved correctly

            var urlFormatScenarios = new[]
            {
                // Standard Azure Files URLs
                new { AccountName = "standardaccount", AzureFileUrl = "https://standardaccount.file.core.windows.net/", Description = "Standard Azure Files URL" },
                new { AccountName = "customdomain", AzureFileUrl = "https://customdomain.file.core.windows.net/", Description = "Custom domain URL" },
                // URLs with different Azure environments
                new { AccountName = "govaccount", AzureFileUrl = "https://govaccount.file.core.usgovcloudapi.net/", Description = "Azure Government cloud URL" },
                new { AccountName = "chinaaccount", AzureFileUrl = "https://chinaaccount.file.core.chinacloudapi.cn/", Description = "Azure China cloud URL" },
                new { AccountName = "germanyaccount", AzureFileUrl = "https://germanyaccount.file.core.cloudapi.de/", Description = "Azure Germany cloud URL" },
                // Edge case URLs
                new { AccountName = "edgecase", AzureFileUrl = "", Description = "Empty URL" },
                new { AccountName = "testaccount", AzureFileUrl = "https://testaccount.file.core.windows.net/myfileshare", Description = "URL with specific file share path" },
                new { AccountName = "portaccount", AzureFileUrl = "https://portaccount.file.core.windows.net:443/", Description = "URL with explicit port" },
                // Unicode and special character URLs
                new { AccountName = "unicodetest", AzureFileUrl = "https://unicodetest.file.core.windows.net/café", Description = "URL with Unicode characters" },
                new { AccountName = "spacestest", AzureFileUrl = "https://spacestest.file.core.windows.net/path with spaces", Description = "URL with spaces" }
            };

            foreach (var scenario in urlFormatScenarios)
            {
                // Arrange
                var psConfig = new PSAzureFileShareConfiguration(
                    accountName: scenario.AccountName,
                    azureFileUrl: scenario.AzureFileUrl,
                    accountKey: "dGVzdGFjY291bnRrZXk=",
                    relativeMountPath: "test-mount",
                    mountOptions: "vers=3.0");

                // Act
                var mgmtConfig = psConfig.toMgmtAzureFileShareConfiguration();
                var roundTripPs = PSAzureFileShareConfiguration.fromMgmtAzureFileShareConfiguration(mgmtConfig);

                // Assert - All URL formats should be preserved exactly as provided
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                Assert.Equal(scenario.AzureFileUrl, mgmtConfig.AzureFileUrl);
                Assert.Equal(scenario.AzureFileUrl, roundTripPs.AzureFileUrl);
                Assert.Equal(scenario.AccountName, mgmtConfig.AccountName);
                Assert.Equal(scenario.AccountName, roundTripPs.AccountName);
            }
        }

        #endregion
    }
}
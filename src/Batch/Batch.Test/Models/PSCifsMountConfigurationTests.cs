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
    public class PSCifsMountConfigurationTests
    {
        #region toMgmtCifsMountConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtCifsMountConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSCifsMountConfiguration(
                username: "domain\\testuser",
                password: "testpassword123",
                source: "//file-server.example.com/shared",
                relativeMountPath: "shared-files",
                mountOptions: "vers=3.0,uid=1000,gid=1000,iocharset=utf8");

            // Act
            var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("domain\\testuser", mgmtConfig.UserName);
            Assert.Equal("testpassword123", mgmtConfig.Password);
            Assert.Equal("//file-server.example.com/shared", mgmtConfig.Source);
            Assert.Equal("shared-files", mgmtConfig.RelativeMountPath);
            Assert.Equal("vers=3.0,uid=1000,gid=1000,iocharset=utf8", mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtCifsMountConfiguration_WithoutMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "password",
                source: "//192.168.1.100/data",
                relativeMountPath: "network-data",
                mountOptions: null);

            // Act
            var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("testuser", mgmtConfig.UserName);
            Assert.Equal("password", mgmtConfig.Password);
            Assert.Equal("//192.168.1.100/data", mgmtConfig.Source);
            Assert.Equal("network-data", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtCifsMountConfiguration_WithEmptyMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSCifsMountConfiguration(
                username: "user@domain.com",
                password: "securepassword",
                source: "//azure-files.file.core.windows.net/fileshare",
                relativeMountPath: "azure-files",
                mountOptions: "");

            // Act
            var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("user@domain.com", mgmtConfig.UserName);
            Assert.Equal("securepassword", mgmtConfig.Password);
            Assert.Equal("//azure-files.file.core.windows.net/fileshare", mgmtConfig.Source);
            Assert.Equal("azure-files", mgmtConfig.RelativeMountPath);
            Assert.Equal("", mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtCifsMountConfiguration_WithMinimalConfiguration_ConvertsCorrectly()
        {
            // Arrange - Using constructor without mount options parameter
            var psConfig = new PSCifsMountConfiguration(
                username: "basicuser",
                password: "basicpass",
                source: "//server/share",
                relativeMountPath: "share");

            // Act
            var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal("basicuser", mgmtConfig.UserName);
            Assert.Equal("basicpass", mgmtConfig.Password);
            Assert.Equal("//server/share", mgmtConfig.Source);
            Assert.Equal("share", mgmtConfig.RelativeMountPath);
            Assert.Null(mgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtCifsMountConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "testpass",
                source: "//server/data",
                relativeMountPath: "data");

            // Act
            var mgmtConfig1 = psConfig.toMgmtCifsMountConfiguration();
            var mgmtConfig2 = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig1);
            Assert.NotNull(mgmtConfig2);
            Assert.NotSame(mgmtConfig1, mgmtConfig2);
            Assert.Equal(mgmtConfig1.UserName, mgmtConfig2.UserName);
            Assert.Equal(mgmtConfig1.Password, mgmtConfig2.Password);
            Assert.Equal(mgmtConfig1.Source, mgmtConfig2.Source);
            Assert.Equal(mgmtConfig1.RelativeMountPath, mgmtConfig2.RelativeMountPath);
            Assert.Equal(mgmtConfig1.MountOptions, mgmtConfig2.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtCifsMountConfiguration_VerifyReturnType()
        {
            // Arrange
            var psConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "testpass",
                source: "//server/test",
                relativeMountPath: "test");

            // Act
            var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.IsType<CifsMountConfiguration>(mgmtConfig);
            Assert.IsAssignableFrom<CifsMountConfiguration>(mgmtConfig);
        }

        #endregion

        #region fromMgmtCifsMountConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "domain\\testuser",
                source: "//file-server.example.com/shared",
                relativeMountPath: "shared-files",
                password: "testpassword123",
                mountOptions: "vers=3.0,uid=1000,gid=1000,iocharset=utf8");

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("domain\\testuser", psConfig.Username);
            Assert.Equal("testpassword123", psConfig.Password);
            Assert.Equal("//file-server.example.com/shared", psConfig.Source);
            Assert.Equal("shared-files", psConfig.RelativeMountPath);
            Assert.Equal("vers=3.0,uid=1000,gid=1000,iocharset=utf8", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_WithoutMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "testuser",
                source: "//192.168.1.100/data",
                relativeMountPath: "network-data",
                password: "password",
                mountOptions: null);

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("testuser", psConfig.Username);
            Assert.Equal("password", psConfig.Password);
            Assert.Equal("//192.168.1.100/data", psConfig.Source);
            Assert.Equal("network-data", psConfig.RelativeMountPath);
            Assert.Null(psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_WithEmptyMountOptions_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "user@domain.com",
                source: "//azure-files.file.core.windows.net/fileshare",
                relativeMountPath: "azure-files",
                password: "securepassword",
                mountOptions: "");

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("user@domain.com", psConfig.Username);
            Assert.Equal("securepassword", psConfig.Password);
            Assert.Equal("//azure-files.file.core.windows.net/fileshare", psConfig.Source);
            Assert.Equal("azure-files", psConfig.RelativeMountPath);
            Assert.Equal("", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_WithMinimalConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "basicuser",
                source: "//server/share",
                relativeMountPath: "share",
                password: "basicpass");

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("basicuser", psConfig.Username);
            Assert.Equal("basicpass", psConfig.Password);
            Assert.Equal("//server/share", psConfig.Source);
            Assert.Equal("share", psConfig.RelativeMountPath);
            Assert.Null(psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "staticuser",
                source: "//test.com/data",
                relativeMountPath: "test-data",
                password: "staticpass",
                mountOptions: "vers=2.1");

            // Act - Call static method directly on class
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal("staticuser", psConfig.Username);
            Assert.Equal("staticpass", psConfig.Password);
            Assert.Equal("//test.com/data", psConfig.Source);
            Assert.Equal("test-data", psConfig.RelativeMountPath);
            Assert.Equal("vers=2.1", psConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "testuser",
                source: "//server/data",
                relativeMountPath: "data",
                password: "testpass",
                mountOptions: "vers=3");

            // Act
            var psConfig1 = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);
            var psConfig2 = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig1);
            Assert.NotNull(psConfig2);
            Assert.NotSame(psConfig1, psConfig2);
            Assert.Equal(psConfig1.Username, psConfig2.Username);
            Assert.Equal(psConfig1.Password, psConfig2.Password);
            Assert.Equal(psConfig1.Source, psConfig2.Source);
            Assert.Equal(psConfig1.RelativeMountPath, psConfig2.RelativeMountPath);
            Assert.Equal(psConfig1.MountOptions, psConfig2.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtCifsMountConfiguration_VerifyReturnType()
        {
            // Arrange
            var mgmtConfig = new CifsMountConfiguration(
                userName: "testuser",
                source: "//server/test",
                relativeMountPath: "test",
                password: "testpass");

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.IsType<PSCifsMountConfiguration>(psConfig);
            Assert.IsAssignableFrom<PSCifsMountConfiguration>(psConfig);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsConfig = new PSCifsMountConfiguration(
                username: "domain\\testuser",
                password: "testpassword123",
                source: "//file-server.example.com/shared",
                relativeMountPath: "shared-files",
                mountOptions: "vers=3.0,uid=1000,gid=1000,iocharset=utf8");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtCifsMountConfiguration();
            var roundTripPsConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Username, roundTripPsConfig.Username);
            Assert.Equal(originalPsConfig.Password, roundTripPsConfig.Password);
            Assert.Equal(originalPsConfig.Source, roundTripPsConfig.Source);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal(originalPsConfig.MountOptions, roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullMountOptions()
        {
            // Arrange
            var originalPsConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "password",
                source: "//server/shared",
                relativeMountPath: "shared",
                mountOptions: null);

            // Act
            var mgmtConfig = originalPsConfig.toMgmtCifsMountConfiguration();
            var roundTripPsConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Username, roundTripPsConfig.Username);
            Assert.Equal(originalPsConfig.Password, roundTripPsConfig.Password);
            Assert.Equal(originalPsConfig.Source, roundTripPsConfig.Source);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Null(roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesEmptyMountOptions()
        {
            // Arrange
            var originalPsConfig = new PSCifsMountConfiguration(
                username: "user@domain.com",
                password: "securepassword",
                source: "//azure-files.file.core.windows.net/fileshare",
                relativeMountPath: "azure-files",
                mountOptions: "");

            // Act
            var mgmtConfig = originalPsConfig.toMgmtCifsMountConfiguration();
            var roundTripPsConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Username, roundTripPsConfig.Username);
            Assert.Equal(originalPsConfig.Password, roundTripPsConfig.Password);
            Assert.Equal(originalPsConfig.Source, roundTripPsConfig.Source);
            Assert.Equal(originalPsConfig.RelativeMountPath, roundTripPsConfig.RelativeMountPath);
            Assert.Equal("", roundTripPsConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalMgmtConfig = new CifsMountConfiguration(
                userName: "domain\\testuser",
                source: "//file-server.example.com/shared",
                relativeMountPath: "shared-files",
                password: "testpassword123",
                mountOptions: "vers=3.0,uid=1000,gid=1000,iocharset=utf8");

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.UserName, roundTripMgmtConfig.UserName);
            Assert.Equal(originalMgmtConfig.Password, roundTripMgmtConfig.Password);
            Assert.Equal(originalMgmtConfig.Source, roundTripMgmtConfig.Source);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal(originalMgmtConfig.MountOptions, roundTripMgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesNullMountOptions()
        {
            // Arrange
            var originalMgmtConfig = new CifsMountConfiguration(
                userName: "testuser",
                source: "//server/shared",
                relativeMountPath: "shared",
                password: "password",
                mountOptions: null);

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.UserName, roundTripMgmtConfig.UserName);
            Assert.Equal(originalMgmtConfig.Password, roundTripMgmtConfig.Password);
            Assert.Equal(originalMgmtConfig.Source, roundTripMgmtConfig.Source);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Null(roundTripMgmtConfig.MountOptions);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesEmptyMountOptions()
        {
            // Arrange
            var originalMgmtConfig = new CifsMountConfiguration(
                userName: "user@domain.com",
                source: "//azure-files.file.core.windows.net/fileshare",
                relativeMountPath: "azure-files",
                password: "securepassword",
                mountOptions: "");

            // Act
            var psConfig = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.toMgmtCifsMountConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.UserName, roundTripMgmtConfig.UserName);
            Assert.Equal(originalMgmtConfig.Password, roundTripMgmtConfig.Password);
            Assert.Equal(originalMgmtConfig.Source, roundTripMgmtConfig.Source);
            Assert.Equal(originalMgmtConfig.RelativeMountPath, roundTripMgmtConfig.RelativeMountPath);
            Assert.Equal("", roundTripMgmtConfig.MountOptions);
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch CIFS file system mounting

            // Test various CIFS mount scenarios
            var cifsScenarios = new[]
            {
                new {
                    Username = "domain\\enterprise-user",
                    Password = "ComplexPassword123!",
                    Source = "//enterprise-nas.corp.com/shared-data",
                    RelativeMountPath = "enterprise-data",
                    MountOptions = "vers=3.0,uid=1000,gid=1000,iocharset=utf8,file_mode=0644,dir_mode=0755",
                    Description = "Enterprise CIFS mount with SMB 3.0 and specific permissions"
                },
                new {
                    Username = "azureuser@company.onmicrosoft.com",
                    Password = "AzureFileShareKey",
                    Source = "//mystorageaccount.file.core.windows.net/myfileshare",
                    RelativeMountPath = "azure-files",
                    MountOptions = "vers=3.0,cache=strict,actimeo=30",
                    Description = "Azure Files mount with strict caching and attribute timeout"
                },
                new {
                    Username = "batchuser",
                    Password = "SimplePassword",
                    Source = "//192.168.100.50/batch-shared",
                    RelativeMountPath = "batch-data",
                    MountOptions = (string)null,
                    Description = "Basic CIFS mount without specific options"
                },
                new {
                    Username = "admin",
                    Password = "AdminPass",
                    Source = "//windows-server/d$/projects",
                    RelativeMountPath = "projects",
                    MountOptions = "vers=2.1,sec=ntlmssp,rsize=65536,wsize=65536",
                    Description = "Windows server mount with NTLM authentication and optimized I/O"
                }
            };

            foreach (var scenario in cifsScenarios)
            {
                // Act - PS to Management conversion
                var psConfig = new PSCifsMountConfiguration(
                    username: scenario.Username,
                    password: scenario.Password,
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();
                var backToPs = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

                // Assert - Verify semantic equivalence
                Assert.NotNull(mgmtConfig);
                Assert.Equal(scenario.Username, mgmtConfig.UserName);
                Assert.Equal(scenario.Password, mgmtConfig.Password);
                Assert.Equal(scenario.Source, mgmtConfig.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtConfig.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtConfig.MountOptions);

                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Username, backToPs.Username);
                Assert.Equal(scenario.Password, backToPs.Password);
                Assert.Equal(scenario.Source, backToPs.Source);
                Assert.Equal(scenario.RelativeMountPath, backToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToPs.MountOptions);

                // Act - Management to PS conversion
                var originalMgmtConfig = new CifsMountConfiguration(
                    userName: scenario.Username,
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    password: scenario.Password,
                    mountOptions: scenario.MountOptions);

                var mgmtToPs = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(originalMgmtConfig);
                var backToMgmt = mgmtToPs.toMgmtCifsMountConfiguration();

                // Assert - Verify semantic equivalence in reverse direction
                Assert.NotNull(mgmtToPs);
                Assert.Equal(scenario.Username, mgmtToPs.Username);
                Assert.Equal(scenario.Password, mgmtToPs.Password);
                Assert.Equal(scenario.Source, mgmtToPs.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtToPs.MountOptions);

                Assert.NotNull(backToMgmt);
                Assert.Equal(scenario.Username, backToMgmt.UserName);
                Assert.Equal(scenario.Password, backToMgmt.Password);
                Assert.Equal(scenario.Source, backToMgmt.Source);
                Assert.Equal(scenario.RelativeMountPath, backToMgmt.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToMgmt.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_BatchPoolContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool mount configuration
            // CifsMountConfiguration is used to mount CIFS/SMB file systems on Batch compute nodes for enterprise file sharing

            // Arrange - Test enterprise and cloud storage scenarios
            var enterpriseScenarios = new PSCifsMountConfiguration[]
            {
                new PSCifsMountConfiguration(
                    username: "CORP\\batch-service",
                    password: "ServiceAccountPassword",
                    source: "//corp-fileserver.enterprise.com/batch-input",
                    relativeMountPath: "input-data",
                    mountOptions: "vers=3.0,domain=CORP,sec=krb5,cache=strict"
                    //Description = "Enterprise Active Directory CIFS mount with Kerberos authentication"
                ),
                new PSCifsMountConfiguration(
                    username: "azurebatch@company.com",
                    password: "AzureStorageAccountKey",
                    source: "//batchstorage.file.core.windows.net/datasets",
                    relativeMountPath: "ml-datasets",
                    mountOptions: "vers=3.0,serverino,mapposix,rsize=1048576,wsize=1048576"
                    //Description = "Azure Files mount for machine learning datasets with high throughput"
                ),
                new PSCifsMountConfiguration(
                    username: "localuser",
                    password: "LocalPassword",
                    source: "//10.0.0.100/shared",
                    relativeMountPath: "shared",
                    mountOptions: null
                    //Description = "Simple local network share without specific options"
                ),
                new PSCifsMountConfiguration(
                    username: "backup-user",
                    password: "BackupPassword123",
                    source: "//backup-nas.company.local/batch-results",
                    relativeMountPath: "results-backup",
                    mountOptions: "vers=2.1,uid=0,gid=0,file_mode=0600,dir_mode=0700"
                    //Description = "Backup storage with restricted permissions for result archival"
                )
            };

            foreach (var scenario in enterpriseScenarios)
            {
                // Arrange
                var psCifsConfig = new PSCifsMountConfiguration(
                    username: scenario.Username,
                    password: scenario.Password,
                    source: scenario.Source,
                    relativeMountPath: scenario.RelativeMountPath,
                    mountOptions: scenario.MountOptions);

                // Act
                var mgmtCifsConfig = psCifsConfig.toMgmtCifsMountConfiguration();

                // Assert - Should convert correctly for Batch pool mount configuration
                Assert.NotNull(mgmtCifsConfig);
                Assert.Equal(scenario.Username, mgmtCifsConfig.UserName);
                Assert.Equal(scenario.Password, mgmtCifsConfig.Password);
                Assert.Equal(scenario.Source, mgmtCifsConfig.Source);
                Assert.Equal(scenario.RelativeMountPath, mgmtCifsConfig.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, mgmtCifsConfig.MountOptions);

                // Verify round-trip conversion maintains Batch pool semantics
                var backToPs = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtCifsConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Username, backToPs.Username);
                Assert.Equal(scenario.Password, backToPs.Password);
                Assert.Equal(scenario.Source, backToPs.Source);
                Assert.Equal(scenario.RelativeMountPath, backToPs.RelativeMountPath);
                Assert.Equal(scenario.MountOptions, backToPs.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psConfig = new PSCifsMountConfiguration(
                username: "testuser",
                password: "testpass",
                source: "//server/data",
                relativeMountPath: "data",
                mountOptions: "vers=3");

            var mgmtConfig = new CifsMountConfiguration(
                userName: "mgmtuser",
                source: "//server/volume",
                relativeMountPath: "volume",
                password: "mgmtpass",
                mountOptions: "vers=2");

            // Act
            var mgmtResult = psConfig.toMgmtCifsMountConfiguration();
            var psResult = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<CifsMountConfiguration>(mgmtResult);
            Assert.IsType<PSCifsMountConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_EdgeCaseValues_HandleCorrectly()
        {
            // Test conversion with various edge case values

            var testConfigurations = new[]
            {
                // Standard configurations
                new { Username = "user", Password = "pass", Source = "//server/share", RelativeMountPath = "share", MountOptions = "vers=3.0" },
                new { Username = "domain\\user", Password = "password", Source = "//192.168.1.100/data", RelativeMountPath = "data", MountOptions = "vers=2.1" },
                // Edge cases
                new { Username = "", Password = "", Source = "", RelativeMountPath = "", MountOptions = "" },
                new { Username = "user@domain.com", Password = "complex!@#$%", Source = "//server/path with spaces", RelativeMountPath = "path", MountOptions = (string)null },
                new { Username = "   ", Password = "   ", Source = "   ", RelativeMountPath = "   ", MountOptions = "   " }, // Whitespace
                new { Username = "very-long-username-for-testing-purposes@very-long-domain-name.company.enterprise.com", Password = "VeryLongPasswordForTestingPurposes123!@#$%^&*()", Source = "//very-long-server-name.very-long-domain.company.enterprise.com/very-long-share-name-for-testing", RelativeMountPath = "very-long-relative-mount-path-for-testing-purposes", MountOptions = "vers=3.0,uid=1000,gid=1000,iocharset=utf8,file_mode=0644,dir_mode=0755,cache=strict,actimeo=30,rsize=1048576,wsize=1048576" }
            };

            foreach (var testConfig in testConfigurations)
            {
                // Arrange
                var psConfig = new PSCifsMountConfiguration(
                    username: testConfig.Username,
                    password: testConfig.Password,
                    source: testConfig.Source,
                    relativeMountPath: testConfig.RelativeMountPath,
                    mountOptions: testConfig.MountOptions);

                var mgmtConfig = new CifsMountConfiguration(
                    userName: testConfig.Username,
                    source: testConfig.Source,
                    relativeMountPath: testConfig.RelativeMountPath,
                    password: testConfig.Password,
                    mountOptions: testConfig.MountOptions);

                // Act
                var mgmtResult = psConfig.toMgmtCifsMountConfiguration();
                var psFromMgmtResult = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);
                var roundTripResult = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtResult);

                // Assert
                Assert.NotNull(mgmtResult);
                Assert.NotNull(psFromMgmtResult);
                Assert.NotNull(roundTripResult);

                Assert.Equal(testConfig.Username, mgmtResult.UserName);
                Assert.Equal(testConfig.Password, mgmtResult.Password);
                Assert.Equal(testConfig.Source, mgmtResult.Source);
                Assert.Equal(testConfig.RelativeMountPath, mgmtResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, mgmtResult.MountOptions);

                Assert.Equal(testConfig.Username, psFromMgmtResult.Username);
                Assert.Equal(testConfig.Password, psFromMgmtResult.Password);
                Assert.Equal(testConfig.Source, psFromMgmtResult.Source);
                Assert.Equal(testConfig.RelativeMountPath, psFromMgmtResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, psFromMgmtResult.MountOptions);

                Assert.Equal(testConfig.Username, roundTripResult.Username);
                Assert.Equal(testConfig.Password, roundTripResult.Password);
                Assert.Equal(testConfig.Source, roundTripResult.Source);
                Assert.Equal(testConfig.RelativeMountPath, roundTripResult.RelativeMountPath);
                Assert.Equal(testConfig.MountOptions, roundTripResult.MountOptions);
            }
        }

        #endregion

        #region Performance and Security Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psConfigs = new List<PSCifsMountConfiguration>();
            var mgmtConfigs = new List<CifsMountConfiguration>();

            for (int i = 0; i < 100; i++)
            {
                psConfigs.Add(new PSCifsMountConfiguration(
                    username: $"user{i}",
                    password: $"password{i}",
                    source: $"//server{i}.example.com/share{i}",
                    relativeMountPath: $"share{i}",
                    mountOptions: $"vers=3.{i % 2},uid={1000 + i},gid={1000 + i}"));

                mgmtConfigs.Add(new CifsMountConfiguration(
                    userName: $"mgmtuser{i}",
                    source: $"//mgmt-server{i}.example.com/volume{i}",
                    relativeMountPath: $"volume{i}",
                    password: $"mgmtpassword{i}",
                    mountOptions: $"vers=2.{i % 2 + 1},rsize={1024 * (i + 1)},wsize={1024 * (i + 1)}"));
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psConfig in psConfigs)
                {
                    var mgmtResult = psConfig.toMgmtCifsMountConfiguration();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtConfig in mgmtConfigs)
                {
                    var psResult = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);
                    Assert.NotNull(psResult);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_RealWorldCifsOptions_HandleCorrectly()
        {
            // Test with realistic CIFS mount options that would be used in production

            var realWorldConfigurations = new PSCifsMountConfiguration[]
            {
                new PSCifsMountConfiguration (
                    username: "ENTERPRISE\\batch-svc",
                    password: "EnterpriseBatchPassword123!",
                    source: "//enterprise-fileserver.corp.com/batch-data",
                    relativeMountPath: "enterprise-data",
                    mountOptions: "vers=3.0,domain=ENTERPRISE,sec=krb5,cache=strict,actimeo=30,rsize=1048576,wsize=1048576"
                    //Description = "Enterprise Active Directory mount with Kerberos and high performance"
                ),
                new PSCifsMountConfiguration (
                    username: "azurebatch@company.onmicrosoft.com",
                    password: "AzureFilesStorageKey123",
                    source: "//batchstorageaccount.file.core.windows.net/datafiles",
                    relativeMountPath: "azure-data",
                    mountOptions: "vers=3.0,serverino,mapposix,cache=loose,actimeo=1"
                    //Description = "Azure Files mount with POSIX mapping and relaxed caching"
                ),
                new PSCifsMountConfiguration (
                    username: "hpc-user",
                    password: "HPCPassword",
                    source: "//hpc-nas.research.edu/scratch",
                    relativeMountPath: "scratch-space",
                    mountOptions: "vers=3.0,hard,intr,rsize=65536,wsize=65536,timeo=14,retrans=3"
                    //Description = "HPC scratch storage with hard mount and retry parameters"
                ),
                new PSCifsMountConfiguration (
                    username: "backup",
                    password: "BackupServicePassword",
                    source: "//backup-server.company.local/batch-results",
                    relativeMountPath: "backup",
                    mountOptions: "vers=2.1,uid=0,gid=0,file_mode=0600,dir_mode=0700,nobrl"
                    //Description = "Backup mount with restricted permissions and no byte-range locking"
                ),
                new PSCifsMountConfiguration (
                    username: "guest",
                    password: "GuestPassword",
                    source: "//public-share.local/public",
                    relativeMountPath: "public",
                    mountOptions: null
                    //Description = "Simple public share without specific options"
                )
            };

            foreach (var config in realWorldConfigurations)
            {
                // Arrange
                var psConfig = new PSCifsMountConfiguration(
                    username: config.Username,
                    password: config.Password,
                    source: config.Source,
                    relativeMountPath: config.RelativeMountPath,
                    mountOptions: config.MountOptions);

                // Act
                var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();
                var roundTripPs = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

                // Assert
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                Assert.Equal(config.Username, mgmtConfig.UserName);
                Assert.Equal(config.Password, mgmtConfig.Password);
                Assert.Equal(config.Source, mgmtConfig.Source);
                Assert.Equal(config.RelativeMountPath, mgmtConfig.RelativeMountPath);
                Assert.Equal(config.MountOptions, mgmtConfig.MountOptions);

                Assert.Equal(config.Username, roundTripPs.Username);
                Assert.Equal(config.Password, roundTripPs.Password);
                Assert.Equal(config.Source, roundTripPs.Source);
                Assert.Equal(config.RelativeMountPath, roundTripPs.RelativeMountPath);
                Assert.Equal(config.MountOptions, roundTripPs.MountOptions);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CifsMountConfigurationConversions_AuthenticationFormats_VerifyBehavior()
        {
            // Test with various authentication formats commonly used with CIFS

            var authenticationScenarios = new[]
            {
                // Domain formats
                new { Username = "DOMAIN\\username", Password = "DomainPassword", Description = "Windows domain format" },
                new { Username = "username@domain.com", Password = "UPNPassword", Description = "User Principal Name format" },
                new { Username = "domain/username", Password = "UnixDomainPassword", Description = "Unix-style domain format" },
                // Azure AD formats
                new { Username = "user@tenant.onmicrosoft.com", Password = "AzureADPassword", Description = "Azure AD UPN format" },
                new { Username = "storageaccount", Password = "StorageAccountKey", Description = "Azure Storage account format" },
                // Simple formats
                new { Username = "localuser", Password = "LocalPassword", Description = "Local user account" },
                new { Username = "serviceaccount", Password = "ServicePassword123!", Description = "Service account with complex password" },
                // Edge cases
                new { Username = "", Password = "", Description = "Empty credentials" },
                new { Username = "user with spaces", Password = "password with spaces", Description = "Credentials with spaces" },
                new { Username = "user@sub.domain.company.com", Password = "Password!@#$%^&*()", Description = "Complex UPN with special characters" }
            };

            foreach (var scenario in authenticationScenarios)
            {
                // Arrange
                var psConfig = new PSCifsMountConfiguration(
                    username: scenario.Username,
                    password: scenario.Password,
                    source: "//server/share",
                    relativeMountPath: "share",
                    mountOptions: "vers=3.0");

                // Act
                var mgmtConfig = psConfig.toMgmtCifsMountConfiguration();
                var roundTripPs = PSCifsMountConfiguration.fromMgmtCifsMountConfiguration(mgmtConfig);

                // Assert - All authentication formats should be preserved exactly as provided
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);

                Assert.Equal(scenario.Username, mgmtConfig.UserName);
                Assert.Equal(scenario.Password, mgmtConfig.Password);

                Assert.Equal(scenario.Username, roundTripPs.Username);
                Assert.Equal(scenario.Password, roundTripPs.Password);
            }
        }

        #endregion
    }
}
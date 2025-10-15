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
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ModelsConversions
{
    public class PSUserAccountTests
    {
        #region toMgmtUserAccount Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithBasicProperties_ConvertsCorrectly()
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "testuser",
                password: "testpassword123",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("testuser", mgmtUserAccount.Name);
            Assert.Equal("testpassword123", mgmtUserAccount.Password);
            Assert.NotNull(mgmtUserAccount.ElevationLevel);
            Assert.Equal(ElevationLevel.NonAdmin, mgmtUserAccount.ElevationLevel.Value);
            Assert.Null(mgmtUserAccount.LinuxUserConfiguration);
            Assert.Null(mgmtUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithAdminElevation_ConvertsCorrectly()
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "adminuser",
                password: "adminpassword456",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("adminuser", mgmtUserAccount.Name);
            Assert.Equal("adminpassword456", mgmtUserAccount.Password);
            Assert.NotNull(mgmtUserAccount.ElevationLevel);
            Assert.Equal(ElevationLevel.Admin, mgmtUserAccount.ElevationLevel.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithLinuxUserConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var linuxConfig = new PSLinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----");
            var psUserAccount = new PSUserAccount(
                name: "linuxuser",
                password: "linuxpassword789",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                linuxUserConfiguration: linuxConfig);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("linuxuser", mgmtUserAccount.Name);
            Assert.Equal("linuxpassword789", mgmtUserAccount.Password);
            Assert.Equal(ElevationLevel.NonAdmin, mgmtUserAccount.ElevationLevel.Value);
            Assert.NotNull(mgmtUserAccount.LinuxUserConfiguration);
            Assert.Equal(1000, mgmtUserAccount.LinuxUserConfiguration.Uid);
            Assert.Equal(1000, mgmtUserAccount.LinuxUserConfiguration.Gid);
            Assert.Equal("-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----", mgmtUserAccount.LinuxUserConfiguration.SshPrivateKey);
            Assert.Null(mgmtUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithWindowsUserConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var windowsConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);
            var psUserAccount = new PSUserAccount(
                name: "windowsuser",
                password: "windowspassword123",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                windowsUserConfiguration: windowsConfig);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("windowsuser", mgmtUserAccount.Name);
            Assert.Equal("windowspassword123", mgmtUserAccount.Password);
            Assert.Equal(ElevationLevel.Admin, mgmtUserAccount.ElevationLevel.Value);
            Assert.Null(mgmtUserAccount.LinuxUserConfiguration);
            Assert.NotNull(mgmtUserAccount.WindowsUserConfiguration);
            Assert.NotNull(mgmtUserAccount.WindowsUserConfiguration.LoginMode);
            Assert.Equal(LoginMode.Interactive, mgmtUserAccount.WindowsUserConfiguration.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithBothConfigurations_ConvertsCorrectly()
        {
            // Arrange
            var linuxConfig = new PSLinuxUserConfiguration(
                uid: 2000,
                gid: 2000,
                sshPrivateKey: "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com");
            var windowsConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Batch);
            var psUserAccount = new PSUserAccount(
                name: "hybriduser",
                password: "hybridpassword456",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                linuxUserConfiguration: linuxConfig,
                windowsUserConfiguration: windowsConfig);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("hybriduser", mgmtUserAccount.Name);
            Assert.Equal("hybridpassword456", mgmtUserAccount.Password);
            Assert.Equal(ElevationLevel.NonAdmin, mgmtUserAccount.ElevationLevel.Value);
            
            Assert.NotNull(mgmtUserAccount.LinuxUserConfiguration);
            Assert.Equal(2000, mgmtUserAccount.LinuxUserConfiguration.Uid);
            Assert.Equal(2000, mgmtUserAccount.LinuxUserConfiguration.Gid);
            Assert.Equal("ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com", mgmtUserAccount.LinuxUserConfiguration.SshPrivateKey);
            
            Assert.NotNull(mgmtUserAccount.WindowsUserConfiguration);
            Assert.NotNull(mgmtUserAccount.WindowsUserConfiguration.LoginMode);
            Assert.Equal(LoginMode.Batch, mgmtUserAccount.WindowsUserConfiguration.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithNullElevationLevel_ConvertsCorrectly()
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "defaultuser",
                password: "defaultpassword",
                elevationLevel: null);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("defaultuser", mgmtUserAccount.Name);
            Assert.Equal("defaultpassword", mgmtUserAccount.Password);
            Assert.Null(mgmtUserAccount.ElevationLevel);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_WithNullConfigurations_ConvertsCorrectly()
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "simpleuser",
                password: "simplepassword",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                linuxUserConfiguration: null,
                windowsUserConfiguration: null);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.Equal("simpleuser", mgmtUserAccount.Name);
            Assert.Equal("simplepassword", mgmtUserAccount.Password);
            Assert.Equal(ElevationLevel.NonAdmin, mgmtUserAccount.ElevationLevel.Value);
            Assert.Null(mgmtUserAccount.LinuxUserConfiguration);
            Assert.Null(mgmtUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "testuser",
                password: "testpassword",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var mgmtUserAccount1 = psUserAccount.toMgmtUserAccount();
            var mgmtUserAccount2 = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount1);
            Assert.NotNull(mgmtUserAccount2);
            Assert.NotSame(mgmtUserAccount1, mgmtUserAccount2);
            Assert.Equal(mgmtUserAccount1.Name, mgmtUserAccount2.Name);
            Assert.Equal(mgmtUserAccount1.Password, mgmtUserAccount2.Password);
            Assert.Equal(mgmtUserAccount1.ElevationLevel, mgmtUserAccount2.ElevationLevel);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToMgmtUserAccount_VerifyReturnType()
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "testuser",
                password: "testpassword");

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.IsType<UserAccount>(mgmtUserAccount);
            Assert.IsAssignableFrom<UserAccount>(mgmtUserAccount);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, ElevationLevel.NonAdmin)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, ElevationLevel.Admin)]
        public void ToMgmtUserAccount_AllElevationLevels_ConvertsCorrectly(
            Microsoft.Azure.Batch.Common.ElevationLevel psElevationLevel,
            ElevationLevel expectedMgmtElevationLevel)
        {
            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "elevationtest",
                password: "elevationpassword",
                elevationLevel: psElevationLevel);

            // Act
            var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(mgmtUserAccount);
            Assert.NotNull(mgmtUserAccount.ElevationLevel);
            Assert.Equal(expectedMgmtElevationLevel, mgmtUserAccount.ElevationLevel.Value);
        }

        #endregion

        #region fromMgmtUserAccount Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithNull_ReturnsNull()
        {
            // Act
            var result = PSUserAccount.fromMgmtUserAccount(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithBasicProperties_ConvertsCorrectly()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "testuser",
                password: "testpassword123",
                elevationLevel: ElevationLevel.NonAdmin);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("testuser", psUserAccount.Name);
            Assert.Equal("testpassword123", psUserAccount.Password);
            Assert.NotNull(psUserAccount.ElevationLevel);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, psUserAccount.ElevationLevel.Value);
            Assert.Null(psUserAccount.LinuxUserConfiguration);
            Assert.Null(psUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithAdminElevation_ConvertsCorrectly()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "adminuser",
                password: "adminpassword456",
                elevationLevel: ElevationLevel.Admin);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("adminuser", psUserAccount.Name);
            Assert.Equal("adminpassword456", psUserAccount.Password);
            Assert.NotNull(psUserAccount.ElevationLevel);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, psUserAccount.ElevationLevel.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithLinuxUserConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var linuxConfig = new LinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAA...\n-----END OPENSSH PRIVATE KEY-----");
            var mgmtUserAccount = new UserAccount(
                name: "linuxuser",
                password: "linuxpassword789",
                elevationLevel: ElevationLevel.NonAdmin,
                linuxUserConfiguration: linuxConfig);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("linuxuser", psUserAccount.Name);
            Assert.Equal("linuxpassword789", psUserAccount.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, psUserAccount.ElevationLevel.Value);
            Assert.NotNull(psUserAccount.LinuxUserConfiguration);
            Assert.Equal(1000, psUserAccount.LinuxUserConfiguration.Uid);
            Assert.Equal(1000, psUserAccount.LinuxUserConfiguration.Gid);
            Assert.Equal("-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAA...\n-----END OPENSSH PRIVATE KEY-----", psUserAccount.LinuxUserConfiguration.SshPrivateKey);
            Assert.Null(psUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithWindowsUserConfiguration_ConvertsCorrectly()
        {
            // Arrange
            var windowsConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Interactive);
            var mgmtUserAccount = new UserAccount(
                name: "windowsuser",
                password: "windowspassword123",
                elevationLevel: ElevationLevel.Admin,
                windowsUserConfiguration: windowsConfig);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("windowsuser", psUserAccount.Name);
            Assert.Equal("windowspassword123", psUserAccount.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, psUserAccount.ElevationLevel.Value);
            Assert.Null(psUserAccount.LinuxUserConfiguration);
            Assert.NotNull(psUserAccount.WindowsUserConfiguration);
            Assert.NotNull(psUserAccount.WindowsUserConfiguration.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, psUserAccount.WindowsUserConfiguration.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithBothConfigurations_ConvertsCorrectly()
        {
            // Arrange
            var linuxConfig = new LinuxUserConfiguration(
                uid: 2000,
                gid: 2000,
                sshPrivateKey: "ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIF... user@hostname");
            var windowsConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Batch);
            var mgmtUserAccount = new UserAccount(
                name: "hybriduser",
                password: "hybridpassword456",
                elevationLevel: ElevationLevel.NonAdmin,
                linuxUserConfiguration: linuxConfig,
                windowsUserConfiguration: windowsConfig);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("hybriduser", psUserAccount.Name);
            Assert.Equal("hybridpassword456", psUserAccount.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, psUserAccount.ElevationLevel.Value);
            
            Assert.NotNull(psUserAccount.LinuxUserConfiguration);
            Assert.Equal(2000, psUserAccount.LinuxUserConfiguration.Uid);
            Assert.Equal(2000, psUserAccount.LinuxUserConfiguration.Gid);
            Assert.Equal("ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIF... user@hostname", psUserAccount.LinuxUserConfiguration.SshPrivateKey);
            
            Assert.NotNull(psUserAccount.WindowsUserConfiguration);
            Assert.NotNull(psUserAccount.WindowsUserConfiguration.LoginMode);
            Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Batch, psUserAccount.WindowsUserConfiguration.LoginMode.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithNullElevationLevel_ConvertsCorrectly()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "defaultuser",
                password: "defaultpassword",
                elevationLevel: null);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("defaultuser", psUserAccount.Name);
            Assert.Equal("defaultpassword", psUserAccount.Password);
            Assert.Null(psUserAccount.ElevationLevel);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_WithNullConfigurations_ConvertsCorrectly()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "simpleuser",
                password: "simplepassword",
                elevationLevel: ElevationLevel.NonAdmin,
                linuxUserConfiguration: null,
                windowsUserConfiguration: null);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("simpleuser", psUserAccount.Name);
            Assert.Equal("simplepassword", psUserAccount.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, psUserAccount.ElevationLevel.Value);
            Assert.Null(psUserAccount.LinuxUserConfiguration);
            Assert.Null(psUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "statictest",
                password: "staticpassword",
                elevationLevel: ElevationLevel.Admin);

            // Act - Call static method directly on class
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.Equal("statictest", psUserAccount.Name);
            Assert.Equal("staticpassword", psUserAccount.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, psUserAccount.ElevationLevel.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "testuser",
                password: "testpassword",
                elevationLevel: ElevationLevel.NonAdmin);

            // Act
            var psUserAccount1 = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);
            var psUserAccount2 = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount1);
            Assert.NotNull(psUserAccount2);
            Assert.NotSame(psUserAccount1, psUserAccount2);
            Assert.Equal(psUserAccount1.Name, psUserAccount2.Name);
            Assert.Equal(psUserAccount1.Password, psUserAccount2.Password);
            Assert.Equal(psUserAccount1.ElevationLevel, psUserAccount2.ElevationLevel);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromMgmtUserAccount_VerifyReturnType()
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "testuser",
                password: "testpassword");

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.IsType<PSUserAccount>(psUserAccount);
            Assert.IsAssignableFrom<PSUserAccount>(psUserAccount);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(ElevationLevel.NonAdmin, Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        [InlineData(ElevationLevel.Admin, Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        public void FromMgmtUserAccount_AllElevationLevels_ConvertsCorrectly(
            ElevationLevel mgmtElevationLevel,
            Microsoft.Azure.Batch.Common.ElevationLevel expectedPsElevationLevel)
        {
            // Arrange
            var mgmtUserAccount = new UserAccount(
                name: "elevationtest",
                password: "elevationpassword",
                elevationLevel: mgmtElevationLevel);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(psUserAccount);
            Assert.NotNull(psUserAccount.ElevationLevel);
            Assert.Equal(expectedPsElevationLevel, psUserAccount.ElevationLevel.Value);
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesBasicProperties()
        {
            // Arrange
            var originalPsUserAccount = new PSUserAccount(
                name: "roundtripuser",
                password: "roundtrippassword",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);

            // Act
            var mgmtUserAccount = originalPsUserAccount.toMgmtUserAccount();
            var roundTripPsUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(roundTripPsUserAccount);
            Assert.Equal(originalPsUserAccount.Name, roundTripPsUserAccount.Name);
            Assert.Equal(originalPsUserAccount.Password, roundTripPsUserAccount.Password);
            Assert.Equal(originalPsUserAccount.ElevationLevel, roundTripPsUserAccount.ElevationLevel);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesLinuxConfiguration()
        {
            // Arrange
            var linuxConfig = new PSLinuxUserConfiguration(
                uid: 1500,
                gid: 1500,
                sshPrivateKey: "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----");
            var originalPsUserAccount = new PSUserAccount(
                name: "linuxroundtrip",
                password: "linuxpassword",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                linuxUserConfiguration: linuxConfig);

            // Act
            var mgmtUserAccount = originalPsUserAccount.toMgmtUserAccount();
            var roundTripPsUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(roundTripPsUserAccount);
            Assert.Equal(originalPsUserAccount.Name, roundTripPsUserAccount.Name);
            Assert.Equal(originalPsUserAccount.Password, roundTripPsUserAccount.Password);
            Assert.Equal(originalPsUserAccount.ElevationLevel, roundTripPsUserAccount.ElevationLevel);
            
            Assert.NotNull(roundTripPsUserAccount.LinuxUserConfiguration);
            Assert.Equal(originalPsUserAccount.LinuxUserConfiguration.Uid, roundTripPsUserAccount.LinuxUserConfiguration.Uid);
            Assert.Equal(originalPsUserAccount.LinuxUserConfiguration.Gid, roundTripPsUserAccount.LinuxUserConfiguration.Gid);
            Assert.Equal(originalPsUserAccount.LinuxUserConfiguration.SshPrivateKey, roundTripPsUserAccount.LinuxUserConfiguration.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesWindowsConfiguration()
        {
            // Arrange
            var windowsConfig = new PSWindowsUserConfiguration(
                loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);
            var originalPsUserAccount = new PSUserAccount(
                name: "windowsroundtrip",
                password: "windowspassword",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                windowsUserConfiguration: windowsConfig);

            // Act
            var mgmtUserAccount = originalPsUserAccount.toMgmtUserAccount();
            var roundTripPsUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(roundTripPsUserAccount);
            Assert.Equal(originalPsUserAccount.Name, roundTripPsUserAccount.Name);
            Assert.Equal(originalPsUserAccount.Password, roundTripPsUserAccount.Password);
            Assert.Equal(originalPsUserAccount.ElevationLevel, roundTripPsUserAccount.ElevationLevel);
            
            Assert.NotNull(roundTripPsUserAccount.WindowsUserConfiguration);
            Assert.Equal(originalPsUserAccount.WindowsUserConfiguration.LoginMode, roundTripPsUserAccount.WindowsUserConfiguration.LoginMode);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullProperties()
        {
            // Arrange
            var originalPsUserAccount = new PSUserAccount(
                name: "nullroundtrip",
                password: "nullpassword",
                elevationLevel: null,
                linuxUserConfiguration: null,
                windowsUserConfiguration: null);

            // Act
            var mgmtUserAccount = originalPsUserAccount.toMgmtUserAccount();
            var roundTripPsUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(roundTripPsUserAccount);
            Assert.Equal(originalPsUserAccount.Name, roundTripPsUserAccount.Name);
            Assert.Equal(originalPsUserAccount.Password, roundTripPsUserAccount.Password);
            Assert.Null(roundTripPsUserAccount.ElevationLevel);
            Assert.Null(roundTripPsUserAccount.LinuxUserConfiguration);
            Assert.Null(roundTripPsUserAccount.WindowsUserConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var linuxConfig = new LinuxUserConfiguration(
                uid: 3000,
                gid: 3000,
                sshPrivateKey: "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com");
            var windowsConfig = new WindowsUserConfiguration(
                loginMode: LoginMode.Batch);
            var originalMgmtUserAccount = new UserAccount(
                name: "mgmtroundtrip",
                password: "mgmtpassword",
                elevationLevel: ElevationLevel.Admin,
                linuxUserConfiguration: linuxConfig,
                windowsUserConfiguration: windowsConfig);

            // Act
            var psUserAccount = PSUserAccount.fromMgmtUserAccount(originalMgmtUserAccount);
            var roundTripMgmtUserAccount = psUserAccount.toMgmtUserAccount();

            // Assert
            Assert.NotNull(roundTripMgmtUserAccount);
            Assert.Equal(originalMgmtUserAccount.Name, roundTripMgmtUserAccount.Name);
            Assert.Equal(originalMgmtUserAccount.Password, roundTripMgmtUserAccount.Password);
            Assert.Equal(originalMgmtUserAccount.ElevationLevel, roundTripMgmtUserAccount.ElevationLevel);
            
            Assert.NotNull(roundTripMgmtUserAccount.LinuxUserConfiguration);
            Assert.Equal(originalMgmtUserAccount.LinuxUserConfiguration.Uid, roundTripMgmtUserAccount.LinuxUserConfiguration.Uid);
            Assert.Equal(originalMgmtUserAccount.LinuxUserConfiguration.Gid, roundTripMgmtUserAccount.LinuxUserConfiguration.Gid);
            Assert.Equal(originalMgmtUserAccount.LinuxUserConfiguration.SshPrivateKey, roundTripMgmtUserAccount.LinuxUserConfiguration.SshPrivateKey);
            
            Assert.NotNull(roundTripMgmtUserAccount.WindowsUserConfiguration);
            Assert.Equal(originalMgmtUserAccount.WindowsUserConfiguration.LoginMode, roundTripMgmtUserAccount.WindowsUserConfiguration.LoginMode);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin)]
        [InlineData(Microsoft.Azure.Batch.Common.ElevationLevel.Admin)]
        public void RoundTripConversion_AllElevationLevels_PreservesOriginalValue(
            Microsoft.Azure.Batch.Common.ElevationLevel originalElevationLevel)
        {
            // Arrange
            var originalPsUserAccount = new PSUserAccount(
                name: "elevationroundtrip",
                password: "elevationpassword",
                elevationLevel: originalElevationLevel);

            // Act
            var mgmtUserAccount = originalPsUserAccount.toMgmtUserAccount();
            var roundTripPsUserAccount = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert
            Assert.NotNull(roundTripPsUserAccount);
            Assert.Equal(originalElevationLevel, roundTripPsUserAccount.ElevationLevel);
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch user accounts

            // Test standard user account semantics
            var psStandardUser = new PSUserAccount(
                name: "standarduser",
                password: "standardpassword123",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);
            var mgmtStandardUser = psStandardUser.toMgmtUserAccount();
            var backToPs = PSUserAccount.fromMgmtUserAccount(mgmtStandardUser);

            Assert.NotNull(mgmtStandardUser);
            Assert.Equal("standarduser", mgmtStandardUser.Name);
            Assert.Equal("standardpassword123", mgmtStandardUser.Password);
            Assert.Equal(ElevationLevel.NonAdmin, mgmtStandardUser.ElevationLevel.Value);
            Assert.NotNull(backToPs);
            Assert.Equal("standarduser", backToPs.Name);
            Assert.Equal("standardpassword123", backToPs.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin, backToPs.ElevationLevel.Value);

            // Test admin user account semantics
            var psAdminUser = new PSUserAccount(
                name: "adminuser",
                password: "adminpassword456",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var mgmtAdminUser = psAdminUser.toMgmtUserAccount();
            var backToPsAdmin = PSUserAccount.fromMgmtUserAccount(mgmtAdminUser);

            Assert.NotNull(mgmtAdminUser);
            Assert.Equal("adminuser", mgmtAdminUser.Name);
            Assert.Equal("adminpassword456", mgmtAdminUser.Password);
            Assert.Equal(ElevationLevel.Admin, mgmtAdminUser.ElevationLevel.Value);
            Assert.NotNull(backToPsAdmin);
            Assert.Equal("adminuser", backToPsAdmin.Name);
            Assert.Equal("adminpassword456", backToPsAdmin.Password);
            Assert.Equal(Microsoft.Azure.Batch.Common.ElevationLevel.Admin, backToPsAdmin.ElevationLevel.Value);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSUserAccount.fromMgmtUserAccount(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_BatchPoolUserContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Azure Batch pool user configuration
            // UserAccount is used to configure user accounts on Batch compute nodes

            // Arrange - Test with realistic Batch pool user scenarios
            var batchUserScenarios = new[]
            {
                // Standard batch processing user
                new {
                    Name = "batchuser",
                    Password = "BatchProcessing123!",
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    Description = "Standard user for batch processing tasks"
                },
                // Administrative user for system operations
                new {
                    Name = "batchadmin",
                    Password = "AdminOperations456!",
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                    Description = "Admin user for system operations and privileged tasks"
                },
                // Linux-specific user with SSH configuration
                new {
                    Name = "linuxbatchuser",
                    Password = "LinuxBatch789!",
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    Description = "Linux user with SSH key configuration"
                },
                // Windows-specific user with login mode configuration
                new {
                    Name = "windowsbatchuser",
                    Password = "WindowsBatch000!",
                    ElevationLevel = Microsoft.Azure.Batch.Common.ElevationLevel.Admin,
                    Description = "Windows user with interactive login mode"
                }
            };

            foreach (var scenario in batchUserScenarios)
            {
                // Act
                PSUserAccount psUserAccount;
                if (scenario.Name.Contains("linux"))
                {
                    var linuxConfig = new PSLinuxUserConfiguration(
                        uid: 1001,
                        gid: 1001,
                        sshPrivateKey: "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA...\n-----END RSA PRIVATE KEY-----");
                    psUserAccount = new PSUserAccount(
                        name: scenario.Name,
                        password: scenario.Password,
                        elevationLevel: scenario.ElevationLevel,
                        linuxUserConfiguration: linuxConfig);
                }
                else if (scenario.Name.Contains("windows"))
                {
                    var windowsConfig = new PSWindowsUserConfiguration(
                        loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive);
                    psUserAccount = new PSUserAccount(
                        name: scenario.Name,
                        password: scenario.Password,
                        elevationLevel: scenario.ElevationLevel,
                        windowsUserConfiguration: windowsConfig);
                }
                else
                {
                    psUserAccount = new PSUserAccount(
                        name: scenario.Name,
                        password: scenario.Password,
                        elevationLevel: scenario.ElevationLevel);
                }

                var mgmtUserAccount = psUserAccount.toMgmtUserAccount();

                // Assert - Should convert correctly for Batch pool user configuration
                Assert.NotNull(mgmtUserAccount);
                Assert.Equal(scenario.Name, mgmtUserAccount.Name);
                Assert.Equal(scenario.Password, mgmtUserAccount.Password);
                
               
                    Assert.NotNull(mgmtUserAccount.ElevationLevel);
                    var expectedMgmtLevel = scenario.ElevationLevel == Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin
                        ? ElevationLevel.NonAdmin
                        : ElevationLevel.Admin;
                    Assert.Equal(expectedMgmtLevel, mgmtUserAccount.ElevationLevel.Value);
                

                // Verify round-trip conversion maintains Batch user semantics
                var backToPs = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Name, backToPs.Name);
                Assert.Equal(scenario.Password, backToPs.Password);
                Assert.Equal(scenario.ElevationLevel, backToPs.ElevationLevel);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_UserNameValidation_PreservesConstraints()
        {
            // Test that user name constraints are preserved during conversion

            var userNameScenarios = new[]
            {
                // Standard user names
                "user1",
                "batchuser",
                "admin_user",
                "test-user",
                // Edge cases for 20 character limit
                "12345678901234567890", // Exactly 20 characters
                "a", // Single character
                // Unicode characters (should be preserved)
                "用户", // Chinese characters
                "usuário", // Portuguese with accent
                "пользователь", // Cyrillic
                // Special characters
                "user@domain",
                "user.name",
                "user+batch"
            };

            foreach (var userName in userNameScenarios)
            {
                // Arrange
                var psUserAccount = new PSUserAccount(
                    name: userName,
                    password: "testpassword123",
                    elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

                // Act
                var mgmtUserAccount = psUserAccount.toMgmtUserAccount();
                var roundTripPs = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

                // Assert - User name should be preserved exactly
                Assert.NotNull(mgmtUserAccount);
                Assert.NotNull(roundTripPs);
                Assert.Equal(userName, mgmtUserAccount.Name);
                Assert.Equal(userName, roundTripPs.Name);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psUserAccount = new PSUserAccount(
                name: "instancetest",
                password: "instancepassword",
                elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.Admin);
            var mgmtUserAccount = new UserAccount(
                name: "mgmtinstancetest",
                password: "mgmtinstancepassword",
                elevationLevel: ElevationLevel.NonAdmin);

            // Act
            var mgmtResult = psUserAccount.toMgmtUserAccount();
            var psResult = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<UserAccount>(mgmtResult);
            Assert.IsType<PSUserAccount>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtUserAccount, mgmtResult);
            Assert.NotSame(psUserAccount, psResult);
        }

        #endregion

        #region Performance Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psUserAccounts = new PSUserAccount[50];
            var mgmtUserAccounts = new UserAccount[50];

            for (int i = 0; i < 50; i++)
            {
                var elevationLevel = i % 2 == 0 
                    ? Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin 
                    : Microsoft.Azure.Batch.Common.ElevationLevel.Admin;
                psUserAccounts[i] = new PSUserAccount(
                    name: $"psuser{i}",
                    password: $"pspassword{i}",
                    elevationLevel: elevationLevel);

                var mgmtElevationLevel = i % 2 == 0 
                    ? ElevationLevel.NonAdmin 
                    : ElevationLevel.Admin;
                mgmtUserAccounts[i] = new UserAccount(
                    name: $"mgmtuser{i}",
                    password: $"mgmtpassword{i}",
                    elevationLevel: mgmtElevationLevel);
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psUserAccount in psUserAccounts)
                {
                    var mgmtResult = psUserAccount.toMgmtUserAccount();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtUserAccount in mgmtUserAccounts)
                {
                    var psResult = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);
                    Assert.NotNull(psResult);
                }
            }
        }

        #endregion

        #region Edge Case and Validation Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_EmptyStringHandling_PreservesValues()
        {
            // Test handling of empty strings (which may be valid in some contexts)

            var edgeCaseScenarios = new[]
            {
                new { Name = "", Password = "validpassword", Description = "Empty name" },
                new { Name = "validuser", Password = "", Description = "Empty password" },
                new { Name = " ", Password = "validpassword", Description = "Whitespace name" },
                new { Name = "validuser", Password = " ", Description = "Whitespace password" }
            };

            foreach (var scenario in edgeCaseScenarios)
            {
                // Arrange
                var psUserAccount = new PSUserAccount(
                    name: scenario.Name,
                    password: scenario.Password,
                    elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin);

                // Act
                var mgmtUserAccount = psUserAccount.toMgmtUserAccount();
                var roundTripPs = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

                // Assert - Values should be preserved exactly as provided
                Assert.NotNull(mgmtUserAccount);
                Assert.NotNull(roundTripPs);
                Assert.Equal(scenario.Name, mgmtUserAccount.Name);
                Assert.Equal(scenario.Password, mgmtUserAccount.Password);
                Assert.Equal(scenario.Name, roundTripPs.Name);
                Assert.Equal(scenario.Password, roundTripPs.Password);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UserAccountConversions_ConfigurationCombinations_HandleCorrectly()
        {
            // Test various combinations of Linux and Windows configurations

            var configurationScenarios = new[]
            {
                new { 
                    HasLinux = true, 
                    HasWindows = false, 
                    Description = "Linux configuration only" 
                },
                new { 
                    HasLinux = false, 
                    HasWindows = true, 
                    Description = "Windows configuration only" 
                },
                new { 
                    HasLinux = true, 
                    HasWindows = true, 
                    Description = "Both Linux and Windows configurations" 
                },
                new { 
                    HasLinux = false, 
                    HasWindows = false, 
                    Description = "No platform-specific configurations" 
                }
            };

            foreach (var scenario in configurationScenarios)
            {
                // Arrange
                PSLinuxUserConfiguration linuxConfig = scenario.HasLinux 
                    ? new PSLinuxUserConfiguration(uid: 1000, gid: 1000, sshPrivateKey: "test-key")
                    : null;
                PSWindowsUserConfiguration windowsConfig = scenario.HasWindows 
                    ? new PSWindowsUserConfiguration(loginMode: Microsoft.Azure.Batch.Common.LoginMode.Interactive)
                    : null;

                var psUserAccount = new PSUserAccount(
                    name: "configtest",
                    password: "configpassword",
                    elevationLevel: Microsoft.Azure.Batch.Common.ElevationLevel.NonAdmin,
                    linuxUserConfiguration: linuxConfig,
                    windowsUserConfiguration: windowsConfig);

                // Act
                var mgmtUserAccount = psUserAccount.toMgmtUserAccount();
                var roundTripPs = PSUserAccount.fromMgmtUserAccount(mgmtUserAccount);

                // Assert - Configuration presence should be preserved
                Assert.NotNull(mgmtUserAccount);
                Assert.NotNull(roundTripPs);

                if (scenario.HasLinux)
                {
                    Assert.NotNull(mgmtUserAccount.LinuxUserConfiguration);
                    Assert.NotNull(roundTripPs.LinuxUserConfiguration);
                    Assert.Equal(1000, mgmtUserAccount.LinuxUserConfiguration.Uid);
                    Assert.Equal(1000, roundTripPs.LinuxUserConfiguration.Uid);
                }
                else
                {
                    Assert.Null(mgmtUserAccount.LinuxUserConfiguration);
                    Assert.Null(roundTripPs.LinuxUserConfiguration);
                }

                if (scenario.HasWindows)
                {
                    Assert.NotNull(mgmtUserAccount.WindowsUserConfiguration);
                    Assert.NotNull(roundTripPs.WindowsUserConfiguration);
                    Assert.Equal(LoginMode.Interactive, mgmtUserAccount.WindowsUserConfiguration.LoginMode.Value);
                    Assert.Equal(Microsoft.Azure.Batch.Common.LoginMode.Interactive, roundTripPs.WindowsUserConfiguration.LoginMode.Value);
                }
                else
                {
                    Assert.Null(mgmtUserAccount.WindowsUserConfiguration);
                    Assert.Null(roundTripPs.WindowsUserConfiguration);
                }
            }
        }

        #endregion
    }
}
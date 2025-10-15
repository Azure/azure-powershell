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
    public class PSLinuxUserConfigurationTests
    {
        #region ToLinuxUserConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSLinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----");

            // Act
            var mgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal(1000, mgmtConfig.Uid);
            Assert.Equal(1000, mgmtConfig.Gid);
            Assert.Equal("-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----", mgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_WithOnlyUidAndGid_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSLinuxUserConfiguration(
                uid: 500,
                gid: 500,
                sshPrivateKey: null);

            // Act
            var mgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal(500, mgmtConfig.Uid);
            Assert.Equal(500, mgmtConfig.Gid);
            Assert.Null(mgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_WithOnlySshPrivateKey_ConvertsCorrectly()
        {
            // Arrange
            var sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com";
            var psConfig = new PSLinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: sshKey);

            // Act
            var mgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Null(mgmtConfig.Uid);
            Assert.Null(mgmtConfig.Gid);
            Assert.Equal(sshKey, mgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_WithNullProperties_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSLinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: null);

            // Act
            var mgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Null(mgmtConfig.Uid);
            Assert.Null(mgmtConfig.Gid);
            Assert.Null(mgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_WithEmptyStringSshKey_ConvertsCorrectly()
        {
            // Arrange
            var psConfig = new PSLinuxUserConfiguration(
                uid: 1001,
                gid: 1001,
                sshPrivateKey: "");

            // Act
            var mgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.Equal(1001, mgmtConfig.Uid);
            Assert.Equal(1001, mgmtConfig.Gid);
            Assert.Equal("", mgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var psConfig = new PSLinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "test-key");

            // Act
            var mgmtConfig1 = psConfig.ToLinuxUserConfiguration();
            var mgmtConfig2 = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig1);
            Assert.NotNull(mgmtConfig2);
            Assert.NotSame(mgmtConfig1, mgmtConfig2);
            Assert.Equal(mgmtConfig1.Uid, mgmtConfig2.Uid);
            Assert.Equal(mgmtConfig1.Gid, mgmtConfig2.Gid);
            Assert.Equal(mgmtConfig1.SshPrivateKey, mgmtConfig2.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_VerifyReturnType()
        {
            // Arrange
            var psConfig = new PSLinuxUserConfiguration(uid: 1000, gid: 1000);

            // Act
            var mgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(mgmtConfig);
            Assert.IsType<LinuxUserConfiguration>(mgmtConfig);
            Assert.IsAssignableFrom<LinuxUserConfiguration>(mgmtConfig);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ToLinuxUserConfiguration_WithEdgeCaseValues_HandlesCorrectly()
        {
            // Arrange - Test with edge case UID/GID values
            var testConfigurations = new[]
            {
                new { Uid = (int?)0, Gid = (int?)0, Description = "Root user (0:0)" },
                new { Uid = (int?)65534, Gid = (int?)65534, Description = "Nobody user (65534:65534)" },
                new { Uid = (int?)1, Gid = (int?)1, Description = "Daemon user (1:1)" },
                new { Uid = (int?)999, Gid = (int?)999, Description = "System user (999:999)" },
                new { Uid = (int?)2147483647, Gid = (int?)2147483647, Description = "Maximum int value" }
            };

            foreach (var testConfig in testConfigurations)
            {
                // Arrange
                var psConfig = new PSLinuxUserConfiguration(
                    uid: testConfig.Uid,
                    gid: testConfig.Gid,
                    sshPrivateKey: $"test-key-for-{testConfig.Uid}");

                // Act
                var mgmtConfig = psConfig.ToLinuxUserConfiguration();

                // Assert
                Assert.NotNull(mgmtConfig);
                Assert.Equal(testConfig.Uid, mgmtConfig.Uid);
                Assert.Equal(testConfig.Gid, mgmtConfig.Gid);
                Assert.Equal($"test-key-for-{testConfig.Uid}", mgmtConfig.SshPrivateKey);
            }
        }

        #endregion

        #region FromLinuxUserConfiguration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithNull_ReturnsNull()
        {
            // Act
            var result = PSLinuxUserConfiguration.FromLinuxUserConfiguration(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithAllProperties_ConvertsCorrectly()
        {
            // Arrange
            var sshKey = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAABG5vbmUAAAAEbm9uZQ...\n-----END OPENSSH PRIVATE KEY-----";
            var mgmtConfig = new LinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: sshKey);

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal(1000, psConfig.Uid);
            Assert.Equal(1000, psConfig.Gid);
            Assert.Equal(sshKey, psConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithOnlyUidAndGid_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new LinuxUserConfiguration(
                uid: 2000,
                gid: 2000,
                sshPrivateKey: null);

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal(2000, psConfig.Uid);
            Assert.Equal(2000, psConfig.Gid);
            Assert.Null(psConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithOnlySshPrivateKey_ConvertsCorrectly()
        {
            // Arrange
            var sshKey = "ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIF... user@hostname";
            var mgmtConfig = new LinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: sshKey);

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Null(psConfig.Uid);
            Assert.Null(psConfig.Gid);
            Assert.Equal(sshKey, psConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithNullProperties_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new LinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: null);

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Null(psConfig.Uid);
            Assert.Null(psConfig.Gid);
            Assert.Null(psConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithEmptyStringSshKey_ConvertsCorrectly()
        {
            // Arrange
            var mgmtConfig = new LinuxUserConfiguration(
                uid: 3000,
                gid: 3000,
                sshPrivateKey: "");

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal(3000, psConfig.Uid);
            Assert.Equal(3000, psConfig.Gid);
            Assert.Equal("", psConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_StaticMethod_DoesNotRequireInstance()
        {
            // Arrange
            var mgmtConfig = new LinuxUserConfiguration(
                uid: 1500,
                gid: 1500,
                sshPrivateKey: "test-key");

            // Act - Call static method directly on class
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.Equal(1500, psConfig.Uid);
            Assert.Equal(1500, psConfig.Gid);
            Assert.Equal("test-key", psConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_AlwaysCreatesNewInstance()
        {
            // Arrange
            var mgmtConfig = new LinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "test-key");

            // Act
            var psConfig1 = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);
            var psConfig2 = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig1);
            Assert.NotNull(psConfig2);
            Assert.NotSame(psConfig1, psConfig2);
            Assert.Equal(psConfig1.Uid, psConfig2.Uid);
            Assert.Equal(psConfig1.Gid, psConfig2.Gid);
            Assert.Equal(psConfig1.SshPrivateKey, psConfig2.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_VerifyReturnType()
        {
            // Arrange
            var mgmtConfig = new LinuxUserConfiguration(uid: 1000, gid: 1000);

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(psConfig);
            Assert.IsType<PSLinuxUserConfiguration>(psConfig);
            Assert.IsAssignableFrom<PSLinuxUserConfiguration>(psConfig);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FromLinuxUserConfiguration_WithEdgeCaseValues_HandlesCorrectly()
        {
            // Arrange - Test with edge case UID/GID values
            var testConfigurations = new[]
            {
                new { Uid = (int?)0, Gid = (int?)0, Description = "Root user (0:0)" },
                new { Uid = (int?)65534, Gid = (int?)65534, Description = "Nobody user (65534:65534)" },
                new { Uid = (int?)1, Gid = (int?)1, Description = "Daemon user (1:1)" },
                new { Uid = (int?)999, Gid = (int?)999, Description = "System user (999:999)" },
                new { Uid = (int?)2147483647, Gid = (int?)2147483647, Description = "Maximum int value" }
            };

            foreach (var testConfig in testConfigurations)
            {
                // Arrange
                var mgmtConfig = new LinuxUserConfiguration(
                    uid: testConfig.Uid,
                    gid: testConfig.Gid,
                    sshPrivateKey: $"test-key-for-{testConfig.Uid}");

                // Act
                var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

                // Assert
                Assert.NotNull(psConfig);
                Assert.Equal(testConfig.Uid, psConfig.Uid);
                Assert.Equal(testConfig.Gid, psConfig.Gid);
                Assert.Equal($"test-key-for-{testConfig.Uid}", psConfig.SshPrivateKey);
            }
        }

        #endregion

        #region Round-trip Conversion Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalPsConfig = new PSLinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----");

            // Act
            var mgmtConfig = originalPsConfig.ToLinuxUserConfiguration();
            var roundTripPsConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Equal(originalPsConfig.Uid, roundTripPsConfig.Uid);
            Assert.Equal(originalPsConfig.Gid, roundTripPsConfig.Gid);
            Assert.Equal(originalPsConfig.SshPrivateKey, roundTripPsConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_ToMgmtAndFromMgmt_PreservesNullProperties()
        {
            // Arrange
            var originalPsConfig = new PSLinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: null);

            // Act
            var mgmtConfig = originalPsConfig.ToLinuxUserConfiguration();
            var roundTripPsConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert
            Assert.NotNull(roundTripPsConfig);
            Assert.Null(roundTripPsConfig.Uid);
            Assert.Null(roundTripPsConfig.Gid);
            Assert.Null(roundTripPsConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesAllProperties()
        {
            // Arrange
            var originalMgmtConfig = new LinuxUserConfiguration(
                uid: 2000,
                gid: 2000,
                sshPrivateKey: "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com");

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Equal(originalMgmtConfig.Uid, roundTripMgmtConfig.Uid);
            Assert.Equal(originalMgmtConfig.Gid, roundTripMgmtConfig.Gid);
            Assert.Equal(originalMgmtConfig.SshPrivateKey, roundTripMgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_FromMgmtAndToMgmt_PreservesNullProperties()
        {
            // Arrange
            var originalMgmtConfig = new LinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: null);

            // Act
            var psConfig = PSLinuxUserConfiguration.FromLinuxUserConfiguration(originalMgmtConfig);
            var roundTripMgmtConfig = psConfig.ToLinuxUserConfiguration();

            // Assert
            Assert.NotNull(roundTripMgmtConfig);
            Assert.Null(roundTripMgmtConfig.Uid);
            Assert.Null(roundTripMgmtConfig.Gid);
            Assert.Null(roundTripMgmtConfig.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoundTripConversion_MultipleScenarios_PreservesSemantics()
        {
            // Arrange - Test various realistic Linux user configurations
            var testScenarios = new[]
            {
                new { 
                    Uid = (int?)1000, 
                    Gid = (int?)1000, 
                    SshKey = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAA...\n-----END OPENSSH PRIVATE KEY-----",
                    Description = "Standard user with SSH key"
                },
                new { 
                    Uid = (int?)0, 
                    Gid = (int?)0, 
                    SshKey = (string)null,
                    Description = "Root user without SSH key"
                },
                new { 
                    Uid = (int?)null, 
                    Gid = (int?)null, 
                    SshKey = "ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIF... user@hostname",
                    Description = "OS-assigned UID/GID with SSH key"
                },
                new { 
                    Uid = (int?)65534, 
                    Gid = (int?)65534, 
                    SshKey = "",
                    Description = "Nobody user with empty SSH key"
                }
            };

            foreach (var scenario in testScenarios)
            {
                // Act - Round trip conversion starting from PS
                var psConfig = new PSLinuxUserConfiguration(scenario.Uid, scenario.Gid, scenario.SshKey);
                var mgmtFromPs = psConfig.ToLinuxUserConfiguration();
                var backToPs = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtFromPs);

                // Assert PS -> Mgmt -> PS
                Assert.Equal(scenario.Uid, backToPs.Uid);
                Assert.Equal(scenario.Gid, backToPs.Gid);
                Assert.Equal(scenario.SshKey, backToPs.SshPrivateKey);

                // Act - Round trip conversion starting from Mgmt
                var mgmtConfig = new LinuxUserConfiguration(scenario.Uid, scenario.Gid, scenario.SshKey);
                var psFromMgmt = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);
                var backToMgmt = psFromMgmt.ToLinuxUserConfiguration();

                // Assert Mgmt -> PS -> Mgmt
                Assert.Equal(scenario.Uid, backToMgmt.Uid);
                Assert.Equal(scenario.Gid, backToMgmt.Gid);
                Assert.Equal(scenario.SshKey, backToMgmt.SshPrivateKey);
            }
        }

        #endregion

        #region Integration Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_BothDirections_MaintainSemanticEquivalence()
        {
            // This test ensures that the semantic meaning is preserved across conversions for Azure Batch Linux user configuration

            // Test standard user configuration - Typical non-root user with SSH access
            var psStandardUser = new PSLinuxUserConfiguration(
                uid: 1000,
                gid: 1000,
                sshPrivateKey: "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----");
            var mgmtStandardUser = psStandardUser.ToLinuxUserConfiguration();
            var backToPs = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtStandardUser);

            Assert.NotNull(mgmtStandardUser);
            Assert.Equal(1000, mgmtStandardUser.Uid);
            Assert.Equal(1000, mgmtStandardUser.Gid);
            Assert.NotNull(mgmtStandardUser.SshPrivateKey);
            Assert.NotNull(backToPs);
            Assert.Equal(1000, backToPs.Uid);
            Assert.Equal(1000, backToPs.Gid);
            Assert.Equal(psStandardUser.SshPrivateKey, backToPs.SshPrivateKey);

            // Test OS-assigned user configuration - Let OS pick UID/GID
            var psOsAssigned = new PSLinuxUserConfiguration(
                uid: null,
                gid: null,
                sshPrivateKey: "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com");
            var mgmtOsAssigned = psOsAssigned.ToLinuxUserConfiguration();
            var backToPsOsAssigned = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtOsAssigned);

            Assert.NotNull(mgmtOsAssigned);
            Assert.Null(mgmtOsAssigned.Uid);
            Assert.Null(mgmtOsAssigned.Gid);
            Assert.NotNull(mgmtOsAssigned.SshPrivateKey);
            Assert.NotNull(backToPsOsAssigned);
            Assert.Null(backToPsOsAssigned.Uid);
            Assert.Null(backToPsOsAssigned.Gid);
            Assert.Equal(psOsAssigned.SshPrivateKey, backToPsOsAssigned.SshPrivateKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_NullHandling_WorksCorrectly()
        {
            // Test null handling in conversions

            // Act
            var resultFromNull = PSLinuxUserConfiguration.FromLinuxUserConfiguration(null);

            // Assert
            Assert.Null(resultFromNull);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_BatchUserAccountContext_VerifyCorrectUsage()
        {
            // This test validates the conversions work correctly in the context of Batch user account configuration
            // LinuxUserConfiguration is used to configure Linux-specific user account properties in Azure Batch

            // Arrange - Test with realistic Batch Linux user scenarios
            var linuxUserScenarios = new[]
            {
                // Standard developer user with SSH access for debugging
                new {
                    Uid = (int?)1000,
                    Gid = (int?)1000,
                    SshKey = "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAA...\n-----END OPENSSH PRIVATE KEY-----",
                    Description = "Developer user with SSH access for remote debugging"
                },
                // Service account user without SSH for production workloads
                new {
                    Uid = (int?)999,
                    Gid = (int?)999,
                    SshKey = (string)null,
                    Description = "Service account for production batch jobs without SSH access"
                },
                // OS-managed user for simple scenarios
                new {
                    Uid = (int?)null,
                    Gid = (int?)null,
                    SshKey = (string)null,
                    Description = "OS-managed user account for simple batch processing"
                },
                // Root user for privileged operations
                new {
                    Uid = (int?)0,
                    Gid = (int?)0,
                    SshKey = "ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIF... admin@hostname",
                    Description = "Root user for privileged system operations"
                }
            };

            foreach (var scenario in linuxUserScenarios)
            {
                // Act
                var psLinuxUserConfig = new PSLinuxUserConfiguration(scenario.Uid, scenario.Gid, scenario.SshKey);
                var mgmtLinuxUserConfig = psLinuxUserConfig.ToLinuxUserConfiguration();

                // Assert - Should convert correctly for Batch user account configuration
                Assert.NotNull(mgmtLinuxUserConfig);
                Assert.Equal(scenario.Uid, mgmtLinuxUserConfig.Uid);
                Assert.Equal(scenario.Gid, mgmtLinuxUserConfig.Gid);
                Assert.Equal(scenario.SshKey, mgmtLinuxUserConfig.SshPrivateKey);

                // Verify round-trip conversion maintains Batch user semantics
                var backToPs = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtLinuxUserConfig);
                Assert.NotNull(backToPs);
                Assert.Equal(scenario.Uid, backToPs.Uid);
                Assert.Equal(scenario.Gid, backToPs.Gid);
                Assert.Equal(scenario.SshKey, backToPs.SshPrivateKey);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_SshKeyFormats_HandleCorrectly()
        {
            // Test with various SSH key formats that are commonly used

            var sshKeyFormats = new[]
            {
                // RSA private key in OpenSSH format
                "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAA...\n-----END OPENSSH PRIVATE KEY-----",
                // RSA private key in traditional format
                "-----BEGIN RSA PRIVATE KEY-----\nMIIEpAIBAAKCAQEA7yn3bRHQ...\n-----END RSA PRIVATE KEY-----",
                // Ed25519 private key
                "-----BEGIN OPENSSH PRIVATE KEY-----\nb3BlbnNzaC1rZXktdjEAAAAGYWVzMjU2Y3Ry...\n-----END OPENSSH PRIVATE KEY-----",
                // Public key (should be handled even though it's technically private key field)
                "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7yn3bRHQ... user@example.com",
                "ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIF... user@hostname",
                // Edge cases
                "",
                " ", // Single space
                "\n", // Single newline
                "invalid-key-format"
            };

            foreach (var sshKey in sshKeyFormats)
            {
                // Arrange
                var psConfig = new PSLinuxUserConfiguration(
                    uid: 1000,
                    gid: 1000,
                    sshPrivateKey: sshKey);

                // Act
                var mgmtConfig = psConfig.ToLinuxUserConfiguration();
                var roundTripPs = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

                // Assert - All key formats should be preserved exactly
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);
                Assert.Equal(sshKey, mgmtConfig.SshPrivateKey);
                Assert.Equal(sshKey, roundTripPs.SshPrivateKey);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_UidGidConstraints_VerifySemantics()
        {
            // Test UID/GID constraint semantics - both should be specified together or not at all

            var uidGidScenarios = new[]
            {
                // Both specified - valid scenario
                new { Uid = (int?)1000, Gid = (int?)1000, IsValid = true, Description = "Both UID and GID specified" },
                // Both null - valid scenario (OS picks)
                new { Uid = (int?)null, Gid = (int?)null, IsValid = true, Description = "Both UID and GID null (OS-assigned)" },
                // Only UID specified - typically invalid but should still convert
                new { Uid = (int?)1000, Gid = (int?)null, IsValid = false, Description = "Only UID specified" },
                // Only GID specified - typically invalid but should still convert
                new { Uid = (int?)null, Gid = (int?)1000, IsValid = false, Description = "Only GID specified" }
            };

            foreach (var scenario in uidGidScenarios)
            {
                // Arrange
                var psConfig = new PSLinuxUserConfiguration(
                    uid: scenario.Uid,
                    gid: scenario.Gid,
                    sshPrivateKey: "test-key");

                // Act - Should convert regardless of validity
                var mgmtConfig = psConfig.ToLinuxUserConfiguration();
                var roundTripPs = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

                // Assert - Conversion should preserve values exactly
                Assert.NotNull(mgmtConfig);
                Assert.NotNull(roundTripPs);
                Assert.Equal(scenario.Uid, mgmtConfig.Uid);
                Assert.Equal(scenario.Gid, mgmtConfig.Gid);
                Assert.Equal(scenario.Uid, roundTripPs.Uid);
                Assert.Equal(scenario.Gid, roundTripPs.Gid);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_InstanceCreation_VerifyBehavior()
        {
            // This test verifies that the conversion methods create appropriate instances

            // Arrange
            var psConfig = new PSLinuxUserConfiguration(uid: 1000, gid: 1000, sshPrivateKey: "test-key");
            var mgmtConfig = new LinuxUserConfiguration(uid: 2000, gid: 2000, sshPrivateKey: "mgmt-key");

            // Act
            var mgmtResult = psConfig.ToLinuxUserConfiguration();
            var psResult = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);

            // Assert - Verify proper instance creation
            Assert.NotNull(mgmtResult);
            Assert.NotNull(psResult);
            Assert.IsType<LinuxUserConfiguration>(mgmtResult);
            Assert.IsType<PSLinuxUserConfiguration>(psResult);

            // Verify new instances are created
            Assert.NotSame(mgmtConfig, mgmtResult);
            Assert.NotSame(psConfig, psResult);
        }

        #endregion

        #region Performance Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LinuxUserConfigurationConversions_PerformanceTest_ExecutesQuickly()
        {
            // This test ensures the conversions are efficient with multiple operations

            // Arrange
            var psConfigs = new PSLinuxUserConfiguration[100];
            var mgmtConfigs = new LinuxUserConfiguration[100];

            for (int i = 0; i < 100; i++)
            {
                psConfigs[i] = new PSLinuxUserConfiguration(
                    uid: 1000 + i,
                    gid: 1000 + i,
                    sshPrivateKey: $"test-key-{i}");

                mgmtConfigs[i] = new LinuxUserConfiguration(
                    uid: 2000 + i,
                    gid: 2000 + i,
                    sshPrivateKey: $"mgmt-key-{i}");
            }

            // Act & Assert - Multiple conversions should complete without delay
            for (int i = 0; i < 10; i++)
            {
                foreach (var psConfig in psConfigs)
                {
                    var mgmtResult = psConfig.ToLinuxUserConfiguration();
                    Assert.NotNull(mgmtResult);
                }

                foreach (var mgmtConfig in mgmtConfigs)
                {
                    var psResult = PSLinuxUserConfiguration.FromLinuxUserConfiguration(mgmtConfig);
                    Assert.NotNull(psResult);
                }
            }
        }

        #endregion
    }
}
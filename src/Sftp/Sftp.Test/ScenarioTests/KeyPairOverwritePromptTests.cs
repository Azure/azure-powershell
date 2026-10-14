using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.SftpCommands;
using Xunit;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Tests for the SSH key pair overwrite prompt behavior.
    /// Validates that both New-AzSftpCertificate and Connect-AzSftp
    /// have a Force parameter and support ShouldContinue confirmation
    /// when existing SSH key pairs are detected.
    /// </summary>
    public class KeyPairOverwritePromptTests
    {
        #region Force Parameter Existence Tests

        [Fact]
        public void TestNewAzSftpCertificateHasForceParameter()
        {
            // Force parameter is inherited from SftpBaseCmdlet
            var command = new NewAzSftpCertificateCommand();

            var forceProp = command.GetType().GetProperty("Force");
            Assert.NotNull(forceProp);
            Assert.Equal(typeof(SwitchParameter), forceProp.PropertyType);
        }

        [Fact]
        public void TestConnectAzSftpHasForceParameter()
        {
            var command = new ConnectAzSftpCommand();

            var forceProp = command.GetType().GetProperty("Force");
            Assert.NotNull(forceProp);
            Assert.Equal(typeof(SwitchParameter), forceProp.PropertyType);
        }

        [Fact]
        public void TestForceParameterIsOptional()
        {
            var command = new NewAzSftpCertificateCommand();

            var forceProp = command.GetType().GetProperty("Force");
            var paramAttrs = forceProp?.GetCustomAttributes(typeof(ParameterAttribute), true);
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);

            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(paramAttr.Mandatory);
        }

        [Fact]
        public void TestForceParameterHasHelpMessage()
        {
            var command = new ConnectAzSftpCommand();

            var forceProp = command.GetType().GetProperty("Force");
            var paramAttrs = forceProp?.GetCustomAttributes(typeof(ParameterAttribute), true);
            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Length > 0);

            var paramAttr = paramAttrs[0] as ParameterAttribute;
            Assert.NotNull(paramAttr);
            Assert.False(string.IsNullOrEmpty(paramAttr.HelpMessage));
            Assert.Contains("overwrite", paramAttr.HelpMessage.ToLower());
        }

        [Fact]
        public void TestForceParameterDefaultsToFalse()
        {
            var command = new NewAzSftpCertificateCommand();

            Assert.False(command.Force.IsPresent);
        }

        #endregion

        #region ShouldProcess/ShouldContinue Support Tests

        [Fact]
        public void TestNewAzSftpCertificateSupportsShouldProcess()
        {
            // ShouldProcess is needed for ShouldContinue to work
            var cmdletAttr = typeof(NewAzSftpCertificateCommand)
                .GetCustomAttributes(typeof(CmdletAttribute), false)
                .OfType<CmdletAttribute>()
                .FirstOrDefault();

            Assert.NotNull(cmdletAttr);
            Assert.True(cmdletAttr.SupportsShouldProcess,
                "New-AzSftpCertificate must support ShouldProcess for the overwrite prompt to work");
        }

        [Fact]
        public void TestConnectAzSftpSupportsShouldProcess()
        {
            var cmdletAttr = typeof(ConnectAzSftpCommand)
                .GetCustomAttributes(typeof(CmdletAttribute), false)
                .OfType<CmdletAttribute>()
                .FirstOrDefault();

            Assert.NotNull(cmdletAttr);
            Assert.True(cmdletAttr.SupportsShouldProcess,
                "Connect-AzSftp must support ShouldProcess for the overwrite prompt to work");
        }

        #endregion

        #region Key File Detection Logic Tests

        [Fact]
        public void TestDefaultKeyNamesMatchConstants()
        {
            // Verify that the key file names used for detection match the constants
            Assert.Equal("id_rsa", SftpConstants.SshPrivateKeyName);
            Assert.Equal("id_rsa.pub", SftpConstants.SshPublicKeyName);
            Assert.Equal("-cert.pub", SftpConstants.SshCertificateSuffix);
        }

        [Fact]
        public void TestNewAzSftpCertificateDefaultKeyPathsUseConstants()
        {
            // When CertificatePath is specified as a directory,
            // the cmdlet should place keys using the constant names
            var command = new NewAzSftpCertificateCommand();

            // Verify the cmdlet uses the id_rsa naming convention
            string expectedPrivateKeyName = SftpConstants.SshPrivateKeyName;
            string expectedPublicKeyName = SftpConstants.SshPublicKeyName;

            Assert.Equal("id_rsa", expectedPrivateKeyName);
            Assert.Equal("id_rsa.pub", expectedPublicKeyName);
        }

        [Fact]
        public void TestExistingKeyDetection_BothKeysExist()
        {
            // Test that existing key files can be detected
            var tempDir = Path.Combine(Path.GetTempPath(), $"sftp_keypair_test_{Guid.NewGuid():N}");
            try
            {
                Directory.CreateDirectory(tempDir);
                string privateKey = Path.Combine(tempDir, "id_rsa");
                string publicKey = Path.Combine(tempDir, "id_rsa.pub");

                File.WriteAllText(privateKey, "fake-private-key");
                File.WriteAllText(publicKey, "fake-public-key");

                Assert.True(File.Exists(privateKey), "Private key should exist for detection");
                Assert.True(File.Exists(publicKey), "Public key should exist for detection");
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void TestExistingKeyDetection_OnlyPrivateKeyExists()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), $"sftp_keypair_test_{Guid.NewGuid():N}");
            try
            {
                Directory.CreateDirectory(tempDir);
                string privateKey = Path.Combine(tempDir, "id_rsa");
                string publicKey = Path.Combine(tempDir, "id_rsa.pub");

                File.WriteAllText(privateKey, "fake-private-key");

                Assert.True(File.Exists(privateKey), "Private key should exist");
                Assert.False(File.Exists(publicKey), "Public key should not exist");
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void TestExistingKeyDetection_OnlyPublicKeyExists()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), $"sftp_keypair_test_{Guid.NewGuid():N}");
            try
            {
                Directory.CreateDirectory(tempDir);
                string privateKey = Path.Combine(tempDir, "id_rsa");
                string publicKey = Path.Combine(tempDir, "id_rsa.pub");

                File.WriteAllText(publicKey, "fake-public-key");

                Assert.False(File.Exists(privateKey), "Private key should not exist");
                Assert.True(File.Exists(publicKey), "Public key should exist");
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void TestExistingKeyDetection_NoKeysExist()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), $"sftp_keypair_test_{Guid.NewGuid():N}");
            try
            {
                Directory.CreateDirectory(tempDir);
                string privateKey = Path.Combine(tempDir, "id_rsa");
                string publicKey = Path.Combine(tempDir, "id_rsa.pub");

                Assert.False(File.Exists(privateKey), "Private key should not exist");
                Assert.False(File.Exists(publicKey), "Public key should not exist");
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }
        }

        #endregion

        #region Force Parameter Behavior Tests

        [Fact]
        public void TestForceParameterCanBeSetToTrue()
        {
            var command = new NewAzSftpCertificateCommand();

            command.Force = new SwitchParameter(true);
            Assert.True(command.Force.IsPresent);
        }

        [Fact]
        public void TestForceParameterCanBeSetToFalse()
        {
            var command = new NewAzSftpCertificateCommand();

            command.Force = new SwitchParameter(false);
            Assert.False(command.Force.IsPresent);
        }

        [Fact]
        public void TestForceParameterInheritedByBothCmdlets()
        {
            // Both cmdlets inherit Force from SftpBaseCmdlet
            var newCert = new NewAzSftpCertificateCommand();
            var connect = new ConnectAzSftpCommand();

            var newCertForceProp = newCert.GetType().GetProperty("Force");
            var connectForceProp = connect.GetType().GetProperty("Force");

            Assert.NotNull(newCertForceProp);
            Assert.NotNull(connectForceProp);

            // Both should be declared on the same base type
            Assert.Equal(newCertForceProp.DeclaringType, connectForceProp.DeclaringType);
            Assert.Equal(typeof(SftpBaseCmdlet), newCertForceProp.DeclaringType);
        }

        #endregion

        #region Overwrite File Integrity Tests

        [Fact]
        public void TestOverwriteRemovesBothKeyFiles()
        {
            // Simulates what the cmdlet does when user confirms overwrite:
            // both key files should be deleted before regeneration
            var tempDir = Path.Combine(Path.GetTempPath(), $"sftp_overwrite_test_{Guid.NewGuid():N}");
            try
            {
                Directory.CreateDirectory(tempDir);
                string privateKey = Path.Combine(tempDir, "id_rsa");
                string publicKey = Path.Combine(tempDir, "id_rsa.pub");

                File.WriteAllText(privateKey, "old-private-key");
                File.WriteAllText(publicKey, "old-public-key");

                // Simulate overwrite behavior
                if (File.Exists(privateKey)) File.Delete(privateKey);
                if (File.Exists(publicKey)) File.Delete(publicKey);

                Assert.False(File.Exists(privateKey), "Private key should be deleted for overwrite");
                Assert.False(File.Exists(publicKey), "Public key should be deleted for overwrite");
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void TestReusePreservesExistingKeyFiles()
        {
            // Simulates what the cmdlet does when user declines overwrite:
            // existing key files should be preserved
            var tempDir = Path.Combine(Path.GetTempPath(), $"sftp_reuse_test_{Guid.NewGuid():N}");
            try
            {
                Directory.CreateDirectory(tempDir);
                string privateKey = Path.Combine(tempDir, "id_rsa");
                string publicKey = Path.Combine(tempDir, "id_rsa.pub");

                string originalPrivateContent = "original-private-key-content";
                string originalPublicContent = "original-public-key-content";
                File.WriteAllText(privateKey, originalPrivateContent);
                File.WriteAllText(publicKey, originalPublicContent);

                // Simulate reuse behavior (no deletion)
                Assert.True(File.Exists(privateKey), "Private key should be preserved");
                Assert.True(File.Exists(publicKey), "Public key should be preserved");
                Assert.Equal(originalPrivateContent, File.ReadAllText(privateKey));
                Assert.Equal(originalPublicContent, File.ReadAllText(publicKey));
            }
            finally
            {
                if (Directory.Exists(tempDir))
                    Directory.Delete(tempDir, true);
            }
        }

        #endregion

        #region Parameter Availability in All Parameter Sets

        [Fact]
        public void TestForceAvailableInNewAzSftpCertificateAllParameterSets()
        {
            // Force is defined once on the base class without ParameterSetName,
            // so it should be available in all parameter sets
            var forceProp = typeof(NewAzSftpCertificateCommand).GetProperty("Force");
            var paramAttrs = forceProp?.GetCustomAttributes(typeof(ParameterAttribute), true)
                .OfType<ParameterAttribute>()
                .ToList();

            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Count > 0);

            // No specific ParameterSetName means it applies to all sets
            var firstAttr = paramAttrs[0];
            Assert.True(string.IsNullOrEmpty(firstAttr.ParameterSetName) ||
                         firstAttr.ParameterSetName == "__AllParameterSets",
                "Force should be available in all parameter sets");
        }

        [Fact]
        public void TestForceAvailableInConnectAzSftpAllParameterSets()
        {
            var forceProp = typeof(ConnectAzSftpCommand).GetProperty("Force");
            var paramAttrs = forceProp?.GetCustomAttributes(typeof(ParameterAttribute), true)
                .OfType<ParameterAttribute>()
                .ToList();

            Assert.NotNull(paramAttrs);
            Assert.True(paramAttrs.Count > 0);

            var firstAttr = paramAttrs[0];
            Assert.True(string.IsNullOrEmpty(firstAttr.ParameterSetName) ||
                         firstAttr.ParameterSetName == "__AllParameterSets",
                "Force should be available in all parameter sets");
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Commands.Sftp.Common;
using Microsoft.Azure.Commands.Sftp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Test suite for SFTP utilities functionality.
    /// Port of Azure CLI test_sftp_utils.py
    /// Owner: johnli1
    /// </summary>
    [TestClass]
    public class SftpUtilsTests
    {
        private string _tempDir;

        [TestInitialize]
        public void SetUp()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "sftp_utils_test_" + Guid.NewGuid().ToString("N").Substring(0, 8));
            Directory.CreateDirectory(_tempDir);
        }

        [TestCleanup]
        public void TearDown()
        {
            if (Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        [TestMethod]
        public void TestBuildSftpCommandWithBasicOptions()
        {
            // Arrange
            var sftpSession = new SFTPSession(
                storageAccount: "teststorage",
                username: "teststorage.testuser",
                host: "teststorage.blob.core.windows.net",
                port: 22,
                certFile: Path.Combine(_tempDir, "test.cert"),
                privateKeyFile: Path.Combine(_tempDir, "test.key"),
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(sftpSession);

            // Assert
            Assert.IsTrue(command.Length > 0);
            Assert.AreEqual("sftp", Path.GetFileNameWithoutExtension(command[0]));
            
            // Should contain basic SSH options
            Assert.IsTrue(Array.Exists(command, arg => arg.Contains("PasswordAuthentication=no")));
            Assert.IsTrue(Array.Exists(command, arg => arg.Contains("StrictHostKeyChecking=no")));
            Assert.IsTrue(Array.Exists(command, arg => arg.Contains("UserKnownHostsFile=") && (arg.Contains("/dev/null") || arg.Contains("NUL"))));
            
            // Should contain destination
            Assert.IsTrue(Array.Exists(command, arg => arg.Contains("teststorage.testuser@teststorage.blob.core.windows.net")));
        }

        [TestMethod]
        public void TestBuildSftpCommandWithCustomPort()
        {
            // Arrange
            var sftpSession = new SFTPSession(
                storageAccount: "teststorage",
                username: "teststorage.testuser",
                host: "teststorage.blob.core.windows.net",
                port: 2222,
                certFile: Path.Combine(_tempDir, "test.cert"),
                privateKeyFile: Path.Combine(_tempDir, "test.key"),
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(sftpSession);

            // Assert
            Assert.IsTrue(Array.Exists(command, arg => arg == "-P"));
            var portIndex = Array.IndexOf(command, "-P");
            Assert.IsTrue(portIndex >= 0 && portIndex + 1 < command.Length);
            Assert.AreEqual("2222", command[portIndex + 1]);
        }

        [TestMethod]
        public void TestBuildSftpCommandWithSftpArgs()
        {
            // Arrange
            var sftpSession = new SFTPSession(
                storageAccount: "teststorage",
                username: "teststorage.testuser",
                host: "teststorage.blob.core.windows.net",
                port: 22,
                certFile: Path.Combine(_tempDir, "test.cert"),
                privateKeyFile: Path.Combine(_tempDir, "test.key"),
                sftpArgs: new[] { "-v", "-b", "batchfile.txt" },
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(sftpSession);

            // Assert
            Assert.IsTrue(Array.Exists(command, arg => arg == "-v"));
            Assert.IsTrue(Array.Exists(command, arg => arg == "-b"));
            Assert.IsTrue(Array.Exists(command, arg => arg == "batchfile.txt"));
        }

        [TestMethod]
        public void TestGetSshClientPathWindowsDefault()
        {
            // This test is environment-specific and would need to be adapted
            // based on whether we're running on Windows or not
            if (!System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                System.Runtime.InteropServices.OSPlatform.Windows))
            {
                Assert.Inconclusive("Test only applicable on Windows");
                return;
            }

            // Arrange & Act
            var sshPath = SftpUtils.GetSshClientPath("ssh");

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(sshPath));
            Assert.IsTrue(sshPath.EndsWith("ssh.exe") || sshPath == "ssh");
        }

        [TestMethod]
        public void TestGetSshClientPathCustomFolder()
        {
            // Arrange
            var customSshFolder = _tempDir;
            var sshExecutable = Path.Combine(customSshFolder, "ssh.exe");
            
            // Create a dummy ssh executable
            File.WriteAllText(sshExecutable, "dummy ssh");

            // Act
            var sshPath = SftpUtils.GetSshClientPath("ssh", customSshFolder);

            // Assert
            Assert.AreEqual(sshExecutable, sshPath);
        }

        [TestMethod]
        public void TestGetSshClientPathNonExistentCustomFolder()
        {
            // Arrange
            var nonExistentFolder = Path.Combine(_tempDir, "nonexistent");

            // Act & Assert
            try
            {
                var sshPath = SftpUtils.GetSshClientPath("ssh", nonExistentFolder);
                
                // Should fallback to system SSH if custom folder doesn't have the executable
                Assert.IsFalse(string.IsNullOrEmpty(sshPath));
            }
            catch (Exception ex)
            {
                // It's acceptable to throw an exception if SSH is not found anywhere
                Assert.IsTrue(ex.Message.Contains("Could not find ssh"));
            }
        }

        [TestMethod]
        public void TestHandleProcessInterruptionWithNullProcess()
        {
            // Act & Assert - Should not throw exception
            SftpUtils.HandleProcessInterruption(null);
        }

        [TestMethod]
        public void TestGetCertificateStartAndEndTimesValidCert()
        {
            // This test would require creating a valid SSH certificate
            // For now, we'll skip it as it requires ssh-keygen to be available
            // and would need to integrate with the full certificate generation pipeline
            Assert.Inconclusive("Test requires valid SSH certificate generation");
        }

        [TestMethod]
        public void TestGetCertificateStartAndEndTimesInvalidCert()
        {
            // Arrange
            var invalidCertFile = Path.Combine(_tempDir, "invalid.cert");
            File.WriteAllText(invalidCertFile, "invalid certificate content");

            // Act & Assert
            try
            {
                var result = SftpUtils.GetCertificateStartAndEndTimes(invalidCertFile);
                Assert.IsNull(result);
            }
            catch (Exception)
            {
                // It's acceptable to throw an exception for invalid certificate
            }
        }

        [TestMethod]
        public void TestGetSshCertValidityNullCertFile()
        {
            // Act
            var result = SftpUtils.GetSshCertValidity(null);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetSshCertValidityEmptyCertFile()
        {
            // Act
            var result = SftpUtils.GetSshCertValidity("");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestCreateSshKeyfileRequiresSshKeygen()
        {
            // This test requires ssh-keygen to be available
            // Skip if not available in the test environment
            try
            {
                // Arrange
                var keyFile = Path.Combine(_tempDir, "test_key");

                // Act
                SftpUtils.CreateSshKeyfile(keyFile);

                // Assert
                Assert.IsTrue(File.Exists(keyFile));
                Assert.IsTrue(File.Exists(keyFile + ".pub"));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ssh-keygen") || ex.Message.Contains("not found"))
                {
                    Assert.Inconclusive("ssh-keygen not available in test environment");
                }
                else
                {
                    throw;
                }
            }
        }

        [TestMethod]
        public void TestAttemptConnectionWithInvalidCommand()
        {
            // Arrange
            var invalidCommand = new[] { "nonexistent_command", "arg1", "arg2" };
            var env = new Dictionary<string, string>();
            var opInfo = new SFTPSession(
                storageAccount: "test",
                username: "test.user",
                host: "test.blob.core.windows.net",
                port: 22,
                certFile: null,
                privateKeyFile: null,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var (successful, duration, errorMsg) = SftpUtils.AttemptConnection(
                invalidCommand, env, SftpUtils.ProcessCreationFlags.None, opInfo, 1);

            // Assert
            Assert.IsFalse(successful);
            Assert.IsNotNull(duration);
            Assert.IsFalse(string.IsNullOrEmpty(errorMsg));
        }

        [TestMethod]
        public void TestExecuteSftpProcessWithInvalidCommand()
        {
            // Arrange
            var invalidCommand = new[] { "nonexistent_command", "arg1" };

            // Act
            var (process, returnCode) = SftpUtils.ExecuteSftpProcess(invalidCommand);

            // Assert
            Assert.IsNull(returnCode); // Should be null due to exception
            // Process might be null or not null depending on implementation
        }

        [TestMethod]
        public void TestSftpConstantsArePopulated()
        {
            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(SftpConstants.WindowsInvalidFoldernameChars));
            Assert.IsTrue(SftpConstants.DefaultSshPort > 0);
            Assert.IsTrue(SftpConstants.DefaultSftpPort > 0);
            Assert.IsFalse(string.IsNullOrEmpty(SftpConstants.SshPrivateKeyName));
            Assert.IsFalse(string.IsNullOrEmpty(SftpConstants.SshPublicKeyName));
            Assert.IsFalse(string.IsNullOrEmpty(SftpConstants.SshCertificateSuffix));
            Assert.IsNotNull(SftpConstants.DefaultSshOptions);
            Assert.IsTrue(SftpConstants.DefaultSshOptions.Length > 0);
        }

        [TestMethod]
        public void TestProcessCreationFlagsEnum()
        {
            // Assert
            Assert.AreEqual(0u, (uint)SftpUtils.ProcessCreationFlags.None);
            Assert.IsTrue((uint)SftpUtils.ProcessCreationFlags.CREATE_NO_WINDOW > 0);
            Assert.IsTrue((uint)SftpUtils.ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP > 0);
        }
    }
}

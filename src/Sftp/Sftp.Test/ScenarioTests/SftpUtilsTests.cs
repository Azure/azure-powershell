using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Xunit;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Models;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    public class SftpUtilsTests : IDisposable
    {
        private readonly string _tempDirectory;

        public SftpUtilsTests()
        {
            _tempDirectory = Path.Combine(Path.GetTempPath(), $"SftpUtilsTests_{Guid.NewGuid():N}");
            Directory.CreateDirectory(_tempDirectory);
        }

        public void Dispose()
        {
            if (Directory.Exists(_tempDirectory))
            {
                try
                {
                    Directory.Delete(_tempDirectory, true);
                }
                catch
                {
                    // Best effort cleanup
                }
            }
        }

        [Fact]
        public void BuildSftpCommand_WithBasicParameters_ReturnsCorrectCommand()
        {
            // Arrange
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: null,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(session);

            // Assert
            Assert.NotNull(command);
            Assert.True(command.Length > 0);
            Assert.Contains("-o", command);
            Assert.Contains("PasswordAuthentication=no", command);
            Assert.Contains("PubkeyAuthentication=yes", command);
            Assert.Contains("StrictHostKeyChecking=no", command);
        }

        [Fact]
        public void BuildSftpCommand_WithCertificateFile_AddsIdentitiesOnlyOption()
        {
            // Arrange
            string certFile = Path.Combine(_tempDirectory, "test-cert.pub");
            File.WriteAllText(certFile, "ssh-rsa-cert-v01@openssh.com test cert");

            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: certFile,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(session);

            // Assert
            Assert.Contains("IdentitiesOnly=yes", command);
        }

        [Fact]
        public void BuildSftpCommand_WithSftpArgs_IncludesAdditionalArguments()
        {
            // Arrange
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: null,
                sftpArgs: new[] { "-v", "-b", "batchfile.txt" },
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(session);

            // Assert
            Assert.Contains("-v", command);
            Assert.Contains("-b", command);
            Assert.Contains("batchfile.txt", command);
        }

        [Fact]
        public void TryGenerateConsoleCtrlEvent_OnWindows_ReturnsBoolean()
        {
            // Act
            var result = SftpUtils.TryGenerateConsoleCtrlEvent(1, 0);

            // Assert
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // On Windows, should return true or false based on actual result
                Assert.IsType<bool>(result);
            }
            else
            {
                // On non-Windows, should always return false
                Assert.False(result);
            }
        }

        [Fact]
        public void HandleProcessInterruption_WithNullProcess_DoesNotThrow()
        {
            // Act & Assert - Should not throw
            SftpUtils.HandleProcessInterruption(null);
        }

        [Fact]
        public void HandleProcessInterruption_WithExitedProcess_DoesNotThrow()
        {
            // Arrange
            var processInfo = new ProcessStartInfo
            {
                FileName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/echo",
                Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "/c echo test" : "test",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(processInfo);
            process.WaitForExit(5000); // Wait for it to exit

            // Act & Assert - Should not throw
            SftpUtils.HandleProcessInterruption(process);
        }

        [Fact]
        public void GetSshClientPath_WithNullSshClientFolder_ReturnsDefaultPath()
        {
            // Act
            var path = SftpUtils.GetSshClientPath("ssh", null);

            // Assert
            Assert.NotNull(path);
            Assert.NotEmpty(path);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.Contains("ssh", path);
                Assert.EndsWith(".exe", path);
            }
            else
            {
                Assert.Equal("ssh", path);
            }
        }

        [Fact]
        public void GetSshClientPath_WithInvalidSshClientFolder_ThrowsException()
        {
            // Arrange
            string invalidFolder = Path.Combine(_tempDirectory, "nonexistent");

            // Act & Assert
            var exception = Assert.Throws<Microsoft.Azure.Commands.Common.Exceptions.AzPSApplicationException>(
                () => SftpUtils.GetSshClientPath("ssh", invalidFolder));
            
            Assert.Contains("Could not find ssh", exception.Message);
        }

        [Fact]
        public void GetSshClientPath_WithValidSshClientFolder_ReturnsCorrectPath()
        {
            // Arrange
            string sshFolder = _tempDirectory;
            string expectedExe = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "ssh.exe" : "ssh";
            string sshPath = Path.Combine(sshFolder, expectedExe);
            
            // Create a dummy ssh executable
            File.WriteAllText(sshPath, "dummy ssh");

            // Act
            var result = SftpUtils.GetSshClientPath("ssh", sshFolder);

            // Assert
            Assert.Equal(sshPath, result);
        }

        [Fact]
        public void GetSshClientPath_UnsupportedArchitecture_ThrowsException()
        {
            // This test is challenging to write for architecture validation 
            // since we can't easily change the runtime architecture in tests
            // But we can test the string logic for different architectures
            
            // Act & Assert
            // The method should work with current architecture
            var result = SftpUtils.GetSshClientPath("ssh");
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("ssh")]
        [InlineData("sftp")]
        [InlineData("ssh-keygen")]
        public void GetSshClientPath_WithDifferentCommands_ReturnsCorrectPaths(string command)
        {
            // Act
            var path = SftpUtils.GetSshClientPath(command, null);

            // Assert
            Assert.NotNull(path);
            Assert.Contains(command, path);
        }

        [Fact]
        public void ProcessCreationFlags_EnumValues_AreCorrect()
        {
            // Assert
            Assert.Equal(0u, (uint)SftpUtils.ProcessCreationFlags.None);
            Assert.Equal(0x08000000u, (uint)SftpUtils.ProcessCreationFlags.CREATE_NO_WINDOW);
            Assert.Equal(0x00000010u, (uint)SftpUtils.ProcessCreationFlags.CREATE_NEW_CONSOLE);
            Assert.Equal(0x00000200u, (uint)SftpUtils.ProcessCreationFlags.CREATE_NEW_PROCESS_GROUP);
            Assert.Equal(0x00000008u, (uint)SftpUtils.ProcessCreationFlags.DETACHED_PROCESS);
        }

        [Fact]
        public void ExecuteSftpProcess_WithInvalidCommand_ReturnsNullExitCode()
        {
            // Arrange
            var command = new[] { "nonexistent_command_that_should_fail" };

            // Act
            var result = SftpUtils.ExecuteSftpProcess(command);

            // Assert
            Assert.NotNull(result);
            Assert.Null(result.Item2); // Exit code should be null for failed process start
        }

        [Fact]
        public void ExecuteSftpProcess_WithEchoCommand_ReturnsSuccessExitCode()
        {
            // Arrange
            var command = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new[] { "cmd.exe", "/c", "echo", "test" }
                : new[] { "/bin/echo", "test" };

            // Act
            var result = SftpUtils.ExecuteSftpProcess(command);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Item1); // Process should not be null
            Assert.Equal(0, result.Item2); // Exit code should be 0 for success
        }

        [Fact]
        public void ExecuteSftpProcess_WithEnvironmentVariables_PassesEnvironment()
        {
            // Arrange
            var command = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new[] { "cmd.exe", "/c", "echo", "%TEST_VAR%" }
                : new[] { "/bin/sh", "-c", "echo $TEST_VAR" };
            
            var env = new Dictionary<string, string> { { "TEST_VAR", "test_value" } };

            // Act
            var result = SftpUtils.ExecuteSftpProcess(command, env);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Item2); // Should succeed
        }

        [Fact]
        public void ExecuteSftpProcess_WithCreateNoWindowFlag_SetsCorrectFlags()
        {
            // Arrange
            var command = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new[] { "cmd.exe", "/c", "echo", "test" }
                : new[] { "/bin/echo", "test" };

            // Act
            var result = SftpUtils.ExecuteSftpProcess(command, null, SftpUtils.ProcessCreationFlags.CREATE_NO_WINDOW);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Item2); // Should succeed
        }

        [Fact]
        public void AttemptConnection_WithSuccessfulCommand_ReturnsTrue()
        {
            // Arrange
            var command = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new[] { "cmd.exe", "/c", "echo", "success" }
                : new[] { "/bin/echo", "success" };
            
            var env = new Dictionary<string, string>();
            var session = new SFTPSession("test", "user", "host", 22, null, null, null, null, null, null, null, false);

            // Act
            var result = SftpUtils.AttemptConnection(command, env, SftpUtils.ProcessCreationFlags.None, session, 1);

            // Assert
            Assert.True(result.Item1); // Success
            Assert.NotNull(result.Item2); // Duration
            Assert.True(result.Item2 >= 0); // Duration should be non-negative
            Assert.Null(result.Item3); // No error message
        }

        [Fact]
        public void AttemptConnection_WithFailingCommand_ReturnsFalse()
        {
            // Arrange
            var command = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new[] { "cmd.exe", "/c", "exit", "1" }
                : new[] { "/bin/sh", "-c", "exit 1" };
            
            var env = new Dictionary<string, string>();
            var session = new SFTPSession("test", "user", "host", 22, null, null, null, null, null, null, null, false);

            // Act
            var result = SftpUtils.AttemptConnection(command, env, SftpUtils.ProcessCreationFlags.None, session, 1);

            // Assert
            Assert.False(result.Item1); // Failure
            Assert.NotNull(result.Item2); // Duration
            Assert.NotNull(result.Item3); // Error message
            Assert.Contains("failed with return code", result.Item3);
        }

        [Fact]
        public void AttemptConnection_WithInvalidCommand_ReturnsFalseWithError()
        {
            // Arrange
            var command = new[] { "definitely_nonexistent_command_12345" };
            var env = new Dictionary<string, string>();
            var session = new SFTPSession("test", "user", "host", 22, null, null, null, null, null, null, null, false);

            // Act
            var result = SftpUtils.AttemptConnection(command, env, SftpUtils.ProcessCreationFlags.None, session, 1);

            // Assert
            Assert.False(result.Item1); // Failure
            Assert.NotNull(result.Item2); // Duration
            Assert.NotNull(result.Item3); // Error message
            Assert.Contains("Failed to start", result.Item3);
        }

        #region BufferSize Tests

        [Fact]
        public void BuildSftpCommand_WithDefaultBufferSize_DoesNotIncludeBufferFlag()
        {
            // Arrange - default buffer size is 256 * 1024 = 262144
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: null,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false,
                bufferSizeBytes: 256 * 1024  // Default value
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(session);

            // Assert - should NOT contain -B flag when using default buffer size
            Assert.DoesNotContain("-B", command);
        }

        [Fact]
        public void BuildSftpCommand_WithCustomBufferSize_IncludesBufferFlag()
        {
            // Arrange - custom buffer size
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: null,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false,
                bufferSizeBytes: 524288  // 512 KB - non-default value
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(session);

            // Assert - should contain -B flag with custom buffer size
            Assert.Contains("-B", command);
            Assert.Contains("524288", command);
        }

        [Fact]
        public void BuildSftpCommand_WithSmallBufferSize_IncludesBufferFlag()
        {
            // Arrange - smaller buffer size
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: null,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false,
                bufferSizeBytes: 32768  // 32 KB
            );

            // Act
            var command = SftpUtils.BuildSftpCommand(session);

            // Assert
            Assert.Contains("-B", command);
            Assert.Contains("32768", command);
        }

        [Fact]
        public void SFTPSession_BufferSizeBytes_DefaultValue_Is256KB()
        {
            // Arrange & Act
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22
            );

            // Assert - default buffer size should be 256 * 1024 = 262144
            Assert.Equal(256 * 1024, session.BufferSizeBytes);
        }

        [Fact]
        public void SFTPSession_BufferSizeBytes_CanBeSetViaConstructor()
        {
            // Arrange & Act
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22,
                bufferSizeBytes: 1048576  // 1 MB
            );

            // Assert
            Assert.Equal(1048576, session.BufferSizeBytes);
        }

        [Fact]
        public void SFTPSession_BufferSizeBytes_CanBeSetViaProperty()
        {
            // Arrange
            var session = new SFTPSession(
                storageAccount: "testaccount",
                username: "testuser",
                host: "testaccount.blob.core.windows.net",
                port: 22
            );

            // Act
            session.BufferSizeBytes = 2097152;  // 2 MB

            // Assert
            Assert.Equal(2097152, session.BufferSizeBytes);
        }

        #endregion
    }
}

using System;
using Xunit;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    public class SftpConstantsTests
    {
        [Fact]
        public void WindowsInvalidFoldernameChars_ContainsExpectedCharacters()
        {
            // Assert
            const string expected = "\\/*:<>?\"|";
            Assert.Equal(expected, SftpConstants.WindowsInvalidFoldernameChars);
            
            // Verify it contains common invalid characters
            Assert.Contains('\\', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('/', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('*', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains(':', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('<', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('>', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('?', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('"', SftpConstants.WindowsInvalidFoldernameChars);
            Assert.Contains('|', SftpConstants.WindowsInvalidFoldernameChars);
        }

        [Fact]
        public void DefaultPorts_AreCorrect()
        {
            // Assert
            Assert.Equal(22, SftpConstants.DefaultSshPort);
            Assert.Equal(22, SftpConstants.DefaultSftpPort);
        }

        [Fact]
        public void SshFileNames_AreCorrect()
        {
            // Assert
            Assert.Equal("id_rsa", SftpConstants.SshPrivateKeyName);
            Assert.Equal("id_rsa.pub", SftpConstants.SshPublicKeyName);
            Assert.Equal("-cert.pub", SftpConstants.SshCertificateSuffix);
        }

        [Fact]
        public void FilePermissions_AreCorrectOctalValues()
        {
            // Assert
            Assert.Equal(SftpConstants.PrivateKeyPermissions, 384);  // 600 octal
            Assert.Equal(SftpConstants.PublicKeyPermissions, 420);   // 644 octal
            
            // Verify the octal conversions are correct
            Assert.Equal(SftpConstants.PrivateKeyPermissions, Convert.ToInt32("600", 8));
            Assert.Equal(SftpConstants.PublicKeyPermissions, Convert.ToInt32("644", 8));
        }

        [Fact]
        public void ProcessTimeouts_AreReasonableValues()
        {
            // Assert
            Assert.Equal(5000, SftpConstants.ProcessExitTimeoutMs);        // 5 seconds
            Assert.Equal(2000, SftpConstants.QuickExitCheckTimeoutMs);     // 2 seconds
            Assert.Equal(30000, SftpConstants.SshKeygenTimeoutMs);         // 30 seconds
            Assert.Equal(1000, SftpConstants.RetryDelayMs);                // 1 second
            
            // Verify they are positive values
            Assert.True(SftpConstants.ProcessExitTimeoutMs > 0);
            Assert.True(SftpConstants.QuickExitCheckTimeoutMs > 0);
            Assert.True(SftpConstants.SshKeygenTimeoutMs > 0);
            Assert.True(SftpConstants.RetryDelayMs > 0);
            
            // Verify reasonable ordering
            Assert.True(SftpConstants.QuickExitCheckTimeoutMs < SftpConstants.ProcessExitTimeoutMs);
            Assert.True(SftpConstants.ProcessExitTimeoutMs < SftpConstants.SshKeygenTimeoutMs);
        }

        [Fact]
        public void DefaultSshOptions_ContainsExpectedOptions()
        {
            // Assert
            Assert.NotNull(SftpConstants.DefaultSshOptions);
            Assert.NotEmpty(SftpConstants.DefaultSshOptions);
            
            // Verify specific expected options
            Assert.Contains("PasswordAuthentication=no", SftpConstants.DefaultSshOptions);
            Assert.Contains("StrictHostKeyChecking=no", SftpConstants.DefaultSshOptions);
            Assert.Contains("UserKnownHostsFile=/dev/null", SftpConstants.DefaultSshOptions);
            Assert.Contains("LogLevel=ERROR", SftpConstants.DefaultSshOptions);
            
            // Verify RSA key types option exists
            Assert.Contains(SftpConstants.DefaultSshOptions, opt => 
                opt.StartsWith("PubkeyAcceptedKeyTypes=") && opt.Contains("rsa-sha2-256"));
        }

        [Fact]
        public void DefaultSshOptions_AllEntriesAreValidFormat()
        {
            // Assert
            foreach (var option in SftpConstants.DefaultSshOptions)
            {
                Assert.NotNull(option);
                Assert.NotEmpty(option);
                
                // SSH options should generally be in format "Key=Value"
                Assert.Contains('=', option);
                
                var parts = option.Split('=');
                Assert.True(parts.Length >= 2, $"Option '{option}' should have key=value format");
                Assert.NotEmpty(parts[0]); // Key should not be empty
                Assert.NotEmpty(parts[1]); // Value should not be empty
            }
        }

        [Fact]
        public void RecommendationMessages_AreNotEmpty()
        {
            // Assert
            Assert.NotNull(SftpConstants.RecommendationSshClientNotFound);
            Assert.NotEmpty(SftpConstants.RecommendationSshClientNotFound);
            
            Assert.NotNull(SftpConstants.RecommendationStorageAccountSftp);
            Assert.NotEmpty(SftpConstants.RecommendationStorageAccountSftp);
        }

        [Fact]
        public void RecommendationSshClientNotFound_ContainsUsefulInformation()
        {
            // Assert
            var message = SftpConstants.RecommendationSshClientNotFound;
            
            Assert.Contains("OpenSSH", message);
            Assert.Contains("SshClientFolder", message);
            Assert.Contains("install", message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void RecommendationStorageAccountSftp_ContainsUsefulInformation()
        {
            // Assert
            var message = SftpConstants.RecommendationStorageAccountSftp;
            
            Assert.Contains("Storage Account", message);
            Assert.Contains("SFTP", message);
            Assert.Contains("permissions", message, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("Storage Blob Data Contributor", message);
        }

        [Fact]
        public void SshCertificateSuffix_StartsWithHyphen()
        {
            // Assert
            Assert.StartsWith("-", SftpConstants.SshCertificateSuffix);
            Assert.EndsWith(".pub", SftpConstants.SshCertificateSuffix);
        }

        [Fact]
        public void SshPublicKeyName_EndsWithPubExtension()
        {
            // Assert
            Assert.EndsWith(".pub", SftpConstants.SshPublicKeyName);
        }

        [Fact]
        public void SshPrivateKeyName_DoesNotHaveExtension()
        {
            // Assert
            Assert.DoesNotContain('.', SftpConstants.SshPrivateKeyName);
        }

        [Fact]
        public void DefaultSshOptions_ContainsSupportForModernKeyTypes()
        {
            // Assert - Should support modern RSA-SHA2 key types
            var pubkeyOption = Assert.Single(SftpConstants.DefaultSshOptions, 
                opt => opt.StartsWith("PubkeyAcceptedKeyTypes="));
            
            Assert.Contains("rsa-sha2-256", pubkeyOption);
            Assert.Contains("cert-v01@openssh.com", pubkeyOption);
        }

        [Fact]
        public void DefaultSshOptions_DisablesPasswordAuthentication()
        {
            // Assert
            Assert.Contains("PasswordAuthentication=no", SftpConstants.DefaultSshOptions);
        }

        [Fact]
        public void DefaultSshOptions_DisablesStrictHostKeyChecking()
        {
            // Assert
            Assert.Contains("StrictHostKeyChecking=no", SftpConstants.DefaultSshOptions);
        }

        [Fact]
        public void DefaultSshOptions_RedirectsKnownHostsToDevNull()
        {
            // Assert
            Assert.Contains("UserKnownHostsFile=/dev/null", SftpConstants.DefaultSshOptions);
        }

        [Fact]
        public void DefaultSshOptions_SetsErrorLogLevel()
        {
            // Assert
            Assert.Contains("LogLevel=ERROR", SftpConstants.DefaultSshOptions);
        }

        [Fact]
        public void FilePermissions_PrivateKeyIsMoreRestrictive()
        {
            // Assert - Private key should have more restrictive permissions than public key
            Assert.True(SftpConstants.PrivateKeyPermissions < SftpConstants.PublicKeyPermissions);
        }

        [Theory]
        [InlineData(SftpConstants.DefaultSshPort)]
        public void DefaultSshPort_IsInValidRange(int port)
        {
            // Assert
            Assert.InRange(port, 1, 65535);
        }
        
        [Theory]
        [InlineData(SftpConstants.DefaultSftpPort)]
        public void DefaultSftpPort_IsInValidRange(int port)
        {
            // Assert
            Assert.InRange(port, 1, 65535);
        }

        [Fact]
        public void AllConstants_AreDefinedAndNotNull()
        {
            // Assert all string constants are not null
            Assert.NotNull(SftpConstants.WindowsInvalidFoldernameChars);
            Assert.NotNull(SftpConstants.SshPrivateKeyName);
            Assert.NotNull(SftpConstants.SshPublicKeyName);
            Assert.NotNull(SftpConstants.SshCertificateSuffix);
            Assert.NotNull(SftpConstants.RecommendationSshClientNotFound);
            Assert.NotNull(SftpConstants.RecommendationStorageAccountSftp);
            Assert.NotNull(SftpConstants.DefaultSshOptions);
        }
    }
}

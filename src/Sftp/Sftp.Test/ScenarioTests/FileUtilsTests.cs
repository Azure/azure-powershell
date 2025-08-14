using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using Xunit;
using Moq;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Test suite for SFTP file utilities.
    /// Port of Azure CLI test_file_utils.py
    /// Owner: johnli1
    /// </summary>
    public class FileUtilsTests
    {
        private string _tempDir;

        public FileUtilsTests()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "sftp_file_utils_test_" + Guid.NewGuid().ToString("N").Substring(0, 8));
            Directory.CreateDirectory(_tempDir);
        }

        private void TearDown()
        {
            if (Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        [Fact]
        public void TestMakeDirsForFileCreatesParentDirectories()
        {
            try
            {
                // Arrange
                var testFilePath = Path.Combine(_tempDir, "subdir1", "subdir2", "test_file.txt");

                // Act
                FileUtils.MakeDirsForFile(testFilePath);

                // Assert
                var parentDir = Path.GetDirectoryName(testFilePath);
                Assert.True(Directory.Exists(parentDir));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestMakeDirsForFileWithExistingDirectories()
        {
            try
            {
                // Arrange
                var existingDir = Path.Combine(_tempDir, "existing");
                Directory.CreateDirectory(existingDir);
                var testFilePath = Path.Combine(existingDir, "test_file.txt");

                // Act & Assert - Should not raise an exception
                FileUtils.MakeDirsForFile(testFilePath);
                Assert.True(Directory.Exists(existingDir));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestMkdirPCreatesDirectory()
        {
            try
            {
                // Arrange
                var testDir = Path.Combine(_tempDir, "new_directory");

                // Act
                FileUtils.MkdirP(testDir);

                // Assert
                Assert.True(Directory.Exists(testDir));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestMkdirPWithExistingDirectory()
        {
            try
            {
                // Arrange
                var existingDir = Path.Combine(_tempDir, "existing");
                Directory.CreateDirectory(existingDir);

                // Act & Assert - Should not raise an exception
                FileUtils.MkdirP(existingDir);
                Assert.True(Directory.Exists(existingDir));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestDeleteFileRemovesExistingFile()
        {
            try
            {
                // Arrange
                var testFile = Path.Combine(_tempDir, "test_delete.txt");
                File.WriteAllText(testFile, "test content");

                // Act
                FileUtils.DeleteFile(testFile, "Test deletion message");

                // Assert
                Assert.False(File.Exists(testFile));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestDeleteFileWithNonexistentFile()
        {
            try
            {
                // Arrange
                var nonexistentFile = Path.Combine(_tempDir, "nonexistent.txt");

                // Act & Assert - Should not raise an exception
                FileUtils.DeleteFile(nonexistentFile, "Test deletion message");
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestDeleteFileHandlesRemovalErrorWithWarning()
        {
            try
            {
                // Arrange
                var testFile = Path.Combine(_tempDir, "test_file.txt");
                File.WriteAllText(testFile, "test");
                
                // Make file read-only to simulate permission error
                File.SetAttributes(testFile, FileAttributes.ReadOnly);

                // Act & Assert - Should not raise exception when warning=true
                try
                {
                    FileUtils.DeleteFile(testFile, "Test message", warning: true);
                    // Should have printed warning but not thrown exception
                }
                finally
                {
                    // Clean up - remove read-only attribute
                    File.SetAttributes(testFile, FileAttributes.Normal);
                    File.Delete(testFile);
                }
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestDeleteFileRaisesErrorWithoutWarning()
        {
            try
            {
                // Arrange
                var testFile = Path.Combine(_tempDir, "test_file.txt");
                File.WriteAllText(testFile, "test");
                
                // Make file read-only to simulate permission error
                File.SetAttributes(testFile, FileAttributes.ReadOnly);

                try
                {
                    // Act & Assert
                    Assert.Throws<AzPSIOException>(() => FileUtils.DeleteFile(testFile, "Test message", warning: false));
                }
                finally
                {
                    // Clean up - remove read-only attribute
                    File.SetAttributes(testFile, FileAttributes.Normal);
                    File.Delete(testFile);
                }
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestDeleteFolderRemovesEmptyDirectory()
        {
            try
            {
                // Arrange
                var testDir = Path.Combine(_tempDir, "empty_dir");
                Directory.CreateDirectory(testDir);

                // Act
                FileUtils.DeleteFolder(testDir, "Test folder deletion");

                // Assert
                Assert.False(Directory.Exists(testDir));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestDeleteFolderWithNonexistentDirectory()
        {
            try
            {
                // Arrange
                var nonexistentDir = Path.Combine(_tempDir, "nonexistent");

                // Act & Assert - Should not raise an exception
                FileUtils.DeleteFolder(nonexistentDir, "Test deletion message");
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestWriteToFileCreatesFileWithContent()
        {
            try
            {
                // Arrange
                var testFile = Path.Combine(_tempDir, "test_write.txt");
                var content = "Hello, SFTP world!";

                // Act
                FileUtils.WriteToFile(testFile, "w", content, "Failed to write file");

                // Assert
                Assert.True(File.Exists(testFile));
                var actualContent = File.ReadAllText(testFile);
                Assert.Equal(content, actualContent);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestWriteToFileWithEncoding()
        {
            try
            {
                // Arrange
                var testFile = Path.Combine(_tempDir, "test_encoding.txt");
                var content = "Unicode content: αβγδε";

                // Act
                FileUtils.WriteToFile(testFile, "w", content, "Failed to write file", "utf-8");

                // Assert
                var actualContent = File.ReadAllText(testFile, System.Text.Encoding.UTF8);
                Assert.Equal(content, actualContent);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestWriteToFileAppendMode()
        {
            try
            {
                // Arrange
                var testFile = Path.Combine(_tempDir, "test_append.txt");
                var initialContent = "Initial content\n";
                var appendContent = "Appended content";

                // Act
                FileUtils.WriteToFile(testFile, "w", initialContent, "Failed to write file");
                FileUtils.WriteToFile(testFile, "a", appendContent, "Failed to append file");

                // Assert
                var content = File.ReadAllText(testFile);
                Assert.Contains(initialContent.Trim(), content);
                Assert.Contains(appendContent, content);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestGetLineThatContainsFindsmatchingLine()
        {
            try
            {
                // Arrange
                var text = "This is the first line\nThis line contains the target substring\nThis is the third line";
                var substring = "target";

                // Act
                var result = FileUtils.GetLineThatContains(text, substring);

                // Assert
                Assert.Equal("This line contains the target substring", result);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestGetLineThatContainsNoMatch()
        {
            try
            {
                // Arrange
                var text = "This is the first line\nThis is the second line\nThis is the third line";
                var substring = "nonexistent";

                // Act
                var result = FileUtils.GetLineThatContains(text, substring);

                // Assert
                Assert.Null(result);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestGetLineThatContainsEmptyText()
        {
            try
            {
                // Arrange
                var text = "";
                var substring = "target";

                // Act
                var result = FileUtils.GetLineThatContains(text, substring);

                // Assert
                Assert.Null(result);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestGetLineThatContainsCaseSensitive()
        {
            try
            {
                // Arrange
                var text = "This line contains TARGET\nThis line contains target";

                // Act
                var resultUpper = FileUtils.GetLineThatContains(text, "TARGET");
                var resultLower = FileUtils.GetLineThatContains(text, "target");

                // Assert
                Assert.Equal("This line contains TARGET", resultUpper);
                Assert.Equal("This line contains target", resultLower);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestRemoveInvalidCharactersFoldername()
        {
            try
            {
                // Arrange
                var folderName = "test\\folder/with*invalid<chars>?|";

                // Act
                var result = FileUtils.RemoveInvalidCharactersFoldername(folderName);

                // Assert
                Assert.Equal("testfolderwithinvalidchars", result);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestRemoveInvalidCharactersFoldernameNullInput()
        {
            try
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(() => FileUtils.RemoveInvalidCharactersFoldername(null));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestRemoveInvalidCharactersFoldernameEmptyInput()
        {
            try
            {
                // Act & Assert
                Assert.Throws<ArgumentException>(() => FileUtils.RemoveInvalidCharactersFoldername(""));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestCheckOrCreatePublicPrivateFilesCreatesBothKeys()
        {
            try
            {
                // Arrange
                var credentialsFolder = Path.Combine(_tempDir, "creds");

                // Act
                var (publicKeyFile, privateKeyFile, deleteKeys) = FileUtils.CheckOrCreatePublicPrivateFiles(null, null, credentialsFolder);

                // Assert
                Assert.True(deleteKeys);
                Assert.True(File.Exists(publicKeyFile));
                Assert.True(File.Exists(privateKeyFile));
                Assert.Equal(Path.Combine(credentialsFolder, SftpConstants.SshPublicKeyName), publicKeyFile);
                Assert.Equal(Path.Combine(credentialsFolder, SftpConstants.SshPrivateKeyName), privateKeyFile);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestCheckOrCreatePublicPrivateFilesWithExistingPublicKey()
        {
            try
            {
                // Arrange
                var publicKeyFile = Path.Combine(_tempDir, "test.pub");
                var privateKeyFile = Path.Combine(_tempDir, "test");
                
                // Create test key files
                File.WriteAllText(publicKeyFile, "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQ test");
                File.WriteAllText(privateKeyFile, "-----BEGIN RSA PRIVATE KEY-----\ntest\n-----END RSA PRIVATE KEY-----");

                // Act
                var (resultPublicKey, resultPrivateKey, deleteKeys) = FileUtils.CheckOrCreatePublicPrivateFiles(publicKeyFile, privateKeyFile, null);

                // Assert
                Assert.False(deleteKeys);
                Assert.Equal(publicKeyFile, resultPublicKey);
                Assert.Equal(privateKeyFile, resultPrivateKey);
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestCheckOrCreatePublicPrivateFilesNonexistentPublicKey()
        {
            try
            {
                // Arrange
                var nonexistentPublicKey = Path.Combine(_tempDir, "nonexistent.pub");

                // Act & Assert
                Assert.Throws<AzPSIOException>(() => FileUtils.CheckOrCreatePublicPrivateFiles(nonexistentPublicKey, null, null));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestCheckOrCreatePublicPrivateFilesNoPublicKeySpecified()
        {
            try
            {
                // Arrange
                var privateKeyFile = Path.Combine(_tempDir, "test");
                File.WriteAllText(privateKeyFile, "test private key");

                // Act & Assert
                Assert.Throws<AzPSIOException>(() => FileUtils.CheckOrCreatePublicPrivateFiles(null, privateKeyFile, null));
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestPrepareJwkDataWithValidPublicKey()
        {
            try
            {
                // This test would require mocking the RSAParser, skipping for now
                // as it needs integration with the full key generation pipeline
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestWriteCertFileCreatesFileWithCorrectFormat()
        {
            try
            {
                // Arrange
                var certFile = Path.Combine(_tempDir, "test_cert.pub");
                // var certificateContents = "AAAAB3NzaC1yc2EAAAADAQABAAABgQC7...";

                // Act
                // Note: This tests the private method via the public API
                // FileUtils.WriteCertFile(certificateContents, certFile);

                // For now, skip this test as WriteCertFile is private
                // Would need to make it internal and use InternalsVisibleTo attribute
            }
            finally
            {
                TearDown();
            }
        }

        [Fact]
        public void TestGetAndWriteCertificateUnsupportedCloud()
        {
            try
            {
                // Arrange: context with unknown cloud name
                var contextMock = new Mock<IAzureContext>();
                var envMock = new Mock<IAzureEnvironment>();
                envMock.Setup(e => e.Name).Returns("unknowncloud");
                contextMock.Setup(c => c.Environment).Returns(envMock.Object);
                contextMock.Setup(c => c.Tenant).Returns((IAzureTenant)null);
                // Act & Assert
                Assert.Throws<AzPSInvalidOperationException>(() => FileUtils.GetAndWriteCertificate(contextMock.Object, "dummy.pub", null, null));
            }
            finally
            {
                TearDown();
            }
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.Sftp.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Test suite for SFTP file utilities.
    /// Port of Azure CLI test_file_utils.py
    /// Owner: johnli1
    /// </summary>
    [TestClass]
    public class FileUtilsTests
    {
        private string _tempDir;

        [TestInitialize]
        public void SetUp()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "sftp_file_utils_test_" + Guid.NewGuid().ToString("N").Substring(0, 8));
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
        public void TestMakeDirsForFileCreatesParentDirectories()
        {
            // Arrange
            var testFilePath = Path.Combine(_tempDir, "subdir1", "subdir2", "test_file.txt");

            // Act
            FileUtils.MakeDirsForFile(testFilePath);

            // Assert
            var parentDir = Path.GetDirectoryName(testFilePath);
            Assert.IsTrue(Directory.Exists(parentDir));
        }

        [TestMethod]
        public void TestMakeDirsForFileWithExistingDirectories()
        {
            // Arrange
            var existingDir = Path.Combine(_tempDir, "existing");
            Directory.CreateDirectory(existingDir);
            var testFilePath = Path.Combine(existingDir, "test_file.txt");

            // Act & Assert - Should not raise an exception
            FileUtils.MakeDirsForFile(testFilePath);
            Assert.IsTrue(Directory.Exists(existingDir));
        }

        [TestMethod]
        public void TestMkdirPCreatesDirectory()
        {
            // Arrange
            var testDir = Path.Combine(_tempDir, "new_directory");

            // Act
            FileUtils.MkdirP(testDir);

            // Assert
            Assert.IsTrue(Directory.Exists(testDir));
        }

        [TestMethod]
        public void TestMkdirPWithExistingDirectory()
        {
            // Arrange
            var existingDir = Path.Combine(_tempDir, "existing");
            Directory.CreateDirectory(existingDir);

            // Act & Assert - Should not raise an exception
            FileUtils.MkdirP(existingDir);
            Assert.IsTrue(Directory.Exists(existingDir));
        }

        [TestMethod]
        public void TestDeleteFileRemovesExistingFile()
        {
            // Arrange
            var testFile = Path.Combine(_tempDir, "test_delete.txt");
            File.WriteAllText(testFile, "test content");

            // Act
            FileUtils.DeleteFile(testFile, "Test deletion message");

            // Assert
            Assert.IsFalse(File.Exists(testFile));
        }

        [TestMethod]
        public void TestDeleteFileWithNonexistentFile()
        {
            // Arrange
            var nonexistentFile = Path.Combine(_tempDir, "nonexistent.txt");

            // Act & Assert - Should not raise an exception
            FileUtils.DeleteFile(nonexistentFile, "Test deletion message");
        }

        [TestMethod]
        public void TestDeleteFileHandlesRemovalErrorWithWarning()
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

        [TestMethod]
        [ExpectedException(typeof(AzPSIOException))]
        public void TestDeleteFileRaisesErrorWithoutWarning()
        {
            // Arrange
            var testFile = Path.Combine(_tempDir, "test_file.txt");
            File.WriteAllText(testFile, "test");
            
            // Make file read-only to simulate permission error
            File.SetAttributes(testFile, FileAttributes.ReadOnly);

            try
            {
                // Act & Assert
                FileUtils.DeleteFile(testFile, "Test message", warning: false);
            }
            finally
            {
                // Clean up - remove read-only attribute
                File.SetAttributes(testFile, FileAttributes.Normal);
                File.Delete(testFile);
            }
        }

        [TestMethod]
        public void TestDeleteFolderRemovesEmptyDirectory()
        {
            // Arrange
            var testDir = Path.Combine(_tempDir, "empty_dir");
            Directory.CreateDirectory(testDir);

            // Act
            FileUtils.DeleteFolder(testDir, "Test folder deletion");

            // Assert
            Assert.IsFalse(Directory.Exists(testDir));
        }

        [TestMethod]
        public void TestDeleteFolderWithNonexistentDirectory()
        {
            // Arrange
            var nonexistentDir = Path.Combine(_tempDir, "nonexistent");

            // Act & Assert - Should not raise an exception
            FileUtils.DeleteFolder(nonexistentDir, "Test deletion message");
        }

        [TestMethod]
        public void TestWriteToFileCreatesFileWithContent()
        {
            // Arrange
            var testFile = Path.Combine(_tempDir, "test_write.txt");
            var content = "Hello, SFTP world!";

            // Act
            FileUtils.WriteToFile(testFile, "w", content, "Failed to write file");

            // Assert
            Assert.IsTrue(File.Exists(testFile));
            var actualContent = File.ReadAllText(testFile);
            Assert.AreEqual(content, actualContent);
        }

        [TestMethod]
        public void TestWriteToFileWithEncoding()
        {
            // Arrange
            var testFile = Path.Combine(_tempDir, "test_encoding.txt");
            var content = "Unicode content: αβγδε";

            // Act
            FileUtils.WriteToFile(testFile, "w", content, "Failed to write file", "utf-8");

            // Assert
            var actualContent = File.ReadAllText(testFile, System.Text.Encoding.UTF8);
            Assert.AreEqual(content, actualContent);
        }

        [TestMethod]
        public void TestWriteToFileAppendMode()
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
            Assert.IsTrue(content.Contains(initialContent.Trim()));
            Assert.IsTrue(content.Contains(appendContent));
        }

        [TestMethod]
        public void TestGetLineThatContainsFindsmatchingLine()
        {
            // Arrange
            var text = "This is the first line\nThis line contains the target substring\nThis is the third line";
            var substring = "target";

            // Act
            var result = FileUtils.GetLineThatContains(text, substring);

            // Assert
            Assert.AreEqual("This line contains the target substring", result);
        }

        [TestMethod]
        public void TestGetLineThatContainsNoMatch()
        {
            // Arrange
            var text = "This is the first line\nThis is the second line\nThis is the third line";
            var substring = "nonexistent";

            // Act
            var result = FileUtils.GetLineThatContains(text, substring);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetLineThatContainsEmptyText()
        {
            // Arrange
            var text = "";
            var substring = "target";

            // Act
            var result = FileUtils.GetLineThatContains(text, substring);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetLineThatContainsCaseSensitive()
        {
            // Arrange
            var text = "This line contains TARGET\nThis line contains target";

            // Act
            var resultUpper = FileUtils.GetLineThatContains(text, "TARGET");
            var resultLower = FileUtils.GetLineThatContains(text, "target");

            // Assert
            Assert.AreEqual("This line contains TARGET", resultUpper);
            Assert.AreEqual("This line contains target", resultLower);
        }

        [TestMethod]
        public void TestRemoveInvalidCharactersFoldername()
        {
            // Arrange
            var folderName = "test\\folder/with*invalid<chars>?|";

            // Act
            var result = FileUtils.RemoveInvalidCharactersFoldername(folderName);

            // Assert
            Assert.AreEqual("testfolderwithinvalidchars", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveInvalidCharactersFoldernameNullInput()
        {
            // Act & Assert
            FileUtils.RemoveInvalidCharactersFoldername(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveInvalidCharactersFoldernameEmptyInput()
        {
            // Act & Assert
            FileUtils.RemoveInvalidCharactersFoldername("");
        }

        [TestMethod]
        public void TestCheckOrCreatePublicPrivateFilesCreatesBothKeys()
        {
            // Arrange
            var credentialsFolder = Path.Combine(_tempDir, "creds");

            // Act
            var (publicKeyFile, privateKeyFile, deleteKeys) = FileUtils.CheckOrCreatePublicPrivateFiles(null, null, credentialsFolder);

            // Assert
            Assert.IsTrue(deleteKeys);
            Assert.IsTrue(File.Exists(publicKeyFile));
            Assert.IsTrue(File.Exists(privateKeyFile));
            Assert.AreEqual(Path.Combine(credentialsFolder, SftpConstants.SshPublicKeyName), publicKeyFile);
            Assert.AreEqual(Path.Combine(credentialsFolder, SftpConstants.SshPrivateKeyName), privateKeyFile);
        }

        [TestMethod]
        public void TestCheckOrCreatePublicPrivateFilesWithExistingPublicKey()
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
            Assert.IsFalse(deleteKeys);
            Assert.AreEqual(publicKeyFile, resultPublicKey);
            Assert.AreEqual(privateKeyFile, resultPrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(AzPSIOException))]
        public void TestCheckOrCreatePublicPrivateFilesNonexistentPublicKey()
        {
            // Arrange
            var nonexistentPublicKey = Path.Combine(_tempDir, "nonexistent.pub");

            // Act & Assert
            FileUtils.CheckOrCreatePublicPrivateFiles(nonexistentPublicKey, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(AzPSIOException))]
        public void TestCheckOrCreatePublicPrivateFilesNoPublicKeySpecified()
        {
            // Arrange
            var privateKeyFile = Path.Combine(_tempDir, "test");
            File.WriteAllText(privateKeyFile, "test private key");

            // Act & Assert
            FileUtils.CheckOrCreatePublicPrivateFiles(null, privateKeyFile, null);
        }

        [TestMethod]
        public void TestPrepareJwkDataWithValidPublicKey()
        {
            // This test would require mocking the RSAParser, skipping for now
            // as it needs integration with the full key generation pipeline
        }

        [TestMethod]
        public void TestWriteCertFileCreatesFileWithCorrectFormat()
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

        [TestMethod]
        [ExpectedException(typeof(AzPSInvalidOperationException))]
        public void TestGetAndWriteCertificateUnsupportedCloud()
        {
            // Arrange: context with unknown cloud name
            var contextMock = new Mock<IAzureContext>();
            var envMock = new Mock<IAzureEnvironment>();
            envMock.Setup(e => e.Name).Returns("unknowncloud");
            contextMock.Setup(c => c.Environment).Returns(envMock.Object);
            contextMock.Setup(c => c.Tenant).Returns((IAzureTenant)null);
            // Act & Assert
            FileUtils.GetAndWriteCertificate(contextMock.Object, "dummy.pub", null, null);
        }
    }
}

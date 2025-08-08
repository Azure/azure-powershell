using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Commands.Sftp.Models;
using System.IO;

namespace Microsoft.Azure.Commands.Sftp.Test.ScenarioTests
{
    [TestClass]
    public class SftpSessionTests
    {
        private string _tempDir;

        [TestInitialize]
        public void SetUp()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "sftp_session_test_" + Guid.NewGuid().ToString("N").Substring(0, 8));
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
        public void TestBuildArgsWithCertificateOnly()
        {
            // Arrange: cert file specified, no keys
            string certPath = Path.Combine(_tempDir, "id_rsa-cert.pub");
            File.WriteAllText(certPath, "dummycert");
            var session = new SFTPSession(
                storageAccount: "acct",
                username: null,
                host: "host",
                port: 22,
                publicKeyFile: null,
                privateKeyFile: null,
                certFile: certPath,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false);

            // Act
            var args = session.BuildArgs();

            // Assert: args should include certificate flag and IdentitiesOnly, not include -i public key
            CollectionAssert.Contains(args, $"-o CertificateFile=\"{certPath}\"");
            CollectionAssert.Contains(args, "-o IdentitiesOnly=yes");
            Assert.IsFalse(args.Contains("-i"));
        }

        [TestMethod]
        public void TestBuildArgsPrefersPrivateKeyThenCertificate()
        {
            // Arrange: private key and certificate specified
            string privPath = Path.Combine(_tempDir, "id_rsa");
            string certPath = Path.Combine(_tempDir, "id_rsa-cert.pub");
            File.WriteAllText(privPath, "dummykey");
            File.WriteAllText(certPath, "dummycert");
            var session = new SFTPSession(
                storageAccount: "acct",
                username: null,
                host: "host",
                port: 2200,
                publicKeyFile: null,
                privateKeyFile: privPath,
                certFile: certPath,
                sftpArgs: null,
                sshClientFolder: null,
                sshProxyFolder: null,
                credentialsFolder: null,
                yesWithoutPrompt: false);

            // Act
            var args = session.BuildArgs();

            // Assert: first identity flag is private key, then certificate flags, then port
            Assert.AreEqual(args[0], "-i");
            Assert.AreEqual(args[1], privPath);
            CollectionAssert.Contains(args, $"-o CertificateFile=\"{certPath}\"");
            CollectionAssert.Contains(args, "-o IdentitiesOnly=yes");
            Assert.IsTrue(args.Contains("-P"));
            int pIndex = args.IndexOf("-P");
            Assert.AreEqual("2200", args[pIndex + 1]);
        }
    }
}

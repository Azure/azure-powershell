using System;
using System.IO;
using Microsoft.Azure.PowerShell.Cmdlets.Sftp.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Azure.PowerShell.Cmdlets.Sftp.Test.ScenarioTests
{
    /// <summary>
    /// Test suite for RSA Parser functionality.
    /// Port of Azure CLI test_rsa_parser.py
    /// Owner: johnli1
    /// </summary>
    [TestClass]
    public class RSAParserTests
    {
        private const string ValidPublicKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQC7vI6eltAVfW5Bt9QvABcdELk8g6+OoWGJmuQquhiYq8mvVEOwPe1LmPbQpVVgTtFt7J3JvDtlPiF2u4mHy8O6p2NJHfgQ5iCQ6M8UyJtJAGl1gQ+VYr+8LPXEhyPJmg8iA+HQvKYZ8Ku1Q8sI8YpQl8bF6X8j7qk9oA+QH+1qJ7nJzG2pVq8B9K2YFJYhZOq6jI8zF+KUVH7JvD9b5f4F9k8iW3ZQl1QH6JzB1N+FhR8uD7X1J9nV8eE2I4bQ0A== test@example.com";
        
        private const string ValidAlgorithm = "ssh-rsa";
        private const string ValidBase64 = "AAAAB3NzaC1yc2EAAAADAQABAAABgQC7vI6eltAVfW5Bt9QvABcdELk8g6+OoWGJmuQquhiYq8mvVEOwPe1LmPbQpVVgTtFt7J3JvDtlPiF2u4mHy8O6p2NJHfgQ5iCQ6M8UyJtJAGl1gQ+VYr+8LPXEhyPJmg8iA+HQvKYZ8Ku1Q8sI8YpQl8bF6X8j7qk9oA+QH+1qJ7nJzG2pVq8B9K2YFJYhZOq6jI8zF+KUVH7JvD9b5f4F9k8iW3ZQl1QH6JzB1N+FhR8uD7X1J9nV8eE2I4bQ0A==";

        [TestMethod]
        public void TestParseValidRSAPublicKey()
        {
            // Arrange
            var parser = new RSAParser();

            // Act
            parser.Parse(ValidPublicKey);

            // Assert
            Assert.AreEqual(ValidAlgorithm, parser.Algorithm);
            Assert.IsFalse(string.IsNullOrEmpty(parser.Exponent));
            Assert.IsFalse(string.IsNullOrEmpty(parser.Modulus));
        }

        [TestMethod]
        public void TestParsePublicKeyWithComment()
        {
            // Arrange
            var parser = new RSAParser();
            var keyWithComment = $"{ValidAlgorithm} {ValidBase64} user@host.example.com";

            // Act
            parser.Parse(keyWithComment);

            // Assert
            Assert.AreEqual(ValidAlgorithm, parser.Algorithm);
            Assert.IsFalse(string.IsNullOrEmpty(parser.Exponent));
            Assert.IsFalse(string.IsNullOrEmpty(parser.Modulus));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParseNullPublicKey()
        {
            // Arrange
            var parser = new RSAParser();

            // Act & Assert
            parser.Parse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParseEmptyPublicKey()
        {
            // Arrange
            var parser = new RSAParser();

            // Act & Assert
            parser.Parse("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestParseWhitespacePublicKey()
        {
            // Arrange
            var parser = new RSAParser();

            // Act & Assert
            parser.Parse("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestParseIncorrectlyFormattedKey()
        {
            // Arrange
            var parser = new RSAParser();
            var malformedKey = "ssh-rsa"; // Missing base64 part

            // Act & Assert
            parser.Parse(malformedKey);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestParseWrongAlgorithm()
        {
            // Arrange
            var parser = new RSAParser();
            var wrongAlgorithmKey = $"ssh-ed25519 {ValidBase64}";

            // Act & Assert
            parser.Parse(wrongAlgorithmKey);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestParseInvalidBase64()
        {
            // Arrange
            var parser = new RSAParser();
            var invalidBase64Key = "ssh-rsa invalid_base64_data";

            // Act & Assert
            parser.Parse(invalidBase64Key);
        }

        [TestMethod]
        public void TestParseMinimalValidKey()
        {
            // Arrange
            var parser = new RSAParser();
            
            // Create a minimal valid SSH RSA key structure
            // ssh-rsa + algorithm length + algorithm + exponent length + exponent + modulus length + modulus
            var algorithmBytes = System.Text.Encoding.ASCII.GetBytes("ssh-rsa");
            var exponentBytes = new byte[] { 0x01, 0x00, 0x01 }; // 65537 in big-endian
            var modulusBytes = new byte[32]; // Small modulus for testing
            
            var keyData = new byte[4 + algorithmBytes.Length + 4 + exponentBytes.Length + 4 + modulusBytes.Length];
            int offset = 0;
            
            // Algorithm length (big-endian)
            keyData[offset++] = 0;
            keyData[offset++] = 0;
            keyData[offset++] = 0;
            keyData[offset++] = (byte)algorithmBytes.Length;
            
            // Algorithm
            Array.Copy(algorithmBytes, 0, keyData, offset, algorithmBytes.Length);
            offset += algorithmBytes.Length;
            
            // Exponent length (big-endian)
            keyData[offset++] = 0;
            keyData[offset++] = 0;
            keyData[offset++] = 0;
            keyData[offset++] = (byte)exponentBytes.Length;
            
            // Exponent
            Array.Copy(exponentBytes, 0, keyData, offset, exponentBytes.Length);
            offset += exponentBytes.Length;
            
            // Modulus length (big-endian)
            keyData[offset++] = 0;
            keyData[offset++] = 0;
            keyData[offset++] = 0;
            keyData[offset++] = (byte)modulusBytes.Length;
            
            // Modulus
            Array.Copy(modulusBytes, 0, keyData, offset, modulusBytes.Length);
            
            var base64Key = Convert.ToBase64String(keyData);
            var minimalKey = $"ssh-rsa {base64Key}";

            // Act
            parser.Parse(minimalKey);

            // Assert
            Assert.AreEqual("ssh-rsa", parser.Algorithm);
            Assert.IsFalse(string.IsNullOrEmpty(parser.Exponent));
            Assert.IsFalse(string.IsNullOrEmpty(parser.Modulus));
        }

        [TestMethod]
        public void TestParseKeyWithTrailingSpaces()
        {
            // Arrange
            var parser = new RSAParser();
            var keyWithSpaces = ValidPublicKey + "   ";

            // Act
            parser.Parse(keyWithSpaces);

            // Assert
            Assert.AreEqual(ValidAlgorithm, parser.Algorithm);
            Assert.IsFalse(string.IsNullOrEmpty(parser.Exponent));
            Assert.IsFalse(string.IsNullOrEmpty(parser.Modulus));
        }

        [TestMethod]
        public void TestParseKeyProducesUrlSafeBase64()
        {
            // Arrange
            var parser = new RSAParser();

            // Act
            parser.Parse(ValidPublicKey);

            // Assert - URL-safe base64 should not contain + or / characters
            Assert.IsFalse(parser.Exponent.Contains("+"));
            Assert.IsFalse(parser.Exponent.Contains("/"));
            Assert.IsFalse(parser.Modulus.Contains("+"));
            Assert.IsFalse(parser.Modulus.Contains("/"));
            
            // Should contain - and _ instead
            // (Note: This assertion might not always be true depending on the key content)
        }

        [TestMethod]
        public void TestInitialStateIsEmpty()
        {
            // Arrange & Act
            var parser = new RSAParser();

            // Assert
            Assert.AreEqual(string.Empty, parser.Algorithm);
            Assert.AreEqual(string.Empty, parser.Exponent);
            Assert.AreEqual(string.Empty, parser.Modulus);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestParseTruncatedKeyData()
        {
            // Arrange
            var parser = new RSAParser();
            
            // Create truncated key data (incomplete length field)
            var truncatedData = new byte[] { 0x00, 0x00 }; // Incomplete 4-byte length
            var base64Truncated = Convert.ToBase64String(truncatedData);
            var truncatedKey = $"ssh-rsa {base64Truncated}";

            // Act & Assert
            parser.Parse(truncatedKey);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestParseKeyWithMismatchedLength()
        {
            // Arrange
            var parser = new RSAParser();
            
            // Create key data with incorrect length field
            var keyData = new byte[] { 0x00, 0x00, 0x00, 0x10, 0x01, 0x02 }; // Says 16 bytes, but only has 2
            var base64Key = Convert.ToBase64String(keyData);
            var mismatchedKey = $"ssh-rsa {base64Key}";

            // Act & Assert
            parser.Parse(mismatchedKey);
        }
    }
}

using Azure.Security.KeyVault.Keys.Cryptography;

using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PSKeyOperationResult
    {

        // Summary: Key identifier
        [Ps1Xml(Target = ViewControl.List, Label = nameof(KeyId), Position = 0)]
        public string KeyId { get; }

        /// <summary>
        /// If operation is Wrap, the value is wrapped key
        /// If operation is Unwrap, the value is unwrapped key
        /// If operation is Encrypt, the value is encryted data
        /// If operation is Decrypt, the value is decrypted data
        /// </summary>
        [Ps1Xml(Target = ViewControl.List, Label = nameof(RawResult), Position = 1)]
        public byte[] RawResult { get; }

        // Summary: Algorithm used.
        [Ps1Xml(Target = ViewControl.List, Label = nameof(Algorithm), Position = 2)]
        public string Algorithm { get; }

        public PSKeyOperationResult(WrapResult wrapResult)
        {
            this.KeyId = wrapResult.KeyId;
            this.RawResult = wrapResult.EncryptedKey;
            this.Algorithm = wrapResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(UnwrapResult unwrapResult)
        {
            this.KeyId = unwrapResult.KeyId;
            this.RawResult = unwrapResult.Key;
            this.Algorithm = unwrapResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(EncryptResult encryptResult)
        {
            this.KeyId = encryptResult.KeyId;
            this.RawResult = encryptResult.Ciphertext;
            this.Algorithm = encryptResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(DecryptResult decryptResult)
        {
            this.KeyId = decryptResult.KeyId;
            this.RawResult = decryptResult.Plaintext;
            this.Algorithm = decryptResult.Algorithm.ToString();
        }
    }
}

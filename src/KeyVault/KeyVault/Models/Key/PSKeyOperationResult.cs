using Azure.Security.KeyVault.Keys.Cryptography;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PSKeyOperationResult
    {
        // Summary: Key identifier
        public string KeyId { get; }

        // Summary: encryted result or wraped result is base64 format. decryted result or unwraped result is plain text
        public string Result { get; }

        /// <summary>
        /// For encrypt operation, this is the byte array format for the result of the encryption.
        /// For decrypt operation, this is the byte array format for the decrypted data.
        /// For wrap operation, this is the byte array of wrapped key.
        /// For unwrap operation, this is the byte array of unwrapped key.
        /// </summary>
        public byte[] RawResult { get; }

        // Summary: Algorithm used.
        public string Algorithm { get; }

        public PSKeyOperationResult(WrapResult wrapResult)
        {
            this.KeyId = wrapResult.KeyId;
            this.RawResult = wrapResult.EncryptedKey;
            this.Result = System.Convert.ToBase64String(wrapResult.EncryptedKey);
            this.Algorithm = wrapResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(UnwrapResult unwrapResult)
        {
            this.KeyId = unwrapResult.KeyId;
            this.RawResult = unwrapResult.Key;
            this.Result = System.Text.Encoding.UTF8.GetString(unwrapResult.Key);
            this.Algorithm = unwrapResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(EncryptResult encryptResult)
        {
            this.KeyId = encryptResult.KeyId;
            this.RawResult = encryptResult.Ciphertext;
            this.Result = System.Convert.ToBase64String(encryptResult.Ciphertext);
            this.Algorithm = encryptResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(DecryptResult decryptResult)
        {
            this.KeyId = decryptResult.KeyId;
            this.RawResult = decryptResult.Plaintext;
            this.Result = System.Text.Encoding.UTF8.GetString(decryptResult.Plaintext);
            this.Algorithm = decryptResult.Algorithm.ToString();
        }
    }
}

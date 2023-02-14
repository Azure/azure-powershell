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

        // Summary: Algorithm used.
        public string Algorithm { get; }

        public PSKeyOperationResult(WrapResult wrapResult)
        {
            this.KeyId = wrapResult.KeyId;
            this.Result = System.Convert.ToBase64String(wrapResult.EncryptedKey);
            this.Algorithm = wrapResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(UnwrapResult unwrapResult)
        {
            this.KeyId = unwrapResult.KeyId;
            this.Result = System.Text.Encoding.Default.GetString(unwrapResult.Key);
            this.Algorithm = unwrapResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(EncryptResult encryptResult)
        {
            this.KeyId = encryptResult.KeyId;
            this.Result = System.Convert.ToBase64String(encryptResult.Ciphertext);
            this.Algorithm = encryptResult.Algorithm.ToString();
        }

        public PSKeyOperationResult(DecryptResult decryptResult)
        {
            this.KeyId = decryptResult.KeyId;
            this.Result = System.Text.Encoding.Default.GetString(decryptResult.Plaintext);
            this.Algorithm = decryptResult.Algorithm.ToString();
        }
    }
}

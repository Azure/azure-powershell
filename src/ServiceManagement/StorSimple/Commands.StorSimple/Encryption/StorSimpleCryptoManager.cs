using System;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Encryption
{
    public class StorSimpleCryptoManager
    {
        private PSStorSimpleClient StorSimpleClient;

        public StorSimpleCryptoManager(PSStorSimpleClient storSimpleClient)
        {
            this.StorSimpleClient = storSimpleClient;
        }

        /// <summary>
        /// Helper method that will return an encrypted secret using rakpub.
        /// Fetches CIK from the keystore and uses it to get plaintext rakpub
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="encryptedSecret"></param>
        /// <returns></returns>
        public KeyStoreOperationStatus EncryptSecretWithRakPub(String secret, out String encryptedSecret)
        {
            StorSimpleKeyManager keyManager = StorSimpleClient.GetResourceContext().StorSimpleKeyManager;
            encryptedSecret = null;

            //reading from keystore
            string cik = null;
            KeyStoreOperationStatus status = keyManager.RetrieveCIK(out cik);
            if (status != KeyStoreOperationStatus.PERSIST_SUCCESS)
            {
                return status;
            }

            string decryptedRAKPub = GetPlainTextRAKPub(cik);

            //encrypt secret using RAKPub
            encryptedSecret = CryptoHelper.EncryptSecretRSAPKCS(secret, decryptedRAKPub);

            return KeyStoreOperationStatus.SUCCESS;
        }

        public string GetPlainTextRAKPub(string cik)
        {
            var encryptedRAKPub = GetEncryptedRAKPub();

            //decrypt the public key using CIK
            return CryptoHelper.DecryptCipherAES(encryptedRAKPub, cik);
        }

        private string GetEncryptedRAKPub()
        {
            //TODO: should use some other method OR is this fine?
            return StorSimpleClient.GetResourceEncryptionKey().ResourceEncryptionKeys.EncodedEncryptedPublicKey;
        }

    }
}

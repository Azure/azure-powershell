// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Encryption
{
    public class StorSimpleCryptoManager
    {
        private StorSimpleClient StorSimpleClient;

        public StorSimpleCryptoManager(StorSimpleClient storSimpleClient)
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
        public KeyStoreOperationStatus EncryptSecretWithRakPub(string secret, out string encryptedSecret)
        {
            StorSimpleKeyManager keyManager = StorSimpleClient.GetResourceContext().StorSimpleKeyManager;
            encryptedSecret = null;

            //reading from keystore
            string cik = null;
            KeyStoreOperationStatus status = keyManager.RetrieveCIK(out cik);
            if (status != KeyStoreOperationStatus.RETRIEVE_SUCCESS)
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

        public string GetSecretsEncryptionThumbprint()
        {
            var key = StorSimpleClient.GetResourceEncryptionKey();
            return key.ResourceEncryptionKeys.Thumbprint;
       }

        private string GetEncryptedRAKPub()
        {
            //TODO: should use some other method OR is this fine?
            return StorSimpleClient.GetResourceEncryptionKey().ResourceEncryptionKeys.EncodedEncryptedPublicKey;
        }

    }
}

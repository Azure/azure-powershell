using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public class StorSimpleCryptoManager
    {
        string ONESDK_KEYSTORE = "onesdk.dat";
        StorSimpleCmdletBase storSimpleBase;

        public StorSimpleCryptoManager(StorSimpleCmdletBase storSimpleBase)
        {
            this.storSimpleBase = storSimpleBase;
        }
        /// <summary>
        /// Helper method that will return an encrypted secret using rakpub.
        /// Fetches CIK from the keystore and uses it to get plaintext rakpub
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        public KeyStoreOperationStatus EncryptSecretWithRakPub( String secret, out String encryptedSecret)
        {
            IKeyManager keyManager = new LocalKeyStoreManager();
            encryptedSecret = null;

            //reading from keystore
            String keyPersisted = null;
            KeyStoreOperationStatus getKeyFromStoreOutput = keyManager.RetrieveKey(out keyPersisted, ONESDK_KEYSTORE);
            if (getKeyFromStoreOutput != KeyStoreOperationStatus.PERSIST_SUCCESS)
            {
                return getKeyFromStoreOutput;
            }

            //decrypt the public key using CIK
            var key = storSimpleBase.StorSimpleClient.GetResourceEncryptionKey();
            String decryptedRAKPub = CryptoHelper.DecryptCipherAES(key.ResourceEncryptionKeys.EncodedEncryptedPublicKey, keyPersisted);

            //encrypt secret using RAKPub
            encryptedSecret = CryptoHelper.EncryptSecretRSAPKCS(secret, decryptedRAKPub);

            return KeyStoreOperationStatus.SUCCESS;
        }
    }
}

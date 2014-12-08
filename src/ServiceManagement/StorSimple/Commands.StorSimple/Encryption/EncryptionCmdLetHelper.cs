using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Encryption
{
    public class EncryptionCmdLetHelper
    {
        public static void PersistCIK(StorSimpleCmdletBase cmdlet, string resourceId, string cik)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException("resourceId", "ResourceId must be specified");
            }

            if (string.IsNullOrEmpty(cik))
            {
                throw new StorSimpleSecretManagementException("Invalid arguments - CIK is NULL", KeyStoreOperationStatus.PERSIST_EMPTY_KEY);
            }

            StorSimpleKeyManager mgr = cmdlet.StorSimpleClient.GetResourceContext().StorSimpleKeyManager;
            KeyStoreOperationStatus status = mgr.PersistCIK(cik);

            if (status == KeyStoreOperationStatus.PERSIST_FILE_ALREADY_EXISTS)
            {
                cmdlet.WriteWarning("Key storage operation failed with error that file already exists. Deleting and retrying");
                mgr.CleanupCIK();
                status = mgr.PersistCIK(cik);
            }

            // other error codes are NOT expected - those validations have been done already
            if (status != KeyStoreOperationStatus.PERSIST_SUCCESS)
            {   
                throw new StorSimpleSecretManagementException("Could not persist secret", status);
            }
        }

        public static string RetrieveCIK(StorSimpleCmdletBase cmdlet, string resourceId)
        {
            string cik = null;

            StorSimpleKeyManager mgr = cmdlet.StorSimpleClient.GetResourceContext().StorSimpleKeyManager;
            KeyStoreOperationStatus status = mgr.RetrieveCIK(out cik);

            if (status == KeyStoreOperationStatus.RETRIEVE_FILESREAM_EMPTY ||
                status == KeyStoreOperationStatus.RETRIEVE_FILESTREAM_INVALID)
            {
                // CIK was persisted, but has been corrupted
                throw new StorSimpleSecretManagementException("Secret was persisted earlier, but seems to have been corrupted", status);
            }

            if (status == KeyStoreOperationStatus.RETRIEVE_FILE_DOES_NOT_EXIST)
            {
                // CIK was never persisted
                throw new StorSimpleSecretManagementException("Could not find the persisted secret.", status);
            }

            // other error codes are NOT expected - those validations have been done already
            if (status != KeyStoreOperationStatus.RETRIEVE_SUCCESS)
            {
                throw new StorSimpleSecretManagementException("Could not reteive secret.", status);
            }

            if (string.IsNullOrEmpty(cik))
            {
                // CIK retrieved successfully, but is NULL :(
                throw new StorSimpleSecretManagementException("Retrieved secret successfully, but was NULL.", KeyStoreOperationStatus.RETRIEVE_EMPTY_KEY);
            }

            return cik;
        }

        public static void ValidatePersistedCIK(StorSimpleCmdletBase cmdlet, string resourceId)
        {
            string cik = RetrieveCIK(cmdlet, resourceId);
            
            StorSimpleCryptoManager cryptMgr = new StorSimpleCryptoManager(cmdlet.StorSimpleClient);
            string rakPub = cryptMgr.GetPlainTextRAKPub(cik);

            if (string.IsNullOrEmpty(rakPub))
            {
                throw new StorSimpleSecretManagementException("Failed to validate persisted secret.", KeyStoreOperationStatus.VALIDATE_FAILED);
            }
        }
    }
}

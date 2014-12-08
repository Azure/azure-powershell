using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Encryption
{
    // This class decorates the IKeyManager infra for securely storing/retrieving secrets.
    // Not prefering inheritence since this class can provide specific, meaningful functions to the user like "PersistCIK" instead of "PersistKey"
    public class StorSimpleKeyManager
    {
        #region properties
        private readonly string APP_DATA_FOLDER_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private const string ONESDK_KEYSTORE_FILE_FOR_CIK = "StorSimplePSSDK_CIK.key";

        private string ResourceId { get; set; }

        #endregion

        public StorSimpleKeyManager(string resourceId)
        {
            this.ResourceId = resourceId;
        }
        
        public KeyStoreOperationStatus RetrieveCIK(out string cik)
        {
            return RetrieveKey(out cik, GenerateKeyFilePathForCIK());
        }

        public KeyStoreOperationStatus PersistCIK(string cik)
        {
            return PersistKey(cik, GenerateKeyFilePathForCIK());
        }

        public KeyStoreOperationStatus CleanupCIK()
        {
            string path = GenerateKeyFilePathForCIK();
            File.Delete(path);
            return KeyStoreOperationStatus.SUCCESS;
        }

        #region privates
        private KeyStoreOperationStatus PersistKey(string keyValue, string filepath)
        {
            string folderPath = Directory.GetDirectoryRoot(filepath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            IKeyManager keyManager = new LocalKeyStoreManager(filepath, true);
            return keyManager.PersistKey(keyValue);
        }
        
        private KeyStoreOperationStatus RetrieveKey(out string keyValue, string filepath)
        {
            keyValue = null;
            if (!File.Exists(filepath))
            {
                return KeyStoreOperationStatus.RETRIEVE_FILE_DOES_NOT_EXIST;
            }

            IKeyManager keyManager = new LocalKeyStoreManager(filepath, true);
            return keyManager.RetrieveKey(out keyValue);
        }

        private string GenerateKeyFolderPathForResource()
        {
            return Path.Combine(APP_DATA_FOLDER_PATH, ResourceId);
        }

        private string GenerateKeyFilePathForCIK()
        {
            return Path.Combine(GenerateKeyFolderPathForResource(), ONESDK_KEYSTORE_FILE_FOR_CIK);
        }
        #endregion
    }
}

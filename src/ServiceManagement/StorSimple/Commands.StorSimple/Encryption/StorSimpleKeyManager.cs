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

using System;
using System.IO;
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
            string folderPath = Path.GetDirectoryName(filepath);
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

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
using System.Security.Cryptography;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Encryption
{
    public class EncryptionCmdLetHelper
    {
        public static void PersistCIK(StorSimpleCmdletBase cmdlet, string resourceId, string cik)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException("resourceId", Resources.ResourceIdMissing);
            }

            if (string.IsNullOrEmpty(cik))
            {
                throw new Exception(Resources.CIKInvalid);
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
                throw new Exception(Resources.PersistSecretFailed);
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
                throw new Exception(Resources.PersistedCIKCorrupted);
            }

            if (status == KeyStoreOperationStatus.RETRIEVE_FILE_DOES_NOT_EXIST)
            {
                // CIK was never persisted
                throw new Exception(Resources.CIKNotPersisted);
            }

            // other error codes are NOT expected - those validations have been done already
            if (status != KeyStoreOperationStatus.RETRIEVE_SUCCESS)
            {
                throw new Exception(Resources.CIKFetchFailed);
            }

            if (string.IsNullOrEmpty(cik))
            {
                // CIK retrieved successfully, but is NULL :(
                throw new Exception(Resources.PersistedCIKIsNull);
            }

            return cik;
        }

        public static void ValidatePersistedCIK(StorSimpleCmdletBase cmdlet, string resourceId)
        {
            string cik = RetrieveCIK(cmdlet, resourceId);
            
            StorSimpleCryptoManager cryptMgr = new StorSimpleCryptoManager(cmdlet.StorSimpleClient);

            string rakPub = null;

            try
            {
                rakPub = cryptMgr.GetPlainTextRAKPub(cik);
            }
            catch (CryptographicException exception)
            {
                // This case is to handle the failures during decrypting the Rak Pub
                cmdlet.WriteVerbose(string.Format(Resources.CIKInvalidWithException, exception.Message));
                throw new Exception(Resources.CIKInvalidWhileDecrypting);
            }

            if (string.IsNullOrEmpty(rakPub))
            {
                throw new Exception(Resources.PersistedCIKValidationFailed);
            }
        }
    }
}

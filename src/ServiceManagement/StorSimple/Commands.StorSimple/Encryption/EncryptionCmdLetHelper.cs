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
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Commands.StorSimple.Exceptions;
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
                throw new StorSimpleSecretManagementException(Resources.CIKInvalid, KeyStoreOperationStatus.PERSIST_EMPTY_KEY);
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
                throw new StorSimpleSecretManagementException(Resources.PersistSecretFailed, status);
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
                throw new StorSimpleSecretManagementException(Resources.PersistedCIKCorrupted, status);
            }

            if (status == KeyStoreOperationStatus.RETRIEVE_FILE_DOES_NOT_EXIST)
            {
                // CIK was never persisted
                throw new StorSimpleSecretManagementException(Resources.CIKNotPersisted, status);
            }

            // other error codes are NOT expected - those validations have been done already
            if (status != KeyStoreOperationStatus.RETRIEVE_SUCCESS)
            {
                throw new StorSimpleSecretManagementException(Resources.CIKFetchFailed, status);
            }

            if (string.IsNullOrEmpty(cik))
            {
                // CIK retrieved successfully, but is NULL :(
                throw new StorSimpleSecretManagementException(Resources.PersistedCIKIsNull, KeyStoreOperationStatus.RETRIEVE_EMPTY_KEY);
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
                throw new StorSimpleSecretManagementException(Resources.PersistedCIKValidationFailed, KeyStoreOperationStatus.VALIDATE_FAILED);
            }
        }
    }
}

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
using Microsoft.WindowsAzure.Commands.StorSimple.Encryption;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple;
using System;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// Internal wrapper implementation of the encryptor which cmdlet will use
    /// </summary>
    internal class ServiceSecretEncryptor : IServiceSecretEncryptor
    {
        private StorSimpleCryptoManager storSimpleCryptoManager;

        /// <summary>
        /// Constructs the encryptor to encrypt the secrets like password/key before sharing with service
        /// </summary>
        /// <param name="client"></param>
        public ServiceSecretEncryptor(StorSimpleClient client)
        {
            this.storSimpleCryptoManager = new StorSimpleCryptoManager(client);
        }

        /// <summary>
        /// Encrypt the secret
        /// </summary>
        /// <param name="secretToBeEncrypted">secret to be encrypted</param>
        /// <returns>encrypted secret</returns>
        public string EncryptSecret(string secretToBeEncrypted)
        {
            string encryptedPassword = string.Empty;
            KeyStoreOperationStatus status = storSimpleCryptoManager.EncryptSecretWithRakPub(secretToBeEncrypted, out encryptedPassword);
            if(KeyStoreOperationStatus.SUCCESS != status)
            {
                throw new Exception(Resources.ServiceSecretEncryptionFailure);
            }
            
            return encryptedPassword;
        }

        /// <summary>
        /// Gets the secrets encryption thumb print
        /// </summary>
        /// <returns>secret encryption thumb print</returns>
        public string GetSecretsEncryptionThumbprint()
        {
            return storSimpleCryptoManager.GetSecretsEncryptionThumbprint();
        }

    }
}
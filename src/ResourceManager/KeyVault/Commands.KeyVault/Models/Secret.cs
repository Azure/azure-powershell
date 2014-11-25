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
using System.Security;
using Client = Microsoft.KeyVault.Client;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class Secret
    {
        public Secret()
        { }

        /// <summary>
        /// Internal constructor used by KeyVaultDataServiceClient
        /// </summary>
        /// <param name="clientSecret">secret returned from service</param>
        /// <param name="vaultUriHelper">helper class</param>
        internal Secret(Client.Secret clientSecret, VaultUriHelper vaultUriHelper)
        {
            if (clientSecret == null)
            {
                throw new ArgumentNullException("clientSecret");
            }
            if (vaultUriHelper == null)
            {
                throw new ArgumentNullException("vaultUriHelper");
            }

            VaultName = vaultUriHelper.GetVaultName(clientSecret.Id);
            SecretName = vaultUriHelper.GetSecretName(clientSecret.Id);
            SecretValue = clientSecret.Value.ToSecureString();
            SecretValueText = clientSecret.Value;
            // TODO: trace vaultUriHelper.KeyVaultDnsSuffix;             

        }

        public string VaultName { get; set; }

        public string SecretName { get; set; }

        public SecureString SecretValue 
        {
            get 
            { 
                return secretValue;  
            }
            set
            {
                secretValue = value;
                if (secretValue != null)
                {
                    SecretValueText = secretValue.ToStringExt();
                }
                else
                {
                    SecretValueText = null;
                }
            }
        }
        private SecureString secretValue;

        public string SecretValueText { get; private set; }


    }
}

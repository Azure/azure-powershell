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
using System.Text;
using System.Net.Http;
using System.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common.Authentication;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Client = Microsoft.KeyVault.Client;
using Microsoft.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class KeyVaultDataServiceClient : IKeyVaultDataServiceClient
    {
        public KeyVaultDataServiceClient(IAuthenticationFactory authFactory, AzureContext context, HttpClient httpClient)
        {
            if (authFactory == null)
            {
                throw new ArgumentNullException("authFactory");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.Environment == null)
            {
                throw new ArgumentException(Resources.InvalidAzureEnvironment);
            }
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }

            var credential = new DataServiceCredential(authFactory, context);            
            this.keyVaultClient = new Client.KeyVaultClient(
                credential.OnAuthentication,
                SendRequestCallback,
                ReceiveResponseCallback,
                httpClient);

            
            this.vaultUriHelper = new VaultUriHelper(
                context.Environment.Endpoints[AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix]);
        }  
        
        /// <summary>
        /// Parameterless constructor for Mocking.
        /// </summary>
        public KeyVaultDataServiceClient()
        {
        }

        public KeyBundle CreateKey(string vaultName, string keyName, KeyCreationAttributes keyAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }
            if (keyAttributes == null)
            {
                throw new ArgumentNullException("keyAttributes");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            Client.KeyAttributes clientAttributes = (Client.KeyAttributes)keyAttributes;
            clientAttributes.Hsm = keyAttributes.Hsm;                 
            string keyType = JsonWebKeyType.Rsa;
            if (keyAttributes.Hsm.HasValue && keyAttributes.Hsm.Value) 
            {
                keyType = JsonWebKeyType.RsaHsm;
            }          

            Client.KeyBundle clientKeyBundle = this.keyVaultClient.CreateKeyAsync(
                vaultAddress, keyName, keyType, keyAttributes.KeyOps, clientAttributes).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        public KeyBundle ImportKey(string vaultName, string keyName, KeyCreationAttributes keyAttributes, JsonWebKey webKey)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }
            if (keyAttributes == null)
            {
                throw new ArgumentNullException("keyAttributes");
            }
            if (webKey == null)
            {
                throw new ArgumentNullException("webKey");
            }
            if (keyAttributes.Hsm.HasValue && !keyAttributes.Hsm.Value &&
                JsonWebKeyType.RsaHsm.Equals(webKey.Kty))
            {
                // Importing HSMRSA key blob as RSA key is not allowed            
                throw new ArgumentException(Resources.InvalidKeyDestination);
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            Client.KeyAttributes clientAttributes = (Client.KeyAttributes)keyAttributes;
            clientAttributes.Hsm = keyAttributes.Hsm;
            webKey.KeyOps = keyAttributes.KeyOps;
            Client.KeyBundle clientKeyBundle = new Client.KeyBundle()
            {
                Attributes = clientAttributes,
                Key = webKey
            };

            clientKeyBundle = this.keyVaultClient.ImportKeyAsync(vaultAddress, keyName, clientKeyBundle).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }      
       
        public KeyBundle SetKey(string vaultName, string keyName, KeyAttributes keyAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }
            if (keyAttributes == null)
            {
                throw new ArgumentNullException("keyAttributes");
            }
          
            string keyId = this.vaultUriHelper.CreateKeyAddress(vaultName, keyName);
            Client.KeyAttributes clientAttributes = (Client.KeyAttributes)keyAttributes;

            var clientKeyBundle = this.keyVaultClient.UpdateKeyAsync(keyId, clientAttributes).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }
        public KeyBundle GetKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }

            string keyId = this.vaultUriHelper.CreateKeyAddress(vaultName, keyName);

            Client.KeyBundle clientKeyBundle = this.keyVaultClient.GetKeyAsync(keyId).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        public IEnumerable<KeyBundle> GetKeys(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            return (this.keyVaultClient.GetKeysAsync(vaultAddress).GetAwaiter().GetResult()).
                Select( (bundle) => {return new KeyBundle(bundle, this.vaultUriHelper);} );       
        }
        
        public KeyBundle DeleteKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }

            string keyId = this.vaultUriHelper.CreateKeyAddress(vaultName, keyName);

            Client.KeyBundle clientKeyBundle = this.keyVaultClient.DeleteKeyAsync(keyId).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        public Secret SetSecret(string vaultName, string secretName, SecureString secretValue)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(secretName))
            {
                throw new ArgumentNullException("secretName");
            }
            if (secretValue == null)
            {
                throw new ArgumentNullException("secretValue");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            string plainSecretValue = secretValue.ToStringExt();

            Client.Secret clientSecret = this.keyVaultClient.SetSecretAsync(vaultAddress, secretName, plainSecretValue).GetAwaiter().GetResult();

            return new Secret(clientSecret, this.vaultUriHelper);
        }

        public Secret GetSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(secretName))
            {
                throw new ArgumentNullException("secretName");
            }

            string secretAddress = this.vaultUriHelper.CreateSecretAddress(vaultName, secretName);

            Client.Secret clientSecret = this.keyVaultClient.GetSecretAsync(secretAddress).GetAwaiter().GetResult();

            return new Secret(clientSecret, this.vaultUriHelper);
        }

        public IEnumerable<Secret> GetSecrets(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }          

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            return (this.keyVaultClient.GetSecretsAsync(vaultAddress).GetAwaiter().GetResult()).
                Select((clientSecret) => { return new Secret(clientSecret, this.vaultUriHelper); });       
        }

        public Secret DeleteSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(secretName))
            {
                throw new ArgumentNullException("secretName");
            }

            string secretAddress = this.vaultUriHelper.CreateSecretAddress(vaultName, secretName);

            Client.Secret clientSecret = this.keyVaultClient.DeleteSecretAsync(secretAddress).GetAwaiter().GetResult();

            return new Secret(clientSecret, this.vaultUriHelper);
        }
                
        private void SendRequestCallback(string correlationId, HttpRequestMessage request)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Tracing.SendRequest(correlationId, request);
            }
        }

        private void ReceiveResponseCallback(string correlationId, HttpResponseMessage response)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Tracing.ReceiveResponse(correlationId, response);
            }
        }

        private VaultUriHelper vaultUriHelper;
        private Client.KeyVaultClient keyVaultClient;        
    }
}

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

using Hyak.Common;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.KeyVault.WebKey;
using Microsoft.Azure.Common.Extensions;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;

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

        public KeyBundle CreateKey(string vaultName, string keyName, KeyAttributes keyAttributes)
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

            Client.KeyBundle clientKeyBundle =
                this.keyVaultClient.CreateKeyAsync(
                    vaultAddress,
                    keyName,
                    keyAttributes.KeyType,
                    key_ops: keyAttributes.KeyOps,
                    keyAttributes: clientAttributes).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        public KeyBundle ImportKey(string vaultName, string keyName, KeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm)
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

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Client.KeyAttributes clientAttributes = (Client.KeyAttributes)keyAttributes;

            webKey.KeyOps = keyAttributes.KeyOps;
            Client.KeyBundle clientKeyBundle = new Client.KeyBundle()
            {
                Attributes = clientAttributes,
                Key = webKey
            };

            clientKeyBundle = this.keyVaultClient.ImportKeyAsync(vaultAddress, keyName, clientKeyBundle, importToHsm).GetAwaiter().GetResult();

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

            Client.KeyAttributes clientAttributes = (Client.KeyAttributes)keyAttributes;

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            var clientKeyBundle = this.keyVaultClient.UpdateKeyAsync(vaultAddress, keyName, keyAttributes.KeyOps, attributes: clientAttributes).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        public KeyBundle GetKey(string vaultName, string keyName, string keyVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Client.KeyBundle clientKeyBundle = this.keyVaultClient.GetKeyAsync(vaultAddress, keyName, keyVersion).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        public IEnumerable<KeyIdentityItem> GetKeys(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            return (this.keyVaultClient.GetKeysAsync(vaultAddress).GetAwaiter().GetResult()).
                Select((keyItem) => { return new KeyIdentityItem(keyItem, this.vaultUriHelper); });
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

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Client.KeyBundle clientKeyBundle = this.keyVaultClient.DeleteKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();

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

            Client.Secret clientSecret = this.keyVaultClient.SetSecretAsync(vaultAddress, secretName, secretValue).GetAwaiter().GetResult();

            return new Secret(clientSecret, this.vaultUriHelper);
        }

        public Secret GetSecret(string vaultName, string secretName, string secretVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(secretName))
            {
                throw new ArgumentNullException("secretName");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            var secretIdentifier = new Client.SecretIdentifier(vaultAddress, secretName, secretVersion);
            Client.Secret clientSecret = this.keyVaultClient.GetSecretAsync(secretIdentifier.Identifier).GetAwaiter().GetResult();

            return new Secret(clientSecret, this.vaultUriHelper);
        }

        public IEnumerable<SecretIdentityItem> GetSecrets(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            return (this.keyVaultClient.GetSecretsAsync(vaultAddress).GetAwaiter().GetResult()).
                Select((secretItem) => { return new SecretIdentityItem(secretItem, this.vaultUriHelper); });
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

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Client.Secret clientSecret = this.keyVaultClient.DeleteSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();

            return new Secret(clientSecret, this.vaultUriHelper);
        }

        public string BackupKey(string vaultName, string keyName, string outputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }
            if (string.IsNullOrEmpty(outputBlobPath))
            {
                throw new ArgumentNullException("outputBlobPath");
            }

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            var backupBlob = this.keyVaultClient.BackupKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();

            File.WriteAllBytes(outputBlobPath, backupBlob);

            return outputBlobPath;
        }

        public KeyBundle RestoreKey(string vaultName, string inputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(inputBlobPath))
            {
                throw new ArgumentNullException("inputBlobPath");
            }

            var backupBlob = File.ReadAllBytes(inputBlobPath);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            var clientKeyBundle = this.keyVaultClient.RestoreKeyAsync(vaultAddress, backupBlob).GetAwaiter().GetResult();

            return new KeyBundle(clientKeyBundle, this.vaultUriHelper);
        }

        private void SendRequestCallback(string correlationId, HttpRequestMessage request)
        {
            if (TracingAdapter.IsEnabled)
            {
                Tracing.SendRequest(correlationId, request);
            }
        }

        private void ReceiveResponseCallback(string correlationId, HttpResponseMessage response)
        {
            if (TracingAdapter.IsEnabled)
            {
                Tracing.ReceiveResponse(correlationId, response);
            }
        }

        private VaultUriHelper vaultUriHelper;
        private Client.KeyVaultClient keyVaultClient;
    }
}

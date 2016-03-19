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

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.WebKey;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class KeyVaultDataServiceClient : IKeyVaultDataServiceClient
    {
        public KeyVaultDataServiceClient(IAuthenticationFactory authFactory, AzureContext context, HttpClient httpClient)
        {
            if (authFactory == null)
                throw new ArgumentNullException("authFactory");
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.Environment == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);
            if (httpClient == null)
                throw new ArgumentNullException("httpClient");
            
            var credential = new DataServiceCredential(authFactory, context, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            this.keyVaultClient = new KeyVaultClient(
                credential.OnAuthentication,
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
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
            if (keyAttributes == null)
                throw new ArgumentNullException("keyAttributes");
            
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            var attributes = (Azure.KeyVault.KeyAttributes)keyAttributes;

            Azure.KeyVault.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.CreateKeyAsync(
                    vaultAddress,
                    keyName,
                    keyAttributes.KeyType,
                    key_ops: keyAttributes.KeyOps,
                    keyAttributes: attributes,
                    tags: keyAttributes.TagsDirectionary).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }

        public KeyBundle ImportKey(string vaultName, string keyName, KeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
            if (keyAttributes == null)
                throw new ArgumentNullException("keyAttributes");
            if (webKey == null)
                throw new ArgumentNullException("webKey");
            if (webKey.Kty == JsonWebKeyType.RsaHsm && (importToHsm.HasValue && !importToHsm.Value))
                throw new ArgumentException(KeyVaultProperties.Resources.ImportByokAsSoftkeyError);
                      
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            
            webKey.KeyOps = keyAttributes.KeyOps;            
            var keyBundle = new Azure.KeyVault.KeyBundle()
            {
                Attributes = (Azure.KeyVault.KeyAttributes)keyAttributes,
                Key = webKey,
                Tags = keyAttributes.TagsDirectionary
            };

            try
            {
                keyBundle = this.keyVaultClient.ImportKeyAsync(vaultAddress, keyName, keyBundle, importToHsm).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }

        public KeyBundle UpdateKey(string vaultName, string keyName, string keyVersion, KeyAttributes keyAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
            if (keyAttributes == null)
                throw new ArgumentNullException("keyAttributes");
            
            var attributes = (Azure.KeyVault.KeyAttributes)keyAttributes;
            var keyIdentifier = new KeyIdentifier(this.vaultUriHelper.CreateVaultAddress(vaultName), keyName, keyVersion);

            Azure.KeyVault.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.UpdateKeyAsync(
                    keyIdentifier.Identifier, keyAttributes.KeyOps, attributes: attributes, tags: keyAttributes.TagsDirectionary).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }

        public KeyBundle GetKey(string vaultName, string keyName, string keyVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
            
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.GetKeyAsync(vaultAddress, keyName, keyVersion).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex); 
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }

        public IEnumerable<KeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");
           
            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);
           
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);
            
            try
            {
                ListKeysResponseMessage result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetKeysAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetKeysNextAsync(options.NextLink).GetAwaiter().GetResult();
                
                options.NextLink = result.NextLink;
                return (result.Value == null) ? new List<KeyIdentityItem>() :
                    result.Value.Select((keyItem) => new KeyIdentityItem(keyItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }                     
        }

        public IEnumerable<KeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            if (string.IsNullOrEmpty(options.Name))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyName);
            
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                ListKeysResponseMessage result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetKeyVersionsAsync(vaultAddress, options.Name).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetKeyVersionsNextAsync(options.NextLink).GetAwaiter().GetResult();
               
                options.NextLink = result.NextLink;
                return result.Value.Select((keyItem) => new KeyIdentityItem(keyItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public KeyBundle DeleteKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
        
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.DeleteKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }

        public Secret SetSecret(string vaultName, string secretName, SecureString secretValue, SecretAttributes secretAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");
            if (secretValue == null)
                throw new ArgumentNullException("secretValue");
            if (secretAttributes == null)
                throw new ArgumentNullException("secretAttributes");

            string value = secretValue.ConvertToString();
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            var attributes = (Azure.KeyVault.SecretAttributes)secretAttributes;

            Azure.KeyVault.Secret secret;
            try
            {
                secret = this.keyVaultClient.SetSecretAsync(vaultAddress, secretName, value, 
                    secretAttributes.TagsDictionary, secretAttributes.ContentType, attributes).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new Secret(secret, this.vaultUriHelper);
        }

        public Secret UpdateSecret(string vaultName, string secretName, string secretVersion, SecretAttributes secretAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");
            if (secretAttributes == null)
                throw new ArgumentNullException("secretAttributes");
                     
            var secretIdentifier = new SecretIdentifier(this.vaultUriHelper.CreateVaultAddress(vaultName), secretName, secretVersion);

            Azure.KeyVault.SecretAttributes attributes = (Azure.KeyVault.SecretAttributes)secretAttributes;

            Azure.KeyVault.Secret secret;
            try
            {
                secret = this.keyVaultClient.UpdateSecretAsync(secretIdentifier.Identifier, 
                    secretAttributes.ContentType, attributes, secretAttributes.TagsDictionary).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new Secret(secret, this.vaultUriHelper);
        }

        public Secret GetSecret(string vaultName, string secretName, string secretVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");
                       
            var secretIdentifier = new SecretIdentifier(this.vaultUriHelper.CreateVaultAddress(vaultName), secretName, secretVersion);
            Azure.KeyVault.Secret secret;
            try
            {
                secret = this.keyVaultClient.GetSecretAsync(secretIdentifier.Identifier).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new Secret(secret, this.vaultUriHelper);
        }

        public IEnumerable<SecretIdentityItem> GetSecrets(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");
            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);
        
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);
                       
            try
            {
                ListSecretsResponseMessage result;
                  
                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetSecretsAsync(vaultAddress).GetAwaiter().GetResult();                    
                else
                    result = this.keyVaultClient.GetSecretsNextAsync(options.NextLink).GetAwaiter().GetResult(); 

                options.NextLink = result.NextLink;
                return (result.Value == null) ? new List<SecretIdentityItem>() :
                    result.Value.Select((secretItem) => new SecretIdentityItem(secretItem, this.vaultUriHelper));            
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }           
        }

        public IEnumerable<SecretIdentityItem> GetSecretVersions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");
            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);
            if (string.IsNullOrEmpty(options.Name))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSecretName);
            
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);
            
            try
            {
                ListSecretsResponseMessage result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetSecretVersionsAsync(vaultAddress, options.Name).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetSecretVersionsNextAsync(options.NextLink).GetAwaiter().GetResult();
                
                options.NextLink = result.NextLink;
                return result.Value.Select((secretItem) => new SecretIdentityItem(secretItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public Secret DeleteSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");
           
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Secret secret;
            try
            {
                secret = this.keyVaultClient.DeleteSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new Secret(secret, this.vaultUriHelper);
        }

        public string BackupKey(string vaultName, string keyName, string outputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");
            if (string.IsNullOrEmpty(outputBlobPath))
                throw new ArgumentNullException("outputBlobPath");
            
            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            byte[] backupBlob;
            try
            {
                backupBlob = this.keyVaultClient.BackupKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            File.WriteAllBytes(outputBlobPath, backupBlob);

            return outputBlobPath;
        }

        public KeyBundle RestoreKey(string vaultName, string inputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(inputBlobPath))
                throw new ArgumentNullException("inputBlobPath");
            
            var backupBlob = File.ReadAllBytes(inputBlobPath);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.RestoreKeyAsync(vaultAddress, backupBlob).GetAwaiter().GetResult();
            }
            catch(Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }       

        private Exception GetInnerException(Exception exception)
        {
            while (exception.InnerException != null) exception = exception.InnerException;
            return exception;
        }

        private VaultUriHelper vaultUriHelper;
        private KeyVaultClient keyVaultClient;
    }
}

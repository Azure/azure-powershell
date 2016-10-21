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

using Microsoft.Azure.KeyVault.WebKey;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System.Security.Cryptography.X509Certificates;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class KeyVaultDataServiceClient : IKeyVaultDataServiceClient
    {
        public KeyVaultDataServiceClient(IAuthenticationFactory authFactory, AzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException("authFactory");
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.Environment == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);

            var credential = new DataServiceCredential(authFactory, context, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            this.keyVaultClient = new KeyVaultClient(credential.OnAuthentication);


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
            var attributes = (Azure.KeyVault.Models.KeyAttributes)keyAttributes;

            Azure.KeyVault.Models.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.CreateKeyAsync(
                    vaultAddress,
                    keyName,
                    keyAttributes.KeyType,
                    keyOps: keyAttributes.KeyOps == null ? null : new List<string> (keyAttributes.KeyOps),
                    keyAttributes: attributes,
                    tags: keyAttributes.TagsDirectionary).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }        

        public CertificateBundle MergeCertificate(string vaultName, string certName, X509Certificate2Collection certs, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException("certName");
            if (null == certs)
                throw new ArgumentNullException("certs");

            CertificateBundle certBundle;

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            try
            {
                certBundle = this.keyVaultClient.MergeCertificateAsync(vaultAddress, certName, certs, null, tags).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certBundle;

        }

        public CertificateBundle ImportCertificate(string vaultName, string certName, string base64CertColl, SecureString certPassword, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException("certName");
            if (string.IsNullOrEmpty(base64CertColl))
                throw new ArgumentNullException("base64CertColl");

            CertificateBundle certBundle;

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            var password = (certPassword == null) ? string.Empty : certPassword.ConvertToString();


            try
            {
                certBundle = this.keyVaultClient.ImportCertificateAsync(vaultAddress, certName, base64CertColl, password, new CertificatePolicy
                {
                    SecretProperties = new SecretProperties
                    {
                        ContentType = "application/x-pkcs12"
                    }
                }, null, tags).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certBundle;
        }

        public CertificateBundle ImportCertificate(string vaultName, string certName, X509Certificate2Collection certificateCollection, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException("certName");
            if (null == certificateCollection)
                throw new ArgumentNullException("certificateCollection");

            CertificateBundle certBundle;
            var vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            try
            {
                certBundle = this.keyVaultClient.ImportCertificateAsync(vaultAddress, certName, certificateCollection, new CertificatePolicy
                {
                    SecretProperties = new SecretProperties
                    {
                        ContentType = "application/x-pkcs12"
                    }
                }, null, tags).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certBundle;
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
            var keyBundle = new Azure.KeyVault.Models.KeyBundle()
            {
                Attributes = (Azure.KeyVault.Models.KeyAttributes)keyAttributes,
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
            
            var attributes = (Azure.KeyVault.Models.KeyAttributes)keyAttributes;
            var keyIdentifier = new KeyIdentifier(this.vaultUriHelper.CreateVaultAddress(vaultName), keyName, keyVersion);

            Azure.KeyVault.Models.KeyBundle keyBundle;
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

        public Contacts GetCertificateContacts(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Contacts contacts;

            try
            {
                contacts = this.keyVaultClient.GetCertificateContactsAsync(vaultAddress).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return contacts;
        }

        public CertificateBundle GetCertificate(string vaultName, string certName, string certificateVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException("certName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateBundle certBundle;

            try
            {
                certBundle = this.keyVaultClient.GetCertificateAsync(vaultAddress, certName, certificateVersion).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certBundle;
        }

        public KeyBundle GetKey(string vaultName, string keyName, string keyVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.KeyBundle keyBundle;
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

        public IEnumerable<CertificateIdentityItem> GetCertificates(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<CertificateItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetCertificatesAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetCertificatesNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<CertificateIdentityItem>() :
                    result.Select((certItem) => { return new CertificateIdentityItem(certItem, this.vaultUriHelper); });
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IEnumerable<CertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options)
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
                IPage<CertificateItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetCertificateVersionsAsync(vaultAddress, options.Name).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetCertificateVersionsNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return result.Select((certificateItem) => new CertificateIdentityItem(certificateItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
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
                IPage<KeyItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetKeysAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetKeysNextAsync(options.NextLink).GetAwaiter().GetResult();
                
                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<KeyIdentityItem>() :
                    result.Select((keyItem) => new KeyIdentityItem(keyItem, this.vaultUriHelper));
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
                IPage<KeyItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetKeyVersionsAsync(vaultAddress, options.Name).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetKeyVersionsNextAsync(options.NextLink).GetAwaiter().GetResult();
               
                options.NextLink = result.NextPageLink;
                return result.Select((keyItem) => new KeyIdentityItem(keyItem, this.vaultUriHelper));
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

            Azure.KeyVault.Models.KeyBundle keyBundle;
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

        public Contacts SetCertificateContacts(string vaultName, Contacts contacts)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (null == contacts)
                throw new ArgumentNullException("contacts");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Contacts outputContacts;

            try
            {
                outputContacts = this.keyVaultClient.SetCertificateContactsAsync(vaultAddress, contacts).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return outputContacts;
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
            var attributes = (Azure.KeyVault.Models.SecretAttributes)secretAttributes;

            Azure.KeyVault.Models.SecretBundle secret;
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

            Azure.KeyVault.Models.SecretAttributes attributes = (Azure.KeyVault.Models.SecretAttributes)secretAttributes;

            SecretBundle secret;
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
            SecretBundle secret;
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
                IPage<SecretItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetSecretsAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetSecretsNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<SecretIdentityItem>() :
                    result.Select((secretItem) => new SecretIdentityItem(secretItem, this.vaultUriHelper));            
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
                IPage<SecretItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetSecretVersionsAsync(vaultAddress, options.Name).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetSecretVersionsNextAsync(options.NextLink).GetAwaiter().GetResult();
                
                options.NextLink = result.NextPageLink;
                return result.Select((secretItem) => new SecretIdentityItem(secretItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public CertificateOperation EnrollCertificate(string vaultName, string certificateName, CertificatePolicy certificatePolicy, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateOperation certificateOperation;

            try
            {
                certificateOperation = this.keyVaultClient.CreateCertificateAsync(vaultAddress, certificateName, certificatePolicy, null, tags).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificateOperation;
        }

        public CertificateBundle UpdateCertificate(string vaultName, string certificateName, string certificateVersion, CertificateAttributes certificateAttributes, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");

            var certificateIdentifier = new CertificateIdentifier(this.vaultUriHelper.CreateVaultAddress(vaultName), certificateName, certificateVersion);

            CertificateBundle certificateBundle;
            try
            {
                certificateBundle = this.keyVaultClient.UpdateCertificateAsync(
                    certificateIdentifier.Identifier, null, certificateAttributes, tags).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificateBundle;
        }

        public CertificateBundle DeleteCertificate(string vaultName, string certName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException("certName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateBundle certBundle;

            try
            {
                certBundle = this.keyVaultClient.DeleteCertificateAsync(vaultAddress, certName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certBundle;
        }

        public CertificateOperation GetCertificateOperation(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateOperation certificateOperation;

            try
            {
                certificateOperation = this.keyVaultClient.GetCertificateOperationAsync(vaultAddress, certificateName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificateOperation;
        }

        public CertificateOperation CancelCertificateOperation(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateOperation certificateOperation;

            try
            {
                certificateOperation = this.keyVaultClient.UpdateCertificateOperationAsync(vaultAddress, certificateName, true).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificateOperation;
        }

        public CertificateOperation DeleteCertificateOperation(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateOperation certificateOperation;

            try
            {
                certificateOperation = this.keyVaultClient.DeleteCertificateOperationAsync(vaultAddress, certificateName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificateOperation;
        }

        public Secret DeleteSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            SecretBundle secret;
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

            BackupKeyResult backupKeyResult;
            try
            {
                backupKeyResult = this.keyVaultClient.BackupKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            File.WriteAllBytes(outputBlobPath, backupKeyResult.Value);

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

            Azure.KeyVault.Models.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.RestoreKeyAsync(vaultAddress, backupBlob).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new KeyBundle(keyBundle, this.vaultUriHelper);
        }

        public CertificatePolicy GetCertificatePolicy(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificatePolicy certificatePolicy;
            try
            {
                certificatePolicy = this.keyVaultClient.GetCertificatePolicyAsync(vaultAddress, certificateName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificatePolicy;
        }

        public CertificatePolicy UpdateCertificatePolicy(string vaultName, string certificateName, CertificatePolicy certificatePolicy)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException("certificateName");
            if (certificatePolicy == null)
                throw new ArgumentNullException("certificatePolicy");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            CertificatePolicy resultantCertificatePolicy;

            try
            {
                resultantCertificatePolicy = this.keyVaultClient.UpdateCertificatePolicyAsync(vaultAddress, certificateName, certificatePolicy).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return resultantCertificatePolicy;
        }

        public IssuerBundle GetCertificateIssuer(string vaultName, string issuerName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(issuerName))
                throw new ArgumentNullException("issuerName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            IssuerBundle certificateIssuer;
            try
            {
                certificateIssuer = this.keyVaultClient.GetCertificateIssuerAsync(vaultAddress, issuerName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return certificateIssuer;
        }

        public IEnumerable<CertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<CertificateIssuerItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetCertificateIssuersAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetCertificateIssuersNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<CertificateIssuerIdentityItem>() :
                    result.Select(issuerItem => new CertificateIssuerIdentityItem(issuerItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IssuerBundle SetCertificateIssuer(
            string vaultName,
            string issuerName,
            string issuerProvider,
            string accountId,
            SecureString apiKey,
            KeyVaultCertificateOrganizationDetails organizationDetails)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(issuerName))
                throw new ArgumentNullException("issuerName");
            if (string.IsNullOrEmpty(issuerProvider))
                throw new ArgumentNullException("issuerProvider");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            var issuer = new IssuerBundle
            {
                Provider = issuerProvider,
                OrganizationDetails = organizationDetails == null ? null : organizationDetails.ToOrganizationDetails(),
            };

            if (!string.IsNullOrEmpty(accountId) || apiKey != null)
            {
                issuer.Credentials = new IssuerCredentials
                {
                    AccountId = accountId,
                    Password = apiKey == null ? null : apiKey.ConvertToString(),
                };
            }

            IssuerBundle resultantIssuer;
            try
            {
                resultantIssuer = this.keyVaultClient.SetCertificateIssuerAsync(
                    vaultAddress,
                    issuerName,
                    issuer.Provider,
                    issuer.Credentials,
                    issuer.OrganizationDetails,
                    issuer.Attributes).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return resultantIssuer;
        }        

        public IssuerBundle DeleteCertificateIssuer(string vaultName, string issuerName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(issuerName))
                throw new ArgumentNullException("issuerName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            IssuerBundle issuer;

            try
            {
                issuer = this.keyVaultClient.DeleteCertificateIssuerAsync(vaultAddress, issuerName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return issuer;
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

﻿// ----------------------------------------------------------------------------------
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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Rest.Azure;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class KeyVaultDataServiceClient : IKeyVaultDataServiceClient
    {
        public KeyVaultDataServiceClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Environment == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidAzureEnvironment);

            var credential = new DataServiceCredential(authFactory, context, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            this.keyVaultClient = new KeyVaultClient(credential.OnAuthentication);


            this.vaultUriHelper = new VaultUriHelper(
                context.Environment.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix));
        }

        /// <summary>
        /// Parameterless constructor for Mocking.
        /// </summary>
        public KeyVaultDataServiceClient()
        {
        }

        public PSKeyVaultKey CreateKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (keyAttributes == null)
                throw new ArgumentNullException(nameof(keyAttributes));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);
            var attributes = (Azure.KeyVault.Models.KeyAttributes)keyAttributes;

            Azure.KeyVault.Models.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.CreateKeyAsync(
                    vaultBaseUrl: vaultAddress,
                    keyName: keyName,
                    kty: keyAttributes.KeyType,
                    keySize: size,
                    keyOps: keyAttributes.KeyOps == null ? null : new List<string> (keyAttributes.KeyOps),
                    keyAttributes: attributes,
                    tags: keyAttributes.TagsDirectionary).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(keyBundle, this.vaultUriHelper);
        }        

        public PSKeyVaultCertificate MergeCertificate(string vaultName, string certName, X509Certificate2Collection certs, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException(nameof(certName));
            if (null == certs)
                throw new ArgumentNullException(nameof(certs));

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

            return new PSKeyVaultCertificate(certBundle);

        }

        public PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, string base64CertColl, SecureString certPassword, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException(nameof(certName));
            if (string.IsNullOrEmpty(base64CertColl))
                throw new ArgumentNullException(nameof(base64CertColl));

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

            return new PSKeyVaultCertificate(certBundle);
        }

        public PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, X509Certificate2Collection certificateCollection, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException(nameof(certName));
            if (null == certificateCollection)
                throw new ArgumentNullException(nameof(certificateCollection));

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

            return new PSKeyVaultCertificate(certBundle);
        }

        public PSKeyVaultKey ImportKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, JsonWebKey webKey, bool? importToHsm)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (keyAttributes == null)
                throw new ArgumentNullException(nameof(keyAttributes));
            if (webKey == null)
                throw new ArgumentNullException(nameof(webKey));
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

            return new PSKeyVaultKey(keyBundle, this.vaultUriHelper);
        }

        public PSKeyVaultKey UpdateKey(string vaultName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (keyAttributes == null)
                throw new ArgumentNullException(nameof(keyAttributes));
            
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

            return new PSKeyVaultKey(keyBundle, this.vaultUriHelper);
        }

        public IEnumerable<PSKeyVaultCertificateContact> GetCertificateContacts(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Contacts contacts;

            try
            {
                contacts = this.keyVaultClient.GetCertificateContactsAsync(vaultAddress).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            if (contacts == null ||
                contacts.ContactList == null)
            {
                return null;
            }

            var contactsModel = new List<PSKeyVaultCertificateContact>();

            foreach (var contact in contacts.ContactList)
            {
                contactsModel.Add(PSKeyVaultCertificateContact.FromKVCertificateContact(contact, vaultName));
            }

            return contactsModel;
        }

        public PSKeyVaultCertificate GetCertificate(string vaultName, string certName, string certificateVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException(nameof(certName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateBundle certBundle;

            try
            {
                certBundle = this.keyVaultClient.GetCertificateAsync(vaultAddress, certName, certificateVersion).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultCertificate(certBundle);
        }

        public PSKeyVaultKey GetKey(string vaultName, string keyName, string keyVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.KeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.GetKeyAsync(vaultAddress, keyName, keyVersion).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(keyBundle, this.vaultUriHelper);
        }

        public IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificates(KeyVaultCertificateFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<CertificateItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetCertificatesAsync(vaultAddress, maxresults: null, includePending: options.IncludePending).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetCertificatesNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<PSKeyVaultCertificateIdentityItem>() :
                    result.Select((certItem) => { return new PSKeyVaultCertificateIdentityItem(certItem, this.vaultUriHelper); });
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IEnumerable<PSKeyVaultCertificateIdentityItem> GetCertificateVersions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

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
                return result.Select((certificateItem) => new PSKeyVaultCertificateIdentityItem(certificateItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IEnumerable<PSKeyVaultKeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

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
                return (result == null) ? new List<PSKeyVaultKeyIdentityItem>() :
                    result.Select((keyItem) => new PSKeyVaultKeyIdentityItem(keyItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

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
                return result.Select((keyItem) => new PSKeyVaultKeyIdentityItem(keyItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public PSDeletedKeyVaultKey DeleteKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.DeletedKeyBundle keyBundle;
            try
            {
                keyBundle = this.keyVaultClient.DeleteKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultKey(keyBundle, this.vaultUriHelper);
        }

        public IEnumerable<PSKeyVaultCertificateContact> SetCertificateContacts(string vaultName, IEnumerable<PSKeyVaultCertificateContact> contacts)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            List<Contact> contactList = null;
            if (contacts != null)
            {
                contactList = new List<Contact>();
                foreach (var psContact in contacts)
                {
                    contactList.Add(new Contact { EmailAddress = psContact.Email });
                }
            }
            Contacts inputContacts = new Contacts { ContactList = contactList };

            Contacts outputContacts;

            try
            {
                outputContacts = this.keyVaultClient.SetCertificateContactsAsync(vaultAddress, inputContacts).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            if (outputContacts == null ||
                outputContacts.ContactList == null)
            {
                return null;
            }

            var contactsModel = new List<PSKeyVaultCertificateContact>();

            foreach (var contact in outputContacts.ContactList)
            {
                contactsModel.Add(PSKeyVaultCertificateContact.FromKVCertificateContact(contact, vaultName));
            }

            return contactsModel;
        }

        public PSKeyVaultSecret SetSecret(string vaultName, string secretName, SecureString secretValue, PSKeyVaultSecretAttributes secretAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException(nameof(secretName));
            if (secretValue == null)
                throw new ArgumentNullException(nameof(secretValue));
            if (secretAttributes == null)
                throw new ArgumentNullException(nameof(secretAttributes));

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

            return new PSKeyVaultSecret(secret, this.vaultUriHelper);
        }

        public PSKeyVaultSecret UpdateSecret(string vaultName, string secretName, string secretVersion, PSKeyVaultSecretAttributes secretAttributes)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException(nameof(secretName));
            if (secretAttributes == null)
                throw new ArgumentNullException(nameof(secretAttributes));

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

            return new PSKeyVaultSecret(secret, this.vaultUriHelper);
        }

        public PSKeyVaultSecret GetSecret(string vaultName, string secretName, string secretVersion)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException(nameof(secretName));

            var secretIdentifier = new SecretIdentifier(this.vaultUriHelper.CreateVaultAddress(vaultName), secretName, secretVersion);
            SecretBundle secret;
            try
            {
                secret = this.keyVaultClient.GetSecretAsync(secretIdentifier.Identifier).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultSecret(secret, this.vaultUriHelper);
        }

        public IEnumerable<PSKeyVaultSecretIdentityItem> GetSecrets(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
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
                return (result == null) ? new List<PSKeyVaultSecretIdentityItem>() :
                    result.Select((secretItem) => new PSKeyVaultSecretIdentityItem(secretItem, this.vaultUriHelper));            
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IEnumerable<PSKeyVaultSecretIdentityItem> GetSecretVersions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
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
                return result.Select((secretItem) => new PSKeyVaultSecretIdentityItem(secretItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public PSKeyVaultCertificateOperation EnrollCertificate(string vaultName, string certificateName, CertificatePolicy certificatePolicy, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));

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

            return PSKeyVaultCertificateOperation.FromCertificateOperation(certificateOperation);
        }

        public PSKeyVaultCertificate UpdateCertificate(string vaultName, string certificateName, string certificateVersion, CertificateAttributes certificateAttributes, IDictionary<string, string> tags)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));

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

            return new PSKeyVaultCertificate(certificateBundle);
        }

        public PSDeletedKeyVaultCertificate DeleteCertificate(string vaultName, string certName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException(nameof(certName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            DeletedCertificateBundle certBundle;

            try
            {
                certBundle = this.keyVaultClient.DeleteCertificateAsync(vaultAddress, certName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultCertificate(certBundle);
        }

        public void PurgeCertificate(string vaultName, string certName)
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrEmpty( certName ) )
                throw new ArgumentNullException( "certName" );

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            try
            {
                this.keyVaultClient.PurgeDeletedCertificateAsync( vaultAddress, certName ).GetAwaiter( ).GetResult( );
            }
            catch (Exception ex)
            {
                throw GetInnerException( ex );
            }
        }

        public PSKeyVaultCertificateOperation GetCertificateOperation(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateOperation certificateOperation;

            try
            {
                certificateOperation = this.keyVaultClient.GetCertificateOperationAsync(vaultAddress, certificateName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return PSKeyVaultCertificateOperation.FromCertificateOperation(certificateOperation);
        }

        public PSKeyVaultCertificateOperation CancelCertificateOperation(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));

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

            return PSKeyVaultCertificateOperation.FromCertificateOperation(certificateOperation);
        }

        public PSKeyVaultCertificateOperation DeleteCertificateOperation(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));

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

            return PSKeyVaultCertificateOperation.FromCertificateOperation(certificateOperation);
        }

        public PSDeletedKeyVaultSecret DeleteSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException(nameof(secretName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            DeletedSecretBundle secret;
            try
            {
                secret = this.keyVaultClient.DeleteSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultSecret(secret, this.vaultUriHelper);
        }

        public string BackupKey(string vaultName, string keyName, string outputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (string.IsNullOrEmpty(outputBlobPath))
                throw new ArgumentNullException(nameof(outputBlobPath));

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

        public PSKeyVaultKey RestoreKey(string vaultName, string inputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(inputBlobPath))
                throw new ArgumentNullException(nameof(inputBlobPath));

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

            return new PSKeyVaultKey(keyBundle, this.vaultUriHelper);
        }

        public string BackupSecret( string vaultName, string secretName, string outputBlobPath )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException(nameof(vaultName));
            if ( string.IsNullOrEmpty( secretName ) )
                throw new ArgumentNullException(nameof(secretName));
            if ( string.IsNullOrEmpty( outputBlobPath ) )
                throw new ArgumentNullException(nameof(outputBlobPath));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            BackupSecretResult backupSecretResult;
            try
            {
                backupSecretResult = this.keyVaultClient.BackupSecretAsync( vaultAddress, secretName ).GetAwaiter( ).GetResult( );
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            File.WriteAllBytes( outputBlobPath, backupSecretResult.Value );

            return outputBlobPath;
        }

        public PSKeyVaultSecret RestoreSecret( string vaultName, string inputBlobPath )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException(nameof(vaultName));
            if ( string.IsNullOrEmpty( inputBlobPath ) )
                throw new ArgumentNullException(nameof(inputBlobPath));

            var backupBlob = File.ReadAllBytes(inputBlobPath);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.SecretBundle secretBundle;
            try
            {
                secretBundle = this.keyVaultClient.RestoreSecretAsync( vaultAddress, backupBlob ).GetAwaiter( ).GetResult( );
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultSecret( secretBundle, this.vaultUriHelper );
        }

        public PSKeyVaultCertificatePolicy GetCertificatePolicy(string vaultName, string certificateName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificatePolicy certificatePolicy;
            try
            {
                certificatePolicy = this.keyVaultClient.GetCertificatePolicyAsync(vaultAddress, certificateName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return PSKeyVaultCertificatePolicy.FromCertificatePolicy(certificatePolicy);
        }

        public PSKeyVaultCertificatePolicy UpdateCertificatePolicy(string vaultName, string certificateName, CertificatePolicy certificatePolicy)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));
            if (certificatePolicy == null)
                throw new ArgumentNullException(nameof(certificatePolicy));

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

            return PSKeyVaultCertificatePolicy.FromCertificatePolicy(certificatePolicy);
        }

        public PSKeyVaultCertificateIssuer GetCertificateIssuer(string vaultName, string issuerName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(issuerName))
                throw new ArgumentNullException(nameof(issuerName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            IssuerBundle certificateIssuer;
            try
            {
                certificateIssuer = this.keyVaultClient.GetCertificateIssuerAsync(vaultAddress, issuerName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return PSKeyVaultCertificateIssuer.FromIssuer(certificateIssuer);
        }

        public IEnumerable<PSKeyVaultCertificateIssuerIdentityItem> GetCertificateIssuers(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

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
                return (result == null) ? new List<PSKeyVaultCertificateIssuerIdentityItem>() :
                    result.Select(issuerItem => new PSKeyVaultCertificateIssuerIdentityItem(issuerItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public PSKeyVaultCertificateIssuer SetCertificateIssuer(
            string vaultName,
            string issuerName,
            string issuerProvider,
            string accountId,
            SecureString apiKey,
            PSKeyVaultCertificateOrganizationDetails organizationDetails)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(issuerName))
                throw new ArgumentNullException(nameof(issuerName));
            if (string.IsNullOrEmpty(issuerProvider))
                throw new ArgumentNullException(nameof(issuerProvider));

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

            return PSKeyVaultCertificateIssuer.FromIssuer(resultantIssuer);
        }        

        public PSKeyVaultCertificateIssuer DeleteCertificateIssuer(string vaultName, string issuerName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(issuerName))
                throw new ArgumentNullException(nameof(issuerName));

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

            return PSKeyVaultCertificateIssuer.FromIssuer(issuer);
        }

        #region Managed Storage Accounts
        public IEnumerable<PSKeyVaultManagedStorageAccountIdentityItem> GetManagedStorageAccounts( KeyVaultObjectFilterOptions options )
        {
            if ( options == null )
                throw new ArgumentNullException( "options" );
            if ( string.IsNullOrEmpty( options.VaultName ) )
                throw new ArgumentException( KeyVaultProperties.Resources.InvalidVaultName );

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress( options.VaultName );

            try
            {
                IPage<StorageAccountItem> result;

                if ( string.IsNullOrEmpty( options.NextLink ) )
                    result = this.keyVaultClient.GetStorageAccountsAsync( vaultAddress ).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetStorageAccountsNextAsync( options.NextLink ).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return result.Select( ( storageAccountItem ) => new PSKeyVaultManagedStorageAccountIdentityItem( storageAccountItem, this.vaultUriHelper ) );
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }
        }

        public PSKeyVaultManagedStorageAccount GetManagedStorageAccount( string vaultName, string managedStorageAccountName )
        {
            if ( string.IsNullOrWhiteSpace( vaultName ) ) throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrWhiteSpace( managedStorageAccountName ) ) throw new ArgumentNullException( "managedStorageAccountName" );

            StorageBundle storageBundle;

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );

            try
            {
                storageBundle = this.keyVaultClient.GetStorageAccountAsync( vaultAddress, managedStorageAccountName ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultManagedStorageAccount( storageBundle, this.vaultUriHelper );
        }

        public PSKeyVaultManagedStorageAccount SetManagedStorageAccount( string vaultName, string managedStorageAccountName, string storageResourceId,
            string activeKeyName, bool? autoRegenerateKey, TimeSpan? regenerationPeriod,
            PSKeyVaultManagedStorageAccountAttributes managedStorageAccountAttributes, Hashtable tags )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrEmpty( managedStorageAccountName ) )
                throw new ArgumentNullException( "managedStorageAccountName" );
            if ( string.IsNullOrEmpty( storageResourceId ) )
                throw new ArgumentNullException( "storageResourceId" );
            if ( string.IsNullOrEmpty( activeKeyName ) )
                throw new ArgumentNullException( "activeKeyName" );

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );
            var attributes = managedStorageAccountAttributes == null ? null : new Azure.KeyVault.Models.StorageAccountAttributes
            {
                Enabled = managedStorageAccountAttributes.Enabled,
            };

            Azure.KeyVault.Models.StorageBundle storageBundle;
            try
            {
                storageBundle =
                    this.keyVaultClient.SetStorageAccountAsync( vaultAddress, managedStorageAccountName,
                        storageResourceId, activeKeyName,
                        autoRegenerateKey ?? true,
                        regenerationPeriod == null ? null : XmlConvert.ToString( regenerationPeriod.Value ), attributes,
                        tags == null ? null : tags.ConvertToDictionary() ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultManagedStorageAccount( storageBundle, this.vaultUriHelper );
        }

        public PSKeyVaultManagedStorageAccount UpdateManagedStorageAccount( string vaultName, string managedStorageAccountName, string activeKeyName,
            bool? autoRegenerateKey, TimeSpan? regenerationPeriod, PSKeyVaultManagedStorageAccountAttributes managedStorageAccountAttributes,
            Hashtable tags )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrEmpty( managedStorageAccountName ) )
                throw new ArgumentNullException( "managedStorageAccountName" );

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );
            var attributes = managedStorageAccountAttributes == null ? null : new Azure.KeyVault.Models.StorageAccountAttributes
            {
                Enabled = managedStorageAccountAttributes.Enabled,
            };

            Azure.KeyVault.Models.StorageBundle storageBundle;
            try
            {
                storageBundle =
                    this.keyVaultClient.UpdateStorageAccountAsync( vaultAddress, managedStorageAccountName,
                        activeKeyName,
                        autoRegenerateKey,
                        regenerationPeriod == null ? null : XmlConvert.ToString( regenerationPeriod.Value ), attributes,
                        tags == null ? null : tags.ConvertToDictionary() ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultManagedStorageAccount( storageBundle, this.vaultUriHelper );
        }

        public PSDeletedKeyVaultManagedStorageAccount DeleteManagedStorageAccount( string vaultName, string managedStorageAccountName )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrEmpty( managedStorageAccountName ) )
                throw new ArgumentNullException( "managedStorageAccountName" );

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );

            Azure.KeyVault.Models.DeletedStorageBundle storageBundle;
            try
            {
                storageBundle = this.keyVaultClient.DeleteStorageAccountAsync( vaultAddress, managedStorageAccountName ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSDeletedKeyVaultManagedStorageAccount( storageBundle, this.vaultUriHelper );
        }

        public PSKeyVaultManagedStorageAccount RegenerateManagedStorageAccountKey( string vaultName, string managedStorageAccountName, string keyName )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrEmpty( managedStorageAccountName ) )
                throw new ArgumentNullException( "managedStorageAccountName" );
            if ( string.IsNullOrEmpty( keyName ) )
                throw new ArgumentNullException( "keyName" );

            Azure.KeyVault.Models.StorageBundle storageBundle;
            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );

            try
            {
                storageBundle = this.keyVaultClient.RegenerateStorageAccountKeyAsync( vaultAddress, managedStorageAccountName, keyName ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultManagedStorageAccount( storageBundle, this.vaultUriHelper );
        }

        public PSKeyVaultManagedStorageSasDefinition GetManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName )
        {
            if ( string.IsNullOrWhiteSpace( vaultName ) ) throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrWhiteSpace( managedStorageAccountName ) ) throw new ArgumentNullException( "managedStorageAccountName" );
            if ( string.IsNullOrWhiteSpace( sasDefinitionName ) ) throw new ArgumentNullException( "sasDefinitionName" );

            SasDefinitionBundle storagesasDefinitionBundle;

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );

            try
            {
                storagesasDefinitionBundle = this.keyVaultClient.GetSasDefinitionAsync( vaultAddress, managedStorageAccountName, sasDefinitionName ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultManagedStorageSasDefinition( storagesasDefinitionBundle, this.vaultUriHelper );
        }

        public IEnumerable<PSKeyVaultManagedStorageSasDefinitionIdentityItem> GetManagedStorageSasDefinitions( KeyVaultStorageSasDefinitiontFilterOptions options )
        {
            if ( options == null )
                throw new ArgumentNullException( "options" );
            if ( string.IsNullOrEmpty( options.VaultName ) )
                throw new ArgumentException( KeyVaultProperties.Resources.InvalidVaultName );
            if ( string.IsNullOrEmpty( options.AccountName ) )
                throw new ArgumentException( KeyVaultProperties.Resources.InvalidManagedStorageAccountName );

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress( options.VaultName );

            try
            {
                IPage<SasDefinitionItem> result;

                if ( string.IsNullOrEmpty( options.NextLink ) )
                    result = this.keyVaultClient.GetSasDefinitionsAsync( vaultAddress, options.AccountName ).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetSasDefinitionsNextAsync( options.NextLink ).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return result.Select( ( storageAccountItem ) => new PSKeyVaultManagedStorageSasDefinitionIdentityItem( storageAccountItem, this.vaultUriHelper ) );
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }
        }

        public PSKeyVaultManagedStorageSasDefinition SetManagedStorageSasDefinition( 
            string vaultName, 
            string managedStorageAccountName, 
            string sasDefinitionName,
            string templateUri,
            string sasType, 
            string validityPeriod,
            PSKeyVaultManagedStorageSasDefinitionAttributes sasDefinitionAttributes, 
            Hashtable tags )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException(nameof(vaultName));
            if ( string.IsNullOrEmpty( managedStorageAccountName ) )
                throw new ArgumentNullException(nameof(managedStorageAccountName));
            if (string.IsNullOrEmpty(templateUri))
                throw new ArgumentNullException(nameof(templateUri));
            if (string.IsNullOrEmpty(sasType))
                throw new ArgumentNullException(nameof(sasType));
            if (string.IsNullOrEmpty(validityPeriod))
                throw new ArgumentNullException(nameof(validityPeriod));
            if ( string.IsNullOrEmpty( sasDefinitionName ) )
                throw new ArgumentNullException(nameof(sasDefinitionName));

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );
            var attributes = sasDefinitionAttributes == null ? null : new Azure.KeyVault.Models.SasDefinitionAttributes
            {
                Enabled = sasDefinitionAttributes.Enabled,
            };

            Azure.KeyVault.Models.SasDefinitionBundle sasDefinitionBundle;
            try
            {
                sasDefinitionBundle =
                    this.keyVaultClient.SetSasDefinitionAsync( 
                        vaultBaseUrl: vaultAddress, 
                        storageAccountName: managedStorageAccountName,
                        sasDefinitionName: sasDefinitionName,
                        templateUri: templateUri,
                        sasType: sasType,
                        validityPeriod:validityPeriod,
                        sasDefinitionAttributes: attributes,
                        tags: tags == null ? null : tags.ConvertToDictionary() ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultManagedStorageSasDefinition( sasDefinitionBundle, this.vaultUriHelper );
        }

        public PSDeletedKeyVaultManagedStorageSasDefinition DeleteManagedStorageSasDefinition( string vaultName, string managedStorageAccountName, string sasDefinitionName )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( "vaultName" );
            if ( string.IsNullOrEmpty( managedStorageAccountName ) )
                throw new ArgumentNullException( "managedStorageAccountName" );
            if ( string.IsNullOrEmpty( sasDefinitionName ) )
                throw new ArgumentNullException( "sasDefinitionName" );

            var vaultAddress = this.vaultUriHelper.CreateVaultAddress( vaultName );

            Azure.KeyVault.Models.DeletedSasDefinitionBundle sasDefinitionBundle;
            try
            {
                sasDefinitionBundle =
                    this.keyVaultClient.DeleteSasDefinitionAsync( vaultAddress,
                        managedStorageAccountName,
                        sasDefinitionName ).GetAwaiter().GetResult();
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSDeletedKeyVaultManagedStorageSasDefinition( sasDefinitionBundle, this.vaultUriHelper );
        }

        #endregion


        private Exception GetInnerException(Exception exception)
        {
            while (exception.InnerException != null) exception = exception.InnerException;
            return exception;
        }

        public PSDeletedKeyVaultKey GetDeletedKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.DeletedKeyBundle deletedKeyBundle;
            try
            {
                deletedKeyBundle = this.keyVaultClient.GetDeletedKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if(ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultKey(deletedKeyBundle, this.vaultUriHelper);
        }

        public IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetDeletedKeys(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<DeletedKeyItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetDeletedKeysAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetDeletedKeysNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<PSDeletedKeyVaultKeyIdentityItem>() :
                    result.Select((deletedKeyItem) => new PSDeletedKeyVaultKeyIdentityItem(deletedKeyItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public PSDeletedKeyVaultSecret GetDeletedSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            DeletedSecretBundle deletedSecret;
            try
            {
                deletedSecret = this.keyVaultClient.GetDeletedSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultSecret(deletedSecret, this.vaultUriHelper);
        }

        public IEnumerable<PSDeletedKeyVaultSecretIdentityItem> GetDeletedSecrets(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");
            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<DeletedSecretItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetDeletedSecretsAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetDeletedSecretsNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<PSDeletedKeyVaultSecretIdentityItem>() :
                    result.Select((deletedSecretItem) => new PSDeletedKeyVaultSecretIdentityItem(deletedSecretItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public void PurgeKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            try
            {
                this.keyVaultClient.PurgeDeletedKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public void PurgeSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            try
            {
                this.keyVaultClient.PurgeDeletedSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public PSKeyVaultKey RecoverKey(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Microsoft.Azure.KeyVault.Models.KeyBundle recoveredKey;
            try
            {
                recoveredKey = this.keyVaultClient.RecoverDeletedKeyAsync(vaultAddress, keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(recoveredKey, this.vaultUriHelper);
        }

        public PSKeyVaultSecret RecoverSecret(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            SecretBundle recoveredSecret;
            try
            {
                recoveredSecret = this.keyVaultClient.RecoverDeletedSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultSecret(recoveredSecret, this.vaultUriHelper);
        }

        public PSDeletedKeyVaultCertificate GetDeletedCertificate( string vaultName, string certName )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( nameof(vaultName) );
            if ( string.IsNullOrEmpty( certName ) )
                throw new ArgumentNullException( nameof(certName) );

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            DeletedCertificateBundle deletedCertificate;
            try
            {
                deletedCertificate = this.keyVaultClient.GetDeletedCertificateAsync( vaultAddress, certName ).GetAwaiter( ).GetResult( );
            }
            catch ( KeyVaultErrorException ex )
            {
                if ( ex.Response.StatusCode == HttpStatusCode.NotFound )
                    return null;
                else
                    throw;
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSDeletedKeyVaultCertificate(deletedCertificate);
        }

        public IEnumerable<PSDeletedKeyVaultCertificateIdentityItem> GetDeletedCertificates( KeyVaultCertificateFilterOptions options )
        {
            if ( options == null )
                throw new ArgumentNullException( nameof( options ) );
            if ( string.IsNullOrEmpty( options.VaultName ) )
                throw new ArgumentException( KeyVaultProperties.Resources.InvalidVaultName );

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<DeletedCertificateItem> result;

                if ( string.IsNullOrEmpty( options.NextLink ) )
                    result = this.keyVaultClient.GetDeletedCertificatesAsync( vaultAddress, maxresults: null, includePending: options.IncludePending ).GetAwaiter( ).GetResult( );
                else
                    result = this.keyVaultClient.GetDeletedCertificatesNextAsync( options.NextLink ).GetAwaiter( ).GetResult( );

                options.NextLink = result.NextPageLink;
                return ( result == null ) ? new List<PSDeletedKeyVaultCertificateIdentityItem>( ) :
                    result.Select( ( deletedItem ) => new PSDeletedKeyVaultCertificateIdentityItem( deletedItem, this.vaultUriHelper ) );
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }
        }

        public PSKeyVaultCertificate RecoverCertificate( string vaultName, string certName )
        {
            if ( string.IsNullOrEmpty( vaultName ) )
                throw new ArgumentNullException( nameof( vaultName ) );
            if ( string.IsNullOrEmpty( certName ) )
                throw new ArgumentNullException( nameof( certName ) );

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            CertificateBundle recoveredCertificate;
            try
            {
                recoveredCertificate = this.keyVaultClient.RecoverDeletedCertificateAsync( vaultAddress, certName ).GetAwaiter( ).GetResult( );
            }
            catch ( Exception ex )
            {
                throw GetInnerException( ex );
            }

            return new PSKeyVaultCertificate(recoveredCertificate);
        }

        public string BackupCertificate(string vaultName, string certificateName, string outputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certificateName))
                throw new ArgumentNullException(nameof(certificateName));
            if (string.IsNullOrEmpty(outputBlobPath))
                throw new ArgumentNullException(nameof(outputBlobPath));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            BackupCertificateResult backupCertificateResult;
            try
            {
                backupCertificateResult = this.keyVaultClient.BackupCertificateAsync(vaultAddress, certificateName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            File.WriteAllBytes(outputBlobPath, backupCertificateResult.Value);

            return outputBlobPath;
        }

        public PSKeyVaultCertificate RestoreCertificate(string vaultName, string inputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(inputBlobPath))
                throw new ArgumentNullException(nameof(inputBlobPath));

            var backupBlob = File.ReadAllBytes(inputBlobPath);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.CertificateBundle certificateBundle;
            try
            {
                certificateBundle = this.keyVaultClient.RestoreCertificateAsync(vaultAddress, backupBlob).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultCertificate(certificateBundle, this.vaultUriHelper);
        }

        public PSDeletedKeyVaultManagedStorageAccount GetDeletedManagedStorageAccount(string vaultName, string managedStorageAccountName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(managedStorageAccountName))
                throw new ArgumentNullException(nameof(managedStorageAccountName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.DeletedStorageBundle deletedStorageBundle;
            try
            {
                deletedStorageBundle = this.keyVaultClient.GetDeletedStorageAccountAsync(vaultAddress, managedStorageAccountName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultManagedStorageAccount(deletedStorageBundle, this.vaultUriHelper);
        }

        public PSDeletedKeyVaultManagedStorageSasDefinition GetDeletedManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(managedStorageAccountName))
                throw new ArgumentNullException(nameof(managedStorageAccountName));
            if (string.IsNullOrWhiteSpace(sasDefinitionName))
                throw new ArgumentNullException(nameof(sasDefinitionName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.DeletedSasDefinitionBundle deletedSasDefinitionBundle;
            try
            {
                deletedSasDefinitionBundle = this.keyVaultClient.GetDeletedSasDefinitionAsync(vaultAddress, managedStorageAccountName, sasDefinitionName).GetAwaiter().GetResult();
            }
            catch (KeyVaultErrorException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultManagedStorageSasDefinition(deletedSasDefinitionBundle, this.vaultUriHelper);
        }

        public IEnumerable<PSDeletedKeyVaultManagedStorageAccountIdentityItem> GetDeletedManagedStorageAccounts(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<DeletedStorageAccountItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetDeletedStorageAccountsAsync(vaultAddress).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetDeletedStorageAccountsNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<PSDeletedKeyVaultManagedStorageAccountIdentityItem>() :
                    result.Select((deletedItem) => new PSDeletedKeyVaultManagedStorageAccountIdentityItem(deletedItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public IEnumerable<PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem> GetDeletedManagedStorageSasDefinitions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            if (String.IsNullOrWhiteSpace(options.Name))
                throw new ArgumentNullException(KeyVaultProperties.Resources.InvalidManagedStorageAccountName);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(options.VaultName);

            try
            {
                IPage<DeletedSasDefinitionItem> result;

                if (string.IsNullOrEmpty(options.NextLink))
                    result = this.keyVaultClient.GetDeletedSasDefinitionsAsync(vaultAddress, options.Name).GetAwaiter().GetResult();
                else
                    result = this.keyVaultClient.GetDeletedSasDefinitionsNextAsync(options.NextLink).GetAwaiter().GetResult();

                options.NextLink = result.NextPageLink;
                return (result == null) ? new List<PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem>() :
                    result.Select((deletedItem) => new PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem(deletedItem, this.vaultUriHelper));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public PSKeyVaultManagedStorageAccount RecoverManagedStorageAccount(string vaultName, string deletedManagedStorageAccountName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(deletedManagedStorageAccountName))
                throw new ArgumentNullException(nameof(deletedManagedStorageAccountName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            StorageBundle recoveredStorageBundle;
            try
            {
                recoveredStorageBundle = this.keyVaultClient.RecoverDeletedStorageAccountAsync(vaultAddress, deletedManagedStorageAccountName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultManagedStorageAccount(recoveredStorageBundle, this.vaultUriHelper);
        }

        public PSKeyVaultManagedStorageSasDefinition RecoverManagedStorageSasDefinition(string vaultName, string managedStorageAccountName, string sasDefinitionName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(managedStorageAccountName))
                throw new ArgumentNullException(nameof(managedStorageAccountName));
            if (string.IsNullOrWhiteSpace(sasDefinitionName))
                throw new ArgumentNullException(nameof(sasDefinitionName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            SasDefinitionBundle recoveredSasDefinitionBundle;
            try
            {
                recoveredSasDefinitionBundle = this.keyVaultClient.RecoverDeletedSasDefinitionAsync(vaultAddress, managedStorageAccountName, sasDefinitionName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultManagedStorageSasDefinition(recoveredSasDefinitionBundle, this.vaultUriHelper);
        }

        public void PurgeManagedStorageAccount(string vaultName, string managedStorageAccountName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(managedStorageAccountName))
                throw new ArgumentNullException(nameof(managedStorageAccountName));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            try
            {
                this.keyVaultClient.PurgeDeletedStorageAccountAsync(vaultAddress, managedStorageAccountName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public string BackupManagedStorageAccount(string vaultName, string managedStorageAccountName, string outputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(managedStorageAccountName))
                throw new ArgumentNullException(nameof(managedStorageAccountName));
            if (string.IsNullOrEmpty(outputBlobPath))
                throw new ArgumentNullException(nameof(outputBlobPath));

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            BackupStorageResult backupStorageAccountResult;
            try
            {
                backupStorageAccountResult = this.keyVaultClient.BackupStorageAccountAsync(vaultAddress, managedStorageAccountName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            File.WriteAllBytes(outputBlobPath, backupStorageAccountResult.Value);

            return outputBlobPath;
        }

        public PSKeyVaultManagedStorageAccount RestoreManagedStorageAccount(string vaultName, string inputBlobPath)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(inputBlobPath))
                throw new ArgumentNullException(nameof(inputBlobPath));

            var backupBlob = File.ReadAllBytes(inputBlobPath);

            string vaultAddress = this.vaultUriHelper.CreateVaultAddress(vaultName);

            Azure.KeyVault.Models.StorageBundle storageAccountBundle;
            try
            {
                storageAccountBundle = this.keyVaultClient.RestoreStorageAccountAsync(vaultAddress, backupBlob).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultManagedStorageAccount(storageAccountBundle, this.vaultUriHelper);
        }

        private VaultUriHelper vaultUriHelper;
        private KeyVaultClient keyVaultClient;
    }
}

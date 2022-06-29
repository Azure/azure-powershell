using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2VaultClient
    {
        private Track2TokenCredential _credential;
        private VaultUriHelper _vaultUriHelper;

        // After a track 2 client is created, the vault / hsm uri associated to it cannot be changed
        // however azure powershell may deal with multiple vaults / hsms
        // so I choose to create a new client for every new request
        // todo: consider caching clients
        private KeyClient CreateKeyClient(string vaultName) => new KeyClient(_vaultUriHelper.CreateVaultUri(vaultName), _credential);
        private CryptographyClient CreateCryptographyClient(string keyId) => new CryptographyClient(new Uri(keyId), _credential);
        private CertificateClient CreateCertificateClient(string vaultName) => new CertificateClient(_vaultUriHelper.CreateVaultUri(vaultName), _credential);

        public Track2VaultClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _credential = new Track2TokenCredential(new DataServiceCredential(authFactory, context, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId));
            _vaultUriHelper = new VaultUriHelper(context.Environment.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix));
        }

        #region Key actions

        internal PSKeyVaultKey CreateKey(string vaultName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName)
        {
            var client = CreateKeyClient(vaultName);
            return CreateKey(client, keyName, keyAttributes, size, curveName);
        }

        private PSKeyVaultKey CreateKey(KeyClient client, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName)
        {
            CreateKeyOptions options;
            bool isHsm = keyAttributes.KeyType == KeyType.RsaHsm || keyAttributes.KeyType == KeyType.EcHsm;

            if (keyAttributes.KeyType == KeyType.Rsa || keyAttributes.KeyType == KeyType.RsaHsm)
            {
                options = new CreateRsaKeyOptions(keyName, isHsm) { KeySize = size };
            }
            else if (keyAttributes.KeyType == KeyType.Ec || keyAttributes.KeyType == KeyType.EcHsm)
            {
                options = new CreateEcKeyOptions(keyName, isHsm) { CurveName = string.IsNullOrEmpty(curveName) ? (KeyCurveName?)null : new KeyCurveName(curveName) };
            }
            else
            {
                // oct (AES) is only supported by managed HSM
                throw new NotSupportedException($"{keyAttributes.KeyType} is not supported");
            }
            options.NotBefore = keyAttributes.NotBefore;
            options.ExpiresOn = keyAttributes.Expires;
            options.Enabled = keyAttributes.Enabled;
            options.Exportable = keyAttributes.Exportable;
            options.ReleasePolicy = keyAttributes.ReleasePolicy?.ToKeyReleasePolicy(); ;

            if (keyAttributes.KeyOps != null)
            {
                foreach (var keyOp in keyAttributes.KeyOps)
                {
                    options.KeyOperations.Add(new KeyOperation(keyOp));
                }
            }
            if (keyAttributes.Tags != null)
            {
                foreach (DictionaryEntry entry in keyAttributes.Tags)
                {
                    options.Tags.Add(entry.Key.ToString(), entry.Value.ToString());
                }
            }

            if (keyAttributes.KeyType == KeyType.Rsa || keyAttributes.KeyType == KeyType.RsaHsm)
            {
                return new PSKeyVaultKey(client.CreateRsaKey(options as CreateRsaKeyOptions).Value, _vaultUriHelper, false);
            }
            else if (keyAttributes.KeyType == KeyType.Ec || keyAttributes.KeyType == KeyType.EcHsm)
            {
                return new PSKeyVaultKey(client.CreateEcKey(options as CreateEcKeyOptions).Value, _vaultUriHelper, false);
            }
            else
            {
                throw new NotSupportedException($"{keyAttributes.KeyType} is not supported");
            }
        }

        internal PSKeyOperationResult Decrypt(string vaultName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            var key = GetKey(vaultName, keyName, version);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            EncryptionAlgorithm keyEncryptAlgorithm = new EncryptionAlgorithm(encryptAlgorithm);
            return Decrypt(cryptographyClient, keyEncryptAlgorithm, value);
        }

        private PSKeyOperationResult Decrypt(CryptographyClient cryptographyClient, EncryptionAlgorithm keyEncryptAlgorithm, byte[] value)
        {
            return new PSKeyOperationResult(cryptographyClient.Decrypt(keyEncryptAlgorithm, value));
        }

        internal PSKeyOperationResult Encrypt(string vaultName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            var key = GetKey(vaultName, keyName, version);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            EncryptionAlgorithm keyEncryptAlgorithm = new EncryptionAlgorithm(encryptAlgorithm);
            return Encrypt(cryptographyClient, keyEncryptAlgorithm, value);
        }

        private PSKeyOperationResult Encrypt(CryptographyClient cryptographyClient, EncryptionAlgorithm keyEncryptAlgorithm, byte[] value)
        {
            return new PSKeyOperationResult(cryptographyClient.Encrypt(keyEncryptAlgorithm, value));
        }

        internal PSKeyVaultKey GetKey(string vaultName, string keyName, string keyVersion)
        {
            var client = CreateKeyClient(vaultName);
            return GetKey(client, keyName, keyVersion);
        }

        private PSKeyVaultKey GetKey(KeyClient client, string keyName, string keyVersion)
        {
            return new PSKeyVaultKey(client.GetKey(keyName, keyVersion).Value, _vaultUriHelper, false);
        }

        internal PSKeyOperationResult UnwrapKey(string vaultName, string keyName, string keyVersion, string wrapAlgorithm, byte[] value)
        {
            var key = GetKey(vaultName, keyName, keyVersion);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            KeyWrapAlgorithm keyWrapAlgorithm = new KeyWrapAlgorithm(wrapAlgorithm);
            return UnwrapKey(cryptographyClient, keyWrapAlgorithm, value);
        }

        private PSKeyOperationResult UnwrapKey(CryptographyClient cryptographyClient, KeyWrapAlgorithm keyWrapAlgorithm, byte[] wrapKey)
        {
            return new PSKeyOperationResult(cryptographyClient.UnwrapKey(keyWrapAlgorithm, wrapKey));
        }

        internal PSKeyOperationResult WrapKey(string vaultName, string keyName, string keyVersion, string wrapAlgorithm, byte[] wrapKey)
        {
            var key = GetKey(vaultName, keyName, keyVersion);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            KeyWrapAlgorithm keyWrapAlgorithm = new KeyWrapAlgorithm(wrapAlgorithm);
            return WrapKey(cryptographyClient, keyWrapAlgorithm, wrapKey);
        }

        private PSKeyOperationResult WrapKey(CryptographyClient cryptographyClient, KeyWrapAlgorithm keyWrapAlgorithm, byte[] wrapKey)
        {
            return new PSKeyOperationResult(cryptographyClient.WrapKey(keyWrapAlgorithm, wrapKey));
        }

        #endregion

        #region Key rotation actions

        internal PSKeyVaultKey RotateKey(string vaultName, string keyName)
        {
            var client = CreateKeyClient(vaultName);
            return RotateKey(client, keyName);
        }

        private PSKeyVaultKey RotateKey(KeyClient client, string keyName)
        {
            return new PSKeyVaultKey(client.RotateKey(keyName), _vaultUriHelper, false);
        }

        internal PSKeyRotationPolicy GetKeyRotationPolicy(string vaultName, string keyName)
        {
            var client = CreateKeyClient(vaultName);
            return GetKeyRotationPolicy(client, vaultName, keyName);
        }

        private PSKeyRotationPolicy GetKeyRotationPolicy(KeyClient client, string vaultName, string keyName)
        {
            return new PSKeyRotationPolicy(client.GetKeyRotationPolicy(keyName), vaultName, keyName);
        }

        internal PSKeyRotationPolicy SetKeyRotationPolicy(PSKeyRotationPolicy psKeyRotationPolicy)
        {
            var client = CreateKeyClient(psKeyRotationPolicy.VaultName);
            var policy = new KeyRotationPolicy()
            {
                ExpiresIn = psKeyRotationPolicy.ExpiresIn,
                LifetimeActions = { }
            };

            psKeyRotationPolicy.LifetimeActions?.ForEach(
                psKeyRotationLifetimeAction => policy.LifetimeActions.Add(
                    new KeyRotationLifetimeAction(psKeyRotationLifetimeAction.Action)
                    {
                        TimeAfterCreate = psKeyRotationLifetimeAction.TimeAfterCreate,
                        TimeBeforeExpiry = psKeyRotationLifetimeAction.TimeBeforeExpiry
                    }
                ));

            return SetKeyRotationPolicy(client, psKeyRotationPolicy.VaultName, psKeyRotationPolicy.KeyName, policy);
        }

        private PSKeyRotationPolicy SetKeyRotationPolicy(KeyClient client, string vaultName, string keyName, KeyRotationPolicy policy)
        {
            return new PSKeyRotationPolicy(client.UpdateKeyRotationPolicy(keyName, policy), vaultName, keyName);
        }

        #endregion

        #region Certificate actions
        internal PSKeyVaultCertificate ImportCertificate(string vaultName, string certName, byte[] certificate, SecureString password, IDictionary<string, string> tags, string contentType = Constants.Pkcs12ContentType)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrEmpty(certName))
                throw new ArgumentNullException(nameof(certName));
            if (null == certificate)
                throw new ArgumentNullException(nameof(certificate));

            var certClient = CreateCertificateClient(vaultName);
            return ImportCertificate(certClient, certName, certificate, password, tags, contentType);
        }

        private PSKeyVaultCertificate ImportCertificate(CertificateClient certClient, string certName, byte[] certificate, SecureString password, IDictionary<string, string> tags, string contentType = Constants.Pkcs12ContentType)
        {
            var options = new ImportCertificateOptions(certName, certificate)
            {
                Policy = new CertificatePolicy()
                {
                    ContentType = contentType
                },
                Password = password?.ConvertToString()
            };
            tags?.ForEach((entry) =>
            {
                options.Tags.Add(entry.Key.ToString(), entry.Value.ToString());
            });
            return new PSKeyVaultCertificate(certClient.ImportCertificate(options));
        }

        public PSKeyVaultCertificate MergeCertificate(string vaultName, string certName, byte[] certificate, IDictionary<string, string> tags)
        {
            var certClient = CreateCertificateClient(vaultName);
            var options = new MergeCertificateOptions(certName, new List<byte[]> { certificate });
            tags?.ForEach((entry) => { options.Tags.Add(entry.Key.ToString(), entry.Value.ToString()); });
            var cert = certClient.MergeCertificate(options);
            return new PSKeyVaultCertificate(cert);
        }
        #endregion
    }
}

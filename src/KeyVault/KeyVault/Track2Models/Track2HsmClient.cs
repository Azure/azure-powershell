using Azure.Security.KeyVault.Administration;
using Azure;
using Azure.Security.KeyVault.Keys;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using KeyProperties = Azure.Security.KeyVault.Keys.KeyProperties;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Xml;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2HsmClient
    {
        private Track2TokenCredential _credential;
        private VaultUriHelper _uriHelper;

        private KeyClient CreateKeyClient(string hsmName) => new KeyClient(_uriHelper.CreateVaultUri(hsmName), _credential);
        private KeyVaultBackupClient CreateBackupClient(string hsmName) => new KeyVaultBackupClient(_uriHelper.CreateVaultUri(hsmName), _credential);
        private KeyVaultAccessControlClient CreateRbacClient(string hsmName) => new KeyVaultAccessControlClient(_uriHelper.CreateVaultUri(hsmName), _credential);
        private CryptographyClient CreateCryptographyClient(string keyId) => new CryptographyClient(new Uri(keyId), _credential);

        public Track2HsmClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _credential = new Track2TokenCredential(new DataServiceCredential(authFactory, context, AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId));
            _uriHelper = new VaultUriHelper(context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointSuffix));
        }

        private Exception GetInnerException(Exception exception)
        {
            while (exception.InnerException != null) exception = exception.InnerException;
            return exception;
        }

        #region Key actions
        internal string BackupKey(string managedHsmName, string keyName, string outputBlobPath)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (string.IsNullOrEmpty(outputBlobPath))
                throw new ArgumentNullException(nameof(outputBlobPath));

            var client = CreateKeyClient(managedHsmName);

            return BackupKey(client, keyName, outputBlobPath);
        }

        private string BackupKey(KeyClient client, string keyName, string outputBlobPath)
        {
            BackupKeyResult backupKeyResult;
            try
            {
                backupKeyResult = new BackupKeyResult(client.BackupKeyAsync(keyName).GetAwaiter().GetResult());
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            File.WriteAllBytes(outputBlobPath, backupKeyResult.Value);

            return outputBlobPath;
        }

        internal PSKeyVaultKey CreateKey(string managedHsmName, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName)
        {
            var client = CreateKeyClient(managedHsmName);
            return CreateKey(client, keyName, keyAttributes, size, curveName);
        }

        private PSKeyVaultKey CreateKey(KeyClient client, string keyName, PSKeyVaultKeyAttributes keyAttributes, int? size, string curveName)
        {
            // todo duplicated code with Track2VaultClient.CreateKey
            CreateKeyOptions options;
            bool isHsm = keyAttributes.KeyType == KeyType.RsaHsm || keyAttributes.KeyType == KeyType.EcHsm;

            if (keyAttributes.KeyType == KeyType.Rsa || keyAttributes.KeyType == KeyType.RsaHsm)
            {
                options = new CreateRsaKeyOptions(keyName, isHsm) { KeySize = size };
            }
            else if (keyAttributes.KeyType == KeyType.Ec || keyAttributes.KeyType == KeyType.EcHsm)
            {
                options = new CreateEcKeyOptions(keyName, isHsm);
                if (string.IsNullOrEmpty(curveName))
                {
                    (options as CreateEcKeyOptions).CurveName = null;
                }
                else
                {
                    (options as CreateEcKeyOptions).CurveName = new KeyCurveName(curveName);
                }
            }
            else
            {
                options = new CreateKeyOptions();
            }

            // Common key attributes
            options.NotBefore = keyAttributes.NotBefore;
            options.ExpiresOn = keyAttributes.Expires;
            options.Enabled = keyAttributes.Enabled;
            options.Exportable = keyAttributes.Exportable;
            options.ReleasePolicy = keyAttributes.ReleasePolicy?.ToKeyReleasePolicy();

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
                return new PSKeyVaultKey(client.CreateRsaKey(options as CreateRsaKeyOptions).Value, _uriHelper, isHsm: true);
            }
            else if (keyAttributes.KeyType == KeyType.Ec || keyAttributes.KeyType == KeyType.EcHsm)
            {
                return new PSKeyVaultKey(client.CreateEcKey(options as CreateEcKeyOptions).Value, _uriHelper, isHsm: true);
            }
            else if (keyAttributes.KeyType == KeyType.Oct || keyAttributes.KeyType.ToString() == "oct-HSM")
            {
                return new PSKeyVaultKey(client.CreateKey(keyName, KeyType.Oct, options).Value, _uriHelper, isHsm: true);
            }
            else
            {
                throw new NotSupportedException($"{keyAttributes.KeyType} is not supported");
            }
        }

        internal PSKeyOperationResult Decrypt(string managedHsmName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            var key = GetKey(managedHsmName, keyName, version);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            EncryptionAlgorithm keyEncryptAlgorithm = new EncryptionAlgorithm(encryptAlgorithm);
            return Decrypt(cryptographyClient, keyEncryptAlgorithm, value);
        }

        private PSKeyOperationResult Decrypt(CryptographyClient cryptographyClient, EncryptionAlgorithm keyEncryptAlgorithm, byte[] value)
        {
            return new PSKeyOperationResult(cryptographyClient.Decrypt(keyEncryptAlgorithm, value));
        }

        internal PSDeletedKeyVaultKey DeleteKey(string managedHsmName, string keyName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));

            var client = CreateKeyClient(managedHsmName);

            return DeleteKey(client, keyName);
        }

        private PSDeletedKeyVaultKey DeleteKey(KeyClient client, string keyName)
        {
            DeletedKey deletedKey;
            try
            {
                deletedKey = client.StartDeleteKeyAsync(keyName).ConfigureAwait(false).GetAwaiter().GetResult()
                    .WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultKey(deletedKey, this._uriHelper, isHsm: true);
        }

        internal PSKeyOperationResult Encrypt(string managedHsmName, string keyName, string version, byte[] value, string encryptAlgorithm)
        {
            var key = GetKey(managedHsmName, keyName, version);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            EncryptionAlgorithm keyEncryptAlgorithm = new EncryptionAlgorithm(encryptAlgorithm);
            return Encrypt(cryptographyClient, keyEncryptAlgorithm, value);
        }

        private PSKeyOperationResult Encrypt(CryptographyClient cryptographyClient, EncryptionAlgorithm keyEncryptAlgorithm, byte[] value)
        {
            return new PSKeyOperationResult(cryptographyClient.Encrypt(keyEncryptAlgorithm, value));
        }

        internal PSKeyOperationResult UnwrapKey(string managedHsmName, string keyName, string version, string wrapAlgorithm, byte[] value)
        {
            var key = GetKey(managedHsmName, keyName, version);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            KeyWrapAlgorithm keyWrapAlgorithm = new KeyWrapAlgorithm(wrapAlgorithm);
            return UnwrapKey(cryptographyClient, keyWrapAlgorithm, value);
        }

        private PSKeyOperationResult UnwrapKey(CryptographyClient cryptographyClient, KeyWrapAlgorithm keyEncryptAlgorithm, byte[] value)
        {
            return new PSKeyOperationResult(cryptographyClient.UnwrapKey(keyEncryptAlgorithm, value));
        }

        internal PSKeyOperationResult WrapKey(string managedHsmName, string keyName, string keyVersion, string wrapAlgorithm, byte[] value)
        {
            var key = GetKey(managedHsmName, keyName, keyVersion);
            var cryptographyClient = CreateCryptographyClient(key.Id);
            KeyWrapAlgorithm keyWrapAlgorithm = new KeyWrapAlgorithm(wrapAlgorithm);
            return WrapKey(cryptographyClient, keyWrapAlgorithm, value);
        }

        private PSKeyOperationResult WrapKey(CryptographyClient cryptographyClient, KeyWrapAlgorithm keyEncryptAlgorithm, byte[] value)
        {
            return new PSKeyOperationResult(cryptographyClient.WrapKey(keyEncryptAlgorithm, value));
        }

        internal PSKeyVaultKey RecoverKey(string managedHsmName, string keyName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException("managedHsmName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var client = CreateKeyClient(managedHsmName);

            return RecoverKey(client, keyName);
        }

        private PSKeyVaultKey RecoverKey(KeyClient client, string keyName)
        {
            KeyVaultKey recoveredKey;
            try
            {
                recoveredKey = client.StartRecoverDeletedKeyAsync(keyName).GetAwaiter().GetResult()
                    .WaitForCompletionAsync().GetAwaiter().GetResult().Value;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(recoveredKey, this._uriHelper, isHsm: true);
        }

        internal PSKeyVaultKey RestoreKey(string managedHsmName, string inputBlobPath)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(inputBlobPath))
                throw new ArgumentNullException(nameof(inputBlobPath));

            var client = CreateKeyClient(managedHsmName);

            return RestoreKey(client, inputBlobPath);
        }

        private PSKeyVaultKey RestoreKey(KeyClient client, string inputBlobPath)
        {
            var backupBlob = File.ReadAllBytes(inputBlobPath);

            KeyVaultKey keyBundle;
            try
            {
                keyBundle = client.RestoreKeyBackupAsync(backupBlob).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(keyBundle, this._uriHelper, isHsm: true);
        }

        internal PSKeyVaultKey UpdateKey(string managedHsmName, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (keyAttributes == null)
                throw new ArgumentNullException(nameof(keyAttributes));

            var client = CreateKeyClient(managedHsmName);

            return UpdateKey(client, keyName, keyVersion, keyAttributes);
        }

        private PSKeyVaultKey UpdateKey(KeyClient client, string keyName, string keyVersion, PSKeyVaultKeyAttributes keyAttributes)
        {
            KeyVaultKey keyBundle = null;

            // Update updatable properties
            KeyProperties keyProperties = new KeyProperties(_uriHelper.CreateaMagedHsmKeyUri(client.VaultUri, keyName, keyVersion))
            {
                Enabled = keyAttributes.Enabled,
                ExpiresOn = keyAttributes.Expires,
                NotBefore = keyAttributes.NotBefore,
                ReleasePolicy = keyAttributes.ReleasePolicy?.ToKeyReleasePolicy()
            };
            
            if (keyAttributes.Tags != null)
            {
                keyProperties.Tags.Clear();
                foreach (KeyValuePair<string, string> entry in keyAttributes.TagsDirectionary)
                {
                    keyProperties.Tags.Add(entry.Key, entry.Value);
                }
            }

            try
            {
                keyBundle = client.UpdateKeyProperties(keyProperties, keyAttributes.KeyOps?.Select(op => new KeyOperation(op)));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(keyBundle, this._uriHelper, isHsm: true);
        }

        internal PSKeyVaultKey GetKey(string managedHsmName, string keyName, string keyVersion)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));

            var client = CreateKeyClient(managedHsmName);
            return GetKey(client, keyName, keyVersion);
        }

        private PSKeyVaultKey GetKey(KeyClient client, string keyName, string keyVersion)
        {
            KeyVaultKey keyBundle;
            try
            {
                keyBundle = client.GetKeyAsync(keyName, keyVersion).GetAwaiter().GetResult();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == (int)HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(keyBundle, this._uriHelper, isHsm: true);
        }

        internal IEnumerable<PSKeyVaultKeyIdentityItem> GetKeys(string managedHsmName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidHsmName);

            var client = CreateKeyClient(managedHsmName);

            try
            {
                IEnumerable<KeyProperties> result = client.GetPropertiesOfKeys();

                return (result == null) ? new List<PSKeyVaultKeyIdentityItem>() :
                    result.Select((keyProperties) => new PSKeyVaultKeyIdentityItem(keyProperties, this._uriHelper, isHsm: true));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        internal IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyAllVersions(string managedHsmName, string keyName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidHsmName);

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyName);

            var client = CreateKeyClient(managedHsmName);
            return GetAllVersionKeys(client, keyName);
        }

        private IEnumerable<PSKeyVaultKeyIdentityItem> GetAllVersionKeys(KeyClient client, string keyName)
        {
            try
            {
                IEnumerable<KeyProperties> result = client.GetPropertiesOfKeyVersions(keyName);
                return (result == null) ? new List<PSKeyVaultKeyIdentityItem>() :
                    result.Select((keyProperties) => new PSKeyVaultKeyIdentityItem(keyProperties, this._uriHelper, isHsm: true));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        internal PSDeletedKeyVaultKey GetDeletedKey(string managedHsmName, string keyName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));

            var client = CreateKeyClient(managedHsmName);

            return GetDeletedKey(client, keyName);
        }

        private PSDeletedKeyVaultKey GetDeletedKey(KeyClient client, string keyName)
        {
            DeletedKey deletedKeyBundle;
            try
            {
                deletedKeyBundle = client.GetDeletedKeyAsync(keyName).GetAwaiter().GetResult();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == (int)HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultKey(deletedKeyBundle, _uriHelper, isHsm: true);
        }

        internal IEnumerable<PSDeletedKeyVaultKeyIdentityItem> GetDeletedKeys(string managedHsmName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            var client = CreateKeyClient(managedHsmName);

            try
            {
                IEnumerable<DeletedKey> result = client.GetDeletedKeys();

                return (result == null) ? new List<PSDeletedKeyVaultKeyIdentityItem>() :
                    result.Select((deletedKey) => new PSDeletedKeyVaultKeyIdentityItem(deletedKey, this._uriHelper, isHsm: true));
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        internal PSKeyVaultKey ImportKey(string managedHsmName, string keyName, JsonWebKey webKey)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException(nameof(keyName));
            if (webKey == null)
                throw new ArgumentNullException(nameof(webKey));
            var client = CreateKeyClient(managedHsmName);

            try
            {
                var key = client.ImportKeyAsync(keyName, webKey).GetAwaiter().GetResult();
                return new PSKeyVaultKey(key, this._uriHelper, isHsm: true);
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        internal void PurgeKey(string managedHsmName, string keyName)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException("managedHsmName");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var client = CreateKeyClient(managedHsmName);

            try
            {
                client.PurgeDeletedKeyAsync(keyName).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        public byte[] GetRandomNumberBytes(string managedHsmName, int count)
        {
            if (string.IsNullOrEmpty(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            
            var client = CreateKeyClient(managedHsmName);
            return client.GetRandomBytes(count);
        }

        #endregion

        #region Key rotation
        internal PSKeyVaultKey RotateKey(string managedHsmName, string keyName)
        {
            var client = CreateKeyClient(managedHsmName);
            return RotateKey(client, keyName);
        }

        private PSKeyVaultKey RotateKey(KeyClient client, string keyName)
        {
            return new PSKeyVaultKey(client.RotateKey(keyName), _uriHelper, isHsm: true);
        }

        internal PSKeyRotationPolicy GetKeyRotationPolicy(string managedHsmName, string keyName)
        {
            var client = CreateKeyClient(managedHsmName);
            return GetKeyRotationPolicy(client, managedHsmName, keyName);
        }

        private PSKeyRotationPolicy GetKeyRotationPolicy(KeyClient client, string managedHsmName, string keyName)
        {
            return new PSKeyRotationPolicy(client.GetKeyRotationPolicy(keyName), managedHsmName, keyName);
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
                    new KeyRotationLifetimeAction(new KeyRotationPolicyAction(psKeyRotationLifetimeAction.Action))
                    {
                        TimeAfterCreate = psKeyRotationLifetimeAction.TimeAfterCreate,
                        TimeBeforeExpiry = psKeyRotationLifetimeAction.TimeBeforeExpiry
                    }
                ));

            return SetKeyRotationPolicy(client, psKeyRotationPolicy.VaultName, psKeyRotationPolicy.KeyName, policy);
        }

        private PSKeyRotationPolicy SetKeyRotationPolicy(KeyClient client, string managedHsmName, string keyName, KeyRotationPolicy keyRotationPolicy)
        {
            return new PSKeyRotationPolicy(client.UpdateKeyRotationPolicy(keyName, keyRotationPolicy), managedHsmName, keyName);
        }
        #endregion

        #region Full backup restore
        public KeyVaultBackupResult BackupHsm(string hsmName, Uri blobStorageUri, string sasToken)
        {
            var client = CreateBackupClient(hsmName);
            var backup = client.StartBackup(blobStorageUri, sasToken);
            KeyVaultBackupResult result;
            try
            {
                result = backup.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult().Value;
            }
            catch
            {
                throw;
            }
            return result;
        }

        public void RestoreHsm(string hsmName, Uri folderUri, string sasToken)
        {
            var client = CreateBackupClient(hsmName);
            var restore = client.StartRestore(folderUri, sasToken);
            try
            {
                restore.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
        }

        public void SelectiveRestoreHsm(string hsmName, string keyName, Uri folderUri, string sasToken)
        {
            var client = CreateBackupClient(hsmName);
            try
            {
                client.StartSelectiveKeyRestore(keyName, folderUri, sasToken)
                    .WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region RBAC
        public PSKeyVaultRoleDefinition[] GetHsmRoleDefinitions(string hsmName, string scope)
        {
            var client = CreateRbacClient(hsmName);
            return client.GetRoleDefinitions(new KeyVaultRoleScope(scope)).Select(roleDefinition => new PSKeyVaultRoleDefinition(roleDefinition)).ToArray();
        }

        internal PSKeyVaultRoleDefinition CreateOrUpdateHsmRoleDefinition(string hsmName, string scope, PSKeyVaultRoleDefinition role)
        {
            CreateOrUpdateRoleDefinitionOptions createOptions;
            if (string.IsNullOrEmpty(role.Name))
            {
                createOptions = new CreateOrUpdateRoleDefinitionOptions(new KeyVaultRoleScope(scope));
            }
            else
            {
                createOptions = new CreateOrUpdateRoleDefinitionOptions(new KeyVaultRoleScope(scope), Guid.Parse(role.Name));
            }
            createOptions.RoleName = role.RoleName;
            createOptions.Description = role.Description;
            role.AssignableScopes.ForEach(x => createOptions.AssignableScopes.Add(x));
            role.Permissions.ForEach(x => createOptions.Permissions.Add(x.ToSdkType()));
            var client = CreateRbacClient(hsmName);
            var roleResponse = client.CreateOrUpdateRoleDefinitionAsync(createOptions, default).ConfigureAwait(false).GetAwaiter().GetResult().Value;
            return new PSKeyVaultRoleDefinition(roleResponse);
        }

        internal PSKeyVaultRoleAssignment[] GetHsmRoleAssignments(string hsmName, string scope)
        {
            var client = CreateRbacClient(hsmName);
            return client.GetRoleAssignments(new KeyVaultRoleScope(scope)).Select(roleAssignment => new PSKeyVaultRoleAssignment(roleAssignment, hsmName)).ToArray();
        }

        internal PSKeyVaultRoleAssignment GetHsmRoleAssignment(string hsmName, string scope, string name)
        {
            var client = CreateRbacClient(hsmName);
            var roleAssignment = client.GetRoleAssignment(new KeyVaultRoleScope(scope), name);
            return new PSKeyVaultRoleAssignment(roleAssignment, hsmName);
        }

        internal PSKeyVaultRoleAssignment CreateHsmRoleAssignment(string hsmName, string scope, string roleDefinitionId, string principalId)
        {
            var client = CreateRbacClient(hsmName);
            var roleAssignment = client.CreateRoleAssignment(new KeyVaultRoleScope(scope), roleDefinitionId, principalId);
            return new PSKeyVaultRoleAssignment(roleAssignment, hsmName);
        }

        internal void RemoveHsmRoleAssignment(string hsmName, string scope, string roleAssignmentName)
        {
            var client = CreateRbacClient(hsmName);
            client.DeleteRoleAssignment(new KeyVaultRoleScope(scope), roleAssignmentName);
        }
        internal void RemoveHsmRoleDefinition(string hsmName, string scope, string roleDefinitionName)
        {
            var client = CreateRbacClient(hsmName);
            client.DeleteRoleDefinitionAsync(new KeyVaultRoleScope(scope), Guid.Parse(roleDefinitionName)).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        #endregion
    }
}

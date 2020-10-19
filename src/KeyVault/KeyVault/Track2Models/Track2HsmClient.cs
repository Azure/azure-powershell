using Azure.Security.KeyVault.Administration;
﻿using Azure;
using Azure.Security.KeyVault.Keys;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections;
using System.Linq;
using AdminSdk = Azure.Security.KeyVault.Administration;
using System.Collections.Generic;
using System.IO;
using System.Net;
using KeyProperties = Azure.Security.KeyVault.Keys.KeyProperties;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2HsmClient
    {
        private Track2TokenCredential _credential;
        private VaultUriHelper _uriHelper;
        private KeyClient CreateKeyClient(string hsmName) => new KeyClient(_uriHelper.CreateVaultUri(hsmName), _credential);
        private KeyVaultBackupClient CreateBackupClient(string hsmName) => new KeyVaultBackupClient(_uriHelper.CreateVaultUri(hsmName), _credential);
        private KeyVaultAccessControlClient CreateRbacClient(string hsmName) => new KeyVaultAccessControlClient(_uriHelper.CreateVaultUri(hsmName), _credential);

        public Track2HsmClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _credential = new Track2TokenCredential(new DataServiceCredential(authFactory, context, AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId));
            _uriHelper = new VaultUriHelper(context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointSuffix));
        }

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

            return new PSKeyVaultKey(keyBundle, this._uriHelper);
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
            options.NotBefore = keyAttributes.NotBefore;
            options.ExpiresOn = keyAttributes.Expires;
            options.Enabled = keyAttributes.Enabled;
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
                return new PSKeyVaultKey(client.CreateRsaKey(options as CreateRsaKeyOptions).Value, _uriHelper);
            }
            else if (keyAttributes.KeyType == KeyType.Ec || keyAttributes.KeyType == KeyType.EcHsm)
            {
                return new PSKeyVaultKey(client.CreateEcKey(options as CreateEcKeyOptions).Value, _uriHelper);
            }
            else if (keyAttributes.KeyType == KeyType.Oct || keyAttributes.KeyType.ToString() == "oct-HSM")
            {
                return new PSKeyVaultKey(client.CreateKey(keyName, KeyType.Oct, options).Value, _uriHelper);
            }
            else
            {
                throw new NotSupportedException($"{keyAttributes.KeyType} is not supported");
            }
        }

        public Uri BackupHsm(string hsmName, Uri blobStorageUri, string sasToken)
        {
            var client = CreateBackupClient(hsmName);
            var backup = client.StartBackup(blobStorageUri, sasToken);
            Uri backupUri;
            try
            {
                backupUri = backup.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult().Value;
            }
            catch
            {
                throw;
            }
            return backupUri;
        }

        public void RestoreHsm(string hsmName, Uri backupLocation, string sasToken, string backupFolder)
        {
            var client = CreateBackupClient(hsmName);
            var restore = client.StartRestore(backupLocation, sasToken, backupFolder);
            try
            {
                restore.WaitForCompletionAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
        }

        public PSKeyVaultRoleDefinition[] GetHsmRoleDefinitions(string hsmName, string scope)
        {
            var client = CreateRbacClient(hsmName);
            return client.GetRoleDefinitions(new KeyVaultRoleScope(scope)).Select(roleDefinition => new PSKeyVaultRoleDefinition(roleDefinition)).ToArray();
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
            var roleAssignment = client.CreateRoleAssignment(new KeyVaultRoleScope(scope), new AdminSdk.Models.KeyVaultRoleAssignmentProperties(roleDefinitionId, principalId));
            return new PSKeyVaultRoleAssignment(roleAssignment, hsmName);
        }

        internal void RemoveHsmRoleAssignment(string hsmName, string scope, string roleAssignmentName)
        {
            var client = CreateRbacClient(hsmName);
            client.DeleteRoleAssignment(new KeyVaultRoleScope(scope), roleAssignmentName);
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

            return new PSDeletedKeyVaultKey(deletedKey, this._uriHelper);
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

            return new PSKeyVaultKey(recoveredKey, this._uriHelper);
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
            KeyVaultKey keyBundle = client.GetKeyAsync(keyName, keyVersion).GetAwaiter().GetResult();
            KeyProperties keyProperties = keyBundle.Properties;
            keyProperties.Enabled = keyAttributes.Enabled;
            keyProperties.ExpiresOn = keyAttributes.Expires;
            keyProperties.NotBefore = keyAttributes.NotBefore;

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
                keyBundle = client.UpdateKeyPropertiesAsync(keyProperties, keyAttributes.KeyOps?.Cast<KeyOperation>().ToList())
                    .GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSKeyVaultKey(keyBundle, this._uriHelper);
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

            return new PSKeyVaultKey(keyBundle, this._uriHelper);
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
                    result.Select((keyProperties) => new PSKeyVaultKeyIdentityItem(keyProperties, this._uriHelper));
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
                    result.Select((keyProperties) => new PSKeyVaultKeyIdentityItem(keyProperties, this._uriHelper));
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

            return new PSDeletedKeyVaultKey(deletedKeyBundle, _uriHelper);
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
                    result.Select((deletedKey) => new PSDeletedKeyVaultKeyIdentityItem(deletedKey, this._uriHelper));
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
                return new PSKeyVaultKey(key, this._uriHelper);
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

        private Exception GetInnerException(Exception exception)
        {
            while (exception.InnerException != null) exception = exception.InnerException;
            return exception;
        }
    }
}

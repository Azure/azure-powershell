using System;
using System.Net;
using System.Collections;
using Azure.Security.KeyVault.Keys;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using System.Collections.Generic;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;
using Azure;
using KeyProperties = Azure.Security.KeyVault.Keys.KeyProperties;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2HsmClient
    {
        private Track2TokenCredential _credential;
        private VaultUriHelper _uriHelper;
        private KeyClient CreateKeyClient(string hsmName) => new KeyClient(_uriHelper.CreateVaultUri(hsmName), _credential);

        public Track2HsmClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _credential = new Track2TokenCredential(new DataServiceCredential(authFactory, context, AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId));
            _uriHelper = new VaultUriHelper(context.Environment.GetEndpoint(AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointSuffix));
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
                // Have no idea why still run KeyCurveName when curveName is null
                //options = new CreateEcKeyOptions(keyName, isHsm)
                //{
                //    CurveName = string.IsNullOrEmpty(curveName) ? null : new KeyCurveName(curveName)
                //};
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
                deletedKey = client.StartDeleteKeyAsync(keyName).GetAwaiter().GetResult()
                    .WaitForCompletionAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }

            return new PSDeletedKeyVaultKey(deletedKey, this._uriHelper);
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
            KeyProperties keyProperties = client.GetKey(keyName).Value.Properties;
            keyProperties.Enabled = keyAttributes.Enabled;
            keyProperties.ExpiresOn = keyAttributes.Expires;
            keyProperties.NotBefore = keyAttributes.NotBefore;

            KeyVaultKey keyBundle;
            try
            {
                keyBundle = client.UpdateKeyPropertiesAsync(keyProperties, keyAttributes.KeyOps.Cast<KeyOperation>().ToList())
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

        internal IEnumerable<PSKeyVaultKeyIdentityItem> GetKeys(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            var client = CreateKeyClient(options.VaultName);

            try
            {
                var keys = client.GetPropertiesOfKeys();


                //return (result == null) ? new List<PSKeyVaultKeyIdentityItem>() :
                //    result.Select((keyProperties) => new PSKeyVaultKeyIdentityItem(keyProperties, this._uriHelper));
                return null;

            }
            catch (Exception ex)
            {
                throw GetInnerException(ex);
            }
        }

        internal IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyVersions(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            if (string.IsNullOrEmpty(options.Name))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyName);

            var client = CreateKeyClient(options.VaultName);
            return GetKeyVersions(client, options);
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

        internal IEnumerable<PSDeletedKeyVaultKey> GetDeletedKeys(KeyVaultObjectFilterOptions options)
        {
            if (options == null)
                throw new ArgumentNullException("options");

            if (string.IsNullOrEmpty(options.VaultName))
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidVaultName);

            var client = CreateKeyClient(options.VaultName);

            try
            {
                IEnumerable<DeletedKey> result = client.GetDeletedKeys();
              
                return (result == null) ? new List<PSDeletedKeyVaultKey>() :
                    result.Select((deletedKey) => new PSDeletedKeyVaultKey(deletedKey, this._uriHelper));
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

        private IEnumerable<PSKeyVaultKeyIdentityItem> GetKeyVersions(KeyClient client, KeyVaultObjectFilterOptions options)
        {
            try
            {
                IEnumerable<KeyProperties> result = client.GetPropertiesOfKeyVersions(options.Name);
                return (result == null) ? new List<PSKeyVaultKeyIdentityItem>() : 
                    result.Select((keyProperties) => new PSKeyVaultKeyIdentityItem(keyProperties, this._uriHelper));
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

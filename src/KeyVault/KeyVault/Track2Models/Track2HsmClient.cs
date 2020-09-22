using Azure.Security.KeyVault.Keys;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using System;
using System.Collections;

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
                options = new CreateEcKeyOptions(keyName, isHsm) { CurveName = string.IsNullOrEmpty(curveName) ? null : new KeyCurveName(curveName) };
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
    }
}

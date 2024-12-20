using System;

namespace Microsoft.Azure.Commands.KeyVault.Models.Secret
{
    /// <summary>
    /// A data class to hold components of a KeyVault Secret URI: VaultName, SecretName, and SecretVersion.
    /// </summary>
    internal class SecretUriComponents
    {
        /// <summary>
        /// The name of the Key Vault.
        /// </summary>
        public string VaultName { get; private set; }

        /// <summary>
        /// The name of the secret in the Key Vault.
        /// </summary>
        public string SecretName { get; private set; }

        /// <summary>
        /// The version of the secret (optional).
        /// </summary>
        public string SecretVersion { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SecretUriComponents class with the specified vault name, secret name, and version.
        /// </summary>
        /// <param name="secretId">The unique Uri/secretId (as a string) of the secret</param>
        public SecretUriComponents(string secretId)
        {
            Uri secretUri = new Uri(secretId);

            // Extract vault name from the URI
            this.VaultName = secretUri.Host.Split('.')[0];

            // Extract secret name from the URI
            this.SecretName = secretUri.Segments.Length > 2 ? secretUri.Segments[2].TrimEnd('/') : string.Empty;

            // Extract secret version (if present)
            this.SecretVersion = secretUri.Segments.Length > 3 ? secretUri.Segments[3] : string.Empty;

        }

        /// <summary>
        /// Returns a string representation of the secret URI components.
        /// </summary>
        /// <returns>A string in the format "VaultName:SecretName:SecretVersion"</returns>
        public override string ToString()
        {
            return $"{VaultName}:{SecretName}:{(string.IsNullOrEmpty(SecretVersion) ? "NoVersion" : SecretVersion)}";
        }
    }
}


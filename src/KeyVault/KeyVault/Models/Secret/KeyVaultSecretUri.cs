using System;

namespace Microsoft.Azure.Commands.KeyVault.Models.Secret
{
    /// <summary>
    /// A data class to hold components of a KeyVault Secret URI: VaultName, SecretName, and SecretVersion.
    /// </summary>
    public class SecretUriComponents
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
        /// <param name="vaultName">The name of the Key Vault</param>
        /// <param name="secretName">The name of the secret</param>
        /// <param name="secretVersion">The version of the secret (optional)</param>
        public SecretUriComponents(string vaultName, string secretName, string secretVersion)
        {
            VaultName = vaultName;
            SecretName = secretName;
            SecretVersion = secretVersion;
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


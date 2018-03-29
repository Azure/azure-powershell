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

namespace Microsoft.Azure.Commands.Aks.Models
{

    /// <summary>
    /// Reference to a secret stored in Azure Key Vault.
    /// </summary>
    public partial class PSKeyVaultSecretRef
    {
        /// <summary>
        /// Initializes a new instance of the PSKeyVaultSecretRef class.
        /// </summary>
        public PSKeyVaultSecretRef(){}

        /// <summary>
        /// Initializes a new instance of the PSKeyVaultSecretRef class.
        /// </summary>
        /// <param name="vaultID">Key vault identifier.</param>
        /// <param name="secretName">The secret name.</param>
        /// <param name="version">The secret version.</param>
        public PSKeyVaultSecretRef(string vaultID, string secretName, string version = default(string))
        {
            VaultID = vaultID;
            SecretName = secretName;
            Version = version;
        }

        /// <summary>
        /// Gets or sets key vault identifier.
        /// </summary>
        public string VaultID { get; set; }

        /// <summary>
        /// Gets or sets the secret name.
        /// </summary>
        public string SecretName { get; set; }

        /// <summary>
        /// Gets or sets the secret version.
        /// </summary>
        public string Version { get; set; }
    }
}

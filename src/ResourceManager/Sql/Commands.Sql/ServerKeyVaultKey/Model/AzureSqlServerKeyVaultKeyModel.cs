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

using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Server Key
    /// </summary>
    public class AzureSqlServerKeyVaultKeyModel
    {
        /// <summary>
        /// Enum representing the allowed Server Key types
        /// </summary>
        public enum ServerKeyType { AzureKeyVault, ServiceManaged };

        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server key
        /// </summary>
        public string ServerKeyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the server key
        /// </summary>
        public ServerKeyType Type { get; set; }

        /// <summary>
        /// Gets or sets the uri of the server key
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the thumbprint of the server key
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the server key
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Creates the SQL Server Key Name from an Azure Key Vault KeyId
        /// Throws an exception if the provided KeyId is malformed.
        /// An example of a well formed Azure Key Vault KeyId is: https://YourVaultName.vault.azure.net/keys/YourKeyName/01234567890123456789012345678901
        /// </summary>
        /// <param name="keyId">The full Azure Key Vault KeyId</param>
        /// <returns>The Server Key Name for the provided KeyId</returns>
        public static string CreateServerKeyNameFromKeyId(string keyId)
        {
            if (string.IsNullOrEmpty(keyId))
            {
                return ServerKeyType.ServiceManaged.ToString();
            }

            // Validate that the url is a keyvault url and has a key and version
            Regex r = new Regex(@"https(.)+\.vault(.)+\/keys\/[^\/]+\/[0-9a-zA-Z]+$", RegexOptions.IgnoreCase);
            if (!r.IsMatch(keyId))
            {
                // Throw an error here, since we don't want to use a non keyvault url
                //
                throw new ArgumentException(String.Format("Invalid parameter format for keyId: {0}."
                + " It should be a well formed Azure Key Vault KeyId like: https://YourVaultName.vault.azure.net/keys/YourKeyName/01234567890123456789012345678901", keyId)
                , "KeyId");
            }

            var uri = new Uri(keyId);

            string vault = uri.Host.Split('.').First();
            string key = uri.Segments[2].TrimEnd('/');
            string version = uri.Segments.Last();

            return String.Format("{0}_{1}_{2}", vault, key, version);
        }
    }
}

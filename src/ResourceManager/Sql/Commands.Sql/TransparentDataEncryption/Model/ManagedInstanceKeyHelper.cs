using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// Helper class for Managed instance key
    /// </summary>
    class ManagedInstanceKeyHelper
    {
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

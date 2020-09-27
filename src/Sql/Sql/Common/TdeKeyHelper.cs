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

using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.Common
{
    /// <summary>
    /// Helper class for Managed instance key
    /// </summary>
    class TdeKeyHelper
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
            Regex r = new Regex(@"https://(.)+\.(managedhsm.azure.net|managedhsm-preview.azure.net|vault.azure.net|vault-int.azure-int.net|vault.azure.cn|managedhsm.azure.cn|vault.usgovcloudapi.net|managedhsm.usgovcloudapi.net|vault.microsoftazure.de|managedhsm.microsoftazure.de|vault.cloudapi.eaglex.ic.gov|vault.cloudapi.microsoft.scloud)(:443)?\/keys/[^\/]+\/[0-9a-zA-Z]+$", RegexOptions.IgnoreCase);
            if (!r.IsMatch(keyId))
            {
                // Throw an error here, since we don't want to use a non keyvault url
                //
                throw new ArgumentException(message:String.Format(Properties.Resources.InvalidKeyId, keyId), paramName:"KeyId");
            }

            var uri = new Uri(keyId);

            string vault = uri.Host.Split('.').First();
            string key = uri.Segments[2].TrimEnd('/');
            string version = uri.Segments.Last();

            return String.Format("{0}_{1}_{2}", vault, key, version);
        }
    }
}

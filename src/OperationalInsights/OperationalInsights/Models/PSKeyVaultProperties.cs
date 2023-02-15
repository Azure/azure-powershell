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

using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSKeyVaultProperties
    {
        private PSKeyVaultProperties(string keyVaultUri, string keyName, string keyVersion)
        {
            KeyVaultUri = keyVaultUri;
            KeyName = keyName;
            KeyVersion = keyVersion;
        }

        /// <summary>
        /// Creates an instance of PSKeyVaultProperties taht serves the response from the SDK only
        /// KeyRsaSize property can be set with a value only from the SDK response - not user configurable
        /// </summary>
        /// <param name="kv"></param>
        private PSKeyVaultProperties(KeyVaultProperties kv)
        {
            this.KeyVaultUri = kv.KeyVaultUri;
            this.KeyName = kv.KeyName;
            this.KeyVersion = kv.KeyVersion;
            this.KeyRsaSize = kv.KeyRsaSize;
        }

        /// <summary>
        /// Creates an instance of PSKeyVaultProperties
        /// </summary>
        /// <param name="keyVaultUri"></param>
        /// <param name="keyName"></param>
        /// <param name="keyVersion"></param>
        /// <returns>PSKeyVaultProperties object ,if no value was passed a null will be returned</returns>
        public static PSKeyVaultProperties CreateKVProperties(string keyVaultUri = null, string keyName = null, string keyVersion = null)
        {
            if (keyVaultUri == null && keyName == null && keyVersion == null)
            {
                return null;
            }

            return new PSKeyVaultProperties(keyVaultUri, keyName, keyVersion);
        }

        /// <summary>
        /// Creates an instance of PSKeyVaultProperties taht serves the response from the SDK only
        /// </summary>
        /// <returns>An instance of PSKeyVaultProperties</returns>
        public static PSKeyVaultProperties GetKVPropertiesFromSDK(KeyVaultProperties kv)
        {
            return new PSKeyVaultProperties(kv);
        }


        public string KeyVaultUri { get; set; }

        public string KeyName { get; set; }

        public string KeyVersion { get; set; }

        public int? KeyRsaSize { get; set; }

        public KeyVaultProperties GetKeyVaultProperties()
        {
            return new KeyVaultProperties(this.KeyVaultUri, this.KeyName, this.KeyVersion);
        }
    }
}

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
        public PSKeyVaultProperties(string keyVaultUri = default(string), string keyName = default(string), string keyVersion = default(string), int keyRsaSize= default(int))
        {
            KeyVaultUri = keyVaultUri;
            KeyName = keyName;
            KeyVersion = keyVersion;
            KeyRsaSize = keyRsaSize;
        }

        public PSKeyVaultProperties(KeyVaultProperties kv)
        {
            this.KeyVaultUri = kv.KeyVaultUri;
            this.KeyName = kv.KeyName;
            this.KeyVersion = kv.KeyVersion;
        }

        public string KeyVaultUri { get; set; }

        public string KeyName { get; set; }

        public string KeyVersion { get; set; }

        public int KeyRsaSize { get; set; }

        public KeyVaultProperties GetKeyVaultProperties()
        {
            return new KeyVaultProperties(this.KeyVaultUri, this.KeyName, this.KeyVersion, this.KeyRsaSize);
        }
    }
}

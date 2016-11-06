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
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class VaultUriHelper
    {
        public VaultUriHelper(string keyVaultDnsSuffix)
        {
            if (string.IsNullOrEmpty(keyVaultDnsSuffix))
                throw new ArgumentNullException("keyVaultDnsSuffix");
            this.KeyVaultDnsSuffix = keyVaultDnsSuffix;
        }

        public string GetVaultName(string vaultAddress)
        {
            Uri vaultUri = CreateAndValidateVaultUri(vaultAddress);
            return vaultUri.Host.Split('.').First();
        }

        public String CreateVaultAddress(string vaultName)
        {
            return CreateVaultUri(vaultName).ToString();
        }

        public string KeyVaultDnsSuffix { get; private set; }

        private Uri CreateAndValidateVaultUri(string vaultAddress)
        {
            if (string.IsNullOrEmpty(vaultAddress))
                throw new ArgumentNullException("vaultAddress");

            Uri vaultUri;
            if (!Uri.TryCreate(vaultAddress, UriKind.Absolute, out vaultUri))
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.InvalidVaultUri, vaultAddress, this.KeyVaultDnsSuffix));

            if (vaultUri.HostNameType != UriHostNameType.Dns ||
                !vaultUri.Host.EndsWith(this.KeyVaultDnsSuffix, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.InvalidVaultUri, vaultAddress, this.KeyVaultDnsSuffix));

            return vaultUri;
        }

        private Uri CreateVaultUri(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");

            UriBuilder builder = new UriBuilder("https", vaultName + "." + this.KeyVaultDnsSuffix);

            return builder.Uri;
        }
    }
}

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

using Microsoft.Azure.Commands.Common.Exceptions;

using System;
using System.Linq;
using System.Text;

using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class VaultUriHelper
    {
        // it doesn't matter if this class acts as a vault uri helper or hsm uri helper
        // the logic is basically the same
        // todo: combine them together
        public VaultUriHelper(string keyVaultDnsSuffix, string managedHsmDnsSuffix = null)
        {
            if (string.IsNullOrEmpty(keyVaultDnsSuffix))
                throw new ArgumentNullException("keyVaultDnsSuffix");
            this.KeyVaultDnsSuffix = keyVaultDnsSuffix;
            ManagedHsmDnsSuffix = managedHsmDnsSuffix;
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
        public string ManagedHsmDnsSuffix { get; private set; }

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

        public Uri CreateVaultUri(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
                throw new ArgumentNullException("vaultName");

            UriBuilder builder = new UriBuilder("https", vaultName + "." + this.KeyVaultDnsSuffix);

            return builder.Uri;
        }

        public Uri CreateManagedHsmUri(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            UriBuilder builder = new UriBuilder("https", name+ "." + ManagedHsmDnsSuffix);

            return builder.Uri;
        }

        public Uri CreateaMagedHsmKeyUri(Uri mhsmUri, string keyName, string version)
        {
            if (null == mhsmUri)
                throw new ArgumentNullException("mhsmUri");
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            string relativePath = new StringBuilder().Append("keys/").Append(keyName).Append("/").Append(version).ToString();
            return new Uri(mhsmUri, relativePath);
        }
    }
}

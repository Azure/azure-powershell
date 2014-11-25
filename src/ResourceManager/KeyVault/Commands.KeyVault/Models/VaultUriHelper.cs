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
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class VaultUriHelper
    {
        public VaultUriHelper(string keyVaultDnsSuffix)
        {
            if (string.IsNullOrEmpty(keyVaultDnsSuffix))
            {
                throw new ArgumentNullException("keyVaultDnsSuffix");
            }
            this.KeyVaultDnsSuffix = keyVaultDnsSuffix;
        }

        public string GetVaultName(string vaultAddress)
        {   
            Uri vaultUri = CreateAndValidateVaultUri(vaultAddress);         
            return vaultUri.Host.Split('.').First();
        }

        public string GetKeyName(string keyAddress)
        {
            Uri vaultUri = CreateAndValidateVaultUri(keyAddress);

            var keyName = GetValueUnderPath(vaultUri, KeyPathName);
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentException(string.Format(Resources.InvalidKeyUri, keyAddress));
            }

            return keyName;
        }

        public string GetSecretName(string secretAddress)
        {
            Uri vaultUri = CreateAndValidateVaultUri(secretAddress);

            var secretName = GetValueUnderPath(vaultUri, SecretPathName);
            if (string.IsNullOrEmpty(secretName)) 
            {
                throw new ArgumentException(string.Format(Resources.InvalidSecretUri, secretAddress));
            }

            return secretName;
        }
        
        public String CreateVaultAddress(string vaultName)
        {
            return CreateVaultUri(vaultName).ToString();
        }       

        public string CreateKeyAddress(string vaultName, string keyName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(keyName))
            {
                throw new ArgumentNullException("keyName");
            }

            return new Uri(CreateVaultUri(vaultName),
                string.Format("/{0}/{1}/", KeyPathName, keyName)).ToString();
        }       

        public string CreateSecretAddress(string vaultName, string secretName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }
            if (string.IsNullOrEmpty(secretName))
            {
                throw new ArgumentNullException("secretName");
            }

            return new Uri(CreateVaultUri(vaultName), 
                string.Format("/{0}/{1}/", SecretPathName, secretName)).ToString();      
        }

        public string KeyVaultDnsSuffix { get; private set; }
        private Uri CreateAndValidateVaultUri(string vaultAddress)
        {
            if (string.IsNullOrEmpty(vaultAddress))
            {
                throw new ArgumentNullException("vaultAddress");
            }

            Uri vaultUri;
            if (!Uri.TryCreate(vaultAddress, UriKind.Absolute, out vaultUri))
            {
                throw new ArgumentException(string.Format(Resources.InvalidVaultUri, vaultAddress, this.KeyVaultDnsSuffix));
            }              

            if (vaultUri.HostNameType != UriHostNameType.Dns ||
                !vaultUri.Host.EndsWith(this.KeyVaultDnsSuffix))
            {
                throw new ArgumentException(string.Format(Resources.InvalidVaultUri, vaultAddress, this.KeyVaultDnsSuffix));
            }
            
            return vaultUri;
        }

        private string GetValueUnderPath(Uri vaultUri, string pathName)
        {
            if (vaultUri.Segments == null ||
                vaultUri.Segments.Length < 3 ||
                !string.Equals(vaultUri.Segments[1].TrimEnd('/'), pathName, StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }

            return vaultUri.Segments[2].TrimEnd('/');
        }

        private Uri CreateVaultUri(string vaultName)
        {
            if (string.IsNullOrEmpty(vaultName))
            {
                throw new ArgumentNullException("vaultName");
            }

            UriBuilder builder = new UriBuilder("https", vaultName + "." + this.KeyVaultDnsSuffix);

            return builder.Uri;
        }       

       
        private const string KeyPathName = "keys";
        private const string SecretPathName = "secrets";                 
    }
}

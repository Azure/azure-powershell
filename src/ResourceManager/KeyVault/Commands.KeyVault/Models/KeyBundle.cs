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

using Microsoft.Azure.KeyVault.WebKey;
using System;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyBundle : ObjectIdentifier
    {
        public KeyBundle()
        { }

        internal KeyBundle(Azure.KeyVault.Models.KeyBundle keyBundle, VaultUriHelper vaultUriHelper)
        {
            if (keyBundle == null)
                throw new ArgumentNullException("keyBundle");
            if (keyBundle.Key == null || keyBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyBundle);

            SetObjectIdentifier(vaultUriHelper, keyBundle.KeyIdentifier);

            Key = keyBundle.Key;
            Attributes = new KeyAttributes(
                keyBundle.Attributes.Enabled,
                keyBundle.Attributes.Expires, 
                keyBundle.Attributes.NotBefore, 
                keyBundle.Key.Kty, 
                keyBundle.Key.KeyOps.ToArray(),
                keyBundle.Attributes.Created,
                keyBundle.Attributes.Updated,
                keyBundle.Tags);
        }

        public KeyAttributes Attributes { get; set; }

        public JsonWebKey Key { get; set; }

    }
}

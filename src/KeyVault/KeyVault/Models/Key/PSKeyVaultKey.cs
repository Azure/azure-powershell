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

using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.Azure.KeyVault.WebKey;

using System;
using System.Linq;

using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Track1Sdk = Microsoft.Azure.KeyVault.Models;
using Track2Sdk = Azure.Security.KeyVault.Keys;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultKey : PSKeyVaultKeyIdentityItem
    {
        #region Constructors
        public PSKeyVaultKey()
        { }

        internal PSKeyVaultKey(Track1Sdk.KeyBundle keyBundle, VaultUriHelper vaultUriHelper, bool isHsm = false)
            : base(keyBundle, isHsm)
        {
            if (keyBundle == null)
                throw new ArgumentNullException("keyBundle");
            if (keyBundle.Key == null || keyBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyBundle);

            SetObjectIdentifier(vaultUriHelper, keyBundle.KeyIdentifier);

            // Key properties
            Key = keyBundle.Key;

            // Quick access for key properties
            KeySize = JwkHelper.ConvertToRSAKey(Key)?.KeySize;

            // Key additional properties
            Attributes = new PSKeyVaultKeyAttributes(keyBundle);
        }

        internal PSKeyVaultKey(Track2Sdk.KeyVaultKey key, VaultUriHelper vaultUriHelper, bool isHsm)
            :base(key?.Properties, null, isHsm)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (key.Key == null || key.Properties == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyBundle);

            // Set Id, Name, Version and VaultName
            SetObjectIdentifier(vaultUriHelper, new Microsoft.Azure.KeyVault.KeyIdentifier(key.Id.ToString()));

            // Key properties
            Key = key.Key.ToTrack1JsonWebKey();

            // Quick access for key properties
            KeySize = JwkHelper.ConvertToRSAKey(Key)?.KeySize;

            // Key additional properties
            Attributes = new PSKeyVaultKeyAttributes(key);
        }
        #endregion

        #region Basic attributes
        public JsonWebKey Key { get; set; }

        public string KeyType
        {
            get { return Key.Kty; }
        }

        public PSKeyVaultKeyAttributes Attributes { get; set; }
        #endregion

        #region Quick access for additional properties
        // Quick access for additional property CurveName
        public string CurveName
        {
            get { return Key.CurveName; }
        }

        // Quick access for additional property KeySize
        public int? KeySize;

        // Quick access for additional property KeySize
        public PSKeyReleasePolicy ReleasePolicy 
        {
            get
            {
                return Attributes.ReleasePolicy;
            }
        }

        #endregion
    }
}

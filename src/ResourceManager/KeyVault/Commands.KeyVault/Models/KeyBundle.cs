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
using Microsoft.KeyVault.WebKey;
using Client = Microsoft.KeyVault.Client;
using Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyBundle : ObjectIdentifier
    {
        public KeyBundle()
        { }

        internal KeyBundle(Client.KeyBundle clientKeyBundle, VaultUriHelper vaultUriHelper)
        {
            if (clientKeyBundle == null)
            {
                throw new ArgumentNullException("clientKeyBundle");
            }            
            if (clientKeyBundle.Key == null || clientKeyBundle.Attributes == null)
            {
                throw new ArgumentException(Resources.InvalidKeyBundle);
            }

            SetObjectIdentifier(vaultUriHelper, new Client.KeyIdentifier(clientKeyBundle.Key.Kid));

            Key = clientKeyBundle.Key;
            Attributes = new KeyAttributes(
                clientKeyBundle.Attributes.Enabled,
                clientKeyBundle.Attributes.Expires, 
                clientKeyBundle.Attributes.NotBefore, 
                clientKeyBundle.Key.Kty, 
                clientKeyBundle.Key.KeyOps);                   
        }

        public KeyAttributes Attributes { get; set; }

        public JsonWebKey Key { get; set; }
        
    }
}

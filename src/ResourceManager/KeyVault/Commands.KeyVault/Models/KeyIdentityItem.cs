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
using Microsoft.Azure.Commands.KeyVault.WebKey;
using Client = Microsoft.Azure.Commands.KeyVault.Client;
using Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class KeyIdentityItem : ObjectIdentifier
    {
        internal KeyIdentityItem(Client.KeyItem clientKeyItem, VaultUriHelper vaultUriHelper)
        {
            if (clientKeyItem == null)
            {
                throw new ArgumentNullException("clientKeyItem");
            }
            if (String.IsNullOrEmpty(clientKeyItem.Kid) || clientKeyItem.Attributes == null)
            {
                throw new ArgumentException(Resources.InvalidKeyBundle);
            }

            SetObjectIdentifier(vaultUriHelper, new Client.KeyIdentifier(clientKeyItem.Kid));

            var attribute = new KeyAttributes(
                clientKeyItem.Attributes.Enabled,
                clientKeyItem.Attributes.Expires,
                clientKeyItem.Attributes.NotBefore);

            Enabled = attribute.Enabled;
            Expires = attribute.Expires;
            NotBefore = attribute.NotBefore;
            Id = clientKeyItem.Kid;
        }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }
    }
}

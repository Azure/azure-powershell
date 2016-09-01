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
using System.Collections;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class CertificateIdentityItem : ObjectIdentifier
    {
        internal CertificateIdentityItem(CertificateItem certItem, VaultUriHelper vaultUriHelper)
        {
            if (certItem == null)
                throw new ArgumentNullException("certItem");
            if (certItem.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyAttributes);
            if (certItem.Identifier == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyIdentifier);

            SetObjectIdentifier(vaultUriHelper, certItem.Identifier);

            Enabled = certItem.Attributes.Enabled;
            Expires = certItem.Attributes.Expires;
            NotBefore = certItem.Attributes.NotBefore;
            Created = certItem.Attributes.Created;
            Updated = certItem.Attributes.Updated;
            Tags = (certItem.Tags == null) ? null : certItem.Tags.ConvertToHashtable();
        }

        internal CertificateIdentityItem(CertificateBundle certBundle)
        {
            if (certBundle == null)
                throw new ArgumentNullException("certBundle");
            if (certBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidKeyAttributes);

            SetObjectIdentifier(new ObjectIdentifier
            {
                Id = certBundle.CertificateIdentifier.Identifier,
                Name = certBundle.CertificateIdentifier.Name,
                VaultName = certBundle.CertificateIdentifier.VaultWithoutScheme,
                Version = certBundle.CertificateIdentifier.Version
            });

            Enabled = certBundle.Attributes.Enabled;
            Expires = certBundle.Attributes.Expires;
            NotBefore = certBundle.Attributes.NotBefore;
            Created = certBundle.Attributes.Created;
            Updated = certBundle.Attributes.Updated;
            Tags = certBundle.Tags.ConvertToHashtable();
        }

        public bool? Enabled { get; set; }

        public DateTime? Expires { get; set; }

        public DateTime? NotBefore { get; set; }

        public DateTime? Created { get; private set; }

        public DateTime? Updated { get; private set; }

        public Hashtable Tags { get; set; }
    }
}

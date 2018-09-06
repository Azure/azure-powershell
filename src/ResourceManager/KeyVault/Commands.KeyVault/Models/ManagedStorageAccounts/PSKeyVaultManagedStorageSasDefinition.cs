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
using Microsoft.Azure.KeyVault;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultManagedStorageSasDefinition : PSKeyVaultManagedStorageSasDefinitionIdentityItem
    {
        internal PSKeyVaultManagedStorageSasDefinition( Azure.KeyVault.Models.SasDefinitionBundle storageSasDefinitionBundle, VaultUriHelper vaultUriHelper )
        {
            if ( storageSasDefinitionBundle == null )
                throw new ArgumentNullException(nameof(storageSasDefinitionBundle));

            if ( vaultUriHelper == null )
                throw new ArgumentNullException(nameof(vaultUriHelper));

            var identifier = new SasDefinitionIdentifier(storageSasDefinitionBundle.Id);
            SetObjectIdentifier(vaultUriHelper, identifier);

            Attributes = storageSasDefinitionBundle.Attributes == null ? null : new PSKeyVaultManagedStorageSasDefinitionAttributes(storageSasDefinitionBundle.Attributes);
            Tags = storageSasDefinitionBundle.Tags == null ? null : storageSasDefinitionBundle.Tags.ConvertToHashtable();
            Sid = storageSasDefinitionBundle.SecretId;
            TemplateUri = storageSasDefinitionBundle.TemplateUri;
            SasType = storageSasDefinitionBundle.SasType;
            ValidityPeriod = storageSasDefinitionBundle.ValidityPeriod;
            AccountName = identifier.StorageAccount;
        }

        public string TemplateUri { get; set; }

        public string SasType { get; set; }

        public string ValidityPeriod { get; set; }
    }
}

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
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models.ManagedStorageAccounts
{
    public sealed class PSDeletedKeyVaultManagedStorageSasDefinition : PSDeletedKeyVaultManagedStorageSasDefinitionIdentityItem
    {
        public PSDeletedKeyVaultManagedStorageSasDefinition()
        { }

        internal PSDeletedKeyVaultManagedStorageSasDefinition(Microsoft.Azure.KeyVault.Models.DeletedSasDefinitionBundle deletedSasDefinitionBundle, VaultUriHelper vaultUriHelper)
        {
            if (deletedSasDefinitionBundle == null)
                throw new ArgumentNullException(nameof(deletedSasDefinitionBundle));
            if (deletedSasDefinitionBundle.Attributes == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidManagedStorageObjectAttributes);
            if (deletedSasDefinitionBundle.Id == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidStorageSasDefinitionIdentifier);

            var identifier = new Microsoft.Azure.KeyVault.SasDefinitionIdentifier(deletedSasDefinitionBundle.Id);
            SetObjectIdentifier(vaultUriHelper, identifier);

            Attributes = deletedSasDefinitionBundle.Attributes == null ? null : new PSKeyVaultManagedStorageSasDefinitionAttributes(deletedSasDefinitionBundle.Attributes);
            Tags = deletedSasDefinitionBundle.Tags == null ? null : deletedSasDefinitionBundle.Tags.ConvertToHashtable();
            Sid = deletedSasDefinitionBundle.SecretId;
            TemplateUri = deletedSasDefinitionBundle.TemplateUri;
            SasType = deletedSasDefinitionBundle.SasType;
            ValidityPeriod = deletedSasDefinitionBundle.ValidityPeriod;
            AccountName = identifier.StorageAccount;

            ScheduledPurgeDate = deletedSasDefinitionBundle.ScheduledPurgeDate;
            DeletedDate = deletedSasDefinitionBundle.DeletedDate;
        }

        public string TemplateUri { get; set; }

        public string SasType { get; set; }

        public string ValidityPeriod { get; set; }
    }
}

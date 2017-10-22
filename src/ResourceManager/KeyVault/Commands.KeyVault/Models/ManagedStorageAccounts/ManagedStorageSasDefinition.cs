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
using Microsoft.Azure.KeyVault;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class ManagedStorageSasDefinition : ManagedStorageSasDefinitionListItem
    {
        internal ManagedStorageSasDefinition( Azure.KeyVault.Models.SasDefinitionBundle storageSasDefinitionBundle, VaultUriHelper vaultUriHelper )
        {
            if ( storageSasDefinitionBundle == null )
                throw new ArgumentNullException( "storageSasDefinitionBundle" );

            if ( vaultUriHelper == null )
                throw new ArgumentNullException( "vaultUriHelper" );

            var identifier = new SasDefinitionIdentifier( storageSasDefinitionBundle.Id );

            Id = identifier.Identifier;
            VaultName = vaultUriHelper.GetVaultName( identifier.Identifier );
            Name = identifier.Name;
            Attributes = storageSasDefinitionBundle.Attributes == null ? null : new ManagedStorageSasDefinitionAttributes( storageSasDefinitionBundle.Attributes.Enabled, storageSasDefinitionBundle.Attributes.Created, storageSasDefinitionBundle.Attributes.Updated );
            Tags = storageSasDefinitionBundle.Tags == null ? null : storageSasDefinitionBundle.Tags.ConvertToHashtable();
            Sid = storageSasDefinitionBundle.SecretId;
            Parameter = storageSasDefinitionBundle.Parameters == null ? null : storageSasDefinitionBundle.Parameters.ConvertToHashtable();
            AccountName = identifier.StorageAccount;
        }

        public Hashtable Parameter { get; set; }

        public string ParameterTable
        {
            get
            {
                return ( Parameter == null ) ? null : Parameter.ConvertToTagsTable();
            }
        }
    }
}

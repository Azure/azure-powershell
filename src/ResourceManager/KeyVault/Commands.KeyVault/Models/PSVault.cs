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
using System.Linq;
using Microsoft.Azure.Commands.Tags.Model;
using KeyVaultManagement = Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.Azure.Commands.Resources.Models;


namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSVault : PSVaultIdentityItem
    {
        public PSVault(KeyVaultManagement.Vault vault, ActiveDirectoryClient adClient)
        {
            var vaultTenantDisplayName = ModelExtensions.GetDisplayNameForTenant(vault.Properties.TenantId, adClient);
            VaultName = vault.Name;
            Location = vault.Location;
            ResourceId = vault.Id;
            ResourceGroupName = (new ResourceIdentifier(vault.Id)).ResourceGroupName;
            Tags = TagsConversionHelper.CreateTagHashtable(vault.Tags);
            Sku = vault.Properties.Sku.Name;
            TenantId = vault.Properties.TenantId;
            TenantName = vaultTenantDisplayName;
            VaultUri = vault.Properties.VaultUri;
            EnabledForDeployment = vault.Properties.EnabledForDeployment;
            EnabledForTemplateDeployment = vault.Properties.EnabledForTemplateDeployment;
            EnabledForDiskEncryption = vault.Properties.EnabledForDiskEncryption;
            AccessPolicies = vault.Properties.AccessPolicies.Select(s => new PSVaultAccessPolicy(s, adClient)).ToArray();
            OriginalVault = vault;
        }
        public string VaultUri { get; private set; }

        public Guid TenantId { get; private set; }

        public string TenantName { get; private set; }

        public string Sku { get; private set; }

        public bool EnabledForDeployment { get; private set; }

        public bool? EnabledForTemplateDeployment { get; private set; }

        public bool? EnabledForDiskEncryption { get; private set; }

        public PSVaultAccessPolicy[] AccessPolicies { get; private set; }

        public string AccessPoliciesText { get { return ModelExtensions.ConstructAccessPoliciesList(AccessPolicies); } }

        //If we got this vault from the server, save the over-the-wire version, to 
        //allow easy updates
        public KeyVaultManagement.Vault OriginalVault { get; private set; }
    }
}

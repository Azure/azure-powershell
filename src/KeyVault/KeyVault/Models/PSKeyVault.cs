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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVault : PSKeyVaultIdentityItem
    {
        public PSKeyVault()
        {
        }

        public PSKeyVault(Vault vault, IMicrosoftGraphClient graphClient)
        {
            var vaultTenantDisplayName = ModelExtensions.GetDisplayNameForTenant(vault.Properties.TenantId, graphClient);
            VaultName = vault.Name;
            Location = vault.Location;
            ResourceId = vault.Id;
            ResourceGroupName = (new ResourceIdentifier(vault.Id)).ResourceGroupName;
            Tags = TagsConversionHelper.CreateTagHashtable(vault.Tags);
            Sku = vault.Properties.Sku.Name.ToString();
            TenantId = vault.Properties.TenantId;
            TenantName = vaultTenantDisplayName;
            VaultUri = vault.Properties.VaultUri;
            EnabledForDeployment = vault.Properties.EnabledForDeployment ?? false;
            EnabledForTemplateDeployment = vault.Properties.EnabledForTemplateDeployment;
            EnabledForDiskEncryption = vault.Properties.EnabledForDiskEncryption;
            EnableSoftDelete = vault.Properties.EnableSoftDelete;
            EnablePurgeProtection = vault.Properties.EnablePurgeProtection;
            EnableRbacAuthorization = vault.Properties.EnableRbacAuthorization;
            PublicNetworkAccess = vault.Properties.PublicNetworkAccess;
            SoftDeleteRetentionInDays = vault.Properties.SoftDeleteRetentionInDays;
            AccessPolicies = vault.Properties.AccessPolicies.Select(s => new PSKeyVaultAccessPolicy(s, graphClient)).ToArray();
            NetworkAcls = InitNetworkRuleSet(vault.Properties);
            OriginalVault = vault;
        }
        public string PublicNetworkAccess { get; private set; }

        public string VaultUri { get; private set; }

        public Guid TenantId { get; private set; }

        public string TenantName { get; private set; }

        public string Sku { get; private set; }

        public bool EnabledForDeployment { get; private set; }

        public bool? EnabledForTemplateDeployment { get; private set; }

        public bool? EnabledForDiskEncryption { get; private set; }

        public bool? EnableSoftDelete { get; private set; }

        public bool? EnablePurgeProtection { get; internal set; }

        public bool? EnableRbacAuthorization { get; private set; }

        public int? SoftDeleteRetentionInDays { get; private set; }

        public PSKeyVaultAccessPolicy[] AccessPolicies { get; private set; }

        public string AccessPoliciesText { get { return ModelExtensions.ConstructAccessPoliciesList(AccessPolicies); } }

        public PSKeyVaultNetworkRuleSet NetworkAcls { get; private set; }

        public string NetworkAclsText { get { return ModelExtensions.ConstructNetworkRuleSet(NetworkAcls); } }

        //If we got this vault from the server, save the over-the-wire version, to
        //allow easy updates
        public Vault OriginalVault { get; private set; }

        private static PSKeyVaultNetworkRuleSet InitNetworkRuleSet(VaultProperties properties)
        {
            // The service will return NULL when NetworkAcls is never set before or set with default values
            // The default constructor will set default property values in SDK's NetworkRuleSet class
            if (properties?.NetworkAcls == null)
            {
                return new PSKeyVaultNetworkRuleSet();
            }

            var networkAcls = properties.NetworkAcls;

            PSKeyVaultNetworkRuleDefaultActionEnum defaultAct;
            if (!Enum.TryParse(networkAcls.DefaultAction, true, out defaultAct))
            {
                defaultAct = PSKeyVaultNetworkRuleDefaultActionEnum.Allow;
            }

            PSKeyVaultNetworkRuleBypassEnum bypass;
            if (!Enum.TryParse(networkAcls.Bypass, true, out bypass))
            {
                bypass = PSKeyVaultNetworkRuleBypassEnum.AzureServices;
            }

            IList<string> allowedIpAddresses = null;
            if (networkAcls.IpRules != null && networkAcls.IpRules.Count > 0)
            {
                allowedIpAddresses = networkAcls.IpRules.Select(item => item.Value).ToList();
            }

            IList<string> allowedVirtualNetworkResourceIds = null;
            if (networkAcls.VirtualNetworkRules != null && networkAcls.VirtualNetworkRules.Count > 0)
            {
                allowedVirtualNetworkResourceIds = networkAcls.VirtualNetworkRules.Select(item => item.Id).ToList();
            }

            return new PSKeyVaultNetworkRuleSet(defaultAct, bypass, allowedIpAddresses, allowedVirtualNetworkResourceIds);
        }
    }
}

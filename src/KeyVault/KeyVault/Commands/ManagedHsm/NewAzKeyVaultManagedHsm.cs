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

using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    /// <summary>
    /// Create a new managed HSM.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsm", SupportsShouldProcess = true)]
    [OutputType(typeof(PSManagedHsm))]
    public class NewAzKeyVaultManagedHsm : KeyVaultManagementCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// HSM name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "Specifies a name of the managed HSM to create. The name can be any combination of letters, digits, or hyphens. The name must start and end with a letter or digit. The name must be universally unique."
            )]
        [ValidateNotNullOrEmpty]
        [Alias("HsmName")]
        public string Name { get; set; }

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the name of an existing resource group in which to create the key vault.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the Azure region in which to create the managed HSM pool. Use the command Get-AzResourceProvider with the ProviderNamespace parameter to see your choices.")]
        [LocationCompleter("Microsoft.KeyVault/managedHSMs")]
        [ValidateNotNullOrEmpty()]
        public string Location { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Initial administrator object id for this managed HSM pool.")]
        public string[] Administrator { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the SKU of the managed HSM instance.")]
        [PSArgumentCompleter("StandardB1", "CustomB32", "CustomB6", "CustomC42", "CustomC10")]
        public string Sku { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Specifies how long the deleted managed hsm pool is retained, and how long until the managed hsm pool in the deleted state can be purged.")]
        [ValidateRange(Constants.MinSoftDeleteRetentionDays, Constants.MaxSoftDeleteRetentionDays)]
        [ValidateNotNullOrEmpty]
        public int SoftDeleteRetentionInDays { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Controls permission for data plane traffic coming from public networks while private endpoint is enabled.")]
        [PSArgumentCompleter("Enabled", "Disabled")]
        public string PublicNetworkAccess { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "specifying whether protection against purge is enabled for this managed HSM pool. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible.")]
        public SwitchParameter EnablePurgeProtection { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The set of user assigned identities associated with the managed HSM. Its value will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.")]
        public string[] UserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hash table which represents resource tags.")]
        [Alias(Constants.TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Specifies a Managed HSM network rule set object (from New-AzKeyVaultManagedHsmNetworkRuleSetObject) to configure default action, bypass, IP rules, and virtual network rules at creation time.")]
        [ValidateNotNull]
        public PSManagedHsmNetworkRuleSet NetworkRuleSet { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.CreateKeyVault))
            {
                if (VaultExistsInCurrentSubscription(Name, true))
                {
                    throw new ArgumentException(Resources.HsmAlreadyExists);
                }

                this.WriteObject(KeyVaultManagementClient.CreateOrRecoverManagedHsm(PrepareParameters(), GraphClient));
            }
        }

        private VaultCreationOrUpdateParameters PrepareParameters()
        {
            ManagedServiceIdentity managedServiceIdentity = null;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UserAssignedIdentity)) && this.UserAssignedIdentity.Length > 0)
            {
                managedServiceIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>()
                };
                UserAssignedIdentity?.ForEach(id => managedServiceIdentity.UserAssignedIdentities.Add(id, new UserAssignedIdentity()));
            };

            // Build network ACLs: use provided PS object if bound, otherwise default empty set
            MhsmNetworkRuleSet networkAcls;
            if (MyInvocation.BoundParameters.ContainsKey(nameof(NetworkRuleSet)) && NetworkRuleSet != null)
            {
                networkAcls = ConvertToServiceNetworkRuleSet(NetworkRuleSet);
            }
            else
            {
                networkAcls = new MhsmNetworkRuleSet();
            }

            // Enforce DefaultAction rule for initial network ACLs if provided
            if ((string.IsNullOrEmpty(PublicNetworkAccess) || PublicNetworkAccess.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                && networkAcls != null
                && ( (networkAcls.IPRules != null && networkAcls.IPRules.Count > 0) || (networkAcls.VirtualNetworkRules != null && networkAcls.VirtualNetworkRules.Count > 0) )
                && string.Equals(networkAcls.DefaultAction, "Allow", StringComparison.OrdinalIgnoreCase))
            {
                networkAcls.DefaultAction = "Deny";
                WriteWarning("DefaultAction automatically set to Deny because PublicNetworkAccess is Enabled and IP or Virtual Network rules are specified.");
            }

            return new VaultCreationOrUpdateParameters()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.Location,
                SkuName = this.Sku,
                TenantId = GetTenantId(),
                Tags = this.Tag,
                Administrator = this.Administrator,
                SkuFamilyName = DefaultManagedHsmSkuFamily,
                // If retention days is not specified, use the default value
                SoftDeleteRetentionInDays = this.SoftDeleteRetentionInDays,
                // false is not accepted
                EnablePurgeProtection = this.EnablePurgeProtection.IsPresent ? true : (bool?)null,
                MhsmNetworkAcls = networkAcls,
                PublicNetworkAccess = this.PublicNetworkAccess,
                ManagedServiceIdentity = managedServiceIdentity
            };
        }

        private static MhsmNetworkRuleSet ConvertToServiceNetworkRuleSet(PSManagedHsmNetworkRuleSet ps)
        {
            var svc = new MhsmNetworkRuleSet
            {
                DefaultAction = ps.DefaultAction.ToString(),
                Bypass = ps.Bypass.ToString()
            };
            if (ps.IpAddressRanges != null)
            {
                svc.IPRules = ps.IpAddressRanges.Select(v => new MhsmipRule { Value = v }).ToList();
            }
            if (ps.VirtualNetworkResourceIds != null)
            {
                svc.VirtualNetworkRules = ps.VirtualNetworkResourceIds.Select(id => new MhsmVirtualNetworkRule { Id = id }).ToList();
            }
            // Service requirement: if any IP/service tag/virtual network rules are specified under enabled public access, DefaultAction must be Deny.
            // We conservatively enforce: if rules specified and DefaultAction is Allow, flip to Deny (public access default is Enabled when unspecified).
            if ((svc.IPRules != null && svc.IPRules.Count > 0) || (svc.VirtualNetworkRules != null && svc.VirtualNetworkRules.Count > 0))
            {
                if (string.Equals(svc.DefaultAction, "Allow", StringComparison.OrdinalIgnoreCase))
                {
                    svc.DefaultAction = "Deny";
                }
            }
            return svc;
        }
    }
}

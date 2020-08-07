#if NETSTANDARD
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
#else
using Microsoft.Azure.ActiveDirectory.GraphClient;
#endif
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSManagedHsm : PSKeyVaultIdentityItem
    {
        public PSManagedHsm()
        {
        }

        public PSManagedHsm(ManagedHsm managedHsm, ActiveDirectoryClient adClient)
        {
            // PSKeyVaultIdentityItem's properties
            ResourceId = managedHsm.Id;
            VaultName = managedHsm.Name;
            ResourceGroupName = (new ResourceIdentifier(managedHsm.Id)).ResourceGroupName;
            Location = managedHsm.Location;
            Tags = TagsConversionHelper.CreateTagHashtable(managedHsm.Tags);

            // PSManagedHsm's properties
            Sku = managedHsm.Sku.Name.ToString();
            TenantId = managedHsm.Properties.TenantId.Value;
            TenantName = ModelExtensions.GetDisplayNameForTenant(TenantId, adClient);
            SecurityDomainId = managedHsm.Properties.SecurityDomainId.Value;
            SecurityDomainName = ModelExtensions.GetDisplayNameForTenant(SecurityDomainId, adClient);
            InitialAdminObjectIds = managedHsm.Properties.InitialAdminObjectIds;
            HsmPoolUri = managedHsm.Properties.HsmPoolUri;
            EnablePurgeProtection = managedHsm.Properties.EnablePurgeProtection;
            EnableSoftDelete = managedHsm.Properties.EnableSoftDelete;
            SoftDeleteRetentionInDays = managedHsm.Properties.SoftDeleteRetentionInDays;
            // AccessPolicies = vault.Properties.AccessPolicies.Select(s => new PSKeyVaultAccessPolicy(s, adClient)).ToArray();
            // NetworkAcls = InitNetworkRuleSet(managedHsm.Properties);
            OriginalManagedHsm = managedHsm;
        }

        public string Sku { get; private set; }
        public Guid TenantId { get; private set; }
        public string TenantName { get; private set; }
        public Guid SecurityDomainId { get; private set; }
        public string SecurityDomainName { get; private set; }
        public IList<string> InitialAdminObjectIds { get; private set; }
        public string HsmPoolUri { get; private set; }
        public bool? EnableSoftDelete { get; private set; }
        public int? SoftDeleteRetentionInDays { get; private set; }
        public bool? EnablePurgeProtection { get; private set; }
        public ManagedHsm OriginalManagedHsm { get; private set; }

    }
}

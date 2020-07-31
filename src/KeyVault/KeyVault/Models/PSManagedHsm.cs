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
    public class PSManagedHsm:PSKeyVaultIdentityItem
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
            SecurityDomainName = ModelExtensions.GetDisplayNameForTenant(SecurityDomainId,adClient) ;
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

   /*   Comments temporarily  
    *     
    *   public PSKeyVaultAccessPolicy[] AccessPolicies { get; private set; }

        public string AccessPoliciesText { get { return ModelExtensions.ConstructAccessPoliciesList(AccessPolicies); } }

        public PSKeyVaultNetworkRuleSet NetworkAcls { get; private set; }

        public string NetworkAclsText { get { return ModelExtensions.ConstructNetworkRuleSet(NetworkAcls); } }

        //If we got this vault from the server, save the over-the-wire version, to
        //allow easy updates

        private static PSKeyVaultNetworkRuleSet InitNetworkRuleSet(VaultProperties properties)
        {
            // The service will return NULL when NetworkAcls is never set before or set with default property values
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
    */
    }
}

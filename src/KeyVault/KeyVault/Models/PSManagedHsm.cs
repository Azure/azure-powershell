#if NETSTANDARD
using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
#else
using Microsoft.Azure.ActiveDirectory.GraphClient;
#endif
using System;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;

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

            // PSManagedHsm's properties, hides type
            Name = managedHsm.Name;
            Sku = managedHsm.Sku.Name.ToString();
            TenantId = managedHsm.Properties.TenantId.Value;
            TenantName = ModelExtensions.GetDisplayNameForTenant(TenantId, adClient);
            InitialAdminObjectIds = managedHsm.Properties.InitialAdminObjectIds.ToArray<string>();
            HsmUri = managedHsm.Properties.HsmUri;
            EnablePurgeProtection = managedHsm.Properties.EnablePurgeProtection;
            EnableSoftDelete = managedHsm.Properties.EnableSoftDelete;
            SoftDeleteRetentionInDays = managedHsm.Properties.SoftDeleteRetentionInDays;
            StatusMessage = managedHsm.Properties.StatusMessage;
            ProvisioningState = managedHsm.Properties.ProvisioningState;
            OriginalManagedHsm = managedHsm;
        }

        public string Name { get; private set; }
        public string Sku { get; private set; }
        public Guid TenantId { get; private set; }
        public string TenantName { get; private set; }
        public string[] InitialAdminObjectIds { get; private set; }
        public string HsmUri { get; private set; }
        public bool? EnableSoftDelete { get; private set; }
        public int? SoftDeleteRetentionInDays { get; private set; }
        public bool? EnablePurgeProtection { get; private set; }
        public string StatusMessage { get; private set; }
        public string ProvisioningState { get; private set; }
        public ManagedHsm OriginalManagedHsm { get; private set; }

    }
}

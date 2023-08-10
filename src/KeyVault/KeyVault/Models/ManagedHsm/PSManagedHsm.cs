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
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Linq;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSManagedHsm : PSKeyVaultIdentityItem
    {
        public PSManagedHsm()
        {
        }

        public PSManagedHsm(ManagedHsm managedHsm, IMicrosoftGraphClient graphClient)
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
            TenantName = ModelExtensions.GetDisplayNameForTenant(TenantId, graphClient);
            InitialAdminObjectIds = managedHsm.Properties.InitialAdminObjectIds.ToArray<string>();
            HsmUri = managedHsm.Properties.HsmUri;
            EnablePurgeProtection = managedHsm.Properties.EnablePurgeProtection;
            EnableSoftDelete = managedHsm.Properties.EnableSoftDelete;
            PublicNetworkAccess = managedHsm.Properties.PublicNetworkAccess;
            SoftDeleteRetentionInDays = managedHsm.Properties.SoftDeleteRetentionInDays;
            StatusMessage = managedHsm.Properties.StatusMessage;
            ProvisioningState = managedHsm.Properties.ProvisioningState;
            SecurityDomain = new PSManagedHSMSecurityDomain(managedHsm?.Properties?.SecurityDomainProperties);
            OriginalManagedHsm = managedHsm;
        }

        public string Name
        {
            get { return VaultName; }
            internal set { VaultName = value; }
        }

        public string PublicNetworkAccess { get; private set; }

        public string Sku { get; private set; }
        public Guid TenantId { get; private set; }
        public string TenantName { get; private set; }
        public string[] InitialAdminObjectIds { get; private set; }
        public string HsmUri { get; private set; }
        public bool? EnableSoftDelete { get; private set; }
        public int? SoftDeleteRetentionInDays { get; private set; }
        public bool? EnablePurgeProtection { get; internal set; }
        public string StatusMessage { get; private set; }
        public string ProvisioningState { get; private set; }

        public PSManagedHSMSecurityDomain SecurityDomain { get; private set; }

        public ManagedHsm OriginalManagedHsm { get; private set; }

    }
}

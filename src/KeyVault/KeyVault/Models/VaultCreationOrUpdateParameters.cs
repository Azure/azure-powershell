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
using Track2ManagementSdk = Azure.ResourceManager.KeyVault.Models;
using Track1ManagementSdk = Microsoft.Azure.Management.KeyVault.Models;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class VaultCreationOrUpdateParameters
    {
        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public Hashtable Tags { get; set; }
        public string SkuName { get; set; }
        public string SkuFamilyName { get; set; }
        public bool? EnabledForDeployment { get; set; }
        public bool? EnabledForTemplateDeployment { get; set; }
        public bool? EnabledForDiskEncryption { get; set; }
        public bool? EnableSoftDelete { get; set; }
        public bool? EnablePurgeProtection { get; set; }
        public bool? EnableRbacAuthorization { get; set; }
        public int? SoftDeleteRetentionInDays { get; set; }
        public string PublicNetworkAccess { get; set; }
        public Guid TenantId { get; set; }
        public Track1ManagementSdk.AccessPolicyEntry AccessPolicy { get; set; }
        public Track1ManagementSdk.NetworkRuleSet NetworkAcls { get; set; }
        public Track1ManagementSdk.CreateMode? CreateMode { get; set; }

        public Track1ManagementSdk.MHSMNetworkRuleSet MhsmNetworkAcls { get; set; }
        public string[] Administrator { get; set; }

        public Track1ManagementSdk.VaultCreateOrUpdateParameters ToTrack1VaultCreateOrUpdateParameters(
            PSKeyVaultNetworkRuleSet networkRuleSet = null)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException("parameters.Name");
            if (string.IsNullOrWhiteSpace(ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(Location))
                throw new ArgumentNullException("parameters.Location");

            var properties = new Track1ManagementSdk.VaultProperties();

            if (CreateMode != Track1ManagementSdk.CreateMode.Recover)
            {
                if (string.IsNullOrWhiteSpace(SkuFamilyName))
                    throw new ArgumentNullException("parameters.SkuFamilyName");
                if (TenantId == Guid.Empty)
                    throw new ArgumentException("parameters.TenantId");
                if (!string.IsNullOrWhiteSpace(SkuName))
                {
                    if (Enum.TryParse(SkuName, true, out Track1ManagementSdk.SkuName skuName))
                    {
                        properties.Sku = new Track1ManagementSdk.Sku(skuName);
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException("parameters.SkuName");
                    }
                }
                properties.EnabledForDeployment = EnabledForDeployment;
                properties.EnabledForTemplateDeployment = EnabledForTemplateDeployment;
                properties.EnabledForDiskEncryption = EnabledForDiskEncryption;
                properties.EnableSoftDelete = EnableSoftDelete;
                properties.EnablePurgeProtection = EnablePurgeProtection;
                properties.EnableRbacAuthorization = EnableRbacAuthorization;
                properties.SoftDeleteRetentionInDays = SoftDeleteRetentionInDays;
                properties.TenantId = TenantId;
                properties.VaultUri = "";
                properties.AccessPolicies = (AccessPolicy != null) ? new[] { AccessPolicy } : 
                    new Track1ManagementSdk.AccessPolicyEntry[] { };

                properties.NetworkAcls = NetworkAcls;
                if (networkRuleSet != null)
                {
                    UpdateVaultNetworkRuleSetProperties(properties, networkRuleSet);
                }
            }
            else
            {
                properties.CreateMode = Track1ManagementSdk.CreateMode.Recover;
            }

            return new Track1ManagementSdk.VaultCreateOrUpdateParameters
            {
                Location = Location,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                Properties = properties
            };
        }

        public Track2ManagementSdk.VaultCreateOrUpdateContent ToTrack2VaultCreateOrUpdateContent()
        {
            if (this == null)
                throw new ArgumentNullException("parameters");
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException("parameters.Name");
            if (string.IsNullOrWhiteSpace(ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(Location))
                throw new ArgumentNullException("parameters.Location");

            Track2ManagementSdk.KeyVaultSku sku = null;
            Track2ManagementSdk.VaultProperties properties = null;

            if (CreateMode != Track1ManagementSdk.CreateMode.Recover)
            {
                if (string.IsNullOrWhiteSpace(SkuFamilyName))
                    throw new ArgumentNullException("parameters.SkuFamilyName");
                if (TenantId == Guid.Empty)
                    throw new ArgumentException("parameters.TenantId");

                if (!string.IsNullOrWhiteSpace(SkuName) && !string.IsNullOrWhiteSpace(SkuFamilyName))
                {
                    if (Enum.TryParse(SkuName, true, out Track2ManagementSdk.KeyVaultSkuName skuName) &&
                        Enum.TryParse(SkuFamilyName, true, out Track2ManagementSdk.KeyVaultSkuFamily skuFamily))
                    {
                        sku = new Track2ManagementSdk.KeyVaultSku(skuFamily, skuName);
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException("parameters.SkuName");
                    }
                }

                properties = new Track2ManagementSdk.VaultProperties(TenantId, sku)
                {
                    EnabledForDeployment = EnabledForDeployment,
                    EnabledForTemplateDeployment = EnabledForTemplateDeployment,
                    EnabledForDiskEncryption = EnabledForDiskEncryption,
                    EnableSoftDelete = EnableSoftDelete,
                    EnablePurgeProtection = EnablePurgeProtection,
                    EnableRbacAuthorization = EnableRbacAuthorization,
                    SoftDeleteRetentionInDays = SoftDeleteRetentionInDays,
                    TenantId = TenantId,
                    VaultUri = new Uri("")
                };
                /*properties.AccessPolicies = (parameters.AccessPolicy != null) ? new[] { parameters.AccessPolicy } :
                    new Track1ManagementSdk.AccessPolicyEntry[] { };

                properties.NetworkAcls = parameters.NetworkAcls;
                if (networkRuleSet != null)
                {
                    UpdateVaultNetworkRuleSetProperties(properties, networkRuleSet);
                }*/
            }
            else
            {
                properties.CreateMode = Track2ManagementSdk.CreateMode.Recover;
            }

            return new Track2ManagementSdk.VaultCreateOrUpdateContent(Location, properties);
        }

        private void UpdateVaultNetworkRuleSetProperties(Track1ManagementSdk.VaultProperties vaultProperties, PSKeyVaultNetworkRuleSet psRuleSet)
        {
            if (vaultProperties == null)
                return;

            var updatedRuleSet = new Track1ManagementSdk.NetworkRuleSet();       // It contains default settings
            if (psRuleSet != null)
            {
                updatedRuleSet.DefaultAction = psRuleSet.DefaultAction.ToString();
                updatedRuleSet.Bypass = psRuleSet.Bypass.ToString();

                if (psRuleSet.IpAddressRanges != null && psRuleSet.IpAddressRanges.Count > 0)
                {
                    updatedRuleSet.IpRules = psRuleSet.IpAddressRanges.Select(ipAddress => new Track1ManagementSdk.IPRule { Value = ipAddress }).ToList();
                }
                else
                {   // Send empty array [] to server to override default
                    updatedRuleSet.IpRules = new List<Track1ManagementSdk.IPRule>();
                }

                if (psRuleSet.VirtualNetworkResourceIds != null && psRuleSet.VirtualNetworkResourceIds.Count > 0)
                {
                    updatedRuleSet.VirtualNetworkRules = psRuleSet.VirtualNetworkResourceIds.Select(resourceId => new Track1ManagementSdk.VirtualNetworkRule { Id = resourceId }).ToList();
                }
                else
                {   // Send empty array [] to server to override default
                    updatedRuleSet.VirtualNetworkRules = new List<Track1ManagementSdk.VirtualNetworkRule>();
                }
            }

            vaultProperties.NetworkAcls = updatedRuleSet;
        }

    }
}

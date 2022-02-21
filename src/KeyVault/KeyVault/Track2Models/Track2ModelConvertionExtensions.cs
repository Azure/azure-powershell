using System;
using System.Collections.Generic;
using System.Text;
using Track2Sdk = Azure.Security.KeyVault.Keys;
using Track1Sdk = Microsoft.Azure.KeyVault.WebKey;
using Track1ManagementSdk = Microsoft.Azure.Management.KeyVault;
using Track2ManagementSdk = Azure.ResourceManager.KeyVault;
using System.Security.Cryptography;
using System.Linq;
using Azure.ResourceManager;

namespace Microsoft.Azure.Commands.KeyVault
{
    internal static class Track2ModelConvertionExtensions
    {
        /// <summary>
        /// Converts a track 2 JsonWebKey object to track 1 type
        /// </summary>
        /// <param name="track2Key">track 2 key</param>
        /// <returns>equivalent track 1 key</returns>
        public static Track1Sdk.JsonWebKey ToTrack1JsonWebKey(this Track2Sdk.JsonWebKey track2Key)
        {
            Track1Sdk.JsonWebKey track1Key;

            // convert key specific properties
            if (track2Key.KeyType == Track2Sdk.KeyType.Ec || track2Key.KeyType == Track2Sdk.KeyType.EcHsm)
            {
                track1Key = new Track1Sdk.JsonWebKey(new Track1Sdk.ECParameters()
                {
                    Curve = track2Key.CurveName.ToString(),
                    X = track2Key.X,
                    Y = track2Key.Y,
                    D = track2Key.D
                });
            }
            else if (track2Key.KeyType == Track2Sdk.KeyType.Rsa || track2Key.KeyType == Track2Sdk.KeyType.RsaHsm)
            {
                track1Key = new Track1Sdk.JsonWebKey(track2Key.ToRSA());
            }
            // SDK doesn't have a definition of OctHSM, so I need to use string comparison
            else if (track2Key.KeyType == Track2Sdk.KeyType.Oct || track2Key.KeyType.ToString() == @"oct-HSM")
            {
                track1Key = new Track1Sdk.JsonWebKey();
                track1Key.Kty = track2Key.KeyType.ToString();
            }
            else
            {
                throw new Exception("Not supported");
            }

            // metadata
            track1Key.KeyOps = new List<string>();
            foreach (var op in track2Key.KeyOps)
            {
                track1Key.KeyOps.Add(op.ToString());
            }
            track1Key.Kid = track2Key.Id;

            return track1Key;
        }

        public static Track1ManagementSdk.Models.NetworkRuleSet ToTrack1NetworkRuleSet(this Track2ManagementSdk.Models.NetworkRuleSet track2NetworkRuleSet) =>
            new Track1ManagementSdk.Models.NetworkRuleSet()
            {
                Bypass = track2NetworkRuleSet.Bypass.ToString(),
                DefaultAction = track2NetworkRuleSet.DefaultAction.ToString(),
                IpRules = track2NetworkRuleSet.IpRules.Select(ipRule => new Track1ManagementSdk.Models.IPRule(ipRule.Value)).ToList(),
                VirtualNetworkRules = track2NetworkRuleSet.VirtualNetworkRules.Select(vnRule => new Track1ManagementSdk.Models.VirtualNetworkRule(vnRule.Id)).ToList()
            };

        public static Track1ManagementSdk.Models.CreateMode? ToTrack1CreateMode(this Track2ManagementSdk.Models.CreateMode track2CreateMode)
        {
            if (!Enum.TryParse(track2CreateMode.ToString(), out Track1ManagementSdk.Models.CreateMode track1CreateMode))
            {
                return null;
            }
            return track1CreateMode;
        }

        public static Track1ManagementSdk.Models.Permissions ToTrack1Permissions(this Track2ManagementSdk.Models.Permissions track2Permissions) =>
            new Track1ManagementSdk.Models.Permissions(track2Permissions.Keys.Select(key => key.ToString()).ToList(),
                    track2Permissions.Secrets.Select(key => key.ToString()).ToList(),
                    track2Permissions.Certificates.Select(key => key.ToString()).ToList(),
                    track2Permissions.Storage.Select(key => key.ToString()).ToList());

        public static Track1ManagementSdk.Models.AccessPolicyEntry ToTrack1AccessPolicyEntry(this Track2ManagementSdk.Models.AccessPolicyEntry track2AccessPolicyEntry) =>
            new Track1ManagementSdk.Models.AccessPolicyEntry
            {
                ApplicationId = track2AccessPolicyEntry.ApplicationId,
                ObjectId = track2AccessPolicyEntry.ObjectId,
                Permissions = track2AccessPolicyEntry.Permissions?.ToTrack1Permissions(),
                TenantId = track2AccessPolicyEntry.TenantId
            };

        public static Track1ManagementSdk.Models.Sku ToTrack1Sku(this Track2ManagementSdk.Models.Sku track2Sku)
        {
            Track1ManagementSdk.Models.Sku track1Sku = new Track1ManagementSdk.Models.Sku();

            if (!Enum.TryParse(track2Sku.Name.ToString(), out Track1ManagementSdk.Models.SkuName track1SkuName))
            {
                return null;
            }
            track1Sku.Name = track1SkuName;
            return track1Sku;
        }

        public static Track1ManagementSdk.Models.PrivateEndpointConnectionItem ToTrack1PrivateEndpointConnectionItem(this Track2ManagementSdk.Models.PrivateEndpointConnectionItem track2PrivateEndpointConnectionItem) =>
            new Track1ManagementSdk.Models.PrivateEndpointConnectionItem()
            {
                PrivateEndpoint = new Track1ManagementSdk.Models.PrivateEndpoint(track2PrivateEndpointConnectionItem.PrivateEndpoint.Id),
                PrivateLinkServiceConnectionState = new Track1ManagementSdk.Models.PrivateLinkServiceConnectionState(
                    track2PrivateEndpointConnectionItem.PrivateLinkServiceConnectionState.Status?.ToString(),
                    track2PrivateEndpointConnectionItem.PrivateLinkServiceConnectionState.Description,
                    track2PrivateEndpointConnectionItem.PrivateLinkServiceConnectionState.ActionsRequired?.ToString()),
                ProvisioningState = track2PrivateEndpointConnectionItem.ProvisioningState?.ToString()
            };

        public static Track1ManagementSdk.Models.VaultProperties ToTrack1VaultProperties(this Track2ManagementSdk.Models.VaultProperties track2VaultProperties) =>
            new Track1ManagementSdk.Models.VaultProperties(track2VaultProperties.TenantId, track2VaultProperties.Sku?.ToTrack1Sku(),
                track2VaultProperties.AccessPolicies.Select(ap => ap?.ToTrack1AccessPolicyEntry()).ToList(), track2VaultProperties.VaultUri,
                track2VaultProperties.EnabledForDeployment, track2VaultProperties.EnabledForDiskEncryption, track2VaultProperties.EnabledForTemplateDeployment,
                track2VaultProperties.EnableSoftDelete, track2VaultProperties.SoftDeleteRetentionInDays, track2VaultProperties.EnableRbacAuthorization,
                track2VaultProperties.CreateMode?.ToTrack1CreateMode(), track2VaultProperties.EnablePurgeProtection,
                track2VaultProperties.NetworkAcls?.ToTrack1NetworkRuleSet(), track2VaultProperties.PrivateEndpointConnections.Select(peCon => peCon?.ToTrack1PrivateEndpointConnectionItem()).ToList());

        public static Track1ManagementSdk.Models.Vault ToTrack1Vault(this Track2ManagementSdk.Vault track2Vault) =>
            new Track1ManagementSdk.Models.Vault(
                track2Vault.Data.Properties?.ToTrack1VaultProperties(),
                track2Vault.Data.Id, track2Vault.Data.Name, track2Vault.Data.Type, track2Vault.Data.Location, track2Vault.Data.Tags.ToDictionary(pair => pair.Key, pair => pair.Value));
    }
}

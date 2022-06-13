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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Adapters;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSStorageAccount : IStorageContextProvider
    {
        public PSStorageAccount(Track2.StorageAccountResource storageAccountResource)
        {
            this.ResourceGroupName = new ResourceIdentifier(storageAccountResource.Id).ResourceGroupName;
            this.StorageAccountName = storageAccountResource.Data.Name;
            this.Id = storageAccountResource.Id;
            this.Location = storageAccountResource.Data.Location;
            this.Sku = new PSSku(storageAccountResource.Data.Sku);
            this.Encryption = storageAccountResource.Data.Encryption;
            this.Kind = storageAccountResource.Data.Kind.ToString();
            this.AccessTier = storageAccountResource.Data.AccessTier;
            this.CreationTime = storageAccountResource.Data.CreationOn;
            this.CustomDomain = storageAccountResource.Data.CustomDomain is null ? null : new PSCustomDomain(storageAccountResource.Data.CustomDomain);
            this.Identity = storageAccountResource.Data.Identity != null ? new PSIdentity(storageAccountResource.Data.Identity) : null;
            this.LastGeoFailoverTime = storageAccountResource.Data.LastGeoFailoverOn;
            this.PrimaryEndpoints = storageAccountResource.Data.PrimaryEndpoints;
            this.PrimaryLocation = storageAccountResource.Data.PrimaryLocation;
            this.ProvisioningState = storageAccountResource.Data.ProvisioningState;
            this.SecondaryEndpoints = storageAccountResource.Data.SecondaryEndpoints;
            this.SecondaryLocation = storageAccountResource.Data.SecondaryLocation;
            this.StatusOfPrimary = storageAccountResource.Data.StatusOfPrimary;
            this.StatusOfSecondary = storageAccountResource.Data.StatusOfSecondary;
            this.Tags = storageAccountResource.Data.Tags;
            this.EnableHttpsTrafficOnly = storageAccountResource.Data.EnableHttpsTrafficOnly;

            this.NetworkRuleSet = PSNetworkRuleSet.ParsePSNetworkRule(storageAccountResource.Data.NetworkRuleSet);

            this.EnableHierarchicalNamespace = storageAccountResource.Data.IsHnsEnabled;
            this.FailoverInProgress = storageAccountResource.Data.FailoverInProgress;
            this.LargeFileSharesState = storageAccountResource.Data.LargeFileSharesState.ToString();
            this.AzureFilesIdentityBasedAuth =
                storageAccountResource.Data.AzureFilesIdentityBasedAuthentication is null ? null : new PSAzureFilesIdentityBasedAuthentication(storageAccountResource.Data.AzureFilesIdentityBasedAuthentication);
            this.GeoReplicationStats = PSGeoReplicationStats.ParsePSGeoReplicationStats(storageAccountResource.Data.GeoReplicationStats);
            this.AllowBlobPublicAccess = storageAccountResource.Data.AllowBlobPublicAccess;
            this.MinimumTlsVersion = storageAccountResource.Data.MinimumTlsVersion is null ? null : storageAccountResource.Data.MinimumTlsVersion.ToString();
            this.RoutingPreference = PSRoutingPreference.ParsePSRoutingPreference(storageAccountResource.Data.RoutingPreference);
            this.BlobRestoreStatus = storageAccountResource.Data.BlobRestoreStatus is null ? null : new PSBlobRestoreStatus(storageAccountResource.Data.BlobRestoreStatus);
            this.EnableNfsV3 = storageAccountResource.Data.EnableNfsV3;
            this.ExtendedLocation = storageAccountResource.Data.ExtendedLocation is null ? null : new PSExtendedLocation(storageAccountResource.Data.ExtendedLocation);
            this.AllowSharedKeyAccess = storageAccountResource.Data.AllowSharedKeyAccess;
            this.KeyCreationTime = storageAccountResource.Data.KeyCreationTime is null ? null : new PSKeyCreationTime(storageAccountResource.Data.KeyCreationTime);
            this.KeyPolicy = storageAccountResource.Data.KeyExpirationPeriodInDays != null ? new PSKeyPolicy((int)(storageAccountResource.Data.KeyExpirationPeriodInDays)) : null;
            this.SasPolicy = storageAccountResource.Data.SasPolicy != null ? new PSSasPolicy(storageAccountResource.Data.SasPolicy.SasExpirationPeriod, storageAccountResource.Data.SasPolicy.ExpirationAction.ToString()) : null;
            this.AllowCrossTenantReplication = storageAccountResource.Data.AllowCrossTenantReplication;
            this.PublicNetworkAccess = storageAccountResource.Data.PublicNetworkAccess != null ? storageAccountResource.Data.PublicNetworkAccess.ToString() : null;
            this.ImmutableStorageWithVersioning = storageAccountResource.Data.ImmutableStorageWithVersioning is null ? null : new PSImmutableStorageAccount(storageAccountResource.Data.ImmutableStorageWithVersioning);
        }

        public bool? AllowCrossTenantReplication { get; set; }

        public PSKeyCreationTime KeyCreationTime { get; set; }
        public PSKeyPolicy KeyPolicy { get; }
        public PSSasPolicy SasPolicy { get; }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 1)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table, Position = 0)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Location", Target = ViewControl.Table, Position = 2)]
        public string Location { get; set; }

        [Ps1Xml(Label = "SkuName", Target = ViewControl.Table, ScriptBlock = "$_.Sku.Name", Position = 3)]
        public PSSku Sku { get; set; }

        [Ps1Xml(Label = "Kind", Target = ViewControl.Table, Position = 4)]
        public string Kind { get; set; }
        public Track2Models.Encryption Encryption { get; set; }

        [Ps1Xml(Label = "AccessTier", Target = ViewControl.Table, Position = 5)]
        public Track2Models.AccessTier? AccessTier { get; set; }

        [Ps1Xml(Label = "CreationTime", Target = ViewControl.Table, Position = 6)]
        public DateTimeOffset? CreationTime { get; set; }

        public PSCustomDomain CustomDomain { get; set; }

        public PSIdentity Identity { get; set; }

        public DateTimeOffset? LastGeoFailoverTime { get; set; }

        public Track2Models.Endpoints PrimaryEndpoints { get; set; }

        [Ps1Xml(Label = "PrimaryLocation", Target = ViewControl.Table, Position = 2)]
        public string PrimaryLocation { get; set; }

        [Ps1Xml(Label = "ProvisioningState", Target = ViewControl.Table, Position = 7)]
        public Track2Models.ProvisioningState? ProvisioningState { get; set; }

        public Track2Models.Endpoints SecondaryEndpoints { get; set; }

        public string SecondaryLocation { get; set; }

        public Track2Models.AccountStatus? StatusOfPrimary { get; set; }

        public Track2Models.AccountStatus? StatusOfSecondary { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        [Ps1Xml(Label = "EnableHttpsTrafficOnly", Target = ViewControl.Table, Position = 8)]
        public bool? EnableHttpsTrafficOnly { get; set; }

        public PSAzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuth { get; set; }

        public bool? EnableHierarchicalNamespace { get; set; }

        public bool? FailoverInProgress { get; set; }

        public string LargeFileSharesState { get; set; }

        public PSNetworkRuleSet NetworkRuleSet { get; set; }

        public PSRoutingPreference RoutingPreference { get; set; }

        public PSBlobRestoreStatus BlobRestoreStatus { get; set; }

        public PSGeoReplicationStats GeoReplicationStats { get; set; }

        public bool? AllowBlobPublicAccess { get; set; }

        public string MinimumTlsVersion { get; set; }

        public bool? EnableNfsV3 { get; set; }

        public bool? AllowSharedKeyAccess { get; set; }

        public PSExtendedLocation ExtendedLocation { get; set; }

        public string PublicNetworkAccess { get; set; }

        public PSImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }

        public static PSStorageAccount Create(Track2.StorageAccountResource storageAccountResource, Track2StorageManagementClient client)
        {
            var result = new PSStorageAccount(storageAccountResource);

            result.Context = new LazyAzureStorageContext((s) =>
            {
                return GetCloudStorageAccount(storageAccountResource);
            }, result.StorageAccountName) as AzureStorageContext;

            return result;
        }

        public static CloudStorageAccount GetCloudStorageAccount(Track2.StorageAccountResource storageAccountResource)
        {
            Uri blobEndpoint = storageAccountResource.Data.PrimaryEndpoints.Blob != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.Blob) : null;
            Uri queueEndpoint = storageAccountResource.Data.PrimaryEndpoints.Queue != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.Queue) : null;
            Uri tableEndpoint = storageAccountResource.Data.PrimaryEndpoints.Table != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.Table) : null;
            Uri fileEndpoint = storageAccountResource.Data.PrimaryEndpoints.File != null ? new Uri(storageAccountResource.Data.PrimaryEndpoints.File) : null;
            string key = storageAccountResource.GetKeys().Value.Keys[0].Value;
            StorageCredentials storageCredentials = new Azure.Storage.Auth.StorageCredentials(storageAccountResource.Data.Name, key);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(
                storageCredentials,
                new StorageUri(blobEndpoint),
                new StorageUri(queueEndpoint),
                new StorageUri(tableEndpoint),
                new StorageUri(fileEndpoint));

            return cloudStorageAccount;
        }

        public IStorageContext Context { get; private set; }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Return a string representation of this storage account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            // Allow listing storage contents through piping
            return null;
        }
    }

    public class PSKeyPolicy
    {
        public string KeyExpirationPeriodInDays { get; set; }

        public PSKeyPolicy(int keyExpirationPeriodInDays)

        {
            this.KeyExpirationPeriodInDays = keyExpirationPeriodInDays.ToString();
        }
    }

    public class PSSasPolicy
    {
        public string SasExpirationPeriod { get; set; }

        public static string ExpirationAction { get; set; }

        public PSSasPolicy(string sasExpirationPeriod, string expirationAction)
        {
            if (sasExpirationPeriod != null)
            {
                this.SasExpirationPeriod = sasExpirationPeriod;
            }
            if (expirationAction != null)
            {
                PSSasPolicy.ExpirationAction = expirationAction;
            }

        }

        public PSSasPolicy() { }
    }

    public class PSCustomDomain
    {
        public string Name { get; set; }
        public bool? UseSubDomain { get; set; }

        public PSCustomDomain(Track2Models.CustomDomain input)
        {
            this.Name = input.Name;
            this.UseSubDomain = input.UseSubDomainName;
        }

        public Track2Models.CustomDomain ParseCustomDomain()
        {
            Track2Models.CustomDomain customDomain =
                new Track2Models.CustomDomain(this.Name);
            customDomain.UseSubDomainName = this.UseSubDomain;
            return customDomain;
        }
    }




    public class PSIdentity
    {
        private const string SystemAssignedUserAssigned = "SystemAssigned,UserAssigned";
        public string PrincipalId { get; set; }
        public string TenantId { get; set; }

        public string Type { get; set; }

        public IDictionary<string, PSUserAssignedIdentity> UserAssignedIdentities = new Dictionary<string, PSUserAssignedIdentity>();

        public PSIdentity(ManagedServiceIdentity identity)
        {
            if (identity.PrincipalId != null)
            {
                this.PrincipalId = identity.PrincipalId.Value.ToString();
            }

            if (identity.TenantId != null)
            {
                this.TenantId = identity.TenantId.Value.ToString();
            }
            if (identity.ManagedServiceIdentityType == ManagedServiceIdentityType.SystemAssignedUserAssigned)
            {
                this.Type = SystemAssignedUserAssigned;
            } else
            {
                this.Type = identity.ManagedServiceIdentityType.ToString();
            }

            identity.UserAssignedIdentities
                .ForEach(x => this.UserAssignedIdentities.Add(x.Key, new PSUserAssignedIdentity(x.Value)));
        }

    }

    public class PSUserAssignedIdentity
    {
        public string PrincipalId { get; set; }

        public string ClientId { get; set; }

        public PSUserAssignedIdentity(global::Azure.ResourceManager.Models.UserAssignedIdentity userAssignedIdentity)
        {
            if (userAssignedIdentity.PrincipalId != null)
            {
                this.PrincipalId = userAssignedIdentity.PrincipalId.Value.ToString();
            }

            if (userAssignedIdentity.ClientId != null)
            {
                this.ClientId = userAssignedIdentity.ClientId.Value.ToString();
            }
        }

    }

    public class PSSku
    {
        public string Name { get; set; }
        public Track2Models.StorageSkuTier? Tier { get; set; }
        public string ResourceType { get; set; }
        public string Kind { get; set; }
        public IList<string> Locations { get; set; }
        public IList<SKUCapability> Capabilities { get; set; }
        public IList<Restriction> Restrictions { get; set; }

        public PSSku(Track2Models.StorageSku sku)
        {
            if (sku != null)
            {
                this.Name = sku.Name.ToString();
                this.Tier = sku.Tier;

            }
        }


        public Track2Models.StorageSku ParseSku()
        {
            Track2Models.StorageSku sku = new Track2Models.StorageSku(Name);
            return sku;
        }
    }

    public class PSExtendedLocation
    {
        public PSExtendedLocation()
        { }

        public PSExtendedLocation(Track2Models.ExtendedLocation extendedLocation)
        {
            this.Name = extendedLocation.Name;
            this.Type = extendedLocation.ExtendedLocationType != null ? extendedLocation.ExtendedLocationType.ToString() : null;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class PSKeyCreationTime
    {
        public PSKeyCreationTime()
        { }

        public PSKeyCreationTime(Track2Models.KeyCreationTime keyCreationTime)
        {
            if (keyCreationTime != null)
            {
                this.Key1 = keyCreationTime.Key1;
                this.Key2 = keyCreationTime.Key2;
            }
        }
        public System.DateTimeOffset? Key1 { get; set; }
        public System.DateTimeOffset? Key2 { get; set; }
    }

    /// <summary>
    /// wrapper class for ImmutableStorageAccount
    /// </summary>
    public class PSImmutableStorageAccount
    {
        public PSImmutableStorageAccount()
        { }

        public PSImmutableStorageAccount(Track2Models.ImmutableStorageAccount immutableStorageAccount)
        {
            if (immutableStorageAccount != null)
            {
                this.Enabled = immutableStorageAccount.Enabled;
                this.ImmutabilityPolicy = immutableStorageAccount.ImmutabilityPolicy is null ? null : new PSAccountImmutabilityPolicyProperties(immutableStorageAccount.ImmutabilityPolicy);
            }
        }
        public bool? Enabled { get; set; }
        public PSAccountImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
    }

    /// <summary>
    /// wrapper class for AccountImmutabilityPolicyProperties
    /// </summary>
    public class PSAccountImmutabilityPolicyProperties
    {
        public PSAccountImmutabilityPolicyProperties()
        { }

        public PSAccountImmutabilityPolicyProperties(Track2Models.AccountImmutabilityPolicyProperties accountImmutabilityPolicyProperties)
        {
            if (accountImmutabilityPolicyProperties != null)
            {
                this.ImmutabilityPeriodSinceCreationInDays = accountImmutabilityPolicyProperties.ImmutabilityPeriodSinceCreationInDays;
                this.State = accountImmutabilityPolicyProperties.State != null ? accountImmutabilityPolicyProperties.State.ToString() : null;
            }
        }
        public int? ImmutabilityPeriodSinceCreationInDays { get; set; }
        public string State { get; set; }
    }
}

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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using System;
using System.Collections.Generic;
using StorageModels = Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSStorageAccount : IStorageContextProvider
    {
        public PSStorageAccount(StorageModels.StorageAccount storageAccount)
        {
            this.ResourceGroupName = new ResourceIdentifier(storageAccount.Id).ResourceGroupName;
            this.StorageAccountName = storageAccount.Name;
            this.Id = storageAccount.Id;
            this.Location = storageAccount.Location;
            this.Sku = new PSSku(storageAccount.Sku);
            this.Encryption = storageAccount.Encryption;
            this.Kind = storageAccount.Kind;
            this.AccessTier = storageAccount.AccessTier;
            this.CreationTime = storageAccount.CreationTime;
            this.CustomDomain = storageAccount.CustomDomain is null ? null : new PSCustomDomain(storageAccount.CustomDomain);
            this.Identity = storageAccount.Identity;
            this.LastGeoFailoverTime = storageAccount.LastGeoFailoverTime;
            this.PrimaryEndpoints = storageAccount.PrimaryEndpoints;
            this.PrimaryLocation = storageAccount.PrimaryLocation;
            this.ProvisioningState = storageAccount.ProvisioningState;
            this.SecondaryEndpoints = storageAccount.SecondaryEndpoints;
            this.SecondaryLocation = storageAccount.SecondaryLocation;
            this.StatusOfPrimary = storageAccount.StatusOfPrimary;
            this.StatusOfSecondary = storageAccount.StatusOfSecondary;
            this.Tags = storageAccount.Tags;
            this.EnableHttpsTrafficOnly = storageAccount.EnableHttpsTrafficOnly;
            this.NetworkRuleSet = PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.NetworkRuleSet);
            this.EnableHierarchicalNamespace = storageAccount.IsHnsEnabled;
            this.FailoverInProgress = storageAccount.FailoverInProgress;
            this.LargeFileSharesState = storageAccount.LargeFileSharesState;
            this.AzureFilesIdentityBasedAuth = storageAccount.AzureFilesIdentityBasedAuthentication is null ? null : new PSAzureFilesIdentityBasedAuthentication(storageAccount.AzureFilesIdentityBasedAuthentication);
            this.GeoReplicationStats = PSGeoReplicationStats.ParsePSGeoReplicationStats(storageAccount.GeoReplicationStats);
            this.AllowBlobPublicAccess = storageAccount.AllowBlobPublicAccess;
            this.MinimumTlsVersion = storageAccount.MinimumTlsVersion;
            this.RoutingPreference = PSRoutingPreference.ParsePSRoutingPreference(storageAccount.RoutingPreference);
            this.BlobRestoreStatus = storageAccount.BlobRestoreStatus is null ? null : new PSBlobRestoreStatus(storageAccount.BlobRestoreStatus);
            this.EnableNfsV3 = storageAccount.EnableNfsV3;
            this.ExtendedLocation = storageAccount.ExtendedLocation is null ? null : new PSExtendedLocation(storageAccount.ExtendedLocation);
            this.AllowSharedKeyAccess = storageAccount.AllowSharedKeyAccess;
            this.KeyCreationTime = storageAccount.KeyCreationTime is null ? null : new PSKeyCreationTime(storageAccount.KeyCreationTime);
            this.KeyPolicy = storageAccount.KeyPolicy;
            this.SasPolicy = storageAccount.SasPolicy;
            this.AllowCrossTenantReplication = storageAccount.AllowCrossTenantReplication;
            this.PublicNetworkAccess = storageAccount.PublicNetworkAccess;
            this.ImmutableStorageWithVersioning = storageAccount.ImmutableStorageWithVersioning is null ? null : new PSImmutableStorageAccount(storageAccount.ImmutableStorageWithVersioning);
            this.StorageAccountSkuConversionStatus = storageAccount.StorageAccountSkuConversionStatus is null ? null : new PSStorageAccountSkuConversionStatus(storageAccount.StorageAccountSkuConversionStatus);
            this.EnableSftp = storageAccount.IsSftpEnabled;
            this.EnableLocalUser = storageAccount.IsLocalUserEnabled;
            this.AllowedCopyScope = storageAccount.AllowedCopyScope;
            this.DnsEndpointType= storageAccount.DnsEndpointType;
        }
        public bool? AllowCrossTenantReplication { get; set; }

        public PSKeyCreationTime KeyCreationTime { get; set; }
        public KeyPolicy KeyPolicy { get; }
        public SasPolicy SasPolicy { get; }

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
        public Encryption Encryption { get; set; }

        [Ps1Xml(Label = "AccessTier", Target = ViewControl.Table, Position = 5)]
        public AccessTier? AccessTier { get; set; }

        [Ps1Xml(Label = "CreationTime", Target = ViewControl.Table, Position = 6)]
        public DateTime? CreationTime { get; set; }

        public PSCustomDomain CustomDomain { get; set; }

        public Identity Identity { get; set; }

        public DateTime? LastGeoFailoverTime { get; set; }

        public Endpoints PrimaryEndpoints { get; set; }

        [Ps1Xml(Label = "PrimaryLocation", Target = ViewControl.Table, Position = 2)]
        public string PrimaryLocation { get; set; }

        [Ps1Xml(Label = "ProvisioningState", Target = ViewControl.Table, Position = 7)]
        public ProvisioningState? ProvisioningState { get; set; }

        public Endpoints SecondaryEndpoints { get; set; }

        public string SecondaryLocation { get; set; }

        public AccountStatus? StatusOfPrimary { get; set; }

        public AccountStatus? StatusOfSecondary { get; set; }

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

        public bool? EnableSftp { get; set; }
        public bool? EnableLocalUser { get; set; }

        public bool? AllowSharedKeyAccess { get; set; }

        public PSExtendedLocation ExtendedLocation { get; set; }

        public string PublicNetworkAccess { get; set; }

        public string AllowedCopyScope { get; set; }

        public PSImmutableStorageAccount ImmutableStorageWithVersioning { get; set; }
        public PSStorageAccountSkuConversionStatus StorageAccountSkuConversionStatus { get; set; }
        public string DnsEndpointType { get; set; }


        public static PSStorageAccount Create(StorageModels.StorageAccount storageAccount, IStorageManagementClient client, IAzureContext DefaultContext)
        {
            var result = new PSStorageAccount(storageAccount);

            // If not allow Shared key, will get Oauth context
            if (storageAccount.AllowSharedKeyAccess.HasValue && !storageAccount.AllowSharedKeyAccess.Value)
            {
                result.Context = new LazyAzureStorageContext((s) =>
                {
                    TokenCredential tokenCredential = OAuthUtil.getTokenCredential(DefaultContext, null);
                    StorageCredentials credential = new StorageCredentials(tokenCredential);
                    CloudStorageAccount track1Account = new CloudStorageAccount(credential,
                        string.IsNullOrEmpty(storageAccount.PrimaryEndpoints.Blob) ? null : new Uri(storageAccount.PrimaryEndpoints.Blob),
                        string.IsNullOrEmpty(storageAccount.PrimaryEndpoints.Queue) ? null : new Uri(storageAccount.PrimaryEndpoints.Queue),
                        string.IsNullOrEmpty(storageAccount.PrimaryEndpoints.Table) ? null : new Uri(storageAccount.PrimaryEndpoints.Table),
                        string.IsNullOrEmpty(storageAccount.PrimaryEndpoints.File) ? null : new Uri(storageAccount.PrimaryEndpoints.File));
                    return track1Account;
                },
                result.StorageAccountName,
                () =>
                {
                    return new AzureSessionCredential(DefaultContext, null);
                }) as AzureStorageContext;
            }
            // get sharedkey context
            else
            {
                result.Context = new LazyAzureStorageContext((s) =>
                {
                    return (new ARMStorageProvider(client)).GetCloudStorageAccount(s, result.ResourceGroupName);
                }, result.StorageAccountName) as AzureStorageContext;
            }

            return result;
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

    public class PSCustomDomain
    {
        public string Name { get; set; }
        public bool? UseSubDomain { get; set; }

        public PSCustomDomain(CustomDomain input)
        {
            this.Name = input.Name;
            this.UseSubDomain = input.UseSubDomainName;
        }

        public CustomDomain ParseCustomDomain()
        {
            return new CustomDomain(this.Name, this.UseSubDomain);
        }
    }

    public class PSSku
    {
        public string Name { get; set; }
        public SkuTier? Tier { get; set; }
        public string ResourceType { get; set; }
        public string Kind { get; set; }
        public IList<string> Locations { get; set; }
        public IList<SKUCapability> Capabilities { get; set; }
        public IList<Restriction> Restrictions { get; set; }

        public PSSku(Sku sku)
        {
            if (sku != null)
            {
                this.Name = sku.Name;
                this.Tier = sku.Tier;
            }
        }

        public Sku ParseSku()
        {
            return new Sku(Name, Tier);
        }
    }

    public class PSExtendedLocation
    {
        public PSExtendedLocation()
        { }

        public PSExtendedLocation(ExtendedLocation extendedLocation)
        {
            this.Name = extendedLocation.Name;
            this.Type = extendedLocation.Type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class PSKeyCreationTime
    {
        public PSKeyCreationTime()
        { }

        public PSKeyCreationTime(KeyCreationTime keyCreationTime)
        {
            if (keyCreationTime != null)
            {
                this.Key1 = keyCreationTime.Key1;
                this.Key2 = keyCreationTime.Key2;
            }
        }
        public System.DateTime? Key1 { get; set; }
        public System.DateTime? Key2 { get; set; }
    }

    /// <summary>
    /// wrapper class for ImmutableStorageAccount
    /// </summary>
    public class PSImmutableStorageAccount
    {
        public PSImmutableStorageAccount()
        { }

        public PSImmutableStorageAccount(ImmutableStorageAccount immutableStorageAccount)
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

        public PSAccountImmutabilityPolicyProperties(AccountImmutabilityPolicyProperties accountImmutabilityPolicyProperties)
        {
            if (accountImmutabilityPolicyProperties != null)
            {
                this.ImmutabilityPeriodSinceCreationInDays = accountImmutabilityPolicyProperties.ImmutabilityPeriodSinceCreationInDays;
                this.State = accountImmutabilityPolicyProperties.State;
            }
        }
        public int? ImmutabilityPeriodSinceCreationInDays { get; set; }
        public string State { get; set; }
    }

    /// <summary>
    ///  wrapper class of StorageAccountSkuConversionStatus
    /// </summary>
    public class PSStorageAccountSkuConversionStatus
    {
        public string SkuConversionStatus { get; set; }
        public string TargetSkuName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public PSStorageAccountSkuConversionStatus(StorageAccountSkuConversionStatus status)
        {
            if (status != null)
            {
                this.SkuConversionStatus = status.SkuConversionStatus;
                this.TargetSkuName = status.TargetSkuName;
                this.StartTime = status.StartTime;
                this.EndTime = status.EndTime;
            }
        }
    }
}

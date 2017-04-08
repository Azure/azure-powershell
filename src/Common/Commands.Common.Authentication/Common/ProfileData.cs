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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// This class provides the representation of data loaded and saved into data files
    /// for AzureSMProfile.
    /// </summary>
    [DataContract]
    public class ProfileData
    {
        [DataMember]
        public string DefaultEnvironmentName { get; set; }

        [DataMember]
        public IEnumerable<AzureEnvironmentData> Environments { get; set; }

        [DataMember]
        public IEnumerable<AzureSubscriptionData> Subscriptions { get; set; }
    }

    /// <summary>
    /// This class provides the representation of data loaded and saved into data files for
    /// an individual Azure environment
    /// </summary>
    [DataContract]
    public class AzureEnvironmentData
    {
        public AzureEnvironment ToAzureEnvironment()
        {
            return new AzureEnvironment
            {
                Name = this.Name,
                ActiveDirectoryServiceEndpointResourceId = this.ActiveDirectoryServiceEndpointResourceId,
                AdTenant = this.AdTenantUrl,
                Gallery = new Uri(this.GalleryEndpoint),
                ManagementPortalUrl = new Uri(this.ManagementPortalUrl),
                PublishSettingsFileUrl = new Uri(this.PublishSettingsFileUrl),
                ResourceManager = new Uri(this.ResourceManagerEndpoint),
                ServiceManagement = new Uri(this.ServiceEndpoint), 
                SqlDatabaseDnsSuffix = this.SqlDatabaseDnsSuffix,
                StorageEndpointSuffix = this.StorageEndpointSuffix,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = this.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                AzureDataLakeStoreFileSystemEndpointSuffix = this.AzureDataLakeStoreFileSystemEndpointSuffix
            };
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PublishSettingsFileUrl { get; set; }

        [DataMember]
        public string ServiceEndpoint { get; set; }

        [DataMember]
        public string ResourceManagerEndpoint { get; set; }

        [DataMember]
        public string ManagementPortalUrl { get; set; }

        [DataMember]
        public string StorageEndpointSuffix { get; set; }

        [DataMember]
        public string AdTenantUrl { get; set; }

        [DataMember]
        public string CommonTenantId { get; set; }

        [DataMember]
        public string GalleryEndpoint { get; set; }

        [DataMember]
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        [DataMember]
        public string SqlDatabaseDnsSuffix { get; set; }

        [DataMember]
        public string TrafficManagerEndpointSuffix { get; set; }

        [DataMember]
        public string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix { get; set; }

        [DataMember]
        public string AzureDataLakeStoreFileSystemEndpointSuffix { get; set; }
    }

    /// <summary>
    /// This class provides the representation of data loaded
    /// and saved into data file for an individual Azure subscription.
    /// </summary>
    [DataContract]
    public class AzureSubscriptionData
    {
        /// <summary>
        /// Constructor used by DataContractSerializer
        /// </summary>
        public AzureSubscriptionData()
        {
        }

        public AzureSubscription ToAzureSubscription(List<AzureEnvironment> envs)
        {
            AzureSubscription subscription = new AzureSubscription();
            try
            {
                subscription.Id = this.SubscriptionId;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Subscription ID is not a valid GUID.", ex);
            }
            subscription.Name = Name;

            // Logic to detect what is the subscription environment relies on having ManagementEndpoint (i.e. RDFE endpoint) set already on the subscription
            List<AzureEnvironment> allEnvs = envs.Union(AzureEnvironment.PublicEnvironments.Values).ToList();
            AzureEnvironment env = allEnvs.FirstOrDefault(e => e.IsEndpointSetToValue(AzureEnvironment.Endpoint.ServiceManagement, this.ManagementEndpoint));

            if (env != null)
            {
                subscription.SetEnvironment(env.Name);
            }
            else
            {
                subscription.SetEnvironment(EnvironmentName.AzureCloud);
            }

            if (!string.IsNullOrEmpty(this.ManagementCertificate))
            {
                subscription.SetAccount(this.ManagementCertificate);
            }

            if (!string.IsNullOrEmpty(this.ActiveDirectoryUserId))
            {
                subscription.SetAccount(this.ActiveDirectoryUserId);
            }

            if (!string.IsNullOrEmpty(this.ActiveDirectoryTenantId))
            {
                subscription.SetProperty(AzureSubscription.Property.Tenants, ActiveDirectoryTenantId);
            }

            if (this.IsDefault)
            {
                subscription.SetProperty(AzureSubscription.Property.Default, "True");
            }

            if (!string.IsNullOrEmpty(this.CloudStorageAccount))
            {
                subscription.SetStorageAccount(this.CloudStorageAccount);
            }

            if (this.RegisteredResourceProviders.Count() > 0)
            {
                StringBuilder providers = new StringBuilder();
                subscription.SetProperty(AzureSubscription.Property.RegisteredResourceProviders,
                    string.Join(",", RegisteredResourceProviders));
            }

            return subscription;
        }

        public IEnumerable<AzureAccount> ToAzureAccounts()
        {
            if (!string.IsNullOrEmpty(ActiveDirectoryUserId))
            {
                AzureAccount userAccount = new AzureAccount
                {
                    Id = ActiveDirectoryUserId,
                    Type = AzureAccount.AccountType.User
                };

                userAccount.SetProperty(AzureAccount.Property.Subscriptions, new Guid(this.SubscriptionId).ToString());

                if (!string.IsNullOrEmpty(ActiveDirectoryTenantId))
                {
                    userAccount.SetProperty(AzureAccount.Property.Tenants, ActiveDirectoryTenantId);
                }

                yield return userAccount;
            }

            if (!string.IsNullOrEmpty(ManagementCertificate))
            {
                AzureAccount certificateAccount = new AzureAccount
                {
                    Id = ManagementCertificate,
                    Type = AzureAccount.AccountType.Certificate
                };

                certificateAccount.SetProperty(AzureAccount.Property.Subscriptions, new Guid(this.SubscriptionId).ToString());

                yield return certificateAccount;
            }
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string SubscriptionId { get; set; }

        [DataMember]
        public string ManagementEndpoint { get; set; }

        [DataMember]
        public string ResourceManagerEndpoint { get; set; }

        [DataMember]
        public string ActiveDirectoryEndpoint { get; set; }

        [DataMember]
        public string ActiveDirectoryTenantId { get; set; }

        [DataMember]
        public string ActiveDirectoryUserId { get; set; }

        [DataMember]
        public string LoginType { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public string ManagementCertificate { get; set; }

        [DataMember]
        public string CloudStorageAccount { get; set; }

        [DataMember]
        public IEnumerable<string> RegisteredResourceProviders { get; set; }

        [DataMember]
        public string GalleryEndpoint { get; set; }

        [DataMember]
        public string ActiveDirectoryServiceEndpointResourceId { get; set; }

        [DataMember]
        public string SqlDatabaseDnsSuffix { get; set; }

        [DataMember]
        public string TrafficManagerEndpointSuffix { get; set; }
    }
}
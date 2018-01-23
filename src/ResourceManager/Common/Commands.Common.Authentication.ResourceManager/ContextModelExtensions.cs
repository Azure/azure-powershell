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
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.Common.Authentication.ResourceManager
{
    public static class ContextModelExtensions
    {
        public static bool HasTokenCache(this IAzureContextContainer container)
        {
            return container != null 
                && container.DefaultContext != null 
                && container.DefaultContext.TokenCache != null 
                && container.DefaultContext.TokenCache.CacheData != null 
                && container.DefaultContext.TokenCache.CacheData.Length > 0;
        }

        public static IAzureTokenCache GetTokenCache(this IAzureContextContainer container)
        {
            IAzureTokenCache result = null;
            if (HasTokenCache(container))
            {
                result = container.DefaultContext.TokenCache;
            }

            return result;
        }

        public static IAzureContext WithAccount(this IAzureContext context, IAzureAccount account)
        {
            if (account != null && !string.IsNullOrWhiteSpace(account.Id) && context != null)
            {
                context.Subscription?.SetAccount(account.Id);
                account.SetOrAppendProperty(AzureAccount.Property.Subscriptions, context.Subscription == null ? null : context.Subscription.Id);
                account.SetOrAppendProperty(AzureAccount.Property.Tenants, context.Tenant == null ? null : context.Tenant.Id);
                context.Account = account;
            }

            return context;
        }

        public static IAzureContext WithTenant(this IAzureContext context, IAzureTenant tenant)
        {
            if (tenant != null && !string.IsNullOrWhiteSpace(tenant.Id) && context != null)
            {
                context.Subscription?.SetTenant(tenant.Id);
                context.Account?.SetOrAppendProperty(AzureAccount.Property.Subscriptions, tenant.Id);
                context.Tenant = tenant;
            }

            return context;
        }

        public static IAzureContext WithSubscription(this IAzureContext context, IAzureSubscription subscription)
        {
            if (subscription != null && !string.IsNullOrWhiteSpace(subscription.Id) && context != null)
            {
                subscription.SetAccount(context.Account != null ? context.Account.Id : null);
                subscription.SetEnvironment(context.Environment != null ? context.Environment.Name : EnvironmentName.AzureCloud);
                subscription.SetTenant(context.Tenant == null ? null : context.Tenant.Id);
                context.Subscription = subscription;
                context.Account?.SetOrAppendProperty(AzureAccount.Property.Subscriptions, subscription.Id);
            }
            return context;
        }

        public static void CopyFrom(this IAzureContext context, IAzureContext other)
        {
            if (context != null && other != null)
            {
                context.Account = new AzureAccount();
                context.Account.CopyFrom(other.Account);
                context.Environment = new AzureEnvironment();
                context.Environment.CopyFrom(other.Environment);
                context.Subscription = new AzureSubscription();
                context.Subscription.CopyFrom(other.Subscription);
                context.Tenant = new AzureTenant();
                context.Tenant.CopyFrom(other.Tenant);
                context.CopyPropertiesFrom(other);
                context.TokenCache = AzureSession.Instance.TokenCache;
            }
        }

        public static IAzureEnvironment Merge(this IAzureEnvironment environment1, IAzureEnvironment environment2)
        {
            if (environment1 == null || environment2 == null)
            {
                throw new ArgumentNullException("environment1");
            }
            if (!string.Equals(environment1.Name, environment2.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("Environment names do not match.");
            }

            AzureEnvironment mergedEnvironment = new AzureEnvironment
            {
                Name = environment1.Name,
                ActiveDirectoryAuthority = environment1.ActiveDirectoryAuthority ?? environment2.ActiveDirectoryAuthority,
                ActiveDirectoryServiceEndpointResourceId = environment1.ActiveDirectoryServiceEndpointResourceId ?? environment2.ActiveDirectoryServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = environment1.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix ?? environment2.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                AzureKeyVaultDnsSuffix = environment1.AzureKeyVaultDnsSuffix ?? environment2.AzureKeyVaultDnsSuffix,
                GalleryUrl = environment1.GalleryUrl ?? environment2.GalleryUrl,
                GraphEndpointResourceId = environment1.GraphEndpointResourceId ?? environment2.GraphEndpointResourceId,
                AdTenant = environment1.AdTenant ?? environment2.AdTenant,
                AzureDataLakeStoreFileSystemEndpointSuffix = environment1.AzureDataLakeStoreFileSystemEndpointSuffix ?? environment2.AzureDataLakeStoreFileSystemEndpointSuffix,
                AzureKeyVaultServiceEndpointResourceId = environment1.AzureKeyVaultServiceEndpointResourceId ?? environment2.AzureKeyVaultServiceEndpointResourceId,
                DataLakeEndpointResourceId = environment1.DataLakeEndpointResourceId ?? environment2.DataLakeEndpointResourceId,
                GraphUrl = environment1.GraphUrl ?? environment2.GraphUrl,
                ManagementPortalUrl = environment1.ManagementPortalUrl ?? environment2.ManagementPortalUrl,
                OnPremise = environment1.OnPremise || environment2.OnPremise,
                PublishSettingsFileUrl = environment1.PublishSettingsFileUrl ?? environment2.PublishSettingsFileUrl,
                ResourceManagerUrl = environment1.ResourceManagerUrl ?? environment2.ResourceManagerUrl,
                ServiceManagementUrl = environment1.ServiceManagementUrl ?? environment2.ServiceManagementUrl,
                SqlDatabaseDnsSuffix = environment1.SqlDatabaseDnsSuffix ?? environment2.SqlDatabaseDnsSuffix,
                StorageEndpointSuffix = environment1.StorageEndpointSuffix ?? environment2.StorageEndpointSuffix,
                TrafficManagerDnsSuffix = environment1.TrafficManagerDnsSuffix ?? environment2.TrafficManagerDnsSuffix
            };

            foreach (var property in environment1.ExtendedProperties.Keys.Union(environment2.ExtendedProperties.Keys))
            {
                mergedEnvironment.ExtendedProperties[property] = environment1.ExtendedProperties.ContainsKey(property) ?
                    environment1.ExtendedProperties[property] : environment2.ExtendedProperties[property];
            }

            return mergedEnvironment;
        }


    }
}

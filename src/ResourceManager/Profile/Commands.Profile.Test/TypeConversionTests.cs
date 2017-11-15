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
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class TypeConversionTests
    {
        public TypeConversionTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullEnvironments()
        {
            Assert.Null((PSAzureEnvironment)null);
            var environment = (PSAzureEnvironment)new AzureEnvironment();
            Assert.NotNull(environment);
            Assert.Null(environment.ActiveDirectoryAuthority);
            Assert.Null(environment.ActiveDirectoryServiceEndpointResourceId);
            Assert.Null(environment.AdTenant);
            Assert.Null(environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix);
            Assert.Null(environment.AzureDataLakeStoreFileSystemEndpointSuffix);
            Assert.Null(environment.DataLakeEndpointResourceId);
            Assert.Null(environment.AzureKeyVaultDnsSuffix);
            Assert.Null(environment.AzureKeyVaultServiceEndpointResourceId);
            Assert.False(environment.EnableAdfsAuthentication);
            Assert.Null(environment.GalleryUrl);
            Assert.Null(environment.GraphUrl);
            Assert.Null(environment.GraphEndpointResourceId);
            Assert.Null(environment.ManagementPortalUrl);
            Assert.Null(environment.Name);
            Assert.Null(environment.PublishSettingsFileUrl);
            Assert.Null(environment.ResourceManagerUrl);
            Assert.Null(environment.ServiceManagementUrl);
            Assert.Null(environment.SqlDatabaseDnsSuffix);
            Assert.Null(environment.StorageEndpointSuffix);
            Assert.Null(environment.TrafficManagerDnsSuffix);
            Assert.Null(environment.BatchEndpointResourceId);
        }

        [Theory]
        [InlineData("TestAll", true, "https://login.microsoftonline.com", "https://management.core.windows.net/",
            "Common", "https://mangement.azure.com/dataLakeJobs", "https://management.azure.com/dataLakeFiles",
            ".keyvault.azure.com", "https://keyvault.azure.com/", "https://gallery.azure.com",
            "https://graph.windows.net", "https://graph.windows.net/", "https://manage.windowsazure.com",
            "https://manage.windowsazure.com/publishsettings", "https://management.azure.com",
            "https://management.core.windows.net", ".sql.azure.com", ".core.windows.net",
            ".trafficmanager.windows.net", "https://batch.core.windows.net", "https://datalake.azure.net")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidEnvironments(string name, bool onPremise, string activeDirectory, string serviceResource,
            string adTenant, string dataLakeJobs, string dataLakeFiles, string kvDnsSuffix,
            string kvResource, string gallery, string graph, string graphResource, string portal,
            string publishSettings, string resourceManager, string serviceManagement,
            string sqlSuffix, string storageSuffix, string trafficManagerSuffix, string batchResource, string dataLakeResource)
        {
            AzureEnvironment azEnvironment = CreateEnvironment(name, onPremise, activeDirectory,
                serviceResource, adTenant, dataLakeJobs, dataLakeFiles, kvDnsSuffix,
                kvResource, gallery, graph, graphResource, portal, publishSettings,
                resourceManager, serviceManagement, sqlSuffix, storageSuffix,
                trafficManagerSuffix, batchResource, dataLakeResource);
            var environment = (PSAzureEnvironment)azEnvironment;
            Assert.NotNull(environment);
            CheckEndpoint(AzureEnvironment.Endpoint.ActiveDirectory, azEnvironment,
                environment.ActiveDirectoryAuthority);
            CheckEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId,
                azEnvironment, environment.ActiveDirectoryServiceEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.AdTenant, azEnvironment,
                environment.AdTenant);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, azEnvironment,
                environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, azEnvironment,
                environment.AzureDataLakeStoreFileSystemEndpointSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.DataLakeEndpointResourceId, azEnvironment,
                environment.DataLakeEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, azEnvironment,
                environment.AzureKeyVaultDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, azEnvironment,
                environment.AzureKeyVaultServiceEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.Gallery, azEnvironment,
                environment.GalleryUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.Graph, azEnvironment,
                environment.GraphUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId, azEnvironment,
                environment.GraphEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl, azEnvironment,
                environment.ManagementPortalUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl, azEnvironment,
                environment.PublishSettingsFileUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.ResourceManager, azEnvironment,
                environment.ResourceManagerUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.ServiceManagement, azEnvironment,
                environment.ServiceManagementUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, azEnvironment,
                environment.SqlDatabaseDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix, azEnvironment,
                environment.StorageEndpointSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, azEnvironment,
                environment.TrafficManagerDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.BatchEndpointResourceId, azEnvironment,
                environment.BatchEndpointResourceId);
            Assert.Equal(azEnvironment.Name, environment.Name);
            Assert.Equal(azEnvironment.OnPremise, environment.EnableAdfsAuthentication);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullPSEnvironments()
        {
            PSAzureEnvironment env = null;
            Assert.Null((AzureEnvironment)env);
            var environment = (AzureEnvironment)new PSAzureEnvironment();
            Assert.NotNull(environment);
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectory));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.AdTenant));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.DataLakeEndpointResourceId));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId));
            Assert.False(environment.OnPremise);
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.Gallery));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.Graph));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.GraphEndpointResourceId));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.ManagementPortalUrl));
            Assert.Null(environment.Name);
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.PublishSettingsFileUrl));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.ResourceManager));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.ServiceManagement));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.StorageEndpointSuffix));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix));
            Assert.False(environment.IsEndpointSet(AzureEnvironment.Endpoint.BatchEndpointResourceId));
        }
        [Theory]
        [InlineData("TestAll", true, "https://login.microsoftonline.com", "https://management.core.windows.net/",
            "Common", "https://mangement.azure.com/dataLakeJobs", "https://management.azure.com/dataLakeFiles",
            ".keyvault.azure.com", "https://keyvault.azure.com/", "https://gallery.azure.com",
            "https://graph.windows.net", "https://graph.windows.net/", "https://manage.windowsazure.com",
            "https://manage.windowsazure.com/publishsettings", "https://management.azure.com",
            "https://management.core.windows.net", ".sql.azure.com", ".core.windows.net",
            ".trafficmanager.windows.net", "https://batch.core.windows.net", "https://datalake.azure.net")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidPSEnvironments(string name, bool onPremise, string activeDirectory, string serviceResource,
            string adTenant, string dataLakeJobs, string dataLakeFiles, string kvDnsSuffix,
            string kvResource, string gallery, string graph, string graphResource, string portal,
            string publishSettings, string resourceManager, string serviceManagement,
            string sqlSuffix, string storageSuffix, string trafficManagerSuffix, string batchResource, string dataLakeResource)
        {
            PSAzureEnvironment environment = new PSAzureEnvironment
            {
                Name = name,
                EnableAdfsAuthentication = onPremise,
                ActiveDirectoryAuthority = activeDirectory,
                ActiveDirectoryServiceEndpointResourceId = serviceResource,
                AdTenant = adTenant,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = dataLakeJobs,
                AzureDataLakeStoreFileSystemEndpointSuffix = dataLakeFiles,
                DataLakeEndpointResourceId = dataLakeResource,
                AzureKeyVaultDnsSuffix = kvDnsSuffix,
                AzureKeyVaultServiceEndpointResourceId = kvResource,
                GalleryUrl = gallery,
                GraphUrl = graph,
                GraphEndpointResourceId = graphResource,
                ManagementPortalUrl = portal,
                PublishSettingsFileUrl = publishSettings,
                ResourceManagerUrl = resourceManager,
                ServiceManagementUrl = serviceManagement,
                SqlDatabaseDnsSuffix = sqlSuffix,
                StorageEndpointSuffix = storageSuffix,
                TrafficManagerDnsSuffix = trafficManagerSuffix,
                BatchEndpointResourceId = batchResource
            };
            var azEnvironment = (AzureEnvironment)environment;
            Assert.NotNull(environment);
            CheckEndpoint(AzureEnvironment.Endpoint.ActiveDirectory, azEnvironment,
                environment.ActiveDirectoryAuthority);
            CheckEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId,
                azEnvironment, environment.ActiveDirectoryServiceEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.AdTenant, azEnvironment,
                environment.AdTenant);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, azEnvironment,
                environment.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, azEnvironment,
                environment.AzureDataLakeStoreFileSystemEndpointSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.DataLakeEndpointResourceId, azEnvironment,
                environment.DataLakeEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, azEnvironment,
                environment.AzureKeyVaultDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, azEnvironment,
                environment.AzureKeyVaultServiceEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.Gallery, azEnvironment,
                environment.GalleryUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.Graph, azEnvironment,
                environment.GraphUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId, azEnvironment,
                environment.GraphEndpointResourceId);
            CheckEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl, azEnvironment,
                environment.ManagementPortalUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl, azEnvironment,
                environment.PublishSettingsFileUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.ResourceManager, azEnvironment,
                environment.ResourceManagerUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.ServiceManagement, azEnvironment,
                environment.ServiceManagementUrl);
            CheckEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, azEnvironment,
                environment.SqlDatabaseDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix, azEnvironment,
                environment.StorageEndpointSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, azEnvironment,
                environment.TrafficManagerDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.BatchEndpointResourceId, azEnvironment,
                environment.BatchEndpointResourceId);
            Assert.Equal(azEnvironment.Name, environment.Name);
            Assert.Equal(azEnvironment.OnPremise, environment.EnableAdfsAuthentication);
        }


        private AzureEnvironment CreateEnvironment(string name, bool onPremise, string activeDirectory, string serviceResource,
            string adTenant, string dataLakeJobs, string dataLakeFiles, string kvDnsSuffix,
            string kvResource, string gallery, string graph, string graphResource, string portal,
            string publishSettings, string resourceManager, string serviceManagement,
            string sqlSuffix, string storageSuffix, string trafficManagerSuffix, string batchResource, string dataLakeResource)
        {
            var environment = new AzureEnvironment() { Name = name, OnPremise = onPremise };
            SetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory, environment, activeDirectory);
            CheckEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId,
                environment, serviceResource);
            CheckEndpoint(AzureEnvironment.Endpoint.AdTenant, environment, adTenant);
            CheckEndpoint(
                AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                environment,
                dataLakeJobs);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix,
                environment,
                dataLakeFiles);
            CheckEndpoint(AzureEnvironment.Endpoint.DataLakeEndpointResourceId,
                environment,
                dataLakeResource);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, environment,
                kvDnsSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId,
                environment,
                kvResource);
            CheckEndpoint(AzureEnvironment.Endpoint.Gallery, environment, gallery);
            CheckEndpoint(AzureEnvironment.Endpoint.Graph, environment, graph);
            CheckEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId, environment,
                graphResource);
            CheckEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl, environment, portal);
            CheckEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl, environment,
                publishSettings);
            CheckEndpoint(AzureEnvironment.Endpoint.ResourceManager, environment,
                resourceManager);
            CheckEndpoint(AzureEnvironment.Endpoint.ServiceManagement, environment,
                serviceManagement);
            CheckEndpoint(AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, environment,
                sqlSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix, environment,
                storageSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, environment,
                trafficManagerSuffix);
            CheckEndpoint(AzureEnvironment.Endpoint.BatchEndpointResourceId, environment,
                batchResource);
            return environment;

        }

        private void SetEndpoint(string endpoint, IAzureEnvironment environment, string endpointValue)
        {
            if (!environment.IsEndpointSet(endpoint) && !string.IsNullOrEmpty(endpointValue))
            {
                environment.SetEndpoint(endpoint, endpointValue);
            }
        }
        private void CheckEndpoint(string endpoint, IAzureEnvironment environment, string valueToCheck)
        {
            if (environment.IsEndpointSet(endpoint))
            {
                Assert.Equal(environment.GetEndpoint(endpoint), valueToCheck);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullAzureSubscriptions()
        {
            Assert.Null((PSAzureSubscription)null);
            var subscription = (PSAzureSubscription)(new AzureSubscription());
            Assert.NotNull(subscription);
            Assert.Null(subscription.CurrentStorageAccountName);
            Assert.Equal(Guid.Empty, subscription.GetId());
            Assert.Null(subscription.Name);
            Assert.Null(subscription.TenantId);
            Assert.NotNull(subscription.ToString());
        }

        [Theory,
        InlineData(null, null, null, null, null),
        InlineData("user@contoso.org", "Test Subscription", "AzureCloud", "juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AzureCloud", "AccountName=juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AzureCloud", "key1 = value1; AccountName = juststorageaccountname", "juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidAzureSubscriptions(string account, string name, string environment, string storageAccount, string expectedAccountName)
        {
            var oldSubscription = new AzureSubscription()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name
            };

            oldSubscription.SetAccount(account);
            oldSubscription.SetEnvironment(environment);
            oldSubscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
            oldSubscription.SetProperty(AzureSubscription.Property.Tenants, Guid.NewGuid().ToString());
            var subscription = (PSAzureSubscription)oldSubscription;
            Assert.Equal(oldSubscription.Name, subscription.Name);
            Assert.Equal(oldSubscription.Id.ToString(), subscription.Id);
            Assert.Equal(oldSubscription.GetProperty(AzureSubscription.Property.Tenants), subscription.TenantId);
            Assert.Equal(expectedAccountName, subscription.CurrentStorageAccountName);
            Assert.Equal(storageAccount, subscription.CurrentStorageAccount);
            Assert.NotNull(subscription.ToString());
            Assert.Equal(oldSubscription.Id, subscription.SubscriptionId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullPSAzureSubscriptions()
        {
            Assert.Null((AzureSubscription)null);
            var subscription = (AzureSubscription)(new PSAzureSubscription());
            Assert.NotNull(subscription);
            Assert.False(subscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
            Assert.False(subscription.IsPropertySet(AzureSubscription.Property.Tenants));
            Assert.Equal(Guid.Empty, subscription.GetId());
            Assert.Null(subscription.Name);
        }

        [Theory,
        InlineData(null, null),
        InlineData("Test Subscription", "juststorageaccountname"),
        InlineData("Test Subscription", "AccountName=juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidPSAzureSubscriptions(string name, string storageAccount)
        {
            var oldSubscription = new PSAzureSubscription()
            {
                CurrentStorageAccount = storageAccount,
                Id = Guid.NewGuid().ToString(),
                Name = name,
                TenantId = Guid.NewGuid().ToString()
            };
            var subscription = (AzureSubscription)oldSubscription;
            Assert.Equal(oldSubscription.Name, subscription.Name);
            Assert.Equal(oldSubscription.Id, subscription.Id.ToString());
            Assert.Equal(oldSubscription.TenantId, subscription.GetProperty(AzureSubscription.Property.Tenants));
            Assert.Equal(storageAccount, subscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullAzureTenants()
        {
            Assert.Null((PSAzureTenant)null);
            var tenant = (PSAzureTenant)(new AzureTenant());
            Assert.NotNull(tenant);
            Assert.Null(tenant.Directory);
            Assert.Equal(Guid.Empty, tenant.GetId());
            Assert.Null(tenant.ToString());
        }

        [Theory,
        InlineData(null),
        InlineData("contoso.org")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidAzureTenants(string domain)
        {
            var oldTenant = new AzureTenant()
            {
                Directory = domain,
                Id = Guid.NewGuid().ToString(),
            };
            var tenant = (PSAzureTenant)oldTenant;
            Assert.Equal(oldTenant.Directory, tenant.Directory);
            Assert.Equal(oldTenant.Id.ToString(), tenant.Id);
            Assert.NotNull(tenant.ToString());
            Assert.Equal(oldTenant.Id, tenant.TenantId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullPSAzureTenants()
        {
            Assert.Null((AzureTenant)null);
            var tenant = (AzureTenant)(new PSAzureTenant());
            Assert.NotNull(tenant);
            Assert.Null(tenant.Directory);
            Assert.Equal(Guid.Empty, tenant.GetId());
        }

        [Theory,
        InlineData(null),
        InlineData("contoso.org")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidPSAzureTenants(string domain)
        {
            var oldTenant = new PSAzureTenant()
            {
                Directory = domain,
                Id = Guid.NewGuid().ToString()
            };
            var tenant = (AzureTenant)oldTenant;
            Assert.Equal(oldTenant.Directory, tenant.Directory);
            Assert.Equal(oldTenant.Id, tenant.Id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullAzureAccounts()
        {
            Assert.Null((PSAzureRmAccount)null);
            var account = (PSAzureRmAccount)(new AzureAccount());
            Assert.NotNull(account);
            Assert.Null(account.Id);
            Assert.Equal(null, account.Type);
            Assert.Null(account.ToString());
        }

        [Theory,
        InlineData(null, AzureAccount.AccountType.AccessToken),
        InlineData("user@contoso.org", AzureAccount.AccountType.User),
        InlineData("user@contoso.org", AzureAccount.AccountType.Certificate),
        InlineData("user@contoso.org", AzureAccount.AccountType.ServicePrincipal)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidAzureAccounts(string id, string type)
        {
            var oldAccount = new AzureAccount()
            {
                Type = type,
                Id = id
            };

            var account = (PSAzureRmAccount)oldAccount;
            Assert.Equal(oldAccount.Type.ToString(), account.Type);
            Assert.Equal(oldAccount.Id, account.Id);
            var accountString = account.ToString();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullPSAzureAccounts()
        {
            Assert.Null((AzureAccount)null);
            var account = (AzureAccount)(new PSAzureRmAccount());
            Assert.NotNull(account);
            Assert.Null(account.Id);
            Assert.Equal(null, account.Type);
        }

        [Theory,
         InlineData(null, AzureAccount.AccountType.AccessToken),
         InlineData("user@contoso.org", AzureAccount.AccountType.User),
         InlineData("user@contoso.org", AzureAccount.AccountType.Certificate),
         InlineData("user@contoso.org", AzureAccount.AccountType.ServicePrincipal)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidPSAzureAccounts(string id, string type)
        {
            var oldAccount = new PSAzureRmAccount
            {
                Id = id,
                Type = type
            };
            var account = (AzureAccount)oldAccount;
            Assert.Equal(oldAccount.Type, account.Type);
            Assert.Equal(oldAccount.Id, account.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullAzureContexts()
        {
            Assert.Null((PSAzureContext)null);
            var context = (PSAzureContext)(new AzureContext(null, null, null, null));
            Assert.NotNull(context);
            Assert.Null(context.Account);
            Assert.Null(context.Tenant);
            Assert.Null(context.Environment);
            Assert.Null(context.Subscription);
            Assert.NotNull(context.ToString());
        }

        [Theory,
        InlineData("user@contoso.org", "Test Subscription", "juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AccountName=juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "key1 = value1; AccountName = juststorageaccountname", "juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidAzureContexts(string account, string subscriptionName, string storageAccount, string expectedAccountName)
        {
            string domain = GetDomainName(account);
            var tenantId = Guid.NewGuid();
            var subscription = new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = subscriptionName };
            subscription.SetAccount(account);
            subscription.SetEnvironment(EnvironmentName.AzureCloud);
            var oldContext = new AzureContext(

                account: new AzureAccount() { Id = account, Type = AzureAccount.AccountType.User },
                environment: AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                subscription: subscription,
                tenant: new AzureTenant() { Id = tenantId.ToString(), Directory = domain });
            oldContext.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, storageAccount);
            oldContext.Subscription.SetProperty(AzureSubscription.Property.Tenants, tenantId.ToString());
            var context = (PSAzureContext)oldContext;
            Assert.NotNull(context);
            Assert.NotNull(context.Account);
            Assert.Equal(oldContext.Account.Type.ToString(), context.Account.Type);
            Assert.Equal(oldContext.Account.Id, context.Account.Id);
            Assert.NotNull(context.Tenant);
            Assert.Equal(oldContext.Tenant.Directory, context.Tenant.Directory);
            Assert.Equal(oldContext.Tenant.Id.ToString(), context.Tenant.Id);
            Assert.NotNull(context.Subscription);
            Assert.Equal(oldContext.Subscription.Name, context.Subscription.Name);
            Assert.Equal(oldContext.Subscription.Id.ToString(), context.Subscription.Id);
            Assert.Equal(oldContext.Subscription.GetTenant(), context.Subscription.GetTenant());
            Assert.Equal(expectedAccountName, ((PSAzureSubscription)context.Subscription).CurrentStorageAccountName);
            Assert.Equal(storageAccount, context.Subscription.GetStorageAccount());
            Assert.NotNull(context.ToString());
        }

        private static string GetDomainName(string account)
        {
            string result = null;
            if (!string.IsNullOrWhiteSpace(account) && account.Contains("@"))
            {
                var parts = account.Split(new char[] { '@' }, 2, StringSplitOptions.RemoveEmptyEntries);
                result = parts[1];
            }

            return result;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertNullPSAzureContexts()
        {
            Assert.Null((AzureContext)null);
            var context = (AzureContext)(new PSAzureContext());
            Assert.NotNull(context);
            Assert.Null(context.Account);
            Assert.Null(context.Environment);
            Assert.Null(context.Subscription);
            Assert.Null(context.Tenant);
        }

        [Theory,
        InlineData("user@contoso.org", "Test Subscription", "juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "AccountName=juststorageaccountname", "juststorageaccountname"),
        InlineData("user@contoso.org", "Test Subscription", "key1 = value1; AccountName = juststorageaccountname", "juststorageaccountname")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanConvertValidPSAzureContexts(string account, string subscription, string storageAccount, string storageAccountName)
        {
            var tenantId = Guid.NewGuid();
            var subscriptionId = Guid.NewGuid();
            var domain = GetDomainName(account);
            var oldContext = new PSAzureContext()
            {
                Account = new PSAzureRmAccount
                {
                    Id = account,
                    Type = "User"
                },
                Environment = (PSAzureEnvironment)AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                Subscription =
                new PSAzureSubscription
                {
                    CurrentStorageAccount = storageAccount,
                    Id = subscriptionId.ToString(),
                    Name = subscription,
                    TenantId = tenantId.ToString()
                },
                Tenant = new PSAzureTenant
                {
                    Directory = domain,
                    Id = tenantId.ToString()
                }
            };
            var context = (AzureContext)oldContext;
            Assert.NotNull(context);
            Assert.NotNull(context.Account);
            Assert.Equal(oldContext.Account.Type, context.Account.Type.ToString());
            Assert.Equal(oldContext.Account.Id, context.Account.Id);
            Assert.NotNull(context.Tenant);
            Assert.Equal(oldContext.Tenant.Directory, context.Tenant.Directory);
            Assert.Equal(oldContext.Tenant.Id, context.Tenant.Id.ToString());
            Assert.NotNull(context.Subscription);
            Assert.Equal(oldContext.Subscription.Name, context.Subscription.Name);
            Assert.Equal(oldContext.Subscription.Id, context.Subscription.Id.ToString());
            Assert.True(context.Subscription.IsPropertySet(AzureSubscription.Property.Tenants));
            Assert.Equal(oldContext.Subscription.GetTenant(), context.Subscription.GetTenant());
            Assert.True(context.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount));
            Assert.Equal(storageAccount, context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount));
        }


    }
}

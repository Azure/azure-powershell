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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    public class RMProfileClient
    {
        private AzureRMProfile _profile;
        private IAzureTokenCache _cache;
        public Action<string> WarningLog;

        public RMProfileClient(AzureRMProfile profile)
        {
            _profile = profile;
            var context = _profile.DefaultContext;
            if (_profile != null && context != null &&
                context.TokenCache != null)
            {
                _cache = context.TokenCache;
            }
        }

        public AzureRMProfile Login(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            SecureString password)
        {
            IAzureSubscription newSubscription = null;
            IAzureTenant newTenant = null;
            string promptBehavior =
                (password == null &&
                 account.Type != AzureAccount.AccountType.AccessToken &&
                 !account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
                ? ShowDialog.Always : ShowDialog.Never;

            // (tenant and subscription are present) OR
            // (tenant is present and subscription is not provided)
            if (!string.IsNullOrEmpty(tenantId))
            {
                var token = AcquireAccessToken(account, environment, tenantId, password, promptBehavior);
                if (TryGetTenantSubscription(token, account, environment, tenantId, subscriptionId, subscriptionName, out newSubscription, out newTenant))
                {
                    account.SetOrAppendProperty(AzureAccount.Property.Tenants, new[] { newTenant.Id.ToString() });
                }
            }
            // (tenant is not provided and subscription is present) OR
            // (tenant is not provided and subscription is not provided)
            else
            {
                var tenants = ListAccountTenants(account, environment, password, promptBehavior).Select(s => s.Id.ToString()).ToArray();
                account.SetProperty(AzureAccount.Property.Tenants, null);
                string accountId = null;

                for (int i = 0; i < tenants.Count(); i++)
                {
                    var tenant = tenants[i];

                    IAzureTenant tempTenant;
                    IAzureSubscription tempSubscription;

                    IAccessToken token = null;

                    try
                    {
                        token = AcquireAccessToken(account, environment, tenant, password, ShowDialog.Auto);

                        if (accountId == null)
                        {
                            accountId = account.Id;
                            account.SetOrAppendProperty(AzureAccount.Property.Tenants, tenant);
                        }
                        else if (accountId.Equals(account.Id, StringComparison.OrdinalIgnoreCase))
                        {
                            account.SetOrAppendProperty(AzureAccount.Property.Tenants, tenant);
                        }
                        else
                        {   // if account ID is different from the first tenant account id we need to ignore current tenant
                            WriteWarningMessage(string.Format(
                                Microsoft.Azure.Commands.Profile.Properties.Resources.AccountIdMismatch,
                                account.Id,
                                tenant,
                                accountId));
                            account.Id = accountId;
                            token = null;
                        }
                    }
                    catch
                    {
                        WriteWarningMessage(string.Format(Microsoft.Azure.Commands.Profile.Properties.Resources.UnableToAqcuireToken, tenant));
                    }

                    if (token != null &&
                        newTenant == null &&
                        TryGetTenantSubscription(token, account, environment, tenant, subscriptionId, subscriptionName, out tempSubscription, out tempTenant))
                    {
                        // If no subscription found for the given token/tenant 
                        // discard tempTenant value unless current token/tenant is the last one.
                        if (tempSubscription != null || i == (tenants.Count() - 1))
                        {
                            newTenant = tempTenant;
                            newSubscription = tempSubscription;
                        }
                    }
                }
            }

            if (newSubscription == null)
            {
                if (subscriptionId != null)
                {
                    throw new PSInvalidOperationException(String.Format(Properties.Resources.SubscriptionIdNotFound, account.Id, subscriptionId));
                }
                else if (subscriptionName != null)
                {
                    throw new PSInvalidOperationException(String.Format(Properties.Resources.SubscriptionNameNotFound, account.Id, subscriptionName));
                }

                _profile.DefaultContext = new AzureContext(account, environment, newTenant);
            }
            else
            {
                _profile.DefaultContext = new AzureContext(newSubscription, account, environment, newTenant);
                if (!newSubscription.State.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                {
                    WriteWarningMessage(string.Format(
                                   Microsoft.Azure.Commands.Profile.Properties.Resources.SelectedSubscriptionNotActive,
                                   newSubscription.State));
                }
            }

            _profile.DefaultContext.TokenCache = _cache;

            return _profile;
        }

        public IAzureContext SetCurrentContext(string tenantId)
        {
            IAzureSubscription firstSubscription = GetFirstSubscription(tenantId);

            if (firstSubscription != null)
            {
                SwitchSubscription(firstSubscription);
            }
            else
            {
                if (_profile.DefaultContext.Account != null)
                {
                    _profile.DefaultContext.Account.SetTenants(tenantId);
                }
                //TODO: should not we clean up this field? It could be a bogus subscription we are leaving behind...
                if (_profile.DefaultContext.Subscription != null)
                {
                    _profile.DefaultContext.Subscription.SetTenant(tenantId);
                }
                _profile.SetContextWithCache(new AzureContext(
                     _profile.DefaultContext.Account,
                     _profile.DefaultContext.Environment,
                     CreateTenant(tenantId)));
            }
            return _profile.DefaultContext;
        }

        public IAzureContext SetCurrentContext(string subscriptionId, string subscriptionName, string tenantId)
        {
            IAzureSubscription subscription;

            if (!string.IsNullOrWhiteSpace(subscriptionId))
            {
                TryGetSubscriptionById(tenantId, subscriptionId, out subscription);
            }
            else if (!string.IsNullOrWhiteSpace(subscriptionName))
            {
                TryGetSubscriptionByName(tenantId, subscriptionName, out subscription);
            }
            else
            {
                throw new ArgumentException(string.Format(
                    "Please provide either subscriptionId or subscriptionName"));
            }

            if (subscription == null)
            {
                string subscriptionFilter = string.IsNullOrWhiteSpace(subscriptionId) ? subscriptionName : subscriptionId;
                throw new ArgumentException(string.Format(
                    "Provided subscription {0} does not exist", subscriptionFilter));
            }
            else
            {
                SwitchSubscription(subscription);
            }

            return _profile.DefaultContext;
        }

        private void SwitchSubscription(IAzureSubscription subscription)
        {
            string tenantId = subscription.GetTenant();

            if (_profile.DefaultContext.Account != null)
            {
                _profile.DefaultContext.Account.SetTenants(tenantId);
            }
            if (_profile.DefaultContext.Subscription != null)
            {
                _profile.DefaultContext.Subscription.SetTenant(tenantId);
            }

            var newSubscription = new AzureSubscription();
            newSubscription.CopyFrom(subscription);

            _profile.SetContextWithCache(new AzureContext(
                newSubscription,
                _profile.DefaultContext.Account,
                _profile.DefaultContext.Environment,
                CreateTenant(tenantId)));
        }

        public List<AzureTenant> ListTenants(string tenant = "")
        {
            List<AzureTenant> tenants = ListAccountTenants(_profile.DefaultContext.Account, _profile.DefaultContext.Environment, null, ShowDialog.Never);
            if (!string.IsNullOrWhiteSpace(tenant))
            {
                tenants = tenants.Where(t => tenant == null ||
                                             tenant.Equals(t.Id.ToString(), StringComparison.OrdinalIgnoreCase) ||
                                             tenant.Equals(t.Directory, StringComparison.OrdinalIgnoreCase))
                                 .ToList();
            }

            return tenants;
        }

        public bool TryGetSubscriptionById(string tenantId, string subscriptionId, out IAzureSubscription subscription)
        {
            Guid subscriptionIdGuid;
            subscription = null;
            if (Guid.TryParse(subscriptionId, out subscriptionIdGuid))
            {
                IEnumerable<IAzureSubscription> subscriptionList = ListSubscriptions(tenantId);
                subscription = subscriptionList.FirstOrDefault(s => s.GetId() == subscriptionIdGuid);
            }
            return subscription != null;
        }

        public bool TryGetSubscriptionByName(string tenantId, string subscriptionName, out IAzureSubscription subscription)
        {
            IEnumerable<IAzureSubscription> subscriptionList = ListSubscriptions(tenantId);
            subscription = subscriptionList.FirstOrDefault(s => s.Name.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));

            return subscription != null;
        }

        private IAzureSubscription GetFirstSubscription(string tenantId)
        {
            IEnumerable<IAzureSubscription> subscriptionList = ListSubscriptions(tenantId);
            return subscriptionList.FirstOrDefault();
        }

        public IAzureEnvironment AddOrSetEnvironment(IAzureEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment", Resources.EnvironmentNeedsToBeSpecified);
            }

            if (AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                throw new InvalidOperationException(
                    string.Format(Resources.ChangingDefaultEnvironmentNotSupported, "environment"));
            }

            if (_profile.EnvironmentTable.ContainsKey(environment.Name))
            {
                _profile.EnvironmentTable[environment.Name] =
                    MergeEnvironmentProperties(environment, _profile.EnvironmentTable[environment.Name]);
            }
            else
            {
                _profile.EnvironmentTable[environment.Name] = environment;
            }

            return _profile.EnvironmentTable[environment.Name];
        }

        public List<IAzureEnvironment> ListEnvironments(string name)
        {
            var result = new List<IAzureEnvironment>();

            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddRange(_profile.Environments);
            }
            else if (_profile.EnvironmentTable.ContainsKey(name))
            {
                result.Add(_profile.EnvironmentTable[name]);
            }

            return result;
        }

        public IAzureEnvironment RemoveEnvironment(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", Resources.EnvironmentNameNeedsToBeSpecified);
            }
            if (AzureEnvironment.PublicEnvironments.ContainsKey(name))
            {
                throw new ArgumentException(Resources.RemovingDefaultEnvironmentsNotSupported, "name");
            }

            if (_profile.EnvironmentTable.ContainsKey(name))
            {
                var environment = _profile.EnvironmentTable[name];
                _profile.EnvironmentTable.Remove(name);
                return environment;
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.EnvironmentNotFound, name), "name");
            }
        }

        public IAccessToken AcquireAccessToken(string tenantId)
        {
            return AcquireAccessToken(_profile.DefaultContext.Account, _profile.DefaultContext.Environment, tenantId, null, ShowDialog.Auto);
        }

        public IEnumerable<IAzureSubscription> ListSubscriptions(string tenantIdOrDomain = "")
        {
            List<IAzureSubscription> subscriptions = new List<IAzureSubscription>();
            var tenants = ListTenants(tenantIdOrDomain);
            foreach (var tenant in tenants)
            {
                try
                {
                    subscriptions.AddRange(
                        ListAllSubscriptionsForTenant(
                            (tenant.GetId() == Guid.Empty) ? tenant.Directory : tenant.Id.ToString()));
                }
                catch (AadAuthenticationException)
                {
                    WriteWarningMessage(string.Format(
                        Microsoft.Azure.Commands.Profile.Properties.Resources.UnableToLogin,
                        _profile.DefaultContext.Account,
                        tenant));
                }

            }

            return subscriptions;
        }

        private AzureTenant CreateTenant(string tenantIdOrDomain)
        {
            var tenant = new AzureTenant();
            Guid tenantIdGuid;
            if (Guid.TryParse(tenantIdOrDomain, out tenantIdGuid))
            {
                tenant.Id = tenantIdGuid.ToString();
            }
            else
            {
                tenant.Directory = tenantIdOrDomain;
            }
            return tenant;
        }

        private IAzureEnvironment MergeEnvironmentProperties(IAzureEnvironment environment1, IAzureEnvironment environment2)
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
                ActiveDirectory = environment1.ActiveDirectory ?? environment2.ActiveDirectory,
                ActiveDirectoryServiceEndpointResourceId = environment1.ActiveDirectoryServiceEndpointResourceId ?? environment2.ActiveDirectoryServiceEndpointResourceId,
                AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = environment1.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix ?? environment2.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,
                AzureKeyVaultDnsSuffix = environment1.AzureKeyVaultDnsSuffix ?? environment2.AzureKeyVaultDnsSuffix,
                Gallery = environment1.Gallery ?? environment2.Gallery,
                GraphEndpointResourceId = environment1.GraphEndpointResourceId ?? environment2.GraphEndpointResourceId,
                AdTenant = environment1.AdTenant ?? environment2.AdTenant,
                AzureDataLakeStoreFileSystemEndpointSuffix = environment1.AzureDataLakeStoreFileSystemEndpointSuffix ?? environment2.AzureDataLakeStoreFileSystemEndpointSuffix,
                AzureKeyVaultServiceEndpointResourceId = environment1.AzureKeyVaultServiceEndpointResourceId ?? environment2.AzureKeyVaultServiceEndpointResourceId,
                Graph = environment1.Graph ?? environment2.Graph,
                ManagementPortal = environment1.ManagementPortal ?? environment2.ManagementPortal,
                OnPremise = environment1.OnPremise || environment2.OnPremise,
                PublishSettingsFile = environment1.PublishSettingsFile ?? environment2.PublishSettingsFile,
                ResourceManager = environment1.ResourceManager ?? environment2.ResourceManager,
                ServiceManagement = environment1.ServiceManagement ?? environment2.ServiceManagement,
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

        private IAccessToken AcquireAccessToken(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            SecureString password,
            string promptBehavior)
        {
            if (account.Type == AzureAccount.AccountType.AccessToken)
            {
                tenantId = tenantId ?? AuthenticationFactory.CommonAdTenant;
                return new SimpleAccessToken(account, tenantId);
            }

            return AzureSession.Instance.AuthenticationFactory.Authenticate(
                account,
                environment,
                tenantId,
                password,
                promptBehavior,
                _cache);
        }

        private bool TryGetTenantSubscription(IAccessToken accessToken,
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            out IAzureSubscription subscription,
            out IAzureTenant tenant)
        {
            using (var subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                        environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        new TokenCredentials(accessToken.AccessToken) as ServiceClientCredentials,
                        AzureSession.Instance.ClientFactory.GetCustomHandlers()))
            {
                Subscription subscriptionFromServer = null;

                try
                {
                    if (subscriptionId != null)
                    {
                        subscriptionFromServer = subscriptionClient.Subscriptions.Get(subscriptionId);
                    }
                    else
                    {
                        var subscriptions = (subscriptionClient.ListAll().ToList() ??
                                                new List<Subscription>())
                                            .Where(s => "enabled".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase) ||
                                                        "warned".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase));

                        account.SetProperty(AzureAccount.Property.Subscriptions, subscriptions.Select(i => i.SubscriptionId).ToArray());

                        if (subscriptions.Any())
                        {
                            if (subscriptionName != null)
                            {
                                subscriptionFromServer = subscriptions.FirstOrDefault(
                                    s => s.DisplayName.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));
                            }
                            else
                            {
                                if (subscriptions.Count() > 1)
                                {
                                    WriteWarningMessage(string.Format(
                                        "TenantId '{0}' contains more than one active subscription. First one will be selected for further use. " +
                                        "To select another subscription, use Set-AzureRmContext.",
                                        tenantId));
                                }
                                subscriptionFromServer = subscriptions.First();
                            }
                        }
                    }
                }
                catch (CloudException ex)
                {
                    WriteWarningMessage(ex.Message);
                }

                if (subscriptionFromServer != null)
                {
                    subscription = new AzureSubscription
                    {
                        Id = subscriptionFromServer.SubscriptionId,
                        Name = subscriptionFromServer.DisplayName,
                        State = subscriptionFromServer.State.ToString()
                    };

                    subscription.SetAccount(accessToken.UserId);
                    subscription.SetEnvironment(environment.Name);
                    subscription.SetTenant(accessToken.TenantId);

                    tenant = new AzureTenant();
                    tenant.Id = accessToken.TenantId;
                    tenant.Directory = accessToken.GetDomain();
                    return true;
                }

                subscription = null;

                if (accessToken != null && accessToken.TenantId != null)
                {
                    tenant = new AzureTenant();
                    tenant.Id = accessToken.TenantId;
                    if (accessToken.UserId != null)
                    {
                        var domain = accessToken.UserId.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                        if (domain.Length == 2)
                        {
                            tenant.Directory = domain[1];
                        }
                    }
                    return true;
                }

                tenant = null;
                return false;
            }
        }

        private List<AzureTenant> ListAccountTenants(IAzureAccount account, IAzureEnvironment environment, SecureString password, string promptBehavior)
        {
            List<AzureTenant> result = new List<AzureTenant>();
            try
            {
                var commonTenantToken = AcquireAccessToken(account, environment, AuthenticationFactory.CommonAdTenant,
                    password, promptBehavior);
                
                SubscriptionClient subscriptionClient = null;
                try
                {
                    subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                        environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        new TokenCredentials(commonTenantToken.AccessToken) as ServiceClientCredentials,
                        AzureSession.Instance.ClientFactory.GetCustomHandlers());
                    //TODO: Fix subscription client to not require subscriptionId
                    result = account.MergeTenants(subscriptionClient.Tenants.List(), commonTenantToken);
                }
                finally
                {
                    // In test mode, we are reusing the client since disposing of it will
                    // fail some tests (due to HttpClient being null)
                    if (subscriptionClient != null && !TestMockSupport.RunningMocked)
                    {
                        subscriptionClient.Dispose();
                    }
                }               
            }
            catch
            {
                WriteWarningMessage(string.Format(Microsoft.Azure.Commands.Profile.Properties.Resources.UnableToAqcuireToken, AuthenticationFactory.CommonAdTenant));
                if (account.IsPropertySet(AzureAccount.Property.Tenants))
                {
                    result =
                        account.GetPropertyAsArray(AzureAccount.Property.Tenants)
                            .Select(ti =>
                            {
                                var tenant = new AzureTenant();

                                Guid guid;
                                if (Guid.TryParse(ti, out guid))
                                {
                                    tenant.Id = ti;
                                    tenant.Directory = AccessTokenExtensions.GetDomain(account.Id);
                                }
                                else
                                {
                                    tenant.Directory = ti;
                                }

                                return tenant;
                            }).ToList();
                }
                if (!result.Any())
                {
                    throw;
                }

            }

            return result;
        }

        private IEnumerable<AzureSubscription> ListAllSubscriptionsForTenant(
            string tenantId)
        {
            IAzureAccount account = _profile.DefaultContext.Account;
            IAzureEnvironment environment = _profile.DefaultContext.Environment;
            SecureString password = null;
            string promptBehavior = ShowDialog.Never;
            IAccessToken accessToken = null;
            try
            {
                accessToken = AcquireAccessToken(account, environment, tenantId, password, promptBehavior);

            }
            catch
            {
                WriteWarningMessage(string.Format(Microsoft.Azure.Commands.Profile.Properties.Resources.UnableToAqcuireToken, tenantId));
                return new List<AzureSubscription>();
            }

            SubscriptionClient subscriptionClient = null;
            try
            {
                subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                        environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                        new TokenCredentials(accessToken.AccessToken) as ServiceClientCredentials,
                        AzureSession.Instance.ClientFactory.GetCustomHandlers());

                AzureContext context = new AzureContext(_profile.DefaultContext.Subscription, account, environment, 
                                            CreateTenantFromString(tenantId, accessToken.TenantId));

                return subscriptionClient.ListAll().Select(s => s.ToAzureSubscription(context));
            }
            finally
            {
                // In test mode, we are reusing the client since disposing of it will
                // fail some tests (due to HttpClient being null)
                if (subscriptionClient != null && !TestMockSupport.RunningMocked)
                {
                    subscriptionClient.Dispose();
                }
            }
        }

        private void WriteWarningMessage(string message)
        {
            if (WarningLog != null)
            {
                WarningLog(message);
            }
        }

        private static AzureTenant CreateTenantFromString(string tenantOrDomain, string accessTokenTenantId)
        {
            AzureTenant result = new AzureTenant();
            Guid id;
            if (Guid.TryParse(tenantOrDomain, out id))
            {
                result.Id = tenantOrDomain;
            }
            else
            {
                result.Id = accessTokenTenantId;
                result.Directory = tenantOrDomain;
            }

            return result;
        }
    }
}

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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Subscriptions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
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
        public Action<string> WarningLog;

        public RMProfileClient(AzureRMProfile profile)
        {
            _profile = profile;

            if (_profile != null && _profile.Context != null &&
                _profile.Context.TokenCache != null && _profile.Context.TokenCache.Length > 0)
            {
                TokenCache.DefaultShared.Deserialize(_profile.Context.TokenCache);
            }
        }

        public AzureRMProfile Login(
            AzureAccount account,
            AzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            SecureString password)
        {
            AzureSubscription newSubscription = null;
            AzureTenant newTenant = null;
            ShowDialog promptBehavior =
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

                    AzureTenant tempTenant;
                    AzureSubscription tempSubscription;

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

                _profile.Context = new AzureContext(account, environment, newTenant);
            }
            else
            {
                _profile.Context = new AzureContext(newSubscription, account, environment, newTenant);
                if (!newSubscription.State.Equals("Enabled", StringComparison.OrdinalIgnoreCase))
                {
                    WriteWarningMessage(string.Format(
                                   Microsoft.Azure.Commands.Profile.Properties.Resources.SelectedSubscriptionNotActive,
                                   newSubscription.State));
                }
            }

            _profile.Context.TokenCache = TokenCache.DefaultShared.Serialize();

            return _profile;
        }

        public AzureContext SetCurrentContext(string tenantId)
        {
            AzureSubscription firstSubscription = GetFirstSubscription(tenantId);

            if (firstSubscription != null)
            {
                SwitchSubscription(firstSubscription);
            }
            else
            {
                if (_profile.Context.Account != null)
                {
                    _profile.Context.Account.Properties[AzureAccount.Property.Tenants] = tenantId;
                }
                //TODO: should not we clean up this field? It could be a bogus subscription we are leaving behind...
                if (_profile.Context.Subscription != null)
                {
                    _profile.Context.Subscription.Properties[AzureSubscription.Property.Tenants] = tenantId;
                }
                _profile.SetContextWithCache(new AzureContext(
                     _profile.Context.Account,
                     _profile.Context.Environment,
                     CreateTenant(tenantId)));
            }
            return _profile.Context;
        }

        public AzureContext SetCurrentContext(string subscriptionId, string subscriptionName, string tenantId)
        {
            AzureSubscription subscription;

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

            return _profile.Context;
        }

        private void SwitchSubscription(AzureSubscription subscription)
        {
            string tenantId = subscription.Properties[AzureSubscription.Property.Tenants];

            if (_profile.Context.Account != null)
            {
                _profile.Context.Account.Properties[AzureAccount.Property.Tenants] = tenantId;
            }
            if (_profile.Context.Subscription != null)
            {
                _profile.Context.Subscription.Properties[AzureSubscription.Property.Tenants] = tenantId;
            }

            var newSubscription = new AzureSubscription
            {
                Id = subscription.Id,
                State = subscription.State
            };
            if (_profile.Context.Subscription != null)
            {
                newSubscription.Account = _profile.Context.Subscription.Account;
                newSubscription.Environment = _profile.Context.Subscription.Environment;
                newSubscription.Properties = _profile.Context.Subscription.Properties;
                newSubscription.Name = (subscription == null) ? null : subscription.Name;
            }

            _profile.SetContextWithCache(new AzureContext(
                newSubscription,
                _profile.Context.Account,
                _profile.Context.Environment,
                CreateTenant(tenantId)));
        }

        public List<AzureTenant> ListTenants(string tenant)
        {
            return ListAccountTenants(_profile.Context.Account, _profile.Context.Environment, null, ShowDialog.Never)
                .Where(t => tenant == null ||
                            tenant.Equals(t.Id.ToString(), StringComparison.OrdinalIgnoreCase) ||
                            tenant.Equals(t.Domain, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool TryGetSubscriptionById(string tenantId, string subscriptionId, out AzureSubscription subscription)
        {
            Guid subscriptionIdGuid;
            subscription = null;
            if (Guid.TryParse(subscriptionId, out subscriptionIdGuid))
            {
                IEnumerable<AzureSubscription> subscriptionList = GetSubscriptions(tenantId);
                subscription = subscriptionList.FirstOrDefault(s => s.Id == subscriptionIdGuid);
            }
            return subscription != null;
        }

        public bool TryGetSubscriptionByName(string tenantId, string subscriptionName, out AzureSubscription subscription)
        {
            IEnumerable<AzureSubscription> subscriptionList = GetSubscriptions(tenantId);
            subscription = subscriptionList.FirstOrDefault(s => s.Name.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));

            return subscription != null;
        }

        private AzureSubscription GetFirstSubscription(string tenantId)
        {
            IEnumerable<AzureSubscription> subscriptionList = GetSubscriptions(null);
            return subscriptionList.FirstOrDefault();
        }

        public IEnumerable<AzureSubscription> GetSubscriptions(string tenantId)
        {
            IEnumerable<AzureSubscription> subscriptionList = new List<AzureSubscription>();
            string listNextLink = null;
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                subscriptionList = ListSubscriptions();
            }
            else
            {
                subscriptionList = ListSubscriptions(tenantId, ref listNextLink);
            }

            return subscriptionList;
        }

        public AzureEnvironment AddOrSetEnvironment(AzureEnvironment environment)
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

            if (_profile.Environments.ContainsKey(environment.Name))
            {
                _profile.Environments[environment.Name] =
                    MergeEnvironmentProperties(environment, _profile.Environments[environment.Name]);
            }
            else
            {
                _profile.Environments[environment.Name] = environment;
            }

            return _profile.Environments[environment.Name];
        }

        public List<AzureEnvironment> ListEnvironments(string name)
        {
            var result = new List<AzureEnvironment>();

            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddRange(_profile.Environments.Values);
            }
            else if (_profile.Environments.ContainsKey(name))
            {
                result.Add(_profile.Environments[name]);
            }

            return result;
        }

        public AzureEnvironment RemoveEnvironment(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", Resources.EnvironmentNameNeedsToBeSpecified);
            }
            if (AzureEnvironment.PublicEnvironments.ContainsKey(name))
            {
                throw new ArgumentException(Resources.RemovingDefaultEnvironmentsNotSupported, "name");
            }

            if (_profile.Environments.ContainsKey(name))
            {
                var environment = _profile.Environments[name];
                _profile.Environments.Remove(name);
                return environment;
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.EnvironmentNotFound, name), "name");
            }
        }

        public IAccessToken AcquireAccessToken(string tenantId)
        {
            return AcquireAccessToken(_profile.Context.Account, _profile.Context.Environment, tenantId, null, ShowDialog.Auto);
        }

        /// <summary>
        /// List all tenants for the account in the profile context
        /// </summary>
        /// <returns>The list of tenants for the default account.</returns>
        public IEnumerable<AzureTenant> ListTenants()
        {
            return ListAccountTenants(_profile.Context.Account, _profile.Context.Environment, null, ShowDialog.Never);
        }

        public IEnumerable<AzureSubscription> ListSubscriptions(string tenant, ref string listNextLink)
        {
            return ListSubscriptionsForTenant(
                _profile.Context.Account,
                _profile.Context.Environment,
                null,
                ShowDialog.Never,
                tenant,
                ref listNextLink);
        }

        public IEnumerable<AzureSubscription> ListSubscriptions()
        {
            string listNextLink = null;

            List<AzureSubscription> subscriptions = new List<AzureSubscription>();
            foreach (var tenant in ListTenants())
            {
                try
                {
                    subscriptions.AddRange(
                        ListSubscriptions(
                            (tenant.Id == Guid.Empty) ? tenant.Domain : tenant.Id.ToString(),
                            ref listNextLink));
                }
                catch (AadAuthenticationException)
                {
                    WriteWarningMessage(string.Format(
                        Microsoft.Azure.Commands.Profile.Properties.Resources.UnableToLogin,
                        _profile.Context.Account,
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
                tenant.Id = tenantIdGuid;
            }
            else
            {
                tenant.Domain = tenantIdOrDomain;
            }
            return tenant;
        }

        private AzureEnvironment MergeEnvironmentProperties(AzureEnvironment environment1, AzureEnvironment environment2)
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
                Name = environment1.Name
            };

            // Merge all properties
            foreach (AzureEnvironment.Endpoint property in Enum.GetValues(typeof(AzureEnvironment.Endpoint)))
            {
                string propertyValue = environment1.GetEndpoint(property) ?? environment2.GetEndpoint(property);
                if (propertyValue != null)
                {
                    mergedEnvironment.Endpoints[property] = propertyValue;
                }
            }

            return mergedEnvironment;
        }

        private IAccessToken AcquireAccessToken(AzureAccount account,
            AzureEnvironment environment,
            string tenantId,
            SecureString password,
            ShowDialog promptBehavior)
        {
            if (account.Type == AzureAccount.AccountType.AccessToken)
            {
                tenantId = tenantId ?? AuthenticationFactory.CommonAdTenant;
                return new SimpleAccessToken(account, tenantId);
            }

            return AzureSession.AuthenticationFactory.Authenticate(
                account,
                environment,
                tenantId,
                password,
                promptBehavior,
                TokenCache.DefaultShared);
        }

        private bool TryGetTenantSubscription(IAccessToken accessToken,
            AzureAccount account,
            AzureEnvironment environment,
            string tenantId,
            string subscriptionId,
            string subscriptionName,
            out AzureSubscription subscription,
            out AzureTenant tenant)
        {
            using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                new TokenCloudCredentials(accessToken.AccessToken),
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
            {
                Subscriptions.Models.Subscription subscriptionFromServer = null;

                try
                {
                    if (subscriptionId != null)
                    {
                        subscriptionFromServer = subscriptionClient.Subscriptions.Get(subscriptionId).Subscription;
                    }
                    else
                    {
                        var subscriptions = (subscriptionClient.Subscriptions.List().Subscriptions ??
                                                new List<Microsoft.Azure.Subscriptions.Models.Subscription>())
                                            .Where(s => "enabled".Equals(s.State, StringComparison.OrdinalIgnoreCase) ||
                                                        "warned".Equals(s.State, StringComparison.OrdinalIgnoreCase));

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
                        Id = new Guid(subscriptionFromServer.SubscriptionId),
                        Account = accessToken.UserId,
                        Environment = environment.Name,
                        Name = subscriptionFromServer.DisplayName,
                        State = subscriptionFromServer.State,
                        Properties = new Dictionary<AzureSubscription.Property, string>
                        {
                            { AzureSubscription.Property.Tenants, accessToken.TenantId }
                        }
                    };

                    tenant = new AzureTenant();
                    tenant.Id = new Guid(accessToken.TenantId);
                    tenant.Domain = accessToken.GetDomain();
                    return true;
                }

                subscription = null;

                if (accessToken != null && accessToken.TenantId != null)
                {
                    tenant = new AzureTenant();
                    tenant.Id = Guid.Parse(accessToken.TenantId);
                    if (accessToken.UserId != null)
                    {
                        var domain = accessToken.UserId.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                        if (domain.Length == 2)
                        {
                            tenant.Domain = domain[1];
                        }
                    }
                    return true;
                }

                tenant = null;
                return false;
            }
        }

        private List<AzureTenant> ListAccountTenants(AzureAccount account, AzureEnvironment environment, SecureString password, ShowDialog promptBehavior)
        {
            List<AzureTenant> result = new List<AzureTenant>();
            try
            {
                var commonTenantToken = AcquireAccessToken(account, environment, AuthenticationFactory.CommonAdTenant,
                    password, promptBehavior);

                using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                    new TokenCloudCredentials(commonTenantToken.AccessToken),
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
                {
                    //TODO: Fix subscription client to not require subscriptionId
                    result = account.MergeTenants(subscriptionClient.Tenants.List().TenantIds, commonTenantToken);
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
                                    tenant.Id = guid;
                                    tenant.Domain = AccessTokenExtensions.GetDomain(account.Id);
                                }
                                else
                                {
                                    tenant.Domain = ti;
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

        private IEnumerable<AzureSubscription> ListSubscriptionsForTenant(
            AzureAccount account,
            AzureEnvironment environment,
            SecureString password,
            ShowDialog promptBehavior,
            string tenantId,
            ref string listNextLink)
        {
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

            using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                new TokenCloudCredentials(accessToken.AccessToken),
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
            {
                Microsoft.Azure.Subscriptions.Models.SubscriptionListResult subscriptions = null;
                if (listNextLink == null)
                {
                    subscriptions = subscriptionClient.Subscriptions.List();
                }
                else
                {
                    subscriptions = subscriptionClient.Subscriptions.ListNext(listNextLink);
                }
                if (subscriptions != null && subscriptions.Subscriptions != null)
                {
                    listNextLink = subscriptions.NextLink;
                    return
                        subscriptions.Subscriptions.Select(
                            (s) =>
                                s.ToAzureSubscription(new AzureContext(_profile.Context.Subscription, account,
                                    environment, CreateTenantFromString(tenantId, accessToken.TenantId))));
                }

                return new List<AzureSubscription>();
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
                result.Id = id;
            }
            else
            {
                result.Id = Guid.Parse(accessTokenTenantId);
                result.Domain = tenantOrDomain;
            }

            return result;
        }
    }
}

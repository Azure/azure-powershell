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
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using Microsoft.Azure.Subscriptions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public AzureRMProfile Login(AzureAccount account, AzureEnvironment environment, string tenantId, string subscriptionId, string subscriptionName, SecureString password)
        {
            AzureSubscription newSubscription = null;
            AzureTenant newTenant = null;
            ShowDialog promptBehavior = password == null ? ShowDialog.Always : ShowDialog.Never;

            // (tenant and subscription are present) OR
            // (tenant is present and subscription is not provided)
            if (!string.IsNullOrEmpty(tenantId))
            {
                var token = AcquireAccessToken(account, environment, tenantId, password, promptBehavior);
                TryGetTenantSubscription(token, account, environment, tenantId, subscriptionId, subscriptionName, out newSubscription, out newTenant);
            }
            // (tenant is not provided and subscription is present) OR
            // (tenant is not provided and subscription is not provided)
            else
            {
                foreach (var tenant in ListAccountTenants(account, environment, password, promptBehavior))
                {
                    AzureTenant tempTenant;
                    AzureSubscription tempSubscription;
                    var token = AcquireAccessToken(account, environment, tenant.Id.ToString(), password,
                        ShowDialog.Auto);
                    if (newTenant == null && TryGetTenantSubscription(token, account, environment, tenant.Id.ToString(), subscriptionId, subscriptionName, out tempSubscription, out tempTenant) &&
                        newTenant == null)
                    {
                        newTenant = tempTenant;
                        newSubscription = tempSubscription;
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
                    throw new PSInvalidOperationException(String.Format(Properties.Resources.SubscriptionNameNotFound, account.Id, subscriptionId));
                }
                else
                {
                    throw new PSInvalidOperationException(String.Format(Properties.Resources.NoSubscriptionFound, account.Id));
                }
            }

            _profile.Context = new AzureContext(newSubscription, account, environment, newTenant);
            _profile.Context.TokenCache = TokenCache.DefaultShared.Serialize();

            return _profile;
        }

        public AzureContext SetCurrentContext(string subscriptionId, string tenantId)
        {
            if (!string.IsNullOrWhiteSpace(tenantId))
            {
                _profile.Context = new AzureContext(
                    _profile.Context.Subscription,
                    _profile.Context.Account,
                    _profile.Context.Environment,
                    new AzureTenant() { Id = new Guid(tenantId) });

                if (_profile.Context.Account != null)
                {
                    _profile.Context.Account.Properties[AzureAccount.Property.Tenants] = tenantId;
                }
                if (_profile.Context.Subscription != null)
                {
                    _profile.Context.Subscription.Properties[AzureSubscription.Property.Tenants] = tenantId;
                }
            }

            if (!string.IsNullOrWhiteSpace(subscriptionId))
            {
                if (!ListSubscriptions(_profile.Context.Tenant.Id.ToString()).Any(s =>
                    string.Equals(s.Id.ToString(), subscriptionId, StringComparison.OrdinalIgnoreCase) ) )
                {
                    throw new ArgumentException(string.Format(
                        "Provided subscription {0} does not exist under current tenant {1}", subscriptionId, _profile.Context.Tenant.Id));
                }

                var newSubscription = new AzureSubscription { Id = new Guid(subscriptionId) };
                if (_profile.Context.Subscription != null)
                {
                    newSubscription.Account = _profile.Context.Subscription.Account;
                    newSubscription.Environment = _profile.Context.Subscription.Environment;
                    newSubscription.Properties = _profile.Context.Subscription.Properties;
                    newSubscription.Name = null;
                }

                _profile.Context = new AzureContext(
                    newSubscription,
                    _profile.Context.Account,
                    _profile.Context.Environment,
                    _profile.Context.Tenant);
            }

            return _profile.Context;
        }

        public List<AzureTenant> ListTenants(string tenant)
        {
            return ListAccountTenants(_profile.Context.Account, _profile.Context.Environment, null, ShowDialog.Auto)
                .Where(t => tenant == null ||
                            tenant.Equals(t.Id.ToString(), StringComparison.OrdinalIgnoreCase) ||
                            tenant.Equals(t.Domain, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool TryGetSubscription(string tenantId, string subscriptionId, out AzureSubscription subscription)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                throw new ArgumentNullException("Please provide a valid tenant Id.");
            }

            AzureTenant tenant;
            var token = AcquireAccessToken(_profile.Context.Account, _profile.Context.Environment,
                tenantId, null, ShowDialog.Never);
            return TryGetTenantSubscription(token, _profile.Context.Account, _profile.Context.Environment,
                tenantId, subscriptionId, null, out subscription, out tenant);
        }

        public bool TryGetSubscriptionByName(string tenantId, string subscriptionName, out AzureSubscription subscription)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
            {
                throw new ArgumentNullException("Please provide a valid tenant Id.");
            }

            IEnumerable<AzureSubscription> subscriptionList = ListSubscriptions(tenantId);
            subscription = subscriptionList.FirstOrDefault(s => s.Name.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));

            return subscription != null;
        }

        public AzureEnvironment AddOrSetEnvironment(AzureEnvironment environment)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment", Resources.EnvironmentNeedsToBeSpecified);
            }

            if (AzureEnvironment.PublicEnvironments.ContainsKey(environment.Name))
            {
                throw new ArgumentException(Resources.ChangingDefaultEnvironmentNotSupported, "environment");
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
                        var subscriptions = subscriptionClient.Subscriptions.List().Subscriptions;
                        if (subscriptions != null && subscriptions.Any())
                        {
                            if (subscriptionName != null)
                            {
                                subscriptionFromServer = subscriptions.FirstOrDefault(s => s.DisplayName.Equals(subscriptionName, StringComparison.OrdinalIgnoreCase));
                            }
                            else
                            {
                                if (subscriptions.Count > 1)
                                {
                                    WriteWarningMessage(string.Format(
                                        "Tenant '{0}' contains more than one subscription. First one will be selected for further use. " +
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
                        Properties = new Dictionary<AzureSubscription.Property, string> { { AzureSubscription.Property.Tenants, accessToken.TenantId } }
                    };

                    account.Properties[AzureAccount.Property.Tenants] = accessToken.TenantId;
                    tenant = new AzureTenant();
                    tenant.Id = new Guid(accessToken.TenantId);
                    tenant.Domain = accessToken.GetDomain();
                    return true;
                }

                subscription = null;
                tenant = null;
                return false;
            }
        }

        private List<AzureTenant> ListAccountTenants(AzureAccount account, AzureEnvironment environment, SecureString password, ShowDialog promptBehavior)
        {
            var commonTenantToken = AcquireAccessToken(account, environment, AuthenticationFactory.CommonAdTenant,
                password, promptBehavior);

            using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                    new TokenCloudCredentials(commonTenantToken.AccessToken),
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
            {
                return subscriptionClient.Tenants.List().TenantIds
                    .Select(ti => new AzureTenant() { Id = new Guid(ti.TenantId), Domain = commonTenantToken.GetDomain() })
                    .ToList();
            }
        }

        /// <summary>
        /// List all tenants for the account in the profile context
        /// </summary>
        /// <returns>The list of tenants for the default account.</returns>
        public IEnumerable<AzureTenant> ListTenants()
        {
            return ListAccountTenants(_profile.Context.Account, _profile.Context.Environment, null, ShowDialog.Never);
        }

        private IEnumerable<AzureSubscription> ListSubscriptionsForTenant(AzureAccount account, AzureEnvironment environment,
            SecureString password, ShowDialog promptBehavior, string tenantId)
        {
            var accessToken = AcquireAccessToken(account, environment, tenantId, password, promptBehavior);
            using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                new TokenCloudCredentials(accessToken.AccessToken),
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
            {
                var subscriptions = subscriptionClient.Subscriptions.List();
                if (subscriptions != null && subscriptions.Subscriptions != null)
                {
                    return
                        subscriptions.Subscriptions.Select(
                            (s) =>
                                s.ToAzureSubscription(new AzureContext(_profile.Context.Subscription, account,
                                    environment, CreateTenantFromString(tenantId))));
                }

                return null;
            }
        }

        public IEnumerable<AzureSubscription> ListSubscriptions(string tenant)
        {
            return ListSubscriptionsForTenant(_profile.Context.Account, _profile.Context.Environment, null,
                ShowDialog.Never, tenant);
        }

        public IEnumerable<AzureSubscription> ListSubscriptions()
        {
            List<AzureSubscription> subscriptions = new List<AzureSubscription>();
            foreach (var tenant in ListTenants())
            {
                try
                {
                    subscriptions.AddRange(ListSubscriptions(tenant.Id.ToString()));
                }
                catch (AadAuthenticationException)
                {
                    WriteWarningMessage(string.Format("Could not authenticate user account {0} with tenant {1}.  " +
                       "Subscriptions in this tenant will not be listed. Please login again using Login-AzureRmAccount " +
                       "to view the subscriptions in this tenant.", _profile.Context.Account, tenant));
                }

            }

            return subscriptions;
        }

        private void WriteWarningMessage(string message)
        {
            if (WarningLog != null)
            {
                WarningLog(message);
            }
        }

        private static AzureTenant CreateTenantFromString(string tenantOrDomain)
        {
            AzureTenant result = new AzureTenant();
            Guid id;
            if (Guid.TryParse(tenantOrDomain, out id))
            {
                result.Id = id;
            }
            else
            {
                result.Domain = tenantOrDomain;
            }

            return result;
        }
    }
}

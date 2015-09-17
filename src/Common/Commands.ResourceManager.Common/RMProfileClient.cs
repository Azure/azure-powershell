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

        public AzureRMProfile Login(AzureAccount account, AzureEnvironment environment, string tenantId, string subscriptionId, SecureString password)
        {
            AzureSubscription newSubscription = null;
            AzureTenant newTenant = null;
            ShowDialog promptBehavior = password == null ? ShowDialog.Always : ShowDialog.Never;

            // (tenant and subscription are present) OR
            // (tenant is present and subscription is not provided)
            if (!string.IsNullOrEmpty(tenantId))
            {
                TryGetTenantSubscription(account, environment, tenantId, subscriptionId, password, promptBehavior, out newSubscription, out newTenant);
            }
            // (tenant is not provided and subscription is present) OR
            // (tenant is not provided and subscription is not provided)
            else
            {
                foreach(var tenant in ListAccountTenants(account, environment, password, promptBehavior))
                {
                    if (TryGetTenantSubscription(account, environment, tenant.Id.ToString(), subscriptionId, password, ShowDialog.Auto, out newSubscription, out newTenant))
                    {
                        break;
                    }
                }
            }

            if (newSubscription == null)
            {
                throw new PSInvalidOperationException("Subscription was not found.");
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
            }

            if(!string.IsNullOrWhiteSpace(subscriptionId))
            {
                var newSubscription = new AzureSubscription { Id = new Guid(subscriptionId) };
                if(_profile.Context.Subscription != null)
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
                throw new ArgumentNullException("Please provide a valid tenant Id");
            }

            AzureTenant tenant;
            return TryGetTenantSubscription(_profile.Context.Account, _profile.Context.Environment,
                tenantId, subscriptionId, null, ShowDialog.Never, out subscription, out tenant);
        }

        private bool TryGetTenantSubscription(
            AzureAccount account, 
            AzureEnvironment environment, 
            string tenantId, 
            string subscriptionId, 
            SecureString password, 
            ShowDialog promptBehavior, 
            out AzureSubscription subscription,
            out AzureTenant tenant)
        {
            var accessToken = AzureSession.AuthenticationFactory.Authenticate(
                    account,
                    environment,
                    tenantId,
                    password,
                    promptBehavior,
                    TokenCache.DefaultShared);
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
                            if (subscriptions.Count > 1)
                            {
                                WriteWarningMessage(string.Format(
                                    "Tenant '{0}' contains more than one subscription. First one will be selected for further use. " +
                                    "To select another subscription, use Set-AzureRMContext.",
                                    tenantId));
                            }
                            subscriptionFromServer = subscriptions.First();
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
            var commonTenantToken = AzureSession.AuthenticationFactory.Authenticate(
                account, 
                environment,
                AuthenticationFactory.CommonAdTenant, 
                password, 
                promptBehavior,
                TokenCache.DefaultShared);

            using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                    new TokenCloudCredentials(commonTenantToken.AccessToken),
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
            {
                return subscriptionClient.Tenants.List().TenantIds
                    .Select(ti => new AzureTenant() { Id = new Guid(ti.TenantId), Domain = commonTenantToken.GetDomain() } )
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
            var accessToken = AzureSession.AuthenticationFactory.Authenticate(
                    account,
                    environment,
                    tenantId,
                    password,
                    promptBehavior);
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
                       "Subscriptions in this tenant will not be listed. Please login again using Login-AzureRMAccount " +
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

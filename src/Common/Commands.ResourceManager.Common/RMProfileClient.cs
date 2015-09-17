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

        public AzureContext UpdateCurrentContext(string subscriptionId, string tenantId)
        {
            AzureSubscription newSubscription = null;
            AzureTenant newTenant = null;
            AzureAccount account = _profile.Context.Account;
            AzureEnvironment envrionment = _profile.Context.Environment;
            ShowDialog promptBehavior = ShowDialog.Auto;

            if (!string.IsNullOrWhiteSpace(tenantId) &&
                !string.IsNullOrWhiteSpace(subscriptionId))
            {                
                if(TryGetTenantSubscription(account, envrionment, tenantId, subscriptionId, null, promptBehavior, out newSubscription, out newTenant))
                {
                    _profile.Context = new AzureContext(newSubscription, account, envrionment, newTenant);
                }
            }
            else if (!string.IsNullOrWhiteSpace(tenantId))
            {
                var accessToken = AzureSession.AuthenticationFactory.Authenticate(
                   account,
                   envrionment,
                   tenantId,
                   null,
                   promptBehavior,
                   TokenCache.DefaultShared);

                account.Properties[AzureAccount.Property.Tenants] = accessToken.TenantId;
                newTenant = new AzureTenant();
                newTenant.Id = new Guid(accessToken.TenantId);
                newTenant.Domain = accessToken.GetDomain();
                _profile.Context = new AzureContext(account, envrionment, newTenant);
            }
            else if(!string.IsNullOrWhiteSpace(subscriptionId))
            {
                foreach (var tenant in ListAccountTenants(account, envrionment, null, promptBehavior))
                {
                    if (TryGetTenantSubscription(account, envrionment, tenant.Id.ToString(), subscriptionId, null, promptBehavior, out newSubscription, out newTenant))
                    {
                        _profile.Context = new AzureContext(newSubscription, account, envrionment, newTenant);
                        break;
                    }
                }
            }
            else
            {
                throw new PSNotSupportedException();
            }

            _profile.Context.TokenCache = TokenCache.DefaultShared.Serialize();

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
                                    "Tenant '{0}' contains more than one subscription. First one will be selected for further use.",
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

        private void WriteWarningMessage(string message)
        {
            if (WarningLog != null)
            {
                WarningLog(message);
            }
        }
    }
}

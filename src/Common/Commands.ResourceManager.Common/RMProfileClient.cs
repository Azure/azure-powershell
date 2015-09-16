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
        }

        public AzureRMProfile Login(AzureAccount account, AzureEnvironment environment, string tenantId, string subscriptionId, SecureString password)
        {
            AzureSubscription newSubscription = null;
            AzureTenant newTenant = new AzureTenant();

            // (tenant and subscription are present) OR
            // (tenant is present and subscription is not provided)
            if (!string.IsNullOrEmpty(tenantId))
            {
                newTenant.Id = new Guid(tenantId);
                ShowDialog promptBehavior = password == null ? ShowDialog.Always : ShowDialog.Never;
                TryGetTenantSubscription(account, environment, tenantId, subscriptionId, password, promptBehavior, out newSubscription);
            }
            // (tenant is not provided and subscription is present) OR
            // (tenant is not provided and subscription is not provided)
            else
            {
                foreach(var tenant in ListAccountTenants(account, environment, password))
                {
                    if (TryGetTenantSubscription(account, environment, tenant, subscriptionId, password, ShowDialog.Auto, out newSubscription))
                    {
                        newTenant.Id = new Guid(tenant);
                        break;
                    }
                }

            }

            if (newSubscription == null)
            {
                throw new PSInvalidOperationException("Subscription was not found.");
            }

            _profile.DefaultContext = new AzureContext(newSubscription, account, environment, newTenant);

            return _profile;
        }

        public bool TryGetSubscription(string tenantId, string subscriptionId, out AzureSubscription subscription)
        {
            return TryGetTenantSubscription(_profile.DefaultContext.Account, _profile.DefaultContext.Environment,
                tenantId, subscriptionId, null, ShowDialog.Never, out subscription);
        }

        private bool TryGetTenantSubscription(
            AzureAccount account, 
            AzureEnvironment environment, 
            string tenantId, 
            string subscriptionId, 
            SecureString password, 
            ShowDialog promptBehavior, 
            out AzureSubscription subscription)
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
                        if (subscriptions != null)
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
                    return true;
                }

                subscription = null;
                return false;
            }
        }

        private string[] ListAccountTenants(AzureAccount account, AzureEnvironment environment, SecureString password)
        {
            ShowDialog promptBehavior = password == null ? ShowDialog.Always : ShowDialog.Never;

            var commonTenantToken = AzureSession.AuthenticationFactory.Authenticate(account, environment,
                AuthenticationFactory.CommonAdTenant, password, promptBehavior);

            using (var subscriptionClient = AzureSession.ClientFactory.CreateCustomClient<SubscriptionClient>(
                    new TokenCloudCredentials(commonTenantToken.AccessToken),
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager)))
            {
                return subscriptionClient.Tenants.List().TenantIds.Select(ti => ti.TenantId).ToArray();
            }
        }

        /// <summary>
        /// List all tenants for the account in the profile context
        /// </summary>
        /// <returns>The list of tenants for the default account.</returns>
        public string[] ListTenants()
        {
            return ListAccountTenants(_profile.DefaultContext.Account, _profile.DefaultContext.Environment, null);
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
                                s.ToAzureSubscription(new AzureContext(_profile.DefaultContext.Subscription, account,
                                    environment, new AzureTenant {Id = new Guid(tenantId)})));
                }

                return null;
            }
        }

        public IEnumerable<AzureSubscription> ListSubscriptions(string tenant)
        {
            return ListSubscriptionsForTenant(_profile.DefaultContext.Account, _profile.DefaultContext.Environment, null,
                ShowDialog.Never, tenant);
        }

        public IEnumerable<AzureSubscription> ListSubscriptions()
        {
            List<AzureSubscription> subscriptions = new List<AzureSubscription>();
            foreach (var tenant in ListTenants())
            {
                try
                {
                    subscriptions.AddRange(ListSubscriptions(tenant));
                }
                catch (AadAuthenticationException)
                {
                    WriteWarningMessage(string.Format("Could not authenticate user account {0} with tenant {1}.  " +
                       "Subscriptions in this tenant will not be listed. Please login again using Login-AzureRMAccount " +
                       "to view the subscriptions in this tenant.", _profile.DefaultContext.Account, tenant));
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
    }
}

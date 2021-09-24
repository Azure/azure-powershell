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
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Utilities
{
    class SubscriptionAndTenantHelper
    {
        internal static IAccessToken AcquireAccessToken(IAzureAccount account, IAzureEnvironment environment, string tenantId)
        {
            return AzureSession.Instance.AuthenticationFactory.Authenticate(
               account,
               environment,
               tenantId,
               null,
               ShowDialog.Never,
               null);
        }

        internal static Dictionary<string, AzureSubscription> GetTenantsForSubscriptions(List<string> subscriptionIds, IAzureContext defaultContext)
        {
            Dictionary<string, AzureSubscription> result = new Dictionary<string, AzureSubscription>();

            if (subscriptionIds != null && subscriptionIds.Count != 0)
            {
                //First get all the tenants, then get subscriptions in each tenant till we exhaust the subscriotions sent in
                //Or we exhaust the tenants
                List<AzureTenant> tenants = ListAccountTenants(defaultContext);

                HashSet<string> subscriptionIdSet = new HashSet<string>(subscriptionIds);

                foreach (var tenant in tenants)
                {
                    if (subscriptionIdSet.Count <= 0)
                    {
                        break;
                    }

                    var tId = tenant.GetId().ToString();
                    var subscriptions = ListAllSubscriptionsForTenant(defaultContext, tId);
                    
                    subscriptions?.ForEach((s) =>
                     {
                         var sId = s.GetId().ToString();
                         if (subscriptionIdSet.Contains(sId))
                         {
                             result.Add(sId, s);
                             subscriptionIdSet.Remove(sId);
                         }
                     }) ;
                }
            }

            return result;
        }

        private static List<AzureTenant> ListAccountTenants(
            IAzureContext defaultContext)
        {
            List<AzureTenant> result = new List<AzureTenant>();
            var commonTenant = GetCommonTenant(defaultContext.Account);

            var commonTenantToken = AcquireAccessToken(
                defaultContext.Account,
                defaultContext.Environment,
                commonTenant);

            SubscriptionClient subscriptionClient = null;
            try
            {
                subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                    defaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                    new TokenCredentials(commonTenantToken.AccessToken) as ServiceClientCredentials,
                    AzureSession.Instance.ClientFactory.GetCustomHandlers());

                var tenants = subscriptionClient.Tenants.List();
                if (tenants != null)
                {
                    result = new List<AzureTenant>();
                    tenants.ForEach((t) =>
                    {
                        result.Add(new AzureTenant { Id = t.TenantId, Directory = commonTenantToken.GetDomain() });
                    });
                }
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

            return result;
        }

        private static IEnumerable<AzureSubscription> ListAllSubscriptionsForTenant(
            IAzureContext defaultContext,
            string tenantId)
        {
            IAzureAccount account = defaultContext.Account;
            IAzureEnvironment environment = defaultContext.Environment;
            IAccessToken accessToken = null;
            try
            {
                accessToken = AcquireAccessToken(account, environment, tenantId);
            }
            catch (Exception e)
            {
                throw new AadAuthenticationFailedException("Could not find subscriptions", e);
            }

            SubscriptionClient subscriptionClient = null;
            subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                    new TokenCredentials(accessToken.AccessToken) as ServiceClientCredentials,
                    AzureSession.Instance.ClientFactory.GetCustomHandlers());

            AzureContext context = new AzureContext(defaultContext.Subscription, account, environment,
                                        CreateTenantFromString(tenantId, accessToken.TenantId));

            return subscriptionClient.ListAllSubscriptions().Select(s => ToAzureSubscription(s, context));
        }

        private static string GetCommonTenant(IAzureAccount account)
        {
            string result = AzureEnvironmentConstants.CommonAdTenant;
            if (account.IsPropertySet(AzureAccount.Property.Tenants))
            {
                var candidate = account.GetTenants().FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(candidate))
                {
                    result = candidate;
                }
            }

            return result;
        }

        private static AzureSubscription ToAzureSubscription(Subscription other, IAzureContext context)
        {
            var subscription = new AzureSubscription();
            subscription.SetAccount(context.Account != null ? context.Account.Id : null);
            subscription.SetEnvironment(context.Environment != null ? context.Environment.Name : EnvironmentName.AzureCloud);
            subscription.Id = other.SubscriptionId;
            subscription.Name = other.DisplayName;
            subscription.State = other.State.ToString();
            subscription.SetTenant(context.Tenant.Id.ToString());
            return subscription;
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

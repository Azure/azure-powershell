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
using Microsoft.Azure.Commands.ResourceManager.Common.Paging;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Azure.Internal.Subscriptions.Models.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Utilities
{
    internal class SubscriptionClientWrapper : ISubscriptionClientWrapper
    {
        public SubscriptionClientWrapper()
        {
            ApiVersion = "2016-06-01";
        }

        public IList<AzureTenant> ListAccountTenants(IAccessToken accessToken, IAzureEnvironment environment)
        {
            List<AzureTenant> result = new List<AzureTenant>();

            SubscriptionClient subscriptionClient = null;
            try
            {
                subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                    environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                    new RenewingTokenCredential(accessToken),
                    AzureSession.Instance.ClientFactory.GetCustomHandlers());

                var tenants = new GenericPageEnumerable<TenantIdDescription>(subscriptionClient.Tenants.List, subscriptionClient.Tenants.ListNext, ulong.MaxValue, 0).ToList();
                if (tenants != null)
                {
                    result = new List<AzureTenant>();
                    tenants.ForEach((t) =>
                    {
                        result.Add(t.ToAzureTenant(accessToken));
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

        public IList<AzureSubscription> ListAllSubscriptionsForTenant(IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            using (var subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                new RenewingTokenCredential(accessToken),
                AzureSession.Instance.ClientFactory.GetCustomHandlers()))
            {
                return (subscriptionClient.ListAllSubscriptions()?
                    .Select(s => s.ToAzureSubscription(account, environment, accessToken.TenantId))).ToList() ?? new List<AzureSubscription>();
            }
        }

        public AzureSubscription GetSubscriptionById(string subscriptionId, IAccessToken accessToken, IAzureAccount account, IAzureEnvironment environment)
        {
            using (var subscriptionClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                new RenewingTokenCredential(accessToken),
                AzureSession.Instance.ClientFactory.GetCustomHandlers()))
            {
                var subscription = subscriptionClient.Subscriptions.Get(subscriptionId);
                if (null != subscription)
                {
                    return subscription.ToAzureSubscription(account, environment, accessToken.TenantId);
                }
            }

            return null;
        }

        public string ApiVersion { get; private set; }
    }
}

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

using Microsoft.Azure;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Rest;
using System;
using System.Security;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockTokenAuthenticationFactory : IAuthenticationFactory, IHyakAuthenticationFactory
    {
        public IAccessToken Token { get; set; }

        public Func<IAzureAccount, IAzureEnvironment, string, IAccessToken> TokenProvider { get; set; }

        public MockTokenAuthenticationFactory()
        {
            Token = new MockAccessToken
            {
                UserId = "Test",
                LoginType = LoginType.OrgId,
                AccessToken = "abc"
            };

            TokenProvider = (account, environment, tenant) => Token = new MockAccessToken
            {
                UserId = account.Id,
                LoginType = LoginType.OrgId,
                AccessToken = Token.AccessToken,
                TenantId = tenant
            };
        }

        public MockTokenAuthenticationFactory(string userId, string accessToken)
        {
            Token = new MockAccessToken
            {
                UserId = userId,
                LoginType = LoginType.OrgId,
                AccessToken = accessToken,
            };

            TokenProvider = ((account, environment, tenant) => Token);
        }

        public MockTokenAuthenticationFactory(string userId, string accessToken, string tenantId)
        {
            Token = new MockAccessToken
            {
                UserId = userId,
                LoginType = LoginType.OrgId,
                AccessToken = accessToken,
                TenantId = tenantId
            };

            TokenProvider = ((account, environment, tenant) => Token);
        }


        public IAccessToken Authenticate(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptActionr,
            IAzureTokenCache tokenCache,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            if (account.Id == null)
            {
                account.Id = "test";
            }

            if (TokenProvider == null)
            {
                return new MockAccessToken()
                {
                    AccessToken = account.Id,
                    LoginType = LoginType.OrgId,
                    UserId = account.Id
                };
            }
            else
            {
                return TokenProvider(account, environment as AzureEnvironment, tenant);
            }
        }

        public IAccessToken Authenticate(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            return Authenticate(account, environment, tenant, password, promptBehavior, promptAction, AzureSession.Instance.TokenCache, resourceId);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context)
        {
            return new AccessTokenCredential(context.Subscription.GetId(), Token);
        }

        public Microsoft.Rest.ServiceClientCredentials GetServiceClientCredentials(IAzureContext context)
        {
            return new Microsoft.Rest.TokenCredentials(Token.AccessToken);
        }


        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context, string targetEndpoint)
        {
            return new AccessTokenCredential(context.Subscription.GetId(), Token);
        }


        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint)
        {
            return new Microsoft.Rest.TokenCredentials(Token.AccessToken);
        }

        public Rest.ServiceClientCredentials GetServiceClientCredentials(string accessToken, Func<string> renew = null)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache)
        {
            throw new NotImplementedException();
        }
    }
}

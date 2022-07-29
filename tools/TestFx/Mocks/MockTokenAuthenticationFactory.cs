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

using Azure.Core;
using Hyak.Common;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Identity.Client;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.TestFx.Mocks
{
    public class MockTokenAuthenticationFactory : IAuthenticationFactory, IHyakAuthenticationFactory
    {
        public IAccessToken Token { get; set; }

        public Func<IAzureAccount, IAzureEnvironment, string, IAccessToken> TokenProvider { get; set; }

        public MockTokenAuthenticationFactory()
        {
            Token = new MockAccessToken
            {
                UserId = "MockUser",
                LoginType = LoginType.OrgId,
                AccessToken = "MockAccessToken"
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

            TokenProvider = (account, environment, tenant) => Token;
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

            TokenProvider = (account, environment, tenant) => Token;
        }

        public IAccessToken Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Action<string> promptAction, IAzureTokenCache tokenCache, string resourceId = "ActiveDirectoryServiceEndpointResourceId")
        {
            if (account.Id == null)
            {
                account.Id = "MockAccount";
            }

            if (TokenProvider == null)
            {
                return new MockAccessToken()
                {
                    UserId = account.Id,
                    LoginType = LoginType.OrgId,
                    AccessToken = account.Id
                };
            }
            else
            {
                return TokenProvider(account, environment as AzureEnvironment, tenant);
            }
        }

        public IAccessToken Authenticate(IAzureAccount account, IAzureEnvironment environment, string tenant, SecureString password, string promptBehavior, Action<string> promptAction, string resourceId = "ActiveDirectoryServiceEndpointResourceId")
        {
            return Authenticate(account, environment, tenant, password, promptBehavior, promptAction, AzureSession.Instance.TokenCache, resourceId);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context)
        {
            return new TokenCredentials(Token.AccessToken);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint)
        {
            return new TokenCredentials(Token.AccessToken);
        }

        public ServiceClientCredentials GetServiceClientCredentials(string accessToken, Func<string> renew = null)
        {
            throw new NotImplementedException();
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context)
        {
            return new AccessTokenCredential(context.Subscription.GetId(), Token);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context, string targetEndpoint)
        {
            return new AccessTokenCredential(context.Subscription.GetId(), Token);
        }

        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache)
        {
            throw new NotImplementedException();
        }

        public TokenCredential GetTokenCredential(IAzureContext context)
        {
            return new AzureTokenCredential(Token.AccessToken);
        }

        public TokenCredential GetTokenCredential(IAzureContext context, string targetEndpoint)
        {
            return new AzureTokenCredential(Token.AccessToken);
        }

        public TokenCredential GetTokenCredential(string accessToken, Func<string> renew = null)
        {
            return new AzureTokenCredential(accessToken, renew);
        }
    }
}
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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public static class SharedTokenCacheClientFactory
    {
        private static readonly string CommonTenant = "organizations";
        private static readonly string PowerShellClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
        private static readonly string CacheFileName = "msal.cache";
        private static readonly string CacheFilePath =
            Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService", CacheFileName);

        private static ITokenCache _tokenCache;

        private static MsalCacheHelper InitializeCacheHelper(string clientId)
        {
            var builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), clientId);
            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));
            var storageCreationProperties = builder.Build();
            return MsalCacheHelper.CreateAsync(storageCreationProperties).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static IPublicClientApplication CreatePublicClient(
            string clientId = null,
            string tenantId = null,
            string authority = null,
            string redirectUri = null)
        {
            clientId = clientId ?? PowerShellClientId;
            var builder = PublicClientApplicationBuilder.Create(clientId);
            if (!string.IsNullOrEmpty(authority))
            {
                builder = builder.WithAuthority(authority);
            }

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder = builder.WithTenantId(tenantId);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            var client = builder.Build();
            var cacheHelper = InitializeCacheHelper(clientId);
            cacheHelper.RegisterCache(client.UserTokenCache);
            return client;
        }

        public static IConfidentialClientApplication CreateConfidentialClient(
            string clientId = null,
            string authority = null,
            string redirectUri = null,
            X509Certificate2 certificate = null,
            SecureString clientSecret = null)
        {
            clientId = clientId ?? PowerShellClientId;
            var builder = ConfidentialClientApplicationBuilder.Create(clientId);
            if (!string.IsNullOrEmpty(authority))
            {
                builder = builder.WithAuthority(authority);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            if (certificate != null)
            {
                builder = builder.WithCertificate(certificate);
            }

            if (clientSecret != null)
            {
                builder = builder.WithClientSecret(ConversionUtilities.SecureStringToString(clientSecret));
            }

            var client = builder.Build();
            var cacheHelper = InitializeCacheHelper(clientId);
            cacheHelper.RegisterCache(client.UserTokenCache);
            return client;
        }

        public static ITokenCache GetTokenCache()
        {
            if (_tokenCache == null)
            {
                var client = CreatePublicClient();
                _tokenCache = client.UserTokenCache;
            }

            return _tokenCache;
        }

        public static bool TryRemoveAccount(string accountId)
        {
            var client = CreatePublicClient();
            var account = client.GetAccountsAsync()
                            .ConfigureAwait(false).GetAwaiter().GetResult()
                            .FirstOrDefault(a => string.Equals(a.Username, accountId, StringComparison.OrdinalIgnoreCase));
            if (account == null)
            {
                return false;
            }

            try
            {
                client.RemoveAsync(account)
                    .ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
                return false;
            }

            return true;
        }
        
        public static IEnumerable<IAccount> GetAccounts()
        {
            return CreatePublicClient()
                    .GetAccountsAsync()
                    .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static void ClearCache()
        {
            var cacheHelper = InitializeCacheHelper(PowerShellClientId);
            cacheHelper.Clear();
        }

        public static List<IAccessToken> GetTenantTokensForAccount(IAccount account, Action<string> promptAction)
        {
            List<IAccessToken> result = new List<IAccessToken>();
            var azureAccount = new AzureAccount()
            {
                Id = account.Username,
                Type = AzureAccount.AccountType.User
            };
            var environment = AzureEnvironment.PublicEnvironments
                                .Where(e => e.Value.ActiveDirectoryAuthority.Contains(account.Environment))
                                .Select(e => e.Value)
                                .FirstOrDefault();
            var commonToken = AzureSession.Instance.AuthenticationFactory.Authenticate(azureAccount, environment, CommonTenant, null, null, promptAction);
            IEnumerable<string> tenants = Enumerable.Empty<string>();
            using (SubscriptionClient subscriptionClient = GetSubscriptionClient(commonToken, environment))
            {
                tenants = subscriptionClient.Tenants.List().Select(t => t.TenantId);
            }

            foreach (var tenant in tenants)
            {
                try
                {
                    var token = AzureSession.Instance.AuthenticationFactory.Authenticate(azureAccount, environment, tenant, null, null, promptAction);
                    if (token != null)
                    {
                        result.Add(token);
                    }
                }
                catch
                {
                    promptAction($"Unable to acquire token for tenant '{tenant}'.");
                }
            }

            return result;
        }

        public static List<IAzureSubscription> GetSubscriptionsFromTenantToken(IAccount account, IAccessToken token, Action<string> promptAction)
        {
            List<IAzureSubscription> result = new List<IAzureSubscription>();
            var azureAccount = new AzureAccount()
            {
                Id = account.Username,
                Type = AzureAccount.AccountType.User
            };
            var environment = AzureEnvironment.PublicEnvironments
                                .Where(e => e.Value.ActiveDirectoryAuthority.Contains(account.Environment))
                                .Select(e => e.Value)
                                .FirstOrDefault();
            using (SubscriptionClient subscriptionClient = GetSubscriptionClient(token, environment))
            {
                var subscriptions = (subscriptionClient.ListAllSubscriptions().ToList() ?? new List<Subscription>())
                                      .Where(s => "enabled".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase) ||
                                                   "warned".Equals(s.State.ToString(), StringComparison.OrdinalIgnoreCase));
                foreach (var subscription in subscriptions)
                {
                    var azureSubscription = new AzureSubscription();
                    azureSubscription.SetAccount(azureAccount.Id);
                    azureSubscription.SetEnvironment(environment.Name);
                    azureSubscription.Id = subscription?.SubscriptionId;
                    azureSubscription.Name = subscription?.DisplayName;
                    azureSubscription.State = subscription?.State.ToString();
                    azureSubscription.SetProperty(AzureSubscription.Property.Tenants, token.TenantId);
                    result.Add(azureSubscription);
                }
            }

            return result;
        }

        private static SubscriptionClient GetSubscriptionClient(IAccessToken token, AzureEnvironment environment)
        {
            return AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                new TokenCredentials(token.AccessToken) as ServiceClientCredentials,
                AzureSession.Instance.ClientFactory.GetCustomHandlers());
        }
    }
}

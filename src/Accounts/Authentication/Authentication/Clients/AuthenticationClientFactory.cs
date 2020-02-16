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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication.Clients
{
    public abstract class AuthenticationClientFactory
    {
        public static readonly string AuthenticationClientFactoryKey = nameof(AuthenticationClientFactory);
        protected readonly string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
        private static readonly string CommonTenant = "organizations";
        private static readonly object _lock = new object();

        public byte[] TokenCacheData { get; set; }

        protected AuthenticationClientFactory(string cacheFilePath = null)
        {
        }

        public virtual byte[] ReadTokenData()
        {
            return TokenCacheData;
        }

        public virtual void WriteTokenData(byte[] data)
        {
        }

        public abstract void RegisterCache(IClientApplicationBase client);

        public abstract void ClearCache();

        public IPublicClientApplication CreatePublicClient(
            string clientId = null,
            string tenantId = null,
            string authority = null,
            string redirectUri = null,
            bool useAdfs = false)
        {
            clientId = clientId ?? PowerShellClientId;
            var builder = PublicClientApplicationBuilder.Create(clientId);
            if (!string.IsNullOrEmpty(authority))
            {
                if (!useAdfs)
                {
                    builder = builder.WithAuthority(authority);
                }
                else
                {
                    builder = builder.WithAdfsAuthority(authority);
                }
            }

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder = builder.WithTenantId(tenantId);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            builder.WithLogging((level, message, pii) =>
            {
                TracingAdapter.Information(string.Format("[MSAL] {0}: {1}", level, message));
            });

            var client = builder.Build();
            RegisterCache(client);
            return client;
        }

        public IConfidentialClientApplication CreateConfidentialClient(
            string clientId = null,
            string authority = null,
            string redirectUri = null,
            X509Certificate2 certificate = null,
            SecureString clientSecret = null,
            bool useAdfs = false)
        {
            clientId = clientId ?? PowerShellClientId;
            var builder = ConfidentialClientApplicationBuilder.Create(clientId);
            if (!string.IsNullOrEmpty(authority))
            {
                if (!useAdfs)
                {
                    builder = builder.WithAuthority(authority);
                }
                else
                {
                    builder = builder.WithAdfsAuthority(authority);
                }
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

            builder.WithLogging((level, message, pii) =>
            {
                TracingAdapter.Information(string.Format("[MSAL] {0}: {1}", level, message));
            });

            var client = builder.Build();
            RegisterCache(client);
            return client;
        }

        public bool TryRemoveAccount(string accountId)
        {
            TracingAdapter.Information(string.Format("[AuthenticationClientFactory] Calling GetAccountsAsync"));
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
                TracingAdapter.Information(string.Format("[AuthenticationClientFactory] Calling RemoveAsync - Account: '{0}'", account.Username));
                client.RemoveAsync(account)
                    .ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<IAccount> ListAccounts(string authority = null)
        {
            TracingAdapter.Information(string.Format("[AuthenticationClientFactory] Calling GetAccountsAsync on {0}", authority ?? "AzureCloud"));
            
            return CreatePublicClient(authority: authority)
                    .GetAccountsAsync()
                    .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public List<IAccessToken> GetTenantTokensForAccount(IAccount account, IAzureEnvironment environment, Action<string> promptAction)
        {
            TracingAdapter.Information(string.Format("[AuthenticationClientFactory] Attempting to acquire tenant tokens for account '{0}'.", account.Username));
            List<IAccessToken> result = new List<IAccessToken>();
            var azureAccount = new AzureAccount()
            {
                Id = account.Username,
                Type = AzureAccount.AccountType.User
            };
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

        public List<IAzureSubscription> GetSubscriptionsFromTenantToken(IAccount account, IAzureEnvironment environment, IAccessToken token, Action<string> promptAction)
        {
            TracingAdapter.Information(string.Format("[AuthenticationClientFactory] Attempting to acquire subscriptions in tenant '{0}' for account '{1}'.", token.TenantId, account.Username));
            List<IAzureSubscription> result = new List<IAzureSubscription>();
            var azureAccount = new AzureAccount()
            {
                Id = account.Username,
                Type = AzureAccount.AccountType.User
            };
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

        private SubscriptionClient GetSubscriptionClient(IAccessToken token, IAzureEnvironment environment)
        {
            return AzureSession.Instance.ClientFactory.CreateCustomArmClient<SubscriptionClient>(
                environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                new TokenCredentials(token.AccessToken) as ServiceClientCredentials,
                AzureSession.Instance.ClientFactory.GetCustomHandlers());
        }

        protected bool TryReadTokenFromFileCache(string cacheFilePath)
        {
            bool result = false;
            lock (_lock)
            {
                try
                {
                    var cacheStorage = GetCacheStorage(cacheFilePath);
                    byte[] data = cacheStorage.ReadData();
                    TokenCacheData = data;
                    result = true;
                }
                catch { }
            }
            return result;
        }

        protected void WriteTokenToFileCache(byte[] data, string cacheFilePath)
        {
            lock (_lock)
            {
                var cacheStorage = GetCacheStorage(cacheFilePath);
                cacheStorage.WriteData(data);
            }
        }

        private MsalCacheStorage GetCacheStorage(string filePath)
        {
            var builder = new StorageCreationPropertiesBuilder(Path.GetFileName(filePath), Path.GetDirectoryName(filePath), PowerShellClientId);
            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));
            var storageCreationProperties = builder.Build();
            return new MsalCacheStorage(storageCreationProperties, new TraceSource("Azure PowerShell"));
        }
    }
}

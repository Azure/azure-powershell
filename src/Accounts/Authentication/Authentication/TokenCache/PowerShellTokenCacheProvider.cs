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

using System;
using System.Collections.Generic;
using System.Linq;

using Azure.Identity;

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Extensions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Internal.Subscriptions.Models;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public abstract class PowerShellTokenCacheProvider
    {
        public const string PowerShellTokenCacheProviderKey = "PowerShellTokenCacheProviderKey";
        //Reanme CommonTenant to OrganizationTenant with reference to
        //https://learn.microsoft.com/en-us/dotnet/api/microsoft.identity.client.abstractapplicationbuilder-1.withauthority?view=msal-dotnet-latest#microsoft-identity-client-abstractapplicationbuilder-1-withauthority(system-string-system-boolean
        //From MSAL, we shall always use "organizations" for both work and school and MSA accounts
        private const string organizationTenant = "organizations";

        protected byte[] _tokenCacheDataToFlush;

        public abstract byte[] ReadTokenData();

        public void UpdateTokenDataWithoutFlush(byte[] data)
        {
            _tokenCacheDataToFlush = data;
        }

        public virtual void FlushTokenData()
        {
            _tokenCacheDataToFlush = null;
        }

        public virtual void ClearCache()
        {
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
            TracingAdapter.Information(string.Format("[PowerShellTokenCacheProvider] Calling GetAccountsAsync on {0}", authority ?? "AzureCloud"));

            return CreatePublicClient(authority: authority)
                    .GetAccountsAsync()
                    .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public List<IAccessToken> GetTenantTokensForAccount(IAccount account, IAzureEnvironment environment, Action<string> promptAction, ICmdletContext cmdletContext)
        {
            TracingAdapter.Information(string.Format("[AuthenticationClientFactory] Attempting to acquire tenant tokens for account '{0}'.", account.Username));
            List<IAccessToken> result = new List<IAccessToken>();
            var azureAccount = new AzureAccount()
            {
                Id = account.Username,
                Type = AzureAccount.AccountType.User
            };

            var commonToken = AzureSession.Instance.AuthenticationFactory.Authenticate(azureAccount, environment, organizationTenant, null, null, promptAction, cmdletContext.ToExtensibleParameters());
            IEnumerable<string> tenants = Enumerable.Empty<string>();
            using (SubscriptionClient subscriptionClient = GetSubscriptionClient(commonToken, environment))
            {
                tenants = subscriptionClient.Tenants.List().Select(t => t.TenantId);
            }

            foreach (var tenant in tenants)
            {
                try
                {
                    var token = AzureSession.Instance.AuthenticationFactory.Authenticate(azureAccount, environment, tenant, null, null, promptAction, cmdletContext.ToExtensibleParameters());
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
                new RenewingTokenCredential(token),
                AzureSession.Instance.ClientFactory.GetCustomHandlers());
        }

        protected abstract void RegisterCache(IPublicClientApplication client);

        /// <summary>
        /// Creates a public client app with tenantId.
        /// This method is not meant for authentication purpose. Use APIs from Azure.Identity instead.
        /// </summary>
        public virtual IPublicClientApplication CreatePublicClient(string authority, string tenantId)
        {
            var builder = PublicClientApplicationBuilder.Create(Constants.PowerShellClientId);
            if (AzConfigReader.IsWamEnabled(authority))
            {
                builder = builder.WithBroker(new BrokerOptions(BrokerOptions.OperatingSystems.Windows));
            }
            if (!string.IsNullOrEmpty(authority))
            {
                builder.WithAuthority(authority, tenantId ?? organizationTenant);
            }
            var client = builder.Build();
            RegisterCache(client);
            return client;
        }
        /// <summary>
        /// Creates a public client app.
        /// This method is not meant for authentication purpose. Use APIs from Azure.Identity instead.
        /// </summary>
        public virtual IPublicClientApplication CreatePublicClient(string authority = null)
        {
            var builder = PublicClientApplicationBuilder.Create(Constants.PowerShellClientId);
            if (AzConfigReader.IsWamEnabled(authority))
            {
                builder = builder.WithBroker(new BrokerOptions(BrokerOptions.OperatingSystems.Windows));
            }
            if (!string.IsNullOrEmpty(authority))
            {
                builder.WithAuthority(authority);
            }
            var client = builder.Build();
            RegisterCache(client);
            return client;
        }

        public abstract TokenCachePersistenceOptions GetTokenCachePersistenceOptions();

    }
}

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
using Microsoft.Identity.Client;
using Microsoft.Rest;
using System;
using System.Linq;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Internal.Subscriptions;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string AppServiceManagedIdentityFlag = "AppServiceManagedIdentityFlag";

        public const string CommonAdTenant = "organizations",
            DefaultMSILoginUri = "http://169.254.169.254/metadata/identity/oauth2/token",
            DefaultBackupMSILoginUri = "http://localhost:50342/oauth2/token";

        public AuthenticationFactory()
        {
            _getKeyStore = () =>
            {
                IServicePrincipalKeyStore keyStore = null;
                if (!AzureSession.Instance.TryGetComponent(ServicePrincipalKeyStore.Name, out keyStore))
                {
                    keyStore = new ServicePrincipalKeyStore();
                }

                return keyStore;
            };

            _getAuthenticator = () =>
            {
                IAuthenticatorBuilder builder = null;
                if (!AzureSession.Instance.TryGetComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, out builder))
                {
                    builder = new AuthenticatorBuilder();
                }

                return builder;
            };

            TokenProvider = new AdalTokenProvider(_getKeyStore);
        }

        private Func<IServicePrincipalKeyStore> _getKeyStore;
        private IServicePrincipalKeyStore _keyStore;
        public IServicePrincipalKeyStore KeyStore
        {
            get
            {
                if (_keyStore == null)
                {
                    _keyStore = _getKeyStore();
                }

                return _keyStore;
            }
            set
            {
                _keyStore = value;
            }
        }

        private Func<IAuthenticatorBuilder> _getAuthenticator;
        internal IAuthenticatorBuilder Builder => _getAuthenticator();

        public ITokenProvider TokenProvider { get; set; }

        public IAccessToken Authenticate(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            IAzureTokenCache tokenCache,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            IAccessToken token = null;
            var cache = tokenCache.GetUserCache() as TokenCache;
            if (cache == null)
            {
                cache = new TokenCache();
            }

            Task<IAccessToken> authToken;
            var processAuthenticator = Builder.Authenticator;
            while (processAuthenticator != null && processAuthenticator.TryAuthenticate(GetAuthenticationParameters(account, environment, tenant, password, promptBehavior, promptAction, tokenCache, resourceId), out authToken))
            {
                token = authToken?.ConfigureAwait(false).GetAwaiter().GetResult();
                if (token != null)
                {
                    account.Id = token.UserId;
                    break;
                }

                processAuthenticator = processAuthenticator.Next;
            }

            return token;
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
            return Authenticate(
                account,
                environment,
                tenant, password,
                promptBehavior,
                promptAction,
                AzureSession.Instance.TokenCache,
                resourceId);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context)
        {
            return GetSubscriptionCloudCredentials(context, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context, string targetEndpoint)
        {
            if (context.Subscription == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidDefaultSubscription
                    : Resources.NoSubscriptionInContext;
                throw new ApplicationException(exceptionMessage);
            }

            if (context.Account == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.AccountNotFound
                    : Resources.ArmAccountNotFound;
                throw new ArgumentException(exceptionMessage);
            }

            switch (context.Account.Type)
            {
                case AzureAccount.AccountType.Certificate:
                    var certificate = AzureSession.Instance.DataStore.GetCertificate(context.Account.Id);
                    return new CertificateCloudCredentials(context.Subscription.Id.ToString(), certificate);
                case AzureAccount.AccountType.AccessToken:
                    return new TokenCloudCredentials(context.Subscription.Id.ToString(), GetEndpointToken(context.Account, targetEndpoint));
            }

            string tenant = null;
            if (context.Subscription != null && context.Account != null)
            {
                tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                      .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                      .FirstOrDefault();
            }

            if (tenant == null && context.Tenant != null && new Guid(context.Tenant.Id) != Guid.Empty)
            {
                tenant = context.Tenant.Id.ToString();
            }

            if (tenant == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.TenantNotFound
                    : Resources.NoTenantInContext;
                throw new ArgumentException(exceptionMessage);
            }

            try
            {
                var tokenCache = AzureSession.Instance.TokenCache;
                TracingAdapter.Information(
                    Resources.UPNAuthenticationTrace,
                    context.Account.Id,
                    context.Environment.Name,
                    tenant);
                if (context.TokenCache != null && context.TokenCache.CacheData != null && context.TokenCache.CacheData.Length > 0)
                {
                    tokenCache = context.TokenCache;
                }

                var token = Authenticate(
                                context.Account,
                                context.Environment,
                                tenant,
                                null,
                                ShowDialog.Never,
                                null,
                                tokenCache,
                                context.Environment.GetTokenAudience(targetEndpoint));


                TracingAdapter.Information(
                    Resources.UPNAuthenticationTokenTrace,
                    token.LoginType,
                    token.TenantId,
                    token.UserId);

                return new AccessTokenCredential(context.Subscription.GetId(), token);
            }
            catch (Exception ex)
            {
                TracingAdapter.Information(Resources.AdalAuthException, ex.Message);
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidSubscriptionState
                    : Resources.InvalidArmContext;
                throw new ArgumentException(exceptionMessage, ex);
            }
        }


        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context)
        {
            return GetServiceClientCredentials(context,
                AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint)
        {
            if (context.Account == null)
            {
                throw new ArgumentException(Resources.ArmAccountNotFound);
            }
            switch (context.Account.Type)
            {
                case AzureAccount.AccountType.Certificate:
                    throw new NotSupportedException(AzureAccount.AccountType.Certificate.ToString());
                case AzureAccount.AccountType.AccessToken:
                    return new TokenCredentials(GetEndpointToken(context.Account, targetEndpoint));
            }


            string tenant = null;

            if (context.Subscription != null && context.Account != null)
            {
                tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                      .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                      .FirstOrDefault();
            }

            if (tenant == null && context.Tenant != null && new Guid(context.Tenant.Id) != Guid.Empty)
            {
                tenant = context.Tenant.Id.ToString();
            }

            if (tenant == null)
            {
                throw new ArgumentException(Resources.NoTenantInContext);
            }

            try
            {
                TracingAdapter.Information(Resources.UPNAuthenticationTrace,
                    context.Account.Id, context.Environment.Name, tenant);

                // TODO: When we will refactor the code, need to add tracing
                /*TracingAdapter.Information(Resources.UPNAuthenticationTokenTrace,
                    token.LoginType, token.TenantId, token.UserId);*/

                var tokenCache = AzureSession.Instance.TokenCache;

                if (context.TokenCache != null)
                {
                    tokenCache = context.TokenCache;
                }

                ServiceClientCredentials result = null;
                switch (context.Account.Type)
                {
                    case AzureAccount.AccountType.ManagedService:
                        result = new RenewingTokenCredential(
                            GetManagedServiceToken(
                                context.Account,
                                context.Environment,
                                tenant,
                                context.Environment.GetTokenAudience(targetEndpoint)));
                        break;
                    case AzureAccount.AccountType.User:
                    case AzureAccount.AccountType.ServicePrincipal:
                        result = new RenewingTokenCredential(Authenticate(context.Account, context.Environment, tenant, null, ShowDialog.Never, null, context.Environment.GetTokenAudience(targetEndpoint)));
                        break;
                    default:
                        throw new NotSupportedException(context.Account.Type.ToString());
                }

                return result;
            }
            catch (Exception ex)
            {
                TracingAdapter.Information(Resources.AdalAuthException, ex.Message);
                throw new ArgumentException(Resources.InvalidArmContext, ex);
            }
        }

        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache)
        {
            TokenCache cache = tokenCache.GetUserCache() as TokenCache;
            if (cache != null && account != null && !string.IsNullOrEmpty(account.Id) && !string.IsNullOrWhiteSpace(account.Type))
            {
                switch (account.Type)
                {
                    case AzureAccount.AccountType.AccessToken:
                        account.SetProperty(AzureAccount.Property.AccessToken, null);
                        account.SetProperty(AzureAccount.Property.GraphAccessToken, null);
                        account.SetProperty(AzureAccount.Property.KeyVaultAccessToken, null);
                        break;
                    case AzureAccount.AccountType.ManagedService:
                        account.SetProperty(AzureAccount.Property.MSILoginUri, null);
                        break;
                    case AzureAccount.AccountType.ServicePrincipal:
                        try
                        {
                            KeyStore.DeleteKey(account.Id, account.GetTenants().FirstOrDefault());
                        }
                        catch
                        {
                            // make best effort to remove credentials
                        }

                        RemoveFromTokenCache(cache, account);
                        break;
                    case AzureAccount.AccountType.User:
                        RemoveFromTokenCache(cache, account);
                        break;
                }
            }
        }

        private IAccessToken GetManagedServiceToken(IAzureAccount account, IAzureEnvironment environment, string tenant, string resourceId)
        {
            if (environment == null)
            {
                throw new InvalidOperationException("Environment is required for MSI Login");
            }

            if (!account.IsPropertySet(AzureAccount.Property.MSILoginUri))
            {
                account.SetProperty(AzureAccount.Property.MSILoginUri, DefaultMSILoginUri);
            }

            if (!account.IsPropertySet(AzureAccount.Property.MSILoginUriBackup))
            {
                account.SetProperty(AzureAccount.Property.MSILoginUriBackup, DefaultBackupMSILoginUri);
            }

            if (string.IsNullOrWhiteSpace(tenant))
            {
                tenant = environment.AdTenant ?? CommonAdTenant;
            }

            if (account.IsPropertySet(AuthenticationFactory.AppServiceManagedIdentityFlag))
            {
                return new ManagedServiceAppServiceAccessToken(account, environment, tenant);
            }

            return new ManagedServiceAccessToken(account, environment, GetResourceId(resourceId, environment), tenant);
        }

        private string GetResourceId(string resourceIdorEndpointName, IAzureEnvironment environment)
        {
            return environment.GetEndpoint(resourceIdorEndpointName) ?? resourceIdorEndpointName;
        }

        private AdalConfiguration GetAdalConfiguration(IAzureEnvironment environment, string tenantId,
            string resourceId, TokenCache tokenCache)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            var adEndpoint = environment.ActiveDirectoryAuthority;
            if (null == adEndpoint)
            {
                throw new ArgumentOutOfRangeException(
                    "environment",
                    string.Format("No Active Directory endpoint specified for environment '{0}'", environment.Name));
            }

            var audience = environment.GetEndpoint(resourceId) ?? resourceId;
            if (string.IsNullOrWhiteSpace(audience))
            {
                string message = Resources.InvalidManagementTokenAudience;
                if (resourceId == AzureEnvironment.Endpoint.GraphEndpointResourceId)
                {
                    message = Resources.InvalidGraphTokenAudience;
                }

                throw new ArgumentOutOfRangeException("environment", string.Format(message, environment.Name));
            }

            return new AdalConfiguration
            {
                AdEndpoint = adEndpoint.ToString(),
                ResourceClientUri = audience,
                AdDomain = tenantId,
                ValidateAuthority = !environment.OnPremise,
                TokenCache = tokenCache
            };
        }

        private string GetEndpointToken(IAzureAccount account, string targetEndpoint)
        {
            string tokenKey = AzureAccount.Property.AccessToken;
            if (targetEndpoint == AzureEnvironment.Endpoint.Graph)
            {
                tokenKey = AzureAccount.Property.GraphAccessToken;
            }

            return account.GetProperty(tokenKey);
        }

        private void RemoveFromTokenCache(TokenCache cache, IAzureAccount account)
        {
            var publicClient = SharedTokenCacheClientFactory.CreatePublicClient();
            var tokenAccounts = publicClient.GetAccountsAsync()
                            .ConfigureAwait(false).GetAwaiter().GetResult()
                            .Where(a => MatchCacheItem(account, a));
            foreach (var tokenAccount in tokenAccounts)
            {
                publicClient.RemoveAsync(tokenAccount)
                                .ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }

        private bool MatchCacheItem(IAzureAccount account, IAccount tokenAccount)
        {
            bool result = false;
            if (account != null && !string.IsNullOrWhiteSpace(account.Type) && tokenAccount != null)
            {
                switch (account.Type)
                {
                    case AzureAccount.AccountType.ServicePrincipal:
                        result = string.Equals(account.Id, tokenAccount.Username, StringComparison.OrdinalIgnoreCase);
                        break;
                    case AzureAccount.AccountType.User:
                        result = string.Equals(account.Id, tokenAccount.Username, StringComparison.OrdinalIgnoreCase)
                            || (account.TenantMap != null && account.TenantMap.Any(
                                (m) => string.Equals(m.Key, tokenAccount.HomeAccountId.TenantId, StringComparison.OrdinalIgnoreCase)
                                       && string.Equals(m.Value, tokenAccount.HomeAccountId.Identifier, StringComparison.OrdinalIgnoreCase)));
                        break;
                }
            }

            return result;
        }

        private AuthenticationParameters GetAuthenticationParameters(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            IAzureTokenCache tokenCache,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            if (account.Type == AzureAccount.AccountType.User)
            {
                if (password == null)
                {
                    if (!string.IsNullOrEmpty(account.Id))
                    {
                        return new SilentParameters(environment, tokenCache, tenant, resourceId, account.Id);
                    }
                    else if (account.IsPropertySet("UseDeviceAuth"))
                    {
                        return new DeviceCodeParameters(environment, tokenCache, tenant, resourceId);
                    }

                    return new InteractiveParameters(environment, tokenCache, tenant, resourceId, promptAction);
                }

                return new UsernamePasswordParameters(environment, tokenCache, tenant, resourceId, account.Id, password);
            }
            else if (account.Type == AzureAccount.AccountType.ServicePrincipal ||
                     account.Type == AzureAccount.AccountType.Certificate)
            {
                return new ServicePrincipalParameters(environment, tokenCache, tenant, resourceId, account.Id, account.GetProperty(AzureAccount.Property.CertificateThumbprint), password);
            }

            return null;
        }
    }
}

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

<<<<<<< HEAD
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using System;
using System.Linq;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using System.Threading.Tasks;

=======
using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

using Hyak.Common;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Identity.Client;
using Microsoft.Rest;

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string AppServiceManagedIdentityFlag = "AppServiceManagedIdentityFlag";

<<<<<<< HEAD
        public const string CommonAdTenant = "Common",
=======
        public const string CommonAdTenant = "organizations",
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD

            TokenProvider = new AdalTokenProvider(_getKeyStore);
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD

=======
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="environment"></param>
        /// <param name="tenant"></param>
        /// <param name="password"></param>
        /// <param name="promptBehavior"></param>
        /// <param name="promptAction"></param>
        /// <param name="tokenCache"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            IAccessToken token;
            var cache = tokenCache as TokenCache;
            if (cache == null)
            {
                cache = TokenCache.DefaultShared;
            }

            Task<IAccessToken> authToken;
            if (Builder.Authenticator.TryAuthenticate(account, environment, tenant, password, promptBehavior, Task.FromResult(promptAction), tokenCache, resourceId, out authToken))
            {
                return authToken.ConfigureAwait(false).GetAwaiter().GetResult();
            }

            var configuration = GetAdalConfiguration(environment, tenant, resourceId, cache);

            TracingAdapter.Information(
                Resources.AdalAuthConfigurationTrace,
                configuration.AdDomain,
                configuration.AdEndpoint,
                configuration.ClientId,
                configuration.ClientRedirectUri,
                configuration.ResourceClientUri,
                configuration.ValidateAuthority);
            if (account != null && account.Type == AzureAccount.AccountType.ManagedService)
            {
                token = GetManagedServiceToken(account, environment, tenant, resourceId);
            }
            else if (account != null && environment != null
                && account.Type == AzureAccount.AccountType.AccessToken)
            {
                var rawToken = new RawAccessToken
                {
                    TenantId = tenant,
                    UserId = account.Id,
                    LoginType = AzureAccount.AccountType.AccessToken
                };

                if ((string.Equals(resourceId, environment.AzureKeyVaultServiceEndpointResourceId, StringComparison.OrdinalIgnoreCase)
                     || string.Equals(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, resourceId, StringComparison.OrdinalIgnoreCase))
                     && account.IsPropertySet(AzureAccount.Property.KeyVaultAccessToken))
                {
                    rawToken.AccessToken = account.GetProperty(AzureAccount.Property.KeyVaultAccessToken);
                }
                else if ((string.Equals(resourceId, environment.GraphEndpointResourceId, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(AzureEnvironment.Endpoint.GraphEndpointResourceId, resourceId, StringComparison.OrdinalIgnoreCase))
                    && account.IsPropertySet(AzureAccount.Property.GraphAccessToken))
                {
                    rawToken.AccessToken = account.GetProperty(AzureAccount.Property.GraphAccessToken);
                }
                else if ((string.Equals(resourceId, environment.ActiveDirectoryServiceEndpointResourceId, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, resourceId, StringComparison.OrdinalIgnoreCase))
                    && account.IsPropertySet(AzureAccount.Property.AccessToken))
                {
                    rawToken.AccessToken = account.GetAccessToken();
                }
                else
                {
                    throw new InvalidOperationException(string.Format(Resources.AccessTokenResourceNotFound, resourceId));
                }

                token = rawToken;
            }
            else if (account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
            {
                var thumbprint = account.GetProperty(AzureAccount.Property.CertificateThumbprint);
                token = TokenProvider.GetAccessTokenWithCertificate(configuration, account.Id, thumbprint, account.Type);
            }
            else
            {
                token = TokenProvider.GetAccessToken(configuration, promptBehavior, promptAction, account.Id, password, account.Type);
            }

            account.Id = token.UserId;
            return token;
        }

=======
            IAccessToken token = null;

            PowerShellTokenCacheProvider tokenCacheProvider;
            if (!AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out tokenCacheProvider))
            {
                throw new NullReferenceException(Resources.AuthenticationClientFactoryNotRegistered);
            }

            Task<IAccessToken> authToken;
            var processAuthenticator = Builder.Authenticator;
            var retries = 5;
            while (retries-- > 0)
            {
                try
                {
                    while (processAuthenticator != null && processAuthenticator.TryAuthenticate(GetAuthenticationParameters(tokenCacheProvider, account, environment, tenant, password, promptBehavior, promptAction, tokenCache, resourceId), out authToken))
                    {
                        token = authToken?.ConfigureAwait(false).GetAwaiter().GetResult();
                        if (token != null)
                        {
                            // token.UserId is null when getting tenant token in ADFS environment
                            account.Id = token.UserId ?? account.Id;
                            if (!string.IsNullOrEmpty(token.HomeAccountId))
                            {
                                account.SetProperty(AzureAccount.Property.HomeAccountId, token.HomeAccountId);
                            }
                            break;
                        }

                        processAuthenticator = processAuthenticator.Next;
                    }
                }
                catch (Exception e)
                {
                    if (!IsTransientException(e) || retries == 0)
                    {
                        throw;
                    }

                    TracingAdapter.Information(string.Format("[AuthenticationFactory] Exception caught when calling TryAuthenticate, retrying authentication - Exception message: '{0}'", e.Message));
                    continue;
                }

                break;
            }

            return token;
        }

        private static bool IsTransientException(Exception e)
        {
            var msalException = e.InnerException as MsalServiceException;
            if(msalException != null)
            {
                return msalException.ErrorCode == MsalError.RequestTimeout ||
                    msalException.ErrorCode == MsalError.ServiceNotAvailable;
            }
            return false;
        }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                AzureSession.Instance.TokenCache,
=======
                null,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                var tokenCache = AzureSession.Instance.TokenCache;
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                TracingAdapter.Information(
                    Resources.UPNAuthenticationTrace,
                    context.Account.Id,
                    context.Environment.Name,
                    tenant);
<<<<<<< HEAD
                if (context.TokenCache != null && context.TokenCache.CacheData != null && context.TokenCache.CacheData.Length > 0)
                {
                    tokenCache = context.TokenCache;
                }
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

                var token = Authenticate(
                                context.Account,
                                context.Environment,
                                tenant,
                                null,
                                ShowDialog.Never,
                                null,
<<<<<<< HEAD
                                tokenCache,
                                context.Environment.GetTokenAudience(targetEndpoint));


=======
                                null,
                                context.Environment.GetTokenAudience(targetEndpoint));

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                throw new ArgumentException(Resources.ArmAccountNotFound);
=======
                throw new AzPSArgumentException(Resources.ArmAccountNotFound, "context.Account", ErrorKind.UserError);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
            switch (context.Account.Type)
            {
                case AzureAccount.AccountType.Certificate:
                    throw new NotSupportedException(AzureAccount.AccountType.Certificate.ToString());
                case AzureAccount.AccountType.AccessToken:
<<<<<<< HEAD
                    return new TokenCredentials(GetEndpointToken(context.Account, targetEndpoint));
=======
                    return new RenewingTokenCredential(new ExternalAccessToken (GetEndpointToken(context.Account, targetEndpoint), () => GetEndpointToken(context.Account, targetEndpoint)));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
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
=======
                IAccessToken token = null;
                switch (context.Account.Type)
                {
                    case AzureAccount.AccountType.ManagedService:
                        token = GetManagedServiceToken(
                                context.Account,
                                context.Environment,
                                tenant,
                            context.Environment.GetTokenAudience(targetEndpoint));
                        break;
                    case AzureAccount.AccountType.User:
                    case AzureAccount.AccountType.ServicePrincipal:
                        token = Authenticate(context.Account, context.Environment, tenant, null, ShowDialog.Never, null, context.Environment.GetTokenAudience(targetEndpoint));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                        break;
                    default:
                        throw new NotSupportedException(context.Account.Type.ToString());
                }

<<<<<<< HEAD
                return result;
=======
                TracingAdapter.Information(Resources.UPNAuthenticationTokenTrace,
                    token.LoginType, token.TenantId, token.UserId);
                return new RenewingTokenCredential(token);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }
            catch (Exception ex)
            {
                TracingAdapter.Information(Resources.AdalAuthException, ex.Message);
                throw new ArgumentException(Resources.InvalidArmContext, ex);
            }
        }

<<<<<<< HEAD
        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache)
        {
            TokenCache cache = tokenCache as TokenCache;
            if (cache != null && account != null && !string.IsNullOrEmpty(account.Id) && !string.IsNullOrWhiteSpace(account.Type))
=======
        public ServiceClientCredentials GetServiceClientCredentials(string accessToken, Func<string> renew = null)
        {
            return new RenewingTokenCredential(new ExternalAccessToken(accessToken, renew));
        }

        /// <summary>
        /// Remove a user from token cache.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="tokenCache">This parameter is no longer used. However to keep the API unchanged it's not removed.</param>
        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache)
        {
            if (account != null && !string.IsNullOrEmpty(account.Id) && !string.IsNullOrWhiteSpace(account.Type))
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
                        RemoveFromTokenCache(cache, account);
                        break;
                    case AzureAccount.AccountType.User:
                        RemoveFromTokenCache(cache, account);
=======
                        RemoveFromTokenCache(account);
                        break;
                    case AzureAccount.AccountType.User:
                        RemoveFromTokenCache(account);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                tenant = environment.AdTenant ?? "Common";
=======
                tenant = environment.AdTenant ?? CommonAdTenant;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            }

            if (account.IsPropertySet(AuthenticationFactory.AppServiceManagedIdentityFlag))
            {
                return new ManagedServiceAppServiceAccessToken(account, environment, GetFunctionsResourceId(resourceId, environment), tenant);
            }

            return new ManagedServiceAccessToken(account, environment, GetResourceId(resourceId, environment), tenant);
        }

        private string GetResourceId(string resourceIdorEndpointName, IAzureEnvironment environment)
        {
            return environment.GetEndpoint(resourceIdorEndpointName) ?? resourceIdorEndpointName;
        }

        private string GetFunctionsResourceId(string resourceIdOrEndpointName, IAzureEnvironment environment)
        {
            var resourceId = environment.GetEndpoint(resourceIdOrEndpointName) ?? resourceIdOrEndpointName;
            if (string.Equals(
                environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId),
                resourceId, StringComparison.OrdinalIgnoreCase))
            {
                resourceId = environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
            }

            return resourceId;
        }

<<<<<<< HEAD
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
            if (cache != null && cache.Count > 0 && account != null && !string.IsNullOrWhiteSpace(account.Id) && !string.IsNullOrWhiteSpace(account.Type))
            {
                var items = cache.ReadItems().Where((i) => MatchCacheItem(account, i));
                foreach (var item in items)
                {
                    cache.DeleteItem(item);
                }
            }
        }

        private bool MatchCacheItem(IAzureAccount account, TokenCacheItem item)
        {
            bool result = false;
            if (account != null && !string.IsNullOrWhiteSpace(account.Type) && item != null)
=======
        private string GetEndpointToken(IAzureAccount account, string targetEndpoint)
        {
            string tokenKey = AzureAccount.Property.AccessToken;
            if (string.Equals(targetEndpoint, AzureEnvironment.Endpoint.Graph, StringComparison.OrdinalIgnoreCase))
            {
                tokenKey = AzureAccount.Property.GraphAccessToken;
            }
            if (string.Equals(targetEndpoint, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, StringComparison.OrdinalIgnoreCase))
            {
                tokenKey = AzureAccount.Property.KeyVaultAccessToken;
            }
            return account.GetProperty(tokenKey);
        }

        private void RemoveFromTokenCache(IAzureAccount account)
        {
            PowerShellTokenCacheProvider tokenCacheProvider;
            if (!AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out tokenCacheProvider))
            {
                throw new NullReferenceException(Resources.AuthenticationClientFactoryNotRegistered);
            }

            var publicClient = tokenCacheProvider.CreatePublicClient();
            var accounts = publicClient.GetAccountsAsync()
                            .ConfigureAwait(false).GetAwaiter().GetResult();
            var tokenAccounts = accounts.Where(a => MatchCacheItem(account, a));
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
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                switch (account.Type)
                {
                    case AzureAccount.AccountType.ServicePrincipal:
<<<<<<< HEAD
                        result = string.Equals(account.Id, item.ClientId, StringComparison.OrdinalIgnoreCase);
                        break;
                    case AzureAccount.AccountType.User:
                        result = string.Equals(account.Id, item.DisplayableId, StringComparison.OrdinalIgnoreCase)
                            || (account.TenantMap != null && account.TenantMap.Any(
                                (m) => string.Equals(m.Key, item.TenantId, StringComparison.OrdinalIgnoreCase)
                                       && string.Equals(m.Value, item.UniqueId, StringComparison.OrdinalIgnoreCase)));
=======
                        result = string.Equals(account.Id, tokenAccount.Username, StringComparison.OrdinalIgnoreCase);
                        break;
                    case AzureAccount.AccountType.User:
                        result = string.Equals(account.Id, tokenAccount.Username, StringComparison.OrdinalIgnoreCase)
                            || (account.TenantMap != null && account.TenantMap.Any(
                                (m) => string.Equals(m.Key, tokenAccount.HomeAccountId.TenantId, StringComparison.OrdinalIgnoreCase)
                                       && string.Equals(m.Value, tokenAccount.HomeAccountId.Identifier, StringComparison.OrdinalIgnoreCase)));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                        break;
                }
            }

            return result;
        }

<<<<<<< HEAD
=======
        private AuthenticationParameters GetAuthenticationParameters(
            PowerShellTokenCacheProvider tokenCacheProvider,
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            IAzureTokenCache tokenCache,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            switch (account.Type)
            {
                case AzureAccount.AccountType.User:
                    if (password == null)
                    {
                        var homeAccountId = account.GetProperty(AzureAccount.Property.HomeAccountId) ?? "";

                        if (!string.IsNullOrEmpty(account.Id))
                        {
                            return new SilentParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, homeAccountId);
                        }

                        if (account.IsPropertySet("UseDeviceAuth"))
                        {
                            return new DeviceCodeParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, homeAccountId);
                        }
                        else if(account.IsPropertySet(AzureAccount.Property.UsePasswordAuth))
                        {
                            return new UsernamePasswordParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, password, homeAccountId);
                        }

                        return new InteractiveParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, homeAccountId, promptAction);
                    }

                    return new UsernamePasswordParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, password, null);
                case AzureAccount.AccountType.Certificate:
                case AzureAccount.AccountType.ServicePrincipal:
                    password = password ?? ConvertToSecureString(account.GetProperty(AzureAccount.Property.ServicePrincipalSecret));
                    return new ServicePrincipalParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, account.GetProperty(AzureAccount.Property.CertificateThumbprint), password);
                case AzureAccount.AccountType.ManagedService:
                    return new ManagedServiceIdentityParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account);
                case AzureAccount.AccountType.AccessToken:
                    return new AccessTokenParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account);
                default:
                    return null;
            }
        }

        internal SecureString ConvertToSecureString(string password)
        {
            if (password == null)
            {
                return null;
            }

            var securePassword = new SecureString();

            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            securePassword.MakeReadOnly();
            return securePassword;
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}

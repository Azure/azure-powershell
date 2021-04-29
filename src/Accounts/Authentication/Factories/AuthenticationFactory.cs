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
                null,
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
                TracingAdapter.Information(
                    Resources.UPNAuthenticationTrace,
                    context.Account.Id,
                    context.Environment.Name,
                    tenant);

                var token = Authenticate(
                                context.Account,
                                context.Environment,
                                tenant,
                                null,
                                ShowDialog.Never,
                                null,
                                null,
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
                throw new AzPSArgumentException(Resources.ArmAccountNotFound, "context.Account", ErrorKind.UserError);
            }
            switch (context.Account.Type)
            {
                case AzureAccount.AccountType.Certificate:
                    throw new NotSupportedException(AzureAccount.AccountType.Certificate.ToString());
                case AzureAccount.AccountType.AccessToken:
                    return new RenewingTokenCredential(new ExternalAccessToken (GetEndpointToken(context.Account, targetEndpoint), () => GetEndpointToken(context.Account, targetEndpoint)));
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
                        break;
                    default:
                        throw new NotSupportedException(context.Account.Type.ToString());
                }

                TracingAdapter.Information(Resources.UPNAuthenticationTokenTrace,
                    token.LoginType, token.TenantId, token.UserId);
                return new RenewingTokenCredential(token);
            }
            catch (Exception ex)
            {
                TracingAdapter.Information(Resources.AdalAuthException, ex.Message);
                throw new ArgumentException(Resources.InvalidArmContext, ex);
            }
        }

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

                        RemoveFromTokenCache(account);
                        break;
                    case AzureAccount.AccountType.User:
                        RemoveFromTokenCache(account);
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
    }
}

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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;
using Microsoft.Azure.Commands.Common.Authentication.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Identity.Client;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string AppServiceManagedIdentityFlag = "AppServiceManagedIdentityFlag";

        public const string CommonAdTenant = "organizations",
            DefaultMSILoginUri = "http://169.254.169.254/metadata/identity/oauth2/token",
            DefaultBackupMSILoginUri = "http://localhost:50342/oauth2/token";

        public const string TokenCacheParameterName = "tokenCache";
        public const string ResourceIdParameterName = "resourceId";
        public const string CmdletContextParameterName = "cmdletContext";
        public const string ClaimsChallengeParameterName = "claimsChallenge";

        public AuthenticationFactory()
        {
            _getKeyStore = () =>
            {
                if (!AzureSession.Instance.TryGetComponent(AzKeyStore.Name, out AzKeyStore keyStore))
                {
                    keyStore = null;
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

        private readonly Func<AzKeyStore> _getKeyStore;
        private AzKeyStore _keyStore;
        public AzKeyStore KeyStore
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
        /// Authenticates an Azure account, service principal, or managed identity against Entra ID and obtains an access token.
        /// </summary>
        /// <param name="account">The Azure account to authenticate.</param>
        /// <param name="environment">The Azure environment to authenticate against.</param>
        /// <param name="tenant">The tenant ID or name to authenticate with.</param>
        /// <param name="password">The password for the account, if applicable.</param>
        /// <param name="promptBehavior">The prompt behavior to use during authentication.</param>
        /// <param name="promptAction">Action to execute when a prompt is required.</param>
        /// <param name="resourceId">The resource identifier to authenticate for.</param>
        /// <returns>An access token for the authenticated principal.</returns>
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

        /// <summary>
        /// Authenticates an Azure account, service principal, or managed identity against Entra ID and obtains an access token.
        /// </summary>
        /// <param name="account">The Azure account to authenticate.</param>
        /// <param name="environment">The Azure environment to authenticate against.</param>
        /// <param name="tenant">The tenant ID or name to authenticate with.</param>
        /// <param name="password">The password for the account, if applicable.</param>
        /// <param name="promptBehavior">The prompt behavior to use during authentication.</param>
        /// <param name="promptAction">Action to execute when a prompt is required.</param>
        /// <param name="tokenCache">The token cache to use for caching authentication results.</param>
        /// <param name="resourceId">The resource identifier to authenticate for.</param>
        /// <returns>An access token for the authenticated principal.</returns>
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
            var optionalParameters = new Dictionary<string, object>()
            {
                { TokenCacheParameterName, tokenCache },
                { ResourceIdParameterName, resourceId }
            };
            return Authenticate(account, environment, tenant, password, promptBehavior, promptAction, optionalParameters);
        }

        /// <summary>
        /// Authenticates an Azure account, service principal, or managed identity against Entra ID and obtains an access token.
        /// This method supports claims challenge for conditional access scenarios and various authentication flows based on account type.
        /// </summary>
        /// <param name="account">The Azure account to authenticate.</param>
        /// <param name="environment">The Azure environment to authenticate against.</param>
        /// <param name="tenant">The tenant ID or name to authenticate with.</param>
        /// <param name="password">The password for the account, if applicable.</param>
        /// <param name="promptBehavior">The prompt behavior to use during authentication.</param>
        /// <param name="promptAction">Action to execute when a prompt is required.</param>
        /// <param name="optionalParameters">Dictionary of optional parameters that may include:
        /// <list type="bullet">
        ///   <item><description>tokenCache (IAzureTokenCache): The token cache to use for caching authentication results.</description></item>
        ///   <item><description>resourceId (string): The resource identifier to authenticate for.</description></item>
        ///   <item><description>claimsChallenge (string): Claims challenge token from a previous authentication attempt requiring additional claims.</description></item>
        ///   <item><description>cmdletContext (ICmdletContext): Context for the cmdlet executing the authentication.</description></item>
        /// </list>
        /// </param>
        /// <returns>An access token for the authenticated principal.</returns>
        public IAccessToken Authenticate(
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            IDictionary<string, object> optionalParameters)
        {
            var resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId;
            string claimsChallenge = null;
            IAzureTokenCache tokenCache = null;
            ICmdletContext cmdletContext = null;
            AuthenticationTelemetry authenticationTelemetry = null;
            
            if (optionalParameters != null)
            {
                if (optionalParameters.ContainsKey(ResourceIdParameterName))
                {
                    resourceId = optionalParameters[ResourceIdParameterName] as string;
                }

                if (optionalParameters.ContainsKey(ClaimsChallengeParameterName))
                {
                    claimsChallenge = optionalParameters[ClaimsChallengeParameterName] as string;
                }

                if (optionalParameters.ContainsKey(TokenCacheParameterName))
                {
                    tokenCache = optionalParameters[TokenCacheParameterName] as IAzureTokenCache;
                }

                if (AzureSession.Instance.TryGetComponent(AuthenticationTelemetry.Name, out authenticationTelemetry))
                {
                    if (optionalParameters.ContainsKey(CmdletContextParameterName))
                    {
                        cmdletContext = optionalParameters[CmdletContextParameterName] as ICmdletContext;
                    }
                }
            }

            PowerShellTokenCacheProvider tokenCacheProvider;
            if (!AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out tokenCacheProvider))
            {
                throw new NullReferenceException(Resources.AuthenticationClientFactoryNotRegistered);
            }

            Task<IAccessToken> authToken;
            var processAuthenticator = Builder.Authenticator;
            var retries = 5;
            var authParamters = GetAuthenticationParameters(tokenCacheProvider, account, environment, tenant, password, promptBehavior, promptAction, claimsChallenge, tokenCache, resourceId);

            IAccessToken token = null;
            while (retries-- > 0)
            {
                try
                {
                    while (processAuthenticator != null && processAuthenticator.TryAuthenticate(authParamters, out authToken))
                    {
                        token = authToken?.GetAwaiter().GetResult();
                        if (token != null)
                        {
                            // token.UserId is null when getting tenant token in ADFS environment
                            account.Id = token.UserId ?? account.Id;
                            if (!string.IsNullOrEmpty(token.HomeAccountId))
                            {
                                account.SetProperty(AzureAccount.Property.HomeAccountId, token.HomeAccountId);
                            }
                            if (cmdletContext!= null)
                            {
                                if (!authenticationTelemetry.PushDataRecord(cmdletContext, new AuthTelemetryRecord(Builder.Authenticator.GetDataForTelemetry(), true)))
                                {
                                    TracingAdapter.Information(string.Format(Resources.AuthenticationTelemetryRecordPushError, (cmdletContext?.CmdletId) ?? "Unknown"));
                                }
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
                        if (cmdletContext != null)
                        {
                            if (!authenticationTelemetry.PushDataRecord(cmdletContext, new AuthTelemetryRecord(Builder.Authenticator.GetDataForTelemetry(), false)))
                            {
                                TracingAdapter.Information(string.Format(Resources.AuthenticationTelemetryRecordPushError, (cmdletContext?.CmdletId) ?? "Unknown"));
                            }
                        }
                        var mfaException = AnalyzeMsalException(e, environment, tenant, resourceId);
                        if (mfaException != null)
                        {
                            throw mfaException;
                        }
                        else
                        {
                            throw;
                        }
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
            if (msalException != null)
            {
                return msalException.ErrorCode == MsalError.RequestTimeout ||
                    msalException.ErrorCode == MsalError.ServiceNotAvailable;
            }
            return false;
        }

        private static AzPSAuthenticationFailedException AnalyzeMsalException(Exception exception, IAzureEnvironment environment, string tenantId, string resourceId)
        {
            var originalException = exception;
            while (exception != null)
            {
                if (exception is MsalUiRequiredException msalUiRequiredException)
                {
                    string errorMessage;
                    string desensitizedMessage;
                    if (NeedTenantArmPermission(environment, tenantId, resourceId))
                    {
                        errorMessage = string.Format(Resources.ErrorMessageMsalInteractionRequiredWithTid, tenantId);
                        desensitizedMessage = "MFA is required to access tenant";
                    }
                    else
                    {
                        errorMessage = string.Format(Resources.ErrorMsgMsalInteractionRequiredWithResourceID, resourceId);
                        desensitizedMessage = "MFA is required to access resource";
                    }
                    return new AzPSAuthenticationFailedException(
                        errorMessage,
                        msalUiRequiredException.ErrorCode,
                        originalException,
                        desensitizedMessage: desensitizedMessage);
                }
                exception = exception.InnerException;
            }

            return null;
        }

        private static bool NeedTenantArmPermission(IAzureEnvironment environment, string tenantId, string resourceId)
        {
            return !string.IsNullOrEmpty(tenantId) && !string.IsNullOrEmpty(resourceId) &&
                string.Equals(environment.GetEndpoint(resourceId), environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
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


        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, ICmdletContext cmdletContext)
        {
            return GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, cmdletContext);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint, ICmdletContext cmdletContext)
        {
            if (context == null)
            {
                throw new AzPSApplicationException("Azure context is empty");
            }
            return GetServiceClientCredentials(context, targetEndpoint, context.Environment.GetTokenAudience(targetEndpoint), cmdletContext);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint, string resourceId, ICmdletContext cmdletContext)
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
                    return new RenewingTokenCredential(new ExternalAccessToken(GetEndpointToken(context.Account, targetEndpoint), () => GetEndpointToken(context.Account, targetEndpoint)));
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
                    case AzureAccount.AccountType.User:
                    case AzureAccount.AccountType.ServicePrincipal:
                    case "ClientAssertion":
                        var optionalParameters = new Dictionary<string, object>()
                        {
                            {ResourceIdParameterName, resourceId },
                            {CmdletContextParameterName, cmdletContext }
                        };
                        token = Authenticate(context.Account, context.Environment, tenant, null, ShowDialog.Never, null, optionalParameters);
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
                throw new AzPSArgumentException(Resources.InvalidArmContext + System.Environment.NewLine + ex.Message, ex);
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
        /// <param name="environment"></param>
        public void RemoveUser(IAzureAccount account, IAzureEnvironment environment)
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
                            KeyStore.RemoveSecureString(new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret, account.Id, account.GetTenants().FirstOrDefault()));
                            KeyStore.RemoveSecureString(new ServicePrincipalKey(AzureAccount.Property.CertificatePassword, account.Id, account.GetTenants().FirstOrDefault()));
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
            if (string.Equals(targetEndpoint, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, StringComparison.OrdinalIgnoreCase))
            {
                tokenKey = AzureAccount.Property.KeyVaultAccessToken;
            }
            if (string.Equals(targetEndpoint, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphEndpointResourceId, StringComparison.OrdinalIgnoreCase) || string.Equals(targetEndpoint, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl, StringComparison.OrdinalIgnoreCase))
            {
                tokenKey = Constants.MicrosoftGraphAccessToken;
            }
            if (string.Equals(targetEndpoint, AzureEnvironment.Endpoint.Graph, StringComparison.OrdinalIgnoreCase))
            {
                tokenKey = AzureAccount.Property.GraphAccessToken;
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
            var accounts = publicClient.GetAccountsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            var tokenAccounts = accounts.Where(a => MatchCacheItem(account, a));
            foreach (var tokenAccount in tokenAccounts)
            {
                publicClient.RemoveAsync(tokenAccount).ConfigureAwait(false).GetAwaiter().GetResult();
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

        /// <summary>
        /// Creates the appropriate authentication parameters based on the account type and other inputs.
        /// </summary>
        /// <param name="tokenCacheProvider">Provider for token caching.</param>
        /// <param name="account">The Azure account to authenticate.</param>
        /// <param name="environment">The Azure environment to authenticate against.</param>
        /// <param name="tenant">The tenant ID or name to authenticate with.</param>
        /// <param name="password">The password for the account, if applicable.</param>
        /// <param name="promptBehavior">The prompt behavior to use during authentication.</param>
        /// <param name="promptAction">Action to execute when a prompt is required.</param>
        /// <param name="claimsChallenge">Claims challenge token from a previous authentication attempt.</param>
        /// <param name="tokenCache">The token cache to use for caching authentication results.</param>
        /// <param name="resourceId">The resource identifier to authenticate for.</param>
        /// <returns>Authentication parameters appropriate for the account type.</returns>
        private AuthenticationParameters GetAuthenticationParameters(
            PowerShellTokenCacheProvider tokenCacheProvider,
            IAzureAccount account,
            IAzureEnvironment environment,
            string tenant,
            SecureString password,
            string promptBehavior,
            Action<string> promptAction,
            string claimsChallenge,
            IAzureTokenCache tokenCache,
            string resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            switch (account.Type)
            {
                case AzureAccount.AccountType.User:
                    if (password == null)
                    {
                        var homeAccountId = account.GetProperty(AzureAccount.Property.HomeAccountId) ?? "";

                        if (!string.IsNullOrEmpty(account.Id) && string.IsNullOrEmpty(claimsChallenge))
                        {
                            return GetSilentParameters(tokenCacheProvider, account, environment, tenant, tokenCache, resourceId, homeAccountId);
                        }

                        if (account.IsPropertySet("UseDeviceAuth"))
                        {
                            return new DeviceCodeParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, homeAccountId, claimsChallenge);
                        }
                        else if (account.IsPropertySet(AzureAccount.Property.UsePasswordAuth))
                        {
                            return new UsernamePasswordParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, password, homeAccountId);
                        }
                        return GetInteractiveParameters(tokenCacheProvider, account, environment, tenant, promptAction, claimsChallenge, tokenCache, resourceId, homeAccountId);
                    }

                    return new UsernamePasswordParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, password, null);
                case AzureAccount.AccountType.Certificate:
                case AzureAccount.AccountType.ServicePrincipal:
                    bool? sendCertificateChain = null;
                    var sendCertificateChainStr = account.GetProperty(AzureAccount.Property.SendCertificateChain);
                    if (!string.IsNullOrWhiteSpace(sendCertificateChainStr))
                    {
                        sendCertificateChain = Boolean.Parse(sendCertificateChainStr);
                    }
                    password = password ?? account.GetProperty(AzureAccount.Property.ServicePrincipalSecret)?.ConvertToSecureString();
                    if (password == null)
                    {
                        try
                        {
                            password = KeyStore.GetSecureString(new ServicePrincipalKey(AzureAccount.Property.ServicePrincipalSecret, account.Id, tenant));
                        }
                        catch
                        {
                            password = null;
                        }

                    }
                    var certificatePassword = account.GetProperty(AzureAccount.Property.CertificatePassword)?.ConvertToSecureString();
                    if (certificatePassword == null)
                    {
                        try
                        {
                            certificatePassword = KeyStore.GetSecureString(new ServicePrincipalKey(AzureAccount.Property.CertificatePassword
                            , account.Id, tenant));
                        }
                        catch
                        {
                            certificatePassword = null;
                        }
                    }
                    return new ServicePrincipalParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, account.GetProperty(AzureAccount.Property.CertificateThumbprint), account.GetProperty(AzureAccount.Property.CertificatePath),
                        certificatePassword, password, sendCertificateChain);
                case AzureAccount.AccountType.ManagedService:
                    return new ManagedServiceIdentityParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account);
                case AzureAccount.AccountType.AccessToken:
                    return new AccessTokenParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account);
                case "ClientAssertion":
                    password = password ?? account.GetProperty("ClientAssertion")?.ConvertToSecureString();
                    return new ClientAssertionParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, password);
                default:
                    return null;
            }
        }

        private static AuthenticationParameters GetInteractiveParameters(PowerShellTokenCacheProvider tokenCacheProvider, IAzureAccount account, IAzureEnvironment environment, string tenant, Action<string> promptAction, string claimsChallenge, IAzureTokenCache tokenCache, string resourceId, string homeAccountId)
        {
            return AzConfigReader.IsWamEnabled(environment.ActiveDirectoryAuthority)
                ? new InteractiveWamParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.GetProperty("LoginHint"), homeAccountId, promptAction, claimsChallenge) as AuthenticationParameters
                : new InteractiveParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.GetProperty("LoginHint"), homeAccountId, promptAction, claimsChallenge);
        }

        private static AuthenticationParameters GetSilentParameters(PowerShellTokenCacheProvider tokenCacheProvider, IAzureAccount account, IAzureEnvironment environment, string tenant, IAzureTokenCache tokenCache, string resourceId, string homeAccountId)
        {
            return new SilentParameters(tokenCacheProvider, environment, tokenCache, tenant, resourceId, account.Id, homeAccountId);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context)
        {
            return GetServiceClientCredentials(context, AzureCmdletContext.CmdletNone);
        }

        public ServiceClientCredentials GetServiceClientCredentials(IAzureContext context, string targetEndpoint)
        {
            return GetServiceClientCredentials(context, targetEndpoint, AzureCmdletContext.CmdletNone);
        }

        /// <summary>
        /// Remove a user from token cache.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="tokenCache">This parameter is no longer used. However to keep the API unchanged it's not removed.</param>
        public void RemoveUser(IAzureAccount account, IAzureTokenCache tokenCache)
        {
            RemoveUser(account, environment: null);
        }
    }
}

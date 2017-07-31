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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Linq;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Properties;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string CommonAdTenant = "Common";

        public AuthenticationFactory()
        {
            TokenProvider = new AdalTokenProvider();
        }

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
            IAccessToken token;
            var cache = tokenCache as TokenCache;
            if (cache == null)
            {
                cache = TokenCache.DefaultShared;
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
            if (account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
            {
                var thumbprint = account.GetProperty(AzureAccount.Property.CertificateThumbprint);
#if !NETSTANDARD
                token = TokenProvider.GetAccessTokenWithCertificate(configuration, account.Id, thumbprint, account.Type);
#else
                throw new NotSupportedException("Certificate based authentication is not supported in netcore version.");
#endif
            }
            else
            {
                token = TokenProvider.GetAccessToken(configuration, promptBehavior, promptAction, account.Id, password, account.Type);
            }

            account.Id = token.UserId;
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

            if (context.Account.Type == AzureAccount.AccountType.Certificate)
            {
                var certificate = AzureSession.Instance.DataStore.GetCertificate(context.Account.Id);
                return new CertificateCloudCredentials(context.Subscription.Id.ToString(), certificate);
            }

            if (context.Account.Type == AzureAccount.AccountType.AccessToken)
            {
                return new TokenCloudCredentials(context.Subscription.Id.ToString(), context.Account.GetProperty(AzureAccount.Property.AccessToken));
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

            if (context.Account.Type == AzureAccount.AccountType.Certificate)
            {
                throw new NotSupportedException(AzureAccount.AccountType.Certificate.ToString());
            }

            if (context.Account.Type == AzureAccount.AccountType.AccessToken)
            {
                return new TokenCredentials(context.Account.GetProperty(AzureAccount.Property.AccessToken));
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

                var env = new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ActiveDirectory),
                    TokenAudience = context.Environment.GetEndpointAsUri(context.Environment.GetTokenAudience(targetEndpoint)),
                    ValidateAuthority = !context.Environment.OnPremise
                };

                var tokenCache = AzureSession.Instance.TokenCache;

                if (context.TokenCache != null)
                {
                    tokenCache = context.TokenCache;
                }

                ServiceClientCredentials result = null;

                if (context.Account.Type == AzureAccount.AccountType.User)
                {
                    result = Rest.Azure.Authentication.UserTokenProvider.CreateCredentialsFromCache(
                        AdalConfiguration.PowerShellClientId,
                        tenant,
                        context.Account.Id,
                        env,
                        tokenCache as TokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                }
                else if (context.Account.Type == AzureAccount.AccountType.ServicePrincipal)
                {
                    if (context.Account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
                    {
                        result = ApplicationTokenProvider.LoginSilentAsync(
                            tenant,
                            context.Account.Id,
                            new CertificateApplicationCredentialProvider(
                                context.Account.GetThumbprint()),
                            env,
                            tokenCache as TokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                    else
                    {
                        result = ApplicationTokenProvider.LoginSilentAsync(
                            tenant,
                            context.Account.Id,
                            new KeyStoreApplicationCredentialProvider(tenant),
                            env,
                            tokenCache as TokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
                else
                {
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

            var audience = environment.GetEndpoint(resourceId);
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
                ResourceClientUri = environment.GetEndpoint(resourceId),
                AdDomain = tenantId,
                ValidateAuthority = !environment.OnPremise,
                TokenCache = tokenCache
            };
        }
    }
}

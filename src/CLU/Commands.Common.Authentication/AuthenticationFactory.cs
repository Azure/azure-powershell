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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using Commands.Common.Authentication.Properties;

namespace Microsoft.Azure.Commands.Common.Authentication.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string CommonAdTenant = "Common";

        public AuthenticationFactory() : this(new DiskDataStore())
        {
        }

        public AuthenticationFactory(IDataStore dataStore)
        {
            TokenProvider = new AdalTokenProvider();
            DataStore = dataStore;
        }

        public ITokenProvider TokenProvider { get; set; }

        public IDataStore DataStore { get; set; }

        public IAccessToken Authenticate(
            AzureAccount account, 
            AzureEnvironment environment, 
            string tenant, 
            string password,
            AuthenticationBehavior behavior,
            TokenCache tokenCache, 
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            var configuration = GetAdalConfiguration(environment, tenant, resourceId, tokenCache);

            ServiceClientTracing.Information(Resources.AdalAuthConfigurationTrace, configuration.AdDomain, configuration.AdEndpoint, 
                configuration.ClientId, configuration.ClientRedirectUri, configuration.ResourceClientUri, configuration.ValidateAuthority);
            IAccessToken token;
            if (account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
            {
                var thumbprint = account.GetProperty(AzureAccount.Property.CertificateThumbprint);
                var certificatePassword = account.GetProperty(AzureAccount.Property.CertificatePassword);
                token = TokenProvider.GetAccessTokenWithCertificate(
                    configuration, account.Id, thumbprint, certificatePassword, account.Type);
            }
            else
            {
                if (account.IsPropertySet(AzureAccount.Property.ApplicationSecret))
                {
                    password = password ?? account.GetProperty(AzureAccount.Property.ApplicationSecret);
                }
                token = TokenProvider.GetAccessToken(configuration, behavior, account.Id, password, account.Type);
            }

            account.Id = token.UserId;
            return token;
        }

        public IAccessToken Authenticate(
            AzureAccount account,
            AzureEnvironment environment,
            string tenant,
            string password,
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            return Authenticate(
                account, 
                environment, 
                tenant, 
                password, 
                new AuthenticationBehavior { Type = AuthenticationType.Silent }, 
                TokenCache.DefaultShared, 
                resourceId);
        }

        public ServiceClientCredentials GetSubscriptionCloudCredentials(AzureContext context)
        {
            return GetSubscriptionCloudCredentials(context, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public ServiceClientCredentials GetSubscriptionCloudCredentials(
            AzureContext context, 
            AzureEnvironment.Endpoint targetEndpoint)
        {
            if (context.Subscription == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidDefaultSubscription
                    : Resources.NoSubscriptionInContext;
                throw new PSInvalidOperationException(exceptionMessage);
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
                throw new NotImplementedException("ADAL 3.6.210231457-alpha does not support certificate based authentication.");
                //var certificate = AzureSession.DataStore.GetCertificate(context.Account.Id);
                //return new CertificateCredentials(context.Subscription.Id.ToString(), certificate);
            }

            if (context.Account.Type == AzureAccount.AccountType.AccessToken)
            {
                return new TokenCredentials(context.Subscription.Id.ToString(), context.Account.GetProperty(AzureAccount.Property.AccessToken));
            }

            string tenant = null;

            if (context.Subscription != null && context.Account != null)
            {
                tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                      .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                      .FirstOrDefault();
            }

            if (tenant == null && context.Tenant != null && context.Tenant.Id != Guid.Empty)
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
                ServiceClientTracing.Information(Resources.UPNAuthenticationTrace, 
                    context.Account.Id, context.Environment.Name, tenant);
                var tokenCache = TokenCache.DefaultShared;
                if(context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    tokenCache = new TokenCache(context.TokenCache);
                }
                
                var token = Authenticate(
                    context.Account, 
                    context.Environment,
                    tenant, null,
                    new AuthenticationBehavior { Type = AuthenticationType.Silent },
                    tokenCache);

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    context.TokenCache = tokenCache.Serialize();
                }

                ServiceClientTracing.Information(Resources.UPNAuthenticationTokenTrace, 
                    token.LoginType, token.TenantId, token.UserId);
                return new AccessTokenCredential(context.Subscription.Id, token);
            }
            catch (Exception ex)
            {
                 ServiceClientTracing.Information(Resources.AdalAuthException, ex.Message);
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidSubscriptionState
                    : Resources.InvalidArmContext;
                throw new ArgumentException(exceptionMessage, ex);
            }
        }

        public ServiceClientCredentials GetServiceClientCredentials(AzureContext context)
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

            if (tenant == null && context.Tenant != null && context.Tenant.Id != Guid.Empty)
            {
                tenant = context.Tenant.Id.ToString();
            }

            if (tenant == null)
            {
                throw new ArgumentException(Resources.NoTenantInContext);
            }

            try
            {
                ServiceClientTracing.Information(Resources.UPNAuthenticationTrace,
                    context.Account.Id, context.Environment.Name, tenant);

                // TODO: When we will refactor the code, need to add tracing
                /*ServiceClientTracing.Information(Resources.UPNAuthenticationTokenTrace,
                    token.LoginType, token.TenantId, token.UserId);*/

                var env = new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ActiveDirectory),
                    TokenAudience = context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId),
                    ValidateAuthority = !context.Environment.OnPremise
                };

                var tokenCache = TokenCache.DefaultShared;

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    tokenCache = new TokenCache(context.TokenCache);
                }

                ServiceClientCredentials result = null;

                if(context.Account.Type == AzureAccount.AccountType.User)
                {
                    result = Rest.Azure.Authentication.UserTokenProvider.CreateCredentialsFromCache(
                        AdalConfiguration.PowerShellClientId, 
                        tenant, 
                        context.Account.Id, 
                        env, 
                        tokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                }
                else if (context.Account.Type == AzureAccount.AccountType.ServicePrincipal)
                {
                    if (context.Account.IsPropertySet(AzureAccount.Property.CertificateThumbprint) 
                        && context.Account.IsPropertySet(AzureAccount.Property.CertificatePassword))
                    {
                        result = ApplicationTokenProvider.LoginSilentAsync(
                            tenant,
                            context.Account.Id,
                            new CertificateApplicationCredentialProvider(
                                context.Account.GetProperty(AzureAccount.Property.CertificateThumbprint),
                                context.Account.GetProperty(AzureAccount.Property.CertificatePassword), DataStore.GetCertificate),
                            env,
                            tokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                    else if (context.Account.IsPropertySet(AzureAccount.Property.ApplicationSecret))
                    {
                        result = ApplicationTokenProvider.LoginSilentAsync(
                            tenant,
                            context.Account.Id,
                            new KeyStoreApplicationCredentialProvider(tenant, context.Account.GetProperty(AzureAccount.Property.ApplicationSecret)),
                            env,
                            tokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                    else
                    {
                        throw new NotSupportedException(Resources.SPNRequiresCreds);
                    }
                }
                else
                {
                    throw new NotSupportedException(context.Account.Type.ToString());
                }

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    context.TokenCache = tokenCache.Serialize();
                }

                return result;
            }
            catch (Exception ex)
            {
                ServiceClientTracing.Information(Resources.AdalAuthException, ex.Message);
                throw new ArgumentException(Resources.InvalidArmContext, ex);
            }
        }

        private AdalConfiguration GetAdalConfiguration(AzureEnvironment environment, string tenantId,
            AzureEnvironment.Endpoint resourceId, TokenCache tokenCache)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            var adEndpoint = environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory];

            return new AdalConfiguration
            {
                AdEndpoint = adEndpoint,
                ResourceClientUri = environment.Endpoints[resourceId],
                AdDomain = tenantId, 
                ValidateAuthority = !environment.OnPremise,
                TokenCache = tokenCache
            };
        }
    }
}

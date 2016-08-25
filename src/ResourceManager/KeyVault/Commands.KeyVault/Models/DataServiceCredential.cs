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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class DataServiceCredential
    {
        private readonly IAuthenticationFactory _authenticationFactory;
        private readonly AzureContext _context;
        private readonly AzureEnvironment.Endpoint _endpointName;

        public DataServiceCredential(IAuthenticationFactory authFactory, AzureContext context, AzureEnvironment.Endpoint resourceIdEndpoint)
        {
            if (authFactory == null)
                throw new ArgumentNullException("authFactory");
            if (context == null)
                throw new ArgumentNullException("context");
            _authenticationFactory = authFactory;
            _context = context;
            _endpointName = resourceIdEndpoint;
            this.TenantId = GetTenantId(context);
        }

        public string TenantId { get; private set; }

        /// <summary>
        /// Authentication callback method required by KeyVaultClient
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="resource"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public Task<string> OnAuthentication(string authority, string resource, string scope)
        {
            // TODO: Add trace to log tokenType, resource, authority, scope etc
            string tokenStr = string.Empty;

            // overriding the cached resourceId value to resource returned from the server
            if (!string.IsNullOrEmpty(resource))
            {
                _context.Environment.Endpoints[_endpointName] = resource;
            }

            var bundle = GetTokenInternal(this.TenantId, this._authenticationFactory, this._context, this._endpointName);
            bundle.Item1.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });
            return Task.FromResult<string>(tokenStr);
        }

        public string GetToken()
        {
            return GetTokenInternal(this.TenantId, this._authenticationFactory, this._context, this._endpointName).Item1.AccessToken;
        }

        private static string GetTenantId(AzureContext context)
        {
            var tenantId = string.Empty;
            if (context.Account == null)
                throw new ArgumentException(KeyVaultProperties.Resources.ArmAccountNotFound);

            if (context.Account.Type != AzureAccount.AccountType.User &&
                context.Account.Type != AzureAccount.AccountType.ServicePrincipal)
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.UnsupportedAccountType, context.Account.Type));

            if (context.Subscription != null && context.Account != null)
                tenantId = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                       .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                       .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(tenantId) && context.Tenant != null && context.Tenant.Id != Guid.Empty)
                tenantId = context.Tenant.Id.ToString();
            return tenantId;
        }

        private static Tuple<IAccessToken, string> GetTokenInternal(string tenantId, IAuthenticationFactory authFactory, AzureContext context, AzureEnvironment.Endpoint resourceIdEndpoint)
        {
            if (string.IsNullOrWhiteSpace(tenantId))
                throw new ArgumentException(KeyVaultProperties.Resources.NoTenantInContext);

            try
            {
                var tokenCache = AzureSession.TokenCache;
                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    tokenCache = new TokenCache(context.TokenCache);
                }

                var accesstoken = authFactory.Authenticate(context.Account, context.Environment, tenantId, null, ShowDialog.Never,
                    tokenCache, resourceIdEndpoint);

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    context.TokenCache = tokenCache.Serialize();
                }

                return Tuple.Create(accesstoken, context.Environment.Endpoints[resourceIdEndpoint]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSubscriptionState, ex);
            }
        }
    }
}

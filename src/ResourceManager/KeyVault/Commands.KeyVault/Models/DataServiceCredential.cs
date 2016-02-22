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

using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class DataServiceCredential
    {
        public DataServiceCredential(IAuthenticationFactory authFactory, AzureContext context, AzureEnvironment.Endpoint resourceIdEndpoint)
        {
            if (authFactory == null)
                throw new ArgumentNullException("authFactory");
            if (context == null)
                throw new ArgumentNullException("context");

            var bundle = GetToken(authFactory, context, resourceIdEndpoint);
            this.token = bundle.Item1;
        }

        public string AccessToken
        {
            get
            {
                return token.AccessToken;
            }
        }

        public string TenantId { get; set; }

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
            this.token.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });
              
            return Task.FromResult<string>(tokenStr);           
        }

        private Tuple<IAccessToken, string> GetToken(IAuthenticationFactory authFactory, AzureContext context, AzureEnvironment.Endpoint resourceIdEndpoint)
        {
            if (context.Account == null)
                throw new ArgumentException(KeyVaultProperties.Resources.ArmAccountNotFound);

            if (context.Account.Type != AzureAccount.AccountType.User &&
                context.Account.Type != AzureAccount.AccountType.ServicePrincipal )
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.UnsupportedAccountType, context.Account.Type));

            if (context.Subscription != null && context.Account != null)
                TenantId = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                       .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                       .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(TenantId) && context.Tenant != null && context.Tenant.Id != Guid.Empty)
                TenantId = context.Tenant.Id.ToString();

            if (string.IsNullOrWhiteSpace(TenantId))
                throw new ArgumentException(KeyVaultProperties.Resources.NoTenantInContext);
          
            try
            {
                var accesstoken = authFactory.Authenticate(context.Account, context.Environment, TenantId, null, ShowDialog.Auto,
                    resourceIdEndpoint);

                return Tuple.Create(accesstoken, context.Environment.Endpoints[resourceIdEndpoint]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSubscriptionState, ex);
            }        
        }
     
        private IAccessToken token;
    }
}

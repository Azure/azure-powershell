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
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal class DataServiceCredential
    {
        public DataServiceCredential(IAuthenticationFactory authFactory, AzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException("authFactory");
            if (context == null)
                throw new ArgumentNullException("context");
            
            var bundle = GetToken(authFactory, context);
            this.token = bundle.Item1;
            this.resourceId = bundle.Item2;
        }

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

        private Tuple<IAccessToken, string> GetToken(IAuthenticationFactory authFactory, AzureContext context)
        {
            if (context.Subscription == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidCurrentSubscription);
            if (context.Account == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSubscriptionState);
            if (context.Account.Type != AzureAccount.AccountType.User)
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.UnsupportedAccountType, context.Account.Type));
            var tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                  .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                  .FirstOrDefault();
            if (tenant == null)
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSubscriptionState);
          
            try
            {
                var accesstoken = authFactory.Authenticate(context.Account, context.Environment, tenant, null, ShowDialog.Auto,
                    ResourceIdEndpoint);

                return Tuple.Create(accesstoken, context.Environment.Endpoints[ResourceIdEndpoint]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(KeyVaultProperties.Resources.InvalidSubscriptionState, ex);
            }        
        }
     
        private IAccessToken token;
        private string resourceId;

        private const AzureEnvironment.Endpoint ResourceIdEndpoint = AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId;
    }
}

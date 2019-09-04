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
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class AccessTokenAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters)
        {
            var tokenParameters = parameters as AccessTokenParameters;
            var tenant = tokenParameters.TenantId;
            var account = tokenParameters.Account;
            var resourceId = tokenParameters.ResourceEndpoint;
            var environment = tokenParameters.Environment;
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
                throw new InvalidOperationException(string.Format("Cannot retrieve access token for resource '{0}';.  Please ensure that you have provided the appropriate access tokens when using access token login.", resourceId));
            }

            return Task.Run(() => rawToken as IAccessToken);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is AccessTokenParameters;
        }
    }
}

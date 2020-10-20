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
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class AccessTokenAuthenticator : DelegatingAuthenticator
    {
        private const string _accessTokenFailure = "Cannot retrieve access token for resource '{0}';. " +
                                                   "Please ensure that you have provided the appropriate access tokens when using access token login.";

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var tokenParameters = parameters as AccessTokenParameters;
            var tenant = tokenParameters.TenantId;
            var account = tokenParameters.Account;
            var resourceId = tokenParameters.ResourceId;
            var environment = tokenParameters.Environment;
            var rawToken = new RawAccessToken
            {
                TenantId = tenant,
                UserId = account.Id,
                LoginType = AzureAccount.AccountType.AccessToken
            };

            if ((resourceId.EqualsInsensitively(environment.AzureKeyVaultServiceEndpointResourceId) ||
                 resourceId.EqualsInsensitively(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId) ||
                 resourceId.EqualsInsensitively(environment.GetEndpoint(environment.AzureKeyVaultServiceEndpointResourceId)) ||
                 resourceId.EqualsInsensitively(environment.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId)))
                 && account.IsPropertySet(AzureAccount.Property.KeyVaultAccessToken))
            {
                TracingAdapter.Information(string.Format("[AccessTokenAuthenticator] Creating KeyVault access token - Tenant: '{0}', ResourceId: '{1}', UserId: '{2}'", tenant, resourceId, account.Id));
                rawToken.AccessToken = account.GetProperty(AzureAccount.Property.KeyVaultAccessToken);
            }
            else if ((resourceId.EqualsInsensitively(environment.GraphEndpointResourceId) ||
                      resourceId.EqualsInsensitively(AzureEnvironment.Endpoint.GraphEndpointResourceId) ||
                      resourceId.EqualsInsensitively(environment.GetEndpoint(environment.GraphEndpointResourceId)) ||
                      resourceId.EqualsInsensitively(environment.GetEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId)))
                      && account.IsPropertySet(AzureAccount.Property.GraphAccessToken))
            {
                TracingAdapter.Information(string.Format("[AccessTokenAuthenticator] Creating Graph access token - Tenant: '{0}', ResourceId: '{1}', UserId: '{2}'", tenant, resourceId, account.Id));
                rawToken.AccessToken = account.GetProperty(AzureAccount.Property.GraphAccessToken);
            }
            else if ((resourceId.EqualsInsensitively(environment.ActiveDirectoryServiceEndpointResourceId) ||
                      resourceId.EqualsInsensitively(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId) ||
                      resourceId.EqualsInsensitively(environment.GetEndpoint(environment.ActiveDirectoryServiceEndpointResourceId)) ||
                      resourceId.EqualsInsensitively(environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)))
                      && account.IsPropertySet(AzureAccount.Property.AccessToken))
            {
                TracingAdapter.Information(string.Format("[AccessTokenAuthenticator] Creating access token - Tenant: '{0}', ResourceId: '{1}', UserId: '{2}'", tenant, resourceId, account.Id));
                rawToken.AccessToken = account.GetAccessToken();
            }
            else
            {
                throw new InvalidOperationException(string.Format(_accessTokenFailure, resourceId));
            }

            return Task.Run(() => rawToken as IAccessToken, cancellationToken);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as AccessTokenParameters) != null;
        }
    }
}

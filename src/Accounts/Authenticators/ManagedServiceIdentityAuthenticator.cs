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

using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class ManagedServiceIdentityAuthenticator : DelegatingAuthenticator
    {
        public const string CommonAdTenant = "organizations",
            AppServiceManagedIdentityFlag = "AppServiceManagedIdentityFlag",
            DefaultMSILoginUri = "http://169.254.169.254/metadata/identity/oauth2/token",
            DefaultBackupMSILoginUri = "http://localhost:50342/oauth2/token";


        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var msiParameters = parameters as ManagedServiceIdentityParameters;

            var scopes = new[] { GetResourceId(msiParameters.ResourceId, msiParameters.Environment) };
            var requestContext = new TokenRequestContext(scopes);
            ManagedIdentityCredential identityCredential = new ManagedIdentityCredential();
            var tokenTask = identityCredential.GetTokenAsync(requestContext);
            return MsalAccessToken.GetAccessTokenAsync(tokenTask, EmptyAction, msiParameters.TenantId, msiParameters.Account.Id);
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as ManagedServiceIdentityParameters) != null;
        }

        //private IAccessToken GetManagedServiceToken(IAzureAccount account, IAzureEnvironment environment, string tenant, string resourceId)
        //{
        //    if (environment == null)
        //    {
        //        throw new InvalidOperationException("Environment is required for MSI Login");
        //    }

        //    if (!account.IsPropertySet(AzureAccount.Property.MSILoginUri))
        //    {
        //        account.SetProperty(AzureAccount.Property.MSILoginUri, DefaultMSILoginUri);
        //    }

        //    if (!account.IsPropertySet(AzureAccount.Property.MSILoginUriBackup))
        //    {
        //        account.SetProperty(AzureAccount.Property.MSILoginUriBackup, DefaultBackupMSILoginUri);
        //    }

        //    if (string.IsNullOrWhiteSpace(tenant))
        //    {
        //        tenant = environment.AdTenant ?? CommonAdTenant;
        //    }

        //    if (account.IsPropertySet(AppServiceManagedIdentityFlag))
        //    {
        //        TracingAdapter.Information(string.Format("[ManagedServiceIdentityAuthenticator] Creating App Service managed service token - Tenant: '{0}', ResourceId: '{1}', UserId: '{2}'", tenant, resourceId, account.Id));
        //        return new ManagedServiceAppServiceAccessToken(account, environment, GetFunctionsResourceId(resourceId, environment), tenant);
        //    }

        //    TracingAdapter.Information(string.Format("[ManagedServiceIdentityAuthenticator] Creating managed service token - Tenant: '{0}', ResourceId: '{1}', UserId: '{2}'", tenant, resourceId, account.Id));
        //    return new ManagedServiceAccessToken(account, environment, GetResourceId(resourceId, environment), tenant);
        //}

        private string GetResourceId(string resourceIdorEndpointName, IAzureEnvironment environment)
        {
            return environment.GetEndpoint(resourceIdorEndpointName) ?? resourceIdorEndpointName;
        }

        //private string GetFunctionsResourceId(string resourceIdOrEndpointName, IAzureEnvironment environment)
        //{
        //    var resourceId = environment.GetEndpoint(resourceIdOrEndpointName) ?? resourceIdOrEndpointName;
        //    if (string.Equals(
        //        environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId),
        //        resourceId, StringComparison.OrdinalIgnoreCase))
        //    {
        //        resourceId = environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
        //    }

        //    return resourceId;
        //}
    }
}

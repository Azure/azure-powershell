﻿// ----------------------------------------------------------------------------------
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

using Azure.Core;
using Azure.Identity.BrokeredAuthentication;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Azure.Identity;
using Microsoft.Azure.PowerShell.Common.Config;
using Microsoft.Azure.Commands.Shared.Config;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    public class SilentAuthenticator : DelegatingAuthenticator
    {
        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var silentParameters = parameters as SilentParameters;
            var onPremise = silentParameters.Environment.OnPremise;
            var tenantId = onPremise ? AdfsTenant :
                (string.Equals(parameters.TenantId, OrganizationsTenant, StringComparison.OrdinalIgnoreCase) ? null : parameters.TenantId);
            var resource = silentParameters.Environment.GetEndpoint(silentParameters.ResourceId) ?? silentParameters.ResourceId;
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);
            var authority = silentParameters.Environment.ActiveDirectoryAuthority;
            var tokenCacheProvider = silentParameters.TokenCacheProvider;

            AzureSession.Instance.TryGetComponent(nameof(AzureCredentialFactory), out AzureCredentialFactory azureCredentialFactory);
            SharedTokenCacheCredentialOptions options = GetTokenCredentialOptions(silentParameters, tenantId, authority, tokenCacheProvider);
            var cacheCredential = azureCredentialFactory.CreateSharedTokenCacheCredentials(options);
            var requestContext = new TokenRequestContext(scopes);
            var parametersLog = $"- TenantId:'{options.TenantId}', Scopes:'{string.Join(",", scopes)}', AuthorityHost:'{options.AuthorityHost}', UserId:'{silentParameters.UserId}'";
            return MsalAccessToken.GetAccessTokenAsync(
                nameof(SilentAuthenticator),
                parametersLog,
                cacheCredential,
                requestContext,
                cancellationToken,
                silentParameters.TenantId,
                silentParameters.UserId,
                silentParameters.HomeAccountId);
        }

        private static SharedTokenCacheCredentialOptions GetTokenCredentialOptions(SilentParameters silentParameters, string tenantId, string authority, PowerShellTokenCacheProvider tokenCacheProvider)
        {
            bool isWamEnabled = AzureSession.Instance.TryGetComponent<IConfigManager>(nameof(IConfigManager), out var config)
                && config.GetConfigValue<bool>(ConfigKeys.EnableLoginByWam);
            SharedTokenCacheCredentialOptions options = isWamEnabled
                ? new SharedTokenCacheCredentialBrokerOptions(tokenCacheProvider.GetTokenCachePersistenceOptions())
                : new SharedTokenCacheCredentialOptions(tokenCacheProvider.GetTokenCachePersistenceOptions());
            options.EnableGuestTenantAuthentication = true;
            options.ClientId = Constants.PowerShellClientId;
            options.Username = silentParameters.UserId;
            options.AuthorityHost = new Uri(authority);
            options.TenantId = tenantId;
            return options;
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as SilentParameters) != null;
        }
    }
}

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
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using System;
using System.Security;

namespace Microsoft.Azure.Commands.ScenarioTest.Mocks
{
    public class MockServicePrincipalAuthenticationFactory : MockTokenAuthenticationFactory
    {
        private string servicePrincipal;

        private SecureString password;

        private AdalTokenProvider adalTokenProvider;

        public MockServicePrincipalAuthenticationFactory(string spn, SecureString password, string accessToken = null) : base(spn, accessToken)
        {
            this.servicePrincipal = spn;
            this.password = password;
        }

        public override IAccessToken Authenticate(AzureAccount account, AzureEnvironment environment, string tenant, SecureString password, ShowDialog promptBehavior, AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            return Authenticate(account, environment, tenant, password, promptBehavior, null, resourceId);
        }

        public override IAccessToken Authenticate(AzureAccount account, AzureEnvironment environment, string tenant, SecureString password, ShowDialog promptBehavior, TokenCache tokenCache, AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record && resourceId == AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId)
            {
                if (this.adalTokenProvider == null)
                {
                    this.adalTokenProvider = new AdalTokenProvider();
                }

                var configuration = GetAdalConfiguration(environment, tenant, resourceId, tokenCache);
                return this.adalTokenProvider.GetAccessToken(configuration, ShowDialog.Never, this.servicePrincipal, this.password, AzureAccount.AccountType.ServicePrincipal);
            }

            return base.Authenticate(account, environment, tenant, password, promptBehavior, tokenCache, resourceId);
        }

        private AdalConfiguration GetAdalConfiguration(AzureEnvironment environment, string tenantId,
            AzureEnvironment.Endpoint resourceId, TokenCache tokenCache)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }

            var adEndpoint = environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory];
            if (string.IsNullOrWhiteSpace(adEndpoint))
            {
                throw new ArgumentOutOfRangeException("environment", string.Format("No Active Directory endpoint specified for environment '{0}'", environment.Name));
            }

            var audience = environment.Endpoints[resourceId];
            if (string.IsNullOrWhiteSpace(audience))
            {
                throw new ArgumentOutOfRangeException("environment", string.Format("No {1} endpoint specified for environment '{0}'", environment.Name, resourceId));
            }

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

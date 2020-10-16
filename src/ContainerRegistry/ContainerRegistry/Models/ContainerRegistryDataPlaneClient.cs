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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class ContainerRegistryDataPlaneClient
    {
        private AzureContainerRegistryClient _client;
        private ServiceClientCredentials _clientCredential;
        private IAccessToken _accessToken;
        private string _endPoint;
        private const string _grantType = "access_token";
        private const string _scope = "registry:catalog:*";
        private const string _https = "https://";
        private readonly string _suffix;

        public Action<string> VerboseLogger { get; set; }
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }

        public ContainerRegistryDataPlaneClient(IAzureContext context)
        {
            _clientCredential = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager);
            _accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(context.Account, context.Environment, context.Tenant.Id, null, ShowDialog.Never, null, context.Environment.GetTokenAudience(AzureEnvironment.Endpoint.ResourceManager));
            _suffix = context.Environment.ContainerRegistryEndpointSuffix;
            _client = AzureSession.Instance.ClientFactory.CreateCustomArmClient<AzureContainerRegistryClient>(_clientCredential);
        }

        public string GetRefreshToken()
        {
            var response = _client.RefreshTokens.GetFromExchangeAsync(grantType: _grantType, service: _endPoint, accessToken: _accessToken.AccessToken);
            return response.Result.RefreshTokenProperty;
        }

        public string GetAccessToken()
        {
            var response = _client.AccessTokens.GetAsync(service: _endPoint, scope: _scope, refreshToken: GetRefreshToken());
            return response.Result.AccessTokenProperty;
        }

        public void SetEndPoint(string RegistryName)
        {
            _endPoint = RegistryName.ToLower() + '.' + _suffix;
            _client.LoginUri = _https + _endPoint;
        }

        public string GetEndPoint()
        {
            return _endPoint;
        }

        public Rest.Azure.AzureOperationResponse CheckRegistry()
        {
            return _client.V2Support.CheckWithHttpMessagesAsync().Result;
        }
    }
}

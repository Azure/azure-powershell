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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class ManagedServiceAccessToken : IAccessToken
    {
        IAzureAccount _account;
        string _tenant;
        string _resourceId;
        IHttpOperations<ManagedServiceTokenInfo> _tokenGetter;
        DateTime _expiration = DateTime.UtcNow;
        string _accessToken;
        string _requestUri;

        public ManagedServiceAccessToken(IAzureAccount account, IAzureEnvironment environment, string resourceId, string tenant = "Common")
        {
            if (account == null || string.IsNullOrEmpty(account.Id) || !account.IsPropertySet(AzureAccount.Property.MSILoginUri))
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (string.IsNullOrWhiteSpace(tenant))
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            _account = account;
            _resourceId = GetResource(resourceId, environment);
            var baseUri = _account.GetProperty(AzureAccount.Property.MSILoginUri);
            var builder = new UriBuilder(baseUri);
            builder.Query = string.Format("resource={0}", Uri.EscapeDataString(_resourceId));
            _requestUri = builder.Uri.ToString();
            _tenant = tenant;
            IHttpOperationsFactory factory;
            if (!AzureSession.Instance.TryGetComponent(HttpClientOperationsFactory.Name, out factory))
            {
                factory = HttpClientOperationsFactory.Create();
            }

            _tokenGetter = factory.GetHttpOperations<ManagedServiceTokenInfo>().WithHeader("Metadata", new[] { "true" });
        }

        public string AccessToken
        {
            get
            {
                try
                {
                    GetOrRenewAuthentication();
                }
                catch (HttpRequestException httpException)
                {
                    throw new InvalidOperationException(string.Format(Resources.MSITokenRequestFailed, _resourceId, _requestUri), httpException);
                }

                return _accessToken;
            }
        }

        public string LoginType => "ManagedService";

        public string TenantId => _tenant;

        public string UserId => _account.Id;

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            authTokenSetter("Bearer", AccessToken);
        }

        void GetOrRenewAuthentication()
        {
            if (_expiration - DateTime.UtcNow < TimeSpan.FromMinutes(5))
            {
                var info = _tokenGetter.GetAsync(_requestUri, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                SetToken(info);
            }
        }

        void SetToken(ManagedServiceTokenInfo info)
        {
            _expiration = DateTime.UtcNow + TimeSpan.FromSeconds(info.ExpiresIn);
            _accessToken = info.AccessToken;
        }

        string GetResource(string endpointOrResource, IAzureEnvironment environment)
        {
            return environment.GetEndpoint(endpointOrResource) ?? endpointOrResource;
        }
    }
}

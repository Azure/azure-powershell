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
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text;
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
            var idType = GetIdentityType(account);
            foreach (var uri in BuildTokenUri(_account.GetProperty(AzureAccount.Property.MSILoginUri), account, idType, _resourceId))
            {
                RequestUris.Enqueue(uri);
            }

            if (account.IsPropertySet(AzureAccount.Property.MSILoginUriBackup))
            {
                foreach (var uri in BuildTokenUri(_account.GetProperty(AzureAccount.Property.MSILoginUriBackup), account, idType, _resourceId))
                {
                    RequestUris.Enqueue(uri);
                }
            }

            _tenant = tenant;
            IHttpOperationsFactory factory;
            if (!AzureSession.Instance.TryGetComponent(HttpClientOperationsFactory.Name, out factory))
            {
                factory = HttpClientOperationsFactory.Create();
            }

            _tokenGetter = factory.GetHttpOperations<ManagedServiceTokenInfo>(true).WithHeader("Metadata", new[] { "true" });
        }

        public string AccessToken
        {
            get
            {
                try
                {
                    GetOrRenewAuthentication();
                }
                catch (CloudException httpException)
                {
                    throw new InvalidOperationException(string.Format(Resources.MSITokenRequestFailed, _resourceId, httpException?.Request?.RequestUri?.ToString()), httpException);
                }

                return _accessToken;
            }
        }

        public Queue<string> RequestUris { get; } = new Queue<string>();

        public string LoginType => "ManagedService";

        public string TenantId => _tenant;

        public string UserId => _account.Id;

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            authTokenSetter("Bearer", AccessToken);
        }

        void GetOrRenewAuthentication()
        {
            if (_expiration - DateTime.UtcNow < ManagedServiceTokenInfo.TimeoutThreshold)
            {
                ManagedServiceTokenInfo info = null;
                while (info == null && RequestUris.Count > 0)
                {
                    var currentRequestUri = RequestUris.Dequeue();
                    try
                    {
                        info = _tokenGetter.GetAsync(currentRequestUri, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                        // if a request was succesful, we should not check any other Uris
                        RequestUris.Clear();
                        RequestUris.Enqueue(currentRequestUri);
                    }
                    catch (CloudException) when (RequestUris.Count > 0)
                    {
                        // do nothing
                    }
                }
                SetToken(info);
            }
        }

        void SetToken(ManagedServiceTokenInfo info)
        {
            if (info != null)
            {
                _expiration = DateTime.UtcNow + TimeSpan.FromSeconds(info.ExpiresIn);
                _accessToken = info.AccessToken;
            }
        }

        static IdentityType GetIdentityType(IAzureAccount account)
        {
            if (account == null || string.IsNullOrWhiteSpace(account.Id) || account.Id.Contains("@"))
            {
                return IdentityType.SystemAssigned;
            }

            if (account.Id.Contains("/"))
            {
                return IdentityType.Resource;
            }

            return IdentityType.ClientId;
        }

        static string GetResource(string endpointOrResource, IAzureEnvironment environment)
        {
            return environment.GetEndpoint(endpointOrResource) ?? endpointOrResource;
        }

        static IEnumerable<string> BuildTokenUri(string baseUri, IAzureAccount account, IdentityType identityType, string resourceId)
        {
            UriBuilder builder = new UriBuilder(baseUri);
            builder.Query = BuildTokenQuery(account, identityType, resourceId);
            yield return builder.Uri.ToString();

            if (identityType == IdentityType.ClientId)
            {
                builder = new UriBuilder(baseUri);
                builder.Query = BuildTokenQuery(account, IdentityType.ObjectId, resourceId);
                yield return builder.Uri.ToString();
            }
        }

        static string BuildTokenQuery(IAzureAccount account, IdentityType idType, string resource)
        {
            StringBuilder query = new StringBuilder($"resource={Uri.EscapeDataString(resource)}");
            switch (idType)
            {
                case IdentityType.Resource:
                    query.Append($"&msi_res_id={Uri.EscapeDataString(account.Id)}");
                    break;
                case IdentityType.ClientId:
                    query.Append($"&client_id={Uri.EscapeDataString(account.Id)}");
                    break;
                case IdentityType.ObjectId:
                    query.Append($"&object_id={Uri.EscapeDataString(account.Id)}");
                    break;
            }

            query.Append("&api-version=2018-02-01");
            return query.ToString();
        }

        enum IdentityType
        {
            Resource,
            ClientId,
            ObjectId,
            SystemAssigned
        }
    }
}

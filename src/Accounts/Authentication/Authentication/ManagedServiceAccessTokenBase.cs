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
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public abstract class ManagedServiceAccessTokenBase<TManagedServiceTokenInfo> : IRenewableToken where TManagedServiceTokenInfo : class, ICacheable
    {
        protected readonly IAzureAccount Account;
        protected readonly string Tenant;
        protected readonly string ResourceId;
        protected readonly IHttpOperations<TManagedServiceTokenInfo> TokenGetter;
        protected DateTimeOffset Expiration = DateTimeOffset.Now;
        protected string accessToken;

        protected ManagedServiceAccessTokenBase(IAzureAccount account, IAzureEnvironment environment, string resourceId, string tenant = "organizations")
        {
            if (string.IsNullOrEmpty(account?.Id) || !account.IsPropertySet(AzureAccount.Property.MSILoginUri))
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

            Account = account;
            ResourceId = GetResource(resourceId, environment);
            var idType = GetIdentityType(account);
            foreach (var uri in BuildTokenUri(Account.GetProperty(AzureAccount.Property.MSILoginUri), account, idType, ResourceId))
            {
                RequestUris.Enqueue(uri);
            }

            if (account.IsPropertySet(AzureAccount.Property.MSILoginUriBackup))
            {
                foreach (var uri in BuildTokenUri(Account.GetProperty(AzureAccount.Property.MSILoginUriBackup), account, idType, ResourceId))
                {
                    RequestUris.Enqueue(uri);
                }
            }

            Tenant = tenant;
            if (!AzureSession.Instance.TryGetComponent(HttpClientOperationsFactory.Name, out IHttpOperationsFactory factory))
            {
                factory = HttpClientOperationsFactory.Create();
            }

            TokenGetter = factory.GetHttpOperations<TManagedServiceTokenInfo>(true).WithHeader("Metadata", new[] { "true" });
            if (account.IsPropertySet(AzureAccount.Property.MSILoginSecret))
            {
                TokenGetter = TokenGetter.WithHeader("Secret", new[] { account.GetProperty(AzureAccount.Property.MSILoginSecret) });
            }
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
                    throw new InvalidOperationException(string.Format(Resources.MSITokenRequestFailed, ResourceId, httpException?.Request?.RequestUri?.ToString()), httpException);
                }

                return accessToken;
            }
        }

        public Queue<string> RequestUris { get; } = new Queue<string>();

        public string LoginType => "ManagedService";

        public string TenantId => Tenant;

        public string UserId => Account.Id;

        public DateTimeOffset ExpiresOn => Expiration;

        public void AuthorizeRequest(Action<string, string> authTokenSetter)
        {
            authTokenSetter("Bearer", AccessToken);
        }

        private void GetOrRenewAuthentication()
        {
            if (Expiration - DateTimeOffset.Now < ManagedServiceTokenInfo.TimeoutThreshold)
            {
                TManagedServiceTokenInfo info = null;
                while (info == null && RequestUris.Count > 0)
                {
                    var currentRequestUri = RequestUris.Dequeue();
                    try
                    {
                        info = TokenGetter.GetAsync(currentRequestUri, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                        // if a request was succesful, we should not check any other Uris
                        RequestUris.Clear();
                        RequestUris.Enqueue(currentRequestUri);
                    }
                    catch (Exception e) when ( (e is CloudException || e is HttpRequestException) && RequestUris.Count > 0)
                    {
                        // skip to the next uri
                    }
                }

                SetToken(info);
            }
        }

        protected abstract void SetToken(TManagedServiceTokenInfo info);

        static IdentityType GetIdentityType(IAzureAccount account)
        {
            if (string.IsNullOrWhiteSpace(account?.Id) || account.Id.Contains("@"))
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

        protected virtual IEnumerable<string> BuildTokenUri(string baseUri, IAzureAccount account, IdentityType identityType, string resourceId)
        {
            var builder = new UriBuilder(baseUri) {Query = BuildTokenQuery(account, identityType, resourceId)};
            yield return builder.Uri.ToString();

            if (identityType == IdentityType.ClientId)
            {
                builder = new UriBuilder(baseUri) {Query = BuildTokenQuery(account, IdentityType.ObjectId, resourceId)};
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

        protected enum IdentityType
        {
            Resource,
            ClientId,
            ObjectId,
            SystemAssigned
        }
    }
}

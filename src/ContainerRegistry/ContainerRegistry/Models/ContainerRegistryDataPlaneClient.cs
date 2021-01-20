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
using Microsoft.Azure.Commands.ContainerRegistry.Models;
using Microsoft.Azure.Commands.ContainerRegistry.DataPlaneOperations;
using Microsoft.Azure.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class ContainerRegistryDataPlaneClient
    {
        private AzureContainerRegistryClient _client;
        private string _accessToken = default(string);
        private string _endPoint;
        private readonly string _suffix;

        private IAzureContext _context;
        private AcrTokenCacheComponents _tokenCacheComponent;

        private const string _grantType = "access_token";
        private const string _scopeDefault = "registry:catalog:*";
        private const string _https = "https://";
        private const string _refreshTokenKey = "AcrRefreshToken";
        private const string _acrTokenCacheKey = SharedComponentKeys.AcrTokenCacheKey;
        private const int _minutesBeforeExpiration = 5;


        public Action<string> VerboseLogger { get; set; }
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }

        public ContainerRegistryDataPlaneClient(IAzureContext context)
        {
            _context = context;
            _suffix = _context.Environment.ContainerRegistryEndpointSuffix;
            ServiceClientCredentials clientCredential = AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(_accessToken, () => _accessToken);
            _client = AzureSession.Instance.ClientFactory.CreateCustomArmClient<AzureContainerRegistryClient>(clientCredential);
        }

        public AzureContainerRegistryClient GetClient()
        {
            return _client;
        }

        public string TryAuthenticate(string scope = _scopeDefault)
        {
            _accessToken = TryGetToken(scope);
            return _accessToken;
        }

        private string TryGetToken(string key)
        {
            if (_tokenCacheComponent == null)
            {
                _tokenCacheComponent = new AcrTokenCacheComponents();
            }
            if (_tokenCacheComponent.GetComponent() == null)
            {
                _tokenCacheComponent.Register(_acrTokenCacheKey, AzureSession.Instance);
            }

            IDictionary<string, AcrToken> cache = _tokenCacheComponent.GetComponent();
            AcrToken value;
            cache.TryGetValue(key, out value);
            if (value == null || value.IsExpired(_minutesBeforeExpiration))
            {
                string token = key.Equals(_refreshTokenKey) ? getRefreshToken() : getAccessToken(key);
                value = new AcrToken(token);
                cache[key] = value;
            }
            return value.GetToken();
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
        
        private string getArmAccessToken()
        {
            return AzureSession
                   .Instance.AuthenticationFactory
                   .Authenticate(_context.Account, _context.Environment, _context.Tenant.Id, null, ShowDialog.Never, null, _context.Environment.GetTokenAudience(AzureEnvironment.Endpoint.ResourceManager))
                   .AccessToken;
        }

        private string getRefreshToken()
        {
            return GetClient()
                    .RefreshTokens
                    .GetFromExchangeAsync(grantType: _grantType, service: _endPoint, accessToken: getArmAccessToken())
                    .GetAwaiter()
                    .GetResult()
                    .RefreshTokenProperty;
        }

        private string getAccessToken(string scope)
        {
            return GetClient()
                    .AccessTokens
                    .GetAsync(service: _endPoint, scope: scope, refreshToken: TryGetToken(_refreshTokenKey))
                    .GetAwaiter()
                    .GetResult()
                    .AccessTokenProperty;
        }

        public PSRepositoryAttribute GetRepository(string repository)
        {
            return new ContainerRegistryRepositoryGetOperation(this, repository).ProcessRequest();
        }

        public IList<string> ListRepository(int? first)
        {
            return new ContainerRegistryRepositoryListOperation(this, first).ProcessRequest();
        }

        public PSDeletedRepository RemoveRepository(string repository)
        {
            return new ContainerRegistryRepositoryRemoveOperation(this, repository).ProcessRequest();
        }

        public PSRepositoryAttribute UpdateRepository(string repository, PSChangeableAttribute attribute)
        {
            new ContainerRegistryRepositoryUpdateOperation(this, repository, attribute).ProcessRequest();
            return GetRepository(repository);
        }

        public PSAcrManifest ListManifest(string repository)
        {
            return new ContainerRegistryManifestListOperation(this, repository).ProcessRequest();
        }

        public PSManifestAttribute GetManifest(string repository, string manifest)
        {
            return new ContainerRegistryManifestGetOperation(this, repository, manifest).ProcessRequest();
        }

        public PSManifestAttribute UpdateManifest(string repository, string manifest, PSChangeableAttribute attribute)
        {
            new ContainerRegistryManifestUpdateOperation(this, repository, manifest, attribute).ProcessRequest();
            return GetManifest(repository, manifest);
        }

        public PSManifestAttribute UpdateManifestByTag(string repository, string tag, PSChangeableAttribute attribute)
        {
            PSTagAttribute tagAttribute = GetTag(repository, tag);
            return UpdateManifest(repository, tagAttribute.Attributes.Digest, attribute);
        }

        public bool RemoveManifest(string repository, string manifest)
        {
            return new ContainerRegistryManifestRemoveOperation(this, repository, manifest).ProcessRequest();
        }

        public bool RemoveManifestByTag(string repository, string tag)
        {
            PSTagAttribute tagAttribute = GetTag(repository, tag);
            return RemoveManifest(repository, tagAttribute.Attributes.Digest);
        }

        public PSTagAttribute GetTag(string repository, string tag)
        {
            return new ContainerRegistryTagGetOperation(this, repository, tag).ProcessRequest();
        }

        public PSTagList ListTag(string repository)
        {
            return new ContainerRegistryTagListOperation(this, repository).ProcessRequest();
        }

        public bool RemoveTag(string repository, string tag)
        {
            return new ContainerRegistryTagRemoveOperation(this, repository, tag).ProcessRequest();
        }

        public PSTagAttribute UpdateTag(string repository, string tag, PSChangeableAttribute attribute)
        {
            new ContainerRegistryTagUpdateOperation(this, repository, tag, attribute).ProcessRequest();
            return GetTag(repository, tag);
        }
    }
}
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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public interface ITokenCacheItemProvider
    {
        string GetTokenFromTokenCache(TokenCache tokenCache, string uniqueId);

        string GetTokenFromTokenCache(TokenCache tokenCache, string uniqueId, string environmentName);
    }

    public class TokenCacheItemProvider : ITokenCacheItemProvider
    {
        public string GetTokenFromTokenCache(TokenCache tokenCache, string uniqueId)
        {
            return GetTokenFromTokenCache(tokenCache, uniqueId, null);
        }

        public string GetTokenFromTokenCache(TokenCache tokenCache, string uniqueId, string environmentName)
        {
            TokenCacheItem tokenCacheItem = null;
            if (string.IsNullOrEmpty(uniqueId))
            {
                var tokenCacheItems = tokenCache.ReadItems().Where(tokenItem => (string.IsNullOrEmpty(environmentName) || tokenItem.Resource.Contains(environmentName)));
                tokenCacheItem = tokenCacheItems.FirstOrDefault();
            }
            else
            {
                var tokenCacheItems = tokenCache.ReadItems().Where(tokenItem => tokenItem.UniqueId.Equals(uniqueId) && (string.IsNullOrEmpty(environmentName) || tokenItem.Resource.Contains(environmentName)));
                tokenCacheItem = tokenCacheItems.FirstOrDefault();
            }

            if (tokenCacheItem == null || string.IsNullOrEmpty(tokenCacheItem.AccessToken))
            {
                throw new PSInvalidOperationException(string.Format(Resources.NotLoggedInMessage, ""));
            }

            return tokenCacheItem.AccessToken;
        }
    }
}

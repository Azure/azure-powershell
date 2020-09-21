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
using System.Threading.Tasks;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public abstract class PowerShellTokenCacheProvider
    {
        public const string PowerShellTokenCacheProviderKey = "PowerShellTokenCacheProviderKey";
        protected const string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";

        protected byte[] _tokenCacheDataToFlush;

        public abstract byte[] ReadTokenData();

        public void UpdateTokenDataWithoutFlush(byte[] data)
        {
            _tokenCacheDataToFlush = data;
        }

        public virtual void FlushTokenData()
        {
            _tokenCacheDataToFlush = null;
        }

        public virtual void ClearCache()
        {
        }

        public bool TryRemoveAccount(string accountId)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public IEnumerable<IAccount> ListAccounts(string authority = null)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public List<IAccessToken> GetTenantTokensForAccount(IAccount account, IAzureEnvironment environment, Action<string> promptAction)
        {
            //TODO:
            throw new NotImplementedException();
        }

        public List<IAzureSubscription> GetSubscriptionsFromTenantToken(IAccount account, IAzureEnvironment environment, IAccessToken token, Action<string> promptAction)
        {
            //TODO:
            throw new NotImplementedException();
        }

        protected abstract void RegisterCache(IPublicClientApplication client);

        public virtual IPublicClientApplication CreatePublicClient()
        {
            var builder = PublicClientApplicationBuilder.Create(PowerShellClientId);

            var client = builder.Build();
            RegisterCache(client);
            return client;
        }

        public abstract Task<byte[]> ReadAsync();
        public abstract Task WriteAsync(byte[] bytes);

    }
}

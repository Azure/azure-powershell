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

using Azure.Identity;

using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class SharedTokenCacheProvider : PowerShellTokenCacheProvider
    {
        private static MsalCacheHelper _helper;
        private static readonly object _lock = new object();
        private byte[] AdalTokenCache { get; set; }

        private TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }

        public SharedTokenCacheProvider(byte[] adalTokenCache = null)
        {
            AdalTokenCache = adalTokenCache;
            TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
            {
                UnsafeAllowUnencryptedStorage = true
            };
        }

        public override byte[] ReadTokenData()
        {
            return GetCacheHelper().LoadUnencryptedTokenCache();
        }

        public override void FlushTokenData()
        {
            if (_tokenCacheDataToFlush != null)
            {
                GetCacheHelper().SaveUnencryptedTokenCache(_tokenCacheDataToFlush);
                base.FlushTokenData();
            }
        }

        /// <summary>
        /// Check if current environment support token cache persistence
        /// </summary>
        /// <returns></returns>
        public static bool SupportCachePersistence(out string message)
        {
            try
            {
                var cacheHelper = GetCacheHelper();
                cacheHelper.VerifyPersistence();
            }
            catch (MsalCachePersistenceException e)
            {
                message = e.Message;
                return false;
            }
            message = null;
            return true;
        }

        protected override void RegisterCache(IPublicClientApplication client)
        {
            if (AdalTokenCache != null && AdalTokenCache.Length > 0)
            {
                // register a one-time handler to deserialize token cache
                client.UserTokenCache.SetBeforeAccess((TokenCacheNotificationArgs args) =>
                {
                    try
                    {
                        args.TokenCache.DeserializeAdalV3(AdalTokenCache);
                    }
                    catch (Exception)
                    {
                        //TODO:
                    }
                    finally
                    {
                        AdalTokenCache = null;
                        var cacheHelper = GetCacheHelper();
                        cacheHelper.RegisterCache(client.UserTokenCache);
                    }
                });
            }
            else
            {
                var cacheHelper = GetCacheHelper();
                cacheHelper.RegisterCache(client.UserTokenCache);
            }
        }

        public override void ClearCache()
        {
            var client = CreatePublicClient();
            var accounts = client.GetAccountsAsync().GetAwaiter().GetResult();
            foreach (var account in accounts)
            {
                // RemoveAsync() removes all account information from MSAL's token cache
                // (this includes MSA - i.e. personal accounts - account info and other account information copied by MSAL into its cache).
                // Removes app-only (not OS-wide) accounts.
                // Apps cannot remove OS accounts. Only users can do that.
                // see https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/wam#removeasync
                client.RemoveAsync(account).GetAwaiter().GetResult();
            }
        }

        private static MsalCacheHelper GetCacheHelper()
        {
            if (_helper != null)
            {
                return _helper;
            }
            lock (_lock)
            {
                // Double check helper existence
                if (_helper == null)
                {
                    _helper = CreateCacheHelper();
                }
                return _helper;
            }
        }

        private static MsalCacheHelper CreateCacheHelper()
        {
            return MsalCacheHelperProvider.GetCacheHelper();
        }

        public override TokenCachePersistenceOptions GetTokenCachePersistenceOptions()
        {
            return TokenCachePersistenceOptions;
        }
    }
}

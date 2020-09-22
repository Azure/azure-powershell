using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Hyak.Common;

using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class SharedTokenCacheProvider : PowerShellTokenCacheProvider
    {
        private static MsalCacheHelper _helper;
        private static readonly object _lock = new object();
        private byte[] AdalTokenCache { get; set; }

        public SharedTokenCacheProvider(byte[] adalTokenCache = null)
        {
            AdalTokenCache = adalTokenCache;
        }

        public override Task<byte[]> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public override Task WriteAsync(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public override byte[] ReadTokenData()
        {
            return GetCacheHelper(PowerShellClientId).LoadUnencryptedTokenCache();
        }

        public override void FlushTokenData()
        {
            GetCacheHelper(PowerShellClientId).SaveUnencryptedTokenCache(_tokenCacheDataToFlush);
            base.FlushTokenData();
        }

        /// <summary>
        /// Check if current environment support token cache persistence
        /// </summary>
        /// <returns></returns>
        public static bool SupportCachePersistence(out string message)
        {
            try
            {
                var cacheHelper = GetCacheHelper(PowerShellClientId);
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
                        var cacheHelper = GetCacheHelper(client.AppConfig.ClientId);
                        cacheHelper.RegisterCache(client.UserTokenCache);
                    }
                });
            }
            else
            {
                var cacheHelper = GetCacheHelper(client.AppConfig.ClientId);
                cacheHelper.RegisterCache(client.UserTokenCache);
            }
        }

        private static MsalCacheHelper GetCacheHelper(String clientId)
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
                    _helper = CreateCacheHelper(clientId);
                }
                return _helper;
            }
        }

        private static MsalCacheHelper CreateCacheHelper(string clientId)
        {
            return MsalCacheHelperProvider.GetCacheHelper();
        }
    }
}

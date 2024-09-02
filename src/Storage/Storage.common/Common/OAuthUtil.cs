using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Storage.Auth;
using System;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    // Handle Track1 SDK OAuth token
    public static class OAuthUtil
    {
        public static TokenCredential getTokenCredential(IAzureContext DefaultContext, DebugLogWriter logWriter)
        {
            IAccessToken accessToken = OAuthUtil.CreateOAuthToken(DefaultContext);

            TokenCredential tokenCredential = new TokenCredential(OAuthUtil.GetTokenStrFromAccessToken(accessToken, logWriter), OAuthUtil.GetTokenRenewer(accessToken, logWriter), null, new TimeSpan(0, 1, 0));
            return tokenCredential;
        }

        public static RenewTokenFuncAsync GetTokenRenewer(IAccessToken accessToken, DebugLogWriter logWriter)
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            RenewTokenFuncAsync renewer = async (Object state, CancellationToken cancellationToken) =>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                var tokenStr = GetTokenStrFromAccessToken(accessToken, logWriter);
                return new NewTokenAndFrequency(tokenStr, new TimeSpan(0, 1, 0));
            };
            return renewer;
        }

        public static IAzureEnvironment EnsureStorageOAuthAudienceSet(IAzureEnvironment environment)
        {
            if (environment != null)
            {
                if (!environment.IsPropertySet(StorageOAuthEndpointResourceKey))
                {
                    environment.SetProperty(StorageOAuthEndpointResourceKey, StorageOAuthEndpointResourceValue);
                }
            }

            return environment;
        }

        /// <summary>
        /// Create a OAuth Token
        /// </summary>
        /// <returns>the token</returns>
        public static IAccessToken CreateOAuthToken(IAzureContext DefaultContext)
        {
            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException(Resources.ContextCannotBeNull);
            }

            IAccessToken accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
               DefaultContext.Account,
               EnsureStorageOAuthAudienceSet(DefaultContext.Environment),
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               StorageOAuthEndpointResourceKey);
            return accessToken;
        }

        /// <summary>
        /// Get the token string from the accesstoken
        /// </summary>
        /// <param name="accessToken">the token</param>
        /// <param name="logWriter"></param>
        /// <returns>token string</returns>
        public static string GetTokenStrFromAccessToken(IAccessToken accessToken, DebugLogWriter logWriter)
        {
            var tokenStr = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });
#if DEBUG            
            if (logWriter != null)
            {
                logWriter(DateTime.Now.ToString() + ": token:" + tokenStr);
            }
#endif
            return tokenStr;
        }
        /// <summary>
        /// The extension key to use for the storage token audience value
        /// </summary>
        public const string StorageOAuthEndpointResourceKey = "StorageOAuthEndpointResourceId";

        /// <summary>
        /// Default resourceId for storage OAuth tokens
        /// </summary>
        public const string StorageOAuthEndpointResourceValue = "https://storage.azure.com";

    }

}

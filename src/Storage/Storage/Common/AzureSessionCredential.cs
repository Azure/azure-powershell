﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    public delegate void DebugLogWriter(string log);
    public class AzureSessionCredential : TokenCredential
    {
        public AzureSessionCredential(IAzureContext DefaultContext, DebugLogWriter logWriter = null)
        {
            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException(Resources.ContextCannotBeNull);
            }
            if (logWriter != null)
            {
                this.debugLogWriter = logWriter;
            }

            IAccessToken accessToken1 = AzureSession.Instance.AuthenticationFactory.Authenticate(
               DefaultContext.Account,
               EnsureStorageOAuthAudienceSet(DefaultContext.Environment),
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               StorageOAuthEndpointResourceKey);
            accessToken =  accessToken1;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken token;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = new AccessToken(tokenValue, DateTimeOffset.UtcNow);
            });
            if (this.debugLogWriter != null)
            {
                this.debugLogWriter("[" + DateTime.Now.ToString() + "] GetToken: " + token.Token);
            }
            return token;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken token;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = new AccessToken(tokenValue, DateTimeOffset.UtcNow);
            });

            if (this.debugLogWriter != null)
            {
                this.debugLogWriter("[" + DateTime.Now.ToString() + "] GetTokenAsync: " + token.Token);
            }
            return new ValueTask<AccessToken>(token);
        }

        private IAzureEnvironment EnsureStorageOAuthAudienceSet(IAzureEnvironment environment)
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
        /// The extension key to use for the storage token audience value
        /// </summary>
        public const string StorageOAuthEndpointResourceKey = "StorageOAuthEndpointResourceId";

        /// <summary>
        /// Default resourceId for storage OAuth tokens
        /// </summary>
        public const string StorageOAuthEndpointResourceValue = "https://storage.azure.com";


        private IAccessToken accessToken;
        private DebugLogWriter debugLogWriter = null;
    }

}

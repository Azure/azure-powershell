using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.Properties;

namespace Microsoft.Azure.Commands.Synapse.Common
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
               DefaultContext.Environment,
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               AzureEnvironment.ExtendedEndpoint.AzureSynapseAnalyticsEndpointResourceId);
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

        /// <summary>
        /// The extension key to use for the synapse token audience value
        /// </summary>
        public const string SynapseOAuthEndpointResourceKey = "SynapseOAuthEndpointResourceKey";

        /// <summary>
        /// Default resourceId for synapse OAuth tokens
        /// </summary>
        public const string SynapseOAuthEndpointResourceValue = "https://dev.azuresynapse.net";


        private IAccessToken accessToken;
        private DebugLogWriter debugLogWriter = null;
    }

}

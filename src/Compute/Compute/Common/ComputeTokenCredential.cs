using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Compute.Common
{
    public class ComputeTokenCredential : TokenCredential
    {
        public IAccessToken accessToken { get; set; }
        public ComputeTokenCredential(IAzureContext DefaultContext, string customAudience)
        {

            if (DefaultContext == null || DefaultContext.Account == null)
            {
                throw new InvalidOperationException();
            }

            IAccessToken accessToken1 = AzureSession.Instance.AuthenticationFactory.Authenticate(
                   DefaultContext.Account,
                   EnsureCustomAudienceSet(DefaultContext.Environment, customAudience),
                   DefaultContext.Tenant.Id,
                   null,
                   ShowDialog.Never,
                   null,
                   customAudience);

            accessToken = accessToken1;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            AccessToken token;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                token = new AccessToken(tokenValue, DateTimeOffset.UtcNow);
            });
            return token;
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }

        private IAzureEnvironment EnsureCustomAudienceSet(IAzureEnvironment environment, string customAudience)
        {
            if (environment != null)
            {
                if (!environment.IsPropertySet(customAudience))
                {
                    environment.SetProperty(customAudience, customAudience);
                }
            }
            return environment;
        }
    }
}
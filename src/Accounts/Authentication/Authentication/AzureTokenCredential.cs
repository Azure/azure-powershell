using Azure.Core;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication.Authentication
{
    public class AzureTokenCredential : TokenCredential
    {
        public string TenantId { get; private set; }

        public delegate string TokenAccessor(IAzureAccount account, string targetEndpoint);

        TokenAccessor _tokenAccessor;
        IAzureAccount _account;
        string _targetEndpoint;
        IAccessToken _accessToken;
        public AzureTokenCredential(IAccessToken accessToken)
        {
            _accessToken = accessToken;            
        }

        public AzureTokenCredential(IAzureAccount account, string targetEndpoint, TokenAccessor getToken)
        {
            _tokenAccessor = getToken;
            _account = account;
            _targetEndpoint = targetEndpoint;
        }
        
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            /*_accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                requestContext.Headers.Authorization = new AuthenticationHeaderValue(tokenType, tokenValue);
            });*/

            return new AccessToken(_tokenAccessor(_account, _targetEndpoint), DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}

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

        private readonly Func<string> _getTokenImpl;

        internal string AccessToken;
      
        public AzureTokenCredential(string accessToken, Func<string>  GetTokenImpl = null)
        {
            AccessToken = accessToken;
            _getTokenImpl = GetTokenImpl;
        }
        
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken( (_getTokenImpl == null) ? AccessToken : _getTokenImpl(), DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}

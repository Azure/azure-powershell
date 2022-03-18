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
        public string AccessToken { get; set; }

        private readonly Func<string> GetTokenImpl;

        public AzureTokenCredential(string accessToken, Func<string> getTokenImpl = null)
        {
            AccessToken = accessToken;
            GetTokenImpl = getTokenImpl;
        }
        
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(GetTokenImpl == null ? AccessToken : GetTokenImpl(), 
                DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}

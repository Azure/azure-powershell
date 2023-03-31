using Azure.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    public class UserSuppliedCredential : TokenCredential
    {
        public string UserToken { get; set; }
        public DateTimeOffset ExpirationOffset { get; set; }
        public UserSuppliedCredential(string user_token, DateTimeOffset time)
        {
            UserToken = user_token;
            ExpirationOffset = time;
        }
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return new AccessToken(UserToken, ExpirationOffset);
        }
        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return new ValueTask<AccessToken>(new AccessToken(UserToken, ExpirationOffset));
        }
    }
}

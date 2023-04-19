using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Commands.CodeSigning.Models
{
    internal class UserSuppliedCredential : TokenCredential
    {
        private readonly CodeSigningServiceCredential codeSigningServiceCredential;

        public UserSuppliedCredential(CodeSigningServiceCredential codeSigningServiceCredential)
        {
            this.codeSigningServiceCredential = codeSigningServiceCredential;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(codeSigningServiceCredential.GetToken(), DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}

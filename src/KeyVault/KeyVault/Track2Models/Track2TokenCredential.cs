using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2TokenCredential : TokenCredential
    {
        private readonly DataServiceCredential dataServiceCredential;

        public Track2TokenCredential(DataServiceCredential dataServiceCredential)
        {
            this.dataServiceCredential = dataServiceCredential;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(dataServiceCredential.GetToken(), DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}
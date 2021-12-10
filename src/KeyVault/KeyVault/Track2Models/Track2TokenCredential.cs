using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2TokenCredential : TokenCredential
    {
        private readonly string _token;

        public Track2TokenCredential(DataServiceCredential dataServiceCredential)
        {
            this._token = dataServiceCredential.GetToken();
        }

        public Track2TokenCredential(string token)
        {
            this._token = token;
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new AccessToken(_token, DateTimeOffset.UtcNow);
        }

        public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return new ValueTask<AccessToken>(this.GetToken(requestContext, cancellationToken));
        }
    }
}
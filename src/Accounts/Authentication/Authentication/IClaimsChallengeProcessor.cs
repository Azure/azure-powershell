using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public interface IClaimsChallengeProcessor
    {
        ValueTask<bool> OnClaimsChallenageAsync(HttpRequestMessage request, string claimsChallenge, string wwwAuthenticateInfo, CancellationToken cancellationToken);
    }
}

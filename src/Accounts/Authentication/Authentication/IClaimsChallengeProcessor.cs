using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public interface IClaimsChallengeProcessor
    {
        ValueTask<bool> OnClaimsChallenageAsync(HttpRequestMessage request, string claimsChallenge, string wwwAuthenticateInfo, CancellationToken cancellationToken);
    }
}

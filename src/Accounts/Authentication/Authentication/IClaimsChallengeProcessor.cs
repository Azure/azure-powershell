// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// Processor to handle claims changllenge
    /// </summary>
    public interface IClaimsChallengeProcessor
    {
        /// <summary>
        /// Handle the clamin challenge
        /// </summary>
        /// <param name="request">The origin request that responds with a claim challenge</param>
        /// <param name="claimsChallenge">Claims challenge string</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>Successful or not</returns>
        ValueTask<bool> OnClaimsChallenageAsync(HttpRequestMessage request, string claimsChallenge, CancellationToken cancellationToken);
    }
}

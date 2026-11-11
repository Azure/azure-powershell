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
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Attestation.Test.UnitTests
{
    public class AttestationTokenCredentialTests
    {
        private static readonly TokenRequestContext Context = new TokenRequestContext(new[] { "https://attest.azure.net/.default" });

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InterfaceNameMatchesAzAccounts()
        {
            Assert.Equal(AttestationTokenCredential.ClaimsChallengeProcessorInterface, typeof(IClaimsChallengeProcessor).FullName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsTokenFromServiceClientCredentials()
        {
            var credentials = new FakeCredentials();
            var token = new AttestationTokenCredential(credentials).GetToken(Context, CancellationToken.None);

            Assert.Equal("initial-token", token.Token);
            Assert.Null(credentials.ReceivedClaims);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ForwardsClaimsChallengeToCredentials()
        {
            var credentials = new FakeCredentials();
            var claims = "{\"access_token\":{\"nbf\":{\"essential\":true,\"value\":\"1700000000\"}}}";
            var token = await new AttestationTokenCredential(credentials).GetTokenAsync(
                new TokenRequestContext(Context.Scopes, claims: claims), CancellationToken.None);

            Assert.Equal("token-with-claims", token.Token);
            Assert.Equal(claims, credentials.ReceivedClaims);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task IgnoresClaimsWhenCredentialsCannotProcessThem()
        {
            var token = await new AttestationTokenCredential(new TokenOnlyCredentials()).GetTokenAsync(
                new TokenRequestContext(Context.Scopes, claims: "{}"), CancellationToken.None);

            Assert.Equal("initial-token", token.Token);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ForwardsClaimsChallengeThroughAzAccountsCredential()
        {
            // RenewingTokenCredential is what GetServiceClientCredentials returns for signed-in accounts.
            var accessToken = new FakeAccessToken();
            var credential = new AttestationTokenCredential(new RenewingTokenCredential(accessToken));

            var token = await credential.GetTokenAsync(new TokenRequestContext(Context.Scopes, claims: "{\"claims\":1}"), CancellationToken.None);

            Assert.Equal("token-with-claims", token.Token);
            Assert.Equal("{\"claims\":1}", accessToken.ReceivedClaims);
        }

        private class FakeAccessToken : IAccessToken, IClaimsChallengeProcessor
        {
            public string ReceivedClaims { get; private set; }

            public string AccessToken { get; private set; } = "initial-token";

            public string UserId => "user";

            public string HomeAccountId => "home";

            public string TenantId => "tenant";

            public string LoginType => "User";

            public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get; } = new System.Collections.Generic.Dictionary<string, string>();

            public void AuthorizeRequest(System.Action<string, string> authTokenSetter) => authTokenSetter("Bearer", AccessToken);

            public ValueTask<bool> OnClaimsChallenageAsync(HttpRequestMessage request, string claimsChallenge, CancellationToken cancellationToken)
            {
                ReceivedClaims = claimsChallenge;
                AccessToken = "token-with-claims";
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                return new ValueTask<bool>(true);
            }
        }

        private class TokenOnlyCredentials : ServiceClientCredentials
        {
            public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "initial-token");
                return Task.CompletedTask;
            }
        }

        private class FakeCredentials : TokenOnlyCredentials, IClaimsChallengeProcessor
        {
            public string ReceivedClaims { get; private set; }

            public ValueTask<bool> OnClaimsChallenageAsync(HttpRequestMessage request, string claimsChallenge, CancellationToken cancellationToken)
            {
                ReceivedClaims = claimsChallenge;
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "token-with-claims");
                return new ValueTask<bool>(true);
            }
        }
    }
}

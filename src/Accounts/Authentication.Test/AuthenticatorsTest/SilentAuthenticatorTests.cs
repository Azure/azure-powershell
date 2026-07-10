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

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;

namespace Common.Authenticators.Test
{
    public class SilentAuthenticatorTests
    {
        private const string TestTenantId = "123";
        private const string TestResourceId = "ActiveDirectoryServiceEndpointResourceId";

        private const string fakeToken = "faketoken";

        private ITestOutputHelper Output { get; set; }

        class TokenCredentialMock : TokenCredential
        {
            public TokenRequestContext LastRequestContext { get; private set; }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                LastRequestContext = requestContext;
                return new AccessToken(fakeToken, DateTimeOffset.Now);
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                LastRequestContext = requestContext;
                return new ValueTask<AccessToken>(new AccessToken(fakeToken, DateTimeOffset.Now));
            }
        }

        public SilentAuthenticatorTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(AuthenticationTelemetry.Name, () => new AuthenticationTelemetry());
            // Reset agentic session tracking so each test starts from a known state.
            AgenticSession.ResetForTests();
            Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, null);
            Output = output;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task SimpleSilentAuthenticationTest()
        {
            var accountId = "testuser";

            //Setup
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateMsalSharedCacheCredential(
                    It.IsAny<IPublicClientApplication>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsNotNull<Func<OnBeforeTokenRequestData, Task>>(),
                    It.IsAny<string>()))
                .Returns(() => new TokenCredentialMock());
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(TestTenantId);

            var parameter = new SilentParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                accountId);

            //Run
            var authenticator = new SilentAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            mockAzureCredentialFactory.Verify();
            Assert.Equal(fakeToken, token.AccessToken);
            Assert.Equal(TestTenantId, token.TenantId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_ManualPlusManual_NeitherAddsClientSession()
        {
            using (new AgentSessionScope(null))
            {
                var callback = await RunSilentAndCaptureCallback();

                var firstRequest = await InvokeCallback(callback);
                var secondRequest = await InvokeCallback(callback);

                AssertNoClientSession(firstRequest);
                AssertNoClientSession(secondRequest);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_AgentPlusAgentSameSession_BothAddSameClientSession()
        {
            const string sessionId = "checkin-scenario-agent-agent";
            using (new AgentSessionScope(sessionId))
            {
                var callback = await RunSilentAndCaptureCallback();

                var firstRequest = await InvokeCallback(callback);
                var secondRequest = await InvokeCallback(callback);

                AssertClientSession(firstRequest, sessionId);
                AssertClientSession(secondRequest, sessionId);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_ManualThenAgent_OnlyAgentAddsClientSession()
        {
            const string sessionId = "checkin-scenario-manual-then-agent";

            OnBeforeTokenRequestData manualRequest;
            using (new AgentSessionScope(null))
            {
                var manualCallback = await RunSilentAndCaptureCallback();
                manualRequest = await InvokeCallback(manualCallback);
            }
            OnBeforeTokenRequestData agentRequest;
            using (new AgentSessionScope(sessionId))
            {
                var agentCallback = await RunSilentAndCaptureCallback();
                agentRequest = await InvokeCallback(agentCallback);
            }

            AssertNoClientSession(manualRequest);
            AssertClientSession(agentRequest, sessionId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_AgentThenManual_OnlyAgentAddsClientSession()
        {
            const string sessionId = "checkin-scenario-agent-then-manual";

            OnBeforeTokenRequestData agentRequest;
            using (new AgentSessionScope(sessionId))
            {
                var agentCallback = await RunSilentAndCaptureCallback();
                agentRequest = await InvokeCallback(agentCallback);
            }
            OnBeforeTokenRequestData manualRequest;
            using (new AgentSessionScope(null))
            {
                var manualCallback = await RunSilentAndCaptureCallback();
                manualRequest = await InvokeCallback(manualCallback);
            }

            AssertClientSession(agentRequest, sessionId);
            AssertNoClientSession(manualRequest);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_TwoDifferentSessions_EachAddsItsOwnClientSession()
        {
            const string sessionA = "checkin-scenario-agent-A";
            const string sessionB = "checkin-scenario-agent-B";

            OnBeforeTokenRequestData requestA;
            using (new AgentSessionScope(sessionA))
            {
                var callbackA = await RunSilentAndCaptureCallback();
                requestA = await InvokeCallback(callbackA);
            }
            OnBeforeTokenRequestData requestB;
            using (new AgentSessionScope(sessionB))
            {
                var callbackB = await RunSilentAndCaptureCallback();
                requestB = await InvokeCallback(callbackB);
            }

            AssertClientSession(requestA, sessionA);
            AssertClientSession(requestB, sessionB);
            Assert.NotEqual(
                requestA.BodyParameters[AgenticSession.ClientSessionParamName],
                requestB.BodyParameters[AgenticSession.ClientSessionParamName]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_SessionIdChangedAfterAuthenticate_CallbackUsesSnapshot()
        {
            const string capturedSession = "checkin-snapshot-captured";
            const string laterSession = "checkin-snapshot-changed-later";

            Func<OnBeforeTokenRequestData, Task> callback;
            using (new AgentSessionScope(capturedSession))
            {
                callback = await RunSilentAndCaptureCallback();
            }
            OnBeforeTokenRequestData request;
            using (new AgentSessionScope(laterSession))
            {
                request = await InvokeCallback(callback);
            }

            AssertClientSession(request, capturedSession);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_ManualMode_TokenRequestContextHasNoClaims()
        {
            using (new AgentSessionScope(null))
            {
                var (_, requestContext) = await RunSilentAndCaptureCallbackAndContext();
                Assert.True(string.IsNullOrEmpty(requestContext.Claims),
                    $"Expected no claims challenge in manual mode, got '{requestContext.Claims}'.");
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task AgenticScenario_AgentMode_TokenRequestContextCarriesXmsCliSidClaim()
        {
            const string sessionId = "checkin-claims-verification-01";
            using (new AgentSessionScope(sessionId))
            {
                var (_, requestContext) = await RunSilentAndCaptureCallbackAndContext();
                Assert.False(string.IsNullOrEmpty(requestContext.Claims),
                    "Expected a non-empty claims challenge in agentic mode.");
                Assert.Contains(AgenticSession.AgenticClaimName, requestContext.Claims);
                Assert.Contains(sessionId, requestContext.Claims);
                Assert.Equal(AgenticSession.BuildClaimsChallenge(sessionId), requestContext.Claims);
            }
        }

        private async Task<Func<OnBeforeTokenRequestData, Task>> RunSilentAndCaptureCallback()
        {
            var (callback, _) = await RunSilentAndCaptureCallbackAndContext();
            return callback;
        }

        private async Task<(Func<OnBeforeTokenRequestData, Task> Callback, TokenRequestContext RequestContext)> RunSilentAndCaptureCallbackAndContext()
        {
            Func<OnBeforeTokenRequestData, Task> captured = null;
            var mockCredential = new TokenCredentialMock();
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateMsalSharedCacheCredential(
                    It.IsAny<IPublicClientApplication>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsNotNull<Func<OnBeforeTokenRequestData, Task>>(),
                    It.IsAny<string>()))
                .Callback<IPublicClientApplication, string, string, string, Func<OnBeforeTokenRequestData, Task>, string>(
                    (_, _, _, _, cb, _) => captured = cb)
                .Returns(() => mockCredential);
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);

            var cacheProvider = new InMemoryTokenCacheProvider();
            var accountId = "testuser";
            var account = new AzureAccount { Id = accountId, Type = AzureAccount.AccountType.User };
            account.SetTenants(TestTenantId);

            var parameter = new SilentParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                accountId);

            await new SilentAuthenticator().Authenticate(parameter);
            return (captured, mockCredential.LastRequestContext);
        }

        private static async Task<OnBeforeTokenRequestData> InvokeCallback(Func<OnBeforeTokenRequestData, Task> callback)
        {
            var data = new OnBeforeTokenRequestData(
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
                new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/token"),
                CancellationToken.None);
            await callback(data);
            return data;
        }

        private static void AssertClientSession(OnBeforeTokenRequestData data, string expected)
        {
            Assert.True(data.BodyParameters.ContainsKey(AgenticSession.ClientSessionParamName),
                $"Expected client_session={expected} in body params");
            Assert.Equal(expected, data.BodyParameters[AgenticSession.ClientSessionParamName]);
        }

        private static void AssertNoClientSession(OnBeforeTokenRequestData data)
        {
            Assert.False(data.BodyParameters.ContainsKey(AgenticSession.ClientSessionParamName),
                "Expected no client_session in body params");
        }

        private sealed class AgentSessionScope : IDisposable
        {
            private readonly string _previous;
            public AgentSessionScope(string value)
            {
                _previous = Environment.GetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName);
                Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, value);
            }
            public void Dispose()
            {
                Environment.SetEnvironmentVariable(AgenticSession.AgentSessionIdEnvVarName, _previous);
            }
        }
    }
}

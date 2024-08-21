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
using Azure.Identity;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Management.Automation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class SilentReAuthByTenantCmdletTest
    {
        private GetAzureRMTenantCommandMock cmdlet;
        private Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
        private Mock<ISubscriptionClientWrapper> mockSubscriptionClient = new Mock<ISubscriptionClientWrapper>() { CallBase = true };
        private List<object> OutputPipeline = new List<object>();
        private List<string> DebugPipeline = new List<string>();
        private List<string> WarnPipeline = new List<string>();
        private AzureContext defaultContext;

        public delegate ValueTask<AccessToken> AccquireToken(int times);
        public delegate HttpResponseMessage GetResponse(int times);

        private const string fakeToken = "fakertoken";

        private const string body200 = @"{{""value"":[{{""id"":""/tenants/{0}"",""tenantId"":""{0}"",""countryCode"":""US"",""displayName"":""AzureSDKTeam"",""domains"":[""AzureSDKTeam.onmicrosoft.com"",""azdevextest.com""],""tenantCategory"":""Home""}}]}}";
        private const string body401 = @"{""error"":{""code"":""AuthenticationFailed"",""message"":""Authentication failed.""}}";
        private const string WwwAuthenticateIP = @"Bearer authorization_uri=""https://login.windows.net/"", error=""invalid_token"", error_description=""Tenant IP Policy validate failed."", claims=""eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNjEzOTgyNjA2In0sInhtc19ycF9pcGFkZHIiOnsidmFsdWUiOiIxNjcuMjIwLjI1NS40MSJ9fX0=""";

        XunitTracingInterceptor xunitLogger;

        public class GetAzureRMTenantCommandMock : GetAzureRMTenantCommand
        {
            public RMProfileClient profileClient = null;

            public override void ExecuteCmdlet()
            {
                WriteObject(profileClient?.ListTenants(TenantId).Select((t) => new PSAzureTenant(t)), enumerateCollection: true);
            }
        }

        class TokenCredentialMock : TokenCredential
        {
            private AccquireToken accquireToken;
            private int times = 0;
            public TokenCredentialMock(AccquireToken accquire)
            {
                accquireToken = accquire;
            }
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                var result = accquireToken(times);
                ++times;
                return result;
            }
        }

        class HttpMockHandler : DelegatingHandler, ICloneable
        {
            private GetResponse getResponse;
            private int times = 0;

            public HttpMockHandler(GetResponse get)
            {
                getResponse = get;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                await base.SendAsync(request, cancellationToken);
                var result = getResponse(times);
                ++times;
                return result;
            }

            public virtual object Clone()
            {
                return new HttpMockHandler(this.getResponse);
            }
        }

        public SilentReAuthByTenantCmdletTest(ITestOutputHelper output)
        {
            ResourceManagerProfileProvider.InitializeResourceManagerProfile();
            xunitLogger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(xunitLogger);

            commandRuntimeMock.Setup(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>())).Callback(
                (Object o, bool enumerateCollection) =>
                {
                    if (enumerateCollection)
                    {
                        IEnumerable<object> objects = o as IEnumerable<object>;
                        objects?.ForEach(e => OutputPipeline.Add(e));
                    }
                    else
                    {
                        OutputPipeline.Add(o);
                    }
                });

            commandRuntimeMock.Setup(f => f.WriteDebug(It.IsAny<string>())).Callback((string message) => DebugPipeline.Add(message));

            commandRuntimeMock.Setup(f => f.WriteWarning(It.IsAny<string>())).Callback((string message) => WarnPipeline.Add(message));

            cmdlet = new GetAzureRMTenantCommandMock()
            {
                CommandRuntime = commandRuntimeMock.Object,
            };

            var sub = new AzureSubscription()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test subscription"
            };
            defaultContext = new AzureContext(sub,
                new AzureAccount() { Id = "admin@contoso.com", Type = AzureAccount.AccountType.User },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant() { Id = Guid.NewGuid().ToString() });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SilentReauthenticateFailure()
        {
            try
            {
                // Setup
                InitializeSession();
                var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
                mockAzureCredentialFactory.Setup(f => f.CreateSharedTokenCacheCredentials(It.IsAny<SharedTokenCacheCredentialOptions>())).Returns(() => new TokenCredentialMock(
                    (times) =>
                    {
                        if (times < 1)
                        {
                            return new ValueTask<AccessToken>(new AccessToken(fakeToken, DateTimeOffset.Now.AddHours(1)));
                        }
                        throw new CredentialUnavailableException("Exception from Azure Identity.");
                    }
                    ));
                AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
                AzureSession.Instance.ClientFactory.AddHandler(new HttpMockHandler(
                    (times) =>
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                        {
                            Content = new StringContent(body401, Encoding.UTF8, "application/json"),
                        };
                        response.Headers.Add("WWW-Authenticate", WwwAuthenticateIP);
                        return response;
                    }));

                cmdlet.TenantId = Guid.NewGuid().ToString();

                // Act
                cmdlet.InvokeBeginProcessing();
                AuthenticationFailedException e = Assert.Throws<AuthenticationFailedException>(() => cmdlet.ExecuteCmdlet());
                string errorMessage = $"Exception from Azure Identity.{Environment.NewLine}authorization_uri: https://login.windows.net/{Environment.NewLine}error: invalid_token{Environment.NewLine}error_description: Tenant IP Policy validate failed.{Environment.NewLine}claims: eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNjEzOTgyNjA2In0sInhtc19ycF9pcGFkZHIiOnsidmFsdWUiOiIxNjcuMjIwLjI1NS40MSJ9fX0={Environment.NewLine}";
                Assert.Equal(errorMessage, e.Message);
                cmdlet.InvokeEndProcessing();
            }
            finally
            {
                //Dispose
                AzureSessionInitializer.CreateOrReplaceSession(new MemoryDataStore());
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SilentReauthenticateSuccess()
        {
            try
            {
                // Setup
                InitializeSession();
                cmdlet.TenantId = Guid.NewGuid().ToString();
                var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
                mockAzureCredentialFactory.Setup(f => f.CreateSharedTokenCacheCredentials(It.IsAny<SharedTokenCacheCredentialOptions>())).Returns(() => new TokenCredentialMock(
                    (firstTime) =>
                    {
                        return new ValueTask<AccessToken>(new AccessToken(fakeToken, DateTimeOffset.Now.AddHours(1)));
                    }));

                AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
                AzureSession.Instance.ClientFactory.AddHandler(new HttpMockHandler(
                    (times) =>
                    {
                        HttpResponseMessage response = null;
                        if (times == 0)
                        {
                            response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                            {
                                Content = new StringContent(body401, Encoding.UTF8, "application/json"),
                            };
                            response.Headers.Add("WWW-Authenticate", WwwAuthenticateIP);
                        }
                        else
                        {
                            response = new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent(string.Format(body200, cmdlet.TenantId), Encoding.UTF8, "application/json"),
                            };
                        }
                        return response;
                    }));

                // Act
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();

                //Verify
                Assert.Single(OutputPipeline);
                Assert.True(OutputPipeline.First() is PSAzureTenant);
                Assert.Equal(cmdlet.TenantId, ((PSAzureTenant)OutputPipeline.First()).Id.ToString());
                Assert.Equal(2, ((PSAzureTenant)OutputPipeline.First()).Domains.Length);
                Assert.Equal("AzureSDKTeam.onmicrosoft.com,azdevextest.com", string.Join(",", ((PSAzureTenant)OutputPipeline.First()).Domains));
                Assert.Equal("Home", ((PSAzureTenant)OutputPipeline.First()).TenantCategory);
            }
            finally
            {
                //Dispose
                AzureSessionInitializer.CreateOrReplaceSession(new MemoryDataStore());
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NormalCase()
        {
            try
            {
                // Setup
                InitializeSession();
                cmdlet.TenantId = Guid.NewGuid().ToString();
                var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
                mockAzureCredentialFactory.Setup(f => f.CreateSharedTokenCacheCredentials(It.IsAny<SharedTokenCacheCredentialOptions>())).Returns(() => new TokenCredentialMock(
                    (times) =>
                    {
                        return new ValueTask<AccessToken>(new AccessToken(fakeToken, DateTimeOffset.Now.AddHours(1)));
                    }));

                AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
                AzureSession.Instance.ClientFactory.AddHandler(new HttpMockHandler(
                    (times) =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(string.Format(body200, cmdlet.TenantId), Encoding.UTF8, "application/json"),
                        };
                        return response;
                    }));

                // Act
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();

                //Verify
                Assert.Single(OutputPipeline);
                Assert.True(OutputPipeline.First() is PSAzureTenant);
                Assert.Equal(cmdlet.TenantId, ((PSAzureTenant)OutputPipeline.First()).Id.ToString());
                Assert.Equal(2, ((PSAzureTenant)OutputPipeline.First()).Domains.Length);
                Assert.Equal("AzureSDKTeam.onmicrosoft.com,azdevextest.com", string.Join(",",((PSAzureTenant)OutputPipeline.First()).Domains));
                Assert.Equal("Home", ((PSAzureTenant)OutputPipeline.First()).TenantCategory);
            }
            finally
            {
                //Dispose
                AzureSessionInitializer.CreateOrReplaceSession(new MemoryDataStore());
            }
        }

        private void InitializeSession()
        {
            AzureSessionInitializer.CreateOrReplaceSession(new MemoryDataStore());
            AzureSession.Instance.ARMContextSaveMode = ContextSaveMode.Process;
            PowerShellTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => cacheProvider, true);
            if (!AzureSession.Instance.TryGetComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, out IAuthenticatorBuilder builder))
            {
                builder = new DefaultAuthenticatorBuilder();
                AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => builder);
            }
            var profile = new AzureRmProfile
            {
                DefaultContext = defaultContext
            };
            cmdlet.profileClient = new RMProfileClient(profile);

            if (!AzureSession.Instance.TryGetComponent(nameof(AuthenticationTelemetry), out AuthenticationTelemetry authenticationTelemetry))
            {
                AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(nameof(AuthenticationTelemetry), () => new AuthenticationTelemetry());
            }
        }

        ~SilentReAuthByTenantCmdletTest()
        {
            XunitTracingInterceptor.RemoveFromContext(xunitLogger);
        }
    }
}

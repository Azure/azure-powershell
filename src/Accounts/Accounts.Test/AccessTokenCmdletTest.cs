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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Interfaces;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class AccessTokenCmdletTests
    {
        private GetAzureRmAccessTokenCommand cmdlet;
        private Mock<IAuthenticationFactory> factoryMock = new Mock<IAuthenticationFactory>();
        private MockCommandRuntime mockedCommandRuntime;
        private IAuthenticationFactory previousFactory = null;

        private string tenantId = Guid.NewGuid().ToString();

        public AccessTokenCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            AzureSession.Instance.RegisterComponent<AuthenticationTelemetry>(AuthenticationTelemetry.Name, () => new AuthenticationTelemetry());
            var defaultContext = new AzureContext(
                new AzureSubscription()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Test subscription"
                },
                new AzureAccount()
                {
                    Id = "admin@contoso.com",
                    Type = AzureAccount.AccountType.User
                },
                AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud],
                new AzureTenant()
                {
                    Id = tenantId
                });

            mockedCommandRuntime = new MockCommandRuntime();
            cmdlet = new GetAzureRmAccessTokenCommand()
            {
                CommandRuntime = mockedCommandRuntime,
                DefaultProfile = new AzureRmProfile()
            };
            cmdlet.DefaultProfile.DefaultContext = defaultContext;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccessTokenAsPlainText()
        {
            // Setup
            cmdlet.TenantId = tenantId;
            var fakeToken = "eyfaketoken.eyfaketoken";
            Environment.SetEnvironmentVariable(Constants.AzPsOutputPlainTextAccessToken, bool.TrueString);

            var expected = new PSAccessToken { 
                UserId = "faker@contoso.com",
                TenantId = cmdlet.TenantId,
                Token = fakeToken
            };
 
            factoryMock.Setup(t => t.Authenticate(
                It.IsAny<IAzureAccount>(),
                It.IsAny<IAzureEnvironment>(),
                It.IsAny<string>(),
                It.IsAny<SecureString>(),
                It.IsAny<string>(),
                It.IsAny<Action<string>>(),
                It.IsAny<IDictionary<string, object>>())).Returns(new MockAccessToken
                {
                    UserId = expected.UserId,
                    LoginType = LoginType.OrgId,
                    AccessToken = expected.Token,
                    TenantId = expected.TenantId
                });
            previousFactory = AzureSession.Instance.AuthenticationFactory;
            AzureSession.Instance.AuthenticationFactory = factoryMock.Object;

            // Act
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            //Verify
            Assert.Single(mockedCommandRuntime.OutputPipeline);
            var outputPipeline = mockedCommandRuntime.OutputPipeline;
            Assert.Equal(expected.TenantId, ((PSAccessToken)outputPipeline.First()).TenantId);
            Assert.Equal(expected.UserId, ((PSAccessToken)outputPipeline.First()).UserId);
            Assert.Equal("Bearer", ((PSAccessToken)outputPipeline.First()).Type);
            Assert.Equal(expected.Token, ((PSAccessToken)outputPipeline.First()).Token);

            Environment.SetEnvironmentVariable(Constants.AzPsOutputPlainTextAccessToken, null);
            AzureSession.Instance.AuthenticationFactory = previousFactory;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAccessTokenAsSecureString()
        {
            // Setup
            cmdlet.TenantId = tenantId;
            cmdlet.AsSecureString = true;
            var fakeToken = "eyfaketoken.eyfaketoken";

            var expected = new PSSecureAccessToken();
            expected.UserId = "faker@contoso.com";
            expected.TenantId = cmdlet.TenantId;
            expected.Token = fakeToken.ConvertToSecureString();


            factoryMock.Setup(t => t.Authenticate(
                It.IsAny<IAzureAccount>(),
                It.IsAny<IAzureEnvironment>(),
                It.IsAny<string>(),
                It.IsAny<SecureString>(),
                It.IsAny<string>(),
                It.IsAny<Action<string>>(),
                It.IsAny<IDictionary<string, object>>())).Returns(new MockAccessToken
                {
                    UserId = expected.UserId,
                    LoginType = LoginType.OrgId,
                    AccessToken = fakeToken,
                    TenantId = expected.TenantId
                });
            previousFactory = AzureSession.Instance.AuthenticationFactory;
            AzureSession.Instance.AuthenticationFactory = factoryMock.Object;

            // Act
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();

            //Verify
            Assert.Single(mockedCommandRuntime.OutputPipeline);
            var outputPipeline = mockedCommandRuntime.OutputPipeline;
            Assert.Equal(expected.TenantId, ((PSSecureAccessToken)outputPipeline.First()).TenantId);
            Assert.Equal(expected.UserId, ((PSSecureAccessToken)outputPipeline.First()).UserId);
            Assert.Equal("Bearer", ((PSSecureAccessToken)outputPipeline.First()).Type);
            var expectedToken = expected.Token.ConvertToString();
            var actualToken = ((PSSecureAccessToken)outputPipeline.First()).Token.ConvertToString();
            Assert.Equal(expectedToken, actualToken);

            AzureSession.Instance.AuthenticationFactory = previousFactory;
        }
    }
}

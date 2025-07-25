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

using System;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Identity;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Authentication.Test.Mocks;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using Xunit;
using Xunit.Abstractions;

namespace Common.Authenticators.Test
{
    public class ManagedServiceIdentityAuthenticatorTests
    {
        private const string TestTenantId = "123";
        private const string TestResourceId = "ActiveDirectoryServiceEndpointResourceId";

        private ITestOutputHelper Output { get; set; }

        public ManagedServiceIdentityAuthenticatorTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            Output = output;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task UserAssignedMSI()
        {
            var accountId = "testuser";

            //Setup
            MockMsalAccessTokenAcquirer mockMsalAccessTokenAcquirer = SetupMockMsalAccessTokenAcquirer();

            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            //id must be equal to accountId
            mockAzureCredentialFactory.Setup(f => f.CreateManagedIdentityCredential(It.Is<string>(id => id == accountId)))
                .Returns(new ManagedIdentityCredential(accountId));
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.ManagedService,
            };
            account.SetTenants(TestTenantId);

            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();
            var parameter = new ManagedServiceIdentityParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account);

            //Run
            ManagedServiceIdentityAuthenticator authenticator = new ManagedServiceIdentityAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            var scopes = mockMsalAccessTokenAcquirer.TokenRequestContext.Scopes;
            Assert.True(scopes.Length == 1);
            Assert.Equal("https://management.core.windows.net/", scopes[0]);
            mockAzureCredentialFactory.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        //Verify https://github.com/Azure/azure-powershell/issues/13376
        public async Task SystemAssignedMSI()
        {
            var accountId = Constants.DefaultMsiAccountIdPrefix + "12345";

            //Setup
            MockMsalAccessTokenAcquirer mockMsalAccessTokenAcquirer = SetupMockMsalAccessTokenAcquirer();

            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            //id must be equal to null
            mockAzureCredentialFactory.Setup(f => f.CreateManagedIdentityCredential(It.Is<string>(id => id == null)))
                .Returns(new ManagedIdentityCredential(accountId));
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.ManagedService,
            };
            account.SetTenants(TestTenantId);

            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();
            var parameter = new ManagedServiceIdentityParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account);

            //Run
            ManagedServiceIdentityAuthenticator authenticator = new ManagedServiceIdentityAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            var scopes = mockMsalAccessTokenAcquirer.TokenRequestContext.Scopes;
            Assert.True(scopes.Length == 1);
            Assert.Equal("https://management.core.windows.net/", scopes[0]);
            mockAzureCredentialFactory.Verify();
        }

        private MsalAccessToken CreateAccessToken(TokenCredential tokenCredential, TokenRequestContext requestContext, string token)
        {
            return new MsalAccessToken(tokenCredential, requestContext, token, DateTimeOffset.Now, "123");
        }

        private MockMsalAccessTokenAcquirer SetupMockMsalAccessTokenAcquirer()
        {
            var mockMsalAccessTokenAcquirer = new MockMsalAccessTokenAcquirer();
            mockMsalAccessTokenAcquirer.AccessTokenFactoryMethod = (tokenCredential, requestContext) => CreateAccessToken(tokenCredential, requestContext, "access token");
            var mockMsalAccessTokenAcquirerFactory = new Mock<MsalAccessTokenAcquirerFactory>();
            mockMsalAccessTokenAcquirerFactory.Setup(f => f.CreateMsalAccessTokenAcquirer())
                .Returns(mockMsalAccessTokenAcquirer);
            AzureSession.Instance.RegisterComponent(
                nameof(MsalAccessTokenAcquirerFactory),
                () => mockMsalAccessTokenAcquirerFactory.Object,
                true);
            return mockMsalAccessTokenAcquirer;
        }
    }
}

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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;
using Xunit.Abstractions;

namespace Common.Authenticators.Test
{
    /// <summary>
    /// Tests for <see cref="AccessTokenAuthenticator"/>.
    /// Covers the bug reported in https://github.com/Azure/azure-powershell/issues/28028 where
    /// Get-AzAccessToken -ResourceUrl "https://management.azure.com/" failed when signed in via
    /// Connect-AzAccount -AccessToken, even though the stored ARM token is valid for that audience.
    /// </summary>
    public class AccessTokenAuthenticatorTests
    {
        private const string TestTenantId = "test-tenant-id";
        private const string TestUserId = "testuser@contoso.com";
        private const string FakeArmToken = "fake-arm-access-token";
        private const string FakeGraphToken = "fake-graph-access-token";
        private const string FakeKeyVaultToken = "fake-keyvault-access-token";

        private readonly IAzureEnvironment _azureCloud = AzureEnvironment.PublicEnvironments["AzureCloud"];

        public AccessTokenAuthenticatorTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
        }

        private AzureAccount CreateAccessTokenAccount()
        {
            var account = new AzureAccount
            {
                Id = TestUserId,
                Type = AzureAccount.AccountType.AccessToken,
            };
            account.SetProperty(AzureAccount.Property.AccessToken, FakeArmToken);
            account.SetProperty(AzureAccount.Property.GraphAccessToken, FakeGraphToken);
            account.SetProperty(AzureAccount.Property.KeyVaultAccessToken, FakeKeyVaultToken);
            return account;
        }

        private AccessTokenParameters CreateParameters(string resourceId, AzureAccount account = null)
        {
            return new AccessTokenParameters(
                new InMemoryTokenCacheProvider(),
                _azureCloud,
                null,
                TestTenantId,
                resourceId,
                account ?? CreateAccessTokenAccount());
        }

        /// <summary>
        /// Verifies that the stored ARM access token is returned when the resource URL is
        /// the legacy management endpoint (https://management.core.windows.net/).
        /// This is the pre-existing working case.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ReturnsArmToken_WhenResourceIsManagementCoreWindowsNet()
        {
            var resourceId = "https://management.core.windows.net/";
            var parameters = CreateParameters(resourceId);
            var authenticator = new AccessTokenAuthenticator();

            var token = await authenticator.Authenticate(parameters);

            Assert.NotNull(token);
            Assert.Equal(FakeArmToken, token.AccessToken);
            Assert.Equal(TestUserId, token.UserId);
            Assert.Equal(TestTenantId, token.TenantId);
        }

        /// <summary>
        /// Verifies that the stored ARM access token is returned when the resource URL is
        /// https://management.azure.com/ — the Azure Resource Manager endpoint URL.
        /// This covers the bug in https://github.com/Azure/azure-powershell/issues/28028.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ReturnsArmToken_WhenResourceIsManagementAzureCom()
        {
            // This is the resource URL that previously caused the error:
            // "[AccessTokenAuthenticator] failed to retrieve access token for resource 'https://management.azure.com/'"
            var resourceId = _azureCloud.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
            Assert.Equal("https://management.azure.com/", resourceId, StringComparer.OrdinalIgnoreCase);

            var parameters = CreateParameters(resourceId);
            var authenticator = new AccessTokenAuthenticator();

            var token = await authenticator.Authenticate(parameters);

            Assert.NotNull(token);
            Assert.Equal(FakeArmToken, token.AccessToken);
            Assert.Equal(TestUserId, token.UserId);
            Assert.Equal(TestTenantId, token.TenantId);
        }

        /// <summary>
        /// Verifies that the KeyVault access token is returned when requesting the KeyVault resource.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ReturnsKeyVaultToken_WhenResourceIsKeyVaultEndpoint()
        {
            var resourceId = _azureCloud.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            var parameters = CreateParameters(resourceId);
            var authenticator = new AccessTokenAuthenticator();

            var token = await authenticator.Authenticate(parameters);

            Assert.NotNull(token);
            Assert.Equal(FakeKeyVaultToken, token.AccessToken);
        }

        /// <summary>
        /// Verifies that the AAD Graph access token is returned when requesting the Graph resource.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ReturnsGraphToken_WhenResourceIsGraphEndpoint()
        {
            var resourceId = _azureCloud.GetEndpoint(AzureEnvironment.Endpoint.GraphEndpointResourceId);
            var parameters = CreateParameters(resourceId);
            var authenticator = new AccessTokenAuthenticator();

            var token = await authenticator.Authenticate(parameters);

            Assert.NotNull(token);
            Assert.Equal(FakeGraphToken, token.AccessToken);
        }

        /// <summary>
        /// Verifies that an InvalidOperationException is thrown when requesting a resource
        /// for which no token was provided at login time.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ThrowsInvalidOperationException_WhenResourceIsUnsupported()
        {
            var resourceId = "https://unsupported.resource.example.com/";
            var parameters = CreateParameters(resourceId);
            var authenticator = new AccessTokenAuthenticator();

            await Assert.ThrowsAsync<InvalidOperationException>(() => authenticator.Authenticate(parameters));
        }

        /// <summary>
        /// Verifies that CanAuthenticate returns true only for AccessTokenParameters.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticate_ReturnsTrueForAccessTokenParameters()
        {
            var parameters = CreateParameters("https://management.azure.com/");
            var authenticator = new AccessTokenAuthenticator();

            Assert.True(authenticator.CanAuthenticate(parameters));
        }
    }
}

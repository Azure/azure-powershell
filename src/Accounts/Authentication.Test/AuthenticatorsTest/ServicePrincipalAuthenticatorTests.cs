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
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Common.Authenticators.Test
{
    public class ServicePrincipalAuthenticatorTests
    {
        private const string TestTenantId = "123";
        private const string TestResourceId = "ActiveDirectoryServiceEndpointResourceId";

        private const string fakeToken = "faketoken";

        private ITestOutputHelper Output { get; set; }

        class TokenCredentialMock : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(new AccessToken(fakeToken, DateTimeOffset.Now));
            }
        }

        public ServicePrincipalAuthenticatorTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            Output = output;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ServicePrincipalSecretAuthenticationTest()
        {
            var accountId = "testuser";
            var securePassword = new SecureString();
            "pa88w0rd!".ToCharArray().ForEach(c => securePassword.AppendChar(c));

            //Setup
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateClientSecretCredential(
                 It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SecureString>(), It.IsAny<ClientCertificateCredentialOptions>())).Returns(() => new TokenCredentialMock());

            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(TestTenantId);

            var parameter = new ServicePrincipalParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                null,
                null,
                null,
                securePassword,
                null);

            //Run
            var authenticator = new ServicePrincipalAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            mockAzureCredentialFactory.Verify(f => f.CreateClientSecretCredential(TestTenantId, accountId, securePassword, It.IsAny<ClientCertificateCredentialOptions>()), Times.Once());
            Assert.Equal(fakeToken, token.AccessToken);
            Assert.Equal(TestTenantId, token.TenantId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ServicePrincipalThumbprintAuthenticationTest()
        {
            var accountId = "testuser";
            var thumbprint = Guid.NewGuid().ToString();

            IDataStore prevDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = new MockDataStore();
            var certificate = AzureSession.Instance.DataStore.GetCertificate(thumbprint);

            //Setup
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateClientCertificateCredential(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<X509Certificate2>(), It.IsAny<ClientCertificateCredentialOptions>())).Returns(() => new TokenCredentialMock());

            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(TestTenantId);

            var parameter = new ServicePrincipalParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                thumbprint,
                null,
                null,
                null,
                null);

            //Run
            var authenticator = new ServicePrincipalAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            mockAzureCredentialFactory.Verify(f => f.CreateClientCertificateCredential(TestTenantId, accountId, certificate, It.IsAny<ClientCertificateCredentialOptions>()), Times.Once());
            Assert.Equal(fakeToken, token.AccessToken);
            Assert.Equal(TestTenantId, token.TenantId);

            AzureSession.Instance.DataStore = prevDataStore;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task ServicePrincipalCertificateFileAuthenticationTest()
        {
            var accountId = "testuser";
            var certificateFile = "d:/certficatefortest.pfx";

            IDataStore prevDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = new MockDataStore();
            AzureSession.Instance.DataStore.WriteFile(certificateFile, "dummyfile");

            //Setup
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateClientCertificateCredential(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ClientCertificateCredentialOptions>())).Returns(() => new TokenCredentialMock());

            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(TestTenantId);

            var parameter = new ServicePrincipalParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                null,
                certificateFile,
                null,
                null,
                null);

            //Run
            var authenticator = new ServicePrincipalAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            mockAzureCredentialFactory.Verify(f => f.CreateClientCertificateCredential(TestTenantId, accountId, certificateFile, It.IsAny<ClientCertificateCredentialOptions>()), Times.Once());
            Assert.Equal(fakeToken, token.AccessToken);
            Assert.Equal(TestTenantId, token.TenantId);

            AzureSession.Instance.DataStore = prevDataStore;
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public async Task ServicePrincipalCertificateFileWithSecretAuthenticationTest()
        {
            var accountId = "testuser";
            var certificateFile = "d:/certficatefortest.pfx";
            var thumbprint = Guid.NewGuid().ToString();
            var securePassword = new SecureString();
            "pa88w0rd!".ToCharArray().ForEach(c => securePassword.AppendChar(c));

            IDataStore prevDataStore = AzureSession.Instance.DataStore;
            AzureSession.Instance.DataStore = new DiskDataStore();

            //Setup
            var mockAzureCredentialFactory = new Mock<AzureCredentialFactory>();
            mockAzureCredentialFactory.Setup(f => f.CreateClientCertificateCredential(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<X509Certificate2>(), It.IsAny<ClientCertificateCredentialOptions>())).Returns(() => new TokenCredentialMock());

            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object, true);
            InMemoryTokenCacheProvider cacheProvider = new InMemoryTokenCacheProvider();

            var account = new AzureAccount
            {
                Id = accountId,
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants(TestTenantId);

            var parameter = new ServicePrincipalParameters(
                cacheProvider,
                AzureEnvironment.PublicEnvironments["AzureCloud"],
                null,
                TestTenantId,
                TestResourceId,
                account.Id,
                null,
                certificateFile,
                securePassword,
                null,
                null);

            //Run
            var authenticator = new ServicePrincipalAuthenticator();
            var token = await authenticator.Authenticate(parameter);

            //Verify
            mockAzureCredentialFactory.Verify(f => f.CreateClientCertificateCredential(TestTenantId, accountId, It.IsAny<X509Certificate2>(), It.IsAny<ClientCertificateCredentialOptions>()), Times.Once());
            Assert.Equal(fakeToken, token.AccessToken);
            Assert.Equal(TestTenantId, token.TenantId);

            AzureSession.Instance.DataStore = prevDataStore;
        }
    }
}

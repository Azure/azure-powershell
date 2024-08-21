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
using System.Collections.Generic;
using System.Linq;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Test;
using Microsoft.Azure.PowerShell.Authenticators;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Xunit;
using Xunit.Abstractions;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.Azure.PowerShell.Authentication.Test.Mocks;
using Azure.Identity;
using Moq;
using System.ServiceModel.Channels;
using Azure.Core;
using Microsoft.Azure.Commands.TestFx.Mocks;

namespace Common.Authentication.Test
{
    public class AuthenticationFactoryTests
    {
        ITestOutputHelper _output;
        public AuthenticationFactoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(Skip = "Need to determine how to adapt this test to new shared token cache model.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerifySubscriptionTokenCacheRemove()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = "testuser",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants("123");
            var sub = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
            };
            sub.SetTenant("123");
            var credential = authFactory.GetSubscriptionCloudCredentials(new AzureContext
            (
                sub,
               account,
                AzureEnvironment.PublicEnvironments["AzureCloud"]
            ));

            Assert.True(credential is AccessTokenCredential);
            Assert.Equal(subscriptionId, new Guid(((AccessTokenCredential)credential).SubscriptionId));
        }

#if !NETSTANDARD
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
       public void VerifyValidateAuthorityFalseForOnPremise()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();
            var account = new AzureAccount
            {
                Id = "testuser",
                Type = AzureAccount.AccountType.User,
            };
            account.SetTenants("123");
            var sub = new AzureSubscription
            {
                Id = subscriptionId.ToString(),
            };
            sub.SetTenant("123");
            var context = new AzureContext
            (
                sub,
                account,
                new AzureEnvironment
                {
                    Name = "Katal",
                    OnPremise = true,
                    ActiveDirectoryAuthority = "http://ad.com",
                    ActiveDirectoryServiceEndpointResourceId = "http://adresource.com"
                }
            );

            var credential = authFactory.Authenticate(context.Account, context.Environment, "common", null, ShowDialog.Always, null);

            Assert.False(((MockAccessTokenProvider)authFactory.TokenProvider).AdalConfiguration.ValidateAuthority);
        }
#endif

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticateWithAccessToken()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAuthenticatorBuilder authenticatorBuilder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => authenticatorBuilder);
            PowerShellTokenCacheProvider factory = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => factory);
            string tenant = Guid.NewGuid().ToString();
            string userId = "user1@contoso.org";
            var armToken = Guid.NewGuid().ToString();
            var graphToken = Guid.NewGuid().ToString();
            var kvToken = Guid.NewGuid().ToString();
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.AccessToken
            };
            account.SetTenants(tenant);
            account.SetAccessToken(armToken);
            account.SetProperty(AzureAccount.Property.GraphAccessToken, graphToken);
            account.SetProperty(AzureAccount.Property.KeyVaultAccessToken, kvToken);
            var authFactory = new AuthenticationFactory();
            var environment = AzureEnvironment.PublicEnvironments.Values.First();
            var checkArmToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null);
            VerifyToken(checkArmToken, armToken, userId, tenant);
            checkArmToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, environment.ActiveDirectoryServiceEndpointResourceId);
            VerifyToken(checkArmToken, armToken, userId, tenant);
            var checkGraphToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, AzureEnvironment.Endpoint.GraphEndpointResourceId);
            VerifyToken(checkGraphToken, graphToken, userId, tenant);
            checkGraphToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, environment.GraphEndpointResourceId);
            VerifyToken(checkGraphToken, graphToken, userId, tenant);
            var checkKVToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, environment.AzureKeyVaultServiceEndpointResourceId);
            VerifyToken(checkKVToken, kvToken, userId, tenant);
            checkKVToken = authFactory.Authenticate(account, environment, tenant, new System.Security.SecureString(), "Never", null, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            VerifyToken(checkKVToken, kvToken, userId, tenant);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticateUsingMSIDefault()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAuthenticatorBuilder authenticatorBuilder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => authenticatorBuilder);
            PowerShellTokenCacheProvider factory = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => factory);
            var msalAccessTokenAcquirerFactory = new MsalAccessTokenAcquirerFactory();
            AzureSession.Instance.RegisterComponent(nameof(MsalAccessTokenAcquirerFactory), () => msalAccessTokenAcquirerFactory, true);

            string expectedAccessToken = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for default URI: {0}", expectedAccessToken);
            var mockAzureCredentialFactory = new MockAzureCredentialFactory();
            MockManagedIdentityCredential mockManagedIdentityCredential = null;
            mockAzureCredentialFactory.CredentialFactory = (clientId) =>
            {
                return mockManagedIdentityCredential = new MockManagedIdentityCredential(clientId)
                {
                    TokenFactory = () => new AccessToken(expectedAccessToken, DateTimeOffset.Now)
                };
            };
            AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => (AzureCredentialFactory)mockAzureCredentialFactory, true);

            string expectedToken2 = Guid.NewGuid().ToString();
            string tenant = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for custom URI: {0}", expectedToken2);
            string userId = Constants.DefaultMsiAccountIdPrefix + "12345";
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
            var expectedResource = environment.ActiveDirectoryServiceEndpointResourceId;
            var builder = new UriBuilder(AuthenticationFactory.DefaultBackupMSILoginUri);
            //builder.Query = $"resource={Uri.EscapeDataString(environment.ActiveDirectoryServiceEndpointResourceId)}&api-version=2018-02-01";
            //var defaultUri = builder.Uri.ToString();

            //var responses = new Dictionary<string, ManagedServiceTokenInfo>(StringComparer.OrdinalIgnoreCase)
            //{
            //    {defaultUri, new ManagedServiceTokenInfo { AccessToken = expectedAccessToken, ExpiresIn = 3600, Resource=expectedResource}},
            //    {"http://myfunkyurl:10432/oauth2/token?resource=foo&api-version=2018-02-01", new ManagedServiceTokenInfo { AccessToken = expectedToken2, ExpiresIn = 3600, Resource="foo"} }
            //};
            //AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestHttpOperationsFactory.Create(responses, _output), true);
            var authFactory = new AuthenticationFactory();
            IAccessToken token = authFactory.Authenticate(account, environment, tenant, null, null, null);
            _output.WriteLine($"Received access token for default Uri ${token.AccessToken}");
            Assert.Equal(expectedAccessToken, token.AccessToken);
            Assert.Null(mockManagedIdentityCredential.AccountId);
            //Assert.Equal(3600, Math.Round(token.ExpiresOn.Subtract(DateTimeOffset.Now).TotalSeconds));
            var userId2 = "abc@foo.com";
            var account2 = new AzureAccount
            {
                Id = userId2,
                Type = AzureAccount.AccountType.ManagedService
            };
            //account2.SetProperty(AzureAccount.Property.MSILoginUri, "http://myfunkyurl:10432/oauth2/token");
            expectedAccessToken = expectedToken2;
            var token2 = authFactory.Authenticate(account2, environment, tenant, null, null, null, "foo");
            _output.WriteLine($"Received access token for custom Uri ${token2.AccessToken}");
            Assert.Equal(expectedToken2, token2.AccessToken);
            Assert.Equal(userId2, mockManagedIdentityCredential.AccountId);
            //var token3 = authFactory.Authenticate(account, environment, tenant, null, null, null, "bar");
            //Assert.Throws<InvalidOperationException>(() => token3.AccessToken);
        }

        [Fact(Skip = "eriwan: mock MSI credential request and response")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticateUsingMSIResourceId()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAuthenticatorBuilder authenticatorBuilder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => authenticatorBuilder);
            PowerShellTokenCacheProvider factory = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => factory);
            string expectedAccessToken = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for ARM URI: {0}", expectedAccessToken);
            string expectedToken2 = Guid.NewGuid().ToString();
            string tenant = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for graph URI: {0}", expectedToken2);
            string userId = "/foo/bar/baz";
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
            var expectedResource = environment.ActiveDirectoryServiceEndpointResourceId;
            var builder = new UriBuilder(AuthenticationFactory.DefaultMSILoginUri);
            builder.Query = $"resource={Uri.EscapeDataString(environment.ActiveDirectoryServiceEndpointResourceId)}&msi_res_id={Uri.EscapeDataString(userId)}&api-version=2018-02-01";
            var defaultUri = builder.Uri.ToString();

            var customBuilder = new UriBuilder(AuthenticationFactory.DefaultMSILoginUri);
            customBuilder.Query = $"resource={Uri.EscapeDataString(environment.GraphEndpointResourceId)}&msi_res_id={Uri.EscapeDataString(userId)}&api-version=2018-02-01";
            var customUri = customBuilder.Uri.ToString();

            var responses = new Dictionary<string, ManagedServiceTokenInfo>(StringComparer.OrdinalIgnoreCase)
            {
                {defaultUri, new ManagedServiceTokenInfo { AccessToken = expectedAccessToken, ExpiresIn = 3600, Resource=expectedResource}},
                {customUri, new ManagedServiceTokenInfo { AccessToken = expectedToken2, ExpiresIn = 3600, Resource=environment.GraphEndpointResourceId} }
            };
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestHttpOperationsFactory.Create(responses, _output), true);
            var authFactory = new AuthenticationFactory();
            IRenewableToken token = (IRenewableToken) authFactory.Authenticate(account, environment, tenant, null, null, null);
            _output.WriteLine($"Received access token for default Uri ${token.AccessToken}");
            Assert.Equal(expectedAccessToken, token.AccessToken);
            Assert.Equal(3600, Math.Round(token.ExpiresOn.Subtract(DateTimeOffset.Now).TotalSeconds));
            var account2 = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var token2 = authFactory.Authenticate(account2, environment, tenant, null, null, null, AzureEnvironment.Endpoint.GraphEndpointResourceId);
            _output.WriteLine($"Received access token for custom Uri ${token2.AccessToken}");
            Assert.Equal(expectedToken2, token2.AccessToken);
            var token3 = authFactory.Authenticate(account, environment, tenant, null, null, null, "bar");
            Assert.Throws<InvalidOperationException>(() => token3.AccessToken);
        }

        [Fact(Skip = "eriwan: mock MSI credential request and response")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticateUsingMSIClientId()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAuthenticatorBuilder authenticatorBuilder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => authenticatorBuilder);
            PowerShellTokenCacheProvider factory = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => factory);
            string expectedAccessToken = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for ARM URI: {0}", expectedAccessToken);
            string expectedToken2 = Guid.NewGuid().ToString();
            string tenant = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for graph URI: {0}", expectedToken2);
            string userId = Guid.NewGuid().ToString();
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
            var expectedResource = environment.ActiveDirectoryServiceEndpointResourceId;
            var builder = new UriBuilder(AuthenticationFactory.DefaultMSILoginUri);
            builder.Query = $"resource={Uri.EscapeDataString(environment.ActiveDirectoryServiceEndpointResourceId)}&client_id={userId}&api-version=2018-02-01";
            var defaultUri = builder.Uri.ToString();

            var customBuilder = new UriBuilder(AuthenticationFactory.DefaultMSILoginUri);
            customBuilder.Query = $"resource={Uri.EscapeDataString(environment.GraphEndpointResourceId)}&client_id={userId}&api-version=2018-02-01";
            var customUri = customBuilder.Uri.ToString();

            var responses = new Dictionary<string, ManagedServiceTokenInfo>(StringComparer.OrdinalIgnoreCase)
            {
                {defaultUri, new ManagedServiceTokenInfo { AccessToken = expectedAccessToken, ExpiresIn = 3600, Resource=expectedResource}},
                {customUri, new ManagedServiceTokenInfo { AccessToken = expectedToken2, ExpiresIn = 3600, Resource=environment.GraphEndpointResourceId} }
            };
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestHttpOperationsFactory.Create(responses, _output), true);
            var authFactory = new AuthenticationFactory();
            IRenewableToken token = (IRenewableToken) authFactory.Authenticate(account, environment, tenant, null, null, null);
            _output.WriteLine($"Received access token for default Uri ${token.AccessToken}");
            Assert.Equal(expectedAccessToken, token.AccessToken);
            Assert.Equal(3600, Math.Round(token.ExpiresOn.Subtract(DateTimeOffset.Now).TotalSeconds));
            var account2 = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var token2 = authFactory.Authenticate(account2, environment, tenant, null, null, null, AzureEnvironment.Endpoint.GraphEndpointResourceId);
            _output.WriteLine($"Received access token for custom Uri ${token2.AccessToken}");
            Assert.Equal(expectedToken2, token2.AccessToken);
            var token3 = authFactory.Authenticate(account, environment, tenant, null, null, null, "bar");
            Assert.Throws<InvalidOperationException>(() => token3.AccessToken);
        }

        [Fact(Skip = "eriwan: mock MSI credential request and response")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanAuthenticateUsingMSIObjectId()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAuthenticatorBuilder authenticatorBuilder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => authenticatorBuilder);
            PowerShellTokenCacheProvider factory = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => factory);
            string expectedAccessToken = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for ARM URI: {0}", expectedAccessToken);
            string expectedToken2 = Guid.NewGuid().ToString();
            string tenant = Guid.NewGuid().ToString();
            _output.WriteLine("Expected access token for graph URI: {0}", expectedToken2);
            string userId = Guid.NewGuid().ToString();
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var environment = AzureEnvironment.PublicEnvironments["AzureCloud"];
            var expectedResource = environment.ActiveDirectoryServiceEndpointResourceId;
            var builder = new UriBuilder(AuthenticationFactory.DefaultMSILoginUri);
            builder.Query = $"resource={Uri.EscapeDataString(environment.ActiveDirectoryServiceEndpointResourceId)}&object_id={userId}&api-version=2018-02-01";
            var defaultUri = builder.Uri.ToString();

            var customBuilder = new UriBuilder(AuthenticationFactory.DefaultMSILoginUri);
            customBuilder.Query = $"resource={Uri.EscapeDataString(environment.GraphEndpointResourceId)}&object_id={userId}&api-version=2018-02-01";
            var customUri = customBuilder.Uri.ToString();

            var responses = new Dictionary<string, ManagedServiceTokenInfo>(StringComparer.OrdinalIgnoreCase)
            {
                {defaultUri, new ManagedServiceTokenInfo { AccessToken = expectedAccessToken, ExpiresIn = 3600, Resource=expectedResource}},
                {customUri, new ManagedServiceTokenInfo { AccessToken = expectedToken2, ExpiresIn = 3600, Resource=environment.GraphEndpointResourceId} }
            };
            AzureSession.Instance.RegisterComponent(HttpClientOperationsFactory.Name, () => TestHttpOperationsFactory.Create(responses, _output), true);
            var authFactory = new AuthenticationFactory();
            IRenewableToken token = (IRenewableToken) authFactory.Authenticate(account, environment, tenant, null, null, null);
            _output.WriteLine($"Received access token for default Uri ${token.AccessToken}");
            Assert.Equal(expectedAccessToken, token.AccessToken);
            Assert.Equal(3600, Math.Round(token.ExpiresOn.Subtract(DateTimeOffset.Now).TotalSeconds));
            var account2 = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.ManagedService
            };
            var token2 = authFactory.Authenticate(account2, environment, tenant, null, null, null, AzureEnvironment.Endpoint.GraphEndpointResourceId);
            _output.WriteLine($"Received access token for custom Uri ${token2.AccessToken}");
            Assert.Equal(expectedToken2, token2.AccessToken);
            var token3 = authFactory.Authenticate(account, environment, tenant, null, null, null, "bar");
            Assert.Throws<InvalidOperationException>(() => token3.AccessToken);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        void ResponseRedactionWorks()
        {
            IList<Regex> matchers = new List<Regex>();
            matchers.Add(new Regex("(\\s*\"access_token\"\\s*:\\s*)\"[^\"]+\""));
            Assert.Equal("   \"access_token\": \"<redacted>\"", GeneralUtilities.TransformBody("   \"access_token\": \"eyJo1234567\"", matchers));
            Assert.Equal("   \"foo\": \"bar\"", GeneralUtilities.TransformBody("   \"foo\": \"bar\""));
        }

        void VerifyToken(IAccessToken checkToken, string expectedAccessToken, string expectedUserId, string expectedTenant)
        {
            Assert.True(checkToken is RawAccessToken);
            Assert.Equal(expectedAccessToken, checkToken.AccessToken);
            Assert.Equal(expectedUserId, checkToken.UserId);
            Assert.Equal(expectedTenant, checkToken.TenantId);
            checkToken.AuthorizeRequest((type, token) =>
            {
                Assert.Equal(expectedAccessToken, token);
                Assert.Equal("Bearer", type);
            });
        }

        private string GetFunctionsResourceId(string resourceIdOrEndpointName, IAzureEnvironment environment)
        {
            var resourceId = environment.GetEndpoint(resourceIdOrEndpointName) ?? resourceIdOrEndpointName;
            if (string.Equals(
                environment.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId),
                resourceId, StringComparison.OrdinalIgnoreCase))
            {
                resourceId = environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);
            }

            return resourceId;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetServiceClientCredentialsWithAccessToken()
        {
            AzureSessionInitializer.InitializeAzureSession();
            IAuthenticatorBuilder authenticatorBuilder = new DefaultAuthenticatorBuilder();
            AzureSession.Instance.RegisterComponent(AuthenticatorBuilder.AuthenticatorBuilderKey, () => authenticatorBuilder);
            PowerShellTokenCacheProvider factory = new InMemoryTokenCacheProvider();
            AzureSession.Instance.RegisterComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, () => factory);
            string tenant = Guid.NewGuid().ToString();
            string userId = "user1@contoso.org";
            var armToken = Guid.NewGuid().ToString();
            var graphToken = Guid.NewGuid().ToString();
            var kvToken = Guid.NewGuid().ToString();
            var account = new AzureAccount
            {
                Id = userId,
                Type = AzureAccount.AccountType.AccessToken
            };
            account.SetTenants(tenant);
            account.SetAccessToken(armToken);
            account.SetProperty(AzureAccount.Property.GraphAccessToken, graphToken);
            account.SetProperty(AzureAccount.Property.KeyVaultAccessToken, kvToken);
            var authFactory = new AuthenticationFactory();
            var environment = AzureEnvironment.PublicEnvironments.Values.First();
            var mockContext = new AzureContext()
            {
                Account = account
            };
            var credentials = authFactory.GetServiceClientCredentials(mockContext);
            VerifyAccessTokenInServiceClientCredentials(credentials, armToken);
            credentials = authFactory.GetServiceClientCredentials(mockContext, AzureEnvironment.Endpoint.Graph);
            VerifyAccessTokenInServiceClientCredentials(credentials, graphToken);
            credentials = authFactory.GetServiceClientCredentials(mockContext, AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId);
            VerifyAccessTokenInServiceClientCredentials(credentials, kvToken);
        }

        private void VerifyAccessTokenInServiceClientCredentials(Microsoft.Rest.ServiceClientCredentials cred, string expected)
        {
            using (var request = new HttpRequestMessage())
            {
                cred.ProcessHttpRequestAsync(request, new CancellationToken()).ConfigureAwait(false).GetAwaiter().GetResult();
                Assert.Equal(expected, request.Headers.Authorization.Parameter);
            }
        }
    }
}

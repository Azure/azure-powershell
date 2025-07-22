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
using Microsoft.Azure.Commands.Common.Authentication.Factories;
using Microsoft.Azure.Commands.Common.Authentication.Test.Mocks;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.PowerShell.Authenticators.Factories;
using Microsoft.WindowsAzure.Commands.Common;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace Common.Authentication.Test
{
    public class AuthenticationFactoryConcurrencyTest : MockAuthenticationTestBase
    {
        public string tenant = Guid.NewGuid().ToString();
        public string armToken = Guid.NewGuid().ToString();

        public AuthenticationFactoryConcurrencyTest(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void AuthenticationFactoryShouldHaveTelemetry()
        {
            //Set the inputs
            var account = new AzureAccount
            {
                Id = Guid.NewGuid().ToString(),
                Type = AzureAccount.AccountType.ServicePrincipal
            };
            account.SetTenants(tenant);
            var environment = AzureEnvironment.PublicEnvironments.Values.First();
            var password = "password".ConvertToSecureString();
            var promptBehavior = "auto";
            Action<string> promptAction = s => { };
            var resourceId = "resourceId";
            var cmdletContext = new AzureCmdletContext(Guid.NewGuid().ToString());

            var keyStore = new Dictionary<IKeyStoreKey, SecureString>();

            // Arrange
            var factory = new AuthenticationFactory();

            // Mock AzureSession setup
            try
            {
                originalInstance = AzureSession.Instance;
            }
            catch (InvalidOperationException)
            {
                originalInstance = null;
            }
            try
            {
                InitializeSession(armToken);
                var mockTokenCredential = new Mock<ClientSecretCredential>();
                mockTokenCredential.Setup(f => f.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>())).ReturnsAsync(new AccessToken(armToken, DateTimeOffset.Now));
                mockTokenCredential.Setup(f => f.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>())).Returns(new AccessToken(armToken, DateTimeOffset.Now));
                mockAzureCredentialFactory.Setup(f => f.CreateClientSecretCredential(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<ClientSecretCredentialOptions>())
                ).Returns(mockTokenCredential.Object);
                AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object);

                mockKeyStore.Setup(f => f.SaveSecureString(It.IsAny<IKeyStoreKey>(), It.IsAny<SecureString>())).Callback((IKeyStoreKey k, SecureString v) => keyStore[k] = v);
                mockKeyStore.Setup(f => f.GetSecureString(It.IsAny<IKeyStoreKey>())).Returns(password);
                AzureSession.Instance.RegisterComponent(AzKeyStore.Name, () => mockKeyStore.Object);

                // Act
                var optionalParameters = new Dictionary<string, object>()
                {
                    {AuthenticationFactory.TokenCacheParameterName,  mockTokenCache.Object},
                    {AuthenticationFactory.ResourceIdParameterName, resourceId },
                    {AuthenticationFactory.CmdletContextParameterName, cmdletContext }
                };
                var result = factory.Authenticate(account, environment, tenant, password, promptBehavior, promptAction, optionalParameters);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(armToken, result.AccessToken);
                Assert.Equal(account.Id, result.UserId);

                if (AzureSession.Instance.TryGetComponent(AuthenticationTelemetry.Name, out AuthenticationTelemetry authenticationTelemetry))
                {
                    var telemetry = authenticationTelemetry.GetTelemetryRecord(cmdletContext);
                    Assert.NotNull(telemetry.Primary);
                    Assert.Equal(mockTokenCredential.Object.GetType().Name, telemetry.Primary.TokenCredentialName);
                    Assert.True(telemetry.Primary.AuthenticationSuccess);
                    Assert.Empty(telemetry.Secondary);
                }
                else
                {
                    Assert.Fail("Authentication telemetry component not found in AzureSession");
                }
            }
            finally
            {
                // Restore original instance
                AzureSession.Initialize(() => originalInstance, true);
            }
        }

        [Fact]
        public async Task AuthenticationFactoryShouldHandleConcurrentAuthentication()
        {
            // Set up common test data
            var environment = AzureEnvironment.PublicEnvironments.Values.First();
            var promptBehavior = "auto";
            Action<string> promptAction = s => { };
            var resourceId = "resourceId";

            var keyStore = new Dictionary<IKeyStoreKey, SecureString>();
            var taskCount = 5;

            // Arrange
            var factory = new AuthenticationFactory();

            // Mock AzureSession setup
            try
            {
                originalInstance = AzureSession.Instance;
            }
            catch (InvalidOperationException)
            {
                originalInstance = null;
            }

            try
            {
                InitializeSession(armToken);
                var mockTokenCredential = new Mock<SharedTokenCacheCredential>();
                mockTokenCredential.Setup(f => f.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AccessToken(armToken, DateTimeOffset.Now));
                mockAzureCredentialFactory.Setup(f => f.CreateSharedTokenCacheCredentials(It.IsAny<SharedTokenCacheCredentialOptions>())).Returns(mockTokenCredential.Object);

                //var mockTokenManagedIdentityCredential = new Mock<ManagedIdentityCredential>();
                //mockTokenManagedIdentityCredential.Setup(f => f.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                //    .ReturnsAsync(new AccessToken(armToken, DateTimeOffset.Now));
                //mockTokenManagedIdentityCredential.Setup(f => f.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                //    .Returns(new AccessToken(armToken, DateTimeOffset.Now));
                //mockAzureCredentialFactory.Setup(f => f.CreateManagedIdentityCredential(It.IsAny<string>())).Returns(mockTokenManagedIdentityCredential.Object);

                AzureSession.Instance.RegisterComponent(nameof(AzureCredentialFactory), () => mockAzureCredentialFactory.Object);

                // Act - Create multiple tasks to authenticate concurrently
                var tasks = new Task<IAccessToken>[taskCount];
                var contexts = new AzureCmdletContext[taskCount];

                for (int i = 0; i < taskCount; i++)
                {
                    // Create unique accounts and context for each task
                    var account = new AzureAccount
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = AzureAccount.AccountType.User
                    };
                    account.SetTenants(tenant);
                    contexts[i] = new AzureCmdletContext(Guid.NewGuid().ToString());

                    var optionalParameters = new Dictionary<string, object>()
                    {
                        {AuthenticationFactory.TokenCacheParameterName, mockTokenCache.Object},
                        {AuthenticationFactory.ResourceIdParameterName, resourceId},
                        {AuthenticationFactory.CmdletContextParameterName, contexts[i]}
                    };

                    // Capture variables for the lambda to avoid closure issues
                    var currentAccount = account;
                    var currentContext = contexts[i];
                    var taskIndex = i;

                    tasks[i] = Task.Run(() =>
                    {
                        _output.WriteLine($"Starting authentication task {taskIndex}");
                        var result = factory.Authenticate(currentAccount, environment, tenant,
                            null, promptBehavior, promptAction, optionalParameters);
                        _output.WriteLine($"Completed authentication task {taskIndex}");
                        return result;
                    });
                }

                // Wait for all tasks to complete
                await Task.WhenAll(tasks);

                // Collect all results
                for (int i = 0; i < taskCount; i++)
                {
                    var result = await tasks[i];
                    Assert.NotNull(result);
                    Assert.Equal(armToken, result.AccessToken);
                }

                // Verify telemetry was recorded for each authentication
                if (AzureSession.Instance.TryGetComponent(AuthenticationTelemetry.Name, out AuthenticationTelemetry authenticationTelemetry))
                {
                    for (int i = 0; i < taskCount; i++)
                    {
                        var telemetry = authenticationTelemetry.GetTelemetryRecord(contexts[i]);
                        Assert.NotNull(telemetry.Primary);
                        Assert.Equal(mockTokenCredential.Object.GetType().Name, telemetry.Primary.TokenCredentialName);
                        Assert.True(telemetry.Primary.AuthenticationSuccess);
                        Assert.Empty(telemetry.Secondary);
                    }
                }
                else
                {
                    Assert.Fail("Authentication telemetry component not found in AzureSession");
                }
            }
            finally
            {
                // Restore original instance
                AzureSession.Initialize(() => originalInstance, true);
            }
        }
    }
}
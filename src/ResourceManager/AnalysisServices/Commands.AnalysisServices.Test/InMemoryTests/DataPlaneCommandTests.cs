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
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Test.InMemoryTests
{
    public class DataPlaneCommandTests : AsTestsBase
    {
        private const string testAsAzureEnvironment = "westcentralus.asazure.windows.net";

        private const string testServer = "testserver";

        private const string testUser = "testuser@contoso.com";

        private const string testPassword = "testpassword";

        private const string testToken = "eyJ0eXAiOi"
                                        + "JKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IjFpOWlmMDllc0YzaU9sS0I2SW9meVVGSUxnQSIsImtpZC"
                                        + "I6IjFpOWlmMDllc0YzaU9sS0I2SW9meVVGSUxnQSJ9.eyJhdWQiOiJodHRwczovL21hbmFnZW1lbnQuY"
                                        + "29yZS53aW5kb3dzLm5ldC8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLXBwZS5uZXQvMDQ1NDZiY"
                                        + "zAtYmMxOS00Y2I2LWIxNmQtNTc0OTQxNzFhNGJjLyIsImlhdCI6MTQ4MDU1NjY0MywibmJmIjoxNDgwN"
                                        + "TU2NjQzLCJleHAiOjE0ODA1NjA1NDMsImFjciI6IjEiLCJhbXIiOlsicHdkIl0sImFwcGlkIjoiMTk1M"
                                        + "GEyNTgtMjI3Yi00ZTMxLWE5Y2YtNzE3NDk1OTQ1ZmMyIiwiYXBwaWRhY3IiOiIwIiwiZV9leHAiOjEwO"
                                        + "DAwLCJmYW1pbHlfbmFtZSI6IlN1c21hbiIsImdpdmVuX25hbWUiOiJEZXJ5YSIsImdyb3VwcyI6WyI0Y"
                                        + "zNmNjNiNy1mZWU1LTQ1ZWItOTAwMy03YWQ1ZDM5MzMzMDIiXSwiaXBhZGRyIjoiMTY3LjIyMC4wLjExM"
                                        + "yIsIm5hbWUiOiJEZXJ5YSBTdXNtYW4iLCJvaWQiOiJhODMyOWI5OS01NGI1LTQwNDctOTU5NS1iNWZkN"
                                        + "2VhMzgyZjYiLCJwbGF0ZiI6IjMiLCJwdWlkIjoiMTAwMzAwMDA5QUJGRTQyRiIsInNjcCI6InVzZXJfa"
                                        + "W1wZXJzb25hdGlvbiIsInN1YiI6ImEyUE5ZZW9KSnk3VnFFVWVkb0ZxS0J6UUNjOWNUN2tCVWtSYm5BM"
                                        + "ldLcnciLCJ0aWQiOiIwNDU0NmJjMC1iYzE5LTRjYjYtYjE2ZC01NzQ5NDE3MWE0YmMiLCJ1bmlxdWVfb"
                                        + "mFtZSI6ImF6dGVzdDBAc3RhYmxldGVzdC5jY3NjdHAubmV0IiwidXBuIjoiYXp0ZXN0MEBzdGFibGV0Z"
                                        + "XN0LmNjc2N0cC5uZXQiLCJ2ZXIiOiIxLjAiLCJ3aWRzIjpbIjYyZTkwMzk0LTY5ZjUtNDIzNy05MTkwL"
                                        + "TAxMjE3NzE0NWUxMCJdfQ.W9eVq_TXGBjWCCl_tRGXM31OZn5G4UBIi6B9xZphvrpaAvu5tnzYm6XWah"
                                        + "jwA_iE1djOpZM3rxFxP4ZFecVyZGHYVddSJ0rg6vw-L4J5jIPDSojqiGoSLtU8yFxEDRaro0SM4LdQ_N"
                                        + "dF-oUwfUQGy88vLOejQdiKzfC-yFvtVSmYoyJSnkZLglDEbhySvLtjXGfpOgiyGLoncV5wTk6Vbf7VLe"
                                        + "65kxhZWVUbTHaPuEvg03ZQ3esDb6wxQewJPAL-GARg6S9wIN776Esw8-53AWhzFu0fIut-9FXGma6jV7"
                                        + "MYPoUUcFuQzLZgphecPyMPXSVhummVCdBwX9sizxnmFA";

        public DataPlaneCommandTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureASAccountCommand()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            var addAmdlet = new AddAzureASAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
            var expectedProfile = new AsAzureProfile
            {
                Context = new AsAzureContext(
                    new AsAzureAccount()
                    {
                        Id = testUser,
                        Tenant = null
                    },
                    new AsAzureEnvironment(testAsAzureEnvironment))
            };
            expectedProfile.Context.Environment.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl, AsAzureClientSession.GetAuthorityUrlForEnvironment(expectedProfile.Context.Environment));
            expectedProfile.Context.Environment.Endpoints.Add(AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat, AsAzureClientSession.RestartEndpointPathFormat);
            expectedProfile.Environments.Add(testAsAzureEnvironment, expectedProfile.Context.Environment);
            expectedProfile.Context.TokenCache = Encoding.ASCII.GetBytes(testToken);

            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();

            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);

            addAmdlet.RolloutEnvironment = testAsAzureEnvironment;
            var password = new SecureString();
            var testpwd = testPassword;
            testpwd.All(c => {
                password.AppendChar(c);
                return true;
            });
            addAmdlet.Credential = new PSCredential(testUser, password);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.WriteObject(expectedProfile));

            // Act
            addAmdlet.InvokeBeginProcessing();
            Assert.Empty(AsAzureClientSession.Instance.Profile.Environments);
            addAmdlet.ExecuteCmdlet();
            Assert.True(AsAzureClientSession.Instance.Profile.Environments.Count == 1);
            Assert.NotNull(AsAzureClientSession.Instance.Profile.Environments[testAsAzureEnvironment]);

            // Call InvokeBeginProcessing again to get coverage. It should use the existing environment in memory not create a new one.
            addAmdlet.InvokeBeginProcessing();
            Assert.True(AsAzureClientSession.Instance.Profile.Environments.Count == 1);
            Assert.NotNull(AsAzureClientSession.Instance.Profile.Environments[testAsAzureEnvironment]);

            addAmdlet.InvokeEndProcessing();

            var environment = (AsAzureEnvironment)AsAzureClientSession.Instance.Profile.Environments[testAsAzureEnvironment];
            Assert.Equal(environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.AdAuthorityBaseUrl], AsAzureClientSession.GetAuthorityUrlForEnvironment(environment));
            Assert.NotNull(environment.Endpoints[AsAzureEnvironment.AsRolloutEndpoints.RestartEndpointFormat]);

            commandRuntimeMock.Verify(f => f.WriteObject(AsAzureClientSession.Instance.Profile));
            mockAuthenticationProvider.Verify(authProvider => authProvider.GetAadAuthenticatedToken(It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartAzureASInstance_Succeeds()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();
            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Set up AsAzureHttpClient mock
            var mockAsAzureHttpClient = new Mock<IAsAzureHttpClient>();
            mockAsAzureHttpClient
                .Setup(obj => obj.CallPostAsync(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<HttpContent>()))
                .Returns(Task<HttpResponseMessage>.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));

            var mockTokenCacheItemProvider = new Mock<ITokenCacheItemProvider>();
            mockTokenCacheItemProvider
                .Setup(obj => obj.GetTokenFromTokenCache(It.IsAny<TokenCache>(), It.IsAny<string>()))
                .Returns(testToken);
            var restartCmdlet = new RestartAzureAnalysisServer(mockAsAzureHttpClient.Object, mockTokenCacheItemProvider.Object)
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            var addAmdlet = new AddAzureASAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            DoLogin(addAmdlet);
            restartCmdlet.Instance = testServer;

            // Act
            restartCmdlet.InvokeBeginProcessing();
            restartCmdlet.ExecuteCmdlet();
            restartCmdlet.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartAzureASInstance_NullInstanceThrows()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();

            var mockAsAzureHttpClient = new Mock<IAsAzureHttpClient>();
            var mockTokenCacheItemProvider = new Mock<ITokenCacheItemProvider>();
            var restartCmdlet = new RestartAzureAnalysisServer(mockAsAzureHttpClient.Object, mockTokenCacheItemProvider.Object)
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();
            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            restartCmdlet.Instance = null;
            // Act
            Assert.Throws<TargetInvocationException>(() => restartCmdlet.InvokeBeginProcessing());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartAzureASInstance_NotLoggedInThrows()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();

            var mockAsAzureHttpClient = new Mock<IAsAzureHttpClient>();
            var mockTokenCacheItemProvider = new Mock<ITokenCacheItemProvider>();
            var restartCmdlet = new RestartAzureAnalysisServer(mockAsAzureHttpClient.Object, mockTokenCacheItemProvider.Object)
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();
            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            restartCmdlet.Instance = testServer;

            // Act
            try
            {
                restartCmdlet.InvokeBeginProcessing();
            }
            catch(Exception ex)
            {
                Assert.IsType<TargetInvocationException>(ex);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExportAzureASInstanceLogTest()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();
            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Set up AsAzureHttpClient mock
            var mockAsAzureHttpClient = new Mock<IAsAzureHttpClient>();
            mockAsAzureHttpClient
                .Setup(obj => obj.CallPostAsync(
                    It.IsAny<Uri>(),
                    It.Is<string>(s => s.Contains("clusterResolve")),
                    It.IsAny<string>(),
                    It.IsAny<HttpContent>()))
                .Returns(Task<HttpResponseMessage>.FromResult(
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("{\"clusterFQDN\": \"resolved.westcentralus.asazure.windows.net\"}")
                    }));
            mockAsAzureHttpClient.Setup(obj => obj.CallGetAsync(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<string>())).Returns(
                Task<HttpResponseMessage>.FromResult(
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("MOCKED STREAM CONTENT")
                    }));

            var mockTokenCacheItemProvider = new Mock<ITokenCacheItemProvider>();
            mockTokenCacheItemProvider
                .Setup(obj => obj.GetTokenFromTokenCache(It.IsAny<TokenCache>(), It.IsAny<string>()))
                .Returns(testToken);

            var exportLogCmdlet = new ExportAzureAnalysisServerLog(mockAsAzureHttpClient.Object, mockTokenCacheItemProvider.Object)
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            var addAmdlet = new AddAzureASAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            DoLogin(addAmdlet);
            exportLogCmdlet.Instance = testServer;
            try
            {
                exportLogCmdlet.OutputPath = System.IO.Path.GetTempFileName();
                exportLogCmdlet.InvokeBeginProcessing();
                exportLogCmdlet.ExecuteCmdlet();
                exportLogCmdlet.InvokeEndProcessing();
            }
            finally
            {
                if (System.IO.File.Exists(exportLogCmdlet.OutputPath))
                {
                    System.IO.File.Delete(exportLogCmdlet.OutputPath);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SynchronizeAzureASInstance_SingleDB_Succeeds()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            
            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();
            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Set up AsAzureHttpClient mock
            var mockAsAzureHttpClient = new Mock<IAsAzureHttpClient>();

            // set up cluster resolve respnose
            ClusterResolutionResult resolveResult = new ClusterResolutionResult()
            {
                ClusterFQDN = "resolved.westcentralus.asazure.windows.net",
                CoreServerName = testServer + ":rw",
                TenantId = Guid.NewGuid().ToString()
            };
            mockAsAzureHttpClient
                .Setup(obj => obj.CallPostAsync(
                    It.IsAny<Uri>(),
                    It.Is<string>(s => s.Contains("clusterResolve")),
                    It.IsAny<string>(),
                    It.IsAny<HttpContent>()))
                .Returns(Task<HttpResponseMessage>.FromResult(
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(resolveResult))
                    }));

            // set up sync respnose
            var postResponse = new HttpResponseMessage(HttpStatusCode.Accepted);
            postResponse.Headers.Location = new Uri("https://done");
            postResponse.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMilliseconds(500));
            postResponse.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            postResponse.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());
            mockAsAzureHttpClient
                .Setup(obj => obj.CallPostAsync(
                    It.IsAny<Uri>(),
                    It.Is<string>(s => s.Contains("sync")),
                    It.IsAny<string>(),
                    It.IsAny<Guid>(),
                    null))
                .Returns(Task<Mock<HttpResponseMessage>>.FromResult(postResponse));


            var getResponse1 = new HttpResponseMessage(HttpStatusCode.SeeOther);
            getResponse1.Headers.Location = new Uri("https://done");
            getResponse1.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMilliseconds(500));
            mockAsAzureHttpClient
                .Setup(obj => obj.CallGetAsync(
                    It.Is<Uri>(u => u.OriginalString.Contains("1")),
                    string.Empty,
                    It.IsAny<string>(),
                    It.IsAny<Guid>()))
                .Returns(Task<HttpResponseMessage>.FromResult(getResponse1));

            var getResponseSucceed = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                        "{\n\"database\":\"db0\",\n\"syncstate\":\"Completed\"\n}", Encoding.UTF8, "application/json")
            };

            var getResponseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            var finalResponses = new Queue<HttpResponseMessage>(new [] { getResponseError, getResponseSucceed });
            mockAsAzureHttpClient
                .Setup(obj => obj.CallGetAsync(
                    It.Is<Uri>(u => u.OriginalString.Contains("done")),
                    string.Empty,
                    It.IsAny<string>(),
                    It.IsAny<Guid>()))
                .Returns(() => Task.FromResult(finalResponses.Dequeue()));

            var mockTokenCacheItemProvider = new Mock<ITokenCacheItemProvider>();
            mockTokenCacheItemProvider
                .Setup(obj => obj.GetTokenFromTokenCache(It.IsAny<TokenCache>(), It.IsAny<string>()))
                .Returns(testToken);
            var syncCmdlet = new SynchronizeAzureAzureAnalysisServer(mockAsAzureHttpClient.Object, mockTokenCacheItemProvider.Object)
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            var addAmdlet = new AddAzureASAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            DoLogin(addAmdlet);
            syncCmdlet.Instance = testServer + ":rw";
            syncCmdlet.Database = "db0";

            // Act
            syncCmdlet.InvokeBeginProcessing();
            syncCmdlet.ExecuteCmdlet();
            syncCmdlet.InvokeEndProcessing();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SynchronizeAzureASInstance_FailsAfterTooManyRetries()
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();

            // Setup
            // Clear the the current profile
            AsAzureClientSession.Instance.Profile.Environments.Clear();
            var mockAuthenticationProvider = new Mock<IAsAzureAuthenticationProvider>();
            mockAuthenticationProvider.Setup(
                authProvider => authProvider.GetAadAuthenticatedToken(
                    It.IsAny<AsAzureContext>(),
                    It.IsAny<SecureString>(),
                    It.IsAny<PromptBehavior>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Uri>())).Returns(testToken);
            AsAzureClientSession.Instance.SetAsAzureAuthenticationProvider(mockAuthenticationProvider.Object);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Set up AsAzureHttpClient mock
            var mockAsAzureHttpClient = new Mock<IAsAzureHttpClient>();

            // set up cluster resolve respnose
            ClusterResolutionResult resolveResult = new ClusterResolutionResult()
            {
                ClusterFQDN = "resolved.westcentralus.asazure.windows.net",
                CoreServerName = testServer + ":rw",
                TenantId = Guid.NewGuid().ToString()
            };
            mockAsAzureHttpClient
                .Setup(obj => obj.CallPostAsync(
                    It.IsAny<Uri>(),
                    It.Is<string>(s => s.Contains("clusterResolve")),
                    It.IsAny<string>(),
                    It.IsAny<HttpContent>()))
                .Returns(Task<HttpResponseMessage>.FromResult(
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(resolveResult))
                    }));

            // set up sync respnose
            var postResponse = new HttpResponseMessage(HttpStatusCode.Accepted);
            postResponse.Headers.Location = new Uri("https://1");
            postResponse.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMilliseconds(500));
            postResponse.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            postResponse.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());
            mockAsAzureHttpClient
                .Setup(obj => obj.CallPostAsync(
                    It.IsAny<Uri>(),
                    It.Is<string>(s => s.Contains("sync")),
                    It.IsAny<string>(),
                    It.IsAny<Guid>(),
                    null))
                .Returns(Task<Mock<HttpResponseMessage>>.FromResult(postResponse));

            var getResponse1 = new HttpResponseMessage(HttpStatusCode.SeeOther);
            getResponse1.Headers.Location = new Uri("https://done");
            getResponse1.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMilliseconds(500));
            getResponse1.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            getResponse1.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());
            mockAsAzureHttpClient
                .Setup(obj => obj.CallGetAsync(
                    It.Is<Uri>(u => u.OriginalString.Contains("1")),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Guid>()))
                .Returns(Task<HttpResponseMessage>.FromResult(getResponse1));

            var getResponseSucceed = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                        "{\n\"database\":\"db0\",\n\"syncstate\":\"Completed\"\n}", Encoding.UTF8, "application/json")
            };
            getResponseSucceed.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            getResponseSucceed.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());

            var getResponseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            getResponseError.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            getResponseError.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());

            var finalResponses = new Queue<HttpResponseMessage>(new[] { getResponseError, getResponseError, getResponseError, getResponseSucceed });
            mockAsAzureHttpClient
                .Setup(obj => obj.CallGetAsync(
                    It.Is<Uri>(u => u.OriginalString.Contains("done")),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<Guid>()))
                .Returns(() => Task.FromResult(finalResponses.Dequeue()));

            var mockTokenCacheItemProvider = new Mock<ITokenCacheItemProvider>();
            mockTokenCacheItemProvider
                .Setup(obj => obj.GetTokenFromTokenCache(It.IsAny<TokenCache>(), It.IsAny<string>()))
                .Returns(testToken);
            var syncCmdlet = new SynchronizeAzureAzureAnalysisServer(mockAsAzureHttpClient.Object, mockTokenCacheItemProvider.Object)
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            var addAmdlet = new AddAzureASAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };

            DoLogin(addAmdlet);
            syncCmdlet.Instance = testServer + ":rw";
            syncCmdlet.Database = "db0";

            // Act
            syncCmdlet.InvokeBeginProcessing();
            Assert.Throws<SynchronizationFailedException>(() => syncCmdlet.ExecuteCmdlet());
            syncCmdlet.InvokeEndProcessing();
        }
        
        private void DoLogin(AddAzureASAccountCommand addCmdlet)
        {
            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();

            addCmdlet.RolloutEnvironment = testAsAzureEnvironment;
            var password = new SecureString();
            var testpwd = testPassword;
            testpwd.All(c => {
                password.AppendChar(c);
                return true;
            });
            addCmdlet.Credential = new PSCredential(testUser, password);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Act
            addCmdlet.InvokeBeginProcessing();
            addCmdlet.ExecuteCmdlet();
            AsAzureClientSession.TokenCache.Deserialize(Encoding.ASCII.GetBytes(testToken));
            addCmdlet.InvokeEndProcessing();
        }
    }
}

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
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models;
using Microsoft.Azure.Commands.AnalysisServices.Test.ScenarioTests;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.AnalysisServices.Test.InMemoryTests
{
    public class DataPlaneCommandTests : AsTestsBase
    {
        private const string testInstance = "asazure://westcentralus.asazure.windows.net/testserver";

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
            SynchronizeAzureAzureAnalysisServer.DefaultRetryIntervalForPolling = TimeSpan.FromSeconds(0);
        }

        #region TestAuthentication

        private class TestAuthenticationCmdlet : AsAzureDataplaneCmdletBase { }

        // TODO: this needs a valid mocked context in order to test authentication.
        //[Fact]
        //[Trait(Category.AcceptanceType, Category.CheckIn)]
        //public void Authentication_Succeeds()
        //{
        //    var context = new PSAzureContext();
        //    TestAuthentication(context);
        //}

        /// <summary>
        /// Assert that cmdlets will fail authentication when provided null context.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Authentication_FailsFromNullContext()
        {
            Assert.Throws<TargetInvocationException>(() => TestAuthentication(null));
        }

        /// <summary>
        /// Assert that cmdlets will fail authentication when provided bad context.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Authentication_FailsFromBadContext()
        {
            Assert.Throws<TargetInvocationException>(() => TestAuthentication(new PSAzureContext()));
        }

        /// <summary>
        /// Common code used for testing authentication.
        /// </summary>
        /// <param name="context"></param>
        private void TestAuthentication(IAzureContext context)
        {
            var cmdlet = new TestAuthenticationCmdlet()
            {
                CurrentContext = context
            };
            cmdlet.InvokeBeginProcessing();
            cmdlet.InvokeEndProcessing();
        }

        #endregion
        #region TestRestart

        /// <summary>
        /// Assert that the restart cmdlet will fail if given a null instance.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartAzureASInstance_NullInstanceThrows()
        {
            var restartCmdlet = CreateTestRestartCmdlet(null);
            Assert.Throws<TargetInvocationException>(() => restartCmdlet.InvokeBeginProcessing());
        }

        /// <summary>
        /// Assert that the restart cmdlet will fail if given a bad instance url.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartAzureASInstance_InvalidInstanceThrows()
        {
            var restartCmdlet = CreateTestRestartCmdlet("https://bad.uri.com");
            Assert.Throws<TargetInvocationException>(() => restartCmdlet.InvokeBeginProcessing());
        }

        /// <summary>
        /// Assert that the restart cmdlet executes successfully.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartAzureASInstance_Succeeds()
        {
            var restartCmdlet = CreateTestRestartCmdlet(testInstance);
            // Set up mock http client
            var mockHttpClient = new Mock<IAsAzureHttpClient>();
            mockHttpClient
                .Setup(m => m.CallPostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .Returns(Task<HttpResponseMessage>.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            restartCmdlet.AsAzureDataplaneClient = mockHttpClient.Object;

            restartCmdlet.InvokeBeginProcessing();
            restartCmdlet.ExecuteCmdlet();
            restartCmdlet.InvokeEndProcessing();
        }

        /// <summary>
        /// Create a properly mocked restart cmdlet.
        /// </summary>
        /// <param name="instance">The test server instance name.</param>
        /// <returns>A properly mocked restart cmdlet.</returns>
        private static RestartAzureAnalysisServer CreateTestRestartCmdlet(string instance)
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var cmdlet = new RestartAzureAnalysisServer()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Instance = instance
            };

            return cmdlet;
        }

        #endregion
        #region TestExportLog

        /// <summary>
        /// Assert that the export cmdlet works.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExportAzureASInstanceLogTest()
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var mockHttpClient = new Mock<IAsAzureHttpClient>();
            mockHttpClient
                .Setup(m => m.CallGetAsync(It.IsAny<string>()))
                .Returns(Task<HttpResponseMessage>.FromResult(
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("MOCKED STREAM CONTENT")
                    }));

            var exportCmdlet = new ExportAzureAnalysisServerLog()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Instance = testInstance,
                OutputPath = System.IO.Path.GetTempFileName(),
                AsAzureDataplaneClient = mockHttpClient.Object
            };

            try
            {
                exportCmdlet.InvokeBeginProcessing();
                exportCmdlet.ExecuteCmdlet();
                exportCmdlet.InvokeEndProcessing();
            }
            finally
            {
                if (System.IO.File.Exists(exportCmdlet.OutputPath))
                {
                    System.IO.File.Delete(exportCmdlet.OutputPath);
                }
            }
        }

        #endregion
        #region TestSync

        /// <summary>
        /// Assert that the sync cmdlet succeeds syncing a single db instance.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SynchronizeAzureASInstance_SingleDB_Succeeds()
        {
            var syncCmdlet = CreateTestSyncCmdlet();
            syncCmdlet.InvokeBeginProcessing();
            syncCmdlet.ExecuteCmdlet();
            syncCmdlet.InvokeEndProcessing();
        }

        /// <summary>
        /// Assert that the sync cmdlet will fail after too many retries.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SynchronizeAzureASInstance_FailsAfterTooManyRetries()
        {
            var syncCmdlet = CreateTestSyncCmdlet(tooManyRetries: true);
            syncCmdlet.InvokeBeginProcessing();
            Assert.Throws<SynchronizationFailedException>(() => syncCmdlet.ExecuteCmdlet());
            syncCmdlet.InvokeEndProcessing();
        }

        /// <summary>
        /// Create a properly mocked Sync cmdlet for testing.
        /// </summary>
        /// <param name="tooManyRetries">Flag to set the planned failures to be greater than the retry count.</param>
        /// <returns>A properly mocked sync cmdlet for testing.</returns>
        private SynchronizeAzureAzureAnalysisServer CreateTestSyncCmdlet(bool tooManyRetries = false)
        {
            // Set up mock http client
            var mockHttpClient = new Mock<IAsAzureHttpClient>();

            var postResponse = new HttpResponseMessage(HttpStatusCode.Accepted);
            postResponse.Headers.Location = new Uri("https://done");
            postResponse.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMilliseconds(500));
            postResponse.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            postResponse.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());
            mockHttpClient
                .Setup(m => m.CallPostAsync(
                    It.IsAny<Uri>(),
                    It.Is<string>(s => s.Contains("sync")),
                    It.IsAny<Guid>(),
                    null))
                .Returns(Task<Mock<HttpResponseMessage>>.FromResult(postResponse));

            var getResponse = new HttpResponseMessage(HttpStatusCode.SeeOther);
            getResponse.Headers.Location = new Uri("https://done");
            getResponse.Headers.RetryAfter = new RetryConditionHeaderValue(TimeSpan.FromMilliseconds(500));
            getResponse.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            getResponse.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());
            mockHttpClient
                .Setup(m => m.CallGetAsync(
                    It.Is<Uri>(u => u.OriginalString.Contains("1")),
                    string.Empty,
                    It.IsAny<Guid>()))
                .Returns(Task<HttpResponseMessage>.FromResult(getResponse));

            var getResponseSucceed = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\n\"database\":\"db0\",\n\"syncstate\":\"Completed\"\n}", Encoding.UTF8, "application/json")
            };
            getResponseSucceed.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            getResponseSucceed.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());

            var getResponseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            getResponseError.Headers.Add("x-ms-root-activity-id", Guid.NewGuid().ToString());
            getResponseError.Headers.Add("x-ms-current-utc-date", Guid.NewGuid().ToString());

            var finalResponses = tooManyRetries ?
                new Queue<HttpResponseMessage>(new[] { getResponseError, getResponseError, getResponseError, getResponseSucceed }) :
                new Queue<HttpResponseMessage>(new[] { getResponseError, getResponseSucceed });

            mockHttpClient
                .Setup(m => m.CallGetAsync(
                    It.Is<Uri>(u => u.OriginalString.Contains("done")),
                    string.Empty,
                    It.IsAny<Guid>()))
                .Returns(() => Task.FromResult(finalResponses.Dequeue()));

            Mock<ICommandRuntime> commandRuntimeMock = new Mock<ICommandRuntime>();
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var cmdlet = new SynchronizeAzureAzureAnalysisServer()
            {
                CommandRuntime = commandRuntimeMock.Object,
                Instance = testInstance + ":rw",
                Database = "db0",
                AsAzureDataplaneClient = mockHttpClient.Object
            };

            return cmdlet;
        }

        #endregion
    }
}

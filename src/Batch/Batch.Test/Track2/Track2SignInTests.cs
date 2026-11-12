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

using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2SignInTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string UsGovBatchResource = "https://batch.core.usgovcloudapi.net/";
        private const string AccountUrl = "https://account.usgovvirginia.batch.usgovcloudapi.net";
        private const string MinimalPoolJson = "{\"id\":\"pool1\",\"vmSize\":\"standard_d2s_v3\",\"state\":\"active\"}";

        public Track2SignInTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
        }

        private static IAzureContext CreateContext(IAzureEnvironment environment)
        {
            return new AzureContext(
                new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "test" },
                new AzureAccount { Id = "user@contoso.com", Type = AzureAccount.AccountType.User },
                environment,
                new AzureTenant { Id = Guid.NewGuid().ToString() });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Track2ClientGetsTheTokenForTheBatchResourceOfTheCurrentCloud()
        {
            // A made-up US Government cloud: only its Batch resource matters here.
            AzureEnvironment usGov = new AzureEnvironment { Name = "FakeUSGovernment" };
            usGov.SetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory, "https://login.microsoftonline.us/");
            usGov.SetEndpoint(AzureEnvironment.Endpoint.BatchEndpointResourceId, UsGovBatchResource);

            RecordingAuthenticationFactory signIn = new RecordingAuthenticationFactory();
            IAuthenticationFactory original = AzureSession.Instance.AuthenticationFactory;
            AzureSession.Instance.AuthenticationFactory = signIn;
            try
            {
                RecordingHandler service = new RecordingHandler().On("GET /pools/pool1", HttpStatusCode.OK, MinimalPoolJson);
                Track2TestContext context = new Track2TestContext(CreateContext(usGov), "account", AccountUrl, service);

                Assert.Equal("pool1", context.Track2Client.GetPool("pool1").Value.Id);

                // Az.Accounts was asked for this cloud's Batch resource (not the public-cloud scope Azure.Compute.Batch requests) ...
                Assert.Same(usGov, signIn.Environment);
                Assert.Equal(AzureEnvironment.Endpoint.BatchEndpointResourceId, signIn.ResourceId);
                // ... and that token is the one sent to the service.
                RecordedRequest request = service.Requests.Single();
                Assert.Equal("Bearer token-for-" + UsGovBatchResource, request.Authorization);
                Assert.Equal("account.usgovvirginia.batch.usgovcloudapi.net", request.Uri.Host);
                Assert.Contains("api-version=2025-06-01", request.Uri.Query);
                Assert.StartsWith("AzurePowershell/", request.UserAgent);
                Assert.Contains("azsdk-net-Compute.Batch/", request.UserAgent);
            }
            finally
            {
                AzureSession.Instance.AuthenticationFactory = original;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Track2ClientUsesSharedKeyWhenTheContextHasKeys()
        {
            RecordingAuthenticationFactory signIn = new RecordingAuthenticationFactory();
            IAuthenticationFactory original = AzureSession.Instance.AuthenticationFactory;
            AzureSession.Instance.AuthenticationFactory = signIn;
            try
            {
                RecordingHandler service = new RecordingHandler().On("GET /pools/pool1", HttpStatusCode.OK, MinimalPoolJson);
                string key = Convert.ToBase64String(Encoding.UTF8.GetBytes("not-a-real-key-not-a-real-key-00"));
                Track2TestContext context = new Track2TestContext(null, "account", "https://account.westus.batch.azure.com", service, key);

                context.Track2Client.GetPool("pool1");

                Assert.StartsWith("SharedKey account:", service.Requests.Single().Authorization);
                Assert.Equal(0, signIn.Calls);
            }
            finally
            {
                AzureSession.Instance.AuthenticationFactory = original;
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TokenExpiryComesFromTheTokenItself()
        {
            DateTimeOffset expires = new DateTimeOffset(2030, 1, 1, 0, 0, 0, TimeSpan.Zero);
            string payload = Convert.ToBase64String(Encoding.UTF8.GetBytes("{\"aud\":\"https://batch.core.usgovcloudapi.net/\",\"exp\":" + expires.ToUnixTimeSeconds() + "}"))
                .TrimEnd('=').Replace('+', '-').Replace('/', '_');

            Assert.Equal(expires, BatchTokenCredential.GetExpiresOn("eyJhbGciOiJub25lIn0." + payload + ".sig"));

            // Not a JWT: fall back to "now", so Azure.Core asks again on the next request.
            DateTimeOffset fallback = BatchTokenCredential.GetExpiresOn("token-for-test");
            Assert.InRange(fallback, DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow.AddMinutes(1));
        }
    }
}

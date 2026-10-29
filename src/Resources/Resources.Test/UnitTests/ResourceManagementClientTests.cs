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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.TestFx.Mocks;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests
{
    public class ResourceManagementClientTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DefaultTimeoutAllowsLongDeploymentValidation()
        {
            using (var client = new ResourceManagementClient(new TokenCredentials("test-token")))
            {
                var wrapper = CreateProductionClient(client);
                Assert.Same(client, wrapper.ResourceManagementClient);
                Assert.Equal(TimeSpan.FromMinutes(5), client.HttpClient.Timeout);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StandaloneSdkClientKeepsDefaultTimeout()
        {
            using (var handler = new HttpClientHandler())
            using (var client = new ResourceManagementClient(
                new Uri("https://management.example.com"),
                new TokenCredentials("test-token"),
                handler))
            {
                Assert.Equal(TimeSpan.FromSeconds(100), client.HttpClient.Timeout);
            }
        }

        [Theory]
        [InlineData(100, 100)]
        [InlineData(30, 30)]
        [InlineData(600, 600)]
        [InlineData(-1, -1)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InjectedSdkClientPreservesTimeout(int timeoutSeconds, int expectedSeconds)
        {
            var timeout = timeoutSeconds == -1 ? Timeout.InfiniteTimeSpan : TimeSpan.FromSeconds(timeoutSeconds);
            var expectedTimeout = expectedSeconds == -1 ? Timeout.InfiniteTimeSpan : TimeSpan.FromSeconds(expectedSeconds);
            using (var httpClient = new HttpClient { Timeout = timeout })
            using (var client = new ResourceManagementClient(
                new TokenCredentials("test-token"), httpClient, disposeHttpClient: false))
            {
                var wrapper = new NewResourceManagerSdkClient(client);
                Assert.Same(client, wrapper.ResourceManagementClient);
                Assert.Same(httpClient, client.HttpClient);
                Assert.Equal(expectedTimeout, client.HttpClient.Timeout);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task LongerDefaultTimeoutStillHonorsCancellation()
        {
            using (var handler = new WaitingHandler())
            using (var httpClient = new HttpClient(handler))
            using (var client = new ResourceManagementClient(
                new TokenCredentials("test-token"), httpClient, disposeHttpClient: false))
            using (var cancellation = new CancellationTokenSource())
            {
                CreateProductionClient(client);
                var request = client.HttpClient.GetAsync("https://management.example.com", cancellation.Token);
                await handler.Started.Task;

                cancellation.Cancel();

                await Assert.ThrowsAnyAsync<OperationCanceledException>(() => request);
                Assert.Equal(TimeSpan.FromMinutes(5), client.HttpClient.Timeout);
            }
        }

        private NewResourceManagerSdkClient CreateProductionClient(ResourceManagementClient client)
        {
            var originalFactory = AzureSession.Instance.ClientFactory;
            try
            {
                AzureSession.Instance.ClientFactory = new MockClientFactory(null, new object[] { client });
                return new NewResourceManagerSdkClient(currentProfile.DefaultContext);
            }
            finally
            {
                AzureSession.Instance.ClientFactory = originalFactory;
            }
        }

        private class WaitingHandler : HttpMessageHandler
        {
            public TaskCompletionSource<bool> Started { get; } =
                new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            protected override async Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Started.SetResult(true);
                await Task.Delay(Timeout.Infinite, cancellationToken);
                return new HttpResponseMessage();
            }
        }
    }
}

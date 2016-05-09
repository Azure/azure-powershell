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

using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class RPRegistrationDelegatingHandlerTests : RMTestBase
    {
        private const string compatibleUri = "https://management.azure.com/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.Compute/virtualMachines/{vm-name}?validating={true|false}&api-version={api-version}";

        private const string incompatibleUri = "https://management.core.windows.net/<subscription-id>";

        public RPRegistrationDelegatingHandlerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvokeRegistrationForUnregisteredResourceProviders()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProviderOperations> mockProvidersOperations = new Mock<IProviderOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            mockProvidersOperations.Setup(f => f.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(
                (string rp, CancellationToken token) =>
                {
                    ProviderGetResult r = new ProviderGetResult
                    {
                        Provider = new Provider
                        {
                            RegistrationState = RegistrationState.Registered.ToString()
                        }
                    };

                    return Task.FromResult(r);
                }
                );
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, compatibleUri);
            Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping = new Dictionary<HttpRequestMessage, List<HttpResponseMessage>>
            {
                {
                    request, new List<HttpResponseMessage>
                    {
                        new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("registered to use namespace") },
                        new HttpResponseMessage(HttpStatusCode.Accepted) { Content = new StringContent("Azure works!") }
                    }
                }
            };
            List<string> msgs = new List<string>();
            RPRegistrationDelegatingHandler rpHandler = new RPRegistrationDelegatingHandler(() => mockClient.Object, s => msgs.Add(s))
            {
                InnerHandler = new MockResponseDelegatingHandler(mapping)
            };
            HttpClient httpClient = new HttpClient(rpHandler);

            // Test
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // Assert
            Assert.True(msgs.Any(s => s.Equals("Succeeded to register resource provider 'microsoft.compute'")));
            Assert.Equal(response.StatusCode, HttpStatusCode.Accepted);
            Assert.Equal(response.Content.ReadAsStringAsync().Result, "Azure works!");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotInvokeRegistrationForRegisteredResourceProviders()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProviderOperations> mockProvidersOperations = new Mock<IProviderOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, compatibleUri);
            Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping = new Dictionary<HttpRequestMessage, List<HttpResponseMessage>>
            {
                {
                    request, new List<HttpResponseMessage>
                    {
                        new HttpResponseMessage(HttpStatusCode.Accepted) { Content = new StringContent("Azure works!") }
                    }
                }
            };
            List<string> msgs = new List<string>();
            RPRegistrationDelegatingHandler rpHandler = new RPRegistrationDelegatingHandler(() => mockClient.Object, s => msgs.Add(s))
            {
                InnerHandler = new MockResponseDelegatingHandler(mapping)
            };
            HttpClient httpClient = new HttpClient(rpHandler);

            // Test
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // Assert
            Assert.Equal(0, msgs.Count);
            Assert.Equal(response.StatusCode, HttpStatusCode.Accepted);
            Assert.Equal(response.Content.ReadAsStringAsync().Result, "Azure works!");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotInvokeRegistrationForUnrelatedStatusCode()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProviderOperations> mockProvidersOperations = new Mock<IProviderOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, compatibleUri);
            Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping = new Dictionary<HttpRequestMessage, List<HttpResponseMessage>>
            {
                {
                    request, new List<HttpResponseMessage>
                    {
                        new HttpResponseMessage(HttpStatusCode.Forbidden) { Content = new StringContent("auth error!") }
                    }
                }
            };
            List<string> msgs = new List<string>();
            RPRegistrationDelegatingHandler rpHandler = new RPRegistrationDelegatingHandler(() => mockClient.Object, s => msgs.Add(s))
            {
                InnerHandler = new MockResponseDelegatingHandler(mapping)
            };
            HttpClient httpClient = new HttpClient(rpHandler);

            // Test
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // Assert
            Assert.Equal(0, msgs.Count);
            Assert.Equal(response.StatusCode, HttpStatusCode.Forbidden);
            Assert.Equal(response.Content.ReadAsStringAsync().Result, "auth error!");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotInvokeRegistrationForIncompatibleUri()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProviderOperations> mockProvidersOperations = new Mock<IProviderOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, incompatibleUri);
            Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping = new Dictionary<HttpRequestMessage, List<HttpResponseMessage>>
            {
                {
                    request, new List<HttpResponseMessage>
                    {
                        new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("registered to use namespace") }
                    }
                }
            };
            List<string> msgs = new List<string>();
            RPRegistrationDelegatingHandler rpHandler = new RPRegistrationDelegatingHandler(() => mockClient.Object, s => msgs.Add(s))
            {
                InnerHandler = new MockResponseDelegatingHandler(mapping)
            };
            HttpClient httpClient = new HttpClient(rpHandler);

            // Test
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // Assert
            Assert.Equal(0, msgs.Count);
            Assert.Equal(response.StatusCode, HttpStatusCode.Conflict);
            Assert.Equal(response.Content.ReadAsStringAsync().Result, "registered to use namespace");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotHangForLongRegistrationCalls()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProviderOperations> mockProvidersOperations = new Mock<IProviderOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            mockProvidersOperations.Setup(f => f.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(
                (string rp, CancellationToken token) =>
                {
                    ProviderGetResult r = new ProviderGetResult
                    {
                        Provider = new Provider
                        {
                            RegistrationState = RegistrationState.Pending.ToString()
                        }
                    };

                    return Task.FromResult(r);
                }
                );
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, compatibleUri);
            Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping = new Dictionary<HttpRequestMessage, List<HttpResponseMessage>>
            {
                {
                    request, new List<HttpResponseMessage>
                    {
                        new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("registered to use namespace") },
                        new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("registered to use namespace") }
                    }
                }
            };
            List<string> msgs = new List<string>();
            RPRegistrationDelegatingHandler rpHandler = new RPRegistrationDelegatingHandler(() => mockClient.Object, s => msgs.Add(s))
            {
                InnerHandler = new MockResponseDelegatingHandler(mapping)
            };
            HttpClient httpClient = new HttpClient(rpHandler);

            // Test
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // Assert
            Assert.True(msgs.Any(s => s.Equals("Failed to register resource provider 'microsoft.compute'.Details: 'The operation has timed out.'")));
            Assert.Equal(response.StatusCode, HttpStatusCode.Conflict);
            Assert.Equal(response.Content.ReadAsStringAsync().Result, "registered to use namespace");
            mockProvidersOperations.Verify(f => f.RegisterAsync("microsoft.compute", It.IsAny<CancellationToken>()), Times.AtMost(4));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotThrowForFailedRegistrationCall()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProviderOperations> mockProvidersOperations = new Mock<IProviderOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            mockProvidersOperations.Setup(f => f.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new CloudException("PR reg failed"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, compatibleUri);
            Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping = new Dictionary<HttpRequestMessage, List<HttpResponseMessage>>
            {
                {
                    request, new List<HttpResponseMessage>
                    {
                        new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("registered to use namespace") },
                        new HttpResponseMessage(HttpStatusCode.Conflict) { Content = new StringContent("registered to use namespace") }
                    }
                }
            };
            List<string> msgs = new List<string>();
            RPRegistrationDelegatingHandler rpHandler = new RPRegistrationDelegatingHandler(() => mockClient.Object, s => msgs.Add(s))
            {
                InnerHandler = new MockResponseDelegatingHandler(mapping)
            };
            HttpClient httpClient = new HttpClient(rpHandler);

            // Test
            HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // Assert
            Assert.True(msgs.Any(s => s.Equals("Failed to register resource provider 'microsoft.compute'.Details: 'PR reg failed'")));
            Assert.Equal(response.StatusCode, HttpStatusCode.Conflict);
            Assert.Equal(response.Content.ReadAsStringAsync().Result, "registered to use namespace");
            mockProvidersOperations.Verify(f => f.RegisterAsync("microsoft.compute", It.IsAny<CancellationToken>()), Times.AtMost(4));
        }
    }

    public class MockResponseDelegatingHandler : DelegatingHandler
    {
        Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping;

        public int RequestsCount { get; set; }

        public MockResponseDelegatingHandler(Dictionary<HttpRequestMessage, List<HttpResponseMessage>> mapping)
        {
            this.mapping = mapping;
            this.RequestsCount = 0;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.Run<HttpResponseMessage>(() =>
            {
                var response = mapping[request].First();
                mapping[request].Remove(response);
                RequestsCount++;
                return response;
            });
        }
    }
}
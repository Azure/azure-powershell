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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Rest.Azure;
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
            Mock<IProvidersOperations> mockProvidersOperations = new Mock<IProvidersOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            mockProvidersOperations.Setup(f => f.RegisterWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>())).Returns(
                (string rp, Dictionary<string, List<string>> ch, CancellationToken token) =>
                {
                    AzureOperationResponse<Provider> r = new AzureOperationResponse<Provider>
                    {
                        Body = new Provider(registrationState: RegistrationState.Registered.ToString())
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
            Assert.Contains(msgs, s => s.Equals("Succeeded to register resource provider 'microsoft.compute'"));
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.Equal("Azure works!", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotInvokeRegistrationForRegisteredResourceProviders()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProvidersOperations> mockProvidersOperations = new Mock<IProvidersOperations>();
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
            Assert.Empty(msgs);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
            Assert.Equal("Azure works!", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotInvokeRegistrationForUnrelatedStatusCode()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProvidersOperations> mockProvidersOperations = new Mock<IProvidersOperations>();
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
            Assert.Empty(msgs);
            Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
            Assert.Equal("auth error!", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotInvokeRegistrationForIncompatibleUri()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProvidersOperations> mockProvidersOperations = new Mock<IProvidersOperations>();
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
            Assert.Empty(msgs);
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
            Assert.Equal("registered to use namespace", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotHangForLongRegistrationCalls()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProvidersOperations> mockProvidersOperations = new Mock<IProvidersOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            mockProvidersOperations.Setup(f => f.RegisterWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>())).Returns(
                (string rp, Dictionary<string, List<string>> ch, CancellationToken token) =>
                {
                    AzureOperationResponse<Provider> r = new AzureOperationResponse<Provider>
                    {
                        Body = new Provider(registrationState: RegistrationState.Pending.ToString())
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
            Assert.Contains(msgs, s => s.Equals("Failed to register resource provider 'microsoft.compute'.Details: 'The operation has timed out.'"));
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
            Assert.Equal("registered to use namespace", response.Content.ReadAsStringAsync().Result);
            mockProvidersOperations.Verify(f => f.RegisterWithHttpMessagesAsync("microsoft.compute", null, It.IsAny<CancellationToken>()), Times.AtMost(5));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotThrowForFailedRegistrationCall()
        {
            // Setup
            Mock<ResourceManagementClient> mockClient = new Mock<ResourceManagementClient>();
            Mock<IProvidersOperations> mockProvidersOperations = new Mock<IProvidersOperations>();
            mockClient.Setup(f => f.Providers).Returns(mockProvidersOperations.Object);
            mockProvidersOperations.Setup(f => f.RegisterWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
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
            Assert.Contains(msgs, s => s.Equals("Failed to register resource provider 'microsoft.compute'.Details: 'PR reg failed'"));
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
            Assert.Equal("registered to use namespace", response.Content.ReadAsStringAsync().Result);
            mockProvidersOperations.Verify(f => f.RegisterWithHttpMessagesAsync("microsoft.compute", null, It.IsAny<CancellationToken>()), Times.AtMost(4));
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
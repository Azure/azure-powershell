using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Administration;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Track2Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    public class EkmConnectionClientTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateConnection_SdkSerializesPrivateNameAndPreservedFields()
        {
            int requestCount = 0;
            using (var httpClient = new HttpClient(new DelegateHandler(request =>
            {
                requestCount++;
                Assert.Contains("api-version=2026-07-01-preview", request.RequestUri.Query);
                var body = JObject.Parse("{\"host\":\"pe1\",\"path_prefix\":\"/api/v1\",\"server_ca_certificates\":[\"AQI=\"],\"server_subject_common_name\":\"proxy.contoso.com\",\"connectivity_mode\":\"PrivateEndpoint\"}");
                if (request.Method == HttpMethod.Patch)
                {
                    body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    Assert.Equal("pe2", (string)body["host"]);
                    Assert.Equal("PrivateEndpoint", (string)body["connectivity_mode"]);
                    Assert.Equal("/api/v1", (string)body["path_prefix"]);
                    Assert.Equal("AQI=", (string)body["server_ca_certificates"][0]);
                    Assert.Equal("proxy.contoso.com", (string)body["server_subject_common_name"]);
                }
                return JsonResponse(HttpStatusCode.OK, body.ToString());
            })))
            {
                var adapter = CreateAdapter(httpClient);
                var result = adapter.UpdateEkmConnection("hsm", "pe2", null, null, null);
                Assert.Equal("pe2", result.Host);
                Assert.Equal(2, requestCount);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(true)]
        [InlineData(false)]
        public void PrivateEndpoint_SdkPollsAzureAsyncOperation(bool create)
        {
            int requestCount = 0;
            using (var httpClient = new HttpClient(new DelegateHandler(request =>
            {
                requestCount++;
                if (requestCount == 1)
                {
                    Assert.Equal(create ? HttpMethod.Post : HttpMethod.Delete, request.Method);
                    Assert.Equal("/ekm/privateendpoint/pe2", request.RequestUri.AbsolutePath);
                    if (create)
                    {
                        var body = JObject.Parse(request.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                        Assert.Equal("pls-alias", (string)body["privateLinkServiceId"]);
                        Assert.Equal("test", (string)body["requestMessage"]);
                    }
                    var response = JsonResponse(HttpStatusCode.Accepted, "{\"jobId\":\"job1\",\"status\":\"InProgress\"}");
                    response.Headers.Add("Azure-AsyncOperation", "https://hsm.managedhsm.azure.net/ekm/privateendpoint/operations/job1?api-version=2026-07-01-preview");
                    response.Headers.Add("Retry-After", "0");
                    return response;
                }
                Assert.Equal(HttpMethod.Get, request.Method);
                Assert.Equal("/ekm/privateendpoint/operations/job1", request.RequestUri.AbsolutePath);
                return JsonResponse(HttpStatusCode.OK, "{\"jobId\":\"job1\",\"privateEndpointName\":\"pe2\",\"status\":\"Succeeded\"}");
            })))
            {
                var adapter = CreateAdapter(httpClient);
                var result = create
                    ? adapter.CreateEkmPrivateEndpoint("hsm", "pe2", "pls-alias", "test", false, CancellationToken.None)
                    : adapter.DeleteEkmPrivateEndpoint("hsm", "pe2", false, CancellationToken.None);
                Assert.Equal("job1", result.JobId);
                Assert.Equal("Succeeded", result.Status);
                Assert.Equal(2, requestCount);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PrivateEndpoint_SdkSurfacesPollingFailure()
        {
            int requestCount = 0;
            using (var httpClient = new HttpClient(new DelegateHandler(request =>
            {
                requestCount++;
                if (requestCount == 1)
                {
                    var response = JsonResponse(HttpStatusCode.Accepted, "{\"jobId\":\"job1\",\"status\":\"InProgress\"}");
                    response.Headers.Add("Azure-AsyncOperation", "https://hsm.managedhsm.azure.net/ekm/privateendpoint/operations/job1?api-version=2026-07-01-preview");
                    response.Headers.Add("Retry-After", "0");
                    return response;
                }
                return JsonResponse(HttpStatusCode.OK, "{\"jobId\":\"job1\",\"status\":\"Failed\",\"error\":{\"code\":\"EndpointInUse\",\"message\":\"Endpoint is in use.\"}}");
            })))
            {
                var adapter = CreateAdapter(httpClient);
                Assert.Throws<RequestFailedException>(() => adapter.DeleteEkmPrivateEndpoint("hsm", "pe2", false, CancellationToken.None));
                Assert.Equal(2, requestCount);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PrivateEndpoint_NoWaitOnlySubmitsRequest()
        {
            int requestCount = 0;
            using (var httpClient = new HttpClient(new DelegateHandler(request =>
            {
                requestCount++;
                var response = JsonResponse(HttpStatusCode.Accepted, "{\"jobId\":\"job1\",\"status\":\"InProgress\"}");
                response.Headers.Add("Azure-AsyncOperation", "https://hsm.managedhsm.azure.net/ekm/privateendpoint/operations/job1?api-version=2026-07-01-preview");
                return response;
            })))
            {
                Assert.Null(CreateAdapter(httpClient).CreateEkmPrivateEndpoint("hsm", "pe2", "pls-alias", null, true, CancellationToken.None));
                Assert.Equal(1, requestCount);
            }
        }

        private static Track2HsmClient CreateAdapter(HttpClient httpClient)
        {
            var credential = new Mock<TokenCredential>();
            var accessToken = new AccessToken("unit-test-token", DateTimeOffset.UtcNow.AddHours(1));
            credential.Setup(instance => instance.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>())).Returns(accessToken);
            credential.Setup(instance => instance.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(accessToken));
            return new Track2HsmClient(name => new KeyVaultEkmClient(new Uri("https://hsm.managedhsm.azure.net"), credential.Object,
                new KeyVaultAdministrationClientOptions(KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview)
                {
                    Transport = new HttpClientTransport(httpClient),
                    Retry = { MaxRetries = 0 }
                }));
        }

        private static HttpResponseMessage JsonResponse(HttpStatusCode statusCode, string json)
        {
            return new HttpResponseMessage(statusCode) { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }

        private sealed class DelegateHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _handler;

            internal DelegateHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
            {
                _handler = handler;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(Send(request, cancellationToken));
            }

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (request.Headers.Authorization == null)
                {
                    var challenge = JsonResponse(HttpStatusCode.Unauthorized, "{}");
                    challenge.Headers.Add("WWW-Authenticate", "Bearer authorization=\"https://login.microsoftonline.com/tenant\", resource=\"https://managedhsm.azure.net\"");
                    return challenge;
                }
                return _handler(request);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, "proxy.contoso.com", "proxy.contoso.com:443")]
        [InlineData("PrivateEndpoint", "pe1", "pe1")]
        public void CreateConnection_PreservesOmittedMode(string mode, string host, string expectedHost)
        {
            var client = new Mock<KeyVaultEkmClient>();
            KeyVaultEkmConnection sent = null;
            client.Setup(instance => instance.CreateEkmConnection(It.IsAny<KeyVaultEkmConnection>(), It.IsAny<CancellationToken>()))
                .Callback<KeyVaultEkmConnection, CancellationToken>((connection, token) => sent = connection)
                .Returns((KeyVaultEkmConnection connection, CancellationToken token) => Response.FromValue(connection, Mock.Of<Response>()));
            var adapter = new Track2HsmClient(name => client.Object);

            var result = adapter.CreateEkmConnection("hsm", host, "/api/v1", new[] { new byte[] { 1, 2 } }, "proxy.contoso.com", mode);

            Assert.Equal(expectedHost, sent.HostName);
            Assert.Equal(mode, sent.ConnectivityMode?.ToString());
            Assert.Equal(expectedHost, result.Host);
            Assert.IsType<string>(Assert.Single(result.ServerCaCertificates));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateConnection_PreservesPrivateModeAndOmittedFields()
        {
            var existing = KeyVaultAdministrationModelFactory.KeyVaultEkmConnection(
                hostName: "pe1", pathPrefix: "/api/v1", serverSubjectCommonName: "proxy.contoso.com",
                serverCaCertificates: new[] { BinaryData.FromBytes(new byte[] { 1, 2 }) },
                connectivityMode: KeyVaultEkmConnectivityMode.PrivateEndpoint);
            var client = new Mock<KeyVaultEkmClient>();
            client.Setup(instance => instance.GetEkmConnection(It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(existing, Mock.Of<Response>()));
            client.Setup(instance => instance.UpdateEkmConnection(It.IsAny<KeyVaultEkmConnection>(), It.IsAny<CancellationToken>()))
                .Returns((KeyVaultEkmConnection connection, CancellationToken token) => Response.FromValue(connection, Mock.Of<Response>()));
            var adapter = new Track2HsmClient(name => client.Object);

            var result = adapter.UpdateEkmConnection("hsm", "pe2", null, null, null);

            Assert.Equal("pe2", result.Host);
            Assert.Equal("PrivateEndpoint", result.ConnectivityMode);
            Assert.Equal("/api/v1", result.PathPrefix);
            Assert.Equal("proxy.contoso.com", result.ServerSubjectCommonName);
            Assert.Equal("AQI=", Assert.Single(result.ServerCaCertificates));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateConnection_RejectsModeSwitchWithoutHostBeforeWrite()
        {
            var existing = KeyVaultAdministrationModelFactory.KeyVaultEkmConnection(hostName: "proxy.contoso.com:443");
            var client = new Mock<KeyVaultEkmClient>();
            client.Setup(instance => instance.GetEkmConnection(It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(existing, Mock.Of<Response>()));
            var adapter = new Track2HsmClient(name => client.Object);

            Assert.Throws<AzPSArgumentException>(() => adapter.UpdateEkmConnection("hsm", null, null, null, null, "PrivateEndpoint"));
            client.Verify(instance => instance.UpdateEkmConnection(It.IsAny<KeyVaultEkmConnection>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatePrivateEndpoint_NoWaitDoesNotReadPendingValue()
        {
            var pending = new Mock<Operation<KeyVaultEkmPrivateEndpointOperation>>();
            pending.SetupGet(operation => operation.Value).Throws(new InvalidOperationException("Operation is pending."));
            var client = new Mock<KeyVaultEkmClient>();
            client.Setup(instance => instance.CreateEkmPrivateEndpoint(WaitUntil.Started, "pe2", "pls-alias", "test", It.IsAny<CancellationToken>()))
                .Returns(pending.Object);
            var adapter = new Track2HsmClient(name => client.Object);

            Assert.Null(adapter.CreateEkmPrivateEndpoint("hsm", "pe2", "pls-alias", "test", true, CancellationToken.None));
            pending.VerifyGet(operation => operation.Value, Times.Never);
        }
    }
}
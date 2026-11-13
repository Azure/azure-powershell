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
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Attestation.Test.UnitTests
{
    /// <summary>
    /// Verifies the requests the policy and policy signer operations send, using a simulated attestation service.
    /// </summary>
    public class AttestationDataServiceClientRoutingTests : IDisposable
    {
        private const string CurrentApiVersion = "2025-06-01";
        private const string LegacyApiVersion = "2018-09-01-preview";
        private const string PolicyText = "version= 1.0;authorizationrules{c:[type==\"$is-debuggable\"] => permit();};issuancerules{};";

        private readonly MockAttestationService _service = new MockAttestationService();
        private readonly List<string> _warnings = new List<string>();
        private readonly AttestationDataServiceClient _client;

        public AttestationDataServiceClientRoutingTests()
        {
            _client = new AttestationDataServiceClient(new StaticTokenCredential(), _service.CreateTransport(), (name, resourceGroupName, isDefaultProvider, location) => MockAttestationService.Endpoint)
            {
                WarningWriter = _warnings.Add
            };
        }

        public void Dispose() => _service.Dispose();

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("TdxVm", "TdxVm")]
        [InlineData("SgxEnclave", "SgxEnclave")]
        [InlineData("VBSEnclave", "Tpm")]
        public void SetsTextPolicyWithCurrentApi(string tee, string attestationType)
        {
            _client.SetPolicy("provider", "rg", null, tee, PolicyText, "Text");

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "PUT", $"/policies/{attestationType}", CurrentApiVersion, null, "text/plain");
            Assert.Equal(Base64Url.EncodeString(PolicyText), ReadTokenBody(request.Body)["AttestationPolicy"].ToString());
            Assert.Empty(_warnings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SendsCallerPolicyTokenUnchangedToCurrentApi()
        {
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });

            _client.SetPolicy("provider", "rg", null, "TdxVm", policyJwt, "JWT");

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "PUT", "/policies/TdxVm", CurrentApiVersion, null, "text/plain");
            Assert.Equal(policyJwt, request.Body);
            Assert.Empty(_warnings);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("SgxEnclave", "SgxEnclave")]
        [InlineData("Tpm", "VBSEnclave")]
        [InlineData("VBSEnclave", "VBSEnclave")]
        public void SendsUnencodedPolicyTokenToLegacyApi(string tee, string legacyTee)
        {
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = PolicyText });

            _client.SetPolicy("provider", "rg", null, tee, policyJwt, "JWT");

            Assert.Equal(2, _service.ServiceRequests.Count);
            AssertRequest(_service.ServiceRequests[0], "POST", "/operations/policy/updatepolicy", LegacyApiVersion, legacyTee, "text/plain");
            Assert.Equal(policyJwt, _service.ServiceRequests[0].Body);
            AssertRequest(_service.ServiceRequests[1], "PUT", "/operations/policy/current", LegacyApiVersion, legacyTee, "text/plain");
            Assert.Equal(_service.LastPolicyUpdateToken, _service.ServiceRequests[1].Body);
            Assert.Single(_warnings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RejectsUnencodedPolicyTokenForTypeLegacyApiDoesNotSupport()
        {
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = PolicyText });

            Assert.Throws<ArgumentException>(() => _client.SetPolicy("provider", "rg", null, "TdxVm", policyJwt, "JWT"));
            Assert.Empty(_service.ServiceRequests);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResetsPolicyWithCurrentApi()
        {
            _client.ResetToDefaultPolicy("provider", "rg", null, "TdxVm", null);

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "POST", "/policies/TdxVm:reset", CurrentApiVersion, null, "text/plain");
            Assert.Empty(_warnings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SendsCallerResetTokenUnchangedToCurrentApi()
        {
            var resetJwt = CreateCallerToken(null);

            _client.ResetToDefaultPolicy("provider", "rg", null, "VBSEnclave", resetJwt);

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "POST", "/policies/Tpm:reset", CurrentApiVersion, null, "text/plain");
            Assert.Equal(resetJwt, request.Body);
            Assert.Empty(_warnings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SendsUnencodedResetTokenToLegacyApi()
        {
            var resetJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = PolicyText });

            _client.ResetToDefaultPolicy("provider", "rg", null, "SgxEnclave", resetJwt);

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "POST", "/operations/policy/current", LegacyApiVersion, "SgxEnclave", "text/plain");
            Assert.Equal(resetJwt, request.Body);
            Assert.Single(_warnings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsPolicyFromValidatedServiceToken()
        {
            var policy = new PSPolicy(_client.GetPolicy("provider", "rg", null, "VBSEnclave"));

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "GET", "/policies/Tpm", CurrentApiVersion, null, null);
            Assert.Equal(PolicyText, policy.Text);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsDefaultProviderPolicySigners()
        {
            var signers = new PSPolicySigners(_client.GetPolicySigners(null, null, null, true, "East US"));

            var request = Assert.Single(_service.ServiceRequests);
            AssertRequest(request, "GET", "/certificates", CurrentApiVersion, null, null);
            Assert.Equal(1, signers.CertificateCount);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(true, "/certificates:add")]
        [InlineData(false, "/certificates:remove")]
        public void SendsCurrentSignerTokenToCurrentApi(bool add, string path)
        {
            var signerJwt = CreateCallerToken(new JObject { ["policyCertificate"] = new JObject { ["kty"] = "RSA" } });

            var signers = add
                ? _client.AddPolicySigner("provider", "rg", null, signerJwt)
                : _client.RemovePolicySigner("provider", "rg", null, signerJwt);

            Assert.Equal(2, _service.ServiceRequests.Count);
            AssertRequest(_service.ServiceRequests[0], "POST", path, CurrentApiVersion, null, "application/json");
            Assert.Equal(signerJwt, JsonConvert.DeserializeObject<string>(_service.ServiceRequests[0].Body));
            AssertRequest(_service.ServiceRequests[1], "GET", "/certificates", CurrentApiVersion, null, null);
            Assert.Equal(1, new PSPolicySigners(signers).CertificateCount);
            Assert.Empty(_warnings);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(true, "PUT")]
        [InlineData(false, "POST")]
        public void SendsLegacySignerTokenToLegacyApi(bool add, string method)
        {
            var signerJwt = CreateCallerToken(new JObject { ["maa-policyCertificate"] = new JObject { ["kty"] = "RSA" } });

            if (add)
                _client.AddPolicySigner("provider", "rg", null, signerJwt);
            else
                _client.RemovePolicySigner("provider", "rg", null, signerJwt);

            Assert.Equal(2, _service.ServiceRequests.Count);
            AssertRequest(_service.ServiceRequests[0], method, "/operations/policy/certificates", LegacyApiVersion, null, "application/json");
            Assert.Equal(signerJwt, JsonConvert.DeserializeObject<string>(_service.ServiceRequests[0].Body));
            AssertRequest(_service.ServiceRequests[1], "GET", "/certificates", CurrentApiVersion, null, null);
            Assert.Single(_warnings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RejectsServiceTokenNotSignedByProvider()
        {
            _service.SignWithUnknownKey = true;
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });
            var signerJwt = CreateCallerToken(new JObject { ["policyCertificate"] = new JObject { ["kty"] = "RSA" } });
            const string reason = "Could not find a certificate which was used to sign the token.";

            // A write the service has accepted must not be sent again when its response fails validation.
            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "TdxVm", PolicyText, "Text"), "PUT", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "TdxVm", policyJwt, "JWT"), "PUT", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.ResetToDefaultPolicy("provider", "rg", null, "TdxVm", null), "POST", "/policies/TdxVm:reset", reason);
            AssertRejectedAfterOneRequest(() => _client.AddPolicySigner("provider", "rg", null, signerJwt), "POST", "/certificates:add", reason);
            AssertRejectedAfterOneRequest(() => _client.RemovePolicySigner("provider", "rg", null, signerJwt), "POST", "/certificates:remove", reason);
            AssertRejectedAfterOneRequest(() => _client.GetPolicy("provider", "rg", null, "TdxVm"), "GET", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.GetPolicySigners("provider", "rg", null), "GET", "/certificates", reason);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AcceptsServiceTokensFromClockAheadWithinTolerance()
        {
            _service.ClockOffset = TimeSpan.FromMinutes(2);
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });

            // Covers tokens validated by the SDK clients and by the module.
            _client.SetPolicy("provider", "rg", null, "TdxVm", PolicyText, "Text");
            _client.GetPolicySigners("provider", "rg", null);
            _client.SetPolicy("provider", "rg", null, "TdxVm", policyJwt, "JWT");
            Assert.Equal(PolicyText, new PSPolicy(_client.GetPolicy("provider", "rg", null, "TdxVm")).Text);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RejectsServiceTokensFromClockAheadBeyondTolerance()
        {
            _service.ClockOffset = TimeSpan.FromSeconds(AttestationDataServiceClient.TokenTimeValidationSlack).Add(TimeSpan.FromMinutes(5));
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });

            const string reason = "Attestation token will not become valid before the slack time provided.";

            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "TdxVm", PolicyText, "Text"), "PUT", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "TdxVm", policyJwt, "JWT"), "PUT", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.GetPolicy("provider", "rg", null, "TdxVm"), "GET", "/policies/TdxVm", reason);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RejectsServiceTokenIssuedByAnotherProvider()
        {
            _service.Issuer = "https://fabrikam.attest.azure.net";
            var policyJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });
            var signerJwt = CreateCallerToken(new JObject { ["policyCertificate"] = new JObject { ["kty"] = "RSA" } });
            var updateJwt = CreateCallerToken(new JObject { ["AttestationPolicy"] = PolicyText });
            var reason = $"Unknown Issuer for attestation token. Expected {MockAttestationService.Endpoint}, found {_service.Issuer}";

            // Covers tokens from the SDK clients, tokens returned for caller tokens, and the earlier API's update token.
            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "TdxVm", PolicyText, "Text"), "PUT", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "TdxVm", policyJwt, "JWT"), "PUT", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.SetPolicy("provider", "rg", null, "SgxEnclave", updateJwt, "JWT"), "POST", "/operations/policy/updatepolicy", reason);
            AssertRejectedAfterOneRequest(() => _client.ResetToDefaultPolicy("provider", "rg", null, "TdxVm", null), "POST", "/policies/TdxVm:reset", reason);
            AssertRejectedAfterOneRequest(() => _client.AddPolicySigner("provider", "rg", null, signerJwt), "POST", "/certificates:add", reason);
            AssertRejectedAfterOneRequest(() => _client.GetPolicy("provider", "rg", null, "TdxVm"), "GET", "/policies/TdxVm", reason);
            AssertRejectedAfterOneRequest(() => _client.GetPolicySigners("provider", "rg", null), "GET", "/certificates", reason);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReportsServiceError()
        {
            _service.ErrorResponse = new JObject { ["error"] = new JObject { ["code"] = "PolicyParsingError", ["message"] = "Invalid policy was specified" } };

            var exception = Assert.Throws<RestException>(() => _client.SetPolicy("provider", "rg", null, "TdxVm", PolicyText, "Text"));

            Assert.Contains("400", exception.Message);
            Assert.Contains("PolicyParsingError", exception.Message);
            Assert.Contains("Invalid policy was specified", exception.Message);
        }

        private void AssertRejectedAfterOneRequest(Action call, string method, string path, string reason)
        {
            _service.Requests.Clear();

            var exception = Assert.Throws<ServiceTokenValidationException>(call);

            Assert.Contains(reason, exception.Message);
            var request = Assert.Single(_service.ServiceRequests);
            Assert.Equal(method, request.Method);
            Assert.Equal(path, request.Path);
        }

        private static void AssertRequest(RecordedRequest request, string method, string path, string apiVersion, string tee, string contentType)
        {
            Assert.Equal(method, request.Method);
            Assert.Equal(path, request.Path);
            Assert.Equal(apiVersion, request.Query["api-version"]);
            Assert.Equal(tee, request.Query["tee"]);
            Assert.Equal(contentType, request.ContentType);
            Assert.Equal("Bearer test-token", request.Authorization);
        }

        private static JObject ReadTokenBody(string jwt)
        {
            return JObject.Parse(Base64Url.DecodeString(jwt.Split('.')[1]));
        }

        private static string CreateCallerToken(JObject body)
        {
            var header = Base64Url.EncodeString("{\"alg\":\"none\"}");
            var encodedBody = body == null ? string.Empty : Base64Url.EncodeString(body.ToString(Formatting.None));
            return $"{header}.{encodedBody}.";
        }

        private class StaticTokenCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new AccessToken("test-token", DateTimeOffset.UtcNow.AddHours(1));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }

        private class RecordedRequest
        {
            public string Method { get; set; }
            public string Path { get; set; }
            public System.Collections.Specialized.NameValueCollection Query { get; set; }
            public string ContentType { get; set; }
            public string Authorization { get; set; }
            public string Body { get; set; }
        }

        /// <summary>
        /// Simulates an attestation provider: records requests and returns tokens signed with the provider's signing key.
        /// </summary>
        private class MockAttestationService : HttpMessageHandler
        {
            public const string Endpoint = "https://contoso.attest.azure.net";
            private const string KeyId = "provider-signing-key";

            private readonly RSA _signingKey = RSA.Create(2048);
            private readonly RSA _unknownKey = RSA.Create(2048);
            private readonly X509Certificate2 _signingCertificate;

            public MockAttestationService()
            {
                var request = new CertificateRequest("CN=" + Endpoint, _signingKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                _signingCertificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));
            }

            public List<RecordedRequest> Requests { get; } = new List<RecordedRequest>();

            /// <summary>
            /// Requests other than the ones that retrieve the provider's signing certificates.
            /// </summary>
            public List<RecordedRequest> ServiceRequests => Requests.Where(r => r.Path != "/certs").ToList();

            public string LastPolicyUpdateToken { get; private set; }

            public bool SignWithUnknownKey { get; set; }

            /// <summary>
            /// Issuer of the tokens the service returns. Defaults to the provider's endpoint.
            /// </summary>
            public string Issuer { get; set; } = Endpoint;

            /// <summary>
            /// Difference between the service's clock and the local clock.
            /// </summary>
            public TimeSpan ClockOffset { get; set; }

            public JObject ErrorResponse { get; set; }

            public HttpPipelineTransport CreateTransport() => new HttpClientTransport(new HttpClient(this));

            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return SendAsync(request, cancellationToken).GetAwaiter().GetResult();
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var recorded = new RecordedRequest
                {
                    Method = request.Method.Method,
                    Path = request.RequestUri.AbsolutePath,
                    Query = HttpUtility.ParseQueryString(request.RequestUri.Query),
                    ContentType = request.Content?.Headers.ContentType?.MediaType,
                    Authorization = request.Headers.Authorization?.ToString(),
                    Body = request.Content == null ? null : await request.Content.ReadAsStringAsync().ConfigureAwait(false)
                };
                Requests.Add(recorded);

                if (recorded.Path == "/certs")
                {
                    return Json(new JObject
                    {
                        ["keys"] = new JArray(new JObject
                        {
                            ["kty"] = "RSA",
                            ["kid"] = KeyId,
                            ["x5c"] = new JArray(Convert.ToBase64String(_signingCertificate.RawData))
                        })
                    });
                }

                if (ErrorResponse != null)
                {
                    return Json(ErrorResponse, HttpStatusCode.BadRequest);
                }

                switch ($"{recorded.Method} {recorded.Path}")
                {
                    case "POST /operations/policy/updatepolicy":
                        LastPolicyUpdateToken = CreateServiceToken(new JObject { ["AttestationPolicy"] = ReadTokenBody(recorded.Body)["AttestationPolicy"] });
                        return Json(new JValue(LastPolicyUpdateToken));
                    case "PUT /operations/policy/current":
                    case "POST /operations/policy/current":
                    case "PUT /operations/policy/certificates":
                    case "POST /operations/policy/certificates":
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    case "GET /certificates":
                        return TokenResponse(new JObject
                        {
                            ["x-ms-policy-certificates"] = new JObject
                            {
                                ["keys"] = new JArray(new JObject
                                {
                                    ["kty"] = "RSA",
                                    ["kid"] = "policy-signer",
                                    ["x5c"] = new JArray(Convert.ToBase64String(_signingCertificate.RawData))
                                })
                            }
                        });
                    case "POST /certificates:add":
                    case "POST /certificates:remove":
                        return TokenResponse(new JObject { ["x-ms-certificate-thumbprint"] = _signingCertificate.Thumbprint, ["x-ms-policycertificates-result"] = "IsPresent" });
                }

                if (recorded.Method == "GET" && recorded.Path.StartsWith("/policies/", StringComparison.Ordinal))
                {
                    var storedPolicy = CreateCallerToken(new JObject { ["AttestationPolicy"] = PolicyText });
                    return TokenResponse(new JObject { [AttestationDataServiceClient.PolicyClaim] = storedPolicy });
                }

                if (recorded.Path.StartsWith("/policies/", StringComparison.Ordinal))
                {
                    return TokenResponse(new JObject { ["x-ms-policy-result"] = recorded.Path.EndsWith(":reset", StringComparison.Ordinal) ? "Removed" : "Updated" });
                }

                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _signingKey.Dispose();
                    _unknownKey.Dispose();
                    _signingCertificate.Dispose();
                }
                base.Dispose(disposing);
            }

            private HttpResponseMessage TokenResponse(JObject claims) => Json(new JObject { ["token"] = CreateServiceToken(claims) });

            private string CreateServiceToken(JObject claims)
            {
                var now = DateTimeOffset.UtcNow.Add(ClockOffset).ToUnixTimeSeconds();
                claims["iss"] = Issuer;
                claims["iat"] = now;
                claims["nbf"] = now;
                claims["exp"] = now + 3600;

                var header = Base64Url.EncodeString(new JObject { ["alg"] = "RS256", ["kid"] = KeyId, ["typ"] = "JWT" }.ToString(Formatting.None));
                var body = Base64Url.EncodeString(claims.ToString(Formatting.None));
                var key = SignWithUnknownKey ? _unknownKey : _signingKey;
                var signature = key.SignData(Encoding.UTF8.GetBytes($"{header}.{body}"), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return $"{header}.{body}.{Base64Url.EncodeBytes(signature)}";
            }

            private static HttpResponseMessage Json(JToken content, HttpStatusCode status = HttpStatusCode.OK)
            {
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(content.ToString(Formatting.None), Encoding.UTF8, "application/json")
                };
            }
        }
    }
}

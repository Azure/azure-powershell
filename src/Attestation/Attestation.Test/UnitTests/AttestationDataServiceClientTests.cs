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
using System.IO;
using Azure.Security.Attestation;
using Microsoft.Azure.Commands.Attestation.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Commands.Attestation.Test.UnitTests
{
    public class AttestationDataServiceClientTests
    {
        private const string PolicyText = "version= 1.0;authorizationrules{=> permit();};issuancerules{};";

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("VBSEnclave", "Tpm")]
        [InlineData("vbsenclave", "Tpm")]
        [InlineData("TdxVm", "TdxVm")]
        [InlineData("SgxEnclave", "SgxEnclave")]
        [InlineData("OpenEnclave", "OpenEnclave")]
        public void MapsTeeToServiceAttestationType(string tee, string expected)
        {
            Assert.Equal(expected, AttestationDataServiceClient.ToServiceAttestationType(tee).ToString());
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Tpm", "VBSEnclave")]
        [InlineData("tpm", "VBSEnclave")]
        [InlineData("VBSEnclave", "VBSEnclave")]
        [InlineData("SgxEnclave", "SgxEnclave")]
        [InlineData("OpenEnclave", "OpenEnclave")]
        public void MapsTeeToLegacyApiTee(string tee, string expected)
        {
            Assert.Equal(expected, AttestationDataServiceClient.ToLegacyTee(tee));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RejectsTeeTheLegacyApiDoesNotSupport()
        {
            Assert.Throws<ArgumentException>(() => AttestationDataServiceClient.ToLegacyTee("TdxVm"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DetectsLegacyPolicyCertificateClaim()
        {
            var legacyFixture = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "SamplePolicySignerFiles", "cert2.signed.txt"));
            var legacyToken = CreateUnsignedToken(new JObject { ["maa-policyCertificate"] = new JObject { ["kty"] = "RSA" } });
            var currentToken = CreateUnsignedToken(new JObject { ["policyCertificate"] = new JObject { ["kty"] = "RSA" } });

            Assert.True(AttestationDataServiceClient.UsesLegacyPolicyCertificateClaim(legacyFixture));
            Assert.True(AttestationDataServiceClient.UsesLegacyPolicyCertificateClaim(legacyToken));
            Assert.False(AttestationDataServiceClient.UsesLegacyPolicyCertificateClaim(currentToken));
            Assert.False(AttestationDataServiceClient.UsesLegacyPolicyCertificateClaim("not a token"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DetectsUnencodedPolicy()
        {
            var unencoded = CreateUnsignedToken(new JObject { ["AttestationPolicy"] = PolicyText });
            var encoded = CreateUnsignedToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });
            var noPolicy = CreateUnsignedToken(new JObject());

            Assert.True(AttestationDataServiceClient.HasUnencodedPolicy(unencoded));
            Assert.False(AttestationDataServiceClient.HasUnencodedPolicy(encoded));
            Assert.False(AttestationDataServiceClient.HasUnencodedPolicy(noPolicy));
            Assert.False(AttestationDataServiceClient.HasUnencodedPolicy("not a token"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreatesPolicyCertificateContentAsJsonString()
        {
            var content = AttestationDataServiceClient.CreatePolicyCertificateContent("  header.body.signature\r\n");

            Assert.Equal("\"header.body.signature\"", content);
            Assert.Equal("header.body.signature", JsonConvert.DeserializeObject<string>(content));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReadsPolicyJwtFromServiceToken()
        {
            var policyJwt = CreateUnsignedToken(new JObject { ["AttestationPolicy"] = Base64Url.EncodeString(PolicyText) });
            var serviceToken = new AttestationToken(BinaryData.FromString(new JObject { ["x-ms-policy"] = policyJwt }.ToString()));
            var responseBody = new JObject { ["token"] = serviceToken.Serialize() }.ToString();

            var token = AttestationToken.Deserialize(AttestationDataServiceClient.ReadResponseToken(responseBody));
            var policy = new PSPolicy(AttestationDataServiceClient.GetStringClaim(token, AttestationDataServiceClient.PolicyClaim));

            Assert.Equal(policyJwt, policy.Jwt);
            Assert.Equal(PolicyText, policy.Text);
            Assert.Equal("none", policy.Algorithm);
            Assert.Throws<InvalidOperationException>(() => AttestationDataServiceClient.ReadResponseToken("{}"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReadsPolicyStoredWithoutBase64UrlEncoding()
        {
            // Earlier API versions stored the policy text as is, and the service returns it unchanged.
            var policyJwt = CreateUnsignedToken(new JObject { ["AttestationPolicy"] = PolicyText });
            var serviceToken = new AttestationToken(BinaryData.FromString(new JObject { ["x-ms-policy"] = policyJwt }.ToString()));

            var policy = new PSPolicy(AttestationDataServiceClient.GetStringClaim(serviceToken, AttestationDataServiceClient.PolicyClaim));

            Assert.Equal(PolicyText, policy.Text);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("x-ms-policy-certificates")]
        [InlineData("maa-policyCertificates")]
        public void ReadsPolicySignersFromEitherClaim(string claimName)
        {
            var keys = new JArray(new JObject { ["kty"] = "RSA", ["kid"] = "1" }, new JObject { ["kty"] = "RSA", ["kid"] = "2" });
            var header = Base64Url.EncodeString(new JObject { ["alg"] = "RS256", ["jku"] = "https://contoso.attest.azure.net/certs" }.ToString(Formatting.None));
            var body = Base64Url.EncodeString(new JObject { [claimName] = new JObject { ["keys"] = keys } }.ToString(Formatting.None));

            var signers = new PSPolicySigners($"{header}.{body}.signature");

            Assert.Equal(2, signers.CertificateCount);
            Assert.Equal("RS256", signers.Algorithm);
            Assert.Equal("https://contoso.attest.azure.net/certs", signers.JKU);
        }

        private static string CreateUnsignedToken(JObject body)
        {
            var header = Base64Url.EncodeString("{\"alg\":\"none\"}");
            return $"{header}.{Base64Url.EncodeString(body.ToString(Formatting.None))}.";
        }
    }
}

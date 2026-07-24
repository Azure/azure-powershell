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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Helpers;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.UnitTests
{
    /// <summary>
    /// Pure unit tests for <see cref="EkmConnectionHelper"/>. These pin the host
    /// normalization, path-prefix validation and certificate-loading rules used by
    /// the EKM connection cmdlets. They do not require an Azure endpoint.
    /// </summary>
    public class EkmConnectionHelperTests
    {
        // ---------- NormalizeHost ----------

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("ekm.contoso.com", "ekm.contoso.com:443")]
        [InlineData("ekm.contoso.com:443", "ekm.contoso.com:443")]
        [InlineData("ekm.contoso.com:8443", "ekm.contoso.com:8443")]
        [InlineData("  ekm.contoso.com  ", "ekm.contoso.com:443")]
        public void NormalizeHost_ValidInputs_AppendsOrPreservesPort(string input, string expected)
        {
            Assert.Equal(expected, EkmConnectionHelper.NormalizeHost(input));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("https://ekm.contoso.com")]
        [InlineData("ekm.contoso.com/path")]
        [InlineData("ekm.contoso.com:abc")]
        [InlineData("ekm.contoso.com:0")]
        [InlineData("ekm.contoso.com:70000")]
        [InlineData("::1")]
        public void NormalizeHost_InvalidInputs_Throws(string input)
        {
            Assert.Throws<AzPSArgumentException>(() => EkmConnectionHelper.NormalizeHost(input));
        }

        // ---------- ValidatePathPrefix ----------

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null)]
        [InlineData("/api/v1")]
        [InlineData("/v1")]
        [InlineData("/a-b/c-d")]
        public void ValidatePathPrefix_ValidInputs_DoesNotThrow(string input)
        {
            EkmConnectionHelper.ValidatePathPrefix(input);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("api/v1")]    // missing leading slash
        [InlineData("/api/v1/")]  // trailing slash
        [InlineData("/api v1")]   // space not allowed
        [InlineData("/api?x=1")]  // illegal character
        public void ValidatePathPrefix_InvalidInputs_Throws(string input)
        {
            Assert.Throws<AzPSArgumentException>(() => EkmConnectionHelper.ValidatePathPrefix(input));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValidatePathPrefix_TooLong_Throws()
        {
            string tooLong = "/" + new string('a', 64);
            Assert.Throws<AzPSArgumentException>(() => EkmConnectionHelper.ValidatePathPrefix(tooLong));
        }

        // ---------- LoadCertificatesAsDer ----------

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadCertificatesAsDer_PemFile_ReturnsDerBytes()
        {
            // A PEM block whose body is valid base64. The helper base64-decodes the
            // block into DER bytes; it does not require a structurally valid cert.
            byte[] derPayload = { 0x30, 0x82, 0x01, 0x02, 0x03, 0x04 };
            string pem =
                "-----BEGIN CERTIFICATE-----\n" +
                Convert.ToBase64String(derPayload) + "\n" +
                "-----END CERTIFICATE-----\n";

            string path = Path.GetTempFileName();
            try
            {
                File.WriteAllText(path, pem);
                var result = EkmConnectionHelper.LoadCertificatesAsDer(new[] { path });

                Assert.Single(result);
                Assert.Equal(derPayload, result[0]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadCertificatesAsDer_MultiBlockPem_ReturnsAllCerts()
        {
            byte[] cert1 = { 0x01, 0x02 };
            byte[] cert2 = { 0x03, 0x04 };
            string pem =
                "-----BEGIN CERTIFICATE-----\n" + Convert.ToBase64String(cert1) + "\n-----END CERTIFICATE-----\n" +
                "-----BEGIN CERTIFICATE-----\n" + Convert.ToBase64String(cert2) + "\n-----END CERTIFICATE-----\n";

            string path = Path.GetTempFileName();
            try
            {
                File.WriteAllText(path, pem);
                var result = EkmConnectionHelper.LoadCertificatesAsDer(new[] { path });

                Assert.Equal(2, result.Count);
                Assert.Equal(cert1, result[0]);
                Assert.Equal(cert2, result[1]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadCertificatesAsDer_DerFile_ReturnsRawBytes()
        {
            byte[] der = { 0x30, 0x82, 0xAB, 0xCD };
            string path = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(path, der);
                var result = EkmConnectionHelper.LoadCertificatesAsDer(new[] { path });

                Assert.Single(result);
                Assert.Equal(der, result[0]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadCertificatesAsDer_MissingFile_Throws()
        {
            Assert.Throws<AzPSArgumentException>(
                () => EkmConnectionHelper.LoadCertificatesAsDer(new[] { "/no/such/file/ekm-ca.cer" }));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LoadCertificatesAsDer_NullOrEmpty_ReturnsEmptyList()
        {
            Assert.Empty(EkmConnectionHelper.LoadCertificatesAsDer(null));
        }
    }
}

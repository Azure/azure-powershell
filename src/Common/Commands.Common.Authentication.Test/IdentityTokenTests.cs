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
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Extensions;

namespace Microsoft.Azure.Commands.Common.Authentication.Test
{
    public class IdentityTokenTests
    {
        [Theory]
        [InlineData("https://adal.authority.com/adfs/{0}/")]
        [InlineData("https://adal.authority.com/adfs/{0}")]
        [InlineData("https://adal.authority.com/adfs/123456789/123456789/123456789/{0}/")]
        [InlineData("https://adal.authority.com/{0}/")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsTenantFromValidIssuer (string tenantFormat)
        {
            var tenant = Guid.NewGuid();
            var issuer = string.Format(tenantFormat, tenant);
            string returnedTenant;
            Assert.True(IdentityTokenHelpers.TryGetTenantFromIssuer(issuer, out returnedTenant));
            Assert.Equal(tenant, Guid.Parse(returnedTenant));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a random non-url string ")]
        [InlineData("https://does.not.contain/a/guid/123456789/")]
        [InlineData("https://bad.guid.position/2449d5b7-7a83-47ca-ae4c-9b03e888bad1/guid/")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnFalseForInvalidIssuer(string issuer)
        {
            string returnedTenant;
            Assert.False(IdentityTokenHelpers.TryGetTenantFromIssuer(issuer, out returnedTenant));
            Assert.Null(returnedTenant);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsIssuerFromValidToken()
        {
            var tenant = Guid.NewGuid();
            var issuer = string.Format("https://adal.authority.com/adfs/{0}/", tenant);
            var token = string.Format("{{\"iss\": \"{0}\", \"field2\": \"value2\"}}", issuer);
            var encodedToken = EncodeToken(token);
            string returnedIssuer;
            Assert.True(IdentityTokenHelpers.TryGetIssuer(encodedToken, out returnedIssuer));
            Assert.Equal<string>(issuer, returnedIssuer);
        }

        [Theory]
        [InlineData("{{\"issuer\": \"1234567890\", \"field2\": \"value2\"}}")]
        [InlineData("random, non-json token text")]
        [InlineData("<xmlData>data is here</xmlData>")]
        [InlineData("")]
        [InlineData(null)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DoesNotThrowForInvalidToken(string token)
        {
            var encodedToken = token == null ? token : EncodeToken(token);
            string returnedIssuer;
            Assert.False(IdentityTokenHelpers.TryGetIssuer(encodedToken, out returnedIssuer));
            Assert.Null(returnedIssuer);
        }

        private static string EncodeToken(string tokenText)
        {
            var tokenBytes = Encoding.UTF8.GetBytes(tokenText);
            return Convert.ToBase64String(tokenBytes).TrimEnd('=');
        }
    }
}

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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Profile.Utilities;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using Moq;

using System;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ResourceManager.Common.Test
{
    public class OpenIDConfigurationTest
    {
        XunitTracingInterceptor xunitLogger;

        public OpenIDConfigurationTest(ITestOutputHelper output)
        {
            xunitLogger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(xunitLogger);
        }

        private const string AADAuthority = "https://login.microsoftonline.com";
        private const string uriPattern = "https://login.microsoftonline.com/{0}/.well-known/openid-configuration";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OpenIDConfigDocRetrieveSuccess()
        {
            var contentSuccess = @"{""token_endpoint"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/oauth2/token"",""token_endpoint_auth_methods_supported"":[""client_secret_post"",""private_key_jwt"",""client_secret_basic""],""jwks_uri"":""https://login.microsoftonline.com/common/discovery/keys"",""response_modes_supported"":[""query"",""fragment"",""form_post""],""subject_types_supported"":[""pairwise""],""id_token_signing_alg_values_supported"":[""RS256""],""response_types_supported"":[""code"",""id_token"",""code id_token"",""token id_token"",""token""],""scopes_supported"":[""openid""],""issuer"":""https://sts.windows.net/54821234-0000-0000-0000-b7b93a3e1234/"",""microsoft_multi_refresh_token"":true,""authorization_endpoint"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/oauth2/authorize"",""device_authorization_endpoint"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/oauth2/devicecode"",""http_logout_supported"":true,""frontchannel_logout_supported"":true,""end_session_endpoint"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/oauth2/logout"",""claims_supported"":[""sub"",""iss"",""cloud_instance_name"",""cloud_instance_host_name"",""cloud_graph_host_name"",""msgraph_host"",""aud"",""exp"",""iat"",""auth_time"",""acr"",""amr"",""nonce"",""email"",""given_name"",""family_name"",""nickname""],""check_session_iframe"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/oauth2/checksession"",""userinfo_endpoint"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/openid/userinfo"",""kerberos_endpoint"":""https://login.microsoftonline.com/54821234-0000-0000-0000-b7b93a3e1234/kerberos"",""tenant_region_scope"":""NA"",""cloud_instance_name"":""microsoftonline.com"",""cloud_graph_host_name"":""graph.windows.net"",""msgraph_host"":""graph.microsoft.com"",""rbac_url"":""https://pas.windows.net""}";
            var testDomain = "TestDomain.com";
            Uri uriExpected = new Uri(string.Format(uriPattern, testDomain));

            var factoryMock = new Mock<IHttpOperationsFactory>();
            factoryMock.Setup(f => f.ReadAsStringAsync(It.IsAny<Uri>())).ReturnsAsync(contentSuccess);

            IOpenIDConfiguration config = new OpenIDConfiguration(testDomain, AADAuthority, httpClientFactory : factoryMock.Object);
            Assert.Equal("54821234-0000-0000-0000-b7b93a3e1234", config.TenantId);
            factoryMock.Verify(f => f.ReadAsStringAsync(It.IsAny<Uri>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OpenIDConfigDocNotFound()
        {
            var contentFailure = @"
{""error"":""invalid_tenant"",""error_description"":""AADSTS90002: Tenant 'fakedomain.com' not found. Check to make sure you have the correct tenant ID and are signing into the correct cloud. Check with your subscription administrator, this may happen if there are no active subscriptions for the tenant.\r\nTrace ID: 2352a858-6e45-4693-ac26-ad88ce4dbd00\r\nCorrelation ID: e1813792-2144-474d-b91f-a1170605599b\r\nTimestamp: 2023-06-18 22:46:37Z"",""error_codes"":[90002],""timestamp"":""2023-06-18 22:46:37Z"",""trace_id"":""2352a858-6e45-4693-ac26-ad88ce4dbd00"",""correlation_id"":""e1813792-2144-474d-b91f-a1170605599b"",""error_uri"":""https://login.microsoftonline.com/error?code=90002""}
";
            var testDomain = "FakeDomain.com";
            Uri uriExpected = new Uri(string.Format(uriPattern, testDomain));

            var factoryMock = new Mock<IHttpOperationsFactory>();
            factoryMock.Setup(f => f.ReadAsStringAsync(It.IsAny<Uri>())).ReturnsAsync(contentFailure);

            IOpenIDConfiguration config = new OpenIDConfiguration(testDomain, AADAuthority, httpClientFactory: factoryMock.Object);
            Assert.Throws<InvalidOperationException>(() => config.TenantId);
            factoryMock.Verify(f => f.ReadAsStringAsync(It.IsAny<Uri>()), Times.Once);
        }

        ~OpenIDConfigurationTest()
        {
            XunitTracingInterceptor.RemoveFromContext(xunitLogger);
        }
    }
}

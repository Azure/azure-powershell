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

using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class SiteConfigConversionTests
    {
        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(2, 3, true)]
        public void SiteConfigRoundTripPreservesApiProperties(int proxyFlag, int scaleLimit, bool alwaysOn)
        {
            var source = new SiteConfig
            {
                Metadata = new List<NameValuePair> { new NameValuePair { Name = "CURRENT_STACK", Value = "dotnet" } },
                IPSecurityRestrictionsDefaultAction = "Deny",
                ScmIPSecurityRestrictionsDefaultAction = "Allow",
                Http20ProxyFlag = proxyFlag,
                MinTlsCipherSuite = "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256",
                ElasticWebAppScaleLimit = scaleLimit,
                AlwaysOn = alwaysOn,
                AppSettings = new List<NameValuePair> { new NameValuePair { Name = "setting", Value = "value" } }
            };

            var result = source.ConvertToSiteConfigResource().ConvertToSiteConfig();

            Assert.Same(source.Metadata, result.Metadata);
            Assert.Equal(source.IPSecurityRestrictionsDefaultAction, result.IPSecurityRestrictionsDefaultAction);
            Assert.Equal(source.ScmIPSecurityRestrictionsDefaultAction, result.ScmIPSecurityRestrictionsDefaultAction);
            Assert.Equal(source.Http20ProxyFlag, result.Http20ProxyFlag);
            Assert.Equal(source.MinTlsCipherSuite, result.MinTlsCipherSuite);
            Assert.Equal(source.ElasticWebAppScaleLimit, result.ElasticWebAppScaleLimit);
            Assert.Equal(source.AlwaysOn, result.AlwaysOn);
            Assert.Same(source.AppSettings, result.AppSettings);
        }

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(2, 3, true)]
        public void SiteConfigResourceRoundTripPreservesApiProperties(int proxyFlag, int scaleLimit, bool alwaysOn)
        {
            var source = new SiteConfigResource
            {
                Metadata = new List<NameValuePair> { new NameValuePair { Name = "CURRENT_STACK", Value = "dotnet" } },
                IPSecurityRestrictionsDefaultAction = "Deny",
                ScmIPSecurityRestrictionsDefaultAction = "Allow",
                Http20ProxyFlag = proxyFlag,
                MinTlsCipherSuite = "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256",
                ElasticWebAppScaleLimit = scaleLimit,
                AlwaysOn = alwaysOn,
                AppSettings = new List<NameValuePair> { new NameValuePair { Name = "setting", Value = "value" } }
            };

            var result = source.ConvertToSiteConfig().ConvertToSiteConfigResource();

            Assert.Same(source.Metadata, result.Metadata);
            Assert.Equal(source.IPSecurityRestrictionsDefaultAction, result.IPSecurityRestrictionsDefaultAction);
            Assert.Equal(source.ScmIPSecurityRestrictionsDefaultAction, result.ScmIPSecurityRestrictionsDefaultAction);
            Assert.Equal(source.Http20ProxyFlag, result.Http20ProxyFlag);
            Assert.Equal(source.MinTlsCipherSuite, result.MinTlsCipherSuite);
            Assert.Equal(source.ElasticWebAppScaleLimit, result.ElasticWebAppScaleLimit);
            Assert.Equal(source.AlwaysOn, result.AlwaysOn);
            Assert.Same(source.AppSettings, result.AppSettings);
        }

        [Fact]
        public void UnspecifiedApiPropertiesRemainUnset()
        {
            var config = new SiteConfigResource().ConvertToSiteConfig();
            var resource = new SiteConfig().ConvertToSiteConfigResource();

            Assert.Null(config.Metadata);
            Assert.Null(config.IPSecurityRestrictionsDefaultAction);
            Assert.Null(config.ScmIPSecurityRestrictionsDefaultAction);
            Assert.Null(config.Http20ProxyFlag);
            Assert.Null(config.MinTlsCipherSuite);
            Assert.Null(config.ElasticWebAppScaleLimit);
            Assert.Null(resource.Metadata);
            Assert.Null(resource.IPSecurityRestrictionsDefaultAction);
            Assert.Null(resource.ScmIPSecurityRestrictionsDefaultAction);
            Assert.Null(resource.Http20ProxyFlag);
            Assert.Null(resource.MinTlsCipherSuite);
            Assert.Null(resource.ElasticWebAppScaleLimit);
        }
    }
}

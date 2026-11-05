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

using Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Linq;
using System.Management.Automation;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class PrivateLinkProviderConfigurationTests
    {
        private const string DataReplicationResourceType = "Microsoft.DataReplication/replicationVaults";

        [Theory]
        [InlineData(DataReplicationResourceType)]
        [InlineData("microsoft.datareplication/replicationvaults")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataReplicationUsesMay2026ApiVersion(string resourceType)
        {
            var configuration = ProviderConfiguration.GetProviderConfiguration(resourceType);

            Assert.NotNull(configuration);
            Assert.Equal("2026-05-01", configuration.ApiVersion);
            Assert.False(configuration.HasConnectionsURI);
            Assert.True(configuration.SupportGetPrivateLinkResource);
            Assert.True(configuration.SupportListPrivateLinkResource);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DataReplicationIsAvailableInPrivateLinkParameters()
        {
            Assert.True(ProviderConfiguration.TryGetEndpointConnectionServiceParameter(
                "PrivateLinkResourceType", "ByResource", out var connectionParameter));
            Assert.Contains(DataReplicationResourceType,
                connectionParameter.Attributes.OfType<ValidateSetAttribute>().Single().ValidValues);

            Assert.True(ProviderConfiguration.TryGetLinkResourceServiceParameter(
                "PrivateLinkResourceType", "ByResource", out var resourceParameter));
            Assert.Contains(DataReplicationResourceType,
                resourceParameter.Attributes.OfType<ValidateSetAttribute>().Single().ValidValues);
        }
    }
}

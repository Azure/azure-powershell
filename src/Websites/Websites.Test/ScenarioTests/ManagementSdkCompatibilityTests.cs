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

using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class ManagementSdkCompatibilityTests
    {
        [Fact]
        public void ProxyOnlyResourcePreservesResourceInterface()
        {
            Assert.True(typeof(IResource).IsAssignableFrom(typeof(ProxyOnlyResource)));
        }

        [Fact]
        public void PushSettingsPreservesNonNullablePropertyAndConstructor()
        {
            var property = typeof(PushSettings).GetProperty(nameof(PushSettings.IsPushEnabled));
            var validateMethod = typeof(PushSettings).GetMethod(nameof(PushSettings.Validate), Type.EmptyTypes);
            var constructor = typeof(PushSettings).GetConstructor(new[]
            {
                typeof(bool),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string)
            });

            Assert.NotNull(property);
            Assert.Equal(typeof(bool), property.PropertyType);
            Assert.NotNull(validateMethod);
            Assert.NotNull(constructor);
        }

        [Fact]
        public void VnetInfoConversionPreservesResourceAndConnectionProperties()
        {
            var routes = new List<VnetRoute>
            {
                new VnetRoute(
                    id: "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/app/virtualNetworkConnections/vnet/routes/default",
                    name: "default",
                    type: "Microsoft.Web/sites/virtualNetworkConnections/routes",
                    kind: "app",
                    routeType: "STATIC",
                    startAddress: "10.0.0.0/24")
            };
            var resource = new VnetInfoResource(
                id: "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/app/virtualNetworkConnections/vnet",
                name: "vnet",
                type: "Microsoft.Web/sites/virtualNetworkConnections",
                kind: "app",
                vnetResourceId: "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet",
                certThumbprint: "thumbprint",
                certBlob: "certificate",
                routes: routes,
                resyncRequired: true,
                dnsServers: "10.0.0.4",
                isSwift: true);

            var result = new VnetInfo(resource);

            Assert.Equal(resource.Id, result.Id);
            Assert.Equal(resource.Name, result.Name);
            Assert.Equal(resource.Type, result.Type);
            Assert.Equal(resource.Kind, result.Kind);
            Assert.Equal(resource.VnetResourceId, result.VnetResourceId);
            Assert.Equal(resource.CertThumbprint, result.CertThumbprint);
            Assert.Equal(resource.CertBlob, result.CertBlob);
            Assert.Same(routes, result.Routes);
            Assert.Equal(resource.ResyncRequired, result.ResyncRequired);
            Assert.Equal(resource.DnsServers, result.DnsServers);
            Assert.Equal(resource.IsSwift, result.IsSwift);
        }
    }
}

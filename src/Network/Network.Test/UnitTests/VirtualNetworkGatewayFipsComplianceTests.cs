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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    // These tests exercise PowerShell parameter binding, the actual New/Set/Get
    // implementations, AutoMapper and SDK HTTP serialization. All HTTP is handled
    // in memory; no Azure account, test subscription or session recording is used.
    [Trait(Category.AcceptanceType, Category.CheckIn)]
    public class VirtualNetworkGatewayFipsComplianceTests : IDisposable
    {
        private const string ResourceGroupName = "fips-test-rg";
        private const string GatewayName = "fips-test-gateway";
        private const string ClientVariable = "FipsTestNetworkClient";
        private readonly GatewayHandler handler;
        private readonly NetworkManagementClient managementClient;
        private readonly Runspace runspace;

        public VirtualNetworkGatewayFipsComplianceTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
            handler = new GatewayHandler();
            managementClient = new NetworkManagementClient(
                new TokenCredentials("unit-test-token"), new HttpClient(handler), true)
            {
                SubscriptionId = Guid.NewGuid().ToString(),
                BaseUri = new Uri("https://management.azure.invalid/")
            };

            var sessionState = InitialSessionState.CreateDefault();
            sessionState.Commands.Add(new SessionStateCmdletEntry(
                "New-AzVirtualNetworkGateway", typeof(TestNewGatewayCommand), null));
            sessionState.Commands.Add(new SessionStateCmdletEntry(
                "Set-AzVirtualNetworkGateway", typeof(TestSetGatewayCommand), null));
            sessionState.Commands.Add(new SessionStateCmdletEntry(
                "Get-AzVirtualNetworkGateway", typeof(TestGetGatewayCommand), null));
            runspace = RunspaceFactory.CreateRunspace(sessionState);
            runspace.Open();
            runspace.SessionStateProxy.SetVariable(ClientVariable, new NetworkClient(managementClient));
            SetResource(true);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void NewRoundTripsTrueFalseAndOmitted(bool? enabled)
        {
            using (var shell = NewCommand(enabled))
            {
                var gateway = AssertGateway(Invoke(shell));
                Assert.Equal(enabled, gateway.VpnClientConfiguration.EnableFipsCompliance);
                AssertWireValue(enabled);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void GetExposesTheServiceValue(bool? enabled)
        {
            SetResource(enabled);
            Assert.Equal(enabled, GetGateway().VpnClientConfiguration.EnableFipsCompliance);
            Assert.Empty(handler.PutBodies);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(null, null)]
        public void SetChangesOnlyBoundFipsAndPreservesP2SSettings(bool? original, bool? requested)
        {
            SetResource(original);
            var gateway = GetGateway();
            using (var shell = SetCommand(gateway, requested))
            {
                // This also exercises the UpdateResourceWithTags parameter set.
                shell.AddParameter("Tag", new Hashtable { ["purpose"] = "fips-test" });
                var result = AssertGateway(Invoke(shell));
                Assert.Equal(requested ?? original, result.VpnClientConfiguration.EnableFipsCompliance);
                Assert.Equal(gateway.VpnClientConfiguration.VpnClientProtocols, result.VpnClientConfiguration.VpnClientProtocols);
                Assert.Equal(gateway.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes,
                    result.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes);
                Assert.Equal("fips-test", result.Tag["purpose"]);
                AssertWireValue(requested ?? original);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetPreservesDirectEditsToTheInputModelWhenSwitchIsOmitted(bool enabled)
        {
            var gateway = GetGateway();
            gateway.VpnClientConfiguration.EnableFipsCompliance = enabled;
            using (var shell = SetCommand(gateway, null))
            {
                Assert.Equal(enabled, AssertGateway(Invoke(shell)).VpnClientConfiguration.EnableFipsCompliance);
                AssertWireValue(enabled);
            }
        }

        [Fact]
        public void SetAcceptsPipelineInputAndExplicitFalse()
        {
            var gateway = GetGateway();
            using (var shell = CreateShell("Set-AzVirtualNetworkGateway"))
            {
                shell.AddParameter("EnableFipsCompliance", false);
                var results = shell.Invoke(new[] { gateway });
                AssertNoErrors(shell);
                Assert.Equal(false, AssertGateway(results).VpnClientConfiguration.EnableFipsCompliance);
                AssertWireValue(false);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetCanAddFipsAlongsideNewP2SSettings(bool enabled)
        {
            SetResource(null, hasP2S: false);
            using (var shell = SetCommand(GetGateway(), enabled))
            {
                shell.AddParameter("VpnClientAddressPool", new[] { "172.16.0.0/24" });
                shell.AddParameter("VpnClientProtocol", new[] { "IkeV2" });
                Assert.Equal(enabled, AssertGateway(Invoke(shell)).VpnClientConfiguration.EnableFipsCompliance);
                AssertWireValue(enabled);
            }
        }

        [Theory]
        [InlineData("New", true)]
        [InlineData("New", false)]
        [InlineData("Set", true)]
        [InlineData("Set", false)]
        public void FipsWithoutP2SConfigurationFailsBeforePut(string verb, bool enabled)
        {
            SetResource(null, hasP2S: false);
            using (var shell = verb == "New" ? NewCommand(enabled, hasP2S: false) : SetCommand(GetGateway(), enabled))
            {
                var error = Assert.Throws<CmdletInvocationException>(() => shell.Invoke());
                Assert.Contains("requires a point-to-site VPN client configuration", error.Message);
                Assert.Empty(handler.PutBodies);
            }
        }

        [Theory]
        [InlineData("New")]
        [InlineData("Set")]
        public void OmittedFipsDoesNotCreateP2SConfiguration(string verb)
        {
            SetResource(null, hasP2S: false);
            using (var shell = verb == "New" ? NewCommand(null, hasP2S: false) : SetCommand(GetGateway(), null))
            {
                Assert.Null(AssertGateway(Invoke(shell)).VpnClientConfiguration);
                Assert.Null(Assert.Single(handler.PutBodies).SelectToken("properties.vpnClientConfiguration"));
            }
        }

        [Theory]
        [InlineData("New")]
        [InlineData("Set")]
        public void WhatIfDoesNotSendPut(string verb)
        {
            using (var shell = verb == "New" ? NewCommand(false) : SetCommand(GetGateway(), false))
            {
                shell.AddParameter("WhatIf");
                Assert.Empty(Invoke(shell));
                Assert.Empty(handler.PutBodies);
            }
        }

        private PowerShell NewCommand(bool? enabled, bool hasP2S = true)
        {
            var shell = CreateShell("New-AzVirtualNetworkGateway")
                .AddParameter("ResourceGroupName", ResourceGroupName)
                .AddParameter("Name", GatewayName)
                .AddParameter("Location", "test-location")
                .AddParameter("GatewayType", "Vpn")
                .AddParameter("VpnType", "RouteBased")
                .AddParameter("GatewaySku", "VpnGw1")
                .AddParameter("Force");
            if (hasP2S)
            {
                shell.AddParameter("VpnClientAddressPool", new[] { "172.16.0.0/24" });
                shell.AddParameter("VpnClientProtocol", new[] { "IkeV2" });
            }

            if (enabled.HasValue)
            {
                shell.AddParameter("EnableFipsCompliance", enabled.Value);
            }

            return shell;
        }

        private PowerShell SetCommand(PSVirtualNetworkGateway gateway, bool? enabled)
        {
            var shell = CreateShell("Set-AzVirtualNetworkGateway").AddParameter("VirtualNetworkGateway", gateway);
            if (enabled.HasValue)
            {
                shell.AddParameter("EnableFipsCompliance", enabled.Value);
            }

            return shell;
        }

        private PSVirtualNetworkGateway GetGateway()
        {
            using (var shell = CreateShell("Get-AzVirtualNetworkGateway")
                .AddParameter("ResourceGroupName", ResourceGroupName)
                .AddParameter("Name", GatewayName))
            {
                return AssertGateway(Invoke(shell));
            }
        }

        private PowerShell CreateShell(string command)
        {
            var shell = PowerShell.Create();
            shell.Runspace = runspace;
            return shell.AddCommand(command);
        }

        private static Collection<PSObject> Invoke(PowerShell shell)
        {
            var results = shell.Invoke();
            AssertNoErrors(shell);
            return results;
        }

        private static void AssertNoErrors(PowerShell shell)
        {
            Assert.False(shell.HadErrors, string.Join(Environment.NewLine, shell.Streams.Error.Select(error => error.ToString())));
        }

        private static PSVirtualNetworkGateway AssertGateway(Collection<PSObject> results)
        {
            return Assert.IsType<PSVirtualNetworkGateway>(Assert.Single(results).BaseObject);
        }

        private void AssertWireValue(bool? expected)
        {
            var configuration = (JObject)Assert.Single(handler.PutBodies).SelectToken("properties.vpnClientConfiguration");
            Assert.NotNull(configuration);
            var property = configuration.Property("enableFipsCompliance", StringComparison.Ordinal);
            if (expected.HasValue)
            {
                Assert.NotNull(property);
                Assert.Equal(JTokenType.Boolean, property.Value.Type);
                Assert.Equal(expected.Value, property.Value.Value<bool>());
            }
            else
            {
                Assert.Null(property);
            }

            Assert.Null(configuration.Property("enableFIPSCompliance", StringComparison.Ordinal));
        }

        private void SetResource(bool? enabled, bool hasP2S = true)
        {
            handler.Resource = JObject.FromObject(new
            {
                id = $"/subscriptions/{managementClient.SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/{GatewayName}",
                name = GatewayName,
                location = "test-location",
                properties = new
                {
                    gatewayType = "Vpn",
                    vpnType = "RouteBased",
                    provisioningState = "Succeeded",
                    sku = new { name = "VpnGw1", tier = "VpnGw1" }
                }
            });
            if (hasP2S)
            {
                var configuration = JObject.FromObject(new
                {
                    vpnClientProtocols = new[] { "IkeV2" },
                    vpnClientAddressPool = new { addressPrefixes = new[] { "172.16.0.0/24" } }
                });
                if (enabled.HasValue)
                {
                    configuration["enableFipsCompliance"] = enabled.Value;
                }

                handler.Resource["properties"]["vpnClientConfiguration"] = configuration;
            }
        }

        public void Dispose()
        {
            runspace.Dispose();
            managementClient.Dispose();
        }

        private sealed class GatewayHandler : HttpMessageHandler
        {
            public JObject Resource { get; set; }
            public List<JObject> PutBodies { get; } = new List<JObject>();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Method == HttpMethod.Put)
                {
                    var body = JObject.Parse(await request.Content.ReadAsStringAsync());
                    PutBodies.Add((JObject)body.DeepClone());
                    body["id"] = Resource["id"];
                    body["name"] = Resource["name"];
                    body["properties"]["provisioningState"] = "Succeeded";
                    Resource = body;
                }
                else if (request.Method != HttpMethod.Get)
                {
                    throw new InvalidOperationException($"Unexpected request in offline FIPS test: {request.Method} {request.RequestUri}");
                }

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(Resource.ToString(Formatting.None), Encoding.UTF8, "application/json")
                };
            }
        }

        // Only the authentication/telemetry lifecycle is replaced. PowerShell still
        // binds the inherited parameters and executes the production cmdlet logic.
        [Cmdlet(VerbsCommon.New, "AzVirtualNetworkGateway", SupportsShouldProcess = true, DefaultParameterSetName = "Default")]
        public class TestNewGatewayCommand : NewAzureVirtualNetworkGatewayCommand
        {
            protected override void BeginProcessing()
            {
                SessionState = ((PSCmdlet)this).SessionState;
                NetworkClient = (NetworkClient)SessionState.PSVariable.GetValue(ClientVariable);
            }

            protected override void ProcessRecord() => Execute();
            protected override void EndProcessing() { }
        }

        [Cmdlet(VerbsCommon.Set, "AzVirtualNetworkGateway", SupportsShouldProcess = true, DefaultParameterSetName = "Default")]
        public class TestSetGatewayCommand : SetAzureVirtualNetworkGatewayCommand
        {
            protected override void BeginProcessing()
            {
                SessionState = ((PSCmdlet)this).SessionState;
                NetworkClient = (NetworkClient)SessionState.PSVariable.GetValue(ClientVariable);
            }

            protected override void ProcessRecord() => Execute();
            protected override void EndProcessing() { }
        }

        [Cmdlet(VerbsCommon.Get, "AzVirtualNetworkGateway")]
        public class TestGetGatewayCommand : GetAzureVirtualNetworkGatewayCommand
        {
            protected override void BeginProcessing()
            {
                SessionState = ((PSCmdlet)this).SessionState;
                NetworkClient = (NetworkClient)SessionState.PSVariable.GetValue(ClientVariable);
            }

            protected override void ProcessRecord() => Execute();
            protected override void EndProcessing() { }
        }
    }
}
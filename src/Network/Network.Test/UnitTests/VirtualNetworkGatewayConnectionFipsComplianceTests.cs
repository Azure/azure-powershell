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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Commands.Network.Test.UnitTests
{
    // Parameter binding, production cmdlet logic, AutoMapper and SDK serialization
    // run normally. A synthetic service handles all requests in memory; these tests
    // do not establish supported service scenarios or omitted-PUT semantics.
    [Trait(Category.AcceptanceType, Category.CheckIn)]
    public class VirtualNetworkGatewayConnectionFipsComplianceTests : IDisposable
    {
        private const string ClientVariable = "FipsConnectionTestNetworkClient";
        private const string TestLocation = "test-location";
        private readonly string resourceGroupName = "fips-rg-" + Guid.NewGuid().ToString("N");
        private readonly string connectionName = "fips-connection-" + Guid.NewGuid().ToString("N");
        private readonly ConnectionHandler handler;
        private readonly NetworkManagementClient managementClient;
        private readonly AzureRmProfile profile;
        private readonly Runspace runspace;

        public VirtualNetworkGatewayConnectionFipsComplianceTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
            handler = new ConnectionHandler();
            managementClient = new NetworkManagementClient(
                new TokenCredentials("unit-test-token"), new HttpClient(handler), true)
            {
                SubscriptionId = Guid.NewGuid().ToString(),
                BaseUri = new Uri("https://management.azure.invalid/")
            };

            // Supply a per-test context for the connection cmdlets' subscription
            // checks, without reading or changing the user's saved Azure profile.
            profile = new AzureRmProfile
            {
                DefaultContext = new AzureContext(
                    new AzureSubscription { Id = managementClient.SubscriptionId },
                    new AzureAccount { Id = "offline-test-account", Type = AzureAccount.AccountType.User },
                    new AzureEnvironment { Name = "Offline", ResourceManagerUrl = managementClient.BaseUri.AbsoluteUri },
                    new AzureTenant { Id = Guid.NewGuid().ToString() })
            };

            var sessionState = InitialSessionState.CreateDefault();
            sessionState.Commands.Add(new SessionStateCmdletEntry(
                "New-AzVirtualNetworkGatewayConnection", typeof(TestNewConnectionCommand), null));
            sessionState.Commands.Add(new SessionStateCmdletEntry(
                "Set-AzVirtualNetworkGatewayConnection", typeof(TestSetConnectionCommand), null));
            sessionState.Commands.Add(new SessionStateCmdletEntry(
                "Get-AzVirtualNetworkGatewayConnection", typeof(TestGetConnectionCommand), null));
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
                Assert.Equal(enabled, AssertConnection(Invoke(shell)).EnableFipsCompliance);
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
            Assert.Equal(enabled, GetConnection().EnableFipsCompliance);
            Assert.Empty(handler.PutBodies);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(null, true)]
        [InlineData(null, false)]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(null, null)]
        public void SetChangesOnlyBoundFipsAndPreservesOtherSettings(bool? original, bool? requested)
        {
            SetResource(original);
            var connection = GetConnection();
            using (var shell = SetCommand(connection, requested))
            {
                shell.AddParameter("Tag", new Hashtable { ["purpose"] = "fips-test" });
                var result = AssertConnection(Invoke(shell));
                Assert.Equal(requested ?? original, result.EnableFipsCompliance);
                Assert.Equal(connection.VirtualNetworkGateway1.Id, result.VirtualNetworkGateway1.Id);
                Assert.Equal(connection.ConnectionType, result.ConnectionType);
                Assert.Equal(connection.ConnectionProtocol, result.ConnectionProtocol);
                Assert.Equal(connection.RoutingWeight, result.RoutingWeight);
                Assert.Equal(connection.EnableBgp, result.EnableBgp);
                Assert.Equal(connection.IpsecPolicies.Single().DhGroup, result.IpsecPolicies.Single().DhGroup);
                Assert.Equal("fips-test", result.Tag["purpose"]);
                AssertWireValue(requested ?? original);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetPreservesDirectModelEditsWhenSwitchIsOmitted(bool enabled)
        {
            var connection = GetConnection();
            connection.EnableFipsCompliance = enabled;
            using (var shell = SetCommand(connection, null))
            {
                Assert.Equal(enabled, AssertConnection(Invoke(shell)).EnableFipsCompliance);
                AssertWireValue(enabled);
            }
        }

        [Fact]
        public void SetAcceptsPipelineInputAndExplicitFalse()
        {
            using (var shell = CreateShell("Set-AzVirtualNetworkGatewayConnection")
                .AddParameter("EnableFipsCompliance", false).AddParameter("Force"))
            {
                var results = shell.Invoke(new[] { GetConnection() });
                AssertNoErrors(shell);
                Assert.Equal(false, AssertConnection(results).EnableFipsCompliance);
                AssertWireValue(false);
            }
        }

        [Fact]
        public void PipelineOmissionPreservesEachInputObjectsValue()
        {
            var connections = new List<PSVirtualNetworkGatewayConnection>();
            foreach (var enabled in new bool?[] { true, false, null })
            {
                SetResource(enabled);
                connections.Add(GetConnection());
            }

            using (var shell = CreateShell("Set-AzVirtualNetworkGatewayConnection").AddParameter("Force"))
            {
                var results = shell.Invoke(connections);
                AssertNoErrors(shell);
                Assert.Equal(new bool?[] { true, false, null },
                    results.Select(result => ((PSVirtualNetworkGatewayConnection)result.BaseObject).EnableFipsCompliance));
                Assert.Equal(3, handler.PutBodies.Count);
                AssertPropertyValue(handler.PutBodies[0], true);
                AssertPropertyValue(handler.PutBodies[1], false);
                AssertPropertyValue(handler.PutBodies[2], null);
            }
        }

        [Fact]
        public void ListPreservesTrueFalseAndMissingAcrossPagesAndWildcardFiltering()
        {
            var first = CreateResource(true, "fips-enabled");
            var second = CreateResource(false, "fips-disabled");
            var third = CreateResource(null, "fips-unspecified");
            handler.Pages.Enqueue(JObject.FromObject(new
            {
                value = new[] { first, CreateResource(true, "other-connection") },
                nextLink = new Uri(managementClient.BaseUri, "next-page").AbsoluteUri
            }));
            handler.Pages.Enqueue(JObject.FromObject(new { value = new[] { second, third } }));

            using (var shell = CreateShell("Get-AzVirtualNetworkGatewayConnection")
                .AddParameter("ResourceGroupName", resourceGroupName).AddParameter("Name", "fips-*"))
            {
                var results = Invoke(shell).Select(result => (PSVirtualNetworkGatewayConnection)result.BaseObject).ToList();
                Assert.Equal(new[] { "fips-enabled", "fips-disabled", "fips-unspecified" }, results.Select(result => result.Name));
                Assert.Equal(new bool?[] { true, false, null }, results.Select(result => result.EnableFipsCompliance));
                Assert.All(results, result => Assert.Equal(resourceGroupName, result.ResourceGroupName));
                Assert.Empty(handler.Pages);
                Assert.Empty(handler.PutBodies);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void ListResultCanBeUpdatedWithoutResettingFips(bool? enabled)
        {
            SetResource(enabled);
            handler.Pages.Enqueue(JObject.FromObject(new { value = new[] { handler.Resource } }));
            PSVirtualNetworkGatewayConnection connection;
            using (var shell = CreateShell("Get-AzVirtualNetworkGatewayConnection")
                .AddParameter("ResourceGroupName", resourceGroupName))
            {
                connection = AssertConnection(Invoke(shell));
            }

            using (var shell = SetCommand(connection, null).AddParameter("DpdTimeoutInSeconds", 60))
            {
                Assert.Equal(enabled, AssertConnection(Invoke(shell)).EnableFipsCompliance);
                AssertWireValue(enabled);
            }
        }

        [Theory]
        [InlineData("New")]
        [InlineData("Set")]
        public void WhatIfDoesNotSendPutOrMutateInput(string verb)
        {
            var connection = GetConnection();
            using (var shell = verb == "New" ? NewCommand(false) : SetCommand(connection, false))
            {
                shell.AddParameter("WhatIf");
                Assert.Empty(Invoke(shell));
                Assert.Empty(handler.PutBodies);
                Assert.Equal(true, connection.EnableFipsCompliance);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [InlineData(null)]
        public void GatewayScopedListSdkModelPreservesFips(bool? enabled)
        {
            var resource = CreateResource(enabled, connectionName);
            var model = SafeJsonConvert.DeserializeObject<MNM.VirtualNetworkGatewayConnectionListEntity>(
                resource.ToString(), managementClient.DeserializationSettings);
            Assert.Equal(enabled, model.EnableFipsCompliance);
            var serialized = JObject.Parse(SafeJsonConvert.SerializeObject(model, managementClient.SerializationSettings));
            AssertPropertyValue(serialized, enabled);
        }

        private PowerShell NewCommand(bool? enabled)
        {
            var shell = CreateShell("New-AzVirtualNetworkGatewayConnection")
                .AddParameter("ResourceGroupName", resourceGroupName)
                .AddParameter("Name", connectionName)
                .AddParameter("Location", TestLocation)
                .AddParameter("VirtualNetworkGateway1", new PSVirtualNetworkGateway { Id = GatewayId })
                .AddParameter("ConnectionType", "IPsec")
                .AddParameter("ConnectionProtocol", "IKEv2")
                .AddParameter("Force");
            if (enabled.HasValue)
            {
                shell.AddParameter("EnableFipsCompliance", enabled.Value);
            }

            return shell;
        }

        private PowerShell SetCommand(PSVirtualNetworkGatewayConnection connection, bool? enabled)
        {
            var shell = CreateShell("Set-AzVirtualNetworkGatewayConnection")
                .AddParameter("VirtualNetworkGatewayConnection", connection).AddParameter("Force");
            if (enabled.HasValue)
            {
                shell.AddParameter("EnableFipsCompliance", enabled.Value);
            }

            return shell;
        }

        private PSVirtualNetworkGatewayConnection GetConnection()
        {
            using (var shell = CreateShell("Get-AzVirtualNetworkGatewayConnection")
                .AddParameter("ResourceGroupName", resourceGroupName).AddParameter("Name", connectionName))
            {
                return AssertConnection(Invoke(shell));
            }
        }

        private PowerShell CreateShell(string command)
        {
            var shell = PowerShell.Create();
            shell.Runspace = runspace;
            return shell.AddCommand(command).AddParameter("DefaultProfile", profile);
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

        private static PSVirtualNetworkGatewayConnection AssertConnection(Collection<PSObject> results)
        {
            return Assert.IsType<PSVirtualNetworkGatewayConnection>(Assert.Single(results).BaseObject);
        }

        private void AssertWireValue(bool? expected)
        {
            AssertPropertyValue(Assert.Single(handler.PutBodies), expected);
        }

        private static void AssertPropertyValue(JObject body, bool? expected)
        {
            var properties = (JObject)body["properties"];
            Assert.NotNull(properties);
            var property = properties.Property("enableFipsCompliance", StringComparison.Ordinal);
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

            Assert.Null(body.Property("enableFipsCompliance", StringComparison.Ordinal));
            Assert.Null(properties.Property("enableFIPSCompliance", StringComparison.Ordinal));
            Assert.Null(properties.SelectToken("virtualNetworkGateway1.properties.enableFipsCompliance"));
            Assert.Null(properties.SelectToken("virtualNetworkGateway1.properties.vpnClientConfiguration.enableFipsCompliance"));
        }

        private string GatewayId => $"/subscriptions/{managementClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworkGateways/gateway";

        private void SetResource(bool? enabled)
        {
            handler.Resource = CreateResource(enabled, connectionName);
        }

        private JObject CreateResource(bool? enabled, string name)
        {
            var resource = JObject.FromObject(new
            {
                id = $"/subscriptions/{managementClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/connections/{name}",
                name,
                location = TestLocation,
                properties = new
                {
                    virtualNetworkGateway1 = new { id = GatewayId },
                    connectionType = "IPsec",
                    connectionProtocol = "IKEv2",
                    authenticationType = "PSK",
                    provisioningState = "Succeeded",
                    enableBgp = true,
                    routingWeight = 7,
                    ipsecPolicies = new[]
                    {
                        new
                        {
                            saLifeTimeSeconds = 28800,
                            saDataSizeKilobytes = 102400000,
                            ipsecEncryption = "AES256",
                            ipsecIntegrity = "SHA256",
                            ikeEncryption = "AES256",
                            ikeIntegrity = "SHA256",
                            dhGroup = "DHGroup14",
                            pfsGroup = "PFS2048"
                        }
                    }
                }
            });
            if (enabled.HasValue)
            {
                resource["properties"]["enableFipsCompliance"] = enabled.Value;
            }

            return resource;
        }

        public void Dispose()
        {
            runspace.Dispose();
            managementClient.Dispose();
        }

        private sealed class ConnectionHandler : HttpMessageHandler
        {
            public JObject Resource { get; set; }
            public Queue<JObject> Pages { get; } = new Queue<JObject>();
            public List<JObject> PutBodies { get; } = new List<JObject>();

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                JObject response;
                if (request.Method == HttpMethod.Put)
                {
                    var body = JObject.Parse(await request.Content.ReadAsStringAsync());
                    PutBodies.Add((JObject)body.DeepClone());
                    body["id"] = Resource["id"];
                    body["name"] = Resource["name"];
                    body["properties"]["provisioningState"] = "Succeeded";
                    Resource = body;
                    response = Resource;
                }
                else if (request.Method == HttpMethod.Get)
                {
                    response = Pages.Count > 0 ? Pages.Dequeue() : Resource;
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected request in offline FIPS test: {request.Method} {request.RequestUri}");
                }

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(response.ToString(Formatting.None), Encoding.UTF8, "application/json")
                };
            }
        }

        // Only authentication and telemetry lifecycle hooks are replaced. Parameters,
        // ShouldProcess, mapping, GET/list and PUT logic use the production implementations.
        [Cmdlet(VerbsCommon.New, "AzVirtualNetworkGatewayConnection", SupportsShouldProcess = true, DefaultParameterSetName = "SetByResource")]
        public class TestNewConnectionCommand : NewAzureVirtualNetworkGatewayConnectionCommand
        {
            protected override void BeginProcessing()
            {
                SessionState = ((PSCmdlet)this).SessionState;
                NetworkClient = (NetworkClient)SessionState.PSVariable.GetValue(ClientVariable);
            }

            protected override void ProcessRecord() => Execute();
            protected override void EndProcessing() { }
        }

        [Cmdlet(VerbsCommon.Set, "AzVirtualNetworkGatewayConnection", SupportsShouldProcess = true, DefaultParameterSetName = "Default")]
        public class TestSetConnectionCommand : SetAzureVirtualNetworkGatewayConnectionCommand
        {
            protected override void BeginProcessing()
            {
                SessionState = ((PSCmdlet)this).SessionState;
                NetworkClient = (NetworkClient)SessionState.PSVariable.GetValue(ClientVariable);
            }

            protected override void ProcessRecord() => Execute();
            protected override void EndProcessing() { }
        }

        [Cmdlet(VerbsCommon.Get, "AzVirtualNetworkGatewayConnection")]
        public class TestGetConnectionCommand : GetAzureVirtualNetworkGatewayConnectionCommand
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
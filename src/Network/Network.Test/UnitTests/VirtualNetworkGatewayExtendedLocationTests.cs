// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
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
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class VirtualNetworkGatewayExtendedLocationTests
    {
        private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
        private const string ResourceGroupName = "gateway-rg";
        private const string GatewayName = "test-gateway";
        private const string EdgeZone = "test-edge-zone";
        private const string VNetId = "/subscriptions/" + SubscriptionId +
            "/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Network/virtualNetworks/test-vnet";

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Vpn", EdgeZone, false)]
        [InlineData("vpn", EdgeZone, false)]
        [InlineData("VPN", EdgeZone, false)]
        [InlineData("ExpressRoute", EdgeZone, true)]
        [InlineData("LocalGateway", EdgeZone, true)]
        [InlineData("Vpn", null, false)]
        [InlineData("ExpressRoute", null, false)]
        [InlineData("LocalGateway", null, false)]
        [InlineData("Vpn", "", false)]
        [InlineData("ExpressRoute", "", false)]
        [InlineData("LocalGateway", "", false)]
        public void NewGatewaySerializesPlacement(string gatewayType, string extendedLocation, bool forwardsVNetId)
        {
            AzureSessionInitializer.InitializeAzureSession();
            var output = new List<object>();
            var runtime = new Mock<ICommandRuntime>();
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>())).Returns(true);
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            runtime.Setup(value => value.WriteObject(It.IsAny<object>())).Callback<object>(output.Add);

            var handler = new GatewayHandler();
            using (var client = new NetworkManagementClient(new TokenCredentials("offline-test-token"), handler)
            {
                BaseUri = new Uri("https://offline.invalid/"),
                SubscriptionId = SubscriptionId,
                LongRunningOperationRetryTimeout = 0
            })
            {
                var command = new NewAzureVirtualNetworkGatewayCommand
                {
                    CommandRuntime = runtime.Object,
                    NetworkClient = new NetworkClient(client),
                    Name = GatewayName,
                    ResourceGroupName = ResourceGroupName,
                    Location = "eastus",
                    GatewayType = gatewayType,
                    VpnType = "RouteBased",
                    ExtendedLocation = extendedLocation,
                    VNetExtendedLocationResourceId = VNetId,
                    Force = true
                };

                command.Execute();

                var body = Assert.Single(handler.Bodies);
                Assert.Equal(gatewayType, (string)body["properties"]["gatewayType"]);
                Assert.Null(body["properties"]["extendedLocation"]);
                Assert.Equal(forwardsVNetId ? VNetId : null, (string)body["properties"]["vNetExtendedLocationResourceId"]);
                var result = Assert.IsType<PSVirtualNetworkGateway>(Assert.Single(output));

                if (string.IsNullOrEmpty(extendedLocation))
                {
                    Assert.Null(body["extendedLocation"]);
                    Assert.Null(result.ExtendedLocation);
                }
                else
                {
                    var placement = Assert.IsType<JObject>(body["extendedLocation"]);
                    Assert.Equal(extendedLocation, (string)placement["name"]);
                    Assert.Equal("EdgeZone", (string)placement["type"]);
                    Assert.NotNull(result.ExtendedLocation);
                    Assert.Equal(extendedLocation, result.ExtendedLocation.Name);
                    Assert.Equal("EdgeZone", result.ExtendedLocation.Type);
                }
            }
        }

        private sealed class GatewayHandler : DelegatingHandler
        {
            public List<JObject> Bodies { get; } = new List<JObject>();
            private JObject gateway;

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.Equal("offline.invalid", request.RequestUri.Host);
                Assert.Equal("/subscriptions/" + SubscriptionId + "/resourceGroups/" + ResourceGroupName +
                    "/providers/Microsoft.Network/virtualNetworkGateways/" + GatewayName, request.RequestUri.AbsolutePath);

                if (request.Method == HttpMethod.Put)
                {
                    var body = JObject.Parse(await request.Content.ReadAsStringAsync());
                    Bodies.Add(body);
                    gateway = (JObject)body.DeepClone();
                    gateway["id"] = request.RequestUri.AbsolutePath;
                    gateway["name"] = GatewayName;
                    gateway["properties"]["provisioningState"] = "Succeeded";
                }
                else
                {
                    Assert.Equal(HttpMethod.Get, request.Method);
                }

                return new HttpResponseMessage(gateway == null ? HttpStatusCode.NotFound : HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(
                        gateway?.ToString() ?? "{\"error\":{\"code\":\"ResourceNotFound\",\"message\":\"Gateway does not exist.\"}}",
                        Encoding.UTF8, "application/json")
                };
            }
        }
    }
}

// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class ApplicationGatewayDeploymentTierTests
    {
        private const string ResourceGroupName = "test-rg";
        private const string GatewayName = "test-gateway";
        private readonly Mock<IApplicationGatewaysOperations> operations = new Mock<IApplicationGatewaysOperations>();
        private readonly Mock<INetworkManagementClient> managementClient = new Mock<INetworkManagementClient>();
        private readonly Mock<ICommandRuntime> commandRuntime = new Mock<ICommandRuntime>();
        private readonly List<object> output = new List<object>();

        public ApplicationGatewayDeploymentTierTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
            managementClient.SetupGet(client => client.ApplicationGateways).Returns(operations.Object);
            commandRuntime.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntime.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntime
                .Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
            commandRuntime.Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(item => output.Add(item));
        }

        [Theory]
        [InlineData("Standard")]
        [InlineData("NetworkIsolated")]
        [InlineData("Accelerated")]
        [InlineData("Elastic")]
        [InlineData(null)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSendsOptionalDeploymentTierAndReturnsIt(string tier)
        {
            var response = CreateGateway(tier);
            SetupGet(response);
            ApplicationGateway request = null;
            SetupCreate(response, value => request = value);
            var command = Configure(new NewAzureApplicationGatewayCommand
            {
                ResourceGroupName = ResourceGroupName,
                Name = GatewayName,
                Location = "eastus",
                Sku = new PSApplicationGatewaySku { Name = "Standard_v2", Tier = "Standard_v2" },
                DeploymentTier = tier,
                GatewayIPConfigurations = new PSApplicationGatewayIPConfiguration[0],
                FrontendPorts = new PSApplicationGatewayFrontendPort[0],
                BackendAddressPools = new PSApplicationGatewayBackendAddressPool[0],
                Force = true
            });

            command.ExecuteCmdlet();

            Assert.NotNull(request);
            Assert.Equal(tier, request.DeploymentTier);
            Assert.Equal(tier, Assert.IsType<PSApplicationGateway>(Assert.Single(output)).DeploymentTier);
        }

        [Theory]
        [InlineData("Standard")]
        [InlineData("NetworkIsolated")]
        [InlineData("Accelerated")]
        [InlineData("Elastic")]
        [InlineData("FutureDeploymentTier")]
        [InlineData(null)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAndSetPreserveDeploymentTierDuringUnrelatedUpdates(string tier)
        {
            SetupGet(CreateGateway(tier));
            var get = Configure(new GetAzureApplicationGatewayCommand
            {
                ResourceGroupName = ResourceGroupName,
                Name = GatewayName
            });
            get.ExecuteCmdlet();
            var gateway = Assert.IsType<PSApplicationGateway>(Assert.Single(output));
            Assert.Equal(tier, gateway.DeploymentTier);
            gateway.EnableHttp2 = true;
            output.Clear();
            ApplicationGateway request = null;
            SetupCreate(CreateGateway(tier), value => request = value);

            Configure(new SetAzureApplicationGatewayCommand { ApplicationGateway = gateway }).ExecuteCmdlet();

            Assert.NotNull(request);
            Assert.Equal(tier, request.DeploymentTier);
            Assert.True(request.EnableHttp2);
            Assert.Equal(tier, Assert.IsType<PSApplicationGateway>(Assert.Single(output)).DeploymentTier);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSendsChangedDeploymentTier()
        {
            SetupGet(CreateGateway("Standard"));
            ApplicationGateway request = null;
            SetupCreate(CreateGateway("Elastic"), value => request = value);
            var gateway = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGateway>(CreateGateway("Standard"));
            gateway.ResourceGroupName = ResourceGroupName;
            gateway.DeploymentTier = "Elastic";

            Configure(new SetAzureApplicationGatewayCommand { ApplicationGateway = gateway }).ExecuteCmdlet();

            Assert.Equal("Elastic", request.DeploymentTier);
        }

        [Theory]
        [InlineData("Standard")]
        [InlineData("NetworkIsolated")]
        [InlineData("Accelerated")]
        [InlineData("Elastic")]
        [InlineData("FutureDeploymentTier")]
        [InlineData(null)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task SdkUsesNewApiAndRoundTripsDeploymentTierOnTheWire(string tier)
        {
            using (var handler = new GatewayHandler(tier))
            using (var httpClient = new HttpClient(handler))
            using (var client = new NetworkManagementClient(new TokenCredentials("test-token"), httpClient, false))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                var response = await client.ApplicationGateways.GetAsync(ResourceGroupName, GatewayName);
                Assert.Equal(tier, response.DeploymentTier);
                Assert.Contains("api-version=2026-05-01", handler.RequestUri.Query);
                await client.ApplicationGateways.CreateOrUpdateAsync(ResourceGroupName, GatewayName, response);
                Assert.Contains("api-version=2026-05-01", handler.RequestUri.Query);
                var payload = JObject.Parse(handler.RequestBody);
                Assert.Null(payload["deploymentTier"]);
                var property = payload["properties"]?["deploymentTier"];
                if (tier == null)
                {
                    Assert.Null(property);
                }
                else
                {
                    Assert.Equal(tier, (string)property);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewParameterValidatesKnownValuesWithoutADefault()
        {
            var property = typeof(NewAzureApplicationGatewayCommand).GetProperty("DeploymentTier");
            var validation = Assert.Single(property.GetCustomAttributes(typeof(ValidateSetAttribute), false).Cast<ValidateSetAttribute>());
            Assert.Equal(new[] { "Standard", "NetworkIsolated", "Accelerated", "Elastic" }, validation.ValidValues);
            var parameter = Assert.Single(property.GetCustomAttributes(typeof(ParameterAttribute), false).Cast<ParameterAttribute>());
            Assert.False(parameter.Mandatory);
            Assert.True(parameter.ValueFromPipelineByPropertyName);
            Assert.Null(new NewAzureApplicationGatewayCommand().DeploymentTier);
        }

        private T Configure<T>(T command) where T : ApplicationGatewayBaseCmdlet
        {
            command.CommandRuntime = commandRuntime.Object;
            command.NetworkClient = new NetworkClient(managementClient.Object);
            return command;
        }

        private void SetupGet(ApplicationGateway gateway)
        {
            operations.Setup(client => client.GetWithHttpMessagesAsync(
                ResourceGroupName, GatewayName, null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<ApplicationGateway> { Body = gateway });
        }

        private void SetupCreate(ApplicationGateway gateway, Action<ApplicationGateway> capture)
        {
            operations.Setup(client => client.CreateOrUpdateWithHttpMessagesAsync(
                ResourceGroupName, GatewayName, It.IsAny<ApplicationGateway>(), null, It.IsAny<CancellationToken>()))
                .Callback<string, string, ApplicationGateway, Dictionary<string, List<string>>, CancellationToken>(
                    (_, _, value, _, _) => capture(value))
                .ReturnsAsync(new AzureOperationResponse<ApplicationGateway> { Body = gateway });
        }

        private static ApplicationGateway CreateGateway(string tier)
        {
            return new ApplicationGateway(name: GatewayName)
            {
                Location = "eastus",
                Sku = new ApplicationGatewaySku { Name = "Standard_v2", Tier = "Standard_v2" },
                DeploymentTier = tier
            };
        }

        private sealed class GatewayHandler : HttpMessageHandler
        {
            private readonly string tier;
            public Uri RequestUri { get; private set; }
            public string RequestBody { get; private set; }

            public GatewayHandler(string tier)
            {
                this.tier = tier;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestUri = request.RequestUri;
                RequestBody = request.Content == null ? null : await request.Content.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        name = GatewayName,
                        location = "eastus",
                        properties = new { provisioningState = "Succeeded", deploymentTier = tier }
                    }), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}

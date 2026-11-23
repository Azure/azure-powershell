// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

using System.Collections.Generic;
using System.Management.Automation;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class NetworkVirtualApplianceLoadBalancerConfigurationTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, null, "Default", 5)]
        [InlineData("sourceip", null, "SourceIP", 5)]
        [InlineData(null, 15, "Default", 15)]
        [InlineData("SOURCEIPPROTOCOL", 4, "SourceIPProtocol", 4)]
        [InlineData("Default", 100, "Default", 100)]
        public void NormalizeAppliesIndependentDefaults(string distribution, int? timeout, string expectedDistribution, int expectedTimeout)
        {
            var result = LoadBalancerConfigurationHelper.Normalize(new PSNetworkVirtualApplianceLoadBalancerConfiguration
            {
                LoadDistribution = distribution,
                IdleTimeoutInMinutes = timeout
            });
            Assert.Equal(expectedDistribution, result.LoadDistribution);
            Assert.Equal(expectedTimeout, result.IdleTimeoutInMinutes);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("invalid", 5)]
        [InlineData("", 5)]
        [InlineData("SourceIP", 3)]
        [InlineData("SourceIP", 101)]
        public void InvalidConfigurationIsRejected(string distribution, int timeout)
        {
            Assert.Throws<PSArgumentException>(() => LoadBalancerConfigurationHelper.Normalize(
                new PSNetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = distribution, IdleTimeoutInMinutes = timeout }));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("AutoExpire")]
        [InlineData(null)]
        [InlineData("")]
        public void ConfiguredIngressRequiresPermanentRuleType(string ruleType)
        {
            Assert.Throws<PSArgumentException>(() => LoadBalancerConfigurationHelper.NormalizeRule(
                new PSNetworkVirtualApplianceLoadBalancerConfiguration(), ruleType));
            Assert.Null(LoadBalancerConfigurationHelper.NormalizeRule(null, ruleType));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PermanentIngressConfigurationMapsInBothDirections()
        {
            var rule = new PSInboundSecurityRulesProperty
            {
                Name = "rule",
                LoadBalancerConfiguration = LoadBalancerConfigurationHelper.NormalizeRule(
                    new PSNetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = "SourceIP" }, "Permanent")
            };
            var sdk = NetworkResourceManagerProfile.Mapper.Map<InboundSecurityRules>(rule);
            var json = JObject.FromObject(sdk);
            Assert.Equal("SourceIP", (string)json["loadBalancerConfiguration"]["loadDistribution"]);
            Assert.Equal(5, (int)json["loadBalancerConfiguration"]["idleTimeoutInMinutes"]);
            var result = NetworkResourceManagerProfile.Mapper.Map<PSInboundSecurityRulesProperty>(sdk);
            Assert.Equal("SourceIP", result.LoadBalancerConfiguration.LoadDistribution);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NvaConfigurationUsesNestedWirePropertyAndRoundTrips()
        {
            var sdk = NetworkResourceManagerProfile.Mapper.Map<NetworkVirtualAppliance>(new PSNetworkVirtualAppliance
            {
                LoadBalancerConfiguration = new PSNetworkVirtualApplianceLoadBalancerConfiguration
                {
                    LoadDistribution = "SourceIPProtocol", IdleTimeoutInMinutes = 15
                }
            });
            using (var client = new NetworkManagementClient(new Microsoft.Rest.TokenCredentials("test")))
            {
                var json = SafeJsonConvert.SerializeObject(sdk, client.SerializationSettings);
                var payload = JObject.Parse(json);
                Assert.Equal("SourceIPProtocol", (string)payload["properties"]["loadBalancerConfiguration"]["loadDistribution"]);
                var roundTrip = SafeJsonConvert.DeserializeObject<NetworkVirtualAppliance>(json, client.DeserializationSettings);
                var ps = NetworkResourceManagerProfile.Mapper.Map<PSNetworkVirtualAppliance>(roundTrip);
                Assert.Equal(15, ps.LoadBalancerConfiguration.IdleTimeoutInMinutes);

                sdk.LoadBalancerConfiguration = null;
                payload = JObject.Parse(SafeJsonConvert.SerializeObject(sdk, client.SerializationSettings));
                Assert.Null(payload["properties"]?["loadBalancerConfiguration"]);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateOmissionClearsExistingConfigurationWhilePreservingAddressFamily()
        {
            var request = RunUpdate(null);
            Assert.Null(request.LoadBalancerConfiguration);
            Assert.Equal(new[] { "IPv4", "IPv6" }, request.AddressFamily);
            Assert.Equal(65223, request.VirtualApplianceAsn);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePartialConfigurationReplacesRatherThanMerges()
        {
            var request = RunUpdate(new PSNetworkVirtualApplianceLoadBalancerConfiguration { IdleTimeoutInMinutes = 20 });
            Assert.Equal("Default", request.LoadBalancerConfiguration.LoadDistribution);
            Assert.Equal(20, request.LoadBalancerConfiguration.IdleTimeoutInMinutes);
            request = RunUpdate(new PSNetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = "sourceip" });
            Assert.Equal("SourceIP", request.LoadBalancerConfiguration.LoadDistribution);
            Assert.Equal(5, request.LoadBalancerConfiguration.IdleTimeoutInMinutes);
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(false)]
        [InlineData(true)]
        public void CreateSupportsHubAndVnet(bool inVnet)
        {
            AzureSessionInitializer.InitializeAzureSession();
            var operations = new Mock<INetworkVirtualAppliancesOperations>();
            NetworkVirtualAppliance request = null;
            SetupOperations(operations, value => request = value);
            var command = Configure(new NewNetworkVirtualApplianceCommand
            {
                ResourceGroupName = "rg", Name = "nva", Location = "australiaeast", Force = true,
                VirtualApplianceAsn = 65222,
                VirtualHubId = inVnet ? null : "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualHubs/hub",
                NvaInterfaceConfiguration = inVnet ? new[] { new PSNetworkVirtualApplianceInterfaceConfigProperties
                {
                    Name = "private", NicType = new List<string> { "PrivateNic" }, Subnet = new PSResourceId { Id = "subnet-id" }
                } } : null,
                LoadBalancerConfiguration = new PSNetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = "sourceipprotocol" }
            }, operations);
            command.Execute();
            Assert.NotNull(request);
            Assert.Equal("SourceIPProtocol", request.LoadBalancerConfiguration.LoadDistribution);
            Assert.Equal(5, request.LoadBalancerConfiguration.IdleTimeoutInMinutes);
            if (inVnet)
            {
                Assert.Single(request.NvaInterfaceConfigurations);
            }
            else
            {
                Assert.EndsWith("/hub", request.VirtualHub.Id);
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("AutoExpire")]
        [InlineData(null)]
        public void IngressCommandRejectsConfigurationBeforeSending(string ruleType)
        {
            var command = new UpdateVirtualApplianceInboundSecurityRuleCommand
            {
                ResourceGroupName = "rg", VirtualApplianceName = "nva", Name = "rules", RuleType = ruleType,
                Rule = new List<PSInboundSecurityRulesProperty>
                {
                    new PSInboundSecurityRulesProperty { LoadBalancerConfiguration = new PSNetworkVirtualApplianceLoadBalancerConfiguration() }
                }
            };
            Assert.Throws<PSArgumentException>(() => command.Execute());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IngressCommandSendsIndependentRuleSettings()
        {
            AzureSessionInitializer.InitializeAzureSession();
            var operations = new Mock<IInboundSecurityRuleOperations>();
            InboundSecurityRule request = null;
            operations.Setup(client => client.CreateOrUpdateWithHttpMessagesAsync("rg", "nva", "rules", It.IsAny<InboundSecurityRule>(), null, It.IsAny<CancellationToken>()))
                .Callback<string, string, string, InboundSecurityRule, Dictionary<string, List<string>>, CancellationToken>((rg, nva, name, model, headers, token) => request = model)
                .ReturnsAsync(new AzureOperationResponse<InboundSecurityRule> { Body = new InboundSecurityRule(), Response = new HttpResponseMessage() });
            var clientMock = new Mock<INetworkManagementClient>();
            clientMock.SetupGet(value => value.InboundSecurityRule).Returns(operations.Object);
            var command = Configure(new UpdateVirtualApplianceInboundSecurityRuleCommand
            {
                ResourceGroupName = "rg", VirtualApplianceName = "nva", Name = "rules", RuleType = "Permanent",
                Rule = new List<PSInboundSecurityRulesProperty>
                {
                    new PSInboundSecurityRulesProperty { Name = "first", LoadBalancerConfiguration = new PSNetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = "SourceIP" } },
                    new PSInboundSecurityRulesProperty { Name = "second", LoadBalancerConfiguration = new PSNetworkVirtualApplianceLoadBalancerConfiguration { IdleTimeoutInMinutes = 20 } },
                    new PSInboundSecurityRulesProperty { Name = "third" }
                }
            }, new Mock<INetworkVirtualAppliancesOperations>());
            command.NetworkClient = new NetworkClient(clientMock.Object);
            command.Execute();
            Assert.NotNull(request);
            Assert.Equal("SourceIP", request.Rules[0].LoadBalancerConfiguration.LoadDistribution);
            Assert.Equal(5, request.Rules[0].LoadBalancerConfiguration.IdleTimeoutInMinutes);
            Assert.Equal("Default", request.Rules[1].LoadBalancerConfiguration.LoadDistribution);
            Assert.Equal(20, request.Rules[1].LoadBalancerConfiguration.IdleTimeoutInMinutes);
            Assert.Null(request.Rules[2].LoadBalancerConfiguration);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExplicitDefaultsResetExistingConfiguration()
        {
            var request = RunUpdate(new PSNetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = "Default", IdleTimeoutInMinutes = 5 });
            Assert.Equal("Default", request.LoadBalancerConfiguration.LoadDistribution);
            Assert.Equal(5, request.LoadBalancerConfiguration.IdleTimeoutInMinutes);
        }

        private static NetworkVirtualAppliance RunUpdate(PSNetworkVirtualApplianceLoadBalancerConfiguration configuration)
        {
            AzureSessionInitializer.InitializeAzureSession();
            var operations = new Mock<INetworkVirtualAppliancesOperations>();
            NetworkVirtualAppliance request = null;
            SetupOperations(operations, value => request = value);
            var command = Configure(new UpdateNetworkVirtualApplianceCommand
            {
                ResourceGroupName = "rg", Name = "nva", Force = true, VirtualApplianceAsn = 65223,
                LoadBalancerConfiguration = configuration
            }, operations);
            command.Execute();
            Assert.NotNull(request);
            return request;
        }

        private static void SetupOperations(Mock<INetworkVirtualAppliancesOperations> operations, System.Action<NetworkVirtualAppliance> capture)
        {
            var existing = new NetworkVirtualAppliance
            {
                Location = "australiaeast", AddressFamily = new List<string> { "IPv4", "IPv6" },
                LoadBalancerConfiguration = new NetworkVirtualApplianceLoadBalancerConfiguration
                {
                    LoadDistribution = "SourceIPProtocol", IdleTimeoutInMinutes = 15
                }
            };
            operations.Setup(client => client.GetWithHttpMessagesAsync("rg", "nva", null, null, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<NetworkVirtualAppliance> { Body = existing, Response = new HttpResponseMessage() });
            operations.Setup(client => client.CreateOrUpdateWithHttpMessagesAsync("rg", "nva", It.IsAny<NetworkVirtualAppliance>(), null, It.IsAny<CancellationToken>()))
                .Callback<string, string, NetworkVirtualAppliance, Dictionary<string, List<string>>, CancellationToken>((rg, name, model, headers, token) => capture(model))
                .ReturnsAsync(new AzureOperationResponse<NetworkVirtualAppliance> { Body = existing, Response = new HttpResponseMessage() });
        }

        private static T Configure<T>(T command, Mock<INetworkVirtualAppliancesOperations> operations) where T : NetworkBaseCmdlet
        {
            var client = new Mock<INetworkManagementClient>();
            client.SetupGet(value => value.NetworkVirtualAppliances).Returns(operations.Object);
            command.NetworkClient = new NetworkClient(client.Object);
            var runtime = new Mock<ICommandRuntime>();
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>())).Returns(true);
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            command.CommandRuntime = runtime.Object;
            return command;
        }
    }
}

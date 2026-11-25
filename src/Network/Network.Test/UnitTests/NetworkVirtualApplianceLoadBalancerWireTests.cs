// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class NetworkVirtualApplianceLoadBalancerWireTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task NvaPutAndReadsUseNewContract()
        {
            var handler = new CaptureHandler();
            using (var client = new NetworkManagementClient(new TokenCredentials("test"), handler))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                await client.NetworkVirtualAppliances.BeginCreateOrUpdateWithHttpMessagesAsync("rg", "nva", new NetworkVirtualAppliance
                {
                    Location = "australiaeast",
                    LoadBalancerConfiguration = new NetworkVirtualApplianceLoadBalancerConfiguration
                    {
                        LoadDistribution = "SourceIPProtocol", IdleTimeoutInMinutes = 15
                    }
                });
                Assert.Contains("api-version=2026-05-01", handler.Uri);
                var body = JObject.Parse(handler.Body);
                Assert.Equal("SourceIPProtocol", (string)body["properties"]["loadBalancerConfiguration"]["loadDistribution"]);
                Assert.Equal(15, (int)body["properties"]["loadBalancerConfiguration"]["idleTimeoutInMinutes"]);

                await client.NetworkVirtualAppliances.GetWithHttpMessagesAsync("rg", "nva");
                Assert.Contains("api-version=2026-05-01", handler.Uri);
                handler.ResponseBody = "{\"value\": []}";
                await client.NetworkVirtualAppliances.ListWithHttpMessagesAsync();
                Assert.Contains("api-version=2026-05-01", handler.Uri);
                await client.NetworkVirtualAppliances.ListByResourceGroupWithHttpMessagesAsync("rg");
                Assert.Contains("api-version=2026-05-01", handler.Uri);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public async Task PermanentIngressPutAndGetUsePerRuleConfiguration()
        {
            var handler = new CaptureHandler();
            using (var client = new NetworkManagementClient(new TokenCredentials("test"), handler))
            {
                client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
                await client.InboundSecurityRule.BeginCreateOrUpdateWithHttpMessagesAsync("rg", "nva", "rules", new InboundSecurityRule
                {
                    RuleType = "Permanent",
                    Rules = new List<InboundSecurityRules>
                    {
                        new InboundSecurityRules
                        {
                            Name = "first", LoadBalancerConfiguration = new NetworkVirtualApplianceLoadBalancerConfiguration { LoadDistribution = "SourceIP", IdleTimeoutInMinutes = 15 }
                        },
                        new InboundSecurityRules { Name = "second" }
                    }
                });
                Assert.Contains("api-version=2026-05-01", handler.Uri);
                var body = JObject.Parse(handler.Body);
                Assert.Equal("SourceIP", (string)body["properties"]["rules"][0]["loadBalancerConfiguration"]["loadDistribution"]);
                Assert.Null(body["properties"]["rules"][1]["loadBalancerConfiguration"]);
                await client.InboundSecurityRule.GetWithHttpMessagesAsync("rg", "nva", "rules");
                Assert.Contains("api-version=2026-05-01", handler.Uri);
            }
        }

        private class CaptureHandler : DelegatingHandler
        {
            public string Uri { get; private set; }
            public string Body { get; private set; }
            public string ResponseBody { get; set; } = "{\"properties\": {\"provisioningState\": \"Succeeded\"}}";

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Uri = request.RequestUri.ToString();
                Body = request.Content == null ? null : await request.Content.ReadAsStringAsync();
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(ResponseBody, System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}

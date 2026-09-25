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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.Azure.Commands.TestFx;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class AzureFirewallPolicyTests : NetworkTestRunner
    {
        public AzureFirewallPolicyTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithThreatIntelWhitelistCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithThreatIntelWhitelistCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithDNSSettings()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithDNSSettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithSQLSetting()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithSQLSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyCRUDWithNetworkRuleDestinationFQDNs()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyCRUDWithNetworkRuleDestinationFQDNs");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithIpGroups()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithIpGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyCRUDWithNatRuleTranslatedFQDN()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyCRUDWithNatRuleTranslatedFQDN");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithWebCategories()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithWebCategories");
        }

        [Fact(Skip = "Skip as current test framework does not support recording generated cmdlets.")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyPremiumFeatures()
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string servicePrincipal = "fakefakefake";
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                var mode = connectionInfo.GetValue<string>(ConnectionStringKeys.HttpRecorderModeKey);
                if (mode == HttpRecorderMode.Playback.ToString())
                {
                    servicePrincipal = HttpMockServer.GetVariable("spn", "fake");
                }
                else
                {
                    servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                    HttpMockServer.Variables["spn"] = servicePrincipal;
                }
            }
            TestRunner.RunTestScript(string.Format("Test-AzureFirewallPolicyPremiumFeatures -baseDir '{0}' -spn '{1}'", AppDomain.CurrentDomain.BaseDirectory, servicePrincipal));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyPremiumWithTerminateTLSEnabled()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyPremiumWithTerminateTLSEnabled");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyPremiumWithTerminateTLSDisabledAndTargetUrls()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyPremiumWithTerminateTLSDisabledAndTargetUrls");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyPremiumWithTerminateTLSEnabledAndTargetUrls()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyPremiumWithTerminateTLSEnabledAndTargetUrls");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyPrivateRangeCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyPrivateRangeCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyBasicSku()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyExplicitProxyCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyExplicitProxyCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyRuleDescription()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyRuleDescription");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithMultipleUAMI()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithMultipleUAMI");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallSnat()
        {
            TestRunner.RunTestScript("Test-AzureFirewallSnat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyApplicationRuleCustomHttpHeader()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyApplicationRuleCustomHttpHeader");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicySizeProperty()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicySizeProperty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyAfcManaged()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyAfcManaged");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyRuleCollectionGroupSizeProperty()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyRuleCollectionGroupSizeProperty");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyKubeSelectorGroupCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyKubeSelectorGroupCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyIDPSProfiles()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyIDPSProfiles");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyDraft()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyDraft");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyRCGyDraft()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyRCGDraft");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyApplicationRuleFqdnTagDefaultProtocol()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyApplicationRuleFqdnTagDefaultProtocol");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyWithParentBasePolicy()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyWithParentBasePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPolicyCRUDWithNetworkRuleGeoLocations()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPolicyCRUDWithNetworkRuleGeoLocations");
        }

        // ---------------------------------------------------------------------
        // Unit tests for New-AzFirewallPolicyNetworkRule Geo IP exclusivity
        // validation. These run the cmdlet's Execute() directly (base.Execute()
        // is a no-op) so no HTTP recording is required.
        // ---------------------------------------------------------------------

        private static NewAzureFirewallPolicyNetworkRuleCommand CreateNetworkRuleCommand(MockCommandRuntime runtime)
        {
            return new NewAzureFirewallPolicyNetworkRuleCommand
            {
                CommandRuntime = runtime,
                Name = "geoRule",
                Protocol = new[] { "TCP" },
                DestinationPort = new[] { "443" }
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleSourceGeoLocationIsNotMandatory()
        {
            var parameter = typeof(NewAzureFirewallPolicyNetworkRuleCommand)
                .GetProperty(nameof(NewAzureFirewallPolicyNetworkRuleCommand.SourceGeoLocation));
            var attribute = parameter.GetCustomAttributes(typeof(ParameterAttribute), false)
                .Cast<ParameterAttribute>()
                .Single(a => a.ParameterSetName == "SourceGeoLocation");

            Assert.False(attribute.Mandatory);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleWithSourceGeoLocationOnlyIsCreated()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceGeoLocation = new[] { "US", "CA" };
            command.DestinationAddress = new[] { "10.0.0.0/24" };

            command.Execute();

            var rule = Assert.IsType<PSAzureFirewallPolicyNetworkRule>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal(new[] { "US", "CA" }, rule.SourceGeoLocations.ToArray());
            Assert.Null(rule.SourceAddresses);
            Assert.Null(rule.SourceIpGroups);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleWithDestinationGeoLocationOnlyIsCreated()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceAddress = new[] { "10.0.0.0/24" };
            command.DestinationGeoLocation = new[] { "US", "CA" };

            command.Execute();

            var rule = Assert.IsType<PSAzureFirewallPolicyNetworkRule>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal(new[] { "US", "CA" }, rule.DestinationGeoLocations.ToArray());
            Assert.Null(rule.DestinationAddresses);
            Assert.Null(rule.DestinationIpGroups);
            Assert.Null(rule.DestinationFqdns);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleSourceGeoLocationWithSourceAddressThrows()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceAddress = new[] { "10.0.0.0/24" };
            command.SourceGeoLocation = new[] { "US" };
            command.DestinationAddress = new[] { "192.168.0.0/24" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("exclusive to each other", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleSourceGeoLocationWithSourceIpGroupThrows()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceIpGroup = new[] { "/subscriptions/s/resourceGroups/rg/providers/Microsoft.Network/ipGroups/ipg1" };
            command.SourceGeoLocation = new[] { "US" };
            command.DestinationAddress = new[] { "192.168.0.0/24" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("exclusive to each other", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleNoSourceTypeSpecifiedThrows()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.DestinationAddress = new[] { "192.168.0.0/24" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("SourceAddress", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleDestinationGeoLocationWithDestinationAddressThrows()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceAddress = new[] { "10.0.0.0/24" };
            command.DestinationAddress = new[] { "192.168.0.0/24" };
            command.DestinationGeoLocation = new[] { "US" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("exclusive to each other", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleDestinationGeoLocationWithDestinationFqdnThrows()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceAddress = new[] { "10.0.0.0/24" };
            command.DestinationFqdn = new[] { "www.microsoft.com" };
            command.DestinationGeoLocation = new[] { "US" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("exclusive to each other", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleDestinationAddressWithDestinationIpGroupThrows()
        {
            // NFVRP-aligned behavior: destination types are now fully mutually exclusive.
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceAddress = new[] { "10.0.0.0/24" };
            command.DestinationAddress = new[] { "192.168.0.0/24" };
            command.DestinationIpGroup = new[] { "/subscriptions/s/resourceGroups/rg/providers/Microsoft.Network/ipGroups/ipg1" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("exclusive to each other", ex.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void NetworkRuleNoDestinationTypeSpecifiedThrows()
        {
            var runtime = new MockCommandRuntime();
            var command = CreateNetworkRuleCommand(runtime);
            command.SourceAddress = new[] { "10.0.0.0/24" };

            var ex = Assert.Throws<ArgumentException>(() => command.Execute());
            Assert.Contains("DestinationAddress", ex.Message);
        }
    }
}

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
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
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
    }
}

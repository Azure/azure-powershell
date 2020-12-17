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

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
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
    }
}

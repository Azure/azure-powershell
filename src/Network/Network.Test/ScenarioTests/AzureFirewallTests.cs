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
    public class AzureFirewallTests : NetworkTestRunner
    {
        public AzureFirewallTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDWithZones()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDWithZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPIPAndVNETObjectTypeParams()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPIPAndVNETObjectTypeParams");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallAllocateAndDeallocate()
        {
            TestRunner.RunTestScript("Test-AzureFirewallAllocateAndDeallocate");
        }

        [Fact(Skip = "Skipped due to intermittent backend failures")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallVirtualHubCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallVirtualHubCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallVirtualHubCRUDWithZones()
        {
            TestRunner.RunTestScript("Test-AzureFirewallVirtualHubCRUDWithZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallThreatIntelWhitelistCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallThreatIntelWhitelistCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallPrivateRangeCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallPrivateRangeCRUD");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDwithManagementIpConfig()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDwithManagementIpConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallWithDNSProxy()
        {
            TestRunner.RunTestScript("Test-AzureFirewallWithDNSProxy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallVirtualHubMultiPublicIPCRUD()
        {
            TestRunner.RunTestScript("Test-AzureFirewallVirtualHubMultiPublicIPCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDWithAllowActiveFTP()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDAllowActiveFTP");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallNoDataPip()
        {
            TestRunner.RunTestScript("Test-AzureFirewallNoDataPip");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallVirtualHubAllocateDeallocated()
        {
            TestRunner.RunTestScript("Test-AzureFirewallVirtualHubAllocateDeallocated");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallBasicSku()
        {
            TestRunner.RunTestScript("Test-AzureFirewallBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallManagementNICBasicSku()
        {
            TestRunner.RunTestScript("Test-AzureFirewallManagementNICBasicSku");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDEnableFatFlowLogging()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDEnableFatFlowLogging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallVirtualHubPrivateIPAddress()
        {
            TestRunner.RunTestScript("Test-AzureFirewallVirtualHubPrivateIPAddress");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDEnableUDPLogOptimization()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDEnableUDPLogOptimization");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDRouteServerId()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDRouteServerId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallCRUDRouteServerIdHub()
        {
            TestRunner.RunTestScript("Test-AzureFirewallCRUDRouteServerIdHub");
        }

        [Fact(Skip = "Skipped due to LearnedIpPrefixes feature not available in most regions")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestGetAzureFirewallLearnedIpPrefixes()
        {
            TestRunner.RunTestScript("Test-GetAzureFirewallLearnedIpPrefixes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestInvokeAzureFirewallPacketCapture()
        {
            TestRunner.RunTestScript("Test-InvokeAzureFirewallPacketCapture");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestByopipAzureHubFirewall()
        {
            TestRunner.RunTestScript("Test-InvokeAzureByopipHubFirewall");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAllocateByopipAzureHubFirewall()
        {
            TestRunner.RunTestScript("Test-InvokeAzureAllocateByopipHubFirewall");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.azurefirewall)]
        public void TestAzureFirewallAutoscaleConfiguration()
        {
            TestRunner.RunTestScript("Test-AzureFirewallAutoscaleConfiguration");
        }
    }
}

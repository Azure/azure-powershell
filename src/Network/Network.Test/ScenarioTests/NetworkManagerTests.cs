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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class NetworkManagerTests : NetworkTestRunner
    {
        public NetworkManagerTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void TestNetworkManagerCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void TestNetworkManagerGroupCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerGroupCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void TestNetworkManagerStaticMemberCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerStaticMemberCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void TestNetworkManagerConnectivityConfigurationCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerConnectivityConfigurationCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerSecurityAdminRuleCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerSecurityAdminRuleCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerRoutingRuleCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerRoutingRuleCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerSecurityUserRuleCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerSecurityUserRuleCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerScopeConnectionCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerScopeConnectionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerSubcriptionConnectionCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerSubscriptionConnectionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerManagementGroupConnectionCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerManagementGroupConnectionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerResourceMinimumParameterCreate()
        {
            TestRunner.RunTestScript("Test-NetworkManagerResourceMinimumParameterCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerIpamPoolCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerIpamPoolCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerIpamPoolStaticCidrCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerIpamPoolStaticCidrCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerVerifierWorkspaceReachabilityAnalysisRunCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerVerifierWorkspaceReachabilityAnalysisRunCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsmdev)]
        public void NetworkManagerSecurityAdminRuleManualAggregationCRUD()
        {
            TestRunner.RunTestScript("Test-NetworkManagerSecurityAdminRuleManualAggregationCRUD");
        }
    }
}
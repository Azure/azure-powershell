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

namespace Commands.Network.Test.ScenarioTests
{
    public class LoadBalancerBackendPoolTests : NetworkTestRunner
    {
        public LoadBalancerBackendPoolTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendPoolCRUD()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendPoolCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendPoolCreate()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendPoolCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestGlobalLoadBalancerBackendPoolCreate()
        {
            TestRunner.RunTestScript("Test-GlobalLoadBalancerBackendPoolCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendPoolRead()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendPoolRead");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendPoolDelete()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendPoolDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendPoolUpdate()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendPoolUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendAddressConfig()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendAddressConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerBackendPoolCRUDWithAddTunnelInterface()
        {
            TestRunner.RunTestScript("Test-LoadBalancerBackendPoolCRUDWithAddTunnelInterface");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestIPBasedBackendPoolQueryInboundNatRulePortMapping()
        {
            TestRunner.RunTestScript("Test-IPBasedBackendPoolQueryInboundNatRulePortMapping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestNICBasedBackendPoolQueryInboundNatRulePortMapping()
        {
            TestRunner.RunTestScript("Test-NICBasedBackendPoolQueryInboundNatRulePortMapping");
        }
    }
}

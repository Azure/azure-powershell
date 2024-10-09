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
    public class LoadBalancerTests : NetworkTestRunner
    {
        public LoadBalancerTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublic()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicTcpReset()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicTcpReset");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalDynamic()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalDynamic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalStatic()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalStatic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicNoInboundNATRule()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicNoInboundNATRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicPublicNoLbRule()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicNoLbRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalUsingId()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicUsingId()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerProbes_ProbeThresholdParameter()
        {
            TestRunner.RunTestScript("Test-LoadBalancerProbes_ProbeThresholdParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerProbes_NoHealthyBackendsBehaviorParameter()
        {
            TestRunner.RunTestScript("Test-LoadBalancerProbes_NoHealthyBackendsBehaviorParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerChildResource()
        {
            TestRunner.RunTestScript("Test-LoadBalancerChildResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatRuleV2()
        {
            TestRunner.RunTestScript("Test-LoadBalancerInboundNatRuleV2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatRuleV2InternalLB()
        {
            TestRunner.RunTestScript("Test-LoadBalancerInboundNatRuleV2-InternalLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerSet()
        {
            TestRunner.RunTestScript("Test-LoadBalancerSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestCreateEmptyLoadBalancer()
        {
            TestRunner.RunTestScript("Test-CreateEmptyLoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerNicAssociation()
        {
            TestRunner.RunTestScript("Test-LoadBalancer-NicAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerNicAssociationDuringCreate()
        {
            TestRunner.RunTestScript("Test-LoadBalancer-NicAssociationDuringCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatPoolConfigInternalLB()
        {
            TestRunner.RunTestScript("Test-LoadBalancerInboundNatPoolConfigCRUD-InternalLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatPoolConfigCRUDPublicLB()
        {
            TestRunner.RunTestScript("Test-LoadBalancerInboundNatPoolConfigCRUD-PublicLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerMultiVipPublic()
        {
            TestRunner.RunTestScript("Test-LoadBalancerMultiVip-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerMultiVipInternal()
        {
            TestRunner.RunTestScript("Test-LoadBalancerMultiVip-Internal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerObjectAssignment()
        {
            TestRunner.RunTestScript("Test-SetLoadBalancerObjectAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicBasicSku()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalBasicSku()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicStandardSku()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicStandardSkuAsDefault()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicStandardSkuDefault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicStandardSkuIpPrefix()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicStandardSkuIpPrefix");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicStandardSkuGlobalTier()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-PublicStandardSkuGlobalTier");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalStandardSku()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalStandardSkuAsDefault()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalStandardSkuDefault");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalHighlyAvailableBasicSku()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalHighlyAvailableBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalHighlyAvailableStandardSku()
        {
            TestRunner.RunTestScript("Test-LoadBalancerCRUD-InternalHighlyAvailableStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerZones()
        {
            TestRunner.RunTestScript("Test-LoadBalancerZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestCreateSubresourcesOnEmptyLoadBalancer()
        {
            TestRunner.RunTestScript("Test-CreateSubresourcesOnEmptyLoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestGatewayLoadBalancerProviderOnePool()
        {
            TestRunner.RunTestScript("Test-GatewayLoadBalancer-ProviderOnePool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestGatewayLoadBalancerProviderTwoPool()
        {
            TestRunner.RunTestScript("Test-GatewayLoadBalancer-ProviderTwoPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestGatewayLoadBalancerConsumerLb()
        {
            TestRunner.RunTestScript("Test-GatewayLoadBalancer-ConsumerLb");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInEdgeZone()
        {
            TestRunner.RunTestScript("Test-LoadBalancerInEdgeZone");
        }
    }
}

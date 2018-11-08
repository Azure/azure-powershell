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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class LoadBalancerTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public LoadBalancerTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublic()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicTcpReset()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicTcpReset");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalDynamic()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalDynamic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalStatic()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalStatic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicNoInboundNATRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicNoInboundNATRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicPublicNoLbRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicNoLbRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalUsingId()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDPublicUsingId()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerChildResource()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerChildResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerSet()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestCreateEmptyLoadBalancer()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CreateEmptyLoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerNicAssociation()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancer-NicAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerNicAssociationDuringCreate()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancer-NicAssociationDuringCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatPoolConfigInternalLB()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerInboundNatPoolConfigCRUD-InternalLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerInboundNatPoolConfigCRUDPublicLB()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerInboundNatPoolConfigCRUD-PublicLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerMultiVipPublic()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerMultiVip-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerMultiVipInternal()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerMultiVip-Internal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerObjectAssignment()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-SetLoadBalancerObjectAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicBasicSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalBasicSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDPublicStandardSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-PublicStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestSetLoadBalancerCRUDInternalStandardSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalHighlyAvailableBasicSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalHighlyAvailableBasicSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerCRUDInternalHighlyAvailableStandardSku()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerCRUD-InternalHighlyAvailableStandardSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestLoadBalancerZones()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-LoadBalancerZones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.slbdev)]
        public void TestCreateSubresourcesOnEmptyLoadBalancer()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CreateSubresourcesOnEmptyLoadBalancer");
        }
    }
}

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
        public LoadBalancerTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDPublic()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDInternalDynamic()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-InternalDynamic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDInternalStatic()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-InternalStatic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDPublicNoInboundNATRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-PublicNoInboundNATRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDPublicPublicNoLbRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-PublicNoLbRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDInternalUsingId()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-InternalUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerCRUDPublicUsingId()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerCRUD-PublicUsingId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerChildResource()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerChildResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerSet()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateEmptyLoadBalancer()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-CreateEmptyLoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerNicAssociation()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancer-NicAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerNicAssociationDuringCreate()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancer-NicAssociationDuringCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerInboundNatPoolConfigInternalLB()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerInboundNatPoolConfigCRUD-InternalLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerInboundNatPoolConfigCRUDPublicLB()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerInboundNatPoolConfigCRUD-PublicLB");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerMultiVipPublic()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerMultiVip-Public");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancerMultiVipInternal()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LoadBalancerMultiVip-Internal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetLoadBalancerObjectAssignment()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-SetLoadBalancerObjectAssignment");
        }
    }
}

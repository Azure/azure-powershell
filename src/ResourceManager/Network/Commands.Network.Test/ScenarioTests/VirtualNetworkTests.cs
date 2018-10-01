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
    public class VirtualNetworkTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public VirtualNetworkTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkCRUDWithDDoSProtection()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkCRUDWithDDoSProtection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkSubnetCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-subnetCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkSubnetDelegationCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-subnetDelegationCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkMultiPrefixSubnetCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-multiPrefixSubnetCRUD");
        }

        [Fact(Skip = "'The '1' auxiliary tokens are either not application token(s) or are from the application(s) ... which are different from the application of primary identity <...>.' StatusCode: 401; ReasonPhrase: Unauthorized.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkPeeringCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkPeeringCRUD");
        }

        [Fact(Skip ="We need to update the way tokens are aquired, as of now aquiring tokens for multiple tenants is broken")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestMultiTenantVNetPCRUD()
        {
            //this test is special, it requires 2 vnets, one of them created in a tenant other than the current context
            //The test assumes one of the vnet (n the other tenant) is already up and runing 
            //The test will create the second vnet and the peer them
            //The underlying cmdlet will actually get a token for the other tenant and pass it on in the REST call..
            //Because of the need to get a token for the remote VNets's tenant, we cant ruin this under a service principal
            //This test needs to be run in a live user mode only where the user is asusmed to  have access to both the tenants

            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-MultiTenantVNetPCRUD");

        }

        [Fact(Skip = "test is timing out , ahmed salma to fix")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestResourceNavigationLinksOnSubnetCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ResourceNavigationLinksCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkUsage()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkSubnetServiceEndpoint()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkSubnetServiceEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.sdnnrp)]
        public void TestVirtualNetworkSubnetServiceEndpointPolicies()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VirtualNetworkSubnetServiceEndpointPolicies");
        }
    }
}

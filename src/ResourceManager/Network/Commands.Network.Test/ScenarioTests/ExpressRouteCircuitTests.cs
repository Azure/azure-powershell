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
    public class ExpressRouteCircuitTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ExpressRouteCircuitTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteCircuitStageCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteCircuitStageCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteCircuitCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteCircuitCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteCircuitPrivatePublicPeeringCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteCircuitPrivatePublicPeeringCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteCircuitMicrosoftPeeringCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteCircuitMicrosoftPeeringCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteCircuitAuthorizationCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteCircuitAuthorizationCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteBgpServiceCommunitiesGet()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteBGPServiceCommunities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteRouteFilterCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteRouteFilters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestExpressRouteCircuitConnectionCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ExpressRouteCircuitConnectionCRUD");
        }
    }
}

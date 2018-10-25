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
    public class RouteTableTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public RouteTableTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEmptyRouteTable()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-EmptyRouteTable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteTableCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-RouteTableCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteTableSubnetRef()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-RouteTableSubnetRef");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteTableRouteCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-RouteTableRouteCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteHopTypeTest()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-RouteHopTypeTest");
        }
    }
}

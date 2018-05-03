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

using System;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class RouteTableTestsGenerated : RMTestBase
    {
        public RouteTableTestsGenerated(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteCRUDMinimalParameters()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-RouteCRUDMinimalParameters"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteCRUDAllParameters()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-RouteCRUDAllParameters"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteTableCRUDMinimalParameters()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-RouteTableCRUDMinimalParameters"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRouteTableCRUDAllParameters()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-RouteTableCRUDAllParameters"));
        }
    }
}

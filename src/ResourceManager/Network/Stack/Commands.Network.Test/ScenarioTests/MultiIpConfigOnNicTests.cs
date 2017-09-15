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
    public class MultiIpConfigOnNicTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {

        [Fact(Skip = "NRP code to be there to test this scenario, skipping it until NRP is ready")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMultiIpConfigCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-MultiIpConfigCRUD");
        }

        public MultiIpConfigOnNicTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact(Skip = "NRP code to be there to test this scenario, skipping it until NRP is ready")]
        /// current error is: LoadBalancingRules are not supported for secondary IpConfigurations. 
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLBWithMultiIpConfigNICCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-LBWithMultiIpConfigNICCRUD");
        }


        [Fact(Skip = "NRP code to be there to test this scenario, skipping it until NRP is ready")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddNICToLBWithMultiIpConfig()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-AddNICToLBWithMultiIpConfig");
        }

        [Fact(Skip = "NRP code to be there to test this scenario, skipping it until NRP is ready")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        /// Public IP is not supported on secondary IpConfigurations
        public void TestLBWithMultiIpConfigMultiNIC()
        {

            NetworkResourcesController.NewInstance.RunPsTest("Test-LBWithMultiIpConfigMultiNIC");
        }
    }
}

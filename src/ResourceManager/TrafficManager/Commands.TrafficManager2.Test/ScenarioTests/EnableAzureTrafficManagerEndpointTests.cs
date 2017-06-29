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

namespace Microsoft.Azure.Commands.TrafficManager.Test.ScenarioTests
{
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class EnableAzureTrafficManagerEndpointTests
    {
        public EnableAzureTrafficManagerEndpointTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        //[Fact(Skip = "TFS#5185296")]
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableEndpoint");
        }

        //[Fact(Skip = "TFS#5185296")]
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpointUsingPiping()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableEndpointUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableNonExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableNonExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableEndpointUsingPipingFromGetProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableEndpointUsingPipingFromGetProfile");
        }
    }
}
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
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagemenet.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    public class EndpointTests
    {
        public EndpointTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AddEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-DeleteEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrud()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EndpointCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudPiping()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EndpointCrudPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-CreateExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateExistingEndpointFromNonExistingProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-CreateExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveExistingEndpointFromNonExistingProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-RemoveExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetExistingEndpointFromNonExistingProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingEndpointFromProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-RemoveNonExistingEndpointFromProfile");
        }

        [Fact(Skip = "TFS#5185296")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableEndpoint");
        }

        [Fact(Skip = "TFS#5185296")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-DisableEndpoint");
        }

        [Fact(Skip = "TFS#5185296")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpointUsingPiping()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableEndpointUsingPiping");
        }

        [Fact(Skip = "TFS#5185296")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEndpointUsingPiping()
        {
            TestController.NewInstance.RunPowerShellTest("Test-DisableEndpointUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableNonExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EnableNonExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableNonExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-DisableNonExistingEndpoint");
        }
    }
}

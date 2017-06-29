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
        public void TestEndpointCrud()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EndpointCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudGeo()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EndpointCrudGeo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudPiping()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EndpointCrudPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointTypeCaseInsensitive()
        {
            TestController.NewInstance.RunPowerShellTest("Test-EndpointTypeCaseInsensitive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipeEndpointFromGetEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-PipeEndpointFromGetEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipeEndpointFromGetProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-PipeEndpointFromGetProfile");
        }
    }
}

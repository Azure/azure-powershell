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
    using Xunit;
    using Xunit.Abstractions;
    public class EndpointTests : TrafficManagerTestRunner
    {
        public EndpointTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddEndpoint()
        {
            TestRunner.RunTestScript("Test-AddEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteEndpoint()
        {
            TestRunner.RunTestScript("Test-DeleteEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrud()
        {
            TestRunner.RunTestScript("Test-EndpointCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudGeo()
        {
            TestRunner.RunTestScript("Test-EndpointCrudGeo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudPiping()
        {
            TestRunner.RunTestScript("Test-EndpointCrudPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateExistingEndpoint()
        {
            TestRunner.RunTestScript("Test-CreateExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateExistingEndpointFromNonExistingProfile()
        {
            TestRunner.RunTestScript("Test-CreateExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveExistingEndpointFromNonExistingProfile()
        {
            TestRunner.RunTestScript("Test-RemoveExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetExistingEndpointFromNonExistingProfile()
        {
            TestRunner.RunTestScript("Test-GetExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingEndpointFromProfile()
        {
            TestRunner.RunTestScript("Test-RemoveNonExistingEndpointFromProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpoint()
        {
            TestRunner.RunTestScript("Test-EnableEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEndpoint()
        {
            TestRunner.RunTestScript("Test-DisableEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpointUsingPiping()
        {
            TestRunner.RunTestScript("Test-EnableEndpointUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpointUsingPipingFromGetProfile()
        {
            TestRunner.RunTestScript("Test-EnableEndpointUsingPipingFromGetProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEndpointUsingPiping()
        {
            TestRunner.RunTestScript("Test-DisableEndpointUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableNonExistingEndpoint()
        {
            TestRunner.RunTestScript("Test-EnableNonExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableNonExistingEndpoint()
        {
            TestRunner.RunTestScript("Test-DisableNonExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointTypeCaseInsensitive()
        {
            TestRunner.RunTestScript("Test-EndpointTypeCaseInsensitive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipeEndpointFromGetEndpoint()
        {
            TestRunner.RunTestScript("Test-PipeEndpointFromGetEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipeEndpointFromGetProfile()
        {
            TestRunner.RunTestScript("Test-PipeEndpointFromGetProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveCustomHeadersFromEndpoint()
        {
            TestRunner.RunTestScript("Test-AddAndRemoveCustomHeadersFromEndpoint");
        }

    // This scenario is not supported with current API specs. Commenting this test.

    /*  [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveIpAddressRanges()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AddAndRemoveIpAddressRanges");
        }*/
    }
}

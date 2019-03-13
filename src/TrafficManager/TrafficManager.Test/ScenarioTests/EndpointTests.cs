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
    using ServiceManagement.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    public class EndpointTests
    {
        public XunitTracingInterceptor _logger;

        public EndpointTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AddEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-DeleteEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EndpointCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudGeo()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EndpointCrudGeo");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointCrudPiping()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EndpointCrudPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateExistingEndpointFromNonExistingProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveExistingEndpointFromNonExistingProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetExistingEndpointFromNonExistingProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetExistingEndpointFromNonExistingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNonExistingEndpointFromProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RemoveNonExistingEndpointFromProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EnableEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-DisableEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpointUsingPiping()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EnableEndpointUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEndpointUsingPipingFromGetProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EnableEndpointUsingPipingFromGetProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEndpointUsingPiping()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-DisableEndpointUsingPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableNonExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EnableNonExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableNonExistingEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-DisableNonExistingEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEndpointTypeCaseInsensitive()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-EndpointTypeCaseInsensitive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipeEndpointFromGetEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-PipeEndpointFromGetEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipeEndpointFromGetProfile()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-PipeEndpointFromGetProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveCustomHeadersFromEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AddAndRemoveCustomHeadersFromEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAndRemoveIpAddressRanges()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AddAndRemoveIpAddressRanges");
        }
    }
}

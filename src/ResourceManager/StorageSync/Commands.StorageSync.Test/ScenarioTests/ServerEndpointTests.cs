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


using Microsoft.Azure.Commands.StorageSync.Test.ScenarioTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.StorageSync.Test.ScenarioTests
{
    public class ServerEndpointTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ServerEndpointTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(_logger = new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestServerEndpoint()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-ServerEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureServerEndpoint()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewAzureServerEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureServerEndpoint()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetAzureServerEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureServerEndpoints()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-GetAzureServerEndpoints");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureServerEndpoint()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureServerEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingSetServerEndpoint()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-PipingToSetAzureRmCurrentServerEndpoint");
        }
    }
}

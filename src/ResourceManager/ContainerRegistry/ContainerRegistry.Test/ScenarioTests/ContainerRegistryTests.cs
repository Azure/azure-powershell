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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ContainerRegistry.Test.ScenarioTests
{
    public class ContainerRegistryTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ContainerRegistryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestContainerReg()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureContainerRegistry");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestContainerRegCredential()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureContainerRegistryCredential");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestContainerRegNameAvailability()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureContainerRegistryNameAvailability");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestContainerRegReplication()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureContainerRegistryReplication");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestContainerRegWebhook()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureContainerRegistryWebhook");
        }
    }
}

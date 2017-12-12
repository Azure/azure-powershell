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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ContainerRegistry.Test.ScenarioTests
{
    public class ContainerRegistryTests : RMTestBase
    {
        public ContainerRegistryTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureContainerRegistry()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureContainerRegistry");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureContainerRegistryCredential()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureContainerRegistryCredential");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureContainerRegistryNameAvailability()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureContainerRegistryNameAvailability");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureContainerRegistryReplication()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureContainerRegistryReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureContainerRegistryWebhook()
        {
            TestController.NewInstance.RunPowerShellTest("Test-AzureContainerRegistryWebhook");
        }
    }
}

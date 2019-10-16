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

namespace Microsoft.Azure.Commands.Maintenance.Test.ScenarioTests
{
    public class MaintenanceTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public MaintenanceTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfiguration()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfigurationWithIdentity()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfigurationWithIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfigurationWithIdentities()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfigurationWithIdentities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestContainerInstanceLog()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmContainerInstanceLog");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfigurationWithVolume()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfigurationWithVolume");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfigurationWithVolumeAndIdentity()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfigurationWithVolumeAndIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfigurationWithVolumeAndIdentities()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfigurationWithVolumeAndIdentities");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateMaintenanceConfigurationDnsLabel()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmMaintenanceConfigurationWithDnsNameLabel");
        }
    }
}

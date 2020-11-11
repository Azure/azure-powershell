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
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class DeviceSecurityGroupsTests
    {
        private readonly XunitTracingInterceptor _logger;

        public DeviceSecurityGroupsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceIdScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmDeviceSecurityGroup-ResourceIdScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceIdLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzureRmDeviceSecurityGroup-ResourceIdLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceIdLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmDeviceSecurityGroup-ResourceIdLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveDeviceSecurityGroups()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remove-AzureRmDeviceSecurityGroup-ResourceIdLevelResource");
        }
    }
}

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
    public class SecurityAutomationTests
    {
        private readonly XunitTracingInterceptor _logger;

        public SecurityAutomationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationSubscriptionScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAutomation-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationResourceScope()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAutomation-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationResourceGroupLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Get-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationResourceGroupLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSecurityAutomationResourceGroupLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSecurityAutomationResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSecurityAutomationInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzSecurityAutomation-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmSecurityAutomationResourceGroupLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Confirm-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmSecurityAutomationResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Confirm-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmSecurityAutomationInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Confirm-AzSecurityAutomation-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSecurityAutomationResourceGroupLevelResource()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remove-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSecurityAutomationResourceId()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remove-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSecurityAutomationInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Remove-AzSecurityAutomation-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationScopeObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSecurityAutomationScopeObject-Test");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationSourceObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSecurityAutomationSourceObject-Test");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationActionObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "New-AzSecurityAutomationActionObject-Test");
        }

    }
}

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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SecurityAutomationTests : SecurityTestRunner
    {
        public SecurityAutomationTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzSecurityAutomation-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationResourceScope()
        {
            TestRunner.RunTestScript("Get-AzSecurityAutomation-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Get-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSecurityAutomationResourceId()
        {
            TestRunner.RunTestScript("Get-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("New-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSecurityAutomationResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Set-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSecurityAutomationResourceId()
        {
            TestRunner.RunTestScript("Set-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSecurityAutomationInputObject()
        {
            TestRunner.RunTestScript("Set-AzSecurityAutomation-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmSecurityAutomationResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Confirm-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmSecurityAutomationResourceId()
        {
            TestRunner.RunTestScript("Confirm-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfirmSecurityAutomationInputObject()
        {
            TestRunner.RunTestScript("Confirm-AzSecurityAutomation-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSecurityAutomationResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Remove-AzSecurityAutomation-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSecurityAutomationResourceId()
        {
            TestRunner.RunTestScript("Remove-AzSecurityAutomation-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSecurityAutomationInputObject()
        {
            TestRunner.RunTestScript("Remove-AzSecurityAutomation-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationScopeObject()
        {
            TestRunner.RunTestScript("New-AzSecurityAutomationScopeObject-Test");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationSourceObject()
        {
            TestRunner.RunTestScript("New-AzSecurityAutomationSourceObject-Test");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewSecurityAutomationActionObject()
        {
            TestRunner.RunTestScript("New-AzSecurityAutomationActionObject-Test");
        }
    }
}

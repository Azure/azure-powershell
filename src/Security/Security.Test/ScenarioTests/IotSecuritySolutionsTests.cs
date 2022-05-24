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
    public class IotSecuritySolutionsTests : SecurityTestRunner
    {
        public IotSecuritySolutionsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetSubscriptionScope()
        {
            TestRunner.RunTestScript("Get-AzureRmIotSecuritySolution-SubscriptionScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceGroupScope()
        {
            TestRunner.RunTestScript("Get-AzureRmIotSecuritySolution-ResourceGroupScope");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Get-AzureRmIotSecuritySolution-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetResourceId()
        {
            TestRunner.RunTestScript("Get-AzureRmIotSecuritySolution-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Set-AzureRmIotSecuritySolution-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetResourceId()
        {
            TestRunner.RunTestScript("Set-AzureRmIotSecuritySolution-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetInputObject()
        {
            TestRunner.RunTestScript("Set-AzureRmIotSecuritySolution-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Remove-AzureRmIotSecuritySolution-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveResourceId()
        {
            TestRunner.RunTestScript("Remove-AzureRmIotSecuritySolution-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateResourceGroupLevelResource()
        {
            TestRunner.RunTestScript("Update-AzureRmIotSecuritySolution-ResourceGroupLevelResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateResourceId()
        {
            TestRunner.RunTestScript("Update-AzureRmIotSecuritySolution-ResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateInputObject()
        {
            TestRunner.RunTestScript("Update-AzureRmIotSecuritySolution-InputObject");
        }
    }
}

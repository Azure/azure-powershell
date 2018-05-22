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

using Microsoft.Azure.Commands.Consumption.Test.ScenarioTests.ScenarioTest;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Consumption.Test.ScenarioTests
{
    public class BudgetTests : RMTestBase
    {
        public BudgetTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBudget()
        {
            TestController.NewInstance.RunPowerShellTest("Test-NewBudget");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBudgetAtResourceGroupLevel()
        {
            TestController.NewInstance.RunPowerShellTest("Test-NewBudgetAtResourceGroupLevel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBudgets()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetBudgets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBudgetsAtResourceGroupLevel()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetBudgetsAtResourceGroupLevel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBudgetByName()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetBudgetByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBudgetByNameAtResourceGroupLevel()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetBudgetByNameAtResourceGroupLevel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetBudget()
        {
            TestController.NewInstance.RunPowerShellTest("Test-SetBudget");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetBudgetAtResourceGroupLevel()
        {
            TestController.NewInstance.RunPowerShellTest("Test-SetBudgetAtResourceGroupLevel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBudget()
        {
            TestController.NewInstance.RunPowerShellTest("Test-RemoveBudget");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBudgetAtResourceGroupLevel()
        {
            TestController.NewInstance.RunPowerShellTest("Test-RemoveBudgetAtResourceGroupLevel");
        }
    }
}

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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Consumption.Test.ScenarioTests
{
    public class BudgetTests : ConsumptionTestRunner
    {
        public BudgetTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBudgetAtSubscriptionLevel()
        {
            TestRunner.RunTestScript("Test-BudgetAtSubscriptionLevel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBudgetAtResourceGroupLevel()
        {
            TestRunner.RunTestScript("Test-BudgetAtResourceGroupLevel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBudgets()
        {
            TestRunner.RunTestScript("Test-GetBudgets");
        }
    }
}

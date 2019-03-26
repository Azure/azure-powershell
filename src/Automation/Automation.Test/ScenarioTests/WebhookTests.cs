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

namespace Commands.Automation.Test
{
    public class WebhookTests : AutomationTestRunner
    {
        public WebhookTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Parallelization failures when accessing RunbookFile.ps1")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void BasicCrud()
        {
            TestRunner.RunTestScript("Test-BasicCrud");
        }

        [Fact(Skip = "Parallelization failures when accessing RunbookFile.ps1")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void NewWithParameters()
        {
            TestRunner.RunTestScript("Test-NewWithParameters");
        }

        [Fact(Skip = "Parallelization failures when accessing RunbookFile.ps1")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void NewFailureParams()
        {
            TestRunner.RunTestScript("Test-NewFailureParams");
        }

        [Fact(Skip = "Parallelization failures when accessing RunbookFile.ps1")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetSuccessScenarios()
        {
            TestRunner.RunTestScript("Test-GetSuccessScenarios");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetFailureScenarios()
        {
            TestRunner.RunTestScript("Test-GetFailureScenarios");
        }
    }
}
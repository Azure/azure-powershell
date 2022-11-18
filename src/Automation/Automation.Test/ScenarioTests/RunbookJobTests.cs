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
using System.IO;
using Xunit;

namespace Commands.Automation.Test
{
    public class RunbookJobTests : AutomationTestRunner
    {
        public RunbookJobTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateRunbookGraph()
        {
            // Write PS Function and call it here
            TestRunner.RunTestScript("Test-CreateRunbookGraph -Name RB-Graphical");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportRunbookPowerShell()
        {
            string runbookPath = Path.Combine("ScenarioTests", "Resources", "RB-PowerShellScriptTutorial.ps1");
            TestRunner.RunTestScript(string.Format("Test-ImportRunbookPowerShell -Name TestRunbook-PowerShellScript -RunbookPath {0}", runbookPath));
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportAndDeleteRunbookGraphical()
        {
            string runbookPath = Path.Combine("ScenarioTests", "Resources", "RB-GraphTutorial.graphrunbook");
            TestRunner.RunTestScript(string.Format("Test-ImportAndDeleteRunbookGraphical -Name TestRunbook-Grapical -RunbookPath {0}", runbookPath));
        }

        [Fact(Skip = "Failed output record causes JSON convert exception in Travis run.")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateJobAndGetOutputPowerShellScript()
        {
            string runbookPath = Path.Combine("ScenarioTests", "Resources", "RB-PowerShellScriptTutorial.ps1");
            TestRunner.RunTestScript(string.Format("Test-CreateJobAndGetOutputPowerShellScript -Name TestRunbook-PSScript-JobAndOutput -RunbookPath {0}", runbookPath));
        }
    }
}

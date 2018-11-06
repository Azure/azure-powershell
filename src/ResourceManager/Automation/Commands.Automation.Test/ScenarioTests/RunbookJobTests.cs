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

namespace Commands.Automation.Test
{
    using Microsoft.Azure.Commands.Automation.Test;
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class RunbookJobTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public RunbookJobTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestCreateRunbookGraph()
        {
            // Write PS Function and call it here
            RunPowerShellTest(_logger, "Test-CreateRunbookGraph -Name RB-Graphical-01");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestImportRunbookPowerShell()
        {
            RunPowerShellTest(_logger, "Test-ImportRunbookPowerShell -Name TestRunbook-PowerShellScript -RunbookPath ScenarioTests\\Resources\\RB-PowerShellScriptTutorial.ps1");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestImportAndDeleteRunbookGraphical()
        {
            RunPowerShellTest(_logger, "Test-ImportAndDeleteRunbookGraphical -Name TestRunbook-Grapical -RunbookPath ScenarioTests\\Resources\\RB-GraphTutorial.graphrunbook");
        }

        [Fact(Skip = "Failed output record causes JSON convert exception in Travis run.")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestCreateJobAndGetOutputPowerShellScript()
        {
            RunPowerShellTest(_logger, "Test-CreateJobAndGetOutputPowerShellScript -Name TestRunbook-PSScript-JobAndOutput -RunbookPath ScenarioTests\\Resources\\RB-PowerShellScriptTutorial.ps1");
        }
    }
}

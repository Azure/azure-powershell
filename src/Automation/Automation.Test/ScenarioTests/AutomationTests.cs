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
    public class AutomationTests : AutomationTestRunner
    {
        public AutomationTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationStartAndStopRunbook()
        {
            TestRunner.RunTestScript("Test-AutomationStartAndStopRunbook -runbookPath ScenarioTests\\Resources\\Test-Workflow.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationPublishAndEditRunbook()
        {
            TestRunner.RunTestScript("Test-AutomationPublishAndEditRunbook -runbookPath ScenarioTests\\Resources\\Test-Workflow.ps1 -editRunbookPath Resources\\Automation\\Test-WorkflowV2.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationConfigureRunbook()
        {
            TestRunner.RunTestScript("Test-AutomationConfigureRunbook -runbookPath ScenarioTests\\Resources\\Write-DebugAndVerboseOutput.ps1");
        }

        [Fact(Skip = "Need to re-record tests with latest version of automation library")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAutomationSuspendAndResumeJob()
        {
            TestRunner.RunTestScript("Test-AutomationSuspendAndResumeJob -runbookPath ScenarioTests\\Resources\\Use-WorkflowCheckpointSample.ps1");
        }

        [Fact(Skip = "Need to re-record tests with latest version of automation library")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAutomationStartRunbookOnASchedule()
        {
            TestRunner.RunTestScript("Test-AutomationStartRunbookOnASchedule -runbookPath ScenarioTests\\Resources\\Test-Workflow.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationStartUnpublishedRunbook()
        {
            TestRunner.RunTestScript("Test-AutomationStartUnpublishedRunbook -runbookPath ScenarioTests\\Resources\\Test-WorkFlowWithVariousParameters.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationRunbookWithParameter()
        {
            TestRunner.RunTestScript("Test-RunbookWithParameter -runbookPath ScenarioTests\\Resources\\Test-PowershellRunbook.ps1 -type 'PowerShell' -parameters @{'nums'=@(1,2,3,4,5,6,7)} -expectedResult 28");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationPy2RunbookWithParameter()
        {
            TestRunner.RunTestScript("Test-RunbookWithParameter -runbookPath ScenarioTests\\Resources\\TestPythonRunbook.py -type 'Python2' -parameters @{'param1'='1';'param2'='2';'param3'='3';'param4'='4';'param5'='5';'param6'='6';'param7'='7'} -expectedResult 28");
        }
    }
}

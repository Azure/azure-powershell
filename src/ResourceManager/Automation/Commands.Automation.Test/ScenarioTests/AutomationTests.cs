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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Automation.Test
{
    public class AutomationTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public AutomationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationStartAndStopRunbook()
        {
            RunPowerShellTest(_logger, "Test-AutomationStartAndStopRunbook -runbookPath ScenarioTests\\Resources\\Test-Workflow.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationPublishAndEditRunbook()
        {
            RunPowerShellTest(_logger, "Test-AutomationPublishAndEditRunbook -runbookPath ScenarioTests\\Resources\\Test-Workflow.ps1 -editRunbookPath Resources\\Automation\\Test-WorkflowV2.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationConfigureRunbook()
        {
            RunPowerShellTest(_logger, "Test-AutomationConfigureRunbook -runbookPath ScenarioTests\\Resources\\Write-DebugAndVerboseOutput.ps1");
        }

        [Fact(Skip = "Need to re-record tests with latest version of automation library")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAutomationSuspendAndResumeJob()
        {
            RunPowerShellTest(_logger, "Test-AutomationSuspendAndResumeJob -runbookPath ScenarioTests\\Resources\\Use-WorkflowCheckpointSample.ps1");
        }

        [Fact(Skip = "Need to re-record tests with latest version of automation library")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAutomationStartRunbookOnASchedule()
        {
            RunPowerShellTest(_logger, "Test-AutomationStartRunbookOnASchedule -runbookPath ScenarioTests\\Resources\\Test-Workflow.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationStartUnpublishedRunbook()
        {
            RunPowerShellTest(_logger, "Test-AutomationStartUnpublishedRunbook -runbookPath ScenarioTests\\Resources\\Test-WorkFlowWithVariousParameters.ps1");
        }

        [Fact(Skip = "Need x64 test framework.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationRunbookWithParameter()
        {
            RunPowerShellTest(_logger, "Test-RunbookWithParameter -runbookPath ScenarioTests\\Resources\\fastJob.ps1  @{'nums'='[1,2,3,4,5,6,7]'}  28");
        }
    }
}

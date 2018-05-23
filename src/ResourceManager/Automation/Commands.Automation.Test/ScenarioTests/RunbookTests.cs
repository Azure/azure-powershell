﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.ScenarioTests
{
    public class RunbookTests : AutomationScenarioTestsBase
    {
        public RunbookTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact(Skip = "Exception on PUT of jobs and jobSchedules and need to fix test for Playback mode")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationStartAndStopRunbook()
        {
            RunPowerShellTest("Test-AutomationStartAndStopRunbook -runbookPath ScenarioTests\\Resources\\Test.ps1");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationPublishAndEditRunbook()
        {
            RunPowerShellTest("Test-AutomationPublishAndEditRunbook -runbookPath ScenarioTests\\Resources\\Test.ps1 -editRunbookPath ScenarioTests\\Resources\\Test-V2.ps1");
        }

        [Fact(Skip = "Exception on PUT of jobs and jobSchedules and need to fix test for Playback mode")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationConfigureRunbook()
        {
            RunPowerShellTest("Test-AutomationConfigureRunbook -runbookPath ScenarioTests\\Resources\\Write-DebugAndVerboseOutput.ps1");
        }

        [Fact(Skip = "Need to re-record tests with latest version of automation library")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationSuspendAndResumeJob()
        {
            RunPowerShellTest("Test-AutomationSuspendAndResumeJob -runbookPath ScenarioTests\\Resources\\Use-WorkflowCheckpointSample.ps1");
        }

        [Fact(Skip = "Exception on PUT of jobs and jobSchedules and need to fix test for Playback mode")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationStartRunbookOnASchedule()
        {
            RunPowerShellTest("Test-AutomationStartRunbookOnASchedule -runbookPath ScenarioTests\\Resources\\Test.ps1");
        }

        [Fact(Skip = "Need to re-record tests with latest version of automation library")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationStartUnpublishedRunbook()
        {
            RunPowerShellTest("Test-AutomationStartUnpublishedRunbook -runbookPath ScenarioTests\\Resources\\Test-WorkFlowWithVariousParameters.ps1");
        }

        [Fact(Skip = "Exception on PUT of jobs and jobSchedules and need to fix test for Playback mode")]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestAutomationRunbookWithParameter()
        {
            RunPowerShellTest("Test-RunbookWithParameter -runbookPath ScenarioTests\\Resources\\fastJob.ps1");
        }       
    }
}

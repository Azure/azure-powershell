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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.ServiceManagemenet.Common.Models;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest
{
    public class AutomationTests
    {
        private EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        public AutomationTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact(Skip = "Fix to make x86 compatible.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationStartAndStopRunbook()
        {
            RunPowerShellTest("Test-AutomationStartAndStopRunbook -runbookPath Resources\\Automation\\Test-Workflow.ps1");
        }

        [Fact(Skip = "Fix to make x86 compatible.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationPublishAndEditRunbook()
        {
            RunPowerShellTest("Test-AutomationPublishAndEditRunbook -runbookPath Resources\\Automation\\Test-Workflow.ps1 -editRunbookPath Resources\\Automation\\Test-WorkflowV2.ps1");
        }

        [Fact (Skip = "Fix to make x86 compatible.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationConfigureRunbook()
        {
            RunPowerShellTest("Test-AutomationConfigureRunbook -runbookPath Resources\\Automation\\Write-DebugAndVerboseOutput.ps1");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAutomationSuspendAndResumeJob()
        {
            RunPowerShellTest("Test-AutomationSuspendAndResumeJob -runbookPath Resources\\Automation\\Use-WorkflowCheckpointSample.ps1");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestAutomationStartRunbookOnASchedule()
        {
            RunPowerShellTest("Test-AutomationStartRunbookOnASchedule -runbookPath Resources\\Automation\\Test-Workflow.ps1");
        }

        [Fact(Skip = "Fix to make x86 compatible.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationStartUnpublishedRunbook()
        {
            RunPowerShellTest("Test-AutomationStartUnpublishedRunbook -runbookPath Resources\\Automation\\Test-WorkFlowWithVariousParameters.ps1");
        }

        [Fact(Skip = "Fix to make x86 compatible.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void TestAutomationRunbookWithParameter()
        {
            RunPowerShellTest("Test-RunbookWithParameter -runbookPath Resources\\Automation\\fastJob.ps1  @{'nums'='[1,2,3,4,5,6,7]'}  28");
        }

        protected void SetupManagementClients()
        {
            helper.SetupSomeOfManagementClients();
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(1), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                List<string> modules = Directory.GetFiles("Resources\\Automation".AsAbsoluteLocation(), "*.ps1").ToList();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModulesFromCommon(AzureModule.AzureServiceManagement, modules.ToArray());

                helper.RunPowerShellTest(scripts);
            }
        }
    }
}

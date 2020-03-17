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
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class DeploymentScriptsTests : ResourceTestRunner
    {
        public DeploymentScriptsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptGetForPowerShell()
        {
            TestRunner.RunTestScript("Test-GetDeploymentScript-PowerShell");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptGetForCli()
        {
            TestRunner.RunTestScript("Test-GetDeploymentScript-Cli");
        }

        [Fact(Skip = "Need to wait until the Resources .NET SDK is updated to 3.3.0 in the PS module.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptGetDeploymentScriptWithBadScript()
        {
            TestRunner.RunTestScript("Test-GetDeploymentScriptWithBadScript");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptLogGetForPowerShell()
        {
            TestRunner.RunTestScript("Test-GetDeploymentScriptLog-PowerShell");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptLogGetForCli()
        {
            TestRunner.RunTestScript("Test-GetDeploymentScriptLog-Cli");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptPipeDeploymentScriptObjectToGetLogs()
        {
            TestRunner.RunTestScript("Test-PipeDeploymentScriptObjectToGetLogs");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptTrySaveNonExistingFilePathForLogFile()
        {
            TestRunner.RunTestScript("Test-TrySaveNonExistingFilePathForLogFile");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptRemoveDeploymentScriptPowerShell()
        {
            TestRunner.RunTestScript("Test-RemoveDeploymentScript-PowerShell");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptRemoveDeploymentScriptCli()
        {
            TestRunner.RunTestScript("Test-RemoveDeploymentScript-Cli");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptTryRemoveNonExistingDeploymentScript()
        {
            TestRunner.RunTestScript("Test-TryRemoveNonExistingDeploymentScript");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptRemovePipedDeploymentScriptObject()
        {
            TestRunner.RunTestScript("Test-RemovePipedDeploymentScriptObject");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentScriptGetAllDeploymentScriptPropertiesCli()
        {
            TestRunner.RunTestScript("Test-GetAllDeploymentScriptPropertiesCli");
        }
    }
}

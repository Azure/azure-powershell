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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class CsRunTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoleInfoIsExtractedFromEmulatorOutput()
        {
            var dummyEmulatorOutput = "Exported interface at http://127.0.0.1:81/.\r\nExported interface at tcp://127.0.0.1:8080/.";
            var output = CsRun.GetRoleInfoMessage(dummyEmulatorOutput);
            Assert.True(output.Contains("Role is running at http://127.0.0.1:81"));
            Assert.True(output.Contains("Role is running at tcp://127.0.0.1:8080"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StartEmulatorUsingExpressMode_VerifyCommandLine()
        {
            StartEmulatorCommonTest(ComputeEmulatorMode.Express);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StartEmulatorUsingFullMode_VerifyCommandLine()
        {
            StartEmulatorCommonTest(ComputeEmulatorMode.Full);
        }

        private void StartEmulatorCommonTest(ComputeEmulatorMode mode)
        {
            // Setup
            string testEmulatorFolder = @"C:\sample-path";
            string testPackagePath = @"c:\sample-path\local_package.csx";
            string testConfigPath = @"c:\sample-path\ServiceConfiguration.Local.cscfg";
            string expectedCsrunCommand = testEmulatorFolder + @"\" + Resources.CsRunExe;
            string expectedComputeArguments = Resources.CsRunStartComputeEmulatorArg;
            string expectedRemoveAllDeploymentsArgument = Resources.CsRunRemoveAllDeploymentsArg;
            string expectedAzureProjectArgument = string.Format("/run:\"{0}\";\"{1}\" {2} /useiisexpress",
                testPackagePath, testConfigPath, Resources.CsRunLanuchBrowserArg);
            if (mode== ComputeEmulatorMode.Full)
            {
                expectedComputeArguments += " " + Resources.CsRunFullEmulatorArg;
                expectedAzureProjectArgument += " " + Resources.CsRunFullEmulatorArg;
            }

            string testRoleUrl = "http://127.0.0.1:8080/";
            int testDeploymentId = 58;
            string testOutput = string.Format("Started: deployment23({0}) Role is running at " + testRoleUrl + ".", testDeploymentId.ToString());
            string expectedRoleRunningMessage = string.Format(Resources.EmulatorRoleRunningMessage, testRoleUrl) + System.Environment.NewLine; 

            CsRun csRun = new CsRun(testEmulatorFolder);
            Mock<ProcessHelper> commandRunner = new Mock<ProcessHelper>();
            commandRunner.Setup(p => p.StartAndWaitForProcess(expectedCsrunCommand, expectedComputeArguments));
            commandRunner.Setup(p => p.StartAndWaitForProcess(expectedCsrunCommand, expectedRemoveAllDeploymentsArgument));
            commandRunner.Setup(p => p.StartAndWaitForProcess(expectedCsrunCommand, expectedAzureProjectArgument))
                .Callback(() => { commandRunner.Object.StandardOutput = testOutput; });

            // Execute
            csRun.CommandRunner = commandRunner.Object;
            
            csRun.StartEmulator(testPackagePath, testConfigPath, true, mode);

            // Assert
            commandRunner.VerifyAll();
            Assert.Equal(csRun.DeploymentId, testDeploymentId);
            Assert.Equal(csRun.RoleInformation, expectedRoleRunningMessage);
        }
    }
}
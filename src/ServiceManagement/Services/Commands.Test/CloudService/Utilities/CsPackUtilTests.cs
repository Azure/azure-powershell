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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Moq;
using System.IO;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    public class CsPackUtilTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        void RetrieveRightErrorFromCsPackProcess()
        {
            string serviceName = "AzureService";
            string sampleError = "error";
            string stagingFolder = FileSystemHelper.GetTemporaryDirectoryName();
            string fakedSDKBinPath = @"c:\foobar";
            Directory.CreateDirectory(stagingFolder);
            try
            {
                CloudServiceProject service = new CloudServiceProject(stagingFolder, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                CsPack packTool = new CsPack();
                string standardOutput, standardError;

                //Scenario #1 we set up so cspack.exe fails (exitcode is 1), but gives out the error through standardOutput.
                Mock<ProcessHelper> commandRunner = new Mock<ProcessHelper>();
                commandRunner.Setup(p => p.StartAndWaitForProcess(It.IsAny<string>(), It.IsAny<string>()))
                    .Callback(() => {
                        commandRunner.Object.StandardOutput = sampleError; 
                        commandRunner.Object.StandardError = ""; 
                        commandRunner.Object.ExitCode = 1; 
                    });
                packTool.ProcessUtil = commandRunner.Object;

                //action
                packTool.CreatePackage(service.Components.Definition, service.Paths, DevEnv.Local, fakedSDKBinPath, out standardOutput, out standardError);

                //assert we take "standardoutput" as the error message
                Assert.Equal(sampleError, standardError);

                //Scenario #2: set up so cspack.exe succeed (exitcode is 0)
                commandRunner = new Mock<ProcessHelper>();
                commandRunner.Setup(p => p.StartAndWaitForProcess(It.IsAny<string>(), It.IsAny<string>()))
                    .Callback(() =>
                    {
                        commandRunner.Object.StandardOutput = sampleError;
                        commandRunner.Object.StandardError = string.Empty;
                        commandRunner.Object.ExitCode = 0;
                    });
                packTool.ProcessUtil = commandRunner.Object;

                //action
                packTool.CreatePackage(service.Components.Definition, service.Paths, DevEnv.Local, fakedSDKBinPath, out standardOutput, out standardError);

                //assert, we outputs no error
                Assert.Equal(string.Empty, standardError);

                //Sceanrio 3: set up so cspack.exe failed (exitcode is 1), but gives out no ouput and error
                commandRunner = new Mock<ProcessHelper>();
                commandRunner.Setup(p => p.StartAndWaitForProcess(It.IsAny<string>(), It.IsAny<string>()))
                    .Callback(() =>
                    {
                        commandRunner.Object.StandardOutput = string.Empty;
                        commandRunner.Object.StandardError = string.Empty;
                        commandRunner.Object.ExitCode = 1;
                    });
                packTool.ProcessUtil = commandRunner.Object;

                //action
                packTool.CreatePackage(service.Components.Definition, service.Paths, DevEnv.Local, fakedSDKBinPath, out standardOutput, out standardError);

                //assert, we output a generic error message
                Assert.Equal(Resources.CsPackExeGenericFailure, standardError);
            }
            finally
            {
                Directory.Delete(stagingFolder, true);
            }
        }
    }
}
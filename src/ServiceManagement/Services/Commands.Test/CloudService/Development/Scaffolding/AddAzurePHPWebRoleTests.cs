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

using System.IO;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Scaffolding
{
    
    public class AddAzurePHPWebRoleTests : SMTestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private AddAzurePHPWebRoleCommand addPHPWebCmdlet;

        public AddAzurePHPWebRoleTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();
        }

        [Fact]
        public void AddAzurePHPWebRoleProcess()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WebRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                addPHPWebCmdlet = new AddAzurePHPWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime };
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreatePHP, rootPath, roleName);
                
                addPHPWebCmdlet.ExecuteCmdlet();

                AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), Path.Combine(Resources.PHPScaffolding, Resources.WebRole));
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
            }
        }

        [Fact]
        public void AddAzurePHPWebRoleWillRecreateDeploymentSettings()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WebRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                addPHPWebCmdlet = new AddAzurePHPWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime };
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreatePHP, rootPath, roleName);
                string settingsFilePath = Path.Combine(rootPath, Resources.SettingsFileName);
                File.Delete(settingsFilePath);
                Assert.False(File.Exists(settingsFilePath));

                addPHPWebCmdlet.ExecuteCmdlet();

                AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), Path.Combine(Resources.PHPScaffolding, Resources.WebRole));
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
                Assert.True(File.Exists(settingsFilePath));
            }
        }
    }
}

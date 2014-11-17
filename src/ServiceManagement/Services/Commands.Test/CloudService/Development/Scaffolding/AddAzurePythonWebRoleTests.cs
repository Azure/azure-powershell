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

using System.Diagnostics;
using System.IO;
using System.Management.Automation;
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
    public class AddAzurePythonWebRoleTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private AddAzureDjangoWebRoleCommand addPythonWebCmdlet;

        public AddAzurePythonWebRoleTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();
        }

        [Fact]
        public void AddAzurePythonWebRoleProcess()
        {
            var pyInstall = AddAzureDjangoWebRoleCommand.FindPythonInterpreterPath();
            if (pyInstall == null)
            {
                Assert.True(false, "Python is not installed on this machine and therefore the Python tests cannot be run");
                return;
            }

            string stdOut, stdErr;
            ProcessHelper.StartAndWaitForProcess(
                    new ProcessStartInfo(
                        Path.Combine(pyInstall, "python.exe"),
                        string.Format("-m django.bin.django-admin")
                    ),
                    out stdOut,
                    out stdErr
            );

            if (stdOut.IndexOf("django-admin.py") == -1)
            {
                Assert.True(false, "Django is not installed on this machine and therefore the Python tests cannot be run.  Please 'pip install Django==1.5'");
                return;
            }

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WebRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                addPythonWebCmdlet = new AddAzureDjangoWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime };
                addPythonWebCmdlet.CommandRuntime = mockCommandRuntime;
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreatePython, rootPath, roleName);
                mockCommandRuntime.ResetPipelines();

                addPythonWebCmdlet.ExecuteCmdlet();

                AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), Path.Combine(Resources.PythonScaffolding, Resources.WebRole));
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
                Assert.True(Directory.Exists(Path.Combine(rootPath, roleName, roleName)));
                Assert.True(File.Exists(Path.Combine(rootPath, roleName, roleName, "manage.py")));
                Assert.True(Directory.Exists(Path.Combine(rootPath, roleName, roleName, roleName)));
                Assert.True(File.Exists(Path.Combine(rootPath, roleName, roleName, roleName, "__init__.py")));
                Assert.True(File.Exists(Path.Combine(rootPath, roleName, roleName, roleName, "settings.py")));
                Assert.True(File.Exists(Path.Combine(rootPath, roleName, roleName, roleName, "urls.py")));
                Assert.True(File.Exists(Path.Combine(rootPath, roleName, roleName, roleName, "wsgi.py")));
            }
        }

        [Fact]
        public void AddAzurePythonWebRoleWillRecreateDeploymentSettings()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WebRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                addPythonWebCmdlet = new AddAzureDjangoWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime };
                addPythonWebCmdlet.CommandRuntime = mockCommandRuntime;
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreatePython, rootPath, roleName);
                string settingsFilePath = Path.Combine(rootPath, Resources.SettingsFileName);
                File.Delete(settingsFilePath);
                Assert.False(File.Exists(settingsFilePath));

                addPythonWebCmdlet.ExecuteCmdlet();

                AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), Path.Combine(Resources.PythonScaffolding, Resources.WebRole));
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
                Assert.True(File.Exists(settingsFilePath));
            }
        }
    }
}

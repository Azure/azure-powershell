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
using System.Reflection;
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
    
    public class NewAzureRoleTemplateTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private NewAzureRoleTemplateCommand addTemplateCmdlet;

        public NewAzureRoleTemplateTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();
        }

        [Fact]
        public void NewAzureRoleTemplateWithWebRole()
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "WebRoleTemplate");
            addTemplateCmdlet = new NewAzureRoleTemplateCommand() { Web = true, CommandRuntime = mockCommandRuntime };

            addTemplateCmdlet.ExecuteCmdlet();

            Assert.Equal<string>(outputPath, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.Path));
            Testing.AssertDirectoryIdentical(Path.Combine(Resources.GeneralScaffolding, RoleType.WebRole.ToString()), outputPath);
        }

        [Fact]
        public void NewAzureRoleTemplateWithWorkerRole()
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "WorkerRoleTemplate");
            addTemplateCmdlet = new NewAzureRoleTemplateCommand() { Worker = true, CommandRuntime = mockCommandRuntime };

            addTemplateCmdlet.ExecuteCmdlet();

            Assert.Equal<string>(outputPath, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.Path));
            Testing.AssertDirectoryIdentical(Path.Combine(Resources.GeneralScaffolding, RoleType.WorkerRole.ToString()), outputPath);
        }

        [Fact]
        public void NewAzureRoleTemplateWithOutputPath()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string outputPath = files.RootPath;
                addTemplateCmdlet = new NewAzureRoleTemplateCommand() { Worker = true, CommandRuntime = mockCommandRuntime, Output = outputPath };

                addTemplateCmdlet.ExecuteCmdlet();

                Assert.Equal<string>(outputPath, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.Path));
                Testing.AssertDirectoryIdentical(Path.Combine(Resources.GeneralScaffolding, RoleType.WorkerRole.ToString()), outputPath);
            }
        }

        [Fact]
        public void NewAzureRoleTemplateWithDirectoryExists()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string outputPath = files.CreateDirectory("test");
                addTemplateCmdlet = new NewAzureRoleTemplateCommand() { Worker = true, CommandRuntime = mockCommandRuntime, Output = outputPath };

                addTemplateCmdlet.ExecuteCmdlet();

                Assert.Equal<string>(
                    outputPath,
                    ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.Path));
                Testing.AssertDirectoryIdentical(
                    Path.Combine(Resources.GeneralScaffolding,
                    RoleType.WorkerRole.ToString()),
                    outputPath);
            }
        }

        [Fact(Skip = "TODO: Fix SetScaffolding in CloudServiceProject.")]
        public void NewAzureRoleTemplateWithRunningOutsideDefaultDirectory()
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "TestDir", "WebRoleTemplate");
            addTemplateCmdlet = new NewAzureRoleTemplateCommand() { Web = true, CommandRuntime = mockCommandRuntime };
            string originalDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory("TestDir");
            Directory.SetCurrentDirectory("TestDir");

            try
            {
                addTemplateCmdlet.ExecuteCmdlet();

                Assert.Equal<string>(
                    outputPath,
                    ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.Path));
                Testing.AssertDirectoryIdentical(
                    Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
                    Resources.GeneralScaffolding, RoleType.WebRole.ToString())),
                    outputPath);
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDir);
            }
        }
    }
}

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

using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Tests.Cmdlet
{
    public class SetAzureVMSizeTests : SMTestBase
    {
        private const string serviceName = "AzureService";

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureServiceProjectRoleCommand cmdlet;

        public SetAzureVMSizeTests()
        {
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new SetAzureServiceProjectRoleCommand();
            cmdlet.CommandRuntime = mockCommandRuntime;
            cmdlet.PassThru = true;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsNode()
        {
            string newRoleVMSize = "Large";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                string roleName = "WebRole1";
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                cmdlet.PassThru = false;
                RoleSettings roleSettings = cmdlet.SetAzureVMSizeProcess("WebRole1", newRoleVMSize, service.Paths.RootPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);

                Assert.Equal<string>(newRoleVMSize, service.Components.Definition.WebRole[0].vmsize.ToString());
                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
                Assert.Equal<string>(roleName, roleSettings.name);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsPHP()
        {
            string newRoleVMSize = "Medium";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                string roleName = "WebRole1";
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                RoleSettings roleSettings = cmdlet.SetAzureVMSizeProcess("WebRole1", newRoleVMSize, service.Paths.RootPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);

                
                Assert.Equal<string>(newRoleVMSize, service.Components.Definition.WebRole[0].vmsize.ToString());
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).Members[Parameters.RoleName].Value.ToString());
                Assert.True(((PSObject)mockCommandRuntime.OutputPipeline[0]).TypeNames.Contains(typeof(RoleSettings).FullName));
                Assert.Equal<string>(roleName, roleSettings.name);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsRoleNameDoesNotExistFail()
        {
            string roleName = "WebRole1";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, roleName, "Medium"), string.Format(Resources.RoleNotFoundMessage, roleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsNodeRoleNameDoesNotExistServiceContainsWebRoleFail()
        {
            string roleName = "WebRole1";
            string invalidRoleName = "foo";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, roleName, 1);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, invalidRoleName, "Large"), string.Format(Resources.RoleNotFoundMessage, invalidRoleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsPHPRoleNameDoesNotExistServiceContainsWebRoleFail()
        {
            string roleName = "WebRole1";
            string invalidRoleName = "foo";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, roleName, 1);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, invalidRoleName, "Large"), string.Format(Resources.RoleNotFoundMessage, invalidRoleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsNodeRoleNameDoesNotExistServiceContainsWorkerRoleFail()
        {
            string roleName = "WorkerRole1";
            string invalidRoleName = "foo";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath, roleName, 1);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, invalidRoleName, "Large"), string.Format(Resources.RoleNotFoundMessage, invalidRoleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsPHPRoleNameDoesNotExistServiceContainsWorkerRoleFail()
        {
            string roleName = "WorkerRole1";
            string invalidRoleName = "foo";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath, roleName, 1);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, invalidRoleName, "Large"), string.Format(Resources.RoleNotFoundMessage, invalidRoleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsEmptyRoleNameFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, string.Empty, "Large"), string.Format(Resources.InvalidOrEmptyArgumentMessage, Resources.RoleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsNullRoleNameFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                Testing.AssertThrows<ArgumentException>(() => service.SetRoleVMSize(service.Paths, null, "Large"), string.Format(Resources.InvalidOrEmptyArgumentMessage, Resources.RoleName));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsCaseInsensitive()
        {
            string newRoleVMSize = "Large" /*RoleSize.Large.ToString()*/;

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                string roleName = "WebRole1";
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                cmdlet.PassThru = false;
                RoleSettings roleSettings = cmdlet.SetAzureVMSizeProcess("WeBrolE1", newRoleVMSize, service.Paths.RootPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);

                
                Assert.Equal<string>(newRoleVMSize, service.Components.Definition.WebRole[0].vmsize.ToString());
                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
                Assert.Equal<string>(roleName, roleSettings.name);

            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureVMSizeProcessTestsCaseInsensitiveVMSizeSize()
        {
            string newRoleVMSize = "ExTraLaRge";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                string roleName = "WebRole1";
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                cmdlet.PassThru = false;
                RoleSettings roleSettings = cmdlet.SetAzureVMSizeProcess("WebRole1", newRoleVMSize, service.Paths.RootPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);


                Assert.Equal<string>(newRoleVMSize.ToLower(), service.Components.Definition.WebRole[0].vmsize.ToString().ToLower());
                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
                Assert.Equal<string>(roleName, roleSettings.name);

            }
        }
    }
}
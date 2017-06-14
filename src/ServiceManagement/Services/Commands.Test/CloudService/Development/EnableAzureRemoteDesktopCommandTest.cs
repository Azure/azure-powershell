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
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development
{
    /// <summary>
    /// Basic unit tests for the Enable-AzureServiceProjectRemoteDesktop enableRDCmdlet.
    /// </summary>
    public class EnableAzureRemoteDesktopCommandTest : SMTestBase
    {
        static private MockCommandRuntime mockCommandRuntime;

        static private EnableAzureServiceProjectRemoteDesktopCommand enableRDCmdlet;

        private AddAzureNodeWebRoleCommand addNodeWebCmdlet;

        private AddAzureNodeWorkerRoleCommand addNodeWorkerCmdlet;

        public EnableAzureRemoteDesktopCommandTest()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();

            addNodeWebCmdlet = new AddAzureNodeWebRoleCommand();
            addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand();
            enableRDCmdlet = new EnableAzureServiceProjectRemoteDesktopCommand();

            addNodeWorkerCmdlet.CommandRuntime = mockCommandRuntime;
            addNodeWebCmdlet.CommandRuntime = mockCommandRuntime;
            enableRDCmdlet.CommandRuntime = mockCommandRuntime;
        }

        /// <summary>
        /// Invoke the Enable-AzureServiceProjectRemoteDesktop enableRDCmdlet.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public static void EnableRemoteDesktop(string username, string password)
        {
            SecureString securePassword = null;
            if (password != null)
            {
                securePassword = new SecureString();
                foreach (char ch in password)
                {
                    securePassword.AppendChar(ch);
                }
                securePassword.MakeReadOnly();
            }

            if (enableRDCmdlet == null)
            {
                enableRDCmdlet = new EnableAzureServiceProjectRemoteDesktopCommand();
                if (mockCommandRuntime == null)
                {
                    mockCommandRuntime = new MockCommandRuntime();
                }
                enableRDCmdlet.CommandRuntime = mockCommandRuntime;
            }

            enableRDCmdlet.Username = username;
            enableRDCmdlet.Password = securePassword;
            enableRDCmdlet.EnableRemoteDesktop();
        }

        public static void VerifyWebRole(WebRole role, bool isForwarder)
        {
            Assert.Equal(isForwarder ? 1 : 0, role.Imports.Where(i => i.moduleName == "RemoteForwarder").Count());
            Assert.Equal(1, role.Imports.Where(i => i.moduleName == "RemoteAccess").Count());
        }

        public static void VerifyWorkerRole(WorkerRole role, bool isForwarder)
        {
            Assert.Equal(isForwarder ? 1 : 0, role.Imports.Where(i => i.moduleName == "RemoteForwarder").Count());
            Assert.Equal(1, role.Imports.Where(i => i.moduleName == "RemoteAccess").Count());
        }

        public static void VerifyRoleSettings(CloudServiceProject service)
        {
            IEnumerable<RoleSettings> settings =
                Enumerable.Concat(
                    service.Components.CloudConfig.Role,
                    service.Components.LocalConfig.Role);
            foreach (RoleSettings roleSettings in settings)
            {
                Assert.Equal(
                    1,
                    roleSettings
                        .Certificates
                        .Where(c => c.name == "Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption")
                        .Count());
            }
        }
        
        /// <summary>
        /// Perform basic parameter validation.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopBasicParameterValidation()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                files.CreateNewService("NEW_SERVICE");

                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop(null, null));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop(string.Empty, string.Empty));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop("user", null));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop("user", string.Empty));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop("user", "short"));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop("user", "onlylower"));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop("user", "ONLYUPPER"));
                Testing.AssertThrows<ArgumentException>(
                    () => EnableRemoteDesktop("user", "1234567890"));
            }
        }

        /// <summary>
        /// Enable remote desktop for an empty service.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopForEmptyService()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                files.CreateNewService("NEW_SERVICE");
                Testing.AssertThrows<InvalidOperationException>(() =>
                    EnableRemoteDesktop("user", "GoodPassword!"));
            }
        }

        /// <summary>
        /// Enable remote desktop for a simple web role.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopForWebRole()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                string rootPath = files.CreateNewService("NEW_SERVICE");
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WebRole", Instances = 1 };
                addNodeWebCmdlet.ExecuteCmdlet();
                EnableRemoteDesktop("user", "GoodPassword!");

                // Verify the role has been setup with forwarding, access,
                // and certs
                CloudServiceProject service = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                VerifyWebRole(service.Components.Definition.WebRole[0], true);
                VerifyRoleSettings(service);
            }
        }

        /// <summary>
        /// Enable remote desktop for web and worker roles.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopForWebAndWorkerRoles()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                string rootPath = files.CreateNewService("NEW_SERVICE");
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WebRole", Instances = 1 };
                addNodeWebCmdlet.ExecuteCmdlet();
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WorkerRole", Instances = 1 };
                addNodeWorkerCmdlet.ExecuteCmdlet();
                mockCommandRuntime.ResetPipelines();
                EnableRemoteDesktop("user", "GoodPassword!");

                // Verify the roles have been setup with forwarding, access,
                // and certs
                CloudServiceProject service = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                VerifyWebRole(service.Components.Definition.WebRole[0], false);
                VerifyWorkerRole(service.Components.Definition.WorkerRole[0], true);
                VerifyRoleSettings(service);
                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
            }
        }

        /// <summary>
        /// Enable remote desktop for multiple web and worker roles.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopForMultipleWebAndWorkerRolesTwice()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                string rootPath = files.CreateNewService("NEW_SERVICE");
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WebRole_1", Instances = 1 };
                addNodeWebCmdlet.ExecuteCmdlet();
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WebRole_2", Instances = 1 };
                addNodeWebCmdlet.ExecuteCmdlet();
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WorkerRole_1", Instances = 1 };
                addNodeWorkerCmdlet.ExecuteCmdlet();
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WorkerRole_2", Instances = 1 };
                addNodeWorkerCmdlet.ExecuteCmdlet();
                mockCommandRuntime.ResetPipelines();
                
                enableRDCmdlet.PassThru = true;
                EnableRemoteDesktop("user", "GoodPassword!");

                enableRDCmdlet.PassThru = false;
                EnableRemoteDesktop("other", "OtherPassword!");

                // Verify the roles have been setup with forwarding, access,
                // and certs
                CloudServiceProject service = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                VerifyWebRole(service.Components.Definition.WebRole[0], false);
                VerifyWebRole(service.Components.Definition.WebRole[0], false);
                VerifyWorkerRole(service.Components.Definition.WorkerRole[0], true);
                VerifyWorkerRole(service.Components.Definition.WorkerRole[1], false);
                VerifyRoleSettings(service);
                Assert.Equal<int>(1, mockCommandRuntime.OutputPipeline.Count);
                Assert.True((bool)mockCommandRuntime.OutputPipeline[0]);
            }
        }

        /// <summary>
        /// Enable remote desktop for a simple web role.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopUnicode()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                string rootPath = files.CreateNewService("NEW_SERVICE");
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand()
                {
                    RootPath = rootPath,
                    CommandRuntime = mockCommandRuntime,
                    Name = "WebRole",
                    Instances = 1
                };
                addNodeWebCmdlet.ExecuteCmdlet();
                EnableRemoteDesktop("㯑䲘䄂㮉", "㯑䲘䄂㮉㮉㮉㮉L");

                // Verify the role has been setup with forwarding, access,
                // and certs
                CloudServiceProject service = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                VerifyWebRole(service.Components.Definition.WebRole[0], true);
                VerifyRoleSettings(service);
            }
        }

        /// <summary>
        /// Enable remote desktop using short unicode password.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableRemoteDesktopUnicodeAndShortPasswordFails()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                string rootPath = files.CreateNewService("NEW_SERVICE");
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand()
                {
                    RootPath = rootPath,
                    CommandRuntime = mockCommandRuntime,
                    Name = "WebRole",
                    Instances = 1
                };
                addNodeWebCmdlet.ExecuteCmdlet();
                Testing.AssertThrows<ArgumentException>(() => EnableRemoteDesktop("㯑䲘䄂㮉", "㯑䲘"));
            }
        }
    }
}

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
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    public class AzureServiceTests: SMTestBase
    {
        private const string serviceName = "AzureService";

        private MockCommandRuntime mockCommandRuntime;

        private AddAzureNodeWebRoleCommand addNodeWebCmdlet;

        private AddAzureNodeWorkerRoleCommand addNodeWorkerCmdlet;

        /// <summary>
        /// This method handles most possible cases that user can do to create role
        /// </summary>
        /// <param name="webRole">Count of web roles to add</param>
        /// <param name="workerRole">Count of worker role to add</param>
        /// <param name="addWebBeforeWorker">Decides in what order to add roles. There are three options, note that value between brackets is the value to pass:
        /// 1. Web then, interleaving (0): interleave adding and start by adding web role first.
        /// 2. Worker then, interleaving (1): interleave adding and start by adding worker role first.
        /// 3. Web then worker (2): add all web roles then worker roles.
        /// 4. Worker then web (3): add all worker roles then web roles.
        /// By default this parameter is set to 0
        /// </param>
        private void AddNodeRoleTest(int webRole, int workerRole, int order = 0)
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                AzureServiceWrapper wrappedService = new AzureServiceWrapper(files.RootPath, serviceName, null);
                CloudServiceProject service = new CloudServiceProject(Path.Combine(files.RootPath, serviceName), null);

                WebRoleInfo[] webRoles = null;
                if (webRole > 0)
                {
                    webRoles = new WebRoleInfo[webRole];
                    for (int i = 0; i < webRoles.Length; i++)
                    {
                        webRoles[i] = new WebRoleInfo(string.Format("{0}{1}", Resources.WebRole, i + 1), 1);
                    }
                }


                WorkerRoleInfo[] workerRoles = null;
                if (workerRole > 0)
                {
                    workerRoles = new WorkerRoleInfo[workerRole];
                    for (int i = 0; i < workerRoles.Length; i++)
                    {
                        workerRoles[i] = new WorkerRoleInfo(string.Format("{0}{1}", Resources.WorkerRole, i + 1), 1);
                    }
                }

                RoleInfo[] roles = (webRole + workerRole > 0) ? new RoleInfo[webRole + workerRole] : null;
                if (order == 0)
                {
                    for (int i = 0, w = 0, wo = 0; i < webRole + workerRole; )
                    {
                        if (w++ < webRole) roles[i++] = wrappedService.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                        if (wo++ < workerRole) roles[i++] = wrappedService.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                    }
                }
                else if (order == 1)
                {
                    for (int i = 0, w = 0, wo = 0; i < webRole + workerRole; )
                    {
                        if (wo++ < workerRole) roles[i++] = wrappedService.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                        if (w++ < webRole) roles[i++] = wrappedService.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                    }
                }
                else if (order == 2)
                {
                    wrappedService.AddRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath, webRole, workerRole);
                    webRoles.CopyTo(roles, 0);
                    Array.Copy(workerRoles, 0, roles, webRole, workerRoles.Length);
                }
                else if (order == 3)
                {
                    wrappedService.AddRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath, 0, workerRole);
                    workerRoles.CopyTo(roles, 0);
                    wrappedService.AddRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath, webRole, 0);
                    Array.Copy(webRoles, 0, roles, workerRole, webRoles.Length);
                }
                else
                {
                    throw new ArgumentException("value for order parameter is unknown");
                }

                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName, webRoles: webRoles, workerRoles: workerRoles, webScaff: Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, workerScaff: Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath, roles: roles);
            }
        }

        private void AddPHPRoleTest(int webRole, int workerRole, int order = 0)
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                AzureServiceWrapper wrappedService = new AzureServiceWrapper(files.RootPath, serviceName, null);
                CloudServiceProject service = new CloudServiceProject(Path.Combine(files.RootPath, serviceName), null);

                WebRoleInfo[] webRoles = null;
                if (webRole > 0)
                {
                    webRoles = new WebRoleInfo[webRole];
                    for (int i = 0; i < webRoles.Length; i++)
                    {
                        webRoles[i] = new WebRoleInfo(string.Format("{0}{1}", Resources.WebRole, i + 1), 1);
                    }
                }


                WorkerRoleInfo[] workerRoles = null;
                if (workerRole > 0)
                {
                    workerRoles = new WorkerRoleInfo[workerRole];
                    for (int i = 0; i < workerRoles.Length; i++)
                    {
                        workerRoles[i] = new WorkerRoleInfo(string.Format("{0}{1}", Resources.WorkerRole, i + 1), 1);
                    }
                }

                RoleInfo[] roles = (webRole + workerRole > 0) ? new RoleInfo[webRole + workerRole] : null;
                if (order == 0)
                {
                    for (int i = 0, w = 0, wo = 0; i < webRole + workerRole; )
                    {
                        if (w++ < webRole) roles[i++] = wrappedService.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                        if (wo++ < workerRole) roles[i++] = wrappedService.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                    }
                }
                else if (order == 1)
                {
                    for (int i = 0, w = 0, wo = 0; i < webRole + workerRole; )
                    {
                        if (wo++ < workerRole) roles[i++] = wrappedService.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                        if (w++ < webRole) roles[i++] = wrappedService.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                    }
                }
                else if (order == 2)
                {
                    wrappedService.AddRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath, webRole, workerRole);
                    webRoles.CopyTo(roles, 0);
                    Array.Copy(workerRoles, 0, roles, webRole, workerRoles.Length);
                }
                else if (order == 3)
                {
                    wrappedService.AddRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath, 0, workerRole);
                    workerRoles.CopyTo(roles, 0);
                    wrappedService.AddRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath, webRole, 0);
                    Array.Copy(webRoles, 0, roles, workerRole, webRoles.Length);
                }
                else
                {
                    throw new ArgumentException("value for order parameter is unknown");
                }

                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName, webRoles: webRoles, workerRoles: workerRoles, webScaff: Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, workerScaff: Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath, roles: roles);
            }
        }

        public AzureServiceTests()
        {
            AzureTool.IgnoreMissingSDKError = true;
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNew()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewEmptyParentDirectoryFail()
        {
            Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(string.Empty, serviceName, null), string.Format(Resources.InvalidOrEmptyArgumentMessage, "service parent directory"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewNullParentDirectoryFail()
        {
            Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(null, serviceName, null), string.Format(Resources.InvalidOrEmptyArgumentMessage, "service parent directory"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewInvalidParentDirectoryFail()
        {
            foreach (string invalidName in Test.Utilities.Common.Data.InvalidFileName)
            {
                Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(string.Empty, serviceName, null), string.Format(Resources.InvalidOrEmptyArgumentMessage, "service parent directory"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewDoesNotExistParentDirectoryFail()
        {
            Testing.AssertThrows<FileNotFoundException>(() => new CloudServiceProject("DoesNotExist", serviceName, null), string.Format(Resources.PathDoesNotExistForElement, Resources.ServiceParentDirectory, "DoesNotExist"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewEmptyServiceNameFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, string.Empty, null), string.Format(Resources.InvalidOrEmptyArgumentMessage, "Name"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewNullServiceNameFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, null, null), string.Format(Resources.InvalidOrEmptyArgumentMessage, "Name"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewInvalidServiceNameFail()
        {
            foreach (string invalidFileName in Test.Utilities.Common.Data.InvalidFileName)
            {
                using (FileSystemHelper files = new FileSystemHelper(this))
                {
                    Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, invalidFileName, null), string.Format(Resources.InvalidFileName, "Name"));
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewInvalidDnsServiceNameFail()
        {
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

            foreach (string invalidDnsName in Test.Utilities.Common.Data.InvalidServiceNames)
            {
                using (FileSystemHelper files = new FileSystemHelper(this))
                {
                    // This case is handled in AzureServiceCreateNewInvalidDnsServiceNameFail test
                    //
                    if (invalidFileNameChars.Any(c => invalidFileNameChars.Contains<char>(c))) continue;
                    Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, invalidDnsName, null), string.Format(Resources.InvalidDnsName, invalidDnsName, "Name"));
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceCreateNewExistingServiceFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                new CloudServiceProject(files.RootPath, serviceName, null);
                Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, serviceName, null), string.Format(Resources.ServiceAlreadyExistsOnDisk, serviceName, Path.Combine(files.RootPath, serviceName)));
            }
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureNodeServiceLoadExistingSimpleService()
        {
            AddNodeRoleTest(0, 0, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureNodeServiceLoadExistingOneWebRoleService()
        {
            AddNodeRoleTest(1, 0, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureNodeServiceLoadExistingOneWorkerRoleService()
        {
            AddNodeRoleTest(0, 1, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureNodeServiceLoadExistingMultipleWebRolesService()
        {
            AddNodeRoleTest(5, 0, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureNodeServiceLoadExistingMultipleWorkerRolesService()
        {
            AddNodeRoleTest(0, 5, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureNodeServiceLoadExistingMultipleWebAndOneWorkerRolesService()
        {
            int order = 0;
            AddNodeRoleTest(3, 4, order++);
            AddNodeRoleTest(2, 4, order++);
            AddNodeRoleTest(4, 2, order++);
            AddNodeRoleTest(3, 5, order++);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePHPServiceLoadExistingSimpleService()
        {
            AddPHPRoleTest(0, 0, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePHPServiceLoadExistingOneWebRoleService()
        {
            AddPHPRoleTest(1, 0, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePHPServiceLoadExistingOneWorkerRoleService()
        {
            AddPHPRoleTest(0, 1, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePHPServiceLoadExistingMultipleWebRolesService()
        {
            AddPHPRoleTest(5, 0, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePHPServiceLoadExistingMultipleWorkerRolesService()
        {
            AddPHPRoleTest(0, 5, 0);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzurePHPServiceLoadExistingMultipleWebAndOneWorkerRolesService()
        {
            int order = 0;
            AddPHPRoleTest(3, 4, order++);
            AddPHPRoleTest(2, 4, order++);
            AddPHPRoleTest(4, 2, order++);
            AddPHPRoleTest(3, 5, order++);
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddNewNodeWebRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                RoleInfo webRole = service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, "MyWebRole", 10);

                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName, webRoles: new WebRoleInfo[] { (WebRoleInfo)webRole }, webScaff: Path.Combine(Resources.NodeScaffolding, Resources.WebRole), roles: new RoleInfo[] { webRole });
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddNewPHPWebRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                RoleInfo webRole = service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, "MyWebRole", 10);

                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName, webRoles: new WebRoleInfo[] { (WebRoleInfo)webRole }, webScaff: Path.Combine(Resources.PHPScaffolding, Resources.WebRole), roles: new RoleInfo[] { webRole });
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddNewNodeWorkerRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                RoleInfo workerRole = service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath, "MyWorkerRole", 10);

                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName, workerRoles: new WorkerRoleInfo[] { (WorkerRoleInfo)workerRole }, workerScaff: Path.Combine(Resources.NodeScaffolding, Resources.WorkerRole), roles: new RoleInfo[] { workerRole });
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddNewPHPWorkerRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                RoleInfo workerRole = service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath, "MyWorkerRole", 10);

                AzureAssert.AzureServiceExists(Path.Combine(files.RootPath, serviceName), Resources.GeneralScaffolding, serviceName, workerRoles: new WorkerRoleInfo[] { (WorkerRoleInfo)workerRole }, workerScaff: Path.Combine(Resources.PHPScaffolding, Resources.WorkerRole), roles: new RoleInfo[] { workerRole });
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddNewNodeWorkerRoleWithWhiteCharFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, serviceName, null).AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, "\tRole"), string.Format(Resources.InvalidRoleNameMessage, "\tRole"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddNewPHPWorkerRoleWithWhiteCharFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                Testing.AssertThrows<ArgumentException>(() => new CloudServiceProject(files.RootPath, serviceName, null).AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, "\tRole"), string.Format(Resources.InvalidRoleNameMessage, "\tRole"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddExistingNodeRoleFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, "WebRole");
                Testing.AssertThrows<ArgumentException>(() => service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, "WebRole"), string.Format(Resources.AddRoleMessageRoleExists, "WebRole"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AzureServiceAddExistingPHPRoleFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, "WebRole");
                Testing.AssertThrows<ArgumentException>(() => service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, "WebRole"), string.Format(Resources.AddRoleMessageRoleExists, "WebRole"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetServiceNameTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                NewAzureServiceProjectCommand newServiceCmdlet = new NewAzureServiceProjectCommand();
                newServiceCmdlet.CommandRuntime = new MockCommandRuntime();
                newServiceCmdlet.NewAzureServiceProcess(files.RootPath, serviceName);
                Assert.Equal<string>(serviceName, new CloudServiceProject(Path.Combine(files.RootPath, serviceName), null).ServiceName);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ChangeServiceNameTest()
        {
            string newName = "NodeAppService";

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.ChangeServiceName(newName, service.Paths);
                Assert.Equal<string>(newName, service.Components.CloudConfig.serviceName);
                Assert.Equal<string>(newName, service.Components.LocalConfig.serviceName);
                Assert.Equal<string>(newName, service.Components.Definition.name);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetNodeRoleInstancesTest()
        {
            int newInstances = 10;

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath, "WebRole", 1);
                service.SetRoleInstances(service.Paths, "WebRole", newInstances);
                Assert.Equal<int>(service.Components.CloudConfig.Role[0].Instances.count, newInstances);
                Assert.Equal<int>(service.Components.LocalConfig.Role[0].Instances.count, newInstances);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetPHPRoleInstancesTest()
        {
            int newInstances = 10;

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath, "WebRole", 1);
                service.SetRoleInstances(service.Paths, "WebRole", newInstances);
                Assert.Equal<int>(service.Components.CloudConfig.Role[0].Instances.count, newInstances);
                Assert.Equal<int>(service.Components.LocalConfig.Role[0].Instances.count, newInstances);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResolveRuntimePackageUrls()
        {
            // Create a temp directory that we'll use to "publish" our service
            using (FileSystemHelper files = new FileSystemHelper(this) { EnableMonitoring = true })
            {
                // Import our default publish settings
                files.CreateAzureSdkDirectoryAndImportPublishSettings();

                // Create a new service that we're going to publish
                string serviceName = "TEST_SERVICE_NAME";

                string rootPath = files.CreateNewService(serviceName);

                // Add web and worker roles
                string defaultWebRoleName = "WebRoleDefault";
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = defaultWebRoleName, Instances = 2 };
                addNodeWebCmdlet.ExecuteCmdlet();

                string defaultWorkerRoleName = "WorkerRoleDefault";
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = defaultWorkerRoleName, Instances = 2 };
                addNodeWorkerCmdlet.ExecuteCmdlet();

                AddAzureNodeWebRoleCommand matchWebRole = addNodeWebCmdlet;
                string matchWebRoleName = "WebRoleExactMatch";
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = matchWebRoleName, Instances = 2 };
                addNodeWebCmdlet.ExecuteCmdlet();

                AddAzureNodeWorkerRoleCommand matchWorkerRole = addNodeWorkerCmdlet;
                string matchWorkerRoleName = "WorkerRoleExactMatch";
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = matchWorkerRoleName, Instances = 2 };
                addNodeWorkerCmdlet.ExecuteCmdlet();

                AddAzureNodeWebRoleCommand overrideWebRole = addNodeWebCmdlet;
                string overrideWebRoleName = "WebRoleOverride";
                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = overrideWebRoleName, Instances = 2 };
                addNodeWebCmdlet.ExecuteCmdlet();

                AddAzureNodeWorkerRoleCommand overrideWorkerRole = addNodeWorkerCmdlet;
                string overrideWorkerRoleName = "WorkerRoleOverride";
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = overrideWorkerRoleName, Instances = 2 };
                addNodeWorkerCmdlet.ExecuteCmdlet();

                string webRole2Name = "WebRole2";
                AddAzureNodeWebRoleCommand addAzureWebRole = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRole2Name };
                addAzureWebRole.ExecuteCmdlet();

                CloudServiceProject testService = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                RuntimePackageHelper.SetRoleRuntime(testService.Components.Definition, matchWebRoleName, testService.Paths, version: "0.8.2");
                RuntimePackageHelper.SetRoleRuntime(testService.Components.Definition, matchWorkerRoleName, testService.Paths, version: "0.8.2");
                RuntimePackageHelper.SetRoleRuntime(testService.Components.Definition, overrideWebRoleName, testService.Paths, overrideUrl: "http://OVERRIDE");
                RuntimePackageHelper.SetRoleRuntime(testService.Components.Definition, overrideWorkerRoleName, testService.Paths, overrideUrl: "http://OVERRIDE");

                bool exceptionWasThrownOnSettingCacheRole = false;
                try
                {
                    string cacheRuntimeVersion = "1.7.0";
                    testService.AddRoleRuntime(testService.Paths, webRole2Name, Resources.CacheRuntimeValue, cacheRuntimeVersion, RuntimePackageHelper.GetTestManifest(files));
                }
                catch (NotSupportedException)
                {
                    exceptionWasThrownOnSettingCacheRole = true;
                }
                Assert.True(exceptionWasThrownOnSettingCacheRole);
                testService.Components.Save(testService.Paths);

                // Get the publishing process started by creating the package
                testService.ResolveRuntimePackageUrls(RuntimePackageHelper.GetTestManifest(files));

                CloudServiceProject updatedService = new CloudServiceProject(testService.Paths.RootPath, null);

                RuntimePackageHelper.ValidateRoleRuntime(updatedService.Components.Definition, defaultWebRoleName, "http://cdn/node/default.exe;http://cdn/iisnode/default.exe", null);
                RuntimePackageHelper.ValidateRoleRuntime(updatedService.Components.Definition, defaultWorkerRoleName, "http://cdn/node/default.exe", null);
                RuntimePackageHelper.ValidateRoleRuntime(updatedService.Components.Definition, matchWorkerRoleName, "http://cdn/node/foo.exe", null);
                RuntimePackageHelper.ValidateRoleRuntime(updatedService.Components.Definition, matchWebRoleName, "http://cdn/node/foo.exe;http://cdn/iisnode/default.exe", null);
                RuntimePackageHelper.ValidateRoleRuntime(updatedService.Components.Definition, overrideWebRoleName, null, "http://OVERRIDE");
                RuntimePackageHelper.ValidateRoleRuntime(updatedService.Components.Definition, overrideWorkerRoleName, null, "http://OVERRIDE");
            }
        }
    }
}
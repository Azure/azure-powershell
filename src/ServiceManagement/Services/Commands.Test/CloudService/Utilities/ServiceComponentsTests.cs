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
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    public class ServiceComponentsTests : SMTestBase, IDisposable
    {
        private const string serviceName = "NodeService";

        private NewAzureServiceProjectCommand newServiceCmdlet;

        private MockCommandRuntime mockCommandRuntime;

        public ServiceComponentsTests()
        {
            mockCommandRuntime = new MockCommandRuntime();
            newServiceCmdlet = new NewAzureServiceProjectCommand();
            newServiceCmdlet.CommandRuntime = mockCommandRuntime;
        }

        public void TestCleanup()
        {
            if (Directory.Exists(serviceName))
            {                
                Directory.Delete(serviceName, true);
            }
        }

        public void Dispose()
        {
            TestCleanup();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceComponentsTest()
        {
            newServiceCmdlet.NewAzureServiceProcess(Directory.GetCurrentDirectory(), serviceName);
            ServiceComponents components = new ServiceComponents(new PowerShellProjectPathInfo(serviceName));
            AzureAssert.AreEqualServiceComponents(components);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceComponentsTestNullPathsFail()
        {
            try
            {
                ServiceComponents components = new ServiceComponents(null as CloudProjectPathInfo);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentException);
                Assert.Equal<string>(ex.Message, string.Format(Resources.NullObjectMessage, "paths"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceComponentsTestCloudConfigDoesNotExistFail()
        {
            newServiceCmdlet.NewAzureServiceProcess(Directory.GetCurrentDirectory(), serviceName);
            PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(serviceName);

            try
            {
                File.Delete(paths.CloudConfiguration);
                ServiceComponents components = new ServiceComponents(paths);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is FileNotFoundException);
                Assert.Equal<string>(ex.Message, string.Format(Resources.PathDoesNotExistForElement, Resources.ServiceConfiguration, paths.CloudConfiguration));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceComponentsTestLocalConfigDoesNotExistFail()
        {
            newServiceCmdlet.NewAzureServiceProcess(Directory.GetCurrentDirectory(), serviceName);
            PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(serviceName);

            try
            {
                File.Delete(paths.LocalConfiguration);
                ServiceComponents components = new ServiceComponents(paths);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is FileNotFoundException);
                Assert.Equal<string>(string.Format(Resources.PathDoesNotExistForElement, Resources.ServiceConfiguration, paths.LocalConfiguration), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceComponentsTestSettingsDoesNotExistFail()
        {
            newServiceCmdlet.NewAzureServiceProcess(Directory.GetCurrentDirectory(), serviceName);
            PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(serviceName);

            try
            {
                File.Delete(paths.Definition);
                ServiceComponents components = new ServiceComponents(paths);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is FileNotFoundException);
                Assert.Equal<string>(string.Format(Resources.PathDoesNotExistForElement, Resources.ServiceDefinition, paths.Definition), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceComponentsTestDefinitionDoesNotExistFail()
        {
            newServiceCmdlet.NewAzureServiceProcess(Directory.GetCurrentDirectory(), serviceName);
            PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(serviceName);

            try
            {
                File.Delete(paths.Definition);
                ServiceComponents components = new ServiceComponents(paths);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is FileNotFoundException);
                Assert.Equal<string>(string.Format(Resources.PathDoesNotExistForElement, Resources.ServiceDefinition, paths.Definition), ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortAllNull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultWebPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortNodeWorkerRoleNull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortPHPWorkerRoleNull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortNodeWebRoleNull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortPHPWebRoleNull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortNullNodeWebEndpointAndNullWorkerRole()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultWebPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                service.Components.Definition.WebRole.ToList().ForEach(wr => wr.Endpoints = null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortNullPHPWebEndpointAndNullWorkerRole()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultWebPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                service.Components.Definition.WebRole.ToList().ForEach(wr => wr.Endpoints = null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortNullNodeWebEndpointAndWorkerRole()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service.Components.Definition.WebRole.ToList().ForEach(wr => wr.Endpoints = null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortNullPHPWebEndpointAndWorkerRole()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service.Components.Definition.WebRole.ToList().ForEach(wr => wr.Endpoints = null);
                service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                service = new CloudServiceProject(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortWithEmptyPortIndpoints()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort);
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service.Components.Definition.WebRole[0].Endpoints.InputEndpoint = null;
                service.Components.Save(service.Paths);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service = new AzureServiceWrapper(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetNextPortAddingThirdEndpoint()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                int expectedPort = int.Parse(Resources.DefaultPort) + 1;
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service = new AzureServiceWrapper(service.Paths.RootPath, null);
                int nextPort = service.Components.GetNextPort();
                Assert.Equal<int>(expectedPort, nextPort);
            }
        }
    }
}
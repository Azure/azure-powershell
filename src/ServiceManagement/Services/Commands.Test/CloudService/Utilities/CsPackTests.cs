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
using System.IO.Packaging;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    internal class CsPackTests : SMTestBase
    {
        private const string serviceName = "AzureService";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateLocalPackageWithOneNodeWebRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                RoleInfo webRoleInfo = service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                string logsDir = Path.Combine(service.Paths.RootPath, webRoleInfo.Name, "server.js.logs");
                string logFile = Path.Combine(logsDir, "0.txt");
                string targetLogsFile = Path.Combine(service.Paths.LocalPackage, "roles", webRoleInfo.Name, @"approot\server.js.logs\0.txt");
                files.CreateDirectory(logsDir);
                files.CreateEmptyFile(logFile);
                service.CreatePackage(DevEnv.Local);

                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WebRole1\approot"), Path.Combine(Resources.NodeScaffolding, Resources.WebRole));
                Assert.True(File.Exists(targetLogsFile));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateLocalPackageWithOnePHPWebRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                RoleInfo webRoleInfo = service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                string logsDir = Path.Combine(service.Paths.RootPath, webRoleInfo.Name, "server.js.logs");
                string logFile = Path.Combine(logsDir, "0.txt");
                string targetLogsFile = Path.Combine(service.Paths.LocalPackage, "roles", webRoleInfo.Name, @"approot\server.js.logs\0.txt");
                files.CreateDirectory(logsDir);
                files.CreateEmptyFile(logFile);
                service.CreatePackage(DevEnv.Local);

                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WebRole1\approot"), Path.Combine(Resources.PHPScaffolding, Resources.WebRole));
                Assert.True(File.Exists(targetLogsFile));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateLocalPackageWithNodeWorkerRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service.CreatePackage(DevEnv.Local);

                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WorkerRole1\approot"), Path.Combine(Resources.NodeScaffolding, Resources.WorkerRole));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateLocalPackageWithPHPWorkerRoleTest()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                service.CreatePackage(DevEnv.Local);

                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WorkerRole1\approot"), Path.Combine(Resources.PHPScaffolding, Resources.WorkerRole));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateLocalPackageWithMultipleRoles()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service.CreatePackage(DevEnv.Local);

                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WorkerRole1\approot"), Path.Combine(Resources.NodeScaffolding, Resources.WorkerRole));
                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WebRole1\approot"), Path.Combine(Resources.NodeScaffolding, Resources.WebRole));
                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WorkerRole2\approot"), Path.Combine(Resources.PHPScaffolding, Resources.WorkerRole));
                AzureAssert.ScaffoldingExists(Path.Combine(service.Paths.LocalPackage, @"roles\WebRole2\approot"), Path.Combine(Resources.PHPScaffolding, Resources.WebRole));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CreateCloudPackageWithMultipleRoles()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service.AddWorkerRole(Test.Utilities.Common.Data.PHPWorkerRoleScaffoldingPath);
                service.AddWebRole(Test.Utilities.Common.Data.PHPWebRoleScaffoldingPath);
                service.CreatePackage(DevEnv.Cloud);

                using (Package package = Package.Open(service.Paths.CloudPackage))
                {
                    Assert.Equal(9, package.GetParts().Count());
                }
            }
        }
    }
}
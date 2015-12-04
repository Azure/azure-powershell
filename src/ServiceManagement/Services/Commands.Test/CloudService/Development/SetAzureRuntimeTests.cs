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
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Tests.Cmdlet
{
    public class SetAzureRuntimeTests : SMTestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private SetAzureServiceProjectRoleCommand cmdlet;

        private const string serviceName = "AzureService";

        public static void VerifyPackageJsonVersion(string rootPath, string roleName, string runtime, string version)
        {
            string packagePath = Path.Combine(rootPath, roleName);
            string actualVersion;
            Assert.True(JavaScriptPackageHelpers.TryGetEngineVersion(packagePath, runtime, out actualVersion));
            Assert.Equal(version, actualVersion);
        }

        public static void VerifyInvalidPackageJsonVersion(string rootPath, string roleName, string runtime, string version)
        {
            string packagePath = Path.Combine(rootPath, roleName);
            string actualVersion;
            Assert.False(JavaScriptPackageHelpers.TryGetEngineVersion(packagePath, runtime, out actualVersion));
        }

        public SetAzureRuntimeTests()
        {
            mockCommandRuntime = new MockCommandRuntime();
            cmdlet = new SetAzureServiceProjectRoleCommand();
            cmdlet.CommandRuntime = mockCommandRuntime;
            cmdlet.PassThru = true;
        }

        /// <summary>
        /// Verify that adding valid role runtimes results in valid changes in the commandlet scaffolding 
        /// (in this case, valid package.json changes).  Test for both a valid node runtiem version and 
        /// valid iisnode runtiem version
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRuntimeValidRuntimeVersions()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                string roleName = "WebRole1";
                cmdlet.PassThru = false;
                
                RoleSettings roleSettings1 = cmdlet.SetAzureRuntimesProcess(roleName, "node", "0.8.2", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                RoleSettings roleSettings2 = cmdlet.SetAzureRuntimesProcess(roleName, "iisnode", "0.1.21", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                VerifyPackageJsonVersion(service.Paths.RootPath, roleName, "node", "0.8.2");
                VerifyPackageJsonVersion(service.Paths.RootPath, roleName, "iisnode", "0.1.21");
                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
                Assert.Equal<string>(roleName, roleSettings1.name);
                Assert.Equal<string>(roleName, roleSettings2.name);
            }
        }

        /// <summary>
        /// Test that attempting to set an invlaid runtime version (one that is not listed in the runtime manifest) 
        /// results in no changes to package scaffolding (no changes in package.json)
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRuntimeInvalidRuntimeVersion()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                string roleName = "WebRole1";
                RoleSettings roleSettings1 = cmdlet.SetAzureRuntimesProcess(roleName, "node", "0.8.99", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                RoleSettings roleSettings2 = cmdlet.SetAzureRuntimesProcess(roleName, "iisnode", "0.9.99", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                VerifyInvalidPackageJsonVersion(service.Paths.RootPath, roleName, "node", "*");
                VerifyInvalidPackageJsonVersion(service.Paths.RootPath, roleName, "iisnode", "*");
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).Members[Parameters.RoleName].Value.ToString());
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[1]).Members[Parameters.RoleName].Value.ToString());
                Assert.True(((PSObject)mockCommandRuntime.OutputPipeline[0]).TypeNames.Contains(typeof(RoleSettings).FullName));
                Assert.True(((PSObject)mockCommandRuntime.OutputPipeline[1]).TypeNames.Contains(typeof(RoleSettings).FullName));
                Assert.Equal<string>(roleName, roleSettings1.name);
                Assert.Equal<string>(roleName, roleSettings2.name);
            }
        }

        /// <summary>
        /// Test that attempting to add a runtime with an invlid runtime type (a runtime type that has no entries in the 
        /// master package.json).  Results in no scaffolding changes - no changes to package.json.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRuntimeInvalidRuntimeType()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                string roleName = "WebRole1";
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                RoleSettings roleSettings1 = cmdlet.SetAzureRuntimesProcess(roleName, "noide", "0.8.99", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                RoleSettings roleSettings2 = cmdlet.SetAzureRuntimesProcess(roleName, "iisnoide", "0.9.99", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                VerifyInvalidPackageJsonVersion(service.Paths.RootPath, roleName, "node", "*");
                VerifyInvalidPackageJsonVersion(service.Paths.RootPath, roleName, "iisnode", "*");
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).Members[Parameters.RoleName].Value.ToString());
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[1]).Members[Parameters.RoleName].Value.ToString());
                Assert.True(((PSObject)mockCommandRuntime.OutputPipeline[0]).TypeNames.Contains(typeof(RoleSettings).FullName));
                Assert.True(((PSObject)mockCommandRuntime.OutputPipeline[1]).TypeNames.Contains(typeof(RoleSettings).FullName));
                Assert.Equal<string>(roleName, roleSettings1.name);
                Assert.Equal<string>(roleName, roleSettings2.name);
            }
        }

        /// <summary>
        /// Verify that adding valid role runtimes results in valid changes in the commandlet scaffolding 
        /// (in this case, valid package.json changes).  Test for both a valid node runtiem version and 
        /// valid iisnode runtiem version
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRuntimeValidRuntimeVersionsCanInsensitive()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                CloudServiceProject service = new CloudServiceProject(files.RootPath, serviceName, null);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                string roleName = "WebRole1";
                string caseInsensitiveName = "weBrolE1";
                cmdlet.PassThru = false;

                RoleSettings roleSettings1 = cmdlet.SetAzureRuntimesProcess(caseInsensitiveName, "node", "0.8.2", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                RoleSettings roleSettings2 = cmdlet.SetAzureRuntimesProcess(caseInsensitiveName, "iisnode", "0.1.21", service.Paths.RootPath, RuntimePackageHelper.GetTestManifest(files));
                VerifyPackageJsonVersion(service.Paths.RootPath, roleName, "node", "0.8.2");
                VerifyPackageJsonVersion(service.Paths.RootPath, roleName, "iisnode", "0.1.21");
                Assert.Equal<int>(0, mockCommandRuntime.OutputPipeline.Count);
                Assert.Equal<string>(roleName, roleSettings1.name);
                Assert.Equal<string>(roleName, roleSettings2.name);
            }
        }
    }
}
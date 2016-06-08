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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development
{
    /// <summary>
    /// Basic unit tests for the Enable-AzureServiceProjectRemoteDesktop enableRDCmdlet.
    /// </summary>
    internal class SaveAzureServiceProjectPackageCommandTest : SMTestBase
    {
        static private MockCommandRuntime mockCommandRuntime;

        static private SaveAzureServiceProjectPackageCommand cmdlet;

        private AddAzureNodeWebRoleCommand addNodeWebCmdlet;

        private AddAzureNodeWorkerRoleCommand addNodeWorkerCmdlet;

        public SaveAzureServiceProjectPackageCommandTest()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();

            addNodeWebCmdlet = new AddAzureNodeWebRoleCommand();
            addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand();
            cmdlet = new SaveAzureServiceProjectPackageCommand();

            addNodeWorkerCmdlet.CommandRuntime = mockCommandRuntime;
            addNodeWebCmdlet.CommandRuntime = mockCommandRuntime;
            cmdlet.CommandRuntime = mockCommandRuntime;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePackageSuccessfull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                files.CreateNewService("NEW_SERVICE");
                string rootPath = Path.Combine(files.RootPath, "NEW_SERVICE");
                string packagePath = Path.Combine(rootPath, Resources.CloudPackageFileName);

                CloudServiceProject service = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);

                cmdlet.ExecuteCmdlet();

                PSObject obj = mockCommandRuntime.OutputPipeline[0] as PSObject;
                Assert.Equal<string>(string.Format(Resources.PackageCreated, packagePath), mockCommandRuntime.VerboseStream[0]);
                Assert.Equal<string>(packagePath, obj.GetVariableValue<string>(Parameters.PackagePath));
                Assert.True(File.Exists(packagePath));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePackageWithEmptyServiceSuccessfull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                files.CreateNewService("NEW_SERVICE");
                string rootPath = Path.Combine(files.RootPath, "NEW_SERVICE");
                string packagePath = Path.Combine(rootPath, Resources.CloudPackageFileName);

                cmdlet.ExecuteCmdlet();

                PSObject obj = mockCommandRuntime.OutputPipeline[0] as PSObject;
                Assert.Equal<string>(string.Format(Resources.PackageCreated, packagePath), mockCommandRuntime.VerboseStream[0]);
                Assert.Equal<string>(packagePath, obj.GetVariableValue<string>(Parameters.PackagePath));
                Assert.True(File.Exists(packagePath));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePackageWithMultipleRolesSuccessfull()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                files.CreateAzureSdkDirectoryAndImportPublishSettings();
                files.CreateNewService("NEW_SERVICE");
                string rootPath = Path.Combine(files.RootPath, "NEW_SERVICE");
                string packagePath = Path.Combine(rootPath, Resources.CloudPackageFileName);

                CloudServiceProject service = new CloudServiceProject(rootPath, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service.AddWorkerRole(Test.Utilities.Common.Data.NodeWorkerRoleScaffoldingPath);
                service.AddWebRole(Test.Utilities.Common.Data.NodeWebRoleScaffoldingPath);

                cmdlet.ExecuteCmdlet();

                PSObject obj = mockCommandRuntime.OutputPipeline[0] as PSObject;
                Assert.Equal<string>(string.Format(Resources.PackageCreated, packagePath), mockCommandRuntime.VerboseStream[0]);
                Assert.Equal<string>(packagePath, obj.GetVariableValue<string>(Parameters.PackagePath));
                Assert.True(File.Exists(packagePath));
            }
        }
    }
}

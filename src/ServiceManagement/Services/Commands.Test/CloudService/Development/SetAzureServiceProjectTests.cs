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
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Tests.Cmdlet
{
    public class SetAzureServiceProjectTests : SMTestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private SetAzureServiceProjectCommand setServiceProjectCmdlet;

        public SetAzureServiceProjectTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();

            setServiceProjectCmdlet = new SetAzureServiceProjectCommand();
            setServiceProjectCmdlet.CommandRuntime = mockCommandRuntime;
            setServiceProjectCmdlet.PassThru = true;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsLocationValid()
        {
            string[] locations = { "West US", "East US", "East Asia", "North Europe" };
            foreach (string item in locations)
            {
                using (FileSystemHelper files = new FileSystemHelper(this))
                {
                    // Create new empty settings file
                    //
                    PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                    ServiceSettings settings = new ServiceSettings();
                    mockCommandRuntime = new MockCommandRuntime();
                    setServiceProjectCmdlet.CommandRuntime = mockCommandRuntime;
                    settings.Save(paths.Settings);

                    settings = setServiceProjectCmdlet.SetAzureServiceProjectProcess(item, null, null, paths.Settings);

                    // Assert location is changed
                    //
                    Assert.Equal<string>(item, settings.Location);
                    ServiceSettings actualOutput = mockCommandRuntime.OutputPipeline[0] as ServiceSettings;
                    Assert.Equal<string>(item, settings.Location);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsLocationEmptyFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                // Create new empty settings file
                //
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                ServiceSettings settings = new ServiceSettings();
                settings.Save(paths.Settings);

                Testing.AssertThrows<ArgumentException>(() => setServiceProjectCmdlet.SetAzureServiceProjectProcess(string.Empty, null, null, paths.Settings), string.Format(Resources.InvalidOrEmptyArgumentMessage, "Location"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsUnknownLocation()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                // Create new empty settings file
                //
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                ServiceSettings settings = new ServiceSettings();
                settings.Save(paths.Settings);
                string unknownLocation = "Unknown Location";

                settings = setServiceProjectCmdlet.SetAzureServiceProjectProcess(unknownLocation, null, null, paths.Settings);

                // Assert location is changed
                //
                Assert.Equal<string>(unknownLocation, settings.Location);
                ServiceSettings actualOutput = mockCommandRuntime.OutputPipeline[0] as ServiceSettings;
                Assert.Equal<string>(unknownLocation, settings.Location);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsStorageTests()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                // Create new empty settings file
                //
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                ServiceSettings settings = new ServiceSettings();
                mockCommandRuntime = new MockCommandRuntime();
                setServiceProjectCmdlet.CommandRuntime = mockCommandRuntime;
                settings.Save(paths.Settings);

                settings = setServiceProjectCmdlet.SetAzureServiceProjectProcess(null, null, "companystore", paths.Settings);

                // Assert storageAccountName is changed
                //
                Assert.Equal<string>("companystore", settings.StorageServiceName);
                ServiceSettings actualOutput = mockCommandRuntime.OutputPipeline[0] as ServiceSettings;
                Assert.Equal<string>("companystore", settings.StorageServiceName);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsStorageTestsEmptyFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                // Create new empty settings file
                //
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                ServiceSettings settings = new ServiceSettings();
                settings.Save(paths.Settings);

                Testing.AssertThrows<ArgumentException>(() => setServiceProjectCmdlet.SetAzureServiceProjectProcess(null, null, string.Empty, paths.Settings), string.Format(Resources.InvalidOrEmptyArgumentMessage, "StorageAccountName"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsSlotTests()
        {
            string[] slots = { DeploymentSlotType.Production, DeploymentSlotType.Staging };
            foreach (string item in slots)
            {
                using (FileSystemHelper files = new FileSystemHelper(this))
                {
                    // Create new empty settings file
                    //
                    PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                    ServiceSettings settings = new ServiceSettings();
                    settings.Save(paths.Settings);

                    setServiceProjectCmdlet.SetAzureServiceProjectProcess(null, item, null, paths.Settings);

                    // Assert slot is changed
                    //
                    settings = ServiceSettings.Load(paths.Settings);
                    Assert.Equal<string>(item, settings.Slot);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsSlotTestsEmptyFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                // Create new empty settings file
                //
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                ServiceSettings settings = new ServiceSettings();
                settings.Save(paths.Settings);

                Testing.AssertThrows<ArgumentException>(() => setServiceProjectCmdlet.SetAzureServiceProjectProcess(null, string.Empty, null, paths.Settings), string.Format(Resources.InvalidOrEmptyArgumentMessage, "Slot"));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureServiceProjectTestsSlotTestsInvalidFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                // Create new empty settings file
                //
                PowerShellProjectPathInfo paths = new PowerShellProjectPathInfo(files.RootPath);
                ServiceSettings settings = new ServiceSettings();
                settings.Save(paths.Settings);

                Testing.AssertThrows<ArgumentException>(() => setServiceProjectCmdlet.SetAzureServiceProjectProcess(null, "MyHome", null, paths.Settings), string.Format(Resources.InvalidServiceSettingElement, "Slot"));
            }
        }
    }
}

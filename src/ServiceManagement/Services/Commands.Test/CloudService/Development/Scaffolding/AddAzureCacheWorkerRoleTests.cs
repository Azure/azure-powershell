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
using Xunit;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Scaffolding
{
    using ConfigConfigurationSetting = Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema.ConfigurationSetting;
    using Microsoft.WindowsAzure.Commands.Common;

    
    public class AddAzureCacheWorkerRoleTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private NewAzureServiceProjectCommand newServiceCmdlet;

        private AddAzureCacheWorkerRoleCommand addCacheRoleCmdlet;

        public AddAzureCacheWorkerRoleTests()
        {
            AzureTool.IgnoreMissingSDKError = true;
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();

            newServiceCmdlet = new NewAzureServiceProjectCommand();
            addCacheRoleCmdlet = new AddAzureCacheWorkerRoleCommand();

            newServiceCmdlet.CommandRuntime = mockCommandRuntime;
            addCacheRoleCmdlet.CommandRuntime = mockCommandRuntime;
        }

        [Fact]
        public void AddNewCacheWorkerRoleSuccessful()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string rootPath = Path.Combine(files.RootPath, "AzureService");
                string roleName = "WorkerRole";
                int expectedInstanceCount = 10;
                newServiceCmdlet.NewAzureServiceProcess(files.RootPath, "AzureService");
                WorkerRole cacheWorkerRole = addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(roleName, expectedInstanceCount, rootPath);

                AzureAssert.ScaffoldingExists(Path.Combine(files.RootPath, "AzureService", "WorkerRole"), Path.Combine(Resources.GeneralScaffolding, Resources.WorkerRole));

                AzureAssert.WorkerRoleImportsExists(new Import { moduleName = Resources.CachingModuleName }, cacheWorkerRole);

                AzureAssert.LocalResourcesLocalStoreExists(new LocalStore { name = Resources.CacheDiagnosticStoreName, cleanOnRoleRecycle = false }, 
                    cacheWorkerRole.LocalResources);

                Assert.Null(cacheWorkerRole.Endpoints.InputEndpoint);

                AssertConfigExists(AzureAssert.GetCloudRole(rootPath, roleName));
                AssertConfigExists(AzureAssert.GetLocalRole(rootPath, roleName), Resources.EmulatorConnectionString);

                PSObject actualOutput = mockCommandRuntime.OutputPipeline[1] as PSObject;
                Assert.Equal<string>(roleName, actualOutput.Members[Parameters.CacheWorkerRoleName].Value.ToString());
                Assert.Equal<int>(expectedInstanceCount, int.Parse(actualOutput.Members[Parameters.Instances].Value.ToString()));
            }
        }

        private static void AssertConfigExists(RoleSettings role, string connectionString = "")
        {
            AzureAssert.ConfigurationSettingExist(new ConfigConfigurationSetting { name = Resources.NamedCacheSettingName, value = Resources.NamedCacheSettingValue }, role.ConfigurationSettings);
            AzureAssert.ConfigurationSettingExist(new ConfigConfigurationSetting { name = Resources.DiagnosticLevelName, value = Resources.DiagnosticLevelValue }, role.ConfigurationSettings);
            AzureAssert.ConfigurationSettingExist(new ConfigConfigurationSetting { name = Resources.CachingCacheSizePercentageSettingName, value = string.Empty }, role.ConfigurationSettings);
            AzureAssert.ConfigurationSettingExist(new ConfigConfigurationSetting { name = Resources.CachingConfigStoreConnectionStringSettingName, value = connectionString }, role.ConfigurationSettings);
        }

        [Fact]
        public void AddNewCacheWorkerRoleWithInvalidNamesFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string rootPath = Path.Combine(files.RootPath, "AzureService");
                newServiceCmdlet.NewAzureServiceProcess(files.RootPath, "AzureService");

                foreach (string invalidName in Test.Utilities.Common.Data.InvalidRoleNames)
                {
                    Testing.AssertThrows<ArgumentException>(() => addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(invalidName, 1, rootPath));
                }
            }
        }

        [Fact]
        public void AddNewCacheWorkerRoleDoesNotHaveAnyRuntime()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string rootPath = Path.Combine(files.RootPath, "AzureService");
                string roleName = "WorkerRole";
                int expectedInstanceCount = 10;
                newServiceCmdlet.NewAzureServiceProcess(files.RootPath, "AzureService");
                
                WorkerRole cacheWorkerRole = addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(roleName, expectedInstanceCount, rootPath);

                Variable runtimeId = Array.Find<Variable>(cacheWorkerRole.Startup.Task[0].Environment, v => v.name.Equals(Resources.RuntimeTypeKey));
                Assert.Equal<string>(string.Empty, runtimeId.value);
            }
        }
    }
}

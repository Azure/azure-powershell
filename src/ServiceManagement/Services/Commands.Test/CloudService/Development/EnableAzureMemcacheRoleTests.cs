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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.CloudService.Development;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Tests
{
    using ConfigConfigurationSetting = Commands.Utilities.Common.XmlSchema.ServiceConfigurationSchema.ConfigurationSetting;
    using DefinitionConfigurationSetting = Commands.Utilities.Common.XmlSchema.ServiceDefinitionSchema.ConfigurationSetting;
    using TestResources = Commands.Common.Test.Properties.Resources;
    using Microsoft.Azure.Common.Authentication;

    public class EnableAzureMemcacheRoleTests : TestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private AddAzureNodeWebRoleCommand addNodeWebCmdlet;

        private AddAzureNodeWorkerRoleCommand addNodeWorkerCmdlet;

        private AddAzureCacheWorkerRoleCommand addCacheRoleCmdlet;

        private EnableAzureMemcacheRoleCommand enableCacheCmdlet;
        
        public EnableAzureMemcacheRoleTests()
        {
            AzureTool.IgnoreMissingSDKError = true;
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();

            enableCacheCmdlet = new EnableAzureMemcacheRoleCommand();
            addCacheRoleCmdlet = new AddAzureCacheWorkerRoleCommand();
            addCacheRoleCmdlet.CommandRuntime = mockCommandRuntime;
            enableCacheCmdlet.CommandRuntime = mockCommandRuntime;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcess()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string webRoleName = "WebRole";
                string expectedMessage = string.Format(Resources.EnableMemcacheMessage, webRoleName, cacheRoleName, Resources.MemcacheEndpointPort);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                mockCommandRuntime.ResetPipelines();
                enableCacheCmdlet.PassThru = true;
                enableCacheCmdlet.CacheRuntimeVersion = "2.5.0";
                enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath);

                AssertCachingEnabled(files, serviceName, rootPath, webRoleName, expectedMessage);
            }
        }

        /// <summary>
        /// Verify that enabling cache on worker role will pass.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessOnWorkerRoleSuccess()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "CacheWorkerRole";
                string workerRoleName = "WorkerRole";
                string expectedMessage = string.Format(Resources.EnableMemcacheMessage, workerRoleName, cacheRoleName, Resources.MemcacheEndpointPort);

                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = workerRoleName };
                addNodeWorkerCmdlet.ExecuteCmdlet();
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                mockCommandRuntime.ResetPipelines();
                enableCacheCmdlet.PassThru = true;
                enableCacheCmdlet.EnableAzureMemcacheRoleProcess(workerRoleName, cacheRoleName, rootPath);

                WorkerRole workerRole = AzureAssert.GetWorkerRole(rootPath, workerRoleName);

                AzureAssert.RuntimeUrlAndIdExists(workerRole.Startup.Task, Resources.CacheRuntimeValue);

                AzureAssert.ScaffoldingExists(Path.Combine(files.RootPath, serviceName, workerRoleName), Path.Combine(Resources.CacheScaffolding, Resources.WorkerRole));
                AzureAssert.StartupTaskExists(workerRole.Startup.Task, Resources.CacheStartupCommand);

                AzureAssert.InternalEndpointExists(workerRole.Endpoints.InternalEndpoint,
                    new InternalEndpoint { name = Resources.MemcacheEndpointName, protocol = InternalProtocol.tcp, port = Resources.MemcacheEndpointPort });

                LocalStore localStore = new LocalStore
                {
                    name = Resources.CacheDiagnosticStoreName,
                    cleanOnRoleRecycle = false
                };

                AzureAssert.LocalResourcesLocalStoreExists(localStore, workerRole.LocalResources);

                DefinitionConfigurationSetting diagnosticLevel = new DefinitionConfigurationSetting { name = Resources.CacheClientDiagnosticLevelAssemblyName };
                AzureAssert.ConfigurationSettingExist(diagnosticLevel, workerRole.ConfigurationSettings);

                ConfigConfigurationSetting clientDiagnosticLevel = new ConfigConfigurationSetting { name = Resources.ClientDiagnosticLevelName, value = Resources.ClientDiagnosticLevelValue };
                AzureAssert.ConfigurationSettingExist(clientDiagnosticLevel, AzureAssert.GetCloudRole(rootPath, workerRoleName).ConfigurationSettings);
                AzureAssert.ConfigurationSettingExist(clientDiagnosticLevel, AzureAssert.GetLocalRole(rootPath, workerRoleName).ConfigurationSettings);

                string workerConfigPath = string.Format(@"{0}\{1}\{2}", rootPath, workerRoleName, "web.config");
                string workerCloudConfig = File.ReadAllText(workerConfigPath);
                Assert.True(workerCloudConfig.Contains("configSections"));
                Assert.True(workerCloudConfig.Contains("dataCacheClients"));

                Assert.Equal<string>(expectedMessage, mockCommandRuntime.VerboseStream[0]);
                Assert.Equal<string>(workerRoleName, (mockCommandRuntime.OutputPipeline[0] as PSObject).GetVariableValue<string>(Parameters.RoleName));
            }
        }

        /// <summary>
        /// Verify that enabling cache with non-existing cache worker role will fail.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessCacheRoleDoesNotExistFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string webRoleName = "WebRole";
                string expected = string.Format(Resources.RoleNotFoundMessage, cacheRoleName);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath));
            }
        }

        /// <summary>
        /// Verify that enabling cache with non-existing role to enable on will fail.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessRoleDoesNotExistFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string webRoleName = "WebRole";
                string expected = string.Format(Resources.RoleNotFoundMessage, webRoleName);

                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath));
            }
        }

        /// <summary>
        /// Verify that enabling cache using same cache worker role on role with cache will fail.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessAlreadyEnabledFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string webRoleName = "WebRole";
                string expected = string.Format(Resources.CacheAlreadyEnabledMessage, webRoleName);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath);

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath));
            }
        }

        /// <summary>
        /// Verify that enabling cache using different cache worker role on role with cache will fail.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessAlreadyEnabledNewCacheRoleFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string newCacheRoleName = "NewCacheWorkerRole";
                string webRoleName = "WebRole";
                string expected = string.Format(Resources.CacheAlreadyEnabledMessage, webRoleName);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath);
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(newCacheRoleName, 1, rootPath);

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, cacheRoleName, rootPath));
            }
        }

        /// <summary>
        /// Verify that enabling cache using non-cache worker role will fail.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessUsingNonCacheWorkerRole()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string workerRoleName = "WorkerRole";
                string webRoleName = "WebRole";
                string expected = string.Format(Resources.NotCacheWorkerRole, workerRoleName);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = workerRoleName };
                addNodeWorkerCmdlet.ExecuteCmdlet();

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, workerRoleName, rootPath));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessWithDefaultRoleName()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string originalDirectory = Directory.GetCurrentDirectory();
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string webRoleName = "WebRole";
                string cacheRoleName = "WorkerRole";
                string expectedMessage = string.Format(Resources.EnableMemcacheMessage, webRoleName, cacheRoleName, Resources.MemcacheEndpointPort);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                Directory.SetCurrentDirectory(Path.Combine(rootPath, webRoleName));
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                mockCommandRuntime.ResetPipelines();
                enableCacheCmdlet.PassThru = true;
                enableCacheCmdlet.CacheRuntimeVersion = "2.5.0";
                enableCacheCmdlet.RoleName = string.Empty;
                enableCacheCmdlet.CacheWorkerRoleName = cacheRoleName;
                enableCacheCmdlet.ExecuteCmdlet();

                AssertCachingEnabled(files, serviceName, rootPath, webRoleName, expectedMessage);
                Directory.SetCurrentDirectory(originalDirectory);
            }
        }

        private void AssertCachingEnabled(
            FileSystemHelper files,
            string serviceName,
            string rootPath,
            string webRoleName,
            string expectedMessage)
        {
            WebRole webRole = AzureAssert.GetWebRole(rootPath, webRoleName);
            RoleSettings roleSettings = AzureAssert.GetCloudRole(rootPath, webRoleName);

            AzureAssert.RuntimeUrlAndIdExists(webRole.Startup.Task, Resources.CacheRuntimeValue);

            Assert.Equal<string>(Resources.CacheRuntimeVersionKey, webRole.Startup.Task[0].Environment[0].name);
            Assert.Equal<string>(enableCacheCmdlet.CacheRuntimeVersion, webRole.Startup.Task[0].Environment[0].value);
            
            Assert.Equal<string>(Resources.EmulatedKey, webRole.Startup.Task[2].Environment[0].name);
            Assert.Equal<string>("/RoleEnvironment/Deployment/@emulated", webRole.Startup.Task[2].Environment[0].RoleInstanceValue.xpath);
            
            Assert.Equal<string>(Resources.CacheRuntimeUrl, webRole.Startup.Task[2].Environment[1].name);
            Assert.Equal<string>(TestResources.CacheRuntimeUrl, webRole.Startup.Task[2].Environment[1].value);
            Assert.Equal(1, webRole.Startup.Task.Count(t => t.commandLine.Equals(Resources.CacheStartupCommand)));
            

            AzureAssert.ScaffoldingExists(Path.Combine(files.RootPath, serviceName, webRoleName), Path.Combine(Resources.CacheScaffolding, Resources.WebRole));
            AzureAssert.StartupTaskExists(webRole.Startup.Task, Resources.CacheStartupCommand);

            AzureAssert.InternalEndpointExists(webRole.Endpoints.InternalEndpoint,
                new InternalEndpoint { name = Resources.MemcacheEndpointName, protocol = InternalProtocol.tcp, port = Resources.MemcacheEndpointPort });

            LocalStore localStore = new LocalStore
            {
                name = Resources.CacheDiagnosticStoreName,
                cleanOnRoleRecycle = false
            };

            AzureAssert.LocalResourcesLocalStoreExists(localStore, webRole.LocalResources);

            DefinitionConfigurationSetting diagnosticLevel = new DefinitionConfigurationSetting { name = Resources.CacheClientDiagnosticLevelAssemblyName };
            AzureAssert.ConfigurationSettingExist(diagnosticLevel, webRole.ConfigurationSettings);

            ConfigConfigurationSetting clientDiagnosticLevel = new ConfigConfigurationSetting { name = Resources.ClientDiagnosticLevelName, value = Resources.ClientDiagnosticLevelValue };
            AzureAssert.ConfigurationSettingExist(clientDiagnosticLevel, roleSettings.ConfigurationSettings);

            AssertWebConfig(string.Format(@"{0}\{1}\{2}", rootPath, webRoleName, Resources.WebCloudConfig));
            AssertWebConfig(string.Format(@"{0}\{1}\{2}", rootPath, webRoleName, Resources.WebConfigTemplateFileName));

            Assert.Equal<string>(expectedMessage, mockCommandRuntime.VerboseStream[0]);
            Assert.Equal<string>(webRoleName, (mockCommandRuntime.OutputPipeline[0] as PSObject).GetVariableValue<string>(Parameters.RoleName));
        }

        private static void AssertWebConfig(string webCloudConfigPath)
        {
            string webCloudCloudConfigContents = FileUtilities.DataStore.ReadFileAsText(webCloudConfigPath);
            Assert.True(webCloudCloudConfigContents.Contains("configSections"));
            Assert.True(webCloudCloudConfigContents.Contains("dataCacheClients"));
        }

        /// <summary>
        /// Verify that enabling cache with non-existing cache worker role will fail.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheRoleProcessOnCacheWorkerRoleFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string expected = string.Format(Resources.InvalidCacheRoleName, cacheRoleName);

                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(cacheRoleName, cacheRoleName, rootPath));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheWithoutCacheWorkerRoleName()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "WorkerRole";
                string webRoleName = "WebRole";
                string expectedMessage = string.Format(Resources.EnableMemcacheMessage, webRoleName, cacheRoleName, Resources.MemcacheEndpointPort);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                mockCommandRuntime.ResetPipelines();
                enableCacheCmdlet.PassThru = true;
                enableCacheCmdlet.CacheRuntimeVersion = "2.5.0";
                enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, null, rootPath);

                AssertCachingEnabled(files, serviceName, rootPath, webRoleName, expectedMessage);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheWithoutCacheWorkerRoleNameAndServiceHasMultipleWorkerRoles()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string cacheRoleName = "CacheWorkerRole";
                string webRoleName = "WebRole";
                string expectedMessage = string.Format(Resources.EnableMemcacheMessage, webRoleName, cacheRoleName, Resources.MemcacheEndpointPort);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WorkerRole" };
                addNodeWorkerCmdlet.ExecuteCmdlet();
                addCacheRoleCmdlet.AddAzureCacheWorkerRoleProcess(cacheRoleName, 1, rootPath);
                mockCommandRuntime.ResetPipelines();
                enableCacheCmdlet.PassThru = true;
                enableCacheCmdlet.CacheRuntimeVersion = "2.5.0";
                enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, null, rootPath);

                AssertCachingEnabled(files, serviceName, rootPath, webRoleName, expectedMessage);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAzureMemcacheWithNoCacheWorkerRolesFail()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string webRoleName = "WebRole";
                string expectedMessage = string.Format(Resources.NoCacheWorkerRoles);

                addNodeWebCmdlet = new AddAzureNodeWebRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = webRoleName };
                addNodeWebCmdlet.ExecuteCmdlet();
                addNodeWorkerCmdlet = new AddAzureNodeWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = "WorkerRole" };
                addNodeWorkerCmdlet.ExecuteCmdlet();
                mockCommandRuntime.ResetPipelines();
                enableCacheCmdlet.PassThru = true;
                enableCacheCmdlet.CacheRuntimeVersion = "2.5.0";

                Testing.AssertThrows<Exception>(() => enableCacheCmdlet.EnableAzureMemcacheRoleProcess(webRoleName, null, rootPath), expectedMessage);
            }
        }
    }
}

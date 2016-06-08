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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class PublishContextTests : SMTestBase, IDisposable
    {
        private static AzureServiceWrapper service;

        private static string packagePath;

        private static string configPath;

        private static ServiceSettings settings;

        private string rootPath = "serviceRootPath";

        /// <summary>
        /// When running this test double check that the certificate used in Azure.PublishSettings has not expired.
        /// </summary>
        public PublishContextTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            service = new AzureServiceWrapper(Directory.GetCurrentDirectory(), Path.GetRandomFileName(), null);
            service.CreateVirtualCloudPackage();
            packagePath = service.Paths.CloudPackage;
            configPath = service.Paths.CloudConfiguration;
            settings = ServiceSettingsTestData.Instance.Data[ServiceSettingsState.Default];
            AzureSession.DataStore = new MemoryDataStore();
            ProfileClient client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            AzureSession.DataStore.WriteFile(Test.Utilities.Common.Data.ValidPublishSettings.First(),
                File.ReadAllText(Test.Utilities.Common.Data.ValidPublishSettings.First()));
            client.ImportPublishSettings(Test.Utilities.Common.Data.ValidPublishSettings.First(), null);
            client.Profile.Save();
        }

        public void TestCleanup()
        {
            AzureSession.DataStore = new MemoryDataStore();
            if (Directory.Exists(Test.Utilities.Common.Data.AzureSdkAppDir))
            {
                new RemoveAzurePublishSettingsCommand().RemovePublishSettingsProcess(Test.Utilities.Common.Data.AzureSdkAppDir);
            }
        }

        #region settings

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestWithDefaultServiceSettings()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            settings.Subscription = "TestSubscription2";
            PublishContext deploySettings = new PublishContext(
                settings,
                packagePath,
                configPath,
                label,
                deploymentName,
                rootPath);

            AzureAssert.AreEqualPublishContext(settings, configPath, deploymentName, label, packagePath, "f62b1e05-af8f-4205-8f98-325079adc155", deploySettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestWithFullServiceSettings()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            ServiceSettings fullSettings = ServiceSettingsTestData.Instance.Data[ServiceSettingsState.Sample1];
            PublishContext deploySettings = new PublishContext(
                fullSettings,
                packagePath,
                configPath,
                label,
                deploymentName,
                rootPath);

            AzureAssert.AreEqualPublishContext(
                fullSettings,
                configPath,
                deploymentName,
                label,
                packagePath,
                "f62b1e05-af8f-4205-8f98-325079adc155",
                deploySettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestNullSettingsFail()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;

            try
            {
                PublishContext deploySettings = new PublishContext(
                    null,
                    packagePath,
                    configPath,
                    label,
                    deploymentName,
                    rootPath);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentException);
                Assert.Equal<string>(Resources.InvalidServiceSettingMessage, ex.Message);
            }
        }

        #endregion

        #region packagePath

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestEmptyPackagePathFail()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            string expectedMessage = string.Format(Resources.InvalidOrEmptyArgumentMessage, "packagePath");

            Testing.AssertThrows<ArgumentException>(() => new PublishContext(
                settings,
                string.Empty,
                configPath,
                label,
                deploymentName,
                rootPath), expectedMessage);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestNullPackagePathFail()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            string expectedMessage = string.Format(Resources.InvalidOrEmptyArgumentMessage, "packagePath");

            Testing.AssertThrows<ArgumentException>(() => new PublishContext(
                settings,
                null,
                configPath,
                label,
                deploymentName,
                rootPath), expectedMessage);
        }

        #endregion

        #region configPath

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestEmptyConfigPathFail()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            string expectedMessage = string.Format(Resources.InvalidOrEmptyArgumentMessage, Resources.ServiceConfiguration);

            Testing.AssertThrows<ArgumentException>(() => new PublishContext(
                settings,
                packagePath,
                string.Empty,
                label,
                deploymentName,
                rootPath), expectedMessage);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestNullConfigPathFail()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            string expectedMessage = string.Format(Resources.InvalidOrEmptyArgumentMessage, Resources.ServiceConfiguration);

            Testing.AssertThrows<ArgumentException>(() => new PublishContext(
                settings,
                packagePath,
                null,
                label,
                deploymentName,
                rootPath), expectedMessage);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestDoesNotConfigPathFail()
        {
            string label = "MyLabel";
            string deploymentName = service.ServiceName;
            string doesNotExistDir = Path.Combine(Directory.GetCurrentDirectory(), "qewindw443298.cscfg");

            try
            {
                PublishContext deploySettings = new PublishContext(
                    settings,
                    packagePath,
                    doesNotExistDir,
                    label,
                    deploymentName,
                    rootPath);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is FileNotFoundException);
                Assert.Equal<string>(string.Format(Resources.PathDoesNotExistForElement, Resources.ServiceConfiguration, doesNotExistDir), ex.Message);
            }
        }

        #endregion

        #region label

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeploymentSettingsTestNullLabelFail()
        {
            string deploymentName = service.ServiceName;

            try
            {
                PublishContext deploySettings = new PublishContext(
                    settings,
                    packagePath,
                    configPath,
                    null,
                    deploymentName,
                    rootPath);
                Assert.True(false, "No exception was thrown");
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentException);
                Assert.True(string.Compare(
                    string.Format(Resources.InvalidOrEmptyArgumentMessage,
                    "serviceName"), ex.Message, true) == 0);
            }
        }

        #endregion

        public void Dispose()
        {
            TestCleanup();
        }
    }
}
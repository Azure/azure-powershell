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
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class AzureServiceExtensionTests : ServiceManagementTest
    {
        private string _serviceName;
        private string _packageName;
        private string _configName;
        private FileInfo _packagePath;
        private FileInfo _configPath;

        const string DeploymentName = "deployment1";
        const string DeploymentLabel = "label1";

        private string _extensionName;
        private string _providerNamespace;
        private string _version;
        private const string PublicConfig = "<PublicConfig><UserName>pstestuser</UserName><Expiration>2015-01-30</Expiration></PublicConfig>";
        private const string PrivateConfig = "<PrivateConfig><Password>p@ssw0rd</Password></PrivateConfig>";

        [TestInitialize]
        public void Initialize()
        {
            // Choose the package and config files from local machine
            _packageName = Convert.ToString(TestContext.DataRow["upgradePackage"]);
            _configName = Convert.ToString(TestContext.DataRow["upgradeConfig"]);
            _packagePath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + _packageName);
            _configPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + _configName);

            Assert.IsTrue(File.Exists(_packagePath.FullName), "VHD file not exist={0}", _packagePath);
            Assert.IsTrue(File.Exists(_configPath.FullName), "VHD file not exist={0}", _configPath);

            _serviceName = Utilities.GetUniqueShortName(serviceNamePrefix);

            pass = false;
            testStartTime = DateTime.Now;
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Get-AzureServiceAvailableExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void GetAzureServiceAvailableExtensionTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                Collection<ExtensionImageContext> resultExtensions = vmPowershellCmdlets.GetAzureServiceAvailableExtension();

                foreach (var extension in resultExtensions)
                {
                    Utilities.PrintContext(extension);
                }

                _extensionName = resultExtensions[0].ExtensionName;
                _providerNamespace = resultExtensions[0].ProviderNameSpace;

                resultExtensions = vmPowershellCmdlets.GetAzureServiceAvailableExtension(
                    extensionName: _extensionName,
                    providerNamespace: _providerNamespace,
                    allVersion: true);

                foreach (var extension in resultExtensions)
                {
                    Utilities.PrintContext(extension);
                }

                string ver = resultExtensions[0].Version;

                resultExtensions = vmPowershellCmdlets.GetAzureServiceAvailableExtension(
                    extensionName: _extensionName,
                    providerNamespace: _providerNamespace,
                    version: ver);

                Utilities.PrintContext(resultExtensions[0]);

                pass = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (New-AzureServiceExtensionConfig)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceExtensionConfigScenarioTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            const string rdpPath = @".\WebRole1.rdp";

            try
            {
                Collection<ExtensionImageContext> resultExtensions = vmPowershellCmdlets.GetAzureServiceAvailableExtension();

                foreach (var extension in resultExtensions)
                {
                    if (extension.ExtensionName == "RDP")
                    {
                        _extensionName = extension.ExtensionName;
                        _providerNamespace = extension.ProviderNameSpace;
                        _version = extension.Version;
                        break;
                    }
                }

                vmPowershellCmdlets.NewAzureService(_serviceName, _serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", _serviceName);

                ExtensionConfigurationInput config = vmPowershellCmdlets.NewAzureServiceExtensionConfig(
                    extensionName: _extensionName,
                    providerNamespace: _providerNamespace,
                    publicConfig: PublicConfig,
                    privateConfig: PrivateConfig,
                    version: _version
                    );

                vmPowershellCmdlets.NewAzureDeployment(_serviceName, _packagePath.FullName, _configPath.FullName,
                    DeploymentSlotType.Production, DeploymentLabel, DeploymentName, false, false, config);

                DeploymentInfoContext result = vmPowershellCmdlets.GetAzureDeployment(_serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, _serviceName, DeploymentName, DeploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");
                var extId = result.ExtensionConfiguration.AllRoles[0].Id;

                ExtensionContext resultExtensionContext = vmPowershellCmdlets.GetAzureServiceExtension(_serviceName)[0];

                Utilities.PrintContext(resultExtensionContext);

                VerifyExtensionContext(resultExtensionContext, "AllRoles", _extensionName, _providerNamespace, _version);

                RemoteDesktopExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceRemoteDesktopExtension(_serviceName)[0];

                Utilities.PrintContext(resultContext);

                VerifyRDP(_serviceName, rdpPath);

                ExtensionConfigurationInput extConfig = vmPowershellCmdlets.NewAzureServiceExtensionConfig(extId, "Uninstall");

                try
                {
                    vmPowershellCmdlets.SetAzureDeploymentConfig(_serviceName, DeploymentSlotType.Production,
                    _configPath.FullName, extConfig);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("BadRequest")
                        || ((e.InnerException != null) && (e.InnerException.ToString().Contains("BadRequest"))))
                    {
                        Console.WriteLine(e.ToString());
                    }
                    else
                    {
                        throw;
                    }
                }

                vmPowershellCmdlets.RemoveAzureServiceExtension(
                    serviceName: _serviceName,
                    extensionName: _extensionName,
                    providerNamespace: _providerNamespace);

                try
                {
                    vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", _serviceName, rdpPath, false);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    Console.WriteLine("Failed to get RDP file as expected");
                }

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, _serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestMethod(), TestCategory(Category.Scenario), TestProperty("Feature", "PAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet ((Get,Set,Remove)-AzureServiceExtension)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\package.csv", "package#csv", DataAccessMethod.Sequential)]
        public void AzureServiceExtensionTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
            const string rdpPath = @".\WebRole2.rdp";

            try
            {
                Collection<ExtensionImageContext> resultExtensions = vmPowershellCmdlets.GetAzureServiceAvailableExtension();

                foreach (var extension in resultExtensions)
                {
                    if (extension.ExtensionName == "RDP")
                    {
                        _extensionName = extension.ExtensionName;
                        _providerNamespace = extension.ProviderNameSpace;
                        _version = extension.Version;
                        break;
                    }
                }

                vmPowershellCmdlets.NewAzureService(_serviceName, _serviceName, locationName);
                Console.WriteLine("service, {0}, is created.", _serviceName);

                vmPowershellCmdlets.NewAzureDeployment(_serviceName, _packagePath.FullName, _configPath.FullName,
                    DeploymentSlotType.Production, DeploymentLabel, DeploymentName, false, false);

                DeploymentInfoContext result = vmPowershellCmdlets.GetAzureDeployment(_serviceName, DeploymentSlotType.Production);
                pass = Utilities.PrintAndCompareDeployment(result, _serviceName, DeploymentName, DeploymentLabel, DeploymentSlotType.Production, null, 2);
                Console.WriteLine("successfully deployed the package");

                vmPowershellCmdlets.SetAzureServiceExtension(
                    serviceName: _serviceName,
                    extensionName: _extensionName,
                    providerNamespace: _providerNamespace,
                    publicConfig: PublicConfig,
                    privateConfig: PrivateConfig,
                    version: _version
                    );

                ExtensionContext resultExtensionContext = vmPowershellCmdlets.GetAzureServiceExtension(_serviceName)[0];

                Utilities.PrintContext(resultExtensionContext);

                VerifyExtensionContext(resultExtensionContext, "AllRoles", _extensionName, _providerNamespace, _version);

                RemoteDesktopExtensionContext resultContext = vmPowershellCmdlets.GetAzureServiceRemoteDesktopExtension(_serviceName)[0];

                Utilities.PrintContext(resultContext);

                VerifyRDP(_serviceName, rdpPath);

                vmPowershellCmdlets.RemoveAzureServiceExtension(
                    serviceName: _serviceName,
                    extensionName: _extensionName,
                    providerNamespace: _providerNamespace,
                    uninstall: true);

                try
                {
                    vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", _serviceName, rdpPath, false);
                    Assert.Fail("Succeeded, but extected to fail!");
                }
                catch (Exception e)
                {
                    if (e is AssertFailedException)
                    {
                        throw;
                    }
                    Console.WriteLine("Failed to get RDP file as expected");
                }

                vmPowershellCmdlets.RemoveAzureDeployment(_serviceName, DeploymentSlotType.Production, true);

                pass &= Utilities.CheckRemove(vmPowershellCmdlets.GetAzureDeployment, _serviceName, DeploymentSlotType.Production);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}", e);
                throw;
            }
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");

            // Remove the service
            if ((cleanupIfPassed && pass) || (cleanupIfFailed && !pass))
            {
                CleanupService(_serviceName);
            }
        }

        private bool VerifyExtensionContext(ExtensionContext resultContext, string role, string extensionName, string providerNamespace, string version)
        {
            try
            {
                Assert.AreEqual(role, resultContext.Role.RoleType.ToString());
                Assert.AreEqual(extensionName, resultContext.Extension);
                Assert.AreEqual(providerNamespace, resultContext.ProviderNameSpace);
                Assert.AreEqual(version, resultContext.Version);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
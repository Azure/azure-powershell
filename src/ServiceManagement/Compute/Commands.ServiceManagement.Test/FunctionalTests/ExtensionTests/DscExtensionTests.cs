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
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ExtensionTests
{
    [TestClass]
    public class DscExtensionTests: ServiceManagementTest
    {
        private const string DscExtensionPublisher = "Microsoft.Powershell.DSC";
        private const string DscExtensionName = "DSC";

        private const string DefaultContainerName = "windows-powershell-dsc";

        private const string testConfigurationArchive = "DscExtensionTestConfiguration.ps1";
        private const string testConfigurationName     = "DscExtensionTestConfiguration";
        private Hashtable    testConfigurationArgument = new Hashtable() { { "DestinationPath", @"'C:\MyDirectory" } };
        private const string testConfigurationDataPath = @".\DSC\DscExtensionTestConfigurationData.psd1";
        
        private string testServiceName;

        private static string dscExtensionVersion;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Utilities.PrintHeader("ClassInitialize");
            try
            {
                DscExtensionTests.dscExtensionVersion = GetDscExtensionVersion();
            }
            finally
            {
                Utilities.PrintFooter("ClassInitialize");
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Utilities.PrintHeader("TestInitialize");
            try
            {
                this.testServiceName = Utilities.GetUniqueShortName(serviceNamePrefix);
                this.testStartTime = DateTime.Now;
                this.pass = false;
            }
            finally
            {
                Utilities.PrintFooter("TestInitialize");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Utilities.PrintHeader("TestCleanup");
            try
            {
                Utilities.ExecuteAndLog(() => CleanupService(this.testServiceName), "Removing VM service used by tests");
            }
            finally
            {
                Utilities.PrintFooter("TestCleanup");
            }
        }

        #region TestCases

        [TestMethod(), Priority(0), TestCategory("Scenario"), TestProperty("Feature", "IaaS"), Owner("narrieta"),
        Description("Test the cmdlets Set/Get-AzureVMDscExtension using a new VM")]
        public void SetDscExtensionOnNewVmTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                var vmName = Utilities.GetUniqueShortName(vmNamePrefix);

                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);

                var arguments = new ServiceManagementCmdletTestHelper.SetAzureVMDscExtensionArguments()
                {
                    Version = DscExtensionTests.dscExtensionVersion,
                    VM = vm,
                    ConfigurationArchive = testConfigurationArchive,
                    StorageContext = null,
                    ContainerName = DefaultContainerName,
                    ConfigurationName = testConfigurationName,
                    ConfigurationArgument = testConfigurationArgument,
                    ConfigurationDataPath = testConfigurationDataPath
                };

                vm = vmPowershellCmdlets.SetAzureVMDscExtension(arguments);

                vmPowershellCmdlets.NewAzureVM(this.testServiceName, new[] { vm }, locationName);

                VerifyDscExtensionContext(vmName, arguments);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestCategory("Scenario"), TestProperty("Feature", "IaaS"), Owner("narrieta"),
        Description("Test the cmdlets Set/Get-AzureVMDscExtension using an existing")]
        public void SetDscExtensionOnExistingVmTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                var vmName = Utilities.GetUniqueShortName(vmNamePrefix);

                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);

                vmPowershellCmdlets.NewAzureVM(this.testServiceName, new[] { vm }, locationName);

                var arguments = new ServiceManagementCmdletTestHelper.SetAzureVMDscExtensionArguments()
                {
                    Version = DscExtensionTests.dscExtensionVersion,
                    VM = vmPowershellCmdlets.GetAzureVM(vmName, this.testServiceName).VM,
                    ConfigurationArchive = testConfigurationArchive,
                    StorageContext = null,
                    ContainerName = DefaultContainerName,
                    ConfigurationName = testConfigurationName,
                    ConfigurationArgument = testConfigurationArgument,
                    ConfigurationDataPath = testConfigurationDataPath
                };

                vm = vmPowershellCmdlets.SetAzureVMDscExtension(arguments);

                vmPowershellCmdlets.UpdateAzureVM(vmName, this.testServiceName, vm);
                
                VerifyDscExtensionContext(vmName, arguments);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        [TestMethod(), Priority(0), TestCategory("Scenario"), TestProperty("Feature", "IaaS"), Owner("narrieta"),
        Description("Test the cmdlets Set-AzureVMDscExtension using default parameters")]
        public void SetDscExtensionWithDefaultParametersTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            try
            {
                var vmName = Utilities.GetUniqueShortName(vmNamePrefix);

                var vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, imageName, true, username, password);

                var arguments = new ServiceManagementCmdletTestHelper.SetAzureVMDscExtensionArguments()
                {
                    Version = DscExtensionTests.dscExtensionVersion,
                    VM = vm,
                    ConfigurationArchive = testConfigurationArchive,
                    StorageContext = null,
                    ContainerName = null,
                    ConfigurationName = null,
                    ConfigurationArgument = testConfigurationArgument,
                    ConfigurationDataPath = testConfigurationDataPath
                };

                vm = vmPowershellCmdlets.SetAzureVMDscExtension(arguments);

                vmPowershellCmdlets.NewAzureVM(this.testServiceName, new[] { vm }, locationName);

                VerifyDscExtensionContext(vmName, arguments);

                pass = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        #endregion TestCases

        #region Helper Methods

        private static string GetDscExtensionVersion()
        {
            Utilities.PrintHeader("Listing the available VM extensions");

            try
            {
                var extensionsInfo = vmPowershellCmdlets.GetAzureVMAvailableExtension(DscExtensionName, DscExtensionPublisher, true);

                var dscExtension = extensionsInfo.OrderBy(c => c.Version).LastOrDefault();

                if (dscExtension == null)
                {
                    throw new Exception(string.Format("Cannot find DSC extension; Name: '{0}' Publisher: '{1}'", DscExtensionName, DscExtensionPublisher));
                }

                var match = Regex.Match(dscExtension.Version, @"((\.).*?){2}");

                var version = dscExtension.Version.Substring(0, match.Groups[2].Captures[1].Index);

                Console.WriteLine("Using Dsc Extension Version: {0}", version);

                return version;
            }
            finally
            {
                Utilities.PrintFooter("Listing the available VM extensions");
            }
        }

        private void VerifyDscExtensionContext(string vmName, ServiceManagementCmdletTestHelper.SetAzureVMDscExtensionArguments expected)
        {
            Utilities.PrintHeader("Verifiying Dsc extension context.");

            try
            {
                var vm = Utilities.GetAzureVM(vmName, this.testServiceName);

                var context = vmPowershellCmdlets.GetAzureVMDscExtension(vm);
                
                Utilities.LogAssert(() => Assert.AreEqual(DscExtensionName, context.ExtensionName), "Verifiying ExtensionName");
                Utilities.LogAssert(() => Assert.AreEqual(DscExtensionPublisher, context.Publisher), "Verifiying Publisher");
                Utilities.LogAssert(() => Assert.AreEqual(DscExtensionName, context.ReferenceName), "Verifiying ReferenceName");
                Utilities.LogAssert(() => Assert.AreEqual(dscExtensionVersion, context.Version), "Verifiying Version");
                Utilities.LogAssert(() => Assert.AreEqual("Enable", context.State),	"Verifiying State");
                Utilities.LogAssert(() => Assert.AreEqual(vmName, context.RoleName), "Verifiying RoleName");

                var expectedContainer = (expected.ContainerName ?? DefaultContainerName) + "/";
                Utilities.LogAssert(() => Assert.IsNotNull(context.ModulesUrl), "Verifiying ModulesUrl is not null");
                var modulesUrl = new Uri(context.ModulesUrl);
                Utilities.LogAssert(() => Assert.AreEqual(3, modulesUrl.Segments.Length), "Verifiying ModulesUrl is well formed");
                Utilities.LogAssert(() => Assert.AreEqual(expectedContainer, modulesUrl.Segments[1]), "Verifiying the container in ModulesUrl");
                Utilities.LogAssert(() => Assert.AreEqual(expected.ConfigurationArchive, modulesUrl.Segments[2]), "Verifiying the configuration in ModulesUrl");

                var expectedConfigurationName = expected.ConfigurationName ?? Path.GetFileNameWithoutExtension(expected.ConfigurationArchive);
                var expectedConfigurationFunction = Path.GetFileNameWithoutExtension(expected.ConfigurationArchive) + "\\" + expectedConfigurationName;
                Utilities.LogAssert(() => Assert.AreEqual(expectedConfigurationFunction, context.ConfigurationFunction), "Verifiying the configuration in ModulesUrl");

                if (expected.ConfigurationArgument == null)
                {
                    Utilities.LogAssert(() => Assert.IsNull(context.Properties), "Verifiying that Properties is null");
                }
                else
                {
                    Utilities.LogAssert(() => Assert.AreEqual(expected.ConfigurationArgument.Count, context.Properties.Count), "Verifiying number of items in Properties");

                    foreach (var key in expected.ConfigurationArgument.Keys)
                    {
                        var k = key;

                        Utilities.LogAssert(() => Assert.AreEqual(expected.ConfigurationArgument[k], context.Properties[k]), "Verifiying Properties[" + key + "]");
                    }
                }
            }
            finally
            {
                Utilities.PrintHeader("Verifiying Dsc extension context.");
            }
        }

        #endregion Helper Methods
    }
}


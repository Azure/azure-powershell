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

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions
{
    /// <summary>
    /// Tests for DSC ConfigurationParsingHelper class.
    /// </summary>
    /// <remarks>
    /// ConfigurationParsingHelper.ParseConfiguration() API requires tests to be run in x64 host.
    /// These tests also require presents of some DSC resource modules on the test machine.
    /// That cannot be ommit, because the language Parser need to load each module on parsing, so additional
    /// dynamic keywords that descrite Configuration can be handled appropriately.
    /// List of required modules:
    /// xComputerManagement
    /// xNetworking
    /// xPSDesiredStateConfiguration
    /// xActiveDirectory
    /// </remarks>
    [TestClass]
    public class VirtualMachineDscExtensionTests : TestBase
    {
        private const string CorporateClientConfigurationPath = @"DSC\Configurations\CorporateClientConfiguration.ps1";
        private const string DomainControllerConfigurationPath = @"DSC\Configurations\DomainControllerConfiguration.ps1";
        private const string SHMulptiConfigurationsPath = @"DSC\Configurations\SHMulptiConfigurations.ps1";
        private const string VisualStudioPath = @"DSC\Configurations\VisualStudio.ps1";
        private const string NameImportListInsideNodeConfigurationPath = @"DSC\Configurations\Dummy\NameImportListInsideNode.ps1";
        private const string NameImportListOutsideNodeConfigurationPath = @"DSC\Configurations\Dummy\NameImportListOutsideNode.ps1";
        private const string NameImportSingleInsideNodeConfigurationPath = @"DSC\Configurations\Dummy\NameImportSingleInsideNode.ps1";
        private const string NameImportSingleOutsideNodeConfigurationPath = @"DSC\Configurations\Dummy\NameImportSingleOutsideNode.ps1";
        private const string NameModuleImportSingleInsideNodeConfigurationPath = @"DSC\Configurations\Dummy\NameModuleImportSingleInsideNode.ps1";
        private const string ModuleImportListInsideNodeConfigurationPath = @"DSC\Configurations\Dummy\ModuleImportListInsideNode.ps1";
        private const string ModuleImportListOutsideNodeConfigurationPath = @"DSC\Configurations\Dummy\ModuleImportListOutsideNode.ps1";
        private const string ModuleImportSingleInsideNodeConfigurationPath = @"DSC\Configurations\Dummy\ModuleImportSingleInsideNode.ps1";
        private const string ModuleImportSingleOutsideNodeConfigurationPath = @"DSC\Configurations\Dummy\ModuleImportSingleOutsideNode.ps1";
        private const string IEEScGoodConfigurationPath = @"DSC\Configurations\IEEScGood.ps1";
        private const string IEEScBadConfigurationPath = @"DSC\Configurations\IEEScBad.ps1";

        [TestMethod]
        [TestCategory("Scenario")]
        public void TestGetModuleNameForDscResourceXComputer()
        {
            string moduleName = ConfigurationParsingHelper.GetModuleNameForDscResource("MSFT_xComputer");
            Assert.AreEqual("xComputerManagement", moduleName);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        public void TestGetModuleNameForDscResourceXADDomain()
        {
            string moduleName = ConfigurationParsingHelper.GetModuleNameForDscResource("MSFT_xADDomain");
            Assert.AreEqual("xActiveDirectory", moduleName);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(CorporateClientConfigurationPath)]
        public void TestExtractConfigurationNames1()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(CorporateClientConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(DomainControllerConfigurationPath)]
        public void TestExtractConfigurationNames2()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(DomainControllerConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(2, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
            Assert.AreEqual("xActiveDirectory", results.RequiredModules[1]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(VisualStudioPath)]
        public void TestExtractConfigurationNames3()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(VisualStudioPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xPSDesiredStateConfiguration", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(SHMulptiConfigurationsPath)]
        public void TestExtractConfigurationNamesMulti()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(SHMulptiConfigurationsPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(3, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
            Assert.AreEqual("xNetworking", results.RequiredModules[1]);
            Assert.AreEqual("xPSDesiredStateConfiguration", results.RequiredModules[2]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(NameImportListInsideNodeConfigurationPath)]
        public void TestNameImportListInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportListInsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(2, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
            Assert.AreEqual("xActiveDirectory", results.RequiredModules[1]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(NameImportListOutsideNodeConfigurationPath)]
        public void TestNameImportListOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportListOutsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(2, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
            Assert.AreEqual("xActiveDirectory", results.RequiredModules[1]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(NameImportSingleInsideNodeConfigurationPath)]
        public void TestNameImportSingleInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportSingleInsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(NameImportSingleOutsideNodeConfigurationPath)]
        public void TestNameImportSingleOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportSingleOutsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(NameModuleImportSingleInsideNodeConfigurationPath)]
        public void TestNameModuleImportSingleInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameModuleImportSingleInsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xComputerManagement", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(ModuleImportListInsideNodeConfigurationPath)]
        public void TestModuleImportListInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportListInsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(2, results.RequiredModules.Count);
            Assert.AreEqual("xPSDesiredStateConfiguration", results.RequiredModules[0]);
            Assert.AreEqual("xNetworking", results.RequiredModules[1]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(ModuleImportListOutsideNodeConfigurationPath)]
        public void TestModuleImportListOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportListOutsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(2, results.RequiredModules.Count);
            Assert.AreEqual("xPSDesiredStateConfiguration", results.RequiredModules[0]);
            Assert.AreEqual("xNetworking", results.RequiredModules[1]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(ModuleImportSingleInsideNodeConfigurationPath)]
        public void TestModuleImportSingleInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportSingleInsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xNetworking", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(ModuleImportSingleOutsideNodeConfigurationPath)]
        public void TestModuleImportSingleOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportSingleOutsideNodeConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xNetworking", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(IEEScGoodConfigurationPath)]
        public void TestIEEScGood()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(IEEScGoodConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xSystemSecurity", results.RequiredModules[0]);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        [DeploymentItem(IEEScBadConfigurationPath)]
        public void TestIEEScBad()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(IEEScBadConfigurationPath);
            Assert.AreEqual(0, results.Errors.Count());
            Assert.AreEqual(1, results.RequiredModules.Count);
            Assert.AreEqual("xSystemSecurity", results.RequiredModules[0]);
        }
    }
}

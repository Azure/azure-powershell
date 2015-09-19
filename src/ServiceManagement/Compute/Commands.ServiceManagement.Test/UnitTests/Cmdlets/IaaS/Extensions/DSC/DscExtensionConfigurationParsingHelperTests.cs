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
using System.IO.Compression;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC.Publish;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test;
using Xunit;


namespace Microsoft.WindowsAzure.Commands.Common.Test.Extensions.DSC
{
    /// <summary>
    /// Tests for DSC <see cref="ConfigurationParsingHelper"/> class.
    /// </summary>
    /// <remarks>
    /// ConfigurationParsingHelper.ParseConfiguration() API requires tests to be run in x64 host.
    /// </remarks>
    public class DscExtensionConfigurationParsingHelperTests
    {
        private const string CorporateClientConfigurationPath = @"Resources\DSC\Configurations\CorporateClientConfiguration.ps1";
        private const string DomainControllerConfigurationPath = @"Resources\DSC\Configurations\DomainControllerConfiguration.ps1";
        private const string ShMulptiConfigurationsPath = @"Resources\DSC\Configurations\SHMulptiConfigurations.ps1";
        private const string VisualStudioPath = @"Resources\DSC\Configurations\VisualStudio.ps1";
        private const string NameImportListInsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\NameImportListInsideNode.ps1";
        private const string NameImportListOutsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\NameImportListOutsideNode.ps1";
        private const string NameImportSingleInsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\NameImportSingleInsideNode.ps1";
        private const string NameImportSingleOutsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\NameImportSingleOutsideNode.ps1";
        private const string NameModuleImportSingleInsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\NameModuleImportSingleInsideNode.ps1";
        private const string ModuleImportListInsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\ModuleImportListInsideNode.ps1";
        private const string ModuleImportListOutsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\ModuleImportListOutsideNode.ps1";
        private const string ModuleImportSingleInsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\ModuleImportSingleInsideNode.ps1";
        private const string ModuleImportSingleOutsideNodeConfigurationPath = @"Resources\DSC\Configurations\Dummy\ModuleImportSingleOutsideNode.ps1";
        private const string IeeScGoodConfigurationPath = @"Resources\DSC\Configurations\IEEScGood.ps1";
        private const string IeeScBadConfigurationPath = @"Resources\DSC\Configurations\IEEScBad.ps1";

        private const string TestDscResourceModulesDirectory = @"azure-sdk-tools-dsc-test";

        private const string XDscResourcesArchivePath = @"Resources\DSC\DSC Resource Kit Wave 6 08282014.zip";

        private const string PsModulePathEnvVar = "PSModulePath";

        public DscExtensionConfigurationParsingHelperTests()
        {
            string testDscResourceModulesPath = Path.Combine(Path.GetTempPath(), TestDscResourceModulesDirectory);
            if (Directory.Exists(testDscResourceModulesPath))
            {
                // cleanup
                Directory.Delete(testDscResourceModulesPath, true);
            }
            // unpack xPSDSC resources
            ZipFile.ExtractToDirectory(XDscResourcesArchivePath, testDscResourceModulesPath);

            // Set $env:PSModulePath to include temp folder, so resources can be explored.
            string psModulePath = Environment.GetEnvironmentVariable(PsModulePathEnvVar);
            string newpsModulePath = psModulePath + ";" + testDscResourceModulesPath;
            Environment.SetEnvironmentVariable(PsModulePathEnvVar, newpsModulePath);
        }

        [Fact (Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestGetModuleNameForDscResourceXComputer()
        {
            string moduleName = ConfigurationParsingHelper.GetModuleNameForDscResource("MSFT_xComputer");
            Assert.Equal("xComputerManagement", moduleName);
        }

        [Fact (Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestGetModuleNameForDscResourceXadDomain()
        {
            string moduleName = ConfigurationParsingHelper.GetModuleNameForDscResource("MSFT_xADDomain");
            Assert.Equal("xActiveDirectory", moduleName);
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestExtractConfigurationNames1()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(CorporateClientConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestExtractConfigurationNames2()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(DomainControllerConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(2, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xActiveDirectory"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestExtractConfigurationNames3()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(VisualStudioPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xPSDesiredStateConfiguration"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestExtractConfigurationNamesMulti()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ShMulptiConfigurationsPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(3, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xNetworking"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xPSDesiredStateConfiguration"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestNameImportListInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportListInsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(2, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xActiveDirectory"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestNameImportListOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportListOutsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(2, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xActiveDirectory"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestNameImportSingleInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportSingleInsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestNameImportSingleOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameImportSingleOutsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestNameModuleImportSingleInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(NameModuleImportSingleInsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xComputerManagement"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestModuleImportListInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportListInsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(2, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xPSDesiredStateConfiguration"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xNetworking"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestModuleImportListOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportListOutsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(2, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xPSDesiredStateConfiguration"));
            Assert.Equal(true, results.RequiredModules.ContainsKey("xNetworking"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestModuleImportSingleInsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportSingleInsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xNetworking"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestModuleImportSingleOutsideNode()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(ModuleImportSingleOutsideNodeConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xNetworking"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestIeeScGood()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(IeeScGoodConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xSystemSecurity"));
        }

        [Fact(Skip = "Tests fail in build system. Disable temporarily")]
        [Trait(Category.Functional, Category.BVT)]
        public void TestIeeScBad()
        {
            ConfigurationParseResult results = ConfigurationParsingHelper.ParseConfiguration(IeeScBadConfigurationPath);
            Assert.Equal(0, results.Errors.Count());
            Assert.Equal(1, results.RequiredModules.Count);
            Assert.Equal(true, results.RequiredModules.ContainsKey("xSystemSecurity"));
        }
    }
}

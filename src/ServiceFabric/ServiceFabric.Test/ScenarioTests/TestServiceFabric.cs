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
using Microsoft.Azure.Commands.ServiceFabric.Commands;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    [TestCaseOrderer("Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests.PriorityOrderer", "Microsoft.Azure.Commands.ServiceFabric.Test")]
    public class TestServiceFabric : ServiceFabricTestRunner
    {
        private sealed class TestServiceFabricClusterCmdlet : ServiceFabricClusterCmdlet
        {
            public DurabilityLevel GetNodeTypeDurabilityLevel(string durabilityLevel)
            {
                return GetDurabilityLevel(durabilityLevel);
            }

            public DurabilityLevel GetVmssDurabilityLevel(string durabilityLevel)
            {
                var vmss = new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSet
                {
                    VirtualMachineProfile = new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSetVMProfile
                    {
                        ExtensionProfile = new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSetExtensionProfile
                        {
                            Extensions = new[]
                            {
                                new Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models.VirtualMachineScaleSetExtension
                                {
                                    Type = "ServiceFabricNode",
                                    Settings = new Newtonsoft.Json.Linq.JObject
                                    {
                                        ["durabilityLevel"] = durabilityLevel
                                    }
                                }
                            }
                        }
                    }
                };

                return GetDurabilityLevel(vmss);
            }

            public override void ExecuteCmdlet()
            {
            }
        }

        public TestServiceFabric(ITestOutputHelper output) : base(output)
        {
            //AddAzureRmServiceFabricNodeType.dontRandom = true;
            ServiceFabricCommonCmdletBase.WriteVerboseIntervalInSec = 0;
            ServiceFabricCmdletBase.RunningTest = true;
            ServiceFabricCmdletBase.NewCreatedKeyVaultWaitTimeInSec = 0;
            //change the thumbprint in the common.ps1 file as well
            ServiceFabricCmdletBase.TestThumbprint = "4D59A08F0039D124316D89680F89024C9E5EC9C4";
            ServiceFabricCmdletBase.TestCommonNameCACert = "azurermsfcntest.southcentralus.cloudapp.azure.com";
            ServiceFabricCmdletBase.TestCommonNameAppCert = "AzureRMSFTestCertApp";
            ServiceFabricCmdletBase.TestThumbprintAppCert = "D9BAB3CC41F5EA798DD086402C1A4EDADEB42B2A";
            ServiceFabricCmdletBase.TestAppCert = false;
        }

        [Fact, TestPriority(3)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricDurability()
        {
            TestRunner.RunTestScript("Test-UpdateAzureRmServiceFabricDurability");
        }

        [Theory]
        [InlineData("bronze", DurabilityLevel.Bronze)]
        [InlineData("silver", DurabilityLevel.Silver)]
        [InlineData("gold", DurabilityLevel.Gold)]
        public void GetDurabilityLevelAcceptsLowercaseValues(string durabilityLevel, DurabilityLevel expectedDurabilityLevel)
        {
            var cmdlet = new TestServiceFabricClusterCmdlet();

            Assert.Equal(expectedDurabilityLevel, cmdlet.GetNodeTypeDurabilityLevel(durabilityLevel));
            Assert.Equal(expectedDurabilityLevel, cmdlet.GetVmssDurabilityLevel(durabilityLevel));
        }

        [Fact]
        public void GetDurabilityLevelReportsInvalidValue()
        {
            var cmdlet = new TestServiceFabricClusterCmdlet();

            var exception = Assert.Throws<System.Management.Automation.PSInvalidOperationException>(
                () => cmdlet.GetNodeTypeDurabilityLevel("invalid"));

            Assert.Contains("Valid values are Bronze, Silver, and Gold.", exception.Message);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("999")]
        [InlineData("0")]
        public void GetDurabilityLevelRejectsNumericStrings(string numericValue)
        {
            var cmdlet = new TestServiceFabricClusterCmdlet();

            Assert.Throws<System.Management.Automation.PSInvalidOperationException>(
                () => cmdlet.GetNodeTypeDurabilityLevel(numericValue));

            Assert.Throws<System.Management.Automation.PSInvalidOperationException>(
                () => cmdlet.GetVmssDurabilityLevel(numericValue));
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricReliability()
        {
            TestRunner.RunTestScript("Test-UpdateAzureRmServiceFabricReliability");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmServiceFabricUpgradeType()
        {
            TestRunner.RunTestScript("Test-SetAzureRmServiceFabricUpgradeType");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmServiceFabricSettings()
        {
            TestRunner.RunTestScript("Test-SetAzureRmServiceFabricSettings");
        }

        [Fact, TestPriority(1)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricSettings()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmServiceFabricSettings");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricClientCertificate()
        {
            TestRunner.RunTestScript("Test-AddAzureRmServiceFabricClientCertificate");
        }

        [Fact, TestPriority(1)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricClientCertificate()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmServiceFabricClientCertificate");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmServiceFabricCluster()
        {
            TestRunner.RunTestScript("Test-NewAzureRmServiceFabricCluster");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmServiceFabricClusterCNCert()
        {
            TestRunner.RunTestScript("Test-NewAzureRmServiceFabricClusterCNCert");
        }

        [Fact, TestPriority(4)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricNode()
        {
            TestRunner.RunTestScript("Test-AddAzureRmServiceFabricNode");
        }

        [Fact, TestPriority(5)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricNode()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmServiceFabricNode");
        }

        [Fact, TestPriority(2)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricNodeType()
        {
            TestRunner.RunTestScript("Test-AddAzureRmServiceFabricNodeType");
        }

        [Fact, TestPriority(6)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestRemoveAzureRmServiceFabricNodeType()
        {
            TestRunner.RunTestScript("Test-RemoveAzureRmServiceFabricNodeType");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricVmImage()
        {
            TestRunner.RunTestScript("Test-UpdateAzureRmServiceFabricVmImage");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DefaultTemplateFilesAvailable()
        {
            var assemblyFolder = AppDomain.CurrentDomain.BaseDirectory;

            string windowsTemplateDirectory = Path.Combine(assemblyFolder, Constants.WindowsTemplateRelativePath);
            var templateFilePath = Path.Combine(windowsTemplateDirectory, Constants.TemplateFileName);
            var parameterFilePath = Path.Combine(windowsTemplateDirectory, Constants.ParameterFileName);
            Assert.True(File.Exists(templateFilePath), string.Format("file not found: {0}", templateFilePath));
            Assert.True(File.Exists(parameterFilePath), string.Format("file not found: {0}", parameterFilePath));

            string ubuntu16TemplateDirectory = Path.Combine(assemblyFolder, Constants.UbuntuServer16TemplateRelativePath);
            templateFilePath = Path.Combine(ubuntu16TemplateDirectory, Constants.TemplateFileName);
            parameterFilePath = Path.Combine(ubuntu16TemplateDirectory, Constants.ParameterFileName);
            Assert.True(File.Exists(templateFilePath), string.Format("file not found: {0}", templateFilePath));
            Assert.True(File.Exists(parameterFilePath), string.Format("file not found: {0}", parameterFilePath));

            string ubuntu18TemplateDirectory = Path.Combine(assemblyFolder, Constants.UbuntuServer18TemplateRelativePath);
            templateFilePath = Path.Combine(ubuntu18TemplateDirectory, Constants.TemplateFileName);
            parameterFilePath = Path.Combine(ubuntu18TemplateDirectory, Constants.ParameterFileName);
            Assert.True(File.Exists(templateFilePath), string.Format("file not found: {0}", templateFilePath));
            Assert.True(File.Exists(parameterFilePath), string.Format("file not found: {0}", parameterFilePath));

            string ubuntu20TemplateDirectory = Path.Combine(assemblyFolder, Constants.UbuntuServer20TemplateRelativePath);
            templateFilePath = Path.Combine(ubuntu20TemplateDirectory, Constants.TemplateFileName);
            parameterFilePath = Path.Combine(ubuntu20TemplateDirectory, Constants.ParameterFileName);
            Assert.True(File.Exists(templateFilePath), string.Format("file not found: {0}", templateFilePath));
            Assert.True(File.Exists(parameterFilePath), string.Format("file not found: {0}", parameterFilePath));

            string ubuntu22TemplateDirectory = Path.Combine(assemblyFolder, Constants.UbuntuServer22TemplateRelativePath);
            templateFilePath = Path.Combine(ubuntu22TemplateDirectory, Constants.TemplateFileName);
            parameterFilePath = Path.Combine(ubuntu22TemplateDirectory, Constants.ParameterFileName);
            Assert.True(File.Exists(templateFilePath), string.Format("file not found: {0}", templateFilePath));
            Assert.True(File.Exists(parameterFilePath), string.Format("file not found: {0}", parameterFilePath));

            string ubuntu24TemplateDirectory = Path.Combine(assemblyFolder, Constants.UbuntuServer24TemplateRelativePath);
            templateFilePath = Path.Combine(ubuntu24TemplateDirectory, Constants.TemplateFileName);
            parameterFilePath = Path.Combine(ubuntu24TemplateDirectory, Constants.ParameterFileName);
            Assert.True(File.Exists(templateFilePath), string.Format("file not found: {0}", templateFilePath));
            Assert.True(File.Exists(parameterFilePath), string.Format("file not found: {0}", parameterFilePath));
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AllOperatingSystemsHaveSkuMapping()
        {
            var cmdlet = new NewAzureRmServiceFabricCluster();
            var allOsValues = Enum.GetValues(typeof(Models.OperatingSystem)).Cast<Models.OperatingSystem>();

            foreach (var os in allOsValues)
            {
                Assert.True(
                    cmdlet.OsToVmSkuString.ContainsKey(os),
                    string.Format("OperatingSystem.{0} is missing from OsToVmSkuString dictionary", os));

                Assert.False(
                    string.IsNullOrEmpty(cmdlet.OsToVmSkuString[os]),
                    string.Format("OperatingSystem.{0} has null or empty SKU value", os));
            }
        }
    }
}

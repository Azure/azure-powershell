﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.ServiceFabric.Commands;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    [TestCaseOrderer("Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests.PriorityOrderer", "Microsoft.Azure.Commands.ServiceFabric.Test")]
    public class TestServiceFabric : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public TestServiceFabric(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);

            AddAzureRmServiceFabricNodeType.dontRandom = true;
            ServiceFabricCommonCmdletBase.WriteVerboseIntervalInSec = 0;
            ServiceFabricCmdletBase.RunningTest = true;
            ServiceFabricCmdletBase.NewCreatedKeyVaultWaitTimeInSec = 0;
            //change the thumbprint in the common.ps1 file as well
            ServiceFabricCmdletBase.TestThumbprint = "D1DC34B88497F50FB0C0F019DA74E4DA5FADD56D";
            ServiceFabricCmdletBase.TestCommonNameCACert = "azurermsfcntest.southcentralus.cloudapp.azure.com";
            ServiceFabricCmdletBase.TestCommonNameAppCert = "AzureRMSFTestCertApp";
            ServiceFabricCmdletBase.TestThumbprintAppCert = "50EA76B5EC4B588CC25CB4C38CC13666A0CA0BB3";
            ServiceFabricCmdletBase.TestAppCert = false;
        }

        [Fact, TestPriority(3)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricDurability()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-UpdateAzureRmServiceFabricDurability");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricReliability()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-UpdateAzureRmServiceFabricReliability");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmServiceFabricUpgradeType()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmServiceFabricUpgradeType");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmServiceFabricSettings()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-SetAzureRmServiceFabricSettings");
        }

        [Fact, TestPriority(1)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricSettings()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmServiceFabricSettings");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricClusterCertificateCNNotAllowed()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmServiceFabricClusterCertificateCNNotAllowed");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricClusterCertificate()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmServiceFabricClusterCertificate");
        }

        [Fact, TestPriority(1)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricClusterCertificate()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmServiceFabricClusterCertificate");
        }

        [Fact, TestPriority(2)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricClusterCertificateNotAllowed()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmServiceFabricClusterCertificateNotAllowed");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricClientCertificate()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmServiceFabricClientCertificate");
        }

        [Fact, TestPriority(1)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricClientCertificate()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmServiceFabricClientCertificate");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmServiceFabricCluster()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewAzureRmServiceFabricCluster");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmServiceFabricClusterCNCert()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-NewAzureRmServiceFabricClusterCNCert");
        }

        [Fact, TestPriority(4)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricNode()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmServiceFabricNode");
        }

        [Fact, TestPriority(5)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricNode()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmServiceFabricNode");
        }

        [Fact, TestPriority(2)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricNodeType()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-AddAzureRmServiceFabricNodeType");
        }

        [Fact, TestPriority(6)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestRemoveAzureRmServiceFabricNodeType()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-RemoveAzureRmServiceFabricNodeType");
        }

        [Fact, TestPriority(0)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricVmImage()
        {
            TestController.NewInstance.RunPsTest(_logger, "Test-UpdateAzureRmServiceFabricVmImage");
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
        }
    }
}

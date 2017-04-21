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
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Azure.Commands.Management.Storage.Test.ScenarioTests;
using Microsoft.Azure.Commands.ServiceFabric.Commands;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    public class TestServiceFabric : RMTestBase
    {
        public TestServiceFabric(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));

            AddAzureRmServiceFabricNodeType.dontRandom = true;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricDurability()
        {
            TestController.NewInstance.RunPsTest("Test-UpdateAzureRmServiceFabricDurability");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateAzureRmServiceFabricReliability()
        {
            TestController.NewInstance.RunPsTest("Test-UpdateAzureRmServiceFabricReliability");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmServiceFabricUpgradeType()
        {
            TestController.NewInstance.RunPsTest("Test-SetAzureRmServiceFabricUpgradeType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRmServiceFabricSettings()
        {
            TestController.NewInstance.RunPsTest("Test-SetAzureRmServiceFabricSettings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricSettings()
        {
            TestController.NewInstance.RunPsTest("Test-RemoveAzureRmServiceFabricSettings");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricClusterCertificate()
        {
            TestController.NewInstance.RunPsTest("Test-AddAzureRmServiceFabricClusterCertificate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricClusterCertificate()
        {
            TestController.NewInstance.RunPsTest("Test-RemoveAzureRmServiceFabricClusterCertificate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricClientCertificate()
        {
            TestController.NewInstance.RunPsTest("Test-AddAzureRmServiceFabricClientCertificate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricClientCertificate()
        {
            TestController.NewInstance.RunPsTest("Test-RemoveAzureRmServiceFabricClientCertificate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmServiceFabricNodeType()
        {
            TestController.NewInstance.RunPsTest("Test-AddAzureRmServiceFabricNodeType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmServiceFabricNodeType()
        {
            TestController.NewInstance.RunPsTest("Test-RemoveAzureRmServiceFabricNodeType");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmServiceFabricCluster()
        {
            var id = AzureRmProfileProvider.Instance.Profile.Context.Account.Id;
            TestController.NewInstance.RunPsTest("Test-NewAzureRmServiceFabricCluster");
        }
    }
}

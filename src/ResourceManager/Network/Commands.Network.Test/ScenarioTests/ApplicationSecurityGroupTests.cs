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
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class ApplicationSecurityGroupTests : RMTestBase
    {
        public ApplicationSecurityGroupTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupCollections()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupCollections"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupInNewSecurityRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInNewSecurityRule"));
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInNewSecurityRule -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupInAddedSecurityRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInAddedSecurityRule"));
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInAddedSecurityRule -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupInSetSecurityRule()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInSetSecurityRule"));
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInSetSecurityRule -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupInNewNetworkInterface()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInNewNetworkInterface"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupInNewNetworkInterfaceIpConfig()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInNewNetworkInterfaceIpConfig"));
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInNewNetworkInterfaceIpConfig -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApplicationSecurityGroupInAddedNetworkInterfaceIpConfig()
        {
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInAddedNetworkInterfaceIpConfig"));
            NetworkResourcesController.NewInstance.RunPsTest(string.Format("Test-ApplicationSecurityGroupInAddedNetworkInterfaceIpConfig -useIds $True"));
        }
    }
}

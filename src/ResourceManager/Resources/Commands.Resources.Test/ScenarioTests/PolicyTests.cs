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


using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class PolicyTests : RMTestBase
    {
        public PolicyTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUD()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtManagementGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtSubscription()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentCRUD()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyAssignmentCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionWithParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicySetDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentWithParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyAssignmentWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUD()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicySetDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtManagementGroup()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicySetDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtSubscription()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicySetDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithUri()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyDefinitionWithUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyObjectPiping()
        {
            ResourcesController.NewInstance.RunPsTest("Test-PolicyObjectPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-GetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RemovePolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyAssignmentParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-SetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-GetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RemovePolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-SetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-GetPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-NewPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-RemovePolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicySetDefinitionParameters()
        {
            ResourcesController.NewInstance.RunPsTest("Test-SetPolicySetDefinitionParameters");
        }
    }
}

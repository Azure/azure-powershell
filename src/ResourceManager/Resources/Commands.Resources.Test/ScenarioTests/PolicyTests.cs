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


using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class PolicyTests : TestManagerBuilder//: RMTestBase
    {
        public PolicyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUD()
        {
            TestManager.RunTestScript("Test-PolicyDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtManagementGroup()
        {
            TestManager.RunTestScript("Test-PolicyDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtSubscription()
        {
            TestManager.RunTestScript("Test-PolicyDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentCRUD()
        {
            TestManager.RunTestScript("Test-PolicyAssignmentCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithParameters()
        {
            TestManager.RunTestScript("Test-PolicyDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionWithParameters()
        {
            TestManager.RunTestScript("Test-PolicySetDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentWithParameters()
        {
            TestManager.RunTestScript("Test-PolicyAssignmentWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUD()
        {
            TestManager.RunTestScript("Test-PolicySetDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtManagementGroup()
        {
            TestManager.RunTestScript("Test-PolicySetDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtSubscription()
        {
            TestManager.RunTestScript("Test-PolicySetDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithUri()
        {
            TestManager.RunTestScript("Test-PolicyDefinitionWithUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyAssignmentParameters()
        {
            TestManager.RunTestScript("Test-GetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyAssignmentParameters()
        {
            TestManager.RunTestScript("Test-NewPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyAssignmentParameters()
        {
            TestManager.RunTestScript("Test-RemovePolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyAssignmentParameters()
        {
            TestManager.RunTestScript("Test-SetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyDefinitionParameters()
        {
            TestManager.RunTestScript("Test-GetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyDefinitionParameters()
        {
            TestManager.RunTestScript("Test-NewPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyDefinitionParameters()
        {
            TestManager.RunTestScript("Test-RemovePolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyDefinitionParameters()
        {
            TestManager.RunTestScript("Test-SetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicySetDefinitionParameters()
        {
            TestManager.RunTestScript("Test-GetPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicySetDefinitionParameters()
        {
            TestManager.RunTestScript("Test-NewPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicySetDefinitionParameters()
        {
            TestManager.RunTestScript("Test-RemovePolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicySetDefinitionParameters()
        {
            TestManager.RunTestScript("Test-SetPolicySetDefinitionParameters");
        }
    }
}

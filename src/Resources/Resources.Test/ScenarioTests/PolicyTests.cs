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
    public class PolicyTests : ResourcesTestRunner
    {
        public PolicyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUD()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionMode()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionMode");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtManagementGroup()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionCRUDAtSubscription()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionCRUDAtSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentCRUD()
        {
            TestRunner.RunTestScript("Test-PolicyAssignmentCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentAssignIdentity()
        {
            TestRunner.RunTestScript("Test-PolicyAssignmentAssignIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentSystemAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-PolicyAssignmentSystemAssignedIdentity");
        }

        [Fact(Skip = "Skip as current test framework does not support recording generated cmdlets.")]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestPolicyAssignmentUserAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-PolicyAssignmentUserAssignedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentEnforcementMode()
        {
            TestRunner.RunTestScript("Test-PolicyAssignmentEnforcementMode");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithParameters()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionWithParameters()
        {
            TestRunner.RunTestScript("Test-PolicySetDefinitionWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyAssignmentWithParameters()
        {
            TestRunner.RunTestScript("Test-PolicyAssignmentWithParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUD()
        {
            TestRunner.RunTestScript("Test-PolicySetDefinitionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDWithGroups()
        {
            TestRunner.RunTestScript("Test-PolicySetDefinitionCRUDWithGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtManagementGroup()
        {
            TestRunner.RunTestScript("Test-PolicySetDefinitionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicySetDefinitionCRUDAtSubscription()
        {
            TestRunner.RunTestScript("Test-PolicySetDefinitionCRUDAtSubscription");
        }

        [Fact(Skip = "Fails on macOS. Needs investigation.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithUri()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionWithUri");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyObjectPiping()
        {
            TestRunner.RunTestScript("Test-PolicyObjectPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyDefinitionWithFullObject()
        {
            TestRunner.RunTestScript("Test-PolicyDefinitionWithFullObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetCmdletFilterParameter()
        {
            TestRunner.RunTestScript("Test-GetCmdletFilterParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBuiltinsByName()
        {
            TestRunner.RunTestScript("Test-GetBuiltinsByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyAssignmentParameters()
        {
            TestRunner.RunTestScript("Test-GetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyAssignmentParameters()
        {
            TestRunner.RunTestScript("Test-NewPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyAssignmentParameters()
        {
            TestRunner.RunTestScript("Test-RemovePolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyAssignmentParameters()
        {
            TestRunner.RunTestScript("Test-SetPolicyAssignmentParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-GetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-NewPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-RemovePolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-SetPolicyDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicySetDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-GetPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicySetDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-NewPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicySetDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-RemovePolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicySetDefinitionParameters()
        {
            TestRunner.RunTestScript("Test-SetPolicySetDefinitionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyExemptionCRUD()
        {
            TestRunner.RunTestScript("Test-PolicyExemptionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyExemptionCRUDOnPolicySet()
        {
            TestRunner.RunTestScript("Test-PolicyExemptionCRUDOnPolicySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPolicyExemptionCRUDAtManagementGroup()
        {
            TestRunner.RunTestScript("Test-PolicyExemptionCRUDAtManagementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPolicyExemptionParameters()
        {
            TestRunner.RunTestScript("Test-GetPolicyExemptionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPolicyExemptionParameters()
        {
            TestRunner.RunTestScript("Test-NewPolicyExemptionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemovePolicyExemptionParameters()
        {
            TestRunner.RunTestScript("Test-RemovePolicyExemptionParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetPolicyExemptionParameters()
        {
            TestRunner.RunTestScript("Test-SetPolicyExemptionParameters");
        }
    }
}

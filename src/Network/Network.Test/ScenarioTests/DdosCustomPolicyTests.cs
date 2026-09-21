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

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class DdosCustomPolicyTests : NetworkTestRunner
    {
        public DdosCustomPolicyTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyDetectionRuleCreation()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyDetectionRuleCreation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUD()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUDWithSingleRule()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUDWithSingleRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUDWithoutRules()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUDWithoutRules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUDWithTags()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUDWithTags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUDWithMultipleTrafficTypes()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUDWithMultipleTrafficTypes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyRemoveWithoutPassThru()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyRemoveWithoutPassThru");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyDetectionRuleValidation()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyDetectionRuleValidation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyAddDetectionRule()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyAddDetectionRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyRemoveDetectionRule()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyRemoveDetectionRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUDWithSet()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUDWithSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyAddDetectionRuleComprehensive()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyAddDetectionRuleComprehensive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyRemoveDetectionRuleComprehensive()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyRemoveDetectionRuleComprehensive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicySetComprehensive()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicySetComprehensive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyDetectionRuleParameterVariations()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyDetectionRuleParameterVariations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyCRUDWithVariousRuleCounts()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyCRUDWithVariousRuleCounts");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyInMemoryMutationIsolation()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyInMemoryMutationIsolation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyRemoveTrafficTypeCaseInsensitive()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyRemoveTrafficTypeCaseInsensitive");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyPipelineChaining()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyPipelineChaining");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.ddos)]
        public void TestDdosCustomPolicyDuplicateTrafficTypePersistFailure()
        {
            TestRunner.RunTestScript("Test-DdosCustomPolicyDuplicateTrafficTypePersistFailure");
        }
    }
}

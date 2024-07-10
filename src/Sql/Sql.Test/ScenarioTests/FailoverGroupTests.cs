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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class FailoverGroupTests : SqlTestRunner
    {
        public FailoverGroupTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverGroup()
        {
            TestRunner.RunTestScript("Test-FailoverGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_Named()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-Named");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_Positional()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-Positional");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_AutomaticPolicy()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-AutomaticPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_AutomaticPolicyGracePeriodReadOnlyFailover()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-AutomaticPolicyGracePeriodReadOnlyFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_ZeroGracePeriod()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-ZeroGracePeriod");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_ManualPolicy()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-ManualPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_Overflow()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-Overflow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateFailoverGroup_CrossSubscription()
        {
            TestRunner.RunTestScript("Test-CreateFailoverGroup-CrossSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_Named()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-Named");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_Positional()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-Positional");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_PipeServer()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-PipeServer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_AutomaticWithGracePeriodReadOnlyFailover()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-AutomaticWithGracePeriodReadOnlyFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_AutomaticWithGracePeriodZero()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-AutomaticWithGracePeriodZero");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_AutomaticToManual()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-AutomaticToManual");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_ManualToAutomaticNoGracePeriod()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-ManualToAutomaticNoGracePeriod");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetFailoverGroup_Overflow()
        {
            TestRunner.RunTestScript("Test-SetFailoverGroup-Overflow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Test_AddRemoveDatabasesToFromFailoverGroup()
        {
            TestRunner.RunTestScript("Test-AddRemoveDatabasesToFromFailoverGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSwitchFailoverGroup()
        {
            TestRunner.RunTestScript("Test-SwitchFailoverGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSwitchFailoverGroupAllowDataLoss()
        {
            TestRunner.RunTestScript("Test-SwitchFailoverGroupAllowDataLoss");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSwitchFailoverGroupTryPlannedBeforeForcedFailover()
        {
            TestRunner.RunTestScript("Test-SwitchFailoverGroupTryPlannedBeforeForcedFailover");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverGroupMultipleSecondaries()
        {
            TestRunner.RunTestScript("Test-FailoverGroupMultipleSecondaries");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddRemoveDatabasesToFromFailoverGroupWithStandby()
        {
            TestRunner.RunTestScript("Test-AddRemoveDatabasesToFromFailoverGroupWithStandby");
        }
    }
}

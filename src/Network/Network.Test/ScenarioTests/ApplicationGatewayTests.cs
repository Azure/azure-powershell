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
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class ApplicationGatewayTests : NetworkTestRunner
    {
        public ApplicationGatewayTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestAvailableSslOptions()
        {
            TestRunner.RunTestScript("Test-AvailableSslOptions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestAvailableWafRuleSets()
        {
            TestRunner.RunTestScript("Test-AvailableWafRuleSets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUD -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUD2()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUD2 -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUD3()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUD3 -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUDSubItems()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDSubItems -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nvadev)]
        public void TestApplicationGatewayCRUDSubItems2()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDSubItems2 -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.nvadev)]
        public void TestApplicationGatewayCRUDRewriteRuleSet()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationGatewayCRUDRewriteRuleSet -baseDir '{0}'", AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}

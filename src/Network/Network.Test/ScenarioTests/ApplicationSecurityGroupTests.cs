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
    public class ApplicationSecurityGroupTests : NetworkTestRunner
    {
        public ApplicationSecurityGroupTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupCRUD()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupCRUD"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupCollections()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupCollections"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupInNewSecurityRule()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInNewSecurityRule"));
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInNewSecurityRule -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupInAddedSecurityRule()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInAddedSecurityRule"));
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInAddedSecurityRule -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupInSetSecurityRule()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInSetSecurityRule"));
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInSetSecurityRule -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupInNewNetworkInterface()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInNewNetworkInterface"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupInNewNetworkInterfaceIpConfig()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInNewNetworkInterfaceIpConfig"));
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInNewNetworkInterfaceIpConfig -useIds $True"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.sdnnrp)]
        public void TestApplicationSecurityGroupInAddedNetworkInterfaceIpConfig()
        {
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInAddedNetworkInterfaceIpConfig"));
            TestRunner.RunTestScript(string.Format("Test-ApplicationSecurityGroupInAddedNetworkInterfaceIpConfig -useIds $True"));
        }
    }
}

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

namespace Commands.Network.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class BastionTests : NetworkTestRunner
    {
        public BastionTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.bastion)]
        public void TestBastionCRUD()
        {
            TestRunner.RunTestScript("Test-BastionCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.bastion)]
        public void TestBastionVnetsIpObjectsParams()
        {
            TestRunner.RunTestScript("Test-BastionVnetsIpObjectsParams");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.bastion)]
        public void TestBastionVnetObjectParam()
        {
            TestRunner.RunTestScript("Test-BastionVnetObjectParam");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.bastion)]
        public void TestBastionIpObjectParam()
        {
            TestRunner.RunTestScript("Test-BastionIpObjectParam");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.bastion)]
        public void TestBastionCreateWithFeatures()
        {
            TestRunner.RunTestScript("Test-BastionCreateWithFeatures");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.bastion)]
        public void TestBastionShareableLink()
        {
            TestRunner.RunTestScript("Test-BastionShareableLink");
        }
    }
}

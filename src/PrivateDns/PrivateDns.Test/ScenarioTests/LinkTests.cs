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


namespace Microsoft.Azure.Commands.PrivateDns.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class LinkTests : PrivateDnsTestRunner
    {
        public LinkTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinkCrud()
        {
            TestRunner.RunTestScript("Test-LinkCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinkCrudWithPiping()
        {
            TestRunner.RunTestScript("Test-LinkCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRegistrationLinkCreate()
        {
            TestRunner.RunTestScript("Test-RegistrationLinkCreate");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinkAlreadyExistsCreateThrow()
        {
            TestRunner.RunTestScript("Test-LinkAlreadyExistsCreateThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLinkWithVirtualNetworkObject()
        {
            TestRunner.RunTestScript("Test-CreateLinkWithVirtualNetworkObject");
        }

        [Fact(Skip = "Test framework doesn't support using tokens for multiple tenants at the moment.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateLinkWithRemoteVirtualId()
        {
            TestRunner.RunTestScript("Test-CreateLinkWithRemoteVirtualId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkRegistrationStatusWithPiping()
        {
            TestRunner.RunTestScript("Test-UpdateLinkRegistrationStatusWithPiping");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkRegistrationStatusWithPipingResourceId()
        {
            TestRunner.RunTestScript("Test-UpdateLinkRegistrationStatusWithResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkWithEtagMismatchThrow()
        {
            TestRunner.RunTestScript("Test-UpdateLinkWithEtagMismatchThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteLinkWithResourceId()
        {
            TestRunner.RunTestScript("Test-DeleteLinkWithResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkWithEtagMismatchOverwrite()
        {
            TestRunner.RunTestScript("Test-UpdateLinkWithEtagMismatchOverwrite");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkZoneNotExistsThrow()
        {
            TestRunner.RunTestScript("Test-UpdateLinkZoneNotExistsThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkLinkNotExistsThrow()
        {
            TestRunner.RunTestScript("Test-UpdateLinkLinkNotExistsThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateLinkWithNoChangesShouldNotThrow()
        {
            TestRunner.RunTestScript("Test-UpdateLinkWithNoChangesShouldNotThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLinkZoneNotExistsThrow()
        {
            TestRunner.RunTestScript("Test-GetLinkZoneNotExistsThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetLinkLinkNotExistsThrow()
        {
            TestRunner.RunTestScript("Test-GetLinkLinkNotExistsThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveLinkZoneNotExistsShouldNotThrow()
        {
            TestRunner.RunTestScript("Test-RemoveLinkZoneNotExistsShouldNotThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveLinkLinkNotExistsShouldNotThrow()
        {
            TestRunner.RunTestScript("Test-RemoveLinkLinkNotExistsShouldNotThrow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListLinks()
        {
            TestRunner.RunTestScript("Test-ListLinks");
        }
    }
}

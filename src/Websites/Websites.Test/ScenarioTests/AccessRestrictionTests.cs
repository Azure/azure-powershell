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

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class AccessRestrictionTests : WebsitesTestRunner
    {
        public AccessRestrictionTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppAccessRestriction()
        {
            TestRunner.RunTestScript("Test-GetWebAppAccessRestriction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateWebAppAccessRestrictionSimple()
        {
            TestRunner.RunTestScript("Test-UpdateWebAppAccessRestrictionSimple");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateWebAppAccessRestrictionComplex()
        {
            TestRunner.RunTestScript("Test-UpdateWebAppAccessRestrictionComplex");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestriction()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestriction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionServiceTag()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestrictionServiceTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionHttpHeaders()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestrictionHttpHeaders");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionServiceEndpoint()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestrictionServiceEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppAccessRestriction()
        {
            TestRunner.RunTestScript("Test-RemoveWebAppAccessRestriction");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppAccessRestrictionServiceTag()
        {
            TestRunner.RunTestScript("Test-RemoveWebAppAccessRestrictionServiceTag");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionScm()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestrictionScm");
        }
                
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppAccessRestrictionScm()
        {
            TestRunner.RunTestScript("Test-RemoveWebAppAccessRestrictionScm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionSlot()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestrictionSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddWebAppAccessRestrictionDuplicate()
        {
            TestRunner.RunTestScript("Test-AddWebAppAccessRestrictionDuplicate");
        }
    }
}

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
// --------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class ResourceManagementPrivateLinksTests : ResourcesTestRunner
    {
        public ResourceManagementPrivateLinksTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveResourceManagementPrivateLink()
        {
            TestRunner.RunTestScript("Test-RemoveResourceManagementPrivateLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceManagementPrivateLink()
        {
            TestRunner.RunTestScript("Test-GetResourceManagementPrivateLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceManagementPrivateLinks()
        {
            TestRunner.RunTestScript("Test-GetResourceManagementPrivateLinks");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveResourceManagementPrivateLinkAssociation()
        {
            TestRunner.RunTestScript("Test-RemoveResourceManagementPrivateLinkAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceManagementPrivateLinkAssociations()
        {
            TestRunner.RunTestScript("Test-GetResourceManagementPrivateLinkAssociations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetResourceManagementPrivateLinkAssociation()
        {
            TestRunner.RunTestScript("Test-GetResourceManagementPrivateLinkAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceManagementPrivateLink()
        {
            TestRunner.RunTestScript("Test-NewResourceManagementPrivateLink");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewResourceManagementPrivateLinkAssociation()
        {
            TestRunner.RunTestScript("Test-NewResourceManagementPrivateLinkAssociation");
        }
    }
}

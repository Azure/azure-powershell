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

namespace Microsoft.Azure.Commands.Management.Search.Test.ScenarioTests
{
    public class SearchServiceTests : SearchTestRunner
    {
        public SearchServiceTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchService()
        {
            TestRunner.RunTestScript("Test-NewAzSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceBasic()
        {
            TestRunner.RunTestScript("Test-NewAzSearchServiceBasic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceL1()
        {
            TestRunner.RunTestScript("Test-NewAzSearchServiceL1");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceIdentity()
        {
            TestRunner.RunTestScript("Test-NewAzSearchServiceIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServicePublicNetworkAccessDisabled()
        {
            TestRunner.RunTestScript("Test-NewAzSearchServicePublicNetworkAccessDisabled");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceIpRules()
        {
            TestRunner.RunTestScript("Test-NewAzSearchServiceIpRules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSearchService()
        {
            TestRunner.RunTestScript("Test-GetAzSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSearchService()
        {
            TestRunner.RunTestScript("Test-RemoveAzSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSearchService()
        {
            TestRunner.RunTestScript("Test-SetAzSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSearchServiceAdminKey()
        {
            TestRunner.RunTestScript("Test-ManageAzSearchServiceAdminKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSearchServiceQueryKey()
        {
            TestRunner.RunTestScript("Test-ManageAzSearchServiceQueryKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateLinkResource()
        {
            TestRunner.RunTestScript("Test-GetAzSearchPrivateLinkResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateLinkResourcePipeline()
        {
            TestRunner.RunTestScript("Test-GetAzSearchPrivateLinkResourcePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSharedPrivateLinkResources()
        {
            TestRunner.RunTestScript("Test-ManageAzSearchSharedPrivateLinkResources");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSharedPrivateLinkResourcesPipeline()
        {
            TestRunner.RunTestScript("Test-ManageAzSearchSharedPrivateLinkResourcePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSharedPrivateLinkResourcesJob()
        {
            TestRunner.RunTestScript("Test-ManageAzSearchSharedPrivateLinkResourceJob");
        }
    }
}

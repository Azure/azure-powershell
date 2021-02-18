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

using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.Search.Test.ScenarioTests
{
    public class SearchServiceTests : RMTestBase
    {
        private readonly XunitTracingInterceptor traceInterceptor;

        public SearchServiceTests(ITestOutputHelper output)
        {
            traceInterceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.traceInterceptor);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchService()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmSearchService");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzSearchService");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceBasic()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmSearchServiceBasic");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzSearchServiceBasic");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceL1()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmSearchServiceL1");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzSearchServiceL1");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceIdentity()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzSearchServiceIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServicePublicNetworkAccessDisabled()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzSearchServicePublicNetworkAccessDisabled");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchServiceIpRules()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzSearchServiceIpRules");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSearchService()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmSearchService");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzSearchService");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSearchService()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-RemoveAzureRmSearchService");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-RemoveAzSearchService");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSearchService()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SetAzureRmSearchService");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-SetAzSearchService");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSearchServiceAdminKey()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzureRmSearchServiceAdminKey");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzSearchServiceAdminKey");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSearchServiceQueryKey()
        {
<<<<<<< HEAD
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzureRmSearchServiceQueryKey");
=======
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzSearchServiceQueryKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateLinkResource()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzSearchPrivateLinkResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPrivateLinkResourcePipeline()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzSearchPrivateLinkResourcePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSharedPrivateLinkResources()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzSearchSharedPrivateLinkResources");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSharedPrivateLinkResourcesPipeline()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzSearchSharedPrivateLinkResourcePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSharedPrivateLinkResourcesJob()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-ManageAzSearchSharedPrivateLinkResourceJob");
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}

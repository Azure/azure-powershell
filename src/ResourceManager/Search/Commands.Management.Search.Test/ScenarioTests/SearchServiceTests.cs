using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.Search.Test.ScenarioTests
{
    public class SearchServiceTests : RMTestBase
    {
        XunitTracingInterceptor traceInterceptor;

        public SearchServiceTests(ITestOutputHelper output)
        {
            this.traceInterceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.traceInterceptor);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSearchService()
        {
            TestController.NewInstance.RunPsTest("Test-NewAzureRmSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSearchService()
        {
            TestController.NewInstance.RunPsTest("Test-GetAzureRmSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSearchService()
        {
            TestController.NewInstance.RunPsTest("Test-RemoveAzureRmSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetSearchService()
        {
            TestController.NewInstance.RunPsTest("Test-SetAzureRmSearchService");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSearchServiceAdminKey()
        {
            TestController.NewInstance.RunPsTest("Test-ManageAzureRmSearchServiceAdminKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSearchServiceQueryKey()
        {
            TestController.NewInstance.RunPsTest("Test-ManageAzureRmSearchServiceQueryKey");
        }
    }
}

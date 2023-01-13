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
    public class WebAppSlotTests : WebsitesTestRunner
    {
        public WebAppSlotTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSlot()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppSlot");
        }

        [Fact(Skip = "TODO #5594: This test requires a pre-set AppService Environment with specific settings.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSlotOnAse()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppSlotOnAse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSlot()
        {
            TestRunner.RunTestScript("Test-GetWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSlotPublishingProfile()
        {
            TestRunner.RunTestScript("Test-WebAppSlotPublishingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneWebAppToSlot()
        {
            TestRunner.RunTestScript("Test-CloneWebAppToSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneWebAppSlot()
        {
            TestRunner.RunTestScript("Test-CloneWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopRestartWebAppSlot()
        {
            TestRunner.RunTestScript("Test-StartStopRestartWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebAppSlot()
        {
            TestRunner.RunTestScript("Test-SetWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSlotSlotConfigName()
        {
            TestRunner.RunTestScript("Test-ManageSlotSlotConfigName");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestWebAppRegularSlotSwap()
        {
            TestRunner.RunTestScript("Test-WebAppRegularSlotSwap");
        }

        [Fact(Skip = "iss#6044 The test needs to be re-written")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSwapWithPreviewResetSlotSwap()
        {
            TestRunner.RunTestScript("Test-WebAppSwapWithPreviewResetSlotSwap");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSwapWithPreviewCompleteSlotSwap()
        {
            TestRunner.RunTestScript("Test-WebAppSwapWithPreviewCompleteSlotSwap");
        }
    }
}

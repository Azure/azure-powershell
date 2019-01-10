﻿// ----------------------------------------------------------------------------------
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


using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppSlotTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public WebAppSlotTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppSlot");
        }

        [Fact(Skip = "TODO #5594: This test requires a pre-set AppService Environment with specific settings.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSlotOnAse()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppSlotOnAse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppSlot");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSlotMetrics()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppSlotMetrics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSlotPublishingProfile()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WebAppSlotPublishingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneWebAppToSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CloneWebAppToSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CloneWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopRestartWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-StartStopRestartWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-SetWebAppSlot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManageSlotSlotConfigName()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-ManageSlotSlotConfigName");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestWebAppRegularSlotSwap()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WebAppRegularSlotSwap");
        }

        [Fact(Skip = "iss#6044 The test needs to be re-written")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSwapWithPreviewResetSlotSwap()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WebAppSwapWithPreviewResetSlotSwap");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSwapWithPreviewCompleteSlotSwap()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WebAppSwapWithPreviewCompleteSlotSwap");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageWebAppHyperVSlot()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-SetAzureStorageWebAppHyperVSlot");
        }
    }
}

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


using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public WebAppTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppHyperV()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppHyperV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableContainerContinuousDeploymentAndGetUrl()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-EnableContainerContinuousDeploymentAndGetUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageWebAppHyperV()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-SetAzureStorageWebAppHyperV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppOnAse()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppOnAse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSimple()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CreateNewWebAppSimple");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebApp");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppMetrics()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-GetWebAppMetrics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppPublishingProfile()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WebAppPublishingProfile");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestPublishWebAppFromZip()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-PublishAzureWebAppFromZip");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestPublishWebAppFromWar()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-PublishAzureWebAppFromWar");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CloneNewWebApp");
        }

        [Fact(Skip = "Test is being skipped until issue with cloning is resolved. See GitHub issue #3770 for more information.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebAppAndDeploymentSlots()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CloneNewWebAppAndDeploymentSlots");
        }

        // This test is failing with an HTTP 500 due to a bug in the clone service.
        [Fact(Skip = "Test is being skipped until issue with cloning is resolved.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebAppWithNewTrafficManager()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-CloneNewWebAppWithTrafficManager");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopRestartWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-StartStopRestartWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-SetWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-RemoveWebApp");
        }

        [Fact(Skip = "Skipping while investigation regarding PowerShell version in Travis continues")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWindowsContainerWebAppCanIssuePSSession()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WindowsContainerCanIssueWebAppPSSession");
        }

        [Fact(Skip = "Expected to fail during playback because it validates that a PsSession into a real container web app can be established")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWindowsContainerWebAppPSSessionOpened()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-WindowsContainerWebAppPSSessionOpened");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTagsNotRemovedBySetWebApp()
        {
            WebsitesController.NewInstance.RunPsTest(_logger, "Test-TagsNotRemovedBySetWebApp");
        }
    }
}

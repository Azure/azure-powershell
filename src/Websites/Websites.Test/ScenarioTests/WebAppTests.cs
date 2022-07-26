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
    public class WebAppTests : WebsitesTestRunner
    {
        public WebAppTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebApp()
        {
            TestRunner.RunTestScript("Test-CreateNewWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppHyperV()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppHyperV");
        }

        [Fact(Skip = "Needs investigation. Fails pulling container image from public registry.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebAppHyperVCredentials()
        {
            TestRunner.RunTestScript("Test-SetWebAppHyperVCredentials");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableContainerContinuousDeploymentAndGetUrl()
        {
            TestRunner.RunTestScript("Test-EnableContainerContinuousDeploymentAndGetUrl");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureStorageWebAppHyperV()
        {
            TestRunner.RunTestScript("Test-SetAzureStorageWebAppHyperV");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppOnAse()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppOnAse");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSimple()
        {
            TestRunner.RunTestScript("Test-CreateNewWebAppSimple");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebApp()
        {
            TestRunner.RunTestScript("Test-GetWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppPublishingProfile()
        {
            TestRunner.RunTestScript("Test-WebAppPublishingProfile");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestPublishWebAppFromZip()
        {
            TestRunner.RunTestScript("Test-PublishAzureWebAppFromZip");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestPublishWebAppFromWar()
        {
            TestRunner.RunTestScript("Test-PublishAzureWebAppFromWar");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebApp()
        {
            TestRunner.RunTestScript("Test-CloneNewWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebAppAndDeploymentSlots()
        {
            TestRunner.RunTestScript("Test-CloneNewWebAppAndDeploymentSlots");
        }

        // This test is failing with an HTTP 500 due to a bug in the clone service.
        [Fact(Skip = "Test is being skipped until issue with cloning is resolved.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebAppWithNewTrafficManager()
        {
            TestRunner.RunTestScript("Test-CloneNewWebAppWithTrafficManager");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopRestartWebApp()
        {
            TestRunner.RunTestScript("Test-StartStopRestartWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebApp()
        {
            TestRunner.RunTestScript("Test-SetWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebApp()
        {
            TestRunner.RunTestScript("Test-RemoveWebApp");
        }

        [Fact(Skip = "Test is being skipped until issue with HttpMockserver unable to load error is resolved.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWindowsContainerWebAppCanIssuePSSession()
        {
            TestRunner.RunTestScript("Test-WindowsContainerCanIssueWebAppPSSession");
        }

        [Fact(Skip = "Expected to fail during playback because it validates that a PsSession into a real container web app can be established")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWindowsContainerWebAppPSSessionOpened()
        {
            TestRunner.RunTestScript("Test-WindowsContainerWebAppPSSessionOpened");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTagsNotRemovedBySetWebApp()
        {
            TestRunner.RunTestScript("Test-TagsNotRemovedBySetWebApp");
        }
    }
}

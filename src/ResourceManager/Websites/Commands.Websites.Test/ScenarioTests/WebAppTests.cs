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


using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppTests : RMTestBase
    {
        public WebAppTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebApp()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CreateNewWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppOnAse()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CreateNewWebAppOnAse");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebApp()
        {
            WebsitesController.NewInstance.RunPsTest("Test-GetWebApp");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppMetrics()
        {
            WebsitesController.NewInstance.RunPsTest("Test-GetWebAppMetrics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppPublishingProfile()
        {
            WebsitesController.NewInstance.RunPsTest("Test-WebAppPublishingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebApp()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CloneNewWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebAppAndDeploymentSlots()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CloneNewWebAppAndDeploymentSlots");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneNewWebAppWithNewTrafficManager()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CloneNewWebAppWithTrafficManager");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopRestartWebApp()
        {
            WebsitesController.NewInstance.RunPsTest("Test-StartStopRestartWebApp");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebApp()
        {
            WebsitesController.NewInstance.RunPsTest("Test-SetWebApp");
        }
    }
}

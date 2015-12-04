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
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppSlotTests : RMTestBase
    {
        private const string CallingClass = "Microsoft.Azure.Commands.Websites.Test.ScenarioTests.WebAppSlotTests";

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestCreateNewWebAppSlot",
                "Test-CreateNewWebAppSlot");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetWebAppSlot",
                "Test-GetWebAppSlot");
        }

        [Fact(Skip= "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppSlotMetrics()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetWebAppSlotMetrics",
                "Test-GetWebAppSlotMetrics");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestWebAppSlotPublishingProfile()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestWebAppSlotPublishingProfile",
                "Test-WebAppSlotPublishingProfile");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneWebAppToSlot()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestCloneWebAppToSlot",
                "Test-CloneWebAppToSlot");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCloneWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestCloneWebAppSlot",
                "Test-CloneWebAppSlot");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartStopRestartWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestStartStopRestartWebAppSlot",
                "Test-StartStopRestartWebAppSlot");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetWebAppSlot()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestSetWebAppSlot",
                "Test-SetWebAppSlot");
        }
    }
}

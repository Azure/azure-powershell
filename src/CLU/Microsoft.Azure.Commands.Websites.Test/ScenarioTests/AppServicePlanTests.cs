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


using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class AppServicePlanTests : RMTestBase
    {
        private const string CallingClass = "Microsoft.Azure.Commands.Websites.Test.ScenarioTests.AppServicePlanTests";

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestCreateNewAppServicePlan",
                "Test-CreateNewAppServicePlan");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestSetAppServicePlan",
                "Test-SetAppServicePlan");
        }

        [Fact(Skip="Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetAppServicePlan",
                "Test-GetAppServicePlan");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAppServicePlan()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestRemoveAppServicePlan",
                "Test-RemoveAppServicePlan");
        }

        [Fact(Skip = "Needs investigation. Fails running playback")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAppServicePlanMetrics()
        {
            WebsitesController.NewInstance.RunPsTest(
                CallingClass,
                "TestGetAppServicePlanMetrics",
                "Test-GetAppServicePlanMetrics");
        }
    }
}

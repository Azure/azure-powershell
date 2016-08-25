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

namespace Microsoft.Azure.Commands.TrafficManager.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagemenet.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    public class ProfileTests
    {
        public ProfileTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrud()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrudWithPiping()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDeleteUsingProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-CreateDeleteUsingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCrudWithEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest("Test-CrudWithEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesInResourceGroup()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ListProfilesInResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListProfilesInSubscription()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ListProfilesInSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileNewAlreadyExists()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileNewAlreadyExists");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileRemoveNonExisting()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileRemoveNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnable()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileEnable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnablePipeline()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileEnablePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileEnableNonExisting()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileEnableNonExisting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisable()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileDisable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisablePipeline()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileDisablePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDisableNonExisting()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ProfileDisableNonExisting");
        }
    }
}

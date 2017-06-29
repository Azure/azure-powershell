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
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class GetAzureTrafficManagerProfileTests
    {
        public GetAzureTrafficManagerProfileTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetMissingProfile()
        {
            TestController.NewInstance.RunPowerShellTest("Test-GetMissingProfile");
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
        public void TestListProfilesWhereObject()
        {
            TestController.NewInstance.RunPowerShellTest("Test-ListProfilesWhereObject");
        }
    }
}
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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class AutoscaleTests : RMTestBase
    {
        public AutoscaleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmAutoscaleSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-AddAzureRmAutoscaleSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAutoscaleSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmAutoscaleSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmAutoscaleSetting()
        {
            TestsController.NewInstance.RunPsTest("Test-RemoveAzureRmAutoscaleSetting");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmAutoscaleHistory()
        {
            TestsController.NewInstance.RunPsTest("Test-GetAzureRmAutoscaleHistory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAutoscaleNotification()
        {
            TestsController.NewInstance.RunPsTest("Test-NewAzureRmAutoscaleNotification");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureRmAutoscaleWebhook()
        {
            TestsController.NewInstance.RunPsTest("Test-NewAzureRmAutoscaleWebhook");
        }
    }
}

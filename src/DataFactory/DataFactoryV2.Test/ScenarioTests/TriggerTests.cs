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

using Microsoft.Azure.Commands.DataFactoryV2.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public class TriggerTests : DataFactoryV2TestRunner
    {
        public TriggerTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTrigger()
        {
            TestRunner.RunTestScript("Test-Trigger");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartTriggerThrowsWithoutPipeline()
        {
            TestRunner.RunTestScript("Test-StartTriggerThrowsWithoutPipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInvokeAndStopTriggerRun()
        {
            TestRunner.RunTestScript("Test-TriggerInvokeAndStop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTriggerRun()
        {
            TestRunner.RunTestScript("Test-TriggerRun");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTriggerWithResourceId()
        {
            TestRunner.RunTestScript("Test-TriggerWithResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEventTriggerSubscriptions()
        {
            TestRunner.RunTestScript("Test-BlobEventTriggerSubscriptions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEventTriggerSubscriptionsByInputObject()
        {
            TestRunner.RunTestScript("Test-BlobEventTriggerSubscriptionsByInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEventTriggerSubscriptionsByResourceId()
        {
            TestRunner.RunTestScript("Test-BlobEventTriggerSubscriptionsByResourceId");
        }
    }
}

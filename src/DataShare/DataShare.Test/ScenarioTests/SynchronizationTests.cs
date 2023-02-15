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

namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class SynchronizationTests : DataShareTestRunner
    {
        public SynchronizationTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartSynchronization()
        {
            TestRunner.RunTestScript("Test-SynchronizationStart");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCancelSynchronization()
        {
            TestRunner.RunTestScript("Test-SynchronizationCancel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSubscriptionSynchronizationCrud()
        {
            TestRunner.RunTestScript("Test-ListShareSubscriptionSynchronizationCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSubscriptionSynchronizationDetailsCrud()
        {
            TestRunner.RunTestScript("Test-ListShareSubscriptionSynchronizationDetailsCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSynchronizationCrud()
        {
            TestRunner.RunTestScript("Test-ListShareSynchronizationCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSynchronizationDetailsCrud()
        {
            TestRunner.RunTestScript("Test-ListShareSynchronizationDetailsCrud");
        }
    }
}

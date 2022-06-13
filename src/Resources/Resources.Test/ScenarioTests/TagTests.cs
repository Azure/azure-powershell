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

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class TagTests : ResourcesTestRunner
    {
        public TagTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagCreateOrUpdateWithResourceIdParamsForSubscription()
        {
            TestRunner.RunTestScript("Test-TagCreateOrUpdateWithResourceIdParamsForSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagCreateOrUpdateWithResourceIdParamsForResource()
        {
            TestRunner.RunTestScript("Test-TagCreateOrUpdateWithResourceIdParamsForResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagUpdateWithResourceIdParamsForSubscription()
        {
            TestRunner.RunTestScript("Test-TagUpdateWithResourceIdParamsForSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagUpdateWithResourceIdParamsForResource()
        {
            TestRunner.RunTestScript("Test-TagUpdateWithResourceIdParamsForResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagGetWithResourceIdParamsForSubscription()
        {
            TestRunner.RunTestScript("Test-TagGetWithResourceIdParamsForSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagGetWithResourceIdParamsForResource()
        {
            TestRunner.RunTestScript("Test-TagGetWithResourceIdParamsForResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagDeleteWithResourceIdParamsForSubscription()
        {
            TestRunner.RunTestScript("Test-TagDeleteWithResourceIdParamsForSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TagDeleteWithResourceIdParamsForResource()
        {
            TestRunner.RunTestScript("Test-TagDeleteWithResourceIdParamsForResource");
        }
    }
}

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

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;

namespace Commands.Network.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class CortexTests : NetworkTestRunner
    {
        public CortexTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestCortexCRUD()
        {
            TestRunner.RunTestScript("Test-CortexCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestCortexExpressRouteCRUD()
        {
            TestRunner.RunTestScript("Test-CortexExpressRouteCRUD");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestCortexDownloadConfig()
        {
            TestRunner.RunTestScript("Test-CortexDownloadConfig");
        }
    }
}

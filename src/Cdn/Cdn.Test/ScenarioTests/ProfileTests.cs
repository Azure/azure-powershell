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

namespace Microsoft.Azure.Commands.Cdn.Test.ScenarioTests.ScenarioTest
{
    public class ProfileTests : CdnTestRunner
    {
        public ProfileTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrud()
        {
            TestRunner.RunTestScript("Test-ProfileCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSkuCreate()
        {
            TestRunner.RunTestScript("Test-SkuCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrudWithPiping()
        {
            TestRunner.RunTestScript("Test-ProfileDeleteAndSsoWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfilePipeline()
        {
            TestRunner.RunTestScript("Test-ProfilePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDeleteWithEndpoints()
        {
            TestRunner.RunTestScript("Test-ProfileDeleteWithEndpoints");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileGetResourceUsage()
        {
            TestRunner.RunTestScript("Test-ProfileGetResourceUsages");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileGetSupportedOptimizationType()
        {
            TestRunner.RunTestScript("Test-ProfileGetSupportedOptimizationType");
        }
    }
}

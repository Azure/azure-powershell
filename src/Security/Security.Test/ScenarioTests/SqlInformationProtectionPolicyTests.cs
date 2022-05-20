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

namespace Microsoft.Azure.Commands.Security.Test.ScenarioTests
{
    public class SqlInformationProtectionPolicyTests : SecurityTestRunner
    {
        public SqlInformationProtectionPolicyTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenInformationTypeAndSensitivityLabelShareSameId()
        {
            TestRunner.RunTestScript("Test-ErrorWhenInformationTypeAndSensitivityLabelShareSameId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenInformationTypeAndSensitivityLabelShareSameDisplayName()
        {
            TestRunner.RunTestScript("Test-ErrorWhenInformationTypeAndSensitivityLabelShareSameDisplayName");

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenInformationTypesShareSameDisplayName()
        {
            TestRunner.RunTestScript("Test-ErrorWhenInformationTypesShareSameDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenInformationTypesShareSameId()
        {
            TestRunner.RunTestScript("Test-ErrorWhenInformationTypesShareSameId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenSensitivityLabelsShareSameDisplayName()
        {
            TestRunner.RunTestScript("Test-ErrorWhenSensitivityLabelsShareSameDisplayName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenSensitivityLabelsShareSameId()
        {
            TestRunner.RunTestScript("Test-ErrorWhenSensitivityLabelsShareSameId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenRankIsInvalid()
        {
            TestRunner.RunTestScript("Test-ErrorWhenRankIsInvalid");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenRankIsMissing()
        {
            TestRunner.RunTestScript("Test-ErrorWhenRankIsMissing");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestErrorWhenSettingAnEmptyPolicy()
        {
            TestRunner.RunTestScript("Test-ErrorWhenSettingAnEmptyPolicy");
        }
    }
}

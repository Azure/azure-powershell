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

namespace Microsoft.Azure.Commands.Insights.Test.ScenarioTests
{
    public class AzureRmLogProfileTests : MonitorTestRunner
    {
        public AzureRmLogProfileTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact] //(Skip = "TODO: fixing this test after introducing Swagger specs")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmLogProfile()
        {
            TestRunner.RunTestScript("Test-GetAzureRmLogProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmLogProfile()
        {
            TestRunner.RunTestScript("Test-AddAzureRmLogProfile");
        }

        [Fact] //(Skip = "TODO: fixing this test after introducing Swagger specs")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddAzureRmLogProfileWithRetention()
        {
            TestRunner.RunTestScript("Test-AddAzureRmLogProfileWithRetention");
        }
    }
}

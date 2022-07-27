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

namespace Microsoft.Azure.Commands.SecurityInsights.Test.ScenarioTests
{
    public class DataConnectorsTests : SecurityInsightsTestRunner
    {
        public DataConnectorsTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void List()
        {
            TestRunner.RunTestScript("Get-AzSentinelDataConnector-List");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Get()
        {
            TestRunner.RunTestScript("Get-AzSentinelDataConnector-Get");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Create()
        {
            TestRunner.RunTestScript("New-AzSentinelDataConnector-Create");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Update()
        {
            TestRunner.RunTestScript("Update-AzSentinelDataConnector-Update");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InputObject()
        {
            TestRunner.RunTestScript("Update-AzSentinelDataConnector-InputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Delete()
        {
            TestRunner.RunTestScript("Remove-AzSentinelDataConnector-Delete");
        }
    }
}

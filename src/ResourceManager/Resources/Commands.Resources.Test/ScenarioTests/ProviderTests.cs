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

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class ProviderTests : TestManagerBuilder
    {
        public ProviderTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureProvider()
        {
            TestManager.RunTestScript("Test-AzureProvider");
        }

        [Fact(Skip = "ZoneMapping removed.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureProvider_WithZoneMappings()
        {
            TestManager.RunTestScript("Test-AzureProvider-WithZoneMappings");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureProviderOperation()
        {
            TestManager.RunTestScript("Test-AzureProviderOperation");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureProviderOperationDataActions()
        {
            TestManager.RunTestScript("Test-AzureProviderOperationDataActions");
        }
    }
}

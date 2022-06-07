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

using Microsoft.Azure.Commands.DataFactories.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test
{
    public class DataFactoryTests : DataFactoriesTestRunner
    {
        public DataFactoryTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingDataFactory()
        {
            TestRunner.RunTestScript("Test-GetNonExistingDataFactory");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactory()
        {
            TestRunner.RunTestScript("Test-CreateDataFactory");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteDataFactoryWithDataFactoryParameter()
        {
            TestRunner.RunTestScript("Test-DeleteDataFactoryWithDataFactoryParameter");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataFactoryPiping()
        {
            TestRunner.RunTestScript("Test-DataFactoryPiping");
        }
    }
}

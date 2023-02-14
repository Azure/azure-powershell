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
    public class DataFactoryGatewayTests : DataFactoriesTestRunner
    {
        public DataFactoryGatewayTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact(Skip = "test takes too long (more than 5 sec)")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingDataFactoryGateway()
        {
            TestRunner.RunTestScript("Test-GetNonExistingDataFactoryGateway");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryGateway()
        {
            TestRunner.RunTestScript("Test-DataFactoryGateway");
        }

#if NETSTANDARD
        [Fact(Skip = "Management library needs NetCore republish")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDataFactoryGatewayAuthKey()
        {
            TestRunner.RunTestScript("Test-DataFactoryGatewayAuthKey");
        }

        [Fact(Skip = "test takes too long (more than 5 sec)")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryGatewayWithDataFactoryParameter()
        {
            TestRunner.RunTestScript("Test-DataFactoryGatewayWithDataFactoryParameter");
        }
    }
}

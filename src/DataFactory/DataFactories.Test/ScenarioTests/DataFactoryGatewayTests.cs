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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactories.Test
{
    public class DataFactoryGatewayTests : DataFactoriesScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public DataFactoryGatewayTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "test takes too long (more than 5 sec)")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingDataFactoryGateway()
        {
            RunPowerShellTest(_logger, "Test-GetNonExistingDataFactoryGateway");
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
            RunPowerShellTest(_logger, "Test-DataFactoryGateway");
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
            RunPowerShellTest(_logger, "Test-DataFactoryGatewayAuthKey");
        }

        [Fact(Skip = "test takes too long (more than 5 sec)")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateDataFactoryGatewayWithDataFactoryParameter()
        {
            RunPowerShellTest(_logger, "Test-DataFactoryGatewayWithDataFactoryParameter");
        }
    }
}

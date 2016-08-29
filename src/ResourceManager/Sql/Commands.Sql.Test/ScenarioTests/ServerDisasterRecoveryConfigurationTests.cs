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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ServerDisasterRecoveryConfigurationTests : SqlTestsBase
    {
        public ServerDisasterRecoveryConfigurationTests(ITestOutputHelper output)
        {
            var logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));

            helper.TracingInterceptor = logger;
        }

        [Fact(Skip = "TODO fix the test failure")]
        [Trait(Category.AcceptanceType, Category.Sql)]
        public void TestServerDisasterRecoveryConfiguration()
        {
            RunPowerShellTest("Test-ServerDisasterRecoveryConfiguration");
        }
    }
}

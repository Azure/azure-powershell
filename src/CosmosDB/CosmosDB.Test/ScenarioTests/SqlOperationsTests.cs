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

namespace Microsoft.Azure.Commands.CosmosDB.Test.ScenarioTests.ScenarioTest
{
    public class SqlOperationsTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public SqlOperationsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlOperationsCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SqlOperationsCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlOperationsCmdletsUsingInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SqlOperationsCmdletsUsingInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlThroughputCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SqlThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlMigrateThroughputCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SqlMigrateThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlRoleCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SqlRoleCmdlets");
        }
    }
}
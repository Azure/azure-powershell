﻿// ----------------------------------------------------------------------------------
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
    public class TableOperationsTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public TableOperationsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableOperationsCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-TableOperationsCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableOperationsCmdletsUsingInputObject()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-TableOperationsCmdletsUsingInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableThroughputCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-TableThroughputCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableMigrateThroughputCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-TableMigrateThroughputCmdlets");
        }
    }
}
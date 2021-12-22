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
    public class RestoreTests
    {
        private readonly ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public RestoreTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "Unrecognized time format for linux/mac.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreAccountCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RestoreAccountCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFromNewAccountCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RestoreFromNewAccountCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoRestoreAccountCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-MongoRestoreAccountCmdlets");
        }

        [Fact(Skip = "Unrecognized time format for linux/mac.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRestoreFailuresAccountCmdlets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RestoreFailuresAccountCmdlets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSqlContainerBackupInformationCmdLets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SqlContainerBackupInformationCmdLets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMongoDBCollectionBackupInformationCmdLets()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-MongoDBCollectionBackupInformationCmdLets");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateCosmosDBAccountBackupPolicyCmdLet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-UpdateCosmosDBAccountBackupPolicyCmdLet");
        }
    }
}

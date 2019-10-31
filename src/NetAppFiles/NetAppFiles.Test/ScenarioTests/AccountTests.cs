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

namespace Microsoft.Azure.Commands.NetAppFiles.Test.ScenarioTests.ScenarioTest
{
    public class AccountTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public AccountTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountCrud()
        {
            GetSessionsDirectoryPath();
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AccountCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountActiveDirectory()
        {
            GetSessionsDirectoryPath();
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AccountActiveDirectory");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAccountPipelines()
        {
            GetSessionsDirectoryPath();
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AccountPipelines");
        }

        private static void GetSessionsDirectoryPath()
        {
            string connectionString = "SubscriptionId=8f38cfec-0ecd-413a-892e-2494f77a3b56;ServicePrincipal=c6c4faba-2b22-44d9-80a4-71ff5b71f811;ServicePrincipalSecret={QR[+@avhE+3qiyY1Xf;AADTenant=72f988bf-86f1-41af-91ab-2d7cd011db47;Environment=Prod;HttpRecorderMode=Record;";
            System.Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connectionString, System.EnvironmentVariableTarget.Process);
            System.Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record", System.EnvironmentVariableTarget.Process);
        }
    }
}

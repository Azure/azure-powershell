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

using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchAccountTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public BatchAccountTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        public void TestGetNonExistingBatchAccount()
        {
            BatchController.NewInstance.RunPsTest("Test-GetNonExistingBatchAccount");
        }

        [Fact]
        public void TestCreatesNewBatchAccount()
        {
            BatchController.NewInstance.RunPsTest("Test-CreatesNewBatchAccount");
        }

        [Fact]
        public void TestUpdatesExistingBatchAccount()
        {
            BatchController.NewInstance.RunPsTest("Test-UpdatesExistingBatchAccount");
        }

        [Fact]
        public void TestGetBatchAccountsUnderResourceGroups()
        {
            BatchController.NewInstance.RunPsTest("Test-GetBatchAccountsUnderResourceGroups");
        }

        [Fact]
        public void TestCreateAndRemoveBatchAccountViaPiping()
        {
            BatchController.NewInstance.RunPsTest("Test-CreateAndRemoveBatchAccountViaPiping");
        }

        [Fact]
        public void TestBatchAccountKeys()
        {
            BatchController.NewInstance.RunPsTest("Test-BatchAccountKeys");
        }

        [Fact]
        public void TestListNodeAgentSkus()
        {
            BatchController.NewInstance.RunPsTest("Test-GetBatchNodeAgentSkus");
        }
    }
}

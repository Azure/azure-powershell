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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Auth;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Storage;

using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchApplicationTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string commonAccountName = ScenarioTestHelpers.SharedAccount;
        private const string accountName = "testmatt2";
        private const string poolId = ScenarioTestHelpers.SharedPool;


        [Fact]
        public void TestUploadApplication()
        {
            BatchController.NewInstance.RunPsTest(string.Format("Test-UploadApplication '{0}'", accountName));
        }

        [Fact]
        public void TestUploadApplicationPackage()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-UploadApplicationPackage '{0}' ", accountName)); ;
        }

        [Fact]
        public void TestUpdateApplicationPackage()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-UpdateApplicationPackage '{0}' ", accountName));
        }

        [Fact]
        public void TestCreatePoolWithApplicationPackage()
        {
            BatchController controller = BatchController.NewInstance;

            controller.RunPsTest(string.Format("Test-CreatePoolWithApplicationPackage '{0}' ", accountName)); ;}

        [Fact]
        public void TestUpdatePoolWithApplicationPackage()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-UpdatePoolWithApplicationPackage '{0}' ", accountName)); ;
        }
    }
}
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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchApplicationTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private readonly string filePath = "Resources\\TestApplicationPackage.zip".AsAbsoluteLocation();

        [Fact]
        public void TestUploadApplication()
        {
            BatchController.NewInstance.RunPsTest(string.Format("Test-AddApplication"));
        }

        [Fact]
        public void TestUploadApplicationPackage()
        {
            BatchController.NewInstance.RunPsTest(string.Format("Test-UploadApplicationPackage '{0}'", filePath));
        }

        [Fact]
        public void TestUpdateApplicationPackage()
        {
            BatchController.NewInstance.RunPsTest(string.Format("Test-UpdateApplicationPackage '{0}'", filePath));
        }

        [Fact]
        public void TestCreatePoolWithApplicationPackage()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId = "testCreatePoolWithAppPackages";
            controller.RunPsTest(string.Format("Test-CreatePoolWithApplicationPackage '{0}' '{1}' ", poolId, filePath));
        }

        [Fact]
        public void TestUpdatePoolWithApplicationPackage()
        {
            BatchController controller = BatchController.NewInstance;
            string poolId = "testUpdatePoolWithAppPackages";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () =>
                {
                    return new string[]
                    {
                        string.Format("Test-UpdatePoolWithApplicationPackage '{0}' '{1}'",
                            poolId, filePath)
                    };
                },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}
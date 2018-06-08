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

using System.Reflection;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchApplicationPackageTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private readonly string filePath = "Resources\\TestApplicationPackage.zip".AsAbsoluteLocation();
        private const string version = "foo";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUploadApplicationPackage()
        {
            string id = "newApplicationPackage";

            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () =>
                {
                    return new string[]
                    {
                        string.Format(string.Format("Test-UploadApplicationPackage '{0}' '{1}' '{2}'", id, version, filePath))
                    };
                },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(controller, context, id, version, filePath);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteApplicationPackage(controller, context, id, version);
                    ScenarioTestHelpers.DeleteApplication(controller, context, id);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateApplicationPackage()
        {
            string id = "updateApplicationPackage";

            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () =>
                {
                    return new string[]
                    {
                        string.Format(string.Format("Test-UpdateApplicationPackage '{0}' '{1}' '{2}'", id, version, filePath))
                    };
                },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(controller, context, id, version, filePath);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteApplicationPackage(controller, context, id, version);
                    ScenarioTestHelpers.DeleteApplication(controller, context, id);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePoolWithApplicationPackage()
        {
            string id = "createPoolWithApplicationPackage";
            string poolId = "testCreatePoolWithAppPackages";

            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () =>
                {
                    return new string[]
                    {
                        string.Format(string.Format("Test-CreatePoolWithApplicationPackage '{0}' '{1}' '{2}'", id, version, poolId))
                    };
                },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(controller, context, id, version, filePath);
                },
                () =>
                {
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePoolWithApplicationPackage()
        {
            string id = "updatePoolWithApplicationPackage";
            string poolId = "testUpdatePoolWithAppPackages";

            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () =>
                {
                    return new string[]
                    {
                        string.Format("Test-UpdatePoolWithApplicationPackage '{0}' '{1}' '{2}'", id, version, poolId)
                    };
                },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(controller, context, id, version, filePath);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolId, targetDedicated: 1, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteApplicationPackage(controller, context, id, version);
                    ScenarioTestHelpers.DeleteApplication(controller, context, id);
                    ScenarioTestHelpers.DeletePool(controller, context, poolId);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }
    }
}
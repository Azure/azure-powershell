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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class BatchApplicationPackageTests : BatchTestRunner
    {
        private readonly string filePath = "Resources\\TestApplicationPackage.zip".AsAbsoluteLocation();
        private const string version = "foo";

        public BatchApplicationPackageTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUploadApplicationPackage()
        {
            string id = "newApplicationPackage";

            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(this, context, id, version, filePath);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteApplicationPackage(this, context, id, version);
                    ScenarioTestHelpers.DeleteApplication(this, context, id);
                },
                $"Test-UploadApplicationPackage '{id}' '{version}' '{filePath}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateApplicationPackage()
        {
            string id = "updateApplicationPackage";

            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(this, context, id, version, filePath);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteApplicationPackage(this, context, id, version);
                    ScenarioTestHelpers.DeleteApplication(this, context, id);
                },
                $"Test-UpdateApplicationPackage '{id}' '{version}' '{filePath}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreatePoolWithApplicationPackage()
        {
            string id = "createPoolWithApplicationPackage";
            string poolId = "testCreatePoolWithAppPackages";

            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(this, context, id, version, filePath);
                },
                $"Test-CreatePoolWithApplicationPackage '{id}' '{version}' '{poolId}'"
            );
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdatePoolWithApplicationPackage()
        {
            string id = "updatePoolWithApplicationPackage";
            string poolId = "testUpdatePoolWithAppPackages";

            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateApplicationPackage(this, context, id, version, filePath);
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId, targetDedicated: 1, targetLowPriority: 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteApplicationPackage(this, context, id, version);
                    ScenarioTestHelpers.DeleteApplication(this, context, id);
                    ScenarioTestHelpers.DeletePool(this, context, poolId);
                },
                $"Test-UpdatePoolWithApplicationPackage '{id}' '{version}' '{poolId}'"
            );
        }
    }
}
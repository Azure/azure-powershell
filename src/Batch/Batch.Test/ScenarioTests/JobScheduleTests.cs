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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class JobScheduleTests : BatchTestRunner
    {
        public JobScheduleTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestJobScheduleCRUD()
        {
            BatchAccountContext context = null;
            string poolId1 = "testPool";
            string poolId2 = "testPool2";

            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId1, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId1);

                    ScenarioTestHelpers.CreateTestPoolVirtualMachine(this, context, poolId2, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(this, context, poolId2);
                },
                () =>
                {

                    ScenarioTestHelpers.DeletePool(this, context, poolId1);
                    ScenarioTestHelpers.DeletePool(this, context, poolId2);
            },
                $"Test-JobScheduleCRUD"
            );


           
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableEnableTerminateJobSchedule()
        {
            string jobScheduleId = "testDisableEnableTerminateJobSchedule";

            BatchAccountContext context = null;
            TestRunner.RunTestScript(
                null,
                mockContext =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(this, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(this, context, jobScheduleId);
                },
                $"Test-DisableEnableTerminateJobSchedule '{jobScheduleId}'"
            );
        }
    }
}

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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class JobScheduleTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public JobScheduleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestJobScheduleCRUD()
        {
            BatchController.NewInstance.RunPsTest("Test-JobScheduleCRUD");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.Flaky)]
        public void TestDisableEnableTerminateJobSchedule()
        {
            BatchController controller = BatchController.NewInstance;
            string jobScheduleId = "testDisableEnableTerminateJobSchedule";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DisableEnableTerminateJobSchedule '{0}'", jobScheduleId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestJobSchedule(controller, context, jobScheduleId, null);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJobSchedule(controller, context, jobScheduleId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}

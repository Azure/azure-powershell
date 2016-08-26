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

namespace Microsoft.Azure.Commands.Scheduler.Test.ScenarioTests
{
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;

    public class JobCollectionTest : RMTestBase
    {
        public JobCollectionTest(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateJobCollection()
        {
            SchedulerController.NewInstance.RunPowerShellTests("Test-CreateJobCollection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateJobCollectionWithInvalidInput()
        {
            SchedulerController.NewInstance.RunPowerShellTests("Test-CreateJobCollectionWithInvalidInput");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateJobCollectionWithNonDefaultParams()
        {
            SchedulerController.NewInstance.RunPowerShellTests("Test-CreateJobCollectionWithNonDefaultParams");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateJobCollection()
        {
            SchedulerController.NewInstance.RunPowerShellTests("Test-UpdateJobCollection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetRemoveJobCollection()
        {
            SchedulerController.NewInstance.RunPowerShellTests("Test-GetRemoveJobCollection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableDisableJobCollection()
        {
            SchedulerController.NewInstance.RunPowerShellTests("Test-EnableDisableJobCollection");
        }
    }
}


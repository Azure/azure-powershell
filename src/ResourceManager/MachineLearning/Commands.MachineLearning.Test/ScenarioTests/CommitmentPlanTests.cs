﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.MachineLearning.Test.ScenarioTests
{
    public class CommitmentPlanTests : RMTestBase
    {
        private readonly XunitTracingInterceptor interceptor;

        public CommitmentPlanTests(ITestOutputHelper output)
        {
            this.interceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.interceptor);
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetRemoveCommitmentPlan()
        {
            CommitmentPlansTestController.NewInstance.RunPsTest(this.interceptor, "Test-CreateGetRemoveMLCommitmentPlan");
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateCommitmentPlan()
        {
            CommitmentPlansTestController.NewInstance.RunPsTest(this.interceptor, "Test-UpdateMLCommitmentPlan");
        }

        [Fact(Skip = "Old ResourceManager version in test controller. Update and re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListCommitmentPlans()
        {
            CommitmentPlansTestController.NewInstance.RunPsTest(this.interceptor, "Test-ListMLCommitmentPlans");
        }

    }
}

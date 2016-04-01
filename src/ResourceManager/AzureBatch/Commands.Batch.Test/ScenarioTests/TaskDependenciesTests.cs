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

using System;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class TaskDependenciesTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUsingTaskDependencies()
        {
            BatchController controller = BatchController.NewInstance;
            string jobId = "createTaskDependencieJob";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-CreateTask-using-td '{0}' '{1}'", ScenarioTestHelpers.MpiOnlineAccount, jobId) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, ScenarioTestHelpers.MpiOnlineAccount);
                    ScenarioTestHelpers.CreateTestJob(controller, context, jobId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteJob(controller, context, jobId);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}

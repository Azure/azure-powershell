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
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class UserTests
    {
        // NOTE: To save time on VM allocation when recording, these tests assume the following:
        //     - A Batch account named 'usertests' exists under the subscription being used for recording.
        //     - There is a pool named 'testPool' that has at least 1 vm allocated to it.

        private const string accountName = "usertests";
        private const string poolName = "testPool";
        private const string vmName = "tvm-1900272697_1-20150407t180708z"; // Run the following to get a vm name: (Get-AzureBatchVM "testPool" -BatchContext $context)[0].Name
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUser()
        {
            BatchController controller = BatchController.NewInstance;
            string userName = "testCreateUser";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-CreateUser '{0}' '{1}' '{2}' '{3}' 0", accountName, poolName, vmName, userName) }; },
                null,
                () =>
                {
                    BatchAccountContext context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.DeleteUser(controller, context, poolName, vmName, userName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUserPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string userName = "testCreateUserPipe";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-CreateUser '{0}' '{1}' '{2}' '{3}' 1", accountName, poolName, vmName, userName) }; },
                null,
                () =>
                {
                    BatchAccountContext context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.DeleteUser(controller, context, poolName, vmName, userName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteUser()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string userName = "testDeleteUser";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteUser '{0}' '{1}' '{2}' '{3}'", accountName, poolName, vmName, userName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    ScenarioTestHelpers.CreateTestUser(controller, context, poolName, vmName, userName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.New, "AzureBatchUser_ST")]
    public class NewBatchUserScenarioTestCommand : NewBatchUserCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Remove, "AzureBatchUser_ST")]
    public class RemoveBatchUserScenarioTestCommand : RemoveBatchUserCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

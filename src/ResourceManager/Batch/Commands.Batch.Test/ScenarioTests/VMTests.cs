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
    public class VMTests
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;
        private const string poolName = ScenarioTestHelpers.SharedPool;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMByName()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetVMByName '{0}' '{1}'", accountName, poolName));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string state = "idle";
            int matches = 0;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListVMsByFilter '{0}' '{1}' '{2}' '{3}'", accountName, poolName, state, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    matches = ScenarioTestHelpers.GetPoolCurrentDedicated(controller, context, poolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            int maxCount = 1;
            controller.RunPsTest(string.Format("Test-ListVMsWithMaxCount '{0}' '{1}' '{2}'", accountName, poolName, maxCount));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllVMs()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            int vmCount = 0;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllVMs '{0}' '{1}' '{2}'", accountName, poolName, vmCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    vmCount = ScenarioTestHelpers.GetPoolCurrentDedicated(controller, context, poolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListVMPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string state = "idle";
            int vmCount = 0;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListVMPipeline '{0}' '{1}' '{2}'", accountName, poolName, vmCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    vmCount = ScenarioTestHelpers.GetPoolCurrentDedicated(controller, context, poolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchVM_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchVMScenarioTestCommand : GetBatchVMCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

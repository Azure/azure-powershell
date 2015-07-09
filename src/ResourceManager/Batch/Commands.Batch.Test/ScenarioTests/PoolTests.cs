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
    public class PoolTests
    {
        private const string commonAccountName = ScenarioTestHelpers.SharedAccount;
        private const string testPoolName = ScenarioTestHelpers.SharedPool;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewPool()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-NewPool '{0}'", commonAccountName));

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetPoolByName()
        {
            BatchController controller = BatchController.NewInstance;
            string poolName = "testGetPool";
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-GetPoolByName '{0}' '{1}'", commonAccountName, poolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPoolsByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            string poolName1 = "testFilter1";
            string poolName2 = "testFilter2";
            string poolName3 = "thirdFilterTest";
            string poolPrefix = "testFilter";
            int matches = 2;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListPoolsByFilter '{0}' '{1}' '{2}'", commonAccountName, poolPrefix, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName1, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName2, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName3, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolName1);
                    ScenarioTestHelpers.DeletePool(controller, context, poolName2);
                    ScenarioTestHelpers.DeletePool(controller, context, poolName3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListPoolsWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            string poolName1 = "testMaxCount1";
            string poolName2 = "testMaxCount2";
            string poolName3 = "thirdMaxCount";
            int maxCount = 1;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListPoolsWithMaxCount '{0}' '{1}'", commonAccountName, maxCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName1, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName2, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName3, 0);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolName1);
                    ScenarioTestHelpers.DeletePool(controller, context, poolName2);
                    ScenarioTestHelpers.DeletePool(controller, context, poolName3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllPools()
        {
            BatchController controller = BatchController.NewInstance;
            string poolName1 = "testList1";
            string poolName2 = "testList2";
            string poolName3 = "thirdTestList";
            int beforeAddCount = 0;
            int afterAddCount = 0;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllPools '{0}' '{1}'", commonAccountName, afterAddCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    beforeAddCount = ScenarioTestHelpers.GetPoolCount(controller, context);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName1, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName2, 0);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName3, 0);
                    afterAddCount = beforeAddCount + 3;
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, poolName1);
                    ScenarioTestHelpers.DeletePool(controller, context, poolName2);
                    ScenarioTestHelpers.DeletePool(controller, context, poolName3);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeletePool()
        {
            BatchController controller = BatchController.NewInstance;
            string poolName = "testDelete";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeletePool '{0}' '{1}' '0'", commonAccountName, poolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName, 0);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeletePoolPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            string poolName = "testDeletePipe";

            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeletePool '{0}' '{1}' '1'", commonAccountName, poolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.CreateTestPool(controller, context, poolName, 0);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResizePoolByName()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ResizePoolByName '{0}' '{1}'", commonAccountName, testPoolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResizePoolByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ResizePoolByPipeline '{0}' '{1}'", commonAccountName, testPoolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopResizePoolByName()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-StopResizePoolByName '{0}' '{1}'", commonAccountName, testPoolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStopResizePoolByPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-StopResizePoolByPipeline '{0}' '{1}'", commonAccountName, testPoolName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, commonAccountName);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, testPoolName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchPool_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchPoolScenarioTestCommand : GetBatchPoolCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.New, "AzureBatchPool_ST", DefaultParameterSetName = TargetDedicatedParameterSet)]
    public class NewBatchPoolScenarioTestCommand : NewBatchPoolCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Remove, "AzureBatchPool_ST")]
    public class RemoveBatchPoolScenarioTestCommand : RemoveBatchPoolCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsLifecycle.Start, "AzureBatchPoolResize_ST")]
    public class StartBatchPoolResizeScenarioTestCommand : StartBatchPoolResizeCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsLifecycle.Stop, "AzureBatchPoolResize_ST")]
    public class StopBatchPoolResizeScenarioTestCommand : StopBatchPoolResizeCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

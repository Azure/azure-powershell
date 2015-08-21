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
    public class ComputeNodeTests
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;
        private const string poolId = ScenarioTestHelpers.SharedPool;

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetComputeNodeById()
        {
            BatchController controller = BatchController.NewInstance;
            controller.RunPsTest(string.Format("Test-GetComputeNodeById '{0}' '{1}'", accountName, poolId));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListComputeNodesByFilter()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string state = "idle";
            int matches = 0;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListComputeNodesByFilter '{0}' '{1}' '{2}' '{3}'", accountName, poolId, state, matches) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    matches = ScenarioTestHelpers.GetPoolCurrentDedicated(controller, context, poolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListComputeNodesWithMaxCount()
        {
            BatchController controller = BatchController.NewInstance;
            int maxCount = 1;
            controller.RunPsTest(string.Format("Test-ListComputeNodesWithMaxCount '{0}' '{1}' '{2}'", accountName, poolId, maxCount));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListAllComputeNodes()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            int computeNodeCount = 0;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListAllComputeNodes '{0}' '{1}' '{2}'", accountName, poolId, computeNodeCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeCount = ScenarioTestHelpers.GetPoolCurrentDedicated(controller, context, poolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListComputeNodePipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            int computeNodeCount = 0;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ListComputeNodePipeline '{0}' '{1}' '{2}'", accountName, poolId, computeNodeCount) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeCount = ScenarioTestHelpers.GetPoolCurrentDedicated(controller, context, poolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRebootComputeNodeById()
        {
            TestRebootComputeNode(false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRebootComputeNodePipeline()
        {
            TestRebootComputeNode(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestReimageComputeNodeById()
        {
            TestReimageComputeNode(false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestReimageComputeNodePipeline()
        {
            TestReimageComputeNode(true);
        }

        private void TestRebootComputeNode(bool usePipeline)
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-RebootComputeNode '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, usePipeline ? 1 : 0) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                    ScenarioTestHelpers.WaitForIdleComputeNode(controller, context, poolId, computeNodeId);
                },
                null,
                TestUtilities.GetCallingClass(),
                usePipeline ? "TestRebootComputeNodePipeline" : "TestRebootComputeNodeById");
        }

        private void TestReimageComputeNode(bool usePipeline)
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-ReimageComputeNode '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, usePipeline ? 1 : 0) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                    ScenarioTestHelpers.WaitForIdleComputeNode(controller, context, poolId, computeNodeId);
                },
                null,
                TestUtilities.GetCallingClass(),
                usePipeline ? "TestReimageComputeNodePipeline" : "TestReimageComputeNodeById");
        }
    }

    // Cmdlets that use the HTTP Recorder interceptor for use with scenario tests
    [Cmdlet(VerbsCommon.Get, "AzureBatchComputeNode_ST", DefaultParameterSetName = Constants.ODataFilterParameterSet)]
    public class GetBatchComputeNodeScenarioTestCommand : GetBatchComputeNodeCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsLifecycle.Restart, "AzureBatchComputeNode_ST", DefaultParameterSetName = Constants.IdParameterSet)]
    public class RestartBatchComputeNodeScenarioTestCommand : RestartBatchComputeNodeCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }

    [Cmdlet(VerbsCommon.Reset, "AzureBatchComputeNode_ST", DefaultParameterSetName = Constants.IdParameterSet)]
    public class ResetBatchComputeNodeScenarioTestCommand : ResetBatchComputeNodeCommand
    {
        public override void ExecuteCmdlet()
        {
            AdditionalBehaviors = new List<BatchClientBehavior>() { ScenarioTestHelpers.CreateHttpRecordingInterceptor() };
            base.ExecuteCmdlet();
        }
    }
}

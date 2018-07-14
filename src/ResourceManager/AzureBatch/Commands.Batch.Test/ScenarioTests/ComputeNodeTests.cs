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

using System.Reflection;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.Azure.ServiceManagemenet.Common.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class ComputeNodeTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string poolId = ScenarioTestHelpers.SharedPool;
        private const string iaasPoolId = ScenarioTestHelpers.SharedIaasPool;
        public XunitTracingInterceptor _logger;

        public ComputeNodeTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveComputeNodes()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string removeNodePoolId = "removenodepool";
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-RemoveComputeNodes '{0}'", removeNodePoolId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    ScenarioTestHelpers.CreateTestPool(controller, context, removeNodePoolId, targetDedicated: 2, targetLowPriority: 0);
                    ScenarioTestHelpers.WaitForSteadyPoolAllocation(controller, context, removeNodePoolId);
                },
                () =>
                {
                    ScenarioTestHelpers.DeletePool(controller, context, removeNodePoolId);
                },
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRebootAndReimageComputeNode()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string computeNodeId2 = null;
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-RebootAndReimageComputeNode '{0}' '{1}' '{2}'", poolId, computeNodeId, computeNodeId2) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId, 0);
                    computeNodeId2 = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId, 1);
                    ScenarioTestHelpers.WaitForIdleComputeNode(controller, context, poolId, computeNodeId);
                    ScenarioTestHelpers.WaitForIdleComputeNode(controller, context, poolId, computeNodeId2);
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDisableAndEnableComputeNodeScheduling()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-DisableAndEnableComputeNodeScheduling '{0}' '{1}'", poolId, computeNodeId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                    ScenarioTestHelpers.WaitForIdleComputeNode(controller, context, poolId, computeNodeId);
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetComputeNodeRemoteLoginSettings()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;

            controller.RunPsTestWorkflow(
                _logger,
                () => { return new string[] { string.Format("Test-GetRemoteLoginSettings '{0}' '{1}'", iaasPoolId, computeNodeId) }; },
                () =>
                {
                    context = new ScenarioTestContext();
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, iaasPoolId);
                },
                null,
                MethodBase.GetCurrentMethod().ReflectedType?.ToString(),
                MethodBase.GetCurrentMethod().Name);
        }
    }
}

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

using System;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Test.ScenarioTests
{
    public class ComputeNodeUserTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private const string accountName = ScenarioTestHelpers.SharedAccount;
        private const string poolId = ScenarioTestHelpers.SharedPool;
        
        [Fact]
        public void TestCreateComputeNodeUser()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string userName = "createuser";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-CreateComputeNodeUser '{0}' '{1}' '{2}' '{3}' 0", accountName, poolId, computeNodeId, userName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateComputeNodeUserPipeline()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string userName = "createuser2";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-CreateComputeNodeUser '{0}' '{1}' '{2}' '{3}' 1", accountName, poolId, computeNodeId, userName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());

        }

        [Fact]
        public void TestUpdateComputeNodeUser()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string userName = "updateuser";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-UpdateComputeNodeUser '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, userName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                    ScenarioTestHelpers.CreateComputeNodeUser(controller, context, poolId, computeNodeId, userName);
                },
                () =>
                {
                    ScenarioTestHelpers.DeleteComputeNodeUser(controller, context, poolId, computeNodeId, userName);
                },
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteComputeNodeUser()
        {
            BatchController controller = BatchController.NewInstance;
            BatchAccountContext context = null;
            string computeNodeId = null;
            string userName = "deleteuser";
            controller.RunPsTestWorkflow(
                () => { return new string[] { string.Format("Test-DeleteComputeNodeUser '{0}' '{1}' '{2}' '{3}'", accountName, poolId, computeNodeId, userName) }; },
                () =>
                {
                    context = ScenarioTestHelpers.GetBatchAccountContextWithKeys(controller, accountName);
                    computeNodeId = ScenarioTestHelpers.GetComputeNodeId(controller, context, poolId);
                    ScenarioTestHelpers.CreateComputeNodeUser(controller, context, poolId, computeNodeId, userName);
                },
                null,
                TestUtilities.GetCallingClass(),
                TestUtilities.GetCurrentMethodName());
        }
    }
}

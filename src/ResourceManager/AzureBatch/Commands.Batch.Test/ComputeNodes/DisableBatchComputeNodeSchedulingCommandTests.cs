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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.BatchRequests;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using BatchCommon = Microsoft.Azure.Batch.Common;

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodes
{
    public class DisableBatchComputeNodeSchedulingCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private DisableBatchComputeNodeSchedulingCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public DisableBatchComputeNodeSchedulingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new DisableBatchComputeNodeSchedulingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableComputeNodeSchedulingParametersTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = null;
            cmdlet.Id = null;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.PoolId = "testPool";
            cmdlet.Id = "computeNode01";

            // Don't go to the service on an Disable Compute Node Scheduling call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                DisableComputeNodeSchedulingOption?,
                ComputeNodeDisableSchedulingOptions,
                AzureOperationHeaderResponse<ComputeNodeDisableSchedulingHeaders>>();
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableComputeNodeSchedulingRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            BatchCommon.DisableComputeNodeSchedulingOption? disableOption = BatchCommon.DisableComputeNodeSchedulingOption.TaskCompletion;
            BatchCommon.DisableComputeNodeSchedulingOption? requestDisableOption = null;

            cmdlet.PoolId = "testPool";
            cmdlet.Id = "computeNode1";
            cmdlet.DisableSchedulingOption = disableOption;

            // Don't go to the service on an Disable Compute Node Scheduling call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                ComputeNodeDisableSchedulingBatchRequest request = (ComputeNodeDisableSchedulingBatchRequest)baseRequest;

                requestDisableOption = BatchTestHelpers.MapEnum<BatchCommon.DisableComputeNodeSchedulingOption>(request.Parameters);

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    var response = new AzureOperationHeaderResponse<ComputeNodeDisableSchedulingHeaders>();
                    Task<AzureOperationHeaderResponse<ComputeNodeDisableSchedulingHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            cmdlet.ExecuteCmdlet();

            // Verify that the parameters were properly set on the outgoing request
            Assert.Equal(disableOption, requestDisableOption);
        }
    }
}

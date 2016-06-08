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

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class RestartBatchComputeNodeCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private RestartBatchComputeNodeCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public RestartBatchComputeNodeCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RestartBatchComputeNodeCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartBatchComputeNodeParametersTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.PoolId = "testPool";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "computeNode1";

            // Don't go to the service on a Reboot ComputeNode call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ComputeNodeRebootOption?,
                ComputeNodeRebootOptions,
                AzureOperationHeaderResponse<ComputeNodeRebootHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RestartComputeNodeRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.PoolId = "testPool";
            cmdlet.Id = "computeNode1";
            cmdlet.RebootOption = BatchCommon.ComputeNodeRebootOption.Terminate;

            ComputeNodeRebootOption? requestRebootOption = null;

            // Don't go to the service on a Reboot ComputeNode call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                ComputeNodeRebootBatchRequest request = (ComputeNodeRebootBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    // Grab the reboot option from the outgoing request.
                    requestRebootOption = request.Parameters;

                    var response = new AzureOperationHeaderResponse<ComputeNodeRebootHeaders>();
                    Task<AzureOperationHeaderResponse<ComputeNodeRebootHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            cmdlet.ExecuteCmdlet();

            // Verify that the reboot option was properly set on the outgoing request
            Assert.Equal(cmdlet.RebootOption, BatchTestHelpers.MapEnum<BatchCommon.ComputeNodeRebootOption>(requestRebootOption));
        }
    }
}

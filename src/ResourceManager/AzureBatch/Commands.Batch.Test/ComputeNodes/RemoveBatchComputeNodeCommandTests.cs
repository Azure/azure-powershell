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

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class RemoveBatchComputeNodeCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private RemoveBatchComputeNodeCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public RemoveBatchComputeNodeCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveBatchComputeNodeCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveBatchComputeNodeParametersTest()
        {
            // Setup cmdlet to skip confirmation popup
            cmdlet.Force = true;
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Ids = null;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.PoolId = "testPool";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Ids = new string[] { "computeNode1" };

            // Don't go to the service on a Remove ComputeNode call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                NodeRemoveParameter,
                PoolRemoveNodesOptions,
                AzureOperationHeaderResponse<PoolRemoveNodesHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveComputeNodeRequestTest()
        {
            // Setup cmdlet to skip confirmation popup
            cmdlet.Force = true;
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.PoolId = "testPool";
            cmdlet.Ids = new string[] { "computeNode1", "computeNode2" };
            cmdlet.DeallocationOption = Microsoft.Azure.Batch.Common.ComputeNodeDeallocationOption.Terminate;
            cmdlet.ResizeTimeout = TimeSpan.FromMinutes(8);

            Microsoft.Azure.Batch.Common.ComputeNodeDeallocationOption? requestDeallocationOption = null;
            TimeSpan? requestResizeTimeout = null;
            IList<string> requestComputeNodeIds = null;

            // Don't go to the service on a Remove ComputeNode call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                PoolRemoveNodesBatchRequest request = (PoolRemoveNodesBatchRequest)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    // Grab the parameters from the outgoing request.
                    requestDeallocationOption = BatchTestHelpers.MapEnum<Microsoft.Azure.Batch.Common.ComputeNodeDeallocationOption>(request.Parameters.NodeDeallocationOption);
                    requestResizeTimeout = request.Parameters.ResizeTimeout;
                    requestComputeNodeIds = request.Parameters.NodeList;

                    var response = new AzureOperationHeaderResponse<PoolRemoveNodesHeaders>();
                    Task<AzureOperationHeaderResponse<PoolRemoveNodesHeaders>> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            cmdlet.ExecuteCmdlet();

            // Verify that the parameters were properly set on the outgoing request
            Assert.Equal(cmdlet.DeallocationOption, requestDeallocationOption);
            Assert.Equal(cmdlet.ResizeTimeout, requestResizeTimeout);
            Assert.Equal(cmdlet.Ids.Length, requestComputeNodeIds.Count);
            foreach (string id in cmdlet.Ids)
            {
                Assert.True(requestComputeNodeIds.Contains(id));
            }
        }
    }
}

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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodes
{
    public class GetBatchComputeNodeCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchComputeNodeCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchComputeNodeCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchComputeNodeCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchComputeNodeTest()
        {
            // Setup cmdlet to get a compute node by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "pool";
            cmdlet.Id = "computeNode1";
            cmdlet.Filter = null;

            // Build a compute node instead of querying the service on a Get ComputeNode call
            AzureOperationResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeGetHeaders> response = BatchTestHelpers.CreateComputeNodeGetResponse(cmdlet.Id);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeGetOptions,
                AzureOperationResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeGetHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSComputeNode> pipeline = new List<PSComputeNode>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSComputeNode>())).Callback<object>(c => pipeline.Add((PSComputeNode)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the compute node returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Id, pipeline[0].Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchComputeNodeODataTest()
        {
            // Setup cmdlet to get a single compute node
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.Id = "computeNode1";
            cmdlet.Select = "id,state";

            string requestSelect = null;

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            AzureOperationResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeGetHeaders> getResponse = BatchTestHelpers.CreateComputeNodeGetResponse(cmdlet.Id);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeGetOptions,
                AzureOperationResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeGetHeaders>>(getResponse);

            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.ComputeNodeGetOptions computeNodeOptions = (ProxyModels.ComputeNodeGetOptions)request.Options;
                requestSelect = computeNodeOptions.Select;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Select, requestSelect);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchComputeNodesODataTest()
        {
            // Setup cmdlet to list compute nodes using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.Id = null;
            cmdlet.Filter = "startswith(id,'test')";
            cmdlet.Select = "id,state";

            string requestFilter = null;
            string requestSelect = null;

            AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders> response =
                BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.ComputeNode, ProxyModels.ComputeNodeListHeaders>();

            Action<BatchRequest<ProxyModels.ComputeNodeListOptions, AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders>>> listComputeNodeAction =
                (request) =>
                {
                    ProxyModels.ComputeNodeListOptions options = (ProxyModels.ComputeNodeListOptions)request.Options;

                    requestFilter = options.Filter;
                    requestSelect = options.Select;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.ComputeNodeListOptions, AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders>>(response, listComputeNodeAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
            Assert.Equal(cmdlet.Select, requestSelect);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchComputeNodesWithoutFiltersTest()
        {
            // Setup cmdlet to list compute nodes without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.Id = null;
            cmdlet.Filter = null;

            string[] idsOfConstructedComputeNodes = new[] { "computeNode1", "computeNode2", "computeNode3" };

            // Build some compute nodes instead of querying the service on a List ComputeNodes call
            AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders> response =
                BatchTestHelpers.CreateComputeNodeListResponse(idsOfConstructedComputeNodes);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeListOptions,
                AzureOperationResponse<IPage<ProxyModels.ComputeNode>,
                ProxyModels.ComputeNodeListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSComputeNode> pipeline = new List<PSComputeNode>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSComputeNode>()))
                .Callback<object>(c => pipeline.Add((PSComputeNode)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed compute nodes to the pipeline
            Assert.Equal(3, pipeline.Count);
            int computeNodeCount = 0;
            foreach (PSComputeNode c in pipeline)
            {
                Assert.True(idsOfConstructedComputeNodes.Contains(c.Id));
                computeNodeCount++;
            }
            Assert.Equal(idsOfConstructedComputeNodes.Length, computeNodeCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListComputeNodesMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list compute nodes without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.Id = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] idsOfConstructedComputeNodes = new[] { "computeNode1", "computeNode2", "computeNode3" };

            // Build some compute nodes instead of querying the service on a List ComputeNodes call
            AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders> response = BatchTestHelpers.CreateComputeNodeListResponse(idsOfConstructedComputeNodes);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.ComputeNodeListOptions,
                AzureOperationResponse<IPage<ProxyModels.ComputeNode>, ProxyModels.ComputeNodeListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSComputeNode> pipeline = new List<PSComputeNode>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSComputeNode>()))
                .Callback<object>(c => pipeline.Add((PSComputeNode)c));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(idsOfConstructedComputeNodes.Length, pipeline.Count);
        }
    }
}

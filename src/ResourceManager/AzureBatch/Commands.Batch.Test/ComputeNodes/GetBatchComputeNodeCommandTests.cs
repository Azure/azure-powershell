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
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodes
{
    public class GetBatchComputeNodeCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchComputeNodeCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchComputeNodeCommandTests()
        {
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
            ComputeNodeGetResponse response = BatchTestHelpers.CreateComputeNodeGetResponse(cmdlet.Id);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ComputeNodeGetParameters, ComputeNodeGetResponse>(response);
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
            ComputeNodeGetResponse getResponse = BatchTestHelpers.CreateComputeNodeGetResponse(cmdlet.Id);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ComputeNodeGetParameters, ComputeNodeGetResponse>(getResponse);
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                requestSelect = request.Parameters.DetailLevel.SelectClause;

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

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ComputeNodeListParameters, ComputeNodeListResponse>();
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                requestFilter = request.Parameters.DetailLevel.FilterClause;
                requestSelect = request.Parameters.DetailLevel.SelectClause;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

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
            ComputeNodeListResponse response = BatchTestHelpers.CreateComputeNodeListResponse(idsOfConstructedComputeNodes);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ComputeNodeListParameters, ComputeNodeListResponse>(response);
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
            ComputeNodeListResponse response = BatchTestHelpers.CreateComputeNodeListResponse(idsOfConstructedComputeNodes);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ComputeNodeListParameters, ComputeNodeListResponse>(response);
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

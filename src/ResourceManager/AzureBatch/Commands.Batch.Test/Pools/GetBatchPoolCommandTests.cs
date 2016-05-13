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

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class GetBatchPoolCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchPoolCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPoolCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPoolCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPoolTest()
        {
            // Setup cmdlet to get a pool by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "testPool";
            cmdlet.Filter = null;

            // Build a CloudPool instead of querying the service on a Get CloudPool call
            AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders> response = BatchTestHelpers.CreateCloudPoolGetResponse(cmdlet.Id);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolGetOptions,
                AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudPool> pipeline = new List<PSCloudPool>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSCloudPool>())).Callback<object>(p => pipeline.Add((PSCloudPool)p));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the pool returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Id, pipeline[0].Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPoolODataTest()
        {
            // Setup cmdlet to get a single pool
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = "testPool";
            cmdlet.Select = "id,state";
            cmdlet.Expand = "stats";

            string requestSelect = null;
            string requestExpand = null;

            // Fetch the OData clauses off the request. The OData clauses are applied after user provided RequestInterceptors, so a ResponseInterceptor is used.
            AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders> getResponse = BatchTestHelpers.CreateCloudPoolGetResponse(cmdlet.Id);
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolGetOptions,
                AzureOperationResponse<ProxyModels.CloudPool, ProxyModels.PoolGetHeaders>>(getResponse);

            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.PoolGetOptions options = (ProxyModels.PoolGetOptions)request.Options;
                requestSelect = options.Select;
                requestExpand = options.Expand;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Select, requestSelect);
            Assert.Equal(cmdlet.Expand, requestExpand);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchPoolsODataTest()
        {
            // Setup cmdlet to list pools using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = "startswith(id,'test')";
            cmdlet.Select = "id,state";
            cmdlet.Expand = "stats";

            string requestFilter = null;
            string requestSelect = null;
            string requestExpand = null;

            AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders> response = BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.CloudPool, ProxyModels.PoolListHeaders>();
            Action<BatchRequest<ProxyModels.PoolListOptions, AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders>>> extractPoolListAction =
                (request) =>
                {
                    ProxyModels.PoolListOptions options = request.Options;
                    requestFilter = options.Filter;
                    requestSelect = options.Select;
                    requestExpand = options.Expand;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(responseToUse: response, requestAction: extractPoolListAction);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
            Assert.Equal(cmdlet.Select, requestSelect);
            Assert.Equal(cmdlet.Expand, requestExpand);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchPoolWithoutFiltersTest()
        {
            // Setup cmdlet to list pools without filters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = null;

            string[] idsOfConstructedPools = new[] { "pool1", "pool2", "pool3" };

            // Build some CloudPools instead of querying the service on a List CloudPools call
            AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders> response = BatchTestHelpers.CreateCloudPoolListResponse(idsOfConstructedPools);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudPool> pipeline = new List<PSCloudPool>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudPool>()))
                .Callback<object>(p => pipeline.Add((PSCloudPool)p));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed pools to the pipeline
            Assert.Equal(3, pipeline.Count);
            int poolCount = 0;
            foreach (PSCloudPool p in pipeline)
            {
                Assert.True(idsOfConstructedPools.Contains(p.Id));
                poolCount++;
            }
            Assert.Equal(idsOfConstructedPools.Length, poolCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListPoolsMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list pools without filters and a max count
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] idsOfConstructedPools = new[] { "pool1", "pool2", "pool3" };

            // Build some CloudPools instead of querying the service on a List CloudPools call
            AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders> response = BatchTestHelpers.CreateCloudPoolListResponse(idsOfConstructedPools);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudPool>, ProxyModels.PoolListHeaders>>(response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudPool> pipeline = new List<PSCloudPool>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudPool>()))
                .Callback<object>(p => pipeline.Add((PSCloudPool)p));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(idsOfConstructedPools.Length, pipeline.Count);
        }
    }
}

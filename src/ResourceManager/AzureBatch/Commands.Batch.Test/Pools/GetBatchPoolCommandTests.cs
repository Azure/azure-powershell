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

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class GetBatchPoolCommandTests
    {
        private GetBatchPoolCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPoolCommandTests()
        {
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
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudPoolGetParameters, CloudPoolGetResponse> request =
                (BatchRequest<CloudPoolGetParameters, CloudPoolGetResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudPoolGetResponse response = BatchTestHelpers.CreateCloudPoolGetResponse(cmdlet.Id);
                    Task<CloudPoolGetResponse> task = Task.FromResult(response);
                    return task;
                };
            });
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
        public void ListBatchPoolByODataFilterTest()
        {
            // Setup cmdlet to list pools using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = "startswith(id,'test')";

            string[] idsOfConstructedPools = new[] { "test1", "test2" };

            // Build some CloudPools instead of querying the service on a List CloudPools call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudPoolListParameters, CloudPoolListResponse> request =
                (BatchRequest<CloudPoolListParameters, CloudPoolListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudPoolListResponse response = BatchTestHelpers.CreateCloudPoolListResponse(idsOfConstructedPools);
                    Task<CloudPoolListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSCloudPool> pipeline = new List<PSCloudPool>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSCloudPool>()))
                .Callback<object>(p => pipeline.Add((PSCloudPool)p));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed pools to the pipeline
            Assert.Equal(2, pipeline.Count);
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
        public void ListBatchPoolWithoutFiltersTest()
        {
            // Setup cmdlet to list pools without filters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;
            cmdlet.Filter = null;

            string[] idsOfConstructedPools = new[] { "pool1", "pool2", "pool3" };

            // Build some CloudPools instead of querying the service on a List CloudPools call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudPoolListParameters, CloudPoolListResponse> request =
                (BatchRequest<CloudPoolListParameters, CloudPoolListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudPoolListResponse response = BatchTestHelpers.CreateCloudPoolListResponse(idsOfConstructedPools);
                    Task<CloudPoolListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
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
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudPoolListParameters, CloudPoolListResponse> request =
                (BatchRequest<CloudPoolListParameters, CloudPoolListResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudPoolListResponse response = BatchTestHelpers.CreateCloudPoolListResponse(idsOfConstructedPools);
                    Task<CloudPoolListResponse> task = Task.FromResult(response);
                    return task;
                };
            });
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
